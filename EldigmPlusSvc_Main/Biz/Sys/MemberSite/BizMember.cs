using EldigmPlusClassLibrary.DbClass.Sys.MemberSite;
using EldigmPlusSvc_Main.Biz.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace EldigmPlusSvc_Main.Biz.Sys.MemberSite
{    
    public class BizMember
    {
        LogClass _logs = new LogClass();


        //TreeView 
        public DataSet sMember_UsingFlag(string pUsingFlag)
        {
            DataSet ds = null;

            DbMember db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbMember(dbCon_IP, dbCon_DB, dbCon_USER);
                ds = db.sMember_UsingFlag(pUsingFlag);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizMember.cs  (Function)::sMemcoMainDB_UsingFlag  (Detail)::pUsingFlag=[" + pUsingFlag + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizMember.cs  (Function)::sMemcoMainDB_UsingFlag  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        //SELECT -> GridView1
        public DataSet sMember(string pMemcoCd)
        {
            DataSet ds = null;

            DbMember db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbMember(dbCon_IP, dbCon_DB, dbCon_USER);
                ds = db.sMember(pMemcoCd);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizMember.cs  (Function)::sMember  (Detail)::pMemcoCd=[" + pMemcoCd + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizMember.cs  (Function)::sMember  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        //MODIFY
        public int mMember(string pMemcoCd, string pMemcoNm, string pUsingFlag, string pSortNo, string pMemo)
        {
            int reCnt = 0;

            DbMember db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbMember(dbCon_IP, dbCon_DB, dbCon_USER);
                reCnt = db.mMember(pMemcoCd, pMemcoNm, pUsingFlag, pSortNo, pMemo);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizMember.cs  (Function)::mMember  (Detail)::pMemcoCd=[" + pMemcoCd + "], pMemcoNm=[" + pMemcoNm + "], pUsingFlag=[" + pUsingFlag + "]" +
                    ", pSortNo=[" + pSortNo + "], pMemo=[" + pMemo + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizMember.cs  (Function)::mMember  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }


        //DUPLICATE CEHCK 
        public int exMember(string pMemcoCd, string pMemcoNm)
        {
            int reCnt = 0;

            DbMember db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbMember(dbCon_IP, dbCon_DB, dbCon_USER);
                reCnt = db.exMember(pMemcoCd, pMemcoNm);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizMember.cs  (Function)::exMember  (Detail)::pMemcoCd=[" + pMemcoCd + "] , pMemcoNm =[" + pMemcoNm +"] ", "Error");
                _logs.SaveLog("[error]  (page)::BizMember.cs  (Function)::exMember  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        //INSERT 
        public int aMember(string pMemcoNM, string pDb_Nm, string pUsingFlag, string pMemo, string pSortNo, string pInputId)
        {
            int reCnt = 0;

            DbMember db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbMember(dbCon_IP, dbCon_DB, dbCon_USER);
                reCnt = db.aMember(pMemcoNM, pDb_Nm, pUsingFlag, pMemo, pSortNo, pInputId);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizMember.cs  (Function)::aMember  (Detail):: pMemcoNM=[" + pMemcoNM + "], pDb_Nm=[" + pDb_Nm + "]" +
                    ", pUsingFlag=[" + pUsingFlag + "], pMemo=[" + pMemo + "], pSortNo=[" + pSortNo + "], pInputId=[" + pInputId + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizMember.cs  (Function)::aMember  (Detail)::" + "\r\n" + ex.ToString(), "Error");
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