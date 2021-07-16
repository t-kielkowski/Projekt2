using Projekt2.ScaffoldModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Projekt2
{
    /// <summary>
    /// Logika interakcji dla klasy NewOrder.xaml
    /// </summary>
    public partial class NewOrder : Window
    {
        public IEnumerable<string> ComboBoxList { get; set; }

        public NewOrder()
        {
            InitializeComponent();
            ComboBoxList = ComboList.ListOrderNames();
            DataContext = this;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            var zlecenia = DataBaseService.AllOrders();
            var requireDays = DataBaseService.RequireDaysForOrder(cbIdRZ.Text);

           
            if (string.IsNullOrEmpty(orderName.Text))
            {
                MessageClass.MessageErrorWithDefaultCaption("Nie podano nazwy towaru");

            }
            else if (string.IsNullOrEmpty(cbIdRZ.Text))
            {
                MessageClass.MessageErrorWithDefaultCaption("Nie podano rodzaju zlecenia");
            }
            else if (deadline.SelectedDate == null)
            {
                MessageClass.MessageErrorWithDefaultCaption("Nie wybrano żadnej daty");

            }
            else if (checkDate(deadline.Text, requireDays))
            {
                MessageClass.MessageError($"Data ostatecznego terminu wykonania musi być starsza od daty w której zlecenie jest przyjmowane z uwzględnieniem potrzebnego czasu na wykonanie zlecenia. W tym przypadku czas potrzebny na wykonanie zlecenia tego rodzaju wynosi {requireDays} dni. Proszę o uwzględnienie tego przy wyborze daty w jakiej zlecenie musi najpóźniej zostać zakończone.", "Popraw date");
            }
            else
            {
                var idZ = zlecenia.Select(x => x.IdZlecenia).LastOrDefault();
                var idRz = DataBaseService.OrderType().Where(x => x.NazwaRodzajZlecenia == cbIdRZ.Text).Select(x => x.IdRodzajZlecenia)
                    .LastOrDefault();

                //var idRz = zlecenia.Where(x => x.IdRodzajZleceniaNavigation.NazwaRodzajZlecenia == cbIdRZ.Text)
                //    .Select(x => x.IdRodzajZlecenia).LastOrDefault();    <<< nie działa, wyrzuca wyjątek :(


                var zlecenie = new Zlecenium
                {
                    IdZlecenia = ++idZ,
                    NazwaTowaru = orderName.Text,
                    DataPrzyjecia = DateTime.Now,
                    NieprzekraczalnyTerminWykonania = DateTime.Parse(deadline.Text),
                    IdRodzajZlecenia = idRz,
                    IdStatusu = 1
                };

                DataBaseService.AddOrder(zlecenie);                
                this.Close();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool checkDate(string date, int days)
        {
            DateTime requireDate = DateTime.Parse(date);
            if (DateTime.Now.AddDays(days) >= requireDate) return true;
            return false;
        }
    }
}
