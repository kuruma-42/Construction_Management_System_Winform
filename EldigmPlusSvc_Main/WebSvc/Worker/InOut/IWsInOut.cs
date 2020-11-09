using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EldigmPlusSvc_Main.WebSvc.Worker.InOut
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드 및 config 파일에서 인터페이스 이름 "IWsInOut"을 변경할 수 있습니다.
    [ServiceContract]
    public interface IWsInOut
    {
        [OperationContract]
        string sLaborCompanyList(string pSiteCd, string pAuthCd, string pCoCd, out List<DataComCombo> reList, out string reMsg);
        [OperationContract]
        string co_Cmb(string pSiteCd, out List<DataComCombo> reList, out string reMsg);
        [OperationContract]
        string team_Cmb(string pSiteCd, out List<DataComCombo> reList, out string reMsg);
        [OperationContract]
        string sInOut(string pDbnm, string pSiteCd, string pDtp1, string pDtp2, string pCocd, string pCmbIO, out List<DataInOut> reList, out string reMsg);
        [OperationContract]
        string sInOutHistory(string pDbnm, string pSiteCd, string pDtp1, string pDtp2, string pCocd, out List<DataInOut> reList, out string reMsg);
        [OperationContract]
        string mInOut(string pDbnm, string pLabNo, string pSiteCd, string pRegDate, string pInDt, string pOutDt, string pCoCd, string pTeamCd, out string reMsg, out string reData);
        [OperationContract]
        string aInOutLog(string pDbnm, string pLabNo, string pSiteCd, string pRegDate, string pInDt, string pOutDt, string pCoCd, string pTeamCd, string pInIOPFId, string pOutIOPFId, string pInputId, out string reMsg, out string reData);
        [OperationContract]
        string dInHistory(string pDbnm, string pLabNo, string pSiteCd, string pRegDate, string pEventDt, out string reMsg, out string reData);[OperationContract]
        string dOutHistory(string pDbnm, string pLabNo, string pSiteCd, string pRegDate, string pEventDt, out string reMsg, out string reData);
        [OperationContract]
        string mInOutHistory(string pDbnm, string pLabNo, string pSiteCd, string pRegDate, string pEventDt, string pEventDtH, string pCoCd, string pTeamCd, out string reMsg, out string reData);
        [OperationContract]
        string aInOutHistory(string pDbnm, string pLabNo, string pSiteCd, string pRegDate, string pEventDt, string pCoCd, string pTeamCd, string pInputId, out string reMsg, out string reData);
        [OperationContract]
        string aInOut(string pDbnm, string pLabNo, string pSiteCd, string pRegDate, string pInDt, string pOutDt, string pCoCd, string pTeamCd, out string reMsg, out string reData);
        [OperationContract]
        string exInOutCo(string pDbnm, string pLabNo, string pSiteCd, string pCoCd, out string reMsg, out string reData);
        [OperationContract]
        string aInOutCo(string pDbnm, string pLabNo, string pSiteCd, string pCoCd, string pInDt, out string reMsg, out string reData);
        [OperationContract]
        string mInOutCo(string pDbnm, string pLabNo, string pSiteCd, string pCoCd, string pInDt, out string reMsg, out string reData);
        [OperationContract]
        string exLabInOutFinal(string pLabNo, string pSiteCd, out string reMsg, out string reData);
        [OperationContract]
        string mLabInOutFinal(string pLabNo, string pSiteCd, string pCoCd, string pTeamCd, string pRegDate, string pInHHMM, string pOutHHMM, out string reMsg, out string reData);
        [OperationContract]
        string aLabInOutFinal(string pLabNo, string pSiteCd, string pCoCd, string pTeamCd, string pRegDate, string pInHHMM, string pOutHHMM, out string reMsg, out string reData);
        [OperationContract]
        string exInOut2020(string pLabNo, string pSiteCd, string pRegdate, out string reMsg, out string reData);
        [OperationContract]
        string aInOut2020(string pLabNo, string pSiteCd, string pRegdate, string pCoCd, string pTeamCd, string pInHHMM, string pOutHHMM, out string reMsg, out string reData);
        [OperationContract]
        string mInOut2020(string pLabNo, string pSiteCd, string pRegdate, string pCoCd, string pTeamCd, string pInHHMM, string pOutHHMM, out string reMsg, out string reData);

    }
    [DataContract]
    public class DataComCombo
    {
        [DataMember(Order = 0)]
        public int VALUE { get; set; }

        [DataMember(Order = 1)]
        public string TEXT { get; set; }
    }

    [DataContract]
    public class DataInOut
    {
        [DataMember(Order = 0)]
        public int LAB_NO { get; set; }

        [DataMember(Order = 1)]
        public int REG_DATE { get; set; }

        [DataMember(Order = 2)]
        public string LAB_NM { get; set; }

        [DataMember(Order = 3)]
        public DateTime IN_DT { get; set; }

        [DataMember(Order = 4)]
        public DateTime OUT_DT { get; set; }

        [DataMember(Order = 5)]
        public DateTime EVENT_DT { get; set; }

        [DataMember(Order = 6)]
        public int CO_CD { get; set; }

        [DataMember(Order = 7)]
        public string CO_NM { get; set; }

        [DataMember(Order = 8)]
        public int TEAM_CD { get; set; }

        [DataMember(Order = 9)]
        public string TEAM_NM { get; set; }
    
        [DataMember(Order = 10)]
        public int DEV_CD { get; set; }

        [DataMember(Order = 11)]
        public string DEV_TYPE_SCD { get; set; }

        [DataMember(Order = 12)]
        public string DEV_IO_SCD { get; set; }

        [DataMember(Order = 13)]
        public string CCODE_NM { get; set; }

        [DataMember(Order = 14)]
        public string DEV_NM { get; set; }

        [DataMember(Order = 15)]
        public string DEV_IO_NM { get; set; }

        [DataMember(Order = 16)]
        public string DEV_TYPE_NM { get; set; }

        [DataMember(Order = 17)]
        public int IN_IOPF_ID { get; set; }

        [DataMember(Order = 18)]
        public int OUT_IOPF_ID { get; set; }
    }


}
