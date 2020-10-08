using EldigmPlusClassLibrary.DbClass.Sys.CodeT;
using EldigmPlusSvc_Main.Biz.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace EldigmPlusSvc_Main.Biz.Sys.CodeT
{
    public class BizCodeT
    {
        LogClass _logs = new LogClass();
       
        public DataSet sSysCode()
        {
            DataSet ds = null;

            DbCodeT db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbCodeT(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                ds = db.sSysCode();
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizSysCodeGrp.cs  (Function)::sSysCode  (Detail)::pScodeGrp=]"
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

        public DataSet sCodeTTreeView(string pScode)
        {
            DataSet ds = null;

            DbCodeT db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbCodeT(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                ds = db.sCodeTTreeView(pScode);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizSysCodeGrp.cs  (Function)::sSysCode  (Detail)::pScodeGrp=]"
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

        public DataSet sCodeT(string pScode)
        {
            DataSet ds = null;

            DbCodeT db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbCodeT(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                ds = db.sCodeT(pScode);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizSysCodeGrp.cs  (Function)::sSysCode  (Detail)::pScodeGrp=]"
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

        public DataSet sCodeTSubTreeView(string pTcode)
        {
            DataSet ds = null;

            DbCodeT db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbCodeT(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                ds = db.sCodeTSubTreeView(pTcode);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizSysCodeGrp.cs  (Function)::sSysCode  (Detail)::pScodeGrp=]"
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

        public DataSet sCodeTSub(string pTcode)
        {
            DataSet ds = null;

            DbCodeT db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbCodeT(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                ds = db.sCodeTSub(pTcode);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizSysCodeGrp.cs  (Function)::sSysCode  (Detail)::pScodeGrp=]"
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



    }
}