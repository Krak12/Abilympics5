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

namespace Abilympics5
{
    /// <summary>
    /// Логика взаимодействия для CreatorMenu.xaml
    /// </summary>
    public partial class CreatorMenu : Window
    {
        public CreatorMenu()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Abilympics5.dbDataSet dbDataSet = ((Abilympics5.dbDataSet)(this.FindResource("dbDataSet")));
            // Загрузить данные в таблицу Orders. Можно изменить этот код как требуется.
            Abilympics5.dbDataSetTableAdapters.OrdersTableAdapter dbDataSetOrdersTableAdapter = new Abilympics5.dbDataSetTableAdapters.OrdersTableAdapter();
            dbDataSetOrdersTableAdapter.Fill(dbDataSet.Orders);
            System.Windows.Data.CollectionViewSource ordersViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("ordersViewSource")));
            ordersViewSource.View.MoveCurrentToFirst();
            // Загрузить данные в таблицу TypeAccount. Можно изменить этот код как требуется.
            Abilympics5.dbDataSetTableAdapters.TypeAccountTableAdapter dbDataSetTypeAccountTableAdapter = new Abilympics5.dbDataSetTableAdapters.TypeAccountTableAdapter();
            dbDataSetTypeAccountTableAdapter.Fill(dbDataSet.TypeAccount);
            System.Windows.Data.CollectionViewSource typeAccountViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("typeAccountViewSource")));
            typeAccountViewSource.View.MoveCurrentToFirst();
            // Загрузить данные в таблицу TypeServices. Можно изменить этот код как требуется.
            Abilympics5.dbDataSetTableAdapters.TypeServicesTableAdapter dbDataSetTypeServicesTableAdapter = new Abilympics5.dbDataSetTableAdapters.TypeServicesTableAdapter();
            dbDataSetTypeServicesTableAdapter.Fill(dbDataSet.TypeServices);
            System.Windows.Data.CollectionViewSource typeServicesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("typeServicesViewSource")));
            typeServicesViewSource.View.MoveCurrentToFirst();
            // Загрузить данные в таблицу Workers. Можно изменить этот код как требуется.
            Abilympics5.dbDataSetTableAdapters.WorkersTableAdapter dbDataSetWorkersTableAdapter = new Abilympics5.dbDataSetTableAdapters.WorkersTableAdapter();
            dbDataSetWorkersTableAdapter.Fill(dbDataSet.Workers);
            System.Windows.Data.CollectionViewSource workersViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("workersViewSource")));
            workersViewSource.View.MoveCurrentToFirst();
        }

        // переходы по tabPage
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            TabControl1.SelectedIndex = 0;
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            TabControl1.SelectedIndex = 1;
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            TabControl1.SelectedIndex = 2;
        }

        // закрытие формы
        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // переход на форму ChangePassCr
        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            Window cpc = new ChangePassCr();
            Hide();
            cpc.ShowDialog();
            Show();
        }
    }
}
