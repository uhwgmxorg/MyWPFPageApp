using System;
using System.Linq;
using System.Collections.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace MyWPFPageApp.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {

        /// <summary>
        /// Properties
        /// </summary>
        private Boolean Logon { get; set; }

        private List<ViewModelBase> pageViewModels;
        public List<ViewModelBase> PageViewModels
        {
            get
            {
                if (pageViewModels == null)
                    pageViewModels = new List<ViewModelBase>();

                return pageViewModels;
            }
        }
        private ViewModelBase currentPageViewModel;
        public ViewModelBase CurrentPageViewModel
        {
            get
            {
                return currentPageViewModel;
            }
            set
            {
                if (currentPageViewModel != value)
                {
                    currentPageViewModel = value;
                    RaisePropertyChanged("CurrentPageViewModel");
                }
            }
        }

        /// <summary>
        /// Command Properties
        /// </summary>
        public RelayCommand WelcomeCommand { get; private set; }
        public RelayCommand LogonCommand { get; private set; }
        public RelayCommand LogoffCommand { get; private set; }
        public RelayCommand MouseCoordinatesCommand { get; private set; }
        public RelayCommand ExitCommand { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindowViewModel()
        {
            WelcomeCommand = new RelayCommand(WelcomeCommandCF, CanWelcomeCommand);
            LogonCommand = new RelayCommand(LogonCommandCF, CanLogonCommand);
            LogoffCommand = new RelayCommand(LogoffCommandCF, CanLogoffCommand);
            MouseCoordinatesCommand = new RelayCommand(MouseCoordinatesCommandCF, CanMouseCoordinatesCommandCommand);
            ExitCommand = new RelayCommand(ExitCommandCF, CanExitCommand);

            // Add available pages
            PageViewModels.Add(new WellcomeViewModel());
            PageViewModels.Add(new LogonViewModel());
            PageViewModels.Add(new MouseCoordinatesViewModel());

            // Set starting page
            CurrentPageViewModel = PageViewModels[0];
            Logon = false;

            // Registe MVVM Message Sytem
            Messenger.Default.Register<String>(this, MVVMMessageFunction);
        }

        /******************************/
        /*     Command Functions      */
        /******************************/
        #region Command Functions

        /// <summary>
        /// WelcomeCommand
        /// </summary>
        private void WelcomeCommandCF()
        {
            CurrentPageViewModel = PageViewModels.Find(vm => vm.ToString() == "MyWPFPageApp.ViewModels.WellcomeViewModel");
        }

        /// <summary>
        /// CanWelcomeCommand
        /// </summary>
        /// <returns></returns>
        private bool CanWelcomeCommand()
        {
            return Logon;
        }

        /// <summary>
        /// LogonCommandCF
        /// </summary>
        private void LogonCommandCF()
        {
            CurrentPageViewModel = PageViewModels.Find(vm => vm.ToString() == "MyWPFPageApp.ViewModels.LogonViewModel");
        }

        /// <summary>
        /// CanLogonCommand
        /// </summary>
        /// <returns></returns>
        private bool CanLogonCommand()
        {
            return !Logon;
        }

        /// <summary>
        /// LogoffCommandCF
        /// </summary>
        private void LogoffCommandCF()
        {
            Logon = false;
        }

        /// <summary>
        /// CanLogoffCommand
        /// </summary>
        /// <returns></returns>
        private bool CanLogoffCommand()
        {
            return Logon;
        }

        /// <summary>
        /// MouseCoordinatesCommandCF
        /// </summary>
        private void MouseCoordinatesCommandCF()
        {
            CurrentPageViewModel = PageViewModels.Find(vm => vm.ToString() == "MyWPFPageApp.ViewModels.MouseCoordinatesViewModel");
        }

        /// <summary>
        /// CanMouseCoordinatesCommandCommand
        /// </summary>
        /// <returns></returns>
        private bool CanMouseCoordinatesCommandCommand()
        {
            return Logon;
        }

        /// <summary>
        /// ExitCommandCF()
        /// </summary>
        private void ExitCommandCF()
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// CanTabelleCommandCF()
        /// </summary>
        /// <returns></returns>
        private bool CanExitCommand()
        {
            return Logon;
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
            if (Message == "logedon")
                Logon = true;
        }

        #endregion
        /******************************/
        /*      Other Functions       */
        /******************************/
        #region Other Functions

        #endregion
    }
}
