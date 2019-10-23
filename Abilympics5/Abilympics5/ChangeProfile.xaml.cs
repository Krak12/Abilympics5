using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для ChangeProfile.xaml
    /// </summary>
    public partial class ChangeProfile : Window
    {
        public static int typeaccount;
        public static string login;
        public static string pass;
        public static string surname;
        public static string name;
        public static string patronymic;
        public static string phone;
        public static string email;

        public ChangeProfile()
        {
            InitializeComponent();
        }

        //private void Clear()
        //{

        //    var fields = new TextBox[]
        //    {
        //        TextBox2,
        //        TextBox4,
        //        TextBox5
        //    };

        //    var box = new ComboBox[]
        //    {
        //         ComboBox1
        //    };

        //    foreach (ComboBox cb in box)
        //    {
        //        cb.Text = String.Empty;
        //    }

        //    foreach (TextBox tb in fields)
        //    {
        //        tb.Text = String.Empty;
        //    }
        //}

        private void CheckPhone(string phone)
        {
            string pattern = @"^[+]\d\s\(\d{3}\)\s\d{3}[-]\d{2}[-]\d{2}$";
            if (Regex.IsMatch(phone, pattern, RegexOptions.IgnoreCase))
            {
                MessageBox.Show("Телефон заполнен", "Информация", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Заполните поле Телефон!", "Информация", MessageBoxButton.OK);
            }
        }

        private void CheckEmail(string email)
        {
            string pattern = @"[a-z0-9.-]+[@][a-z]+[.][a-z]+";
            if (Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase))
            {
                MessageBox.Show("Email заполнен", "Информация", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Заполните email!", "Информация", MessageBoxButton.OK);
            }
        }

        // закрытие формы
        private void Button1_Click(object sender, RoutedEventArgs e)
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

        // сохранение изменений профиля
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            var userTA = new dbDataSetTableAdapters.WorkersTableAdapter();

            var users = userTA.GetDataByWHEREPhoneIsNull();
            var users1 = userTA.GetDataByWHEREPhoneIsNotNull();
            if (users.Count == 0)
            {
                MessageBox.Show("Поле Phone пусто!", "Информация", MessageBoxButton.OK);
            }
            else if (users1.Count != 0)
            {
                MessageBox.Show("Поле Phone не пусто!", "Информация", MessageBoxButton.OK);
            }

            var users2 = userTA.GetDataByWHEREEmailIsNull();
            var users3 = userTA.GetDataByWHEREEmailIsNotNull();
            if (users2.Count == 0)
            {
                MessageBox.Show("Поле Email пусто!", "Информация", MessageBoxButton.OK);
            }
            else if (users3.Count != 0)
            {
                MessageBox.Show("Поле Email не пусто!", "Информация", MessageBoxButton.OK);
            }


            if ((DataRowView)ComboBox1.SelectedItem == null)
            {
                MessageBox.Show("Заполните поле!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (TextBox7.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Заполните поле!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (TextBox8.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Заполните поле!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            dbDataSet.TypeAccountRow typeAccount = ((DataRowView)ComboBox1.SelectedItem).Row as dbDataSet.TypeAccountRow;

            typeaccount = typeAccount.ID;
            login = TextBox2.Text;

            var user1TA = new dbDataSetTableAdapters.WorkersTableAdapter();

            if (login != Data.UserAutorized.Login)
            {
                var userDataTable = user1TA.GetDataByLogin(login);
                if (userDataTable.Count > 0) 
                {
                    MessageBox.Show("Логин занят!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            surname = TextBox4.Text;
            name = TextBox5.Text;
            patronymic = TextBox6.Text;
            CheckPhone(TextBox7.Text);
            CheckEmail(TextBox8.Text);
            Data.UserAutorized.TypeAcc = typeaccount;
            Data.UserAutorized.Login = login;
            Data.UserAutorized.Surname = surname;
            Data.UserAutorized.Name = name;
            Data.UserAutorized.Patronymic = patronymic;
            Data.UserAutorized.Phone = phone;
            Data.UserAutorized.Email = email;

            userTA.Update(Data.UserAutorized);

            MessageBoxResult result = MessageBox.Show("Редактирование прошло успешно!", "Информация", MessageBoxButton.OK);
            result = MessageBoxResult.OK;

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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Abilympics5.dbDataSet dbDataSet = ((Abilympics5.dbDataSet)(this.FindResource("dbDataSet")));
            // Загрузить данные в таблицу TypeAccount. Можно изменить этот код как требуется.
            Abilympics5.dbDataSetTableAdapters.TypeAccountTableAdapter dbDataSetTypeAccountTableAdapter = new Abilympics5.dbDataSetTableAdapters.TypeAccountTableAdapter();
            dbDataSetTypeAccountTableAdapter.Fill(dbDataSet.TypeAccount);
            System.Windows.Data.CollectionViewSource typeAccountViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("typeAccountViewSource")));
            typeAccountViewSource.View.MoveCurrentToFirst();

            ComboBox1.SelectedIndex = Data.UserAutorized.TypeAcc - 1;
            TextBox2.Text = Data.UserAutorized.Login;
            TextBox4.Text = Data.UserAutorized.Surname;
            TextBox5.Text = Data.UserAutorized.Name;
            TextBox6.Text = Data.UserAutorized.Patronymic;
            TextBox7.Text = Data.UserAutorized.Phone;
            TextBox8.Text = Data.UserAutorized.Email;
        }

        private void ComboBox1_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (ComboBox1.SelectedIndex == 0)
            {
                Window cm = new CreatorMenu();
                Hide();
                cm.ShowDialog();
                Show();
            }
            else if (ComboBox1.SelectedIndex == 1)
            {
                Window sm = new SpecialistMenu();
                Hide();
                sm.ShowDialog();
                Show();
            }
            else if (ComboBox1.SelectedIndex == 2)
            {
                Window tm = new TechnicianMenu();
                Hide();
                tm.ShowDialog();
                Show();
            }
        }
    }
}
