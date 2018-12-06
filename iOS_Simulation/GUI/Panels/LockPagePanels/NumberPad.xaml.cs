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

namespace iOS_Simulation.GUI.Panels.LockPagePanels
{
    /// <summary>
    /// Interaction logic for NumberPad.xaml
    /// </summary>
    public partial class NumberPad : UserControl
    {
        public event EventHandler IsPressed;
        public int PressedButtonIndex = 0;

        const int NUM_BUTTONS = 10;
        Button[] ButtonArr = new Button[NUM_BUTTONS];
        public NumberPad()
        {
            InitializeComponent();

            ButtonArr[0] = Btn_0;
            ButtonArr[1] = Btn_1;
            ButtonArr[2] = Btn_2;
            ButtonArr[3] = Btn_3;
            ButtonArr[4] = Btn_4;
            ButtonArr[5] = Btn_5;
            ButtonArr[6] = Btn_6;
            ButtonArr[7] = Btn_7;
            ButtonArr[8] = Btn_8;
            ButtonArr[9] = Btn_9;
        }
 
        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < NUM_BUTTONS; i++)
            {
                if (sender == ButtonArr[i])
                {
                    PressedButtonIndex = i;
                    if (this.IsPressed != null)
                        this.IsPressed(new object(), new EventArgs());
                }
            }
        }
    }
}
