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
    /// Логика взаимодействия для Realtors.xaml
    /// </summary>
    public partial class Realtors : Window
    {
        EstateAgencyEntities context;
        string currentLetter = "";

        public object StackLetters { get; private set; }

        public Realtors(EstateAgencyEntities context, Realtors newrealtors)
        {
            InitializeComponent();
            this.context = context;
            this.DataContext = newrealtors;
            ShowTable();
            ShowLetters();
        }

        private void ShowLetters()
        {
            for (char i = 'А'; i <= 'Я'; i++)
            {
                TextBlock letter = new TextBlock
                {
                    Text = i.ToString(),
                    FontWeight = FontWeights.Bold,
                    Foreground = Brushes.Black,
                    Margin = new Thickness(10, 1, 5, 1)
                };
                letter.MouseLeftButtonDown += TextBlock_MouseLeftButtonDown;
                StckLttrs.Children.Add(letter);
            }
        }

        private void ShowTable()
        {
            DataGrid2.ItemsSource = context.Realtors.ToList();
            //if (SName.Text == null && NPhone.Text == null)
            //    return;
            //List<Realtors> listRealtors = context.Realtors.ToList();
            //listRealtors = listRealtors.Where(x => x.NumberPhone.ToLower().Contains(NPhone.Text.ToLower())).ToList();
            //if (currentLetter.Count() == 1)
            //{
            //    listRealtors = listRealtors.Where(x => x.Surname.Contains(currentLetter)).ToList();
            //}
            //DataGrid2.ItemsSource = listRealtors.OrderBy(x => x.Surname).ToList();
        }

        private void BtnAddRe_Click(object sender, RoutedEventArgs e)
        {
            var NewRealtor = new Realtors();
            context.Realtors.Add(NewRealtor);
            var BtnAddRealtor = new AddUpdateRealtors(context, NewRealtor);
            BtnAddRealtor.ShowDialog();
            ShowTable();
        }

        private void BtnDeleteRe_Click(object sender, RoutedEventArgs e)
        {
            var покупатели = DataGrid2.SelectedItem as Realtors;
            if (покупатели == null)
            {
                MessageBox.Show("Выберите строку!");
                return;

            }
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы действительно хотите удадить эту строку?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                context.Realtors.Remove(покупатели);
                context.SaveChanges();
                ShowTable();

            }
        }

        private void BtnEditData_Click(object sender, RoutedEventArgs e)
        {
            Button AddPokup = sender as Button;
            var currentCar = AddPokup.DataContext as Realtors;
            var EdiWindow = new AddUpdateRealtors(context, currentCar);
            EdiWindow.ShowDialog();
        }

        private void SName_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShowTable();
        }

        private void NPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShowTable();
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var label = (TextBlock)sender;
            currentLetter = label.Text;
            foreach (TextBlock letter in StckLttrs.Children)
            {
                letter.Foreground = Brushes.Black;
            }
            label.Foreground = Brushes.Red;
            ShowTable();
        }
    }
}
