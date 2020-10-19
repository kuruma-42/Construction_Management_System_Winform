using EldigmPlusSvc_Main.Biz.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using EldigmPlusClassLibrary.DbClass.Worker.InOut;

namespace EldigmPlusSvc_Main.Biz.Worker.InOut
{
    public class BizInOut
    {
        LogClass logs = new LogClass();

        public DataSet sInOut(string pDbnm, string pSiteCd, string pDtp1, string pDtp2)
        {
            DataSet ds = null;

            DbInOut db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbInOut(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                ds = db.sInOut(pDbnm, pSiteCd, pDtp1, pDtp2);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizInOut.cs  (Function)::sInOut  (Detail)::pDbnm=[" + pDbnm + "]", "Error");
                logs.SaveLog("[error]  (page)::BizInOut.cs  (Function)::sInOut  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        public DataSet sInOutLog(string pDbnm, string pSiteCd, string pDtp1, string pDtp2)
        {
            DataSet ds = null;

            DbInOut db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbInOut(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                ds = db.sInOutLog(pDbnm, pSiteCd, pDtp1, pDtp2);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizInOut.cs  (Function)::sInOutLog  (Detail)::pDbnm=[" + pDbnm +"]", "Error");
                logs.SaveLog("[error]  (page)::BizInOut.cs  (Function)::sInOutLog  (Detail)::" + "\r\n" + ex.ToString(), "Error");
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