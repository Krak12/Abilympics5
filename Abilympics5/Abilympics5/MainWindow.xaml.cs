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
    /// Логика взаимодействия для WindowMain.xaml
    /// </summary>
    public partial class WindowMain : Window
    {
        private string Pass = "";

        public WindowMain()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            // настройка ввода логина или пароля
            var userTA = new dbDataSetTableAdapters.WorkersTableAdapter();
            var users = userTA.GetDataByLoginAndPass(TextBox1.Text, PasswordBox1.Password);

            if (users.Count == 0)
            {
                MessageBox.Show("Неверный логин или пароль! Повторите попытку ввода.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            // переходы по формам зависящие от TypeAcc
            Data.UserAutorized = userTA.GetDataByLogin(TextBox1.Text.Trim()).First();

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

        // настройка функции Показать пароль
        private void ShowPass_Checked(object sender, RoutedEventArgs e)
        {
            TextBox2.Text = Pass;
            TextBox2.Visibility = Visibility.Visible;
            PasswordBox1.Visibility = Visibility.Hidden;
        }

        private void ShowPass_Unchecked(object sender, RoutedEventArgs e)
        {
            PasswordBox1.Password = Pass;
            TextBox2.Visibility = Visibility.Hidden;
            PasswordBox1.Visibility = Visibility.Visible;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Pass = PasswordBox1.Password;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Pass = TextBox2.Text;
        }
    }
}
