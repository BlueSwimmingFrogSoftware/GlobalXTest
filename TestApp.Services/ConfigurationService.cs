using System;
using System.Collections.Generic;
using System.Text;
using TestApp.Interfaces;

namespace TestApp.Services
{
    public class ConfigurationService : IConfigurationService
    {
        public ConfigurationService(string[] args)
        {
            InputPath = "";

            if (args == null || args.Length > 0)
            {
                InputPath = args[0];
            }

            OutputPath = "sorted-names-list.txt";
        }

        public string InputPath { get; }
        public string OutputPath { get; }

    }
}
