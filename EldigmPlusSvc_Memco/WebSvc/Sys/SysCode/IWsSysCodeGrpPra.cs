using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EldigmPlusSvc_Memco.WebSvc.Sys.SysCode
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드 및 config 파일에서 인터페이스 이름 "IWsSysCodeGrpPra"을 변경할 수 있습니다.
    [ServiceContract]
    public interface IWsSysCodeGrpPra
    {
        [OperationContract]
        string psSysCodeGrp(string pScodeGrp, out List<DataSysCodeGrpPra> reList, out string reMsg);

        [OperationContract]
        string pmSysCodeGrp(string pScodeGrp, string pScodeNm, string pUsingFlag, string pSortNo, string pMemo, out string reMsg);
    }



    [DataContract]
    public class DataSysCodeGrpPra
    {
        [DataMember(Order = 0)]
        public string SCODE_GRP { get; set; }

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