using EldigmPlusSvc_Main.Biz.Common;
using EldigmPlusSvc_Main.Biz.Sys.Menu;
using System;
using System.Collections.Generic;
using System.Data;

namespace EldigmPlusSvc_Main.WebSvc.Sys.Menu
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드, svc 및 config 파일에서 클래스 이름 "WsMenuMainDB"을 변경할 수 있습니다.
    // 참고: 이 서비스를 테스트하기 위해 WCF 테스트 클라이언트를 시작하려면 솔루션 탐색기에서 WsMenuMainDB.svc나 WsMenuMainDB.svc.cs를 선택하고 디버깅을 시작하십시오.
    public class WsMenuMainDB : IWsMenuMainDB
    {
        LogClass logs = new LogClass();

        public string sMenuTopTreeView(out List<DataMenuTop> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizMenuMainDB bizMenu = null;
            try
            {
                bizMenu = new BizMenuMainDB();

                try
                {
                    ds = bizMenu.sMenuTopTreeView();

                    reMsg = "[검색 성공]";
                    reCode = "Y";
                }
                catch (Exception ex)
                {
                    reMsg = "[검색 실패]" + ex.ToString();
                    reCode = "N";
                }
            }
            catch (Exception ex)
            {
                reMsg = "[검색 에러] :: " + ex.ToString();
                reCode = "N";
            }

            List<DataMenuTop> data = new List<DataMenuTop>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataMenuTop>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsMenuMainDB.svc  (Function)::sMenuTopTreeView  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        public string sMenuSubTreeView(string pTopMenuCd, out List<DataMenuSub> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizMenuMainDB bizMenu = null;
            try
            {
                bizMenu = new BizMenuMainDB();

                try
                {
                    ds = bizMenu.sMenuSubTreeView(pTopMenuCd);

                    reMsg = "[검색 성공]";
                    reCode = "Y";
                }
                catch (Exception ex)
                {
                    reMsg = "[검색 실패]" + ex.ToString();
                    reCode = "N";
                }
            }
            catch (Exception ex)
            {
                reMsg = "[검색 에러] :: " + ex.ToString();
                reCode = "N";
            }

            List<DataMenuSub> data = new List<DataMenuSub>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataMenuSub>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsMenuMainDB.svc  (Function)::sMenuSubTreeView  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        public string sMenuTreeView(string pTopMenuCd, string pSubMenuCd, out List<DataMenu> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizMenuMainDB bizMenu = null;
            try
            {
                bizMenu = new BizMenuMainDB();

                try
                {
                    ds = bizMenu.sMenuTreeView(pTopMenuCd, pSubMenuCd);

                    reMsg = "[검색 성공]";
                    reCode = "Y";
                }
                catch (Exception ex)
                {
                    reMsg = "[검색 실패]" + ex.ToString();
                    reCode = "N";
                }
            }
            catch (Exception ex)
            {
                reMsg = "[검색 에러] :: " + ex.ToString();
                reCode = "N";
            }

            List<DataMenu> data = new List<DataMenu>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataMenu>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsMenuMainDB.svc  (Function)::sMenuTreeView  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        public string sMenuTreeView2(string pTopMenuCd, string pSubMenuCd, string pMenuCd, out List<DataMenu> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizMenuMainDB bizMenu = null;
            try
            {
                bizMenu = new BizMenuMainDB();

                try
                {
                    ds = bizMenu.sMenuTreeView2(pTopMenuCd, pSubMenuCd, pMenuCd);

                    reMsg = "[검색 성공]";
                    reCode = "Y";
                }
                catch (Exception ex)
                {
                    reMsg = "[검색 실패]" + ex.ToString();
                    reCode = "N";
                }
            }
            catch (Exception ex)
            {
                reMsg = "[검색 에러] :: " + ex.ToString();
                reCode = "N";
            }

            List<DataMenu> data = new List<DataMenu>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataMenu>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsMenuMainDB.svc  (Function)::sMenuTreeView2  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        public string exMenuTop(string pTopMenuCd, string pTopMenuNm, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizMenuMainDB bizMenu = null;
            try
            {
                bizMenu = new BizMenuMainDB();

                int reCnt = bizMenu.exMenuTop(pTopMenuCd, pTopMenuNm);

                if (reCnt > 0)
                {
                    reMsg = "[검색 성공]";
                    reCode = "Y";
                    reData = reCnt.ToString();
                }
                else
                {
                    reMsg = "[검색 성공] - 정보 없음";
                    reCode = "Y";
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsMenuMainDB.svc  (Function)::exMenuTop  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[검색 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        public string exMenuSub(string pSubMenuCd, string pTopMenuCd, string pSubMenuNm, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizMenuMainDB bizMenu = null;
            try
            {
                bizMenu = new BizMenuMainDB();

                int reCnt = bizMenu.exMenuSub(pSubMenuCd, pTopMenuCd, pSubMenuNm);

                if (reCnt > 0)
                {
                    reMsg = "[검색 성공]";
                    reCode = "Y";
                    reData = reCnt.ToString();
                }
                else
                {
                    reMsg = "[검색 성공] - 정보 없음";
                    reCode = "Y";
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsMenuMainDB.svc  (Function)::exMenuSub  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[검색 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        public string exMenu(string pMenuCd, string pTopMenuCd, string pSubMenuCd, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizMenuMainDB bizMenu = null;
            try
            {
                bizMenu = new BizMenuMainDB();

                int reCnt = bizMenu.exMenu(pMenuCd, pTopMenuCd, pSubMenuCd);

                if (reCnt > 0)
                {
                    reMsg = "[검색 성공]";
                    reCode = "Y";
                    reData = reCnt.ToString();
                }
                else
                {
                    reMsg = "[검색 성공] - 정보 없음";
                    reCode = "Y";
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsMenuMainDB.svc  (Function)::exMenu  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[검색 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        public string aMenuTop(string pTopMenuNm, string pAppFlag, string pUsingFlag, string pSortNo, string pInputId, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizMenuMainDB bizMenu = null;
            try
            {
                bizMenu = new BizMenuMainDB();

                int reCnt = bizMenu.aMenuTop(pTopMenuNm, pAppFlag, pUsingFlag, pSortNo, pInputId);

                if (reCnt > 0)
                {
                    reMsg = "[검색 성공]";
                    reCode = "Y";
                    reData = reCnt.ToString();
                }
                else
                {
                    reMsg = "[검색 성공] - 정보 없음";
                    reCode = "Y";
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsMenuMainDB.svc  (Function)::aMenuTop  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[검색 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        public string aMenuSub(string pTopMenuCd, string pSubMenuNm, string pUsingFlag, string pSortNo, string pInputId, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizMenuMainDB bizMenu = null;
            try
            {
                bizMenu = new BizMenuMainDB();

                int reCnt = bizMenu.aMenuSub(pTopMenuCd, pSubMenuNm, pUsingFlag, pSortNo, pInputId);

                if (reCnt > 0)
                {
                    reMsg = "[검색 성공]";
                    reCode = "Y";
                    reData = reCnt.ToString();
                }
                else
                {
                    reMsg = "[검색 성공] - 정보 없음";
                    reCode = "Y";
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsMenuMainDB.svc  (Function)::aMenuSub  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[검색 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        public string aMenu(string pTopMenuCd, string pSubMenuCd, string pMenuCd, string pMenuNm, string pUsingFlag, string pSortNo, string pMenuPath, string pFileFolder, string pInputId, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizMenuMainDB bizMenu = null;
            try
            {
                bizMenu = new BizMenuMainDB();

                int reCnt = bizMenu.aMenu(pTopMenuCd, pSubMenuCd, pMenuCd, pMenuNm, pUsingFlag, pSortNo, pMenuPath, pFileFolder, pInputId);

                if (reCnt > 0)
                {
                    reMsg = "[검색 성공]";
                    reCode = "Y";
                    reData = reCnt.ToString();
                }
                else
                {
                    reMsg = "[검색 성공] - 정보 없음";
                    reCode = "Y";
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsMenuMainDB.svc  (Function)::aMenu  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[검색 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        public string mMenuTop(string pTopMenuCd, string pUsingFlag, string pSortNo, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizMenuMainDB bizMenu = null;
            try
            {
                bizMenu = new BizMenuMainDB();

                int reCnt = bizMenu.mMenuTop(pTopMenuCd, pUsingFlag, pSortNo);

                if (reCnt > 0)
                {
                    reMsg = "[저장 성공]";
                    reCode = "Y";
                    reData = reCnt.ToString();
                }
                else
                {
                    reMsg = "[저장 성공] - 정보 없음";
                    reCode = "Y";
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsMenuMainDB.svc  (Function)::mMenuTop  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        public string mMenuSub(string pTopMenuCd, string pSubMenuCd, string pUsingFlag, string pSortNo, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizMenuMainDB bizMenu = null;
            try
            {
                bizMenu = new BizMenuMainDB();

                int reCnt = bizMenu.mMenuSub(pTopMenuCd, pSubMenuCd, pUsingFlag, pSortNo);

                if (reCnt > 0)
                {
                    reMsg = "[저장 성공]";
                    reCode = "Y";
                    reData = reCnt.ToString();
                }
                else
                {
                    reMsg = "[저장 성공] - 정보 없음";
                    reCode = "Y";
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsMenuMainDB.svc  (Function)::mMenuSub  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        public string mMenu(string pTopMenuCd, string pSubMenuCd, string pMenuCd, string pUsingFlag, string pSortNo, string pMenuPath, string pFileFolder, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizMenuMainDB bizMenu = null;
            try
            {
                bizMenu = new BizMenuMainDB();

                int reCnt = bizMenu.mMenu(pTopMenuCd, pSubMenuCd, pMenuCd, pUsingFlag, pSortNo, pMenuPath, pFileFolder);

                if (reCnt > 0)
                {
                    reMsg = "[저장 성공]";
                    reCode = "Y";
                    reData = reCnt.ToString();
                }
                else
                {
                    reMsg = "[저장 성공] - 정보 없음";
                    reCode = "Y";
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsMenuMainDB.svc  (Function)::mMenu  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;

        }

        public string sSiteMainDB(string pMemcoCd, out List<DataSiteMainDB> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizMenuMainDB bizMenu = null;
            try
            {
                bizMenu = new BizMenuMainDB();

                try
                {
                    ds = bizMenu.sSiteMainDB(pMemcoCd);

                    reMsg = "[검색 성공]";
                    reCode = "Y";
                }
                catch (Exception ex)
                {
                    reMsg = "[검색 실패]" + ex.ToString();
                    reCode = "N";
                }
            }
            catch (Exception ex)
            {
                reMsg = "[검색 에러] :: " + ex.ToString();
                reCode = "N";
            }

            List<DataSiteMainDB> data = new List<DataSiteMainDB>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataSiteMainDB>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsMenuMainDB.svc  (Function)::sSiteMainDB  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        //SITE -> DBNM 가져오기 
        public string siteDbNm(string pSiteCd, out string reData, out string reMsg)
        {
            string reCode = "N";

            string reVal = "";
            BizMenuMainDB bizMenu = null;
            try
            {
                bizMenu = new BizMenuMainDB();

                try
                {
                    reVal = bizMenu.siteDbNm(pSiteCd);

                    reMsg = "[검색 성공]";
                    reCode = "Y";
                }
                catch (Exception ex)
                {
                    reMsg = "[검색 실패]" + ex.ToString();
                    reCode = "N";
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsMenuMainDB.svc  (Function)::siteDbNm  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg = "[검색 에러 - BizSystem 연결 실패] :: " + ex.ToString();
                reCode = "N";
            }

            reData = reVal;

            return reCode;
        }

        public string sMenuMemberDB(string pDbnm, string pSiteCd, string pTopMenuCd, string pSubMenuCd, out List<DataMenuSite> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizMenuMainDB bizMenu = null;
            try
            {
                bizMenu = new BizMenuMainDB();

                try
                {
                    ds = bizMenu.sMenuMemberDB(pDbnm, pSiteCd, pTopMenuCd, pSubMenuCd);

                    reMsg = "[검색 성공]";
                    reCode = "Y";
                }
                catch (Exception ex)
                {
                    reMsg = "[검색 실패]" + ex.ToString();
                    reCode = "N";
                }
            }
            catch (Exception ex)
            {
                reMsg = "[검색 에러] :: " + ex.ToString();
                reCode = "N";
            }

            List<DataMenuSite> data = new List<DataMenuSite>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataMenuSite>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsMenuMainDB.svc  (Function)::sMenuMemberDB  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        public string mMenuMemberDB(string pDbnm, string pSiteCd, string pMenuCd, string pUsingFlag, string pSortNo, string pMemo, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizMenuMainDB bizMenu = null;
            try
            {
                bizMenu = new BizMenuMainDB();

                int reCnt = bizMenu.mMenuMemberDB(pDbnm, pSiteCd, pMenuCd, pUsingFlag, pSortNo, pMemo);

                if (reCnt > 0)
                {
                    reMsg = "[저장 성공]";
                    reCode = "Y";
                    reData = reCnt.ToString();
                }
                else
                {
                    reMsg = "[저장 성공] - 정보 없음";
                    reCode = "Y";
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsMenuMainDB.svc  (Function)::mMenuMemberDB  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;

        }

        public string aMenuMemberDB(string pDbnm, string pSiteCd, string pMenuCd, string pTopMenuCd, string pSubMenuCd, string pMenuNm, string pUsingFlag, string pSortNo, string pMemo, string pInputId, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizMenuMainDB bizMenu = null;
            try
            {
                bizMenu = new BizMenuMainDB();

                int reCnt = bizMenu.aMenuMemberDB(pDbnm, pSiteCd, pMenuCd, pTopMenuCd, pSubMenuCd, pMenuNm, pUsingFlag, pSortNo, pMemo, pInputId);

                if (reCnt > 0)
                {
                    reMsg = "[검색 성공]";
                    reCode = "Y";
                    reData = reCnt.ToString();
                }
                else
                {
                    reMsg = "[검색 성공] - 정보 없음";
                    reCode = "Y";
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsMenuMainDB.svc  (Function)::aMenuMemberDB  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[검색 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        public string sCodeAuthSiteMemberDB(string pDbnm, out List<DataCodeAuthSiteMemberDB> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizMenuMainDB bizMenu = null;
            try
            {
                bizMenu = new BizMenuMainDB();

                try
                {
                    ds = bizMenu.sCodeAuthSiteMemberDB(pDbnm);

                    reMsg = "[검색 성공]";
                    reCode = "Y";
                }
                catch (Exception ex)
                {
                    reMsg = "[검색 실패]" + ex.ToString();
                    reCode = "N";
                }
            }
            catch (Exception ex)
            {
                reMsg = "[검색 에러] :: " + ex.ToString();
                reCode = "N";
            }

            List<DataCodeAuthSiteMemberDB> data = new List<DataCodeAuthSiteMemberDB>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataCodeAuthSiteMemberDB>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsMenuMainDB.svc  (Function)::sSiteMainDB  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        public string sSetAuthSiteMemberDB(string pDbnm, string pSiteCd, string pTopMenuCd, string pSubMenuCd, string pAuthCd, out List<DataSetAuthSiteMemberDB> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizMenuMainDB bizMenu = null;
            try
            {
                bizMenu = new BizMenuMainDB();

                try
                {
                    ds = bizMenu.sSetAuthSiteMemberDB(pDbnm, pSiteCd, pTopMenuCd, pSubMenuCd, pAuthCd);

                    reMsg = "[검색 성공]";
                    reCode = "Y";
                }
                catch (Exception ex)
                {
                    reMsg = "[검색 실패]" + ex.ToString();
                    reCode = "N";
                }
            }
            catch (Exception ex)
            {
                reMsg = "[검색 에러] :: " + ex.ToString();
                reCode = "N";
            }

            List<DataSetAuthSiteMemberDB> data = new List<DataSetAuthSiteMemberDB>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataSetAuthSiteMemberDB>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsMenuMainDB.svc  (Function)::sSiteMainDB  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        public string mSetAuthSiteMemberDB(string pDbnm, string pSiteCd, string pMenuCd, string pAuthCd, string pViewFlag, string pNewFlag, string pModifyFlag, string pDelFlag, string pReportFlag, string pPrintFlag, string pDownloadFlag, string pInputId, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizMenuMainDB bizMenu = null;
            try
            {
                bizMenu = new BizMenuMainDB();

                int reCnt = bizMenu.mSetAuthSiteMemberDB(pDbnm, pSiteCd, pMenuCd, pAuthCd, pViewFlag, pNewFlag, pModifyFlag, pDelFlag, pReportFlag, pPrintFlag, pDownloadFlag);
                int reCntLog = bizMenu.aSetAuthSiteMemberDBLog(pDbnm, pSiteCd, pMenuCd, pAuthCd, pViewFlag, pNewFlag, pModifyFlag, pDelFlag, pReportFlag, pPrintFlag, pDownloadFlag, pInputId);

                if (reCnt > 0)
                {
                    reMsg = "[저장 성공]";
                    reCode = "Y";
                    reData = reCnt.ToString();
                }
                else
                {
                    reMsg = "[저장 성공] - 정보 없음";
                    reCode = "Y";
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsMenuMainDB.svc  (Function)::mMenuMemberDB  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        public string aSetAuthSiteMemberDB(string pDbnm, string pSiteCd, string pMenuCd, string pAuthCd, string pViewFlag, string pNewFlag, string pModifyFlag, string pDelFlag, string pReportFlag, string pPrintFlag, string pDownloadFlag, string pInputId, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizMenuMainDB bizMenu = null;
            try
            {
                bizMenu = new BizMenuMainDB();

                int reCnt = bizMenu.aSetAuthSiteMemberDB(pDbnm, pSiteCd, pMenuCd, pAuthCd, pViewFlag, pNewFlag, pModifyFlag, pDelFlag, pReportFlag, pPrintFlag, pDownloadFlag, pInputId);
                int reCntLog = bizMenu.aSetAuthSiteMemberDBLog(pDbnm, pSiteCd, pMenuCd, pAuthCd, pViewFlag, pNewFlag, pModifyFlag, pDelFlag, pReportFlag, pPrintFlag, pDownloadFlag, pInputId);

                if (reCnt > 0)
                {
                    reMsg = "[검색 성공]";
                    reCode = "Y";
                    reData = reCnt.ToString();
                }
                else
                {
                    reMsg = "[검색 성공] - 정보 없음";
                    reCode = "Y";
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsMenuMainDB.svc  (Function)::aMenuMemberDB  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[검색 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

    }
}
