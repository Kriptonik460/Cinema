using Cinematheatre.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Cinematheatre
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {

        public static CinemaEntities DB = new CinemaEntities();

        public App()
        {
            DB.Category.Load();
            DB.CinemaPlace.Load();
            DB.Director.Load();
            DB.User.Load();
            DB.Schedule.Load();
            DB.Film.Load();
            DB.Employee.Load();
        }
    }
}
