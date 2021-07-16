using System;
using System.Collections.Generic;

#nullable disable

namespace Projekt2.ScaffoldModel
{
    public partial class ListaSurowców
    {
        public int IdZlecenia { get; set; }
        public int IdSurowca { get; set; }

        public virtual SurowcePółprodukty IdSurowcaNavigation { get; set; }
        public virtual Zlecenium IdZleceniaNavigation { get; set; }
    }
}
