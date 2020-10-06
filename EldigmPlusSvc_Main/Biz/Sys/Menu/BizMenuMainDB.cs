using EldigmPlusClassLibrary.DbClass.Sys.Menu;
using EldigmPlusSvc_Main.Biz.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace EldigmPlusSvc_Main.Biz.Sys.Menu
{
    public class BizMenuMainDB
    {
        LogClass _logs = new LogClass();

        public DataSet sManuTopTreeView(string USING_FLAG)
        {
            DataSet ds = null;

            DbMenuMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbMenuMainDB(dbCon_IP, dbCon_DB, dbCon_USER);
                ds = db.sManuTopTreeView(USING_FLAG);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::sManu_UsingFlag  (Detail)::pUsingFlag=[]", "Error");
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::sManu_UsingFlag  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        public DataSet sManuSubTreeView(string TOP_MENU_CD, string USING_FLAG)
        {
            DataSet ds = null;

            DbMenuMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbMenuMainDB(dbCon_IP, dbCon_DB, dbCon_USER);
                ds = db.sManuSubTreeView(TOP_MENU_CD, USING_FLAG);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::sManu_UsingFlag  (Detail)::pUsingFlag=[" + TOP_MENU_CD + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::sManu_UsingFlag  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        public DataSet sManuTreeView(string TOP_MENU_CD, string SUB_MENU_CD, string USING_FLAG)
        {
            DataSet ds = null;

            DbMenuMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbMenuMainDB(dbCon_IP, dbCon_DB, dbCon_USER);
                ds = db.sManuTreeView(TOP_MENU_CD, SUB_MENU_CD, USING_FLAG);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::sManu_UsingFlag  (Detail)::TOP_MENU_CD=[" + TOP_MENU_CD + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::sManu_UsingFlag  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        public DataSet sManuTreeView2(string TOP_MENU_CD, string SUB_MENU_CD, string MENU_CD, string USING_FLAG)
        {
            DataSet ds = null;

            DbMenuMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbMenuMainDB(dbCon_IP, dbCon_DB, dbCon_USER);
                ds = db.sManuTreeView2(TOP_MENU_CD, SUB_MENU_CD, MENU_CD, USING_FLAG);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::sManu_UsingFlag  (Detail)::TOP_MENU_CD=[" + TOP_MENU_CD + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::sManu_UsingFlag  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        public int exMenuTop(string TOP_MENU_CD, string TOP_MENU_NM)
        {
            throw new NotImplementedException();
        }

        public int exMenuSub(string SUB_MENU_CD, string TOP_MENU_CD, string SUB_MENU_NM)
        {
            int reCnt = 0;

            DbMenuMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbMenuMainDB(dbCon_IP, dbCon_DB, dbCon_USER);
                reCnt = db.exMenuSub(SUB_MENU_CD, TOP_MENU_CD, SUB_MENU_NM);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::exSubMenuCd  (Detail)::TOP_MENU_CD=[" + SUB_MENU_CD + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::exSubMenuCd  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int exMenu(string MENU_CD, string TOP_MENU_CD, string SUB_MENU_CD, string MENU_NM)
        {
            int reCnt = 0;

            DbMenuMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbMenuMainDB(dbCon_IP, dbCon_DB, dbCon_USER);
                reCnt = db.exMenu(MENU_CD, TOP_MENU_CD, SUB_MENU_CD, MENU_NM);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::exMenu  (Detail)::MENU_CD=[" + MENU_CD + "]" +
                 ", TOP_MENU_CD=[" + TOP_MENU_CD + "], SUB_MENU_CD=[" + SUB_MENU_CD + "], MENU_NM=[" + MENU_NM + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::exMenu  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int aMenuTop(string TOP_MENU_NM, string APP_FLAG, string USING_FLAG, string SORT_NO, string INPUT_ID)
        {
            int reCnt = 0;

            DbMenuMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbMenuMainDB(dbCon_IP, dbCon_DB, dbCon_USER);
                reCnt = db.aMenuTop(TOP_MENU_NM, APP_FLAG, USING_FLAG, SORT_NO, INPUT_ID);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::aMenuTop  (Detail)::, TOP_MENU_NM=[" + TOP_MENU_NM + "], APP_FLAG=[" + APP_FLAG + "]" +
                    ", USING_FLAG=[" + USING_FLAG + "], SORT_NO=[" + SORT_NO + "], INPUT_ID=[" + INPUT_ID + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::aMenuTop  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int aMenuSub(string TOP_MENU_CD, string SUB_MENU_NM, string USING_FLAG, string SORT_NO, string INPUT_ID)
        {
            int reCnt = 0;

            DbMenuMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbMenuMainDB(dbCon_IP, dbCon_DB, dbCon_USER);
                reCnt = db.aMenuSub(TOP_MENU_CD, SUB_MENU_NM, USING_FLAG, SORT_NO, INPUT_ID);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::aMenuSub  (Detail)::, TOP_MENU_CD=[" + TOP_MENU_CD + "], SUB_MENU_NM=[" + SUB_MENU_NM + "]" +
                    ", USING_FLAG=[" + USING_FLAG + "], SORT_NO=[" + SORT_NO + "], INPUT_ID=[" + INPUT_ID + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::aMenuSub  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }

        public int aMenu(string MENU_CD, string TOP_MENU_CD, string SUB_MENU_CD, string MENU_NM, string USING_FLAG, string SORT_NO, string INPUT_ID)
        {
            int reCnt = 0;

            DbMenuMainDB db = null;
            try
            {
                string dbCon_IP = WebConfigurationManager.ConnectionStrings["ConnectionStr_IP"].ConnectionString;
                string dbCon_DB = WebConfigurationManager.ConnectionStrings["ConnectionStr_DB"].ConnectionString;
                string dbCon_USER = WebConfigurationManager.ConnectionStrings["ConnectionStr_USER"].ConnectionString;

                db = new DbMenuMainDB(dbCon_IP, dbCon_DB, dbCon_USER);
                reCnt = db.aMenu(MENU_CD, TOP_MENU_CD, SUB_MENU_CD, MENU_NM, USING_FLAG, SORT_NO, INPUT_ID);
            }
            catch (Exception ex)
            {
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::aMenu  (Detail)::, MENU_CD=[" + MENU_CD + "], TOP_MENU_CD=[" + TOP_MENU_CD + "], SUB_MENU_CD=[" + SUB_MENU_CD + "]" +
                    ", MENU_NM=[" + MENU_NM + "], USING_FLAG =[" + USING_FLAG + "], SORT_NO=[" + SORT_NO + "], INPUT_ID=[" + INPUT_ID + "]", "Error");
                _logs.SaveLog("[error]  (page)::BizMenuMainDB.cs  (Function)::aMenu  (Detail)::" + "\r\n" + ex.ToString(), "Error");
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