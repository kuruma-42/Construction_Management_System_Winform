using EldigmPlusClassLibrary.DbClass.Sys.MemberSite;
using EldigmPlusClassLibrary.DbClass.Sys.SysAuth;
using EldigmPlusSvc_Main.Biz.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace EldigmPlusSvc_Main.Biz.Sys.MemberSite
{
    public class BizSite
    {
        LogClass logs = new LogClass();
        //public string sDbNm(string pMemcoCd)
        //{
        //    string reVal = "";

        //    DbSysAuthMemberDB db = null;
        //    try
        //    {
        //        string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
        //        string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
        //        string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

        //        db = new DbSysAuthMemberDB(dbCon_IP, dbCon_DB, dbCon_USER);
        //        reVal = db.sDbNm(pMemcoCd);
        //    }
        //    catch (Exception ex)
        //    {
        //        logs.SaveLog("[error]  (page)::BizSysAuthMemberDB.cs  (Function)::sDbNm  (Detail)::pMemcoCd=[" + pMemcoCd + "]", "Error");
        //        logs.SaveLog("[error]  (page)::BizSysAuthMemberDB.cs  (Function)::sDbNm  (Detail)::" + "\r\n" + ex.ToString(), "Error");
        //    }
        //    finally
        //    {
        //        if (db != null)
        //            db.DisConnect();
        //    }

        //    return reVal;
        //}

        public DataSet sMemberMainDB()
        {
            DataSet ds = null;

            DbSite db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbSite(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                ds = db.sMemberMainDB();
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizSite.cs  (Function)::sMemberMainDB  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }


        public DataSet sSite(string pMemcoCd, string pUsingFlag)
        {
            DataSet ds = null;

            DbSite db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbSite(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                ds = db.sSite(pMemcoCd, pUsingFlag);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizSite.cs  (Function)::sSite  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }
        

          


        public int mSite(string siteCd_val, string siteNm_val, string usingFlag_val, string sortNo_val, string memo_val)
        {
            int reCnt = 0;

            DbSite db = null;

            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbSite(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                reCnt = db.mSite(siteCd_val, siteNm_val, usingFlag_val, sortNo_val, memo_val);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizSite.cs  (Function)::mSite  (Detail)::siteCd_val=[" + siteCd_val + "], siteNm_val=[" + siteNm_val + "]" +
                    ", usingFlag_val=[" + usingFlag_val + "], sortNo_val=[" + sortNo_val + "], memo_val=[" + memo_val + "]", "Error");
                logs.SaveLog("[error]  (page)::BizSite.cs  (Function)::mSite  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        //DUPLICATE CHECK 
        public int exSite(string pSiteNm)
        {
            int reCnt = 0;

            DbSite db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbSite(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                reCnt = db.exSite(pSiteNm);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizSite.cs  (Function)::exSite  (Detail)::pSiteNm=[" + pSiteNm + "]", "Error");
                logs.SaveLog("[error]  (page)::BizSite.cs  (Function)::exSite  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public string aSite(string pDbNm, Hashtable param, out Hashtable outVal)
        {
            string reVal = "";

            DbSite db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = "Initial Catalog=PLUS-" + pDbNm + ";";
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbSite(dbCon_IP, dbCon_DB, dbCon_USER, "1");
                reVal = db.aSite(param, out outVal);
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

        ////INSERT 
        //public int aSite(string memcoCd_val, string siteNm_val, string usingFlag_val, string sortNo_val, string memo_val, string pInputId)
        //{
        //    int reCnt = 0;

        //    DbSite db = null;
        //    try
        //    {
        //        string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
        //        string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
        //        string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

        //        db = new DbSite(dbCon_IP, dbCon_DB, dbCon_USER);
        //        reCnt = db.aSite(memcoCd_val, siteNm_val, usingFlag_val, sortNo_val, memo_val, pInputId);
        //    }
        //    catch (Exception ex)
        //    {
        //        logs.SaveLog("[error]  (page)::BizSite.cs  (Function)::aSite  (Detail)::memcoCd_val=[" + memcoCd_val + "], siteNm_val=[" + siteNm_val + "], usingFlag_val=[" + usingFlag_val + "]" +
        //            ", sortNo_val=[" + sortNo_val + "], pInputId=[" + pInputId + "]", "Error");
        //        logs.SaveLog("[error]  (page)::BizSite.cs  (Function)::aSite  (Detail)::" + "\r\n" + ex.ToString(), "Error");
        //    }
        //    finally
        //    {
        //        if (db != null)
        //            db.DisConnect();
        //    }

        //    return reCnt;
        //}

        ////INSERT 
        //public int aSite_Member(string siteCd_val, string memcoCd_val, string siteNm_val, string headcoCd_val)
        //{
        //    int reCnt = 0;

        //    DbSite db = null;
        //    try
        //    {
        //        string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
        //        string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
        //        string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

        //        db = new DbSite(dbCon_IP, dbCon_DB, dbCon_USER);
        //        reCnt = db.aSite_Member(siteCd_val, memcoCd_val, siteNm_val, headcoCd_val);
        //    }
        //    catch (Exception ex)
        //    {
        //        logs.SaveLog("[error]  (page)::BizSite.cs  (Function)::aSite_Member  (Detail)::siteCd_val=[" + siteCd_val + "], memcoCd_val=[" + memcoCd_val + "], siteNm_val=[" + siteNm_val + "]" +
        //            ", headcoCd_val=[" + headcoCd_val + "]", "Error");
        //        logs.SaveLog("[error]  (page)::BizSite.cs  (Function)::aSite_Member  (Detail)::" + "\r\n" + ex.ToString(), "Error");
        //    }
        //    finally
        //    {
        //        if (db != null)
        //            db.DisConnect();
        //    }

        //    return reCnt;
        //}

        //public int aSiteInfo_Member(string siteCd_val, string memcoCd_val)
        //{
        //    int reCnt = 0;

        //    DbSite db = null;
        //    try
        //    {
        //        string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
        //        string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
        //        string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

        //        db = new DbSite(dbCon_IP, dbCon_DB, dbCon_USER);
        //        reCnt = db.aSiteInfo_Member(siteCd_val, memcoCd_val);
        //    }
        //    catch (Exception ex)
        //    {
        //        logs.SaveLog("[error]  (page)::BizSite.cs  (Function)::aSiteInfo_Member  (Detail)::siteCd_val=[" + siteCd_val + "], memcoCd_val=[" + memcoCd_val + "]", "Error");
        //        logs.SaveLog("[error]  (page)::BizSite.cs  (Function)::aSiteInfo_Member  (Detail)::" + "\r\n" + ex.ToString(), "Error");
        //    }
        //    finally
        //    {
        //        if (db != null)
        //            db.DisConnect();
        //    }

        //    return reCnt;
        //}
    }
}