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
    /// Логика взаимодействия для TechnicianMenu.xaml
    /// </summary>
    public partial class TechnicianMenu : Window
    {
        public TechnicianMenu()
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

        // закрытие формы
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
