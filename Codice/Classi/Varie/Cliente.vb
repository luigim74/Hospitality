Imports System.Data.OleDb

Public Class Cliente
   Inherits Persona

   Public TipoCliente As String
   Public AccompNome1 As String
   Public AccompNome2 As String
   Public AccompNome3 As String
   Public AccompNome4 As String
   Public AccompNome5 As String
   Public AccompDataNascita1 As String
   Public AccompDataNascita2 As String
   Public AccompDataNascita3 As String
   Public AccompDataNascita4 As String
   Public AccompDataNascita5 As String
   Public AccompLuogoNascita1 As String
   Public AccompLuogoNascita2 As String
   Public AccompLuogoNascita3 As String
   Public AccompLuogoNascita4 As String
   Public AccompLuogoNascita5 As String
   Public AccompResidenza1 As String
   Public AccompResidenza2 As String
   Public AccompResidenza3 As String
   Public AccompResidenza4 As String
   Public AccompResidenza5 As String
   Public CamereNum1 As String
   Public CamereNum2 As String
   Public CamereNum3 As String
   Public CamereNum4 As String
   Public CamereNum5 As String
   Public CamereData1 As String
   Public CamereData2 As String
   Public CamereData3 As String
   Public CamereData4 As String
   Public CamereData5 As String
   Public CamereNotti1 As String
   Public CamereNotti2 As String
   Public CamereNotti3 As String
   Public CamereNotti4 As String
   Public CamereNotti5 As String
   Public Strutture As String

   ' Dichiara un oggetto connessione.
   Dim cn As New OleDbConnection(ConnString)
   Dim tr As OleDbTransaction

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
         If IsDBNull(ds.Tables(tabella).Rows(0)("DataScadenzaDoc")) = False Then
            Me.DataScadenzaDoc = ds.Tables(tabella).Rows(0)("DataScadenzaDoc")
         Else
            Me.DataScadenzaDoc = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("NumeroDoc")) = False Then
            Me.NumeroDoc = ds.Tables(tabella).Rows(0)("NumeroDoc")
         Else
            Me.NumeroDoc = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("RilasciatoDa")) = False Then
            Me.RilasciatoDa = ds.Tables(tabella).Rows(0)("RilasciatoDa")
         Else
            Me.RilasciatoDa = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("TipoCliente")) = False Then
            Me.TipoCliente = ds.Tables(tabella).Rows(0)("TipoCliente")
         Else
            Me.TipoCliente = ""
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
         If IsDBNull(ds.Tables(tabella).Rows(0)("InvioCorrisp")) = False Then
            Me.InvioCorrisp = ds.Tables(tabella).Rows(0)("InvioCorrisp")
         Else
            Me.InvioCorrisp = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Disabile")) = False Then
            Me.Disabile = ds.Tables(tabella).Rows(0)("Disabile")
         Else
            Me.Disabile = ""
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
         If IsDBNull(ds.Tables(tabella).Rows(0)("AccompNome1")) = False Then
            Me.AccompNome1 = ds.Tables(tabella).Rows(0)("AccompNome1")
         Else
            Me.AccompNome1 = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("AccompNome2")) = False Then
            Me.AccompNome2 = ds.Tables(tabella).Rows(0)("AccompNome2")
         Else
            Me.AccompNome2 = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("AccompNome3")) = False Then
            Me.AccompNome3 = ds.Tables(tabella).Rows(0)("AccompNome3")
         Else
            Me.AccompNome3 = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("AccompNome4")) = False Then
            Me.AccompNome4 = ds.Tables(tabella).Rows(0)("AccompNome4")
         Else
            Me.AccompNome4 = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("AccompNome5")) = False Then
            Me.AccompNome5 = ds.Tables(tabella).Rows(0)("AccompNome5")
         Else
            Me.AccompNome5 = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("AccompDataNascita1")) = False Then
            Me.AccompDataNascita1 = ds.Tables(tabella).Rows(0)("AccompDataNascita1")
         Else
            Me.AccompDataNascita1 = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("AccompDataNascita2")) = False Then
            Me.AccompDataNascita2 = ds.Tables(tabella).Rows(0)("AccompDataNascita2")
         Else
            Me.AccompDataNascita2 = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("AccompDataNascita3")) = False Then
            Me.AccompDataNascita3 = ds.Tables(tabella).Rows(0)("AccompDataNascita3")
         Else
            Me.AccompDataNascita3 = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("AccompDataNascita4")) = False Then
            Me.AccompDataNascita4 = ds.Tables(tabella).Rows(0)("AccompDataNascita4")
         Else
            Me.AccompDataNascita4 = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("AccompDataNascita5")) = False Then
            Me.AccompDataNascita5 = ds.Tables(tabella).Rows(0)("AccompDataNascita5")
         Else
            Me.AccompDataNascita5 = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("AccompLuogoNascita1")) = False Then
            Me.AccompLuogoNascita1 = ds.Tables(tabella).Rows(0)("AccompLuogoNascita1")
         Else
            Me.AccompLuogoNascita1 = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("AccompLuogoNascita2")) = False Then
            Me.AccompLuogoNascita2 = ds.Tables(tabella).Rows(0)("AccompLuogoNascita2")
         Else
            Me.AccompLuogoNascita2 = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("AccompLuogoNascita3")) = False Then
            Me.AccompLuogoNascita3 = ds.Tables(tabella).Rows(0)("AccompLuogoNascita3")
         Else
            Me.AccompLuogoNascita3 = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("AccompLuogoNascita4")) = False Then
            Me.AccompLuogoNascita4 = ds.Tables(tabella).Rows(0)("AccompLuogoNascita4")
         Else
            Me.AccompLuogoNascita4 = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("AccompLuogoNascita5")) = False Then
            Me.AccompLuogoNascita5 = ds.Tables(tabella).Rows(0)("AccompLuogoNascita5")
         Else
            Me.AccompLuogoNascita5 = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("AccompResidenza1")) = False Then
            Me.AccompResidenza1 = ds.Tables(tabella).Rows(0)("AccompResidenza1")
         Else
            Me.AccompResidenza1 = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("AccompResidenza2")) = False Then
            Me.AccompResidenza2 = ds.Tables(tabella).Rows(0)("AccompResidenza2")
         Else
            Me.AccompResidenza2 = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("AccompResidenza3")) = False Then
            Me.AccompResidenza3 = ds.Tables(tabella).Rows(0)("AccompResidenza3")
         Else
            Me.AccompResidenza3 = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("AccompResidenza4")) = False Then
            Me.AccompResidenza4 = ds.Tables(tabella).Rows(0)("AccompResidenza4")
         Else
            Me.AccompResidenza4 = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("AccompResidenza5")) = False Then
            Me.AccompResidenza5 = ds.Tables(tabella).Rows(0)("AccompResidenza5")
         Else
            Me.AccompResidenza5 = ""
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
         ' Visualizza un messaggio di errore.
         MessageBox.Show(ex.Message)

      Finally
         da.Dispose()
         ds.Dispose()
         ' Chiude la connessione.
         cn.Close()
      End Try
   End Sub

   Public Sub InserisciDati(ByVal tabella As String)
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
         ' Crea la stringa di eliminazione.
         sql = String.Format("INSERT INTO {0} (Nome, AccompDataNascita1, AccompDataNascita2, AccompDataNascita3, AccompDataNascita4, AccompDataNascita5, AccompLuogoNascita1, " & _
                                              "AccompLuogoNascita2, AccompLuogoNascita3, AccompLuogoNascita4, AccompLuogoNascita5, AccompNome1, AccompNome2, AccompNome3, " & _
                                              "AccompNome4, AccompNome5, AccompResidenza1, AccompResidenza2, AccompResidenza3, AccompResidenza4, AccompResidenza5, CamereData1, " & _
                                              "CamereData2, CamereData3, CamereData4, CamereData5, CamereNotti1, CamereNotti2, CamereNotti3, CamereNotti4, CamereNotti5, CamereNum1, " & _
                                              "CamereNum2, CamereNum3, CamereNum4, CamereNum5, Cap, Cell, Città, CodFisc, Cognome, DataNascita, DataRilascioDoc, DataScadenzaDoc, " & _
                                              "Disabile, Email, Fax, Indirizzo1, Indirizzo2, InvioCorrisp, LuogoNascita, Nazione, NazioneNascita, NumCarta, NumeroDoc, Piva, " & _
                                              "Provincia, ProvNascita, Regione, RilasciatoDa, ScadenzaCarta, Sesso, Strutture, Targa, TelCasa, TelUfficio, TipoCliente, TipoDoc, TipoPagamento, " & _
                                              "TitolareCarta, Titolo, [Note], Immagine) " & _
                                       "VALUES('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', " & _
                                              "'{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', " & _
                                              "'{21}', '{22}', '{23}', '{24}', '{25}', '{26}', '{27}', '{28}', '{29}', '{30}', " & _
                                              "'{31}', '{32}', '{33}', '{34}', '{35}', '{36}', '{37}', '{38}', '{39}', '{40}', " & _
                                              "'{41}', '{42}', '{43}', '{44}', '{45}', '{46}', '{47}', '{48}', '{49}', '{50}', " & _
                                              "'{51}', '{52}', '{53}', '{54}', '{55}', '{56}', '{57}', '{58}', '{59}', '{60}', " & _
                                              "'{61}', '{62}', '{63}', '{64}', '{65}', '{66}', '{67}', '{68}', '{69}', '{70}', " & _
                                              "'{71}', '{72}', '{73}')", tabella, _
                                              Me.Nome, _
                                              Me.AccompDataNascita1, _
                                              Me.AccompDataNascita2, _
                                              Me.AccompDataNascita3, _
                                              Me.AccompDataNascita4, _
                                              Me.AccompDataNascita5, _
                                              Me.AccompLuogoNascita1, _
                                              Me.AccompLuogoNascita2, _
                                              Me.AccompLuogoNascita3, _
                                              Me.AccompLuogoNascita4, _
                                              Me.AccompLuogoNascita5, _
                                              Me.AccompNome1, _
                                              Me.AccompNome2, _
                                              Me.AccompNome3, _
                                              Me.AccompNome4, _
                                              Me.AccompNome5, _
                                              Me.AccompResidenza1, _
                                              Me.AccompResidenza2, _
                                              Me.AccompResidenza3, _
                                              Me.AccompResidenza4, _
                                              Me.AccompResidenza5, _
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
                                              Me.Cognome, _
                                              Me.DataNascita, _
                                              Me.DataRilascioDoc, _
                                              Me.DataScadenzaDoc, _
                                              Me.Disabile, _
                                              Me.Email, _
                                              Me.Fax, _
                                              Me.Indirizzo1, _
                                              Me.Indirizzo2, _
                                              Me.InvioCorrisp, _
                                              Me.LuogoNascita, _
                                              Me.Nazione, _
                                              Me.NazioneNascita, _
                                              Me.NumCarta, _
                                              Me.NumeroDoc, _
                                              Me.PIva, _
                                              Me.Provincia, _
                                              Me.ProvNascita, _
                                              Me.Regione, _
                                              Me.RilasciatoDa, _
                                              Me.ScadenzaCarta, _
                                              Me.Sesso, _
                                              Me.Strutture, _
                                              Me.Targa, _
                                              Me.TelCasa, _
                                              Me.TelUfficio, _
                                              Me.TipoCliente, _
                                              Me.TipoDoc, _
                                              Me.TipoPagamento, _
                                              Me.TitolareCarta, _
                                              Me.Titolo, _
                                              Me.Note, _
                                              Me.Immagine)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)
         ' Esegue il comando.
         Dim Record As Integer = cmdInsert.ExecuteNonQuery()

         ' Conferma transazione.
         tr.Commit()

      Catch ex As Exception
         ' Annulla transazione.
         tr.Rollback()

         ' Visualizza un messaggio di errore.
         MessageBox.Show(ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Sub

   Public Sub ModificaDati(ByVal tabella As String, ByVal codice As String)
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} " & _
                             "SET Nome = '{1}', " & _
                             "AccompDataNascita1 = '{2}', " & _
                             "AccompDataNascita2 = '{3}', " & _
                             "AccompDataNascita3 = '{4}', " & _
                             "AccompDataNascita4 = '{5}', " & _
                             "AccompDataNascita5 = '{6}', " & _
                             "AccompLuogoNascita1 = '{7}', " & _
                             "AccompLuogoNascita2 = '{8}', " & _
                             "AccompLuogoNascita3 = '{9}', " & _
                             "AccompLuogoNascita4 = '{10}', " & _
                             "AccompLuogoNascita5 = '{11}', " & _
                             "AccompNome1 = '{12}', " & _
                             "AccompNome2 = '{13}', " & _
                             "AccompNome3 = '{14}', " & _
                             "AccompNome4 = '{15}', " & _
                             "AccompNome5 = '{16}', " & _
                             "AccompResidenza1 = '{17}', " & _
                             "AccompResidenza2 = '{18}', " & _
                             "AccompResidenza3 = '{19}', " & _
                             "AccompResidenza4 = '{20}', " & _
                             "AccompResidenza5 = '{21}', " & _
                             "CamereData1 = '{22}', " & _
                             "CamereData2 = '{23}', " & _
                             "CamereData3 = '{24}', " & _
                             "CamereData4 = '{25}', " & _
                             "CamereData5 = '{26}', " & _
                             "CamereNotti1 = '{27}', " & _
                             "CamereNotti2 = '{28}', " & _
                             "CamereNotti3 = '{29}', " & _
                             "CamereNotti4 = '{30}', " & _
                             "CamereNotti5 = '{31}', " & _
                             "CamereNum1 = '{32}', " & _
                             "CamereNum2 = '{33}', " & _
                             "CamereNum3 = '{34}', " & _
                             "CamereNum4 = '{35}', " & _
                             "CamereNum5 = '{36}', " & _
                             "Cap = '{37}', " & _
                             "Cell = '{38}', " & _
                             "Città = '{39}', " & _
                             "CodFisc = '{40}', " & _
                             "Cognome = '{41}', " & _
                             "DataNascita = '{42}', " & _
                             "DataRilascioDoc = '{43}', " & _
                             "DataScadenzaDoc = '{44}', " & _
                             "Disabile = '{45}', " & _
                             "Email = '{46}', " & _
                             "Fax = '{47}', " & _
                             "Indirizzo1 = '{48}', " & _
                             "Indirizzo2 = '{49}', " & _
                             "InvioCorrisp = '{50}', " & _
                             "LuogoNascita = '{51}', " & _
                             "Nazione = '{52}', " & _
                             "NazioneNascita = '{53}', " & _
                             "NumCarta = '{54}', " & _
                             "NumeroDoc = '{55}', " & _
                             "PIva = '{56}', " & _
                             "Provincia = '{57}', " & _
                             "ProvNascita = '{58}', " & _
                             "Regione = '{59}', " & _
                             "RilasciatoDa = '{60}', " & _
                             "ScadenzaCarta = '{61}', " & _
                             "Sesso = '{62}', " & _
                             "Strutture = '{63}', " & _
                             "Targa = '{64}', " & _
                             "TelCasa = '{65}', " & _
                             "TelUfficio = '{66}', " & _
                             "TipoCliente = '{67}', " & _
                             "TipoDoc = '{68}', " & _
                             "TipoPagamento = '{69}', " & _
                             "TitolareCarta = '{70}', " & _
                             "Titolo = '{71}', " & _
                             "[Note] = '{72}', " & _
                             "Immagine = '{73}' " & _
                             "WHERE Id = {74}", _
                              tabella, _
                              Me.Nome, _
                              Me.AccompDataNascita1, _
                              Me.AccompDataNascita2, _
                              Me.AccompDataNascita3, _
                              Me.AccompDataNascita4, _
                              Me.AccompDataNascita5, _
                              Me.AccompLuogoNascita1, _
                              Me.AccompLuogoNascita2, _
                              Me.AccompLuogoNascita3, _
                              Me.AccompLuogoNascita4, _
                              Me.AccompLuogoNascita5, _
                              Me.AccompNome1, _
                              Me.AccompNome2, _
                              Me.AccompNome3, _
                              Me.AccompNome4, _
                              Me.AccompNome5, _
                              Me.AccompResidenza1, _
                              Me.AccompResidenza2, _
                              Me.AccompResidenza3, _
                              Me.AccompResidenza4, _
                              Me.AccompResidenza5, _
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
                              Me.Cognome, _
                              Me.DataNascita, _
                              Me.DataRilascioDoc, _
                              Me.DataScadenzaDoc, _
                              Me.Disabile, _
                              Me.Email, _
                              Me.Fax, _
                              Me.Indirizzo1, _
                              Me.Indirizzo2, _
                              Me.InvioCorrisp, _
                              Me.LuogoNascita, _
                              Me.Nazione, _
                              Me.NazioneNascita, _
                              Me.NumCarta, _
                              Me.NumeroDoc, _
                              Me.PIva, _
                              Me.Provincia, _
                              Me.ProvNascita, _
                              Me.Regione, _
                              Me.RilasciatoDa, _
                              Me.ScadenzaCarta, _
                              Me.Sesso, _
                              Me.Strutture, _
                              Me.Targa, _
                              Me.TelCasa, _
                              Me.TelUfficio, _
                              Me.TipoCliente, _
                              Me.TipoDoc, _
                              Me.TipoPagamento, _
                              Me.TitolareCarta, _
                              Me.Titolo, _
                              Me.Note, _
                              Me.Immagine, _
                              codice)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)
         ' Esegue il comando.
         Dim Record As Integer = cmdUpdate.ExecuteNonQuery()

         ' Conferma transazione.
         tr.Commit()

      Catch ex As Exception
         ' Annulla transazione.
         tr.Rollback()

         ' Visualizza un messaggio di errore.
         MessageBox.Show(ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()
      End Try
   End Sub
End Class
