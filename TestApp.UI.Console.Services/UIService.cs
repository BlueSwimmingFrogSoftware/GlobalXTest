using System;
using System.Collections.Generic;
using System.Text;
using TestApp.Domain;
using TestApp.UI.Console.Interfaces;
using TestApp.Model;

namespace TestApp.UI.Console.Services
{
    public class UIService : IUIService
    {
        public UIService()
        {

        }

        public void Show(SortedNameListModel model)
        {
            foreach (var n in model.Names)
            {
                System.Console.WriteLine(n.DisplayName);
            }

        }
    }
}
