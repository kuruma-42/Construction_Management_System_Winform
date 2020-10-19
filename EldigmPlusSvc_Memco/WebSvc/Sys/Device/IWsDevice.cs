using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EldigmPlusSvc_Memco.WebSvc.Sys.Device
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드 및 config 파일에서 인터페이스 이름 "IWsDevice"을 변경할 수 있습니다.
    [ServiceContract]
    public interface IWsDevice
    {

        // ** DEVICE PART  ** 
        [OperationContract]
        string devTypeCmb(out List<DataDevCombo> reList, out string reMsg);

        [OperationContract]
        string devIOCmb(out List<DataDevCombo> reList, out string reMsg);

        [OperationContract]
        string sDevice(string pDbNm, string pSiteCd, out List<DataDevice> reList, out string reMsg);

        [OperationContract]
        string mDevice(string pDbNm, string pSiteCd, string pDevCd, string pDeviceId, string pDevTypeScd, string pDevIOScd, string pDevNm, string pIp, string pSortNo, string pUsingFalg, string pMemo, out string reMsg, out string reData);

        [OperationContract]
        string aDevicePro(string pDbNm, string[] param, out string reMsg, out string reData);        

        [OperationContract]
        string logDevice(string pDbNm, string pDevCd, string pSiteCd, string pDeviceId, string pDevTypeScd, string pDevIOScd, string pDevNm, string pIp, string pUsingFalg, string pSortNo, string pMemo, string pInputId, out string reMsg, out string reData);
        
    }



    // ** DEVICE DATA PART 

    //SELECT 
    [DataContract]
    public class DataDevice
    {
        [DataMember(Order = 0)]
        public int DEV_CD { get; set; }

        [DataMember(Order = 1)]
        public int DEVICE_ID { get; set; }

        [DataMember(Order = 2)]
        public string DEV_TYPE_SCD { get; set; }

        [DataMember(Order = 3)]
        public string DEV_IO_SCD { get; set; }

        [DataMember(Order = 4)]
        public string DEV_NM { get; set; }

        [DataMember(Order = 5)]
        public string IP { get; set; }

        [DataMember(Order = 6)]
        public int USING_FLAG { get; set; }

        [DataMember(Order = 7)]
        public int SORT_NO { get; set; }

        [DataMember(Order = 8)]
        public string MEMO { get; set; }
    }

    //COMBO DATA -> DEV_TYPE SCD , DEV_IO_SCD    
    [DataContract]
    public class DataDevCombo
    {
        [DataMember(Order = 0)]
        public string SCODE { get; set; }

        [DataMember(Order = 1)]
        public string SCODE_NM { get; set; }
    }  


}

