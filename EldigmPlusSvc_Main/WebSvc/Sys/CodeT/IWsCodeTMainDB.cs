using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EldigmPlusSvc_Main.WebSvc.Sys.CodeT
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드 및 config 파일에서 인터페이스 이름 "IWsCodeTMainDB"을 변경할 수 있습니다.
    [ServiceContract]
    public interface IWsCodeTMainDB
    {
        [OperationContract]
        string sSysCode(out List<DataSysCode> reList, out string reMsg);
        [OperationContract]
        string sCodeTTreeView(string pScode, out List<DataCodeT> reList, out string reMsg);
        [OperationContract]
        string sCodeT(string pScode, out List<DataCodeT> reList, out string reMsg);
        [OperationContract]
        string sCodeTSubTreeView(string pTcode, out List<DataCodeTSub> reList, out string reMsg);
        [OperationContract]
        string sCodeTSub(string pTcode, out List<DataCodeTSub> reList, out string reMsg);
        [OperationContract]
        string mCodeT(string pTcode, string pListFlag, string pRequiredFlag, string pNumericFlag, out string reMsg, out string reData);
        [OperationContract]
        string aCodeT(string pTcode, string pttypeScd, string ptcodeNm, string pListFlag, string pRequiredFlag, string pNumericFlag, string pInputId, out string reMsg, out string reData);
        [OperationContract]
        string exCodeT(string pTcode, string ptcodeNm, out string reMsg, out string reData);
        [OperationContract]
        string aCodeTSub(string pTcode, string pTscodeNm, string pUsingCnt, string pInputId, out string reMsg, out string reData);
        [OperationContract]
        string exCodeTSub(string pTcode, string pTscodeNm, out string reMsg, out string reData);
        [OperationContract]
        string sCodeTSiteTreeView(string pDbnm, string pSiteCd, string pAuth, out List<DataCodeTSiteTreeView> reList, out string reMsg);
        [OperationContract]
        string sCodeTSite(string pDbnm, string pSiteCd, string pTgrpCcd, out List<DataCodeTSite> reList, out string reMsg);
        [OperationContract]
        string mCodeTSite(string pDbnm, string pSiteCd, string pTcode, string pDefaultValue, string pUsingFlag, string pSortNo, string pMemo, out string reMsg, out string reData);



        // ** CodeTAuthSite PART START 

        [OperationContract]
        string sCodeAuthTTreeView(string pScode, string pSiteCd, out List<DataCodeTAuth> reList, out string reMsg);

        [OperationContract]
        string sCodeTAuth(string pTcode, string pSiteCd, out List<DataCodeTAuthSelect> reList, out string reMsg);

        [OperationContract]
        string sCodeTAuthTtype(string pTtypeScd, string pSiteCd, out List<DataCodeTAuthSelect> reList, out string reMsg);

        [OperationContract]
        string mCodeTAuth(string pTcodeNm, string pSiteCd, string pAuthCd, string pViewFlag, string pNewFlag, string pModifyFlag, out string reMsg, out string reData);

        // ** CodeTAuthSite PART END


    }

    //메인
    [DataContract]
    public class DataSysCode
    {
        [DataMember(Order = 0)]
        public string SCODE { get; set; }
        [DataMember(Order = 1)]
        public string SCODE_NM { get; set; }
    }

    [DataContract]
    public class DataCodeT
    {
        [DataMember(Order = 0)]
        public string TCODE { get; set; }
        [DataMember(Order = 1)]
        public string TTYPE_SCD { get; set; }
        [DataMember(Order = 2)]
        public string TCODE_NM { get; set; }
        [DataMember(Order = 3)]
        public int LIST_FLAG { get; set; }
        [DataMember(Order = 4)]
        public int REQUIRED_FLAG { get; set; }
        [DataMember(Order = 5)]
        public int NUMERIC_FLAG { get; set; }
    }

    [DataContract]
    public class DataCodeTSub
    {
        [DataMember(Order = 0)]
        public int TSCODE { get; set; }
        [DataMember(Order = 1)]
        public string TCODE { get; set; }
        [DataMember(Order = 2)]
        public string TSCODE_NM { get; set; }
        [DataMember(Order = 3)]
        public int USING_CNT { get; set; }
    }

    // ** CodeTAuthSite PART START 
    [DataContract]
    public class DataCodeTAuth
    {
        [DataMember(Order = 0)]
        public string TCODE { get; set; }

        [DataMember(Order = 1)]
        public string TCODE_NM { get; set; }

        [DataMember(Order = 2)]
        public int USING_FLAG { get; set; }

    }


    [DataContract]
    public class DataCodeTAuthSelect
    {
        [DataMember(Order = 0)]
        public string AUTH_CD { get; set; }

        [DataMember(Order = 1)]
        public string TCODE_NM { get; set; }

        [DataMember(Order = 2)]
        public int VIEW_FLAG { get; set; }

        [DataMember(Order = 3)]
        public int NEW_FLAG { get; set; }

        [DataMember(Order = 4)]
        public int MODIFY_FLAG { get; set; }

    }

    // ** CodeTAuthSite PART END




    //현장
    [DataContract]
    public class DataCodeTSiteTreeView
    {
        [DataMember(Order = 0)]
        public int CCODE { get; set; }
        [DataMember(Order = 1)]
        public string CCODE_NM { get; set; }
    }

    [DataContract]
    public class DataCodeTSite
    {
        [DataMember(Order = 0)]
        public string TCODE { get; set; }
        [DataMember(Order = 1)]
        public string TCODE_NM { get; set; }
        [DataMember(Order = 2)]
        public string DEFAULT_VALUE { get; set; }
        [DataMember(Order = 3)]
        public int USING_FLAG { get; set; }
        [DataMember(Order = 4)]
        public int SORT_NO { get; set; }
        [DataMember(Order = 5)]
        public string MEMO { get; set; }
    }

}
