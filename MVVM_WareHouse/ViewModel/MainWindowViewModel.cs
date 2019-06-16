using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MVVM_WareHouse.Command;
using MVVM_WareHouse.Model;

namespace MVVM_WareHouse.ViewModel
{
    class MainWindowViewModel : NotifyObject
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindowViewModel( string state )
        {
            if(state == STATEMENTS.USER_ADMIN_ACCOUNT) IsAdminLogin = true;
            else IsAdminLogin = false;

            _InnerPageUri = new Uri("/View/DefaultPage.xaml", UriKind.Relative);

            ChangeInnerPageCommand = new ChangeInnerPageCommand(this);
        }

        #region Parameters

        private string _UserID;
        /// <summary>
        /// the current log user
        /// </summary>
        public string UserID { get => _UserID; set => _UserID = value; }


        private Uri _InnerPageUri;
        /// <summary>
        /// Set the innerpage's uri
        /// </summary>
        public Uri InnerPageUri {
            get => _InnerPageUri;
            set{
                _InnerPageUri = value;
                if(InnerPageUri != null) OnPropertyChanged("InnerPageUri");
            }
        }

        /// <summary>
        /// Use this to convert bool to Visibility
        /// </summary>
        private bool IsAdminLogin
        {
            set
            {
                if (value) UserLoginOptions = Visibility.Visible;
                else UserLoginOptions = Visibility.Collapsed;
            }
        }

        private Visibility _UserLoginOptions;
        /// <summary>
        /// 
        /// </summary>
        public Visibility UserLoginOptions
        {
            get
            {
                return _UserLoginOptions;
            }
            set
            {
                _UserLoginOptions = value;
                OnPropertyChanged("UserLoginOptions");
            }
        }

        #endregion

        #region Commands

        /// <summary>
        /// Change Inner page command
        /// </summary>
        public ChangeInnerPageCommand ChangeInnerPageCommand { get; private set; }

        #endregion
    }
}
