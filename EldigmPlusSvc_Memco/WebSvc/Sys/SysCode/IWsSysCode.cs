using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EldigmPlusSvc_Memco.WebSvc.Sys.SysCode
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드 및 config 파일에서 인터페이스 이름 "IWsSysCode"을 변경할 수 있습니다.
    [ServiceContract]
    public interface IWsSysCode
    {
        [OperationContract]
        string sSysSysCode(out List<DataCodeGroup> reList, out string reMsg);

    }



    [DataContract]
    public class DataCodeGroup
    {   
        [DataMember(Order = 0)]
        public int SCODE_GRP { get; set; }

        [DataMember(Order = 1)]
        public string SCODE_NM { get; set; }
    }

}