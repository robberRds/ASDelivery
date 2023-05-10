using PX.Data;
using System;

namespace ASDelivery
{
    [PXCacheName("History")]
    public class ASHistory : IBqlTable
    {
        #region RefNbr
        [PXDBString(50, IsKey = true, IsUnicode = true, InputMask = "")]
        [PXParent(typeof(Select<ASPreparation, Where<ASPreparation.refNbr, Equal<Current<ASHistory.refNbr>>>>))]
        [PXUIField(DisplayName = "Ref Nbr")]
        public virtual string RefNbr { get; set; }
        public abstract class refNbr : PX.Data.BQL.BqlString.Field<refNbr> { }
        #endregion

        #region EmployerID
        [PXDBInt(IsKey = true)]
        [PXUIField(DisplayName = "Employer ID")]
        public virtual int? EmployerID { get; set; }
        public abstract class employerID : PX.Data.BQL.BqlInt.Field<employerID> { }
        #endregion

        #region StartOfPreparation
        [PXDBDate()]
        [PXUIField(DisplayName = "Start Of Preparation")]
        public virtual DateTime? StartOfPreparation { get; set; }
        public abstract class startOfPreparation : PX.Data.BQL.BqlDateTime.Field<startOfPreparation> { }
        #endregion

        #region FinishOfPreparation
        [PXDBDate()]
        [PXUIField(DisplayName = "Finish Of Preparation")]
        public virtual DateTime? FinishOfPreparation { get; set; }
        public abstract class finishOfPreparation : PX.Data.BQL.BqlDateTime.Field<finishOfPreparation> { }
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