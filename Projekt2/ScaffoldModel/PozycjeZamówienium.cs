using System;
using System.Collections.Generic;

#nullable disable

namespace Projekt2.ScaffoldModel
{
    public partial class PozycjeZamówienium
    {
        public int IdZamówienia { get; set; }
        public int IdSurowca { get; set; }
        public short Ilość { get; set; }
        public decimal CenaJednostkowa { get; set; }
        public decimal? WartośćPozycji { get; set; }

        public virtual SurowcePółprodukty IdSurowcaNavigation { get; set; }
        public virtual Zamówienium IdZamówieniaNavigation { get; set; }
    }
}
