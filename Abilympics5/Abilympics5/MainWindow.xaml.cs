using System;
using System.Collections.Generic;
using System.Drawing;
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
    //gigihadid8655@yandex.ru
    /// <summary>
    /// Логика взаимодействия для WindowMain.xaml
    /// </summary>
    public partial class WindowMain : Window
    {
        private string Pass = "";

        public string TestText { get; set; } = "Gleb, Hello!";

        private int TryLoginCount = 0;
        private (int code, Bitmap img)[] Capches =
        {
            (43587, Properties.Resources.capcha_43587),
            (89228, Properties.Resources.capcha_89228),
        };
        private Random Rand = new Random();
        private int SelectedCapcha = 0;

        public WindowMain()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            TryLoginCount++;

            string login = TextBox1.Text;
            string pass = PasswordBox1.Password;

            UpdateCapchaVisible();

            bool tryLogin = Login(login, pass);

            if (!tryLogin)
            {
                MessageBox.Show("Error!");
            }

            // настройка ввода логина или пароля
            var userTA = new dbDataSetTableAdapters.WorkersTableAdapter();
            var users = userTA.GetDataByLoginAndPass(TextBox1.Text, PasswordBox1.Password);

            if (users.Count == 0)
            {
                MessageBox.Show("Неверный логин или пароль! Повторите попытку ввода.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
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

        private bool Login(string login, string pass)
        {
            bool capchaSuccess = CapchaSuccess();

            //if (capchaSuccess && login == "123" && pass == "456")
            //{
            //    TryLoginCount = 0;

            //    UpdateCapchaVisible();

            //    if (CheckBox2.Checked) RemindData.Remind(login, pass);
            //    else RemindData.Clear();

            //    if (Data.UserAutorized.TypeAcc == 1)
            //    {
            //        Window cm = new CreatorMenu();
            //        Hide();
            //        cm.ShowDialog();
            //        Show();
            //    }
            //    else if (Data.UserAutorized.TypeAcc == 2)
            //    {
            //        Window sm = new SpecialistMenu();
            //        Hide();
            //        sm.ShowDialog();
            //        Show();
            //    }
            //    else if (Data.UserAutorized.TypeAcc == 3)
            //    {
            //        Window tm = new TechnicianMenu();
            //        Hide();
            //        tm.ShowDialog();
            //        Show();
            //    }

            //    TextBox1.Text = "";
            //    PasswordBox1.Password = "";

            //    return true;
            //}

            return false;
        }

        private bool IsCapchaVisible()
        {
            return TryLoginCount >= 3;
        }


        private bool CapchaSuccess()
        {
            if (IsCapchaVisible())
            {
                string codeText = TextBox3.Text;
                int code;

                return int.TryParse(codeText, out code) && code == Capches[SelectedCapcha].code;
            }

            return true;
        }

        private void UpdateCapchaVisible()
        {
            //if (IsCapchaVisible())
            //{
            //    panel1.Visible = true;
            //    panel2.Location = new Point(panel2.Location.X, 260);

            //    textBox3.Clear();

            //    SelectedCapcha = Rand.Next(Capches.Length);
            //    pictureBox1.Image = Capches[SelectedCapcha].img;
            //}
            //else
            //{
            //    panel1.Visible = false;
            //    panel2.Location = new Point(panel2.Location.X, 185);
            //}
        }
    }
}
