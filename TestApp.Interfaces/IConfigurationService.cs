using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Interfaces
{
    public interface IConfigurationService
    {
        string InputPath { get; }
        string OutputPath { get; }
    }
}
