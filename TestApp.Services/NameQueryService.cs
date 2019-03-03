using System;
using System.Collections.Generic;
using System.Text;
using TestApp.Domain;
using System.IO;
using TestApp.Interfaces;

namespace TestApp.Services
{
    public class NameQueryService : INameQueryService
    {
        private readonly IConfigurationService configSvc;
        private readonly INameMappingService nameMappingSvc;

        public NameQueryService(IConfigurationService configSvc,
                                INameMappingService nameMappingSvc)
        {
            this.configSvc = configSvc;
            this.nameMappingSvc = nameMappingSvc;
        }

        public IEnumerable<Name> GetNames()
        {
            var names = new List<Name>();
            var path = configSvc.InputPath;

            FileStream fileStream = new FileStream(path, FileMode.Open);
            using (StreamReader reader = new StreamReader(fileStream))
            {
              
                while(!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    var n = nameMappingSvc.Map(line);

                    names.Add(n);
                }  
            }

            return names;
        }
    }
}
