using PX.Data;
using PX.Objects.CS;
using PX.Objects.IN;
using System;

namespace ASDelivery
{
    [PXCacheName("Order")]
    public class ASOrder : IBqlTable
    {
        #region OrderID
        [Inventory(DisplayName = "Dish")]
        public virtual int? OrderID { get; set; }
        public abstract class orderID : PX.Data.BQL.BqlInt.Field<orderID> { }
        #endregion

        #region RecipeID
        [PXDBInt()]
        [PXUIField(DisplayName = "Recipe")]
        public virtual int? RecipeID { get; set; }
        public abstract class recipeID : PX.Data.BQL.BqlInt.Field<recipeID> { }
        #endregion

        #region Count
        [PXDBInt()]
        [PXUIField(DisplayName = "Count")]
        public virtual int? Count { get; set; }
        public abstract class count : PX.Data.BQL.BqlInt.Field<count> { }
        #endregion

        #region LineNbr
        [PXDBInt(IsKey = true)]
        [PXLineNbr(typeof(ASPreparation.recipeLineCntr))]
        [PXUIField(DisplayName = "Ref Nbr.", Visibility = PXUIVisibility.SelectorVisible)]
        public virtual int? LineNbr { get; set; }
        public abstract class lineNbr : PX.Data.BQL.BqlInt.Field<lineNbr> { }
        #endregion

        #region CreatedByID
        [PXDBCreatedByID()]
        public virtual Guid? CreatedByID { get; set; }
        public abstract class createdByID : PX.Data.BQL.BqlGuid.Field<createdByID> { }
        #endregion

        #region CreatedByScreenID
        [PXDBCreatedByScreenID()]
        public virtual string CreatedByScreenID { get; set; }
        public abstract class createdByScreenID : PX.Data.BQL.BqlString.Field<createdByScreenID> { }
        #endregion

        #region CreatedDateTime
        [PXDBCreatedDateTime()]
        public virtual DateTime? CreatedDateTime { get; set; }
        public abstract class createdDateTime : PX.Data.BQL.BqlDateTime.Field<createdDateTime> { }
        #endregion

        #region LastModifiedByID
        [PXDBLastModifiedByID()]
        public virtual Guid? LastModifiedByID { get; set; }
        public abstract class lastModifiedByID : PX.Data.BQL.BqlGuid.Field<lastModifiedByID> { }
        #endregion

        #region LastModifiedByScreenID
        [PXDBLastModifiedByScreenID()]
        public virtual string LastModifiedByScreenID { get; set; }
        public abstract class lastModifiedByScreenID : PX.Data.BQL.BqlString.Field<lastModifiedByScreenID> { }
        #endregion

        #region LastModifiedDateTime
        [PXDBLastModifiedDateTime()]
        public virtual DateTime? LastModifiedDateTime { get; set; }
        public abstract class lastModifiedDateTime : PX.Data.BQL.BqlDateTime.Field<lastModifiedDateTime> { }
        #endregion

        #region Tstamp
        [PXDBTimestamp()]
        [PXUIField(DisplayName = "Tstamp")]
        public virtual byte[] Tstamp { get; set; }
        public abstract class tstamp : PX.Data.BQL.BqlByteArray.Field<tstamp> { }
        #endregion

        #region Noteid
        [PXNote()]
        public virtual Guid? Noteid { get; set; }
        public abstract class noteid : PX.Data.BQL.BqlGuid.Field<noteid> { }
        #endregion
    }
}