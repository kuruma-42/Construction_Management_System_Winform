using EldigmPlusClassLibrary.DbClass.Sys.Device;
using EldigmPlusClassLibrary.DbClass.Worker.LaborSearch;
using EldigmPlusSvc_Memco.Biz.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace EldigmPlusSvc_Memco.Biz.Worker
{
    public class BizLaborSearch
    {
        LogClass logs = new LogClass();


        //CONST CMB BOX WITHOUT NOSELECT
        public DataSet sLaborCompanyList(string pSiteCd, string pAuthCd, string pCoCd)
        {
            DataSet ds = null;

            DbLaborSearch db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbLaborSearch(dbCon_IP, dbCon_DB, dbCon_USER, "0");

                //MYCOM_FLAG 값을 구해옴 
                string pMyComFlag = "";
                pMyComFlag = db.sMyComFlag(pSiteCd, pAuthCd);
                
                ds = db.sLaborCompanyList(pSiteCd, Convert.ToInt16(pMyComFlag), Convert.ToInt16(pCoCd));
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::sLaborCompanyList  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }





        //SELECT 
        public DataSet sLaborSearch(string pSiteCd, string pCoCd)
        {
            DataSet ds = null;

            DbLaborSearch db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbLaborSearch(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                ds = db.sLaborSearch(pSiteCd, pCoCd);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::sLaborSearch  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }




















        //CO_TYPE CMB BOX WITHOUT NO SELECT
        public DataSet devIOCmb()
        {
            DataSet ds = null;

            DbDevice db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbDevice(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                ds = db.devIOCmb();
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizDevice.cs  (Function)::devIOCmb  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }
                      






        //SELECT 
        public DataSet sDevice(string pDbNm, string pSiteCd)
        {
            DataSet ds = null;

            DbDevice db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbDevice(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                ds = db.sDevice(pDbNm, pSiteCd);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizDevice.cs  (Function)::sDevice  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }


        //MODIFY
        public int mDevice(string pDbNm, string pSiteCd, string pDevCd, string pDeviceId, string pDevTypeScd, string pDevIOScd, string pDevNm, string pIp, string pSortNo, string pUsingFalg, string pMemo)
        {
            int reCnt = 0;

            DbDevice db = null;

            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbDevice(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                reCnt = db.mDevice(pDbNm, pSiteCd, pDevCd, pDeviceId, pDevTypeScd, pDevIOScd, pDevNm, pIp, pSortNo, pUsingFalg, pMemo);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizDevice.cs  (Function)::mDevice  (Detail)::pDbNm=[" + pDbNm + "], pSiteCd=[" + pSiteCd + "]," +
                    " pDevCd=[" + pDevCd + "], pDeviceId=[" + pDeviceId + "], pDevTypeScd=[" + pDevTypeScd + "]," +
                    " pDevIOScd=[" + pDevIOScd + "], pDevNm=[" + pDevNm + "], pIp=[" + pIp + "]," +
                    " pSortNo=[" + pSortNo + "], pUsingFalg=[" + pUsingFalg + "], pMemo=[" + pMemo + "] ", "Error");
                logs.SaveLog("[error]  (page)::BizDevice.cs  (Function)::mDevice  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }


        //INSERT TEAM WITH PROCEDURE
        public string aDevicePro(string pDbNm, Hashtable param, out Hashtable outVal)
        {
            string reVal = "";

            DbDevice db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = "Initial Catalog=PLUS-" + pDbNm + ";";
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbDevice(dbCon_IP, dbCon_DB, dbCon_USER, "1");
                reVal = db.aDevicePro(param, out outVal);
            }
            catch (Exception ex)
            {
                outVal = null;
                logs.SaveLog("[error]  (page)::BizDevice.cs  (Function)::aDevicePro  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reVal;
        }




        //LOG
        public int logDevice(string pDbNm, string pDevCd, string pSiteCd, string pDeviceId, string pDevTypeScd, string pDevIOScd, string pDevNm, string pIp, string pUsingFalg, string pSortNo, string pMemo, string pInputId)
        {
            int reCnt = 0;

            DbDevice db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbDevice(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                reCnt = db.logDevice(pDbNm, pDevCd, pSiteCd, pDeviceId, pDevTypeScd, pDevIOScd, pDevNm, pIp, pUsingFalg, pSortNo, pMemo, pInputId);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizDevice.cs  (Function)::logDevice  (Detail)::pDbNm=[" + pDbNm + "], pDevCd=[" + pDevCd + "], pSiteCd=[" + pSiteCd + "]" +
                    ", pDeviceId=[" + pDeviceId + "], pDevTypeScd=[" + pDevTypeScd + "], pDevIOScd=[" + pDevIOScd + "], pDevNm=[" + pDevNm + "], " +
                    "pIp=[" + pIp + "], pUsingFalg=[" + pUsingFalg + "], pSortNo=[" + pSortNo + "], pMemo=[" + pMemo + "], pInputId=[" + pInputId + "]", "Error");
                logs.SaveLog("[error]  (page)::BizDevice.cs  (Function)::logDevice  (Detail)::" + "\r\n" + ex.ToString(), "Error");
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