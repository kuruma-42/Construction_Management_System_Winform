using EldigmPlusClassLibrary.DbClass.Sys.SysCode;
using EldigmPlusSvc_Main.Biz.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace EldigmPlusSvc_Main.Biz.Sys.SysCode
{
    public class BizSysCodeGrp
    {
        LogClass _logs = new LogClass();

        public DataSet sSysCodeGrp(string pScodeGrp)
        {
            DataSet ds = null;

            DbSysCodeGrp db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbSysCodeGrp(dbCon_IP, dbCon_DB, dbCon_USER);
                ds = db.sSysCodeGrp(pScodeGrp);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizSysCodeGrp.cs  (Function)::sSysCodeGrp  (Detail)::pScodeGrp=[" + pScodeGrp + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizSysCodeGrp.cs  (Function)::sSysCodeGrp  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        public int mSysCodeGrp(string pScodeGrp, string pScodeNm, string pUsingFlag, string pSortNo, string pMemo)
        {
            int reCnt = 0;

            DbSysCodeGrp db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbSysCodeGrp(dbCon_IP, dbCon_DB, dbCon_USER);
                reCnt = db.mSysCodeGrp(pScodeGrp, pScodeNm, pUsingFlag, pSortNo, pMemo);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizSysCodeGrp.cs  (Function)::mSysCodeGrp  (Detail)::pScodeGrp=[" + pScodeGrp + "], pScodeNm=[" + pScodeNm + "], pUsingFlag=[" + pUsingFlag + "]" +
                    ", pSortNo=[" + pSortNo + "], pMemo=[" + pMemo + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizSysCodeGrp.cs  (Function)::mSysCodeGrp  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int exSysCodeGrp(string sauthCd_val)
        {
            int reCnt = 0;

            DbSysCodeGrp db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbSysCodeGrp(dbCon_IP, dbCon_DB, dbCon_USER);
                reCnt = db.exSysCodeGrp(sauthCd_val);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizSysCodeGrp.cs  (Function)::exSysCodeGrp  (Detail)::pScodeGrp=[" + sauthCd_val + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizSysCodeGrp.cs  (Function)::exSysCodeGrp  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int aSysCodeGrp(string pScodeGrp, string pScodeGrpNm, string pUsingFlag, string pSortNo, string pMemo, string pInputId)
        {
            int reCnt = 0;

            DbSysCodeGrp db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbSysCodeGrp(dbCon_IP, dbCon_DB, dbCon_USER);
                reCnt = db.aSysCodeGrp(pScodeGrp, pScodeGrpNm, pUsingFlag, pSortNo, pMemo, pInputId);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizSysCodeGrp.cs  (Function)::aSysCodeGrp  (Detail)::, pScodeGrp=[" + pScodeGrp + "], Grp=[" + pScodeGrpNm + "], pUsingFlag=[" + pUsingFlag + "]" +
                    ", pSortNo=[" + pSortNo + "], pMemo=[" + pMemo + "], pInputId=[" + pInputId + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizSysCodeGrp.cs  (Function)::aSysCodeGrp  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }






        public DataSet sSysCodeGrp_UsingFlag(string pUsingFlag)
        {
            DataSet ds = null;

            DbSysCodeGrp db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbSysCodeGrp(dbCon_IP, dbCon_DB, dbCon_USER);
                ds = db.sSysCodeGrp_UsingFlag(pUsingFlag);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizSysCodeGrp.cs  (Function)::sSysCodeGrp_UsingFlag  (Detail)::pUsingFlag=[" + pUsingFlag + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizSysCodeGrp.cs  (Function)::sSysCodeGrp_UsingFlag  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        public DataSet sSysCode(string pScodeGrp, string pUsingFlag, string pScodeNm)
        {
            DataSet ds = null;

            DbSysCodeGrp db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbSysCodeGrp(dbCon_IP, dbCon_DB, dbCon_USER);
                ds = db.sSysCode(pScodeGrp, pUsingFlag, pScodeNm);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizSysCodeGrp.cs  (Function)::sSysCode  (Detail)::pScodeGrp=[" + pScodeGrp + "], pUsingFlag=[" + pUsingFlag + "], pScodeNm=[" + pScodeNm + "]"
                    , "Error");
                _logs.SaveLog("[error]  (page)::BizSysCodeGrp.cs  (Function)::sSysCode  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        public int mSysCode(string pScode, string pScodeNm, string pUsingFlag, string pSortNo, string pMemo)
        {
            int reCnt = 0;

            DbSysCodeGrp db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbSysCodeGrp(dbCon_IP, dbCon_DB, dbCon_USER);
                reCnt = db.mSysCode(pScode, pScodeNm, pUsingFlag, pSortNo, pMemo);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizSysCodeGrp.cs  (Function)::mSysCode  (Detail)::pScode=[" + pScode + "], pScodeNm=[" + pScodeNm + "], pUsingFlag=[" + pUsingFlag + "]" +
                    ", pSortNo=[" + pSortNo + "], pMemo=[" + pMemo + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizSysCodeGrp.cs  (Function)::mSysCode  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int exSysCode(string pScode)
        {
            int reCnt = 0;

            DbSysCodeGrp db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbSysCodeGrp(dbCon_IP, dbCon_DB, dbCon_USER);
                reCnt = db.exSysCode(pScode);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizSysCodeGrp.cs  (Function)::exSysCode  (Detail)::pScode=[" + pScode + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizSysCodeGrp.cs  (Function)::exSysCode  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int aSysCode(string pScode, string pScodeGrp, string pScodeNm, string pUsingFlag, string pMemo, string pSortNo, string pInputId)
        {
            int reCnt = 0;

            DbSysCodeGrp db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbSysCodeGrp(dbCon_IP, dbCon_DB, dbCon_USER);
                reCnt = db.aSysCode(pScode, pScodeGrp, pScodeNm, pUsingFlag, pMemo, pSortNo, pInputId);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizSysCodeGrp.cs  (Function)::aSysCode  (Detail)::pScode=[" + pScode + "], pScodeGrp=[" + pScodeGrp + "], pScodeNm=[" + pScodeNm + "]" +
                    ", pUsingFlag=[" + pUsingFlag + "], pMemo=[" + pMemo + "], pSortNo=[" + pSortNo + "], pInputId=[" + pInputId + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizSysCodeGrp.cs  (Function)::aSysCode  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int aSysCodeLog(string pScode, string pScodeNm, string pUsingFlag, string pSortNo, string pMemo, string pInputId)
        {
            int reCnt = 0;

            DbSysCodeGrp db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbSysCodeGrp(dbCon_IP, dbCon_DB, dbCon_USER);
                reCnt = db.aSysCodeLog(pScode, pScodeNm, pUsingFlag, pSortNo, pMemo, pInputId);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizSysCodeGrp.cs  (Function)::aSysCodeLog  (Detail)::pScode=[" + pScode + "], pScodeNm=[" + pScodeNm + "], pUsingFlag=[" + pUsingFlag + "]" +
                    ", pSortNo=[" + pSortNo + "], pMemo=[" + pMemo + "], pInputId=[" + pInputId + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizSysCodeGrp.cs  (Function)::aSysCodeLog  (Detail)::" + "\r\n" + ex.ToString(), "Error");
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