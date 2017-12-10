Imports System.Data.OleDb

Public Class PrenCamere

   Public Codice As Integer
   Public IdCliente As Integer
   Public Numero As Integer
   Public Data As String
   Public Tipologia As String
   Public Stato As String
   Public Cognome As String
   Public Nome As String
   Public Adulti As Integer
   Public Neonati As Integer
   Public Bambini As Integer
   Public Ragazzi As Integer
   Public NumeroCamera As String
   Public DescrizioneCamera As String
   Public Trattamento As String
   Public DataArrivo As String
   Public DataPartenza As String
   Public OraArrivo As String
   Public NumeroNotti As Integer
   Public Listino As String
   Public Pagamento As String
   Public CostoCamera As String
   Public AccontoCamera As String
   Public TotaleConto As String
   Public ApplicaSconto As String
   Public Sconto As String
   Public Servizio As String
   Public Colore As Integer
   Public Note As String

   ' Dichiara un oggetto connessione.
   Private cn As New OleDbConnection(ConnString)
   Private tr As OleDbTransaction
   ' Gestione degli errori.
   Private err As New Varie.Errore

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
            Me.Codice = Convert.ToInt32(ds.Tables(tabella).Rows(0)("Id"))
         Else
            Me.Codice = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("IdCliente")) = False Then
            Me.IdCliente = Convert.ToInt32(ds.Tables(tabella).Rows(0)("IdCliente"))
         Else
            Me.IdCliente = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Numero")) = False Then
            Me.Numero = Convert.ToInt32(ds.Tables(tabella).Rows(0)("Numero"))
         Else
            Me.Numero = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Data")) = False Then
            Me.Data = ds.Tables(tabella).Rows(0)("Data").ToString
         Else
            Me.Data = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Tipologia")) = False Then
            Me.Tipologia = ds.Tables(tabella).Rows(0)("Tipologia").ToString
         Else
            Me.Tipologia = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Stato")) = False Then
            Me.Stato = ds.Tables(tabella).Rows(0)("Stato").ToString
         Else
            Me.Stato = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Cognome")) = False Then
            Me.Cognome = ds.Tables(tabella).Rows(0)("Cognome").ToString
         Else
            Me.Cognome = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Nome")) = False Then
            Me.Nome = ds.Tables(tabella).Rows(0)("Nome").ToString
         Else
            Me.Nome = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Adulti")) = False Then
            Me.Adulti = ds.Tables(tabella).Rows(0)("Adulti").ToString
         Else
            Me.Adulti = "0"
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Neonati")) = False Then
            Me.Neonati = ds.Tables(tabella).Rows(0)("Neonati").ToString
         Else
            Me.Neonati = "0"
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Bambini")) = False Then
            Me.Bambini = ds.Tables(tabella).Rows(0)("Bambini").ToString
         Else
            Me.Bambini = "0"
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Ragazzi")) = False Then
            Me.Ragazzi = ds.Tables(tabella).Rows(0)("Ragazzi").ToString
         Else
            Me.Ragazzi = "0"
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("NumeroCamera")) = False Then
            Me.NumeroCamera = ds.Tables(tabella).Rows(0)("NumeroCamera").ToString
         Else
            Me.NumeroCamera = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("DescrizioneCamera")) = False Then
            Me.DescrizioneCamera = ds.Tables(tabella).Rows(0)("DescrizioneCamera").ToString
         Else
            Me.DescrizioneCamera = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Trattamento")) = False Then
            Me.Trattamento = ds.Tables(tabella).Rows(0)("Trattamento").ToString
         Else
            Me.Trattamento = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("DataArrivo")) = False Then
            Me.DataArrivo = ds.Tables(tabella).Rows(0)("DataArrivo").ToString
         Else
            Me.DataArrivo = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("DataPartenza")) = False Then
            Me.DataPartenza = ds.Tables(tabella).Rows(0)("DataPartenza").ToString
         Else
            Me.DataPartenza = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("OraArrivo")) = False Then
            Me.OraArrivo = ds.Tables(tabella).Rows(0)("OraArrivo").ToString
         Else
            Me.OraArrivo = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("NumeroNotti")) = False Then
            Me.NumeroNotti = ds.Tables(tabella).Rows(0)("NumeroNotti").ToString
         Else
            Me.NumeroNotti = "0"
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Listino")) = False Then
            Me.Listino = ds.Tables(tabella).Rows(0)("Listino").ToString
         Else
            Me.Listino = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Pagamento")) = False Then
            Me.Pagamento = ds.Tables(tabella).Rows(0)("Pagamento").ToString
         Else
            Me.Pagamento = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("CostoCamera")) = False Then
            Me.CostoCamera = ds.Tables(tabella).Rows(0)("CostoCamera").ToString
         Else
            Me.CostoCamera = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("AccontoCamera")) = False Then
            Me.AccontoCamera = ds.Tables(tabella).Rows(0)("AccontoCamera").ToString
         Else
            Me.AccontoCamera = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("TotaleConto")) = False Then
            Me.TotaleConto = ds.Tables(tabella).Rows(0)("TotaleConto").ToString
         Else
            Me.TotaleConto = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ApplicaSconto")) = False Then
            Me.ApplicaSconto = ds.Tables(tabella).Rows(0)("ApplicaSconto").ToString
         Else
            Me.ApplicaSconto = "0"
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Sconto")) = False Then
            Me.Sconto = ds.Tables(tabella).Rows(0)("Sconto").ToString
         Else
            Me.Sconto = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Servizio")) = False Then
            Me.Servizio = ds.Tables(tabella).Rows(0)("Servizio").ToString
         Else
            Me.Servizio = VALORE_ZERO
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
         sql = String.Format("INSERT INTO {0} (IdCliente, Numero, Data, Tipologia, Stato, Cognome, Nome, Adulti, Neonati, Bambini, Ragazzi, NumeroCamera, DescrizioneCamera, " & _
                                              "Trattamento, DataArrivo, DataPartenza, OraArrivo, NumeroNotti, Listino, Pagamento, CostoCamera, AccontoCamera, " & _
                                              "TotaleConto, ApplicaSconto, Sconto, Servizio, Colore, [Note]) " & _
                                       "VALUES(@IdCliente, @Numero, @Data, @Tipologia, @Stato, @Cognome, @Nome, @Adulti, @Neonati, @Bambini, @Ragazzi, @NumeroCamera, @DescrizioneCamera, " & _
                                              "@Trattamento, @DataArrivo, @DataPartenza, @OraArrivo, @NumeroNotti, @Listino, @Pagamento, @CostoCamera, @AccontoCamera, " & _
                                              "@TotaleConto, @ApplicaSconto, @Sconto, @Servizio, @Colore, @Note)", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)

         cmdInsert.Parameters.Add("@IdCliente", Me.IdCliente)
         cmdInsert.Parameters.Add("@Numero", Me.Numero)
         cmdInsert.Parameters.Add("@Data", Me.Data)
         cmdInsert.Parameters.Add("@Tipologia", Me.Tipologia)
         cmdInsert.Parameters.Add("@Stato", Me.Stato)
         cmdInsert.Parameters.Add("@Cognome", Me.Cognome)
         cmdInsert.Parameters.Add("@Nome", Me.Nome)
         cmdInsert.Parameters.Add("@Adulti", Me.Adulti)
         cmdInsert.Parameters.Add("@Neonati", Me.Neonati)
         cmdInsert.Parameters.Add("@Bambini", Me.Bambini)
         cmdInsert.Parameters.Add("@Ragazzi", Me.Ragazzi)
         cmdInsert.Parameters.Add("@NumeroCamera", Me.NumeroCamera)
         cmdInsert.Parameters.Add("@DescrizioneCamera", Me.DescrizioneCamera)
         cmdInsert.Parameters.Add("@Trattamento", Me.Trattamento)
         cmdInsert.Parameters.Add("@DataArrivo", Me.DataArrivo)
         cmdInsert.Parameters.Add("@DataPartenza", Me.DataPartenza)
         cmdInsert.Parameters.Add("@OraArrivo", Me.OraArrivo)
         cmdInsert.Parameters.Add("@NumeroNotti", Me.NumeroNotti)
         cmdInsert.Parameters.Add("@Listino", Me.Listino)
         cmdInsert.Parameters.Add("@Pagamento", Me.Pagamento)
         cmdInsert.Parameters.Add("@CostoCamera", Me.CostoCamera)
         cmdInsert.Parameters.Add("@AccontoCamera", Me.AccontoCamera)
         cmdInsert.Parameters.Add("@TotaleConto", Me.TotaleConto)
         cmdInsert.Parameters.Add("@ApplicaSconto", Me.ApplicaSconto)
         cmdInsert.Parameters.Add("@Sconto", Me.Sconto)
         cmdInsert.Parameters.Add("@Servizio", Me.Servizio)
         cmdInsert.Parameters.Add("@Colore", Me.Colore)
         cmdInsert.Parameters.Add("@Note", Me.Note)

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
                             "SET IdCliente = @IdCliente, " & _
                             "Numero = @Numero, " & _
                             "Data = @Data, " & _
                             "Tipologia = @Tipologia, " & _
                             "Stato = @Stato, " & _
                             "Cognome = @Cognome, " & _
                             "Nome = @Nome, " & _
                             "Adulti = @Adulti, " & _
                             "Neonati = @Neonati, " & _
                             "Bambini = @Bambini, " & _
                             "Ragazzi = @Ragazzi, " & _
                             "NumeroCamera = @NumeroCamera, " & _
                             "DescrizioneCamera = @DescrizioneCamera, " & _
                             "Trattamento = @Trattamento, " & _
                             "DataArrivo = @DataArrivo, " & _
                             "DataPartenza = @DataPartenza, " & _
                             "OraArrivo = @OraArrivo, " & _
                             "NumeroNotti = @NumeroNotti, " & _
                             "Listino = @Listino, " & _
                             "Pagamento = @Pagamento, " & _
                             "CostoCamera = @CostoCamera, " & _
                             "AccontoCamera = @AccontoCamera, " & _
                             "TotaleConto = @TotaleConto, " & _
                             "ApplicaSconto = @ApplicaSconto, " & _
                             "Sconto = @Sconto, " & _
                             "Servizio = @Servizio, " & _
                             "Colore = @Colore, " & _
                             "[Note] = @Note " & _
                             "WHERE Id = {1}", _
                              tabella, _
                              codice)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.Add("@IdCliente", Me.IdCliente)
         cmdUpdate.Parameters.Add("@Numero", Me.Numero)
         cmdUpdate.Parameters.Add("@Data", Me.Data)
         cmdUpdate.Parameters.Add("@Tipologia", Me.Tipologia)
         cmdUpdate.Parameters.Add("@Stato", Me.Stato)
         cmdUpdate.Parameters.Add("@Cognome", Me.Cognome)
         cmdUpdate.Parameters.Add("@Nome", Me.Nome)
         cmdUpdate.Parameters.Add("@Adulti", Me.Adulti)
         cmdUpdate.Parameters.Add("@Neonati", Me.Neonati)
         cmdUpdate.Parameters.Add("@Bambini", Me.Bambini)
         cmdUpdate.Parameters.Add("@Ragazzi", Me.Ragazzi)
         cmdUpdate.Parameters.Add("@NumeroCamera", Me.NumeroCamera)
         cmdUpdate.Parameters.Add("@DescrizioneCamera", Me.DescrizioneCamera)
         cmdUpdate.Parameters.Add("@Trattamento", Me.Trattamento)
         cmdUpdate.Parameters.Add("@DataArrivo", Me.DataArrivo)
         cmdUpdate.Parameters.Add("@DataPartenza", Me.DataPartenza)
         cmdUpdate.Parameters.Add("@OraArrivo", Me.OraArrivo)
         cmdUpdate.Parameters.Add("@NumeroNotti", Me.NumeroNotti)
         cmdUpdate.Parameters.Add("@Listino", Me.Listino)
         cmdUpdate.Parameters.Add("@Pagamento", Me.Pagamento)
         cmdUpdate.Parameters.Add("@CostoCamera", Me.CostoCamera)
         cmdUpdate.Parameters.Add("@AccontoCamera", Me.AccontoCamera)
         cmdUpdate.Parameters.Add("@TotaleConto", Me.TotaleConto)
         cmdUpdate.Parameters.Add("@ApplicaSconto", Me.ApplicaSconto)
         cmdUpdate.Parameters.Add("@Sconto", Me.Sconto)
         cmdUpdate.Parameters.Add("@Servizio", Me.Servizio)
         cmdUpdate.Parameters.Add("@Colore", Me.Colore)
         cmdUpdate.Parameters.Add("@Note", Me.Note)

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
