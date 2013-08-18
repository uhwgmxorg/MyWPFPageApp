using System;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Command;

namespace MyWPFPageApp.ViewModels
{
    class LogonViewModel : ViewModelBase
    {

        /// <summary>
        /// Binding Vars
        /// </summary>
        private string user;
        public string User
        {
            get { return user; }
            set
            {
                if (value != User)
                {
                    user = value;
                    RaisePropertyChanged("User");
                }
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                if (value != Password)
                {
                    password = value;
                    RaisePropertyChanged("Password");
                }
            }
        }

        /// <summary>
        /// Command Properties
        /// </summary>
        public RelayCommand LogonCommand { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public LogonViewModel()
        {
            LogonCommand = new RelayCommand(LogonCommandCF, CanLogonCommand);

            // Registe MVVM Message Sytem
            Messenger.Default.Register<String>(this, MVVMMessageFunction);
        }

        /******************************/
        /*     Command Functions      */
        /******************************/
        #region Command Functions

        /// <summary>
        /// LogonCommandCF
        /// </summary>
        private void LogonCommandCF()
        {
            // Message to MainWindowViewModel
            Messenger.Default.Send<String, MainWindowViewModel>("logedon");
        }

        /// <summary>
        /// CanLogonCommand
        /// </summary>
        /// <returns></returns>
        private bool CanLogonCommand()
        {
            return true;
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
