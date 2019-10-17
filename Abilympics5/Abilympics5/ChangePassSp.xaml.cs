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
    /// Логика взаимодействия для ChangePassSp.xaml
    /// </summary>
    public partial class ChangePassSp : Window
    {
        public ChangePassSp()
        {
            InitializeComponent();
        }

        // закрытие формы
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /* сохранение значения поля TextBox и 
         переход на форму SpecialistMenu*/
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Data.ChangePassSp = TextBox3.Text;
            Window sm = new SpecialistMenu();
            Hide();
            sm.ShowDialog();
            Show();
        }
    }
}
