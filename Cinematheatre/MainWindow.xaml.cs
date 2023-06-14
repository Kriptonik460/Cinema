using Cinematheatre.Models;
using Cinematheatre.WorkPage;
using Cinematheatre.WorkPage.DirecorWork;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cinematheatre
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            new Regustr().Show();
            Close();
        }

        private void Avtor_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTb.Text.Trim() == "" || PasswordTb.Text.Trim() == "")
            {
                MessageBox.Show("Заполните все поля");
            }
            else
            {
                User cd = App.DB.User.FirstOrDefault(f => f.Login == LoginTb.Text.Trim() && f.Password == PasswordTb.Text.Trim());
                if (cd != null)
                {

                    if (App.DB.Employee.FirstOrDefault(g => g.User.Id == cd.Id) != null)
                    {
                        SaveSomeData.user = cd;
                        new EmplWindows().Show();
                        Close();
                    }

                    if (App.DB.Director.FirstOrDefault(k => k.User.Id == cd.Id) != null)
                    {
                        SaveSomeData.user = cd;
                        new DirectorWindows().Show();
                        Close();
                    }


                }
                else
                    MessageBox.Show("Пошел нахуй!");
            }
        }
    }
}
