Public Class ListaDocumenti
   Const NOME_TABELLA As String = "Documenti"
   Const TIPO_DOC_PF As String = "Proforma"
   Const TIPO_DOC_CO As String = "Conto"

   Dim CFormatta As New ClsFormatta
   Dim DatiConfig As AppConfig
   Dim cliente As String

   Public Sub New(ByVal intestatario As String)

      ' La chiamata è richiesta dalla finestra di progettazione.
      InitializeComponent()

      cliente = intestatario

      ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().

   End Sub

   Private Sub ListaDocumenti_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      If CaricaLista(NOME_TABELLA) = True Then
         Exit Sub
      End If
   End Sub

   Private Sub eui_cmdImporta_Click(sender As Object, e As EventArgs) Handles eui_cmdImporta.Click

   End Sub

   Private Sub eui_cmdAnnulla_Click(sender As Object, e As EventArgs) Handles eui_cmdAnnulla.Click

   End Sub

   Private Sub lvwPiatti_DoubleClick(sender As Object, e As EventArgs) Handles lvwPiatti.DoubleClick
      eui_cmdImporta.PerformClick()
   End Sub

   Public Function CaricaLista(ByVal tabella As String) As Boolean
      Dim caricata As Boolean = False
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim sql As String
      Dim strDescrizione As String

      Try
         cn.Open()

         ' Filtra i documenti in base al cliente.
         If cliente <> String.Empty Then
            sql = "SELECT * FROM " & tabella & " WHERE Cliente = '" & cliente & "' AND TipoDoc = '" & TIPO_DOC_CO & "' OR TipoDoc = '" & TIPO_DOC_PF & "' ORDER BY Id ASC"
         Else
            sql = "SELECT * FROM " & tabella & " WHERE TipoDoc = '" & TIPO_DOC_CO & "' OR TipoDoc = '" & TIPO_DOC_PF & "' ORDER BY Id ASC"
         End If

         Dim cmd As New OleDbCommand(sql, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()
            ' Numero.
            If IsDBNull(dr.Item("NumDoc")) = False Then
               lvwPiatti.Items.Add(dr.Item("NumDoc"))
            Else
               lvwPiatti.Items.Add(String.Empty)
            End If

            ' Data.
            If IsDBNull(dr.Item("DataDoc")) = False Then
               lvwPiatti.Items(lvwPiatti.Items.Count - 1).SubItems.Add(dr.Item("DataDoc"))
            Else
               lvwPiatti.Items(lvwPiatti.Items.Count - 1).SubItems.Add(String.Empty)
            End If

            ' Ora.
            If IsDBNull(dr.Item("OraDoc")) = False Then
               lvwPiatti.Items(lvwPiatti.Items.Count - 1).SubItems.Add(dr.Item("OraDoc"))
            Else
               lvwPiatti.Items(lvwPiatti.Items.Count - 1).SubItems.Add(String.Empty)
            End If

            ' Documento.
            If IsDBNull(dr.Item("TipoDoc")) = False Then
               lvwPiatti.Items(lvwPiatti.Items.Count - 1).SubItems.Add(dr.Item("TipoDoc"))
            Else
               lvwPiatti.Items(lvwPiatti.Items.Count - 1).SubItems.Add(String.Empty)
            End If

            ' Cliente.
            If IsDBNull(dr.Item("Cliente")) = False Then
               lvwPiatti.Items(lvwPiatti.Items.Count - 1).SubItems.Add(dr.Item("Cliente"))
            Else
               lvwPiatti.Items(lvwPiatti.Items.Count - 1).SubItems.Add(String.Empty)
            End If

            ' Stato.
            If IsDBNull(dr.Item("StatoDoc")) = False Then
               lvwPiatti.Items(lvwPiatti.Items.Count - 1).SubItems.Add(dr.Item("StatoDoc"))
            Else
               lvwPiatti.Items(lvwPiatti.Items.Count - 1).SubItems.Add(String.Empty)
            End If

            ' Totale.
            If IsDBNull(dr.Item("TotDoc")) = False Then
               Dim val As String = CFormatta.FormattaNumeroDouble(Convert.ToDouble(dr.Item("TotDoc")))
               lvwPiatti.Items(lvwPiatti.Items.Count - 1).SubItems.Add(val)
            Else
               lvwPiatti.Items(lvwPiatti.Items.Count - 1).SubItems.Add(VALORE_ZERO)
            End If

            ' Codice.
            lvwPiatti.Items(lvwPiatti.Items.Count - 1).SubItems.Add(dr.Item("Id"))
            'lvwAccessoriServizi.Items(lvwAccessoriServizi.Items.Count - 1).ForeColor = Color.FromArgb(dr.Item("Colore"))

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

End Class