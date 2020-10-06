using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EldigmPlusSvc_Memco.WebSvc.Sys.SysAuth
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드 및 config 파일에서 인터페이스 이름 "IWsSysAuthMemberDB"을 변경할 수 있습니다.
    [ServiceContract]
    public interface IWsSysAuthMemberDB
    {
        [OperationContract]
        string sDbNm(string pMemcoCd, out string reData, out string reMsg);

        [OperationContract]
        string sMemberMainDB(out List<DataMemberMainDB> reList, out string reMsg);

        [OperationContract]
        string sSysAuthMemberDB(string pDbnm, string pUsingFlag, out List<DataSysAuthMemberDB> reList, out string reMsg);

        [OperationContract]
        string mSysAuthMemberDB(string pDbnm, string sauthCd_val, string sauthNm_val, string myblockFlag_val, string myconFlag_val, string mycomFlag_val, string myteamFlag_val, string usingFlag_val, string memo_val, out string reMsg, out string reData); // reData 인트 스트링 체크 

        [OperationContract]
        string exSysAuthMainDB(string sauthCd_val, string sauthNm_val, out string reMsg, out string reData);

        [OperationContract]
        string aSysAuthMemberDB(string pDbnm, string sauthCd_val, string sauthNm_val, string myblockFlag_val, string myconFlag_val, string mycomFlag_val, string myteamFlag_val, string usingFlag_val, string sauthLevel_val, string memo_val, string pInputId, out string reMsg, out string reData);

        [OperationContract]
        string aSysAuthMainDB(string sauthCd_val, string sauthNm_val, string myblockFlag_val, string myconFlag_val, string mycomFlag_val, string myteamFlag_val, string usingFlag_val, string sauthLevel_val, string memo_val, string pInputId, out string reMsg, out string reData);




        //SysAuthSiteDB 
        [OperationContract]
        string sSiteMainDB(string pMemcoCd, out List<DataSiteMainDB> reList, out string reMsg);

        [OperationContract]
        string siteDbNm(string pSiteCd, out string reData, out string reMsg);

        [OperationContract]
        string sSysAuthSiteDB(string pSiteCd, string pDbnm, string pUsingFlag, out List<DataSysAuthSiteDB> reList, out string reMsg);

        [OperationContract]
        string mSysAuthSiteDB(string pDbnm, string pSiteCd, string sauthCd_val, string lab_aprv_Flag_val, string usingFlag_val, string memo_val, out string reMsg, out string reData);

        [OperationContract]
        string aSysAuthSiteDB(string pDbnm, string pSiteCd, string sauthCd_val, string lab_aprv_Flag_val, string usingFlag_val, string sauthLevel_val, string memo_val, string pInputId, out string reMsg, out string reData);
    }


    [DataContract]
    public class DataSysAuthMemberDB
    {
        [DataMember(Order = 0)]
        public string AUTH_CD { get; set; }

        [DataMember(Order = 1)]
        public string AUTH_NM { get; set; }

        [DataMember(Order = 2)]
        public int MYBLOCK_FLAG { get; set; }

        [DataMember(Order = 3)]
        public int MYCON_FLAG { get; set; }

        [DataMember(Order = 4)]
        public int MYCOM_FLAG { get; set; }

        [DataMember(Order = 5)]
        public int MYTEAM_FLAG { get; set; }

        [DataMember(Order = 6)]
        public int USING_FLAG { get; set; }

        [DataMember(Order = 7)]
        public int AUTH_LEVEL { get; set; }

        [DataMember(Order = 8)]
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




    //SysAuthSiteDB 
    [DataContract]
    public class DataSiteMainDB
    {
        [DataMember(Order = 0)]
        public int SITE_CD { get; set; }

        [DataMember(Order = 1)]
        public string SITE_NM { get; set; }
    }


    [DataContract]
    public class DataSysAuthSiteDB
    {
        [DataMember(Order = 0)]
        public string AUTH_CD { get; set; }

        [DataMember(Order = 1)]
        public string AUTH_NM { get; set; }

        [DataMember(Order = 2)]
        public int AUTH_LEVEL { get; set; }

        [DataMember(Order = 3)]
        public int LAB_APRV_FLAG { get; set; }

        [DataMember(Order = 4)]
        public int USING_FLAG { get; set; }

        [DataMember(Order = 5)]
        public int MYTEAM_FLAG { get; set; }

        [DataMember(Order = 6)]
        public string MEMO { get; set; }

    }



}
