using Projekt2.ScaffoldModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Projekt2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<string> ComboBoxListStat { get; set; }
        public List<string> ComboBoxListOrderNames { get; set; }


        public MainWindow()
        {
            InitializeComponent();
            ComboBoxListStat = ComboList.ListStatNamesAdditional();
            ComboBoxListOrderNames = ComboList.ListOrderNamesAdditional();
            DataContext = this;
            LoadProductList(DataBaseService.AllOrders());
        }



        private void btnDeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            DeleteOrder();
            LoadProductList(DataBaseService.AllOrders());
        }


        private void btnChangeStat_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (Zlecenium)lstOrders.SelectedItem;


            if (lstOrders.SelectedIndex == -1)
            {
                MessageClass.MessageErrorWithDefaultCaption("Wybierz zleceni do którego chcesz zmienić status");
            }
            else if (selectedItem.IdStatusu == 3)
            {
                MessageClass.MessageErrorWithDefaultCaption("Nie można edytować zleceń ukończonych");
            }
            else
            {
                SelectStatus window = new SelectStatus();
                window.ShowDialog();
                var status = window.Status;

                int stat = TransformIdFromText(status);


                DataBaseService.ChangeOrderStat(selectedItem, stat);
                LoadProductList(DataBaseService.AllOrders());
            }
        }



        private void btnShowMaterials_Click(object sender, RoutedEventArgs e)
        {
            if (lstOrders.SelectedIndex == -1)
            {
                MessageClass.MessageErrorWithDefaultCaption("Wybierz zlecenie do którego chcesz wyświetlić produkty");
            }
            else
            {
                var selectedItem = (Zlecenium)lstOrders.SelectedItem;
                var IdRz = (int)selectedItem.IdRodzajZlecenia;
                var IdZl = (int)selectedItem.IdZlecenia;

                ListOfMaterials window = new ListOfMaterials(IdRz, IdZl);
                window.ShowDialog();
            }
        }


        private void btnShowBy_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(cbStat.Text) || string.IsNullOrEmpty(cbIdRZ.Text))
            {
                MessageClass.MessageErrorWithDefaultCaption("Wybierz które zlecenia chcesz wyświetlić");
            }
            else
            {
                string stat = cbStat.Text;
                string idRzl = cbIdRZ.Text;
                int idStat = TransformIdFromText(stat);

                if (idStat == 0 && idRzl == "Wszystkie") LoadProductList(DataBaseService.AllOrders());
                else if (idStat == 0 && idRzl != "Wszystkie") LoadOrdersBy(idRz: idRzl);
                else if (idStat != 0 && idRzl == "Wszystkie") LoadOrdersBy(idSta: idStat);
                else LoadOrdersBy(idStat, idRzl);
            }

        }


        private void btnShowByDate_Click(object sender, RoutedEventArgs e)
        {

            if (startDate.SelectedDate == null || endDate.SelectedDate == null)
            {
                MessageClass.MessageErrorWithDefaultCaption("Wybierz zakres dat który chcesz wyświetlić");
            }
            else
            {
                DateTime start = DateTime.Parse(startDate.Text);
                DateTime end = DateTime.Parse(endDate.Text);

                if (start.AddDays(5) > end)
                {
                    MessageClass.MessageErrorWithDefaultCaption(
                        "Przedział czasowy pomiędzy zakresami musi wynosić minimum 5 dni");
                }
                else
                {
                    var zleceniaByDate = DataBaseService.OrdersSelectedByDate(start, end);
                    LoadProductList(zleceniaByDate);
                }
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            startDate.SelectedDate = null;
            endDate.SelectedDate = null;
            cbStat.SelectedItem = null;
            cbIdRZ.SelectedItem = null;
            LoadProductList(DataBaseService.AllOrders());
        }


        private void btnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            var window = new NewOrder();
            window.ShowDialog();
            LoadProductList(DataBaseService.AllOrders());
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            ListOfMaterials window = new ListOfMaterials();
            window.ShowDialog();

        }


        private void DeleteOrder()
        {
            if (lstOrders.SelectedIndex == -1)
            {
                MessageClass.MessageErrorWithDefaultCaption("Wybierz zleceni które chcesz usunąć");
            }
            else
            {
                var selectedItem = (Zlecenium)lstOrders.SelectedItem;
                DataBaseService.DeleteOrder(selectedItem);
            }
        }


        private void LoadOrdersBy(int idSta = 0, string idRz = "Wszystkie")
        {
            var zlecenia = DataBaseService.AllOrders();
            IEnumerable<Zlecenium> zleceniaById;

            if (idSta == 0)
            {
                zleceniaById = zlecenia.Where(x => x.IdRodzajZleceniaNavigation.NazwaRodzajZlecenia == idRz);
                LoadProductList(zleceniaById);

            }
            else if (idRz == "Wszystkie")
            {
                zleceniaById = zlecenia.Where(x => x.IdStatusu == idSta);
                LoadProductList(zleceniaById);

            }
            else
            {
                zleceniaById = zlecenia.Where(x => x.IdStatusu == idSta && x.IdRodzajZleceniaNavigation.NazwaRodzajZlecenia == idRz);
                LoadProductList(zleceniaById);
            }

        }


        private void LoadProductList(IEnumerable<Zlecenium> zlecenia)
        {
            lstOrders.Items.Clear();
            foreach (var orders in zlecenia)
            {
                lstOrders.Items.Add(orders);
            }

        }

        private int TransformIdFromText(string status)
        {
            if (status == "Wszystkie") return 0;
            else if (status == "Oczekujące") return 1;
            else if (status == "W realizacji") return 2;
            else return 3;
        }

    }
}
