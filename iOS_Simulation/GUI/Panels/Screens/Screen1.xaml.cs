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

namespace iOS_Simulation.GUI.Panels.Screens
{
    /// <summary>
    /// Interaction logic for Screen1.xaml
    /// </summary>
    public partial class Screen1 : UserControl
    {
        public Screen1()
        {
            InitializeComponent();
        }

        public void LoadApps()
        {
            AniShape.moveXY(Grid_00, -100, 0, -100, 0, 0.3);
            AniShape.moveXY(Grid_01, -100, 0, -60, 0, 0.3);
        }
    }
}
