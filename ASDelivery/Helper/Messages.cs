using PX.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASDelivery
{
    [PXLocalizable]
    public static class Messages
    {
        //Expenses statuses
        public const string OnHold = "On Hold";
        public const string Open = "Open";
        public const string Cooking = "Cooking";
        public const string Cooked = "Cooked";
        public const string Delivering = "Delivering";
        public const string Delivered = "Delivered";
        public const string Closed = "Closed";
    }
}
