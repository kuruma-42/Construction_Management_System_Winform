using EldigmPlusClassLibrary.DbClass.Sys.SysCode;
using EldigmPlusSvc_Memco.Biz.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EldigmPlusSvc_Memco.Biz.Sys.SysCode
{
    public class BizSysCodeGrp
    {
        LogClass logs = new LogClass();

        public DataSet sSysCodeGrp(string pScodeGrp)
        {
            DataSet ds = null;

            DbSysCodeGrp db = null;
            try
            {
                db = new DbSysCodeGrp();
                ds = db.sSysCodeGrp(pScodeGrp);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizSysCodeGrp.cs  (Function)::sSysCodeGrp  (Detail)::pScodeGrp=[" + pScodeGrp + "]", "Error");
                logs.SaveLog("[error]  (page)::BizSysCodeGrp.cs  (Function)::sSysCodeGrp  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        public int mSysCodeGrp(string pScodeGrp, string pScodeNm, string pUsingFlag, string pSortNo, string pMemo)
        {
            int reCnt = 0;

            DbSysCodeGrp db = null;
            try
            {
                db = new DbSysCodeGrp();
                reCnt = db.mSysCodeGrp(pScodeGrp, pScodeNm, pUsingFlag, pSortNo, pMemo);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizSysCodeGrp.cs  (Function)::mSysCodeGrp  (Detail)::pScodeGrp=[" + pScodeGrp + "], pScodeNm=[" + pScodeNm + "], pUsingFlag=[" + pUsingFlag + "]" +
                    ", pSortNo=[" + pSortNo + "], pMemo=[" + pMemo + "]", "Error");
                logs.SaveLog("[error]  (page)::BizSysCodeGrp.cs  (Function)::mSysCodeGrp  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public DataSet sSysCodeGrp_UsingFlag(string pUsingFlag)
        {
            DataSet ds = null;

            DbSysCodeGrp db = null;
            try
            {
                db = new DbSysCodeGrp();
                ds = db.sSysCodeGrp_UsingFlag(pUsingFlag);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizSysCodeGrp.cs  (Function)::sSysCodeGrp_UsingFlag  (Detail)::pUsingFlag=[" + pUsingFlag + "]", "Error");
                logs.SaveLog("[error]  (page)::BizSysCodeGrp.cs  (Function)::sSysCodeGrp_UsingFlag  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        public DataSet sSysCode(string pScodeGrp, string pUsingFlag, string pScodeNm)
        {
            DataSet ds = null;

            DbSysCodeGrp db = null;
            try
            {
                db = new DbSysCodeGrp();
                ds = db.sSysCode(pScodeGrp, pUsingFlag, pScodeNm);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizSysCodeGrp.cs  (Function)::sSysCode  (Detail)::pScodeGrp=[" + pScodeGrp + "], pUsingFlag=[" + pUsingFlag + "], pScodeNm=[" + pScodeNm + "]"
                    , "Error");
                logs.SaveLog("[error]  (page)::BizSysCodeGrp.cs  (Function)::sSysCode  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        public int mSysCode(string pScode, string pScodeNm, string pUsingFlag, string pSortNo, string pMemo)
        {
            int reCnt = 0;

            DbSysCodeGrp db = null;
            try
            {
                db = new DbSysCodeGrp();
                reCnt = db.mSysCode(pScode, pScodeNm, pUsingFlag, pSortNo, pMemo);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizSysCodeGrp.cs  (Function)::mSysCode  (Detail)::pScode=[" + pScode + "], pScodeNm=[" + pScodeNm + "], pUsingFlag=[" + pUsingFlag + "]" +
                    ", pSortNo=[" + pSortNo + "], pMemo=[" + pMemo + "]", "Error");
                logs.SaveLog("[error]  (page)::BizSysCodeGrp.cs  (Function)::mSysCode  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int exSysCode(string pScode)
        {
            int reCnt = 0;
            
            DbSysCodeGrp db = null;
            try
            {
                db = new DbSysCodeGrp();
                reCnt = db.exSysCode(pScode);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizSysCodeGrp.cs  (Function)::exSysCode  (Detail)::pScode=[" + pScode + "]", "Error");
                logs.SaveLog("[error]  (page)::BizSysCodeGrp.cs  (Function)::exSysCode  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int aSysCode(string pScode, string pScodeGrp, string pScodeNm, string pUsingFlag, string pMemo, string pSortNo, string pInputId)
        {
            int reCnt = 0;

            DbSysCodeGrp db = null;
            try
            {
                db = new DbSysCodeGrp();
                reCnt = db.aSysCode(pScode, pScodeGrp, pScodeNm, pUsingFlag, pMemo, pSortNo, pInputId);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizSysCodeGrp.cs  (Function)::aSysCode  (Detail)::pScode=[" + pScode + "], pScodeGrp=[" + pScodeGrp + "], pScodeNm=[" + pScodeNm + "]" +
                    ", pUsingFlag=[" + pUsingFlag + "], pMemo=[" + pMemo + "], pSortNo=[" + pSortNo + "], pInputId=[" + pInputId + "]", "Error");
                logs.SaveLog("[error]  (page)::BizSysCodeGrp.cs  (Function)::aSysCode  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int aSysCodeLog(string pScode, string pScodeNm, string pUsingFlag, string pSortNo, string pMemo, string pInputId)
        {
            int reCnt = 0;

            DbSysCodeGrp db = null;
            try
            {
                db = new DbSysCodeGrp();
                reCnt = db.aSysCodeLog(pScode, pScodeNm, pUsingFlag, pSortNo, pMemo, pInputId);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizSysCodeGrp.cs  (Function)::aSysCodeLog  (Detail)::pScode=[" + pScode + "], pScodeNm=[" + pScodeNm + "], pUsingFlag=[" + pUsingFlag + "]" +
                    ", pSortNo=[" + pSortNo + "], pMemo=[" + pMemo + "], pInputId=[" + pInputId + "]", "Error");
                logs.SaveLog("[error]  (page)::BizSysCodeGrp.cs  (Function)::aSysCodeLog  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }


        public DataSet fSysCodeSearch(string _scodeGrp, string pScode_Nm)
        {
            DataSet ds = null;

            DbSysCodeGrp db = null;
            try
            {
                string SCODE_NM = pScode_Nm;
                string SCODE_GRP = _scodeGrp;

                db = new DbSysCodeGrp();
                ds = db.fSysCodeSearch(SCODE_GRP, SCODE_NM);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizSysCodeGrp.cs  (Function)::sSysCode  (Detail)::pScodeGrp=[" + pScode_Nm + "]", "Error");
                logs.SaveLog("[error]  (page)::BizSysCodeGrp.cs  (Function)::sSysCode  (Detail)::" + "\r\n" + ex.ToString(), "Error");
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
