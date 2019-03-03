using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using TestApp.Interfaces;
using TestApp.Services;
using TestApp.UI.Console.Interfaces;
using TestApp.UI.Console.Services;

namespace TestApp.DI
{
    public class UIConsoleServiceProviderFactory
    {

        private string[] args;
        public UIConsoleServiceProviderFactory(string[] args)
        {
            this.args = args;
        }

        public ServiceProvider GetServiceProvider()
        {
            var p = new ServiceCollection()
            .AddTransient<INameQueryService,NameQueryService>()
            .AddTransient<INamePersistenceService,NamePersistenceService>()
            .AddTransient<IUIService, UIService>()
            .AddTransient<IControllerService, ControllerService>()
            .AddTransient<ITransformationService, TransformationService>()
            .AddTransient<IConfigurationService, ConfigurationService>(n => new ConfigurationService(args))
            .AddTransient<INameMappingService, NameMappingService>()
            .AddTransient<ISortedNameListModelService, SortedNameListModelService>()
            .BuildServiceProvider();

            return p;
        }
    }
}
