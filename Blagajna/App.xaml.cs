using HandyControl.Tools;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Windows;

namespace ServisVozila
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string ConnectionString { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            // Set culture to English
            //var culture = new CultureInfo("en-US");
            //Thread.CurrentThread.CurrentCulture = culture;
            //Thread.CurrentThread.CurrentUICulture = culture;

            base.OnStartup(e);
            ConfigHelper.Instance.SetLang("en");
        }
    }

}
