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
            // Загрузить данные в таблицу TypeAccount. Можно изменить этот код как требуется.
            Abilympics5.dbDataSetTableAdapters.TypeAccountTableAdapter dbDataSetTypeAccountTableAdapter = new Abilympics5.dbDataSetTableAdapters.TypeAccountTableAdapter();
            dbDataSetTypeAccountTableAdapter.Fill(dbDataSet.TypeAccount);
            System.Windows.Data.CollectionViewSource typeAccountViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("typeAccountViewSource")));
            typeAccountViewSource.View.MoveCurrentToFirst();

            string result = dbDataSetTypeAccountTableAdapter.GetDataByTypeAccount(Data.UserAutorized.TypeAcc).ToString();
            TextBox1.Text = result;
            TextBox2.Text = Data.UserAutorized.Login;
            TextBox3.Text = Data.UserAutorized.Password;
            TextBox4.Text = Data.UserAutorized.Surname;
            TextBox5.Text = Data.UserAutorized.Name;
            TextBox6.Text = Data.UserAutorized.Patronymic;
            TextBox7.Text = Data.UserAutorized.Phone;
            TextBox8.Text = Data.UserAutorized.Email;
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

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            Window cp = new ChangeProfile();
            Hide();
            cp.ShowDialog();
            Show();
        }
    }
}
