using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DiplomEstateAgency
{
    /// <summary>
    /// Логика взаимодействия для WindowAddUpdateDeals.xaml
    /// </summary>
    public partial class WindowAddUpdateDeals : Window
    {
        EstateAgencyEntities context;
        public WindowAddUpdateDeals(EstateAgencyEntities context, Deals newSdelka)
        {
            InitializeComponent(); 
            this.context = context;
            Apa.ItemsSource = context.Apartaments.ToList();
            Own.ItemsSource = context.Owners.ToList();
            Rltrs.ItemsSource = context.Realtors.ToList();
            Cli.ItemsSource = context.Clients.ToList();
            this.DataContext = newSdelka;
        }

        private void BtnSaveData_Click(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
            this.Close();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
