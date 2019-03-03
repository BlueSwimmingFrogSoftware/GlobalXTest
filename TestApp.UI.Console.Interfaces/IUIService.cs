using System;
using System.Collections.Generic;
using System.Text;
using TestApp.Domain;
using TestApp.Model;

namespace TestApp.UI.Console.Interfaces
{
    public interface IUIService
    {
        void Show(SortedNameListModel names);
    }
}
