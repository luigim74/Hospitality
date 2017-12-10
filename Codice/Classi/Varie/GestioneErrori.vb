'classe gestione errori es: istanziare la classe e richiamare
'metodo>>> .MemoErrore(ex)
'Revisione 1.1 30_01_05

Public Class GestioneErrori
  Implements IDisposable

  Public Sub MemoErrore(ByRef ex As System.Exception)

    If Not (ex Is Nothing) Then
      Trace.WriteLine("--------------errori-----------")
      Trace.Write(Now.ToString)
      Trace.Write(".")
      Trace.Write(Now.Millisecond)
      Trace.Write("       :   ")
      Trace.WriteLine(ex.Message)
      Trace.Write("Informazione Specifica Errore :")
      Trace.WriteLine(ex.StackTrace)
      LeggiStack()
    End If

  End Sub

  Public Sub MemoErrore(ByRef ex As System.ApplicationException)

    If Not (ex Is Nothing) Then
      Trace.WriteLine("--------------errori-----------")
      Trace.Write(Now.ToString)
      Trace.Write(".")
      Trace.Write(Now.Millisecond)
      Trace.Write("       :   ")
      Trace.WriteLine(ex.Message)
      Trace.Write("Informazione Specifica Errore :")
      Trace.WriteLine(ex.StackTrace)
      LeggiStack()
    End If

  End Sub

  Private Sub LeggiStack()
    Dim FlashStack As New StackTrace
    Dim I As Int32

    Trace.WriteLine("Immagine dello Stack :")
    I = 2
    Do While (I <= 5) And (I <= (FlashStack.FrameCount - 1))
      Trace.Write(I)
      Trace.Write(") ")
      Trace.Write(FlashStack.GetFrame(I).GetMethod.DeclaringType.Namespace)
      Trace.Write(".")
      Trace.Write(FlashStack.GetFrame(I).GetMethod.DeclaringType.Name)
      Trace.Write(".")
      Trace.WriteLine(FlashStack.GetFrame(I).GetMethod.Name.ToString)
      I += 1
    Loop
  End Sub

  Public Sub Debug(ByVal Info As String)
    Trace.WriteLine("-----------debug---------------")
    Trace.Write(Now.ToLongDateString)
    Trace.WriteLine("                               ")
    Trace.Write(Now.ToLongTimeString)
    Trace.WriteLine("                               ")
    Trace.WriteLine(Info)
    Trace.WriteLine("                               ")
  End Sub

  Public Sub Dispose() Implements System.IDisposable.Dispose
    'Routine per il Rilascio delle Risorse
  End Sub

End Class
