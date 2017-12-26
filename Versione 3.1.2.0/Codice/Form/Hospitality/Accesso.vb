Imports System.Data.OleDb

Public Class frmAccesso
   Inherits System.Windows.Forms.Form

#Region " Codice generato da Progettazione Windows Form "

   Public Sub New()
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

      'Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent()
   End Sub

   'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
   Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing Then
         If Not (components Is Nothing) Then
            components.Dispose()
         End If
      End If
      MyBase.Dispose(disposing)
   End Sub

   'Richiesto da Progettazione Windows Form
   Private components As System.ComponentModel.IContainer

   'NOTE: la procedura che segue è richiesta da Progettazione Windows Form.
   'Può essere modificata in Progettazione Windows Form.  
   'Non modificarla nell'editor del codice.
   Public WithEvents label As System.Windows.Forms.Label
   Friend WithEvents txtPassword As System.Windows.Forms.TextBox
   Public WithEvents lblVerifica As System.Windows.Forms.Label
   Friend WithEvents cmbOperatore As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents eui_cmdAnnulla As Elegant.Ui.Button
   Friend WithEvents eui_cmdOK As Elegant.Ui.Button
   Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAccesso))
      Me.label = New System.Windows.Forms.Label()
      Me.txtPassword = New System.Windows.Forms.TextBox()
      Me.lblVerifica = New System.Windows.Forms.Label()
      Me.cmbOperatore = New System.Windows.Forms.ComboBox()
      Me.PictureBox2 = New System.Windows.Forms.PictureBox()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.eui_cmdAnnulla = New Elegant.Ui.Button()
      Me.eui_cmdOK = New Elegant.Ui.Button()
      CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'label
      '
      Me.label.AutoSize = True
      Me.label.BackColor = System.Drawing.Color.Transparent
      Me.label.Cursor = System.Windows.Forms.Cursors.Default
      Me.label.ForeColor = System.Drawing.Color.Black
      Me.label.Location = New System.Drawing.Point(176, 63)
      Me.label.Name = "label"
      Me.label.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.label.Size = New System.Drawing.Size(56, 13)
      Me.label.TabIndex = 182
      Me.label.Text = "Password:"
      '
      'txtPassword
      '
      Me.txtPassword.Location = New System.Drawing.Point(176, 80)
      Me.txtPassword.MaxLength = 100
      Me.txtPassword.Name = "txtPassword"
      Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
      Me.txtPassword.Size = New System.Drawing.Size(208, 20)
      Me.txtPassword.TabIndex = 1
      '
      'lblVerifica
      '
      Me.lblVerifica.AutoSize = True
      Me.lblVerifica.BackColor = System.Drawing.Color.Transparent
      Me.lblVerifica.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblVerifica.ForeColor = System.Drawing.Color.Black
      Me.lblVerifica.Location = New System.Drawing.Point(176, 15)
      Me.lblVerifica.Name = "lblVerifica"
      Me.lblVerifica.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lblVerifica.Size = New System.Drawing.Size(57, 13)
      Me.lblVerifica.TabIndex = 181
      Me.lblVerifica.Text = "Operatore:"
      '
      'cmbOperatore
      '
      Me.cmbOperatore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbOperatore.Location = New System.Drawing.Point(176, 32)
      Me.cmbOperatore.Name = "cmbOperatore"
      Me.cmbOperatore.Size = New System.Drawing.Size(208, 21)
      Me.cmbOperatore.TabIndex = 0
      '
      'PictureBox2
      '
      Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
      Me.PictureBox2.Location = New System.Drawing.Point(0, 0)
      Me.PictureBox2.Name = "PictureBox2"
      Me.PictureBox2.Size = New System.Drawing.Size(160, 168)
      Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
      Me.PictureBox2.TabIndex = 185
      Me.PictureBox2.TabStop = False
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'eui_cmdAnnulla
      '
      Me.eui_cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.eui_cmdAnnulla.Id = "5815fb08-3511-4c54-a173-cd48cbc7eb17"
      Me.eui_cmdAnnulla.KeyTip = "A"
      Me.eui_cmdAnnulla.Location = New System.Drawing.Point(304, 120)
      Me.eui_cmdAnnulla.Name = "eui_cmdAnnulla"
      Me.eui_cmdAnnulla.ScreenTip.Caption = "Annulla"
      Me.eui_cmdAnnulla.ScreenTip.Text = "Annulla l'operazione e chiude la finestra"
      Me.eui_cmdAnnulla.Size = New System.Drawing.Size(80, 24)
      Me.eui_cmdAnnulla.TabIndex = 187
      Me.eui_cmdAnnulla.Text = "&Annulla"
      '
      'eui_cmdOK
      '
      Me.eui_cmdOK.Id = "3aec9268-18c4-4062-85b2-1459f457e1f3"
      Me.eui_cmdOK.KeyTip = "O"
      Me.eui_cmdOK.Location = New System.Drawing.Point(216, 120)
      Me.eui_cmdOK.Name = "eui_cmdOK"
      Me.eui_cmdOK.ScreenTip.Caption = "OK"
      Me.eui_cmdOK.ScreenTip.Text = "Conferma l'operazione  e chiude la finestra." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Nella versione Dimostrativa non è" &
    " necessario specificare la password. Premere sul tasto OK."
      Me.eui_cmdOK.Size = New System.Drawing.Size(80, 24)
      Me.eui_cmdOK.TabIndex = 186
      Me.eui_cmdOK.Text = "&OK"
      '
      'frmAccesso
      '
      Me.AcceptButton = Me.eui_cmdOK
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.eui_cmdAnnulla
      Me.ClientSize = New System.Drawing.Size(405, 169)
      Me.Controls.Add(Me.eui_cmdAnnulla)
      Me.Controls.Add(Me.eui_cmdOK)
      Me.Controls.Add(Me.PictureBox2)
      Me.Controls.Add(Me.cmbOperatore)
      Me.Controls.Add(Me.label)
      Me.Controls.Add(Me.txtPassword)
      Me.Controls.Add(Me.lblVerifica)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmAccesso"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Seleziona operatore"
      CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Dim TAB_OPERATORI = "Operatori"
   Dim TAB_GRUPPI = "Gruppi"

   Dim DatiConfig As AppConfig

   Private Function LeggiDatiConfig() As String
      Try
         Dim ultimoNomeOperatore As String

         ultimoNomeOperatore = DatiConfig.GetValue("UltimoNomeOperatore")
         If ultimoNomeOperatore = String.Empty Then
            ultimoNomeOperatore = "Amministratore"
         End If

         Return ultimoNomeOperatore

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Function

   Private Sub SalvaDatiConfig(ByVal codiceOperatore As String, ByVal ultimoNomeOperatore As String)
      Try

         If ultimoNomeOperatore = String.Empty Then
            DatiConfig.SetValue("CodiceOperatore", "1")
            DatiConfig.SetValue("UltimoNomeOperatore", "Amministratore")
         Else
            DatiConfig.SetValue("CodiceOperatore", codiceOperatore)
            DatiConfig.SetValue("UltimoNomeOperatore", ultimoNomeOperatore)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub CaricaListaOperatori(ByVal cmb As ComboBox, ByVal tabella As String)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read
            cmb.Items.Add(dr.Item("NomeUtente"))
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub LeggiDatiOperatore(ByVal nome As String, ByVal tabella As String)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE NomeUtente = '" & nome & "' ORDER BY NomeUtente ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read
            operatore.Codice = dr.Item("Id").ToString
            operatore.Nome = dr.Item("NomeUtente")
            operatore.Pwd = dr.Item("Password")
            operatore.Gruppo = dr.Item("Gruppo")
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub LeggiDatiAccesso(ByVal nome As String, ByVal tabella As String)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE NomeGruppo = '" & nome & "' ORDER BY NomeGruppo ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read
            operatore.Amministratore = dr.Item("Amministratore")
            operatore.AnagAziende = dr.Item("AnagAziende")
            operatore.AnagCamerieri = dr.Item("AnagCamerieri")
            operatore.AnagCatPiatti = dr.Item("AnagCatPiatti")
            operatore.AnagClienti = dr.Item("AnagClienti")
            operatore.AnagDatiAzienda = dr.Item("AnagDatiAzienda")
            operatore.AnagFornitori = dr.Item("AnagFornitori")
            operatore.AnagPiatti = dr.Item("AnagPiatti")
            operatore.AnagSale = dr.Item("AnagSale")
            operatore.AnagTavoli = dr.Item("AnagTavoli")
            operatore.AnagRisorse = dr.Item("AnagRisorse")
            operatore.AnagAccessoriServizi = dr.Item("AnagAccessoriServizi")
            operatore.ArchiviBackup = dr.Item("ArchiviBackup")
            operatore.ArchiviCompatta = dr.Item("ArchiviCompatta")
            operatore.ArchiviPulizia = dr.Item("ArchiviPulizia")
            operatore.TabAttività = dr.Item("TabAttività")
            operatore.TabCatClienti = dr.Item("TabCatClienti")
            operatore.TabCatMerce = dr.Item("TabCatMerce")
            operatore.TabFormeCortesia = dr.Item("TabFormeCortesia")
            operatore.TabMagazzini = dr.Item("TabMagazzini")
            operatore.TabMsg = dr.Item("TabMsg")
            operatore.TabNazioni = dr.Item("TabNazioni")
            operatore.TabPagamenti = dr.Item("TabPagamenti")
            operatore.TabPiani = dr.Item("TabPiani")
            operatore.TabReparti = dr.Item("TabReparti")
            operatore.TabScaffali = dr.Item("TabScaffali")
            ' DA_FARE_B: GESTIONE DOCUMENTI - Tipo documenti eliminata dal menu - Sostituire con tabella Causali Documenti.
            'operatore.TabTipoDoc = dr.Item("TabTipoDoc")
            operatore.TabUbicazioni = dr.Item("TabUbicazioni")
            operatore.TabUM = dr.Item("TabUM")
            operatore.TabTipoRisorse = dr.Item("TabTipoRisorse")
            operatore.ContChiusura = dr.Item("ContChiusura")
            operatore.ContCorrispettivi = dr.Item("ContCorrispettivi")
            operatore.ContDoc = dr.Item("ContDoc")
            operatore.ContPrimaNota = dr.Item("ContPrimaNota")
            operatore.GestAcquisti = dr.Item("GestAcquisti")
            operatore.GestGruppi = dr.Item("GestGruppi")
            operatore.GestOperatori = dr.Item("GestOperatori")
            operatore.GestPrenSale = dr.Item("GestPrenSale")
            operatore.GestPrenTavoli = dr.Item("GestPrenTavoli")
            operatore.GestPrenRisorse = dr.Item("GestPrenRisorse")
            operatore.GestPlanningRisorse = dr.Item("GestPlanningRisorse")
            operatore.GestStatRisorse = dr.Item("GestStatRisorse")
            operatore.GestPuntoCassa = dr.Item("GestPuntoCassa")
            operatore.GestStatistiche = dr.Item("GestStatistiche")
            operatore.GestTavoli = dr.Item("GestTavoli")
            operatore.MagArticoli = dr.Item("MagArticoli")
            operatore.MagInventario = dr.Item("MagInventario")
            operatore.MagMovimenti = dr.Item("MagMov")
            operatore.MagScorte = dr.Item("MagScorte")
            operatore.StruCap = dr.Item("StruCap")
            operatore.StruCodiciBarre = dr.Item("StruCodiciBarre")
            operatore.StruDispTavoli = dr.Item("StruDispTavoli")
            operatore.StruMsg = dr.Item("StruMsg")
            operatore.StruMenù = dr.Item("StruMenù")
            operatore.VisOpzioni = dr.Item("VisOpzioni")
            operatore.VisErrori = dr.Item("VisErrori")
            operatore.VisOperazioni = dr.Item("VisOperazioni")
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Sub frmPassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig

         g_frmMain.eui_cmdOperatore.Text = String.Empty

         operatore.EliminaDati()

         CaricaListaOperatori(cmbOperatore, TAB_OPERATORI)

         cmbOperatore.SelectedItem = LeggiDatiConfig()

         cmbOperatore.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdAnnulla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles eui_cmdAnnulla.Click
      Me.DialogResult = DialogResult.Cancel
      Me.Close()
   End Sub

   Private Sub eui_cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles eui_cmdOK.Click
      Try
         LeggiDatiOperatore(cmbOperatore.Text, TAB_OPERATORI)

         Dim pwdInChiaro As String = LeggiPwd(operatore.Pwd)

         If txtPassword.Text = pwdInChiaro Then
            Me.DialogResult = DialogResult.OK
            g_frmMain.eui_cmdOperatore.Text = cmbOperatore.Text.ToUpper
            LeggiDatiAccesso(operatore.Gruppo, TAB_GRUPPI)

            ' Imposta i vari comandi per l'operatore indentificato.
            Dim i As Integer
            For i = 1 To NUMERO_TOT_ENUM_FINESTRA ' Numero totale dell'enumerazione Finestra.
               g_frmMain.ImpostaFunzioniOperatore(i)
            Next

            SalvaDatiConfig(operatore.Codice, operatore.Nome)

            Me.Close()

            ' Registra loperazione efettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Login, String.Empty, MODULO_ACCESSO_OPERATORE)

         Else
            Me.DialogResult = DialogResult.None
            txtPassword.Text = ""
            txtPassword.Focus()
            ErrorProvider1.SetError(txtPassword, "La password non è corretta!")
            operatore.EliminaDati()
            Exit Sub
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPassword.TextChanged
      ErrorProvider1.SetError(txtPassword, "")
   End Sub

End Class
