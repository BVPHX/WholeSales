using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace Prakt18
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ManySalesDB db = new ManySalesDB();
        AddProd add = new AddProd();

        public MainWindow()
        {
            InitializeComponent();
            mainGrid.ItemsSource = db.Sales.Local.ToBindingList();
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            Sales entry = new Sales();
            add.ShowDialog();
            entry.ProductName = add.ProductName;
            entry.BatchNumber = add.BatchNumber;
            entry.SinglePrice = add.SinglePrice;
            entry.SelledSinglePrice = add.SelledSinglePrice;
            entry.ArrivalDate = add.ArrivalDate;
            entry.SellDate = add.SellDate;
            entry.BatchSize = add.BatchSize;
            entry.BuyerCompany = add.BuyerCompany;
            entry.SelledBatchSize = add.SelledBatchSize;

            db.Sales.Add(entry);
            db.SaveChanges();



            mainGrid.Items.Refresh();
        }
    }
}
