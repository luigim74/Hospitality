Imports System.Data.OleDb
Imports AnagTab.Anagrafiche
Imports MSolution.Varie

Public Class Prenotazione

   Public Codice As String
   Public Numero As String
   Public IdCliente As Integer
   Public TipoPren As String
   Public Intestatario As String
   Public Arrivo As String
   Public Partenza As String
   Public Stato As String
   Public Trattamento As String
   Public Listino As String
   Public OraArrivo As String
   Public Agenzia As String
   Public Pagamento As String
   Public Voucher As String
   Public ScadOpzione As String
   Public Importo As String
   Public Colore As Integer
   Public Note As String

   ' Dichiara un oggetto connessione.
   Private cn As New OleDbConnection(ConnString)
   Private tr As OleDbTransaction
   ' Gestione degli errori.
   Private err As New Errore

   Public Sub LeggiDati(ByVal tabella As String, ByVal codice As String)
      ' Dichiara un oggetto DataAdapter.
      Dim da As OleDbDataAdapter
      ' Dichiara un oggetto DataSet
      Dim ds As DataSet
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Crea la stringa.
         sql = String.Format("SELECT * FROM {0} WHERE Id = {1}", tabella, codice)

         ' Dichiara un oggetto DataAdapter.
         da = New OleDbDataAdapter(sql, cn)

         ' Dichiara un oggetto DataSet
         ds = New DataSet

         ' Riempe il DataSet con i dati della tabella.
         da.Fill(ds, tabella)

         ' Assegna i valori dei campi del DataSet ai campi della classe.
         If IsDBNull(ds.Tables(tabella).Rows(0)("Id")) = False Then
            Me.Codice = ds.Tables(tabella).Rows(0)("Id")
         Else
            Me.Codice = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("IdCliente")) = False Then
            Me.IdCliente = ds.Tables(tabella).Rows(0)("IdCliente")
         Else
            Me.IdCliente = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Numero")) = False Then
            Me.Numero = ds.Tables(tabella).Rows(0)("Numero")
         Else
            Me.Numero = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("TipoPren")) = False Then
            Me.TipoPren = ds.Tables(tabella).Rows(0)("TipoPren")
         Else
            Me.TipoPren = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Intestatario")) = False Then
            Me.Intestatario = ds.Tables(tabella).Rows(0)("Intestatario")
         Else
            Me.Intestatario = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Arrivo")) = False Then
            Me.Arrivo = ds.Tables(tabella).Rows(0)("Arrivo")
         Else
            Me.Arrivo = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Partenza")) = False Then
            Me.Partenza = ds.Tables(tabella).Rows(0)("Partenza")
         Else
            Me.Partenza = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Stato")) = False Then
            Me.Stato = ds.Tables(tabella).Rows(0)("Stato")
         Else
            Me.Stato = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Trattamento")) = False Then
            Me.Trattamento = ds.Tables(tabella).Rows(0)("Trattamento")
         Else
            Me.Trattamento = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Listino")) = False Then
            Me.Listino = ds.Tables(tabella).Rows(0)("Listino")
         Else
            Me.Listino = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("OraArrivo")) = False Then
            Me.OraArrivo = ds.Tables(tabella).Rows(0)("OraArrivo")
         Else
            Me.OraArrivo = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Agenzia")) = False Then
            Me.Agenzia = ds.Tables(tabella).Rows(0)("Agenzia")
         Else
            Me.Agenzia = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Pagamento")) = False Then
            Me.Pagamento = ds.Tables(tabella).Rows(0)("Pagamento")
         Else
            Me.Pagamento = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Voucher")) = False Then
            Me.Voucher = ds.Tables(tabella).Rows(0)("Voucher")
         Else
            Me.Voucher = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ScadOpzione")) = False Then
            Me.ScadOpzione = ds.Tables(tabella).Rows(0)("ScadOpzione")
         Else
            Me.ScadOpzione = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Importo")) = False Then
            Me.Importo = ds.Tables(tabella).Rows(0)("Importo")
         Else
            Me.Importo = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Colore")) = False Then
            Me.Colore = ds.Tables(tabella).Rows(0)("Colore")
         Else
            Me.Colore = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Note")) = False Then
            Me.Note = ds.Tables(tabella).Rows(0)("Note")
         Else
            Me.Note = ""
         End If
      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         da.Dispose()
         ds.Dispose()
         ' Chiude la connessione.
         cn.Close()
      End Try
   End Sub

   Public Function InserisciDati(ByVal tabella As String) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
         ' Crea la stringa di eliminazione.
         sql = String.Format("INSERT INTO {0} (IdCliente, Numero, TipoPren, Intestatario, Arrivo, Partenza, " & _
                                              "Stato, Trattamento, Listino, OraArrivo, Agenzia, Pagamento, " & _
                                              "Voucher, ScadOpzione, Importo, Colore, [Note]) " & _
                                       "VALUES({1}, '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', " & _
                                              "'{10}', '{11}', '{12}', '{13}', '{14}', '{15}', {16}, '{17}')", _
                                                tabella, _
                                                Me.IdCliente, _
                                                Me.Numero, _
                                                Me.TipoPren, _
                                                Me.Intestatario, _
                                                Me.Arrivo, _
                                                Me.Partenza, _
                                                Me.Stato, _
                                                Me.Trattamento, _
                                                Me.Listino, _
                                                Me.OraArrivo, _
                                                Me.Agenzia, _
                                                Me.Pagamento, _
                                                Me.Voucher, _
                                                Me.ScadOpzione, _
                                                Me.Importo, _
                                                Me.Colore, _
                                                Me.Note)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)
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

   Public Function ModificaDati(ByVal tabella As String, ByVal codice As String) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} " & _
                             "SET IdCliente = {1}, " & _
                             "Numero = '{2}', " & _
                             "TipoPren = '{3}', " & _
                             "Intestatario = '{4}', " & _
                             "Arrivo = '{5}', " & _
                             "Partenza = '{6}', " & _
                             "Stato = '{7}', " & _
                             "Trattamento = '{8}', " & _
                             "Listino = '{9}', " & _
                             "OraArrivo = '{10}', " & _
                             "Agenzia = '{11}', " & _
                             "Pagamento = '{12}', " & _
                             "Voucher = '{13}', " & _
                             "ScadOpzione = '{14}', " & _
                             "Importo = '{15}', " & _
                             "Colore = {16}, " & _
                             "[Note] = '{17}' " & _
                             "WHERE Id = {18}", _
                              tabella, _
                              Me.IdCliente, _
                              Me.Numero, _
                              Me.TipoPren, _
                              Me.Intestatario, _
                              Me.Arrivo, _
                              Me.Partenza, _
                              Me.Stato, _
                              Me.Trattamento, _
                              Me.Listino, _
                              Me.OraArrivo, _
                              Me.Agenzia, _
                              Me.Pagamento, _
                              Me.Voucher, _
                              Me.ScadOpzione, _
                              Me.Importo, _
                              Me.Colore, _
                              Me.Note, _
                              codice)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)
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

End Class
