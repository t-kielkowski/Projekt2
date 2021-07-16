using System;
using System.Collections.Generic;

#nullable disable

namespace Projekt2.ScaffoldModel
{
    public partial class RodzajZlecenium
    {
        public RodzajZlecenium()
        {
            Zlecenia = new HashSet<Zlecenium>();
        }

        public int IdRodzajZlecenia { get; set; }
        public int PotrzebnyCzasNaRealizacje { get; set; }
        public string NazwaRodzajZlecenia { get; set; }
        public string Opis { get; set; }

        public virtual ICollection<Zlecenium> Zlecenia { get; set; }
    }
}
