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
    public class BizSysAuthMemberDB
    {
        LogClass logs = new LogClass();
        public string sDbNm(string pMemcoCd)
        {
            string reVal = "";

            DbSysAuthMemberDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbSysAuthMemberDB(dbCon_IP, dbCon_DB, dbCon_USER);
                reVal = db.sDbNm(pMemcoCd);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizSysAuthMemberDB.cs  (Function)::sDbNm  (Detail)::pMemcoCd=[" + pMemcoCd + "]", "Error");
                logs.SaveLog("[error]  (page)::BizSysAuthMemberDB.cs  (Function)::sDbNm  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reVal;
        }

        public DataSet sMemberMainDB()
        {
            DataSet ds = null;

            DbSysAuthMemberDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbSysAuthMemberDB(dbCon_IP, dbCon_DB, dbCon_USER);
                ds = db.sMemberMainDB();
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizSysAuthMemberDB.cs  (Function)::sMemberMainDB  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }


        public DataSet sSysAuthMemberDB(string pDbnm, string pUsingFlag)
        {
            DataSet ds = null;

            DbSysAuthMemberDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbSysAuthMemberDB(dbCon_IP, dbCon_DB, dbCon_USER);
                ds = db.sSysAuthMemberDB(pDbnm, pUsingFlag);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizSysAuthMemberDB.cs  (Function)::sSysAuthMemberDB  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        public int mSysAuthMemberDB(string pDbnm, string sauthCd_val, string sauthNm_val, string myblockFlag_val, string myconFlag_val, string mycomFlag_val, string myteamFlag_val, string usingFlag_val, string memo_val)
        {
            int reCnt = 0;

            DbSysAuthMemberDB db = null;

            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbSysAuthMemberDB(dbCon_IP, dbCon_DB, dbCon_USER);
                reCnt = db.mSysAuthMemberDB(pDbnm, sauthCd_val, sauthNm_val, myblockFlag_val, myconFlag_val, mycomFlag_val, myteamFlag_val, usingFlag_val, memo_val);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizSysAuthMemberDB.cs  (Function)::mSysAuthMemberDB  (Detail)::sauthCd_val=[" + sauthCd_val + "], sauthNm_val=[" + sauthNm_val + "], myblockFlag_val=[" + myblockFlag_val + "], myconFlag_val=[" + myconFlag_val + "], mycomFlag_val=[" + mycomFlag_val + "], myteamFlag_val=[" + myteamFlag_val + "], usingFlag_val=[" + usingFlag_val + "], memo_val=[" + memo_val + "]", "Error");
                logs.SaveLog("[error]  (page)::BizSysAuthMemberDB.cs  (Function)::mSysAuthMemberDB  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int exSysAuthMainDB(string sauthCd_val, string sauthNm_val)
        {
            int reCnt = 0;

            DbSysAuthMemberDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbSysAuthMemberDB(dbCon_IP, dbCon_DB, dbCon_USER);
                reCnt = db.exSysAuthMainDB(sauthCd_val, sauthNm_val);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizSysAuthMemberDB.cs  (Function)::exSysAuthMainDB  (Detail)::sauthCd_val=[" + sauthCd_val + "]", "Error");
                logs.SaveLog("[error]  (page)::BizSysAuthMemberDB.cs  (Function)::exSysAuthMainDB  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int aSysAuthMemberDB(string pDbnm, string sauthCd_val, string sauthNm_val, string myblockFlag_val, string myconFlag_val, string mycomFlag_val, string myteamFlag_val, string usingFlag_val, string sauthLevel_val, string memo_val, string pInputId)
        {
            int reCnt = 0;

            DbSysAuthMemberDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbSysAuthMemberDB(dbCon_IP, dbCon_DB, dbCon_USER);
                reCnt = db.aSysAuthMemberDB(pDbnm, sauthCd_val, sauthNm_val, myblockFlag_val, myconFlag_val, mycomFlag_val, myteamFlag_val, usingFlag_val, sauthLevel_val, memo_val, pInputId);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizSysAuthMemberDB.cs  (Function)::aSysAuthMemberDB  (Detail)::sauthCd_val=[" + sauthCd_val + "], sauthNm_val=[" + sauthNm_val + "], myblockFlag_val=[" + myblockFlag_val + "]" +
                    ", myconFlag_val=[" + myconFlag_val + "], mycomFlag_val=[" + mycomFlag_val + "]", "Error");
                logs.SaveLog("[error]  (page)::BizSysAuthMemberDB.cs  (Function)::aSysAuthMemberDB  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int aSysAuthMainDB(string sauthCd_val, string sauthNm_val, string myblockFlag_val, string myconFlag_val, string mycomFlag_val, string myteamFlag_val, string usingFlag_val, string sauthLevel_val, string memo_val, string pInputId)
        {
            int reCnt = 0;

            DbSysAuthMemberDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbSysAuthMemberDB(dbCon_IP, dbCon_DB, dbCon_USER);
                reCnt = db.aSysAuthMainDB(sauthCd_val, sauthNm_val, myblockFlag_val, myconFlag_val, mycomFlag_val, myteamFlag_val, usingFlag_val, sauthLevel_val, memo_val, pInputId);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizSysAuthMemberDB.cs  (Function)::aSysAuthMainDB  (Detail)::sauthCd_val=[" + sauthCd_val + "], sauthNm_val=[" + sauthNm_val + "], myblockFlag_val=[" + myblockFlag_val + "]" +
                    ", myconFlag_val=[" + myconFlag_val + "], mycomFlag_val=[" + mycomFlag_val + "]", "Error");
                logs.SaveLog("[error]  (page)::BizSysAuthMemberDB.cs  (Function)::aSysAuthMainDB  (Detail)::" + "\r\n" + ex.ToString(), "Error");
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