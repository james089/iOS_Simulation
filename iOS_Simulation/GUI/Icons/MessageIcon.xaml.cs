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

namespace iOS_Simulation.GUI.Icons
{
    /// <summary>
    /// Interaction logic for MessageIcon.xaml
    /// </summary>
    public partial class MessageIcon : UserControl
    {
        public MessageIcon()
        {
            InitializeComponent();
        }

        public event EventHandler IsPressed;
        private void Btn_enter_Click(object sender, RoutedEventArgs e)
        {
            if (this.IsPressed != null)
                this.IsPressed(new object(), new EventArgs());
        }

    }
}
