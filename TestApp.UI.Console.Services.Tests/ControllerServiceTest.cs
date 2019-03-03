using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestApp.Interfaces;
using TestApp.UI.Console.Interfaces;

using Moq;
using System.Collections.Generic;
using TestApp.Domain;
using TestApp.Model;

namespace TestApp.UI.Console.Services.Tests
{
    [TestClass]
    public class ControllerServiceTest
    {
        private ControllerService svc;

        private INameQueryService nameQuerySvc;
        private IUIService uiSvc;
        private INamePersistenceService namePersistSvc;
        private ITransformationService transformSvc;
        private ISortedNameListModelService modelSvc;

        private Mock<INameQueryService> mockNameQuerySvc;
        private Mock<IUIService> mockUISvc;
        private Mock<INamePersistenceService> mockNamePersistSvc;
        private Mock<ITransformationService> mockTransformSvc;
        private Mock<ISortedNameListModelService> mockModelSvc;

        private List<Name> input;
        private List<Name> sortedList;
        private SortedNameListModel model;

        void Prepare()
        {
            mockNameQuerySvc = new Mock<INameQueryService>();

            input = new List<Name>();
            mockNameQuerySvc.Setup(n => n.GetNames()).Returns(input);
            nameQuerySvc = mockNameQuerySvc.Object;

            mockNamePersistSvc = new Mock<INamePersistenceService>();
            mockNamePersistSvc.Setup(n => n.SaveNames(It.IsAny<IEnumerable<Name>>()));
            namePersistSvc = mockNamePersistSvc.Object;

            sortedList = new List<Name>();

            mockTransformSvc = new Mock<ITransformationService>();
            mockTransformSvc.Setup(n => n.Transform(It.IsAny<IEnumerable<Name>>())).Returns(sortedList);
            transformSvc = mockTransformSvc.Object;

            model = new SortedNameListModel();
            mockModelSvc = new Mock<ISortedNameListModelService>();
            mockModelSvc.Setup(n => n.GetModel(input)).Returns(model);
            modelSvc = mockModelSvc.Object;

            mockUISvc = new Mock<IUIService>();
            mockUISvc.Setup(n => n.Show(It.IsAny<SortedNameListModel>()));
            uiSvc = mockUISvc.Object;

            svc = new ControllerService(uiSvc, nameQuerySvc, namePersistSvc, transformSvc, modelSvc);
        }

        [TestMethod]
        public void ItWillExecuteServices()
        {
            Prepare();

            svc.Run();

            mockNameQuerySvc.Verify(n => n.GetNames(), Times.Once);
            mockNamePersistSvc.Verify(n => n.SaveNames(It.Is<IEnumerable<Name>>(x => x == sortedList)), Times.Once);
            mockTransformSvc.Verify(n => n.Transform(It.Is<IEnumerable<Name>>(x => x == input)), Times.Once);
            mockModelSvc.Verify(n => n.GetModel(It.Is<IEnumerable<Name>>(x => x == sortedList)), Times.Once);
            mockUISvc.Verify(n => n.Show(It.Is<SortedNameListModel>(x => x == model)), Times.Once);

        }
    }
}
