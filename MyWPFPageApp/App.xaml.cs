using System;
using System.Linq;
using System.Windows;
using MyWPFPageApp.Views;

namespace MyWPFPageApp
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindowView mainWindowView = new MainWindowView();
            mainWindowView.Show();
        }
    }
}
