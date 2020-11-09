using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EldigmPlusSvc_Memco.WebSvc.MainHome
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드 및 config 파일에서 인터페이스 이름 "IWsMainHome"을 변경할 수 있습니다.
    [ServiceContract]
    public interface IWsMainHome
    {

        [OperationContract]
        string sDbNm(string pMemcoCd, out string reData, out string reMsg);

        [OperationContract]
        string sSiteMenu(string pDbNm, string pSiteCd, out List<DataTopMenu> reList, out string reMsg);

        [OperationContract]
        string sSiteSubMenu1(string pDbNm, string pSiteCd, string pTopMenuCd, out List<DataSubMenu1> reList, out string reMsg);

        [OperationContract]
        string sSiteSubMenu2(string pDbNm, string pSiteCd, string pTopMenuCd, string pSubMenuCd, string pAuthCd, out List<DataSubMenu2> reList, out string reMsg);
    }



    [DataContract]
    public class DataTopMenu
    {
        [DataMember(Order = 0)]
        public int TOP_MENU_CD { get; set; }

        [DataMember(Order = 1)]
        public string TOP_MENU_NM { get; set; }
    }

    [DataContract]
    public class DataSubMenu1
    {
        [DataMember(Order = 0)]
        public int SUB_MENU_CD { get; set; }

        [DataMember(Order = 1)]
        public string SUB_MENU_NM { get; set; }
    }

    [DataContract]
    public class DataSubMenu2
    {
        [DataMember(Order = 0)]
        public string MENU_CD { get; set; }

        [DataMember(Order = 1)]
        public int TOP_MENU_CD { get; set; }

        [DataMember(Order = 2)]
        public int SUB_MENU_CD { get; set; }

        [DataMember(Order = 3)]
        public string MENU_NM { get; set; }

        [DataMember(Order = 4)]
        public string MEMO { get; set; }

        [DataMember(Order = 5)]
        public string MENU_PATH { get; set; }
    }
}
