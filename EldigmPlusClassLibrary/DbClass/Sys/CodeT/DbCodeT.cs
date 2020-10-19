using EldigmPlusDb.DbClass.Common;
using Framework.Data;
using System;
using System.Collections;
using System.Data;

namespace EldigmPlusClassLibrary.DbClass.Sys.CodeT
{
    public class DbCodeT
    {
        DataObj _sqlHelper = null;

        public DbCodeT(string pCon_IP, string pCon_DB, string pCon_USER, string pType)
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

        public string sDbNm(string SITE_CD)
        {
            string sql = "" +

            " SELECT ISNULL(MAX(B.DB_NM), '') DB_NM " +
            " FROM [PLUS_MAIN].dbo.TM00_SITE A  " +
            " INNER JOIN [PLUS_MAIN].dbo.TM00_MEMCO B ON A.MEMCO_CD = B.MEMCO_CD " +
            " WHERE SITE_CD =" + SITE_CD + " ";

            object reVal = null;

            if (_sqlHelper != null)
                reVal = _sqlHelper.ExecuteScalar(sql);

            return reVal.ToString();
        }




        public DataSet sSysCode()
        {
            string sql = "" +
                " SELECT SCODE, SCODE_NM " +
                " FROM [PLUS_MAIN].dbo.TM00_CODE_SYS " +
                " WHERE SCODE_GRP = 'LabInfoType' AND USING_FLAG = 1 ";

            sql += "" +
                " ORDER BY SORT_NO, SCODE_NM ";

            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }

        public DataSet sCodeTTreeView(string SCODE)
        {
            string sql = "" +
                " SELECT TCODE, TCODE_NM FROM TM00_CODE_T WHERE TTYPE_SCD = '" + SCODE + "'";

            sql += "" +
                " ORDER BY TTYPE_SCD, TCODE_NM ";

            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }

        public DataSet sCodeT(string SCODE)
        {
            string sql = "" +
                " SELECT TCODE, TTYPE_SCD, TCODE_NM, LIST_FLAG, REQUIRED_FLAG, NUMERIC_FLAG FROM TM00_CODE_T WHERE TTYPE_SCD = '" + SCODE + "'";

            sql += "" +
                " ORDER BY TTYPE_SCD, TCODE_NM ";

            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }


        public DataSet sCodeTSubTreeView(string TCODE)
        {
            string sql = "" +
                " SELECT TCODE, TSCODE_NM FROM TM00_CODE_TSUB WHERE TCODE = '" + TCODE + "' ";

            sql += "" +
                " ORDER BY TCODE, USING_CNT ";

            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }

        public DataSet sCodeTSub(string TCODE)
        {
            string sql = "" +
                " SELECT TCODE, TSCODE_NM, USING_CNT FROM TM00_CODE_TSUB WHERE TCODE = '" + TCODE + "' ";

            sql += "" +
                " ORDER BY TCODE, USING_CNT ";

            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }

        public DataSet sCodeTSubTscode(string TCODE)
        {
            string sql = "" +
                " SELECT TSCODE, TSCODE_NM FROM TM00_CODE_TSUB WHERE TCODE = '" + TCODE + "' ";

            sql += "" +
                " ORDER BY TCODE, USING_CNT ";

            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }

        public int mCodeT(string TCODE, string LIST_FLAG, string REQUIRED_FLAG, string NUMERIC_FLAG)
        {
            string sql = "" +
                " UPDATE PLUS_MAIN.dbo.TM00_CODE_T SET LIST_FLAG = " + LIST_FLAG + ", REQUIRED_FLAG = " + REQUIRED_FLAG +
                ", NUMERIC_FLAG = " + NUMERIC_FLAG + " WHERE TCODE = '" + TCODE + "'";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

        public int aCodeTSiteLog(string DBNM, string SITE_CD, string TCODE, string TGRP_CCD, string REQUIRED_FLAG, string NUMERIC_FLAG, string DEFAULT_VALUE, string USING_FLAG, string SORT_NO, string MEMO, string INPUT_ID)
        {
            string sql = "" +
                " INSERT INTO [PLUS-" + DBNM + "].dbo.T00_CODE_T_SITE_LOG (SITE_CD, TCODE, LOG_NO, TGRP_CCD, REQUIRED_FLAG," +
                " NUMERIC_FLAG, DEFAULT_VALUE, USING_FLAG, SORT_NO, MEMO, INPUT_ID, INPUT_DT) VALUES (" + SITE_CD + ", '" + TCODE + "'," +
                " (SELECT ISNULL(MAX(LOG_NO),0)+1 FROM [PLUS-" + DBNM + "].dbo.T00_CODE_T_SITE_LOG WHERE SITE_CD = " + SITE_CD + " AND TCODE = '" + TCODE + "'), " +
                " " + TGRP_CCD + ", " + REQUIRED_FLAG + ", " + NUMERIC_FLAG + "," +
                " '" + DEFAULT_VALUE + "', " + USING_FLAG + ", " + SORT_NO + ", '" + MEMO + "', '" + INPUT_ID + "', GETDATE()) ";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

        public int exCodeT(string TCODE, string TCODE_NM)
        {
            string sql = "" +
                " SELECT COUNT(*) CNT FROM [PLUS_MAIN].dbo.TM00_CODE_T WHERE TCODE = '" + TCODE + "' AND TCODE_NM = '" + TCODE_NM + "' ";

            object reObj = 0;
            if (_sqlHelper != null)
                reObj = _sqlHelper.ExecuteScalar(sql);

            return Convert.ToInt16(reObj);
        }

        public int aCodeT(string TCODE, string TTYPE_SCD, string TCODE_NM, string LIST_FLAG, string REQUIRED_FLAG, string NUMERIC_FLAG, string INPUT_ID)
        {
            string sql = "" +
                " INSERT INTO [PLUS_MAIN].dbo.TM00_CODE_T (TCODE, TTYPE_SCD, TCODE_NM, LIST_FLAG, REQUIRED_FLAG, NUMERIC_FLAG, INPUT_ID, INPUT_DT) " +
                " VALUES ('" + TCODE + "', '" + TTYPE_SCD + "', '" + TCODE_NM + "', " + LIST_FLAG + ", '" + REQUIRED_FLAG + "', '" + NUMERIC_FLAG + "', '" + INPUT_ID + "', GETDATE()) ";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

        public int exCodeTSub(string TCODE, string TSCODE_NM)
        {
            string sql = "" +
                " SELECT COUNT(*) CNT FROM [PLUS_MAIN].dbo.TM00_CODE_TSUB WHERE TCODE = '" + TCODE + "' AND TSCODE_NM = '" + TSCODE_NM + "' ";

            object reObj = 0;
            if (_sqlHelper != null)
                reObj = _sqlHelper.ExecuteScalar(sql);

            return Convert.ToInt16(reObj);
        }

        public int aCodeTSub(string TCODE, string TSCODE_NM, string USING_CNT, string INPUT_ID)
        {
            string sql = "" +
                " INSERT INTO [PLUS_MAIN].dbo.TM00_CODE_TSUB (TCODE, TSCODE_NM, USING_CNT, INPUT_ID, INPUT_DT) " +
                " VALUES ('" + TCODE + "', '" + TSCODE_NM + "', " + USING_CNT + ", '" + INPUT_ID + "', GETDATE()) ";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

        public DataSet sCodeTSiteTreeView(string DBNM, string SITE_CD, string AUTH_CD)
        {
            string sql = "" +
                " SELECT A.CCODE, A.CCODE_NM FROM (SELECT A.CCODE, A.CCODE_GRP, A.CCODE_NM, B.SORT_NO " +
                " FROM [PLUS-" + DBNM + "].dbo.T00_CODE_COMN A INNER JOIN [PLUS-" + DBNM + "].dbo.T00_CODE_COMN_SITE B " +
                " ON A.CCODE = B.CCODE WHERE SITE_CD = " + SITE_CD + " AND CCODE_GRP = 'AddinfoGrp' AND USING_FLAG = 1) A " +
                " INNER JOIN (SELECT CCODE_GRP FROM [PLUS-" + DBNM + "].dbo.T00_CODE_GRP_SETAUTH_SITE WHERE SITE_CD = " + SITE_CD + "" +
                " AND AUTH_CD = '" + AUTH_CD + "' AND CCODE_GRP = 'AddinfoGrp' AND VIEW_FLAG = 1) B ON A.CCODE_GRP = B.CCODE_GRP ";

            sql += "" +
                " ORDER BY SORT_NO, A.CCODE_NM ";

            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }

       

        //**AUTH PART START
        public DataSet sCodeTAuthTreeView(string SCODE, string SITE_CD)
        {
            string dbNm = sDbNm(SITE_CD);            
        
            string sql = "" +
               " SELECT A.TCODE,B.TCODE_NM " +
               " FROM [PLUS-" + dbNm + "].dbo.T00_CODE_T_SITE A " +
               " INNER JOIN [PLUS-" + dbNm + "].dbo.T00_CODE_T B ON A.TCODE = B.TCODE AND A.USING_FLAG = 1 AND SITE_CD = " + SITE_CD + " " +
               " WHERE B.TTYPE_SCD = '" + SCODE + "' ";

            sql += "" +
                " ORDER BY A.SORT_NO, B.TCODE_NM ";

            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }

        
        //SELECT 
        public DataSet sCodeTAuth(string TCODE, string SITE_CD, string AUTH_CD )
        {
            string dbNm = sDbNm(SITE_CD);

            string sql = "" +
                " SELECT A.TCODE, A.AUTH_CD, B.TCODE_NM, A.VIEW_FLAG, A.NEW_FLAG, A.MODIFY_FLAG " +
                " FROM [PLUS-" + dbNm + "].dbo.T00_CODE_T_SETAUTH_SITE A" +
                " INNER JOIN [PLUS-" + dbNm + "].dbo.T00_CODE_T B ON A.TCODE = B.TCODE AND A.SITE_CD =" + SITE_CD + " " +
                " WHERE A.TCODE = '" + TCODE + "' AND A.AUTH_CD = '" + AUTH_CD + "' ";

            sql += "" +
                " ORDER BY A.AUTH_CD";

            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }


        //SELECT WHEN USER CLICK TTYPE_SCD 
        public DataSet sCodeTAuthTtype(string TTYPE_SCD, string SITE_CD, string AUTH_CD)
        {
            string dbNm = sDbNm(SITE_CD);

            string sql = "" +
               " SELECT A.TCODE, A.AUTH_CD, B.TCODE_NM, A.VIEW_FLAG, A.NEW_FLAG, A.MODIFY_FLAG " +
               " FROM [PLUS-" + dbNm + "].dbo.T00_CODE_T_SETAUTH_SITE A" +
               " INNER JOIN [PLUS-" + dbNm + "].dbo.T00_CODE_T B ON A.TCODE = B.TCODE AND A.SITE_CD = " + SITE_CD + " " +
               " WHERE B.TTYPE_SCD = '" + TTYPE_SCD + "' AND A.AUTH_CD = '" + AUTH_CD + "' ";
            sql += "" +
                " ORDER BY B.TCODE_NM, A.AUTH_CD";

            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }
        

        //MODIFY AUTH 
        public int mCodeTAuth(string TCODE, string SITE_CD, string AUTH_CD, string VIEW_FLAG, string NEW_FLAG, string MODIFY_FLAG)
        {
            string dbNm = sDbNm(SITE_CD);

            string sql = "" +
              " UPDATE [PLUS-" + dbNm + "].dbo.T00_CODE_T_SETAUTH_SITE " +
              " SET VIEW_FLAG = " + VIEW_FLAG + ", NEW_FLAG = " + NEW_FLAG + ", MODIFY_FLAG = " + MODIFY_FLAG + " " +
              " WHERE SITE_CD = " + SITE_CD + " AND TCODE = '" + TCODE + "' AND AUTH_CD = '" + AUTH_CD + "' ";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

        //**AUTH PART END


        public DataSet sCodeTSite(string DBNM, string SITE_CD, string TGRP_CCD)
        {
            string sql = "" +
                " SELECT A.TCODE, B.TCODE_NM, DEFAULT_VALUE, USING_FLAG, SORT_NO, MEMO FROM [PLUS-" + DBNM + "].dbo.T00_CODE_T_SITE A " +
                " INNER JOIN [PLUS-" + DBNM + "].dbo.T00_CODE_T B ON A.TCODE = B.TCODE " +
                " WHERE SITE_CD = " + SITE_CD + " AND TGRP_CCD = " + TGRP_CCD + "";

            sql += "" +
                " ORDER BY SORT_NO, B.TCODE_NM ";

            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }

        public int mCodeTSite(string DBNM, string SITE_CD, string TCODE, string DEFAULT_VALUE, string USING_FLAG, string SORT_NO, string MEMO)
        {
            string sql = "" +
                " UPDATE [PLUS-" + DBNM + "].dbo.T00_CODE_T_SITE SET DEFAULT_VALUE = '" + DEFAULT_VALUE + "', USING_FLAG = " + USING_FLAG +
                ", SORT_NO = " + SORT_NO + ", MEMO = '" + MEMO + "' WHERE SITE_CD = " + SITE_CD + " AND TCODE = '" + TCODE + "'";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

        public string aCodeTSite(Hashtable param, out Hashtable outVal)
        {
            string sql = "sp_CODE_T_New";

            object reObj = _sqlHelper.ExecuteCommandsp(sql, param, out outVal);

            return reObj.ToString();
        }

        public string aCodeTSubSite(Hashtable param, out Hashtable outVal)
        {
            string sql = "sp_CODE_TSUB_New";

            object reObj = _sqlHelper.ExecuteCommandsp(sql, param, out outVal);

            return reObj.ToString();
        }
        

    }
}
