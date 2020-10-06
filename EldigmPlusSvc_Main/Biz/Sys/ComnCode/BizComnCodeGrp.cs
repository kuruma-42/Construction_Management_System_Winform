using EldigmPlusClassLibrary.DbClass.Sys.CommonCode;
using EldigmPlusSvc_Main.Biz.Common;
using System;
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

                db = new DbComnCodeGrpMainDB(dbCon_IP, dbCon_DB, dbCon_USER);
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

        public int aComnCodeGrp(string pCcodeGrp, string pCcodeGrpNm, string pUsingFlag, string pSortNo, string pMemo, string pInputId)
        {
            int reCnt = 0;

            DbComnCodeGrpMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbComnCodeGrpMainDB(dbCon_IP, dbCon_DB, dbCon_USER);
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

                db = new DbComnCodeGrpMainDB(dbCon_IP, dbCon_DB, dbCon_USER);
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

                db = new DbComnCodeGrpMainDB(dbCon_IP, dbCon_DB, dbCon_USER);
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

    }
}