using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestApp.Services.Tests
{
    [TestClass]
    public class ConfigurationServiceTest
    {
        private ConfigurationService svc;
        private string param1 = "./test.txt";
        void Prepare()
        {
            svc = new ConfigurationService(new string[] { param1 });
        }

        [TestMethod]
        public void ItWillLoadConfigurationParamters()
        {
            Prepare();

            Assert.AreEqual(svc.InputPath, param1);
            Assert.AreEqual(svc.OutputPath, "sorted-names-list.txt");
        }
    }
}
