using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WCFClient.UI.Commands;
using WCFClient.UI.Enums;

namespace WCFClient.UI.ViewModel
{
    class MainViewModel: ViewModelBase
    {
        public Command LoginCommand { get; set; }
        public Command LogoutCommand { get; set; }
        public Command NewControlCommand { get; set; }
        public Command NewWindowCommand { get; set; }
        public Command NewControl2Command { get; set; }

        public AuthenticationViewModel AuthVM { get; set; }

        private FrameworkElement _SubView;
        public FrameworkElement SubView
        {
            get { return _SubView; }
            set
            {
                if (value != _SubView)
                {
                    _SubView = value;
                    RaisePropertyChanged("SubView");
                }
            }
        }

        private double _InputValue;
        public double InputValue
        {
            get { return _InputValue; }
            set
            {
                if (value != _InputValue)
                {
                    _InputValue = value;
                    RaisePropertyChanged("InputValue");
                }
            }
        }


        // public List<MyMenuItem> TheMenu { get; set; }

        public MainViewModel(Border Stage)
        {
            AuthVM = new AuthenticationViewModel();

            LoginCommand = new Command(DoLogin);
            //LogoutCommand = new RelayCommand(DoLogout, AuthVM.CanDoAuthenticated);
            //NewControlCommand = new RelayCommand(DoNewControl, CanDoNewControl);
            //NewWindowCommand = new RelayCommand(DoNewWindow, CanDoNewWindow);
            //NewControl2Command = new RelayCommand(DoNewControl2, CanDoNewControl2);

            //TheMenu = new List<MyMenuItem>
            //{
            //    new MyMenuItem { Header = "Log off", Command = LogoutCommand },
            //    new MyMenuItem { Header = "Other stuff",
            //        Children = new List<MyMenuItem>
            //        {
            //            new MyMenuItem { Header = "Load new control", Command = NewControlCommand },
            //            new MyMenuItem { Header = "Load control v2", Command = NewControl2Command },
            //            new MyMenuItem { Header = "Open new window", Command = NewWindowCommand },
            //        },
            //    },
            //};

            ApplicationController.GetInstance().SetStage(Stage);
        }

        private void DoLogin(object obj)
        {
            AuthVM.Authenticate();
        }

        private bool CanDoLogout(object obj)
        {
            return AuthVM.IsAuthenticated;
        }

        private void DoLogout(object obj)
        {
            AuthVM.LogOff();
        }

        private bool CanDoNewControl(object obj)
        {
            return AuthVM.IsAuthenticated;
        }

        private void DoNewControl(object obj)
        {
            ApplicationController.GetInstance().GoToPage(ApplicationPage.LogInControlView);
        }

        private bool CanDoNewWindow(object obj)
        {
            return AuthVM.IsAuthenticated;
        }

       

        private bool CanDoNewControl2(object obj)
        {
            return AuthVM.IsAuthenticated;
        }

       
    }
}
