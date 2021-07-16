using System;
using System.Collections.Generic;

#nullable disable

namespace Projekt2.ScaffoldModel
{
    public partial class ZamówieniaDostawcy
    {
        public int IdZamówienia { get; set; }
        public int IdDostawcy { get; set; }

        public virtual Dostawcy IdDostawcyNavigation { get; set; }
        public virtual Zamówienium IdZamówieniaNavigation { get; set; }
    }
}
