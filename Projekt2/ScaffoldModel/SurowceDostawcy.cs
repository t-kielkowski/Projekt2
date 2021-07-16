using System;
using System.Collections.Generic;

#nullable disable

namespace Projekt2.ScaffoldModel
{
    public partial class SurowceDostawcy
    {
        public int IdSurowca { get; set; }
        public int IdDostawcy { get; set; }

        public virtual Dostawcy IdDostawcyNavigation { get; set; }
        public virtual SurowcePółprodukty IdSurowcaNavigation { get; set; }
    }
}
