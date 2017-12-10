Public Class CAzienda
   Public RagSociale As String
   Public Indirizzo As String
   Public Cap As String
   Public Città As String
   Public Provincia As String
   Public Regione As String
   Public Nazione As String
   Public Telefono As String
   Public Fax As String
   Public Email As String
   Public Piva As String
   Public CodFisc As String

   Public Sub New()

   End Sub

   Public Sub Nuovo()

   End Sub
   Public Sub Modifica()

   End Sub
   Public Sub Elimina()

   End Sub

   Protected Overrides Sub Finalize()
      MyBase.Finalize()
   End Sub
End Class
