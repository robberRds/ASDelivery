using ASDelivery.Helper;
using PX.Data;
using PX.Data.Licensing;
using PX.Objects.CS;
using PX.Objects.EP;
using System;

namespace ASDelivery
{
    [PXCacheName("Preparation")]
    public class ASPreparation : IBqlTable
    {
        #region RefNbr
        [PXDBString(50, IsKey = true, IsUnicode = true)]
        [PXDefault(PersistingCheck = PXPersistingCheck.NullOrBlank)]
        [PXUIField(DisplayName = "Ref Nbr.")]
        [PXSelector(typeof(Search<ASPreparation.refNbr>))]
        [AutoNumber(typeof(ASSetup.orderNumbering), typeof(createdDateTime))]

        public virtual string RefNbr { get; set; }
        public abstract class refNbr : PX.Data.BQL.BqlString.Field<refNbr> { }
        #endregion

        #region EmployerID
        [PXDBInt()]
        [PXEPEmployeeSelector()]
        //[PXParent(typeof(Select<EPEmployee, Where<EPEmployee.bAccountID, Equal<Current<employerID>>>>))]
        [PXUIField(DisplayName = "Disher")]
        //[PXSelector(typeof(Search<EPEmployee.acctCD>))]
        public virtual int? EmployerID { get; set; }
        public abstract class employerID : PX.Data.BQL.BqlInt.Field<employerID> { }
        #endregion

        #region Status
        [PXDBString(2, IsFixed = true, InputMask = "")]
        [PXDefault(PreparationStatusConstants.OnHold)]
        [PXUIField(DisplayName = "Status", Visibility = PXUIVisibility.SelectorVisible, Enabled = false)]
        [PXStringList(
                new string[]
                {
                PreparationStatusConstants.OnHold,
                PreparationStatusConstants.Open,
                PreparationStatusConstants.Paused,
                PreparationStatusConstants.Closed
                },
                new string[]
                {
                Helper.Messages.OnHold,
                Helper.Messages.Open,
                Helper.Messages.Paused,
                Helper.Messages.Closed
                })]

        public virtual string Status { get; set; }
        public abstract class status : PX.Data.BQL.BqlString.Field<status> { }
        #endregion

        #region StartOfPreparation
        [PXDBDateAndTime()]
        [PXUIField(DisplayName = "Start Of Preparation")]
        public virtual DateTime? StartOfPreparation { get; set; }
        public abstract class startOfPreparation : PX.Data.BQL.BqlDateTime.Field<startOfPreparation> { }
        #endregion

        #region FinishOfPreparation
        [PXDBDateAndTime()]
        [PXUIField(DisplayName = "Finish Of Preparation")]
        public virtual DateTime? FinishOfPreparation { get; set; }
        public abstract class finishOfPreparation : PX.Data.BQL.BqlDateTime.Field<finishOfPreparation> { }
        #endregion

        #region RecipeLineCntr
        [PXDBInt()]
        [PXDefault(0)]
        public virtual int? RecipeLineCntr { get; set; }
        public abstract class recipeLineCntr : PX.Data.BQL.BqlInt.Field<recipeLineCntr> { }
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