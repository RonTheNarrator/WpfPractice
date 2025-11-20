using System.Configuration;
using System.Data;
using System.Windows;

namespace HelloWPFApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public void AppStartup(object sender, StartupEventArgs e)
        {
            if (e.Args.Length > 0)
            {
                MessageBox.Show(e.Args[0]);
            }
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show($"Unhandled exception: {e.ToString}");
            //e.Handled = true;
        }
    }

}
