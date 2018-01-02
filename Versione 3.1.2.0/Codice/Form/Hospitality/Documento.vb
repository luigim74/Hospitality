﻿Imports Elegant.Ui

Public Class frmDocumento

   Const ANA_CLIENTI As String = "Clienti"
   Const ANA_AZIENDE As String = "Aziende"
   Const TAB_DOCUMENTI As String = "Documenti"
   Const TAB_DETTAGLI_DOCUMENTI As String = "DettagliDoc"
   Const TAB_TIPO_DOCUMENTI As String = "TipoDoc"
   Const TAB_CAUSALI_DOCUMENTI As String = "CausaliDocumento"
   Const TAB_TIPO_PAGAMENTO As String = "ModPagamento"

   Const TIPO_DOC_RF As String = "Ricevuta Fiscale"
   Const TIPO_DOC_FF As String = "Fattura"
   Const TIPO_DOC_SF As String = "Scontrino"
   Const TIPO_DOC_PF As String = "Proforma"
   Const TIPO_DOC_CO As String = "Conto"

   Private idDocumento As String
   Private tipoDocumento As String
   Private nomeFinestra As String

   Private Doc As New Documenti
   Private CFormatta As New ClsFormatta
   Private CConvalida As New ConvalidaKeyPress
   Private DatiConfig As AppConfig

   ' Dichiara un oggetto connessione.
   Dim cn As New OleDbConnection(ConnString)
   ' Dichiara un oggetto transazione.
   Dim tr As OleDbTransaction
   Dim cmd As New OleDbCommand(sql, cn)
   Dim ds As New DataSet
   ' Numero di record.
   Dim numRecord As Integer
   Dim sql As String


   ''' <summary>
   ''' Apre il documento da eleborare.
   ''' </summary>
   ''' <param name="nomeWnd">Nome della finestra che richiama il metodo.</param>
   ''' <param name="documento">Il tipo di documento da aprire.</param>
   ''' <param name="id">Il codice del documento da aprire.</param>
   Public Sub New(ByVal nomeWnd As String, ByVal documento As String, ByVal id As String)

      ' Chiamata richiesta dalla finestra di progettazione.
      InitializeComponent()

      idDocumento = id
      tipoDocumento = documento
      nomeFinestra = nomeWnd

      Me.Tag = id

      ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().

   End Sub

   Public Function LeggiNumeroMax(ByVal tabella As String, ByVal tipoDoc As String) As Integer
      Dim closeOnExit As Boolean
      Dim numRec As Integer

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Ottiene il numero di record.
         'cmd.CommandText = String.Format("SELECT MAX(NumDoc) FROM {0} WHERE TipoDoc = '{1}'", tabella, tipoDoc)

         ' Ottiene i dati per l'anno corrente.
         Dim Anno As String = Year(Now)
         Dim primoGiornoAnno As String = CFormatta.FormattaData("01/01/" & Anno)
         Dim numUltimoGiornoAnno As String = DateTime.DaysInMonth(Anno, 12)
         Dim ultimoGiornoAnno As String = CFormatta.FormattaData(numUltimoGiornoAnno & "/12/" & Anno)

         cmd.CommandText = String.Format("SELECT MAX(NumDoc) FROM {0} WHERE TipoDoc = '{1}' AND DataDoc BETWEEN #{2}# AND #{3}#", tabella, tipoDoc, primoGiornoAnno, ultimoGiornoAnno)

         If IsDBNull(cmd.ExecuteScalar()) = False Then
            numRec = CInt(cmd.ExecuteScalar())
         Else
            numRec = 0
         End If

         Return numRec

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Function

   Public Function LeggiNumeroDocFiscaleConfig(ByVal tabella As String, ByVal tipoDoc As String) As Integer
      Try
         Dim DatiConfig As AppConfig
         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig

         Dim chiaveConfig As String = String.Empty
         Select Case tipoDoc
            Case TIPO_DOC_FF
               chiaveConfig = "NumeroFattura"

            Case TIPO_DOC_RF
               chiaveConfig = "NumeroRicevuta"

            Case TIPO_DOC_PF
               chiaveConfig = "NumeroProforma"

         End Select

         If IsNumeric(DatiConfig.GetValue(chiaveConfig)) = False Then
            ' Legge dal database.
            Dim num As Integer = LeggiNumeroMax(tabella, tipoDoc)
            If num = 0 Then
               Return 1
            Else
               Return num
            End If
         Else
            ' Legge dal file di configurazione.
            Return Convert.ToInt32(DatiConfig.GetValue(chiaveConfig))
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Function

   Private Sub SalvaNumeroDocFiscaleConfig(ByVal tabella As String, ByVal tipoDoc As String, ByVal numDoc As Integer)
      Try
         Dim DatiConfig As AppConfig
         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig

         Dim chiaveConfig As String
         Select Case tipoDoc
            Case TIPO_DOC_FF
               chiaveConfig = "NumeroFattura"

            Case TIPO_DOC_RF
               chiaveConfig = "NumeroRicevuta"

            Case TIPO_DOC_PF
               chiaveConfig = "NumeroProforma"

         End Select

         DatiConfig.SetValue(chiaveConfig, (numDoc + 1).ToString)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   ''' <summary>
   ''' Crea un nuovo documento.
   ''' </summary>
   Private Sub NuovoDocumento()
      Try
         ' Assegna il tipo del documento al titolo della finestra.
         Me.Text = tipoDocumento

         ' SHEDA GENERALE.
         Dim NumeroDocumento As Integer

         Select Case tipoDocumento
            Case TIPO_DOC_CO, TIPO_DOC_PF
               NumeroDocumento = LeggiNumeroMax(TAB_DOCUMENTI, tipoDocumento)

            Case TIPO_DOC_RF, TIPO_DOC_FF
               NumeroDocumento = LeggiNumeroDocFiscaleConfig(TAB_DOCUMENTI, tipoDocumento)

            Case TIPO_DOC_SF
               NumeroDocumento = LeggiNumeroMax(TAB_DOCUMENTI, tipoDocumento)

         End Select

         eui_txtNumero.Text = NumeroDocumento.ToString
         eui_txtAnno.Text = Today.Year.ToString
         eui_dtpData.Text = Today.ToString
         eui_txtOra.Text = TimeOfDay.Hour.ToString & ":" & TimeOfDay.Minute.ToString
         eui_cmbTipoDocumento.Text = tipoDocumento

         eui_cmbStatoDocumento.Text = "Bozza"
         eui_cmbCausaleDocumento.Text = "Vendita"

         eui_txtImponibile.Text = VALORE_ZERO
         eui_txtImposta.Text = VALORE_ZERO
         eui_txtTotaleDocumento.Text = VALORE_ZERO

         ' SHEDA DETTAGLI.

         ' SHEDA TOTALI.
         eui_txtTotaliRep1ImponibileLordo.Text = VALORE_ZERO
         eui_txtTotaliRep2ImponibileLordo.Text = VALORE_ZERO
         eui_txtTotaliRep3ImponibileLordo.Text = VALORE_ZERO
         eui_txtTotaliRep4ImponibileLordo.Text = VALORE_ZERO

         eui_txtTotaliRep1Aliquota.Text = VALORE_ZERO
         eui_txtTotaliRep2Aliquota.Text = VALORE_ZERO
         eui_txtTotaliRep3Aliquota.Text = VALORE_ZERO
         eui_txtTotaliRep4Aliquota.Text = VALORE_ZERO

         eui_txtTotaliRep1Imposta.Text = VALORE_ZERO
         eui_txtTotaliRep2Imposta.Text = VALORE_ZERO
         eui_txtTotaliRep3Imposta.Text = VALORE_ZERO
         eui_txtTotaliRep4Imposta.Text = VALORE_ZERO

         eui_txtTotaliSconto.Text = VALORE_ZERO
         eui_txtTotaliServizio.Text = VALORE_ZERO
         eui_txtTotaliCoperto.Text = VALORE_ZERO

         eui_txtTotaliContanti.Text = VALORE_ZERO
         eui_txtTotaliCarte.Text = VALORE_ZERO
         eui_txtTotaliBuoni.Text = VALORE_ZERO
         eui_txtTotaliSospeso.Text = VALORE_ZERO

         eui_txtTotaliImponibile.Text = VALORE_ZERO
         eui_txtTotaleImposta.Text = VALORE_ZERO
         eui_txtTotaleConto.Text = VALORE_ZERO

         ' SCHEDA NOTE.
         eui_txtNote.Text = String.Empty

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   ''' <summary>
   ''' Modifica i dati del documento selezionato.
   ''' </summary>
   Private Sub ModificaDocumento()
      Try
         With Doc
            ' Visualizza i dati nei rispettivi campi.
            .LeggiDati(TAB_DOCUMENTI, idDocumento)

            ' Assegna il tipo del documento al titolo della finestra.
            Me.Text = .Tipo

            ' Assegna i dati dei campi della classe alle caselle di testo.

            ' DETTAGLI.
            InserisciDettagliRiga(TAB_DETTAGLI_DOCUMENTI, Convert.ToInt32(idDocumento))

            ' DOCUMENTO.
            eui_txtNumero.Text = .Numero
            eui_cmbTipoDocumento.Text = .Tipo
            eui_txtAnno.Text = .Anno
            eui_dtpData.Value = .Data
            eui_txtOra.Text = .Ora
            eui_cmbStatoDocumento.Text = .Stato
            eui_cmbCausaleDocumento.Text = .Causale

            ' CLIENTE.
            eui_txtIdCliente.Text = .IdCliente
            eui_cmbClienteCognome.Text = .Cliente
            eui_txtIndirizzo.Text = .Indirizzo
            eui_txtCap.Text = .Cap
            eui_txtCittà.Text = .Città
            eui_txtProvincia.Text = .Provincia
            eui_txtPartitaIva.Text = .PIva
            eui_txtCodiceFiscale.Text = .CodFiscale

            ' DOCUMENTO.
            'eui_txtTotaliSconto.Text = .Sconto
            eui_txtTotaliContanti.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.Contanti))
            eui_txtTotaliCarte.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.Carte))
            eui_txtTotaliBuoni.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.BuoniPasto))

            eui_cmbTipoPagamento.Text = .TipoPagamento
            eui_txtTavolo.Text = .Tavolo
            eui_txtCameriere.Text = .Cameriere
            eui_txtTotaliSospeso.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.Sospeso))
            eui_txtTotaliImponibile.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.Imponibile))
            eui_txtTotaleImposta.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.Imposta))
            eui_txtTotaleConto.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.TotDoc))
            eui_txtTotaleDocumento.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.TotDoc))

            ' TOTALI.

            ' DA_FARE_A: Valutare se salvare l'iva anche per le ricevute.
            ' Se fattura salva l'iva...
            If eui_cmbTipoDocumento.Text = TIPO_DOC_FF Then
               eui_txtTotaliRep1ImponibileLordo.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.ImpLordoRep1))
               eui_txtTotaliRep2ImponibileLordo.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.ImpLordoRep2))
               eui_txtTotaliRep3ImponibileLordo.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.ImpLordoRep3))
               eui_txtTotaliRep4ImponibileLordo.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.ImpLordoRep4))

               eui_txtTotaliRep1Aliquota.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.AliquotaIvaRep1))
               eui_txtTotaliRep2Aliquota.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.AliquotaIvaRep2))
               eui_txtTotaliRep3Aliquota.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.AliquotaIvaRep3))
               eui_txtTotaliRep4Aliquota.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.AliquotaIvaRep4))

               eui_txtTotaliRep1Imposta.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.ImpostaRep1))
               eui_txtTotaliRep2Imposta.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.ImpostaRep2))
               eui_txtTotaliRep3Imposta.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.ImpostaRep3))
               eui_txtTotaliRep4Imposta.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.ImpostaRep4))

               eui_txtImponibile.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.Imponibile))
               eui_txtImposta.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.Imposta))
            Else
               eui_txtTotaliRep1ImponibileLordo.Text = VALORE_ZERO
               eui_txtTotaliRep2ImponibileLordo.Text = VALORE_ZERO
               eui_txtTotaliRep3ImponibileLordo.Text = VALORE_ZERO
               eui_txtTotaliRep4ImponibileLordo.Text = VALORE_ZERO

               eui_txtTotaliRep1Aliquota.Text = VALORE_ZERO
               eui_txtTotaliRep2Aliquota.Text = VALORE_ZERO
               eui_txtTotaliRep3Aliquota.Text = VALORE_ZERO
               eui_txtTotaliRep4Aliquota.Text = VALORE_ZERO

               eui_txtTotaliRep1Imposta.Text = VALORE_ZERO
               eui_txtTotaliRep2Imposta.Text = VALORE_ZERO
               eui_txtTotaliRep3Imposta.Text = VALORE_ZERO
               eui_txtTotaliRep4Imposta.Text = VALORE_ZERO

               eui_txtImponibile.Text = VALORE_ZERO
               eui_txtImposta.Text = VALORE_ZERO
            End If

            ' NOTE.
            eui_txtNote.Text = .Note

         End With

      Catch ex As Exception

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub InserisciDettagliRiga(ByVal tabella As String, ByVal id As Integer)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim strDescrizione As String
      Dim QTA As Integer = 1

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE RifDoc = " & id & " ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()

            eui_cmdNuovaRiga.PerformClick()

            ' Codice.
            If IsDBNull(dr.Item("CodiceArticolo")) = False Then
               dgvDettagli.CurrentRow.Cells(clnCodice.Name).Value = dr.Item("CodiceArticolo")
            Else
               dgvDettagli.CurrentRow.Cells(clnCodice.Name).Value = String.Empty
            End If

            ' Descrizione.
            If IsDBNull(dr.Item("Descrizione")) = False Then
               dgvDettagli.CurrentRow.Cells(clnDescrizione.Name).Value = dr.Item("Descrizione")
            Else
               dgvDettagli.CurrentRow.Cells(clnDescrizione.Name).Value = String.Empty
            End If

            ' Unità di misura.
            If IsDBNull(dr.Item("UnitàMisura")) = False Then
               dgvDettagli.CurrentRow.Cells(clnUm.Name).Value = dr.Item("UnitàMisura")
            Else
               dgvDettagli.CurrentRow.Cells(clnUm.Name).Value = String.Empty
            End If

            ' Quantità.
            If IsDBNull(dr.Item("Quantità")) = False Then
               dgvDettagli.CurrentRow.Cells(clnQta.Name).Value = dr.Item("Quantità")
            Else
               dgvDettagli.CurrentRow.Cells(clnQta.Name).Value = VALORE_ZERO
            End If

            ' Valore Unitario.
            If IsDBNull(dr.Item("ValoreUnitario")) = False Then
               dgvDettagli.CurrentRow.Cells(clnPrezzo.Name).Value = dr.Item("ValoreUnitario")
            Else
               dgvDettagli.CurrentRow.Cells(clnPrezzo.Name).Value = VALORE_ZERO
            End If

            ' Sconto %.
            If IsDBNull(dr.Item("Sconto")) = False Then
               dgvDettagli.CurrentRow.Cells(clnSconto.Name).Value = dr.Item("Sconto")
            Else
               dgvDettagli.CurrentRow.Cells(clnSconto.Name).Value = VALORE_ZERO
            End If

            ' Importo.
            If IsDBNull(dr.Item("ImportoNetto")) = False Then
               dgvDettagli.CurrentRow.Cells(clnImporto.Name).Value = dr.Item("ImportoNetto")
            Else
               dgvDettagli.CurrentRow.Cells(clnImporto.Name).Value = VALORE_ZERO
            End If

            ' Aliquota Iva.
            If IsDBNull(dr.Item("AliquotaIva")) = False Then
               dgvDettagli.CurrentRow.Cells(clnIva.Name).Value = dr.Item("AliquotaIva")
            Else
               dgvDettagli.CurrentRow.Cells(clnIva.Name).Value = "0"
            End If

         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Sub LeggiDatiConto()
      Try
         ' SHEDA GENERALE.
         Dim numeroDocumento As Integer
         Dim statoDocumento As String
         Dim causaleDocumento As String

         Select Case tipoDocumento
            Case TIPO_DOC_CO, TIPO_DOC_PF
               numeroDocumento = LeggiNumeroMax(TAB_DOCUMENTI, tipoDocumento) + 1
               statoDocumento = "Aperto"
               causaleDocumento = "Conto"

            Case TIPO_DOC_PF
               numeroDocumento = LeggiNumeroMax(TAB_DOCUMENTI, tipoDocumento) + 1
               statoDocumento = "Bozza"
               causaleDocumento = "Conto Proforma"

            Case TIPO_DOC_RF, TIPO_DOC_FF
               numeroDocumento = LeggiNumeroDocFiscaleConfig(TAB_DOCUMENTI, tipoDocumento)
               statoDocumento = "Bozza"
               causaleDocumento = "Vendita"

            Case TIPO_DOC_SF
               numeroDocumento = LeggiNumeroMax(TAB_DOCUMENTI, tipoDocumento) + 1
               statoDocumento = "Bozza"
               causaleDocumento = "Vendita"

         End Select

         Dim valSospeso As Double = Convert.ToDouble(g_frmContoPos.txtSospeso.Text)
         Dim valDaPagare As Double = Convert.ToDouble(g_frmContoPos.netBtn_DaPagare.TextButton)

         eui_cmbTipoDocumento.Text = tipoDocumento
         eui_txtNumero.Text = numeroDocumento
         eui_txtNumProgressivo.Text = numeroDocumento
         eui_txtAnno.Text = String.Empty
         eui_dtpData.Text = g_frmPos.dtpData.Value.Date.ToString
         eui_txtOra.Text = g_frmPos.lblOra.Text

         eui_cmbStatoDocumento.Text = statoDocumento
         eui_cmbCausaleDocumento.Text = causaleDocumento

         Select Case tipoCliente
            Case Cliente.Azienda
               ' Viene aggiunta la lettera A per identificare le Aziende.
               ' Codice aggiunto dopo la creazione della nuova anagrafica Aziende.
               eui_txtIdCliente.Text = "A" & g_frmContoPos.txtIdAzienda.Text
            Case Cliente.Privato
               ' ID normale.
               eui_txtIdCliente.Text = g_frmContoPos.txtIdCliente.Text
         End Select

         If g_frmContoPos.eui_cmdCliente.Text = "Seleziona cliente" Then
            eui_cmbClienteCognome.Text = String.Empty
            eui_txtClienteNome.Text = String.Empty
         Else
            eui_cmbClienteCognome.Text = g_frmContoPos.txtCognome.Text
            eui_txtClienteNome.Text = g_frmContoPos.txtNome.Text
         End If

         eui_txtIndirizzo.Text = g_frmContoPos.txtIndirizzo.Text
         eui_txtCap.Text = FormattaApici(g_frmContoPos.txtCap.Text)
         eui_txtCittà.Text = FormattaApici(g_frmContoPos.txtCittà.Text)
         eui_txtProvincia.Text = FormattaApici(g_frmContoPos.txtProv.Text)
         eui_txtPartitaIva.Text = g_frmContoPos.txtPIva.Text
         eui_txtCodiceFiscale.Text = g_frmContoPos.txtCodiceFiscale.Text

         eui_txtServizio.Text = g_frmContoPos.txtServizio.Text
         eui_txtSconto.Text = g_frmContoPos.txtValSconto.Text

         If g_frmContoPos.txtCartaCredito.Text <> VALORE_ZERO Then
            eui_cmbTipoPagamento.Text = g_frmContoPos.eui_cmdTipoPagamento.Text
         Else
            eui_cmbTipoPagamento.Text = "Contanti"
         End If

         eui_txtTavolo.Text = g_frmContoPos.nomeTavoloDoc
         eui_txtCameriere.Text = g_frmContoPos.nomeCameriereDoc

         eui_txtTotaleDocumento.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(valDaPagare))

         If g_frmContoPos.tipoDocumento = TIPO_DOC_FF Then
            ' Calcola l'IVA.
            Dim valImposta As Double
            Dim valImponibile As Double

            If IsNumeric(g_frmContoPos.txtIva.Text) = True Then

               valImponibile = CalcolaImponibileIva(g_frmContoPos.Text, valDaPagare)
               valImposta = CalcolaPercentuale(valImponibile, Convert.ToDouble(g_frmContoPos.txtIva.Text))
            Else
               valImposta = 0.0
               g_frmContoPos.txtIva.Text = VALORE_ZERO
            End If

            eui_txtImponibile.Text = CFormatta.FormattaNumeroDouble(valImponibile)
            'eui_txtIva.Text = g_frmContoPos.txtIva.Text
            eui_txtImposta.Text = CFormatta.FormattaNumeroDouble(valImposta)
         Else
            eui_txtImponibile.Text = VALORE_ZERO
            '.Iva = VALORE_ZERO
            eui_txtImposta.Text = VALORE_ZERO
         End If

         ' SHEDA DETTAGLI.

         If g_frmContoPos.eui_cmdTipoConto.Text.ToUpper = "UNICO" Then
            ' SALVA I DETTAGLI PER IL COPERTO.
            If g_frmContoPos.txtCoperto.Text <> VALORE_ZERO Then
               ' Codice, Descrizione, Unità di misura, Quantità, Prezzo, Sconto, Totale.
               dgvDettagli.Rows.Insert(dgvDettagli.Rows.Count - 1,
                                    String.Empty,
                                    "Coperto",
                                    String.Empty,
                                    NumCopertiRistorante,
                                    CopertoRistorante,
                                    VALORE_ZERO,
                                    CFormatta.FormattaNumeroDouble(g_frmContoPos.txtCoperto.Text))

            End If
         End If

         Dim i As Integer
         For i = 0 To g_frmContoPos.lstvDettagli.Items.Count - 1
            'Dim colore As Color = lstvDettagli.Items(i).BackColor
            'If colore.Equals(Color.LightCoral) = False Then

            ' Codice, Descrizione, Unità di misura, Quantità, Prezzo, Sconto, Totale.
            dgvDettagli.Rows.Insert(dgvDettagli.Rows.Count - 1,
                                    String.Empty,
                                    FormattaApici(g_frmContoPos.lstvDettagli.Items(i).SubItems(2).Text),
                                    String.Empty,
                                    g_frmContoPos.lstvDettagli.Items(i).SubItems(1).Text,
                                    VALORE_ZERO,
                                    VALORE_ZERO,
                                    g_frmContoPos.lstvDettagli.Items(i).SubItems(3).Text)

            'End If
         Next



         'If g_frmContoPos.cmdTipoConto.Text <> "ALLA ROMANA" Then
         '   ' SALVA I DETTAGLI PER LO SCONTO.
         '   If g_frmContoPos.txtValSconto.Text <> VALORE_ZERO Then

         '      ' Codice, Descrizione, Unità di misura, Quantità, Prezzo, Sconto, Totale.
         '      dgvDettagli.Rows.Insert(dgvDettagli.Rows.Count - 1,
         '                           String.Empty,
         '                           "Sconto",
         '                           String.Empty,
         '                           "1",
         '                           VALORE_ZERO,
         '                           VALORE_ZERO,
         '                           g_frmContoPos.valSconto)

         'End If
         'End If

         'If cmdTipoConto.Text <> "ALLA ROMANA" Then
         '   ' SALVA I DETTAGLI PER IL SERVIZIO.
         '   If Doc.Servizio <> VALORE_ZERO Then
         '      ' Avvia una transazione.
         '      tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
         '      ' Crea la stringa di eliminazione.
         '      sql = String.Format("INSERT INTO {0} (RifDoc, Descrizione, Quantità, ImportoNetto) " &
         '                                    "VALUES(@RifDoc, @Descrizione, @Quantità, @ImportoNetto)", TAB_DETTAGLI_DOC)
         '      ' Crea il comando per la connessione corrente.
         '      Dim cmdInsert As New OleDbCommand(sql, cn, tr)
         '      cmdInsert.Parameters.Add("@RifDoc", LeggiUltimoRecord(TAB_DOC))
         '      cmdInsert.Parameters.Add("@Descrizione", "Servizio")
         '      cmdInsert.Parameters.Add("@Quantità", "1")
         '      cmdInsert.Parameters.Add("@ImportoNetto", Doc.Servizio)
         '      ' Esegue il comando.
         '      Dim Record As Integer = cmdInsert.ExecuteNonQuery()
         '      ' Conferma transazione.
         '      tr.Commit()
         '   End If
         'End If

         ' Salva il Numero del prossimo documento da stampare.
         'SalvaNumeroDocFiscaleConfig(TAB_DOC, tipoDocumento, NumeroDocumento)

         ' SHEDA TOTALI.
         eui_txtTotaliRep1ImponibileLordo.Text = VALORE_ZERO
         eui_txtTotaliRep2ImponibileLordo.Text = VALORE_ZERO
         eui_txtTotaliRep3ImponibileLordo.Text = VALORE_ZERO
         eui_txtTotaliRep4ImponibileLordo.Text = VALORE_ZERO

         eui_txtTotaliRep1Aliquota.Text = g_frmContoPos.txtIva.Text
         eui_txtTotaliRep2Aliquota.Text = VALORE_ZERO
         eui_txtTotaliRep3Aliquota.Text = VALORE_ZERO
         eui_txtTotaliRep4Aliquota.Text = VALORE_ZERO

         eui_txtTotaliRep1Imposta.Text = VALORE_ZERO
         eui_txtTotaliRep2Imposta.Text = VALORE_ZERO
         eui_txtTotaliRep3Imposta.Text = VALORE_ZERO
         eui_txtTotaliRep4Imposta.Text = VALORE_ZERO

         eui_txtTotaliSconto.Text = CFormatta.FormattaNumeroDouble(g_frmContoPos.valSconto)
         eui_txtTotaliServizio.Text = CFormatta.FormattaNumeroDouble(g_frmContoPos.valServizio)
         eui_txtTotaliCoperto.Text = g_frmContoPos.txtCoperto.Text

         eui_txtTotaliContanti.Text = g_frmContoPos.txtContanti.Text
         eui_txtTotaliCarte.Text = g_frmContoPos.txtCartaCredito.Text
         eui_txtTotaliBuoni.Text = g_frmContoPos.txtBuoni.Text
         eui_txtTotaliSospeso.Text = g_frmContoPos.txtSospeso.Text

         eui_txtTotaliImponibile.Text = eui_txtImponibile.Text
         eui_txtTotaleImposta.Text = eui_txtImposta.Text
         eui_txtTotaleConto.Text = eui_txtTotaleDocumento.Text

      Catch ex As Exception
         ' Annulla transazione.
         'tr.Rollback()

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         'cn.Close()

      End Try
   End Sub

   ''' <summary>
   ''' Salva i dati per il documento creato.
   ''' </summary>
   ''' <returns><c>True</c> Documento salvato, <c>False</c> Documento non salvato.</returns>
   Private Function SalvaDocumento() As Boolean
      Try
         With Doc
            Dim valSospeso As Double = Convert.ToDouble(eui_txtTotaliSospeso.Text)
            Dim valDaPagare As Double = Convert.ToDouble(eui_txtTotaleDocumento.Text)

            ' Verifica l'esistenza di un nuomero per il documento.
            If eui_txtNumero.Text <> String.Empty Then
               .Numero = Convert.ToInt32(eui_txtNumero.Text)
            Else
               MessageBox.Show("Non è possibile salvare il documento senza una numerazione valida! Verrà utilizzato l'ultimo numero disponibile.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

               ' Applica l'ultimo numero progressivo per il tipo di documento.
               eui_txtNumero.Text = eui_txtNumProgressivo.Text
               eui_txtNumero.Focus()
               Exit Function
            End If

            ' Verifica l'esistenza di almeno una riga di dettaglio per il documento.
            If dgvDettagli.Rows.Count = 1 Then
               MessageBox.Show("Non è possibile salvare il documento senza almeno una riga di dettaglio!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               Exit Function
            End If

            .Tipo = eui_cmbTipoDocumento.Text
            .Anno = eui_txtAnno.Text
            .Data = eui_dtpData.Value.Value.Date
            .Ora = eui_txtOra.Text
            .Stato = eui_cmbStatoDocumento.Text
            .Causale = eui_cmbCausaleDocumento.Text

            .IdCliente = eui_txtIdCliente.Text
            If eui_cmbClienteCognome.Text & " " & eui_txtClienteNome.Text <> String.Empty Then
               .Cliente = eui_cmbClienteCognome.Text & " " & eui_txtClienteNome.Text
            Else
               .Cliente = String.Empty
            End If

            .Indirizzo = FormattaApici(eui_txtIndirizzo.Text)
            .Cap = FormattaApici(eui_txtCap.Text)
            .Città = FormattaApici(eui_txtCittà.Text)
            .Provincia = FormattaApici(eui_txtProvincia.Text)
            .PIva = eui_txtPartitaIva.Text
            .CodFiscale = eui_txtCodiceFiscale.Text
            .CodAzienda = String.Empty

            .Sconto = eui_txtTotaliSconto.Text
            .TipoSconto = String.Empty
            .Servizio = VALORE_ZERO
            .TipoServizio = String.Empty
            .Coperto = VALORE_ZERO
            .Contanti = eui_txtTotaliContanti.Text
            .Carte = eui_txtTotaliCarte.Text
            .BuoniPasto = eui_txtTotaliBuoni.Text
            .BuoniPastoIncassare = eui_txtTotaliBuoni.Text
            .Note = eui_txtNote.Text
            .Chiuso = "No"

            If eui_txtTotaliCarte.Text <> VALORE_ZERO Then
               .TipoPagamento = eui_cmbTipoPagamento.Text & ": € " & CFormatta.FormattaNumeroDouble(Convert.ToDouble(eui_txtTotaliCarte.Text))
            Else
               If eui_txtTotaliContanti.Text <> VALORE_ZERO Then
                  .TipoPagamento = "Contanti"
               Else
                  .TipoPagamento = String.Empty
               End If
            End If

            .Tavolo = eui_txtTavolo.Text
            .Cameriere = eui_txtCameriere.Text
            .Sospeso = valSospeso.ToString
            .SospesoIncassare = valSospeso.ToString
            .TotDoc = valDaPagare.ToString

            ' DA_FARE_A: Valutare se salvare l'iva anche per le ricevute.
            ' Se fattura salva l'iva...
            If eui_cmbTipoDocumento.Text = TIPO_DOC_FF Then

               .ImpLordoRep1 = eui_txtTotaliRep1ImponibileLordo.Text
               .ImpLordoRep2 = eui_txtTotaliRep2ImponibileLordo.Text
               .ImpLordoRep3 = eui_txtTotaliRep3ImponibileLordo.Text
               .ImpLordoRep4 = eui_txtTotaliRep4ImponibileLordo.Text

               .AliquotaIvaRep1 = eui_txtTotaliRep1Aliquota.Text
               .AliquotaIvaRep2 = eui_txtTotaliRep2Aliquota.Text
               .AliquotaIvaRep3 = eui_txtTotaliRep3Aliquota.Text
               .AliquotaIvaRep4 = eui_txtTotaliRep4Aliquota.Text

               .ImpostaRep1 = eui_txtTotaliRep1Imposta.Text
               .ImpostaRep2 = eui_txtTotaliRep2Imposta.Text
               .ImpostaRep3 = eui_txtTotaliRep3Imposta.Text
               .ImpostaRep4 = eui_txtTotaliRep4Imposta.Text

               .Imponibile = eui_txtImponibile.Text
               .Imposta = eui_txtImposta.Text
               .Iva = VALORE_ZERO
            Else
               .ImpLordoRep1 = VALORE_ZERO
               .ImpLordoRep2 = VALORE_ZERO
               .ImpLordoRep3 = VALORE_ZERO
               .ImpLordoRep4 = VALORE_ZERO

               .AliquotaIvaRep1 = VALORE_ZERO
               .AliquotaIvaRep2 = VALORE_ZERO
               .AliquotaIvaRep3 = VALORE_ZERO
               .AliquotaIvaRep4 = VALORE_ZERO

               .ImpostaRep1 = VALORE_ZERO
               .ImpostaRep2 = VALORE_ZERO
               .ImpostaRep3 = VALORE_ZERO
               .ImpostaRep4 = VALORE_ZERO

               .Imponibile = VALORE_ZERO
               .Iva = VALORE_ZERO
               .Imposta = VALORE_ZERO
            End If

            ' Se la proprietà 'Tag' contiene un valore viene richiamata la procedura
            ' di modifica dati, altrimenti viene richiamata la procedura di inserimento dati.
            If Me.Tag <> String.Empty Then
               ' Salva le modifiche effettuate al documento.
               .ModificaDati(TAB_DOCUMENTI, Me.Tag)

               ' Apre la connessione.
               cn.Open()

               ' Elimina le righe di dettaglio del documento per salvare quelle nuove.
               Dim sqlElimina As String
               Dim trElimina As OleDbTransaction


               ' Avvia una transazione.
               trElimina = cn.BeginTransaction(IsolationLevel.ReadCommitted)

               ' Crea la stringa di eliminazione.
               sqlElimina = String.Format("DELETE FROM {0} WHERE RifDoc = {1}", TAB_DETTAGLI_DOCUMENTI, Me.Tag)

               ' Crea il comando per la connessione corrente.
               Dim cmdDelete As New OleDbCommand(sqlElimina, cn, trElimina)

               ' Esegue il comando.
               Dim Record As Integer = cmdDelete.ExecuteNonQuery()

               ' Conferma la transazione.
               trElimina.Commit()
            Else
               ' Salva i dati del nuovo documento creato.
               .InserisciDati(TAB_DOCUMENTI)
            End If

            ' SALVA I DETTAGLI DEL DOCUMENTO.
            Dim sql As String
            ' Apre la connessione.
            If cn.State = ConnectionState.Closed Then
               cn.Open()
            End If

            Dim i As Integer
            For i = 0 To dgvDettagli.Rows.Count - 2 ' L'ultima riga è quella di inserimento dati.
               ' Avvia una transazione.
               tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
               ' Crea la stringa di eliminazione.
               sql = String.Format("INSERT INTO {0} (RifDoc, CodiceArticolo, Descrizione, UnitàMisura, Quantità, ValoreUnitario, Sconto, ImportoNetto, AliquotaIva) " &
                                   "VALUES(@RifDoc, @CodiceArticolo, @Descrizione, @UnitàMisura, @Quantità, @ValoreUnitario, @Sconto, @ImportoNetto, @AliquotaIva)", TAB_DETTAGLI_DOCUMENTI)

               ' Crea il comando per la connessione corrente.
               Dim cmdInsert As New OleDbCommand(sql, cn, tr)

               ' In caso di variante senza una quantità.
               Dim quantità As String

               If Me.Tag <> String.Empty Then
                  cmdInsert.Parameters.AddWithValue("@RifDoc", Me.Tag.ToString)
               Else
                  cmdInsert.Parameters.AddWithValue("@RifDoc", LeggiUltimoRecord(TAB_DOCUMENTI))
               End If

               cmdInsert.Parameters.AddWithValue("@CodiceArticolo", dgvDettagli.Rows(i).Cells(clnCodice.Name).Value.ToString)
               cmdInsert.Parameters.AddWithValue("@Descrizione", dgvDettagli.Rows(i).Cells(clnDescrizione.Name).Value.ToString)
               cmdInsert.Parameters.AddWithValue("@UnitàMisura", dgvDettagli.Rows(i).Cells(clnUm.Name).Value.ToString)
               cmdInsert.Parameters.AddWithValue("@Quantità", dgvDettagli.Rows(i).Cells(clnQta.Name).Value.ToString)
               cmdInsert.Parameters.AddWithValue("@ValoreUnitario", dgvDettagli.Rows(i).Cells(clnPrezzo.Name).Value.ToString) ' B_TODO: Modifica per Retail.
               cmdInsert.Parameters.AddWithValue("@Sconto", dgvDettagli.Rows(i).Cells(clnSconto.Name).Value.ToString)
               cmdInsert.Parameters.AddWithValue("@ImportoNetto", dgvDettagli.Rows(i).Cells(clnImporto.Name).Value.ToString)
               cmdInsert.Parameters.AddWithValue("@AliquotaIva", dgvDettagli.Rows(i).Cells(clnIva.Name).Value.ToString)

               ' Esegue il comando.
               Dim Record As Integer = cmdInsert.ExecuteNonQuery()
                  ' Conferma transazione.
                  tr.Commit()
               Next

               ' Salva il Numero del prossimo documento da stampare.
               SalvaNumeroDocFiscaleConfig(TAB_DOCUMENTI, eui_cmbTipoDocumento.Text, Convert.ToInt32(eui_txtNumero.Text))

         End With

         Return True

      Catch ex As Exception
         ' Annulla transazione.
         tr.Rollback()

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Function

   Private Sub CalcolaImportoRigaDoc()
      Try
         ' Quantità.
         Dim qtà As Integer
         If IsNothing(dgvDettagli.CurrentRow.Cells(clnQta.Name).Value) = False Then
            If IsNumeric(dgvDettagli.CurrentRow.Cells(clnQta.Name).Value) = True Then
               qtà = Convert.ToInt32(dgvDettagli.CurrentRow.Cells(clnQta.Name).Value)
            End If
         End If

         ' Prezzo.
         Dim prezzo As Double
         If IsNothing(dgvDettagli.CurrentRow.Cells(clnPrezzo.Name).Value) = False Then
            If IsNumeric(dgvDettagli.CurrentRow.Cells(clnPrezzo.Name).Value) = True Then
               prezzo = Convert.ToDouble(dgvDettagli.CurrentRow.Cells(clnPrezzo.Name).Value)
            End If
         End If

         ' Importo.
         Dim importo As Double = (prezzo * qtà)

         ' Sconto.
         Dim sconto As Double
         If IsNothing(dgvDettagli.CurrentRow.Cells(clnSconto.Name).Value) = False Then
            If IsNumeric(dgvDettagli.CurrentRow.Cells(clnSconto.Name).Value) = True Then
               sconto = Convert.ToDouble(dgvDettagli.CurrentRow.Cells(clnSconto.Name).Value)
            End If
         End If

         ' Calcola il valore dello sconto
         Dim valSconto As Double = CalcolaPercentuale(importo, sconto)

         ' Sottrae lo sconto al valore dell'importo totale.
         importo = (importo - valSconto)

         ' Inserisce l'importo totale nella cella della riga corrente.
         dgvDettagli.CurrentRow.Cells(clnImporto.Name).Value = CFormatta.FormattaEuro(importo)

         ' Inserisce l'importo totale dello sconto nella cella della riga corrente.
         dgvDettagli.CurrentRow.Cells(clnValoreSconto.Name).Value = CFormatta.FormattaEuro(valSconto)

      Catch ex As FormatException
         Exit Sub

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CalcolaImportoTotaleDoc()
      Try
         ' Importo.
         Dim importo As Double

         Dim i As Integer
         For i = 0 To dgvDettagli.Rows.Count - 1
            ' Somma tutti gli importi delle righe del documento.
            importo = (importo + Convert.ToDouble(dgvDettagli.Rows(i).Cells(clnImporto.Name).Value))
         Next

         ' Aggiorna i totali.
         eui_txtTotaleDocumento.Text = CFormatta.FormattaEuro(importo)
         eui_txtTotaleConto.Text = CFormatta.FormattaEuro(importo)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CalcolaImportoTotaleIva()
      Try
         ' Importo.
         Dim importo1 As Double
         Dim importo2 As Double
         Dim importo3 As Double
         Dim importo4 As Double

         Dim percIva1 As Integer
         Dim percIva2 As Integer
         Dim percIva3 As Integer
         Dim percIva4 As Integer

         Dim valTotaleImpostaRep1 As Double
         Dim valTotaleImpostaRep2 As Double
         Dim valTotaleImpostaRep3 As Double
         Dim valTotaleImpostaRep4 As Double

         Dim valTotaleImponibile1 As Double
         Dim valTotaleImponibile2 As Double
         Dim valTotaleImponibile3 As Double
         Dim valTotaleImponibile4 As Double

         ' Somma tutti gli importi delle righe del documento.
         Dim i As Integer
         For i = 0 To dgvDettagli.Rows.Count - 1

            Select Case dgvDettagli.Rows(i).Cells(clnRepartoIva.Name).Value
               Case "Reparto 1"
                  importo1 = Convert.ToDouble(dgvDettagli.Rows(i).Cells(clnImporto.Name).Value)
                  percIva1 = Convert.ToInt32(dgvDettagli.Rows(i).Cells(clnIva.Name).Value)
                  valTotaleImponibile1 = valTotaleImponibile1 + CalcolaImponibileIva(percIva1.ToString, importo1)
                  valTotaleImpostaRep1 = CalcolaPercentuale(valTotaleImponibile1, percIva1)

               Case "Reparto 2"
                  importo2 = Convert.ToDouble(dgvDettagli.Rows(i).Cells(clnImporto.Name).Value)
                  percIva2 = Convert.ToInt32(dgvDettagli.Rows(i).Cells(clnIva.Name).Value)
                  valTotaleImponibile2 = valTotaleImponibile2 + CalcolaImponibileIva(percIva2.ToString, importo2)
                  valTotaleImpostaRep2 = CalcolaPercentuale(valTotaleImponibile2, percIva2)

               Case "Reparto 3"
                  importo3 = Convert.ToDouble(dgvDettagli.Rows(i).Cells(clnImporto.Name).Value)
                  percIva3 = Convert.ToInt32(dgvDettagli.Rows(i).Cells(clnIva.Name).Value)
                  valTotaleImponibile3 = valTotaleImponibile3 + CalcolaImponibileIva(percIva3.ToString, importo3)
                  valTotaleImpostaRep3 = CalcolaPercentuale(valTotaleImponibile3, percIva3)

               Case "Reparto 4"
                  importo4 = Convert.ToDouble(dgvDettagli.Rows(i).Cells(clnImporto.Name).Value)
                  percIva4 = Convert.ToInt32(dgvDettagli.Rows(i).Cells(clnIva.Name).Value)
                  valTotaleImponibile4 = valTotaleImponibile4 + CalcolaImponibileIva(percIva4.ToString, importo4)
                  valTotaleImpostaRep4 = CalcolaPercentuale(valTotaleImponibile4, percIva4)

            End Select
         Next

         ' Aggiorna i totali.

         ' Aliquote Iva.
         eui_txtTotaliRep1Aliquota.Text = percIva1.ToString
         eui_txtTotaliRep2Aliquota.Text = percIva2.ToString
         eui_txtTotaliRep3Aliquota.Text = percIva3.ToString
         eui_txtTotaliRep4Aliquota.Text = percIva4.ToString

         ' Imponibile.
         eui_txtTotaliRep1ImponibileLordo.Text = CFormatta.FormattaEuro(valTotaleImponibile1)
         eui_txtTotaliRep2ImponibileLordo.Text = CFormatta.FormattaEuro(valTotaleImponibile2)
         eui_txtTotaliRep3ImponibileLordo.Text = CFormatta.FormattaEuro(valTotaleImponibile3)
         eui_txtTotaliRep4ImponibileLordo.Text = CFormatta.FormattaEuro(valTotaleImponibile4)

         ' Imposte.
         eui_txtTotaliRep1Imposta.Text = CFormatta.FormattaEuro(valTotaleImpostaRep1)
         eui_txtTotaliRep2Imposta.Text = CFormatta.FormattaEuro(valTotaleImpostaRep2)
         eui_txtTotaliRep3Imposta.Text = CFormatta.FormattaEuro(valTotaleImpostaRep3)
         eui_txtTotaliRep4Imposta.Text = CFormatta.FormattaEuro(valTotaleImpostaRep4)

         ' Imponibile totale.
         eui_txtImponibile.Text = CFormatta.FormattaEuro((valTotaleImponibile1 + valTotaleImponibile2 + valTotaleImponibile3 + valTotaleImponibile4))
         eui_txtTotaliImponibile.Text = eui_txtImponibile.Text

         ' Imposta totale.
         eui_txtImposta.Text = CFormatta.FormattaEuro((valTotaleImpostaRep1 + valTotaleImpostaRep2 + valTotaleImpostaRep3 + valTotaleImpostaRep4))
         eui_txtTotaleImposta.Text = eui_txtImposta.Text

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CalcolaTotaleSconto()
      Try
         Dim valSconto As Double

         Dim i As Integer
         For i = 0 To dgvDettagli.Rows.Count - 1
            ' Valore sconto per riga..
            If IsNothing(dgvDettagli.Rows(i).Cells(clnValoreSconto.Name).Value) = False Then
               If IsNumeric(dgvDettagli.Rows(i).Cells(clnValoreSconto.Name).Value) = True Then
                  valSconto = valSconto + Convert.ToDouble(dgvDettagli.Rows(i).Cells(clnValoreSconto.Name).Value)
               End If
            End If
         Next

         ' Totale sconto.
         eui_txtTotaliSconto.Text = CFormatta.FormattaEuro(valSconto)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Function LeggiAliquotaIva(ByVal reparto As String) As String
      Try
         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig

         ' Aliquote IVA per i reparti.
         Dim aliquotaIva As String

         Select Case reparto
            Case "Reparto 1"
               aliquotaIva = DatiConfig.GetValue("AliquotaIva1")

            Case "Reparto 2"
               aliquotaIva = DatiConfig.GetValue("AliquotaIva2")

            Case "Reparto 3"
               aliquotaIva = DatiConfig.GetValue("AliquotaIva3")

            Case "Reparto 4"
               aliquotaIva = DatiConfig.GetValue("AliquotaIva4")

            Case Else
               aliquotaIva = AliquotaIvaRistorante

         End Select

         Return aliquotaIva

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return AliquotaIvaRistorante

      End Try
   End Function

   Private Function VerificaAliquotaIva(ByVal valIva As String) As String
      Try
         Select Case valIva
            Case LeggiAliquotaIva("Reparto 1")
               Return "Reparto 1"

            Case LeggiAliquotaIva("Reparto 2")
               Return "Reparto 2"

            Case LeggiAliquotaIva("Reparto 3")
               Return "Reparto 3"

            Case LeggiAliquotaIva("Reparto 4")
               Return "Reparto 4"

            Case Else
               Return String.Empty

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

      End Try
   End Function

   Private Sub InserisciRepartoIva()
      Try
         Dim repIva As String = VerificaAliquotaIva(dgvDettagli.CurrentRow.Cells(clnIva.Name).Value.ToString)

         dgvDettagli.CurrentRow.Cells(clnRepartoIva.Name).Value = repIva

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Function ApriClienti(ByVal val As String) As Boolean
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         ' Per la versione demo.
         ' Se è un nuovo inserimento verifica il numero dei record.
         If val = String.Empty Then
            If g_VerDemo = True Then
               ' Test per la versione demo.
               If VerificaNumRecord(LeggiNumRecord(ANA_CLIENTI, cn, cmd)) = True Then
                  Exit Function
               End If
            End If
         End If

         Dim frm As New frmClienti
         frm.Tag = val

         If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            Return True
         Else
            Return False
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      End Try
   End Function

   Private Sub frmDocumento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      Try
         ImpostaIcona(Me)

         CaricaLista(eui_cmbTipoDocumento, TAB_TIPO_DOCUMENTI)
         CaricaLista(eui_cmbCausaleDocumento, TAB_CAUSALI_DOCUMENTI)
         CaricaListaClienti(eui_cmbClienteCognome, eui_cmbIdCliente, ANA_CLIENTI)
         CaricaLista(eui_cmbTipoPagamento, TAB_TIPO_PAGAMENTO)

         Select Case nomeFinestra
            Case "ContoPos"
               LeggiDatiConto()

            Case "ElencoDoc"
               ' Se il tipo documento è una stringa vuota apre la finestra per la modifica di un documento,
               ' altrimenti apre la finestra per un nuovo documento.
               If idDocumento = String.Empty Then
                  NuovoDocumento()
               Else
                  ModificaDocumento()
               End If

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdAnnulla_Click(sender As Object, e As EventArgs) Handles eui_cmdAnnulla.Click
      Me.Close()
   End Sub

   Private Sub eui_cmdNuovoCliente_Click(sender As Object, e As EventArgs) Handles eui_cmdNuovoCliente.Click
      Try
         ' Inserimento nuovo cliente...
         If ApriClienti(String.Empty) = True Then
            CaricaListaClienti(eui_cmbClienteCognome, eui_cmbIdCliente, ANA_CLIENTI)

            eui_cmbIdCliente.Text = String.Empty
            eui_cmbClienteCognome.Text = String.Empty
            eui_txtClienteNome.Text = String.Empty
            eui_txtIndirizzo.Text = String.Empty
            eui_txtCittà.Text = String.Empty
            eui_txtCap.Text = String.Empty
            eui_txtProvincia.Text = String.Empty
            eui_txtPartitaIva.Text = String.Empty
            eui_txtCodiceFiscale.Text = String.Empty
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdModificaCliente_Click(sender As Object, e As EventArgs) Handles eui_cmdModificaCliente.Click
      Try
         ' Modifica cliente esistente...
         If ApriClienti(eui_cmbIdCliente.Text) = True Then
            CaricaListaClienti(eui_cmbClienteCognome, eui_cmbIdCliente, ANA_CLIENTI)

            eui_cmbIdCliente.Text = String.Empty
            eui_cmbClienteCognome.Text = String.Empty
            eui_txtClienteNome.Text = String.Empty
            eui_txtIndirizzo.Text = String.Empty
            eui_txtCittà.Text = String.Empty
            eui_txtCap.Text = String.Empty
            eui_txtProvincia.Text = String.Empty
            eui_txtPartitaIva.Text = String.Empty
            eui_txtCodiceFiscale.Text = String.Empty
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_cmbClienteCognome_SelectedIndexChanged(sender As Object, e As EventArgs) Handles eui_cmbClienteCognome.SelectedIndexChanged
      Try
         ' Legge il nome relativo alla lista Cognome.
         eui_cmbIdCliente.SelectedIndex = eui_cmbClienteCognome.SelectedIndex

         Dim AClienti As New Anagrafiche.Cliente(ConnString)

         AClienti.LeggiDati(ANA_CLIENTI, eui_cmbIdCliente.Text)

         eui_txtClienteNome.Text = AClienti.Nome
         eui_txtIndirizzo.Text = AClienti.Indirizzo1
         eui_txtCittà.Text = AClienti.Città
         eui_txtCap.Text = AClienti.Cap
         eui_txtProvincia.Text = AClienti.Provincia
         eui_txtPartitaIva.Text = AClienti.PIva
         eui_txtCodiceFiscale.Text = AClienti.CodFisc
         eui_txtSconto.Text = AClienti.Sconto
         ' DA_FARE_A: Valutare se leggere l'aliquota iva del cliente
         'eui_txtIva.Text = AClienti.Iva

         If eui_txtClienteNome.Text <> String.Empty Then
            eui_lblStatoClienteDoc.Text = eui_cmbClienteCognome.Text & " - " & eui_txtClienteNome.Text
         Else
            eui_lblStatoClienteDoc.Text = eui_cmbClienteCognome.Text
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_cmbTipoDocumento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles eui_cmbTipoDocumento.SelectedIndexChanged
      Try
         ' In caso di Documento esistente.
         If idDocumento <> String.Empty Then
            idDocumento = String.Empty
            Exit Sub
         End If

         Dim NumeroDocumento As Integer

         Select Case eui_cmbTipoDocumento.Text
            Case TIPO_DOC_CO, TIPO_DOC_PF
               NumeroDocumento = LeggiNumeroMax(TAB_DOCUMENTI, eui_cmbTipoDocumento.Text) + 1

            Case TIPO_DOC_RF, TIPO_DOC_FF
               NumeroDocumento = LeggiNumeroDocFiscaleConfig(TAB_DOCUMENTI, eui_cmbTipoDocumento.Text)

            Case TIPO_DOC_SF
               NumeroDocumento = LeggiNumeroMax(TAB_DOCUMENTI, eui_cmbTipoDocumento.Text) + 1

         End Select

         eui_txtNumero.Text = NumeroDocumento.ToString
         Me.Text = eui_cmbTipoDocumento.Text

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_txtNumero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtNumero.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdAnteprima_Click(sender As Object, e As EventArgs) Handles eui_cmdAnteprima.Click
      Try
         Select Case nomeFinestra
            Case "ContoPos"

               'If g_frmPos.nomeTavolo <> String.Empty And g_frmPos.nomeTavolo <> "Tavoli" Then
               '   mantieniDatiTavolo = False
               'Else
               '   mantieniDatiTavolo = True
               'End If

               'g_frmContoPos.tipoDocumento = tipoDocumento

               'If g_frmContoPos.ImpostaNomeDoc(0) <> String.Empty Then
               '   g_frmContoPos.percorsoRep = "\Reports\" & g_frmContoPos.ImpostaNomeDoc(0)
               'Else
               '   Select Case tipoDocumento
               '      Case TIPO_DOC_CO
               '         ' TODO: Aggiungere documento conto.

               '      Case TIPO_DOC_PF
               '         g_frmContoPos.percorsoRep = PERCORSO_REP_PF_A4_DOPPIA

               '      Case TIPO_DOC_RF
               '         g_frmContoPos.percorsoRep = PERCORSO_REP_RF_A4_DOPPIA

               '      Case TIPO_DOC_FF
               '         g_frmContoPos.percorsoRep = PERCORSO_REP_FF_A4_DOPPIA

               '      Case TIPO_DOC_SF
               '         ' TODO: Aggiungere documento scontrino.

               '   End Select
               'End If

               'If g_frmContoPos.txtSospeso.Text <> VALORE_ZERO Then
               '   If g_frmContoPos.VerificaIntestazione() = False Then
               '      Exit Sub
               '   End If
               'End If

               'If g_frmContoPos.VerificaCartaCredito() = True Then
               '   g_frmContoPos.StampaConto(g_frmContoPos.ImpostaNomeStampante(0))
               'End If

            Case "ElencoDoc"

         End Select


      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdSalva_Click(sender As Object, e As EventArgs) Handles eui_cmdSalva.Click
      Try
         ' Salva il documento e chiude la finestra.
         If SalvaDocumento() = True Then
            Me.Close()

            ' Se aperto aggiorna l'elenco documenti.
            If IsNothing(g_frmDocumenti) = False Then
               g_frmDocumenti.AggiornaDati()
            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_txtNumero_TextChanged(sender As Object, e As EventArgs) Handles eui_txtNumero.TextChanged
      Try
         eui_lblStatoNumeroDoc.Text = eui_txtNumero.Text & "/" & eui_txtAnno.Text

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_dtpData_ValueChanged(sender As Object, e As EventArgs) Handles eui_dtpData.ValueChanged
      Try
         eui_lblStatoDataDoc.Text = eui_dtpData.Value.GetValueOrDefault.ToShortDateString

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_txtTotaleDocumento_TextChanged(sender As Object, e As EventArgs) Handles eui_txtTotaleDocumento.TextChanged
      Try
         eui_lblStatoTotaleDoc.Text = eui_txtTotaleDocumento.Text

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdInsPiatti_Click(sender As Object, e As EventArgs) Handles eui_cmdInsPiatti.Click
      Try
         Dim frm As New ListaPiatti
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_cmdInsAccessori_Click(sender As Object, e As EventArgs) Handles eui_cmdInsAccessori.Click
      Try
         Dim frm As New ListaAccessoriServizi("Accessorio")
         frm.Tag = "Documento"
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdInsiServizi_Click(sender As Object, e As EventArgs) Handles eui_cmdInsiServizi.Click
      Try
         Dim frm As New ListaAccessoriServizi("Servizio")
         frm.Tag = "Documento"
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_tpcDocumento_SelectedTabPageChanged(sender As Object, e As TabPageChangedEventArgs) Handles eui_tpcDocumento.SelectedTabPageChanged
      Try
         Select Case eui_tpcDocumento.SelectedTabPage.Text
            Case "Dettagli"
               If dgvDettagli.Rows.Count = 1 Then
                  eui_cmdCancellaTutto.PerformClick()
               End If
         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdNuovaRiga_Click(sender As Object, e As EventArgs) Handles eui_cmdNuovaRiga.Click
      Try
         dgvDettagli.Focus()
         dgvDettagli.Rows.Add()
         dgvDettagli.Rows.Item(dgvDettagli.Rows.Count - 2).Selected = True
         dgvDettagli.Rows.Item(dgvDettagli.Rows.Count - 2).Cells.Item(0).Selected = True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdEliminaRiga_Click(sender As Object, e As EventArgs) Handles eui_cmdEliminaRiga.Click
      Try
         dgvDettagli.Focus()
         dgvDettagli.Rows.Remove(dgvDettagli.CurrentRow)

         CalcolaImportoRigaDoc()
         CalcolaTotaleSconto()
         CalcolaImportoTotaleIva()
         CalcolaImportoTotaleDoc()

      Catch ex As InvalidOperationException
         Exit Sub

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_cmdCancellaTutto_Click(sender As Object, e As EventArgs) Handles eui_cmdCancellaTutto.Click
      Try
         dgvDettagli.Focus()
         dgvDettagli.Rows.Clear()
         dgvDettagli.Rows.Add()

         CalcolaImportoRigaDoc()
         CalcolaTotaleSconto()
         CalcolaImportoTotaleIva()
         CalcolaImportoTotaleDoc()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub dgvDettagli_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDettagli.CellValueChanged
      Try
         ' Se ci sono righe nel documento...
         If dgvDettagli.Rows.Count <> 1 Then

            If IsNothing(dgvDettagli.CurrentRow.Cells(clnIva.Name).Value) = False Then
               If VerificaAliquotaIva(dgvDettagli.CurrentRow.Cells(clnIva.Name).Value.ToString) = String.Empty Then
                  MessageBox.Show("Il valore dell'aliquota Iva inserito non è corretto!" & vbCrLf &
                                  "Inserire una delle quattro aliquote impostate nel programma. (Vedere finestra Opzioni)", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                  dgvDettagli.CurrentRow.Cells(clnIva.Name).Value = 0
               Else
                  InserisciRepartoIva()
               End If
            End If

            ' Questa riga è necessaria altrimenti non calcola lo sconto inserito. 
            Dim qtà As Integer = dgvDettagli.CurrentRow.Cells(clnQta.Name).Value

            CalcolaImportoRigaDoc()
            CalcolaTotaleSconto()
            CalcolaImportoTotaleIva()
            CalcolaImportoTotaleDoc()

            ' Questa riga è necessaria altrimenti non calcola lo sconto inserito. 
            dgvDettagli.CurrentRow.Cells(clnQta.Name).Value = qtà

         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub dgvDettagli_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvDettagli.CellFormatting
      Try
         Select Case e.ColumnIndex
            Case 0, 1, 2
               ' Colonne da non formattare (Codice, Descrizione, Unità di misura).
               Exit Sub

            Case Else
               ' Tutte le altre colonne da formattare.

               Dim valCell As Double
               If IsNothing(e.Value) = False Then
                  If IsNumeric(e.Value) = True Then
                     ' Colonna Iva.
                     If e.ColumnIndex = 7 Then
                        Exit Sub
                     Else
                        valCell = Convert.ToInt32(e.Value)
                        e.Value = CFormatta.FormattaEuro(valCell)
                     End If
                  Else
                     ' Colonna Iva.
                     If e.ColumnIndex = 7 Then
                        e.Value = 0
                     Else
                        e.Value = VALORE_ZERO
                     End If
                  End If
               End If

         End Select

      Catch ex As FormatException
         Exit Sub

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_txtTotaliRep1ImponibileLordo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtTotaliRep1ImponibileLordo.KeyPress
      ' Annulla il carattere premuto. 
      e.KeyChar = String.Empty
   End Sub

   Private Sub eui_txtTotaliRep2ImponibileLordo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtTotaliRep2ImponibileLordo.KeyPress
      ' Annulla il carattere premuto. 
      e.KeyChar = String.Empty
   End Sub

   Private Sub eui_txtTotaliRep1Aliquota_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtTotaliRep1Aliquota.KeyPress
      ' Annulla il carattere premuto. 
      e.KeyChar = String.Empty
   End Sub

   Private Sub eui_txtTotaliRep1Imposta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtTotaliRep1Imposta.KeyPress
      ' Annulla il carattere premuto. 
      e.KeyChar = String.Empty
   End Sub

   Private Sub eui_txtTotaliRep2Aliquota_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtTotaliRep2Aliquota.KeyPress
      ' Annulla il carattere premuto. 
      e.KeyChar = String.Empty
   End Sub

   Private Sub eui_txtTotaliRep2Imposta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtTotaliRep2Imposta.KeyPress
      ' Annulla il carattere premuto. 
      e.KeyChar = String.Empty
   End Sub

   Private Sub eui_txtTotaliRep3Aliquota_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtTotaliRep3Aliquota.KeyPress
      ' Annulla il carattere premuto. 
      e.KeyChar = String.Empty
   End Sub

   Private Sub eui_txtTotaliRep3ImponibileLordo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtTotaliRep3ImponibileLordo.KeyPress
      ' Annulla il carattere premuto. 
      e.KeyChar = String.Empty
   End Sub

   Private Sub eui_txtTotaliRep3Imposta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtTotaliRep3Imposta.KeyPress
      ' Annulla il carattere premuto. 
      e.KeyChar = String.Empty
   End Sub

   Private Sub eui_txtTotaliRep4Aliquota_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtTotaliRep4Aliquota.KeyPress
      ' Annulla il carattere premuto. 
      e.KeyChar = String.Empty
   End Sub

   Private Sub eui_txtTotaliRep4ImponibileLordo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtTotaliRep4ImponibileLordo.KeyPress
      ' Annulla il carattere premuto. 
      e.KeyChar = String.Empty
   End Sub

   Private Sub eui_txtTotaliRep4Imposta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtTotaliRep4Imposta.KeyPress
      ' Annulla il carattere premuto. 
      e.KeyChar = String.Empty
   End Sub

   Private Sub eui_txtTotaliSconto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtTotaliSconto.KeyPress
      ' Annulla il carattere premuto. 
      e.KeyChar = String.Empty
   End Sub

   Private Sub eui_txtTotaliServizio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtTotaliServizio.KeyPress
      ' Annulla il carattere premuto. 
      e.KeyChar = String.Empty
   End Sub

   Private Sub eui_txtTotaliImponibile_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtTotaliImponibile.KeyPress
      ' Annulla il carattere premuto. 
      e.KeyChar = String.Empty
   End Sub

   Private Sub eui_txtTotaleDocumento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtTotaleDocumento.KeyPress
      ' Annulla il carattere premuto. 
      e.KeyChar = String.Empty
   End Sub

   Private Sub eui_txtTotaleImposta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtTotaleImposta.KeyPress
      ' Annulla il carattere premuto. 
      e.KeyChar = String.Empty
   End Sub

   Private Sub eui_txtTotaleConto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtTotaleConto.KeyPress
      ' Annulla il carattere premuto. 
      e.KeyChar = String.Empty
   End Sub

   Private Sub eui_txtImponibile_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtImponibile.KeyPress
      ' Annulla il carattere premuto. 
      e.KeyChar = String.Empty
   End Sub

   Private Sub eui_txtImposta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtImposta.KeyPress
      ' Annulla il carattere premuto. 
      e.KeyChar = String.Empty
   End Sub

   Private Sub eui_txtTotaliCoperto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtTotaliCoperto.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_txtTotaliContanti_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtTotaliContanti.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_txtTotaliCarte_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtTotaliCarte.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_txtTotaliBuoni_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtTotaliBuoni.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_txtTotaliSospeso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtTotaliSospeso.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_txtTotaliSospeso_LostFocus(sender As Object, e As EventArgs) Handles eui_txtTotaliSospeso.LostFocus
      Try
         Dim sospeso As Double
         If IsNumeric(sender.Text) = True Then
            sospeso = Convert.ToDouble(sender.Text)
         End If

         Dim totaleDoc As Double
         If IsNumeric(eui_txtTotaleDocumento.Text) = True Then
            totaleDoc = Convert.ToDouble(eui_txtTotaleDocumento.Text)
         End If

         If sospeso > totaleDoc Then
            MessageBox.Show("Il valore sospeso specificato non può essere maggiore dell'importo totale del documento.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            sender.Text = VALORE_ZERO
            sender.Focus()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         sender.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(sender.Text))

      End Try

   End Sub

   Private Sub eui_txtTotaliCoperto_LostFocus(sender As Object, e As EventArgs) Handles eui_txtTotaliCoperto.LostFocus
      sender.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(sender.Text))
   End Sub

   Private Sub eui_txtTotaliContanti_LostFocus(sender As Object, e As EventArgs) Handles eui_txtTotaliContanti.LostFocus
      sender.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(sender.Text))
   End Sub

   Private Sub eui_txtTotaliBuoni_LostFocus(sender As Object, e As EventArgs) Handles eui_txtTotaliBuoni.LostFocus
      sender.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(sender.Text))
   End Sub

   Private Sub eui_txtTotaliCarte_LostFocus(sender As Object, e As EventArgs) Handles eui_txtTotaliCarte.LostFocus
      sender.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(sender.Text))
   End Sub

   Private Sub eui_cmdTastiera_Click(sender As Object, e As EventArgs) Handles eui_cmdTastiera.Click
      AvviaTastieraVirtuale(Me.Handle)
   End Sub

End Class
