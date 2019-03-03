using System;
using System.Collections.Generic;
using System.Text;
using TestApp.Domain;
using System.Linq;
using TestApp.Interfaces;

namespace TestApp.Services
{
    public class TransformationService : ITransformationService
    {
        public TransformationService()
        {
        }

        public IEnumerable<Name> Transform(IEnumerable<Name> names)
        {
            var sorted = names.OrderBy(n => n.LastName)
                               .ThenBy(n => n.FirstName)
                               .ThenBy(n => n.MiddleName1)
                               .ThenBy(n => n.MiddleName2);
            return sorted;
        }
    }
}
