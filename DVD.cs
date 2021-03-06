using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca_db
{
    public class DVD : Documento
    {
        public int Durata { get; set; }

        public DVD(long Codice, string Titolo, string Settore, int Durata, string nomeScaffale) : base(Codice, Titolo, Settore, nomeScaffale)
        {
            this.Durata = Durata;
        }

        public override string ToString()
        {
            return string.Format("{0}\nDurata:{1}",
                base.ToString(),
                this.Durata);
        }
    }
}
