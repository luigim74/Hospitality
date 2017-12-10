' Nome form:            frmCamere
' Autore:               Luigi Montana, Montana Software
' Data creazione:       18/01/2005
' Data ultima modifica: 06/08/2005
' Descrizione:          Anagrafica Camere.

Option Strict Off
Option Explicit On 

Imports System.IO
Imports System.Data.OleDb

Public Class frmPrenCamera
   Inherits System.Windows.Forms.Form

#Region " Codice generato da Progettazione Windows Form "

   Public Sub New(ByVal nomeFrm As String)
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

      ' Nome della finestra che ha effettuato la chiamata.
      tipoFrm = nomeFrm

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
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents lblIntestazione As System.Windows.Forms.Label
   Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
   Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
   Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
   Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
   Public WithEvents Label5 As System.Windows.Forms.Label
   Public WithEvents Label4 As System.Windows.Forms.Label
   Public WithEvents Label3 As System.Windows.Forms.Label
   Public WithEvents Label20 As System.Windows.Forms.Label
   Public WithEvents txtNote As System.Windows.Forms.TextBox
   Friend WithEvents Salva As System.Windows.Forms.ToolBarButton
   Friend WithEvents Annulla As System.Windows.Forms.ToolBarButton
   Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
   Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
   Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
   Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
   Friend WithEvents cmdColore As System.Windows.Forms.Button
   Public WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents lvwAllegati As System.Windows.Forms.ListView
   Friend WithEvents ColumnHeader19 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader20 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader21 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader22 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader23 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader24 As System.Windows.Forms.ColumnHeader
   Friend WithEvents cmbTrattamento As System.Windows.Forms.ComboBox
   Friend WithEvents cmdApriIntestatario As System.Windows.Forms.Button
   Friend WithEvents cmbTipologia As System.Windows.Forms.ComboBox
   Public WithEvents txtCodice As System.Windows.Forms.TextBox
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents dtpData As System.Windows.Forms.DateTimePicker
   Public WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
   Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
   Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
   Friend WithEvents cmbListino As System.Windows.Forms.ComboBox
   Public WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents cmbPagamento As System.Windows.Forms.ComboBox
   Public WithEvents Label2 As System.Windows.Forms.Label
   Public WithEvents Label10 As System.Windows.Forms.Label
   Public WithEvents Label1 As System.Windows.Forms.Label
   Public WithEvents txtNumero As System.Windows.Forms.TextBox
   Public WithEvents Label12 As System.Windows.Forms.Label
   Public WithEvents txtDescrizioneCamera As System.Windows.Forms.TextBox
   Friend WithEvents cmbNumeroCamera As System.Windows.Forms.ComboBox
   Public WithEvents Label11 As System.Windows.Forms.Label
   Public WithEvents txtAccontoCamera As System.Windows.Forms.TextBox
   Public WithEvents Label18 As System.Windows.Forms.Label
   Public WithEvents txtPrezzoCamera As System.Windows.Forms.TextBox
   Public WithEvents txtTotaleCostoCamera As System.Windows.Forms.TextBox
   Public WithEvents Label16 As System.Windows.Forms.Label
   Public WithEvents Label17 As System.Windows.Forms.Label
   Friend WithEvents nudBambini As System.Windows.Forms.NumericUpDown
   Friend WithEvents nudAdulti As System.Windows.Forms.NumericUpDown
   Friend WithEvents lvwOccupanti As System.Windows.Forms.ListView
   Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
   Friend WithEvents lvwAddebiti As System.Windows.Forms.ListView
   Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
   Friend WithEvents eui_QuantitàMeno As Elegant.Ui.Button
   Friend WithEvents eui_cmdQuantitàPiù As Elegant.Ui.Button
   Public WithEvents txtTotaleAddebitiExtra As System.Windows.Forms.TextBox
   Public WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents eui_ddwnInserisciAddebiti As Elegant.Ui.DropDown
   Friend WithEvents eui_cmdEliminaRiga As Elegant.Ui.Button
   Friend WithEvents cmdInserisciOccupanti As Elegant.Ui.Button
   Friend WithEvents cmdEliminaOccupanti As Elegant.Ui.Button
   Friend WithEvents Button5 As Elegant.Ui.Button
   Friend WithEvents Button3 As Elegant.Ui.Button
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Friend WithEvents PopupMenu1 As Elegant.Ui.PopupMenu
   Friend WithEvents eui_cmdAccessori As Elegant.Ui.Button
   Friend WithEvents eui_cmdServizi As Elegant.Ui.Button
   Friend WithEvents Separator1 As Elegant.Ui.Separator
   Friend WithEvents eui_cmdApriPos As Elegant.Ui.Button
   Friend WithEvents cmbStatoPren As System.Windows.Forms.ComboBox
   Public WithEvents Label13 As System.Windows.Forms.Label
   Public WithEvents txtTotaleAddebiti As System.Windows.Forms.TextBox
   Public WithEvents Label15 As System.Windows.Forms.Label
   Public WithEvents txtTotaleConto As System.Windows.Forms.TextBox
   Public WithEvents Label14 As System.Windows.Forms.Label
   Friend WithEvents Panel2 As System.Windows.Forms.Panel
   Public WithEvents lblPartenza As System.Windows.Forms.Label
   Public WithEvents lblArrivo As System.Windows.Forms.Label
   Friend WithEvents mcDataPartenza As System.Windows.Forms.MonthCalendar
   Public WithEvents txtNumeroNotti As System.Windows.Forms.TextBox
   Public WithEvents Label27 As System.Windows.Forms.Label
   Friend WithEvents dtpOraArrivo As System.Windows.Forms.DateTimePicker
   Public WithEvents Label28 As System.Windows.Forms.Label
   Friend WithEvents mcDataArrivo As System.Windows.Forms.MonthCalendar
   Friend WithEvents cmbCognome As System.Windows.Forms.ComboBox
   Public WithEvents txtNome As System.Windows.Forms.TextBox
   Friend WithEvents cmbIdCliente As System.Windows.Forms.ComboBox
   Friend WithEvents cmbNome As System.Windows.Forms.ComboBox
   Friend WithEvents nudNeonati As System.Windows.Forms.NumericUpDown
   Public WithEvents Label21 As System.Windows.Forms.Label
   Friend WithEvents nudRagazzi As System.Windows.Forms.NumericUpDown
   Public WithEvents Label19 As System.Windows.Forms.Label
   Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
   Friend WithEvents txtSconto As System.Windows.Forms.TextBox
   Public WithEvents Label22 As System.Windows.Forms.Label
   Friend WithEvents cmbApplicaSconto As System.Windows.Forms.ComboBox
   Public WithEvents Label23 As System.Windows.Forms.Label
   Friend WithEvents txtServizio As System.Windows.Forms.TextBox
   Public WithEvents Label24 As System.Windows.Forms.Label
   Public WithEvents txtTotaleIncassare As System.Windows.Forms.TextBox
   Public WithEvents Label25 As System.Windows.Forms.Label
   Public WithEvents txtTotaleTassaSoggiorno As System.Windows.Forms.TextBox
   Public WithEvents Label26 As System.Windows.Forms.Label
   Friend WithEvents cmbIdListino As System.Windows.Forms.ComboBox
   Friend WithEvents Button4 As Elegant.Ui.Button
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrenCamera))
      Dim ListViewGroup1 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Articoli vari", System.Windows.Forms.HorizontalAlignment.Left)
      Dim ListViewGroup2 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Accessori", System.Windows.Forms.HorizontalAlignment.Left)
      Dim ListViewGroup3 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Servizi", System.Windows.Forms.HorizontalAlignment.Left)
      Me.ToolBar1 = New System.Windows.Forms.ToolBar()
      Me.Salva = New System.Windows.Forms.ToolBarButton()
      Me.Annulla = New System.Windows.Forms.ToolBarButton()
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.lblIntestazione = New System.Windows.Forms.Label()
      Me.TabControl1 = New System.Windows.Forms.TabControl()
      Me.TabPage1 = New System.Windows.Forms.TabPage()
      Me.nudNeonati = New System.Windows.Forms.NumericUpDown()
      Me.Label21 = New System.Windows.Forms.Label()
      Me.nudRagazzi = New System.Windows.Forms.NumericUpDown()
      Me.Label19 = New System.Windows.Forms.Label()
      Me.cmbNome = New System.Windows.Forms.ComboBox()
      Me.cmbIdCliente = New System.Windows.Forms.ComboBox()
      Me.txtNome = New System.Windows.Forms.TextBox()
      Me.cmbCognome = New System.Windows.Forms.ComboBox()
      Me.Panel2 = New System.Windows.Forms.Panel()
      Me.mcDataArrivo = New System.Windows.Forms.MonthCalendar()
      Me.txtNumeroNotti = New System.Windows.Forms.TextBox()
      Me.Label27 = New System.Windows.Forms.Label()
      Me.dtpOraArrivo = New System.Windows.Forms.DateTimePicker()
      Me.Label28 = New System.Windows.Forms.Label()
      Me.lblPartenza = New System.Windows.Forms.Label()
      Me.lblArrivo = New System.Windows.Forms.Label()
      Me.mcDataPartenza = New System.Windows.Forms.MonthCalendar()
      Me.cmbStatoPren = New System.Windows.Forms.ComboBox()
      Me.Label13 = New System.Windows.Forms.Label()
      Me.nudBambini = New System.Windows.Forms.NumericUpDown()
      Me.nudAdulti = New System.Windows.Forms.NumericUpDown()
      Me.txtNumero = New System.Windows.Forms.TextBox()
      Me.Label12 = New System.Windows.Forms.Label()
      Me.txtDescrizioneCamera = New System.Windows.Forms.TextBox()
      Me.cmbNumeroCamera = New System.Windows.Forms.ComboBox()
      Me.Label11 = New System.Windows.Forms.Label()
      Me.Label10 = New System.Windows.Forms.Label()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.cmdColore = New System.Windows.Forms.Button()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.dtpData = New System.Windows.Forms.DateTimePicker()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.cmbTrattamento = New System.Windows.Forms.ComboBox()
      Me.cmdApriIntestatario = New System.Windows.Forms.Button()
      Me.cmbTipologia = New System.Windows.Forms.ComboBox()
      Me.txtCodice = New System.Windows.Forms.TextBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.Label20 = New System.Windows.Forms.Label()
      Me.TabPage3 = New System.Windows.Forms.TabPage()
      Me.cmdInserisciOccupanti = New Elegant.Ui.Button()
      Me.cmdEliminaOccupanti = New Elegant.Ui.Button()
      Me.lvwOccupanti = New System.Windows.Forms.ListView()
      Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.TabPage4 = New System.Windows.Forms.TabPage()
      Me.eui_QuantitàMeno = New Elegant.Ui.Button()
      Me.eui_cmdQuantitàPiù = New Elegant.Ui.Button()
      Me.txtTotaleAddebitiExtra = New System.Windows.Forms.TextBox()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.eui_ddwnInserisciAddebiti = New Elegant.Ui.DropDown()
      Me.PopupMenu1 = New Elegant.Ui.PopupMenu(Me.components)
      Me.eui_cmdAccessori = New Elegant.Ui.Button()
      Me.eui_cmdServizi = New Elegant.Ui.Button()
      Me.Separator1 = New Elegant.Ui.Separator()
      Me.eui_cmdApriPos = New Elegant.Ui.Button()
      Me.eui_cmdEliminaRiga = New Elegant.Ui.Button()
      Me.lvwAddebiti = New System.Windows.Forms.ListView()
      Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.TabPage7 = New System.Windows.Forms.TabPage()
      Me.cmbIdListino = New System.Windows.Forms.ComboBox()
      Me.txtTotaleTassaSoggiorno = New System.Windows.Forms.TextBox()
      Me.Label26 = New System.Windows.Forms.Label()
      Me.txtTotaleIncassare = New System.Windows.Forms.TextBox()
      Me.Label25 = New System.Windows.Forms.Label()
      Me.txtServizio = New System.Windows.Forms.TextBox()
      Me.Label24 = New System.Windows.Forms.Label()
      Me.txtSconto = New System.Windows.Forms.TextBox()
      Me.Label22 = New System.Windows.Forms.Label()
      Me.cmbApplicaSconto = New System.Windows.Forms.ComboBox()
      Me.Label23 = New System.Windows.Forms.Label()
      Me.txtTotaleAddebiti = New System.Windows.Forms.TextBox()
      Me.Label15 = New System.Windows.Forms.Label()
      Me.txtTotaleConto = New System.Windows.Forms.TextBox()
      Me.Label14 = New System.Windows.Forms.Label()
      Me.txtAccontoCamera = New System.Windows.Forms.TextBox()
      Me.Label18 = New System.Windows.Forms.Label()
      Me.txtPrezzoCamera = New System.Windows.Forms.TextBox()
      Me.txtTotaleCostoCamera = New System.Windows.Forms.TextBox()
      Me.Label16 = New System.Windows.Forms.Label()
      Me.Label17 = New System.Windows.Forms.Label()
      Me.cmbListino = New System.Windows.Forms.ComboBox()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.cmbPagamento = New System.Windows.Forms.ComboBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.TabPage5 = New System.Windows.Forms.TabPage()
      Me.Button5 = New Elegant.Ui.Button()
      Me.Button3 = New Elegant.Ui.Button()
      Me.Button4 = New Elegant.Ui.Button()
      Me.lvwAllegati = New System.Windows.Forms.ListView()
      Me.ColumnHeader19 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader20 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader21 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader22 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader23 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader24 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.TabPage6 = New System.Windows.Forms.TabPage()
      Me.txtNote = New System.Windows.Forms.TextBox()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.Panel1.SuspendLayout()
      Me.TabControl1.SuspendLayout()
      Me.TabPage1.SuspendLayout()
      CType(Me.nudNeonati, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.nudRagazzi, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.Panel2.SuspendLayout()
      CType(Me.nudBambini, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.nudAdulti, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.TabPage3.SuspendLayout()
      Me.TabPage4.SuspendLayout()
      CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.TabPage7.SuspendLayout()
      Me.TabPage5.SuspendLayout()
      Me.TabPage6.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
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
      Me.ToolBar1.Size = New System.Drawing.Size(592, 26)
      Me.ToolBar1.TabIndex = 0
      Me.ToolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
      '
      'Salva
      '
      Me.Salva.ImageIndex = 0
      Me.Salva.Name = "Salva"
      Me.Salva.Tag = "Salva"
      Me.Salva.Text = "Salva"
      Me.Salva.ToolTipText = "Salva"
      '
      'Annulla
      '
      Me.Annulla.ImageIndex = 1
      Me.Annulla.Name = "Annulla"
      Me.Annulla.Tag = "Annulla"
      Me.Annulla.Text = "Annulla"
      Me.Annulla.ToolTipText = "Annulla"
      '
      'ImageList1
      '
      Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
      Me.ImageList1.Images.SetKeyName(0, "saveHS.png")
      Me.ImageList1.Images.SetKeyName(1, "Edit_UndoHS.png")
      '
      'Panel1
      '
      Me.Panel1.BackColor = System.Drawing.Color.Gray
      Me.Panel1.Controls.Add(Me.lblIntestazione)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel1.Location = New System.Drawing.Point(0, 26)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(592, 20)
      Me.Panel1.TabIndex = 0
      '
      'lblIntestazione
      '
      Me.lblIntestazione.AutoSize = True
      Me.lblIntestazione.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblIntestazione.ForeColor = System.Drawing.SystemColors.Window
      Me.lblIntestazione.Location = New System.Drawing.Point(4, 2)
      Me.lblIntestazione.Name = "lblIntestazione"
      Me.lblIntestazione.Size = New System.Drawing.Size(17, 16)
      Me.lblIntestazione.TabIndex = 0
      Me.lblIntestazione.Text = "#"
      '
      'TabControl1
      '
      Me.TabControl1.Controls.Add(Me.TabPage1)
      Me.TabControl1.Controls.Add(Me.TabPage3)
      Me.TabControl1.Controls.Add(Me.TabPage4)
      Me.TabControl1.Controls.Add(Me.TabPage7)
      Me.TabControl1.Controls.Add(Me.TabPage5)
      Me.TabControl1.Controls.Add(Me.TabPage6)
      Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.TabControl1.Location = New System.Drawing.Point(0, 46)
      Me.TabControl1.Multiline = True
      Me.TabControl1.Name = "TabControl1"
      Me.TabControl1.SelectedIndex = 0
      Me.TabControl1.Size = New System.Drawing.Size(592, 565)
      Me.TabControl1.TabIndex = 0
      '
      'TabPage1
      '
      Me.TabPage1.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage1.Controls.Add(Me.nudNeonati)
      Me.TabPage1.Controls.Add(Me.Label21)
      Me.TabPage1.Controls.Add(Me.nudRagazzi)
      Me.TabPage1.Controls.Add(Me.Label19)
      Me.TabPage1.Controls.Add(Me.cmbNome)
      Me.TabPage1.Controls.Add(Me.cmbIdCliente)
      Me.TabPage1.Controls.Add(Me.txtNome)
      Me.TabPage1.Controls.Add(Me.cmbCognome)
      Me.TabPage1.Controls.Add(Me.Panel2)
      Me.TabPage1.Controls.Add(Me.cmbStatoPren)
      Me.TabPage1.Controls.Add(Me.Label13)
      Me.TabPage1.Controls.Add(Me.nudBambini)
      Me.TabPage1.Controls.Add(Me.nudAdulti)
      Me.TabPage1.Controls.Add(Me.txtNumero)
      Me.TabPage1.Controls.Add(Me.Label12)
      Me.TabPage1.Controls.Add(Me.txtDescrizioneCamera)
      Me.TabPage1.Controls.Add(Me.cmbNumeroCamera)
      Me.TabPage1.Controls.Add(Me.Label11)
      Me.TabPage1.Controls.Add(Me.Label10)
      Me.TabPage1.Controls.Add(Me.Label1)
      Me.TabPage1.Controls.Add(Me.cmdColore)
      Me.TabPage1.Controls.Add(Me.Label8)
      Me.TabPage1.Controls.Add(Me.dtpData)
      Me.TabPage1.Controls.Add(Me.Label7)
      Me.TabPage1.Controls.Add(Me.cmbTrattamento)
      Me.TabPage1.Controls.Add(Me.cmdApriIntestatario)
      Me.TabPage1.Controls.Add(Me.cmbTipologia)
      Me.TabPage1.Controls.Add(Me.txtCodice)
      Me.TabPage1.Controls.Add(Me.Label5)
      Me.TabPage1.Controls.Add(Me.Label4)
      Me.TabPage1.Controls.Add(Me.Label3)
      Me.TabPage1.Controls.Add(Me.Label20)
      Me.TabPage1.ForeColor = System.Drawing.Color.Black
      Me.TabPage1.Location = New System.Drawing.Point(4, 22)
      Me.TabPage1.Name = "TabPage1"
      Me.TabPage1.Size = New System.Drawing.Size(584, 539)
      Me.TabPage1.TabIndex = 0
      Me.TabPage1.Text = "Dati principali"
      '
      'nudNeonati
      '
      Me.nudNeonati.Location = New System.Drawing.Point(232, 152)
      Me.nudNeonati.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
      Me.nudNeonati.Name = "nudNeonati"
      Me.nudNeonati.Size = New System.Drawing.Size(48, 20)
      Me.nudNeonati.TabIndex = 9
      '
      'Label21
      '
      Me.Label21.AutoSize = True
      Me.Label21.BackColor = System.Drawing.Color.Transparent
      Me.Label21.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label21.ForeColor = System.Drawing.Color.Black
      Me.Label21.Location = New System.Drawing.Point(167, 152)
      Me.Label21.Name = "Label21"
      Me.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label21.Size = New System.Drawing.Size(65, 13)
      Me.Label21.TabIndex = 241
      Me.Label21.Text = "Neonati 0-2:"
      '
      'nudRagazzi
      '
      Me.nudRagazzi.Location = New System.Drawing.Point(472, 152)
      Me.nudRagazzi.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
      Me.nudRagazzi.Name = "nudRagazzi"
      Me.nudRagazzi.Size = New System.Drawing.Size(48, 20)
      Me.nudRagazzi.TabIndex = 11
      '
      'Label19
      '
      Me.Label19.AutoSize = True
      Me.Label19.BackColor = System.Drawing.Color.Transparent
      Me.Label19.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label19.ForeColor = System.Drawing.Color.Black
      Me.Label19.Location = New System.Drawing.Point(419, 152)
      Me.Label19.Name = "Label19"
      Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label19.Size = New System.Drawing.Size(48, 13)
      Me.Label19.TabIndex = 239
      Me.Label19.Text = "Ragazzi:"
      '
      'cmbNome
      '
      Me.cmbNome.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbNome.Location = New System.Drawing.Point(520, 120)
      Me.cmbNome.Name = "cmbNome"
      Me.cmbNome.Size = New System.Drawing.Size(24, 21)
      Me.cmbNome.TabIndex = 237
      Me.cmbNome.Visible = False
      '
      'cmbIdCliente
      '
      Me.cmbIdCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbIdCliente.Location = New System.Drawing.Point(88, 120)
      Me.cmbIdCliente.Name = "cmbIdCliente"
      Me.cmbIdCliente.Size = New System.Drawing.Size(24, 21)
      Me.cmbIdCliente.TabIndex = 236
      Me.cmbIdCliente.Visible = False
      '
      'txtNome
      '
      Me.txtNome.AcceptsReturn = True
      Me.txtNome.BackColor = System.Drawing.SystemColors.Window
      Me.txtNome.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtNome.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtNome.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtNome.Location = New System.Drawing.Point(352, 120)
      Me.txtNome.MaxLength = 0
      Me.txtNome.Name = "txtNome"
      Me.txtNome.ReadOnly = True
      Me.txtNome.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtNome.Size = New System.Drawing.Size(146, 20)
      Me.txtNome.TabIndex = 6
      Me.txtNome.TabStop = False
      '
      'cmbCognome
      '
      Me.cmbCognome.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCognome.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbCognome.Location = New System.Drawing.Point(112, 120)
      Me.cmbCognome.Name = "cmbCognome"
      Me.cmbCognome.Size = New System.Drawing.Size(232, 21)
      Me.cmbCognome.TabIndex = 5
      '
      'Panel2
      '
      Me.Panel2.BackColor = System.Drawing.Color.White
      Me.Panel2.Controls.Add(Me.mcDataArrivo)
      Me.Panel2.Controls.Add(Me.txtNumeroNotti)
      Me.Panel2.Controls.Add(Me.Label27)
      Me.Panel2.Controls.Add(Me.dtpOraArrivo)
      Me.Panel2.Controls.Add(Me.Label28)
      Me.Panel2.Controls.Add(Me.lblPartenza)
      Me.Panel2.Controls.Add(Me.lblArrivo)
      Me.Panel2.Controls.Add(Me.mcDataPartenza)
      Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.Panel2.Location = New System.Drawing.Point(0, 283)
      Me.Panel2.Name = "Panel2"
      Me.Panel2.Size = New System.Drawing.Size(584, 256)
      Me.Panel2.TabIndex = 232
      '
      'mcDataArrivo
      '
      Me.mcDataArrivo.Location = New System.Drawing.Point(32, 40)
      Me.mcDataArrivo.MaxSelectionCount = 1
      Me.mcDataArrivo.Name = "mcDataArrivo"
      Me.mcDataArrivo.ShowToday = False
      Me.mcDataArrivo.ShowTodayCircle = False
      Me.mcDataArrivo.TabIndex = 0
      Me.mcDataArrivo.TodayDate = New Date(2014, 8, 27, 0, 0, 0, 0)
      '
      'txtNumeroNotti
      '
      Me.txtNumeroNotti.AcceptsReturn = True
      Me.txtNumeroNotti.BackColor = System.Drawing.SystemColors.Window
      Me.txtNumeroNotti.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtNumeroNotti.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtNumeroNotti.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtNumeroNotti.Location = New System.Drawing.Point(440, 216)
      Me.txtNumeroNotti.MaxLength = 0
      Me.txtNumeroNotti.Name = "txtNumeroNotti"
      Me.txtNumeroNotti.ReadOnly = True
      Me.txtNumeroNotti.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtNumeroNotti.Size = New System.Drawing.Size(80, 20)
      Me.txtNumeroNotti.TabIndex = 3
      Me.txtNumeroNotti.TabStop = False
      Me.txtNumeroNotti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label27
      '
      Me.Label27.AutoSize = True
      Me.Label27.BackColor = System.Drawing.Color.Transparent
      Me.Label27.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label27.ForeColor = System.Drawing.Color.Black
      Me.Label27.Location = New System.Drawing.Point(360, 216)
      Me.Label27.Name = "Label27"
      Me.Label27.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label27.Size = New System.Drawing.Size(70, 13)
      Me.Label27.TabIndex = 237
      Me.Label27.Text = "Numero notti:"
      '
      'dtpOraArrivo
      '
      Me.dtpOraArrivo.Format = System.Windows.Forms.DateTimePickerFormat.Time
      Me.dtpOraArrivo.Location = New System.Drawing.Point(104, 216)
      Me.dtpOraArrivo.Name = "dtpOraArrivo"
      Me.dtpOraArrivo.ShowUpDown = True
      Me.dtpOraArrivo.Size = New System.Drawing.Size(80, 20)
      Me.dtpOraArrivo.TabIndex = 2
      Me.dtpOraArrivo.Value = New Date(2014, 8, 27, 17, 52, 25, 0)
      '
      'Label28
      '
      Me.Label28.AutoSize = True
      Me.Label28.BackColor = System.Drawing.Color.Transparent
      Me.Label28.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label28.ForeColor = System.Drawing.Color.Black
      Me.Label28.Location = New System.Drawing.Point(32, 216)
      Me.Label28.Name = "Label28"
      Me.Label28.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label28.Size = New System.Drawing.Size(67, 13)
      Me.Label28.TabIndex = 236
      Me.Label28.Text = "Ora di arrivo:"
      '
      'lblPartenza
      '
      Me.lblPartenza.AutoSize = True
      Me.lblPartenza.BackColor = System.Drawing.Color.Transparent
      Me.lblPartenza.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblPartenza.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblPartenza.ForeColor = System.Drawing.Color.Green
      Me.lblPartenza.Location = New System.Drawing.Point(295, 19)
      Me.lblPartenza.Name = "lblPartenza"
      Me.lblPartenza.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lblPartenza.Size = New System.Drawing.Size(68, 15)
      Me.lblPartenza.TabIndex = 233
      Me.lblPartenza.Text = "Partenza:"
      '
      'lblArrivo
      '
      Me.lblArrivo.AutoSize = True
      Me.lblArrivo.BackColor = System.Drawing.Color.Transparent
      Me.lblArrivo.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblArrivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblArrivo.ForeColor = System.Drawing.Color.Red
      Me.lblArrivo.Location = New System.Drawing.Point(31, 19)
      Me.lblArrivo.Name = "lblArrivo"
      Me.lblArrivo.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lblArrivo.Size = New System.Drawing.Size(47, 15)
      Me.lblArrivo.TabIndex = 232
      Me.lblArrivo.Text = "Arrivo:"
      '
      'mcDataPartenza
      '
      Me.mcDataPartenza.Location = New System.Drawing.Point(295, 40)
      Me.mcDataPartenza.MaxSelectionCount = 1
      Me.mcDataPartenza.Name = "mcDataPartenza"
      Me.mcDataPartenza.ShowToday = False
      Me.mcDataPartenza.ShowTodayCircle = False
      Me.mcDataPartenza.TabIndex = 1
      '
      'cmbStatoPren
      '
      Me.cmbStatoPren.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbStatoPren.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbStatoPren.Location = New System.Drawing.Point(352, 88)
      Me.cmbStatoPren.Name = "cmbStatoPren"
      Me.cmbStatoPren.Size = New System.Drawing.Size(168, 21)
      Me.cmbStatoPren.TabIndex = 4
      '
      'Label13
      '
      Me.Label13.AutoSize = True
      Me.Label13.BackColor = System.Drawing.Color.Transparent
      Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label13.ForeColor = System.Drawing.Color.Black
      Me.Label13.Location = New System.Drawing.Point(248, 88)
      Me.Label13.Name = "Label13"
      Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label13.Size = New System.Drawing.Size(99, 13)
      Me.Label13.TabIndex = 231
      Me.Label13.Text = "Stato prenotazione:"
      '
      'nudBambini
      '
      Me.nudBambini.Location = New System.Drawing.Point(352, 152)
      Me.nudBambini.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
      Me.nudBambini.Name = "nudBambini"
      Me.nudBambini.Size = New System.Drawing.Size(48, 20)
      Me.nudBambini.TabIndex = 10
      '
      'nudAdulti
      '
      Me.nudAdulti.Location = New System.Drawing.Point(112, 152)
      Me.nudAdulti.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
      Me.nudAdulti.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
      Me.nudAdulti.Name = "nudAdulti"
      Me.nudAdulti.Size = New System.Drawing.Size(48, 20)
      Me.nudAdulti.TabIndex = 8
      Me.nudAdulti.ThousandsSeparator = True
      Me.nudAdulti.Value = New Decimal(New Integer() {1, 0, 0, 0})
      '
      'txtNumero
      '
      Me.txtNumero.AcceptsReturn = True
      Me.txtNumero.BackColor = System.Drawing.SystemColors.Window
      Me.txtNumero.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtNumero.ForeColor = System.Drawing.Color.Red
      Me.txtNumero.Location = New System.Drawing.Point(112, 56)
      Me.txtNumero.MaxLength = 0
      Me.txtNumero.Name = "txtNumero"
      Me.txtNumero.ReadOnly = True
      Me.txtNumero.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtNumero.Size = New System.Drawing.Size(112, 20)
      Me.txtNumero.TabIndex = 1
      Me.txtNumero.TabStop = False
      '
      'Label12
      '
      Me.Label12.AutoSize = True
      Me.Label12.BackColor = System.Drawing.Color.Transparent
      Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label12.ForeColor = System.Drawing.Color.Black
      Me.Label12.Location = New System.Drawing.Point(32, 56)
      Me.Label12.Name = "Label12"
      Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label12.Size = New System.Drawing.Size(47, 13)
      Me.Label12.TabIndex = 200
      Me.Label12.Text = "Numero:"
      '
      'txtDescrizioneCamera
      '
      Me.txtDescrizioneCamera.AcceptsReturn = True
      Me.txtDescrizioneCamera.BackColor = System.Drawing.SystemColors.Window
      Me.txtDescrizioneCamera.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtDescrizioneCamera.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtDescrizioneCamera.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtDescrizioneCamera.Location = New System.Drawing.Point(256, 184)
      Me.txtDescrizioneCamera.MaxLength = 0
      Me.txtDescrizioneCamera.Name = "txtDescrizioneCamera"
      Me.txtDescrizioneCamera.ReadOnly = True
      Me.txtDescrizioneCamera.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtDescrizioneCamera.Size = New System.Drawing.Size(264, 20)
      Me.txtDescrizioneCamera.TabIndex = 13
      Me.txtDescrizioneCamera.TabStop = False
      '
      'cmbNumeroCamera
      '
      Me.cmbNumeroCamera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbNumeroCamera.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbNumeroCamera.Location = New System.Drawing.Point(112, 184)
      Me.cmbNumeroCamera.Name = "cmbNumeroCamera"
      Me.cmbNumeroCamera.Size = New System.Drawing.Size(136, 21)
      Me.cmbNumeroCamera.TabIndex = 12
      '
      'Label11
      '
      Me.Label11.AutoSize = True
      Me.Label11.BackColor = System.Drawing.Color.Transparent
      Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label11.ForeColor = System.Drawing.Color.Black
      Me.Label11.Location = New System.Drawing.Point(32, 184)
      Me.Label11.Name = "Label11"
      Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label11.Size = New System.Drawing.Size(46, 13)
      Me.Label11.TabIndex = 197
      Me.Label11.Text = "Camera:"
      '
      'Label10
      '
      Me.Label10.AutoSize = True
      Me.Label10.BackColor = System.Drawing.Color.Transparent
      Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label10.ForeColor = System.Drawing.Color.Black
      Me.Label10.Location = New System.Drawing.Point(287, 152)
      Me.Label10.Name = "Label10"
      Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label10.Size = New System.Drawing.Size(65, 13)
      Me.Label10.TabIndex = 195
      Me.Label10.Text = "Bambini 3-6:"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.BackColor = System.Drawing.Color.Transparent
      Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(32, 152)
      Me.Label1.Name = "Label1"
      Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label1.Size = New System.Drawing.Size(36, 13)
      Me.Label1.TabIndex = 194
      Me.Label1.Text = "Adulti:"
      '
      'cmdColore
      '
      Me.cmdColore.BackColor = System.Drawing.Color.White
      Me.cmdColore.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdColore.Location = New System.Drawing.Point(408, 24)
      Me.cmdColore.Name = "cmdColore"
      Me.cmdColore.Size = New System.Drawing.Size(112, 19)
      Me.cmdColore.TabIndex = 1
      Me.cmdColore.UseVisualStyleBackColor = False
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.BackColor = System.Drawing.Color.Transparent
      Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label8.ForeColor = System.Drawing.Color.Black
      Me.Label8.Location = New System.Drawing.Point(352, 24)
      Me.Label8.Name = "Label8"
      Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label8.Size = New System.Drawing.Size(40, 13)
      Me.Label8.TabIndex = 193
      Me.Label8.Text = "Colore:"
      '
      'dtpData
      '
      Me.dtpData.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpData.Location = New System.Drawing.Point(408, 56)
      Me.dtpData.Name = "dtpData"
      Me.dtpData.Size = New System.Drawing.Size(112, 20)
      Me.dtpData.TabIndex = 2
      Me.dtpData.Value = New Date(2005, 8, 17, 15, 37, 0, 654)
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.BackColor = System.Drawing.Color.Transparent
      Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label7.ForeColor = System.Drawing.Color.Black
      Me.Label7.Location = New System.Drawing.Point(352, 56)
      Me.Label7.Name = "Label7"
      Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label7.Size = New System.Drawing.Size(33, 13)
      Me.Label7.TabIndex = 189
      Me.Label7.Text = "Data:"
      '
      'cmbTrattamento
      '
      Me.cmbTrattamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTrattamento.Items.AddRange(New Object() {"PN - Pernottamento", "BB - Pernottamento e prima colazione", "MP - Mezza Pensione", "PC - Pensione Completa"})
      Me.cmbTrattamento.Location = New System.Drawing.Point(112, 216)
      Me.cmbTrattamento.Name = "cmbTrattamento"
      Me.cmbTrattamento.Size = New System.Drawing.Size(408, 21)
      Me.cmbTrattamento.TabIndex = 14
      '
      'cmdApriIntestatario
      '
      Me.cmdApriIntestatario.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdApriIntestatario.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdApriIntestatario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.cmdApriIntestatario.Location = New System.Drawing.Point(496, 119)
      Me.cmdApriIntestatario.Name = "cmdApriIntestatario"
      Me.cmdApriIntestatario.Size = New System.Drawing.Size(24, 22)
      Me.cmdApriIntestatario.TabIndex = 7
      Me.cmdApriIntestatario.Tag = ""
      Me.cmdApriIntestatario.Text = "..."
      Me.ToolTip1.SetToolTip(Me.cmdApriIntestatario, "Apre la finestra Clienti per un nuovo inserimento.")
      '
      'cmbTipologia
      '
      Me.cmbTipologia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipologia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbTipologia.Items.AddRange(New Object() {"Individuale", "Famiglia", "Gruppo"})
      Me.cmbTipologia.Location = New System.Drawing.Point(112, 88)
      Me.cmbTipologia.Name = "cmbTipologia"
      Me.cmbTipologia.Size = New System.Drawing.Size(112, 21)
      Me.cmbTipologia.TabIndex = 3
      '
      'txtCodice
      '
      Me.txtCodice.AcceptsReturn = True
      Me.txtCodice.BackColor = System.Drawing.SystemColors.Window
      Me.txtCodice.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCodice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCodice.ForeColor = System.Drawing.Color.Red
      Me.txtCodice.Location = New System.Drawing.Point(112, 24)
      Me.txtCodice.MaxLength = 0
      Me.txtCodice.Name = "txtCodice"
      Me.txtCodice.ReadOnly = True
      Me.txtCodice.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCodice.Size = New System.Drawing.Size(112, 20)
      Me.txtCodice.TabIndex = 0
      Me.txtCodice.TabStop = False
      Me.txtCodice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.BackColor = System.Drawing.Color.Transparent
      Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label5.ForeColor = System.Drawing.Color.Black
      Me.Label5.Location = New System.Drawing.Point(32, 24)
      Me.Label5.Name = "Label5"
      Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label5.Size = New System.Drawing.Size(43, 13)
      Me.Label5.TabIndex = 164
      Me.Label5.Text = "Codice:"
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.BackColor = System.Drawing.Color.Transparent
      Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label4.ForeColor = System.Drawing.Color.Black
      Me.Label4.Location = New System.Drawing.Point(32, 88)
      Me.Label4.Name = "Label4"
      Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label4.Size = New System.Drawing.Size(53, 13)
      Me.Label4.TabIndex = 163
      Me.Label4.Text = "Tipologia:"
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.BackColor = System.Drawing.Color.Transparent
      Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label3.ForeColor = System.Drawing.Color.Black
      Me.Label3.Location = New System.Drawing.Point(32, 216)
      Me.Label3.Name = "Label3"
      Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label3.Size = New System.Drawing.Size(67, 13)
      Me.Label3.TabIndex = 162
      Me.Label3.Text = "Trattamento:"
      '
      'Label20
      '
      Me.Label20.AutoSize = True
      Me.Label20.BackColor = System.Drawing.Color.Transparent
      Me.Label20.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label20.ForeColor = System.Drawing.Color.Black
      Me.Label20.Location = New System.Drawing.Point(32, 120)
      Me.Label20.Name = "Label20"
      Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label20.Size = New System.Drawing.Size(62, 13)
      Me.Label20.TabIndex = 153
      Me.Label20.Text = "Intestatario:"
      '
      'TabPage3
      '
      Me.TabPage3.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage3.Controls.Add(Me.cmdInserisciOccupanti)
      Me.TabPage3.Controls.Add(Me.cmdEliminaOccupanti)
      Me.TabPage3.Controls.Add(Me.lvwOccupanti)
      Me.TabPage3.Location = New System.Drawing.Point(4, 22)
      Me.TabPage3.Name = "TabPage3"
      Me.TabPage3.Size = New System.Drawing.Size(584, 539)
      Me.TabPage3.TabIndex = 7
      Me.TabPage3.Text = "Occupanti"
      '
      'cmdInserisciOccupanti
      '
      Me.cmdInserisciOccupanti.Id = "5cb4629d-8026-4d6c-9815-611d4bacb7c7"
      Me.cmdInserisciOccupanti.Location = New System.Drawing.Point(320, 464)
      Me.cmdInserisciOccupanti.Name = "cmdInserisciOccupanti"
      Me.cmdInserisciOccupanti.Size = New System.Drawing.Size(104, 32)
      Me.cmdInserisciOccupanti.TabIndex = 1
      Me.cmdInserisciOccupanti.Text = "&Inserisci"
      '
      'cmdEliminaOccupanti
      '
      Me.cmdEliminaOccupanti.Id = "f4c880ee-0846-4e54-a486-3bc390ef19a6"
      Me.cmdEliminaOccupanti.Location = New System.Drawing.Point(432, 464)
      Me.cmdEliminaOccupanti.Name = "cmdEliminaOccupanti"
      Me.cmdEliminaOccupanti.Size = New System.Drawing.Size(104, 32)
      Me.cmdEliminaOccupanti.TabIndex = 2
      Me.cmdEliminaOccupanti.Text = "&Elimina"
      '
      'lvwOccupanti
      '
      Me.lvwOccupanti.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader14, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader13, Me.ColumnHeader12})
      Me.lvwOccupanti.Dock = System.Windows.Forms.DockStyle.Top
      Me.lvwOccupanti.FullRowSelect = True
      Me.lvwOccupanti.Location = New System.Drawing.Point(0, 0)
      Me.lvwOccupanti.MultiSelect = False
      Me.lvwOccupanti.Name = "lvwOccupanti"
      Me.lvwOccupanti.Size = New System.Drawing.Size(584, 456)
      Me.lvwOccupanti.TabIndex = 0
      Me.lvwOccupanti.UseCompatibleStateImageBehavior = False
      Me.lvwOccupanti.View = System.Windows.Forms.View.Details
      '
      'ColumnHeader14
      '
      Me.ColumnHeader14.Text = "Indice"
      Me.ColumnHeader14.Width = 0
      '
      'ColumnHeader7
      '
      Me.ColumnHeader7.Text = "Cognome"
      Me.ColumnHeader7.Width = 100
      '
      'ColumnHeader8
      '
      Me.ColumnHeader8.Text = "Nome"
      Me.ColumnHeader8.Width = 100
      '
      'ColumnHeader9
      '
      Me.ColumnHeader9.Text = "Data di Nascita"
      Me.ColumnHeader9.Width = 90
      '
      'ColumnHeader10
      '
      Me.ColumnHeader10.Text = "Luogo di Nascita"
      Me.ColumnHeader10.Width = 120
      '
      'ColumnHeader11
      '
      Me.ColumnHeader11.Text = "Provincia"
      '
      'ColumnHeader13
      '
      Me.ColumnHeader13.Text = "Nazionalità"
      Me.ColumnHeader13.Width = 75
      '
      'ColumnHeader12
      '
      Me.ColumnHeader12.Text = "Codice"
      Me.ColumnHeader12.Width = 0
      '
      'TabPage4
      '
      Me.TabPage4.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage4.Controls.Add(Me.eui_QuantitàMeno)
      Me.TabPage4.Controls.Add(Me.eui_cmdQuantitàPiù)
      Me.TabPage4.Controls.Add(Me.txtTotaleAddebitiExtra)
      Me.TabPage4.Controls.Add(Me.Label6)
      Me.TabPage4.Controls.Add(Me.eui_ddwnInserisciAddebiti)
      Me.TabPage4.Controls.Add(Me.eui_cmdEliminaRiga)
      Me.TabPage4.Controls.Add(Me.lvwAddebiti)
      Me.TabPage4.Location = New System.Drawing.Point(4, 22)
      Me.TabPage4.Name = "TabPage4"
      Me.TabPage4.Size = New System.Drawing.Size(584, 539)
      Me.TabPage4.TabIndex = 8
      Me.TabPage4.Text = "Addebiti extra"
      '
      'eui_QuantitàMeno
      '
      Me.eui_QuantitàMeno.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_QuantitàMeno.Id = "935d7524-8227-429e-a226-d2120196b3b4"
      Me.eui_QuantitàMeno.Location = New System.Drawing.Point(280, 464)
      Me.eui_QuantitàMeno.Name = "eui_QuantitàMeno"
      Me.eui_QuantitàMeno.Size = New System.Drawing.Size(54, 32)
      Me.eui_QuantitàMeno.TabIndex = 4
      Me.eui_QuantitàMeno.Text = "-"
      '
      'eui_cmdQuantitàPiù
      '
      Me.eui_cmdQuantitàPiù.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdQuantitàPiù.Id = "5fb61b44-641b-4288-b440-86140f8714bc"
      Me.eui_cmdQuantitàPiù.Location = New System.Drawing.Point(216, 464)
      Me.eui_cmdQuantitàPiù.Name = "eui_cmdQuantitàPiù"
      Me.eui_cmdQuantitàPiù.Size = New System.Drawing.Size(54, 32)
      Me.eui_cmdQuantitàPiù.TabIndex = 3
      Me.eui_cmdQuantitàPiù.Text = "+"
      '
      'txtTotaleAddebitiExtra
      '
      Me.txtTotaleAddebitiExtra.AcceptsReturn = True
      Me.txtTotaleAddebitiExtra.BackColor = System.Drawing.SystemColors.Window
      Me.txtTotaleAddebitiExtra.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtTotaleAddebitiExtra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTotaleAddebitiExtra.ForeColor = System.Drawing.Color.Red
      Me.txtTotaleAddebitiExtra.Location = New System.Drawing.Point(424, 472)
      Me.txtTotaleAddebitiExtra.MaxLength = 0
      Me.txtTotaleAddebitiExtra.Name = "txtTotaleAddebitiExtra"
      Me.txtTotaleAddebitiExtra.ReadOnly = True
      Me.txtTotaleAddebitiExtra.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtTotaleAddebitiExtra.Size = New System.Drawing.Size(112, 20)
      Me.txtTotaleAddebitiExtra.TabIndex = 5
      Me.txtTotaleAddebitiExtra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.BackColor = System.Drawing.Color.Transparent
      Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label6.ForeColor = System.Drawing.Color.Black
      Me.Label6.Location = New System.Drawing.Point(352, 472)
      Me.Label6.Name = "Label6"
      Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label6.Size = New System.Drawing.Size(40, 13)
      Me.Label6.TabIndex = 246
      Me.Label6.Text = "Totale:"
      '
      'eui_ddwnInserisciAddebiti
      '
      Me.eui_ddwnInserisciAddebiti.Id = "6a724180-52f1-430d-a791-0e4ecc9b472b"
      Me.eui_ddwnInserisciAddebiti.Location = New System.Drawing.Point(16, 464)
      Me.eui_ddwnInserisciAddebiti.Name = "eui_ddwnInserisciAddebiti"
      Me.eui_ddwnInserisciAddebiti.Popup = Me.PopupMenu1
      Me.eui_ddwnInserisciAddebiti.Size = New System.Drawing.Size(88, 32)
      Me.eui_ddwnInserisciAddebiti.TabIndex = 1
      Me.eui_ddwnInserisciAddebiti.Text = "&Inserisci"
      '
      'PopupMenu1
      '
      Me.PopupMenu1.Items.AddRange(New System.Windows.Forms.Control() {Me.eui_cmdAccessori, Me.eui_cmdServizi, Me.Separator1, Me.eui_cmdApriPos})
      Me.PopupMenu1.KeepPopupsWithOffsetPlacementWithinPlacementArea = False
      Me.PopupMenu1.PlacementMode = Elegant.Ui.PopupPlacementMode.Bottom
      Me.PopupMenu1.Size = New System.Drawing.Size(100, 100)
      '
      'eui_cmdAccessori
      '
      Me.eui_cmdAccessori.Id = "65ce2768-b168-476b-a00d-d6c84fa68b16"
      Me.eui_cmdAccessori.KeyTip = "A"
      Me.eui_cmdAccessori.Location = New System.Drawing.Point(2, 2)
      Me.eui_cmdAccessori.Name = "eui_cmdAccessori"
      Me.eui_cmdAccessori.ScreenTip.Caption = "Accessori"
      Me.eui_cmdAccessori.ScreenTip.Text = "Apre un'elenco per l'inserimento degli accessori."
      Me.eui_cmdAccessori.Size = New System.Drawing.Size(165, 23)
      Me.eui_cmdAccessori.TabIndex = 3
      Me.eui_cmdAccessori.Text = "&Accessori"
      '
      'eui_cmdServizi
      '
      Me.eui_cmdServizi.Id = "b842a7bc-e784-4c16-a929-9b64c7ed9719"
      Me.eui_cmdServizi.KeyTip = "S"
      Me.eui_cmdServizi.Location = New System.Drawing.Point(2, 25)
      Me.eui_cmdServizi.Name = "eui_cmdServizi"
      Me.eui_cmdServizi.ScreenTip.Caption = "Servizi"
      Me.eui_cmdServizi.ScreenTip.Text = "Apre un'elenco per l'inserimento dei servizi."
      Me.eui_cmdServizi.Size = New System.Drawing.Size(165, 23)
      Me.eui_cmdServizi.TabIndex = 4
      Me.eui_cmdServizi.Text = "&Servizi / Trattamenti"
      '
      'Separator1
      '
      Me.Separator1.Id = "2c444c99-4b2c-43fb-8dec-4325e076e4be"
      Me.Separator1.Location = New System.Drawing.Point(2, 48)
      Me.Separator1.Name = "Separator1"
      Me.Separator1.Orientation = Elegant.Ui.SeparatorOrientation.Horizontal
      Me.Separator1.Size = New System.Drawing.Size(165, 5)
      Me.Separator1.TabIndex = 6
      Me.Separator1.Text = "Separator1"
      '
      'eui_cmdApriPos
      '
      Me.eui_cmdApriPos.Enabled = False
      Me.eui_cmdApriPos.Id = "671aa799-916f-451b-81a2-e4a0d0a5a0f5"
      Me.eui_cmdApriPos.KeyTip = "P"
      Me.eui_cmdApriPos.Location = New System.Drawing.Point(2, 53)
      Me.eui_cmdApriPos.Name = "eui_cmdApriPos"
      Me.eui_cmdApriPos.ScreenTip.Caption = "Apri Punto cassa"
      Me.eui_cmdApriPos.ScreenTip.Text = "Apre il Punto cassa per l'inserimento di prodotti vari."
      Me.eui_cmdApriPos.Size = New System.Drawing.Size(165, 23)
      Me.eui_cmdApriPos.TabIndex = 5
      Me.eui_cmdApriPos.Text = "Apri &Punto cassa"
      '
      'eui_cmdEliminaRiga
      '
      Me.eui_cmdEliminaRiga.Id = "fcff986b-eec3-470c-802c-0667c1cf3949"
      Me.eui_cmdEliminaRiga.Location = New System.Drawing.Point(112, 464)
      Me.eui_cmdEliminaRiga.Name = "eui_cmdEliminaRiga"
      Me.eui_cmdEliminaRiga.Size = New System.Drawing.Size(88, 32)
      Me.eui_cmdEliminaRiga.TabIndex = 2
      Me.eui_cmdEliminaRiga.Text = "&Elimina riga"
      '
      'lvwAddebiti
      '
      Me.lvwAddebiti.AllowColumnReorder = True
      Me.lvwAddebiti.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader5, Me.ColumnHeader6})
      Me.lvwAddebiti.Dock = System.Windows.Forms.DockStyle.Top
      Me.lvwAddebiti.FullRowSelect = True
      ListViewGroup1.Header = "Articoli vari"
      ListViewGroup1.Name = "ListViewGroup1"
      ListViewGroup2.Header = "Accessori"
      ListViewGroup2.Name = "ListViewGroup2"
      ListViewGroup3.Header = "Servizi"
      ListViewGroup3.Name = "ListViewGroup3"
      Me.lvwAddebiti.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup1, ListViewGroup2, ListViewGroup3})
      Me.lvwAddebiti.Location = New System.Drawing.Point(0, 0)
      Me.lvwAddebiti.MultiSelect = False
      Me.lvwAddebiti.Name = "lvwAddebiti"
      Me.lvwAddebiti.Size = New System.Drawing.Size(584, 456)
      Me.lvwAddebiti.TabIndex = 0
      Me.lvwAddebiti.UseCompatibleStateImageBehavior = False
      Me.lvwAddebiti.View = System.Windows.Forms.View.Details
      '
      'ColumnHeader1
      '
      Me.ColumnHeader1.Text = "Data"
      Me.ColumnHeader1.Width = 80
      '
      'ColumnHeader2
      '
      Me.ColumnHeader2.Text = "Descrizione"
      Me.ColumnHeader2.Width = 300
      '
      'ColumnHeader3
      '
      Me.ColumnHeader3.Text = "Quantità"
      '
      'ColumnHeader5
      '
      Me.ColumnHeader5.Text = "Importo"
      Me.ColumnHeader5.Width = 80
      '
      'ColumnHeader6
      '
      Me.ColumnHeader6.Text = "Indice"
      Me.ColumnHeader6.Width = 0
      '
      'TabPage7
      '
      Me.TabPage7.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage7.Controls.Add(Me.cmbIdListino)
      Me.TabPage7.Controls.Add(Me.txtTotaleTassaSoggiorno)
      Me.TabPage7.Controls.Add(Me.Label26)
      Me.TabPage7.Controls.Add(Me.txtTotaleIncassare)
      Me.TabPage7.Controls.Add(Me.Label25)
      Me.TabPage7.Controls.Add(Me.txtServizio)
      Me.TabPage7.Controls.Add(Me.Label24)
      Me.TabPage7.Controls.Add(Me.txtSconto)
      Me.TabPage7.Controls.Add(Me.Label22)
      Me.TabPage7.Controls.Add(Me.cmbApplicaSconto)
      Me.TabPage7.Controls.Add(Me.Label23)
      Me.TabPage7.Controls.Add(Me.txtTotaleAddebiti)
      Me.TabPage7.Controls.Add(Me.Label15)
      Me.TabPage7.Controls.Add(Me.txtTotaleConto)
      Me.TabPage7.Controls.Add(Me.Label14)
      Me.TabPage7.Controls.Add(Me.txtAccontoCamera)
      Me.TabPage7.Controls.Add(Me.Label18)
      Me.TabPage7.Controls.Add(Me.txtPrezzoCamera)
      Me.TabPage7.Controls.Add(Me.txtTotaleCostoCamera)
      Me.TabPage7.Controls.Add(Me.Label16)
      Me.TabPage7.Controls.Add(Me.Label17)
      Me.TabPage7.Controls.Add(Me.cmbListino)
      Me.TabPage7.Controls.Add(Me.Label9)
      Me.TabPage7.Controls.Add(Me.cmbPagamento)
      Me.TabPage7.Controls.Add(Me.Label2)
      Me.TabPage7.Location = New System.Drawing.Point(4, 22)
      Me.TabPage7.Name = "TabPage7"
      Me.TabPage7.Size = New System.Drawing.Size(584, 539)
      Me.TabPage7.TabIndex = 9
      Me.TabPage7.Text = "Gestione conto"
      '
      'cmbIdListino
      '
      Me.cmbIdListino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbIdListino.Location = New System.Drawing.Point(128, 24)
      Me.cmbIdListino.Name = "cmbIdListino"
      Me.cmbIdListino.Size = New System.Drawing.Size(24, 21)
      Me.cmbIdListino.TabIndex = 255
      Me.cmbIdListino.Visible = False
      '
      'txtTotaleTassaSoggiorno
      '
      Me.txtTotaleTassaSoggiorno.AcceptsReturn = True
      Me.txtTotaleTassaSoggiorno.BackColor = System.Drawing.SystemColors.Window
      Me.txtTotaleTassaSoggiorno.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtTotaleTassaSoggiorno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTotaleTassaSoggiorno.ForeColor = System.Drawing.Color.Blue
      Me.txtTotaleTassaSoggiorno.Location = New System.Drawing.Point(416, 144)
      Me.txtTotaleTassaSoggiorno.MaxLength = 0
      Me.txtTotaleTassaSoggiorno.Name = "txtTotaleTassaSoggiorno"
      Me.txtTotaleTassaSoggiorno.ReadOnly = True
      Me.txtTotaleTassaSoggiorno.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtTotaleTassaSoggiorno.Size = New System.Drawing.Size(104, 20)
      Me.txtTotaleTassaSoggiorno.TabIndex = 5
      Me.txtTotaleTassaSoggiorno.TabStop = False
      Me.txtTotaleTassaSoggiorno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label26
      '
      Me.Label26.AutoSize = True
      Me.Label26.BackColor = System.Drawing.Color.Transparent
      Me.Label26.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label26.ForeColor = System.Drawing.Color.Black
      Me.Label26.Location = New System.Drawing.Point(280, 144)
      Me.Label26.Name = "Label26"
      Me.Label26.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label26.Size = New System.Drawing.Size(128, 13)
      Me.Label26.TabIndex = 254
      Me.Label26.Text = "Totale tassa di soggiorno:"
      '
      'txtTotaleIncassare
      '
      Me.txtTotaleIncassare.AcceptsReturn = True
      Me.txtTotaleIncassare.BackColor = System.Drawing.SystemColors.Window
      Me.txtTotaleIncassare.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtTotaleIncassare.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTotaleIncassare.ForeColor = System.Drawing.Color.Red
      Me.txtTotaleIncassare.Location = New System.Drawing.Point(416, 288)
      Me.txtTotaleIncassare.MaxLength = 0
      Me.txtTotaleIncassare.Name = "txtTotaleIncassare"
      Me.txtTotaleIncassare.ReadOnly = True
      Me.txtTotaleIncassare.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtTotaleIncassare.Size = New System.Drawing.Size(104, 20)
      Me.txtTotaleIncassare.TabIndex = 11
      Me.txtTotaleIncassare.TabStop = False
      Me.txtTotaleIncassare.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label25
      '
      Me.Label25.AutoSize = True
      Me.Label25.BackColor = System.Drawing.Color.Transparent
      Me.Label25.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label25.ForeColor = System.Drawing.Color.Black
      Me.Label25.Location = New System.Drawing.Point(280, 288)
      Me.Label25.Name = "Label25"
      Me.Label25.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label25.Size = New System.Drawing.Size(103, 13)
      Me.Label25.TabIndex = 252
      Me.Label25.Text = "Totale da incassare:"
      '
      'txtServizio
      '
      Me.txtServizio.ForeColor = System.Drawing.Color.Black
      Me.txtServizio.Location = New System.Drawing.Point(416, 176)
      Me.txtServizio.MaxLength = 0
      Me.txtServizio.Name = "txtServizio"
      Me.txtServizio.Size = New System.Drawing.Size(104, 20)
      Me.txtServizio.TabIndex = 6
      Me.txtServizio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label24
      '
      Me.Label24.AutoSize = True
      Me.Label24.BackColor = System.Drawing.Color.Transparent
      Me.Label24.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label24.ForeColor = System.Drawing.Color.Black
      Me.Label24.Location = New System.Drawing.Point(280, 176)
      Me.Label24.Name = "Label24"
      Me.Label24.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label24.Size = New System.Drawing.Size(58, 13)
      Me.Label24.TabIndex = 250
      Me.Label24.Text = "% Servizio:"
      '
      'txtSconto
      '
      Me.txtSconto.ForeColor = System.Drawing.Color.Black
      Me.txtSconto.Location = New System.Drawing.Point(416, 200)
      Me.txtSconto.MaxLength = 0
      Me.txtSconto.Name = "txtSconto"
      Me.txtSconto.Size = New System.Drawing.Size(104, 20)
      Me.txtSconto.TabIndex = 8
      Me.txtSconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label22
      '
      Me.Label22.AutoSize = True
      Me.Label22.BackColor = System.Drawing.Color.Transparent
      Me.Label22.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label22.ForeColor = System.Drawing.Color.Black
      Me.Label22.Location = New System.Drawing.Point(280, 200)
      Me.Label22.Name = "Label22"
      Me.Label22.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label22.Size = New System.Drawing.Size(55, 13)
      Me.Label22.TabIndex = 248
      Me.Label22.Text = "% Sconto:"
      '
      'cmbApplicaSconto
      '
      Me.cmbApplicaSconto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbApplicaSconto.Items.AddRange(New Object() {"Totale camera", "Totale conto"})
      Me.cmbApplicaSconto.Location = New System.Drawing.Point(152, 200)
      Me.cmbApplicaSconto.Name = "cmbApplicaSconto"
      Me.cmbApplicaSconto.Size = New System.Drawing.Size(112, 21)
      Me.cmbApplicaSconto.TabIndex = 7
      '
      'Label23
      '
      Me.Label23.AutoSize = True
      Me.Label23.BackColor = System.Drawing.Color.Transparent
      Me.Label23.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label23.ForeColor = System.Drawing.Color.Black
      Me.Label23.Location = New System.Drawing.Point(32, 200)
      Me.Label23.Name = "Label23"
      Me.Label23.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label23.Size = New System.Drawing.Size(107, 13)
      Me.Label23.TabIndex = 247
      Me.Label23.Text = "Applica lo sconto sul:"
      '
      'txtTotaleAddebiti
      '
      Me.txtTotaleAddebiti.AcceptsReturn = True
      Me.txtTotaleAddebiti.BackColor = System.Drawing.SystemColors.Window
      Me.txtTotaleAddebiti.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtTotaleAddebiti.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTotaleAddebiti.ForeColor = System.Drawing.Color.Red
      Me.txtTotaleAddebiti.Location = New System.Drawing.Point(416, 120)
      Me.txtTotaleAddebiti.MaxLength = 0
      Me.txtTotaleAddebiti.Name = "txtTotaleAddebiti"
      Me.txtTotaleAddebiti.ReadOnly = True
      Me.txtTotaleAddebiti.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtTotaleAddebiti.Size = New System.Drawing.Size(104, 20)
      Me.txtTotaleAddebiti.TabIndex = 4
      Me.txtTotaleAddebiti.TabStop = False
      Me.txtTotaleAddebiti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label15
      '
      Me.Label15.AutoSize = True
      Me.Label15.BackColor = System.Drawing.Color.Transparent
      Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label15.ForeColor = System.Drawing.Color.Black
      Me.Label15.Location = New System.Drawing.Point(280, 120)
      Me.Label15.Name = "Label15"
      Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label15.Size = New System.Drawing.Size(106, 13)
      Me.Label15.TabIndex = 214
      Me.Label15.Text = "Totale addebiti extra:"
      '
      'txtTotaleConto
      '
      Me.txtTotaleConto.AcceptsReturn = True
      Me.txtTotaleConto.BackColor = System.Drawing.SystemColors.Window
      Me.txtTotaleConto.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtTotaleConto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTotaleConto.ForeColor = System.Drawing.Color.Red
      Me.txtTotaleConto.Location = New System.Drawing.Point(416, 232)
      Me.txtTotaleConto.MaxLength = 0
      Me.txtTotaleConto.Name = "txtTotaleConto"
      Me.txtTotaleConto.ReadOnly = True
      Me.txtTotaleConto.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtTotaleConto.Size = New System.Drawing.Size(104, 20)
      Me.txtTotaleConto.TabIndex = 9
      Me.txtTotaleConto.TabStop = False
      Me.txtTotaleConto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label14
      '
      Me.Label14.AutoSize = True
      Me.Label14.BackColor = System.Drawing.Color.Transparent
      Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label14.ForeColor = System.Drawing.Color.Black
      Me.Label14.Location = New System.Drawing.Point(280, 232)
      Me.Label14.Name = "Label14"
      Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label14.Size = New System.Drawing.Size(70, 13)
      Me.Label14.TabIndex = 212
      Me.Label14.Text = "Totale conto:"
      '
      'txtAccontoCamera
      '
      Me.txtAccontoCamera.AcceptsReturn = True
      Me.txtAccontoCamera.BackColor = System.Drawing.SystemColors.Window
      Me.txtAccontoCamera.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtAccontoCamera.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtAccontoCamera.ForeColor = System.Drawing.Color.Green
      Me.txtAccontoCamera.Location = New System.Drawing.Point(416, 256)
      Me.txtAccontoCamera.MaxLength = 0
      Me.txtAccontoCamera.Name = "txtAccontoCamera"
      Me.txtAccontoCamera.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtAccontoCamera.Size = New System.Drawing.Size(104, 20)
      Me.txtAccontoCamera.TabIndex = 10
      Me.txtAccontoCamera.TabStop = False
      Me.txtAccontoCamera.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label18
      '
      Me.Label18.AutoSize = True
      Me.Label18.BackColor = System.Drawing.Color.Transparent
      Me.Label18.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label18.ForeColor = System.Drawing.Color.Black
      Me.Label18.Location = New System.Drawing.Point(280, 256)
      Me.Label18.Name = "Label18"
      Me.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label18.Size = New System.Drawing.Size(50, 13)
      Me.Label18.TabIndex = 210
      Me.Label18.Text = "Acconto:"
      '
      'txtPrezzoCamera
      '
      Me.txtPrezzoCamera.BackColor = System.Drawing.SystemColors.Window
      Me.txtPrezzoCamera.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtPrezzoCamera.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtPrezzoCamera.ForeColor = System.Drawing.Color.Red
      Me.txtPrezzoCamera.Location = New System.Drawing.Point(160, 96)
      Me.txtPrezzoCamera.MaxLength = 0
      Me.txtPrezzoCamera.Name = "txtPrezzoCamera"
      Me.txtPrezzoCamera.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtPrezzoCamera.Size = New System.Drawing.Size(104, 20)
      Me.txtPrezzoCamera.TabIndex = 2
      Me.txtPrezzoCamera.TabStop = False
      Me.txtPrezzoCamera.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtTotaleCostoCamera
      '
      Me.txtTotaleCostoCamera.AcceptsReturn = True
      Me.txtTotaleCostoCamera.BackColor = System.Drawing.SystemColors.Window
      Me.txtTotaleCostoCamera.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtTotaleCostoCamera.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTotaleCostoCamera.ForeColor = System.Drawing.Color.Red
      Me.txtTotaleCostoCamera.Location = New System.Drawing.Point(416, 96)
      Me.txtTotaleCostoCamera.MaxLength = 0
      Me.txtTotaleCostoCamera.Name = "txtTotaleCostoCamera"
      Me.txtTotaleCostoCamera.ReadOnly = True
      Me.txtTotaleCostoCamera.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtTotaleCostoCamera.Size = New System.Drawing.Size(104, 20)
      Me.txtTotaleCostoCamera.TabIndex = 3
      Me.txtTotaleCostoCamera.TabStop = False
      Me.txtTotaleCostoCamera.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label16
      '
      Me.Label16.AutoSize = True
      Me.Label16.BackColor = System.Drawing.Color.Transparent
      Me.Label16.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label16.ForeColor = System.Drawing.Color.Black
      Me.Label16.Location = New System.Drawing.Point(280, 96)
      Me.Label16.Name = "Label16"
      Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label16.Size = New System.Drawing.Size(78, 13)
      Me.Label16.TabIndex = 207
      Me.Label16.Text = "Totale camera:"
      '
      'Label17
      '
      Me.Label17.AutoSize = True
      Me.Label17.BackColor = System.Drawing.Color.Transparent
      Me.Label17.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label17.ForeColor = System.Drawing.Color.Black
      Me.Label17.Location = New System.Drawing.Point(32, 96)
      Me.Label17.Name = "Label17"
      Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label17.Size = New System.Drawing.Size(120, 13)
      Me.Label17.TabIndex = 206
      Me.Label17.Text = "Prezzo camera / giorno:"
      '
      'cmbListino
      '
      Me.cmbListino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbListino.Location = New System.Drawing.Point(160, 24)
      Me.cmbListino.Name = "cmbListino"
      Me.cmbListino.Size = New System.Drawing.Size(360, 21)
      Me.cmbListino.TabIndex = 0
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.BackColor = System.Drawing.Color.Transparent
      Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label9.ForeColor = System.Drawing.Color.Black
      Me.Label9.Location = New System.Drawing.Point(32, 24)
      Me.Label9.Name = "Label9"
      Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label9.Size = New System.Drawing.Size(40, 13)
      Me.Label9.TabIndex = 205
      Me.Label9.Text = "Listino:"
      '
      'cmbPagamento
      '
      Me.cmbPagamento.Location = New System.Drawing.Point(160, 56)
      Me.cmbPagamento.Name = "cmbPagamento"
      Me.cmbPagamento.Size = New System.Drawing.Size(360, 21)
      Me.cmbPagamento.TabIndex = 1
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.BackColor = System.Drawing.Color.Transparent
      Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label2.ForeColor = System.Drawing.Color.Black
      Me.Label2.Location = New System.Drawing.Point(32, 56)
      Me.Label2.Name = "Label2"
      Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label2.Size = New System.Drawing.Size(106, 13)
      Me.Label2.TabIndex = 188
      Me.Label2.Text = "Modalità pagamento:"
      '
      'TabPage5
      '
      Me.TabPage5.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage5.Controls.Add(Me.Button5)
      Me.TabPage5.Controls.Add(Me.Button3)
      Me.TabPage5.Controls.Add(Me.Button4)
      Me.TabPage5.Controls.Add(Me.lvwAllegati)
      Me.TabPage5.Location = New System.Drawing.Point(4, 22)
      Me.TabPage5.Name = "TabPage5"
      Me.TabPage5.Size = New System.Drawing.Size(574, 529)
      Me.TabPage5.TabIndex = 4
      Me.TabPage5.Text = "Documenti allegati"
      '
      'Button5
      '
      Me.Button5.Id = "66c9af49-ae69-4d17-a153-fc8b7b9c251f"
      Me.Button5.Location = New System.Drawing.Point(208, 464)
      Me.Button5.Name = "Button5"
      Me.Button5.Size = New System.Drawing.Size(104, 32)
      Me.Button5.TabIndex = 1
      Me.Button5.Text = "&Inserisci"
      '
      'Button3
      '
      Me.Button3.Id = "79b623f2-520c-4ae8-9214-cc5068441d03"
      Me.Button3.Location = New System.Drawing.Point(320, 464)
      Me.Button3.Name = "Button3"
      Me.Button3.Size = New System.Drawing.Size(104, 32)
      Me.Button3.TabIndex = 2
      Me.Button3.Text = "&Modifica"
      '
      'Button4
      '
      Me.Button4.Id = "368cb4d8-8c76-4571-8381-f730faf25625"
      Me.Button4.Location = New System.Drawing.Point(432, 464)
      Me.Button4.Name = "Button4"
      Me.Button4.Size = New System.Drawing.Size(104, 32)
      Me.Button4.TabIndex = 3
      Me.Button4.Text = "&Elimina"
      '
      'lvwAllegati
      '
      Me.lvwAllegati.AllowColumnReorder = True
      Me.lvwAllegati.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader19, Me.ColumnHeader20, Me.ColumnHeader21, Me.ColumnHeader22, Me.ColumnHeader23, Me.ColumnHeader24})
      Me.lvwAllegati.Dock = System.Windows.Forms.DockStyle.Top
      Me.lvwAllegati.Location = New System.Drawing.Point(0, 0)
      Me.lvwAllegati.MultiSelect = False
      Me.lvwAllegati.Name = "lvwAllegati"
      Me.lvwAllegati.Size = New System.Drawing.Size(574, 456)
      Me.lvwAllegati.TabIndex = 0
      Me.lvwAllegati.UseCompatibleStateImageBehavior = False
      Me.lvwAllegati.View = System.Windows.Forms.View.Details
      '
      'ColumnHeader19
      '
      Me.ColumnHeader19.Text = "Documento"
      Me.ColumnHeader19.Width = 200
      '
      'ColumnHeader20
      '
      Me.ColumnHeader20.Text = "Data"
      Me.ColumnHeader20.Width = 75
      '
      'ColumnHeader21
      '
      Me.ColumnHeader21.Text = "Ora"
      Me.ColumnHeader21.Width = 75
      '
      'ColumnHeader22
      '
      Me.ColumnHeader22.Text = "Note"
      Me.ColumnHeader22.Width = 500
      '
      'ColumnHeader23
      '
      Me.ColumnHeader23.Text = "Percorso"
      Me.ColumnHeader23.Width = 500
      '
      'ColumnHeader24
      '
      Me.ColumnHeader24.Text = "Codice"
      Me.ColumnHeader24.Width = 0
      '
      'TabPage6
      '
      Me.TabPage6.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage6.Controls.Add(Me.txtNote)
      Me.TabPage6.Location = New System.Drawing.Point(4, 22)
      Me.TabPage6.Name = "TabPage6"
      Me.TabPage6.Size = New System.Drawing.Size(574, 529)
      Me.TabPage6.TabIndex = 5
      Me.TabPage6.Text = "Note"
      '
      'txtNote
      '
      Me.txtNote.AcceptsReturn = True
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
      Me.txtNote.Size = New System.Drawing.Size(574, 529)
      Me.txtNote.TabIndex = 0
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
      'frmPrenCamera
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(592, 611)
      Me.Controls.Add(Me.TabControl1)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.ToolBar1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmPrenCamera"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Prenotazione camera"
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      Me.TabControl1.ResumeLayout(False)
      Me.TabPage1.ResumeLayout(False)
      Me.TabPage1.PerformLayout()
      CType(Me.nudNeonati, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.nudRagazzi, System.ComponentModel.ISupportInitialize).EndInit()
      Me.Panel2.ResumeLayout(False)
      Me.Panel2.PerformLayout()
      CType(Me.nudBambini, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.nudAdulti, System.ComponentModel.ISupportInitialize).EndInit()
      Me.TabPage3.ResumeLayout(False)
      Me.TabPage4.ResumeLayout(False)
      Me.TabPage4.PerformLayout()
      CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.TabPage7.ResumeLayout(False)
      Me.TabPage7.PerformLayout()
      Me.TabPage5.ResumeLayout(False)
      Me.TabPage6.ResumeLayout(False)
      Me.TabPage6.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Public IPren As New PrenCamere
   Public IPrenOccupanti As New PrenCamereOccupanti
   Public IPrenAddebiti As New PrenCamereAddebiti
   Public IAllegati As New Allegati

   Const NOME_TABELLA As String = "PrenCamere"
   Const TAB_CLIENTI As String = "Clienti"
   Const TAB_CAMERE As String = "Camere"
   Const TAB_LISTINO As String = "ListiniCamere"
   Const TAB_PAGAMENTO As String = "ModPagamento"
   Const TAB_ALLEGATI As String = "Allegati"
   Const TAB_STATO_PREN As String = "StatoPren"
   Const TAB_PREN_OCCUPANTI As String = "PrenCamereOccupanti"
   Const TAB_PREN_ADDEBITI As String = "PrenCamereAddebiti"
   Const TAB_STAGIONI As String = "Stagioni"

   Const BASSA_STAGIONE As String = "BASSA"
   Const MEDIA_STAGIONE As String = "MEDIA"
   Const ALTA_STAGIONE As String = "ALTA"

   Private CFormatta As New ClsFormatta
   Private CConvalida As New ConvalidaKeyPress
   Private DatiConfig As AppConfig

   ' Il tipo di finestra che ha effettuato la chiamata.
   Dim tipoFrm As String
   ' Il tipo di Listino - Prezzo a persona o Camera.
   Dim tipoListino As String
   ' Sconto applicato ai bambini.
   Dim scontoNeonato As String
   Dim scontoBambino As String
   Dim scontoRagazzo As String
   ' Serve a sapere se il form è stato caricato.
   Dim loadForm As Boolean = False

   ' Dichiara un oggetto connessione.
   Dim cn As New OleDbConnection(ConnString)
   ' Dichiara un oggetto transazione.
   Dim tr As OleDbTransaction
   Dim cmd As New OleDbCommand(sql, cn)
   Dim ds As New DataSet
   ' Numero di record.
   Dim numRecord As Integer
   Dim sql As String

   Private Function SalvaDati() As Boolean

      ' Salva eventuali nuovi valori nelle rispettive tabelle dati.
      AggiornaTabella(cmbPagamento, TAB_PAGAMENTO)

      Try
         With IPren
            ' Assegna i dati dei campi della classe alle caselle di testo.
            ' A_TODO: HOTEL - da modificare!
            .IdCliente = Convert.ToInt32(cmbIdCliente.Text)
            .Numero = Convert.ToInt32(txtNumero.Text)
            .Data = dtpData.Text
            .Tipologia = cmbTipologia.Text
            .Stato = cmbStatoPren.Text
            .Cognome = FormattaApici(cmbCognome.Text)
            .Nome = FormattaApici(txtNome.Text)
            .Adulti = nudAdulti.Value
            .Neonati = nudNeonati.Value
            .Bambini = nudBambini.Value
            .Ragazzi = nudRagazzi.Value
            .NumeroCamera = FormattaApici(cmbNumeroCamera.Text)
            .DescrizioneCamera = txtDescrizioneCamera.Text
            .Trattamento = cmbTrattamento.Text
            .DataArrivo = FormattaData(mcDataArrivo.SelectionRange.Start.Date, True)
            .DataPartenza = FormattaData(mcDataPartenza.SelectionRange.Start.Date, True)
            .OraArrivo = dtpOraArrivo.Text
            .NumeroNotti = Convert.ToInt32(txtNumeroNotti.Text)
            .Listino = cmbListino.Text
            .Pagamento = FormattaApici(cmbPagamento.Text)

            If IsNumeric(txtPrezzoCamera.Text) = True Then
               .CostoCamera = CFormatta.FormattaEuro(Convert.ToDecimal(txtPrezzoCamera.Text))
            Else
               .CostoCamera = VALORE_ZERO
            End If
            If IsNumeric(txtAccontoCamera.Text) = True Then
               .AccontoCamera = CFormatta.FormattaEuro(Convert.ToDecimal(txtAccontoCamera.Text))
            Else
               .AccontoCamera = VALORE_ZERO
            End If
            If IsNumeric(txtTotaleConto.Text) = True Then
               .TotaleConto = CFormatta.FormattaEuro(Convert.ToDecimal(txtTotaleConto.Text))
            Else
               .TotaleConto = VALORE_ZERO
            End If

            If IsNumeric(txtSconto.Text) = True Then
               .Sconto = CFormatta.FormattaEuro(Convert.ToDecimal(txtSconto.Text))
            Else
               .Sconto = VALORE_ZERO
            End If
            If IsNumeric(txtServizio.Text) = True Then
               .Servizio = CFormatta.FormattaEuro(Convert.ToDecimal(txtServizio.Text))
            Else
               .Servizio = VALORE_ZERO
            End If

            .ApplicaSconto = cmbApplicaSconto.SelectedIndex.ToString

            .Note = FormattaApici(txtNote.Text)

            If .Colore = 0 Then
               .Colore = Convert.ToInt32(Color.White.ToArgb)
            End If

            '  Se la proprietà 'Tag' contiene un valore viene richiamata la procedura
            ' di modifica dati, altrimenti viene richiamata la procedura di inserimento dati.
            If Me.Tag <> "" Then
               Return .ModificaDati(NOME_TABELLA, Me.Tag)
            Else
               Return .InserisciDati(NOME_TABELLA)
            End If

         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Function

   Private Function SalvaOccupanti(ByVal id As String) As Boolean
      ' Salva i dati per il Tavolo selezionato.
      Try
         Dim idPren As Integer

         If Me.Tag <> "" Then
            idPren = id
         Else
            idPren = LeggiUltimaPren(NOME_TABELLA)
         End If

         With IPrenOccupanti
            .EliminaDati(TAB_PREN_OCCUPANTI, idPren)

            Dim i As Integer
            For i = 0 To lvwOccupanti.Items.Count - 1
               .RifPren = idPren
               .Cognome = lvwOccupanti.Items(i).SubItems(1).Text
               .Nome = lvwOccupanti.Items(i).SubItems(2).Text
               .DataNascita = lvwOccupanti.Items(i).SubItems(3).Text
               .LuogoNascita = lvwOccupanti.Items(i).SubItems(4).Text
               .ProvNascita = lvwOccupanti.Items(i).SubItems(5).Text
               .Nazionalità = lvwOccupanti.Items(i).SubItems(6).Text
               .CodiceCliente = lvwOccupanti.Items(i).SubItems(7).Text

               .InserisciDati(TAB_PREN_OCCUPANTI)
            Next
         End With

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      End Try
   End Function

   Private Function SalvaAddebitiExtra(ByVal id As String) As Boolean
      ' Salva i dati per gli addebiti extra.
      Try
         Dim idPren As Integer

         If Me.Tag <> "" Then
            idPren = id
         Else
            idPren = LeggiUltimaPren(NOME_TABELLA)
         End If

         With IPrenAddebiti
            .EliminaDati(TAB_PREN_ADDEBITI, idPren)

            Dim i As Integer
            For i = 0 To lvwAddebiti.Items.Count - 1
               .RifPren = idPren
               .Data = lvwAddebiti.Items(i).Text
               .Descrizione = lvwAddebiti.Items(i).SubItems(1).Text
               .Quantità = lvwAddebiti.Items(i).SubItems(2).Text
               .Importo = lvwAddebiti.Items(i).SubItems(3).Text
               .Colore = lvwAddebiti.Items(i).ForeColor.ToArgb
               .Gruppo = lvwAddebiti.Items(i).Group.ToString
               .InserisciDati(TAB_PREN_ADDEBITI)
            Next

         End With

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      End Try
   End Function

   Private Sub LeggiOccupanti()
      Try
         With IPrenOccupanti
            .LeggiDati(lvwOccupanti, TAB_PREN_OCCUPANTI, Me.Tag)
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub LeggiAddebitiExtra()
      Try
         With IPrenAddebiti
            .LeggiDati(lvwAddebiti, TAB_PREN_ADDEBITI, Me.Tag)
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   ' A_TODO: HOTEL - da modificare!
   Private Function LeggiTotaleTassaSoggiorno(ByVal numAdulti As Integer, ByVal numNeonati As Integer, ByVal numBambini As Integer, ByVal numRagazzi As Integer) As Decimal
      Try
         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig

         ' Legge il prezzo della Tassa di soggiorno.
         Dim tassaSoggiorno As Double
         If IsNumeric(DatiConfig.GetValue("TassaSoggiornoHotel")) = True Then
            tassaSoggiorno = Convert.ToDouble(DatiConfig.GetValue("TassaSoggiornoHotel"))
         Else
            tassaSoggiorno = 0
         End If

         ' Aggiunge gli Adulti al numero di persone che pagheranno la tassa.
         Dim numPersone As Integer = numAdulti

         ' Verifica se i Neonati pagheranno la tassa.
         Dim applicaTassaNeonati As Boolean
         If DatiConfig.GetValue("ApplicaTassaNeonati") <> String.Empty Then
            applicaTassaNeonati = DatiConfig.GetValue("ApplicaTassaNeonati")
         Else
            applicaTassaNeonati = False
         End If

         ' Aggiunge i Neonati al numero di persone che pagheranno la tassa.
         If applicaTassaNeonati = True Then
            numPersone = numPersone + numNeonati
         End If

         ' Verifica se i Bambini pagheranno la tassa.
         Dim applicaTassaBambini As Boolean
         If DatiConfig.GetValue("ApplicaTassaBambini") <> String.Empty Then
            applicaTassaBambini = DatiConfig.GetValue("ApplicaTassaBambini")
         Else
            applicaTassaBambini = False
         End If

         ' Aggiunge i Bambini al numero di persone che pagheranno la tassa.
         If applicaTassaBambini = True Then
            numPersone = numPersone + numBambini
         End If

         ' Verifica se i Ragazzi pagheranno la tassa.
         Dim applicaTassaRagazzi As Boolean
         If DatiConfig.GetValue("ApplicaTassaRagazzi") <> String.Empty Then
            applicaTassaRagazzi = DatiConfig.GetValue("ApplicaTassaRagazzi")
         Else
            applicaTassaRagazzi = False
         End If

         ' Aggiunge i Ragazzi al numero di persone che pagheranno la tassa.
         If applicaTassaRagazzi = True Then
            numPersone = numPersone + numRagazzi
         End If

         Return (tassaSoggiorno * numPersone).ToString

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return 0

      End Try
   End Function

   Private Sub LeggiServizio()
      Try
         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig

         ' Percentuale per il Servizio.
         txtServizio.Text = DatiConfig.GetValue("ServizioHotel")
         If txtServizio.Text.Length = 0 Then
            txtServizio.Text = VALORE_ZERO
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Function LeggiScontoCliente(ByVal tabella As String, ByVal id As Integer) As String
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Id = " & id & " ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read
            Return dr.Item("Sconto")
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Function

   Private Function LeggiUltimaPren(ByVal tabella As String) As Integer
      Dim closeOnExit As Boolean
      Dim id As Integer

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Verifica l'esistenza del record.
         cmd.CommandText = String.Format("SELECT MAX(Id) FROM {0}", tabella)

         id = CInt(cmd.ExecuteScalar())

         Return id

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Function

   Private Function VerificaDisponibilitàCamera(ByVal numeroCamera As String, ByVal dataDal As Date, ByVal dataAl As Date) As Integer
      Dim closeOnExit As Boolean
      Dim numRec As Integer

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Ottiene il numero di record.
         cmd.CommandText = String.Format("SELECT COUNT(*) FROM {0} " &
                                         "WHERE NumeroCamera = '{1}' " &
                                         "AND (DataArrivo >= #{2}# AND DataArrivo < #{3}#) " &
                                         "OR (DataPartenza > #{2}# AND DataPartenza <= #{3}#) " &
                                         "OR (DataArrivo < #{2}# AND DataPartenza > #{3}#)",
                                         NOME_TABELLA, numeroCamera, dataDal.ToShortDateString, dataAl.ToShortDateString)

         numRec = CInt(cmd.ExecuteScalar())

         Return numRec

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return 0

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Function

   ' A_TODO: HOTEL - da modificare!
   Private Sub SalvaPrenCamere()
      'If SalvaPCamera = True Then
      '   IPrenCamere.EliminaDati(TAB_PREN_CAMERE, IPren.Codice)
      'End If

      'If IPrenCamere.ConvalidaDati(lvwCamere) = True Then
      '   Dim i As Integer
      '   For i = 0 To lvwCamere.Items.Count - 1
      '      With IPrenCamere
      '         .IdPren = IPren.Codice
      '         .Arrivo = lvwCamere.Items(i).SubItems(0).Text
      '         .Partenza = lvwCamere.Items(i).SubItems(1).Text
      '         .Giorni = lvwCamere.Items(i).SubItems(2).Text
      '         .Camera = lvwCamere.Items(i).SubItems(3).Text
      '         .Tipo = lvwCamere.Items(i).SubItems(4).Text
      '         .Sistemazione = lvwCamere.Items(i).SubItems(5).Text
      '      End With

      '      IPrenCamere.InserisciDati(TAB_PREN_CAMERE)
      '   Next
      'End If
   End Sub

   ' A_TODO: HOTEL - da modificare!
   Private Sub SalvaPrenTratt()
      'If SalvaPTratt = True Then
      '   IPrenTratt.EliminaDati(TAB_PREN_TRATT, IPren.Codice)
      'End If

      'If IPrenTratt.ConvalidaDati(lvwTrattamento) = True Then
      '   Dim i As Integer
      '   For i = 0 To lvwTrattamento.Items.Count - 1
      '      With IPrenTratt
      '         .IdPren = IPren.Codice
      '         .Dal = lvwTrattamento.Items(i).SubItems(0).Text
      '         .Al = lvwTrattamento.Items(i).SubItems(1).Text
      '         .Giorni = lvwTrattamento.Items(i).SubItems(2).Text
      '         .Trattamento = lvwTrattamento.Items(i).SubItems(3).Text
      '         .Adulti = lvwTrattamento.Items(i).SubItems(4).Text
      '         .Ragazzi = lvwTrattamento.Items(i).SubItems(5).Text
      '         .Bambini = lvwTrattamento.Items(i).SubItems(6).Text
      '         .Neonati = lvwTrattamento.Items(i).SubItems(7).Text
      '         .Prezzo = lvwTrattamento.Items(i).SubItems(8).Text
      '         .Retta = lvwTrattamento.Items(i).SubItems(9).Text
      '      End With

      '      IPrenTratt.InserisciDati(TAB_PREN_TRATT)
      '   Next
      'End If
   End Sub

   ' NON PIU' UTILIZZATA!
   Private Sub ModificaColore()
      'Try
      '   With ColorDialog1()
      '      .Color = cmdColore.BackColor
      '      .AllowFullOpen = True
      '      .SolidColorOnly = True

      '      If .ShowDialog = DialogResult.OK Then
      '         cmdColore.BackColor = .Color
      '      End If

      '      IPren.Colore = Convert.ToString(.Color.ToArgb)
      '   End With

      'Catch ex As Exception
      '   ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '   err.GestisciErrore(ex.StackTrace, ex.Message)

      'End Try
   End Sub

   ' A_TODO: HOTEL - da modificare!
   Public Function ApriClienti(ByVal val As String) As Boolean
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         ' Per la versione demo.
         ' Se è un nuovo inserimento verifica il numero dei record.
         If val = String.Empty Then
            If g_VerDemo = True Then
               ' Test per la versione demo.
               If VerificaNumRecord(LeggiNumRecord(TAB_CLIENTI, cn, cmd)) = True Then
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

   Private Function ImpostaDatiAllegati(ByVal note As String, ByVal ins As Boolean) As Boolean
      Try
         OpenFileDialog1.Filter = "Tutti i file |*.*"

         OpenFileDialog1.FilterIndex = 1

         'IAllegati.IdCliente = CInt(IPren.IdCliente)

         If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            ' Assegna i dati dei campi della classe alle caselle di testo.
            IAllegati.Documento = Path.GetFileName(OpenFileDialog1.FileName)
            IAllegati.Data = CStr(Today)
            IAllegati.Ora = CStr(TimeOfDay)
            IAllegati.Percorso = OpenFileDialog1.FileName
            IAllegati.Estensione = Path.GetExtension(OpenFileDialog1.FileName)
         Else
            If ins = True Then
               Return False
            End If
         End If

         Dim val As String
         val = InputBox("Digitare il testo per il campo Note.", "Note", note)
         If val <> "" Then
            IAllegati.Note = val
         Else
            IAllegati.Note = note
         End If

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Function

   Public Sub RimuoviAllegati(ByVal tabella As String, ByVal id As Integer)
      Try
         Dim Risposta As Short
         Dim sql As String

         Dim Documento As String = lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(0).Text

         ' Chiede conferma per l'eliminazione.
         Risposta = MsgBox("Si desidera rimuovere il documento """ & Documento & """?" & vbCrLf & vbCrLf & _
                           "Non sarà più possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma rimozione")

         If Risposta = MsgBoxResult.Yes Then
            ' Apre la connessione.
            cn.Open()

            ' Avvia una transazione.
            tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

            ' Crea la stringa di eliminazione.
            sql = String.Format("DELETE FROM {0} WHERE Id = {1}", tabella, id)

            ' Crea il comando per la connessione corrente.
            Dim cmdDelete As New OleDbCommand(sql, cn, tr)

            ' Esegue il comando.
            Dim Record As Integer = cmdDelete.ExecuteNonQuery()

            ' Conferma la transazione.
            tr.Commit()

         End If

      Catch ex As Exception
         ' Annulla la transazione.
         tr.Rollback()

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()
      End Try
   End Sub

   ' A_TODO: HOTEL - da modificare!
   Private Sub ConvalidaAllegati()
      '' Carica la lista dei componenti aggiuntivi.
      'If IAllegati.LeggiDati(lvwAllegati, TAB_ALLEGATI, IPren.IdCliente) = True Then
      '   cmdModifica.Enabled = True
      '   cmdRimuovi.Enabled = True
      'Else
      '   cmdModifica.Enabled = False
      '   cmdRimuovi.Enabled = False
      'End If

   End Sub

   ' A_TODO: HOTEL - da modificare!
   Private Sub ConvalidaPrenCamere()
      '' Carica la lista dei componenti aggiuntivi.
      'If IPrenCamere.ConvalidaDati(lvwCamere) = True Then
      '   cmdModCamere.Enabled = True
      '   cmdRimCamere.Enabled = True
      'Else
      '   cmdModCamere.Enabled = False
      '   cmdRimCamere.Enabled = False
      'End If
   End Sub

   ' A_TODO: HOTEL - da modificare!
   Private Sub ConvalidaPrenTratt()
      '' Carica la lista dei componenti aggiuntivi.
      'If IPrenTratt.ConvalidaDati(lvwTrattamento) = True Then
      '   cmdModTratt.Enabled = True
      '   cmdRimTratt.Enabled = True
      'Else
      '   cmdModTratt.Enabled = False
      '   cmdRimTratt.Enabled = False
      'End If
   End Sub

   Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
      Select Case e.Button.Tag
         Case "Salva"

            If VerificaDisponibilitàCamera(cmbNumeroCamera.Text, mcDataArrivo.SelectionRange.Start.Date, mcDataPartenza.SelectionRange.Start.Date) <> 0 Then
               MessageBox.Show("La camera che si vuole prenotare non è disponibile per il periodo selezionato!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
               ' Salva i dati nel database.
               If SalvaDati() = True Then

                  ' Salva eventuali clienti occupanti.
                  SalvaOccupanti(Me.Tag)

                  ' Salva eventuali addebiti extra.
                  SalvaAddebitiExtra(Me.Tag)

                  Select Case tipoFrm
                     Case ElencoPrenCamere.Name
                        ' Aggiorna la griglia dati.
                        g_frmPrenCamere.AggiornaDati()

                     Case PlanningCamere.Name
                        ' Aggiorna il Planning con eventuali nuove camere e prentazioni..
                        g_frmPlanningCamere.AggiornaPlanning()

                  End Select

                  ' Chiude la finestra.
                  Me.Close()
               End If
            End If

         Case "Annulla"

            ' Chiude la finestra.
            Me.Close()

      End Select
   End Sub

   Private Sub frmPrenCamera_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         ' A_TODO: HOTEL - da modificare!
         ' Carica le liste.
         CaricaListaClienti(cmbCognome, cmbNome, cmbIdCliente, TAB_CLIENTI)
         CaricaListaCamere(cmbNumeroCamera, TAB_CAMERE)
         CaricaLista(cmbListino, cmbIdListino, TAB_LISTINO)
         CaricaLista(cmbPagamento, TAB_PAGAMENTO)
         CaricaLista(cmbStatoPren, TAB_STATO_PREN)

         If Me.Tag <> "" Then
            With IPren
               ' Comando Modifica.

               ' Visualizza i dati nei rispettivi campi.
               .LeggiDati(NOME_TABELLA, Me.Tag)

               ' Assegna i dati dei campi della classe alle caselle di testo.
               '.idcliente = 
               txtCodice.Text = .Codice
               txtNumero.Text = .Numero
               dtpData.Value = Convert.ToDateTime(.Data)
               cmbTipologia.Text = .Tipologia
               cmbStatoPren.Text = .Stato
               cmbCognome.Text = .Cognome
               txtNome.Text = .Nome
               cmbListino.Text = .Listino
               nudAdulti.Value = Convert.ToDecimal(.Adulti)
               nudNeonati.Value = Convert.ToDecimal(.Neonati)
               nudBambini.Value = Convert.ToDecimal(.Bambini)
               nudRagazzi.Value = Convert.ToDecimal(.Ragazzi)
               cmbNumeroCamera.Text = .NumeroCamera
               txtDescrizioneCamera.Text = .DescrizioneCamera
               cmbTrattamento.Text = .Trattamento
               mcDataArrivo.SetDate(Convert.ToDateTime(.DataArrivo))
               mcDataPartenza.SetDate(Convert.ToDateTime(.DataPartenza))
               dtpOraArrivo.Value = Convert.ToDateTime(.OraArrivo)
               txtNumeroNotti.Text = .NumeroNotti.ToString
               cmbPagamento.Text = .Pagamento
               txtPrezzoCamera.Text = CFormatta.FormattaEuro(.CostoCamera)
               txtAccontoCamera.Text = CFormatta.FormattaEuro(.AccontoCamera)
               txtTotaleConto.Text = CFormatta.FormattaEuro(.TotaleConto)
               cmbApplicaSconto.SelectedIndex = Convert.ToInt32(.ApplicaSconto)

               If IsNumeric(.Sconto) = True Then
                  txtSconto.Text = CFormatta.FormattaEuro(Convert.ToDecimal(.Sconto))
               Else
                  txtSconto.Text = VALORE_ZERO
               End If
               If IsNumeric(.Servizio) = True Then
                  txtServizio.Text = CFormatta.FormattaEuro(Convert.ToDecimal(.Servizio))
               Else
                  txtServizio.Text = VALORE_ZERO
               End If

               txtNote.Text = .Note

               If .Colore <> 0 Then
                  cmdColore.BackColor = Color.FromArgb(.Colore)
               End If

               ' Aggiorna la nuova data di arrivo.
               lblArrivo.Text = "Arrivo: " & Convert.ToDateTime(.DataArrivo).ToLongDateString
               ' Aggiorna la nuova data di partenza.
               lblPartenza.Text = "Partenza: " & Convert.ToDateTime(.DataPartenza).ToLongDateString

               ' Carica eventuali clienti occupanti.
               LeggiOccupanti()

               ' Carica eventuali addebiti extra.
               LeggiAddebitiExtra()
               CalcolaTotaleAddebiti()

               ' Legge il Sevizio.
               LeggiServizio()

            End With
         Else
            ' Comando Nuovo.

            ' Genera il numero progressivo.
            txtNumero.Text = LeggiUltimoRecord(NOME_TABELLA, "Numero") + 1
            ' Data prenotazione - Oggi.
            dtpData.Value = Today
            ' Seleziona il valore Individuale.
            cmbTipologia.SelectedIndex = 0
            ' Seleziona il valore Solo Pernottamento.
            cmbTrattamento.SelectedIndex = 0

            Select Case tipoFrm
               Case ElencoPrenCamere.Name
                  ' Data e ora di arrivo
                  mcDataArrivo.SetDate(Today)
                  mcDataPartenza.MinDate = Today.AddDays(1)
                  mcDataPartenza.SetDate(Today.AddDays(1))
                  ' Aggiorna la nuova data di arrivo.
                  lblArrivo.Text = "Arrivo: " & Today.ToLongDateString
                  ' Aggiorna la nuova data di partenza.
                  lblPartenza.Text = "Partenza: " & Today.AddDays(1).ToLongDateString
                  ' Aggiorna il numero delle notti.
                  txtNumeroNotti.Text = CalcolaNumGiorni(Today, mcDataPartenza.SelectionRange.Start.Date).ToString

               Case PlanningCamere.Name
                  Dim data As Date = Convert.ToDateTime(g_frmPlanningCamere.dgvPrenotazioni.Columns(g_frmPlanningCamere.dgvPrenotazioni.CurrentCell.ColumnIndex).Name).Date

                  ' Data e ora di arrivo
                  mcDataArrivo.SetDate(data)
                  mcDataPartenza.MinDate = data.AddDays(1)
                  mcDataPartenza.SetDate(data.AddDays(1))
                  ' Aggiorna la nuova data di arrivo.
                  lblArrivo.Text = "Arrivo: " & data.ToLongDateString
                  ' Aggiorna la nuova data di partenza.
                  lblPartenza.Text = "Partenza: " & data.AddDays(1).ToLongDateString
                  ' Aggiorna il numero delle notti.
                  txtNumeroNotti.Text = CalcolaNumGiorni(data, mcDataPartenza.SelectionRange.Start.Date).ToString
                  ' Assegna il numero di camera selezionato dal Planning.
                  cmbNumeroCamera.Text = g_frmPlanningCamere.dgvCamere.Rows(g_frmPlanningCamere.dgvPrenotazioni.CurrentCell.RowIndex).Cells("Numero").Value

            End Select

            ' Ora corrente.
            dtpOraArrivo.Value = Now

            ' Contabile.
            txtPrezzoCamera.Text = VALORE_ZERO
            txtTotaleCostoCamera.Text = VALORE_ZERO
            txtTotaleAddebiti.Text = VALORE_ZERO
            txtSconto.Text = VALORE_ZERO
            txtServizio.Text = VALORE_ZERO
            txtTotaleTassaSoggiorno.Text = VALORE_ZERO
            txtTotaleConto.Text = VALORE_ZERO
            txtAccontoCamera.Text = VALORE_ZERO
            cmbApplicaSconto.SelectedIndex = 0

         End If

         ' A_TODO: HOTEL - da modificare!
         'IPrenCamere = New PrenCamere
         'IPrenCamere.LeggiDati(lvwCamere, TAB_PREN_CAMERE, IPren.Codice)
         'ConvalidaPrenCamere()

         'IPrenTratt = New PrenTratt
         'IPrenTratt.LeggiDati(lvwTrattamento, TAB_PREN_TRATT, IPren.Codice)
         'ConvalidaPrenTratt()

         ' Carica la lista delle degli allegati.
         ConvalidaAllegati()

         ' Genera l'intestazione con i dati del form.
         lblIntestazione.Text = VisIntestazione(txtNumero.Text, cmbCognome.Text, txtNome.Text)

         ' Imposta i pulsanti di default.
         'cmdInsCamere.NotifyDefault(True)
         'cmdInsTratt.NotifyDefault(True)
         'cmdInserimento.NotifyDefault(True)

         ' Imposta lo stato attivo.
         txtNumero.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

         ' Serve a sapere se il form è stato caricato.
         loadForm = True
      End Try
   End Sub

   ' A_TODO: HOTEL - da modificare!
   Private Sub frmPrenCamera_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      If Me.Tag <> "0" Then
         ' Registra loperazione effettuata dall'operatore identificato.
         'g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_GESTIONE_PREN_RISORSE)
      End If

   End Sub

   Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
      ' Imposta lo stato attivo.
      Select Case TabControl1.SelectedIndex()
         Case 0
            ' Dati principali.
            txtNumero.Focus()

         Case 1
            ' Occupanti.
            lvwOccupanti.Focus()

         Case 2
            ' Addebiti extra.
            lvwAddebiti.Focus()

         Case 3
            ' Contabile.
            cmbListino.Focus()

            ' Inserisce il prezzo della camera in base al Listino elezionato.
            ApplicaListino()

         Case 4
            ' Allegati.
            lvwAllegati.Focus()

         Case 5
            ' Note.
            txtNote.Focus()

      End Select
   End Sub

   Private Sub cmdColore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdColore.Click
      'ModificaColore()
      MessageBox.Show("Per assegnare un colore alla prenotazione selezionare un valore nella casella 'Stato prenotazione'.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
   End Sub

   Private Sub cmdApriIntestatario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApriIntestatario.Click
      Try
         ' Se è stato inserito un nuovo cliente...
         If ApriClienti("") = True Then
            CaricaListaClienti(cmbCognome, cmbNome, cmbIdCliente, TAB_CLIENTI)

            cmbCognome.Text = String.Empty
            cmbNome.Text = String.Empty
            txtNome.Text = String.Empty
            cmbIdCliente.Text = String.Empty
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   ' A_TODO: HOTEL - da modificare!
   Private Sub cmdRimuovi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         'cmdInserimento.NotifyDefault(False)

         RimuoviAllegati(TAB_ALLEGATI, lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(5).Text)
         ConvalidaAllegati()

      Catch ex As NullReferenceException
         ' Visualizza un messaggio.
         MessageBox.Show("Selezionare un elemento dalla lista.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

      End Try
   End Sub

   ' A_TODO: HOTEL - da modificare!
   Private Sub cmdModifica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         'cmdInserimento.NotifyDefault(False)

         With IAllegati
            .Documento = lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(0).Text
            .Data = lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(1).Text
            .Ora = lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(2).Text
            .Note = lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(3).Text
            .Percorso = lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(4).Text

            If ImpostaDatiAllegati(.Note, False) = True Then
               .ModificaDati(TAB_ALLEGATI, lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(5).Text)
               ConvalidaAllegati()
            End If
         End With

      Catch ex As NullReferenceException
         ' Visualizza un messaggio.
         MessageBox.Show("Selezionare un elemento dalla lista.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

      End Try
   End Sub

   ' A_TODO: HOTEL - da modificare!
   Private Sub cmdInserimento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      If ImpostaDatiAllegati("", True) = True Then
         IAllegati.InserisciDati(TAB_ALLEGATI)
         ConvalidaAllegati()
      End If

   End Sub

   ' A_TODO: HOTEL - da modificare!
   Private Sub cmdInsCamere_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      'Try
      '   Dim frm As New frmPrenCamere

      '   frm.VisDati(IPrenCamere, False)

      '   If frm.ShowDialog() = DialogResult.OK Then
      '      SalvaPCamera = True
      '      IPrenCamere.NuovoElemento(lvwCamere)
      '      ConvalidaPrenCamere()
      '   End If

      'Catch ex As Exception
      '   ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '   err.GestisciErrore(ex.StackTrace, ex.Message)

      'End Try
   End Sub

   ' A_TODO: HOTEL - da modificare!
   Private Sub cmdModCamere_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      'cmdInsCamere.NotifyDefault(False)

      'Try
      '   Dim frm As New frmPrenCamere

      '   With IPrenCamere
      '      .Arrivo = lvwCamere.Items(lvwCamere.FocusedItem.Index).SubItems(0).Text
      '      .Partenza = lvwCamere.Items(lvwCamere.FocusedItem.Index).SubItems(1).Text
      '      .Camera = lvwCamere.Items(lvwCamere.FocusedItem.Index).SubItems(3).Text
      '   End With

      '   frm.VisDati(IPrenCamere, True)

      '   If frm.ShowDialog() = DialogResult.OK Then
      '      SalvaPCamera = True
      '      IPrenCamere.RimuoviElemento(lvwCamere)
      '      IPrenCamere.NuovoElemento(lvwCamere)
      '   End If

      'Catch ex As NullReferenceException
      '   ' Visualizza un messaggio.
      '   MessageBox.Show("Selezionare un elemento dalla lista.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

      'End Try
   End Sub

   ' A_TODO: HOTEL - da modificare!
   Private Sub cmdRimCamere_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      'cmdInsCamere.NotifyDefault(False)

      'Try
      '   Dim Risposta As Short

      '   Dim val As String
      '   val = lvwCamere.Items(lvwCamere.FocusedItem.Index).SubItems(0).Text

      '   ' Chiede conferma per l'eliminazione.
      '   Risposta = MsgBox("Si desidera rimuovere l'elemento selezionato?" & vbCrLf & vbCrLf & _
      '                     "Non sarà più possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma rimozione")

      '   If Risposta = MsgBoxResult.Yes Then
      '      SalvaPCamera = True
      '      IPrenCamere.RimuoviElemento(lvwCamere)
      '      ConvalidaPrenCamere()
      '   End If

      'Catch ex As NullReferenceException
      '   ' Visualizza un messaggio.
      '   MessageBox.Show("Selezionare un elemento dalla lista.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

      'End Try
   End Sub

   ' A_TODO: HOTEL - da modificare!
   Private Sub cmdInsTratt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      'Try
      '   Dim frm As New frmPrenTratt

      '   frm.VisDati(IPrenTratt, False)

      '   If frm.ShowDialog() = DialogResult.OK Then
      '      SalvaPTratt = True
      '      IPrenTratt.NuovoElemento(lvwTrattamento)
      '      ConvalidaPrenTratt()
      '   End If

      'Catch ex As Exception
      '   ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '   err.GestisciErrore(ex.StackTrace, ex.Message)

      'End Try
   End Sub

   ' A_TODO: HOTEL - da modificare!
   Private Sub cmdModTratt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      'cmdInsTratt.NotifyDefault(False)

      'Try
      '   Dim frm As New frmPrenTratt
      '   With IPrenTratt
      '      .Dal = lvwTrattamento.Items(lvwTrattamento.FocusedItem.Index).SubItems(0).Text
      '      .Al = lvwTrattamento.Items(lvwTrattamento.FocusedItem.Index).SubItems(1).Text
      '      .Trattamento = lvwTrattamento.Items(lvwTrattamento.FocusedItem.Index).SubItems(3).Text
      '      .Adulti = lvwTrattamento.Items(lvwTrattamento.FocusedItem.Index).SubItems(4).Text
      '      .Ragazzi = lvwTrattamento.Items(lvwTrattamento.FocusedItem.Index).SubItems(5).Text
      '      .Bambini = lvwTrattamento.Items(lvwTrattamento.FocusedItem.Index).SubItems(6).Text
      '      .Neonati = lvwTrattamento.Items(lvwTrattamento.FocusedItem.Index).SubItems(7).Text
      '   End With

      '   frm.VisDati(IPrenTratt, True)

      '   If frm.ShowDialog() = DialogResult.OK Then
      '      SalvaPTratt = True
      '      IPrenTratt.RimuoviElemento(lvwTrattamento)
      '      IPrenTratt.NuovoElemento(lvwTrattamento)
      '   End If

      'Catch ex As NullReferenceException
      '   ' Visualizza un messaggio.
      '   MessageBox.Show("Selezionare un elemento dalla lista.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

      'End Try
   End Sub

   ' A_TODO: HOTEL - da modificare!
   Private Sub cmdRimTratt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      'cmdInsTratt.NotifyDefault(False)

      'Try
      '   Dim Risposta As Short

      '   Dim val As String
      '   val = lvwTrattamento.Items(lvwTrattamento.FocusedItem.Index).SubItems(0).Text

      '   ' Chiede conferma per l'eliminazione.
      '   Risposta = MsgBox("Si desidera rimuovere l'elemento selezionato?" & vbCrLf & vbCrLf & _
      '                     "Non sarà più possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma rimozione")

      '   If Risposta = MsgBoxResult.Yes Then
      '      SalvaPTratt = True
      '      IPrenTratt.RimuoviElemento(lvwTrattamento)
      '      ConvalidaPrenTratt()
      '   End If

      'Catch ex As NullReferenceException
      '   ' Visualizza un messaggio.
      '   MessageBox.Show("Selezionare un elemento dalla lista.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

      'End Try
   End Sub

   ' A_TODO: HOTEL - da modificare!
   Private Sub lvwAllegati_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwAllegati.DoubleClick
      ' a_todo: DA TERMINARE - IMPOSTARE TUTTI I PROGRAMMI APRIBILI.
      Dim Estensione As String
      Dim NomeFile As String
      Dim Percorso As String
      Dim PercorsoApp As String
      Dim NomeApp As String
      Dim Proc As New Process

      Try

         ' Nome del file.
         NomeFile = lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(0).Text
         ' Percorso del file.
         Percorso = lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(4).Text

         ' Ottiene l'estensione del file.
         Estensione = Path.GetExtension(Percorso)

         Select Case Estensione.ToUpper
            Case ".DOC", ".RTF"
               ' Word
               NomeApp = "WINWORD.EXE"

            Case ".XLS"
               ' Excel
               NomeApp = "EXCEL.EXE"

            Case ".MDB"
               ' Access
               NomeApp = "MSACCESS.EXE"

            Case ".PPT"
               ' Power Point
               NomeApp = "POWERPNT.EXE"

            Case ".TXT"
               ' Blocco note.
               NomeApp = "NOTEPAD.EXE"

            Case ".PDF"
               ' Acrobat Reader
               NomeApp = "ACRORD32.EXE"

            Case ".HTM"
               ' Internet Explorer
               NomeApp = "IEXPLORE.EXE"
         End Select

         ' Avvia l'applicazione.
         Proc.StartInfo.FileName = NomeApp
         Proc.StartInfo.Arguments = Percorso
         Proc.StartInfo.ErrorDialog = True
         Proc.StartInfo.ErrorDialogParentHandle = Me.Handle
         Proc.StartInfo.UseShellExecute = True
         Proc.Start()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         'err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub cmbStatoPren_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStatoPren.SelectedIndexChanged
      Try
         cmdColore.BackColor = Color.FromArgb(AssegnaColore(cmbStatoPren.Text, TAB_STATO_PREN))
         IPren.Colore = Convert.ToString(cmdColore.BackColor.ToArgb)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Private Sub mcDataArrivo_DateChanged(sender As System.Object, e As System.Windows.Forms.DateRangeEventArgs) Handles mcDataArrivo.DateChanged
      Try
         ' Aggiorna la nuova data di arrivo.
         lblArrivo.Text = "Arrivo: " & e.Start.Date.ToLongDateString

         ' Se la data di arrivo è maggiore o uguale alla data di partenza.
         If e.Start.Date.Date >= mcDataPartenza.SelectionRange.Start.Date Then

            ' Imposta nuovamente il calendario.
            mcDataPartenza.MinDate = e.Start.Date.AddDays(1)

            ' Aggiorna la nuova data di partenza.
            lblPartenza.Text = "Partenza: " & mcDataPartenza.SelectionRange.Start.Date.ToLongDateString

            ' Aggiorna il numero delle notti.
            txtNumeroNotti.Text = CalcolaNumGiorni(e.Start.Date, mcDataPartenza.SelectionRange.Start.Date).ToString

            ' Inserisce il prezzo della camera in base al Listino elezionato.
            ApplicaListino()

            Exit Sub
         End If

         ' Imposta nuovamente il calendario.
         mcDataPartenza.MinDate = e.Start.Date.AddDays(1)

         ' Aggiorna il numero delle notti.
         txtNumeroNotti.Text = CalcolaNumGiorni(e.Start.Date, mcDataPartenza.SelectionRange.Start.Date).ToString

         ' Inserisce il prezzo della camera in base al Listino elezionato.
         ApplicaListino()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub mcDataPartenza_DateChanged(sender As System.Object, e As System.Windows.Forms.DateRangeEventArgs) Handles mcDataPartenza.DateChanged
      Try
         ' Aggiorna la nuova data di partenza.
         lblPartenza.Text = "Partenza: " & e.Start.Date.ToLongDateString

         ' Aggiorna il numero delle notti.
         txtNumeroNotti.Text = CalcolaNumGiorni(mcDataArrivo.SelectionRange.Start.Date, e.Start.Date).ToString

         ' Inserisce il prezzo della camera in base al Listino elezionato.
         'ApplicaListino()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub cmbNumeroCamera_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbNumeroCamera.SelectedIndexChanged
      Try
         txtDescrizioneCamera.Text = LeggiDescrizioneCamera(cmbNumeroCamera.Text, TAB_CAMERE)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub cmbCognome_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbCognome.SelectedIndexChanged
      Try
         ' Legge il nome relativo alla lista Cognome.
         cmbIdCliente.SelectedIndex = cmbCognome.SelectedIndex
         cmbNome.SelectedIndex = cmbCognome.SelectedIndex
         txtNome.Text = cmbNome.Text

         ' Genera l'intestazione con i dati del form.
         lblIntestazione.Text = VisIntestazione(txtNumero.Text, cmbCognome.Text, txtNome.Text)

         ' Se è impostata l'aliquota Iva per il cliente... Altrimenti viene utilzzata quella di reparto.
         'Dim valIva As String = CFormatta.FormattaEuro(LeggiIvaCliente(ANA_CLIENTI, cmbIdCliente.Text))
         'If valIva <> VALORE_ZERO Then
         '   txtIva.Text = valIva
         'End If

         Dim valSconto As String = LeggiScontoCliente(TAB_CLIENTI, cmbIdCliente.Text)

         If IsNumeric(valSconto) = True Then
            txtSconto.Text = CFormatta.FormattaEuro(Convert.ToDecimal(valSconto)) '& "%"
         Else
            txtSconto.Text = VALORE_ZERO
         End If

         CalcolaTotaleConto()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub txtPrezzoCamera_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrezzoCamera.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtAccontoCamera_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAccontoCamera.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtPrezzoCamera_LostFocus(sender As Object, e As System.EventArgs) Handles txtPrezzoCamera.LostFocus
      Try
         If IsNumeric(sender.Text) Then
            sender.Text = CFormatta.FormattaEuro(Convert.ToDecimal(sender.Text))
         Else
            sender.Text = VALORE_ZERO
         End If

         ' Esegue i calcoli per il totale degli importi.
         CalcolaTotaleConto()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtAccontoCamera_LostFocus(sender As Object, e As System.EventArgs) Handles txtAccontoCamera.LostFocus
      Try
         If IsNumeric(sender.Text) Then
            sender.Text = CFormatta.FormattaEuro(Convert.ToDecimal(sender.Text))
         Else
            sender.Text = VALORE_ZERO
         End If

         ' Esegue i calcoli per il totale degli importi.
         CalcolaTotaleConto()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub CalcolaTotaleAddebiti()
      Try
         If lvwAddebiti.Items.Count <> 0 Then
            Dim i As Integer = 0
            Dim TotRiga As Decimal
            Dim TotaleConto As Decimal

            For i = 0 To lvwAddebiti.Items.Count - 1
               TotRiga = Convert.ToDecimal(lvwAddebiti.Items(i).SubItems(3).Text)
               TotaleConto = TotaleConto + TotRiga
            Next i

            txtTotaleAddebitiExtra.Text = CFormatta.FormattaEuro(TotaleConto)
         Else
            txtTotaleAddebitiExtra.Text = VALORE_ZERO
         End If

         ' Aggiorna il campo nella scheda Contabile.
         txtTotaleAddebiti.Text = txtTotaleAddebitiExtra.Text

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CalcolaTotaleConto()
      Try
         Dim numNotti As Integer
         If IsNumeric(txtNumeroNotti.Text) = True Then
            numNotti = Convert.ToInt32(txtNumeroNotti.Text)
         Else
            numNotti = 0
         End If

         Dim prezzoCamera As Double
         If IsNumeric(txtPrezzoCamera.Text) = True Then
            prezzoCamera = Convert.ToDouble(txtPrezzoCamera.Text)
         Else
            prezzoCamera = 0
         End If

         Dim addebitiExtra As Double
         If IsNumeric(txtTotaleAddebiti.Text) = True Then
            addebitiExtra = Convert.ToDouble(txtTotaleAddebiti.Text)
         Else
            addebitiExtra = 0
         End If

         Dim accontoCamera As Double
         If IsNumeric(txtAccontoCamera.Text) = True Then
            accontoCamera = Convert.ToDouble(txtAccontoCamera.Text)
         Else
            accontoCamera = 0
         End If

         ' Calcola il totale del costo della camera in base al tipo di listino applicato.
         Dim totCamera As Double
         Dim totCameraAdulti As Double
         Dim totCameraNeonati As Double
         Dim totCameraBambini As Double
         Dim totCameraRagazzi As Double

         Dim numAdulti As Integer = Convert.ToInt32(nudAdulti.Value)
         Dim numNeonati As Integer = Convert.ToInt32(nudNeonati.Value)
         Dim numBambini As Integer = Convert.ToInt32(nudBambini.Value)
         Dim numRagazzi As Integer = Convert.ToInt32(nudRagazzi.Value)

         Select Case tipoListino

            Case "Tariffa a Persona"
               ' Adulti.
               totCameraAdulti = ((prezzoCamera * numAdulti) * numNotti)

               ' Neonati.
               If scontoNeonato = VALORE_ZERO Or scontoNeonato = String.Empty Then
                  totCameraNeonati = ((prezzoCamera * numNeonati) * numNotti)
               Else
                  Dim scontoPrezzoCamera As Double = ((prezzoCamera * Convert.ToDouble(scontoNeonato)) / 100)
                  totCameraNeonati = ((scontoPrezzoCamera * numNeonati) * numNotti)
               End If

               ' Bambini.
               If scontoBambino = VALORE_ZERO Or scontoBambino = String.Empty Then
                  totCameraBambini = ((prezzoCamera * numBambini) * numNotti)
               Else
                  Dim scontoPrezzoCamera As Double = ((prezzoCamera * Convert.ToDouble(scontoBambino)) / 100)
                  totCameraBambini = ((scontoPrezzoCamera * numBambini) * numNotti)
               End If

               ' Ragazzi.
               If scontoRagazzo = VALORE_ZERO Or scontoRagazzo = String.Empty Then
                  totCameraRagazzi = ((prezzoCamera * numRagazzi) * numNotti)
               Else
                  Dim scontoPrezzoCamera As Double = ((prezzoCamera * Convert.ToDouble(scontoRagazzo)) / 100)
                  totCameraRagazzi = ((scontoPrezzoCamera * numRagazzi) * numNotti)
               End If

               ' Totale camera complessivo.
               totCamera = (totCameraAdulti + totCameraNeonati + totCameraBambini + totCameraRagazzi)

            Case "Tariffa a Camera"
               ' Totale camera complessivo.
               totCamera = (prezzoCamera * numNotti)

         End Select

         txtTotaleCostoCamera.Text = CFormatta.FormattaEuro(totCamera)

         ' Legge e calcola il totale per la Tassa di Soggiorno.
         Dim totaleTassaSoggiorno As Double
         totaleTassaSoggiorno = LeggiTotaleTassaSoggiorno(numAdulti, numNeonati, numBambini, numRagazzi)
         txtTotaleTassaSoggiorno.Text = CFormatta.FormattaEuro(totaleTassaSoggiorno)

         ' Calcola il totale parziale del conto.
         Dim totConto As Double = (totCamera + addebitiExtra + totaleTassaSoggiorno) ' - accontoCamera)

         ' Calcola il valore del servizio sul totale del conto.
         Dim valServizio As Double
         Dim servizio As Double
         'Dim percServizio As Integer = txtServizio.Text.IndexOf("%")
         'If percServizio <> -1 Then
         If IsNumeric((txtServizio.Text)) Then
            servizio = Convert.ToDouble(txtServizio.Text) '.Remove(txtServizio.Text.Length - 1, 1))
            valServizio = CalcolaPercentuale(totConto, servizio)
         Else
            valServizio = 0 'Convert.ToDouble(txtServizio.Text)
            txtServizio.Text = VALORE_ZERO
         End If

         ' Calcola il valore dello sconto.
         Dim valSconto As Double
         Dim sconto As Double
         'Dim percSconto As Integer = txtSconto.Text.IndexOf("%")
         'If percSconto <> -1 Then
         If IsNumeric((txtSconto.Text)) Then
            sconto = Convert.ToDouble(txtSconto.Text) '.Remove(txtSconto.Text.Length - 1, 1))

            If cmbApplicaSconto.SelectedIndex = 1 Then
               ' Sul totale del conto.
               valSconto = CalcolaPercentuale(totConto, sconto)
            Else
               ' Sul totale della camera.
               valSconto = CalcolaPercentuale(totCamera, sconto)
            End If
         Else
            valSconto = 0 'Convert.ToDouble(txtSconto.Text)
            txtSconto.Text = VALORE_ZERO
         End If

         ' Calcola il totale del conto.
         Dim valDaPagare As Double = (totConto + valServizio - valSconto)
         txtTotaleConto.Text = CFormatta.FormattaEuro(valDaPagare)

         ' Calcola il totale da incassare sottraendo eventuali acconti.
         Dim totIncassare As Double = (valDaPagare - accontoCamera)
         txtTotaleIncassare.Text = CFormatta.FormattaEuro(totIncassare)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub cmdInserisciOccupanti_Click(sender As System.Object, e As System.EventArgs) Handles cmdInserisciOccupanti.Click
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         Dim frm As New frmInsClienti
         'frm.Tag = ""
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub cmdEliminaOccupanti_Click(sender As System.Object, e As System.EventArgs) Handles cmdEliminaOccupanti.Click
      Try
         If lvwOccupanti.Items.Count <> 0 Then

            lvwOccupanti.Focus()

            ' L'elemento inserito viene rimosso dall'elenco.
            lvwOccupanti.Items(lvwOccupanti.FocusedItem.Index).Remove()

         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_cmdAccessori_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdAccessori.Click
      Try
         Dim frm As New ListaAccessoriServizi("Accessorio")
         frm.Tag = "PrenCamera"
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdServizi_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdServizi.Click
      Try
         Dim frm As New ListaAccessoriServizi("Servizio")
         frm.Tag = "PrenCamera"
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdEliminaRiga_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdEliminaRiga.Click
      EliminaRiga()
      CalcolaTotaleAddebiti()
   End Sub

   Private Sub EliminaRiga()
      Try
         ' Registra loperazione effettuata dall'operatore identificato.
         'lvwAddebiti.Focus()
         'Dim strDescrizione As String = "(" & lvwAddebiti.Items(lvwAddebiti.FocusedItem.Index).SubItems(1).Text & _
         '                               " " & lvwAddebiti.Items(lvwAddebiti.FocusedItem.Index).SubItems(2).Text & _
         '                               " € " & lvwAddebiti.Items(lvwAddebiti.FocusedItem.Index).SubItems(3).Text & ")"

         'g_frmMain.RegistraOperazione(TipoOperazione.Cancella, strDescrizione, MODULO_GESTIONE_POS)

         If lvwAddebiti.Items.Count <> 0 Then
            lvwAddebiti.Focus()
            lvwAddebiti.Items.RemoveAt(lvwAddebiti.FocusedItem.Index)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdQuantitàPiù_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdQuantitàPiù.Click
      AumentaDiminuisciQta(True)
      CalcolaTotaleAddebiti()
   End Sub

   Private Sub eui_QuantitàMeno_Click(sender As System.Object, e As System.EventArgs) Handles eui_QuantitàMeno.Click
      AumentaDiminuisciQta(False)
      CalcolaTotaleAddebiti()
   End Sub

   Private Function AumentaDiminuisciQta(ByVal val As Boolean) As Boolean
      ' Vero: aumenta di 1 - Falso: diminuisce di 1.
      Try
         If lvwAddebiti.Items.Count <> 0 Then
            lvwAddebiti.Focus()

            Dim quantità As Integer = Convert.ToInt32(lvwAddebiti.Items(lvwAddebiti.FocusedItem.Index).SubItems(2).Text)
            Dim totPrezzo As Decimal = Convert.ToDecimal(lvwAddebiti.Items(lvwAddebiti.FocusedItem.Index).SubItems(3).Text)
            Dim prezzo As Decimal

            ' Ottiene il prezzo di una singola unità.
            prezzo = totPrezzo / quantità

            If val = True Then
               quantità += 1
            Else
               If quantità = 1 Then
                  EliminaRiga()

                  Return False
               Else
                  quantità -= 1
               End If
            End If

            ' Calcola il prezzo totale in base alla quantità inserita.
            totPrezzo = prezzo * quantità
            lvwAddebiti.Items(lvwAddebiti.FocusedItem.Index).SubItems(3).Text = String.Format("{0:0.00}", totPrezzo)

            lvwAddebiti.Items(lvwAddebiti.FocusedItem.Index).SubItems(2).Text = quantità

            Return True
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

      End Try
   End Function

   Private Sub txtServizio_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtServizio.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtServizio_LostFocus(sender As Object, e As System.EventArgs) Handles txtServizio.LostFocus
      Try
         If IsNumeric(sender.Text) Then
            sender.Text = CFormatta.FormattaEuro(Convert.ToDecimal(sender.Text))
         Else
            sender.Text = VALORE_ZERO
         End If

         ' Esegue i calcoli per il totale degli importi.
         CalcolaTotaleConto()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtSconto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSconto.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtSconto_LostFocus(sender As Object, e As System.EventArgs) Handles txtSconto.LostFocus
      Try
         If IsNumeric(sender.Text) Then
            sender.Text = CFormatta.FormattaEuro(Convert.ToDecimal(sender.Text))
         Else
            sender.Text = VALORE_ZERO
         End If

         ' Esegue i calcoli per il totale degli importi.
         CalcolaTotaleConto()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub cmbApplicaSconto_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbApplicaSconto.SelectedIndexChanged
      Try
         ' Esegue i calcoli per il totale degli importi.
         CalcolaTotaleConto()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtPrezzoCamera_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPrezzoCamera.TextChanged

   End Sub

   Private Sub txtAccontoCamera_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtAccontoCamera.TextChanged

   End Sub

   Private Sub cmbListino_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbListino.SelectedIndexChanged
      ' Inserisce il prezzo della camera in base al Listino elezionato.
      If loadForm = True Then
         ApplicaListino()
      End If

   End Sub

   Private Sub cmbTrattamento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTrattamento.SelectedIndexChanged
      ' Inserisce il prezzo della camera in base al Listino elezionato.
      If loadForm = True Then
         ApplicaListino()
      End If

   End Sub

   Private Sub nudAdulti_ValueChanged(sender As Object, e As EventArgs) Handles nudAdulti.ValueChanged
      ' Inserisce il prezzo della camera in base al Listino elezionato.
      If loadForm = True Then
         ApplicaListino()
      End If

   End Sub

   Private Sub nudNeonati_ValueChanged(sender As Object, e As EventArgs) Handles nudNeonati.ValueChanged
      ' Inserisce il prezzo della camera in base al Listino elezionato.
      If loadForm = True Then
         ApplicaListino()
      End If

   End Sub

   Private Sub nudBambini_ValueChanged(sender As Object, e As EventArgs) Handles nudBambini.ValueChanged
      ' Inserisce il prezzo della camera in base al Listino elezionato.
      If loadForm = True Then
         ApplicaListino()
      End If

   End Sub

   Private Sub nudRagazzi_ValueChanged(sender As Object, e As EventArgs) Handles nudRagazzi.ValueChanged
      ' Inserisce il prezzo della camera in base al Listino elezionato.
      If loadForm = True Then
         ApplicaListino()
      End If

   End Sub

   Private Function LeggiBassaStagione1(ByVal dataPren As Date) As String
      Try
         ' Verifico la data per sapere il periodo di stagione.
         Dim AStagioni As New Stagioni

         With AStagioni

            ' Leggo i dati.
            .LeggiDati(TAB_STAGIONI)

            If IsDate(.DataInizio1_Bassa) = True And IsDate(.DataFine1_Bassa) = True Then
               Dim dataTemp As Date = Convert.ToDateTime(.DataInizio1_Bassa & Today.Year.ToString)
               Dim dataTempFine As Date = Convert.ToDateTime(.DataFine1_Bassa & Today.Year.ToString)

               If dataTemp <> dataTempFine Then
                  Do
                     If dataTemp = dataPren Then
                        Return BASSA_STAGIONE
                     Else
                        dataTemp = dataTemp.AddDays(1)
                     End If
                  Loop Until dataTemp = dataTempFine
               Else
                  If dataTemp = dataPren Then
                     Return BASSA_STAGIONE
                  End If
               End If
            End If

         End With

         Return String.Empty

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Function

   Private Function LeggiBassaStagione2(ByVal dataPren As Date) As String
      Try
         ' Verifico la data per sapere il periodo di stagione.
         Dim AStagioni As New Stagioni

         With AStagioni

            ' Leggo i dati.
            .LeggiDati(TAB_STAGIONI)

            If IsDate(.DataInizio2_Bassa) = True And IsDate(.DataFine2_Bassa) = True Then
               Dim dataTemp As Date = Convert.ToDateTime(.DataInizio2_Bassa & Today.Year.ToString)
               Dim dataTempFine As Date = Convert.ToDateTime(.DataFine2_Bassa & Today.Year.ToString)

               If dataTemp <> dataTempFine Then
                  Do
                     If dataTemp = dataPren Then
                        Return BASSA_STAGIONE
                     Else
                        dataTemp = dataTemp.AddDays(1)
                     End If
                  Loop Until dataTemp = dataTempFine
               Else
                  If dataTemp = dataPren Then
                     Return BASSA_STAGIONE
                  End If
               End If
            End If

         End With

         Return String.Empty

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Function

   Private Function LeggiBassaStagione3(ByVal dataPren As Date) As String
      Try
         ' Verifico la data per sapere il periodo di stagione.
         Dim AStagioni As New Stagioni

         With AStagioni

            ' Leggo i dati.
            .LeggiDati(TAB_STAGIONI)

            If IsDate(.DataInizio3_Bassa) = True And IsDate(.DataFine3_Bassa) = True Then
               Dim dataTemp As Date = Convert.ToDateTime(.DataInizio3_Bassa & Today.Year.ToString)
               Dim dataTempFine As Date = Convert.ToDateTime(.DataFine3_Bassa & Today.Year.ToString)

               If dataTemp <> dataTempFine Then
                  Do
                     If dataTemp = dataPren Then
                        Return BASSA_STAGIONE
                     Else
                        dataTemp = dataTemp.AddDays(1)
                     End If
                  Loop Until dataTemp = dataTempFine
               Else
                  If dataTemp = dataPren Then
                     Return BASSA_STAGIONE
                  End If
               End If
            End If

         End With

         Return String.Empty

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Function

   Private Function LeggiMediaStagione1(ByVal dataPren As Date) As String
      Try
         ' Verifico la data per sapere il periodo di stagione.
         Dim AStagioni As New Stagioni

         With AStagioni

            ' Leggo i dati.
            .LeggiDati(TAB_STAGIONI)

            If IsDate(.DataInizio1_Media) = True And IsDate(.DataFine1_Media) = True Then
               Dim dataTemp As Date = Convert.ToDateTime(.DataInizio1_Media & Today.Year.ToString)
               Dim dataTempFine As Date = Convert.ToDateTime(.DataFine1_Media & Today.Year.ToString)

               If dataTemp <> dataTempFine Then
                  Do
                     If dataTemp = dataPren Then
                        Return MEDIA_STAGIONE
                     Else
                        dataTemp = dataTemp.AddDays(1)
                     End If
                  Loop Until dataTemp = dataTempFine
               Else
                  If dataTemp = dataPren Then
                     Return MEDIA_STAGIONE
                  End If
               End If
            End If

         End With

         Return String.Empty

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Function

   Private Function LeggiMediaStagione2(ByVal dataPren As Date) As String
      Try
         ' Verifico la data per sapere il periodo di stagione.
         Dim AStagioni As New Stagioni

         With AStagioni

            ' Leggo i dati.
            .LeggiDati(TAB_STAGIONI)

            If IsDate(.DataInizio2_Media) = True And IsDate(.DataFine2_Media) = True Then
               Dim dataTemp As Date = Convert.ToDateTime(.DataInizio2_Media & Today.Year.ToString)
               Dim dataTempFine As Date = Convert.ToDateTime(.DataFine2_Media & Today.Year.ToString)

               If dataTemp <> dataTempFine Then
                  Do
                     If dataTemp = dataPren Then
                        Return MEDIA_STAGIONE
                     Else
                        dataTemp = dataTemp.AddDays(1)
                     End If
                  Loop Until dataTemp = dataTempFine
               Else
                  If dataTemp = dataPren Then
                     Return MEDIA_STAGIONE
                  End If
               End If
            End If

         End With

         Return String.Empty

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Function

   Private Function LeggiMediaStagione3(ByVal dataPren As Date) As String
      Try
         ' Verifico la data per sapere il periodo di stagione.
         Dim AStagioni As New Stagioni

         With AStagioni

            ' Leggo i dati.
            .LeggiDati(TAB_STAGIONI)

            If IsDate(.DataInizio3_Media) = True And IsDate(.DataFine3_Media) = True Then
               Dim dataTemp As Date = Convert.ToDateTime(.DataInizio3_Media & Today.Year.ToString)
               Dim dataTempFine As Date = Convert.ToDateTime(.DataFine3_Media & Today.Year.ToString)

               If dataTemp <> dataTempFine Then
                  Do
                     If dataTemp = dataPren Then
                        Return MEDIA_STAGIONE
                     Else
                        dataTemp = dataTemp.AddDays(1)
                     End If
                  Loop Until dataTemp = dataTempFine
               Else
                  If dataTemp = dataPren Then
                     Return MEDIA_STAGIONE
                  End If
               End If
            End If

         End With

         Return String.Empty

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Function

   Private Function LeggiAltaStagione1(ByVal dataPren As Date) As String
      Try
         ' Verifico la data per sapere il periodo di stagione.
         Dim AStagioni As New Stagioni

         With AStagioni

            ' Leggo i dati.
            .LeggiDati(TAB_STAGIONI)

            If IsDate(.DataInizio1_Alta) = True And IsDate(.DataFine1_Alta) = True Then
               Dim dataTemp As Date = Convert.ToDateTime(.DataInizio1_Alta & Today.Year.ToString)
               Dim dataTempFine As Date = Convert.ToDateTime(.DataFine1_Alta & Today.Year.ToString)

               If dataTemp <> dataTempFine Then
                  Do
                     If dataTemp = dataPren Then
                        Return ALTA_STAGIONE
                     Else
                        dataTemp = dataTemp.AddDays(1)
                     End If
                  Loop Until dataTemp = dataTempFine
               Else
                  If dataTemp = dataPren Then
                     Return ALTA_STAGIONE
                  End If
               End If
            End If

         End With

         Return String.Empty

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Function

   Private Function LeggiAltaStagione2(ByVal dataPren As Date) As String
      Try
         ' Verifico la data per sapere il periodo di stagione.
         Dim AStagioni As New Stagioni

         With AStagioni

            ' Leggo i dati.
            .LeggiDati(TAB_STAGIONI)

            If IsDate(.DataInizio2_Alta) = True And IsDate(.DataFine2_Alta) = True Then
               Dim dataTemp As Date = Convert.ToDateTime(.DataInizio2_Alta & Today.Year.ToString)
               Dim dataTempFine As Date = Convert.ToDateTime(.DataFine2_Alta & Today.Year.ToString)

               If dataTemp <> dataTempFine Then
                  Do
                     If dataTemp = dataPren Then
                        Return ALTA_STAGIONE
                     Else
                        dataTemp = dataTemp.AddDays(1)
                     End If
                  Loop Until dataTemp = dataTempFine
               Else
                  If dataTemp = dataPren Then
                     Return ALTA_STAGIONE
                  End If
               End If
            End If

         End With

         Return String.Empty

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Function

   Private Function LeggiAltaStagione3(ByVal dataPren As Date) As String
      Try
         ' Verifico la data per sapere il periodo di stagione.
         Dim AStagioni As New Stagioni

         With AStagioni

            ' Leggo i dati.
            .LeggiDati(TAB_STAGIONI)

            If IsDate(.DataInizio3_Alta) = True And IsDate(.DataFine3_Alta) = True Then
               Dim dataTemp As Date = Convert.ToDateTime(.DataInizio3_Alta & Today.Year.ToString)
               Dim dataTempFine As Date = Convert.ToDateTime(.DataFine3_Alta & Today.Year.ToString)

               If dataTemp <> dataTempFine Then
                  Do
                     If dataTemp = dataPren Then
                        Return ALTA_STAGIONE
                     Else
                        dataTemp = dataTemp.AddDays(1)
                     End If
                  Loop Until dataTemp = dataTempFine
               Else
                  If dataTemp = dataPren Then
                     Return ALTA_STAGIONE
                  End If
               End If
            End If

         End With

         Return String.Empty

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Function

   Private Function LeggiPrezzoListino(ByVal tipoStagione As String) As String
      Try
         Const PERNOTTAMENTO As String = "PN"
         Const BED_AND_BREAKFAST As String = "BB"
         Const MEZZA_PENSIONE As String = "MP"
         Const PENSIONE_COMPLETA As String = "PC"

         ' Leggo l'Id del listino selezionato.
         cmbIdListino.SelectedIndex = cmbListino.SelectedIndex

         ' Estraggo i dati del listino selezionato.
         Dim AListinoCamera As New ListinoCamera
         With AListinoCamera
            .LeggiDati(TAB_LISTINO, cmbIdListino.Text)

            ' Leggo il tipo di Listino - Prezzo a persona o Camera.
            tipoListino = .Tipologia

            ' Leggo il Trattamento selezionato.
            Dim trattamento As String = cmbTrattamento.Text.Substring(0, 2)

            ' Leggo il prezzo da applicare.
            Select Case tipoStagione
               Case BASSA_STAGIONE
                  scontoNeonato = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.ScontoNeonato_Bassa))
                  scontoBambino = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.ScontoBambino_Bassa))
                  scontoRagazzo = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.ScontoRagazzo_Bassa))

                  Select Case trattamento
                     Case PERNOTTAMENTO
                        Return .SoloPernottamento_Bassa
                     Case BED_AND_BREAKFAST
                        Return .BB_Bassa
                     Case MEZZA_PENSIONE
                        Return .MezzaPensione_Bassa
                     Case PENSIONE_COMPLETA
                        Return .PensioneCompleta_Bassa
                  End Select

               Case MEDIA_STAGIONE
                  scontoNeonato = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.ScontoNeonato_Media))
                  scontoBambino = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.ScontoBambino_Media))
                  scontoRagazzo = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.ScontoRagazzo_Media))

                  Select Case trattamento
                     Case PERNOTTAMENTO
                        Return .SoloPernottamento_Media
                     Case BED_AND_BREAKFAST
                        Return .BB_Media
                     Case MEZZA_PENSIONE
                        Return .MezzaPensione_Media
                     Case PENSIONE_COMPLETA
                        Return .PensioneCompleta_Media
                  End Select

               Case ALTA_STAGIONE
                  scontoNeonato = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.ScontoNeonato_Alta))
                  scontoBambino = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.ScontoBambino_Alta))
                  scontoRagazzo = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.ScontoRagazzo_Alta))

                  Select Case trattamento
                     Case PERNOTTAMENTO
                        Return .SoloPernottamento_Alta
                     Case BED_AND_BREAKFAST
                        Return .BB_Alta
                     Case MEZZA_PENSIONE
                        Return .MezzaPensione_Alta
                     Case PENSIONE_COMPLETA
                        Return .PensioneCompleta_Alta
                  End Select

               Case Else
                  Return VALORE_ZERO

            End Select

         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Function

   Private Sub ApplicaListino()
      Try
         Dim tipoStagione As String
         Dim prezzoCamera As String

         ' Leggo la data di inizio prenotazione.
         Dim dataPrenotazione As Date = mcDataArrivo.SelectionRange.Start.Date

         ' Bassa stagione - Intervallo 1.
         tipoStagione = LeggiBassaStagione1(dataPrenotazione)
         If tipoStagione <> String.Empty Then
            prezzoCamera = LeggiPrezzoListino(tipoStagione)
         End If

         ' Bassa stagione - Intervallo 2.
         tipoStagione = LeggiBassaStagione2(dataPrenotazione)
         If tipoStagione <> String.Empty Then
            prezzoCamera = LeggiPrezzoListino(tipoStagione)
         End If

         ' Bassa stagione - Intervallo 3.
         tipoStagione = LeggiBassaStagione3(dataPrenotazione)
         If tipoStagione <> String.Empty Then
            prezzoCamera = LeggiPrezzoListino(tipoStagione)
         End If

         ' Media stagione - Intervallo 1.
         tipoStagione = LeggiMediaStagione1(dataPrenotazione)
         If tipoStagione <> String.Empty Then
            prezzoCamera = LeggiPrezzoListino(tipoStagione)
         End If

         ' Media stagione - Intervallo 2.
         tipoStagione = LeggiMediaStagione2(dataPrenotazione)
         If tipoStagione <> String.Empty Then
            prezzoCamera = LeggiPrezzoListino(tipoStagione)
         End If

         ' Media stagione - Intervallo 3.
         tipoStagione = LeggiMediaStagione3(dataPrenotazione)
         If tipoStagione <> String.Empty Then
            prezzoCamera = LeggiPrezzoListino(tipoStagione)
         End If

         ' Alta stagione - Intervallo 1.
         tipoStagione = LeggiAltaStagione1(dataPrenotazione)
         If tipoStagione <> String.Empty Then
            prezzoCamera = LeggiPrezzoListino(tipoStagione)
         End If

         ' Alta stagione - Intervallo 2.
         tipoStagione = LeggiAltaStagione2(dataPrenotazione)
         If tipoStagione <> String.Empty Then
            prezzoCamera = LeggiPrezzoListino(tipoStagione)
         End If

         ' Alta stagione - Intervallo 3.
         tipoStagione = LeggiAltaStagione3(dataPrenotazione)
         If tipoStagione <> String.Empty Then
            prezzoCamera = LeggiPrezzoListino(tipoStagione)
         End If

         ' Assegna il prezzo alla camera.
         txtPrezzoCamera.Text = CFormatta.FormattaEuro(Convert.ToDecimal(prezzoCamera))

         ' Esegue i calcoli per il totale degli importi.
         CalcolaTotaleConto()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

End Class
