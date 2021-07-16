using System;
using System.Collections.Generic;

#nullable disable

namespace Projekt2.ScaffoldModel
{
    public partial class Zamówienium
    {
        public Zamówienium()
        {
            PozycjeZamówienia = new HashSet<PozycjeZamówienium>();
            ZamówieniaDostawcies = new HashSet<ZamówieniaDostawcy>();
        }

        public int IdZamówienia { get; set; }
        public DateTime DataZamówienia { get; set; }
        public DateTime DataWymagana { get; set; }
        public DateTime? DataWysyłki { get; set; }

        public virtual ICollection<PozycjeZamówienium> PozycjeZamówienia { get; set; }
        public virtual ICollection<ZamówieniaDostawcy> ZamówieniaDostawcies { get; set; }
    }
}
