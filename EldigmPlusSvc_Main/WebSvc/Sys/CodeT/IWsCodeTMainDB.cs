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


    }


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

}
