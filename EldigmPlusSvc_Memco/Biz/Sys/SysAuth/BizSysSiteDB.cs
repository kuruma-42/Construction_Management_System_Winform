using EldigmPlusClassLibrary.DbClass.Sys.SysAuth;
using EldigmPlusSvc_Memco.Biz.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace EldigmPlusSvc_Memco.Biz.Sys.SysAuth
{
    public class BizSysSiteDB
    {
        LogClass logs = new LogClass();


        public string siteDbNm(string pSiteCd)
        {
            string reVal = "";

            DbSysAuthSiteDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbSysAuthSiteDB(dbCon_IP, dbCon_DB, dbCon_USER);
                reVal = db.siteDbNm(pSiteCd);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizSysSiteDB.cs  (Function)::siteDbNm  (Detail)::pSiteCd=[" + pSiteCd + "]", "Error");
                logs.SaveLog("[error]  (page)::BizSysSiteDB.cs  (Function)::siteDbNm  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reVal;
        }

        public DataSet sSiteMainDB(string pMemcoCd)
        {
            DataSet ds = null;

            DbSysAuthSiteDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbSysAuthSiteDB(dbCon_IP, dbCon_DB, dbCon_USER);
                ds = db.sSiteMainDB(pMemcoCd);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizSysSiteDB.cs  (Function)::sSiteMainDB  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }


        public DataSet sSysAuthSiteDB(string pSiteCd, string pDbnm, string pUsingFlag)
        {
            DataSet ds = null;

            DbSysAuthSiteDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbSysAuthSiteDB(dbCon_IP, dbCon_DB, dbCon_USER);
                ds = db.sSysAuthSiteDB(pSiteCd, pDbnm, pUsingFlag);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizSysSiteMemberDB.cs  (Function)::sSysAuthSiteDB  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }
        
        public int mSysAuthSiteDB(string pDbnm, string pSiteCd, string sauthCd_val, string lab_aprv_Flag_val, string usingFlag_val, string memo_val)
        {
            int reCnt = 0;

            DbSysAuthSiteDB db = null;

            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbSysAuthSiteDB(dbCon_IP, dbCon_DB, dbCon_USER);
                reCnt = db.mSysAuthSiteDB(pDbnm, pSiteCd, sauthCd_val, lab_aprv_Flag_val, usingFlag_val, memo_val);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizSysSiteDB.cs  (Function)::mSysAuthSiteDB  (Detail)::pDbnm=[" + pDbnm + "], pSiteCd=[" + pSiteCd + "], sauthCd_val=[" + sauthCd_val + "], lab_aprv_Flag_val=[" + lab_aprv_Flag_val + "], usingFlag_val=[" + usingFlag_val + "] ", "Error");
                logs.SaveLog("[error]  (page)::BizSysSiteDB.cs  (Function)::mSysAuthSiteDB  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        
        public int aSysAuthSiteDB(string pDbnm, string pSiteCd, string sauthCd_val, string lab_aprv_Flag_val, string usingFlag_val, string sauthLevel_val, string memo_val, string pInputId)
        {
            int reCnt = 0;

            DbSysAuthSiteDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbSysAuthSiteDB(dbCon_IP, dbCon_DB, dbCon_USER);
                reCnt = db.aSysAuthSiteDB(pDbnm, pSiteCd, sauthCd_val, lab_aprv_Flag_val, usingFlag_val, sauthLevel_val, memo_val, pInputId);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizSysSiteDB.cs  (Function)::aSysAuthSiteDB  (Detail)::pSiteCd=[" + pSiteCd + "], sauthCd_val=[" + sauthCd_val + "], lab_aprv_Flag_val=[" + lab_aprv_Flag_val + "]" +
                    ", usingFlag_val=[" + usingFlag_val + "], sauthLevel_val=[" + sauthLevel_val + "], memo_val=[" + memo_val + "], pInputId=[" + pInputId + "]", "Error");
                logs.SaveLog("[error]  (page)::BizSysSiteDB.cs  (Function)::aSysAuthSiteDB  (Detail)::" + "\r\n" + ex.ToString(), "Error");
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