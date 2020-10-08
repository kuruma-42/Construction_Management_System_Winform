using EldigmPlusClassLibrary.DbClass.Sys.Menu;
using EldigmPlusSvc_Main.Biz.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace EldigmPlusSvc_Main.Biz.Sys.Menu
{
    public class BizMenuMainDB
    {
        LogClass _logs = new LogClass();

        public DataSet sMenuTopTreeView()
        {
            DataSet ds = null;

            DbMenuMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbMenuMainDB(dbCon_IP, dbCon_DB, dbCon_USER);
                ds = db.sMenuTopTreeView();
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::sMenuTopTreeView  (Detail)::", "Error");
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::sMenuTopTreeView  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        public DataSet sMenuSubTreeView(string pTopMenuCd)
        {
            DataSet ds = null;

            DbMenuMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbMenuMainDB(dbCon_IP, dbCon_DB, dbCon_USER);
                ds = db.sMenuSubTreeView(pTopMenuCd);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::sMenuSubTreeView  (Detail)::pTopMenuCd=[" + pTopMenuCd + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::sMenuSubTreeView  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        public DataSet sMenuTreeView(string pTopMenuCd, string pSubMenuCd)
        {
            DataSet ds = null;

            DbMenuMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbMenuMainDB(dbCon_IP, dbCon_DB, dbCon_USER);
                ds = db.sMenuTreeView(pTopMenuCd, pSubMenuCd);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::sMenuTreeView  (Detail)::pTopMenuCd=[" + pTopMenuCd + "]" +
               ", pSubMenuCd=[" + pSubMenuCd + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::sMenuTreeView  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        public DataSet sMenuTreeView2(string pTopMenuCd, string pSubMenuCd, string pMenuCd)
        {
            DataSet ds = null;

            DbMenuMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbMenuMainDB(dbCon_IP, dbCon_DB, dbCon_USER);
                ds = db.sMenuTreeView2(pTopMenuCd, pSubMenuCd, pMenuCd);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::sMenuTreeView2  (Detail)::pTopMenuCd=[" + pTopMenuCd + "]" +
                ", pSubMenuCd=[" + pSubMenuCd + "], pMenuCd=[" + pMenuCd + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::sMenuTreeView2  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        public int exMenuTop(string pTopMenuCd, string pTopMenuNm)
        {
            throw new NotImplementedException();
        }

        public int exMenuSub(string pSubMenuCd, string pTopMenuCd, string pSubMenuNm)
        {
            int reCnt = 0;

            DbMenuMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbMenuMainDB(dbCon_IP, dbCon_DB, dbCon_USER);
                reCnt = db.exMenuSub(pSubMenuCd, pTopMenuCd, pSubMenuNm);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::exMenuSub  (Detail)::pSubMenuCd=[" + pSubMenuCd + "]" +
                 ", pTopMenuCd=[" + pTopMenuCd + "], pSubMenuNm=[" + pSubMenuNm + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::exMenuSub  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int exMenu(string pMenuCd, string pTopMenuCd, string pSubMenuCd)
        {
            int reCnt = 0;

            DbMenuMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbMenuMainDB(dbCon_IP, dbCon_DB, dbCon_USER);
                reCnt = db.exMenu(pMenuCd, pTopMenuCd, pSubMenuCd);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::exMenu  (Detail)::pMenuCd=[" + pMenuCd + "]" +
                 ", pTopMenuCd=[" + pTopMenuCd + "], pSubMenuCd=[" + pSubMenuCd + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::exMenu  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int aMenuTop(string pTopMenuNm, string pAppFlag, string pUsingFlag, string pSortNo, string pInputId)
        {
            int reCnt = 0;

            DbMenuMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbMenuMainDB(dbCon_IP, dbCon_DB, dbCon_USER);
                reCnt = db.aMenuTop(pTopMenuNm, pAppFlag, pUsingFlag, pSortNo, pInputId);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::aMenuTop  (Detail)::, pTopMenuNm=[" + pTopMenuNm + "], pAppFlag=[" + pAppFlag + "]" +
                    ", pUsingFlag=[" + pUsingFlag + "], pSortNo=[" + pSortNo + "], pInputId=[" + pInputId + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::aMenuTop  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int aMenuSub(string pTopMenuCd, string pSubMenuNm, string pUsingFlag, string pSortNo, string pInputId)
        {
            int reCnt = 0;

            DbMenuMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbMenuMainDB(dbCon_IP, dbCon_DB, dbCon_USER);
                reCnt = db.aMenuSub(pTopMenuCd, pSubMenuNm, pUsingFlag, pSortNo, pInputId);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::aMenuSub  (Detail)::, pTopMenuCd=[" + pTopMenuCd + "], pSubMenuNm=[" + pSubMenuNm + "]" +
                    ", pUsingFlag=[" + pUsingFlag + "], pSortNo=[" + pSortNo + "], pInputId=[" + pInputId + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::aMenuSub  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int aMenu(string pTopMenuCd, string pSubMenuCd, string pMenuCd, string pMenuNm, string pUsingFlag, string pSortNo, string pMenuPath, string pFileFolder, string pInputId)
        {
            int reCnt = 0;
            
            DbMenuMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbMenuMainDB(dbCon_IP, dbCon_DB, dbCon_USER);
                reCnt = db.aMenu(pTopMenuCd, pSubMenuCd, pMenuCd, pMenuNm, pUsingFlag, pSortNo, pMenuPath, pFileFolder, pInputId);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::aMenu  (Detail)::, pMenuCd=[" + pMenuCd + "], pTopMenuCd=[" + pTopMenuCd + "], pSubMenuCd=[" + pSubMenuCd + "]" +
                    ", pMenuNm=[" + pMenuNm + "], pUsingFlag =[" + pUsingFlag + "], pSortNo=[" + pSortNo + "], pInputId=[" + pInputId + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::aMenu  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int mMenuTop(string pTopMenuCd, string pUsingFlag, string pSortNo)
        {
            int reCnt = 0;

            DbMenuMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbMenuMainDB(dbCon_IP, dbCon_DB, dbCon_USER);
                reCnt = db.mMenuTop(pTopMenuCd, pUsingFlag, pSortNo);
                //mMenuTop(string TOP_MENU_CD, string USING_FLAG, string SORT_NO)
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::mMenuTop  (Detail)::, pTopMenuCd=[" + pTopMenuCd + "]," +
                    " pUsingFlag=[" + pUsingFlag + "], pSortNo=[" + pSortNo + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::mMenuTop  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int mMenuSub(string pTopMenuCd, string pSubMenuCd, string pUsingFlag, string pSortNo)
        {
            int reCnt = 0;

            DbMenuMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbMenuMainDB(dbCon_IP, dbCon_DB, dbCon_USER);
                reCnt = db.mMenuSub(pTopMenuCd, pSubMenuCd, pUsingFlag, pSortNo);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::mMenuSub  (Detail)::, pTopMenuCd=[" + pTopMenuCd + "]" +
                    ", pSubMenuCd=[" + pSubMenuCd + "], pUsingFlag =[" + pUsingFlag + "], pSortNo=[" + pSortNo + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::mMenuSub  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int mMenu(string pTopMenuCd, string pSubMenuCd, string pMenuCd, string pUsingFlag, string pSortNo, string pMenuPath, string pFileFolder)
        {
            int reCnt = 0;

            DbMenuMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbMenuMainDB(dbCon_IP, dbCon_DB, dbCon_USER);
                reCnt = db.mMenu(pTopMenuCd, pSubMenuCd, pMenuCd, pUsingFlag, pSortNo, pMenuPath, pFileFolder);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::mMenu  (Detail):: pTopMenuCd=[" + pTopMenuCd + "]" +
                    ", pSubMenuCd=[" + pSubMenuCd + "], pMenuCd=[" + pMenuCd + "], pUsingFlag=[" + pUsingFlag + "]" +
                    ", pSortNo=[" + pSortNo + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::mMenu  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public DataSet sSiteMainDB(string pMemcoCd)
        {
            DataSet ds = null;

            DbMenuMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbMenuMainDB(dbCon_IP, dbCon_DB, dbCon_USER);
                ds = db.sSiteMainDB(pMemcoCd);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::sSiteMainDB  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        public string siteDbNm(string pSiteCd)
        {
            string reVal = "";

            DbMenuMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbMenuMainDB(dbCon_IP, dbCon_DB, dbCon_USER);
                reVal = db.siteDbNm(pSiteCd);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::siteDbNm  (Detail)::pSiteCd=[" + pSiteCd + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::siteDbNm  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reVal;
        }

        public DataSet sMenuMemberDB(string pDbnm, string pSiteCd, string pTopMenuCd, string pSubMenuCd)
        {
            DataSet ds = null;

            DbMenuMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbMenuMainDB(dbCon_IP, dbCon_DB, dbCon_USER);
                ds = db.sMenuMemberDB(pDbnm, pSiteCd, pTopMenuCd, pSubMenuCd);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::sMenuMemberDB  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        public int mMenuMemberDB(string pDbnm, string pSiteCd, string pMenuCd, string pUsingFlag, string pSortNo, string pMemo)
        {
            int reCnt = 0;

            DbMenuMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbMenuMainDB(dbCon_IP, dbCon_DB, dbCon_USER);
                reCnt = db.mMenuMemberDB(pDbnm, pSiteCd, pMenuCd, pUsingFlag, pSortNo, pMemo);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::mMenuMemberDB  (Detail):: pDbnm=[" + pDbnm + "]" +
                    ", pSiteCd=[" + pSiteCd + "], pMenuCd=[" + pMenuCd + "], pUsingFlag=[" + pUsingFlag + "], pSortNo=[" + pSortNo + "]" +
                    ", pMemo=[" + pMemo + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::mMenuMemberDB  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int aMenuMemberDB(string pDbnm, string pSiteCd, string pMenuCd, string pTopMenuCd, string pSubMenuCd, string pMenuNm, string pUsingFlag, string pSortNo, string pMemo, string pInputId)
        {
            int reCnt = 0;

            DbMenuMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbMenuMainDB(dbCon_IP, dbCon_DB, dbCon_USER);
                reCnt = db.aMenuMemberDB(pDbnm, pSiteCd, pMenuCd, pTopMenuCd, pSubMenuCd, pMenuNm, pUsingFlag, pSortNo, pMemo, pInputId);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::aMenuMemberDB  (Detail)::, pDbnm=[" + pDbnm + "], pSiteCd=[" + pSiteCd + "]," +
                    " pMenuCd=[" + pMenuCd + "], pTopMenuCd=[" + pTopMenuCd + "], pSubMenuCd=[" + pSubMenuCd + "]" +
                    ", pMenuNm=[" + pMenuNm + "], pUsingFlag =[" + pUsingFlag + "], pSortNo=[" + pSortNo + "], pMemo=[" + pMemo + "]," +
                    " pInputId =[" + pInputId + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::aMenuMemberDB  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public DataSet sCodeAuthSiteMemberDB(string pDbnm)
        {
            DataSet ds = null;

            DbMenuMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbMenuMainDB(dbCon_IP, dbCon_DB, dbCon_USER);
                ds = db.sCodeAuthSiteMemberDB(pDbnm);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::sCodeAuthSiteMemberDB  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        public DataSet sSetAuthSiteMemberDB(string pDbnm, string pSiteCd, string pTopMenuCd, string pSubMenuCd, string pAuthCd)
        {
            DataSet ds = null;

            DbMenuMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbMenuMainDB(dbCon_IP, dbCon_DB, dbCon_USER);
                ds = db.sSetAuthSiteMemberDB(pDbnm, pSiteCd, pTopMenuCd, pSubMenuCd, pAuthCd);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::sSetAuthSiteMemberDB  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        public int mSetAuthSiteMemberDB(string pDbnm, string pSiteCd, string pMenuCd, string pAuthCd, string pViewFlag, string pNewFlag, string pModifyFlag, string pDelFlag, string pReportFlag, string pPrintFlag, string pDownloadFlag)
        {
            int reCnt = 0;

            DbMenuMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbMenuMainDB(dbCon_IP, dbCon_DB, dbCon_USER);
                reCnt = db.mSetAuthSiteMemberDB(pDbnm, pSiteCd, pMenuCd, pAuthCd, pViewFlag, pNewFlag, pModifyFlag, pDelFlag, pReportFlag, pPrintFlag, pDownloadFlag);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::mSetAuthSiteMemberDB  (Detail):: pDbnm=['" + pDbnm + "'], pMenuCd =['" + pMenuCd + "']" +
                    ", pAuthCd=['" + pAuthCd + "'], pViewFlag=[" + pViewFlag + "], pNewFlag=[" + pNewFlag + "]" + ", pModifyFlag=[" + pModifyFlag + "]" +
                    ", pDelFlag=[" + pDelFlag + "], pReportFlag=[" + pReportFlag + "], pPrintFlag=[" + pPrintFlag + "]" +
                    ", pDownloadFlag=[" + pDownloadFlag + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::mSetAuthSiteMemberDB  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int aSetAuthSiteMemberDBLog(string pDbnm, string pSiteCd, string pMenuCd, string pAuthCd, string pViewFlag, string pNewFlag, string pModifyFlag, string pDelFlag, string pReportFlag, string pPrintFlag, string pDownloadFlag, string pInputId)
        {
            int reCnt = 0;

            DbMenuMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbMenuMainDB(dbCon_IP, dbCon_DB, dbCon_USER);
                reCnt = db.aSetAuthSiteMemberDBLog(pDbnm, pSiteCd, pMenuCd, pAuthCd, pViewFlag, pNewFlag, pModifyFlag, pDelFlag, pReportFlag, pPrintFlag, pDownloadFlag, pInputId);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::aSetAuthSiteMemberDBLog  (Detail)::, pDbnm=['" + pDbnm + "'], pSiteCd=[" + pSiteCd + "]" +
                    ", pMenuCd=['" + pMenuCd + "'], pAuthCd=['" + pAuthCd + "'], pViewFlag=[" + pViewFlag + "]" +
                    ", pNewFlag=[" + pNewFlag + "], pModifyFlag =[" + pModifyFlag + "], pDelFlag=[" + pDelFlag + "], pReportFlag=[" + pReportFlag + "]" +
                    ", pPrintFlag =[" + pPrintFlag + "], pDownloadFlag =[" + pDownloadFlag + "], pInputId =[" + pInputId + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::aSetAuthSiteMemberDBLog  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int aSetAuthSiteMemberDB(string pDbnm, string pSiteCd, string pMenuCd, string pAuthCd, string pViewFlag, string pNewFlag, string pModifyFlag, string pDelFlag, string pReportFlag, string pPrintFlag, string pDownloadFlag, string pInputId)
        {
            int reCnt = 0;

            DbMenuMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbMenuMainDB(dbCon_IP, dbCon_DB, dbCon_USER);
                reCnt = db.aSetAuthSiteMemberDB(pDbnm, pSiteCd, pMenuCd, pAuthCd, pViewFlag, pNewFlag, pModifyFlag, pDelFlag, pReportFlag, pPrintFlag, pDownloadFlag, pInputId);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::aSetAuthSiteMemberDB  (Detail)::, pDbnm=['" + pDbnm + "'], pSiteCd=[" + pSiteCd + "]" +
                    ", pMenuCd=['" + pMenuCd + "'], pAuthCd=['" + pAuthCd + "'], pViewFlag=[" + pViewFlag + "]" +
                    ", pNewFlag=[" + pNewFlag + "], pModifyFlag =[" + pModifyFlag + "], pDelFlag=[" + pDelFlag + "], pReportFlag=[" + pReportFlag + "]" +
                    ", pPrintFlag =[" + pPrintFlag + "], pDownloadFlag =[" + pDownloadFlag + "], pInputId =[" + pInputId + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::aSetAuthSiteMemberDB  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        
    }
}