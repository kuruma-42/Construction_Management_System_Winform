using EldigmPlusClassLibrary.DbClass.Sys.CommonCode;
using EldigmPlusSvc_Main.Biz.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace EldigmPlusSvc_Main.Biz.Sys.ComnCode
{
    public class BizComnCodeGrp
    {
        LogClass logs = new LogClass();

        public DataSet sComnCodeGrp()
        {
            DataSet ds = null;

            DbComnCodeGrpMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbComnCodeGrpMainDB(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                ds = db.sComnCodeGrp();
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizComnCodeGrp.cs  (Function)::sComnCodeGrp  (Detail)::pScodeGrp=[  ]", "Error");
                logs.SaveLog("[error]  (page)::BizComnCodeGrp.cs  (Function)::sComnCodeGrp  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        public DataSet sComnCodeGrpUsingFlag()
        {
            DataSet ds = null;

            DbComnCodeGrpMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbComnCodeGrpMainDB(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                ds = db.sComnCodeGrpUsingFlag();
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizComnCodeGrp.cs  (Function)::sComnCodeGrp  (Detail)::pScodeGrp=[  ]", "Error");
                logs.SaveLog("[error]  (page)::BizComnCodeGrp.cs  (Function)::sComnCodeGrp  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        public int aComnCodeGrp(string pCcodeGrp, string pCcodeGrpNm, string pUsingFlag, string pSortNo, string pMemo, string pInputId)
        {
            int reCnt = 0;

            DbComnCodeGrpMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbComnCodeGrpMainDB(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                reCnt = db.aComnCodeGrp(pCcodeGrp, pCcodeGrpNm, pUsingFlag, pSortNo, pMemo, pInputId);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizComnCodeGrp.cs  (Function)::aComnCodeGrp  (Detail)::, pScodeGrp=[" + pCcodeGrp + "], Grp=[" + pCcodeGrpNm + "], pUsingFlag=[" + pUsingFlag + "]" +
                    ", pSortNo=[" + pSortNo + "], pMemo=[" + pMemo + "], pInputId=[" + pInputId + "]", "Error");
                logs.SaveLog("[error]  (page)::BizComnCodeGrp.cs  (Function)::aComnCodeGrp  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int exComnCodeGrp(string pCcodeGrp)
        {
            int reCnt = 0;

            DbComnCodeGrpMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbComnCodeGrpMainDB(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                reCnt = db.exComnCodeGrp(pCcodeGrp);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizComnCodeGrp.cs  (Function)::exComnCodeGrp  (Detail)::pCcodeGrp=[" + pCcodeGrp + "]", "Error");
                logs.SaveLog("[error]  (page)::BizComnCodeGrp.cs  (Function)::exComnCodeGrp  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int mComnCodeGrp(string pCcodeGrp, string pCcodeNm, string pUsingFlag, string pSortNo, string pMemo)
        {
            int reCnt = 0;

            DbComnCodeGrpMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbComnCodeGrpMainDB(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                reCnt = db.mComnCodeGrp(pCcodeGrp, pCcodeNm, pUsingFlag, pSortNo, pMemo);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizComnCodeGrp.cs  (Function)::mComnCodeGrp  (Detail)::pCcodeGrp=[" + pCcodeGrp + "], pCcodeNm=[" + pCcodeNm + "], pUsingFlag=[" + pUsingFlag + "]" +
                    ", pSortNo=[" + pSortNo + "], pMemo=[" + pMemo + "]", "Error");
                logs.SaveLog("[error]  (page)::BizComnCodeGrp.cs  (Function)::mComnCodeGrp  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public string siteDbNm(string pSiteCd)
        {
            string reVal = "";

            DbComnCodeGrpMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbComnCodeGrpMainDB(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                reVal = db.siteDbNm(pSiteCd);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizComnCodeGrp.cs  (Function)::siteDbNm  (Detail)::pSiteCd=[" + pSiteCd + "]", "Error");
                logs.SaveLog("[error]  (page)::BizComnCodeGrp.cs  (Function)::siteDbNm  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reVal;
        }

        public DataSet sCodeAuthSiteMemberDB(string pDbnm)
        {
            DataSet ds = null;

            DbComnCodeGrpMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbComnCodeGrpMainDB(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                ds = db.sCodeAuthSiteMemberDB(pDbnm);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizComnCodeGrp.cs  (Function)::sCodeAuthSiteMemberDB  (Detail)::pScodeGrp=[  ]", "Error");
                logs.SaveLog("[error]  (page)::BizComnCodeGrp.cs  (Function)::sCodeAuthSiteMemberDB  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        public DataSet sSetAuthSiteMemberDB(string pDbnm, string pSiteCd, string pAuthCd)
        {
            DataSet ds = null;

            DbComnCodeGrpMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbComnCodeGrpMainDB(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                ds = db.sSetAuthSiteMemberDB(pDbnm, pSiteCd, pAuthCd);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizComnCodeGrp.cs  (Function)::sSetAuthSiteMemberDB  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        public DataSet sSetAuthSiteMemberDBSub(string pCcodeGrp, string pDbnm, string pSiteCd, string pAuthCd)
        {
            DataSet ds = null;

            DbComnCodeGrpMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbComnCodeGrpMainDB(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                ds = db.sSetAuthSiteMemberDBSub(pCcodeGrp, pDbnm, pSiteCd, pAuthCd);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizComnCodeGrp.cs  (Function)::sSetAuthSiteMemberDB  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        public int mSetAuthSiteMemberDB(string pDbnm, string pSiteCd, string pAuthCd, string pCcodeGrp, string pViewFlag, string pNewFlag, string pModifyFlag, string pDelFlag, string pReportFlag, string pPrintFlag, string pDownloadFlag)
        {
            int reCnt = 0;

            DbComnCodeGrpMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbComnCodeGrpMainDB(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                reCnt = db.mSetAuthSiteMemberDB(pDbnm, pSiteCd, pAuthCd, pCcodeGrp, pViewFlag, pNewFlag, pModifyFlag, pDelFlag, pReportFlag, pPrintFlag, pDownloadFlag);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizComnCodeGrp.cs  (Function)::mSetAuthSiteMemberDB  (Detail):: pDbnm=['" + pDbnm + "'], pSiteCd =['" + pSiteCd + "']" +
                    ", pCcodeGrp=['" + pCcodeGrp + "'], pAuthCd=[" + pAuthCd + "], pViewFlag=[" + pViewFlag + "]" + ", pNewFlag=[" + pNewFlag + "]" +
                    ", pModifyFlag=[" + pModifyFlag + "'], pDelFlag=[" + pDelFlag + "], pReportFlag=[" + pReportFlag + "], pPrintFlag=[" + pPrintFlag + "]" +
                    ", pDownloadFlag=[" + pDownloadFlag + "]", "Error");
                logs.SaveLog("[error]  (page)::BizComnCodeGrp.cs  (Function)::mSetAuthSiteMemberDB  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int aSetAuthSiteMemberDBLog(string pDbnm, string pSiteCd, string pAuthCd, string pCcodeGrp, string pViewFlag, string pNewFlag, string pModifyFlag, string pDelFlag, string pReportFlag, string pPrintFlag, string pDownloadFlag, string pInputId)
        {
            int reCnt = 0;
            DbComnCodeGrpMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbComnCodeGrpMainDB(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                reCnt = db.aSetAuthSiteMemberDBLog(pDbnm, pSiteCd, pAuthCd, pCcodeGrp, pViewFlag, pNewFlag, pModifyFlag, pDelFlag, pReportFlag, pPrintFlag, pDownloadFlag, pInputId);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizComnCodeGrp.cs  (Function)::aSetAuthSiteMemberDBLog  (Detail)::, pDbnm=['" + pDbnm + "'], pSiteCd=[" + pSiteCd + "]" +
                    ", pCcodeGrp=['" + pCcodeGrp + "'], pAuthCd=['" + pAuthCd + "'], pViewFlag=[" + pViewFlag + "]" +
                    ", pNewFlag=[" + pNewFlag + "], pModifyFlag =[" + pModifyFlag + "], pDelFlag=[" + pDelFlag + "], pReportFlag=[" + pReportFlag + "]" +
                    ", pPrintFlag =[" + pPrintFlag + "], pDownloadFlag =[" + pDownloadFlag + "], pInputId =[" + pInputId + "]", "Error");
                logs.SaveLog("[error]  (page)::BizComnCodeGrp.cs  (Function)::aSetAuthSiteMemberDBLog  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int aSetAuthSiteMemberDB(string pDbnm, string pSiteCd, string pAuthCd, string pCcodeGrp, string pViewFlag, string pNewFlag, string pModifyFlag, string pDelFlag, string pReportFlag, string pPrintFlag, string pDownloadFlag, string pInputId)
        {
            int reCnt = 0;

            DbComnCodeGrpMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbComnCodeGrpMainDB(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                reCnt = db.aSetAuthSiteMemberDB(pDbnm, pSiteCd, pAuthCd, pCcodeGrp, pViewFlag, pNewFlag, pModifyFlag, pDelFlag, pReportFlag, pPrintFlag, pDownloadFlag, pInputId);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizComnCodeGrp.cs  (Function)::aSetAuthSiteMemberDB  (Detail)::, pDbnm=['" + pDbnm + "'], pSiteCd=[" + pSiteCd + "]" +
                    ", pCcodeGrp=['" + pCcodeGrp + "'], pAuthCd=['" + pAuthCd + "'], pViewFlag=[" + pViewFlag + "]" +
                    ", pNewFlag=[" + pNewFlag + "], pModifyFlag =[" + pModifyFlag + "], pDelFlag=[" + pDelFlag + "], pReportFlag=[" + pReportFlag + "]" +
                    ", pPrintFlag =[" + pPrintFlag + "], pDownloadFlag =[" + pDownloadFlag + "], pInputId =[" + pInputId + "]", "Error");
                logs.SaveLog("[error]  (page)::BizComnCodeGrp.cs  (Function)::aSetAuthSiteMemberDB  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public DataSet sComnSiteTreeView(string pDbnm, string pSiteCd, string pAuthCd)
        {
            DataSet ds = null;

            DbComnCodeGrpMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbComnCodeGrpMainDB(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                ds = db.sComnSiteTreeView(pDbnm, pSiteCd, pAuthCd);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizComnCodeGrp.cs  (Function)::sComnSiteTreeView  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        public DataSet sComnSite(string pDbnm, string pSiteCd, string pCcodeGrp, string pUsingFlag, string pCcodeNm)
        {
            DataSet ds = null;

            DbComnCodeGrpMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbComnCodeGrpMainDB(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                ds = db.sComnSite(pDbnm, pSiteCd, pCcodeGrp, pUsingFlag, pCcodeNm);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizComnCodeGrp.cs  (Function)::sComnSite  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        public int mComnSite(string pDbnm, string pSiteCd, string pCcode, string pUsingFlag, string pSortNo, string pMemo)
        {
            int reCnt = 0;

            DbComnCodeGrpMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbComnCodeGrpMainDB(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                reCnt = db.mComnSite(pDbnm, pSiteCd, pCcode, pUsingFlag, pSortNo, pMemo);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizComnCodeGrp.cs  (Function)::mComnSite  (Detail):: pDbnm=['" + pDbnm + "'], pSiteCd =['" + pSiteCd + "']" +
                    ", pCcode=['" + pCcode + "'], pUsingFlag=[" + pUsingFlag + "], pSortNo=[" + pSortNo + "]" + ", pMemo=[" + pMemo + "]", "Error");
                logs.SaveLog("[error]  (page)::BizComnCodeGrp.cs  (Function)::mComnSite  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int aComnSiteLog(string pDbnm, string pSiteCd, string pCcode, string pUsingFlag, string pSortNo, string pMemo, string pInputId)
        {
            int reCnt = 0;
            DbComnCodeGrpMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbComnCodeGrpMainDB(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                reCnt = db.aComnSiteLog(pDbnm, pSiteCd, pCcode, pUsingFlag, pSortNo, pMemo, pInputId);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizComnCodeGrp.cs  (Function)::aComnSiteLog  (Detail)::, pDbnm=['" + pDbnm + "'], pSiteCd=[" + pSiteCd + "]" +
                    ", pCcode=['" + pCcode + "'], pUsingFlag=['" + pUsingFlag + "'], pSortNo=[" + pSortNo + "]" +
                    ", pMemo=[" + pMemo + "], pInputId =[" + pInputId + "]", "Error");
                logs.SaveLog("[error]  (page)::BizComnCodeGrp.cs  (Function)::aComnSiteLog  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public string aComnSite(string pDbNm, Hashtable param, out Hashtable outVal)
        {
            string reVal = "";

            DbComnCodeGrpMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = "Initial Catalog=PLUS-" + pDbNm + ";";
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbComnCodeGrpMainDB(dbCon_IP, dbCon_DB, dbCon_USER, "1");
                reVal = db.aComnSite(param, out outVal);
            }
            catch (Exception ex)
            {
                outVal = null;
                //logs.SaveLog("[error]  (page)::BizSite.cs  (Function)::aSite  (Detail)::memcoCd_val=[" + memcoCd_val + "], siteNm_val=[" + siteNm_val + "], usingFlag_val=[" + usingFlag_val + "]" +
                //    ", sortNo_val=[" + sortNo_val + "], pInputId=[" + pInputId + "]", "Error");
                logs.SaveLog("[error]  (page)::BizSite.cs  (Function)::aSite  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reVal;
        }

    }
}