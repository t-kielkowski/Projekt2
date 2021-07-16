using System;
using System.Collections.Generic;

#nullable disable

namespace Projekt2.ScaffoldModel
{
    public partial class StatusZlecenium
    {
        public StatusZlecenium()
        {
            Zlecenia = new HashSet<Zlecenium>();
        }

        public int IdStatusu { get; set; }
        public string StatusZlecenia { get; set; }

        public virtual ICollection<Zlecenium> Zlecenia { get; set; }
    }
}
