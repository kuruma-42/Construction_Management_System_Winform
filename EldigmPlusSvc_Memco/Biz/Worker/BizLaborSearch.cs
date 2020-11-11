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




        //** LABOR SEARCH PART START **
        //BLOCK CMB BOX 
        public DataSet sLaborBlockList(string pSiteCd, string pAuthCd, string pCcode, string pLngBlock)
        {
            DataSet ds = null;

            DbLaborSearch db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbLaborSearch(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                           
                DataSet ds1 = db.sMyFlags(pSiteCd, pAuthCd);
                string pMyBlockFlag = ds1.Tables[0].Rows[0]["MYBLOCK_FLAG"].ToString();

                ds = db.sLaborBlockList(pSiteCd, Convert.ToInt16(pMyBlockFlag), Convert.ToInt16(pCcode), pLngBlock);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::sLaborBlockList  (Detail):: " +
                  " pSiteCd=['" + pSiteCd + "'], pAuthCd=[" + pAuthCd + "], pCcode=[" + pCcode + "],pLngBlock=[" + pLngBlock + "]", "Error");
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
        public DataSet sLaborConstList(string pSiteCd, string pAuthCd, string pCcode, string pLngConst)
        {
            DataSet ds = null;

            DbLaborSearch db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbLaborSearch(dbCon_IP, dbCon_DB, dbCon_USER, "0");

                DataSet ds1 = db.sMyFlags(pSiteCd, pAuthCd);
                string pMyConFlag = ds1.Tables[0].Rows[0]["MYCON_FLAG"].ToString();

                ds = db.sLaborConstList(pSiteCd, Convert.ToInt16(pMyConFlag), Convert.ToInt16(pCcode), pLngConst);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::sLaborConstList  (Detail):: " +
                  " pSiteCd=['" + pSiteCd + "'], pAuthCd=[" + pAuthCd + "], pCcode=[" + pCcode + "],pLngBlock=[" + pLngConst + "]", "Error");
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
        public DataSet sLaborJobList(string pSiteCd, string pLngJob)
        {
            DataSet ds = null;

            DbLaborSearch db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbLaborSearch(dbCon_IP, dbCon_DB, dbCon_USER, "0");              

                ds = db.sLaborJobList(pSiteCd, pLngJob);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::sLaborJobList  (Detail):: " +
                  " pSiteCd=['" + pSiteCd + "'], pLngJob=[" + pLngJob + "]", "Error");
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
        public DataSet sLaborCompanyList(string pSiteCd, string pAuthCd, string pCoCd, string pLngCom)
        {
            DataSet ds = null;

            DbLaborSearch db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbLaborSearch(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                 
                DataSet ds1 = db.sMyFlags(pSiteCd, pAuthCd);
                string pMyComFlag = ds1.Tables[0].Rows[0]["MYCOM_FLAG"].ToString();

                ds = db.sLaborCompanyList(pSiteCd, Convert.ToInt16(pMyComFlag), Convert.ToInt16(pCoCd), pLngCom);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::sLaborCompanyList  (Detail):: " +
                " pSiteCd=['" + pSiteCd + "'], pAuthCd=[" + pAuthCd + "], pCoCd=[" + pCoCd + "],pLngCom=[" + pLngCom + "]", "Error");
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
        public DataSet sLaborTeamList(string pSiteCd, string pAuthCd, string pTeamCd, string pCoCd, string pLngTeam)
        {
            DataSet ds = null;

            DbLaborSearch db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbLaborSearch(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                               
                DataSet ds1 = db.sMyFlags(pSiteCd, pAuthCd);
                string pMyTeamFlag = ds1.Tables[0].Rows[0]["MYTEAM_FLAG"].ToString();

                ds = db.sLaborTeamList(pSiteCd, Convert.ToInt16(pMyTeamFlag), Convert.ToInt16(pTeamCd), pCoCd, pLngTeam);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::sLaborTeamList  (Detail):: " +
                " pSiteCd=['" + pSiteCd + "'], pAuthCd=[" + pAuthCd + "], pTeamCd=[" + pTeamCd + "], pCoCd=[" + pCoCd + "], pLngTeam=[" + pLngTeam + "]", "Error");
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::sLaborTeamList  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        //LAB INFO TYPE CMB BOX 
        public DataSet sLabInfoTypeList(string pSiteCd, string pLngCategory)
        {
            DataSet ds = null;

            DbLaborSearch db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbLaborSearch(dbCon_IP, dbCon_DB, dbCon_USER, "0");

                ds = db.sLabInfoTypeList(pSiteCd, pLngCategory);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::sLabInfoTypeList  (Detail):: " +
                " pSiteCd=['" + pSiteCd + "'], pLngCategory=[" + pLngCategory + "]", "Error");
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::sLabInfoTypeList  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        //LAB INFO TYPE CMB BOX 
        public DataSet sLabTcodeList(string pSiteCd, string pTgrpCcd, string pTtypeScd, string pLngCategory, string pAuthCd)
        {
            DataSet ds = null;

            DbLaborSearch db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbLaborSearch(dbCon_IP, dbCon_DB, dbCon_USER, "0");

                ds = db.sLabTcodeList(pSiteCd, pTgrpCcd, pTtypeScd, pLngCategory, pAuthCd);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::sLabTcodeList  (Detail):: " +
                " pSiteCd=['" + pSiteCd + "'], pTgrpCcd=['" + pTgrpCcd + "'], pTtypeScd=['" + pTtypeScd + "'], pLngCategory=['" + pLngCategory + "'], pAuthCd=[" + pAuthCd + "]", "Error");
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::sLabTcodeList  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        //CCODE COMBO BOX (USING THIS CMB CCODE AS TGRP_CCD **INCLUDE CATEGORY FOR VALUE 0**)
        public DataSet sLaborAddInfoCcode2(string pSiteCd, string pAuth, string pLangCategory)
        {
            DataSet ds = null;

            DbLaborSearch db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbLaborSearch(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                ds = db.sLaborAddInfoCcode2(pSiteCd, pAuth, pLangCategory);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::sLaborAddInfoCcode2  (Detail):: " +
                    " pSiteCd=['" + pSiteCd + "'], pAuth=[" + pAuth + "], pLangCategory=[" + pLangCategory + "]", "Error");
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::sLaborAddInfoCcode2  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }



        //SELECT 
        public DataSet sLaborSearch(string pSiteCd, string pBlockCcd , string pConstCcd, string pCoCd, string pTeamCd, string pSearchCondition, string pSearchTxt, string pTtypeScd, string pTcode, string pValue)
        {
            DataSet ds = null;

            DbLaborSearch db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbLaborSearch(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                ds = db.sLaborSearch(pSiteCd, pBlockCcd, pConstCcd, pCoCd, pTeamCd, pSearchCondition, pSearchTxt, pTtypeScd, pTcode, pValue);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::sLaborSearch  (Detail):: " +
                " pSiteCd=['" + pSiteCd + "'], pBlockCcd=[" + pBlockCcd + "], pConstCcd=[" + pConstCcd + "], pCoCd=[" + pCoCd + "],pTeamCd=[" + pTeamCd + "],pSearchCondition=[" + pSearchCondition + "]," +
                "pSearchTxt=[" + pSearchTxt + "],pTtypeScd=[" + pTtypeScd + "],pTcode=[" + pTcode + "], pValue=[" + pValue + "]", "Error");
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::sLaborSearch  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        //** LABOR SEARCH PART END **











        //** LABOR SEARCH POP UP PART START **

        //TEAM CMB BOX 
        public string sLabAprvFlag(string pSiteCd, string pAuthCd)
        {
            string reVal = "";
            DataSet ds = null;

            DbLaborSearch db = null;
            try
            {

                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbLaborSearch(dbCon_IP, dbCon_DB, dbCon_USER, "0");

                reVal = db.sLabAprvFlag(pSiteCd, pAuthCd);

            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::sLabAprvFlag  (Detail):: " +
                " pSiteCd=['" + pSiteCd + "'], pAuthCd=[" + pAuthCd + "]", "Error");
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::sLabAprvFlag  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reVal;
        }




        //SELECT THE LOWEST AUTH_CD AT SITE 
        public string sLabAuth(string pSiteCd)
        {
            string reVal = "";

            DbLaborSearch db = null;
            try
            {

                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbLaborSearch(dbCon_IP, dbCon_DB, dbCon_USER, "0");

                reVal = db.sLabAuth(pSiteCd);

            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::sLabAuth  (Detail):: " +
               " pSiteCd=['" + pSiteCd + "']", "Error");
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::sLabAuth  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reVal;
        }




        //DUPLICATE CHECK MEMBER AND RETURN LAB_NO 
        public string exLabMember(string pSiteCd, string pLabNm, string pMobileNo, string pBirthDate)
        {
            string reVal = "";

            DbLaborSearch db = null;
            try
            {

                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbLaborSearch(dbCon_IP, dbCon_DB, dbCon_USER, "0");

                reVal = db.exLabMember(pSiteCd, pLabNm, pMobileNo, pBirthDate);

            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::sLaborCompanyList  (Detail):: " +
              " pSiteCd=['" + pSiteCd + "'], pLabNm=[" + pLabNm + "], pMobileNo=[" + pMobileNo + "],pBirthDate=[" + pBirthDate + "]", "Error");
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::exLabMember  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reVal;
        }

        
        //DUPLICATE CHECK MAIN AND RETURN LAB_NO 
        public string exLabMain(string pLabNm, string pMobileNo, string pBirthDate)
        {
            string reVal = "";

            DbLaborSearch db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbLaborSearch(dbCon_IP, dbCon_DB, dbCon_USER, "0");

                reVal = db.exLabMain(pLabNm, pMobileNo, pBirthDate);

            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::exLabMain  (Detail):: " +
             " pLabNm=['" + pLabNm + "'], pMobileNo=[" + pMobileNo + "], pBirthDate=[" + pBirthDate + "]", "Error");
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::exLabMain  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reVal;
        }


        //CCODE COMBO BOX (USING THIS CMB CCODE AS TGRP_CCD)
        public DataSet sLaborAddInfoCcode(string pDbnm, string pSiteCd, string pAuth)
        {
            DataSet ds = null;

            DbLaborSearch db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbLaborSearch(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                ds = db.sLaborAddInfoCcode(pDbnm, pSiteCd, pAuth);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::sLaborAddInfoCcode  (Detail):: " +
                    " pDbnm=['" + pDbnm + "'], pSiteCd=[" + pSiteCd + "], pAuth=[" + pAuth + "]", "Error");
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::sLaborAddInfoCcode  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        //ADD INFO dgv4 COMBO (ex. CarSize, InspectionMethod)  
        public DataSet sLaborAddInfoSub(string pDbnm, string pTcode)
        {
            DataSet ds = null;

            DbLaborSearch db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbLaborSearch(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                ds = db.sLaborAddInfoSub(pDbnm, pTcode);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::sLaborAddInfoSub  (Detail):: " +
                    " pDbnm=['" + pDbnm + "'], pTcode=[" + pTcode + "]", "Error");
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::sLaborAddInfoSub  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }


        //ADD INFO 
        public DataSet sLaborAddInfo(string pSiteCd, string pTcode, string pTgrpCcd, string pAuthCd)
        {
            DataSet ds = null;

            DbLaborSearch db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbLaborSearch(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                
                ds = db.sLaborAddInfo(pSiteCd, pTcode, pTgrpCcd, pAuthCd);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::sLaborAddInfo  (Detail):: " +
                    " pSiteCd=['" + pSiteCd + "'], pTcode=[" + pTcode + "]", "Error");
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::sLaborAddInfo  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }


        //ADD INFO 
        public DataSet sLaborAddInfoModify(string pLabNo, string pSiteCd, string pTtypeScd, string pTgrpCcd)
        {
            DataSet ds = null;

            DbLaborSearch db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbLaborSearch(dbCon_IP, dbCon_DB, dbCon_USER, "0");

                ds = db.sLaborAddInfoModify(pLabNo, pSiteCd, pTtypeScd, pTgrpCcd);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::sLaborAddInfoModify  (Detail):: " +
                    " pLabNo=['" + pLabNo + "'], pSiteCd=['" + pSiteCd + "'], pTtypeScd=['" + pTtypeScd + "'],pTgrpCcd=[" + pTgrpCcd + "]", "Error");
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::sLaborAddInfoModify  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        //INSERT LABOR WITH PROCEDURE
        public string aLaborPro(string pDbNm, Hashtable param, out Hashtable outVal)
        {
            string reVal = "";

            DbLaborSearch db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = "Initial Catalog=PLUS-" + pDbNm + ";";
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbLaborSearch(dbCon_IP, dbCon_DB, dbCon_USER, "1");
                reVal = db.aLaborPro(param, out outVal);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::aLaborPro  (Detail):: " +
                    " pDbNm=['" + pDbNm + "'], param=[" + param + "]", "Error");
                outVal = null;
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::aLaborPro  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reVal;
        }



        //MODIFY LABOR WITH PROCEDURE
        public string mLaborPro(string pDbNm, Hashtable param, out Hashtable outVal)
        {
            string reVal = "";

            DbLaborSearch db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = "Initial Catalog=PLUS-" + pDbNm + ";";
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbLaborSearch(dbCon_IP, dbCon_DB, dbCon_USER, "1");
                reVal = db.mLaborPro(param, out outVal);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::mLaborPro  (Detail):: " +
                    " pDbNm=['" + pDbNm + "'], param=[" + param + "]", "Error");
                outVal = null;
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::mLaborPro  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reVal;
        }

        ////INSERT TCODE_LAB 
        public int aLaborLabTcodeSite(string pDbnm, string pLabNo, string pSiteCd, string pTcode, string pTtypeScd, string pValue)
        {
            int reCnt = 0;

            DbLaborSearch db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbLaborSearch(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                reCnt = db.aLaborLabTcodeSite(pDbnm, pLabNo, pSiteCd, pTcode, pTtypeScd, pValue);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::aLaborLabTcodeSite  (Detail)::pDbnm=[" + pDbnm + "], pLabNo=[" + pLabNo + "], myblockFlag_val=[" + pSiteCd + "]" +
                    ", pTcode=[" + pTcode + "], pTtypeScd=[" + pTtypeScd + "], pValue=[" + pValue + "]", "Error");
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::aLaborLabTcodeSite  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }


        ////UPDATE TCODE_LAB 
        public int mLaborLabTcodeSite(string pDbnm, string pLabNo, string pSiteCd, string pTcode, string pValue)
        {
            int reCnt = 0;

            DbLaborSearch db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbLaborSearch(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                reCnt = db.mLaborLabTcodeSite(pDbnm, pLabNo, pSiteCd, pTcode, pValue);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::mLaborLabTcodeSite  (Detail)::pDbnm=[" + pDbnm + "], pLabNo=[" + pLabNo + "], myblockFlag_val=[" + pSiteCd + "]" +
                    ", pTcode=[" + pTcode + "], pValue=[" + pValue + "]", "Error");
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::mLaborLabTcodeSite  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

   

        ////FIRST INSERT LAB_TCODE_SITE_LOG 
        public int aLaborLabTcodeSiteLog(string pDbnm, string pLabNo, string pSiteCd, string pTcode, string pTtypeScd, string pValue, string pInputId)
        {
            int reCnt = 0;

            DbLaborSearch db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbLaborSearch(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                reCnt = db.aLaborLabTcodeSiteLog(pDbnm, pLabNo, pSiteCd, pTcode, pTtypeScd, pValue, pInputId);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::mLaborLabTcodeSiteLog  (Detail)::pDbnm=[" + pDbnm + "], pLabNo=[" + pLabNo + "], myblockFlag_val=[" + pSiteCd + "]" +
                    ", pTcode=[" + pTcode + "], pValue=[" + pValue + "]", "Error");
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::mLaborLabTcodeSiteLog  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }



        //** AUTH SET PART START 
        public string AuthLaborNew(string pDbNm, string pSiteCd, string pAuthCd)
        {
            string reVal = "";

            DbLaborSearch db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbLaborSearch(dbCon_IP, dbCon_DB, dbCon_USER, "0");

                DataSet ds1 = db.AuthLabor(pDbNm, pSiteCd, pAuthCd);
                string pNew_Flag = ds1.Tables[0].Rows[0]["NEW_FLAG"].ToString();

                reVal = pNew_Flag;
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::AuthLaborNew  (Detail):: " +
                  " pSiteCd=['" + pDbNm + "'], pAuthCd=[" + pSiteCd + "], pLngBlock=[" + pAuthCd + "]", "Error");
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::AuthLaborNew  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reVal;
        }

        public string AuthLaborModify(string pDbNm, string pSiteCd, string pAuthCd)
        {
            string reVal = "";

            DbLaborSearch db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbLaborSearch(dbCon_IP, dbCon_DB, dbCon_USER, "0");

                DataSet ds1 = db.AuthLabor(pDbNm, pSiteCd, pAuthCd);
                string pModify_Flag = ds1.Tables[0].Rows[0]["MODIFY_FLAG"].ToString();

                reVal = pModify_Flag;
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::AuthLaborModify  (Detail):: " +
                  " pSiteCd=['" + pDbNm + "'], pAuthCd=[" + pSiteCd + "], pLngBlock=[" + pAuthCd + "]", "Error");
                logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::AuthLaborModify  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reVal;
        }






        //** AUTH SET PART END


        //////UPDATE LAB_TCODE_SITE_LOG  
        //public int mLaborLabTcodeSiteLog(string pDbnm, string pLabNo, string pSiteCd, string pTcode, string pTtypeScd, string pValue, string pInputId)
        //{
        //    int reCnt = 0;

        //    DbLaborSearch db = null;
        //    try
        //    {
        //        string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
        //        string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
        //        string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

        //        db = new DbLaborSearch(dbCon_IP, dbCon_DB, dbCon_USER, "0");
        //        reCnt = db.mLaborLabTcodeSiteLog(pDbnm, pLabNo, pSiteCd, pTcode, pTtypeScd, pValue, pInputId);
        //    }
        //    catch (Exception ex)
        //    {
        //        logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::mLaborLabTcodeSiteLog  (Detail)::pDbnm=[" + pDbnm + "], pLabNo=[" + pLabNo + "], myblockFlag_val=[" + pSiteCd + "]" +
        //            ", pTcode=[" + pTcode + "], pValue=[" + pValue + "]", "Error");
        //        logs.SaveLog("[error]  (page)::BizLaborSearch.cs  (Function)::mLaborLabTcodeSiteLog  (Detail)::" + "\r\n" + ex.ToString(), "Error");
        //    }
        //    finally
        //    {
        //        if (db != null)
        //            db.DisConnect();
        //    }

        //    return reCnt;
        //}




        //** LABOR SEARCH POP UP PART END **

    }
}