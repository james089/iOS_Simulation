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
    /// Interaction logic for NumberButton.xaml
    /// </summary>
    public partial class NumberButton : Button
    {
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("ExTxt", typeof(string), typeof(NumberButton), new PropertyMetadata(""));

        public String ExTxt
        {
            get { return (String)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public NumberButton()
        {
            InitializeComponent();
        }
    }
}
