/******************************************************************************/
/*                                                                            */
/*   Program: MyWPFPageApp                                                    */
/*   My MVVM Template                                                         */
/*                                                                            */
/*   15.8.2013 0.0.0.0 uhwgmxorg Start                                        */
/*                                                                            */
/******************************************************************************/
using System;
using System.Linq;
using System.Windows;

namespace MyWPFPageApp.Views
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        public MainWindowView()
        {
            InitializeComponent();
            DataContext = new MyWPFPageApp.ViewModels.MainWindowViewModel();
        }
    }
}
