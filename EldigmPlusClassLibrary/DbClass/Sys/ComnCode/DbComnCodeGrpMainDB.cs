using EldigmPlusDb.DbClass.Common;
using Framework.Data;
using System;
using System.Collections;
using System.Data;

namespace EldigmPlusClassLibrary.DbClass.Sys.CommonCode
{
    public class DbComnCodeGrpMainDB
    {
        DataObj _sqlHelper = null;

        public DbComnCodeGrpMainDB(string pCon_IP, string pCon_DB, string pCon_USER, string pType)
        {
            string mainKey_E256 = "6LL/J2V3x6N8kXK3qj5FOxZpRR20xWFlgnscFikXwy0=";

            EncDecClass edc = new EncDecClass();
            string mainKey_D256 = edc.AESDecrypt256(mainKey_E256, "eldigm");
            string strDbconn = "";
            if (pType == "1")
                strDbconn = pCon_IP + pCon_DB + edc.AESDecrypt256(pCon_USER, mainKey_D256);
            else
                strDbconn = pCon_IP + edc.AESDecrypt256(pCon_DB, mainKey_D256) + edc.AESDecrypt256(pCon_USER, mainKey_D256);

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

        public DataSet sComnCodeGrp()
        {
            string sql = "" +
                " SELECT CCODE_GRP, CCODE_GRP_NM, USING_FLAG, SORT_NO, MEMO " +
                " FROM [PLUS_MAIN].dbo.TM00_CODE_COMN_GRP ";

            sql += "" +
                " ORDER BY SORT_NO, CCODE_GRP_NM ";

            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }

        public DataSet sComnCodeGrpUsingFlag()
        {
            string sql = "" +
                " SELECT CCODE_GRP, CCODE_GRP_NM, USING_FLAG, SORT_NO, MEMO " +
                " FROM [PLUS_MAIN].dbo.TM00_CODE_COMN_GRP " +
                " WHERE USING_FLAG = 1 ";

            sql += "" +
                " ORDER BY SORT_NO, CCODE_GRP_NM ";

            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }

        public int aComnCodeGrp(string CCODE_GRP, string CCODE_GRP_NM, string USING_FLAG, string SORT_NO, string MEMO, string INPUT_ID)
        {
            string sql = "" +
                " INSERT INTO [PLUS_MAIN].dbo.TM00_CODE_COMN_GRP (CCODE_GRP, CCODE_GRP_NM, USING_FLAG, SORT_NO, MEMO, INPUT_ID, INPUT_DT) " +
                " VALUES ('" + CCODE_GRP + "', '" + CCODE_GRP_NM + "', " + USING_FLAG + ", " + SORT_NO + ", '" + MEMO + "', '" + INPUT_ID + "', GETDATE()) ";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

        public int exComnCodeGrp(string CCODE_GRP)
        {
            string sql = "" +
                " SELECT COUNT(*) CNT " +
                " FROM [PLUS_MAIN].dbo.TM00_CODE_COMN_GRP " +
                " WHERE CCODE_GRP = '" + CCODE_GRP + "' ";

            object reObj = 0;
            if (_sqlHelper != null)
                reObj = _sqlHelper.ExecuteScalar(sql);

            return Convert.ToInt16(reObj);
        }

        public int mComnCodeGrp(string CCODE_GRP, string CCODE_GRP_NM, string USING_FLAG, string SORT_NO, string MEMO)
        {
            string sql = "" +
                " UPDATE [PLUS_MAIN].dbo.TM00_CODE_COMN_GRP SET CCODE_GRP_NM = '" + CCODE_GRP_NM + "', USING_FLAG = " + USING_FLAG + ", SORT_NO = " + SORT_NO + ", MEMO = '" + MEMO + "' " +
                " WHERE CCODE_GRP = '" + CCODE_GRP + "' ";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

        public string siteDbNm(string SITE_CD)
        {
            string sql = "" +
                " SELECT ISNULL(MAX(A.DB_NM), '') DB_NM " +
                " FROM [PLUS_MAIN].dbo.TM00_MEMCO A " +
                " INNER JOIN[PLUS_MAIN].dbo.TM00_SITE B ON A.MEMCO_CD = B.MEMCO_CD ";

            sql += "" +
            "WHERE SITE_CD = '" + SITE_CD + "' ";

            object reVal = null;

            if (_sqlHelper != null)
                reVal = _sqlHelper.ExecuteScalar(sql);

            return reVal.ToString();
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

        public DataSet sSetAuthSiteMemberDB(string DBNM, string SITE_CD, string AUTH_CD)
        {
            string sql = "" +
                 " SELECT A.CCODE_GRP, A.CCODE_GRP_NM, ISNULL(B.VIEW_FLAG, 0) VIEW_FLAG, ISNULL(B.NEW_FLAG, 0) NEW_FLAG, ISNULL(B.MODIFY_FLAG, 0) MODIFY_FLAG, " +
                 " ISNULL(B.DEL_FLAG, 0) DEL_FLAG, ISNULL(B.REPORT_FLAG, 0) REPORT_FLAG, ISNULL(B.PRINT_FLAG, 0) PRINT_FLAG, ISNULL(B.DOWNLOAD_FLAG, 0) DOWNLOAD_FLAG " +
                 " FROM [PLUS_MAIN].dbo.TM00_CODE_COMN_GRP A LEFT OUTER JOIN [PLUS-" + DBNM + "].dbo.T00_CODE_GRP_SETAUTH_SITE B " +
                 " ON A.CCODE_GRP = B.CCODE_GRP AND B.SITE_CD = " + SITE_CD + " AND B.AUTH_CD = '" + AUTH_CD + "'" +
                 " WHERE A.USING_FLAG = 1 ";

            sql += "" +
              " ORDER BY A.SORT_NO, A.CCODE_GRP_NM ";



            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }

        public DataSet sSetAuthSiteMemberDBSub(string CCODE_GRP, string DBNM, string SITE_CD, string AUTH_CD)
        {
            string sql = "" +
                 " SELECT A.CCODE_GRP, A.CCODE_GRP_NM, ISNULL(B.VIEW_FLAG, 0) VIEW_FLAG, ISNULL(B.NEW_FLAG, 0) NEW_FLAG, ISNULL(B.MODIFY_FLAG, 0) MODIFY_FLAG, " +
                 " ISNULL(B.DEL_FLAG, 0) DEL_FLAG, ISNULL(B.REPORT_FLAG, 0) REPORT_FLAG, ISNULL(B.PRINT_FLAG, 0) PRINT_FLAG, ISNULL(B.DOWNLOAD_FLAG, 0) DOWNLOAD_FLAG " +
                 " FROM [PLUS_MAIN].dbo.TM00_CODE_COMN_GRP A LEFT OUTER JOIN [PLUS-" + DBNM + "].dbo.T00_CODE_GRP_SETAUTH_SITE B " +
                 " ON A.CCODE_GRP = B.CCODE_GRP AND B.SITE_CD = " + SITE_CD + " AND B.AUTH_CD = '" + AUTH_CD + "'" +
                 " WHERE A.USING_FLAG = 1 AND A.CCODE_GRP = '" + CCODE_GRP + "'";

            sql += "" +
              " ORDER BY A.SORT_NO, A.CCODE_GRP_NM ";



            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }

        public int mSetAuthSiteMemberDB(string DBNM, string SITE_CD, string AUTH_CD, string CCODE_GRP, string VIEW_FLAG, string NEW_FLAG, string MODIFY_FLAG, string DEL_FLAG, string REPORT_FLAG, string PRINT_FLAG, string DOWNLOAD_FLAG)
        {
            string sql = "" +
            " UPDATE [PLUS-" + DBNM + "].dbo.T00_CODE_GRP_SETAUTH_SITE SET VIEW_FLAG = " + VIEW_FLAG + ", NEW_FLAG = " + NEW_FLAG + "," +
            " MODIFY_FLAG = " + MODIFY_FLAG + "," + " DEL_FLAG = " + DEL_FLAG + ", REPORT_FLAG = " + REPORT_FLAG + "," +
            " PRINT_FLAG = " + PRINT_FLAG + ", DOWNLOAD_FLAG = " + DOWNLOAD_FLAG + "" +
            " WHERE SITE_CD = '" + SITE_CD + "' AND AUTH_CD = '" + AUTH_CD + "' AND CCODE_GRP = '" + CCODE_GRP + "'";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

        public int aSetAuthSiteMemberDBLog(string DBNM, string SITE_CD, string AUTH_CD, string CCODE_GRP, string VIEW_FLAG, string NEW_FLAG, string MODIFY_FLAG, string DEL_FLAG, string REPORT_FLAG, string PRINT_FLAG, string DOWNLOAD_FLAG, string INPUT_ID)
        {
            string sql = "" +
                " INSERT INTO [PLUS-" + DBNM + "].dbo.T00_CODE_GRP_SETAUTH_SITE_LOG (SITE_CD, AUTH_CD, CCODE_GRP, LOG_NO, VIEW_FLAG," +
                " NEW_FLAG, MODIFY_FLAG, DEL_FLAG, REPORT_FLAG, PRINT_FLAG, DOWNLOAD_FLAG, INPUT_ID, INPUT_DT) " +
                " VALUES (" + SITE_CD + ", '" + AUTH_CD + "', '" + CCODE_GRP + "'," +
                " (SELECT ISNULL(MAX(LOG_NO),0)+1 FROM [PLUS-" + DBNM + "].dbo.T00_CODE_GRP_SETAUTH_SITE_LOG WHERE SITE_CD = " + SITE_CD + " AND CCODE_GRP = '" + CCODE_GRP + "' AND AUTH_CD = '" + AUTH_CD + "')," +
                " " + VIEW_FLAG + ", " + NEW_FLAG + ", " + MODIFY_FLAG + ", " + DEL_FLAG + ", " + REPORT_FLAG + "," +
                " " + PRINT_FLAG + ", " + DOWNLOAD_FLAG + ", '" + INPUT_ID + "', GETDATE()) ";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

        public int aSetAuthSiteMemberDB(string DBNM, string SITE_CD, string AUTH_CD, string CCODE_GRP, string VIEW_FLAG, string NEW_FLAG, string MODIFY_FLAG, string DEL_FLAG, string REPORT_FLAG, string PRINT_FLAG, string DOWNLOAD_FLAG, string INPUT_ID)
        {
            string sql = "" +
                " INSERT INTO [PLUS-" + DBNM + "].dbo.T00_CODE_GRP_SETAUTH_SITE (SITE_CD, AUTH_CD, CCODE_GRP, VIEW_FLAG," +
                " NEW_FLAG, MODIFY_FLAG, DEL_FLAG, REPORT_FLAG, PRINT_FLAG, DOWNLOAD_FLAG, INPUT_ID, INPUT_DT) " +
                " VALUES (" + SITE_CD + ", '" + AUTH_CD + "', '" + CCODE_GRP + "'," +
                " " + VIEW_FLAG + ", " + NEW_FLAG + ", " + MODIFY_FLAG + ", " + DEL_FLAG + ", " + REPORT_FLAG + "," +
                " " + PRINT_FLAG + ", " + DOWNLOAD_FLAG + ", '" + INPUT_ID + "', GETDATE()) ";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

        public DataSet sComnSiteTreeView(string DBNM, string SITE_CD, string AUTH_CD)
        {
            string sql = "" +
                 " SELECT A.NEW_FLAG, A.MODIFY_FLAG, A.DEL_FLAG, B.CCODE_GRP, B.CCODE_GRP_NM FROM ( SELECT CCODE_GRP, NEW_FLAG, MODIFY_FLAG, DEL_FLAG " +
                 " FROM [PLUS-" + DBNM + "].dbo.T00_CODE_GRP_SETAUTH_SITE " +
                 " WHERE SITE_CD = 1 AND AUTH_CD = 'SysAdmin' AND VIEW_FLAG = 1 ) A INNER JOIN " +
                 " ( SELECT CCODE_GRP, CCODE_GRP_NM FROM [PLUS_MAIN].dbo.TM00_CODE_COMN_GRP WHERE USING_FLAG = 1 ) B " +
                 " ON A.CCODE_GRP = B.CCODE_GRP " +
                 " ORDER BY B.CCODE_GRP_NM, B.CCODE_GRP ";
            
            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }

        public DataSet sComnSite(string DBNM, string SITE_CD, string CCODE_GRP, string USING_FLAG, string CCODE_NM)
        {
            string sql = "" +
                " SELECT * FROM [PLUS-" + DBNM + "].dbo.View_Code_Comn " +
                " WHERE CCODE_GRP = '" + CCODE_GRP + "' AND SITE_CD = " + SITE_CD;
            
            if (USING_FLAG != "")
            {
                sql += " AND USING_FLAG = '" + USING_FLAG + "' ";
            }
            if (CCODE_NM != "")
            {
                sql += " AND CCODE_NM LIKE '%" + CCODE_NM + "%' ";
            }

            sql += "" +
                " ORDER BY SORT_NO, CCODE_NM ";

            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }

        public int mComnSite(string DBNM, string SITE_CD, string CCODE, string USING_FLAG, string SORT_NO, string MEMO)
        {
            string sql = "" +
            " UPDATE [PLUS-" + DBNM + "].dbo.T00_CODE_COMN_SITE SET USING_FLAG = " + USING_FLAG + ", SORT_NO = " + SORT_NO + "," +
            " MEMO = '" + MEMO + "' WHERE SITE_CD = " + SITE_CD + " AND CCODE = " + CCODE + "";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }
        
        public int aComnSiteLog(string DBNM, string SITE_CD, string CCODE, string USING_FLAG, string SORT_NO, string MEMO, string INPUT_ID)
        {
            string sql = "" +
                " INSERT INTO [PLUS-" + DBNM + "].dbo.T00_CODE_COMN_SITE_LOG (SITE_CD, CCODE, LOG_NO, USING_FLAG, SORT_NO, MEMO, INPUT_ID, INPUT_DT) " +
                " VALUES (" + SITE_CD + ", " + CCODE + "," +
                " (SELECT ISNULL(MAX(LOG_NO),0)+1 FROM [PLUS-" + DBNM + "].dbo.T00_CODE_COMN_SITE_LOG WHERE SITE_CD = " + SITE_CD + " AND CCODE = '" + CCODE + "')," +
                " " + USING_FLAG + ", " + SORT_NO + ", '" + MEMO + "', " + INPUT_ID + ", GETDATE())";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

        public string aComnSite(Hashtable param, out Hashtable outVal)
        {
            string sql = "sp_CODE_COMN_New";

            object reObj = _sqlHelper.ExecuteCommandsp(sql, param, out outVal);

            return reObj.ToString();
        }

    }
}
