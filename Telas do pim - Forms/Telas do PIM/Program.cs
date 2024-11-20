using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Text;
using Telas_do_PIM.Forms;
using Telas_do_PIM.Job;
using Telas_do_PIM.Models;
using XSystem.Security.Cryptography;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Telas_do_PIM
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
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
                CreateHostBuilder().Build().RunAsync();
                Application.Run(form);
            }
        }
        private static IHostBuilder CreateHostBuilder()
        {
            var _configuration = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .Build();
            var connection = _configuration.GetSection("ConnectionStrings:AzureDB").Value;
            return Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddDbContext<GenesisSolutionsContext>(
                    options => options
                            .UseLazyLoadingProxies()
                            .UseSqlServer(connection)
                            .EnableSensitiveDataLogging()
                            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                            .EnableDetailedErrors(), ServiceLifetime.Scoped);
                    services.AddHostedService<JobConsultaStatusPagamento>();
                });
        }

        public static IServiceProvider ServiceProvider { get; set; }
        public static Funcionario? funcionarioLogado { get; set; }
        public static Cliente? clienteLogado { get; set; }
        private static void ConfigureServices(ServiceCollection services)
        {
            var _configuration = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .Build();

            var connection = _configuration.GetSection("ConnectionStrings:AzureDB").Value;

            //Context para o banco de dados
            services.AddDbContext<GenesisSolutionsContext>(
                options => options
                            .UseLazyLoadingProxies()
                            .UseSqlServer(connection)
                            .EnableSensitiveDataLogging()
                            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                            .EnableDetailedErrors(),ServiceLifetime.Scoped);

            //Carregar o arquivo config json
            services.AddSingleton<IConfiguration>(_configuration);

            //Registrar os forms
            services.AddTransient<TelaDeLogin>();
            services.AddTransient<TelaCadastroFuncionario>();
            services.AddTransient<TelaCadastroCliente>();
            services.AddTransient<TelaCadastroProduto>();
            services.AddTransient<TelaDeSelecao>();
            services.AddTransient<TelaPrincipal>();
            services.AddTransient<TelaManutencaoFuncionario>();
            services.AddTransient<TelaManutencaoClientes>();
            services.AddTransient<TelaManutencaoProdutos>();
            services.AddTransient<TelaCarregamentoProdutos>();
            services.AddTransient<TelaEsqueceuSenha>();
            services.AddTransient<TelaCadastroCategoria>();
            services.AddTransient<TelaAtualizaImagemProduto>();
            services.AddTransient<TelaCartaoCreditoMP>();


        }
        public static string Encrypt(string value)
        {
            //Using MD5 to encrypt a string
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                //Hash data
                byte[] data = md5.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);
            }
        }
    }
}