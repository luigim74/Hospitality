'Imports IWshRuntimeLibrary

Public Class Shortcut

   'Public Sub New(ByVal shortcutFullName As String)
   '   Me.ShortcutFullName = shortcutFullName
   'End Sub

   'Private _ShortcutFullName As String

   'Public Property ShortcutFullName As String
   '   Get
   '      Return (_ShortcutFullName)
   '   End Get
   '   Set(ByVal value As String)
   '      If String.IsNullOrWhiteSpace(value) Then Throw New ArgumentNullException("ShortcutFullName", "ShortcutFullName non può essere vuoto!")
   '      _ShortcutFullName = value
   '   End Set
   'End Property

   'Public Property TargetPath As String
   'Public Property WindowStyle As ShortcutWindowsStyle = ShortcutWindowsStyle.NormalFocus
   'Public Property IconPath As String
   'Public Property IconIndex As Int16 = 0
   'Public Property Description As String
   'Public Property WorkingDirectory As String
   'Public Property Arguments As String

   'Public Function Save() As Boolean
   '   Dim retval As Boolean = False
   '   Dim shortCut As IWshShortcut = Nothing
   '   Dim shell As WshShell = Nothing
   '   Try
   '      shell = New WshShell()
   '   Catch ex As Exception
   '      Throw
   '   End Try
   '   If shell IsNot Nothing Then
   '      Try
   '         shortCut = CType(shell.CreateShortcut(Me.ShortcutFullName), IWshShortcut)
   '      Catch ex As Exception
   '         Throw
   '      End Try
   '      If shortCut IsNot Nothing Then
   '         shortCut.TargetPath = Me.TargetPath
   '         shortCut.WindowStyle = CInt(Me.WindowStyle)
   '         shortCut.Description = Me.Description
   '         shortCut.WorkingDirectory = Me.WorkingDirectory
   '         shortCut.IconLocation = String.Format("{0}, {1}", Me.IconPath, Me.IconIndex)
   '         shortCut.Arguments = Me.Arguments
   '         If Not String.IsNullOrWhiteSpace(Me.Hotkey) Then
   '            shortCut.Hotkey = Me.Hotkey
   '         End If

   '         Try
   '            shortCut.Save()
   '            retval = System.IO.File.Exists(Me.ShortcutFullName)
   '         Catch ex As Exception
   '            Throw()
   '         End Try
   '      End If
   '   End If
   '   Return (retVal)
   'End Function
End Class




