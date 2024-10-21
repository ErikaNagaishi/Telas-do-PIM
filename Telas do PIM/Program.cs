using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Telas_do_PIM.Forms;
using Telas_do_PIM.Models;

namespace Telas_do_PIM
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();

            ConfigureServices(services);

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                ServiceProvider = serviceProvider;
                var form = serviceProvider.GetRequiredService<TelaDeLogin>();
                form.StartPosition = FormStartPosition.CenterScreen;
                Application.Run(form);
            }
        }
        public static IServiceProvider ServiceProvider { get; private set; }
        private static void ConfigureServices(ServiceCollection services)
        {
            var _configuration = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .Build();

            var connection = _configuration.GetSection("ConnectionStrings:AzureDB").Value;

            services.AddDbContext<GenesisSolutionsContext>(
                options => options.UseSqlServer(connection));

            services.AddTransient<TelaDeLogin>();
            services.AddTransient<TelaCadastro>();
            services.AddTransient<TelaCadastroCliente>();
            services.AddTransient<TelaDeSelecao>();
            services.AddTransient<TelaPrincipal>();

        }
    }
}