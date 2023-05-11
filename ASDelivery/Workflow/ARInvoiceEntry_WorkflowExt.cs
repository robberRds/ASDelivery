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

namespace ASDelivery.Workflow
{
    using State = ARDocStatus;
    public class ARInvoiceEntry_WorkflowExt : PXGraphExtension<ARInvoiceEntry_Workflow, ARInvoiceEntry>
    {

        #region Constants
        public static class States
        {
            public const string Cooking = ASDeliveryConstants.Cooking;
            public const string Cooked = ASDeliveryConstants.Cooked;
            public const string Delivering = ASDeliveryConstants.Delivering;
            public const string Delivered = ASDeliveryConstants.Delivered;

            public class cooking : PX.Data.BQL.BqlString.Constant<cooking>
            {
                public cooking() : base(Cooking) { }
            }
            public class cooked : PX.Data.BQL.BqlString.Constant<cooked>
            {
                public cooked() : base(Cooked) { }
            }
            public class delivering : PX.Data.BQL.BqlString.Constant<delivering>
            {
                public delivering() : base(Delivering) { }
            }
            public class delivered : PX.Data.BQL.BqlString.Constant<delivered>
            {
                public delivered() : base(Delivered) { }
            }
        }

        #endregion
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
                .CreateExisting<ARInvoiceEntry_WorkflowExt>(g => g.onHold, a => a
                    .WithCategory(processingCategory));
            var openAction = context.ActionDefinitions
                .CreateExisting<ARInvoiceEntry_WorkflowExt>(g => g.open, a => a
                    .WithCategory(processingCategory));
            var cancelAction = context.ActionDefinitions
                .CreateExisting<ARInvoiceEntry_WorkflowExt>(g => g.cancel, a => a
                    .WithCategory(processingCategory));
            var cookingAction = context.ActionDefinitions
                .CreateExisting<ARInvoiceEntry_WorkflowExt>(g => g.cooking, a => a
                    .WithCategory(processingCategory)
                    .PlaceAfter(g => g.payInvoice));
            var cookedAction = context.ActionDefinitions
                .CreateExisting<ARInvoiceEntry_WorkflowExt>(g => g.cooked, a => a
                    .WithCategory(processingCategory));
            var deliveringAction = context.ActionDefinitions
                .CreateExisting<ARInvoiceEntry_WorkflowExt>(g => g.delivering, a => a
                    .WithCategory(processingCategory));
            var deliveredAction = context.ActionDefinitions
                .CreateExisting<ARInvoiceEntry_WorkflowExt>(g => g.delivered, a => a
                    .WithCategory(processingCategory));
            var closeAction = context.ActionDefinitions
                .CreateExisting<ARInvoiceEntry_WorkflowExt>(g => g.close, a => a
                    .WithCategory(processingCategory));

            config.GetScreenConfigurationContext<ARInvoiceEntry, ARInvoice>().UpdateScreenConfigurationFor(
                screen =>
                screen
                    .AddDefaultFlow(flow =>
                        flow
                       .WithFlowStates(fss =>
                       {
                           fss.Add<State.hold>(flowState =>
                           {
                               return flowState
                                   .IsInitial()
                                   .WithActions(actions =>
                                   {
                                       actions.Add(openAction, a => a.IsDuplicatedInToolbar()
                                           .WithConnotation(ActionConnotation.Success));
                                   });
                           });
                           fss.Add<State.open>(flowState =>
                           {
                               return flowState
                                   .WithActions(actions =>
                                   {
                                       actions.Add(holdAction, a => a.IsDuplicatedInToolbar());
                                       actions.Add(cookingAction, a => a.IsDuplicatedInToolbar());
                                   });
                           });
                           fss.Add<State.canceled>(flowState =>
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
                           transitions.AddGroupFrom<State.hold>(ts =>
                           {
                               ts.Add(t => t.To<State.open>().IsTriggeredOn(openAction));
                           });
                           transitions.AddGroupFrom<State.open>(ts =>
                           {
                               ts.Add(t => t.To<State.hold>().IsTriggeredOn(holdAction));
                               ts.Add(t => t.To<States.cooking>().IsTriggeredOn(cookingAction));
                           });
                           transitions.AddGroupFrom<State.canceled>(ts =>
                           {
                               ts.Add(t => t.To<State.hold>().IsTriggeredOn(holdAction));
                               ts.Add(t => t.To<State.closed>().IsTriggeredOn(closeAction));
                           });
                           transitions.AddGroupFrom<States.cooking>(ts =>
                           {
                               ts.Add(t => t.To<States.cooked>().IsTriggeredOn(cookedAction));
                               ts.Add(t => t.To<State.canceled>().IsTriggeredOn(cancelAction));
                           });
                           transitions.AddGroupFrom<States.cooked>(ts =>
                           {
                               ts.Add(t => t.To<States.delivering>().IsTriggeredOn(deliveringAction));
                               ts.Add(t => t.To<State.canceled>().IsTriggeredOn(cancelAction));
                           });
                           transitions.AddGroupFrom<States.delivering>(ts =>
                           {
                               ts.Add(t => t.To<States.delivered>().IsTriggeredOn(deliveredAction));
                               ts.Add(t => t.To<State.canceled>().IsTriggeredOn(cancelAction));
                           });
                           transitions.AddGroupFrom<States.delivered>(ts =>
                           {
                               ts.Add(t => t.To<State.closed>().IsTriggeredOn(closeAction));
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
