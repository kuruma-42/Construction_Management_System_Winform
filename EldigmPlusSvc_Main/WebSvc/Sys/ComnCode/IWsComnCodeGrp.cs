using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EldigmPlusSvc_Main.WebSvc.Sys.ComnCode
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드 및 config 파일에서 인터페이스 이름 "IWsComnCodeGrp"을 변경할 수 있습니다.
    [ServiceContract]
    public interface IWsComnCodeGrp
    {
        [OperationContract]
        string sComnCodeGrp(out List<DataComnCodeGrp> reList, out string reMsg);
        [OperationContract]
        string sComnCodeGrpUsingFlag(out List<DataComnCodeGrp> reList, out string reMsg);
        [OperationContract]
        string aComnCodeGrp(string pCcodeGrp, string pCcodeGrpNm, string pUsingFlag, string pSortNo, string pMemo, string pInputId, out string reMsg, out string reData);
        [OperationContract]
        string exComnCodeGrp(string pCcodeGrp, out string reMsg, out string reData);
        [OperationContract]
        string mComnCodeGrp(string pCcodeGrp, string pCcodeGrpNm, string pUsingFlag, string pSortNo, string pMemo, out string reMsg, out int reData);
        [OperationContract]
        string siteDbNm(string pSiteCd, out string reData, out string reMsg);
        [OperationContract]
        string sCodeAuthSiteMemberDB(string pDbnm, out List<DataCodeAuthSiteMemberDB> reList, out string reMsg);
        [OperationContract]
        string sSetAuthSiteMemberDB(string pDbnm, string pSiteCd, string pAuthCd, out List<DataSetAuthSiteMemberDB> reList, out string reMsg);
        [OperationContract]
        string sSetAuthSiteMemberDBSub(string pCcodeGrp, string pDbnm, string pSiteCd, string pAuthCd, out List<DataSetAuthSiteMemberDB> reList, out string reMsg);
        [OperationContract]
        string mSetAuthSiteMemberDB(string pDbnm, string pSiteCd, string pAuthCd, string pCcodeGrp, string pViewFlag, string pNewFlag, string pModifyFlag, string pDelFlag, string pReportFlag, string pPrintFlag, string pDownloadFlag, string pInputId, out string reMsg, out string reData);
        [OperationContract]
        string aSetAuthSiteMemberDB(string pDbnm, string pSiteCd, string pAuthCd, string pCcodeGrp, string pViewFlag, string pNewFlag, string pModifyFlag, string pDelFlag, string pReportFlag, string pPrintFlag, string pDownloadFlag, string pInputId, out string reMsg, out string reData);
        [OperationContract]
        string sComnSiteTreeView(string pDbnm, string pSiteCd, string pAuthCd, out List<DataSetAuthSiteMemberDB> reList, out string reMsg);
        [OperationContract]
        string sComnSite(string pDbnm, string pSiteCd, string pCcodeGrp, string pUsingFlag, string pCcodeNm, out List<DataComecodeSite> reList, out string reMsg);
        [OperationContract]
        string mComnSite(string pDbnm, string pSiteCd, string pCcode, string pUsingFlag, string pSortNo, string pMemo, string pInputId, out string reMsg, out string reData);
        [OperationContract]
        string aComnSite(string pDbNm, string[] param, out string reMsg, out string reData);



    }

    [DataContract]
    public class DataComnCodeGrp
    {
        [DataMember(Order = 0)]
        public string CCODE_GRP { get; set; }

        [DataMember(Order = 1)]
        public string CCODE_GRP_NM { get; set; }

        [DataMember(Order = 2)]
        public int USING_FLAG { get; set; }

        [DataMember(Order = 3)]
        public int SORT_NO { get; set; }

        [DataMember(Order = 4)]
        public string MEMO { get; set; }
    }

    [DataContract]
    public class DataComnCode
    {
        [DataMember(Order = 0)]
        public string CCODE { get; set; }

        [DataMember(Order = 1)]
        public string CCODE_GRP_NM { get; set; }

        [DataMember(Order = 2)]
        public int USING_FLAG { get; set; }

        [DataMember(Order = 3)]
        public int SORT_NO { get; set; }

        [DataMember(Order = 4)]
        public string MEMO { get; set; }
    }

    [DataContract]
    public class DataCodeAuthSiteMemberDB
    {
        [DataMember(Order = 0)]
        public string AUTH_CD { get; set; }

        [DataMember(Order = 1)]
        public string AUTH_NM { get; set; }
    }

    [DataContract]
    public class DataSetAuthSiteMemberDB
    {
        [DataMember(Order = 0)]
        public string CCODE_GRP { get; set; }
        [DataMember(Order = 1)]
        public string CCODE_GRP_NM { get; set; }
        [DataMember(Order = 2)]
        public Int16 VIEW_FLAG { get; set; }
        [DataMember(Order = 3)]
        public Int16 NEW_FLAG { get; set; }
        [DataMember(Order = 4)]
        public Int16 MODIFY_FLAG { get; set; }
        [DataMember(Order = 5)]
        public Int16 DEL_FLAG { get; set; }
        [DataMember(Order = 6)]
        public Int16 REPORT_FLAG { get; set; }
        [DataMember(Order = 7)]
        public Int16 PRINT_FLAG { get; set; }
        [DataMember(Order = 8)]
        public Int16 DOWNLOAD_FLAG { get; set; }
    }

    [DataContract]
    public class DataComecodeSite
    {
        [DataMember(Order = 0)]
        public int CCODE { get; set; }

        [DataMember(Order = 1)]
        public string CCODE_GRP { get; set; }

        [DataMember(Order = 2)]
        public string CCODE_NM { get; set; }

        [DataMember(Order = 3)]
        public string MEMO { get; set; }

        [DataMember(Order = 4)]
        public int USING_FLAG { get; set; }

        [DataMember(Order = 5)]
        public int SORT_NO { get; set; }
    }


}