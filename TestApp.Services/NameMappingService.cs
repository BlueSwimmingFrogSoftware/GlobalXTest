using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestApp.Domain;
using TestApp.Interfaces;

namespace TestApp.Services
{
    public class NameMappingService : INameMappingService
    {
        public NameMappingService()
        {

        }

        public Name Map(string line)
        {
            if (String.IsNullOrEmpty(line)) throw new InvalidOperationException("Parameter must not be null or empty");

            var nameParts = line.Split(" ");

            if (nameParts.Length < 2) throw new InvalidOperationException("Cannot parse full name");

            var n = new Name();

            n.DisplayName = line;
            n.FirstName = nameParts.First();
            n.LastName = nameParts.Last();
            n.MiddleName1 = "";
            n.MiddleName2 = "";

            if (nameParts.Length == 3)
            {
                n.MiddleName1 = nameParts[1];
            }

            if (nameParts.Length > 3)
            {
                n.MiddleName1 = nameParts[1];
                n.MiddleName2 = nameParts[2];
            }


            return n;
        }
    }
}
