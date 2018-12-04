﻿using iOS_Simulation.Services;
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
using iOS_Simulation.GUI.Pages;
using iOS_Simulation.GUI.Helpers;

namespace iOS_Simulation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow mMainWindow = null;
        public MainWindow()
        {
            mMainWindow = this;
            InitializeComponent();

            GUIUpdateService.UpdateRoutineSetup();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GUIUpdateService.StartUpdateRoutine();

            Uri homeUri = MainPage.pageUri;
            Frame pFrame = mFrame;

            UINavigation.navControl = new UINavigation(homeUri, pFrame);
            UINavigation.GoToHomePage();
        }

        private void Grid_titleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }


        #region Gestures
        public enum GestureType
        {
            swipeUpFromBottomEdge,
            swipeRightFromLeftEdge
        }
        bool isGestureStarted = false;
        bool isMouseDown = false;
        Point startPoint = new Point(0, 0);
        private void Grid_gestureArea_bottom_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isMouseDown = true;
            lbl_debug.Content = $"{e.GetPosition(Grid_wholeSimulationArea).X}, {e.GetPosition(Grid_wholeSimulationArea).Y}";
        }
        #endregion Gestures

        private void Grid_gestureArea_bottom_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void Grid_gestureArea_bottom_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private double GetDistance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }
    }
}
