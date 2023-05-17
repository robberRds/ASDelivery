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
        public SelectFrom<ASOrder>.Where<ASOrder.refNbr.IsEqual<ASPreparation.refNbr.FromCurrent>>.View Order;
        public SelectFrom<ASHistory>.Where<ASHistory.refNbr.IsEqual<ASPreparation.refNbr.FromCurrent>>.View History;

        public PXSetup<ASSetup> AutoNumSetup;

        #region Events
        protected void _(Events.FieldUpdated<ASPreparation, ASPreparation.status> e)
        {
            ASPreparation row = e.Row;
            if(row.Status == Helper.PreparationStatusConstants.Open)
            {
                row.StartOfPreparation = System.DateTime.Now;
            } else 
                if(row.Status == Helper.PreparationStatusConstants.Closed)
            {
                row.FinishOfPreparation = System.DateTime.Now;
            }
            Preparation.Update(row);
        }
        #endregion

        #region Actions
        public PXAction<ASPreparation> OnHoldAction;
        [PXButton(), PXUIField(DisplayName = "Remove Hold",
        MapEnableRights = PXCacheRights.Select,
        MapViewRights = PXCacheRights.Select)]
        protected virtual IEnumerable onHoldAction(PXAdapter adapter)
        => adapter.Get();

        public PXAction<ASPreparation> OpenAction;
        [PXButton, PXUIField(DisplayName = Helper.Messages.Open,
          MapEnableRights = PXCacheRights.Select,
          MapViewRights = PXCacheRights.Select)]
        protected virtual IEnumerable openAction(PXAdapter adapter) => adapter.Get();

        public PXAction<ASPreparation> PausedAction;
        [PXButton, PXUIField(DisplayName = Helper.Messages.Paused,
            MapEnableRights = PXCacheRights.Select,
            MapViewRights = PXCacheRights.Select)]
        protected virtual IEnumerable pausedAction(PXAdapter adapter) => adapter.Get();

        public PXAction<ASPreparation> ClosedAction;
        [PXButton, PXUIField(DisplayName = Helper.Messages.Closed,
            MapEnableRights = PXCacheRights.Select,
            MapViewRights = PXCacheRights.Select)]
        protected virtual IEnumerable closedAction(PXAdapter adapter) => adapter.Get();
        #endregion
    }
}