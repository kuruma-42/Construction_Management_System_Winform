using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EldigmPlusSvc_Memco.WebSvc.Sys.Worker
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드 및 config 파일에서 인터페이스 이름 "IWsWorkerLaborSearch"을 변경할 수 있습니다.
    [ServiceContract]
    public interface IWsWorkerLaborSearch
    {
        // ** LABOR SEARCH PART  START **

        [OperationContract]
        string sLaborCompanyList(string pSiteCd, string pAuthCd, string pCoCd, string pLngCom, out List<DataComCombo> reList, out string reMsg);

        [OperationContract]
        string sLaborConstList(string pSiteCd, string pAuthCd, string pCcode, string pLngConst, out List<DataComCombo> reList, out string reMsg);

        [OperationContract]
        string sLaborJobList(string pSiteCd, string pLngJob, out List<DataComCombo> reList, out string reMsg);

        [OperationContract]
        string sLaborBlockList(string pSiteCd, string pAuthCd, string pCcode, string pLngBlock,out List<DataComCombo> reList, out string reMsg);

        [OperationContract]
        string sLaborTeamList(string pSiteCd, string pAuthCd, string pTeamCd, string pCocd, string pLngTeam, out List<DataComCombo> reList, out string reMsg);

        [OperationContract]
        string sLaborSearch(string pSiteCd, string pBlockCcd, string pConstCcd, string pCoCd, string pTeamCd, string pSearchCondition, string pSearchTxt, out List<DataLaborSearch> reList, out string reMsg);

        // ** LABOR SEARCH PART END **






        // ** LABOR SEARCH POP UP PART START **


        [OperationContract]
        string sLabAprvFlag(string pSiteCd, string pAuthCd, out string reData, out string reMsg);

        [OperationContract]
        string sLabAuth(string pSiteCd, out string reData, out string reMsg);

        [OperationContract]
        string exLabMember(string pSiteCd,string pLabNm, string pMobileNo, string pBirthDate, out string reData, out string reMsg);

        [OperationContract]
        string exLabMain(string pLabNm, string pMobileNo, string pBirthDate, out string reData, out string reMsg);

        [OperationContract]
        string sLaborAddInfoCcode(string pDbnm, string pSiteCd, string pAuth, out List<DataAddinfoCcode> reList, out string reMsg);        

        [OperationContract]
        string sLaborAddInfo(string pSiteCd, string pCodeT, string pTgrpCcd, out List<DataAddinfo> reList, out string reMsg);

        [OperationContract]
        string sLaborAddInfoModify(string pLabNo, string pSiteCd, string pTtypeScd, string pTgrpCcd, out List<DataAddinfo> reList, out string reMsg);

        [OperationContract]
        string sLaborAddInfoSub(string pSiteCd, string pTcode, out List<DataAddinfoCcodesub> reList, out string reMsg);

        [OperationContract] 
        string aLaborPro(string pDbNm, string[] param, out string[] reData, out string reMsg);

        [OperationContract]
        string mLaborPro(string pDbNm, string[] param, out string reData, out string reMsg); 

         [OperationContract]
        string aLaborLabTcodeSite(string pDbnm, string pLabNo, string pSiteCd, string pTcode, string pTtypeScd, string pValue, out string reData, out string reMsg);

        [OperationContract]
        string mLaborLabTcodeSite(string pDbnm, string pLabNo, string pSiteCd, string pTcode, string pValue, out string reData, out string reMsg);
        
        [OperationContract]
        string aLaborLabTcodeSiteLog(string pDbnm, string pLabNo, string pSiteCd, string pTcode, string pTtypeScd, string pValue, string pInputId, out string reData, out string reMsg);

        //[OperationContract]
        //string mLaborLabTcodeSiteLog(string pDbnm, string pLabNo, string pSiteCd, string pTcode, string pTtypeScd, string pValue, string pInputId, out string reData, out string reMsg);

        // ** LABOR SEARCH POP UP PART END **

    }


    //ADD INFO SUB TSCODE 
    [DataContract]
    public class DataAddinfoCcodesub
    {
        [DataMember(Order = 0)]
        public int TSCODE { get; set; }

        [DataMember(Order = 1)]
        public string TSCODE_NM { get; set; }
    }

    //ADD INFO CCODE = TGRP_CCD
    [DataContract]
    public class DataAddinfoCcode
    {
        [DataMember(Order = 0)]
        public int CCODE { get; set; }
        [DataMember(Order = 1)]
        public string CCODE_NM { get; set; }
    }


    //ADD INFO 1,2,3,4,
    [DataContract]
    public class DataAddinfo
    {
        [DataMember(Order = 0)]
        public string TCODE { get; set; }

        [DataMember(Order = 1)]
        public string TTYPE_SCD { get; set; }

        [DataMember(Order = 2)]
        public string TCODE_NM { get; set; }

        [DataMember(Order = 3)]
        public string VALUE { get; set; }
    }



    //COMBO DATA -> COMPANY
    [DataContract]
    public class DataComCombo
    {
        [DataMember(Order = 0)]
        public int VALUE { get; set; }

        [DataMember(Order = 1)]
        public string TEXT { get; set; }
    }


    [DataContract]
    public class DataLaborSearch
    {
        [DataMember(Order = 0)]
        public int LAB_NO { get; set; }

        [DataMember(Order = 1)]
        public string CO_NM { get; set; }

        [DataMember(Order = 2)]
        public string LAB_NM { get; set; }

        [DataMember(Order = 3)]
        public string JOB_NM { get; set; }

        [DataMember(Order = 4)]
        public string TEAM_NM { get; set; }

        [DataMember(Order = 5)]
        public int BIRTH_DATE { get; set; }

        [DataMember(Order = 6)]
        public string MOBILE_NO { get; set; }

        [DataMember(Order = 7)]
        public int USER_NO { get; set; }

        [DataMember(Order = 8)]
        public string AUTH_CD { get; set; }

        [DataMember(Order = 9)]
        public int BLOCK_CCD { get; set; }

        [DataMember(Order = 10)]
        public int CO_CD { get; set; }

        [DataMember(Order = 11)]
        public int TEAM_CD { get; set; }

        [DataMember(Order = 12)]
        public int JOB_CCD { get; set; }
             


        //DATA POSSIBLE TO USE AFTER 

        //[DataMember(Order = 5)]
        //public int FACE_PHOTO { get; set; }

        //[DataMember(Order = 10)]
        //public int LAB_STS { get; set; }     
    }


}