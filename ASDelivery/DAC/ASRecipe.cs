using System;
using PX.Data;
using PX.Objects.CS;

namespace ASDelivery
{
    [Serializable]
    [PXCacheName("Recipe")]
    public class ASRecipe : IBqlTable
    {
        #region RefNbr
        [PXDBString(50, IsKey = true, IsUnicode = true)]
        [PXDefault(PersistingCheck = PXPersistingCheck.NullOrBlank)]
        [PXUIField(DisplayName = "Ref Nbr.", Visibility = PXUIVisibility.SelectorVisible)]
        //[AutoNumber(typeof(ASSetup.requestNumber), typeof(ASRecipe.createdDateTime))]
        [PXSelector(typeof(Search<ASRecipe.refNbr>))]
        public virtual string RefNbr { get; set; }
        public abstract class refNbr : PX.Data.BQL.BqlString.Field<refNbr> { }
        #endregion

        #region DishID
        [PXDBInt()]
        [PXUIField(DisplayName = "Dish Name")]
        public virtual int? DishID { get; set; }
        public abstract class dishid : PX.Data.BQL.BqlInt.Field<dishid> { }
        #endregion
        #region Description
        [PXDBString(60, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Description")]
        [PXDefault("")]
        public virtual string Description { get; set; }
        public abstract class description : PX.Data.BQL.BqlString.Field<description> { }
        #endregion
        #region RecipeLineCntr
        [PXDBInt()]
        [PXDefault(0)]
        public virtual int? RecipeLineCntr { get; set; }
        public abstract class recipeLineCntr : PX.Data.BQL.BqlInt.Field<recipeLineCntr> { }
        #endregion

        #region CreatedDateTime
        [PXDBCreatedDateTime()]
        [PXUIField(DisplayName = "Created Date")]
        public virtual DateTime? CreatedDateTime { get; set; }
        public abstract class createdDateTime :
            PX.Data.BQL.BqlDateTime.Field<createdDateTime>
        { }
        #endregion
        #region CreatedByID
        [PXDBCreatedByID()]
        public virtual Guid? CreatedByID { get; set; }
        public abstract class createdByID :
            PX.Data.BQL.BqlGuid.Field<createdByID>
        { }
        #endregion
        #region CreatedByScreenID
        [PXDBCreatedByScreenID()]
        public virtual string CreatedByScreenID { get; set; }
        public abstract class createdByScreenID :
            PX.Data.BQL.BqlString.Field<createdByScreenID>
        { }
        #endregion
        #region LastModifiedDateTime
        [PXDBLastModifiedDateTime()]
        public virtual DateTime? LastModifiedDateTime { get; set; }
        public abstract class lastModifiedDateTime :
            PX.Data.BQL.BqlDateTime.Field<lastModifiedDateTime>
        { }
        #endregion
        #region LastModifiedByID
        [PXDBLastModifiedByID()]
        public virtual Guid? LastModifiedByID { get; set; }
        public abstract class lastModifiedByID :
            PX.Data.BQL.BqlGuid.Field<lastModifiedByID>
        { }
        #endregion
        #region LastModifiedByScreenID
        [PXDBLastModifiedByScreenID()]
        public virtual string LastModifiedByScreenID { get; set; }
        public abstract class lastModifiedByScreenID :
            PX.Data.BQL.BqlString.Field<lastModifiedByScreenID>
        { }
        #endregion
        #region Tstamp
        [PXDBTimestamp()]
        public virtual byte[] Tstamp { get; set; }
        public abstract class tstamp : PX.Data.BQL.BqlByteArray.Field<tstamp> { }
        #endregion
        #region NoteID
        [PXNote()]
        public virtual Guid? NoteID { get; set; }
        public abstract class noteID : PX.Data.BQL.BqlGuid.Field<noteID> { }
        #endregion
    }
}