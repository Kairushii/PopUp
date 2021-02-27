using PopUp.Service;
using PopUp.Stores;
using PopUp.Viewmodels;
using System;
using System.Drawing;
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
            _notifyIcon.Icon = new Icon("Images/envelope_50px.ico");
            _notifyIcon.Text = "SingletonSean";
            _notifyIcon.Click += NotifyIcon_Click;

            _notifyIcon.ContextMenuStrip = new Forms.ContextMenuStrip();
            _notifyIcon.ContextMenuStrip.Items.Add("Status", Image.FromFile("Images/envelope_50px.ico"), OnStatusClicked);
        

            _notifyIcon.Visible = true;

            _timerStore = new TimerStore(new NotifyIconNotificationService(_notifyIcon));
            _timerViewModel = new TimerViewModel(_timerStore);

            MainWindow = new MainWindow();
            MainWindow.DataContext = _timerViewModel;
            MainWindow.Show();

            base.OnStartup(e);
        }

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
            _timerViewModel.Dispose();
            _timerStore.Dispose();

            base.OnExit(e);
        }
    }
}
