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
        string sInOut(string pDbnm, string pSiteCd, string pDtp1, string pDtp2, out List<DataInOut> reList, out string reMsg);
        [OperationContract]
        string sInOutLog(string pDbnm, string pSiteCd, string pDtp1, string pDtp2, out List<DataInOut> reList, out string reMsg);

    }

    [DataContract]
    public class DataInOut
    {
        [DataMember(Order = 0)]
        public int LAB_NO { get; set; }

        [DataMember(Order = 1)]
        public string LAB_NM { get; set; }

        [DataMember(Order = 2)]
        public DateTime IN_DT { get; set; }

        [DataMember(Order = 3)]
        public DateTime OUT_DT { get; set; }

        [DataMember(Order = 4)]
        public DateTime EVENT_DT { get; set; }

        [DataMember(Order = 5)]
        public string CO_NM { get; set; }

        [DataMember(Order = 6)]
        public string TEAM_NM { get; set; }

        [DataMember(Order = 7)]
        public int DEV_CD { get; set; }

        [DataMember(Order = 8)]
        public string DEV_TYPE_SCD { get; set; }

        [DataMember(Order = 9)]
        public string DEV_IO_SCD { get; set; }

        [DataMember(Order = 10)]
        public string CODE_NM { get; set; }
    }


}
