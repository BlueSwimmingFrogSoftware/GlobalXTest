using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestApp.Interfaces;
using TestApp.UI.Console.Interfaces;

namespace TestApp.UI.Console.Services
{
    public class ControllerService : IControllerService
    {
        private readonly IUIService uiSvc;
        private readonly INameQueryService nameQrySvc;
        private readonly INamePersistenceService namePersistenceSvc;
        private readonly ITransformationService transformSvc;
        private readonly ISortedNameListModelService modelSvc;

        public ControllerService(IUIService uiSvc,
                                 INameQueryService nameQrySvc,
                                 INamePersistenceService namePersistenceSvc,
                                 ITransformationService transformSvc,
                                 ISortedNameListModelService modelSvc)
        {
            this.uiSvc = uiSvc;
            this.nameQrySvc = nameQrySvc;
            this.namePersistenceSvc = namePersistenceSvc;
            this.transformSvc = transformSvc;
            this.modelSvc = modelSvc;
        }

        public void Run()
        {
            var names = nameQrySvc.GetNames();
            var namesTransformed = transformSvc.Transform(names);

            namePersistenceSvc.SaveNames(namesTransformed);

            var model = modelSvc.GetModel(namesTransformed);

            uiSvc.Show(model);
        }
    }
}
