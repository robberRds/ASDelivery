using System;
using System.Collections;
using PX.Data;
using PX.Data.BQL.Fluent;
using PX.Objects.AR;

namespace ASDelivery
{
    public class ASControllerWorkplaceMaint : PXGraph<ASControllerWorkplaceMaint>
    {
        #region Views

        public SelectFrom<ASControllerWorkplace>.View ControllerWorkplaceView;

        public SelectFrom<ARInvoice>.
            /*Where<ARInvoice.docDate.IsEqual<AccessInfo.businessDate.FromCurrent>>.*/
            OrderBy<Desc<ARInvoice.docDate>>.
            View InvoiceView;

        #endregion

        #region Action

        public PXAction<ARInvoice> CreateInvoices;
        [PXButton(DisplayOnMainToolbar = false)]
        [PXUIField(DisplayName = "Create Invoices", Enabled = true)]
        protected virtual IEnumerable createInvoices(PXAdapter adapter)
        {
            ARInvoiceEntry graph = PXGraph.CreateInstance<ARInvoiceEntry>();
            graph.Document.Cache.IsDirty = true; // Помечаем документ как измененный, чтобы сохранить его

            PXRedirectHelper.TryRedirect(graph, PXRedirectHelper.WindowMode.NewWindow); // Переходим на новую страницу создания счета-фактуры

            yield return adapter.Get();
        }
        public PXAction<ARInvoice> CreatePreparation;
        [PXButton(DisplayOnMainToolbar = false)]
        [PXUIField(DisplayName = "Create Preparation", Enabled = true)]
        protected virtual IEnumerable createPreparation(PXAdapter adapter)
        {
            ARInvoiceEntry graph = PXGraph.CreateInstance<ARInvoiceEntry>();
            graph.Document.Cache.IsDirty = true; // Помечаем документ как измененный, чтобы сохранить его

            PXRedirectHelper.TryRedirect(graph, PXRedirectHelper.WindowMode.NewWindow); // Переходим на новую страницу создания счета-фактуры

            yield return adapter.Get();
        }

        #endregion

        #region Events
        
        #endregion
    }
}