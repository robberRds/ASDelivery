using ASDelivery.Helper;
using PX.Data.WorkflowAPI;
using PX.Objects.Common;

namespace ASDelivery.Workflows
{
    // Acuminator disable once PX1016 ExtensionDoesNotDeclareIsActiveMethod extension should be constantly active
    public class ASPreparationWorkflow : PX.Data.PXGraphExtension<ASPreparationMaint>
    {
        #region Constants
        public static class States
        {
            public const string OnHold = PreparationStatusConstants.OnHold;
            public const string Open = PreparationStatusConstants.Open;
            public const string Paused = PreparationStatusConstants.Paused;
            public const string Closed = PreparationStatusConstants.Closed;

            public class onHold : PX.Data.BQL.BqlString.Constant<onHold>
            {
                public onHold() : base(OnHold) { }
            }

            public class open : PX.Data.BQL.BqlString.Constant<open>
            {
                public open() : base(Open) { }
            }

            public class paused : PX.Data.BQL.BqlString.Constant<paused>
            {
                public paused() : base(Paused) { }
            }

            public class closed : PX.Data.BQL.BqlString.Constant<closed>
            {
                public closed() : base(Closed) { }
            }
        }
        #endregion

        public override void Configure(PXScreenConfiguration config)
        {
            var context = config.GetScreenConfigurationContext<ASPreparationMaint, ASPreparation>();

            #region Categories
            var commonCategories = CommonActionCategories.Get(context);
            var processingCategory = commonCategories.Processing;
            var otherCategory = commonCategories.Other;
            #endregion

            //start
            context.AddScreenConfigurationFor(screen =>
                screen
                    .StateIdentifierIs<ASPreparation.status>() // Identifier
                    .AddDefaultFlow(flow =>
                        flow
                        .WithFlowStates(fss => // States
                        {
                            fss.Add<States.onHold>(flowState =>
                            {
                                return flowState
                                    .IsInitial()
                                    .WithActions(actions => // OnHold Action
                                    {
                                        actions.Add(g => g.OnHoldAction, a => a.IsDuplicatedInToolbar());
                                    });
                            });
                            fss.Add<States.open>(flowState =>
                            {
                                return flowState
                                    .WithFieldStates(states => {})
                                    .WithActions(actions => // Open Action
                                    {
                                        actions.Add(g => g.PausedAction, a => a.IsDuplicatedInToolbar());
                                        actions.Add(g => g.ClosedAction, a => a.IsDuplicatedInToolbar());
                                    });
                            });
                            fss.Add<States.paused>(flowState =>
                            {
                                return flowState
                                    .WithFieldStates(states =>
                                    {
                                    })
                                    .WithActions(actions => // Paused Action
                                    {
                                        actions.Add(g => g.OpenAction, a => a.IsDuplicatedInToolbar());
                                        actions.Add(g => g.ClosedAction, a => a.IsDuplicatedInToolbar());
                                    });
                            });
                            fss.Add<States.closed>(flowState =>
                            {
                                return flowState
                                    .WithFieldStates(states =>
                                    {
                                    })
                                    .WithActions(actions => // Closed Action
                                    {
                                        //actions.Add(g => g.OnHoldAction, a => a.IsDuplicatedInToolbar());
                                        //actions.Add(g => g.OpenAction, a => a.IsDuplicatedInToolbar());
                                    });
                            });
                        }).WithTransitions(transitions => // Transitions
                        {
                            transitions.AddGroupFrom<States.onHold>(ts =>
                            {
                                ts.Add(t => t.To<States.open>().IsTriggeredOn(g => g.OnHoldAction));
                            });
                            transitions.AddGroupFrom<States.open>(ts =>
                            {
                                ts.Add(t => t.To<States.paused>().IsTriggeredOn(g => g.PausedAction));
                                ts.Add(t => t.To<States.closed>().IsTriggeredOn(g => g.ClosedAction));
                            });
                            transitions.AddGroupFrom<States.paused>(ts =>
                            {
                                ts.Add(t => t.To<States.open>().IsTriggeredOn(g => g.OpenAction));
                                ts.Add(t => t.To<States.closed>().IsTriggeredOn(g => g.ClosedAction));
                            });
                            transitions.AddGroupFrom<States.closed>(ts =>
                            {
                                //ts.Add(t => t.To<States.onHold>().IsTriggeredOn(g => g.OnHoldAction));
                                //ts.Add(t => t.To<States.open>().IsTriggeredOn(g => g.OpenAction));
                            });
                        }))
                    .WithActions(actions => // Actions
                    {
                        actions.Add(g => g.OnHoldAction, c => c.WithCategory(processingCategory));
                        actions.Add(g => g.OpenAction, c => c.WithCategory(processingCategory));
                        actions.Add(g => g.PausedAction, c => c.WithCategory(processingCategory));
                        actions.Add(g => g.ClosedAction, c => c.WithCategory(processingCategory));

                    })
                    .WithCategories(categories => // Categories
                    {
                        categories.Add(processingCategory);
                        categories.Add(otherCategory);
                    })
                );
        }
    }
}
