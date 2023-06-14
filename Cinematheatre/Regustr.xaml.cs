using Cinematheatre.Models;
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

namespace Cinematheatre
{
    /// <summary>
    /// Логика взаимодействия для Regustr.xaml
    /// </summary>
    public partial class Regustr : Window
    {
        User user;
        Employee employee;
        Director director;
        public Regustr()
        {
            InitializeComponent();
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            var proverkaLogin = LoginTb.Text.Trim();
            if (App.DB.User.FirstOrDefault(d => d.Login == proverkaLogin) == null)
            {
                if ((string.IsNullOrEmpty(LoginTb.Text) && (string.IsNullOrEmpty(PasswordTb.Text) &&
                    (string.IsNullOrEmpty(LastName.Text) && (string.IsNullOrEmpty(FirsrNaem.Text) && (string.IsNullOrEmpty(Patronomic.Text)))))))
                {
                    MessageBox.Show("Поля пустые");
                    return;
                }

                user = new User()
                {
                    Login = LoginTb.Text.Trim(),
                    Password = PasswordTb.Text.Trim()
                };
                App.DB.User.Add(user);
                if (TypeUserCB.SelectedIndex == 0)
                {
                    employee = new Employee()
                    {
                        Lastname = LastName.Text.Trim(),
                        Firstname = FirsrNaem.Text.Trim(),
                        Patronomic = Patronomic.Text.Trim(),
                        IdUser = user.Id

                    };
                    App.DB.Employee.Add(employee);
                    App.DB.SaveChanges();
                    new MainWindow().Show();
                    Close();
                }
                else
                {
                    director = new Director()
                    {
                        Lastname = LastName.Text.Trim(),
                        Firstname = FirsrNaem.Text.Trim(),
                        Patronomic = Patronomic.Text.Trim(),
                        IdUser = user.Id

                    };
                    App.DB.Director.Add(director);
                    App.DB.SaveChanges();
                    new MainWindow().Show();
                    Close();
                }




            }
            else
                MessageBox.Show("Данный логин уже занят");


        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
    }
}
