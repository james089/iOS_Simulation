using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static iOS_Simulation.Main.GV;

namespace iOS_Simulation.GUI.Pages
{
    /// <summary>
    /// Interaction logic for LockPage.xaml
    /// </summary>
    public partial class LockPage : UserControl
    {
        public static LockPage mLockPage = null;
        public LockPage()
        {
            mLockPage = this;
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            lbl_time.Content = $"{DateTime.Now: HH:mm}";
            lbl_date.Content = $"{DateTime.Now.DayOfWeek}, {(Months)DateTime.Today.Date.Month} {DateTime.Today.Date.Day}";
        }
    }
}
