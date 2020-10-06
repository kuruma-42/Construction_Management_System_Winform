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
        string aComnCodeGrp(string pCcodeGrp, string pCcodeGrpNm, string pUsingFlag, string pSortNo, string pMemo, string pInputId, out string reMsg, out string reData);
        [OperationContract]
        string exComnCodeGrp(string pCcodeGrp, out string reMsg, out string reData);
        [OperationContract]
        string mComnCodeGrp(string pCcodeGrp, string pCcodeGrpNm, string pUsingFlag, string pSortNo, string pMemo, out string reMsg, out int reData);

    }

    [DataContract]
    public class DataComnCodeGrp
    {
        [DataMember(Order = 0)]
        public string CCODE_GRP { get; set; }

        [DataMember(Order = 1)]
        public string CCODE_NM { get; set; }

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
        public string CCODE_NM { get; set; }

        [DataMember(Order = 2)]
        public int USING_FLAG { get; set; }

        [DataMember(Order = 3)]
        public int SORT_NO { get; set; }

        [DataMember(Order = 4)]
        public string MEMO { get; set; }
    }

}