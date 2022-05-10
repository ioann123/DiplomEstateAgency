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
    /// Логика взаимодействия для AddUpdateRealtors.xaml
    /// </summary>
    public partial class AddUpdateRealtors : Window
    {
        EstateAgencyEntities context;
        public AddUpdateRealtors(EstateAgencyEntities context, Realtors newRealtor)
        {
            InitializeComponent(); 
            this.context = context;
            ge.ItemsSource = context.Gender.ToList();
            this.DataContext = newRealtor;
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
