using EldigmPlusDb.DbClass.Common;
using Framework.Data;
using System;
using System.Data;

namespace EldigmPlusClassLibrary.DbClass.Sys.Menu
{
    public class DbMenuMainDB
    {
        DataObj _sqlHelper = null;

        public DbMenuMainDB(string pCon_IP, string pCon_DB, string pCon_USER)
        {
            string mainKey_E256 = "6LL/J2V3x6N8kXK3qj5FOxZpRR20xWFlgnscFikXwy0=";

            EncDecClass edc = new EncDecClass();
            string mainKey_D256 = edc.AESDecrypt256(mainKey_E256, "eldigm");
            string strDbconn = pCon_IP + edc.AESDecrypt256(pCon_DB, mainKey_D256) + edc.AESDecrypt256(pCon_USER, mainKey_D256);

            _sqlHelper = new DataObj();
            _sqlHelper.SetConnect(strDbconn);
        }

        public void DisConnect()
        {
            if (_sqlHelper != null)
            {
                _sqlHelper.DisConnect();
                _sqlHelper = null;
            }
        }

        public DataSet sManuTopTreeView(string USING_FLAG)
        {
            string sql = "" +
                " SELECT TOP_MENU_CD, TOP_MENU_NM, APP_FLAG, USING_FLAG, SORT_NO " +
                " FROM [PLUS_MAIN].dbo.TM00_MENU_TOP ";

            if (USING_FLAG != "")
            {
                sql += " WHERE USING_FLAG = '" + USING_FLAG + "' ";
            }

            sql += "" +
                " ORDER BY SORT_NO, TOP_MENU_NM ";

            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }

        public DataSet sManuSubTreeView(string TOP_MENU_CD, string USING_FLAG)
        {
            string sql = "" +
                " SELECT SUB_MENU_CD, TOP_MENU_CD, SUB_MENU_NM, USING_FLAG, SORT_NO " +
                " FROM [PLUS_MAIN].dbo.TM00_MENU_SUB ";

            sql += " WHERE TOP_MENU_CD = " + TOP_MENU_CD + "";

            if (USING_FLAG != "")
            {
                sql += " AND USING_FLAG = '" + USING_FLAG + "' ";
            }

            sql += "" +
                " ORDER BY SORT_NO, SUB_MENU_NM ";

            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }

        public DataSet sManuTreeView(string TOP_MENU_CD, string SUB_MENU_CD, string USING_FLAG)
        {
            string sql = "" +
                " SELECT MENU_CD, TOP_MENU_CD, SUB_MENU_CD, MENU_NM, USING_FLAG, SORT_NO, ISNULL(MENU_PATH, '') MENU_PATH, ISNULL(FILE_FOLDER, '') FILE_FOLDER " +
                " FROM [PLUS_MAIN].dbo.TM00_MENU ";

            sql += " WHERE TOP_MENU_CD = " + TOP_MENU_CD + " AND SUB_MENU_CD = " + SUB_MENU_CD + "";

            if (USING_FLAG != "")
            {
                sql += " AND USING_FLAG = '" + USING_FLAG + "' ";
            }

            sql += "" +
                " ORDER BY SORT_NO, MENU_NM ";

            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }

        public DataSet sManuTreeView2(string TOP_MENU_CD, string SUB_MENU_CD, string MENU_CD, string USING_FLAG)
        {
            string sql = "" +
                " SELECT MENU_CD, TOP_MENU_CD, SUB_MENU_CD, MENU_NM, USING_FLAG, SORT_NO, ISNULL(MENU_PATH, '') MENU_PATH, ISNULL(FILE_FOLDER, '') FILE_FOLDER " +
                " FROM [PLUS_MAIN].dbo.TM00_MENU ";

            //if (USING_FLAG != "")
            sql += " WHERE TOP_MENU_CD = " + TOP_MENU_CD + " AND SUB_MENU_CD = " + SUB_MENU_CD + " AND MENU_CD = '" + MENU_CD + "'";

            if (USING_FLAG != "")
            {
                sql += " AND USING_FLAG = '" + USING_FLAG + "' ";
            }

            sql += "" +
                " ORDER BY SORT_NO, MENU_NM ";

            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }

        public int exMenuTop(string TOP_MENU_CD, string TOP_MENU_NM)
        {
            string sql = "" +
                 " SELECT COUNT(*) CNT " +
                 " FROM [PLUS_MAIN].dbo.TM00_MENU_TOP " +
                 " WHERE TOP_MENU_CD = '" + TOP_MENU_CD + "' AND TOP_MENU_NM = '" + TOP_MENU_NM + "'";

            object reObj = 0;
            if (_sqlHelper != null)
                reObj = _sqlHelper.ExecuteScalar(sql);

            return Convert.ToInt16(reObj);
        }

        public int exMenuSub(string SUB_MENU_CD, string TOP_MENU_CD, string SUB_MENU_NM)
        {
            string sql = "" +
                 " SELECT COUNT(*) CNT " +
                 " FROM [PLUS_MAIN].dbo.TM00_MENU_SUB " +
                 " WHERE SUB_MENU_CD = '" + SUB_MENU_CD + "' AND TOP_MENU_CD = '" + TOP_MENU_CD + "' AND SUB_MENU_NM = '" + SUB_MENU_NM + "'";

            object reObj = 0;
            if (_sqlHelper != null)
                reObj = _sqlHelper.ExecuteScalar(sql);

            return Convert.ToInt16(reObj);
        }

        public int exMenu(string MENU_CD, string TOP_MENU_CD, string SUB_MENU_CD, string MENU_NM)
        {
            string sql = "" +
                 " SELECT COUNT(*) CNT " +
                 " FROM [PLUS_MAIN].dbo.TM00_MENU " +
                 " WHERE MENU_CD = '" + MENU_CD + "' AND TOP_MENU_CD = '" + TOP_MENU_CD + "' AND SUB_MENU_CD = '" + SUB_MENU_CD + "' AND MENU_NM = '" + MENU_NM + "'";

            object reObj = 0;
            if (_sqlHelper != null)
                reObj = _sqlHelper.ExecuteScalar(sql);

            return Convert.ToInt16(reObj);
        }

        public int aMenuTop(string TOP_MENU_NM, string APP_FLAG, string USING_FLAG, string SORT_NO, string INPUT_ID)
        {
            string sql = "" +
                " INSERT INTO [PLUS_MAIN].dbo.TM00_MENU_TOP (TOP_MENU_NM, APP_FLAG, USING_FLAG, SORT_NO, INPUT_ID, INPUT_DT) " +
                " VALUES ('" + TOP_MENU_NM + "', " + APP_FLAG + ", " + USING_FLAG + ", '" + SORT_NO + "', " + INPUT_ID + ", GETDATE()) ";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

        public int aMenuSub(string TOP_MENU_CD, string SUB_MENU_NM, string USING_FLAG, string SORT_NO, string INPUT_ID)
        {
            string sql = "" +
                " INSERT INTO [PLUS_MAIN].dbo.TM00_MENU_SUB (TOP_MENU_CD, SUB_MENU_NM, USING_FLAG, SORT_NO, INPUT_ID, INPUT_DT) " +
                " VALUES (" + TOP_MENU_CD + ", '" + SUB_MENU_NM + "', " + USING_FLAG + ", '" + SORT_NO + "', '" + INPUT_ID + "', GETDATE()) ";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

        public int aMenu(string TOP_MENU_CD, string SUB_MENU_CD, string MENU_CD, string MENU_NM, string USING_FLAG, string SORT_NO, string INPUT_ID)
        {
            string sql = "" +
                " INSERT INTO [PLUS_MAIN].dbo.TM00_MENU (TOP_MENU_CD, SUB_MENU_CD, MENU_CD, MENU_NM, USING_FLAG, SORT_NO, INPUT_ID, INPUT_DT) " +
                " VALUES ('" + TOP_MENU_CD + "', '" + SUB_MENU_CD + "', '" + MENU_CD + "', '" + MENU_NM + "', " + USING_FLAG + ", '" + SORT_NO + "', '" + INPUT_ID + "', GETDATE()) ";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }




    }
}
