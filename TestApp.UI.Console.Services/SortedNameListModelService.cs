using System;
using System.Collections.Generic;
using System.Text;
using TestApp.Domain;
using TestApp.UI.Console.Interfaces;
using TestApp.Model;

namespace TestApp.UI.Console.Services
{
    public class SortedNameListModelService : ISortedNameListModelService
    {
        public SortedNameListModelService()
        {

        }

        public SortedNameListModel GetModel(IEnumerable<Name> names)
        {
            var model = new SortedNameListModel();
            model.Names = names;

            return model;
        }
    }
}
