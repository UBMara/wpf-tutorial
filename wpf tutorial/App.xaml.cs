using System.Configuration;
using System.Data;
using System.Windows;
using wpf_tutorial.Stores;
using wpf_tutorial.ViewModels;

namespace wpf_tutorial
{
    public partial class App : Application
    {   
        private readonly SelectedYTVStore _selectedYTVStore;

        public App()
        {
            _selectedYTVStore = new SelectedYTVStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new YTVViewModel(_selectedYTVStore)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }
    }

}
