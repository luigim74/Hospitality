Public Class ListaPiatti

   Const NOME_TABELLA As String = "Piatti"
   Dim CFormatta As New ClsFormatta
   Private DatiConfig As AppConfig


   Public Sub New()

      ' Chiamata richiesta dalla finestra di progettazione.
      InitializeComponent()

      ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().

   End Sub

   Private Sub ListaPiatti_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

      If CaricaLista(NOME_TABELLA) = True Then
         Exit Sub
      End If
   End Sub

   Private Sub eui_cmdAnnulla_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdAnnulla.Click
      Me.Close()
   End Sub

   Private Sub eui_cmdInserisci_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdInserisci.Click
      Try
         Dim id As Integer = Convert.ToInt32(lvwPiatti.Items(lvwPiatti.FocusedItem.Index).Text)

         g_frmDocumento.dgvDettagli.Focus()

         InserisciElementi(NOME_TABELLA, id)
         'g_frmDatiPrenRisorse.CalcolaTotaleConto()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         Me.Close()

      End Try
   End Sub

   Private Sub lvwPiatti_DoubleClick(sender As Object, e As System.EventArgs) Handles lvwPiatti.DoubleClick
      eui_cmdInserisci.PerformClick()
   End Sub

   Public Function CaricaLista(ByVal tabella As String) As Boolean
      Dim caricata As Boolean = False
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim strDescrizione As String

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & "' ORDER BY Descrizione ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()
            ' Codice.
            lvwPiatti.Items.Add(dr.Item("Id"))
            'lvwAccessoriServizi.Items(lvwAccessoriServizi.Items.Count - 1).ForeColor = Color.FromArgb(dr.Item("Colore"))

            ' Descrizione.
            If IsDBNull(dr.Item("Descrizione")) = False Then
               lvwPiatti.Items(lvwPiatti.Items.Count - 1).SubItems.Add(dr.Item("Descrizione"))
            Else
               lvwPiatti.Items(lvwPiatti.Items.Count - 1).SubItems.Add("")
            End If

            ' Costo.
            If IsDBNull(dr.Item("Listino1")) = False Then
               Dim val As String = CFormatta.FormattaNumeroDouble(Convert.ToDouble(dr.Item("Listino1")))
               lvwPiatti.Items(lvwPiatti.Items.Count - 1).SubItems.Add(val)
            Else
               lvwPiatti.Items(lvwPiatti.Items.Count - 1).SubItems.Add(VALORE_ZERO)
            End If

            ' Stringa per registrare loperazione effettuata dall'operatore identificato.
            'strDescrizione = "(" & dr.Item("Descrizione") & ")"

            caricata = True
         Loop

         ' Registra loperazione effettuata dall'operatore identificato.
         'g_frmMain.RegistraOperazione(TipoOperazione.SelezionaPiatto, strDescrizione, MODULO_GESTIONE_POS)

         Return caricata

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

      Finally
         cn.Close()

      End Try
   End Function

   Public Sub InserisciElementi(ByVal tabella As String, ByVal id As Integer)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim strDescrizione As String
      Dim QTA As Integer = 1

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Id = " & id & " ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()
            ' Codice.
            If IsDBNull(dr.Item("Id")) = False Then
               g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnCodice.Name).Value = dr.Item("Id")
            Else
               g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnCodice.Name).Value = String.Empty
            End If

            ' Descrizione.
            If IsDBNull(dr.Item("Descrizione")) = False Then
               g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnDescrizione.Name).Value = dr.Item("Descrizione")
            Else
               g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnDescrizione.Name).Value = String.Empty
            End If

            ' Unità di misura.
            If IsDBNull(dr.Item("UnitàMisura")) = False Then
               g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnUm.Name).Value = dr.Item("UnitàMisura")
            Else
               g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnUm.Name).Value = String.Empty
            End If

            ' Quantità.
            g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnQta.Name).Value = "1,00"

            ' Listino.
            Select Case eui_dwnListino.Text
               Case "Listino 1"
                  If IsDBNull(dr.Item("Listino1")) = False Then
                     g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnPrezzo.Name).Value = dr.Item("Listino1")
                  Else
                     g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnPrezzo.Name).Value = String.Empty
                  End If

               Case "Listino 2"
                  If IsDBNull(dr.Item("Listino2")) = False Then
                     g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnPrezzo.Name).Value = dr.Item("Listino2")
                  Else
                     g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnPrezzo.Name).Value = String.Empty
                  End If

               Case "Listino 3"
                  If IsDBNull(dr.Item("Listino3")) = False Then
                     g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnPrezzo.Name).Value = dr.Item("Listino3")
                  Else
                     g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnPrezzo.Name).Value = String.Empty
                  End If

               Case "Listino 4"
                  If IsDBNull(dr.Item("Listino4")) = False Then
                     g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnPrezzo.Name).Value = dr.Item("Listino4")
                  Else
                     g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnPrezzo.Name).Value = String.Empty
                  End If

               Case Else
                  g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnPrezzo.Name).Value = dr.Item("Listino1")

            End Select

            ' Sconto %.
            g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnSconto.Name).Value = VALORE_ZERO

            ' Importo.
            g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnImporto.Name).Value = g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnPrezzo.Name).Value

            ' Aliquota Iva.
            If IsDBNull(dr.Item("AliquotaIva")) = False Then
               g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnIva.Name).Value = LeggiAliquotaIva(dr.Item("AliquotaIva"))
            Else
               g_frmDocumento.dgvDettagli.CurrentRow.Cells(g_frmDocumento.clnIva.Name).Value = AliquotaIvaRistorante
            End If

            ' Stringa per registrare loperazione effettuata dall'operatore identificato.
            'strDescrizione = "(" & dr.Item("Descrizione") & ")"

         Loop

         ' Registra loperazione effettuata dall'operatore identificato.
         'g_frmMain.RegistraOperazione(TipoOperazione.SelezionaPiatto, strDescrizione, MODULO_GESTIONE_POS)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub InserisciAccessoriServiziCamera(ByVal tabella As String, ByVal tipologia As String, ByVal id As Integer)
      '' Dichiara un oggetto connessione.
      'Dim cn As New OleDbConnection(ConnString)
      'Dim strDescrizione As String
      'Dim QTA As Integer = 1

      'Try
      '   cn.Open()

      '   Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Id = " & id & " ORDER BY Id ASC", cn)
      '   Dim dr As OleDbDataReader = cmd.ExecuteReader()


      '   Do While dr.Read()

      '      ' Indice.
      '      'g_frmPrenCamera.lvwAddebiti.Items.Add(g_frmPrenCamera.lvwAddebiti.Items.Count)

      '      ' Data.
      '      g_frmPrenCamera.lvwAddebiti.Items.Add(Today.ToShortDateString)

      '      ' Descrizione.
      '      If IsDBNull(dr.Item("Descrizione")) = False Then
      '         g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).SubItems.Add(dr.Item("Descrizione"))
      '      Else
      '         g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).SubItems.Add("")
      '      End If

      '      ' Stabilisce il gruppo di appartenenza.
      '      Dim valGruppo As Short
      '      Select Case tipologia
      '         Case "Accessorio"
      '            valGruppo = 1
      '         Case "Servizio"
      '            valGruppo = 2
      '         Case Else ' Articoli vari
      '            valGruppo = 0
      '      End Select

      '      ' Assegna il gruppo.
      '      g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).Group = g_frmPrenCamera.lvwAddebiti.Groups.Item(valGruppo)
      '      g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).ForeColor = Color.FromArgb(dr.Item("Colore"))

      '      ' Quantità.
      '      g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).SubItems.Add(QTA)

      '      ' Costo.
      '      If IsDBNull(dr.Item("Costo")) = False Then
      '         Dim val As String = CFormatta.FormattaNumeroDouble(Convert.ToDouble(dr.Item("Costo")))
      '         g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).SubItems.Add(val)
      '      Else
      '         g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).SubItems.Add(VALORE_ZERO)
      '      End If

      '      ' Stringa per registrare loperazione effettuata dall'operatore identificato.
      '      'strDescrizione = "(" & dr.Item("Descrizione") & ")"

      '   Loop

      '   ' Registra loperazione effettuata dall'operatore identificato.
      '   'g_frmMain.RegistraOperazione(TipoOperazione.SelezionaPiatto, strDescrizione, MODULO_GESTIONE_POS)

      'Catch ex As Exception
      '   ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '   err.GestisciErrore(ex.StackTrace, ex.Message)

      'Finally
      '   cn.Close()

      'End Try
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

   Private Sub eui_cmdListino1_Click(sender As Object, e As EventArgs) Handles eui_cmdListino1.Click
      Try
         eui_dwnListino.Text = sender.text

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdListino2_Click(sender As Object, e As EventArgs) Handles eui_cmdListino2.Click
      Try
         eui_dwnListino.Text = sender.text

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdListino3_Click(sender As Object, e As EventArgs) Handles eui_cmdListino3.Click
      Try
         eui_dwnListino.Text = sender.text

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdListino4_Click(sender As Object, e As EventArgs) Handles eui_cmdListino4.Click
      Try
         eui_dwnListino.Text = sender.text

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub
End Class