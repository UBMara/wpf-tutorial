using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using wpf_tutorial.Stores;
using wpf_tutorial.ViewModels;
using wpftutorial.Domain.Commands;
using wpftutorial.Domain.Queries;
using wpftutorialFramework;
using wpftutorialFramework.Commands;
using wpftutorialFramework.Querues;
using wpf_tutorial.HostBuilders;

namespace wpf_tutorial
{
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .AddDbContext()
                .ConfigureServices((context, services) =>
                {

                services.AddSingleton<IGetAllYTVQuery ,GetAllYTVQuery>();
                services.AddSingleton<ICreateCommand ,CreateViewerCommand>();
                services.AddSingleton<IUpdateCommand ,UpdateViewerCommand>();
                services.AddSingleton<IDeleteCommand ,DeleteViewerCommand>();

                services.AddSingleton<ModelNavigationStore>();
                services.AddSingleton<YTVStore>();
                services.AddSingleton<SelectedYTVStore>();

                services.AddTransient<YTVViewModel>(CreateYTVViewModel);
                services.AddSingleton<MainViewModel>();

                 services.AddSingleton<MainWindow>((services) => new MainWindow(){
                        DataContext = services.GetRequiredService<MainViewModel>()
                    });
                })
                .Build();
        }

        private YTVViewModel CreateYTVViewModel(IServiceProvider services)
        {
            return YTVViewModel.LoadViewModel(
                services.GetRequiredService<YTVStore>(),
                services.GetRequiredService<SelectedYTVStore>(),
                services.GetRequiredService<ModelNavigationStore>());
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            YTViewrsDBContextFactory ytvFactory = _host.Services.GetRequiredService<YTViewrsDBContextFactory>();

            using (YTViewrsDBContext context = ytvFactory.Create())
            {
                context.Database.Migrate();
            }

            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();
            base.OnStartup(e);
        }
        protected override void OnExit(ExitEventArgs e)
        {
            _host.StopAsync();
            _host.Dispose();

            base.OnExit(e);
        }
    }

}
