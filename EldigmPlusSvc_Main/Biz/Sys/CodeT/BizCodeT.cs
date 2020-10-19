using EldigmPlusClassLibrary.DbClass.Sys.CodeT;
using EldigmPlusSvc_Main.Biz.Common;
using System;
using System.Collections;
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
                _logs.SaveLog("[error]  (page)::BizCodeT.cs  (Function)::sSysCode  (Detail)::"
                    , "Error");
                _logs.SaveLog("[error]  (page)::BizCodeT.cs  (Function)::sSysCode  (Detail)::" + "\r\n" + ex.ToString(), "Error");
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
                _logs.SaveLog("[error]  (page)::BizCodeT.cs  (Function)::sCodeTTreeView  (Detail):: " +
                      " pScode=['" + pScode + "']", "Error");
                _logs.SaveLog("[error]  (page)::BizCodeT.cs  (Function)::sCodeTTreeView  (Detail)::" + "\r\n" + ex.ToString(), "Error");
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
                _logs.SaveLog("[error]  (page)::BizCodeT.cs  (Function)::sCodeT  (Detail):: " +
                     " pScode=['" + pScode + "']", "Error");
                _logs.SaveLog("[error]  (page)::BizCodeT.cs  (Function)::sCodeT  (Detail)::" + "\r\n" + ex.ToString(), "Error");
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
                _logs.SaveLog("[error]  (page)::BizCodeT.cs  (Function)::sCodeTSubTreeView  (Detail):: " +
                    " pTcode=['" + pTcode + "']", "Error");
                _logs.SaveLog("[error]  (page)::BizCodeT.cs  (Function)::sCodeTSubTreeView  (Detail)::" + "\r\n" + ex.ToString(), "Error");
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
                _logs.SaveLog("[error]  (page)::BizCodeT.cs  (Function)::sCodeTSub  (Detail):: " +
                   " pTcode=['" + pTcode + "']", "Error");
                _logs.SaveLog("[error]  (page)::BizCodeT.cs  (Function)::sCodeTSub  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        public DataSet sCodeTSubTscode(string pTcode)
        {
            DataSet ds = null;

            DbCodeT db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbCodeT(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                ds = db.sCodeTSubTscode(pTcode);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizCodeT.cs  (Function)::sCodeTSub  (Detail):: " +
                   " pTcode=['" + pTcode + "']", "Error");
                _logs.SaveLog("[error]  (page)::BizCodeT.cs  (Function)::sCodeTSub  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        public int mCodeT(string pTcode, string pListFlag, string pRequiredFlag, string pNumericFlag)
        {
            int reCnt = 0;

            DbCodeT db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbCodeT(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                reCnt = db.mCodeT(pTcode, pListFlag, pRequiredFlag, pNumericFlag);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizCodeT.cs  (Function)::mCodeT  (Detail):: " +
                    ", pTcode=['" + pTcode + "'], pListFlag=[" + pListFlag + "], pRequiredFlag=[" + pRequiredFlag + "]" + ", pNumericFlag=[" + pNumericFlag + "]" 
                    , "Error");
                _logs.SaveLog("[error]  (page)::BizCodeT.cs  (Function)::mCodeT  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int exCodeT(string pTcode, string ptcodeNm)
        {
            int reCnt = 0;

            DbCodeT db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbCodeT(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                reCnt = db.exCodeT(pTcode, ptcodeNm);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizCodeT.cs  (Function)::exCodeT  (Detail):: " +
                    ", pTcode=['" + pTcode + "'], ptcodeNm=[" + ptcodeNm + "],", "Error");
                _logs.SaveLog("[error]  (page)::BizCodeT.cs  (Function)::exCodeT  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }
        public int aCodeT(string pTcode, string pttypeScd, string ptcodeNm, string pListFlag, string pRequiredFlag, string pNumericFlag, string pInputId)
        {
            int reCnt = 0;

            DbCodeT db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbCodeT(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                reCnt = db.aCodeT(pTcode, pttypeScd, ptcodeNm, pListFlag, pRequiredFlag, pNumericFlag, pInputId);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizCodeT.cs  (Function)::aCodeT  (Detail):: " +
                    ", pTcode=['" + pTcode + "'], pttypeScd=[" + pttypeScd + "], ptcodeNm=[" + ptcodeNm + "]" +
                    ", pRequiredFlag=[" + pRequiredFlag + "], pNumericFlag=['" + pNumericFlag + "'], pInputId=[" + pInputId + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizCodeT.cs  (Function)::aCodeT  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int exCodeTSub(string pTcode, string ptscodeNm)
        {
            int reCnt = 0;

            DbCodeT db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbCodeT(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                reCnt = db.exCodeTSub(pTcode, ptscodeNm);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizCodeT.cs  (Function)::exCodeTSub  (Detail):: " +
                    ", pTcode=['" + pTcode + "']", "Error");
                _logs.SaveLog("[error]  (page)::BizCodeT.cs  (Function)::exCodeTSub  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int aCodeTSub(string pTcode, string pTscodeNm, string pUsingCnt, string pInputId)
        {
            int reCnt = 0;

            DbCodeT db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbCodeT(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                reCnt = db.aCodeTSub(pTcode, pTscodeNm, pUsingCnt, pInputId);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizCodeT.cs  (Function)::aCodeTSub  (Detail):: " +
                    ", pTcode=['" + pTcode + "'], pTscodeNm=[" + pTscodeNm + "], pUsingCnt=[" + pUsingCnt + "]" + ", pInputId=[" + pInputId + "]"
                    , "Error");
                _logs.SaveLog("[error]  (page)::BizCodeT.cs  (Function)::aCodeTSub  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public DataSet sCodeTSiteTreeView(string pDbnm, string pSiteCd, string pAuth)
        {
            DataSet ds = null;

            DbCodeT db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbCodeT(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                ds = db.sCodeTSiteTreeView(pDbnm, pSiteCd, pAuth);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizCodeT.cs  (Function)::sCodeTSubTreeView  (Detail):: " +
                    " pDbnm=['" + pDbnm + "'], pSiteCd=[" + pSiteCd + "], pAuth=[" + pAuth + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizCodeT.cs  (Function)::sCodeTSubTreeView  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        public DataSet sCodeTSite(string pDbnm, string pSiteCd, string pTgrpCcd)
        {
            DataSet ds = null;

            DbCodeT db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbCodeT(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                ds = db.sCodeTSite(pDbnm, pSiteCd, pTgrpCcd);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizCodeT.cs  (Function)::sCodeTSite  (Detail):: " +
                    " pDbnm=['" + pDbnm + "'], pSiteCd=[" + pSiteCd + "], pTgrpCcd=[" + pTgrpCcd + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizCodeT.cs  (Function)::sCodeTSite  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }


        public int mCodeTSite(string pDbnm, string pSiteCd, string pTcode, string pDefaultValue, string pUsingFlag, string pSortNo, string pMemo)
        {
            int reCnt = 0;

            DbCodeT db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbCodeT(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                reCnt = db.mCodeTSite(pDbnm, pSiteCd, pTcode, pDefaultValue, pUsingFlag, pSortNo, pMemo);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizCodeT.cs  (Function)::mCodeTSite  (Detail):: " +
                    ", pDbnm=['" + pDbnm + "'], pSiteCd=[" + pSiteCd + "], pTcode=[" + pTcode + "]" + ", pDefaultValue=[" + pDefaultValue + "]" +
                    ", pUsingFlag=['" + pUsingFlag + "'], pSortNo=[" + pSortNo + "], pMemo=[" + pMemo + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizCodeT.cs  (Function)::mCodeTSite  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public string aCodeTSite(string pDbNm, Hashtable param, out Hashtable outVal)
        {
            string reVal = "";

            DbCodeT db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = "Initial Catalog=PLUS-" + pDbNm + ";";
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbCodeT(dbCon_IP, dbCon_DB, dbCon_USER, "1");
                reVal = db.aCodeTSite(param, out outVal);
            }
            catch (Exception ex)
            {
                outVal = null;
                //logs.SaveLog("[error]  (page)::BizCodeT.cs  (Function)::aCodeTSite  (Detail)::memcoCd_val=[" + memcoCd_val + "], siteNm_val=[" + siteNm_val + "], usingFlag_val=[" + usingFlag_val + "]" +
                //    ", sortNo_val=[" + sortNo_val + "], pInputId=[" + pInputId + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizSite.cs  (Function)::aCodeTSite  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reVal;
        }

        public string aCodeTSubSite(string pDbNm, Hashtable param, out Hashtable outVal)
        {
            string reVal = "";

            DbCodeT db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = "Initial Catalog=PLUS-" + pDbNm + ";";
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbCodeT(dbCon_IP, dbCon_DB, dbCon_USER, "1");
                reVal = db.aCodeTSubSite(param, out outVal);
            }
            catch (Exception ex)
            {
                outVal = null;
                //logs.SaveLog("[error]  (page)::BizCodeT.cs  (Function)::aCodeTSite  (Detail)::memcoCd_val=[" + memcoCd_val + "], siteNm_val=[" + siteNm_val + "], usingFlag_val=[" + usingFlag_val + "]" +
                //    ", sortNo_val=[" + sortNo_val + "], pInputId=[" + pInputId + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizSite.cs  (Function)::aCodeTSite  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reVal;
        }

        public int aCodeTSiteLog(string pDbnm, string pSiteCd, string pTcode, string pTgrpCcd, string pRequiredFlag, string pNumericFlag, string pDefaultValue, string pUsingFlag, string pSortNo, string pMemo, string pInputId)
        {
            int reCnt = 0;

            DbCodeT db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbCodeT(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                reCnt = db.aCodeTSiteLog(pDbnm, pSiteCd, pTcode, pTgrpCcd, pRequiredFlag, pNumericFlag, pDefaultValue, pUsingFlag, pSortNo, pMemo, pInputId);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizCodeT.cs  (Function)::aCodeT  (Detail):: " +
                    ", pDbnm=['" + pDbnm + "'], pSiteCd=[" + pSiteCd + "], pTcode=[" + pTcode + "]" +
                     ", pTgrpCcd=['" + pTgrpCcd + "'], pRequiredFlag=[" + pRequiredFlag + "], pNumericFlag=[" + pNumericFlag + "]" +
                      ", pDefaultValue=['" + pDefaultValue + "'], pUsingFlag=[" + pUsingFlag + "], pSortNo=[" + pSortNo + "]" +
                    ", pMemo=[" + pMemo + "], pInputId=[" + pInputId + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizCodeT.cs  (Function)::aCodeT  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }
        

        //**AUTH PART START 

        //TREEVIEW 2
        public DataSet sCodeTAuthTreeView(string pScode, string pSiteCd)
        {
            DataSet ds = null;

            DbCodeT db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbCodeT(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                ds = db.sCodeTAuthTreeView(pScode, pSiteCd);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizCodeT.cs  (Function)::sCodeTAuthTreeView  (Detail):: pScode=[" + pScode + "], pSiteCd=[" + pSiteCd + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizCodeT.cs  (Function)::sCodeTAuthTreeView  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        //SELECT
        public DataSet sCodeTAuth(string pTcode, string pSiteCd, string pAuthCd)
        {
            DataSet ds = null;

            DbCodeT db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbCodeT(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                ds = db.sCodeTAuth(pTcode, pSiteCd, pAuthCd);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizCodeT.cs  (Function)::sCodeTAuth  (Detail):: pScode=[" + pTcode + "], pSiteCd=[" + pSiteCd + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizCodeT.cs  (Function)::sCodeTAuth  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        //SELECT : WHEN USER CLICK TTYPE_SCD 
        public DataSet sCodeTAuthTtype(string pTtypeScd, string pSiteCd, string pAuthCd)
        {
            DataSet ds = null;

            DbCodeT db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbCodeT(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                ds = db.sCodeTAuthTtype(pTtypeScd, pSiteCd, pAuthCd);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizCodeT.cs  (Function)::sCodeTAuthTtype  (Detail):: pTtypeScd=[" + pTtypeScd + "], pSiteCd=[" + pSiteCd + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizCodeT.cs  (Function)::sCodeTAuthTtype  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }


        public int mCodeTAuth(string pTcodeNm, string pSiteCd, string pAuthCd, string pViewFlag, string pNewFlag, string pModifyFlag)
        {
            int reCnt = 0;

            DbCodeT db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbCodeT(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                reCnt = db.mCodeTAuth(pTcodeNm, pSiteCd, pAuthCd, pViewFlag, pNewFlag, pModifyFlag);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizCodeT.cs  (Function)::mCodeTAuth  (Detail):: " +
                    " pTcodeNm=['" + pTcodeNm + "'], pSiteCd=[" + pSiteCd + "], pAuthCd=[" + pAuthCd + "]" + ", pViewFlag=[" + pViewFlag + "]" +
                    ", pNewFlag=['" + pNewFlag + "'], pModifyFlag=[" + pModifyFlag + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizCodeT.cs  (Function)::mCodeTAuth  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }
        //**AUTH PART END 

    }
}