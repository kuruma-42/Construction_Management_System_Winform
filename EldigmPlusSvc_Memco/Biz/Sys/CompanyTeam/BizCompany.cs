using System;
using EldigmPlusClassLibrary.DbClass.Sys.SysCode;
using System.Data;
using System.Web.Configuration;
using EldigmPlusSvc_Memco.Biz.Common;
using EldigmPlusClassLibrary.DbClass.Sys.CompanyTeam;
using System.Collections;

namespace EldigmPlusSvc_Memco.Biz.Sys.CompanyTeam
{
    public class BizCompany
    {
        LogClass _logs = new LogClass();

        //CONST CMB BOX
        public DataSet constCmb(string pSiteCd)
        {
            DataSet ds = null;

            DbCompany db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbCompany(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                ds = db.constCmb(pSiteCd);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizCompany.cs  (Function)::constCmb  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        //CO_TYPE CMB BOX
        public DataSet cotype_Cmb()
        {
            DataSet ds = null;

            DbCompany db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbCompany(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                ds = db.cotype_Cmb();
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizCompany.cs  (Function)::cotype_Cmb  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        //CONST CMB BOX WITHOUT NOSELECT
        public DataSet constCmb2(string pSiteCd)
        {
            DataSet ds = null;

            DbCompany db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbCompany(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                ds = db.constCmb2(pSiteCd);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizCompany.cs  (Function)::constCmb2  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        //CO_TYPE CMB BOX WITHOUT NO SELECT
        public DataSet cotype_Cmb2()
        {
            DataSet ds = null;

            DbCompany db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbCompany(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                ds = db.cotype_Cmb2();
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizCompany.cs  (Function)::cotype_Cmb2  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }



        public DataSet sCompany(string pSiteCd, string pUsingFlag, string pCoNm)
        {
            DataSet ds = null;

            DbCompany db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbCompany(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                ds = db.sCompany( pSiteCd, pUsingFlag, pCoNm);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizCompany.cs  (Function)::sCompany  (Detail)::pSiteCd=[" + pSiteCd + "], pUsingFlag=[" + pUsingFlag + "], pCoNm=[" + pCoNm + "]"
                    , "Error");
                _logs.SaveLog("[error]  (page)::BizCompany.cs  (Function)::sCompany  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }


        public int mCompanyMain(string pCoCd, string pCoNm, string pBizNo, string pConstCcd, string pCoTypeScd, string pOwnerNm, string pTel, string pAddr )
        {
            int reCnt = 0;

            DbCompany db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbCompany(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                reCnt = db.mCompanyMain(pCoCd, pCoNm, pBizNo, pConstCcd, pCoTypeScd, pOwnerNm, pTel, pAddr);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizCompany.cs  (Function)::mCompanyMain  (Detail)::pCoCd=[" + pCoCd + "], pCoNm=[" + pCoNm + "], pBizNo=[" + pBizNo + "]" +
                    ", pConstCcd=[" + pConstCcd + "], pCoTypeScd=[" + pCoTypeScd + "], pOwnerNm=[" + pOwnerNm + "], pTel=[" + pTel + "] pAddr=[" + pAddr + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizCompany.cs  (Function)::mCompanyMain  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        

        public int mCompanyMemco(string pSiteCd, string pCoCd, string pCoNm, string pHeadcoCd, string pConstCcd, string pCoTypeScd, string pSortNo)
        {
            int reCnt = 0;

            DbCompany db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbCompany(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                reCnt = db.mCompanyMemco(pSiteCd, pCoCd, pCoNm, pHeadcoCd, pConstCcd, pCoTypeScd, pSortNo);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizCompany.cs  (Function)::mCompanyMemco  (Detail)::pSiteCd=[" + pSiteCd + "], pCoCd=[" + pCoCd + "], pCoNm=[" + pCoNm + "], pHeadcoCd=[" + pHeadcoCd + "]" +
                    ", pConstCcd=[" + pConstCcd + "], pCoTypeScd=[" + pCoTypeScd + "], pSortNo=[" + pSortNo + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizCompany.cs  (Function)::mCompanyMemco  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }


        public int mCompanyMemcoSite(string pSiteCd, string pCoCd, string pStartDate, string pEndDate, string pUsingFlag, string pSortNo, string pMemo)
        {
            int reCnt = 0;

            DbCompany db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbCompany(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                reCnt = db.mCompanyMemcoSite(pSiteCd, pCoCd, pStartDate, pEndDate, pUsingFlag, pSortNo, pMemo);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizCompany.cs  (Function)::mCompanyMemcoSite  (Detail)::pSiteCd=[" + pSiteCd + "], pStartDate=[" + pStartDate + "], pEndDate=[" + pEndDate + "], pUsingFlag=[" + pUsingFlag + "]" +
                    ", pSortNo=[" + pSortNo + "], pMemo=[" + pMemo + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizCompany.cs  (Function)::mCompanyMemcoSite  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int mConpanyMainLog(string pCoCd, string pCoNm, string pBizNo, string pConstCcd, string pCoTypeScd, string pOwnerNm, string pTel, string pAddr, string pUsingCnt, string pInputId)
        {
            int reCnt = 0;

            DbCompany db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbCompany(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                reCnt = db.mConpanyMainLog(pCoCd, pCoNm, pBizNo, pConstCcd, pCoTypeScd, pOwnerNm, pTel, pAddr, pUsingCnt, pInputId);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizCompany.cs  (Function)::mConpanyMainLog  (Detail)::pCoCd=[" + pCoCd + "], pCoNm=[" + pCoNm + "], pBizNo=[" + pBizNo + "]" +
                    ", pConstCcd=[" + pConstCcd + "], pCoTypeScd=[" + pCoTypeScd + "], pOwnerNm=[" + pOwnerNm + "], pTel=[" + pTel + "], pAddr=[" + pAddr + "], pUsingCnt=[" + pUsingCnt + "], pInputId=[" + pInputId + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizCompany.cs  (Function)::mConpanyMainLog  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int mCompanySiteLog(string pCoCd, string pSiteCd, string pCoNm, string pConstCcd, string pCoTypeScd, string pStartDate, string pEndDate, string pUsingFlag, string pSortNo, string pMemo, string pInputId)
        {
            int reCnt = 0;

            DbCompany db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;


                db = new DbCompany(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                reCnt = db.mCompanySiteLog(pCoCd, pSiteCd, pCoNm, pConstCcd, pCoTypeScd, pStartDate, pEndDate, pUsingFlag, pSortNo, pMemo, pInputId);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizCompany.cs  (Function)::mConpanyMainLog  (Detail)::pCoCd=[" + pCoCd + "], pSiteCd=[" + pSiteCd + "], pCoNm=[" + pCoNm + "]" +
                    ", pConstCcd=[" + pConstCcd + "], pCoTypeScd=[" + pCoTypeScd + "], pStartDate=[" + pStartDate + "], pEndDate=[" + pEndDate + "], pUsingFlag=[" + pUsingFlag + "], pSortNo=[" + pSortNo + "], pMemo=[" + pMemo + "], pInputId=[" + pInputId + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizCompany.cs  (Function)::mCompanySiteLog  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }







        public int aCompanyMemcoSite(string pSiteCd, string pCoCd, string pStartDate, string pEndDate, string pUsingFlag, string pSortNo, string pMemo, string pInputId)
        {
            int reCnt = 0;

            DbCompany db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbCompany(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                reCnt = db.aCompanyMemcoSite(pSiteCd, pCoCd, pStartDate, pEndDate, pUsingFlag, pSortNo, pMemo, pInputId);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizCompany.cs  (Function)::aCompanyMemcoSite  (Detail)::pSiteCd=[" + pSiteCd + "], pCoCd=[" + pCoCd + "], pStartDate=[" + pStartDate + "]" +
                    ", pEndDate=[" + pEndDate + "], pMemo=[" + pUsingFlag + "], pMemo=[" + pSortNo + "], pMemo=[" + pMemo + "], pSortNo=[" + pInputId + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizCompany.cs  (Function)::aCompanyMemcoSite  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        //INSERT COMPANY WITH PROCEDURE
        public string aCompanyPro(string pDbNm, Hashtable param, out Hashtable outVal)
        {
            string reVal = "";

            DbCompany db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = "Initial Catalog=PLUS-" + pDbNm + ";";
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbCompany(dbCon_IP, dbCon_DB, dbCon_USER, "1");
                reVal = db.aCompanyPro(param, out outVal);
            }
            catch (Exception ex)
            {
                outVal = null;
                _logs.SaveLog("[error]  (page)::BizCompany.cs  (Function)::aCompanyPro  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reVal;
        }

    }

}