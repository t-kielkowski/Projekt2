using System.Collections.Generic;
using System.Windows;

namespace Projekt2
{
    /// <summary>
    /// Logika interakcji dla klasy SelectStatus.xaml
    /// </summary>
    public partial class SelectStatus : Window
    {
        public IEnumerable<string> ComboBoxListStat { get; set; }
        public string Status { get; set; }

        public SelectStatus()
        {
            InitializeComponent();
            ComboBoxListStat = ComboList.ListStatNames();
            DataContext = this;
        }


        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(cbStat.Text))
                MessageClass.MessageErrorWithDefaultCaption("Wybierz status zlecenia");
            else
            {
                Status = cbStat.Text;
                this.Close();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
