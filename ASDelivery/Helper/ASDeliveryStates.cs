using PX.Data.BQL;
using PX.Objects.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASDelivery
{
    public class ASDeliveryStates : ILabelProvider
    {
        public class ListAttribute : LabelListAttribute
        {
            public ListAttribute()
                : base(_valueLabelPairs)
            {
            }
        }

        public class onHold : BqlType<IBqlString, string>.Constant<onHold>
        {
            public onHold()
                : base("H")
            {
            }
        }

        public class open : BqlType<IBqlString, string>.Constant<open>
        {
            public open()
                : base("O")
            {
            }
        }

        public class canceled : BqlType<IBqlString, string>.Constant<canceled>
        {
            public canceled()
                : base("C")
            {
            }
        }

        public class closed : BqlType<IBqlString, string>.Constant<closed>
        {
            public closed()
                : base("L")
            {
            }
        }
        public class cooking : BqlType<IBqlString, string>.Constant<cooking>
        {
            public cooking()
                : base("K")
            {
            }
        }
        public class cooked : BqlType<IBqlString, string>.Constant<cooked>
        {
            public cooked()
                : base("E")
            {
            }
        }

        public class delivering : BqlType<IBqlString, string>.Constant<delivering>
        {
            public delivering()
                : base("G")
            {
            }
        }
        public class delivered : BqlType<IBqlString, string>.Constant<delivered>
        {
            public delivered()
                : base("D")
            {
            }
        }

        private static readonly IEnumerable<ValueLabelPair> _valueLabelPairs = new ValueLabelList
        {
            { "H", "OnHold" },
            { "O", "Open" },
            { "C", "Canceled" },
            { "L", "Closed" },
            { "K", "Cooking" },
            { "E", "Cooked" },
            { "G", "Delivering" },
            { "D", "Delivered" }
        };

        public static readonly string[] Values = new string[8]
        {
            "H", "O", "C", "L", "K", "E", "G", "D"
        };

        public static readonly string[] Labels = new string[8]
        {
            "OnHold", "Open", "Canceled", "Closed", "Cooking", "Cooked", "Delivering", "Delivered"
        };

        public const string OnHold = "H";
        public const string Open = "O";
        public const string Canceled = "C";
        public const string Closed = "L";
        public const string Cooking = "K";
        public const string Cooked = "E";
        public const string Delivering = "G";
        public const string Delivered = "D";


        public IEnumerable<ValueLabelPair> ValueLabelPairs => _valueLabelPairs;
    }
    /*public static class ASDeliveryStates
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
    }*/
}
