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

        public DataSet sMenuTopTreeView()
        {
            string sql = "" +
                " SELECT TOP_MENU_CD, TOP_MENU_NM, APP_FLAG, USING_FLAG, SORT_NO " +
                " FROM [PLUS_MAIN].dbo.TM00_MENU_TOP ";

            sql += "" +
                " ORDER BY SORT_NO, TOP_MENU_NM ";

            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }

        public DataSet sMenuSubTreeView(string TOP_MENU_CD)
        {
            string sql = "" +
                " SELECT SUB_MENU_CD, TOP_MENU_CD, SUB_MENU_NM, USING_FLAG, SORT_NO " +
                " FROM [PLUS_MAIN].dbo.TM00_MENU_SUB ";

            sql += " WHERE TOP_MENU_CD = " + TOP_MENU_CD + "";

            sql += "" +
                " ORDER BY SORT_NO, SUB_MENU_NM ";

            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }

        public DataSet sMenuTreeView(string TOP_MENU_CD, string SUB_MENU_CD)
        {
            string sql = "" +
                " SELECT MENU_CD, TOP_MENU_CD, SUB_MENU_CD, MENU_NM, USING_FLAG, SORT_NO, ISNULL(MENU_PATH, '') MENU_PATH, ISNULL(FILE_FOLDER, '') FILE_FOLDER " +
                " FROM [PLUS_MAIN].dbo.TM00_MENU ";

            sql += " WHERE TOP_MENU_CD = " + TOP_MENU_CD + " AND SUB_MENU_CD = " + SUB_MENU_CD + "";

            sql += "" +
                " ORDER BY SORT_NO, MENU_NM ";

            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }

        public DataSet sMenuTreeView2(string TOP_MENU_CD, string SUB_MENU_CD, string MENU_CD)
        {
            string sql = "" +
                " SELECT MENU_CD, TOP_MENU_CD, SUB_MENU_CD, MENU_NM, USING_FLAG, SORT_NO, ISNULL(MENU_PATH, '') MENU_PATH, ISNULL(FILE_FOLDER, '') FILE_FOLDER " +
                " FROM [PLUS_MAIN].dbo.TM00_MENU ";

            sql += " WHERE TOP_MENU_CD = " + TOP_MENU_CD + " AND SUB_MENU_CD = " + SUB_MENU_CD + " AND MENU_CD = '" + MENU_CD + "'";

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

        public int exMenu(string MENU_CD, string TOP_MENU_CD, string SUB_MENU_CD)
        {
            string sql = "" +
                 " SELECT COUNT(*) CNT " +
                 " FROM [PLUS_MAIN].dbo.TM00_MENU " +
                 " WHERE MENU_CD = '" + MENU_CD + "' AND TOP_MENU_CD = '" + TOP_MENU_CD + "' AND SUB_MENU_CD = '" + SUB_MENU_CD + "'";

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

        public int aMenu(string TOP_MENU_CD, string SUB_MENU_CD, string MENU_CD, string MENU_NM, string USING_FLAG, string SORT_NO, string MENU_PATH, string FILE_FOLDER, string INPUT_ID)
        {
            string sql = "" +
                " INSERT INTO [PLUS_MAIN].dbo.TM00_MENU (TOP_MENU_CD, SUB_MENU_CD, MENU_CD, MENU_NM, USING_FLAG, SORT_NO, MENU_PATH, FILE_FOLDER, INPUT_ID, INPUT_DT) " +
                " VALUES ('" + TOP_MENU_CD + "', '" + SUB_MENU_CD + "', '" + MENU_CD + "', '" + MENU_NM + "', " + USING_FLAG + ", '" + SORT_NO + "', '" + MENU_PATH + "', '" + FILE_FOLDER + "', '" + INPUT_ID + "', GETDATE()) ";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

        public int mMenuTop(string TOP_MENU_CD, string USING_FLAG, string SORT_NO)
        {
            string sql = "" +
               " UPDATE [PLUS_MAIN].dbo.TM00_MENU_TOP SET USING_FLAG = '" + USING_FLAG + "', SORT_NO = " + SORT_NO +
                " WHERE TOP_MENU_CD = '" + TOP_MENU_CD + "'";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

        public int mMenuSub(string TOP_MENU_CD, string SUB_MENU_CD, string USING_FLAG, string SORT_NO)
        {
            string sql = "" +
                " UPDATE [PLUS_MAIN].dbo.TM00_MENU_SUB SET USING_FLAG = '" + USING_FLAG + "', SORT_NO = " + SORT_NO +
                " WHERE TOP_MENU_CD = '" + TOP_MENU_CD + "' AND SUB_MENU_CD = '" + SUB_MENU_CD + "'";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

        public int mMenu(string TOP_MENU_CD, string SUB_MENU_CD, string MENU_CD, string USING_FLAG, string SORT_NO, string MENU_PATH, string FILE_FOLDER)
        {
            string sql = "" +
                " UPDATE [PLUS_MAIN].dbo.TM00_MENU SET USING_FLAG = " + USING_FLAG + ", SORT_NO = " + SORT_NO + ", MENU_PATH = '" + MENU_PATH + "', FILE_FOLDER = '" + FILE_FOLDER + "'" +
                " WHERE TOP_MENU_CD = '" + TOP_MENU_CD + "' AND SUB_MENU_CD = '" + SUB_MENU_CD + "' AND MENU_CD = '" + MENU_CD + "' ";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

        public DataSet sMenu(string TOP_MENU_CD, string SUB_MENU_CD)
        {
            string sql = "" +
                " SELECT MENU_CD, TOP_MENU_CD, SUB_MENU_CD, MENU_NM, USING_FLAG, SORT_NO, ISNULL(MENU_PATH, '') MENU_PATH, ISNULL(FILE_FOLDER, '') FILE_FOLDER " +
                " FROM [PLUS_MAIN].dbo.TM00_MENU ";

            sql += " WHERE TOP_MENU_CD = " + TOP_MENU_CD + " AND SUB_MENU_CD = " + SUB_MENU_CD + "";

            sql += "" +
                " ORDER BY SORT_NO, MENU_NM ";

            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }

        public DataSet sSiteMainDB(string MEMCO_CD)
        {
            string sql = "" +
                 " SELECT SITE_CD, SITE_NM " +
                 " FROM [PLUS_MAIN].dbo.TM00_SITE " +
                 " WHERE USING_FLAG = 1 AND MEMCO_CD = " + MEMCO_CD + " ";

            sql += "" +
              " ORDER BY SORT_NO, SITE_NM ";



            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }



        //Site -> DBNM : MEMCO INNER JOIN WITH SITE
        public string siteDbNm(string SITE_CD)
        {
            string sql = "" +
                " SELECT ISNULL(MAX(A.DB_NM), '') DB_NM " +
                " FROM [PLUS_MAIN].dbo.TM00_MEMCO A " +
                " INNER JOIN[PLUS_MAIN].dbo.TM00_SITE B ON A.MEMCO_CD = B.MEMCO_CD " +
                " WHERE SITE_CD = " + SITE_CD + "";

            object reVal = null;

            if (_sqlHelper != null)
                reVal = _sqlHelper.ExecuteScalar(sql);

            return reVal.ToString();
        }

        //SELECT
        public DataSet sMenuMemberDB(string DBNM, string SITE_CD, string TOP_MENU_CD, string SUB_MENU_CD)
        {
            string sql = "" +
               " SELECT A.MENU_CD, A.MENU_NM, A.TOP_MENU_CD, A.SUB_MENU_CD, ISNULL(B.USING_FLAG, 0) USING_FLAG, " +
               " CASE WHEN B.MENU_CD IS NOT NULL THEN B.SORT_NO ELSE A.SORT_NO END SORT_NO, " +
               " ISNULL(A.MENU_PATH, '') MENU_PATH, ISNULL(A.FILE_FOLDER, '') FILE_FOLDER, ISNULL(B.MEMO, '') MEMO " +
               " FROM [PLUS_MAIN].dbo.TM00_MENU A " +
               " LEFT OUTER JOIN [PLUS-" + DBNM + "].dbo.T00_MENU_SITE B ON A.MENU_CD = B.MENU_CD AND B.SITE_CD = " + SITE_CD +
               " WHERE A.TOP_MENU_CD = " + TOP_MENU_CD + " AND A.SUB_MENU_CD = " + SUB_MENU_CD +
               " ORDER BY A.SORT_NO, A.MENU_NM ";

            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }

        public int mMenuMemberDB(string DBNM, string SITE_CD, string MENU_CD, string USING_FLAG, string SORT_NO, string MEMO)
        {
            string sql = "" +
                " UPDATE [PLUS-" + DBNM + "].dbo.T00_MENU_SITE SET USING_FLAG =" + USING_FLAG + ", SORT_NO = " + SORT_NO + ", MEMO = '" + MEMO +
                "' WHERE MENU_CD = '" + MENU_CD + "' AND SITE_CD = " + SITE_CD + "";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

        public int aMenuMemberDB(string DBNM, string SITE_CD, string MENU_CD, string TOP_MENU_CD, string SUB_MENU_CD, string MENU_NM, string USING_FLAG, string SORT_NO, string MEMO, string INPUT_ID)
        {
            string sql = "" +
                " INSERT INTO [PLUS-" + DBNM + "].dbo.T00_MENU_SITE (SITE_CD, MENU_CD, TOP_MENU_CD, SUB_MENU_CD, MENU_NM, USING_FLAG, SORT_NO, MEMO, INPUT_ID, INPUT_DT) " +
                " VALUES ('" + SITE_CD + "', '" + MENU_CD + "', " + TOP_MENU_CD + ", " + SUB_MENU_CD + ", '" + MENU_NM + "', " + USING_FLAG + ", " + SORT_NO + ", '" + MEMO + "', '" + INPUT_ID + "', GETDATE()) ";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

        public DataSet sCodeAuthSiteMemberDB(string DBNM)
        {
            string sql = "" +
                 " SELECT B.AUTH_CD, A.AUTH_NM FROM [PLUS-" + DBNM + "].dbo.T00_CODE_AUTH A " +
                 " INNER JOIN [PLUS-" + DBNM + "].dbo.T00_CODE_AUTH_SITE B " +
                 " ON A.AUTH_CD = B.AUTH_CD AND B.USING_FLAG = 1 AND B.SITE_CD = 1 ";

            sql += "" +
              " ORDER BY B.AUTH_LEVEL, A.AUTH_NM ";



            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }

        public DataSet sSetAuthSiteMemberDB(string DBNM, string SITE_CD, string TOP_MENU_CD, string SUB_MENU_CD, string AUTH_CD)
        {
            string sql = "" +
                 " SELECT A.MENU_CD, A.MENU_NM, ISNULL(B.VIEW_FLAG, 0) VIEW_FLAG, ISNULL(B.NEW_FLAG, 0) NEW_FLAG, ISNULL(B.MODIFY_FLAG, 0) MODIFY_FLAG, " +
                 " ISNULL(B.DEL_FLAG, 0) DEL_FLAG, ISNULL(B.REPORT_FLAG, 0) REPORT_FLAG, ISNULL(B.PRINT_FLAG, 0) PRINT_FLAG, ISNULL(B.DOWNLOAD_FLAG, 0) DOWNLOAD_FLAG " +
                 " FROM [PLUS-" + DBNM + "].dbo.T00_MENU_SITE A LEFT OUTER JOIN [PLUS-" + DBNM + "].dbo.T00_MENU_SETAUTH_SITE B" +
                 " ON A.SITE_CD = B.SITE_CD AND A.MENU_CD = B.MENU_CD AND B.AUTH_CD = '" + AUTH_CD + "'" +
                 " WHERE A.SITE_CD = " + SITE_CD + " AND A.TOP_MENU_CD = " + TOP_MENU_CD + " AND A.SUB_MENU_CD = " + SUB_MENU_CD + "";

            sql += "" +
              " ORDER BY A.MENU_NM ";



            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }

        public int mSetAuthSiteMemberDB(string DBNM, string SITE_CD, string MENU_CD, string AUTH_CD, string VIEW_FLAG, string NEW_FLAG, string MODIFY_FLAG, string DEL_FLAG, string REPORT_FLAG, string PRINT_FLAG, string DOWNLOAD_FLAG)
        {
            string sql = "" +
            " UPDATE [PLUS-" + DBNM + "].dbo.T00_MENU_SETAUTH_SITE SET VIEW_FLAG = " + VIEW_FLAG + ", NEW_FLAG = " + NEW_FLAG + "," +
            " MODIFY_FLAG = " + MODIFY_FLAG + "," + " DEL_FLAG = " + DEL_FLAG + ", REPORT_FLAG = " + REPORT_FLAG + "," +
            " PRINT_FLAG = " + PRINT_FLAG + ", DOWNLOAD_FLAG = " + DOWNLOAD_FLAG + "" +
            " WHERE MENU_CD = '" + MENU_CD + "' AND AUTH_CD = '" + AUTH_CD + "' AND SITE_CD = '" + SITE_CD + "'";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }


        public int aSetAuthSiteMemberDBLog(string DBNM, string SITE_CD, string MENU_CD, string AUTH_CD, string VIEW_FLAG, string NEW_FLAG, string MODIFY_FLAG, string DEL_FLAG, string REPORT_FLAG, string PRINT_FLAG, string DOWNLOAD_FLAG, string INPUT_ID)
        {
            string sql = "" +
                " INSERT INTO [PLUS-" + DBNM + "].dbo.T00_MENU_SETAUTH_SITE_LOG (SITE_CD, MENU_CD, AUTH_CD, LOG_NO, VIEW_FLAG," +
                " NEW_FLAG, MODIFY_FLAG, DEL_FLAG, REPORT_FLAG, PRINT_FLAG, DOWNLOAD_FLAG, INPUT_ID, INPUT_DT) " +
                " VALUES (" + SITE_CD + ", '" + MENU_CD + "', '" + AUTH_CD + "'," +
                " (SELECT ISNULL(MAX(LOG_NO),0)+1 FROM [PLUS-" + DBNM + "].dbo.T00_MENU_SETAUTH_SITE_LOG WHERE SITE_CD = " + SITE_CD + " AND MENU_CD = '" + MENU_CD + "' AND AUTH_CD = '" + AUTH_CD + "')," +
                " " + VIEW_FLAG + ", " + NEW_FLAG + ", " + MODIFY_FLAG + ", " + DEL_FLAG + ", " + REPORT_FLAG + "," +
                " " + PRINT_FLAG + ", " + DOWNLOAD_FLAG + ", '" + INPUT_ID + "', GETDATE()) ";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }
        public int aSetAuthSiteMemberDB(string DBNM, string SITE_CD, string MENU_CD, string AUTH_CD, string VIEW_FLAG, string NEW_FLAG, string MODIFY_FLAG, string DEL_FLAG, string REPORT_FLAG, string PRINT_FLAG, string DOWNLOAD_FLAG, string INPUT_ID)
        {
            string sql = "" +
                " INSERT INTO [PLUS-" + DBNM + "].dbo.T00_MENU_SETAUTH_SITE (SITE_CD, MENU_CD, AUTH_CD, VIEW_FLAG," +
                " NEW_FLAG, MODIFY_FLAG, DEL_FLAG, REPORT_FLAG, PRINT_FLAG, DOWNLOAD_FLAG, INPUT_ID, INPUT_DT) " +
                " VALUES (" + SITE_CD + ", '" + MENU_CD + "', '" + AUTH_CD + "'," +
                " " + VIEW_FLAG + ", " + NEW_FLAG + ", " + MODIFY_FLAG + ", " + DEL_FLAG + ", " + REPORT_FLAG + "," +
                " " + PRINT_FLAG + ", " + DOWNLOAD_FLAG + ", '" + INPUT_ID + "', GETDATE()) ";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }



    }
}
