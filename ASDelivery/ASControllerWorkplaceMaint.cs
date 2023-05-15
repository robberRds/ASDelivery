using System;
using PX.Data;
using PX.Data.BQL.Fluent;
using PX.Objects.AR;

namespace ASDelivery
{
    public class ASControllerWorkplaceMaint : PXGraph<ASControllerWorkplaceMaint>
    {
        public SelectFrom<ASControllerWorkplace>.View ControllerWorkplace;

        public SelectFrom<ARInvoice>.
            Where<ARInvoice.docDate.IsEqual<AccessInfo.businessDate.FromCurrent>>.
            OrderBy<Desc<ARInvoice.docDate>>.
            View InvoiceView;

        //public PXSave<MasterTable> Save;
        //public PXCancel<MasterTable> Cancel;
    }
}