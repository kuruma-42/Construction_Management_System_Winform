using EldigmPlusClassLibrary.DbClass.MainHome;
using EldigmPlusSvc_Memco.Biz.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace EldigmPlusSvc_Memco.Biz.MainHome
{
    public class BizMainHome
    {
        LogClass _logs = new LogClass();

        public string sDbNm(string pMemcoCd)
        {
            string reVal = "";

            DbMainHome db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbMainHome(dbCon_IP, dbCon_DB, dbCon_USER);
                reVal = db.sDbNm(pMemcoCd);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizMainHome.cs  (Function)::sDbNm  (Detail)::pMemcoCd=[" + pMemcoCd + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizMainHome.cs  (Function)::sDbNm  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reVal;
        }

        public DataSet sSiteMenu(string pDbNm, string pSiteCd)
        {
            DataSet ds = null;

            DbMainHome db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbMainHome(dbCon_IP, dbCon_DB, dbCon_USER);
                ds = db.sSiteMenu(pDbNm, pSiteCd);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizMainHome.cs  (Function)::sSiteMenu  (Detail)::pDbNm=[" + pDbNm + "], pSiteCd=[" + pSiteCd + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizMainHome.cs  (Function)::sSiteMenu  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        public DataSet sSiteSubMenu1(string pDbNm, string pSiteCd, string pTopMenuCd)
        {
            DataSet ds = null;

            DbMainHome db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbMainHome(dbCon_IP, dbCon_DB, dbCon_USER);
                ds = db.sSiteSubMenu1(pDbNm, pSiteCd, pTopMenuCd);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizMainHome.cs  (Function)::sSiteSubMenu1  (Detail)::pDbNm=[" + pDbNm + "], pSiteCd=[" + pSiteCd + "], pTopMenuCd=[" + pTopMenuCd + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizMainHome.cs  (Function)::sSiteSubMenu1  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        public DataSet sSiteSubMenu2(string pDbNm, string pSiteCd, string pTopMenuCd, string pSubMenuCd, string pAuthCd)
        {
            DataSet ds = null;

            DbMainHome db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbMainHome(dbCon_IP, dbCon_DB, dbCon_USER);
                ds = db.sSiteSubMenu2(pDbNm, pSiteCd, pTopMenuCd, pSubMenuCd, pAuthCd);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizMainHome.cs  (Function)::sSiteSubMenu2  (Detail)::pDbNm=[" + pDbNm + "], pSiteCd=[" + pSiteCd + "], pTopMenuCd=[" + pTopMenuCd + "]" +
                    ", pSubMenuCd=[" + pSubMenuCd + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizMainHome.cs  (Function)::sSiteSubMenu2  (Detail)::" + "\r\n" + ex.ToString(), "Error");
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