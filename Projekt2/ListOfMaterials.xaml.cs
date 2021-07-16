using Microsoft.EntityFrameworkCore;
using Projekt2.ScaffoldModel;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Projekt2
{
    /// <summary>
    /// Logika interakcji dla klasy ListOfMaterials.xaml
    /// </summary>
    public partial class ListOfMaterials : Window
    {
        public int IdZlecenia;

        public ListOfMaterials()
        {
            InitializeComponent();
            LoadMaterialsList();
            DataContext = this;
        }


        public ListOfMaterials(int IdRz, int idZl)
        {
            InitializeComponent();
            LoadMaterialsListByIdRz(IdRz, idZl);
            DataContext = this;
        }

        private void LoadMaterialsList()
        {
            List<Zlecenium> zlecenia = (List<Zlecenium>)DataBaseService.AllOrders();
            var numberOfOrders = zlecenia.Count;


            for (int i = 0; i < numberOfOrders; i++)
            {
                var idRz = (int)zlecenia[i].IdRodzajZlecenia;
                var idZl = (int)zlecenia[i].IdZlecenia;
                LoadMaterialsListByIdRz(idRz, idZl);
            }
        }


        private void LoadMaterialsListByIdRz(int IdRz, int idZl)
        {
            //lstMaterials.Items.Clear();

            if (IdRz == 1)
            {
                LoadSpecyficMaterial(1, idZl);
                LoadSpecyficMaterial(2, idZl);
                LoadSpecyficMaterial(3, idZl);
            }


            else if (IdRz == 2)
            {
                LoadSpecyficMaterial(4, idZl);
                LoadSpecyficMaterial(5, idZl);
                LoadSpecyficMaterial(1, idZl);
            }


            else if (IdRz == 3)
            {
                LoadSpecyficMaterial(5, idZl);
                LoadSpecyficMaterial(2, idZl);
                LoadSpecyficMaterial(10, idZl);
            }


            else if (IdRz == 4)
            {
                LoadSpecyficMaterial(9, idZl);
                LoadSpecyficMaterial(8, idZl);
                LoadSpecyficMaterial(11, idZl);
            }


            else if (IdRz == 5)
            {
                LoadSpecyficMaterial(4, idZl);
                LoadSpecyficMaterial(7, idZl);
                LoadSpecyficMaterial(12, idZl);
            }


            else if (IdRz == 6)
            {
                LoadSpecyficMaterial(10, idZl);
                LoadSpecyficMaterial(11, idZl);
                LoadSpecyficMaterial(4, idZl);
            }


            else if (IdRz == 7)
            {
                LoadSpecyficMaterial(1, idZl);
                LoadSpecyficMaterial(2, idZl);
                LoadSpecyficMaterial(3, idZl);
            }


            else if (IdRz == 8)
            {
                LoadSpecyficMaterial(3, idZl);
                LoadSpecyficMaterial(9, idZl);
                LoadSpecyficMaterial(10, idZl);
            }

            else if (IdRz == 9)
            {
                LoadSpecyficMaterial(8, idZl);
                LoadSpecyficMaterial(6, idZl);
                LoadSpecyficMaterial(7, idZl);
            }

            else if (IdRz == 10)
            {
                LoadSpecyficMaterial(2, idZl);
                LoadSpecyficMaterial(12, idZl);
                LoadSpecyficMaterial(9, idZl);
            }

        }

        public void LoadSpecyficMaterial(int material, int idZl)
        {
            var surowce = DataBaseService.RawMaterials();

            var item = new
            {
                IdZlecenia = idZl,
                IdSurowca = surowce.Where(x => x.IdSurowca == material).Select(x => x.IdSurowca).LastOrDefault(),
                NazwaSurowca = surowce.Where(x => x.IdSurowca == material).Select(x => x.NazwaSurowca).LastOrDefault(),
                IlośćJednostkowa = surowce.Where(x => x.IdSurowca == material).Select(x => x.IlośćJednostkowa).LastOrDefault(),
                CenaJednostkowa = surowce.Where(x => x.IdSurowca == material).Select(x => x.CenaJednostkowa).LastOrDefault()
            };

            lstMaterials.Items.Add(item);

        }

        private void btnWyjdz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
