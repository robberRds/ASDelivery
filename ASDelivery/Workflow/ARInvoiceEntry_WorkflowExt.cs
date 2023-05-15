using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PX.Data;
using PX.Data.WorkflowAPI;
using PX.Objects.AR;
using System.Threading.Tasks;
using PX.Objects.CS;
using PX.Data.BQL.Fluent;
using static PX.Objects.AR.ARInvoiceEntry_Workflow;
using PX.Objects.Common;
using System.Collections;

namespace ASDelivery
{
    using State = ARDocStatus;
    using Self = ARInvoiceEntry_WorkflowExt;
    using States = ASDeliveryStates;
    public class ARInvoiceEntry_WorkflowExt : PXGraphExtension<ARInvoiceEntry>
    {
        public static bool IsActive()
        {
            return true;
        }
        public override void Configure(PXScreenConfiguration config)
        {
            var context = config.GetScreenConfigurationContext<ARInvoiceEntry, ARInvoice>();

            #region Categories
            var commonCategories = CommonActionCategories.Get(context);
            var processingCategory = commonCategories.Processing;
            var otherCategory = commonCategories.Other;
            #endregion

            var holdAction = context.ActionDefinitions
                .CreateExisting<Self>(g => g.onHold, a => a);
            var openAction = context.ActionDefinitions
                .CreateExisting<Self>(g => g.open, a => a);
            var cancelAction = context.ActionDefinitions
                .CreateExisting<Self>(g => g.cancel, a => a);
            var cookingAction = context.ActionDefinitions
                .CreateExisting<Self>(g => g.cooking, a => a
                .PlaceAfter(g => g.payInvoice));
            var cookedAction = context.ActionDefinitions
                .CreateExisting<Self>(g => g.cooked, a => a);
            var deliveringAction = context.ActionDefinitions
                .CreateExisting<Self>(g => g.delivering, a => a);
            var deliveredAction = context.ActionDefinitions
                .CreateExisting<Self>(g => g.delivered, a => a);
            var closeAction = context.ActionDefinitions
                .CreateExisting<Self>(g => g.close, a => a);

            config.GetScreenConfigurationContext<ARInvoiceEntry, ARInvoice>().UpdateScreenConfigurationFor(
                screen =>
                    screen.StateIdentifierIs<ARRegisterExt.status>()
                    .RemoveDefaultFlow()
                    .AddDefaultFlow(flow =>
                        flow
                       .WithFlowStates(fss =>
                       {
                           fss.Add<States.onHold>(flowState =>
                           {
                               return flowState
                                   .IsInitial()
                                   .WithActions(actions =>
                                   {
                                       actions.Add(openAction, a => a.IsDuplicatedInToolbar()
                                           .WithConnotation(ActionConnotation.Success));
                                   });
                           });
                           fss.Add<States.open>(flowState =>
                           {
                               return flowState
                                   .WithActions(actions =>
                                   {
                                       actions.Add(holdAction, a => a.IsDuplicatedInToolbar());
                                       actions.Add(cookingAction, a => a.IsDuplicatedInToolbar());
                                   });
                           });
                           fss.Add<States.canceled>(flowState =>
                           {
                               return flowState
                                   .WithActions(actions =>
                                   {
                                       actions.Add(holdAction, a => a.IsDuplicatedInToolbar());
                                       actions.Add(closeAction, a => a.IsDuplicatedInToolbar());
                                   });
                           });
                           fss.Add<States.cooking>(flowState =>
                           {
                               return flowState
                                   .WithActions(actions =>
                                   {
                                       actions.Add(cookedAction, a => a.IsDuplicatedInToolbar());
                                       actions.Add(cancelAction, a => a.IsDuplicatedInToolbar());
                                   });
                           });
                           fss.Add<States.cooked>(flowState =>
                           {
                               return flowState
                                   .WithActions(actions =>
                                   {
                                       actions.Add(deliveringAction, a => a.IsDuplicatedInToolbar());
                                       actions.Add(cancelAction, a => a.IsDuplicatedInToolbar());
                                   });
                           });
                           fss.Add<States.delivering>(flowState =>
                           {
                               return flowState
                                   .WithActions(actions =>
                                   {
                                       actions.Add(deliveredAction, a => a.IsDuplicatedInToolbar());
                                       actions.Add(cancelAction, a => a.IsDuplicatedInToolbar());
                                   });
                           });
                           fss.Add<States.delivered>(flowState =>
                           {
                               return flowState
                                   .WithActions(actions =>
                                   {
                                       actions.Add(closeAction, a => a.IsDuplicatedInToolbar());
                                   });
                           });
                       })
                       .WithTransitions(transitions =>
                       {
                           transitions.AddGroupFrom<States.onHold>(ts =>
                           {
                               ts.Add(t => t.To<States.open>().IsTriggeredOn(openAction));
                           });
                           transitions.AddGroupFrom<States.open>(ts =>
                           {
                               ts.Add(t => t.To<States.onHold>().IsTriggeredOn(holdAction));
                               ts.Add(t => t.To<States.cooking>().IsTriggeredOn(cookingAction));
                           });
                           transitions.AddGroupFrom<States.canceled>(ts =>
                           {
                               ts.Add(t => t.To<States.onHold>().IsTriggeredOn(holdAction));
                               ts.Add(t => t.To<States.closed>().IsTriggeredOn(closeAction));
                           });
                           transitions.AddGroupFrom<States.cooking>(ts =>
                           {
                               ts.Add(t => t.To<States.cooked>().IsTriggeredOn(cookedAction));
                               ts.Add(t => t.To<States.canceled>().IsTriggeredOn(cancelAction));
                           });
                           transitions.AddGroupFrom<States.cooked>(ts =>
                           {
                               ts.Add(t => t.To<States.delivering>().IsTriggeredOn(deliveringAction));
                               ts.Add(t => t.To<States.canceled>().IsTriggeredOn(cancelAction));
                           });
                           transitions.AddGroupFrom<States.delivering>(ts =>
                           {
                               ts.Add(t => t.To<States.delivered>().IsTriggeredOn(deliveredAction));
                               ts.Add(t => t.To<States.canceled>().IsTriggeredOn(cancelAction));
                           });
                           transitions.AddGroupFrom<States.delivered>(ts =>
                           {
                               ts.Add(t => t.To<States.closed>().IsTriggeredOn(closeAction));
                           });
                       })
                    )
                    .WithCategories(categories =>
                    {
                        categories.Add(processingCategory);
                        categories.Add(otherCategory);
                    })
                    .WithActions(actions =>
                    {
                        actions.Add(holdAction);
                        actions.Add(openAction);
                        actions.Add(cancelAction);
                        actions.Add(cookingAction);
                        actions.Add(cookedAction);
                        actions.Add(deliveringAction);
                        actions.Add(deliveredAction);
                        actions.Add(closeAction);
                    })
            );
        }
        #region Actions
        public PXAction<ARInvoice> onHold;
        [PXButton]
        [PXUIField(DisplayName = "Hold", Enabled = false)]
        protected virtual IEnumerable OnHold(PXAdapter adapter) => adapter.Get();
        public PXAction<ARInvoice> open;
        [PXButton]
        [PXUIField(DisplayName = "Open", Enabled = false)]
        protected virtual IEnumerable Open(PXAdapter adapter) => adapter.Get();
        public PXAction<ARInvoice> cooking;
        [PXButton]
        [PXUIField(DisplayName = "Cooking", Enabled = false)]
        protected virtual IEnumerable Cooking(PXAdapter adapter) => adapter.Get();
        public PXAction<ARInvoice> cooked;
        [PXButton]
        [PXUIField(DisplayName = "Cooked", Enabled = false)]
        protected virtual IEnumerable Cooked(PXAdapter adapter) => adapter.Get();
        public PXAction<ARInvoice> delivering;
        [PXButton]
        [PXUIField(DisplayName = "Delivering", Enabled = false)]
        protected virtual IEnumerable Delivering(PXAdapter adapter) => adapter.Get();
        public PXAction<ARInvoice> delivered;
        [PXButton]
        [PXUIField(DisplayName = "Delivered", Enabled = false)]
        protected virtual IEnumerable Delivered(PXAdapter adapter) => adapter.Get();
        public PXAction<ARInvoice> cancel;
        [PXButton]
        [PXUIField(DisplayName = "Cancel", Enabled = false)]
        protected virtual IEnumerable Cancel(PXAdapter adapter) => adapter.Get();
        public PXAction<ARInvoice> close;
        [PXButton]
        [PXUIField(DisplayName = "Close", Enabled = false)]
        protected virtual IEnumerable Close(PXAdapter adapter) => adapter.Get();
        #endregion
    }
}
