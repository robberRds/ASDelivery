using PX.Data;
using PX.Data.BQL.Fluent;
using System.Collections;

namespace ASDelivery
{
    public class ASPreparationMaint : PXGraph<ASPreparationMaint, ASPreparation>
    {
        #region Graph constructor
        public ASPreparationMaint()
        {
            ASSetup setup = AutoNumSetup.Current;
        }
        #endregion

        public SelectFrom<ASPreparation>.View Preparation;
        public SelectFrom<ASOrder>.View Order;
        public SelectFrom<ASHistory>.View History;

        public PXSetup<ASSetup> AutoNumSetup;

        #region Events
        protected void _(Events.FieldUpdated<ASPreparation, ASPreparation.finishOfPreparation> e)
        {
            ASPreparation row = e.Row;
            ASHistory rev = History.Insert();
            rev.EmployerID = row.EmployerID;
            rev.StartOfPreparation = row.StartOfPreparation;
            rev.FinishOfPreparation = row.FinishOfPreparation;
            History.Update(rev);
        }

        //protected void _(Events.FieldUpdated<ASOrder, ASOrder.orderID> e)
        //{
        //    ASOrder order = e.Row;
        //    order.RecipeID = typeof(Search<ASRecipe, Where<ASRecipe.dishID, Equal<ASOrder.orderID>>>);
        //}
        #endregion

        #region Actions
        public PXAction<ASPreparation> OnHoldAction;
        [PXButton(), PXUIField(DisplayName = "Remove Hold",
        MapEnableRights = PXCacheRights.Select,
        MapViewRights = PXCacheRights.Select)]
        protected virtual IEnumerable onHoldAction(PXAdapter adapter)
        => adapter.Get();

        public PXAction<ASPreparation> OpenAction;
        [PXButton, PXUIField(DisplayName = "Open",
          MapEnableRights = PXCacheRights.Select,
          MapViewRights = PXCacheRights.Select)]
        protected virtual IEnumerable openAction(PXAdapter adapter) => adapter.Get();

        public PXAction<ASPreparation> PausedAction;
        [PXButton, PXUIField(DisplayName = "Pause",
            MapEnableRights = PXCacheRights.Select,
            MapViewRights = PXCacheRights.Select)]
        protected virtual IEnumerable pausedAction(PXAdapter adapter) => adapter.Get();

        public PXAction<ASPreparation> ClosedAction;
        [PXButton, PXUIField(DisplayName = "Close",
            MapEnableRights = PXCacheRights.Select,
            MapViewRights = PXCacheRights.Select)]
        protected virtual IEnumerable closedAction(PXAdapter adapter) => adapter.Get();
        #endregion
    }
}