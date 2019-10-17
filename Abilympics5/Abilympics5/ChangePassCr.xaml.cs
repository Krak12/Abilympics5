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
    /// Логика взаимодействия для ChangePassCr.xaml
    /// </summary>
    public partial class ChangePassCr : Window
    {
        public ChangePassCr()
        {
            InitializeComponent();
        }

        // закрытие формы
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /* сохранение значения поля TextBox и 
         переход на форму CreatorMenu*/
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Data.ChangePassCr = TextBox3.Text;
            Window cm = new CreatorMenu();
            Hide();
            cm.ShowDialog();
            Show();
        }
    }
}
