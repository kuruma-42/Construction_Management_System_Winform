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





        //BLOCK CMB BOX 
        public DataSet sLaborBlockList(string pSiteCd, string pAuthCd, string pCcode)
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
                string pMyBlockFlag = "";
                pMyBlockFlag = db.sMyBlockFlag(pSiteCd, pAuthCd);

                ds = db.sLaborBlockList(pSiteCd, Convert.ToInt16(pMyBlockFlag), Convert.ToInt16(pCcode));
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::sLaborBlockList  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }



        //CONST CMB BOX 
        public DataSet sLaborConstList(string pSiteCd, string pAuthCd, string pCcode)
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
                string pMyConFlag = "";
                pMyConFlag = db.sMyConFlag(pSiteCd, pAuthCd);

                ds = db.sLaborConstList(pSiteCd, Convert.ToInt16(pMyConFlag), Convert.ToInt16(pCcode));
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::sLaborConstList  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        //JOB CMB BOX 
        public DataSet sLaborJobList(string pSiteCd)
        {
            DataSet ds = null;

            DbLaborSearch db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbLaborSearch(dbCon_IP, dbCon_DB, dbCon_USER, "0");              

                ds = db.sLaborJobList(pSiteCd);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::sLaborJobList  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        //COMPANY CMB BOX 
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



        //TEAM CMB BOX 
        public DataSet sLaborTeamList(string pSiteCd, string pAuthCd, string pTeamCd, string pCoCd)
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
                string pMyTeamFlag = "";
                pMyTeamFlag = db.sMyTeamFlag(pSiteCd, pAuthCd);

                ds = db.sLaborTeamList(pSiteCd, Convert.ToInt16(pMyTeamFlag), Convert.ToInt16(pTeamCd), pCoCd);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::sLaborTeamList  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }



        //SELECT 
        public DataSet sLaborSearch(string pSiteCd, string pBlockCcd , string pConstCcd, string pCoCd, string pTeamCd, string pSearchCondition, string pSearchTxt)
        {
            DataSet ds = null;

            DbLaborSearch db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbLaborSearch(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                ds = db.sLaborSearch(pSiteCd, pBlockCcd, pConstCcd, pCoCd, pTeamCd, pSearchCondition, pSearchTxt);
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
    }
}