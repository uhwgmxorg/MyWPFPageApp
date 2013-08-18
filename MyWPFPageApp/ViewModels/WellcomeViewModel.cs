using System;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace MyWPFPageApp.ViewModels
{
    class WellcomeViewModel : ViewModelBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public WellcomeViewModel()
        {
            // Registe MVVM Message Sytem
            Messenger.Default.Register<String>(this, MVVMMessageFunction);
        }

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
