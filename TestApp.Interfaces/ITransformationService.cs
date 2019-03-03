using System;
using System.Collections.Generic;
using System.Text;
using TestApp.Domain;

namespace TestApp.Interfaces
{
    public interface ITransformationService
    {
        IEnumerable<Name> Transform(IEnumerable<Name> names);
    }
}
