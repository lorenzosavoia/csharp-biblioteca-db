
using System.Data.SqlClient;
namespace csharp_biblioteca_db
{
    internal class db
    {
        //funzione per connettere il db
        private static string stringaDiConnessione = "Data Source=localhost;Initial Catalog=Biblioteca;Integrated Security=True;Pooling=False";
        private static SqlConnection Connect()
        {
            SqlConnection conn = new SqlConnection(stringaDiConnessione);
            
                try
                {
                    conn.Open();
           
                }catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
                return conn;
              
        }
        


        /*     insert into dbo.DOCUMENTI(Codice, Titolo, Settore, Stato, Tipo, Scaffale)
             Values(1, 'I PROMESSI SPOSI','Romanzo','disponibile','libro','S001')*/


        /*insert into dbo.Libri(Codice, NumPagine)
        Values(1,300)*/

        /*insert into dbo.Autori(Nome, Cognome, mail)
        Values('Alessandro','Manzoni','Alessandromanzoni@gmail.com')*/

        /*insert into Autori_documenti(codice_autore, codice_documento)
        values(1000,1)*/
        internal static int libroAdd(Libro libro, List<Autore> lsAutori)
        {
            //devo collegarmi e inviare un comando di insert del nuovo scaffale
            var conn = Connect();
            if (conn == null)
            {
                throw new Exception("Unable to connect to database");
            }
            var cmd = string.Format(@"insert into dbo.DOCUMENTI(Codice, Titolo, Settore, Stato, Tipo, Scaffale)
             Values({0}, '{1}','{2}','{3}','libro','{4}')", libro.Codice, libro.Titolo,libro.Settore,libro.Stato.ToString(),libro.Scaffale.Numero) ;

            using (SqlCommand insert = new SqlCommand(cmd, conn))
            {
                try
                {
                    var numrows = insert.ExecuteNonQuery();
                    if(numrows != 1)
                    {
                        throw new Exception("Valore di ritorno errato");
                    }
                 
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    conn.Close();
                    return 0;
                }
            }

            var cmd1 = string.Format("insert into dbo.Libri(Codice, NumPagine) Values({0}, {1}) ",libro.Codice,libro.NumeroPagine);

             using (SqlCommand insert = new SqlCommand(cmd1, conn))
             {
                    try
                    {
                        var numrows = insert.ExecuteNonQuery();

                        if (numrows != 1)
                        {
                            throw new Exception("Valore di ritorno errato");
                        }

                        
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        conn.Close();
                        return 0;
                    }

             }
            
             foreach (Autore autore in lsAutori)
            {
                var cmd2 = string.Format(@"insert into dbo.Autori(Codice,Nome, Cognome, mail) 
                        Values({0},'{1}','{2}','{3}')  ", autore.iCodiceAutore,autore.Nome, autore.Cognome, autore.sMail);

                using (SqlCommand insert = new SqlCommand(cmd2, conn))
                {
                    try
                    {
                        var numrows = insert.ExecuteNonQuery();

                        if (numrows != 1)
                        {
                            throw new Exception("Valore di ritorno errato");
                        }

                        
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        conn.Close();
                        return 0;
                    }

                }
            }
            foreach(Autore autore in lsAutori)
            {
                var cmd3 = string.Format(@"insert into Autori_documenti(codice_autore, codice_documento)
                                values({0},{1}) ",autore.iCodiceAutore, libro.Codice );

                using (SqlCommand insert = new SqlCommand(cmd3, conn))
                {
                    try
                    {
                        var numrows = insert.ExecuteNonQuery();

                        if (numrows != 1)
                        {
                            throw new Exception("Valore di ritorno errato");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        conn.Close();
                        return 0;
                    }                    
                }
            }
            conn.Close();
            return 0;
        }

        internal static int scaffaleAdd(string nuovo)
        {
            //devo collegarmi e inviare un comando di insert del nuovo scaffale
            var conn = Connect();
            if (conn == null)
            {
                throw new Exception("Unable to connect to database");
            }
            var cmd = string.Format("insert into Scaffale (Scaffale) values ('{0}')", nuovo);

            using (SqlCommand insert = new SqlCommand(cmd, conn))
            {
                try
                {
                    var numrows = insert.ExecuteNonQuery();
                    return numrows;
                }catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }finally
                {
                    conn.Close();
                }
            }
        }
        internal static List<string> scaffaliGet()
        {
            List<string> ls = new List<string>();
            var conn = Connect();
            if (conn == null)
            {
                throw new Exception("Unable to connect to database");
            }
            //query per prendere tutto lo scaffale dal db
            var cmd = string.Format("select Scaffale from Scaffale");

            using (SqlCommand query = new SqlCommand(cmd, conn))
            {
                using (SqlDataReader reader = query.ExecuteReader())
                {
                    Console.WriteLine(reader.FieldCount);
                    while (reader.Read())
                    {
                        ls.Add(reader.GetString(0));
                    }
                }
            }

            conn.Close();
            return ls;
        }
        //nel caso ci siano più attributi, allora potete utilizzare le tuple
        internal static List<Tuple<int, string, string, string, string, string>> documentiGet()
        {
            var ld = new List<Tuple<int, string, string, string, string, string>>();
            var conn = Connect();
            if (conn == null)
                throw new Exception("Unable to connect to the dabatase");
            var cmd = String.Format("select codice, Titolo, Settore, Stato, Tipo, Scaffale from Documenti");  //Li prendo tutti
            using (SqlCommand select = new SqlCommand(cmd, conn))
            {
                using (SqlDataReader reader = select.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var data = new Tuple<Int32, string, string, string, string, string>(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetString(4),
                            reader.GetString(5));
                        ld.Add(data);
                    }
                }
            }
            conn.Close();
            return ld;
        }
    }
}