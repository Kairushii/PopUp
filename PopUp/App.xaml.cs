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

        public App()
        {
            _notifyIcon = new Forms.NotifyIcon();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow();
            MainWindow.Hide();

            _notifyIcon.Text = "PopUp Email";
            _notifyIcon.Icon = new System.Drawing.Icon("Images/envelope_50px.ico");
            _notifyIcon.Visible = true;

            _notifyIcon.ContextMenuStrip = new Forms.ContextMenuStrip();
            _notifyIcon.ContextMenuStrip.Items.Add("Set Timer", System.Drawing.Image.FromFile("Images/envelope_50px.ico"), OnStatusClicked);


            base.OnStartup(e);
        }

        private void OnStatusClicked(object sender, EventArgs e) 
        {
            
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _notifyIcon.Dispose();
            base.OnExit(e);
        }
    }
}
