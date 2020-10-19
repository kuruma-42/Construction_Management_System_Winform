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

        public DataSet sInOut(string DBNM, string SITE_CD, string DTP1, string DTP2)
        {
            string sql = "" +
                " SELECT A.LAB_NO, B.LAB_NM, A.IN_DT, A.OUT_DT, C.CO_NM, ISNULL(D.TEAM_NM, '') TEAM_NM, ISNULL(A.DEV_IO_SCD, '') DEV_IO_SCD, ISNULL(F.CCODE_NM, '') CODE_NM " +
                " FROM (SELECT A.LAB_NO, IN_DT, OUT_DT, CO_CD, TEAM_CD, DEV_IO_SCD FROM [PLUS-" + DBNM + "].dbo.T01_INOUT_SITE A " +
                " WHERE A.SITE_CD = " + SITE_CD + " AND REG_DATE >= '" + DTP1 + "' AND REG_DATE < '" + DTP2 + "') A " +
                " INNER JOIN [PLUS-" + DBNM + "].dbo.T01_LAB B ON A.LAB_NO = B.LAB_NO " +
                " INNER JOIN [PLUS-" + DBNM + "].dbo.T00_COMPANY C ON A.CO_CD = C.CO_CD " +
                " LEFT OUTER JOIN [PLUS-" + DBNM + "].dbo.T00_TEAM_SITE D ON A.TEAM_CD = D.TEAM_CD AND D.SITE_CD = " + SITE_CD +
                " INNER JOIN [PLUS-" + DBNM + "].dbo.T01_LAB_SITE_INFO E ON A.LAB_NO = E.LAB_NO AND E.SITE_CD = " + SITE_CD +
                " LEFT OUTER JOIN [PLUS-" + DBNM + "].dbo.T00_CODE_COMN F ON E.JOB_CCD = F.CCODE " +
                " ORDER BY B.LAB_NM, A.IN_DT ";
                

            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }

        public DataSet sInOutLog(string DBNM, string SITE_CD, string DTP1, string DTP2)
        {
            string sql = "" +
                " SELECT A.LAB_NO, B.LAB_NM, A.EVENT_DT, C.CO_NM, ISNULL(D.TEAM_NM, '') TEAM_NM, A.DEV_CD, A.DEV_TYPE_SCD, ISNULL(A.DEV_IO_SCD, '') DEV_IO_SCD, ISNULL(F.CCODE_NM, '') CODE_NM " +
                " FROM (SELECT A.LAB_NO, EVENT_DT, CO_CD, TEAM_CD, DEV_CD, DEV_TYPE_SCD, DEV_IO_SCD FROM [PLUS-" + DBNM + "].dbo.T01_INOUT_SITE_LOG A " +
                " WHERE A.SITE_CD = " + SITE_CD + " AND REG_DATE >= '" + DTP1 + "' AND REG_DATE < '" + DTP2 + "') A " +
                " INNER JOIN [PLUS-" + DBNM + "].dbo.T01_LAB B ON A.LAB_NO = B.LAB_NO " +
                " INNER JOIN [PLUS-" + DBNM + "].dbo.T00_COMPANY C ON A.CO_CD = C.CO_CD " +
                " LEFT OUTER JOIN [PLUS-" + DBNM + "].dbo.T00_TEAM_SITE D ON A.TEAM_CD = D.TEAM_CD AND D.SITE_CD = " + SITE_CD +
                " INNER JOIN [PLUS-" + DBNM + "].dbo.T01_LAB_SITE_INFO E ON A.LAB_NO = E.LAB_NO AND E.SITE_CD = " + SITE_CD +
                " LEFT OUTER JOIN [PLUS-" + DBNM + "].dbo.T00_CODE_COMN F ON E.JOB_CCD = F.CCODE " +
                " ORDER BY B.LAB_NM, A.EVENT_DT ";

            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }


    }
}
