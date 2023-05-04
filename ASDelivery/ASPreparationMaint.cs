using PX.Data;
using PX.Data.BQL.Fluent;

namespace ASDelivery
{
    public class ASPreparationMaint : PXGraph<ASPreparationMaint>
    {
        public SelectFrom<ASPreparation>.View Preparation;
        public SelectFrom<ASOrder>.View Order;

    }
}