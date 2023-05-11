using ARCashSale = PX.Objects.AR.Standalone.ARCashSale;
using CRLocation = PX.Objects.CR.Standalone.Location;
using IRegister = PX.Objects.CM.IRegister;
using PX.Data.BQL.Fluent;
using PX.Data.BQL;
using PX.Data.EP;
using PX.Data.ReferentialIntegrity.Attributes;
using PX.Data.WorkflowAPI;
using PX.Data;
using PX.Objects.AR.BQL;
using PX.Objects.AR;
using PX.Objects.CM.Extensions;
using PX.Objects.Common.Abstractions;
using PX.Objects.Common.Attributes;
using PX.Objects.Common.MigrationMode;
using PX.Objects.Common;
using PX.Objects.CR;
using PX.Objects.CS;
using PX.Objects.GL.DAC;
using PX.Objects.GL.FinPeriods.TableDefinition;
using PX.Objects.GL;
using PX.Objects;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System;


namespace ASDelivery
{
    // Acuminator disable once PX1016 ExtensionDoesNotDeclareIsActiveMethod extension should be constantly active
    public sealed class ARRegisterExt1 : PXCacheExtension<PX.Objects.AR.ARRegister>
    {
        #region Constants
        public static class States
        {
            public const string OnHold = ASDeliveryConstants.OnHold;
            public const string Open = ASDeliveryConstants.Open;
            public const string Canceled = ASDeliveryConstants.Canceled;
            public const string Closed = ASDeliveryConstants.Closed;
            public const string Cooking = ASDeliveryConstants.Cooking;
            public const string Cooked = ASDeliveryConstants.Cooked;
            public const string Delivering = ASDeliveryConstants.Delivering;
            public const string Delivered = ASDeliveryConstants.Delivered;
            public class onHold : PX.Data.BQL.BqlString.Constant<onHold>
            {
                public onHold() : base(OnHold) { }
            }
            public class open : PX.Data.BQL.BqlString.Constant<open>
            {
                public open() : base(Open) { }
            }
            public class canceled : PX.Data.BQL.BqlString.Constant<canceled>
            {
                public canceled() : base(Canceled) { }
            }
            public class closed : PX.Data.BQL.BqlString.Constant<closed>
            {
                public closed() : base(Closed) { }
            }
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
    }
}