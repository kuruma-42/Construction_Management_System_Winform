using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EldigmPlusSvc_Main.WebSvc.Sys.SysAuth
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드 및 config 파일에서 인터페이스 이름 "IWsSysAuthMainDB"을 변경할 수 있습니다.

    [ServiceContract]
    public interface IWsSysAuthMainDB
    {
        [OperationContract]
        string sSysAuthMainDB(string pUsingFlag , out List<DataSysAuthMainDB> reList, out string reMsg);
        [OperationContract]
        string mSysAuthMainDB(string sauthCd_val, string sauthNm_val, string myblockFlag_val, string myconFlag_val, string mycomFlag_val, string myteamFlag_val, string usingFlag_val, string memo_val, out string reMsg, out string reData); // reData 인트 스트링 체크 

        [OperationContract]
        string exSysAuthMainDB(string sauthCd_val, out string reMsg, out string reData);

        [OperationContract]
        string aSysAuthMainDB(string sauthCd_val, string sauthNm_val, string myblockFlag_val, string myconFlag_val, string mycomFlag_val, string myteamFlag_val, string usingFlag_val, string sauthLevel_val, string memo_val, string pInputId, out string reMsg, out string reData);
    }


    [DataContract]
    public class DataSysAuthMainDB
    {
        [DataMember(Order = 0)]
        public string AUTH_CD { get; set; }

        [DataMember(Order = 1)]
        public string AUTH_NM { get; set; }

        [DataMember(Order = 2)]
        public int MYBLOCK_FLAG { get; set; }

        [DataMember(Order = 3)]
        public int MYCON_FLAG { get; set; }

        [DataMember(Order = 4)]
        public int MYCOM_FLAG { get; set; }

        [DataMember(Order = 5)]
        public int MYTEAM_FLAG { get; set; }

        [DataMember(Order = 6)]
        public int USING_FLAG { get; set; }

        [DataMember(Order = 7)]
        public int AUTH_LEVEL { get; set; }

        [DataMember(Order = 8)]
        public string MEMO { get; set; }
    }

}

