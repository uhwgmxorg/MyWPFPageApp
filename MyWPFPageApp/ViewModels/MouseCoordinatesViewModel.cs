using System;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;

namespace MyWPFPageApp.ViewModels
{
    class MouseCoordinatesViewModel : ViewModelBase
    {

        /// <summary>
        /// Binding Vars
        /// </summary>
        private string mouseCoordinates;
        public string MouseCoordinates
        {
            get { return mouseCoordinates; }
            set
            {
                if (value != MouseCoordinates)
                {
                    mouseCoordinates = value;
                    RaisePropertyChanged("MouseCoordinates");
                }
            }
        }

        /// <summary>
        /// EventsToCommands
        /// <summary>
        public RelayCommand<object> MouseMove { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public MouseCoordinatesViewModel()
    	{
            MouseMove = new RelayCommand<object>(MouseMoveCF);

            MouseCoordinates = "X=0;Y=0";

            // Registe MVVM Message Sytem
            Messenger.Default.Register<String>(this, MVVMMessageFunction);
        }

        /******************************/
        /*  EventToCommandsFunctions  */
        /******************************/
        #region EventToCommandsFunctions

        /// <summary>
        /// MouseMoveCF
        /// </summary>
        /// <param name="obj"></param>
        public void MouseMoveCF(object obj)
        {
            System.Windows.Input.MouseEventArgs Mea = (System.Windows.Input.MouseEventArgs)obj;
            MouseCoordinates = "X=" + Mea.GetPosition((Canvas)((RoutedEventArgs)((MouseEventArgs)obj)).Source).X.ToString() + ";Y=" + Mea.GetPosition((Canvas)((RoutedEventArgs)((MouseEventArgs)obj)).Source).Y.ToString();
        }

        #endregion
        /******************************/
        /*      Other Events          */
        /******************************/
        #region Other Events

        /// <summary>
        /// MVVMMessageFunction
        /// </summary>
        /// <param name="Message"></param>
        private void MVVMMessageFunction(String Message)
        {
        }

        #endregion
    }
}
