using BombonesApp2026.Ioc;
using Microsoft.Extensions.DependencyInjection;

namespace BombonesApp2026.Windows
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection();

            services.AddApplicationServices();

            //Luego tenemos acá que crear los servicios de los form

            //services.AddTransient<frmLogin>();
            //services.AddTransient<frmPrincipal>();

            var formularios=typeof(Program).Assembly.GetTypes()
                .Where(t=>t.IsSubclassOf(typeof(Form)) && !t.IsAbstract) .ToList();
            foreach (var frm in formularios)
            {
                services.AddTransient(frm);
            }

            using (var provider = services.BuildServiceProvider())
            {
                // To customize application configuration such as set high DPI settings or default font,
                // see https://aka.ms/applicationconfiguration.
                ApplicationConfiguration.Initialize();
                Application.Run(provider.GetRequiredService<frmLogin>());

            }

        }
    }
}