﻿using System;
using System.Data.SqlClient;
using System.Windows;

namespace csharp_biblioteca_db // Note: actual namespace depends on the project name.
{
    public class Program
    {
        static void Main(string[] args)
        {
            Biblioteca b = new Biblioteca("Civica");

            /*StreamReader reader = new StreamReader("elenco.txt");
            string linea;
            while((linea = reader.ReadLine()) != null)
            {
                var vett= linea.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                string s = vett[0];
                var cn = s.Split(new char[] { ' ' });
                string nome = cn[0];

                string cognome = "";
                try
                {
                    cognome = s.Substring(cn[0].Length + 1);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                string titolo = vett[1];
                Console.WriteLine("Nome: {0}, Cognome: {1}, Titolo: {2}", nome, cognome, titolo);
                string mail = nome + "@" + cognome;
                List<Autore> lAutoriLibro = new List<Autore>();
                Autore AutoreMioLibro = new Autore(nome, cognome, mail);
                lAutoriLibro.Add(AutoreMioLibro);
                b.AggiungiLibro(db.GetUniqueId(), titolo, "vario", 4234, "S003", lAutoriLibro);

            }
            Environment.Exit(-1);*/


/*
            List<Autore> lAutoriLibro = new List<Autore>();
            Autore AutoreMioLibro = new Autore("Ciao", "Savpoasda", "giant.ddassas");
            lAutoriLibro.Add(AutoreMioLibro);
            b.AggiungiDvd(db.GetUniqueId(), "sono un dvd", "pazzo", 123, "S003", lAutoriLibro);

            db.documentiGet();*/
            /*b.AggiungiScaffale("s001");
            b.AggiungiScaffale("s002");
            b.AggiungiScaffale("s003");*/


            /*Console.WriteLine("Lista operazione: ");
            Console.WriteLine("\t1 : cercaLibro per Autore ");
            Console.WriteLine("Cosa vuoi fare ?");

            string sAppo = Console.ReadLine();*/

           /* while (sAppo != null)

            {
                if (sAppo == "1") b.GestisciOperazioneBiblioteca(1); 
            }*/

            /*

            Data Source=localhost;Initial Catalog=Biblioteca;Integrated Security=True;Pooling=False

            #region "Libro 1"
            Libro l1 = new Libro("ISBN1", "Titolo 1", 2009, "Storia", 220);

            Autore a1 = new Autore("Nome 1", "Cognome 1");
            Autore a2 = new Autore("Nome 2", "Cognome 2");

          
            #endregion

            #region "Libro 2"
            Libro l2 = new Libro("ISBN2", "Titolo 2", 2009, "Storia", 130);

            Autore a3 = new Autore("Nome 3", "Cognome 3");
            Autore a4 = new Autore("Nome 4", "Cognome 4");

            l2.Autori.Add(a3);
            l2.Autori.Add(a4);

            l2.Scaffale = s2;
            
            #endregion

            #region "DVD"
            DVD dvd1 = new DVD("Codice1", "Titolo 3", 2019, "Storia", 130);

            dvd1.Autori.Add(a3);

            dvd1.Scaffale = s3;
           
            #endregion

            Utente u1 = new Utente("Nome 1", "Cognome 1", "Telefono 1", "Email 1", "Password 1");

           

            Prestito p1 = new Prestito("P00001", new DateTime(2019, 1, 20), new DateTime(2019, 2, 20), u1, l1);
            Prestito p2 = new Prestito("P00002", new DateTime(2019, 3, 20), new DateTime(2019, 4, 20), u1, l2);

           

            Console.WriteLine("\n\nSearchByCodice: ISBN1\n\n");

            List<Documento> results = b.SearchByCodice("ISBN1");

            foreach (Documento doc in results)
            {
                Console.WriteLine(doc.ToString());

                if (doc.Autori.Count > 0)
                {
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("Autori");
                    Console.WriteLine("--------------------------");
                    foreach (Autore a in doc.Autori)
                    {
                        Console.WriteLine(a.ToString());
                        Console.WriteLine("--------------------------");
                    }
                }
            }

            Console.WriteLine("\n\nSearchPrestiti: Nome 1, Cognome 1\n\n");

            List<Prestito> prestiti = b.SearchPrestiti("Nome 1", "Cognome 1");

            foreach (Prestito p in prestiti)
            {
                Console.WriteLine(p.ToString());
                Console.WriteLine("--------------------------");
            }

            */

        }
       
    }
}
