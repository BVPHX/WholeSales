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

namespace Prakt18
{
    /// <summary>
    /// Логика взаимодействия для AddProd.xaml
    /// </summary>
    public partial class AddProd : Window
    {
        public int SinglePrice { get; set; }
        public int BatchNumber { get; set; }
        public int BatchSize { get; set; }
        public int SelledBatchSize { get; set; }
        public int SelledSinglePrice { get; set; }
        public string ProductName { get; set; }
        public string BuyerCompany { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime SellDate { get; set; }

        public AddProd()
        {

            InitializeComponent();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (int.TryParse(e.Text, out int _)) return;
            e.Handled = true;
        }

        private void FilledAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SinglePrice = Convert.ToInt32(tbSinglePrice.Text);
                BatchNumber = Convert.ToInt32(tbBatchNumber.Text);
                BatchSize = Convert.ToInt32(tbBatchSize.Text);
                SelledBatchSize = Convert.ToInt32(tbSelledBatchSize.Text);
                SelledSinglePrice = Convert.ToInt32(tbSelledSinglePrice.Text);
                ProductName = tbProdName.Text;
                BuyerCompany = tbBuyerCompany.Text;
                ArrivalDate = (DateTime)dpArrivalDate.SelectedDate;
                SellDate = (DateTime)dpSellDate.SelectedDate;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Введены некорректные данные","Ошибка",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            DialogResult = true;
            Close();
        }
    }
}
