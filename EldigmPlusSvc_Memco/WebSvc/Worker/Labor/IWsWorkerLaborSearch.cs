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
        // ** LABOR SEARCH PART  **

        [OperationContract]
        string sLaborCompanyList(string pSiteCd, string pAuthCd, string pCoCd, out List<DataComCombo> reList, out string reMsg);

        [OperationContract]
        string sLaborConstList(string pSiteCd, string pAuthCd, string pCcode, out List<DataComCombo> reList, out string reMsg);

        [OperationContract]
        string sLaborJobList(string pSiteCd, out List<DataComCombo> reList, out string reMsg);

        [OperationContract]
        string sLaborBlockList(string pSiteCd, string pAuthCd, string pCcode, out List<DataComCombo> reList, out string reMsg);

        [OperationContract]
        string sLaborTeamList(string pSiteCd, string pAuthCd, string pTeamCd, string pCocd, out List<DataComCombo> reList, out string reMsg);

        [OperationContract]
        string sLaborSearch(string pSiteCd, string pBlockCcd, string pConstCcd, string pCoCd, string pTeamCd, string pSearchCondition, string pSearchTxt, out List<DataLaborSearch> reList, out string reMsg);
                          
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


        //DATA POSSIBLE TO USE AFTER 
        

        //[DataMember(Order = 5)]
        //public int FACE_PHOTO { get; set; }

        //[DataMember(Order = 6)]
        //public int CO_CD { get; set; }

        //[DataMember(Order = 7)]
        //public int TEAM_CD { get; set; }

        //[DataMember(Order = 8)]
        //public int JOB_CCD { get; set; }

        //[DataMember(Order = 9)]
        //public int BLOCK_CCD { get; set; }

        //[DataMember(Order = 10)]
        //public int LAB_STS { get; set; }     

    }  


}