using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using static iOS_Simulation.MainWindow;

namespace iOS_Simulation.Services
{
    class GUIUpdateService
    {
        private static BackgroundWorker mUpdateRoutine = new BackgroundWorker();
        private const int UPDATE_INTERVAL = 50;

        public static void UpdateRoutineSetup()
        {
            mUpdateRoutine.DoWork += new DoWorkEventHandler(mUpdateRoutine_doWork);
            mUpdateRoutine.ProgressChanged += new ProgressChangedEventHandler(mUpdateRoutine_ProgressChanged);
            mUpdateRoutine.RunWorkerCompleted += new RunWorkerCompletedEventHandler(mUpdateRoutine_WorkerCompleted);
            mUpdateRoutine.WorkerReportsProgress = true;
            mUpdateRoutine.WorkerSupportsCancellation = true;
        }

        public static void StartUpdateRoutine()
        {
            if (!mUpdateRoutine.IsBusy)
                mUpdateRoutine.RunWorkerAsync();
        }

        //static int counter_ping_camera = 0;
        private static void mUpdateRoutine_doWork(object sender, DoWorkEventArgs e)
        {
            while (!mUpdateRoutine.CancellationPending)
            {
                mUpdateRoutine.ReportProgress(0);
                Thread.Sleep(UPDATE_INTERVAL);
            }
        }

        private static void mUpdateRoutine_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            mMainWindow.lbl_time.Content = $"{DateTime.Now : h:mm}";
        }

        private static void mUpdateRoutine_WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Update thread stopped unexpectedly. Shut down program");
            Application.Current.Shutdown();
        }
    }
}
