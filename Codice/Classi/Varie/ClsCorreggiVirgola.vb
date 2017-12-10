Public Class ClsCorreggiVirgola
   Private err As New Varie.Errore

   'questa routine permette di controllare l'inserimento dei punti, nelle txt
   'viene posto la virgola all'evento key up della text
   Public Sub correggi_virgola(ByVal KeyCode As Object, ByVal SCA As TextBox)
      Dim punto, virgola As String

      Try
         'If KeyCode =  Then Exit Sub
         If KeyCode = 110 Then
            If Len(Trim(SCA.Text)) > 1 Then
               If Mid(SCA.Text, Len(SCA.Text) - 1, 1) = "," Then
                  SCA.Text = Left(SCA.Text, Len(SCA.Text) - 1)
                  SCA.SelectionStart = Len(SCA.Text)
               Else
                  If Left(SCA.Text, 1) = "." Then
                     SCA.Text = "0" & "," & Right(SCA.Text, Len(Trim(SCA.Text & "")) - 1)
                     SCA.SelectionStart = 2 ' Len(SCA)
                  Else
                     'If Val(SCA.Text) <> SCA.Text Then
                     '  punto = "."
                     '  virgola = ","
                     '  Dim posizione As String = InStr(1, SCA.Text, punto, vbTextCompare)
                     '  Dim posizionev As String = InStr(1, SCA.Text, virgola, vbTextCompare)
                     '  If posizionev <> 0 Then
                     '    If Len(SCA) = posizione Then
                     '      SCA.Text = Left(SCA.Text, posizione - 1)
                     '      SCA.SelectionStart = Len(SCA)
                     '    Else
                     '      SCA.Text = Left(SCA.Text, posizione - 1) & Right(SCA.Text, Len(SCA.Text) - posizione)
                     '      SCA.SelectionStart = Len(SCA)
                     '    End If
                     '  Else
                     '    SCA.Text = Left(SCA.Text, posizione - 1) & "," & Right(SCA.Text, Len(SCA) - posizione)
                     '    SCA.SelectionStart = Len(SCA.Text)
                     '  End If
                     'Else
                     SCA.Text = Left(SCA.Text, Len(SCA.Text) - 1) & ","
                     SCA.SelectionStart = Len(SCA.Text)
                     'End If
                  End If
               End If
               ' virgola = ","
               ' If Len(Trim(SCA & "")) - InStr(1, SCA, virgola, vbTextCompare) > 2 Then
               '     SCA = Round(SCA, Decimale)
               ' End If
            Else
               SCA.Text = "0" & ","
               SCA.SelectionStart = Len(SCA.Text)
            End If
         Else
            If KeyCode <> 13 Then
               If Len(Trim(SCA.Text & "")) > 0 Then
                  virgola = ","
                  If InStr(1, SCA.Text, virgola, vbTextCompare) > 0 Then
                     If Len(Trim(SCA.Text & "")) - InStr(1, SCA.Text, virgola, vbTextCompare) > 6 Then
                        'SCA.Text = Round(SCA.Text, 6)
                        SCA.SelectionStart = Len(SCA)
                     End If
                  End If
                  If Not (KeyCode > 34 And KeyCode < 41) And KeyCode <> 13 Then
                     'If Not ((KeyCode > 95 And KeyCode < 106) Or (KeyCode > 47 And KeyCode < 58)) And KeyCode <> 8 And KeyCode <> 123 And KeyCode <> 46 Then
                     '  SCA.Text = Left(SCA.Text, Len(SCA.Text) - 1)
                     '  SCA.SelectionStart = Len(SCA.Text)
                     'End If
                  End If
               End If
            End If
         End If
      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         Err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

End Class
