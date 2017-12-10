Imports System.Data.OleDb

Public Class PrenCamereOccupanti

   Public RifPren As Integer
   Public CodiceCliente As String = String.Empty
   Public Cognome As String = String.Empty
   Public Nome As String = String.Empty
   Public DataNascita As String = String.Empty
   Public LuogoNascita As String = String.Empty
   Public ProvNascita As String = String.Empty
   Public Nazionalità As String = String.Empty

   ' Dichiara un oggetto connessione.
   Private cn As New OleDbConnection(ConnString)
   Private tr As OleDbTransaction
   ' Gestione degli errori.
   Private err As New Varie.Errore
   Private CFormatta As New ClsFormatta

   Public Function LeggiDati(ByVal tabella As String, ByVal codPren As Integer) As Boolean
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE RifPren = " & codPren, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()
            ' IdRisorsa
            If IsDBNull(dr.Item("RifPren")) = False Then
               Me.RifPren = Convert.ToInt32(dr.Item("RifPren"))
            Else
               Me.RifPren = codPren
            End If
            ' Codice Cliente
            If IsDBNull(dr.Item("CodiceCliente")) = False Then
               Me.CodiceCliente = dr.Item("CodiceCliente")
            Else
               Me.CodiceCliente = String.Empty
            End If
            ' Cognome.
            If IsDBNull(dr.Item("Cognome")) = False Then
               Me.Cognome = dr.Item("Cognome").ToString
            Else
               Me.Cognome = String.Empty
            End If
            ' Nome.
            If IsDBNull(dr.Item("Nome")) = False Then
               Me.Nome = dr.Item("Nome").ToString
            Else
               Me.Nome = String.Empty
            End If
            ' Data di nascita.
            If IsDBNull(dr.Item("DataNascita")) = False Then
               Me.DataNascita = dr.Item("DataNascita").ToString
            Else
               Me.DataNascita = String.Empty
            End If
            ' LuogoNascita.
            If IsDBNull(dr.Item("LuogoNascita")) = False Then
               Me.LuogoNascita = dr.Item("LuogoNascita").ToString
            Else
               Me.LuogoNascita = String.Empty
            End If
            ' ProvNascita.
            If IsDBNull(dr.Item("ProvNascita")) = False Then
               Me.ProvNascita = dr.Item("ProvNascita").ToString
            Else
               Me.ProvNascita = String.Empty
            End If
            ' Nazionalità.
            If IsDBNull(dr.Item("Nazionalità")) = False Then
               Me.Nazionalità = dr.Item("Nazionalità").ToString
            Else
               Me.Nazionalità = String.Empty
            End If
         Loop

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      Finally
         cn.Close()

      End Try
   End Function

   Public Function LeggiDati(ByVal lst As ListView, ByVal tabella As String, ByVal codPren As Integer) As Boolean
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim Caricati As Boolean = False

      Try
         cn.Open()

         Dim i As Integer = 0

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE RifPren = " & codPren, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         lst.Items.Clear()

         Do While dr.Read()
            ' Indice.
            lst.Items.Add(i)

            ' Cognome.
            If IsDBNull(dr.Item("Cognome")) = False Then
               lst.Items(i).SubItems.Add(dr.Item("Cognome").ToString)
            Else
               lst.Items(i).SubItems.Add("")
            End If
            ' Nome.
            If IsDBNull(dr.Item("Nome")) = False Then
               lst.Items(i).SubItems.Add(dr.Item("Nome").ToString)
            Else
               lst.Items(i).SubItems.Add("")
            End If
            ' DataNascita.
            If IsDBNull(dr.Item("DataNascita")) = False Then
               lst.Items(i).SubItems.Add(dr.Item("DataNascita").ToString)
            Else
               lst.Items(i).SubItems.Add("")
            End If
            ' LuogoNascita.
            If IsDBNull(dr.Item("LuogoNascita")) = False Then
               lst.Items(i).SubItems.Add(dr.Item("LuogoNascita").ToString)
            Else
               lst.Items(i).SubItems.Add("")
            End If
            ' ProvNascita.
            If IsDBNull(dr.Item("ProvNascita")) = False Then
               lst.Items(i).SubItems.Add(dr.Item("ProvNascita").ToString)
            Else
               lst.Items(i).SubItems.Add("")
            End If
            ' Nazionalità.
            If IsDBNull(dr.Item("Nazionalità")) = False Then
               lst.Items(i).SubItems.Add(dr.Item("Nazionalità").ToString)
            Else
               lst.Items(i).SubItems.Add("")
            End If
            ' Codice Cliente.
            If IsDBNull(dr.Item("CodiceCliente")) = False Then
               lst.Items(i).SubItems.Add(dr.Item("CodiceCliente").ToString)
            Else
               lst.Items(i).SubItems.Add("")
            End If

            'lst.Items(i).BackColor = Color.MediumSeaGreen
            'lst.Items(i).ForeColor = Color.FromArgb(Convert.ToInt32(dr.Item("Colore")))
            'lst.Items(i).Font = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Italic)

            ' Stabilisce il gruppo di appartenenza.
            'Dim valGruppo As Short
            'Select Case dr.Item("Gruppo").ToString
            '   Case "Accessori"
            '      valGruppo = 1
            '   Case "Servizi"
            '      valGruppo = 2
            '   Case Else ' Articoli vari
            '      valGruppo = 0
            'End Select

            'lst.Items(i).Group = lst.Groups.Item(valGruppo)

            i = i + 1

            Caricati = True
         Loop

         Return Caricati

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

      Finally
         cn.Close()

      End Try
   End Function

   Public Function InserisciDati(ByVal tabella As String) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
         ' Crea la stringa di eliminazione.
         sql = String.Format("INSERT INTO {0} (RifPren, CodiceCliente, Cognome, Nome, DataNascita, LuogoNascita, ProvNascita, Nazionalità) " & _
                                       "VALUES(@RifPren, @CodiceCliente, @Cognome, @Nome, @DataNascita, @LuogoNascita, @ProvNascita, @Nazionalità)", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)

         cmdInsert.Parameters.AddWithValue("@RifPren", Me.RifPren)
         cmdInsert.Parameters.AddWithValue("@CodiceCliente", Me.CodiceCliente)
         cmdInsert.Parameters.AddWithValue("@Cognome", Me.Cognome)
         cmdInsert.Parameters.AddWithValue("@Nome", Me.Nome)
         cmdInsert.Parameters.AddWithValue("@DataNascita", Me.DataNascita)
         cmdInsert.Parameters.AddWithValue("@LuogoNascita", Me.LuogoNascita)
         cmdInsert.Parameters.AddWithValue("@ProvNascita", Me.ProvNascita)
         cmdInsert.Parameters.AddWithValue("@Nazionalità", Me.Nazionalità)

         ' Esegue il comando.
         Dim Record As Integer = cmdInsert.ExecuteNonQuery()

         ' Conferma transazione.
         tr.Commit()

         Return True

      Catch ex As Exception
         ' Annulla transazione.
         tr.Rollback()

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Function

   Public Function ModificaDati(ByVal tabella As String, ByVal codPren As Integer) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} " & _
                             "SET RifPren = @RifPren, " & _
                             "CodiceCliente = @CodiceCliente, " & _
                             "Cognome = @Cognome, " & _
                             "Nome = @Nome, " & _
                             "DataNascita = @DataNascita, " & _
                             "LuogoNascita = @LuogoNascita, " & _
                             "ProvNascita = @ProvNascita, " & _
                             "Nazionalità = @Nazionalità " & _
                             "WHERE RifPren = {1}", _
                             tabella, _
                             codPren)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.AddWithValue("@RifPren", Me.RifPren)
         cmdUpdate.Parameters.AddWithValue("@CodiceCliente", Me.CodiceCliente)
         cmdUpdate.Parameters.AddWithValue("@Cognome", Me.Cognome)
         cmdUpdate.Parameters.AddWithValue("@Nome", Me.Nome)
         cmdUpdate.Parameters.AddWithValue("@DataNascita", Me.DataNascita)
         cmdUpdate.Parameters.AddWithValue("@LuogoNascita", Me.LuogoNascita)
         cmdUpdate.Parameters.AddWithValue("@ProvNascita", Me.ProvNascita)
         cmdUpdate.Parameters.AddWithValue("@Nazionalità", Me.Nazionalità)

         ' Esegue il comando.
         Dim Record As Integer = cmdUpdate.ExecuteNonQuery()

         ' Conferma transazione.
         tr.Commit()

         Return True

      Catch ex As Exception
         ' Annulla transazione.
         tr.Rollback()

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

      Finally
         ' Chiude la connessione.
         cn.Close()
      End Try
   End Function

   Public Function EliminaDati(ByVal tabella As String, ByVal Id As Integer) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("DELETE FROM {0} WHERE RifPren = {1}", tabella, Id)

         ' Crea il comando per la connessione corrente.
         Dim cmdDelete As New OleDbCommand(sql, cn, tr)

         ' Esegue il comando.
         Dim Record As Integer = cmdDelete.ExecuteNonQuery()

         ' Conferma transazione.
         tr.Commit()

         Return True

      Catch ex As Exception
         ' Annulla transazione.
         tr.Rollback()

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

      Finally
         ' Chiude la connessione.
         cn.Close()
      End Try
   End Function

End Class
