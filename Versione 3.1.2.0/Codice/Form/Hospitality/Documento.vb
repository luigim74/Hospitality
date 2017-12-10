Imports Elegant.Ui

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
   Public Sub New(ByVal nomeWnd As String, ByVal documento As String)

      ' Chiamata richiesta dalla finestra di progettazione.
      InitializeComponent()

      tipoDocumento = documento
      nomeFinestra = nomeWnd

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

   ' TODO: Utilizzare per l'apertura dei documenti dall'elenco documenti.
   Private Sub NuovoDocumento()
      Try
         ' SHEDA GENERALE.

         ' TODO: GESTIONE DOCUMENTI - MODIFICARE!
         Dim NumeroDocumento As Integer

         Select Case tipoDocumento
            Case TIPO_DOC_CO, TIPO_DOC_PF
               NumeroDocumento = LeggiNumeroMax(TAB_DOCUMENTI, tipoDocumento)

            Case TIPO_DOC_RF, TIPO_DOC_FF
               NumeroDocumento = LeggiNumeroDocFiscaleConfig(TAB_DOCUMENTI, tipoDocumento)

            Case TIPO_DOC_SF
               NumeroDocumento = LeggiNumeroMax(TAB_DOCUMENTI, tipoDocumento)

         End Select

         ' TODO: GESTIONE DOCUMENTI - MODIFICARE!
         'Dim valSospeso As Double = Convert.ToDouble(g_frmContoPos.txtSospeso.Text) + Convert.ToDouble(g_frmContoPos.txtCartaCredito.Text)
         'Dim valDaPagare As Double = Convert.ToDouble(g_frmContoPos.netBtn_DaPagare.TextButton)

         eui_txtNumero.Text = NumeroDocumento.ToString
         eui_txtAnno.Text = Today.Year.ToString
         eui_dtpData.Text = Today.ToString
         eui_txtOra.Text = Today.Hour.ToString
         eui_cmbTipoDocumento.Text = tipoDocumento

         eui_cmbStatoDocumento.Text = "Bozza"
         eui_cmbCausaleDocumento.Text = "Vendita"

         'Select Case tipoCliente
         '   Case Cliente.Azienda
         '      ' Viene aggiunta la lettera A per identificare le Aziende.
         '      ' Codice aggiunto dopo la creazione della nuova anagrafica Aziende.
         '      .IdCliente = "A" & idCliente
         '   Case Cliente.Privato
         '      ' ID normale.
         '      .IdCliente = idCliente
         'End Select
         'If g_frmContoPos.eui_cmdCliente.Text = "Seleziona cliente" Then
         '   eui_cmbClienteCognome.Text = String.Empty
         '   eui_txtClienteNome.Text = String.Empty
         'Else
         '   eui_cmbClienteCognome.Text = g_frmContoPos.eui_cmdCliente.Text
         '   eui_txtClienteNome.Text = String.Empty
         'End If

         'eui_txtIndirizzo.Text = g_frmContoPos.txtIndirizzo.Text
         'eui_txtCap.Text = FormattaApici(g_frmContoPos.txtCap.Text)
         'eui_txtCittà.Text = FormattaApici(g_frmContoPos.txtCittà.Text)
         'eui_txtProvincia.Text = FormattaApici(g_frmContoPos.txtProv.Text)
         'eui_txtPartitaIva.Text = g_frmContoPos.txtPIva.Text
         'eui_txtCodiceFiscale.Text = String.Empty

         '.CodAzienda = String.Empty
         '.Coperto = CFormatta.FormattaNumeroDouble(g_frmContoPos.txtCoperto.Text)
         eui_txtServizio.Text = VALORE_ZERO
         eui_txtSconto.Text = VALORE_ZERO
         '.BuoniPasto = CFormatta.FormattaNumeroDouble(g_frmContoPos.txtBuoni.Text)
         '.BuoniPastoIncassare = CFormatta.FormattaNumeroDouble(g_frmContoPos.txtBuoni.Text)
         '.Chiuso = "No"
         '.Note = ""

         'If g_frmContoPos.txtCartaCredito.Text <> VALORE_ZERO Then
         '   eui_cmbTipoPagamento.Text = g_frmContoPos.eui_cmdTipoPagamento.Text ' & ": € " & CFormatta.FormattaNumeroDouble(valSospeso)
         'Else
         '   eui_cmbTipoPagamento.Text = "Contanti"
         'End If

         '.Tavolo = g_frmContoPos.nomeTavoloDoc
         '.Cameriere = g_frmContoPos.nomeCameriereDoc
         '.Sospeso = CFormatta.FormattaNumeroDouble(valSospeso)
         '.SospesoIncassare = CFormatta.FormattaNumeroDouble(valSospeso)
         'eui_txtTotaleDocumento.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(valDaPagare))

         'If g_frmContoPos.tipoDocumento = TIPO_DOC_FF Then
         '   ' Calcola l'IVA.
         '   Dim valImposta As Double
         '   Dim valImponibile As Double
         '   If IsNumeric(g_frmContoPos.txtIva.Text) = True Then

         '      Dim valCoefficiente As Double
         '      Select Case g_frmContoPos.txtIva.Text
         '         Case "22,00"
         '            valCoefficiente = 1.22
         '         Case "21,00"
         '            valCoefficiente = 1.21
         '         Case "20,00"
         '            valCoefficiente = 1.2
         '         Case "10,00"
         '            valCoefficiente = 1.1
         '         Case "4,00"
         '            valCoefficiente = 1.04
         '         Case Else
         '            valCoefficiente = 0.0
         '      End Select

         '      If valCoefficiente <> 0.0 Then
         '         valImponibile = (valDaPagare / valCoefficiente)
         '      Else
         '         valImponibile = 0.0
         '      End If

         '      valImposta = CalcolaPercentuale(valImponibile, Convert.ToDouble(g_frmContoPos.txtIva.Text))
         '   Else
         '      valImposta = 0.0
         '      g_frmContoPos.txtIva.Text = VALORE_ZERO
         '   End If

         '   'Dim valImponibile As Double = (valDaPagare - valImposta)
         '   eui_txtImponibile.Text = CFormatta.FormattaNumeroDouble(valImponibile)
         '   'eui_txtIva.Text = g_frmContoPos.txtIva.Text
         '   eui_txtImposta.Text = CFormatta.FormattaNumeroDouble(valImposta)
         'Else
         eui_txtImponibile.Text = VALORE_ZERO
         '   '.Iva = VALORE_ZERO
         eui_txtImposta.Text = VALORE_ZERO
         'End If

         eui_txtTotaleDocumento.Text = VALORE_ZERO

         '.InserisciDati(TAB_DOCUMENTI)

         ' SHEDA DETTAGLI.

         'If g_frmContoPos.eui_cmdTipoConto.Text.ToUpper = "UNICO" Then
         '   ' SALVA I DETTAGLI PER IL COPERTO.
         '   If g_frmContoPos.txtCoperto.Text <> VALORE_ZERO Then
         '      ' Codice, Descrizione, Unità di misura, Quantità, Prezzo, Sconto, Totale.
         '      dgvDettagli.Rows.Insert(dgvDettagli.Rows.Count - 1,
         '                           String.Empty,
         '                           "Coperto",
         '                           String.Empty,
         '                           NumCopertiRistorante,
         '                           CopertoRistorante,
         '                           VALORE_ZERO,
         '                           CFormatta.FormattaNumeroDouble(g_frmContoPos.txtCoperto.Text))

         '   End If
         'End If

         'Dim i As Integer
         'For i = 0 To g_frmContoPos.lstvDettagli.Items.Count - 1
         '   'Dim colore As Color = lstvDettagli.Items(i).BackColor
         '   'If colore.Equals(Color.LightCoral) = False Then

         '   ' Codice, Descrizione, Unità di misura, Quantità, Prezzo, Sconto, Totale.
         '   dgvDettagli.Rows.Insert(dgvDettagli.Rows.Count - 1,
         '                           String.Empty,
         '                           FormattaApici(g_frmContoPos.lstvDettagli.Items(i).SubItems(2).Text),
         '                           String.Empty,
         '                           g_frmContoPos.lstvDettagli.Items(i).SubItems(1).Text,
         '                           VALORE_ZERO,
         '                           VALORE_ZERO,
         '                           g_frmContoPos.lstvDettagli.Items(i).SubItems(3).Text)

         '   'End If
         'Next



         'If g_frmContoPos.eui_cmdTipoConto.Text.ToUpper <> "ALLA ROMANA" Then
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

         'If eui_cmdTipoConto.Text.ToUpper <> "ALLA ROMANA" Then
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

         eui_txtTotaliRep1ImponibileScontato.Text = VALORE_ZERO
         eui_txtTotaliRep2ImponibileScontato.Text = VALORE_ZERO
         eui_txtTotaliRep3ImponibileScontato.Text = VALORE_ZERO
         eui_txtTotaliRep4ImponibileScontato.Text = VALORE_ZERO

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

         ' Note.
         eui_txtNote.Text = String.Empty

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

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

               'Dim valCoefficiente As Double
               'Select Case g_frmContoPos.txtIva.Text
               '   Case "22,00"
               '      valCoefficiente = 1.22
               '   Case "21,00"
               '      valCoefficiente = 1.21
               '   Case "20,00"
               '      valCoefficiente = 1.2
               '   Case "10,00"
               '      valCoefficiente = 1.1
               '   Case "4,00"
               '      valCoefficiente = 1.04
               '   Case Else
               '      valCoefficiente = 0.0
               'End Select

               'If valCoefficiente <> 0.0 Then
               valImponibile = CalcolaImponibileIva(g_frmContoPos.Text, valDaPagare) '(valDaPagare / valCoefficiente)
               'Else
               '   valImponibile = 0.0
               'End If

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

         eui_txtTotaliRep1ImponibileScontato.Text = VALORE_ZERO
         eui_txtTotaliRep2ImponibileScontato.Text = VALORE_ZERO
         eui_txtTotaliRep3ImponibileScontato.Text = VALORE_ZERO
         eui_txtTotaliRep4ImponibileScontato.Text = VALORE_ZERO

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

            .Tipo = tipoDocumento
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

            .ImpLordoRep1 = VALORE_ZERO
            .ImpLordoRep2 = VALORE_ZERO
            .ImpLordoRep3 = VALORE_ZERO
            .ImpLordoRep4 = VALORE_ZERO
            .ImpScontatoRep1 = VALORE_ZERO
            .ImpScontatoRep2 = VALORE_ZERO
            .ImpScontatoRep3 = VALORE_ZERO
            .ImpScontatoRep4 = VALORE_ZERO
            .AliquotaIvaRep1 = eui_txtTotaliRep1Aliquota.Text
            .AliquotaIvaRep2 = VALORE_ZERO
            .AliquotaIvaRep3 = VALORE_ZERO
            .AliquotaIvaRep4 = VALORE_ZERO
            .ImpostaRep1 = VALORE_ZERO
            .ImpostaRep2 = VALORE_ZERO
            .ImpostaRep3 = VALORE_ZERO
            .ImpostaRep4 = VALORE_ZERO

            ' .PercSconto = eui_txtSconto.Text
            ' .PerServizio = eui_txtServizio.Text
            .Sconto = eui_txtTotaliSconto.Text
            .TipoSconto = String.Empty
            .Servizio = eui_txtTotaliServizio.Text
            .TipoServizio = String.Empty
            .Coperto = eui_txtTotaliCoperto.Text
            .Contanti = eui_txtTotaliContanti.Text
            .Carte = eui_txtTotaliCarte.Text
            .BuoniPasto = eui_txtTotaliBuoni.Text
            .BuoniPastoIncassare = eui_txtTotaliBuoni.Text
            .Note = eui_txtNote.Text
            .Chiuso = "No"

            If eui_txtTotaliCarte.Text <> VALORE_ZERO Then
               .TipoPagamento = eui_cmbTipoPagamento.Text & ": € " & CFormatta.FormattaNumeroDouble(eui_txtTotaliCarte.Text)
            Else
               If eui_txtTotaliContanti.Text <> VALORE_ZERO Then
                  .TipoPagamento = "Contanti"
               Else
                  .TipoPagamento = String.Empty
               End If
            End If

            .Tavolo = eui_txtTavolo.Text
            .Cameriere = eui_txtCameriere.Text
            .Sospeso = CFormatta.FormattaNumeroDouble(valSospeso)
            .SospesoIncassare = CFormatta.FormattaNumeroDouble(valSospeso)
            .TotDoc = CFormatta.FormattaNumeroDouble(Convert.ToDouble(valDaPagare))

            If tipoDocumento = TIPO_DOC_FF Then
               ' Calcola l'IVA.
               Dim valImposta As Double
               Dim valImponibile As Double

               ' TODO: DA MODIFICARE!!!              
               If IsNumeric(eui_txtTotaliRep1Aliquota.Text) = True Then

                  Dim valCoefficiente As Double
                  Select Case eui_txtTotaliRep1Aliquota.Text
                     Case "22,00"
                        valCoefficiente = 1.22
                     Case "21,00"
                        valCoefficiente = 1.21
                     Case "20,00"
                        valCoefficiente = 1.2
                     Case "10,00"
                        valCoefficiente = 1.1
                     Case "4,00"
                        valCoefficiente = 1.04
                     Case Else
                        valCoefficiente = 0.0
                  End Select

                  If valCoefficiente <> 0.0 Then
                     valImponibile = (valDaPagare / valCoefficiente)
                  Else
                     valImponibile = 0.0
                  End If

                  valImposta = CalcolaPercentuale(valImponibile, Convert.ToDouble(eui_txtTotaliRep1Aliquota.Text))
               Else
                  valImposta = 0.0
                  eui_txtTotaliRep1Aliquota.Text = VALORE_ZERO
               End If

               .Imponibile = CFormatta.FormattaNumeroDouble(valImponibile)
               .Iva = eui_txtTotaliRep1Aliquota.Text
               .Imposta = CFormatta.FormattaNumeroDouble(valImposta)
            Else
               .Imponibile = VALORE_ZERO
               .Iva = VALORE_ZERO
               .Imposta = VALORE_ZERO
            End If

            .InserisciDati(TAB_DOCUMENTI)
         End With

         ' SALVA I DETTAGLI DEL DOCUMENTO.
         Dim sql As String
         ' Apre la connessione.
         cn.Open()

         'If eui_cmdTipoConto.Text.ToUpper = "UNICO" Then
         ' SALVA I DETTAGLI PER IL COPERTO.
         If Doc.Coperto <> VALORE_ZERO Then
            ' Avvia una transazione.
            tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
            ' Crea la stringa di inserimento.
            sql = String.Format("INSERT INTO {0} (RifDoc, Descrizione, Quantità, ImportoNetto) " &
                                             "VALUES(@RifDoc, @Descrizione, @Quantità, @ImportoNetto)", TAB_DETTAGLI_DOCUMENTI)
            ' Crea il comando per la connessione corrente.
            Dim cmdInsert As New OleDbCommand(sql, cn, tr)
            cmdInsert.Parameters.AddWithValue("@RifDoc", LeggiUltimoRecord(TAB_DOCUMENTI))
            cmdInsert.Parameters.AddWithValue("@Descrizione", "COPERTO")
            cmdInsert.Parameters.AddWithValue("@Quantità", NumCopertiRistorante)
            cmdInsert.Parameters.AddWithValue("@ImportoNetto", Doc.Coperto)
            ' Esegue il comando.
            Dim Record As Integer = cmdInsert.ExecuteNonQuery()
            ' Conferma transazione.
            tr.Commit()
         End If
         'End If

         ' SALVA I DETTAGLI PER I PIATTI.
         Dim i As Integer
         For i = 0 To dgvDettagli.Rows.Count - 2 ' L'ultima riga è quella di inserimento dati.
            'Dim colore As Color = lstvDettagli.Items(i).BackColor
            'If colore.Equals(Color.LightCoral) = False Then

            ' Avvia una transazione.
            tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
            ' Crea la stringa di eliminazione.
            sql = String.Format("INSERT INTO {0} (RifDoc, Descrizione, Quantità, ValoreUnitario, ImportoNetto) " &
                                          "VALUES(@RifDoc, @Descrizione, @Quantità, @ValoreUnitario, @ImportoNetto)", TAB_DETTAGLI_DOCUMENTI)

            ' Crea il comando per la connessione corrente.
            Dim cmdInsert As New OleDbCommand(sql, cn, tr)

            ' In caso di variante senza una quantità.
            Dim quantità As String

            If dgvDettagli.Rows(i).Cells(clnQta.Name).Value <> String.Empty Then
               quantità = dgvDettagli.Rows(i).Cells(clnQta.Name).Value
            Else
               quantità = VALORE_ZERO
            End If

            cmdInsert.Parameters.AddWithValue("@RifDoc", LeggiUltimoRecord(TAB_DOCUMENTI))
            cmdInsert.Parameters.AddWithValue("@Descrizione", FormattaApici(dgvDettagli.Rows(i).Cells(clnDescrizione.Name).Value))
            cmdInsert.Parameters.AddWithValue("@Quantità", quantità)
            cmdInsert.Parameters.AddWithValue("@ValoreUnitario", dgvDettagli.Rows(i).Cells(clnPrezzo.Name).Value) ' B_TODO: Modifica per Retail.
            cmdInsert.Parameters.AddWithValue("@ImportoNetto", dgvDettagli.Rows(i).Cells(clnImporto.Name).Value)

            ' Esegue il comando.
            Dim Record As Integer = cmdInsert.ExecuteNonQuery()
            ' Conferma transazione.
            tr.Commit()

            'End If
         Next

         ' If eui_cmdTipoConto.Text.ToUpper <> "ALLA ROMANA" Then
         ' SALVA I DETTAGLI PER LO SCONTO.
         If Doc.Sconto <> VALORE_ZERO Then
            ' Avvia una transazione.
            tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
            ' Crea la stringa di eliminazione.
            sql = String.Format("INSERT INTO {0} (RifDoc, Descrizione, Quantità, ImportoNetto) " &
                                             "VALUES(@RifDoc, @Descrizione, @Quantità, @ImportoNetto)", TAB_DETTAGLI_DOCUMENTI)
            ' Crea il comando per la connessione corrente.
            Dim cmdInsert As New OleDbCommand(sql, cn, tr)
            cmdInsert.Parameters.AddWithValue("@RifDoc", LeggiUltimoRecord(TAB_DOCUMENTI))
            cmdInsert.Parameters.AddWithValue("@Descrizione", "SCONTO")
            cmdInsert.Parameters.AddWithValue("@Quantità", VALORE_ZERO)
            cmdInsert.Parameters.AddWithValue("@ImportoNetto", "-" & Doc.Sconto)
            ' Esegue il comando.
            Dim Record As Integer = cmdInsert.ExecuteNonQuery()
            ' Conferma transazione.
            tr.Commit()
         End If
         'End If


         ' If eui_cmdTipoConto.Text.ToUpper <> "ALLA ROMANA" Then
         ' SALVA I DETTAGLI PER IL SERVIZIO.
         If Doc.Servizio <> VALORE_ZERO Then
            ' Avvia una transazione.
            tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
            ' Crea la stringa di eliminazione.
            sql = String.Format("INSERT INTO {0} (RifDoc, Descrizione, Quantità, ImportoNetto) " &
                                             "VALUES(@RifDoc, @Descrizione, @Quantità, @ImportoNetto)", TAB_DETTAGLI_DOCUMENTI)
            ' Crea il comando per la connessione corrente.
            Dim cmdInsert As New OleDbCommand(sql, cn, tr)
            cmdInsert.Parameters.AddWithValue("@RifDoc", LeggiUltimoRecord(TAB_DOCUMENTI))
            cmdInsert.Parameters.AddWithValue("@Descrizione", "SERVIZIO")
            cmdInsert.Parameters.AddWithValue("@Quantità", VALORE_ZERO)
            cmdInsert.Parameters.AddWithValue("@ImportoNetto", Doc.Servizio)
            ' Esegue il comando.
            Dim Record As Integer = cmdInsert.ExecuteNonQuery()
            ' Conferma transazione.
            tr.Commit()
         End If
         ' End If

         ' Salva il Numero del prossimo documento da stampare.
         SalvaNumeroDocFiscaleConfig(TAB_DOCUMENTI, tipoDocumento, Convert.ToInt32(eui_txtNumero.Text))

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

   ' TODO: SOSTITUIRE TUTTI I DECIMAL CON I DOUBLE!!!
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
         Dim importo As Decimal

         ' Somma tutti gli importi delle righe del documento.
         Dim i As Integer
         For i = 0 To dgvDettagli.Rows.Count - 1
            importo = (importo + Convert.ToDecimal(dgvDettagli.Rows(i).Cells(clnImporto.Name).Value))
         Next

         ' Aggiorna i totali.
         eui_txtTotaleDocumento.Text = CFormatta.FormattaEuro(importo)
         eui_txtTotaleConto.Text = CFormatta.FormattaEuro(importo)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   ' TODO: DA VERIFICARE!!!
   Private Sub CalcolaImportoTotaleIva()
      Try
         ' Importo.
         Dim importo1 As Decimal
         Dim importo2 As Decimal
         Dim importo3 As Decimal
         Dim importo4 As Decimal

         Dim percIva1 As Integer
         Dim percIva2 As Integer
         Dim percIva3 As Integer
         Dim percIva4 As Integer

         Dim valTotaleImpostaRep1 As Decimal
         Dim valTotaleImpostaRep2 As Decimal
         Dim valTotaleImpostaRep3 As Decimal
         Dim valTotaleImpostaRep4 As Decimal

         Dim valTotaleImponibile1 As Decimal
         Dim valTotaleImponibile2 As Decimal
         Dim valTotaleImponibile3 As Decimal
         Dim valTotaleImponibile4 As Decimal

         'Dim valTotaleImponibileLordo1 As Decimal
         'Dim valTotaleImponibileLordo2 As Decimal
         'Dim valTotaleImponibileLordo3 As Decimal
         'Dim valTotaleImponibileLordo4 As Decimal

         ' Somma tutti gli importi delle righe del documento.
         Dim i As Integer
         For i = 0 To dgvDettagli.Rows.Count - 1

            Select Case dgvDettagli.Rows(i).Cells(clnRepartoIva.Name).Value
               Case "Reparto 1"
                  importo1 = Convert.ToDecimal(dgvDettagli.Rows(i).Cells(clnImporto.Name).Value)
                  percIva1 = Convert.ToInt32(dgvDettagli.Rows(i).Cells(clnIva.Name).Value)
                  valTotaleImponibile1 = valTotaleImponibile1 + CalcolaImponibileIva(percIva1.ToString, importo1)
                  valTotaleImpostaRep1 = CalcolaPercentuale(valTotaleImponibile1, percIva1)

                  '' In caso di sconto calcola l'imponibile lordo.
                  'If importo1 < importoLordo Then
                  '   valTotaleImponibileLordo1 = valTotaleImponibileLordo1 + CalcolaImponibileIva(percIva1.ToString, importoLordo)
                  'Else
                  '   valTotaleImponibileLordo1 = 0.0
                  'End If

               Case "Reparto 2"
                  importo2 = Convert.ToDecimal(dgvDettagli.Rows(i).Cells(clnImporto.Name).Value)
                  percIva2 = Convert.ToInt32(dgvDettagli.Rows(i).Cells(clnIva.Name).Value)
                  valTotaleImponibile2 = valTotaleImponibile2 + CalcolaImponibileIva(percIva2.ToString, importo2)
                  valTotaleImpostaRep2 = CalcolaPercentuale(valTotaleImponibile2, percIva2)

                  '' In caso di sconto calcola l'imponibile lordo.
                  'If importo2 < importoLordo Then
                  '   valTotaleImponibileLordo2 = valTotaleImponibileLordo2 + CalcolaImponibileIva(percIva2.ToString, importoLordo)
                  'Else
                  '   valTotaleImponibileLordo2 = 0.0
                  'End If

               Case "Reparto 3"
                  importo3 = Convert.ToDecimal(dgvDettagli.Rows(i).Cells(clnImporto.Name).Value)
                  percIva3 = Convert.ToInt32(dgvDettagli.Rows(i).Cells(clnIva.Name).Value)
                  valTotaleImponibile3 = valTotaleImponibile3 + CalcolaImponibileIva(percIva3.ToString, importo3)
                  valTotaleImpostaRep3 = CalcolaPercentuale(valTotaleImponibile3, percIva3)

                  '' In caso di sconto calcola l'imponibile lordo.
                  'If importo3 < importoLordo Then
                  '   valTotaleImponibileLordo3 = valTotaleImponibileLordo3 + CalcolaImponibileIva(percIva3.ToString, importoLordo)
                  'Else
                  '   valTotaleImponibileLordo3 = 0.0
                  'End If

               Case "Reparto 4"
                  importo4 = Convert.ToDecimal(dgvDettagli.Rows(i).Cells(clnImporto.Name).Value)
                  percIva4 = Convert.ToInt32(dgvDettagli.Rows(i).Cells(clnIva.Name).Value)
                  valTotaleImponibile4 = valTotaleImponibile4 + CalcolaImponibileIva(percIva4.ToString, importo4)
                  valTotaleImpostaRep4 = CalcolaPercentuale(valTotaleImponibile4, percIva4)

                  '' In caso di sconto calcola l'imponibile lordo.
                  'If importo4 < importoLordo Then
                  '   valTotaleImponibileLordo4 = valTotaleImponibileLordo4 + CalcolaImponibileIva(percIva4.ToString, importoLordo)
                  'Else
                  '   valTotaleImponibileLordo4 = 0.0
                  'End If
            End Select
         Next

         ' Aggiorna i totali.

         ' Aliquote Iva.
         eui_txtTotaliRep1Aliquota.Text = percIva1.ToString
         eui_txtTotaliRep2Aliquota.Text = percIva2.ToString
         eui_txtTotaliRep3Aliquota.Text = percIva3.ToString
         eui_txtTotaliRep4Aliquota.Text = percIva4.ToString

         'If valTotaleImponibileLordo1 = 0.0 Then
         ' Imponibile.
         eui_txtTotaliRep1ImponibileLordo.Text = CFormatta.FormattaEuro(valTotaleImponibile1)
         eui_txtTotaliRep2ImponibileLordo.Text = CFormatta.FormattaEuro(valTotaleImponibile2)
         eui_txtTotaliRep3ImponibileLordo.Text = CFormatta.FormattaEuro(valTotaleImponibile3)
         eui_txtTotaliRep4ImponibileLordo.Text = CFormatta.FormattaEuro(valTotaleImponibile4)

         '' Imponibile scontato.
         'eui_txtTotaliRep1ImponibileScontato.Text = VALORE_ZERO
         'eui_txtTotaliRep2ImponibileScontato.Text = VALORE_ZERO
         'eui_txtTotaliRep3ImponibileScontato.Text = VALORE_ZERO
         'eui_txtTotaliRep4ImponibileScontato.Text = VALORE_ZERO
         'Else
         '' Imponibile.
         'eui_txtTotaliRep1ImponibileLordo.Text = CFormatta.FormattaEuro(valTotaleImponibileLordo1)
         'eui_txtTotaliRep2ImponibileLordo.Text = CFormatta.FormattaEuro(valTotaleImponibileLordo2)
         'eui_txtTotaliRep3ImponibileLordo.Text = CFormatta.FormattaEuro(valTotaleImponibileLordo3)
         'eui_txtTotaliRep4ImponibileLordo.Text = CFormatta.FormattaEuro(valTotaleImponibileLordo4)

         '' Imponibile scontato.
         'eui_txtTotaliRep1ImponibileScontato.Text = CFormatta.FormattaEuro(valTotaleImponibile1)
         'eui_txtTotaliRep2ImponibileScontato.Text = CFormatta.FormattaEuro(valTotaleImponibile2)
         'eui_txtTotaliRep3ImponibileScontato.Text = CFormatta.FormattaEuro(valTotaleImponibile3)
         'eui_txtTotaliRep4ImponibileScontato.Text = CFormatta.FormattaEuro(valTotaleImponibile4)
         'End If

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

         'Select Case nomeFinestra
         '   Case "ContoPos"
         '      LeggiDatiConto()

         '   Case "ElencoDoc"
         NuovoDocumento()

         'End Select

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
         ' TODO: Valutare se leggere l'aliquota iva del cliente.
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

   Private Sub eui_cmdInsAccessoriServizi_Click(sender As Object, e As EventArgs) Handles eui_cmdInsAccessoriServizi.Click
      'Dim i As Integer = g_frmDocumento.dgvDettagli.Rows.Count
      'g_frmDocumento.dgvDettagli.Rows.Insert(i - 1, 1)
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
         g_frmDocumento.dgvDettagli.Rows.Add()
         g_frmDocumento.dgvDettagli.Rows.Item(g_frmDocumento.dgvDettagli.Rows.Count - 2).Selected = True
         g_frmDocumento.dgvDettagli.Rows.Item(g_frmDocumento.dgvDettagli.Rows.Count - 2).Cells.Item(0).Selected = True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdEliminaRiga_Click(sender As Object, e As EventArgs) Handles eui_cmdEliminaRiga.Click
      Try
         dgvDettagli.Focus()
         g_frmDocumento.dgvDettagli.Rows.Remove(g_frmDocumento.dgvDettagli.CurrentRow)

         CalcolaImportoRigaDoc()
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
         g_frmDocumento.dgvDettagli.Rows.Clear()
         g_frmDocumento.dgvDettagli.Rows.Add()

         CalcolaImportoRigaDoc()
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

               Dim valCell As Decimal
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


End Class
