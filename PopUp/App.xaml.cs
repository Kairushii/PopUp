using PopUp.Stores;
using PopUp.Viewmodels;
using System;
using System.Windows;
using Forms = System.Windows.Forms;


namespace PopUp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        
        private readonly Forms.NotifyIcon _notifyIcon;
        private TimerStore _timerStore;
        private TimerViewModel _timerViewModel;

        public App()
        {
            _notifyIcon = new Forms.NotifyIcon();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _timerStore = new TimerStore();
            _timerViewModel = new TimerViewModel(_timerStore);

            _notifyIcon.Text = "PopUp Email";
            _notifyIcon.Icon = new System.Drawing.Icon("Images/envelope_50px.ico");
            _notifyIcon.Visible = true;
            _notifyIcon.Click += NotifyIcon_Click;

            //_notifyIcon.ContextMenuStrip = new Forms.ContextMenuStrip();
            //_notifyIcon.ContextMenuStrip.Items.Add("Set Timer", System.Drawing.Image.FromFile("Images/envelope_50px.ico"), OnStatusClicked);
            MainWindow = new MainWindow();
            MainWindow.DataContext = _timerViewModel;
            MainWindow.Hide();  

            base.OnStartup(e);
        }

        //private void OnStatusClicked(object sender, EventArgs e) 
        //{

        //}
        private void OnStatusClicked(object sender, EventArgs e)
        {
            string status = _timerStore.IsRunning ? "Timer is running." : "Timer is stopped.";
            MessageBox.Show(status, "Status", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            MainWindow.WindowState = WindowState.Normal;
            MainWindow.Activate();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _notifyIcon.Dispose();
            base.OnExit(e);
        }
    }
}
