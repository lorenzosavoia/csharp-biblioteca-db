using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca_db
{
    public class Autore : Persona
    {
        public string sMail { get; set; }
        public long iCodiceAutore { get; set; }
        public Autore(string Nome, string Cognome, string sMail) : base(Nome, Cognome)
        {
            this.sMail = sMail;
            iCodiceAutore = GeneraCodiceAutore();   
        }
        public long GeneraCodiceAutore()
        {
            return db.GetUniqueId();
        }
    }
}
