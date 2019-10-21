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

            //string result = dbDataSetWorkersTableAdapter.GetDataByTypeAccount(Data.UserAutorized.TypeAcc).ToString();
            //TextBox2.Text = result;
            TextBox3.Text = Data.UserAutorized.Login;
            TextBox4.Text = Data.UserAutorized.Password;
            TextBox5.Text = Data.UserAutorized.Surname;
            TextBox6.Text = Data.UserAutorized.Name;
            TextBox7.Text = Data.UserAutorized.Patronymic;
            TextBox8.Text = Data.UserAutorized.Phone;
            TextBox9.Text = Data.UserAutorized.Email;
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

        // переход на форму ChangePass
        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            if (Data.UserAutorized.TypeAcc == 1)
            {
                Window cm = new CreatorMenu();
                Hide();
                cm.ShowDialog();
                Show();
            }
            else if (Data.UserAutorized.TypeAcc == 2)
            {
                Window sm = new SpecialistMenu();
                Hide();
                sm.ShowDialog();
                Show();
            }
            else if (Data.UserAutorized.TypeAcc == 3)
            {
                Window tm = new TechnicianMenu();
                Hide();
                tm.ShowDialog();
                Show();
            }
        } 

        // переход на форму ChangeProfile
        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            Window cp = new ChangeProfile();
            Hide();
            cp.ShowDialog();
            Show();
        }
    }
}
