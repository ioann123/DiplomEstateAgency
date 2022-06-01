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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DiplomEstateAgency
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EstateAgencyEntities context;
        public MainWindow()
        {
            InitializeComponent();
            context = new EstateAgencyEntities();
            ShowTable();
        }

        private void ShowTable()
        {
            DataGrid1.ItemsSource = context.Deals.ToList();
        }

        private void BtnAddData_Click(object sender, RoutedEventArgs e)
        {
            var NewSdelka = new Deals();
            context.Deals.Add(NewSdelka);
            var BtnAddData = new WindowAddUpdateDeals(context, NewSdelka);
            BtnAddData.ShowDialog();
            ShowTable();
        }

        private void BtnDeleteData_Click(object sender, RoutedEventArgs e)
        {
            var сделки = DataGrid1.SelectedItem as Deals;
            if (сделки == null)
            {
                MessageBox.Show("Выберите строку!");
                return;

            }
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы действительно хотите удадить эту строку?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                context.Deals.Remove(сделки);
                context.SaveChanges();
                ShowTable();
            }
        }

        private void BtnEditData_Click(object sender, RoutedEventArgs e)
        {
            Button BtnEdit = sender as Button;
            var currentCar = BtnEdit.DataContext as Deals;
            var EdiWindow = new WindowAddUpdateDeals(context, currentCar);
            EdiWindow.ShowDialog();
            ShowTable();
        }

        private void Realtors_Click(object sender, RoutedEventArgs e)
        {
            var RealtorADD = new Realtors();
            context.Realtors.Add(RealtorADD);
            var BtnAddReal = new Realtors(context, RealtorADD);
            BtnAddReal.ShowDialog();
            ShowTable();
        }

    }
}
