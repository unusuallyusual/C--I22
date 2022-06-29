using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TelegaBot
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
    protected override void OnStartup(StartupEventArgs e)
    {
      MessageBox.Show("Приветули!");
    }
  }
}
