using Microsoft.Extensions.DependencyInjection;
using ppedv.CarCare.Logic.Core;
using ppedv.CarCare.Model.Contracts;
using ppedv.CarCare.UI.WPF.ViewModels;
using ppedv.CarCare.UI.WPF.Views;
using System.Configuration;
using System.Data;
using System.Windows;

namespace ppedv.CarCare.UI.WPF
{
    public sealed partial class App : Application
    {
        public App()
        {
            Services = ConfigureServices();

            this.InitializeComponent();
        }

        /// <summary>
        /// Gets the current <see cref="App"/> instance in use
        /// </summary>
        public new static App Current => (App)Application.Current;

        /// <summary>
        /// Gets the <see cref="IServiceProvider"/> instance to resolve application services.
        /// </summary>
        public IServiceProvider Services { get; }

        /// <summary>
        /// Configures the services for the application.
        /// </summary>
        private static IServiceProvider ConfigureServices()
        {
            var conString = "Server=(localdb)\\mssqllocaldb;Database=CarCare_Test;Trusted_Connection=true;";
            var services = new ServiceCollection();

            services.AddTransient<IRepository>(x => new Data.EfCore.CarCareContextRepositoryAdapter(conString));
            services.AddSingleton<GarageService>();
            services.AddSingleton<CarsViewModel>();

            return services.BuildServiceProvider();
        }
    }
}
