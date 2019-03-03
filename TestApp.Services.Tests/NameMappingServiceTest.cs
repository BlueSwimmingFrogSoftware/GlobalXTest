using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestApp.Interfaces;

namespace TestApp.Services.Tests
{
    [TestClass]
    public class NameMappingServiceTest
    {
        private INameMappingService svc;
        public void Prepare()
        {
            svc = new NameMappingService();
        }

        [TestMethod]
        public void ItWillMapFirstLastNames()
        {
            Prepare();

            var input = "Joe Doe";
            var n = svc.Map(input);

            Assert.IsNotNull(n);
            Assert.AreEqual(n.FirstName, "Joe");
            Assert.AreEqual(n.MiddleName1, "");
            Assert.AreEqual(n.MiddleName2, "");
            Assert.AreEqual(n.LastName, "Doe");
            Assert.AreEqual(n.DisplayName, "Joe Doe");
        }

        [TestMethod]
        public void ItWillMapFirstMiddleLastNames()
        {

            Prepare();

            var input = "Joe Magic Doe";
            var n = svc.Map(input);

            Assert.IsNotNull(n);
            Assert.AreEqual(n.FirstName, "Joe");
            Assert.AreEqual(n.MiddleName1, "Magic");
            Assert.AreEqual(n.MiddleName2, "");
            Assert.AreEqual(n.LastName, "Doe");
            Assert.AreEqual(n.DisplayName, "Joe Magic Doe");
        }


        [TestMethod]
        public void ItWillMapFirstMiddleMiddleLastNames()
        {
            Prepare();

            var input = "Joe Magic Ivanovich Doe";
            var n = svc.Map(input);

            Assert.IsNotNull(n);
            Assert.AreEqual(n.FirstName, "Joe");
            Assert.AreEqual(n.MiddleName1, "Magic");
            Assert.AreEqual(n.MiddleName2, "Ivanovich");
            Assert.AreEqual(n.LastName, "Doe");
            Assert.AreEqual(n.DisplayName, "Joe Magic Ivanovich Doe");
        }

        [TestMethod]
        public void ItWillIgnore3rdMiddleName()
        {
            Prepare();

            var input = "Joe Magic Ivanovich Carl Doe";
            var n = svc.Map(input);

            Assert.IsNotNull(n);
            Assert.AreEqual(n.FirstName, "Joe");
            Assert.AreEqual(n.MiddleName1, "Magic");
            Assert.AreEqual(n.MiddleName2, "Ivanovich");
            Assert.AreEqual(n.LastName, "Doe");
            Assert.AreEqual(n.DisplayName, "Joe Magic Ivanovich Carl Doe");
        }

        [TestMethod]
        public void ItWillFailWhenOneName()
        {
            Prepare();

            var input = "Doe";

            Assert.ThrowsException<System.InvalidOperationException>(() => svc.Map(input));
        }

    }
}
