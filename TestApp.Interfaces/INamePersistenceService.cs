using System;
using System.Collections.Generic;
using System.Text;
using TestApp.Domain;

namespace TestApp.Interfaces
{
    public interface INamePersistenceService
    {
        void SaveNames(IEnumerable<Name> names);
    }
}
