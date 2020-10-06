using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EldigmPlusSvc_Main.WebSvc.Sys.Menu
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드 및 config 파일에서 인터페이스 이름 "IWsMenuMainDB"을 변경할 수 있습니다.
    [ServiceContract]
    public interface IWsMenuMainDB
    {
        [OperationContract]
        string sManuTopTreeView(string USING_FLAG, out List<DataMenuTop> reList, out string reMsg);
        [OperationContract]
        string sManuSubTreeView(string TOP_MENU_CD, string USING_FLAG, out List<DataMenuSub> reList, out string reMsg);
        [OperationContract]
        string sManuTreeView(string TOP_MENU_CD, string SUB_MENU_CD, string USING_FLAG, out List<DataMenu> reList, out string reMsg);
        [OperationContract]
        string sManuTreeView2(string TOP_MENU_CD, string SUB_MENU_CD, string MENU_CD, string USING_FLAG, out List<DataMenu> reList, out string reMsg);
        [OperationContract]
        string exMenuTop(string TOP_MENU_CD, string TOP_MENU_NM, out string reMsg, out string reData);
        [OperationContract]
        string exMenuSub(string SUB_MENU_CD, string TOP_MENU_CD, string SUB_MENU_NM, out string reMsg, out string reData);
        [OperationContract]
        string exMenu(string MENU_CD, string TOP_MENU_CD, string SUB_MENU_CD, string MENU_NM, out string reMsg, out string reData);
        [OperationContract]
        string aMenuTop(string TOP_MENU_NM, string APP_FLAG, string USING_FLAG, string SORT_NO, string INPUT_ID, out string reMsg, out string reData);
        [OperationContract]
        string aMenuSub(string TOP_MENU_CD, string SUB_MENU_NM, string USING_FLAG, string SORT_NO, string INPUT_ID, out string reMsg, out string reData);
        [OperationContract]
        string aMenu(string MENU_CD, string TOP_MENU_CD, string SUB_MENU_CD, string MENU_NM, string USING_FLAG, string SORT_NO, string INPUT_ID, out string reMsg, out string reData);

    }

    [DataContract]
    public class DataMenuTop
    {
        [DataMember(Order = 0)]
        public int TOP_MENU_CD { get; set; }

        [DataMember(Order = 1)]
        public string TOP_MENU_NM { get; set; }

        [DataMember(Order = 2)]
        public int APP_FLAG { get; set; }

        [DataMember(Order = 3)]
        public int USING_FLAG { get; set; }

        [DataMember(Order = 4)]
        public int SORT_NO { get; set; }
    }

    [DataContract]
    public class DataMenuSub
    {
        [DataMember(Order = 0)]
        public int SUB_MENU_CD { get; set; }

        [DataMember(Order = 1)]
        public int TOP_MENU_CD { get; set; }

        [DataMember(Order = 2)]
        public string SUB_MENU_NM { get; set; }

        [DataMember(Order = 3)]
        public int USING_FLAG { get; set; }

        [DataMember(Order = 4)]
        public int SORT_NO { get; set; }
    }

    [DataContract]
    public class DataMenu
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
        public int USING_FLAG { get; set; }

        [DataMember(Order = 5)]
        public int SORT_NO { get; set; }

        //[DataMember(Order = 6)]
        //public string MENU_PATH { get; set; }

        //[DataMember(Order = 7)]
        //public string FILE_FOLDER { get; set; }
    }

}
