using EldigmPlusDb.DbClass.Common;
using Framework.Data;
using System;
using System.Collections;
using System.Data;

namespace EldigmPlusClassLibrary.DbClass.Worker.InOut
{
    public class DbInOut
    {
        DataObj _sqlHelper = null;

        public DbInOut(string pCon_IP, string pCon_DB, string pCon_USER, string pType)
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

        public string sMyComFlag(string SITE_CD, string AUTH_CD)
        {
            string dbNm = "";
            dbNm = sDbNm(SITE_CD);
            string con = "[PLUS-" + dbNm + "].dbo.";

            string sql = "" +

            " SELECT MYCOM_FLAG FROM " + con + "T00_CODE_AUTH A " +
            " INNER JOIN " + con + "T00_CODE_AUTH_SITE B ON A.AUTH_CD = B.AUTH_CD " +
            " WHERE B.AUTH_CD = '" + AUTH_CD + "' AND B.SITE_CD = " + SITE_CD + " ";


            object reVal = null;

            if (_sqlHelper != null)
                reVal = _sqlHelper.ExecuteScalar(sql);

            return reVal.ToString();
        }

        //COMPANY CMB BOX 
        public DataSet sLaborCompanyList(string SITE_CD, int CO_CD)
        {
            string dbNm = sDbNm(SITE_CD);
            string con = "[PLUS-" + dbNm + "].dbo.";

            string sql = "" +

                    " SELECT CO_CD AS VALUE, CO_NM AS TEXT, SORT_NO " +
                    " FROM " + con + "View_Company " +
                    " WHERE SITE_CD = " + SITE_CD +
                    " AND USING_FLAG = 1 " +
                    " UNION ALL " +
                    " SELECT '0' AS VALUE, '전체' AS TEXT, '99999999' AS SORT_NO " +
                    " ORDER BY SORT_NO, TEXT ";

            //if (MYCOM_FLAG == 1)
            //    sql += " AND VALUE = " + CO_CD + " ";

            //sql += "" +
            //    " ORDER BY SORT_NO, TEXT ";

            DataSet ds = null;

            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }

        public DataSet co_Cmb(string SITE_CD)
        {
            string dbNm = sDbNm(SITE_CD);
            string con = "[PLUS-" + dbNm + "].dbo.";

            string sql = "" +
                " SELECT CO_CD AS VALUE, CO_NM AS TEXT, SORT_NO " +
                " FROM " + con + "T00_COMPANY " +
                " ORDER BY SORT_NO, TEXT ";


            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }

        public DataSet team_Cmb(string SITE_CD)
        {
            string dbNm = sDbNm(SITE_CD);
            string con = "[PLUS-" + dbNm + "].dbo.";

            string sql = "" +
                " SELECT TEAM_CD AS VALUE, TEAM_NM AS TEXT, SORT_NO " +
                " FROM " + con + "T00_TEAM_SITE " +
                " WHERE SITE_CD = 1 AND USING_FLAG = 1 " +
                " UNION ALL " +
                " SELECT '0' AS VALUE, '미선택' AS TEXT, '99999999' AS SORT_NO " +
                " ORDER BY SORT_NO, TEXT ";


            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }

        public DataSet sInOut(string DBNM, string SITE_CD, string DTP1, string DTP2, string CO_CD, string CMB_IO)
        {
            string sql;
            string con = "[PLUS-" + DBNM + "].dbo.";

            if (CMB_IO == "1")
            {
                sql = "" +
                " SELECT A.LAB_NO, A.REG_DATE, A.CO_CD, A.TEAM_CD, B.LAB_NM, A.IN_DT, ISNULL(A.OUT_DT, '') OUT_DT, C.CO_NM, ISNULL(D.TEAM_NM, '') TEAM_NM, " +
                " ISNULL(A.IN_IOPF_ID, '') IN_IOPF_ID, ISNULL(A.OUT_IOPF_ID, '') OUT_IOPF_ID, ISNULL(F.CCODE_NM, '') CCODE_NM " +
                " FROM (SELECT LAB_NO, REG_DATE, IN_DT, OUT_DT, CO_CD, TEAM_CD, DEV_IO_SCD, IN_IOPF_ID, OUT_IOPF_ID FROM " + con + "T01_INOUT_SITE " +
                " WHERE SITE_CD = " + SITE_CD + " AND REG_DATE >= '" + DTP1 + "' AND REG_DATE < '" + DTP2 + "') A " +
                " INNER JOIN " + con + "T01_LAB B ON A.LAB_NO = B.LAB_NO " +
                " INNER JOIN " + con + "T00_COMPANY C ON A.CO_CD = C.CO_CD " +
                " LEFT OUTER JOIN " + con + "T00_TEAM_SITE D ON A.TEAM_CD = D.TEAM_CD AND D.SITE_CD = " + SITE_CD +
                " INNER JOIN " + con + "T01_LAB_SITE_INFO E ON A.LAB_NO = E.LAB_NO AND E.SITE_CD = " + SITE_CD +
                " LEFT OUTER JOIN " + con + "T00_CODE_COMN F ON E.JOB_CCD = F.CCODE " +
                " WHERE A.LAB_NO IS NOT NULL ";
            }
            else
            {
                sql = "" +
                " SELECT A.LAB_NO, B.LAB_NM, ISNULL(A.CO_CD, '') CO_CD, ISNULL(A.TEAM_CD, '') TEAM_CD, C.CO_NM, ISNULL(D.TEAM_NM, '') TEAM_NM, ISNULL(E.CCODE_NM, '') CCODE_NM " +
                " FROM (SELECT * FROM " + con + "T01_LAB_SITE_INFO WHERE SITE_CD = " + SITE_CD + ") A " +
                " INNER JOIN " + con + "T01_LAB B ON A.LAB_NO = B.LAB_NO " +
                " INNER JOIN " + con + "T00_COMPANY C ON A.CO_CD = C.CO_CD " +
                " LEFT OUTER JOIN " + con + "T00_TEAM_SITE D ON A.TEAM_CD = D.TEAM_CD AND D.SITE_CD = " + SITE_CD +
                " LEFT OUTER JOIN " + con + "T00_CODE_COMN E ON A.JOB_CCD = E.CCODE " +
                " LEFT OUTER JOIN " + con + "T01_INOUT_SITE F ON A.LAB_NO = F.LAB_NO AND F.SITE_CD = " + SITE_CD + " AND F.REG_DATE = " + DTP1 + "" +
                " WHERE F.REG_DATE != " + DTP1 + " OR F.REG_DATE IS NULL ";
            }

            if (CO_CD != "0")
            {
                sql += "" +
                    " AND A.CO_CD = " + CO_CD + "";
            }
            sql += "" +
            " ORDER BY A.CO_CD, B.LAB_NM ";


            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }

        public DataSet sInOutHistory(string DBNM, string SITE_CD, string DTP1, string DTP2, string CO_CD)
        {
            string con = "[PLUS-" + DBNM + "].dbo.";
            string sql = "" +
                " SELECT B.LAB_NM, A.EVENT_DT, C.CO_NM, ISNULL(D.TEAM_NM, '') TEAM_NM, ISNULL(G.DEV_NM, '') DEV_NM, ISNULL(H.SCODE_NM, '') DEV_IO_NM, ISNULL(I.SCODE_NM, '') DEV_TYPE_NM, ISNULL(F.CCODE_NM, '') CCODE_NM  " +
                " FROM (SELECT LAB_NO, EVENT_DT, CO_CD, TEAM_CD, DEV_CD, DEV_TYPE_SCD, DEV_IO_SCD FROM " + con + "T01_INOUT_SITE_HISTORY " +
                " WHERE SITE_CD = " + SITE_CD + " AND EVENT_DT >= '" + DTP1 + "' AND EVENT_DT < '" + DTP2 + "') A " +
                " INNER JOIN " + con + "T01_LAB B ON A.LAB_NO = B.LAB_NO " +
                " INNER JOIN " + con + "T00_COMPANY C ON A.CO_CD = C.CO_CD " +
                " LEFT OUTER JOIN " + con + "T00_TEAM_SITE D ON A.TEAM_CD = D.TEAM_CD AND D.SITE_CD = " + SITE_CD +
                " INNER JOIN " + con + "T01_LAB_SITE_INFO E ON A.LAB_NO = E.LAB_NO AND E.SITE_CD = " + SITE_CD +
                " LEFT OUTER JOIN " + con + "T00_CODE_COMN F ON E.JOB_CCD = F.CCODE " +
                " LEFT OUTER JOIN " + con + "T00_DEVICE G ON A.DEV_CD = G.DEV_CD " +
                " LEFT OUTER JOIN [PLUS_MAIN].dbo.TM00_CODE_SYS H ON A.DEV_IO_SCD = H.SCODE AND H.SCODE_GRP = 'DevIO' " +
                " LEFT OUTER JOIN [PLUS_MAIN].dbo.TM00_CODE_SYS I ON A.DEV_TYPE_SCD = I.SCODE AND I.SCODE_GRP = 'DevType'";

            if (CO_CD != "0")
            {
                sql += "" +
                    " WHERE A.CO_CD = " + CO_CD + "";
            }

            sql += "" +
                " ORDER BY B.LAB_NM, A.EVENT_DT ";

            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }

        public int mInOut(string DBNM, string LAB_NO, string SITE_CD, string REG_DATE, string IN_DT, string OUT_DT, string CO_CD, string TEAM_CD)
        {
            string con = "[PLUS-" + DBNM + "].dbo.";
            string sql = "" +
               " UPDATE " + con + "T01_INOUT_SITE SET IN_DT = '" + IN_DT + "', OUT_DT = '" + OUT_DT + "', CO_CD = " + CO_CD + ", TEAM_CD = " + TEAM_CD + "" +
               " WHERE LAB_NO = " + LAB_NO + " AND SITE_CD = " + SITE_CD + " AND REG_DATE = " + REG_DATE + "";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

        public int aInOut(string DBNM, string LAB_NO, string SITE_CD, string REG_DATE, string IN_DT, string OUT_DT, string CO_CD, string TEAM_CD)
        {
            string con = "[PLUS-" + DBNM + "].dbo.";
            string sql = "";

            if (OUT_DT == null)
            {
                sql = "" +
                " INSERT INTO " + con + "T01_INOUT_SITE (LAB_NO, SITE_CD, REG_DATE, IN_DT, CO_CD, TEAM_CD) " +
                " VALUES (" + LAB_NO + ", " + SITE_CD + ", " + REG_DATE + ", '" + IN_DT + "', " + CO_CD + ", " + TEAM_CD + ") ";
            }
            else
            {
                sql = "" +
                " INSERT INTO " + con + "T01_INOUT_SITE (LAB_NO, SITE_CD, REG_DATE, IN_DT, OUT_DT, CO_CD, TEAM_CD) " +
                " VALUES (" + LAB_NO + ", " + SITE_CD + ", " + REG_DATE + ", '" + IN_DT + "', '" + OUT_DT + "', " + CO_CD + ", " + TEAM_CD + ") ";
            }

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

        public int aInOutLog(string DBNM, string LAB_NO, string SITE_CD, string REG_DATE, string IN_DT, string OUT_DT, string CO_CD, string TEAM_CD, string IN_IOPF_ID, string OUT_IOPF_ID, string INPUT_ID)
        {
            string con = "[PLUS-" + DBNM + "].dbo.";
            string sql = "" +
                " INSERT INTO " + con + "T01_INOUT_SITE_LOG (LAB_NO, SITE_CD, REG_DATE, LOG_NO, IN_DT, OUT_DT, CO_CD, TEAM_CD, " +
                " IN_IOPF_ID, OUT_IOPF_ID, INPUT_ID, INPUT_DT, DEL_FLAG) " +
                " VALUES (" + LAB_NO + ", " + SITE_CD + ", " + REG_DATE +
                ", (SELECT ISNULL(MAX(LOG_NO), 0) + 1 FROM " + con + "T01_INOUT_SITE_LOG WHERE LAB_NO = " + LAB_NO + " AND SITE_CD = " + SITE_CD + " AND REG_DATE = " + REG_DATE + "), " +
                "'" + IN_DT + "', '" + OUT_DT + "', " + CO_CD + ", " + TEAM_CD + ", " + IN_IOPF_ID + ", " + OUT_IOPF_ID + ", '" + INPUT_ID + "', GETDATE(), 0) ";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

        public int dInHistory(string DBNM, string LAB_NO, string SITE_CD, string REG_DATE, string EVENT_DT)
        {
            string con = "[PLUS-" + DBNM + "].dbo.";
            string sql = "" +
            " DELETE FROM " + con + "T01_INOUT_SITE_HISTORY " +
            " WHERE LAB_NO = " + LAB_NO + " AND SITE_CD = " + SITE_CD + " AND REG_DATE = " + REG_DATE + " AND EVENT_DT <= '" + EVENT_DT + "'";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

        public int dOutHistory(string DBNM, string LAB_NO, string SITE_CD, string REG_DATE, string EVENT_DT)
        {
            string con = "[PLUS-" + DBNM + "].dbo.";
            string sql = "" +
            " DELETE FROM " + con + "T01_INOUT_SITE_HISTORY " +
            " WHERE LAB_NO = " + LAB_NO + " AND SITE_CD = " + SITE_CD + " AND REG_DATE = " + REG_DATE + " AND EVENT_DT >= '" + EVENT_DT + "'";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

        public int mInOutHistory(string DBNM, string LAB_NO, string SITE_CD, string REG_DATE, string EVENT_DT, string EVENT_DT_H, string CO_CD, string TEAM_CD)
        {
            string con = "[PLUS-" + DBNM + "].dbo.";
            string sql = "" +
               " UPDATE " + con + "T01_INOUT_SITE_HISTORY SET EVENT_DT = '" + EVENT_DT + "', CO_CD = " + CO_CD + ", TEAM_CD = " + TEAM_CD + "" +
               " WHERE LAB_NO = '" + LAB_NO + "' AND SITE_CD = " + SITE_CD + " AND REG_DATE = " + REG_DATE + " AND EVENT_DT = '" + EVENT_DT_H + "'";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

        public int aInOutHistory(string DBNM, string LAB_NO, string SITE_CD, string REG_DATE, string EVENT_DT, string CO_CD, string TEAM_CD, string INPUT_ID)
        {
            string con = "[PLUS-" + DBNM + "].dbo.";
            string sql = "" +
               " INSERT INTO " + con + "T01_INOUT_SITE_HISTORY (LAB_NO, SITE_CD, REG_DATE, EVENT_DT, CO_CD, TEAM_CD, DEV_CD, INPUT_ID, INPUT_DT) " +
               " VALUES (" + LAB_NO + ", " + SITE_CD + ", " + REG_DATE + ", '" + EVENT_DT + "', " + CO_CD + ", " + TEAM_CD + ", 0, '" + INPUT_ID + "', GETDATE()) ";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }
        public string exInOutCo(string DBNM, string LAB_NO, string SITE_CD, string CO_CD)
        {
            string con = "[PLUS-" + DBNM + "].dbo.";
            string sql = "" +
            " SELECT ISNULL(EVENT_DT, 0) EVENT_DT FROM " + con + "T01_LAB_INOUT_CO " +
            " WHERE LAB_NO = " + LAB_NO + " AND SITE_CD = " + SITE_CD + " AND CO_CD = " + CO_CD + "";

            object reObj = 0;
            if (_sqlHelper != null)
                reObj = _sqlHelper.ExecuteScalar(sql);

            return Convert.ToString(reObj);
        }


        public int aInOutCo(string DBNM, string LAB_NO, string SITE_CD, string CO_CD, string EVENT_DT)
        {
            string con = "[PLUS-" + DBNM + "].dbo.";
            string sql = "" +
               " INSERT INTO " + con + "T01_LAB_INOUT_CO (LAB_NO, SITE_CD, CO_CD, EVENT_DT, INPUT_DT) " +
               " VALUES (" + LAB_NO + ", " + SITE_CD + ", " + CO_CD + ", '" + EVENT_DT + "', GETDATE()) ";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

        public int mInOutCo(string DBNM, string LAB_NO, string SITE_CD, string CO_CD, string EVENT_DT)
        {
            string con = "[PLUS-" + DBNM + "].dbo.";
            string sql = "" +
               " UPDATE " + con + "T01_LAB_INOUT_CO SET EVENT_DT = '" + EVENT_DT + "', INPUT_DT = GETDATE()" +
               " WHERE LAB_NO = " + LAB_NO + " AND SITE_CD = " + SITE_CD + " AND CO_CD = " + CO_CD + "";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

        public int exLabInOutFinal(string LAB_NO, string SITE_CD)
        {
            string sql = "" +
            " SELECT REG_DATE FROM PLUS_SUB.dbo.TS01_LAB_INOUT_SITE_FINAL " +
            " WHERE LAB_NO = " + LAB_NO + " AND SITE_CD = " + SITE_CD + "";

            object reObj = 0;
            if (_sqlHelper != null)
                reObj = _sqlHelper.ExecuteScalar(sql);

            return Convert.ToInt32(reObj);
        }

        public int mLabInOutFinal(string LAB_NO, string SITE_CD, string CO_CD, string TEAM_CD, string REG_DATE, string IN_HHMM, string OUT_HHMM)
        {
            string sql = "" +
               " UPDATE PLUS_SUB.dbo.TS01_LAB_INOUT_SITE_FINAL SET CO_CD = " + CO_CD + ", TEAM_CD = " + TEAM_CD + ", REG_DATE = " + REG_DATE + ", IN_HHMM = '" + IN_HHMM + "', OUT_HHMM = '" + OUT_HHMM + "'" +
               " WHERE LAB_NO = " + LAB_NO + " AND SITE_CD = " + SITE_CD + "";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

        public int aLabInOutFinal(string LAB_NO, string SITE_CD, string CO_CD, string TEAM_CD, string REG_DATE, string IN_HHMM, string OUT_HHMM)
        {
            string sql = "" +
               " INSERT INTO PLUS_SUB.dbo.TS01_LAB_INOUT_SITE_FINAL (LAB_NO, SITE_CD, CO_CD, TEAM_CD, REG_DATE, IN_HHMM, OUT_HHMM, INPUT_DT) " +
               " VALUES (" +LAB_NO + ", " + SITE_CD + ", " + CO_CD + ", " + TEAM_CD + ", " + REG_DATE + ", '" + IN_HHMM + "', '" + OUT_HHMM + "', GETDATE()) ";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

        public int exInOut2020(string LAB_NO, string SITE_CD, string REG_DATE)
        {
            string sql = "" +
            " SELECT LAB_NO FROM PLUS_SUB.dbo.TS01_LAB_INOUT_2020 " +
            " WHERE LAB_NO = " + LAB_NO + " AND SITE_CD = " + SITE_CD + " AND REG_DATE = " + REG_DATE + "";

            object reObj = 0;
            if (_sqlHelper != null)
                reObj = _sqlHelper.ExecuteScalar(sql);

            return Convert.ToInt32(reObj);
        }
        
        public int aInOut2020(string LAB_NO, string SITE_CD, string REG_DATE, string CO_CD, string TEAM_CD, string IN_HHMM, string OUT_HHMM)
        {
            string sql = "" +
               " INSERT INTO PLUS_SUB.dbo.TS01_LAB_INOUT_2020 (LAB_NO, SITE_CD, REG_DATE, CO_CD, TEAM_CD, IN_HHMM, OUT_HHMM, INPUT_DT) " +
               " VALUES (" + LAB_NO + ", " + SITE_CD + ", " + REG_DATE + ", " + CO_CD + ", " + TEAM_CD + ", '" + IN_HHMM + "', '" + OUT_HHMM + "', GETDATE()) ";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

        public int mInOut2020(string LAB_NO, string SITE_CD, string REG_DATE, string CO_CD, string TEAM_CD, string IN_HHMM, string OUT_HHMM)
        {
            string sql = "" +
               " UPDATE PLUS_SUB.dbo.TS01_LAB_INOUT_2020 SET CO_CD = " + CO_CD + ", TEAM_CD = " + TEAM_CD + ", IN_HHMM = '" + IN_HHMM + "', OUT_HHMM = '" + OUT_HHMM + "'" + 
               " WHERE LAB_NO = " + LAB_NO + " AND SITE_CD = " + SITE_CD + " AND REG_DATE = " + REG_DATE + "";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }


    }
}
