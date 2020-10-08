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
        string sMenuTopTreeView(out List<DataMenuTop> reList, out string reMsg);
        [OperationContract]
        string sMenuSubTreeView(string pTopMenuCd, out List<DataMenuSub> reList, out string reMsg);
        [OperationContract]
        string sMenuTreeView(string pTopMenuCd, string pSubMenuCd, out List<DataMenu> reList, out string reMsg);
        [OperationContract]
        string sMenuTreeView2(string pTopMenuCd, string pSubMenuCd, string pMenuCd, out List<DataMenu> reList, out string reMsg);
        [OperationContract]
        string exMenuTop(string pTopMenuCd, string pTopMenuNm, out string reMsg, out string reData);
        [OperationContract]
        string exMenuSub(string pSubMenuCd, string pTopMenuCd, string pSubMenuNm, out string reMsg, out string reData);
        [OperationContract]
        string exMenu(string pMenuCd, string pTopMenuCd, string pSubMenuCd, out string reMsg, out string reData);
        [OperationContract]
        string aMenuTop(string pTopMenuNm, string pAppFlag, string pUsingFlag, string pSortNo, string pInputId, out string reMsg, out string reData);
        [OperationContract]
        string aMenuSub(string pTopMenuCd, string pSubMenuNm, string pUsingFlag, string pSortNo, string pInputId, out string reMsg, out string reData);
        [OperationContract] 
        string aMenu(string pTopMenuCd, string pSubMenuCd, string pMenuCd, string pMenuNm, string pUsingFlag, string pSortNo, string pMenuPath, string pFileFolder, string pInputId, out string reMsg, out string reData);
        [OperationContract]
        string mMenuTop(string pTopMenuCd, string pUsingFlag, string pSortNo, out string reMsg, out string reData);
        [OperationContract]
        string mMenuSub(string pTopMenuCd, string pSubMenuCd, string pUsingFlag, string pSortNo, out string reMsg, out string reData);
        [OperationContract]
        string mMenu(string pTopMenuCd, string pSubMenuCd, string pMenuCd, string pUsingFlag, string pSortNo, string pMenuPath, string pFileFolder, out string reMsg, out string reData);
        [OperationContract]
        string sSiteMainDB(string pMemcoCd, out List<DataSiteMainDB> reList, out string reMsg);
        [OperationContract]
        string siteDbNm(string pSiteCd, out string reData, out string reMsg);
        [OperationContract]
        string sMenuMemberDB(string pDbnm, string pSiteCd, string pTopMenuCd, string pSubMenuCd, out List<DataMenuSite> reList, out string reMsg);
        [OperationContract]
        string mMenuMemberDB(string pDbnm, string pSiteCd, string pMenuCd, string pUsingFlag, string pSortNo, string pMemo, out string reMsg, out string reData);
        [OperationContract]
        string aMenuMemberDB(string pDbnm, string pSiteCd, string pMenuCd, string pTopMenuCd, string pSubMenuCd, string pMenuNm, string pUsingFlag, string pSortNo, string pMemo, string pInputId, out string reMsg, out string reData);
        [OperationContract]
        string sCodeAuthSiteMemberDB(string pDbnm, out List<DataCodeAuthSiteMemberDB> reList, out string reMsg);
        [OperationContract]
        string sSetAuthSiteMemberDB(string pDbnm, string pSiteCd, string pTopMenuCd, string pSubMenuCd, string pAuthCd, out List<DataSetAuthSiteMemberDB> reList, out string reMsg);
        [OperationContract]
        string mSetAuthSiteMemberDB(string pDbnm, string pSiteCd, string pMenuCd, string pAuthCd, string pViewFlag, string pNewFlag, string pModifyFlag, string pDelFlag, string pReportFlag, string pPrintFlag, string pDownloadFlag, string pInputId, out string reMsg, out string reData);
        [OperationContract]
        string aSetAuthSiteMemberDB(string pDbnm, string pSiteCd, string pMenuCd, string pAuthCd, string pViewFlag, string pNewFlag, string pModifyFlag, string pDelFlag, string pReportFlag, string pPrintFlag, string pDownloadFlag, string pInputId, out string reMsg, out string reData);


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

        [DataMember(Order = 6)]
        public string MENU_PATH { get; set; }

        [DataMember(Order = 7)]
        public string FILE_FOLDER { get; set; }
    }

    [DataContract]
    public class DataSiteMainDB
    {
        [DataMember(Order = 0)]
        public int SITE_CD { get; set; }

        [DataMember(Order = 1)]
        public string SITE_NM { get; set; }
    }

    [DataContract]
    public class DataMenuSite
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

        [DataMember(Order = 6)]
        public string MEMO { get; set; }

        [DataMember(Order = 7)]
        public string MENU_PATH { get; set; }

        [DataMember(Order = 8)]
        public string FILE_FOLDER { get; set; }
    }

    [DataContract]
    public class DataCodeAuthSiteMemberDB
    {
        [DataMember(Order = 0)]
        public string AUTH_CD { get; set; }

        [DataMember(Order = 1)]
        public string AUTH_NM { get; set; }
    }

    [DataContract]
    public class DataSetAuthSiteMemberDB
    {
        [DataMember(Order = 0)]
        public string MENU_CD { get; set; }
        [DataMember(Order = 1)]
        public string MENU_NM { get; set; }
        [DataMember(Order = 2)]
        public Int16 VIEW_FLAG { get; set; }
        [DataMember(Order = 3)]
        public Int16 NEW_FLAG { get; set; }
        [DataMember(Order = 4)]
        public Int16 MODIFY_FLAG { get; set; }
        [DataMember(Order = 5)]
        public Int16 DEL_FLAG { get; set; }
        [DataMember(Order = 6)]
        public Int16 REPORT_FLAG { get; set; }
        [DataMember(Order = 7)]
        public Int16 PRINT_FLAG { get; set; }
        [DataMember(Order = 8)]
        public Int16 DOWNLOAD_FLAG { get; set; }
    }




}
