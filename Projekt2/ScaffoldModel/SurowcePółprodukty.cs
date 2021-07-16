using System;
using System.Collections.Generic;

#nullable disable

namespace Projekt2.ScaffoldModel
{
    public partial class SurowcePółprodukty
    {
        public SurowcePółprodukty()
        {
            ListaSurowcóws = new HashSet<ListaSurowców>();
            PozycjeZamówienia = new HashSet<PozycjeZamówienium>();
            SurowceDostawcies = new HashSet<SurowceDostawcy>();
        }

        public int IdSurowca { get; set; }
        public string NazwaSurowca { get; set; }
        public string IlośćJednostkowa { get; set; }
        public decimal? CenaJednostkowa { get; set; }

        public virtual ICollection<ListaSurowców> ListaSurowcóws { get; set; }
        public virtual ICollection<PozycjeZamówienium> PozycjeZamówienia { get; set; }
        public virtual ICollection<SurowceDostawcy> SurowceDostawcies { get; set; }
    }
}
