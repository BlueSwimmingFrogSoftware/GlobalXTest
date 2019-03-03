using System;
using Microsoft.Extensions.DependencyInjection;
using TestApp.DI;
using TestApp.UI.Console.Interfaces;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var c = new UIConsoleServiceProviderFactory(args);
            var p = c.GetServiceProvider();

            var svc = p.GetService<IControllerService>();

            svc.Run();
        }
    }
}
