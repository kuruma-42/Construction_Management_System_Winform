using EldigmPlusClassLibrary.DbClass.Sys.SysAuth;
using EldigmPlusSvc_Main.Biz.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace EldigmPlusSvc_Main.Biz.Sys.SysAuth
{
    public class BizSysAuthMainDB
    {
        LogClass logs = new LogClass();

        public DataSet sSysAuthMainDB(string pUsingFlag)
        {
            DataSet ds = null;

            DbSysAuthMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbSysAuthMainDB(dbCon_IP, dbCon_DB, dbCon_USER);
                ds = db.sDbSysAuthMainDB(pUsingFlag);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizSysAuthMainDB.cs  (Function)::sDbSysAuthMainDB  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        public int mSysAuthMainDB(string sauthCd_val, string sauthNm_val, string myblockFlag_val, string myconFlag_val, string mycomFlag_val, string myteamFlag_val, string usingFlag_val, string memo_val)
        {
            int reCnt = 0;

            DbSysAuthMainDB db = null;

            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbSysAuthMainDB(dbCon_IP, dbCon_DB, dbCon_USER);
                reCnt = db.mSysAuthMainDB(sauthCd_val, sauthNm_val, myblockFlag_val, myconFlag_val, mycomFlag_val, myteamFlag_val, usingFlag_val, memo_val);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizSysAuthMainDB.cs  (Function)::mSysAuthMainDB  (Detail)::sauthCd_val=[" + sauthCd_val + "], sauthNm_val=[" + sauthNm_val + "], myblockFlag_val=[" + myblockFlag_val + "], myconFlag_val=[" + myconFlag_val + "], mycomFlag_val=[" + mycomFlag_val + "], myteamFlag_val=[" + myteamFlag_val + "], usingFlag_val=[" + usingFlag_val + "], memo_val=[" + memo_val + "]", "Error");
                logs.SaveLog("[error]  (page)::BizSysAuthMainDB.cs  (Function)::mSysAuthMainDB  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int exSysAuthMainDB(string pScodeGrp)
        {
            int reCnt = 0;

            DbSysAuthMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbSysAuthMainDB(dbCon_IP, dbCon_DB, dbCon_USER);
                reCnt = db.exSysAuthMainDB(pScodeGrp);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizSysAuthMainDB.cs  (Function)::exSysAuthMainDB  (Detail)::pScodeGrp=[" + pScodeGrp + "]", "Error");
                logs.SaveLog("[error]  (page)::BizSysAuthMainDB.cs  (Function)::exSysAuthMainDB  (Detail)::" + "\r\n" + ex.ToString(), "Error");
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

            DbSysAuthMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbSysAuthMainDB(dbCon_IP, dbCon_DB, dbCon_USER);
                reCnt = db.aSysAuthMainDB(sauthCd_val, sauthNm_val, myblockFlag_val, myconFlag_val, mycomFlag_val, myteamFlag_val, usingFlag_val, sauthLevel_val, memo_val, pInputId);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizSysAuthMainDB.cs  (Function)::aSysAuthMainDB  (Detail)::sauthCd_val=[" + sauthCd_val + "], sauthNm_val=[" + sauthNm_val + "], myblockFlag_val=[" + myblockFlag_val + "]" +
                    ", myconFlag_val=[" + myconFlag_val + "], mycomFlag_val=[" + mycomFlag_val + "]", "Error");
                logs.SaveLog("[error]  (page)::BizSysAuthMainDB.cs  (Function)::aSysAuthMainDB  (Detail)::" + "\r\n" + ex.ToString(), "Error");
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