Imports System.Data.OleDb
Imports AnagTab.Anagrafiche
Imports MSolution.Varie

Public Class Ditta
   Inherits Cliente

   ' Campi.
   Public RagSoc As String

   Private err As New Errore

   ' B_TODO: RENDERE LA STRINGA PARAMETRICA.
   ' Stringa di connessione.
   Private ConnString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data source=C:\Hs.mdb"

   ' Dichiara un oggetto connessione.
   Private cn As New OleDbConnection(ConnString)
   Private tr As OleDbTransaction

   Public Overrides Sub LeggiDati(ByVal tabella As String, ByVal codice As String)
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
         If IsDBNull(ds.Tables(tabella).Rows(0)("RagSoc")) = False Then
            Me.RagSoc = ds.Tables(tabella).Rows(0)("RagSoc")
         Else
            Me.RagSoc = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Titolo")) = False Then
            Me.Titolo = ds.Tables(tabella).Rows(0)("Titolo")
         Else
            Me.Titolo = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("CodFisc")) = False Then
            Me.CodFisc = ds.Tables(tabella).Rows(0)("CodFisc")
         Else
            Me.CodFisc = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("PIva")) = False Then
            Me.PIva = ds.Tables(tabella).Rows(0)("PIva")
         Else
            Me.PIva = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Indirizzo1")) = False Then
            Me.Indirizzo1 = ds.Tables(tabella).Rows(0)("Indirizzo1")
         Else
            Me.Indirizzo1 = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Indirizzo2")) = False Then
            Me.Indirizzo2 = ds.Tables(tabella).Rows(0)("Indirizzo2")
         Else
            Me.Indirizzo2 = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Cap")) = False Then
            Me.Cap = ds.Tables(tabella).Rows(0)("Cap")
         Else
            Me.Cap = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Città")) = False Then
            Me.Città = ds.Tables(tabella).Rows(0)("Città")
         Else
            Me.Città = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Provincia")) = False Then
            Me.Provincia = ds.Tables(tabella).Rows(0)("Provincia")
         Else
            Me.Provincia = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Regione")) = False Then
            Me.Regione = ds.Tables(tabella).Rows(0)("Regione")
         Else
            Me.Regione = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Nazione")) = False Then
            Me.Nazione = ds.Tables(tabella).Rows(0)("Nazione")
         Else
            Me.Nazione = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("TipoCliente")) = False Then
            Me.TipoCliente = ds.Tables(tabella).Rows(0)("TipoCliente")
         Else
            Me.TipoCliente = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("TelCasa")) = False Then
            Me.TelCasa = ds.Tables(tabella).Rows(0)("TelCasa")
         Else
            Me.TelCasa = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("TelUfficio")) = False Then
            Me.TelUfficio = ds.Tables(tabella).Rows(0)("TelUfficio")
         Else
            Me.TelUfficio = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Cell")) = False Then
            Me.Cell = ds.Tables(tabella).Rows(0)("Cell")
         Else
            Me.Cell = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Fax")) = False Then
            Me.Fax = ds.Tables(tabella).Rows(0)("Fax")
         Else
            Me.Fax = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Email")) = False Then
            Me.Email = ds.Tables(tabella).Rows(0)("Email")
         Else
            Me.Email = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Internet")) = False Then
            Me.Internet = ds.Tables(tabella).Rows(0)("Internet")
         Else
            Me.Internet = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("CamereNum1")) = False Then
            Me.CamereNum1 = ds.Tables(tabella).Rows(0)("CamereNum1")
         Else
            Me.CamereNum1 = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("CamereNum2")) = False Then
            Me.CamereNum2 = ds.Tables(tabella).Rows(0)("CamereNum2")
         Else
            Me.CamereNum2 = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("CamereNum3")) = False Then
            Me.CamereNum3 = ds.Tables(tabella).Rows(0)("CamereNum3")
         Else
            Me.CamereNum3 = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("CamereNum4")) = False Then
            Me.CamereNum4 = ds.Tables(tabella).Rows(0)("CamereNum4")
         Else
            Me.CamereNum4 = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("CamereNum5")) = False Then
            Me.CamereNum5 = ds.Tables(tabella).Rows(0)("CamereNum5")
         Else
            Me.CamereNum5 = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("CamereData1")) = False Then
            Me.CamereData1 = ds.Tables(tabella).Rows(0)("CamereData1")
         Else
            Me.CamereData1 = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("CamereData2")) = False Then
            Me.CamereData2 = ds.Tables(tabella).Rows(0)("CamereData2")
         Else
            Me.CamereData2 = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("CamereData3")) = False Then
            Me.CamereData3 = ds.Tables(tabella).Rows(0)("CamereData3")
         Else
            Me.CamereData3 = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("CamereData4")) = False Then
            Me.CamereData4 = ds.Tables(tabella).Rows(0)("CamereData4")
         Else
            Me.CamereData4 = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("CamereData5")) = False Then
            Me.CamereData5 = ds.Tables(tabella).Rows(0)("CamereData5")
         Else
            Me.CamereData5 = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("CamereNotti1")) = False Then
            Me.CamereNotti1 = ds.Tables(tabella).Rows(0)("CamereNotti1")
         Else
            Me.CamereNotti1 = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("CamereNotti2")) = False Then
            Me.CamereNotti2 = ds.Tables(tabella).Rows(0)("CamereNotti2")
         Else
            Me.CamereNotti2 = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("CamereNotti3")) = False Then
            Me.CamereNotti3 = ds.Tables(tabella).Rows(0)("CamereNotti3")
         Else
            Me.CamereNotti3 = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("CamereNotti4")) = False Then
            Me.CamereNotti4 = ds.Tables(tabella).Rows(0)("CamereNotti4")
         Else
            Me.CamereNotti4 = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("CamereNotti5")) = False Then
            Me.CamereNotti5 = ds.Tables(tabella).Rows(0)("CamereNotti5")
         Else
            Me.CamereNotti5 = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Strutture")) = False Then
            Me.Strutture = ds.Tables(tabella).Rows(0)("Strutture")
         Else
            Me.Strutture = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Immagine")) = False Then
            Me.Immagine = ds.Tables(tabella).Rows(0)("Immagine")
         Else
            Me.Immagine = Nothing
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

   Public Overrides Function InserisciDati(ByVal tabella As String) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
         ' Crea la stringa di eliminazione.
         sql = String.Format("INSERT INTO {0} (RagSoc, CamereData1, CamereData2, CamereData3, CamereData4, " & _
                                              "CamereData5, CamereNotti1, CamereNotti2, CamereNotti3, CamereNotti4, " & _
                                              "CamereNotti5, CamereNum1, CamereNum2, CamereNum3, CamereNum4, CamereNum5, " & _
                                              "Cap, Cell, Città, CodFisc, Email, Fax, Indirizzo1, Nazione, Piva, Provincia, " & _
                                              "Regione, Strutture, TelCasa, TelUfficio, TipoCliente, Titolo, [Note], " & _
                                              "Immagine, Internet, Indirizzo2) " & _
                                       "VALUES('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', " & _
                                              "'{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', " & _
                                              "'{21}', '{22}', '{23}', '{24}', '{25}', '{26}', '{27}', '{28}', '{29}', '{30}', " & _
                                              "'{31}', '{32}', '{33}', '{34}', '{35}', '{36}')", tabella, _
                                              Me.RagSoc, _
                                              Me.CamereData1, _
                                              Me.CamereData2, _
                                              Me.CamereData3, _
                                              Me.CamereData4, _
                                              Me.CamereData5, _
                                              Me.CamereNotti1, _
                                              Me.CamereNotti2, _
                                              Me.CamereNotti3, _
                                              Me.CamereNotti4, _
                                              Me.CamereNotti5, _
                                              Me.CamereNum1, _
                                              Me.CamereNum2, _
                                              Me.CamereNum3, _
                                              Me.CamereNum4, _
                                              Me.CamereNum5, _
                                              Me.Cap, _
                                              Me.Cell, _
                                              Me.Città, _
                                              Me.CodFisc, _
                                              Me.Email, _
                                              Me.Fax, _
                                              Me.Indirizzo1, _
                                              Me.Nazione, _
                                              Me.PIva, _
                                              Me.Provincia, _
                                              Me.Regione, _
                                              Me.Strutture, _
                                              Me.TelCasa, _
                                              Me.TelUfficio, _
                                              Me.TipoCliente, _
                                              Me.Titolo, _
                                              Me.Note, _
                                              Me.Immagine, _
                                              Me.Internet, _
                                              Me.Indirizzo2)

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

   Public Overrides Function ModificaDati(ByVal tabella As String, ByVal codice As String) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} " & _
                             "SET RagSoc = '{1}', " & _
                             "CamereData1 = '{2}', " & _
                             "CamereData2 = '{3}', " & _
                             "CamereData3 = '{4}', " & _
                             "CamereData4 = '{5}', " & _
                             "CamereData5 = '{6}', " & _
                             "CamereNotti1 = '{7}', " & _
                             "CamereNotti2 = '{8}', " & _
                             "CamereNotti3 = '{9}', " & _
                             "CamereNotti4 = '{10}', " & _
                             "CamereNotti5 = '{11}', " & _
                             "CamereNum1 = '{12}', " & _
                             "CamereNum2 = '{13}', " & _
                             "CamereNum3 = '{14}', " & _
                             "CamereNum4 = '{15}', " & _
                             "CamereNum5 = '{16}', " & _
                             "Cap = '{17}', " & _
                             "Cell = '{18}', " & _
                             "Città = '{19}', " & _
                             "CodFisc = '{20}', " & _
                             "Email = '{21}', " & _
                             "Fax = '{22}', " & _
                             "Indirizzo1 = '{23}', " & _
                             "Indirizzo2 = '{24}', " & _
                             "Nazione = '{25}', " & _
                             "PIva = '{26}', " & _
                             "Provincia = '{27}', " & _
                             "Regione = '{28}', " & _
                             "Strutture = '{29}', " & _
                             "TelCasa = '{30}', " & _
                             "TelUfficio = '{31}', " & _
                             "TipoCliente = '{32}', " & _
                             "Titolo = '{33}', " & _
                             "[Note] = '{34}', " & _
                             "Immagine = '{35}', " & _
                             "Internet = '{36}' " & _
                             "WHERE Id = {37}", _
                              tabella, _
                              Me.RagSoc, _
                              Me.CamereData1, _
                              Me.CamereData2, _
                              Me.CamereData3, _
                              Me.CamereData4, _
                              Me.CamereData5, _
                              Me.CamereNotti1, _
                              Me.CamereNotti2, _
                              Me.CamereNotti3, _
                              Me.CamereNotti4, _
                              Me.CamereNotti5, _
                              Me.CamereNum1, _
                              Me.CamereNum2, _
                              Me.CamereNum3, _
                              Me.CamereNum4, _
                              Me.CamereNum5, _
                              Me.Cap, _
                              Me.Cell, _
                              Me.Città, _
                              Me.CodFisc, _
                              Me.Email, _
                              Me.Fax, _
                              Me.Indirizzo1, _
                              Me.Indirizzo2, _
                              Me.Nazione, _
                              Me.PIva, _
                              Me.Provincia, _
                              Me.Regione, _
                              Me.Strutture, _
                              Me.TelCasa, _
                              Me.TelUfficio, _
                              Me.TipoCliente, _
                              Me.Titolo, _
                              Me.Note, _
                              Me.Immagine, _
                              Me.Internet, _
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
