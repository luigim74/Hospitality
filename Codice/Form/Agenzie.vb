' Nome form:            frmAgenzie
' Autore:               Luigi Montana, Montana Software
' Data creazione:       18/01/2005
' Data ultima modifica: 06/08/2005
' Descrizione:          Anagrafica Agenzie.

Option Strict Off
Option Explicit On 

Imports System.IO
Imports System.Data.OleDb
Imports AnagTab.Anagrafiche
Imports MSolution.Varie

Public Class frmAgenzie
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

   'NOTA: la procedura che segue è richiesta da Progettazione Windows Form.
   'Può essere modificata in Progettazione Windows Form.  
   'Non modificarla nell'editor del codice.
   Public WithEvents ToolBar1 As System.Windows.Forms.ToolBar
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents lblIntestazione As System.Windows.Forms.Label
   Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
   Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
   Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
   Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
   Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
   Public WithEvents txtPIva As System.Windows.Forms.TextBox
   Public WithEvents txtCodFisc As System.Windows.Forms.TextBox
   Public WithEvents Label31 As System.Windows.Forms.Label
   Public WithEvents Label30 As System.Windows.Forms.Label
   Public WithEvents txtRegione As System.Windows.Forms.TextBox
   Public WithEvents txtProv As System.Windows.Forms.TextBox
   Public WithEvents txtCap As System.Windows.Forms.TextBox
   Public WithEvents txtCittà As System.Windows.Forms.TextBox
   Public WithEvents Label34 As System.Windows.Forms.Label
   Public WithEvents label As System.Windows.Forms.Label
   Public WithEvents Label21 As System.Windows.Forms.Label
   Public WithEvents Label10 As System.Windows.Forms.Label
   Public WithEvents Label9 As System.Windows.Forms.Label
   Public WithEvents Label6 As System.Windows.Forms.Label
   Public WithEvents Label5 As System.Windows.Forms.Label
   Public WithEvents Label4 As System.Windows.Forms.Label
   Public WithEvents Label3 As System.Windows.Forms.Label
   Public WithEvents Label20 As System.Windows.Forms.Label
   Public WithEvents txtFax As System.Windows.Forms.TextBox
   Public WithEvents txtEmail As System.Windows.Forms.TextBox
   Public WithEvents txtTelUfficio As System.Windows.Forms.TextBox
   Public WithEvents txtCell As System.Windows.Forms.TextBox
   Public WithEvents txtTelCasa As System.Windows.Forms.TextBox
   Public WithEvents Label22 As System.Windows.Forms.Label
   Public WithEvents Label1 As System.Windows.Forms.Label
   Public WithEvents Label15 As System.Windows.Forms.Label
   Public WithEvents Label13 As System.Windows.Forms.Label
   Public WithEvents Label11 As System.Windows.Forms.Label
   Public WithEvents Label38 As System.Windows.Forms.Label
   Public WithEvents Label33 As System.Windows.Forms.Label
   Public WithEvents Label32 As System.Windows.Forms.Label
   Public WithEvents Label27 As System.Windows.Forms.Label
   Public WithEvents txtNote As System.Windows.Forms.TextBox
   Friend WithEvents Salva As System.Windows.Forms.ToolBarButton
   Friend WithEvents Annulla As System.Windows.Forms.ToolBarButton
   Friend WithEvents cmbNazione As System.Windows.Forms.ComboBox
   Friend WithEvents cmbTitolo As System.Windows.Forms.ComboBox
   Public WithEvents txtIndirizzo2 As System.Windows.Forms.TextBox
   Public WithEvents txtIndirizzo1 As System.Windows.Forms.TextBox
   Public WithEvents txtCodice As System.Windows.Forms.TextBox
   Friend WithEvents cmbStruttura As System.Windows.Forms.ComboBox
   Public WithEvents txtCameraNotti_4 As System.Windows.Forms.TextBox
   Public WithEvents txtCameraNum_0 As System.Windows.Forms.TextBox
   Public WithEvents txtCameraData_0 As System.Windows.Forms.TextBox
   Public WithEvents txtCameraNotti_0 As System.Windows.Forms.TextBox
   Public WithEvents txtCameraNum_1 As System.Windows.Forms.TextBox
   Public WithEvents txtCameraData_1 As System.Windows.Forms.TextBox
   Public WithEvents txtCameraNotti_1 As System.Windows.Forms.TextBox
   Public WithEvents txtCameraNum_2 As System.Windows.Forms.TextBox
   Public WithEvents txtCameraData_2 As System.Windows.Forms.TextBox
   Public WithEvents txtCameraNotti_2 As System.Windows.Forms.TextBox
   Public WithEvents txtCameraNum_3 As System.Windows.Forms.TextBox
   Public WithEvents txtCameraData_3 As System.Windows.Forms.TextBox
   Public WithEvents txtCameraNotti_3 As System.Windows.Forms.TextBox
   Public WithEvents txtCameraNum_4 As System.Windows.Forms.TextBox
   Public WithEvents txtCameraData_4 As System.Windows.Forms.TextBox
   Public WithEvents picFoto As System.Windows.Forms.PictureBox
   Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
   Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
   Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
   Friend WithEvents EliminaImg As System.Windows.Forms.Button
   Friend WithEvents ApriImg As System.Windows.Forms.Button
   Friend WithEvents cmbTipoCliente As System.Windows.Forms.ComboBox
   Public WithEvents Label7 As System.Windows.Forms.Label
   Public WithEvents txtRagSoc As System.Windows.Forms.TextBox
   Public WithEvents txtInternet As System.Windows.Forms.TextBox
   Public WithEvents Label2 As System.Windows.Forms.Label
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAgenzie))
      Me.ToolBar1 = New System.Windows.Forms.ToolBar
      Me.Salva = New System.Windows.Forms.ToolBarButton
      Me.Annulla = New System.Windows.Forms.ToolBarButton
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.Panel1 = New System.Windows.Forms.Panel
      Me.lblIntestazione = New System.Windows.Forms.Label
      Me.TabControl1 = New System.Windows.Forms.TabControl
      Me.TabPage1 = New System.Windows.Forms.TabPage
      Me.cmbTipoCliente = New System.Windows.Forms.ComboBox
      Me.Label7 = New System.Windows.Forms.Label
      Me.EliminaImg = New System.Windows.Forms.Button
      Me.ApriImg = New System.Windows.Forms.Button
      Me.picFoto = New System.Windows.Forms.PictureBox
      Me.cmbNazione = New System.Windows.Forms.ComboBox
      Me.cmbTitolo = New System.Windows.Forms.ComboBox
      Me.txtPIva = New System.Windows.Forms.TextBox
      Me.txtCodFisc = New System.Windows.Forms.TextBox
      Me.Label31 = New System.Windows.Forms.Label
      Me.Label30 = New System.Windows.Forms.Label
      Me.txtIndirizzo2 = New System.Windows.Forms.TextBox
      Me.txtRegione = New System.Windows.Forms.TextBox
      Me.txtProv = New System.Windows.Forms.TextBox
      Me.txtCap = New System.Windows.Forms.TextBox
      Me.txtCittà = New System.Windows.Forms.TextBox
      Me.txtIndirizzo1 = New System.Windows.Forms.TextBox
      Me.txtRagSoc = New System.Windows.Forms.TextBox
      Me.Label34 = New System.Windows.Forms.Label
      Me.label = New System.Windows.Forms.Label
      Me.Label21 = New System.Windows.Forms.Label
      Me.Label10 = New System.Windows.Forms.Label
      Me.Label9 = New System.Windows.Forms.Label
      Me.Label6 = New System.Windows.Forms.Label
      Me.Label5 = New System.Windows.Forms.Label
      Me.Label4 = New System.Windows.Forms.Label
      Me.Label3 = New System.Windows.Forms.Label
      Me.txtCodice = New System.Windows.Forms.TextBox
      Me.Label20 = New System.Windows.Forms.Label
      Me.TabPage3 = New System.Windows.Forms.TabPage
      Me.txtInternet = New System.Windows.Forms.TextBox
      Me.Label2 = New System.Windows.Forms.Label
      Me.txtFax = New System.Windows.Forms.TextBox
      Me.txtEmail = New System.Windows.Forms.TextBox
      Me.txtTelUfficio = New System.Windows.Forms.TextBox
      Me.txtCell = New System.Windows.Forms.TextBox
      Me.txtTelCasa = New System.Windows.Forms.TextBox
      Me.Label22 = New System.Windows.Forms.Label
      Me.Label1 = New System.Windows.Forms.Label
      Me.Label15 = New System.Windows.Forms.Label
      Me.Label13 = New System.Windows.Forms.Label
      Me.Label11 = New System.Windows.Forms.Label
      Me.TabPage5 = New System.Windows.Forms.TabPage
      Me.cmbStruttura = New System.Windows.Forms.ComboBox
      Me.txtCameraNotti_4 = New System.Windows.Forms.TextBox
      Me.txtCameraNum_0 = New System.Windows.Forms.TextBox
      Me.txtCameraData_0 = New System.Windows.Forms.TextBox
      Me.txtCameraNotti_0 = New System.Windows.Forms.TextBox
      Me.txtCameraNum_1 = New System.Windows.Forms.TextBox
      Me.txtCameraData_1 = New System.Windows.Forms.TextBox
      Me.txtCameraNotti_1 = New System.Windows.Forms.TextBox
      Me.txtCameraNum_2 = New System.Windows.Forms.TextBox
      Me.txtCameraData_2 = New System.Windows.Forms.TextBox
      Me.txtCameraNotti_2 = New System.Windows.Forms.TextBox
      Me.txtCameraNum_3 = New System.Windows.Forms.TextBox
      Me.txtCameraData_3 = New System.Windows.Forms.TextBox
      Me.txtCameraNotti_3 = New System.Windows.Forms.TextBox
      Me.txtCameraNum_4 = New System.Windows.Forms.TextBox
      Me.txtCameraData_4 = New System.Windows.Forms.TextBox
      Me.Label38 = New System.Windows.Forms.Label
      Me.Label33 = New System.Windows.Forms.Label
      Me.Label32 = New System.Windows.Forms.Label
      Me.Label27 = New System.Windows.Forms.Label
      Me.TabPage6 = New System.Windows.Forms.TabPage
      Me.txtNote = New System.Windows.Forms.TextBox
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
      Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.Panel1.SuspendLayout()
      Me.TabControl1.SuspendLayout()
      Me.TabPage1.SuspendLayout()
      Me.TabPage3.SuspendLayout()
      Me.TabPage5.SuspendLayout()
      Me.TabPage6.SuspendLayout()
      Me.SuspendLayout()
      '
      'ToolBar1
      '
      Me.ToolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
      Me.ToolBar1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.Salva, Me.Annulla})
      Me.ToolBar1.ButtonSize = New System.Drawing.Size(22, 22)
      Me.ToolBar1.Divider = False
      Me.ToolBar1.DropDownArrows = True
      Me.ToolBar1.ImageList = Me.ImageList1
      Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
      Me.ToolBar1.Name = "ToolBar1"
      Me.ToolBar1.ShowToolTips = True
      Me.ToolBar1.Size = New System.Drawing.Size(544, 32)
      Me.ToolBar1.TabIndex = 0
      '
      'Salva
      '
      Me.Salva.ImageIndex = 15
      Me.Salva.Tag = "Salva"
      Me.Salva.ToolTipText = "Salva"
      '
      'Annulla
      '
      Me.Annulla.ImageIndex = 16
      Me.Annulla.Tag = "Annulla"
      Me.Annulla.ToolTipText = "Annulla"
      '
      'ImageList1
      '
      Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
      Me.ImageList1.ImageSize = New System.Drawing.Size(22, 22)
      Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
      '
      'Panel1
      '
      Me.Panel1.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.Panel1.Controls.Add(Me.lblIntestazione)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel1.Location = New System.Drawing.Point(0, 32)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(544, 20)
      Me.Panel1.TabIndex = 0
      '
      'lblIntestazione
      '
      Me.lblIntestazione.AutoSize = True
      Me.lblIntestazione.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblIntestazione.ForeColor = System.Drawing.SystemColors.Window
      Me.lblIntestazione.Location = New System.Drawing.Point(4, 2)
      Me.lblIntestazione.Name = "lblIntestazione"
      Me.lblIntestazione.Size = New System.Drawing.Size(13, 18)
      Me.lblIntestazione.TabIndex = 0
      Me.lblIntestazione.Text = "#"
      '
      'TabControl1
      '
      Me.TabControl1.Controls.Add(Me.TabPage1)
      Me.TabControl1.Controls.Add(Me.TabPage3)
      Me.TabControl1.Controls.Add(Me.TabPage5)
      Me.TabControl1.Controls.Add(Me.TabPage6)
      Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.TabControl1.Location = New System.Drawing.Point(0, 52)
      Me.TabControl1.Multiline = True
      Me.TabControl1.Name = "TabControl1"
      Me.TabControl1.SelectedIndex = 0
      Me.TabControl1.Size = New System.Drawing.Size(544, 314)
      Me.TabControl1.TabIndex = 0
      '
      'TabPage1
      '
      Me.TabPage1.Controls.Add(Me.cmbTipoCliente)
      Me.TabPage1.Controls.Add(Me.Label7)
      Me.TabPage1.Controls.Add(Me.EliminaImg)
      Me.TabPage1.Controls.Add(Me.ApriImg)
      Me.TabPage1.Controls.Add(Me.picFoto)
      Me.TabPage1.Controls.Add(Me.cmbNazione)
      Me.TabPage1.Controls.Add(Me.cmbTitolo)
      Me.TabPage1.Controls.Add(Me.txtPIva)
      Me.TabPage1.Controls.Add(Me.txtCodFisc)
      Me.TabPage1.Controls.Add(Me.Label31)
      Me.TabPage1.Controls.Add(Me.Label30)
      Me.TabPage1.Controls.Add(Me.txtIndirizzo2)
      Me.TabPage1.Controls.Add(Me.txtRegione)
      Me.TabPage1.Controls.Add(Me.txtProv)
      Me.TabPage1.Controls.Add(Me.txtCap)
      Me.TabPage1.Controls.Add(Me.txtCittà)
      Me.TabPage1.Controls.Add(Me.txtIndirizzo1)
      Me.TabPage1.Controls.Add(Me.txtRagSoc)
      Me.TabPage1.Controls.Add(Me.Label34)
      Me.TabPage1.Controls.Add(Me.label)
      Me.TabPage1.Controls.Add(Me.Label21)
      Me.TabPage1.Controls.Add(Me.Label10)
      Me.TabPage1.Controls.Add(Me.Label9)
      Me.TabPage1.Controls.Add(Me.Label6)
      Me.TabPage1.Controls.Add(Me.Label5)
      Me.TabPage1.Controls.Add(Me.Label4)
      Me.TabPage1.Controls.Add(Me.Label3)
      Me.TabPage1.Controls.Add(Me.txtCodice)
      Me.TabPage1.Controls.Add(Me.Label20)
      Me.TabPage1.Location = New System.Drawing.Point(4, 22)
      Me.TabPage1.Name = "TabPage1"
      Me.TabPage1.Size = New System.Drawing.Size(536, 288)
      Me.TabPage1.TabIndex = 0
      Me.TabPage1.Text = "Dati principali"
      '
      'cmbTipoCliente
      '
      Me.cmbTipoCliente.Location = New System.Drawing.Point(104, 248)
      Me.cmbTipoCliente.Name = "cmbTipoCliente"
      Me.cmbTipoCliente.Size = New System.Drawing.Size(160, 21)
      Me.cmbTipoCliente.TabIndex = 9
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.BackColor = System.Drawing.SystemColors.Control
      Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label7.ForeColor = System.Drawing.SystemColors.Desktop
      Me.Label7.Location = New System.Drawing.Point(16, 248)
      Me.Label7.Name = "Label7"
      Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label7.Size = New System.Drawing.Size(92, 16)
      Me.Label7.TabIndex = 182
      Me.Label7.Text = "Categoria cliente:"
      '
      'EliminaImg
      '
      Me.EliminaImg.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.EliminaImg.Location = New System.Drawing.Point(440, 173)
      Me.EliminaImg.Name = "EliminaImg"
      Me.EliminaImg.Size = New System.Drawing.Size(72, 24)
      Me.EliminaImg.TabIndex = 13
      Me.EliminaImg.Text = "&Elimina"
      '
      'ApriImg
      '
      Me.ApriImg.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ApriImg.Location = New System.Drawing.Point(360, 173)
      Me.ApriImg.Name = "ApriImg"
      Me.ApriImg.Size = New System.Drawing.Size(72, 24)
      Me.ApriImg.TabIndex = 12
      Me.ApriImg.Text = "&Apri"
      '
      'picFoto
      '
      Me.picFoto.BackColor = System.Drawing.SystemColors.ActiveCaptionText
      Me.picFoto.Cursor = System.Windows.Forms.Cursors.Default
      Me.picFoto.Location = New System.Drawing.Point(360, 16)
      Me.picFoto.Name = "picFoto"
      Me.picFoto.Size = New System.Drawing.Size(153, 153)
      Me.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
      Me.picFoto.TabIndex = 178
      Me.picFoto.TabStop = False
      '
      'cmbNazione
      '
      Me.cmbNazione.Location = New System.Drawing.Point(105, 224)
      Me.cmbNazione.Name = "cmbNazione"
      Me.cmbNazione.Size = New System.Drawing.Size(160, 21)
      Me.cmbNazione.TabIndex = 8
      '
      'cmbTitolo
      '
      Me.cmbTitolo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbTitolo.Location = New System.Drawing.Point(104, 48)
      Me.cmbTitolo.Name = "cmbTitolo"
      Me.cmbTitolo.Size = New System.Drawing.Size(241, 21)
      Me.cmbTitolo.TabIndex = 0
      '
      'txtPIva
      '
      Me.txtPIva.AcceptsReturn = True
      Me.txtPIva.AutoSize = False
      Me.txtPIva.BackColor = System.Drawing.SystemColors.Window
      Me.txtPIva.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtPIva.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtPIva.Location = New System.Drawing.Point(360, 248)
      Me.txtPIva.MaxLength = 11
      Me.txtPIva.Name = "txtPIva"
      Me.txtPIva.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtPIva.Size = New System.Drawing.Size(153, 19)
      Me.txtPIva.TabIndex = 11
      Me.txtPIva.Text = ""
      '
      'txtCodFisc
      '
      Me.txtCodFisc.AcceptsReturn = True
      Me.txtCodFisc.AutoSize = False
      Me.txtCodFisc.BackColor = System.Drawing.SystemColors.Window
      Me.txtCodFisc.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCodFisc.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCodFisc.Location = New System.Drawing.Point(360, 224)
      Me.txtCodFisc.MaxLength = 16
      Me.txtCodFisc.Name = "txtCodFisc"
      Me.txtCodFisc.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCodFisc.Size = New System.Drawing.Size(153, 19)
      Me.txtCodFisc.TabIndex = 10
      Me.txtCodFisc.Text = ""
      '
      'Label31
      '
      Me.Label31.AutoSize = True
      Me.Label31.BackColor = System.Drawing.SystemColors.Control
      Me.Label31.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label31.ForeColor = System.Drawing.SystemColors.Desktop
      Me.Label31.Location = New System.Drawing.Point(280, 248)
      Me.Label31.Name = "Label31"
      Me.Label31.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label31.Size = New System.Drawing.Size(71, 16)
      Me.Label31.TabIndex = 175
      Me.Label31.Text = "Partita I.V.A.:"
      '
      'Label30
      '
      Me.Label30.AutoSize = True
      Me.Label30.BackColor = System.Drawing.SystemColors.Control
      Me.Label30.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label30.ForeColor = System.Drawing.SystemColors.Desktop
      Me.Label30.Location = New System.Drawing.Point(280, 224)
      Me.Label30.Name = "Label30"
      Me.Label30.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label30.Size = New System.Drawing.Size(78, 16)
      Me.Label30.TabIndex = 174
      Me.Label30.Text = "Codice fiscale:"
      '
      'txtIndirizzo2
      '
      Me.txtIndirizzo2.AcceptsReturn = True
      Me.txtIndirizzo2.AutoSize = False
      Me.txtIndirizzo2.BackColor = System.Drawing.SystemColors.Window
      Me.txtIndirizzo2.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtIndirizzo2.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtIndirizzo2.Location = New System.Drawing.Point(105, 128)
      Me.txtIndirizzo2.MaxLength = 100
      Me.txtIndirizzo2.Name = "txtIndirizzo2"
      Me.txtIndirizzo2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtIndirizzo2.Size = New System.Drawing.Size(241, 19)
      Me.txtIndirizzo2.TabIndex = 3
      Me.txtIndirizzo2.Text = ""
      '
      'txtRegione
      '
      Me.txtRegione.AcceptsReturn = True
      Me.txtRegione.AutoSize = False
      Me.txtRegione.BackColor = System.Drawing.SystemColors.Window
      Me.txtRegione.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtRegione.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtRegione.Location = New System.Drawing.Point(105, 200)
      Me.txtRegione.MaxLength = 50
      Me.txtRegione.Name = "txtRegione"
      Me.txtRegione.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtRegione.Size = New System.Drawing.Size(160, 19)
      Me.txtRegione.TabIndex = 7
      Me.txtRegione.Text = ""
      '
      'txtProv
      '
      Me.txtProv.AcceptsReturn = True
      Me.txtProv.AutoSize = False
      Me.txtProv.BackColor = System.Drawing.SystemColors.Window
      Me.txtProv.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtProv.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtProv.Location = New System.Drawing.Point(224, 176)
      Me.txtProv.MaxLength = 2
      Me.txtProv.Name = "txtProv"
      Me.txtProv.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtProv.Size = New System.Drawing.Size(40, 19)
      Me.txtProv.TabIndex = 6
      Me.txtProv.Text = ""
      '
      'txtCap
      '
      Me.txtCap.AcceptsReturn = True
      Me.txtCap.AutoSize = False
      Me.txtCap.BackColor = System.Drawing.SystemColors.Window
      Me.txtCap.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCap.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCap.Location = New System.Drawing.Point(105, 176)
      Me.txtCap.MaxLength = 5
      Me.txtCap.Name = "txtCap"
      Me.txtCap.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCap.Size = New System.Drawing.Size(49, 19)
      Me.txtCap.TabIndex = 5
      Me.txtCap.Text = ""
      '
      'txtCittà
      '
      Me.txtCittà.AcceptsReturn = True
      Me.txtCittà.AutoSize = False
      Me.txtCittà.BackColor = System.Drawing.SystemColors.Window
      Me.txtCittà.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCittà.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCittà.Location = New System.Drawing.Point(105, 152)
      Me.txtCittà.MaxLength = 100
      Me.txtCittà.Name = "txtCittà"
      Me.txtCittà.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCittà.Size = New System.Drawing.Size(241, 19)
      Me.txtCittà.TabIndex = 4
      Me.txtCittà.Text = ""
      '
      'txtIndirizzo1
      '
      Me.txtIndirizzo1.AcceptsReturn = True
      Me.txtIndirizzo1.AutoSize = False
      Me.txtIndirizzo1.BackColor = System.Drawing.SystemColors.Window
      Me.txtIndirizzo1.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtIndirizzo1.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtIndirizzo1.Location = New System.Drawing.Point(105, 104)
      Me.txtIndirizzo1.MaxLength = 100
      Me.txtIndirizzo1.Name = "txtIndirizzo1"
      Me.txtIndirizzo1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtIndirizzo1.Size = New System.Drawing.Size(241, 19)
      Me.txtIndirizzo1.TabIndex = 2
      Me.txtIndirizzo1.Text = ""
      '
      'txtRagSoc
      '
      Me.txtRagSoc.AcceptsReturn = True
      Me.txtRagSoc.AutoSize = False
      Me.txtRagSoc.BackColor = System.Drawing.SystemColors.Window
      Me.txtRagSoc.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtRagSoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtRagSoc.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtRagSoc.Location = New System.Drawing.Point(104, 72)
      Me.txtRagSoc.MaxLength = 50
      Me.txtRagSoc.Name = "txtRagSoc"
      Me.txtRagSoc.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtRagSoc.Size = New System.Drawing.Size(241, 19)
      Me.txtRagSoc.TabIndex = 1
      Me.txtRagSoc.Text = ""
      '
      'Label34
      '
      Me.Label34.AutoSize = True
      Me.Label34.BackColor = System.Drawing.SystemColors.Control
      Me.Label34.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label34.ForeColor = System.Drawing.SystemColors.Desktop
      Me.Label34.Location = New System.Drawing.Point(16, 128)
      Me.Label34.Name = "Label34"
      Me.Label34.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label34.Size = New System.Drawing.Size(59, 16)
      Me.Label34.TabIndex = 171
      Me.Label34.Text = "Indirizzo 2:"
      '
      'label
      '
      Me.label.AutoSize = True
      Me.label.BackColor = System.Drawing.SystemColors.Control
      Me.label.Cursor = System.Windows.Forms.Cursors.Default
      Me.label.ForeColor = System.Drawing.SystemColors.Desktop
      Me.label.Location = New System.Drawing.Point(16, 48)
      Me.label.Name = "label"
      Me.label.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.label.Size = New System.Drawing.Size(95, 16)
      Me.label.TabIndex = 169
      Me.label.Text = "Forma di cortesia:"
      '
      'Label21
      '
      Me.Label21.AutoSize = True
      Me.Label21.BackColor = System.Drawing.SystemColors.Control
      Me.Label21.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label21.ForeColor = System.Drawing.SystemColors.Desktop
      Me.Label21.Location = New System.Drawing.Point(16, 200)
      Me.Label21.Name = "Label21"
      Me.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label21.Size = New System.Drawing.Size(50, 16)
      Me.Label21.TabIndex = 168
      Me.Label21.Text = "Regione:"
      '
      'Label10
      '
      Me.Label10.AutoSize = True
      Me.Label10.BackColor = System.Drawing.SystemColors.Control
      Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label10.ForeColor = System.Drawing.SystemColors.Desktop
      Me.Label10.Location = New System.Drawing.Point(16, 224)
      Me.Label10.Name = "Label10"
      Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label10.Size = New System.Drawing.Size(49, 16)
      Me.Label10.TabIndex = 167
      Me.Label10.Text = "Nazione:"
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.BackColor = System.Drawing.SystemColors.Control
      Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label9.ForeColor = System.Drawing.SystemColors.Desktop
      Me.Label9.Location = New System.Drawing.Point(169, 176)
      Me.Label9.Name = "Label9"
      Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label9.Size = New System.Drawing.Size(54, 16)
      Me.Label9.TabIndex = 166
      Me.Label9.Text = "Provincia:"
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.BackColor = System.Drawing.SystemColors.Control
      Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label6.ForeColor = System.Drawing.SystemColors.Desktop
      Me.Label6.Location = New System.Drawing.Point(16, 176)
      Me.Label6.Name = "Label6"
      Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label6.Size = New System.Drawing.Size(40, 16)
      Me.Label6.TabIndex = 165
      Me.Label6.Text = "C.A.P.:"
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.BackColor = System.Drawing.SystemColors.Control
      Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label5.ForeColor = System.Drawing.SystemColors.Desktop
      Me.Label5.Location = New System.Drawing.Point(16, 152)
      Me.Label5.Name = "Label5"
      Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label5.Size = New System.Drawing.Size(31, 16)
      Me.Label5.TabIndex = 164
      Me.Label5.Text = "Città:"
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.BackColor = System.Drawing.SystemColors.Control
      Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label4.ForeColor = System.Drawing.SystemColors.Desktop
      Me.Label4.Location = New System.Drawing.Point(16, 104)
      Me.Label4.Name = "Label4"
      Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label4.Size = New System.Drawing.Size(59, 16)
      Me.Label4.TabIndex = 163
      Me.Label4.Text = "Indirizzo 1:"
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.BackColor = System.Drawing.SystemColors.Control
      Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label3.ForeColor = System.Drawing.SystemColors.Desktop
      Me.Label3.Location = New System.Drawing.Point(16, 72)
      Me.Label3.Name = "Label3"
      Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label3.Size = New System.Drawing.Size(88, 16)
      Me.Label3.TabIndex = 162
      Me.Label3.Text = "Ragione sociale:"
      '
      'txtCodice
      '
      Me.txtCodice.AcceptsReturn = True
      Me.txtCodice.AutoSize = False
      Me.txtCodice.BackColor = System.Drawing.SystemColors.Control
      Me.txtCodice.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCodice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCodice.ForeColor = System.Drawing.SystemColors.AppWorkspace
      Me.txtCodice.Location = New System.Drawing.Point(104, 16)
      Me.txtCodice.MaxLength = 50
      Me.txtCodice.Name = "txtCodice"
      Me.txtCodice.ReadOnly = True
      Me.txtCodice.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCodice.Size = New System.Drawing.Size(159, 19)
      Me.txtCodice.TabIndex = 0
      Me.txtCodice.TabStop = False
      Me.txtCodice.Text = ""
      Me.txtCodice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'Label20
      '
      Me.Label20.AutoSize = True
      Me.Label20.BackColor = System.Drawing.SystemColors.Control
      Me.Label20.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label20.ForeColor = System.Drawing.SystemColors.Desktop
      Me.Label20.Location = New System.Drawing.Point(16, 16)
      Me.Label20.Name = "Label20"
      Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label20.Size = New System.Drawing.Size(43, 16)
      Me.Label20.TabIndex = 153
      Me.Label20.Text = "Codice:"
      '
      'TabPage3
      '
      Me.TabPage3.Controls.Add(Me.txtInternet)
      Me.TabPage3.Controls.Add(Me.Label2)
      Me.TabPage3.Controls.Add(Me.txtFax)
      Me.TabPage3.Controls.Add(Me.txtEmail)
      Me.TabPage3.Controls.Add(Me.txtTelUfficio)
      Me.TabPage3.Controls.Add(Me.txtCell)
      Me.TabPage3.Controls.Add(Me.txtTelCasa)
      Me.TabPage3.Controls.Add(Me.Label22)
      Me.TabPage3.Controls.Add(Me.Label1)
      Me.TabPage3.Controls.Add(Me.Label15)
      Me.TabPage3.Controls.Add(Me.Label13)
      Me.TabPage3.Controls.Add(Me.Label11)
      Me.TabPage3.Location = New System.Drawing.Point(4, 22)
      Me.TabPage3.Name = "TabPage3"
      Me.TabPage3.Size = New System.Drawing.Size(536, 288)
      Me.TabPage3.TabIndex = 2
      Me.TabPage3.Text = "Telefono"
      '
      'txtInternet
      '
      Me.txtInternet.AcceptsReturn = True
      Me.txtInternet.AutoSize = False
      Me.txtInternet.BackColor = System.Drawing.SystemColors.Window
      Me.txtInternet.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtInternet.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtInternet.Location = New System.Drawing.Point(96, 192)
      Me.txtInternet.MaxLength = 0
      Me.txtInternet.Name = "txtInternet"
      Me.txtInternet.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtInternet.Size = New System.Drawing.Size(408, 19)
      Me.txtInternet.TabIndex = 5
      Me.txtInternet.Text = ""
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.BackColor = System.Drawing.SystemColors.Control
      Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label2.ForeColor = System.Drawing.SystemColors.Desktop
      Me.Label2.Location = New System.Drawing.Point(32, 192)
      Me.Label2.Name = "Label2"
      Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label2.Size = New System.Drawing.Size(46, 16)
      Me.Label2.TabIndex = 187
      Me.Label2.Text = "Internet:"
      '
      'txtFax
      '
      Me.txtFax.AcceptsReturn = True
      Me.txtFax.AutoSize = False
      Me.txtFax.BackColor = System.Drawing.SystemColors.Window
      Me.txtFax.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtFax.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtFax.Location = New System.Drawing.Point(96, 96)
      Me.txtFax.MaxLength = 15
      Me.txtFax.Name = "txtFax"
      Me.txtFax.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtFax.Size = New System.Drawing.Size(233, 19)
      Me.txtFax.TabIndex = 2
      Me.txtFax.Text = ""
      '
      'txtEmail
      '
      Me.txtEmail.AcceptsReturn = True
      Me.txtEmail.AutoSize = False
      Me.txtEmail.BackColor = System.Drawing.SystemColors.Window
      Me.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtEmail.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtEmail.Location = New System.Drawing.Point(96, 160)
      Me.txtEmail.MaxLength = 100
      Me.txtEmail.Name = "txtEmail"
      Me.txtEmail.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtEmail.Size = New System.Drawing.Size(408, 19)
      Me.txtEmail.TabIndex = 4
      Me.txtEmail.Text = ""
      '
      'txtTelUfficio
      '
      Me.txtTelUfficio.AcceptsReturn = True
      Me.txtTelUfficio.AutoSize = False
      Me.txtTelUfficio.BackColor = System.Drawing.SystemColors.Window
      Me.txtTelUfficio.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtTelUfficio.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtTelUfficio.Location = New System.Drawing.Point(96, 64)
      Me.txtTelUfficio.MaxLength = 15
      Me.txtTelUfficio.Name = "txtTelUfficio"
      Me.txtTelUfficio.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtTelUfficio.Size = New System.Drawing.Size(233, 19)
      Me.txtTelUfficio.TabIndex = 1
      Me.txtTelUfficio.Text = ""
      '
      'txtCell
      '
      Me.txtCell.AcceptsReturn = True
      Me.txtCell.AutoSize = False
      Me.txtCell.BackColor = System.Drawing.SystemColors.Window
      Me.txtCell.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCell.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCell.Location = New System.Drawing.Point(96, 128)
      Me.txtCell.MaxLength = 15
      Me.txtCell.Name = "txtCell"
      Me.txtCell.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCell.Size = New System.Drawing.Size(233, 19)
      Me.txtCell.TabIndex = 3
      Me.txtCell.Text = ""
      '
      'txtTelCasa
      '
      Me.txtTelCasa.AcceptsReturn = True
      Me.txtTelCasa.AutoSize = False
      Me.txtTelCasa.BackColor = System.Drawing.SystemColors.Window
      Me.txtTelCasa.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtTelCasa.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtTelCasa.Location = New System.Drawing.Point(96, 32)
      Me.txtTelCasa.MaxLength = 15
      Me.txtTelCasa.Name = "txtTelCasa"
      Me.txtTelCasa.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtTelCasa.Size = New System.Drawing.Size(233, 19)
      Me.txtTelCasa.TabIndex = 0
      Me.txtTelCasa.Text = ""
      '
      'Label22
      '
      Me.Label22.AutoSize = True
      Me.Label22.BackColor = System.Drawing.SystemColors.Control
      Me.Label22.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label22.ForeColor = System.Drawing.SystemColors.Desktop
      Me.Label22.Location = New System.Drawing.Point(32, 128)
      Me.Label22.Name = "Label22"
      Me.Label22.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label22.Size = New System.Drawing.Size(52, 16)
      Me.Label22.TabIndex = 117
      Me.Label22.Text = "Cellulare:"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.BackColor = System.Drawing.SystemColors.Control
      Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label1.ForeColor = System.Drawing.SystemColors.Desktop
      Me.Label1.Location = New System.Drawing.Point(32, 64)
      Me.Label1.Name = "Label1"
      Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label1.Size = New System.Drawing.Size(59, 16)
      Me.Label1.TabIndex = 116
      Me.Label1.Text = "Tel. ufficio:"
      '
      'Label15
      '
      Me.Label15.AutoSize = True
      Me.Label15.BackColor = System.Drawing.SystemColors.Control
      Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label15.ForeColor = System.Drawing.SystemColors.Desktop
      Me.Label15.Location = New System.Drawing.Point(32, 160)
      Me.Label15.Name = "Label15"
      Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label15.Size = New System.Drawing.Size(40, 16)
      Me.Label15.TabIndex = 115
      Me.Label15.Text = "E-mail:"
      '
      'Label13
      '
      Me.Label13.AutoSize = True
      Me.Label13.BackColor = System.Drawing.SystemColors.Control
      Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label13.ForeColor = System.Drawing.SystemColors.Desktop
      Me.Label13.Location = New System.Drawing.Point(32, 96)
      Me.Label13.Name = "Label13"
      Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label13.Size = New System.Drawing.Size(26, 16)
      Me.Label13.TabIndex = 114
      Me.Label13.Text = "Fax:"
      '
      'Label11
      '
      Me.Label11.AutoSize = True
      Me.Label11.BackColor = System.Drawing.SystemColors.Control
      Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label11.ForeColor = System.Drawing.SystemColors.Desktop
      Me.Label11.Location = New System.Drawing.Point(32, 32)
      Me.Label11.Name = "Label11"
      Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label11.Size = New System.Drawing.Size(53, 16)
      Me.Label11.TabIndex = 113
      Me.Label11.Text = "Tel. casa:"
      '
      'TabPage5
      '
      Me.TabPage5.Controls.Add(Me.cmbStruttura)
      Me.TabPage5.Controls.Add(Me.txtCameraNotti_4)
      Me.TabPage5.Controls.Add(Me.txtCameraNum_0)
      Me.TabPage5.Controls.Add(Me.txtCameraData_0)
      Me.TabPage5.Controls.Add(Me.txtCameraNotti_0)
      Me.TabPage5.Controls.Add(Me.txtCameraNum_1)
      Me.TabPage5.Controls.Add(Me.txtCameraData_1)
      Me.TabPage5.Controls.Add(Me.txtCameraNotti_1)
      Me.TabPage5.Controls.Add(Me.txtCameraNum_2)
      Me.TabPage5.Controls.Add(Me.txtCameraData_2)
      Me.TabPage5.Controls.Add(Me.txtCameraNotti_2)
      Me.TabPage5.Controls.Add(Me.txtCameraNum_3)
      Me.TabPage5.Controls.Add(Me.txtCameraData_3)
      Me.TabPage5.Controls.Add(Me.txtCameraNotti_3)
      Me.TabPage5.Controls.Add(Me.txtCameraNum_4)
      Me.TabPage5.Controls.Add(Me.txtCameraData_4)
      Me.TabPage5.Controls.Add(Me.Label38)
      Me.TabPage5.Controls.Add(Me.Label33)
      Me.TabPage5.Controls.Add(Me.Label32)
      Me.TabPage5.Controls.Add(Me.Label27)
      Me.TabPage5.Location = New System.Drawing.Point(4, 22)
      Me.TabPage5.Name = "TabPage5"
      Me.TabPage5.Size = New System.Drawing.Size(536, 288)
      Me.TabPage5.TabIndex = 4
      Me.TabPage5.Text = "Camere abituali"
      '
      'cmbStruttura
      '
      Me.cmbStruttura.Location = New System.Drawing.Point(24, 232)
      Me.cmbStruttura.Name = "cmbStruttura"
      Me.cmbStruttura.Size = New System.Drawing.Size(256, 21)
      Me.cmbStruttura.TabIndex = 0
      Me.cmbStruttura.Visible = False
      '
      'txtCameraNotti_4
      '
      Me.txtCameraNotti_4.AcceptsReturn = True
      Me.txtCameraNotti_4.AutoSize = False
      Me.txtCameraNotti_4.BackColor = System.Drawing.SystemColors.Window
      Me.txtCameraNotti_4.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCameraNotti_4.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCameraNotti_4.Location = New System.Drawing.Point(224, 168)
      Me.txtCameraNotti_4.MaxLength = 5
      Me.txtCameraNotti_4.Name = "txtCameraNotti_4"
      Me.txtCameraNotti_4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCameraNotti_4.Size = New System.Drawing.Size(56, 19)
      Me.txtCameraNotti_4.TabIndex = 15
      Me.txtCameraNotti_4.Text = ""
      '
      'txtCameraNum_0
      '
      Me.txtCameraNum_0.AcceptsReturn = True
      Me.txtCameraNum_0.AutoSize = False
      Me.txtCameraNum_0.BackColor = System.Drawing.SystemColors.Window
      Me.txtCameraNum_0.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCameraNum_0.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCameraNum_0.Location = New System.Drawing.Point(24, 40)
      Me.txtCameraNum_0.MaxLength = 5
      Me.txtCameraNum_0.Name = "txtCameraNum_0"
      Me.txtCameraNum_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCameraNum_0.Size = New System.Drawing.Size(56, 19)
      Me.txtCameraNum_0.TabIndex = 1
      Me.txtCameraNum_0.Text = ""
      '
      'txtCameraData_0
      '
      Me.txtCameraData_0.AcceptsReturn = True
      Me.txtCameraData_0.AutoSize = False
      Me.txtCameraData_0.BackColor = System.Drawing.SystemColors.Window
      Me.txtCameraData_0.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCameraData_0.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCameraData_0.Location = New System.Drawing.Point(96, 40)
      Me.txtCameraData_0.MaxLength = 10
      Me.txtCameraData_0.Name = "txtCameraData_0"
      Me.txtCameraData_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCameraData_0.Size = New System.Drawing.Size(112, 19)
      Me.txtCameraData_0.TabIndex = 2
      Me.txtCameraData_0.Text = ""
      '
      'txtCameraNotti_0
      '
      Me.txtCameraNotti_0.AcceptsReturn = True
      Me.txtCameraNotti_0.AutoSize = False
      Me.txtCameraNotti_0.BackColor = System.Drawing.SystemColors.Window
      Me.txtCameraNotti_0.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCameraNotti_0.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCameraNotti_0.Location = New System.Drawing.Point(224, 40)
      Me.txtCameraNotti_0.MaxLength = 5
      Me.txtCameraNotti_0.Name = "txtCameraNotti_0"
      Me.txtCameraNotti_0.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCameraNotti_0.Size = New System.Drawing.Size(56, 19)
      Me.txtCameraNotti_0.TabIndex = 3
      Me.txtCameraNotti_0.Text = ""
      '
      'txtCameraNum_1
      '
      Me.txtCameraNum_1.AcceptsReturn = True
      Me.txtCameraNum_1.AutoSize = False
      Me.txtCameraNum_1.BackColor = System.Drawing.SystemColors.Window
      Me.txtCameraNum_1.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCameraNum_1.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCameraNum_1.Location = New System.Drawing.Point(24, 72)
      Me.txtCameraNum_1.MaxLength = 5
      Me.txtCameraNum_1.Name = "txtCameraNum_1"
      Me.txtCameraNum_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCameraNum_1.Size = New System.Drawing.Size(56, 19)
      Me.txtCameraNum_1.TabIndex = 4
      Me.txtCameraNum_1.Text = ""
      '
      'txtCameraData_1
      '
      Me.txtCameraData_1.AcceptsReturn = True
      Me.txtCameraData_1.AutoSize = False
      Me.txtCameraData_1.BackColor = System.Drawing.SystemColors.Window
      Me.txtCameraData_1.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCameraData_1.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCameraData_1.Location = New System.Drawing.Point(96, 72)
      Me.txtCameraData_1.MaxLength = 10
      Me.txtCameraData_1.Name = "txtCameraData_1"
      Me.txtCameraData_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCameraData_1.Size = New System.Drawing.Size(112, 19)
      Me.txtCameraData_1.TabIndex = 5
      Me.txtCameraData_1.Text = ""
      '
      'txtCameraNotti_1
      '
      Me.txtCameraNotti_1.AcceptsReturn = True
      Me.txtCameraNotti_1.AutoSize = False
      Me.txtCameraNotti_1.BackColor = System.Drawing.SystemColors.Window
      Me.txtCameraNotti_1.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCameraNotti_1.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCameraNotti_1.Location = New System.Drawing.Point(224, 72)
      Me.txtCameraNotti_1.MaxLength = 5
      Me.txtCameraNotti_1.Name = "txtCameraNotti_1"
      Me.txtCameraNotti_1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCameraNotti_1.Size = New System.Drawing.Size(56, 19)
      Me.txtCameraNotti_1.TabIndex = 6
      Me.txtCameraNotti_1.Text = ""
      '
      'txtCameraNum_2
      '
      Me.txtCameraNum_2.AcceptsReturn = True
      Me.txtCameraNum_2.AutoSize = False
      Me.txtCameraNum_2.BackColor = System.Drawing.SystemColors.Window
      Me.txtCameraNum_2.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCameraNum_2.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCameraNum_2.Location = New System.Drawing.Point(24, 104)
      Me.txtCameraNum_2.MaxLength = 5
      Me.txtCameraNum_2.Name = "txtCameraNum_2"
      Me.txtCameraNum_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCameraNum_2.Size = New System.Drawing.Size(56, 19)
      Me.txtCameraNum_2.TabIndex = 7
      Me.txtCameraNum_2.Text = ""
      '
      'txtCameraData_2
      '
      Me.txtCameraData_2.AcceptsReturn = True
      Me.txtCameraData_2.AutoSize = False
      Me.txtCameraData_2.BackColor = System.Drawing.SystemColors.Window
      Me.txtCameraData_2.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCameraData_2.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCameraData_2.Location = New System.Drawing.Point(96, 104)
      Me.txtCameraData_2.MaxLength = 10
      Me.txtCameraData_2.Name = "txtCameraData_2"
      Me.txtCameraData_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCameraData_2.Size = New System.Drawing.Size(112, 19)
      Me.txtCameraData_2.TabIndex = 8
      Me.txtCameraData_2.Text = ""
      '
      'txtCameraNotti_2
      '
      Me.txtCameraNotti_2.AcceptsReturn = True
      Me.txtCameraNotti_2.AutoSize = False
      Me.txtCameraNotti_2.BackColor = System.Drawing.SystemColors.Window
      Me.txtCameraNotti_2.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCameraNotti_2.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCameraNotti_2.Location = New System.Drawing.Point(224, 104)
      Me.txtCameraNotti_2.MaxLength = 5
      Me.txtCameraNotti_2.Name = "txtCameraNotti_2"
      Me.txtCameraNotti_2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCameraNotti_2.Size = New System.Drawing.Size(56, 19)
      Me.txtCameraNotti_2.TabIndex = 9
      Me.txtCameraNotti_2.Text = ""
      '
      'txtCameraNum_3
      '
      Me.txtCameraNum_3.AcceptsReturn = True
      Me.txtCameraNum_3.AutoSize = False
      Me.txtCameraNum_3.BackColor = System.Drawing.SystemColors.Window
      Me.txtCameraNum_3.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCameraNum_3.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCameraNum_3.Location = New System.Drawing.Point(24, 136)
      Me.txtCameraNum_3.MaxLength = 5
      Me.txtCameraNum_3.Name = "txtCameraNum_3"
      Me.txtCameraNum_3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCameraNum_3.Size = New System.Drawing.Size(56, 19)
      Me.txtCameraNum_3.TabIndex = 10
      Me.txtCameraNum_3.Text = ""
      '
      'txtCameraData_3
      '
      Me.txtCameraData_3.AcceptsReturn = True
      Me.txtCameraData_3.AutoSize = False
      Me.txtCameraData_3.BackColor = System.Drawing.SystemColors.Window
      Me.txtCameraData_3.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCameraData_3.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCameraData_3.Location = New System.Drawing.Point(96, 136)
      Me.txtCameraData_3.MaxLength = 10
      Me.txtCameraData_3.Name = "txtCameraData_3"
      Me.txtCameraData_3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCameraData_3.Size = New System.Drawing.Size(112, 19)
      Me.txtCameraData_3.TabIndex = 11
      Me.txtCameraData_3.Text = ""
      '
      'txtCameraNotti_3
      '
      Me.txtCameraNotti_3.AcceptsReturn = True
      Me.txtCameraNotti_3.AutoSize = False
      Me.txtCameraNotti_3.BackColor = System.Drawing.SystemColors.Window
      Me.txtCameraNotti_3.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCameraNotti_3.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCameraNotti_3.Location = New System.Drawing.Point(224, 136)
      Me.txtCameraNotti_3.MaxLength = 5
      Me.txtCameraNotti_3.Name = "txtCameraNotti_3"
      Me.txtCameraNotti_3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCameraNotti_3.Size = New System.Drawing.Size(56, 19)
      Me.txtCameraNotti_3.TabIndex = 12
      Me.txtCameraNotti_3.Text = ""
      '
      'txtCameraNum_4
      '
      Me.txtCameraNum_4.AcceptsReturn = True
      Me.txtCameraNum_4.AutoSize = False
      Me.txtCameraNum_4.BackColor = System.Drawing.SystemColors.Window
      Me.txtCameraNum_4.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCameraNum_4.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCameraNum_4.Location = New System.Drawing.Point(24, 168)
      Me.txtCameraNum_4.MaxLength = 5
      Me.txtCameraNum_4.Name = "txtCameraNum_4"
      Me.txtCameraNum_4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCameraNum_4.Size = New System.Drawing.Size(56, 19)
      Me.txtCameraNum_4.TabIndex = 13
      Me.txtCameraNum_4.Text = ""
      '
      'txtCameraData_4
      '
      Me.txtCameraData_4.AcceptsReturn = True
      Me.txtCameraData_4.AutoSize = False
      Me.txtCameraData_4.BackColor = System.Drawing.SystemColors.Window
      Me.txtCameraData_4.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCameraData_4.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCameraData_4.Location = New System.Drawing.Point(96, 168)
      Me.txtCameraData_4.MaxLength = 10
      Me.txtCameraData_4.Name = "txtCameraData_4"
      Me.txtCameraData_4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCameraData_4.Size = New System.Drawing.Size(112, 19)
      Me.txtCameraData_4.TabIndex = 14
      Me.txtCameraData_4.Text = ""
      '
      'Label38
      '
      Me.Label38.AutoSize = True
      Me.Label38.BackColor = System.Drawing.SystemColors.Control
      Me.Label38.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label38.ForeColor = System.Drawing.SystemColors.Desktop
      Me.Label38.Location = New System.Drawing.Point(24, 216)
      Me.Label38.Name = "Label38"
      Me.Label38.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label38.Size = New System.Drawing.Size(51, 16)
      Me.Label38.TabIndex = 151
      Me.Label38.Text = "Struttura:"
      Me.Label38.Visible = False
      '
      'Label33
      '
      Me.Label33.AutoSize = True
      Me.Label33.BackColor = System.Drawing.SystemColors.Control
      Me.Label33.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label33.ForeColor = System.Drawing.SystemColors.Desktop
      Me.Label33.Location = New System.Drawing.Point(96, 24)
      Me.Label33.Name = "Label33"
      Me.Label33.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label33.Size = New System.Drawing.Size(31, 16)
      Me.Label33.TabIndex = 150
      Me.Label33.Text = "Data:"
      '
      'Label32
      '
      Me.Label32.AutoSize = True
      Me.Label32.BackColor = System.Drawing.SystemColors.Control
      Me.Label32.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label32.ForeColor = System.Drawing.SystemColors.Desktop
      Me.Label32.Location = New System.Drawing.Point(224, 24)
      Me.Label32.Name = "Label32"
      Me.Label32.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label32.Size = New System.Drawing.Size(31, 16)
      Me.Label32.TabIndex = 149
      Me.Label32.Text = "Notti:"
      '
      'Label27
      '
      Me.Label27.AutoSize = True
      Me.Label27.BackColor = System.Drawing.SystemColors.Control
      Me.Label27.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label27.ForeColor = System.Drawing.SystemColors.Desktop
      Me.Label27.Location = New System.Drawing.Point(24, 24)
      Me.Label27.Name = "Label27"
      Me.Label27.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label27.Size = New System.Drawing.Size(48, 16)
      Me.Label27.TabIndex = 148
      Me.Label27.Text = "Camera:"
      '
      'TabPage6
      '
      Me.TabPage6.Controls.Add(Me.txtNote)
      Me.TabPage6.Location = New System.Drawing.Point(4, 22)
      Me.TabPage6.Name = "TabPage6"
      Me.TabPage6.Size = New System.Drawing.Size(536, 288)
      Me.TabPage6.TabIndex = 5
      Me.TabPage6.Text = "Note"
      '
      'txtNote
      '
      Me.txtNote.AcceptsReturn = True
      Me.txtNote.AutoSize = False
      Me.txtNote.BackColor = System.Drawing.SystemColors.Window
      Me.txtNote.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtNote.Dock = System.Windows.Forms.DockStyle.Fill
      Me.txtNote.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtNote.Location = New System.Drawing.Point(0, 0)
      Me.txtNote.MaxLength = 0
      Me.txtNote.Multiline = True
      Me.txtNote.Name = "txtNote"
      Me.txtNote.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtNote.Size = New System.Drawing.Size(536, 288)
      Me.txtNote.TabIndex = 0
      Me.txtNote.Text = ""
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'frmAgenzie
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(544, 366)
      Me.Controls.Add(Me.TabControl1)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.ToolBar1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmAgenzie"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Agenzie"
      Me.Panel1.ResumeLayout(False)
      Me.TabControl1.ResumeLayout(False)
      Me.TabPage1.ResumeLayout(False)
      Me.TabPage3.ResumeLayout(False)
      Me.TabPage5.ResumeLayout(False)
      Me.TabPage6.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub

#End Region

   Public AAgenzie As New Ditta

   Const TAB_QUALIFICHE As String = "Qualifiche"
   Const TAB_NAZIONI As String = "Nazioni"
   Const TAB_TIPO_CLIENTE As String = "CategorieClienti"
   Const NOME_TABELLA As String = "Agenzie"

   ' Dichiara un oggetto connessione.
   Dim cn As New OleDbConnection(ConnString)
   ' Dichiara un oggetto transazione.
   Dim tr As OleDbTransaction
   Dim cmd As New OleDbCommand(sql, cn)
   Dim ds As New DataSet

   ' Numero di record.
   Dim numRecord As Integer
   Dim sql As String

   Private Sub FormResize(ByVal larghezza As Short, ByVal altezza As Short)
      ' Imposta le dimensioni standard del form.
      Me.Width = larghezza
      Me.Height = altezza
   End Sub

   Private Function SalvaDati() As Boolean

      ' Salva eventuali nuovi valori nelle rispettive tabelle dati.
      AggiornaTabella(cmbTitolo, TAB_QUALIFICHE)
      AggiornaTabella(cmbNazione, TAB_NAZIONI)
      AggiornaTabella(cmbTipoCliente, TAB_TIPO_CLIENTE)

      Try
         ' Assegna i dati dei campi della classe alle caselle di testo.
         AAgenzie.Codice = txtCodice.Text
         AAgenzie.RagSoc = txtRagSoc.Text
         AAgenzie.Titolo = cmbTitolo.Text
         AAgenzie.CodFisc = txtCodFisc.Text
         AAgenzie.PIva = txtPIva.Text
         AAgenzie.Indirizzo1 = txtIndirizzo1.Text
         AAgenzie.Indirizzo2 = txtIndirizzo2.Text
         AAgenzie.Cap = txtCap.Text
         AAgenzie.Città = txtCittà.Text
         AAgenzie.Provincia = txtProv.Text
         AAgenzie.Regione = txtRegione.Text
         AAgenzie.Nazione = cmbNazione.Text
         AAgenzie.TipoCliente = cmbTipoCliente.Text
         AAgenzie.TelCasa = txtTelCasa.Text
         AAgenzie.TelUfficio = txtTelUfficio.Text
         AAgenzie.Cell = txtCell.Text
         AAgenzie.Fax = txtFax.Text
         AAgenzie.Email = txtEmail.Text
         AAgenzie.Internet = txtInternet.Text
         AAgenzie.CamereNum1 = txtCameraNum_0.Text
         AAgenzie.CamereNum2 = txtCameraNum_1.Text
         AAgenzie.CamereNum3 = txtCameraNum_2.Text
         AAgenzie.CamereNum4 = txtCameraNum_3.Text
         AAgenzie.CamereNum5 = txtCameraNum_4.Text
         AAgenzie.CamereData1 = txtCameraData_0.Text
         AAgenzie.CamereData2 = txtCameraData_1.Text
         AAgenzie.CamereData3 = txtCameraData_2.Text
         AAgenzie.CamereData4 = txtCameraData_3.Text
         AAgenzie.CamereData5 = txtCameraData_4.Text
         AAgenzie.CamereNotti1 = txtCameraNotti_0.Text
         AAgenzie.CamereNotti2 = txtCameraNotti_1.Text
         AAgenzie.CamereNotti3 = txtCameraNotti_2.Text
         AAgenzie.CamereNotti4 = txtCameraNotti_3.Text
         AAgenzie.CamereNotti5 = txtCameraNotti_4.Text
         AAgenzie.Strutture = cmbStruttura.Text
         AAgenzie.Note = txtNote.Text

         ' Se la proprietà 'Tag' contiene un valore viene richiamata la procedura
         ' di modifica dati, altrimenti viene richiamata la procedura di inserimento dati.
         If Me.Tag <> "" Then
            Return AAgenzie.ModificaDati(NOME_TABELLA, Me.Tag)
         Else
            Return AAgenzie.InserisciDati(NOME_TABELLA)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally

      End Try
   End Function

   Private Sub InserisciImmagine()
      Try
         OpenFileDialog1.Filter = "Tutti i formati |*.Bmp; *.Gif; *.Jpg; *.Jpeg; *.Png; *.Tga; *.Tiff; *.Wmf|" & _
                                  "Bmp (Bitmap di Windows)|*.Bmp|" & _
                                  "Gif |*.Gif|" & _
                                  "Jpeg/Jpg |*.Jpg; *.Jpeg |" & _
                                  "Png |*.Png|" & _
                                  "Tga |*.Tga|" & _
                                  "Tiff |*.Tiff|" & _
                                  "Wmf (Metafile di Windows) |*.Wmf"

         OpenFileDialog1.FilterIndex = 1
         OpenFileDialog1.ShowDialog()

         AAgenzie.Immagine = OpenFileDialog1.FileName

         If File.Exists(AAgenzie.Immagine) = True Then
            Dim bmp As New Bitmap(AAgenzie.Immagine)
            picFoto.Image = bmp
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub EliminaImmagine()
      Try
         If Not (picFoto.Image Is Nothing) Then
            picFoto.Image.Dispose()
            picFoto.Image = Nothing
            AAgenzie.Immagine = ""
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub frmAgenzie_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta le dimensioni del form.
         FormResize(FORM_LARGHEZZA, FORM_ALTEZZA)

         If Me.Tag <> "" Then
            ' Visualizza i dati nei rispettivi campi.
            AAgenzie.LeggiDati(NOME_TABELLA, Me.Tag)

            ' Assegna i dati dei campi della classe alle caselle di testo.
            txtCodice.Text = AAgenzie.Codice
            txtRagSoc.Text = AAgenzie.RagSoc
            cmbTitolo.Text = AAgenzie.Titolo
            txtCodFisc.Text = AAgenzie.CodFisc
            txtPIva.Text = AAgenzie.PIva
            txtIndirizzo1.Text = AAgenzie.Indirizzo1
            txtIndirizzo2.Text = AAgenzie.Indirizzo2
            txtCap.Text = AAgenzie.Cap
            txtCittà.Text = AAgenzie.Città
            txtProv.Text = AAgenzie.Provincia
            txtRegione.Text = AAgenzie.Regione
            cmbNazione.Text = AAgenzie.Nazione
            cmbTipoCliente.Text = AAgenzie.TipoCliente
            txtTelCasa.Text = AAgenzie.TelCasa
            txtTelUfficio.Text = AAgenzie.TelUfficio
            txtCell.Text = AAgenzie.Cell
            txtFax.Text = AAgenzie.Fax
            txtEmail.Text = AAgenzie.Email
            txtInternet.Text = AAgenzie.Internet
            txtCameraNum_0.Text = AAgenzie.CamereNum1
            txtCameraNum_1.Text = AAgenzie.CamereNum2
            txtCameraNum_2.Text = AAgenzie.CamereNum3
            txtCameraNum_3.Text = AAgenzie.CamereNum4
            txtCameraNum_4.Text = AAgenzie.CamereNum5
            txtCameraData_0.Text = AAgenzie.CamereData1
            txtCameraData_1.Text = AAgenzie.CamereData2
            txtCameraData_2.Text = AAgenzie.CamereData3
            txtCameraData_3.Text = AAgenzie.CamereData4
            txtCameraData_4.Text = AAgenzie.CamereData5
            txtCameraNotti_0.Text = AAgenzie.CamereNotti1
            txtCameraNotti_1.Text = AAgenzie.CamereNotti2
            txtCameraNotti_2.Text = AAgenzie.CamereNotti3
            txtCameraNotti_3.Text = AAgenzie.CamereNotti4
            txtCameraNotti_4.Text = AAgenzie.CamereNotti5
            cmbStruttura.Text = AAgenzie.Strutture
            txtNote.Text = AAgenzie.Note

            If AAgenzie.Immagine <> Nothing Then
               If File.Exists(AAgenzie.Immagine) = True Then
                  Dim bmp As New Bitmap(AAgenzie.Immagine)
                  picFoto.Image = bmp
               End If
            End If

         End If

         ' Carica le liste.
         CaricaLista(cmbTitolo, TAB_QUALIFICHE)
         CaricaLista(cmbNazione, TAB_NAZIONI)
         CaricaLista(cmbTipoCliente, TAB_TIPO_CLIENTE)

         ' Genera l'intestazione con i dati del form.
         lblIntestazione.Text = VisIntestazione(txtCodice.Text, txtRagSoc.Text, )

         ' Imposta il pulsante di default.
         ApriImg.NotifyDefault(True)

         ' Imposta lo stato attivo.
         cmbTitolo.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default
      End Try
   End Sub

   Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
      Select Case e.Button.Tag
         Case "Salva"
            ' Salva i dati nel database.
            If SalvaDati() = True Then
               ' Aggiorna la griglia dati.
               g_frmAgenzie.AggiornaDati()
               ' Chiude la finestra.
               Me.Close()
            End If

         Case "Annulla"
            ' Chiude la finestra.
            Me.Close()
      End Select
   End Sub

   Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
      Select Case TabControl1.SelectedIndex()
         Case 0
            ' Imposta lo stato attivo.
            Me.cmbTitolo.Focus()
         Case 1
            ' Imposta lo stato attivo.
            Me.txtTelCasa.Focus()
         Case 2
            ' Imposta lo stato attivo.
            Me.txtCameraNum_0.Focus()
         Case 3
            ' Imposta lo stato attivo.
            Me.txtNote.Focus()
      End Select
   End Sub

   Private Sub txtCap_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCap.TextChanged
      ConvalidaCampi(txtCap.Text, Me.txtCap, ErrorProvider1)
   End Sub

   Private Sub txtPIva_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPIva.TextChanged
      ConvalidaCampi(txtPIva.Text, Me.txtPIva, ErrorProvider1)
   End Sub

   Private Sub txtTelCasa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTelCasa.TextChanged
      ConvalidaCampi(txtTelCasa.Text, Me.txtTelCasa, ErrorProvider1)
   End Sub

   Private Sub txtTelUfficio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTelUfficio.TextChanged
      ConvalidaCampi(txtTelUfficio.Text, Me.txtTelUfficio, ErrorProvider1)
   End Sub

   Private Sub txtFax_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFax.TextChanged
      ConvalidaCampi(txtFax.Text, Me.txtFax, ErrorProvider1)
   End Sub

   Private Sub txtCell_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCell.TextChanged
      ConvalidaCampi(txtCell.Text, Me.txtCell, ErrorProvider1)
   End Sub

   Private Sub ApriImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ApriImg.Click
      InserisciImmagine()
   End Sub

   Private Sub EliminaImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminaImg.Click
      EliminaImmagine()
   End Sub

   Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage1.Click

   End Sub

   Private Sub frmAgenzie_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed

   End Sub
End Class
