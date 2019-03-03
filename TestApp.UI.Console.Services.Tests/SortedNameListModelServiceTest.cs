using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using TestApp.Domain;

namespace TestApp.UI.Console.Services.Tests
{
    [TestClass]
    public class SortedNameListModelServiceTest
    {
        private SortedNameListModelService svc;

        void Prepare()
        {
            svc = new SortedNameListModelService();
        }

        [TestMethod]
        public void ItWillCreateViewModel()
        {
            Prepare();

            var input = new List<Name>();

            input.Add(new Name { DisplayName = "Adam Spolsky", FirstName = "Adam", LastName = "Spolsky", MiddleName1 = "", MiddleName2 = "" });
            input.Add(new Name { DisplayName = "Joe Doe", FirstName = "Joe", LastName = "Doe", MiddleName1 = "", MiddleName2 = "" });
            input.Add(new Name { DisplayName = "Jane Helen Doe", FirstName = "Jane", LastName = "Doe", MiddleName1 = "Helen", MiddleName2 = "" });
            input.Add(new Name { DisplayName = "Jane Doe", FirstName = "Jane", LastName = "Doe", MiddleName1 = "", MiddleName2 = "" });

            var output = svc.GetModel(input);

            Assert.IsNotNull(output);
            Assert.IsNotNull(output.Names);
            Assert.AreEqual(output.Names.Count(), 4);
        }


    }
}
