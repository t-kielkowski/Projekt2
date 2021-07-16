using System;
using System.Collections.Generic;

#nullable disable

namespace Projekt2.ScaffoldModel
{
    public partial class Dostawcy
    {
        public Dostawcy()
        {
            SurowceDostawcies = new HashSet<SurowceDostawcy>();
            ZamówieniaDostawcies = new HashSet<ZamówieniaDostawcy>();
        }

        public int IdDostawcy { get; set; }
        public string NazwaFirmy { get; set; }
        public string Adres { get; set; }
        public string KodPocztowy { get; set; }
        public string Miasto { get; set; }
        public string Kraj { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public DateTime DataZawarciaUmowy { get; set; }
        public int OkresZawarciaUmowy { get; set; }
        public int GwarantowanyTerminDostaw { get; set; }

        public virtual ICollection<SurowceDostawcy> SurowceDostawcies { get; set; }
        public virtual ICollection<ZamówieniaDostawcy> ZamówieniaDostawcies { get; set; }
    }
}
