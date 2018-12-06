using iOS_Simulation.GUI.Panels.LockPagePanels;
using iOS_Simulation.Theme.Animations;
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
using static iOS_Simulation.MainWindow;
using static iOS_Simulation.GUI.Pages.MainPage;

namespace iOS_Simulation.GUI.Pages
{
    /// <summary>
    /// Interaction logic for LockPage.xaml
    /// </summary>
    public partial class LockPage : UserControl
    {
        public static LockPage mLockPage = null;

        public string EnteredPasscode = "";
        public string PresetPasscode = "111111";

        public LockPage()
        {
            mLockPage = this;
            InitializeComponent();
            mNumberPad.IsPressed += MNumberPad_IsPressed;
        }

        private void MNumberPad_IsPressed(object sender, EventArgs e)
        {
            mPasscodeDots.AddDot();
            EnteredPasscode += mNumberPad.PressedButtonIndex;

            if (EnteredPasscode == PresetPasscode)
            {
                Unlock();
            }
            else if(mPasscodeDots.DotIndex == PasscodeDots.TOTAL_DOTS && EnteredPasscode != PresetPasscode)
            {
                UnlockFailed();
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            lbl_time.Content = $"{DateTime.Now: HH:mm}";
            lbl_date.Content = $"{DateTime.Now.DayOfWeek}, {(Months)DateTime.Today.Date.Month} {DateTime.Today.Date.Day}";
        }

        private void Btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            mPasscodeDots.DeleteAll();
            EnteredPasscode = "";
        }

        public void Unlock()
        {
            //AniShape.move(this, AniShape.MoveDirection.y, -1000, 0.5);
            AniShape.fadeOut(this);
            mMainWindow.Btn_lock.Visibility = Visibility.Visible;
            mPasscodeDots.DeleteAll();
            EnteredPasscode = "";

            mMainPage.mScreen1.LoadApps();
        }

        private void UnlockFailed()
        {
            AniShape.shake(mLockIcon, 10);
            AniShape.shake(mPasscodeDots);
            mPasscodeDots.DeleteAll();
            EnteredPasscode = "";
        }

        public void Lock()
        {
            AniShape.fadeIn(this);
            //this.Visibility = Visibility.Visible;
            //this.Opacity = 1;
            //AniShape.move(this, AniShape.MoveDirection.y, -1000, 0, 0.5);
            mMainWindow.Btn_lock.Visibility = Visibility.Collapsed;
        }
    }
}
