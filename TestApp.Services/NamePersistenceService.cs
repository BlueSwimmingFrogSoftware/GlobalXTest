using System;
using System.Collections.Generic;
using System.Text;
using TestApp.Domain;
using System.IO;
using TestApp.Interfaces;

namespace TestApp.Services
{
    public class NamePersistenceService : INamePersistenceService
    {

        private readonly IConfigurationService configSvc;
        public NamePersistenceService(IConfigurationService configSvc)
        {
            this.configSvc = configSvc;
        }

        public void SaveNames(IEnumerable<Name> names)
        {
            var path = configSvc.OutputPath;

            FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate);
            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                foreach(var n in names)
                {
                    writer.WriteLine(n.DisplayName);
                }
            }
        }
    }
}
