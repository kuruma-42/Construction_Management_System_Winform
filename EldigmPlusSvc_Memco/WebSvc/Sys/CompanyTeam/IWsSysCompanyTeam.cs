using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EldigmPlusSvc_Memco.WebSvc.Sys.CompanyTeam
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드 및 config 파일에서 인터페이스 이름 "IWsSysCompanyTeam"을 변경할 수 있습니다.
    [ServiceContract]
    public interface IWsSysCompanyTeam
    {        

        [OperationContract]
        string constCmb(string pSiteCd, out List<DataConstCmb> reList, out string reMsg);

        [OperationContract]
        string cotype_Cmb(out List<DataCotypeCmb> reList, out string reMsg);

        [OperationContract]
        string constCmb2(string pSiteCd, out List<DataConstCmb2> reList, out string reMsg);

        [OperationContract]
        string cotype_Cmb2(out List<DataCotypeCmb2> reList, out string reMsg);

        [OperationContract]
        string sCompany(string pSiteCd, string pUsingFlag, string pCoNm, out List<DataCompany> reList, out string reMsg);

        [OperationContract]
        string mCompanyMain(string pCoCd, string pCoNm, string pBizNo, string pConstCcd, string pCoTypeScd, string pOwnerNm, string pTel, string pAddr, out string reMsg, out string reData);
        
        [OperationContract]
        string mCompanyMemco(string pSiteCd, string pCoCd, string pCoNm, string pHeadcoCd, string pConstCcd, string pCoTypeScd, string pSortNo, out string reMsg, out string reData);

        [OperationContract]
        string mCompanyMemcoSite(string pSiteCd, string pCoCd, string pStartDate, string pEndDate, string pUsingFlag, string pSortNo, string pMemo, out string reMsg, out string reData);

        [OperationContract]
        string aCompanyMemcoSite(string pSiteCd, string pCoCd, string pStartDate, string pEndDate, string pUsingFlag, string pSortNo, string pMemo, string pInputId, out string reMsg, out string reData);

        [OperationContract]
        string aCompanyPro(string pDbNm, string[] param, out string reMsg, out string reData);

        [OperationContract]
        string mConpanyMainLog(string pCoCd, string pCoNm, string pBizNo, string pConstCcd, string pCoTypeScd, string pOwnerNm, string pTel, string pAddr, string pUsingCnt, string pInputId, out string reMsg, out string reData);

        [OperationContract]
        string mCompanySiteLog(string pCoCd, string pSiteCd, string pCoNm, string pConstCcd, string pCoTypeScd, string pStartDate, string pEndDate, string pUsingFlag, string pSortNo, string pMemo, string pInputId, out string reMsg, out string reData);




        // TEAM PART START FROM HERE 



        [OperationContract]
        string companyCmb(string pSiteCd, out List<DataCompanyCmb> reList, out string reMsg);

        [OperationContract]
        string sTeam(string pSiteCd, string pCoCd, string pUsingFlag, string pTeamNm, out List<DataTeam> reList, out string reMsg);

        [OperationContract]
        string mTeamMemco(string pSiteCd, string pTeamCd, string pTeamNm, string pUsingFalg, string pSortNo, string pMemo, out string reMsg, out string reData);

        //[OperationContract]
        //string aTeamPro(string pDbNm, string[] param, out string reMsg, out string reData);





    }

    //TEAM PART DATA 
    [DataContract]
    public class DataCompanyCmb
    {
        [DataMember(Order = 0)]
        public int CO_CD { get; set; }

        [DataMember(Order = 1)]
        public string CO_NM { get; set; }
    }


    [DataContract]
    public class DataTeam
    {
        [DataMember(Order = 0)]
        public int TEAM_CD { get; set; }

        [DataMember(Order = 1)]
        public string TEAM_NM { get; set; }

        [DataMember(Order = 2)]
        public int USING_FLAG { get; set; }

        [DataMember(Order = 3)]
        public int SORT_NO { get; set; }

        [DataMember(Order = 4)]
        public string MEMO { get; set; }
    }




    [DataContract]
    public class DataConstCmb
    {
        [DataMember(Order = 0)]
        public int VALUE { get; set; }

        [DataMember(Order = 1)]
        public string TEXT { get; set; }
    }


    [DataContract]
    public class DataConstCmb2
    {
        [DataMember(Order = 0)]
        public int CCODE { get; set; }

        [DataMember(Order = 1)]
        public string CCODE_NM { get; set; }
    }

    [DataContract]
    public class DataCotypeCmb
    {
        [DataMember(Order = 0)]
        public string VALUE { get; set; }

        [DataMember(Order = 1)]
        public string TEXT { get; set; }
    }

    [DataContract]
    public class DataCotypeCmb2
    {
        [DataMember(Order = 0)]
        public string SCODE { get; set; }

        [DataMember(Order = 1)]
        public string SCODE_NM { get; set; }
    }


    [DataContract]
    public class DataCompany
    {
        [DataMember(Order = 0)]
        public int CO_CD { get; set; }

        [DataMember(Order = 1)]
        public string CO_NM { get; set; }

        [DataMember(Order = 2)]
        public int USING_FLAG { get; set; }

        [DataMember(Order = 3)]
        public string HEADCO_CD { get; set; }

        [DataMember(Order = 4)]
        public int CONST_CCD { get; set; }

        [DataMember(Order = 5)]
        public string CO_TYPE_SCD { get; set; }

        [DataMember(Order = 6)]
        public int SITE_CD { get; set; }

        [DataMember(Order = 7)]
        public int START_DATE { get; set; }

        [DataMember(Order = 8)]
        public int END_DATE { get; set; }

        [DataMember(Order = 9)]
        public string BIZ_NO { get; set; }

        [DataMember(Order = 10)]
        public string OWNER_NM { get; set; }

        [DataMember(Order = 11)]
        public string TEL { get; set; }

        [DataMember(Order = 12)]
        public string ADDR { get; set; }

        [DataMember(Order = 13)]
        public int USING_CNT { get; set; }

        [DataMember(Order = 14)]
        public int SORT_NO { get; set; }

        [DataMember(Order = 15)]
        public string MEMO { get; set; }


    }

}