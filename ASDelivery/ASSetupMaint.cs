using System;
using PX.Data;

namespace ASDelivery
{
    public class ASSetupMaint : PXGraph<ASSetupMaint>
    {

        public PXSave<MasterTable> Save;
        public PXCancel<MasterTable> Cancel;


        public PXFilter<MasterTable> MasterView;
        public PXFilter<DetailsTable> DetailsView;

        [Serializable]
        public class MasterTable : IBqlTable
        {

        }

        [Serializable]
        public class DetailsTable : IBqlTable
        {

        }


    }
}