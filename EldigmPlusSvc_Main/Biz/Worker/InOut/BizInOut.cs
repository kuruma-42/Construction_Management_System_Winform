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

        //CONST CMB BOX WITHOUT NOSELECT
        public DataSet sLaborCompanyList(string pSiteCd, string pAuthCd, string pCoCd)
        {
            DataSet ds = null;

            DbInOut db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbInOut(dbCon_IP, dbCon_DB, dbCon_USER, "0");

                //MYCOM_FLAG 값을 구해옴 
                //string pMyComFlag = "";
                //pMyComFlag = db.sMyComFlag(pSiteCd, pAuthCd);

                ds = db.sLaborCompanyList(pSiteCd, Convert.ToInt16(pCoCd));
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizInOut.cs  (Function)::sLaborCompanyList  (Detail)::pSiteCd=[" + pSiteCd + "], " +
                    " pAuthCd=[" + pAuthCd + "], pCoCd=[" + pCoCd + "]", "Error");
                logs.SaveLog("[error]  (page)::BizInOut.cs  (Function)::sLaborCompanyList  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        public DataSet co_Cmb(string pSiteCd)
        {
            DataSet ds = null;

            DbInOut db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbInOut(dbCon_IP, dbCon_DB, dbCon_USER, "0");

                ds = db.co_Cmb(pSiteCd);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizInOut.cs  (Function)::sLaborCompanyList  (Detail)::pSiteCd=[" + pSiteCd + "]", "Error");
                logs.SaveLog("[error]  (page)::BizInOut.cs  (Function)::sLaborCompanyList  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        public DataSet team_Cmb(string pSiteCd)
        {
            DataSet ds = null;

            DbInOut db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbInOut(dbCon_IP, dbCon_DB, dbCon_USER, "0");

                ds = db.team_Cmb(pSiteCd);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizInOut.cs  (Function)::sLaborCompanyList  (Detail)::pSiteCd=[" + pSiteCd + "]", "Error");
                logs.SaveLog("[error]  (page)::BizInOut.cs  (Function)::sLaborCompanyList  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        public DataSet sInOut(string pDbnm, string pSiteCd, string pDtp1, string pDtp2, string pCocd, string pCmbIO)
        {
            DataSet ds = null;

            DbInOut db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbInOut(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                ds = db.sInOut(pDbnm, pSiteCd, pDtp1, pDtp2, pCocd, pCmbIO);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizInOut.cs  (Function)::sInOut  (Detail)::pDbnm=[" + pDbnm + "], " +
                    "pSiteCd=[" + pSiteCd + "], pDtp1=[" + pDtp1 + "], pDtp2=[" + pDtp2 + "], pCocd=[" + pCocd + "]", "Error");
                logs.SaveLog("[error]  (page)::BizInOut.cs  (Function)::sInOut  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        public DataSet sInOutHistory(string pDbnm, string pSiteCd, string pDtp1, string pDtp2, string pCocd)
        {
            DataSet ds = null;

            DbInOut db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbInOut(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                ds = db.sInOutHistory(pDbnm, pSiteCd, pDtp1, pDtp2, pCocd);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizInOut.cs  (Function)::sInOutHistory  (Detail)::pDbnm=[" + pDbnm + "], " +
                    "pSiteCd=[" + pSiteCd + "], pDtp1=[" + pDtp1 + "], pDtp2=[" + pDtp2 + "], pCocd=[" + pCocd + "]", "Error");
                logs.SaveLog("[error]  (page)::BizInOut.cs  (Function)::sInOutHistory  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        public int mInOut(string pDbnm, string pLabNo, string pSiteCd, string pRegDate, string pInDt, string pOutDt, string pCoCd, string pTeamCd)
        {
            int reCnt = 0;

            DbInOut db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbInOut(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                reCnt = db.mInOut(pDbnm, pLabNo, pSiteCd, pRegDate, pInDt, pOutDt, pCoCd, pTeamCd);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizInOut.cs  (Function)::mInOut  (Detail)::, pDbnm=[" + pDbnm + "], pLabNo=[" + pLabNo + "]" +
                    ", pSiteCd=[" + pSiteCd + "], pRegDate=[" + pRegDate + "], pInDt=[" + pInDt + "], pOutDt=[" + pOutDt + "]", "Error");
                logs.SaveLog("[error]  (page)::BizInOut.cs  (Function)::mInOut  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

      public int aInOutLog(string pDbnm, string pLabNo, string pSiteCd, string pRegDate, string pInDt, string pOutDt, string pCoCd, string pTeamCd, string pInIOPFId, string pOutIOPFId, string pInputId)
        {
            int reCnt = 0;
            DbInOut db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbInOut(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                reCnt = db.aInOutLog(pDbnm, pLabNo, pSiteCd, pRegDate, pInDt, pOutDt, pCoCd, pTeamCd, pInIOPFId, pOutIOPFId, pInputId);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizInOut.cs  (Function)::aInOutLog  (Detail):: pDbnm=[" + pDbnm + "], pLabNo=[" + pLabNo + "]" +
                    "pSiteCd=[" + pSiteCd + "], pRegDate=[" + pRegDate + "], + pCoCd =[" + pCoCd + "], pTeamCd =[" + pTeamCd + "]" +
                    ", pInputId=[" + pInputId + "]", "Error");
                logs.SaveLog("[error]  (page)::BizInOut.cs  (Function)::aInOutLog  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int dInHistory(string pDbnm, string pLabNo, string pSiteCd, string pRegDate, string pEventDt)
        {
            int reCnt = 0;

            DbInOut db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbInOut(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                reCnt = db.dInHistory(pDbnm, pLabNo, pSiteCd, pRegDate, pEventDt);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizInOut.cs  (Function)::exInOutHistory  (Detail)::, pDbnm=[" + pDbnm + "], pLabNo=[" + pLabNo + "]" +
                    ", pSiteCd=[" + pSiteCd + "], pRegDate=[" + pRegDate + "], pEventDt=[" + pEventDt + "]", "Error");
                logs.SaveLog("[error]  (page)::BizInOut.cs  (Function)::exInOutHistory  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int dOutHistory(string pDbnm, string pLabNo, string pSiteCd, string pRegDate, string pEventDt)
        {
            int reCnt = 0;

            DbInOut db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbInOut(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                reCnt = db.dOutHistory(pDbnm, pLabNo, pSiteCd, pRegDate, pEventDt);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizInOut.cs  (Function)::exInOutHistory  (Detail)::, pDbnm=[" + pDbnm + "], pLabNo=[" + pLabNo + "]" +
                    ", pSiteCd=[" + pSiteCd + "], pRegDate=[" + pRegDate + "], pEventDt=[" + pEventDt + "]", "Error");
                logs.SaveLog("[error]  (page)::BizInOut.cs  (Function)::exInOutHistory  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int mInOutHistory(string pDbnm, string pLabNo, string pSiteCd, string pRegDate, string pEventDt, string pEventDtH, string pCoCd, string pTeamCd)
        {
            int reCnt = 0;

            DbInOut db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbInOut(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                reCnt = db.mInOutHistory(pDbnm, pLabNo, pSiteCd, pRegDate, pEventDt, pEventDtH, pCoCd, pTeamCd);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizInOut.cs  (Function)::mInOutHistory  (Detail)::, pDbnm=[" + pDbnm + "], pLabNo=[" + pLabNo + "]" +
                    ", pSiteCd=[" + pSiteCd + "], pRegDate=[" + pRegDate + "], pEventDt=[" + pEventDt + "]", "Error");
                logs.SaveLog("[error]  (page)::BizInOut.cs  (Function)::mInOutHistory  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int aInOutHistory(string pDbnm, string pLabNo, string pSiteCd, string pRegDate, string pEventDt, string pCoCd, string pTeamCd, string pInputId)
        {
            int reCnt = 0;

            DbInOut db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbInOut(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                reCnt = db.aInOutHistory(pDbnm, pLabNo, pSiteCd, pRegDate, pEventDt, pCoCd, pTeamCd, pInputId);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizInOut.cs  (Function)::aInOutHistory  (Detail)::, pDbnm=[" + pDbnm + "], pLabNo=[" + pLabNo + "]" +
                    ", pSiteCd=[" + pSiteCd + "], pRegDate=[" + pRegDate + "], pEventDt=[" + pEventDt + "], pCoCd=[" + pCoCd + "]" +
                    ", pTeamCd=[" + pTeamCd + "], pInputId=[" + pInputId + "]", "Error");
                logs.SaveLog("[error]  (page)::BizInOut.cs  (Function)::aInOutHistory  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int aInOut(string pDbnm, string pLabNo, string pSiteCd, string pRegDate, string pInDt, string pOutDt, string pCoCd, string pTeamCd)
        {
            int reCnt = 0;

            DbInOut db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbInOut(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                reCnt = db.aInOut(pDbnm, pLabNo, pSiteCd, pRegDate, pInDt, pOutDt, pCoCd, pTeamCd);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizInOut.cs  (Function)::aInOut  (Detail)::, pDbnm=[" + pDbnm + "], pLabNo=[" + pLabNo + "]" +
                    ", pSiteCd=[" + pSiteCd + "], pRegDate=[" + pRegDate + "], pInDt=[" + pInDt + "], pOutDt=[" + pOutDt + "], pCoCd=[" + pCoCd + "]" +
                    ", pTeamCd=[" + pTeamCd + "]", "Error");
                logs.SaveLog("[error]  (page)::BizInOut.cs  (Function)::aInOut  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public string exInOutCo(string pDbnm, string pLabNo, string pSiteCd, string CO_CD)
        {
            string reCnt = "0";

            DbInOut db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbInOut(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                reCnt = db.exInOutCo(pDbnm, pLabNo, pSiteCd, CO_CD);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizInOut.cs  (Function)::exLabInOutFinal  (Detail)::, pLabNo=[" + pLabNo + "], pSiteCd=[" + pSiteCd + "]", "Error");
                logs.SaveLog("[error]  (page)::BizInOut.cs  (Function)::exLabInOutFinal  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int aInOutCo(string pDbnm, string pLabNo, string pSiteCd, string pCoCd, string pInDt)
        {
            int reCnt = 0;

            DbInOut db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbInOut(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                reCnt = db.aInOutCo(pDbnm, pLabNo, pSiteCd, pCoCd, pInDt);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizInOut.cs  (Function)::aInOutCo  (Detail)::, pDbnm=[" + pDbnm + "], pLabNo=[" + pLabNo + "]" +
                    ", pSiteCd=[" + pSiteCd + "], pCoCd=[" + pCoCd + "]", "Error");
                logs.SaveLog("[error]  (page)::BizInOut.cs  (Function)::aInOutCo  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int mInOutCo(string pDbnm, string pLabNo, string pSiteCd, string pCoCd, string pInDt)
        {
            int reCnt = 0;

            DbInOut db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbInOut(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                reCnt = db.mInOutCo(pDbnm, pLabNo, pSiteCd, pCoCd, pInDt);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizInOut.cs  (Function)::mInOutCo  (Detail)::, pDbnm=[" + pDbnm + "], pLabNo=[" + pLabNo + "]" +
                     ", pSiteCd=[" + pSiteCd + "], pCoCd=[" + pCoCd + "]", "Error");
                logs.SaveLog("[error]  (page)::BizInOut.cs  (Function)::mInOutCo  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int exLabInOutFinal(string pLabNo, string pSiteCd)
        {
            int reCnt = 0;

            DbInOut db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbInOut(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                reCnt = db.exLabInOutFinal(pLabNo, pSiteCd);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizInOut.cs  (Function)::exLabInOutFinal  (Detail)::, pLabNo=[" + pLabNo + "], pSiteCd=[" + pSiteCd + "]", "Error");
                logs.SaveLog("[error]  (page)::BizInOut.cs  (Function)::exLabInOutFinal  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int mLabInOutFinal(string pLabNo, string pSiteCd, string pCoCd, string pTeamCd, string pRegDate, string pInHHMM, string pOutHHMM)
        {
            int reCnt = 0;

            DbInOut db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbInOut(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                reCnt = db.mLabInOutFinal(pLabNo, pSiteCd, pCoCd, pTeamCd, pRegDate, pInHHMM, pOutHHMM);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizInOut.cs  (Function)::mLabInOutFinal  (Detail):: pLabNo=[" + pLabNo + "]" +
                    ", pSiteCd=[" + pSiteCd + "], pCoCd=[" + pCoCd + "], pTeamCd=[" + pTeamCd + "], pRegDate=[" + pRegDate + "], " +
                    " pInHHMM=[" + pInHHMM + "], pOutHHMM=[" + pOutHHMM + "]", "Error");
                logs.SaveLog("[error]  (page)::BizInOut.cs  (Function)::mLabInOutFinal  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int aLabInOutFinal(string pLabNo, string pSiteCd, string pCoCd, string pTeamCd, string pRegDate, string pInHHMM, string pOutHHMM)
        {
            int reCnt = 0;

            DbInOut db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbInOut(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                reCnt = db.aLabInOutFinal(pLabNo, pSiteCd, pCoCd, pTeamCd, pRegDate, pInHHMM, pOutHHMM);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizInOut.cs  (Function)::aLabInOutFinal  (Detail):: pLabNo=[" + pLabNo + "]" +
                    ", pSiteCd=[" + pSiteCd + "], pCoCd=[" + pCoCd + "], pTeamCd=[" + pTeamCd + "], pRegDate=[" + pRegDate + "], " +
                    " pInHHMM=[" + pInHHMM + "], pOutHHMM=[" + pOutHHMM + "]", "Error");
                logs.SaveLog("[error]  (page)::BizInOut.cs  (Function)::aLabInOutFinal  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int exInOut2020(string pLabNo, string pSiteCd, string pRegdate)
        {
            int reCnt = 0;

            DbInOut db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbInOut(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                reCnt = db.exInOut2020(pLabNo, pSiteCd, pRegdate);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizInOut.cs  (Function)::exInOut2020  (Detail)::, pLabNo=[" + pLabNo + "], pSiteCd=[" + pSiteCd + "]", "Error");
                logs.SaveLog("[error]  (page)::BizInOut.cs  (Function)::exInOut2020  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int aInOut2020(string pLabNo, string pSiteCd, string pRegDate, string pCoCd, string pTeamCd, string pInHHMM, string pOutHHMM)
        {
            int reCnt = 0;

            DbInOut db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbInOut(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                reCnt = db.aInOut2020(pLabNo, pSiteCd, pRegDate, pCoCd, pTeamCd, pInHHMM, pOutHHMM);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizInOut.cs  (Function)::aInOut2020  (Detail):: pLabNo=[" + pLabNo + "]" +
                    ", pSiteCd=[" + pSiteCd + "], pCoCd=[" + pCoCd + "], pTeamCd=[" + pTeamCd + "], pRegDate=[" + pRegDate + "], " +
                    " pInHHMM=[" + pInHHMM + "], pOutHHMM=[" + pOutHHMM + "]", "Error");
                logs.SaveLog("[error]  (page)::BizInOut.cs  (Function)::aInOut2020  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int mInOut2020(string pLabNo, string pSiteCd, string pRegDate, string pCoCd, string pTeamCd,  string pInHHMM, string pOutHHMM)
        {
            int reCnt = 0;

            DbInOut db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbInOut(dbCon_IP, dbCon_DB, dbCon_USER, "0");
                reCnt = db.mInOut2020(pLabNo, pSiteCd, pRegDate, pCoCd, pTeamCd, pInHHMM, pOutHHMM);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizInOut.cs  (Function)::mInOut2020  (Detail):: pLabNo=[" + pLabNo + "]" +
                    ", pSiteCd=[" + pSiteCd + "], pCoCd=[" + pCoCd + "], pTeamCd=[" + pTeamCd + "], pRegDate=[" + pRegDate + "], " +
                    " pInHHMM=[" + pInHHMM + "], pOutHHMM=[" + pOutHHMM + "]", "Error");
                logs.SaveLog("[error]  (page)::BizInOut.cs  (Function)::mInOut2020  (Detail)::" + "\r\n" + ex.ToString(), "Error");
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