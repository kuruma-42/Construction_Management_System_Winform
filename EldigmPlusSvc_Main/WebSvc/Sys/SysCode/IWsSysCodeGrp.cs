using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EldigmPlusSvc_Main.WebSvc.Sys.SysCode
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드 및 config 파일에서 인터페이스 이름 "IWsSysCodeGrp"을 변경할 수 있습니다.

    [ServiceContract]
    public interface IWsSysCodeGrp
    {
        [OperationContract]
        string sSysCodeGrp(string pScodeGrp, out List<DataSysCodeGrp> reList, out string reMsg);

        [OperationContract]
        string mSysCodeGrp(string pScodeGrp, string pScodeNm, string pUsingFlag, string pSortNo, string pMemo, out string reMsg, out int reData);

        [OperationContract]
        string exSysCodeGrp(string pScodeGrp, out string reMsg, out string reData);

        [OperationContract]
        string aSysCodeGrp(string pScodeGrp, string pScodeGrpNm, string pUsingFlag, string pSortNo, string pMemo, string pInputId, out string reMsg, out string reData);

        [OperationContract]
        string sSysCodeGrp_UsingFlag(string pUsingFlag, out List<DataSysCodeGrp> reList, out string reMsg);

        [OperationContract]
        string sSysCode(string pScodeGrp, string pUsingFlag, string pScodeNm, out List<DataSysCode> reList, out string reMsg);

        [OperationContract]
        string mSysCode(string pScode, string pScodeNm, string pUsingFlag, string pSortNo, string pMemo, string pInputId, out string reMsg, out string reData);

        [OperationContract]
        string exSysCode(string pScode, out string reMsg, out string reData);

        [OperationContract]
        string aSysCode(string pScode, string pScodeGrp, string pScodeNm, string pUsingFlag, string pMemo, string pSortNo, string pInputId, out string reMsg, out string reData);
    }



    [DataContract]
    public class DataSysCodeGrp
    {
        [DataMember(Order = 0)]
        public string SCODE_GRP { get; set; }

        [DataMember(Order = 1)]
        public string SCODE_GRP_NM { get; set; }

        [DataMember(Order = 2)]
        public int USING_FLAG { get; set; }

        [DataMember(Order = 3)]
        public int SORT_NO { get; set; }

        [DataMember(Order = 4)]
        public string MEMO { get; set; }
    }

    [DataContract]
    public class DataSysCode
    {
        [DataMember(Order = 0)]
        public string SCODE { get; set; }

        [DataMember(Order = 1)]
        public string SCODE_NM { get; set; }

        [DataMember(Order = 2)]
        public int USING_FLAG { get; set; }

        [DataMember(Order = 3)]
        public int SORT_NO { get; set; }

        [DataMember(Order = 4)]
        public string MEMO { get; set; }
    }

}


