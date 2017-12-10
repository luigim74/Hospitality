Public Class Form1
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
   Friend WithEvents ToolBar1 As System.Windows.Forms.ToolBar
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Friend WithEvents ToolBarButton1 As System.Windows.Forms.ToolBarButton
   Friend WithEvents ToolBarButton2 As System.Windows.Forms.ToolBarButton
   Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
      Me.ToolBar1 = New System.Windows.Forms.ToolBar
      Me.ToolBarButton1 = New System.Windows.Forms.ToolBarButton
      Me.ToolBarButton2 = New System.Windows.Forms.ToolBarButton
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
      Me.SuspendLayout()
      '
      'ToolBar1
      '
      Me.ToolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
      Me.ToolBar1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.ToolBarButton1, Me.ToolBarButton2})
      Me.ToolBar1.ButtonSize = New System.Drawing.Size(22, 22)
      Me.ToolBar1.DropDownArrows = True
      Me.ToolBar1.ImageList = Me.ImageList1
      Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
      Me.ToolBar1.Name = "ToolBar1"
      Me.ToolBar1.ShowToolTips = True
      Me.ToolBar1.Size = New System.Drawing.Size(504, 48)
      Me.ToolBar1.TabIndex = 0
      '
      'ToolBarButton1
      '
      Me.ToolBarButton1.ImageIndex = 0
      Me.ToolBarButton1.Text = "ddd"
      '
      'ToolBarButton2
      '
      Me.ToolBarButton2.ImageIndex = 3
      '
      'ImageList1
      '
      Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
      Me.ImageList1.ImageSize = New System.Drawing.Size(22, 22)
      Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
      '
      'CrystalReportViewer1
      '
      Me.CrystalReportViewer1.ActiveViewIndex = -1
      Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 48)
      Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
      Me.CrystalReportViewer1.ReportSource = "C:\Progetti Visual Studio\WindowsApplication1\CrystalReport1.rpt"
      Me.CrystalReportViewer1.Size = New System.Drawing.Size(504, 238)
      Me.CrystalReportViewer1.TabIndex = 1
      '
      'Form1
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(504, 286)
      Me.Controls.Add(Me.CrystalReportViewer1)
      Me.Controls.Add(Me.ToolBar1)
      Me.Name = "Form1"
      Me.Text = "Form1"
      Me.ResumeLayout(False)

   End Sub

#End Region

End Class
