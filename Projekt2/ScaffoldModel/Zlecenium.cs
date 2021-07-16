using System;
using System.Collections.Generic;

#nullable disable

namespace Projekt2.ScaffoldModel
{
    public partial class Zlecenium
    {
        public Zlecenium()
        {
            ListaSurowcóws = new HashSet<ListaSurowców>();
        }

        public int IdZlecenia { get; set; }
        public string NazwaTowaru { get; set; }
        public DateTime DataPrzyjecia { get; set; }
        public DateTime? DataRozpoczecia { get; set; }
        public DateTime? NieprzekraczalnyTerminWykonania { get; set; }
        public DateTime? RzeczywistaDataZakonczenia { get; set; }
        public int? IdRodzajZlecenia { get; set; }
        public int? IdStatusu { get; set; }

        public virtual RodzajZlecenium IdRodzajZleceniaNavigation { get; set; }
        public virtual StatusZlecenium IdStatusuNavigation { get; set; }
        public virtual ICollection<ListaSurowców> ListaSurowcóws { get; set; }
    }
}
