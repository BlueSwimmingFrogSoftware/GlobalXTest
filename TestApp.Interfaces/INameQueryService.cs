using System;
using System.Collections.Generic;
using System.Text;
using TestApp.Domain;

namespace TestApp.Interfaces
{
    public interface INameQueryService
    {
        IEnumerable<Name> GetNames();
    }
}
