using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace iOS_Simulation.GUI.Helpers
{
    public class UINavigation
    {
        private Uri homePageUri = null;
        private Uri currentPageUri = null;
        private Frame presentationPage = null;

        public static UINavigation navControl = null;

        public UINavigation(Uri home, Frame pres)
        {
            homePageUri = home;
            navControl = this;
            currentPageUri = home;
            presentationPage = pres;
        }

        public static void GoToPage(Uri nextpageUri)
        {
            if (navControl != null && nextpageUri != navControl.homePageUri)
            {
                if (nextpageUri != null)
                {
                    navControl.presentationPage.NavigationService.Navigate(nextpageUri);
                    navControl.currentPageUri = nextpageUri;
                }
            }
        }

        public static void GoToHomePage()
        {
            if (navControl != null)
            {
                navControl.presentationPage.NavigationService.Navigate(navControl.homePageUri);
                navControl.currentPageUri = navControl.homePageUri;
            }
        }
    }
}
