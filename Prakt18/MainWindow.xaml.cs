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
        public ManySalesDB db = new ManySalesDB();
        AddProd add = new AddProd();
        EditRecord editRecord = new EditRecord();
        public MainWindow()
        {
            InitializeComponent();
            db.Sales.Load();
            mainGrid.ItemsSource = db.Sales.Local.ToBindingList();
            if (mainGrid.SelectedIndex == -1)
            {
                bDelete.IsEnabled = false;
                bChange.IsEnabled = false;
            }
        }

        private void AddRecord_Click(object sender, RoutedEventArgs e)
        {
            Sales entry = new Sales();
            if (add.ShowDialog() == false) return;
            else
            {
                entry.ProductName = add.ProductName;
                entry.BatchNumber = add.BatchNumber;
                entry.SinglePrice = add.SinglePrice;
                entry.SelledSinglePrice = add.SelledSinglePrice;
                entry.ArrivalDate = add.ArrivalDate.Date;
                entry.SellDate = add.SellDate.Date;
                entry.BatchSize = add.BatchSize;
                entry.BuyerCompany = add.BuyerCompany;
                entry.SelledBatchSize = add.SelledBatchSize;

                db.Sales.Add(entry);
                db.SaveChanges();



                mainGrid.Items.Refresh();
            }
        }

        private void ChangeRecord_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = mainGrid.SelectedIndex;
            if (indexRow != -1)
            {
                Sales row = (Sales)mainGrid.Items[indexRow];
                editRecord = new EditRecord();
                if (editRecord.ShowDialog() == false) return;

                else
                {
                    row = db.Sales.Find(indexRow);

                    row.ProductName = editRecord.ProductName;
                    row.BatchNumber = editRecord.BatchNumber;
                    row.SinglePrice = editRecord.SinglePrice;
                    row.SelledSinglePrice = editRecord.SelledSinglePrice;
                    row.ArrivalDate = editRecord.ArrivalDate;
                    row.SellDate = editRecord.SellDate;
                    row.BatchSize = editRecord.BatchSize;
                    row.BuyerCompany = editRecord.BuyerCompany;
                    row.SelledBatchSize = editRecord.SelledBatchSize;

                    db.SaveChanges();
                    mainGrid.Items.Refresh();
                }
            }
            else MessageBox.Show("Не выбрана запись");
        }

        private void DeleteRecord_Click(object sender, RoutedEventArgs e)
        {

            if (mainGrid.SelectedIndex != -1)
            {
                Sales row = (Sales)mainGrid.Items[mainGrid.SelectedIndex];
                var res = MessageBox.Show("Вы уверены что хотите удалить запись?","Удаление записи",MessageBoxButton.YesNo);
                if (res == MessageBoxResult.Yes)
                {
                    db.Sales.Remove(row);
                    db.SaveChanges();
                    mainGrid.Items.Refresh();
                }
                else return;
            }
        }

        private void GridSelectionChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (mainGrid.SelectedIndex != -1)
            {
                bDelete.IsEnabled = true;
                bChange.IsEnabled = true;
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
