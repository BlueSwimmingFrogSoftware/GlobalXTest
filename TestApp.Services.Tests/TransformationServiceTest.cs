using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using TestApp.Domain;

namespace TestApp.Services.Tests
{
    [TestClass]
    public class TransformationServiceTest
    {
        private TransformationService svc;

        void Prepare()
        {
            svc = new TransformationService();
        }

        [TestMethod]
        public void ItWillSortByLastName()
        {
            Prepare();

            var input = new List<Name>();
            input.Add(new Name { DisplayName = "Adam Spolsky", FirstName = "Adam", LastName = "Spolsky", MiddleName1 = "", MiddleName2 = "" });
            input.Add(new Name { DisplayName = "Joe Doe", FirstName = "Joe", LastName = "Doe", MiddleName1 = "", MiddleName2 = "" });

            var output = svc.Transform(input).ToList();

            Assert.IsNotNull(output);
            Assert.AreEqual(output.Count(), 2);
            Assert.AreEqual(output.First().LastName, "Doe");
        }

        [TestMethod]
        public void ItWillSortByLastNameThenByFirstName()
        {
            Prepare();

            var input = new List<Name>();
           
            input.Add(new Name { DisplayName = "Adam Spolsky", FirstName = "Adam", LastName = "Spolsky", MiddleName1 = "", MiddleName2 = "" });
            input.Add(new Name { DisplayName = "Joe Doe", FirstName = "Joe", LastName = "Doe", MiddleName1 = "", MiddleName2 = "" });
            input.Add(new Name { DisplayName = "Jane Doe", FirstName = "Jane", LastName = "Doe", MiddleName1 = "", MiddleName2 = "" });

            var output = svc.Transform(input).ToList();

            Assert.IsNotNull(output);
            Assert.AreEqual(output.Count(), 3);
            Assert.AreEqual(output.First().FirstName, "Jane");
            Assert.AreEqual(output.First().LastName, "Doe");
        }

        [TestMethod]
        public void ItWillSortByLastNameThenByFirstNameAndThenByMiddle()
        {
            Prepare();

            var input = new List<Name>();

            input.Add(new Name { DisplayName = "Adam Spolsky", FirstName = "Adam", LastName = "Spolsky", MiddleName1 = "", MiddleName2 = "" });
            input.Add(new Name { DisplayName = "Joe Doe", FirstName = "Joe", LastName = "Doe", MiddleName1 = "", MiddleName2 = "" });
            input.Add(new Name { DisplayName = "Jane Helen Doe", FirstName = "Jane", LastName = "Doe", MiddleName1 = "Helen", MiddleName2 = "" });
            input.Add(new Name { DisplayName = "Jane Doe", FirstName = "Jane", LastName = "Doe", MiddleName1 = "", MiddleName2 = "" });

            var output = svc.Transform(input).ToList();

            Assert.IsNotNull(output);
            Assert.AreEqual(output.Count(), 4);
            Assert.AreEqual(output.First().DisplayName, "Jane Doe");
          
        }
    }
}
