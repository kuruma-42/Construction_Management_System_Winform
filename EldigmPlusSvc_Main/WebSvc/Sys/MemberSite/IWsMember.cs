using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EldigmPlusSvc_Main.WebSvc.Sys.MemberSite
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드 및 config 파일에서 인터페이스 이름 "IWsMember"을 변경할 수 있습니다.
    [ServiceContract]
    public interface IWsMember
    {
        [OperationContract]
        string sMember_UsingFlag(string pUsingFlag, out List<DataMemberDB> reList, out string reMsg);

        [OperationContract]
        string sMember(string pMemcoCd, out List<DataMemberDB> reList, out string reMsg);

        [OperationContract]
        string mMember(string pMemcoCd, string pMemcoNm, string pUsingFlag, string pSortNo, string pMemo, out string reMsg, out string reData);

        [OperationContract]
        string exMember(string pMemcoCd, string pMemcoNm, out string reMsg, out string reData);

        [OperationContract]
        string aMember(string pMemcoNM, string pDb_Nm, string pUsingFlag, string pSortNop, string pMemo, string pInputId, out string reMsg, out string reData);





        //SITE PART 
        [OperationContract]
        string sMemberMainDB(out List<DataMemberMainDB> reList, out string reMsg);

        [OperationContract]
        string sSite(string pMemcoCd, string pUsingFlag, out List<DataSiteDB> reList, out string reMsg);

        [OperationContract]
        string mSite(string siteCd_val, string siteNm_val, string usingFlag_val, string sortNo_val, string memo_val, out string reMsg, out string reData);

        [OperationContract]
        string exSite(string pSiteNm, out string reMsg, out string reData);

        [OperationContract] 
        string aSite(string pDbNm, string[] param, out string reMsg, out string reData);

        //[OperationContract]
        //string aSite(string memcoCd_val, string siteNm_val, string usingFlag_val, string sortNo_val, string memo_val, string pInputId, out string reMsg, out string reData);

        //[OperationContract]
        //string aSite_Member(string siteCd_val, string memcoCd_val, string siteNm_val, string headcoCd_val, out string reMsg, out string reData);

        //[OperationContract]
        //string aSiteInfo_Member(string siteCd_val, string memcoCd_val, out string reMsg, out string reData);

    }



    [DataContract]
    public class DataMemberDB
    {
        [DataMember(Order = 0)]
        public int MEMCO_CD { get; set; }

        [DataMember(Order = 1)]
        public string MEMCO_NM { get; set; }

        [DataMember(Order = 2)]
        public string DB_NM { get; set; }

        [DataMember(Order = 3)]
        public int USING_FLAG { get; set; }

        [DataMember(Order = 4)]
        public int SORT_NO { get; set; }

        [DataMember(Order = 5)]
        public string MEMO { get; set; }
    }


    [DataContract]
    public class DataMemberMainDB
    {
        [DataMember(Order = 0)]
        public int MEMCO_CD { get; set; }

        [DataMember(Order = 1)]
        public string MEMCO_NM { get; set; }

    }



    //SITE PART 
    [DataContract]
    public class DataSiteDB
    {
        [DataMember(Order = 0)]
        public int SITE_CD { get; set; }

        [DataMember(Order = 1)]
        public int MEMCO_CD { get; set; }

        [DataMember(Order = 2)]
        public string SITE_NM { get; set; }

        [DataMember(Order = 3)]
        public int USING_FLAG { get; set; }

        [DataMember(Order = 4)]
        public int SORT_NO { get; set; }

        [DataMember(Order = 5)]
        public string MEMO { get; set; }
    }



}
