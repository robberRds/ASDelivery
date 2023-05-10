using System;
using PX.Data;
using PX.Data.BQL.Fluent;

namespace ASDelivery
{
    public class ASSetupMaint : PXGraph<ASSetupMaint>
    {

        public PXSave<ASSetup> Save;
        public PXCancel<ASSetup> Cancel;

        public SelectFrom<ASSetup>.View SetupView;
    }
}