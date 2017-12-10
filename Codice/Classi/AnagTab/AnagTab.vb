Imports System.Data.OleDb

Namespace Anagrafiche

   Public Class Azienda
      Public Codice As Integer
      Public RagSociale As String
      Public Descrizione As String
      Public Piva As String
      Public CodFisc As String
      Public Rea As String
      Public Iri As String
      Public Indirizzo As String
      Public Cap As String
      Public Citt‡ As String
      Public Provincia As String
      Public Regione As String
      Public Nazione As String
      Public Telefono As String
      Public Fax As String
      Public Email As String
      Public Internet As String
      Public Attivit‡ As String
      Public Immagine() As Byte
      Public PercorsoImg As String
      Public PercorsoDB As String
      Public TipoPagamento As String
      Public Banca As String
      Public Cin As String
      Public Abi As String
      Public Cab As String
      Public Cc As String
      Public Iban As String

      Private m_ConnString As String

      Public Property ConnString()
         Get
            Return m_ConnString
         End Get

         Set(ByVal Value)
            m_ConnString = Value
         End Set
      End Property

      Public Sub New(ByVal val As String)
         ' Imposta la stringa di connessione del database.
         Me.ConnString = val
      End Sub

      Protected Overrides Sub Finalize()
         MyBase.Finalize()
      End Sub

      Private err As New Varie.Errore
      Private tr As OleDbTransaction

      Public Sub LeggiDati(ByVal tabella As String, ByVal codice As String)
         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(Me.ConnString)
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
               Me.RagSociale = ds.Tables(tabella).Rows(0)("RagSoc")
            Else
               Me.RagSociale = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Descrizione")) = False Then
               Me.Descrizione = ds.Tables(tabella).Rows(0)("Descrizione")
            Else
               Me.Descrizione = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Iva")) = False Then
               Me.Piva = ds.Tables(tabella).Rows(0)("Iva")
            Else
               Me.Piva = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("CodFisc")) = False Then
               Me.CodFisc = ds.Tables(tabella).Rows(0)("CodFisc")
            Else
               Me.CodFisc = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Rea")) = False Then
               Me.Rea = ds.Tables(tabella).Rows(0)("Rea")
            Else
               Me.Rea = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Iri")) = False Then
               Me.Iri = ds.Tables(tabella).Rows(0)("Iri")
            Else
               Me.Iri = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Indirizzo")) = False Then
               Me.Indirizzo = ds.Tables(tabella).Rows(0)("Indirizzo")
            Else
               Me.Indirizzo = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Cap")) = False Then
               Me.Cap = ds.Tables(tabella).Rows(0)("Cap")
            Else
               Me.Cap = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Citt‡")) = False Then
               Me.Citt‡ = ds.Tables(tabella).Rows(0)("Citt‡")
            Else
               Me.Citt‡ = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Prov")) = False Then
               Me.Provincia = ds.Tables(tabella).Rows(0)("Prov")
            Else
               Me.Provincia = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Nazione")) = False Then
               Me.Nazione = ds.Tables(tabella).Rows(0)("Nazione")
            Else
               Me.Nazione = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Regione")) = False Then
               Me.Regione = ds.Tables(tabella).Rows(0)("Regione")
            Else
               Me.Regione = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Tel")) = False Then
               Me.Telefono = ds.Tables(tabella).Rows(0)("Tel")
            Else
               Me.Telefono = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Fax")) = False Then
               Me.Fax = ds.Tables(tabella).Rows(0)("Fax")
            Else
               Me.Fax = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Mail")) = False Then
               Me.Email = ds.Tables(tabella).Rows(0)("Mail")
            Else
               Me.Email = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Internet")) = False Then
               Me.Internet = ds.Tables(tabella).Rows(0)("Internet")
            Else
               Me.Internet = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Immagine")) = False Then
               Me.Immagine = ds.Tables(tabella).Rows(0)("Immagine")
            Else
               Me.Immagine = Nothing
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("PercorsoImg")) = False Then
               Me.PercorsoImg = ds.Tables(tabella).Rows(0)("PercorsoImg")
            Else
               Me.PercorsoImg = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Attivit‡")) = False Then
               Me.Attivit‡ = ds.Tables(tabella).Rows(0)("Attivit‡")
            Else
               Me.Attivit‡ = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("PercorsoDB")) = False Then
               Me.PercorsoDB = ds.Tables(tabella).Rows(0)("PercorsoDB")
            Else
               Me.PercorsoDB = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("ModPagamento")) = False Then
               Me.TipoPagamento = ds.Tables(tabella).Rows(0)("ModPagamento")
            Else
               Me.TipoPagamento = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Banca")) = False Then
               Me.Banca = ds.Tables(tabella).Rows(0)("Banca")
            Else
               Me.Banca = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Cin")) = False Then
               Me.Cin = ds.Tables(tabella).Rows(0)("Cin")
            Else
               Me.Cin = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Abi")) = False Then
               Me.Abi = ds.Tables(tabella).Rows(0)("Abi")
            Else
               Me.Abi = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Cab")) = False Then
               Me.Cab = ds.Tables(tabella).Rows(0)("Cab")
            Else
               Me.Cab = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Cc")) = False Then
               Me.Cc = ds.Tables(tabella).Rows(0)("Cc")
            Else
               Me.Cc = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Iban")) = False Then
               Me.Iban = ds.Tables(tabella).Rows(0)("Iban")
            Else
               Me.Iban = ""
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

      Public Function LeggiDati(ByVal tabella As String) As Boolean
         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(Me.ConnString)
         ' Dichiara un oggetto DataAdapter.
         Dim da As OleDbDataAdapter
         ' Dichiara un oggetto DataSet
         Dim ds As DataSet
         Dim sql As String

         Try
            ' Apre la connessione.
            cn.Open()

            ' Crea la stringa.
            sql = String.Format("SELECT * FROM {0}", tabella)

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
               Me.RagSociale = ds.Tables(tabella).Rows(0)("RagSoc")
            Else
               Me.RagSociale = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Descrizione")) = False Then
               Me.Descrizione = ds.Tables(tabella).Rows(0)("Descrizione")
            Else
               Me.Descrizione = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Iva")) = False Then
               Me.Piva = ds.Tables(tabella).Rows(0)("Iva")
            Else
               Me.Piva = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("CodFisc")) = False Then
               Me.CodFisc = ds.Tables(tabella).Rows(0)("CodFisc")
            Else
               Me.CodFisc = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Rea")) = False Then
               Me.Rea = ds.Tables(tabella).Rows(0)("Rea")
            Else
               Me.Rea = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Iri")) = False Then
               Me.Iri = ds.Tables(tabella).Rows(0)("Iri")
            Else
               Me.Iri = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Indirizzo")) = False Then
               Me.Indirizzo = ds.Tables(tabella).Rows(0)("Indirizzo")
            Else
               Me.Indirizzo = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Cap")) = False Then
               Me.Cap = ds.Tables(tabella).Rows(0)("Cap")
            Else
               Me.Cap = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Citt‡")) = False Then
               Me.Citt‡ = ds.Tables(tabella).Rows(0)("Citt‡")
            Else
               Me.Citt‡ = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Prov")) = False Then
               Me.Provincia = ds.Tables(tabella).Rows(0)("Prov")
            Else
               Me.Provincia = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Nazione")) = False Then
               Me.Nazione = ds.Tables(tabella).Rows(0)("Nazione")
            Else
               Me.Nazione = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Regione")) = False Then
               Me.Regione = ds.Tables(tabella).Rows(0)("Regione")
            Else
               Me.Regione = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Tel")) = False Then
               Me.Telefono = ds.Tables(tabella).Rows(0)("Tel")
            Else
               Me.Telefono = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Fax")) = False Then
               Me.Fax = ds.Tables(tabella).Rows(0)("Fax")
            Else
               Me.Fax = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("mail")) = False Then
               Me.Email = ds.Tables(tabella).Rows(0)("mail")
            Else
               Me.Email = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Internet")) = False Then
               Me.Internet = ds.Tables(tabella).Rows(0)("Internet")
            Else
               Me.Internet = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Immagine")) = False Then
               Me.Immagine = ds.Tables(tabella).Rows(0)("Immagine")
            Else
               Me.Immagine = Nothing
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("PercorsoImg")) = False Then
               Me.PercorsoImg = ds.Tables(tabella).Rows(0)("PercorsoImg")
            Else
               Me.PercorsoImg = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Attivit‡")) = False Then
               Me.Attivit‡ = ds.Tables(tabella).Rows(0)("Attivit‡")
            Else
               Me.Attivit‡ = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("PercorsoDB")) = False Then
               Me.PercorsoDB = ds.Tables(tabella).Rows(0)("PercorsoDB")
            Else
               Me.PercorsoDB = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("ModPagamento")) = False Then
               Me.TipoPagamento = ds.Tables(tabella).Rows(0)("ModPagamento")
            Else
               Me.TipoPagamento = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Banca")) = False Then
               Me.Banca = ds.Tables(tabella).Rows(0)("Banca")
            Else
               Me.Banca = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Cin")) = False Then
               Me.Cin = ds.Tables(tabella).Rows(0)("Cin")
            Else
               Me.Cin = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Abi")) = False Then
               Me.Abi = ds.Tables(tabella).Rows(0)("Abi")
            Else
               Me.Abi = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Cab")) = False Then
               Me.Cab = ds.Tables(tabella).Rows(0)("Cab")
            Else
               Me.Cab = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Cc")) = False Then
               Me.Cc = ds.Tables(tabella).Rows(0)("Cc")
            Else
               Me.Cc = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Iban")) = False Then
               Me.Iban = ds.Tables(tabella).Rows(0)("Iban")
            Else
               Me.Iban = ""
            End If

            Return True

         Catch ex As Exception
            ' Visualizza un messaggio di errore e lo registra nell'apposito file.
            err.GestisciErrore(ex.StackTrace, ex.Message)

            Return False

         Finally
            da.Dispose()
            ds.Dispose()
            ' Chiude la connessione.
            cn.Close()
         End Try
      End Function

      Public Sub InserisciDati(ByVal tabella As String)
         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(Me.ConnString)
         Dim sql As String

         Try
            ' Apre la connessione.
            cn.Open()

            ' Avvia una transazione.
            tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
            sql = String.Format("INSERT INTO {0} (RagSoc, Descrizione, Iva, CodFisc, Rea, Iri, Indirizzo, " & _
                                                 "Citt‡, Prov, Cap, Nazione, Tel, Fax, Internet, " & _
                                                 "Mail, Immagine, Attivit‡, PercorsoDB) " & _
                                          "VALUES(@RagSoc, @Descrizione, @Iva, @CodFisc, @Rea, @Iri, @Indirizzo, " & _
                                                 "@Citt‡, @Prov, @Cap, @Nazione, @Tel, @Fax, @Internet, " & _
                                                 "@Mail, @Immagine, @Attivit‡, @PercorsoDB)", tabella)

            ' Crea il comando per la connessione corrente.
            Dim cmdInsert As New OleDbCommand(sql, cn, tr)

            cmdInsert.Parameters.Add("@RagSoc", Me.RagSociale)
            cmdInsert.Parameters.Add("@Descrizione", Me.Descrizione)
            cmdInsert.Parameters.Add("@Iva", Me.Piva)
            cmdInsert.Parameters.Add("@CodFisc", Me.CodFisc)
            cmdInsert.Parameters.Add("@Rea", Me.Rea)
            cmdInsert.Parameters.Add("@Iri", Me.Iri)
            cmdInsert.Parameters.Add("@Indirizzo", Me.Indirizzo)
            cmdInsert.Parameters.Add("@Citt‡", Me.Citt‡)
            cmdInsert.Parameters.Add("@Prov", Me.Provincia)
            cmdInsert.Parameters.Add("@Cap", Me.Cap)
            cmdInsert.Parameters.Add("@Nazione", Me.Nazione)
            cmdInsert.Parameters.Add("@Tel", Me.Telefono)
            cmdInsert.Parameters.Add("@Fax", Me.Fax)
            cmdInsert.Parameters.Add("@Internet", Me.Internet)
            cmdInsert.Parameters.Add("@Mail", Me.Email)
            cmdInsert.Parameters.Add("@Immagine", Me.Immagine)
            cmdInsert.Parameters.Add("@Attivit‡", Me.Attivit‡)
            cmdInsert.Parameters.Add("@PercorsoDB", Me.PercorsoDB)

            ' Esegue il comando.
            Dim Record As Integer = cmdInsert.ExecuteNonQuery()

            ' Conferma transazione.
            tr.Commit()

         Catch ex As Exception
            ' Annulla transazione.
            tr.Rollback()

            ' Visualizza un messaggio di errore e lo registra nell'apposito file.
            err.GestisciErrore(ex.StackTrace, ex.Message)

         Finally
            ' Chiude la connessione.
            cn.Close()

         End Try
      End Sub

      Public Sub ModificaDati(ByVal tabella As String, ByVal codice As Integer)
         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(Me.ConnString)
         Dim sql As String

         Try
            ' Apre la connessione.
            cn.Open()

            ' Avvia una transazione.
            tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

            ' Crea la stringa di eliminazione.
            sql = String.Format("UPDATE {0} " & _
                                "SET RagSoc = @RagSoc, " & _
                                "Descrizione = @Descrizione, " & _
                                "Iva = @Iva, " & _
                                "CodFisc = @CodFisc, " & _
                                "Rea = @Rea, " & _
                                "Iri = @Iri, " & _
                                "Indirizzo = @Indirizzo, " & _
                                "Citt‡ = @Citt‡, " & _
                                "Prov = @Prov, " & _
                                "Cap = @Cap, " & _
                                "Nazione = @Nazione, " & _
                                "Tel = @Tel, " & _
                                "Fax = @Fax, " & _
                                "Internet = @Internet, " & _
                                "Mail = @Mail, " & _
                                "Immagine = @Immagine, " & _
                                "PercorsoImg = @PercorsoImg, " & _
                                "Attivit‡ = @Attivit‡, " & _
                                "PercorsoDB = @PercorsoDB, " & _
                                "ModPagamento = @ModPagamento, " & _
                                "Banca = @Banca, " & _
                                "Cin = @Cin, " & _
                                "Abi = @Abi, " & _
                                "Cab = @Cab, " & _
                                "Cc = @Cc, " & _
                                "Iban = @Iban " & _
                                "WHERE Id = {1}", _
                                 tabella, _
                                 codice)

            ' Crea il comando per la connessione corrente.
            Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

            cmdUpdate.Parameters.Add("@RagSoc", Me.RagSociale)
            cmdUpdate.Parameters.Add("@Descrizione", Me.Descrizione)
            cmdUpdate.Parameters.Add("@Iva", Me.Piva)
            cmdUpdate.Parameters.Add("@CodFisc", Me.CodFisc)
            cmdUpdate.Parameters.Add("@Rea", Me.Rea)
            cmdUpdate.Parameters.Add("@Iri", Me.Iri)
            cmdUpdate.Parameters.Add("@Indirizzo", Me.Indirizzo)
            cmdUpdate.Parameters.Add("@Citt‡", Me.Citt‡)
            cmdUpdate.Parameters.Add("@Prov", Me.Provincia)
            cmdUpdate.Parameters.Add("@Cap", Me.Cap)
            cmdUpdate.Parameters.Add("@Nazione", Me.Nazione)
            cmdUpdate.Parameters.Add("@Tel", Me.Telefono)
            cmdUpdate.Parameters.Add("@Fax", Me.Fax)
            cmdUpdate.Parameters.Add("@Internet", Me.Internet)
            cmdUpdate.Parameters.Add("@Mail", Me.Email)
            cmdUpdate.Parameters.Add("@Immagine", Me.Immagine)
            cmdUpdate.Parameters.Add("@PercorsoImg", Me.PercorsoImg)
            cmdUpdate.Parameters.Add("@Attivit‡", Me.Attivit‡)
            cmdUpdate.Parameters.Add("@PercorsoDB", Me.PercorsoDB)
            cmdUpdate.Parameters.Add("@ModPagamento", Me.TipoPagamento)
            cmdUpdate.Parameters.Add("@Banca", Me.Banca)
            cmdUpdate.Parameters.Add("@Cin", Me.Cin)
            cmdUpdate.Parameters.Add("@Abi", Me.Abi)
            cmdUpdate.Parameters.Add("@Cab", Me.Cab)
            cmdUpdate.Parameters.Add("@Cc", Me.Cc)
            cmdUpdate.Parameters.Add("@Iban", Me.Iban)

            ' Esegue il comando.
            Dim Record As Integer = cmdUpdate.ExecuteNonQuery()

            ' Conferma transazione.
            tr.Commit()

         Catch ex As Exception
            ' Annulla transazione.
            tr.Rollback()

            ' Visualizza un messaggio di errore e lo registra nell'apposito file.
            err.GestisciErrore(ex.StackTrace, ex.Message)

         Finally
            ' Chiude la connessione.
            cn.Close()
         End Try
      End Sub
   End Class

   Public Class Persona
      Public Codice As String = String.Empty
      Public Cognome As String = String.Empty
      Public Nome As String = String.Empty
      Public Titolo As String = String.Empty
      Public Sesso As String = String.Empty
      Public CodFisc As String = String.Empty
      Public PIva As String = String.Empty
      Public Indirizzo1 As String = String.Empty
      Public Indirizzo2 As String = String.Empty
      Public Cap As String = String.Empty
      Public Citt‡ As String = String.Empty
      Public Provincia As String = String.Empty
      Public Regione As String = String.Empty
      Public Nazione As String = String.Empty
      Public DataNascita As String = String.Empty
      Public LuogoNascita As String = String.Empty
      Public ProvNascita As String = String.Empty
      Public NazioneNascita As String = String.Empty
      Public Nazionalit‡ As String = String.Empty
      Public TipoDoc As String = String.Empty
      Public NumeroDocIdentit‡ As String = String.Empty
      Public DataRilascioDoc As String = String.Empty
      Public RilasciatoDa As String = String.Empty
      Public Citt‡RilascioDoc As String = String.Empty
      Public NazioneRilascioDoc As String = String.Empty
      Public Intestatario As String = String.Empty
      Public TipoPagamento As String = String.Empty
      Public CartaCredito As String = String.Empty
      Public NumCarta As String = String.Empty
      Public ScadenzaCarta As String = String.Empty
      Public TitolareCarta As String = String.Empty
      Public Targa As String = String.Empty
      Public Disabile As String = String.Empty
      Public InvioCorrisp As String = String.Empty
      Public Obsoleto As String = String.Empty
      Public TelCasa As String = String.Empty
      Public TelUfficio As String = String.Empty
      Public Fax As String = String.Empty
      Public Cell As String = String.Empty
      Public Email As String = String.Empty
      Public Internet As String = String.Empty
      Public Immagine As String = String.Empty
      Public Professione As String = String.Empty
      Public Lingua As String = String.Empty
      ' Utilizzato per il codice tessera.
      Public NumeroDoc As String = String.Empty
      Public Note As String = String.Empty

   End Class

   Public Class Cliente
      Inherits Persona

      Public Mastro As String = String.Empty
      Public TipoCliente As String = String.Empty
      Public Mercato As String = String.Empty
      Public Canale As String = String.Empty
      Public NoteVideo As String = String.Empty
      Public NoteStampa As String = String.Empty
      Public Privacy As String = String.Empty
      Public InsPS As String = String.Empty
      Public NumComp As String = String.Empty
      Public Strutture As String = String.Empty
      Public Iva As String = String.Empty
      Public Sconto As String = String.Empty
      'Public CodiceTessera As String = String.Empty

      Private m_ConnString As String

      Public Property ConnString()
         Get
            Return m_ConnString
         End Get

         Set(ByVal Value)
            m_ConnString = Value
         End Set
      End Property

      Public Sub New(ByVal val As String)
         ' Imposta la stringa di connessione del database.
         Me.ConnString = val
      End Sub

      Private err As New Varie.Errore
      Private tr As OleDbTransaction

      Public Overridable Sub LeggiDati(ByVal tabella As String, ByVal codice As String)
         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(Me.ConnString)
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
            If IsDBNull(ds.Tables(tabella).Rows(0)("Mastro")) = False Then
               Me.Mastro = ds.Tables(tabella).Rows(0)("Mastro")
            Else
               Me.Mastro = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Cognome")) = False Then
               Me.Cognome = ds.Tables(tabella).Rows(0)("Cognome")
            Else
               Me.Cognome = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Nome")) = False Then
               Me.Nome = ds.Tables(tabella).Rows(0)("Nome")
            Else
               Me.Nome = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Titolo")) = False Then
               Me.Titolo = ds.Tables(tabella).Rows(0)("Titolo")
            Else
               Me.Titolo = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Sesso")) = False Then
               Me.Sesso = ds.Tables(tabella).Rows(0)("Sesso")
            Else
               Me.Sesso = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("CodFisc")) = False Then
               Me.CodFisc = ds.Tables(tabella).Rows(0)("CodFisc")
            Else
               Me.CodFisc = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Piva")) = False Then
               Me.PIva = ds.Tables(tabella).Rows(0)("Piva")
            Else
               Me.PIva = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Indirizzo")) = False Then
               Me.Indirizzo1 = ds.Tables(tabella).Rows(0)("Indirizzo")
            Else
               Me.Indirizzo1 = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Cap")) = False Then
               Me.Cap = ds.Tables(tabella).Rows(0)("Cap")
            Else
               Me.Cap = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Citt‡")) = False Then
               Me.Citt‡ = ds.Tables(tabella).Rows(0)("Citt‡")
            Else
               Me.Citt‡ = ""
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
            If IsDBNull(ds.Tables(tabella).Rows(0)("DataNascita")) = False Then
               Me.DataNascita = ds.Tables(tabella).Rows(0)("DataNascita")
            Else
               Me.DataNascita = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("LuogoNascita")) = False Then
               Me.LuogoNascita = ds.Tables(tabella).Rows(0)("LuogoNascita")
            Else
               Me.LuogoNascita = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("ProvNascita")) = False Then
               Me.ProvNascita = ds.Tables(tabella).Rows(0)("ProvNascita")
            Else
               Me.ProvNascita = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("NazioneNascita")) = False Then
               Me.NazioneNascita = ds.Tables(tabella).Rows(0)("NazioneNascita")
            Else
               Me.NazioneNascita = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Nazionalit‡")) = False Then
               Me.Nazionalit‡ = ds.Tables(tabella).Rows(0)("Nazionalit‡")
            Else
               Me.Nazionalit‡ = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("TipoDoc")) = False Then
               Me.TipoDoc = ds.Tables(tabella).Rows(0)("TipoDoc")
            Else
               Me.TipoDoc = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("DataRilascioDoc")) = False Then
               Me.DataRilascioDoc = ds.Tables(tabella).Rows(0)("DataRilascioDoc")
            Else
               Me.DataRilascioDoc = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("NumeroDocIdentit‡")) = False Then
               Me.NumeroDocIdentit‡ = ds.Tables(tabella).Rows(0)("NumeroDocIdentit‡")
            Else
               Me.NumeroDocIdentit‡ = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("RilasciatoDa")) = False Then
               Me.RilasciatoDa = ds.Tables(tabella).Rows(0)("RilasciatoDa")
            Else
               Me.RilasciatoDa = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Citt‡RilascioDoc")) = False Then
               Me.Citt‡RilascioDoc = ds.Tables(tabella).Rows(0)("Citt‡RilascioDoc")
            Else
               Me.Citt‡RilascioDoc = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("NazioneRilascioDoc")) = False Then
               Me.NazioneRilascioDoc = ds.Tables(tabella).Rows(0)("NazioneRilascioDoc")
            Else
               Me.NazioneRilascioDoc = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("TipoCliente")) = False Then
               Me.TipoCliente = ds.Tables(tabella).Rows(0)("TipoCliente")
            Else
               Me.TipoCliente = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Intestatario")) = False Then
               Me.Intestatario = ds.Tables(tabella).Rows(0)("Intestatario")
            Else
               Me.Intestatario = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("TipoPagamento")) = False Then
               Me.TipoPagamento = ds.Tables(tabella).Rows(0)("TipoPagamento")
            Else
               Me.TipoPagamento = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("NumCarta")) = False Then
               Me.NumCarta = ds.Tables(tabella).Rows(0)("NumCarta")
            Else
               Me.NumCarta = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("ScadenzaCarta")) = False Then
               Me.ScadenzaCarta = ds.Tables(tabella).Rows(0)("ScadenzaCarta")
            Else
               Me.ScadenzaCarta = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("TitolareCarta")) = False Then
               Me.TitolareCarta = ds.Tables(tabella).Rows(0)("TitolareCarta")
            Else
               Me.TitolareCarta = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Targa")) = False Then
               Me.Targa = ds.Tables(tabella).Rows(0)("Targa")
            Else
               Me.Targa = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Disabile")) = False Then
               Me.Disabile = ds.Tables(tabella).Rows(0)("Disabile")
            Else
               Me.Disabile = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("InvioCorrisp")) = False Then
               Me.InvioCorrisp = ds.Tables(tabella).Rows(0)("InvioCorrisp")
            Else
               Me.InvioCorrisp = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Obsoleto")) = False Then
               Me.Obsoleto = ds.Tables(tabella).Rows(0)("Obsoleto")
            Else
               Me.Obsoleto = ""
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
            If IsDBNull(ds.Tables(tabella).Rows(0)("Mercato")) = False Then
               Me.Mercato = ds.Tables(tabella).Rows(0)("Mercato")
            Else
               Me.Mercato = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Canale")) = False Then
               Me.Canale = ds.Tables(tabella).Rows(0)("Canale")
            Else
               Me.Canale = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Lingua")) = False Then
               Me.Lingua = ds.Tables(tabella).Rows(0)("Lingua")
            Else
               Me.Lingua = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Professione")) = False Then
               Me.Professione = ds.Tables(tabella).Rows(0)("Professione")
            Else
               Me.Professione = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("NoteVideo")) = False Then
               Me.NoteVideo = ds.Tables(tabella).Rows(0)("NoteVideo")
            Else
               Me.NoteVideo = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("NoteStampa")) = False Then
               Me.NoteStampa = ds.Tables(tabella).Rows(0)("NoteStampa")
            Else
               Me.NoteStampa = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Privacy")) = False Then
               Me.Privacy = ds.Tables(tabella).Rows(0)("Privacy")
            Else
               Me.Privacy = Nothing
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("InsPS")) = False Then
               Me.InsPS = ds.Tables(tabella).Rows(0)("InsPS")
            Else
               Me.InsPS = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("NumComp")) = False Then
               Me.NumComp = ds.Tables(tabella).Rows(0)("NumComp")
            Else
               Me.NumComp = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Iva")) = False Then
               Me.Iva = ds.Tables(tabella).Rows(0)("Iva")
            Else
               Me.Iva = VALORE_ZERO
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Sconto")) = False Then
               Me.Sconto = ds.Tables(tabella).Rows(0)("Sconto")
            Else
               Me.Sconto = VALORE_ZERO
            End If
            ' Codice tessera.
            If IsDBNull(ds.Tables(tabella).Rows(0)("NumeroDoc")) = False Then
               Me.NumeroDoc = ds.Tables(tabella).Rows(0)("NumeroDoc")
            Else
               Me.NumeroDoc = ""
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

      Public Overridable Function InserisciDati(ByVal tabella As String) As Boolean
         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(Me.ConnString)
         Dim sql As String

         Try
            ' Apre la connessione.
            cn.Open()

            ' Avvia una transazione.
            tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
            ' Crea la stringa di eliminazione.
            sql = String.Format("INSERT INTO {0} (Mastro, Titolo, Nome, Cognome, Sesso, Indirizzo, Cap, Citt‡, Provincia, Regione, Nazione, CodFisc, Piva, " & _
                                                 "DataNascita, LuogoNascita, ProvNascita, NazioneNascita, Nazionalit‡, " & _
                                                 "TipoDoc, NumeroDocIdentit‡, DataRilascioDoc, RilasciatoDa, Citt‡RilascioDoc, NazioneRilascioDoc, " & _
                                                 "Disabile, InvioCorrisp, Obsoleto, TelCasa, TelUfficio, Cell, Fax, Email, Internet, " & _
                                                 "CartaCredito, TitolareCarta, NumCarta, ScadenzaCarta, TipoCliente, TipoPagamento, Strutture, Targa, Intestatario," & _
                                                 "[Note], Immagine, Mercato, Canale, Lingua, Professione, [NoteVideo], [NoteStampa], Privacy, InsPS, NumComp, Iva, Sconto, NumeroDoc) " & _
                                          "VALUES(@Mastro, @Titolo, @Nome, @Cognome, @Sesso, @Indirizzo, @Cap, @Citt‡, @Provincia, @Regione, @Nazione, @CodFisc, @Piva, " & _
                                                 "@DataNascita, @LuogoNascita, @ProvNascita, @NazioneNascita, @Nazionalit‡, " & _
                                                 "@TipoDoc, @NumeroDocIdentit‡, @DataRilascioDoc, @RilasciatoDa, @Citt‡RilascioDoc, @NazioneRilascioDoc, " & _
                                                 "@Disabile, @InvioCorrisp, @Obsoleto, @TelCasa, @TelUfficio, @Cell, @Fax, @Email, @Internet, " & _
                                                 "@CartaCredito, @TitolareCarta, @NumCarta, @ScadenzaCarta, @TipoCliente, @TipoPagamento, @Strutture, @Targa, @Intestatario," & _
                                                 "@Note, @Immagine, @Mercato, @Canale, @Lingua, @Professione, @NoteVideo, @NoteStampa, @Privacy, @InsPS, @NumComp, @Iva, @Sconto, @NumeroDoc)", tabella)

            ' Crea il comando per la connessione corrente.
            Dim cmdInsert As New OleDbCommand(sql, cn, tr)

            cmdInsert.Parameters.Add("@Mastro", Me.Mastro)
            cmdInsert.Parameters.Add("@Titolo", Me.Titolo)
            cmdInsert.Parameters.Add("@Nome", Me.Nome)
            cmdInsert.Parameters.Add("@Cognome", Me.Cognome)
            cmdInsert.Parameters.Add("@Sesso", Me.Sesso)
            cmdInsert.Parameters.Add("@Indirizzo", Me.Indirizzo1)
            cmdInsert.Parameters.Add("@Cap", Me.Cap)
            cmdInsert.Parameters.Add("@Citt‡", Me.Citt‡)
            cmdInsert.Parameters.Add("@Provincia", Me.Provincia)
            cmdInsert.Parameters.Add("@Regione", Me.Regione)
            cmdInsert.Parameters.Add("@Nazione", Me.Nazione)
            cmdInsert.Parameters.Add("@CodFisc", Me.CodFisc)
            cmdInsert.Parameters.Add("@Piva", Me.PIva)
            cmdInsert.Parameters.Add("@DataNascita", Me.DataNascita)
            cmdInsert.Parameters.Add("@LuogoNascita", Me.LuogoNascita)
            cmdInsert.Parameters.Add("@ProvNascita", Me.ProvNascita)
            cmdInsert.Parameters.Add("@NazioneNascita", Me.NazioneNascita)
            cmdInsert.Parameters.Add("@Nazionalit‡", Me.Nazionalit‡)
            cmdInsert.Parameters.Add("@TipoDoc", Me.TipoDoc)
            cmdInsert.Parameters.Add("@NumeroDocIdentit‡", Me.NumeroDocIdentit‡)
            cmdInsert.Parameters.Add("@DataRilascioDoc", Me.DataRilascioDoc)
            cmdInsert.Parameters.Add("@RilasciatoDa", Me.RilasciatoDa)
            cmdInsert.Parameters.Add("@Citt‡RilascioDoc", Me.Citt‡RilascioDoc)
            cmdInsert.Parameters.Add("@NazioneRilascioDoc", Me.NazioneRilascioDoc)
            cmdInsert.Parameters.Add("@Disabile", Me.Disabile)
            cmdInsert.Parameters.Add("@InvioCorrisp", Me.InvioCorrisp)
            cmdInsert.Parameters.Add("@Obsoleto", Me.Obsoleto)
            cmdInsert.Parameters.Add("@TelCasa", Me.TelCasa)
            cmdInsert.Parameters.Add("@TelUfficio", Me.TelUfficio)
            cmdInsert.Parameters.Add("@Cell", Me.Cell)
            cmdInsert.Parameters.Add("@Fax", Me.Fax)
            cmdInsert.Parameters.Add("@Email", Me.Email)
            cmdInsert.Parameters.Add("@Internet", Me.Internet)
            cmdInsert.Parameters.Add("@CartaCredito", Me.CartaCredito)
            cmdInsert.Parameters.Add("@TitolareCarta", Me.TitolareCarta)
            cmdInsert.Parameters.Add("@NumCarta", Me.NumCarta)
            cmdInsert.Parameters.Add("@ScadenzaCarta", Me.ScadenzaCarta)
            cmdInsert.Parameters.Add("@TipoCliente", Me.TipoCliente)
            cmdInsert.Parameters.Add("@TipoPagamento", Me.TipoPagamento)
            cmdInsert.Parameters.Add("@Strutture", Me.Strutture)
            cmdInsert.Parameters.Add("@Targa", Me.Targa)
            cmdInsert.Parameters.Add("@Intestatario", Me.Intestatario)
            cmdInsert.Parameters.Add("@Note", Me.Note)
            cmdInsert.Parameters.Add("@Immagine", Me.Immagine)
            cmdInsert.Parameters.Add("@Mercato", Me.Mercato)
            cmdInsert.Parameters.Add("@Canale", Me.Canale)
            cmdInsert.Parameters.Add("@Lingua", Me.Lingua)
            cmdInsert.Parameters.Add("@Professione", Me.Professione)
            cmdInsert.Parameters.Add("@NoteVideo", Me.NoteVideo)
            cmdInsert.Parameters.Add("@NoteStampa", Me.NoteStampa)
            cmdInsert.Parameters.Add("@Privacy", Me.Privacy)
            cmdInsert.Parameters.Add("@InsPS", Me.InsPS)
            cmdInsert.Parameters.Add("@NumComp", Me.NumComp)
            cmdInsert.Parameters.Add("@Iva", Me.Iva)
            cmdInsert.Parameters.Add("@Sconto", Me.Sconto)
            cmdInsert.Parameters.Add("@NumeroDoc", Me.NumeroDoc)

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

      Public Overridable Function ModificaDati(ByVal tabella As String, ByVal codice As String) As Boolean
         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(Me.ConnString)
         Dim sql As String

         Try
            ' Apre la connessione.
            cn.Open()

            ' Avvia una transazione.
            tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

            ' Crea la stringa di eliminazione.
            sql = String.Format("UPDATE {0} " & _
                                "SET Mastro = @Mastro, " & _
                                "Titolo = @Titolo, " & _
                                "Nome = @Nome, " & _
                                "Cognome = @Cognome, " & _
                                "Sesso = @Sesso, " & _
                                "Indirizzo = @Indirizzo, " & _
                                "Cap = @Cap, " & _
                                "Citt‡ = @Citt‡, " & _
                                "Provincia = @Provincia, " & _
                                "Regione = @Regione, " & _
                                "Nazione = @Nazione, " & _
                                "CodFisc = @CodFisc, " & _
                                "Piva = @Piva, " & _
                                "DataNascita = @DataNascita, " & _
                                "LuogoNascita = @LuogoNascita, " & _
                                "ProvNascita = @ProvNascita, " & _
                                "NazioneNascita = @NazioneNascita, " & _
                                "Nazionalit‡ = @Nazionalit‡, " & _
                                "TipoDoc = @TipoDoc, " & _
                                "NumeroDocIdentit‡ = @NumeroDocIdentit‡, " & _
                                "DataRilascioDoc = @DataRilascioDoc, " & _
                                "RilasciatoDa = @RilasciatoDa, " & _
                                "Citt‡RilascioDoc = @Citt‡RilascioDoc, " & _
                                "NazioneRilascioDoc = @NazioneRilascioDoc, " & _
                                "Disabile = @Disabile, " & _
                                "InvioCorrisp = @InvioCorrisp, " & _
                                "Obsoleto = @Obsoleto, " & _
                                "TelCasa = @TelCasa, " & _
                                "TelUfficio = @TelUfficio, " & _
                                "Cell = @Cell, " & _
                                "Fax = @Fax, " & _
                                "Email = @Email, " & _
                                "Internet = @Internet, " & _
                                "CartaCredito = @CartaCredito, " & _
                                "TitolareCarta = @TitolareCarta, " & _
                                "NumCarta = @NumCarta, " & _
                                "ScadenzaCarta = @ScadenzaCarta, " & _
                                "TipoCliente = @TipoCliente, " & _
                                "TipoPagamento = @TipoPagamento, " & _
                                "Strutture = @Strutture, " & _
                                "Targa = @Targa, " & _
                                "Intestatario = @Intestatario, " & _
                                "[Note] = @Note, " & _
                                "Immagine = @Immagine, " & _
                                "Mercato = @Mercato, " & _
                                "Canale = @Canale, " & _
                                "Lingua = @Lingua, " & _
                                "Professione = @Professione, " & _
                                "[NoteVideo] = @NoteVideo, " & _
                                "[NoteStampa] = @NoteStampa, " & _
                                "Privacy = @Privacy, " & _
                                "InsPS = @InsPS, " & _
                                "NumComp = @NumComp, " & _
                                "Iva = @Iva, " & _
                                "Sconto = @Sconto, " & _
                                "NumeroDoc = @NumeroDoc " & _
                                "WHERE Id = {1}", _
                                 tabella, _
                                 codice)


            ' Crea il comando per la connessione corrente.
            Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

            cmdUpdate.Parameters.Add("@Mastro", Me.Mastro)
            cmdUpdate.Parameters.Add("@Titolo", Me.Titolo)
            cmdUpdate.Parameters.Add("@Nome", Me.Nome)
            cmdUpdate.Parameters.Add("@Cognome", Me.Cognome)
            cmdUpdate.Parameters.Add("@Sesso", Me.Sesso)
            cmdUpdate.Parameters.Add("@Indirizzo", Me.Indirizzo1)
            cmdUpdate.Parameters.Add("@Cap", Me.Cap)
            cmdUpdate.Parameters.Add("@Citt‡", Me.Citt‡)
            cmdUpdate.Parameters.Add("@Provincia", Me.Provincia)
            cmdUpdate.Parameters.Add("@Regione", Me.Regione)
            cmdUpdate.Parameters.Add("@Nazione", Me.Nazione)
            cmdUpdate.Parameters.Add("@CodFisc", Me.CodFisc)
            cmdUpdate.Parameters.Add("@Piva", Me.PIva)
            cmdUpdate.Parameters.Add("@DataNascita", Me.DataNascita)
            cmdUpdate.Parameters.Add("@LuogoNascita", Me.LuogoNascita)
            cmdUpdate.Parameters.Add("@ProvNascita", Me.ProvNascita)
            cmdUpdate.Parameters.Add("@NazioneNascita", Me.NazioneNascita)
            cmdUpdate.Parameters.Add("@Nazionalit‡", Me.Nazionalit‡)
            cmdUpdate.Parameters.Add("@TipoDoc", Me.TipoDoc)
            cmdUpdate.Parameters.Add("@NumeroDocIdentit‡", Me.NumeroDocIdentit‡)
            cmdUpdate.Parameters.Add("@DataRilascioDoc", Me.DataRilascioDoc)
            cmdUpdate.Parameters.Add("@RilasciatoDa", Me.RilasciatoDa)
            cmdUpdate.Parameters.Add("@Citt‡RilascioDoc", Me.Citt‡RilascioDoc)
            cmdUpdate.Parameters.Add("@NazioneRilascioDoc", Me.NazioneRilascioDoc)
            cmdUpdate.Parameters.Add("@Disabile", Me.Disabile)
            cmdUpdate.Parameters.Add("@InvioCorrisp", Me.InvioCorrisp)
            cmdUpdate.Parameters.Add("@Obsoleto", Me.Obsoleto)
            cmdUpdate.Parameters.Add("@TelCasa", Me.TelCasa)
            cmdUpdate.Parameters.Add("@TelUfficio", Me.TelUfficio)
            cmdUpdate.Parameters.Add("@Cell", Me.Cell)
            cmdUpdate.Parameters.Add("@Fax", Me.Fax)
            cmdUpdate.Parameters.Add("@Email", Me.Email)
            cmdUpdate.Parameters.Add("@Internet", Me.Internet)
            cmdUpdate.Parameters.Add("@CartaCredito", Me.CartaCredito)
            cmdUpdate.Parameters.Add("@TitolareCarta", Me.TitolareCarta)
            cmdUpdate.Parameters.Add("@NumCarta", Me.NumCarta)
            cmdUpdate.Parameters.Add("@ScadenzaCarta", Me.ScadenzaCarta)
            cmdUpdate.Parameters.Add("@TipoCliente", Me.TipoCliente)
            cmdUpdate.Parameters.Add("@TipoPagamento", Me.TipoPagamento)
            cmdUpdate.Parameters.Add("@Strutture", Me.Strutture)
            cmdUpdate.Parameters.Add("@Targa", Me.Targa)
            cmdUpdate.Parameters.Add("@Intestatario", Me.Intestatario)
            cmdUpdate.Parameters.Add("@Note", Me.Note)
            cmdUpdate.Parameters.Add("@Immagine", Me.Immagine)
            cmdUpdate.Parameters.Add("@Mercato", Me.Mercato)
            cmdUpdate.Parameters.Add("@Canale", Me.Canale)
            cmdUpdate.Parameters.Add("@Lingua", Me.Lingua)
            cmdUpdate.Parameters.Add("@Professione", Me.Professione)
            cmdUpdate.Parameters.Add("@NoteVideo", Me.NoteVideo)
            cmdUpdate.Parameters.Add("@NoteStampa", Me.NoteStampa)
            cmdUpdate.Parameters.Add("@Privacy", Me.Privacy)
            cmdUpdate.Parameters.Add("@InsPS", Me.InsPS)
            cmdUpdate.Parameters.Add("@NumComp", Me.NumComp)
            cmdUpdate.Parameters.Add("@Iva", Me.Iva)
            cmdUpdate.Parameters.Add("@Sconto", Me.Sconto)
            cmdUpdate.Parameters.Add("@NumeroDoc", Me.NumeroDoc)

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

   Public Class AziendaCliente
      Inherits Persona

      Public RagSociale As String
      Public Contatto As String
      Public Attivit‡ As String
      Public TipoCliente As String
      Public RagSocialeDest As String
      Public IndirizzoDest As String
      Public CapDest As String
      Public Citt‡Dest As String
      Public ProvDest As String
      Public NazioneDest As String
      Public TelDest As String
      Public FaxDest As String
      Public Banca As String
      Public Cin As String
      Public Abi As String
      Public Cab As String
      Public Cc As String
      Public Iban As String
      Public Listino As String
      Public Sconto As String
      Public Iva As String
      Public IvaInFatt As String
      Public CodIva As String
      Public Aliquota As String
      Public DescrizioneIva As String
      Public Puntualit‡ As String
      Public Privacy As String
      Public CodAzienda As String
      Public NoteDoc As String

      Private err As New Varie.Errore

      Private m_ConnString As String

      Public Property ConnString()
         Get
            Return m_ConnString
         End Get

         Set(ByVal Value)
            m_ConnString = Value
         End Set
      End Property

      Public Sub New(ByVal val As String)
         ' Imposta la stringa di connessione del database.
         Me.ConnString = val
      End Sub

      Private tr As OleDbTransaction

      Public Overridable Sub LeggiDati(ByVal tabella As String, ByVal codice As String)
         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(Me.ConnString)
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
            If IsDBNull(ds.Tables(tabella).Rows(0)("RagSociale")) = False Then
               Me.RagSociale = ds.Tables(tabella).Rows(0)("RagSociale")
            Else
               Me.RagSociale = ""
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
            If IsDBNull(ds.Tables(tabella).Rows(0)("Indirizzo")) = False Then
               Me.Indirizzo1 = ds.Tables(tabella).Rows(0)("Indirizzo")
            Else
               Me.Indirizzo1 = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Cap")) = False Then
               Me.Cap = ds.Tables(tabella).Rows(0)("Cap")
            Else
               Me.Cap = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Citt‡")) = False Then
               Me.Citt‡ = ds.Tables(tabella).Rows(0)("Citt‡")
            Else
               Me.Citt‡ = ""
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
            If IsDBNull(ds.Tables(tabella).Rows(0)("Contatto")) = False Then
               Me.Contatto = ds.Tables(tabella).Rows(0)("Contatto")
            Else
               Me.Contatto = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Attivit‡")) = False Then
               Me.Attivit‡ = ds.Tables(tabella).Rows(0)("Attivit‡")
            Else
               Me.Attivit‡ = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("RagioneSocialeDest")) = False Then
               Me.RagSocialeDest = ds.Tables(tabella).Rows(0)("RagioneSocialeDest")
            Else
               Me.RagSocialeDest = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("IndirizzoDest")) = False Then
               Me.IndirizzoDest = ds.Tables(tabella).Rows(0)("IndirizzoDest")
            Else
               Me.IndirizzoDest = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("CapDest")) = False Then
               Me.CapDest = ds.Tables(tabella).Rows(0)("CapDest")
            Else
               Me.CapDest = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Citt‡Dest")) = False Then
               Me.Citt‡Dest = ds.Tables(tabella).Rows(0)("Citt‡Dest")
            Else
               Me.Citt‡Dest = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("ProvinciaDest")) = False Then
               Me.ProvDest = ds.Tables(tabella).Rows(0)("ProvinciaDest")
            Else
               Me.ProvDest = ""
            End If

            If IsDBNull(ds.Tables(tabella).Rows(0)("NazioneDest")) = False Then
               Me.NazioneDest = ds.Tables(tabella).Rows(0)("NazioneDest")
            Else
               Me.NazioneDest = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("TelDest")) = False Then
               Me.TelDest = ds.Tables(tabella).Rows(0)("TelDest")
            Else
               Me.TelDest = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("FaxDest")) = False Then
               Me.FaxDest = ds.Tables(tabella).Rows(0)("FaxDest")
            Else
               Me.FaxDest = ""
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
            If IsDBNull(ds.Tables(tabella).Rows(0)("ModPagamento")) = False Then
               Me.TipoPagamento = ds.Tables(tabella).Rows(0)("ModPagamento")
            Else
               Me.TipoPagamento = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Banca")) = False Then
               Me.Banca = ds.Tables(tabella).Rows(0)("Banca")
            Else
               Me.Banca = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Cin")) = False Then
               Me.Cin = ds.Tables(tabella).Rows(0)("Cin")
            Else
               Me.Cin = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Abi")) = False Then
               Me.Abi = ds.Tables(tabella).Rows(0)("Abi")
            Else
               Me.Abi = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Cab")) = False Then
               Me.Cab = ds.Tables(tabella).Rows(0)("Cab")
            Else
               Me.Cab = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Cc")) = False Then
               Me.Cc = ds.Tables(tabella).Rows(0)("Cc")
            Else
               Me.Cc = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Iban")) = False Then
               Me.Iban = ds.Tables(tabella).Rows(0)("Iban")
            Else
               Me.Iban = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Listino")) = False Then
               Me.Listino = ds.Tables(tabella).Rows(0)("Listino")
            Else
               Me.Listino = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Sconto")) = False Then
               Me.Sconto = ds.Tables(tabella).Rows(0)("Sconto")
            Else
               Me.Sconto = VALORE_ZERO
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("IvaInFatt")) = False Then
               Me.IvaInFatt = ds.Tables(tabella).Rows(0)("IvaInFatt")
            Else
               Me.IvaInFatt = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("CodIva")) = False Then
               Me.CodIva = ds.Tables(tabella).Rows(0)("CodIva")
            Else
               Me.CodIva = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Aliquota")) = False Then
               Me.Aliquota = ds.Tables(tabella).Rows(0)("Aliquota")
            Else
               Me.Aliquota = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("DescrizioneIva")) = False Then
               Me.DescrizioneIva = ds.Tables(tabella).Rows(0)("DescrizioneIva")
            Else
               Me.DescrizioneIva = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Puntualit‡")) = False Then
               Me.Puntualit‡ = ds.Tables(tabella).Rows(0)("Puntualit‡")
            Else
               Me.Puntualit‡ = ""
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
            If IsDBNull(ds.Tables(tabella).Rows(0)("Immagine")) = False Then
               Me.Immagine = ds.Tables(tabella).Rows(0)("Immagine")
            Else
               Me.Immagine = Nothing
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Iva")) = False Then
               Me.Iva = ds.Tables(tabella).Rows(0)("Iva")
            Else
               Me.Iva = VALORE_ZERO
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Privacy")) = False Then
               Me.Privacy = ds.Tables(tabella).Rows(0)("Privacy")
            Else
               Me.Privacy = Nothing
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("Note")) = False Then
               Me.Note = ds.Tables(tabella).Rows(0)("Note")
            Else
               Me.Note = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("NoteDoc")) = False Then
               Me.NoteDoc = ds.Tables(tabella).Rows(0)("NoteDoc")
            Else
               Me.NoteDoc = ""
            End If
            If IsDBNull(ds.Tables(tabella).Rows(0)("CodAzienda")) = False Then
               Me.CodAzienda = ds.Tables(tabella).Rows(0)("CodAzienda")
            Else
               Me.CodAzienda = ""
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

      Public Overridable Function InserisciDati(ByVal tabella As String) As Boolean
         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(Me.ConnString)
         Dim sql As String

         Try
            ' Apre la connessione.
            cn.Open()

            ' Avvia una transazione.
            tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
            ' Crea la stringa di eliminazione.
            sql = String.Format("INSERT INTO {0} (RagSociale, Indirizzo, Cap, Citt‡, Provincia, Regione, Nazione, Contatto, " & _
                                                 "Attivit‡, Immagine, Piva, CodFisc, RagioneSocialeDest, IndirizzoDest, CapDest, " & _
                                                 "Citt‡Dest, ProvinciaDest, NazioneDest, TelDest, FaxDest, ModPagamento, " & _
                                                 "Banca, Cin, Abi, Cab, Cc, Iban, Listino, Sconto, IvaInfatt, CodIva, Aliquota, " & _
                                                 "DescrizioneIva, Puntualit‡, TelCasa, TelUfficio, Fax, Cell, " & _
                                                 "[Note], Email, Internet, Iva, Privacy, Titolo, CodAzienda, NoteDoc) " & _
                                          "VALUES('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', " & _
                                                 "'{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', " & _
                                                 "'{21}', '{22}', '{23}', '{24}', '{25}', '{26}', '{27}', '{28}', '{29}', '{30}', " & _
                                                 "'{31}', '{32}', '{33}', '{34}', '{35}', '{36}', '{37}', '{38}', '{39}', '{40}', " & _
                                                 "'{41}', '{42}', '{43}', '{44}', '{45}', '{46}')", _
                                                 tabella, _
                                                 Me.RagSociale, _
                                                 Me.Indirizzo1, _
                                                 Me.Cap, _
                                                 Me.Citt‡, _
                                                 Me.Provincia, _
                                                 Me.Regione, _
                                                 Me.Nazione, _
                                                 Me.Contatto, _
                                                 Me.Attivit‡, _
                                                 Me.Immagine, _
                                                 Me.PIva, _
                                                 Me.CodFisc, _
                                                 Me.RagSocialeDest, _
                                                 Me.IndirizzoDest, _
                                                 Me.CapDest, _
                                                 Me.Citt‡Dest, _
                                                 Me.ProvDest, _
                                                 Me.NazioneDest, _
                                                 Me.TelDest, _
                                                 Me.FaxDest, _
                                                 Me.TipoPagamento, _
                                                 Me.Banca, _
                                                 Me.Cin, _
                                                 Me.Abi, _
                                                 Me.Cab, _
                                                 Me.Cc, _
                                                 Me.Iban, _
                                                 Me.Listino, _
                                                 Me.Sconto, _
                                                 Me.IvaInFatt, _
                                                 Me.CodIva, _
                                                 Me.Aliquota, _
                                                 Me.DescrizioneIva, _
                                                 Me.Puntualit‡, _
                                                 Me.TelCasa, _
                                                 Me.TelUfficio, _
                                                 Me.Fax, _
                                                 Me.Cell, _
                                                 Me.Note, _
                                                 Me.Email, _
                                                 Me.Internet, _
                                                 Me.Iva, _
                                                 Me.Privacy, _
                                                 Me.Titolo, _
                                                 Me.CodAzienda, _
                                                 Me.NoteDoc)

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

      Public Overridable Function ModificaDati(ByVal tabella As String, ByVal codice As String) As Boolean
         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(Me.ConnString)
         Dim sql As String

         Try
            ' Apre la connessione.
            cn.Open()

            ' Avvia una transazione.
            tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

            ' Crea la stringa di eliminazione.
            sql = String.Format("UPDATE {0} " & _
                                "SET RagSociale = '{1}', " & _
                                "Indirizzo = '{2}', " & _
                                "Cap = '{3}', " & _
                                "Citt‡ = '{4}', " & _
                                "Provincia = '{5}', " & _
                                "Regione = '{6}', " & _
                                "Nazione = '{7}', " & _
                                "Contatto = '{8}', " & _
                                "Attivit‡ = '{9}', " & _
                                "Immagine = '{10}', " & _
                                "Piva = '{11}', " & _
                                "CodFisc = '{12}', " & _
                                "RagioneSocialeDest = '{13}', " & _
                                "IndirizzoDest = '{14}', " & _
                                "CapDest = '{15}', " & _
                                "Citt‡Dest = '{16}', " & _
                                "ProvinciaDest = '{17}', " & _
                                "NazioneDest = '{18}', " & _
                                "TelDest = '{19}', " & _
                                "FaxDest = '{20}', " & _
                                "ModPagamento = '{21}', " & _
                                "Banca = '{22}', " & _
                                "Cin = '{23}', " & _
                                "Abi = '{24}', " & _
                                "Cab = '{25}', " & _
                                "Cc = '{26}', " & _
                                "Iban = '{27}', " & _
                                "Listino = '{28}', " & _
                                "Sconto = '{29}', " & _
                                "IvaInfatt = '{30}', " & _
                                "CodIva = '{31}', " & _
                                "Aliquota = '{32}', " & _
                                "DescrizioneIva = '{33}', " & _
                                "Puntualit‡ = '{34}', " & _
                                "TelCasa = '{35}', " & _
                                "TelUfficio= '{36}', " & _
                                "Fax = '{37}', " & _
                                "Cell = '{38}', " & _
                                "[Note] = '{39}', " & _
                                "Email = '{40}', " & _
                                "Internet = '{41}', " & _
                                "Iva = '{42}', " & _
                                "Privacy = '{43}', " & _
                                "Titolo = '{44}', " & _
                                "CodAzienda = '{45}', " & _
                                "NoteDoc = '{46}' " & _
                                "WHERE Id = {47}", _
                                 tabella, _
                                 Me.RagSociale, _
                                 Me.Indirizzo1, _
                                 Me.Cap, _
                                 Me.Citt‡, _
                                 Me.Provincia, _
                                 Me.Regione, _
                                 Me.Nazione, _
                                 Me.Contatto, _
                                 Me.Attivit‡, _
                                 Me.Immagine, _
                                 Me.PIva, _
                                 Me.CodFisc, _
                                 Me.RagSocialeDest, _
                                 Me.IndirizzoDest, _
                                 Me.CapDest, _
                                 Me.Citt‡Dest, _
                                 Me.ProvDest, _
                                 Me.NazioneDest, _
                                 Me.TelDest, _
                                 Me.FaxDest, _
                                 Me.TipoPagamento, _
                                 Me.Banca, _
                                 Me.Cin, _
                                 Me.Abi, _
                                 Me.Cab, _
                                 Me.Cc, _
                                 Me.Iban, _
                                 Me.Listino, _
                                 Me.Sconto, _
                                 Me.IvaInFatt, _
                                 Me.CodIva, _
                                 Me.Aliquota, _
                                 Me.DescrizioneIva, _
                                 Me.Puntualit‡, _
                                 Me.TelCasa, _
                                 Me.TelUfficio, _
                                 Me.Fax, _
                                 Me.Cell, _
                                 Me.Note, _
                                 Me.Email, _
                                 Me.Internet, _
                                 Me.Iva, _
                                 Me.Privacy, _
                                 Me.Titolo, _
                                 Me.CodAzienda, _
                                 Me.NoteDoc, _
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

End Namespace

Namespace Tabelle

   Public Class Nazioni

   End Class

End Namespace
