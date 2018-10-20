using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WCFClient.UI.Enums;
using WCFClient.UI.View.Controls;

namespace WCFClient
{
    class ApplicationController
    {
        static ApplicationController _instance;
        public static ApplicationController GetInstance()
        {
            if (_instance == null)
                _instance = new ApplicationController();
            return _instance;
        }

        Border _stage;

        private ApplicationController() { }

        public void GoToPage(ApplicationPage page)
        {
            switch (page)
            {
                case ApplicationPage.LogInControlView:
                    _stage.Child = new LogInControlView();
                    break;
            }
        }

        public void SetStage(Border Stage)
        {
            _stage = Stage;
          
        }

    }
}
