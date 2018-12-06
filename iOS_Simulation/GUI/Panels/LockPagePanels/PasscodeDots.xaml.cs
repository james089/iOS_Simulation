using iOS_Simulation.Main;
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
    /// Interaction logic for PasscodeDots.xaml
    /// </summary>
    public partial class PasscodeDots : UserControl
    {
        public const int TOTAL_DOTS = 6;
        Border[] mBorders = new Border[TOTAL_DOTS];
        public int DotIndex = 0;
        
        public PasscodeDots()
        {
            InitializeComponent();
            mBorders[0] = Dot1;
            mBorders[1] = Dot2;
            mBorders[2] = Dot3;
            mBorders[3] = Dot4;
            mBorders[4] = Dot5;
            mBorders[5] = Dot6;
        }

        public void AddDot()
        {
            if (DotIndex < TOTAL_DOTS)
            { 
                mBorders[DotIndex].Background = mBrushes.White;
                mBorders[DotIndex].BorderThickness = new Thickness(0);
                DotIndex ++;
            }
        }

        public void DeletDot()
        {
            if (DotIndex >= 0)
            {
                mBorders[DotIndex - 1].Background = mBrushes.Transparent;
                mBorders[DotIndex - 1].BorderThickness = new Thickness(2);
                DotIndex--;
            }
        }

        public void DeleteAll()
        {
            DotIndex = 0;
            for (int i = 0; i < TOTAL_DOTS; i++)
            {
                mBorders[i].Background = mBrushes.Transparent;
                mBorders[i].BorderThickness = new Thickness(2);
            }
        }
    }
}
