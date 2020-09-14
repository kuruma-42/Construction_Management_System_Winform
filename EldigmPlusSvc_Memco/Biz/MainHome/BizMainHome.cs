using EldigmPlusClassLibrary.DbClass.MainHome;
using EldigmPlusSvc_Memco.Biz.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EldigmPlusSvc_Memco.Biz.MainHome
{
    public class BizMainHome
    {
        LogClass logs = new LogClass();

        public string sDbNm(string pMemcoCd)
        {
            string reVal = "";

            DbMainHome db = null;
            try
            {
                db = new DbMainHome();
                reVal = db.sDbNm(pMemcoCd);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizSystem.cs  (Function)::sSiteMenu  (Detail)::pMemcoCd=[" + pMemcoCd + "]", "Error");
                logs.SaveLog("[error]  (page)::BizSystem.cs  (Function)::sSiteMenu  (Detail)::" + "\r\n" + ex.ToString(), "Error");
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
                db = new DbMainHome();
                ds = db.sSiteMenu(pDbNm, pSiteCd);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizSystem.cs  (Function)::sSiteMenu  (Detail)::pDbNm=[" + pDbNm + "], pSiteCd=[" + pSiteCd + "]", "Error");
                logs.SaveLog("[error]  (page)::BizSystem.cs  (Function)::sSiteMenu  (Detail)::" + "\r\n" + ex.ToString(), "Error");
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
                db = new DbMainHome();
                ds = db.sSiteSubMenu1(pDbNm, pSiteCd, pTopMenuCd);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizSystem.cs  (Function)::sSiteSubMenu1  (Detail)::pDbNm=[" + pDbNm + "], pSiteCd=[" + pSiteCd + "], pTopMenuCd=[" + pTopMenuCd + "]", "Error");
                logs.SaveLog("[error]  (page)::BizSystem.cs  (Function)::sSiteSubMenu1  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        public DataSet sSiteSubMenu2(string pDbNm, string pSiteCd, string pTopMenuCd, string pSubMenuCd)
        {
            DataSet ds = null;

            DbMainHome db = null;
            try
            {
                db = new DbMainHome();
                ds = db.sSiteSubMenu2(pDbNm, pSiteCd, pTopMenuCd, pSubMenuCd);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizSystem.cs  (Function)::sSiteSubMenu2  (Detail)::pDbNm=[" + pDbNm + "], pSiteCd=[" + pSiteCd + "], pTopMenuCd=[" + pTopMenuCd + "]" +
                    ", pSubMenuCd=[" + pSubMenuCd + "]", "Error");
                logs.SaveLog("[error]  (page)::BizSystem.cs  (Function)::sSiteSubMenu2  (Detail)::" + "\r\n" + ex.ToString(), "Error");
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