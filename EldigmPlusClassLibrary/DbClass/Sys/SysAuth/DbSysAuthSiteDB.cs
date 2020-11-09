using EldigmPlusDb.DbClass.Common;
using Framework.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldigmPlusClassLibrary.DbClass.Sys.SysAuth
{
    public class DbSysAuthSiteDB
    {
        DataObj _sqlHelper = null;

        public DbSysAuthSiteDB(string pCon_IP, string pCon_DB, string pCon_USER)
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



        //Site -> DBNM : MEMCO INNER JOIN WITH SITE
        public string siteDbNm(string SITE_CD)
        {
            string sql = "" +
                " SELECT ISNULL(MAX(A.DB_NM), '') DB_NM " +
                " FROM[PLUS_MAIN].dbo.TM00_MEMCO A " +
                " INNER JOIN[PLUS_MAIN].dbo.TM00_SITE B ON A.MEMCO_CD = B.MEMCO_CD ";

            sql += "" +
            "WHERE SITE_CD = '" + SITE_CD + "' ";

            object reVal = null;

            if (_sqlHelper != null)
                reVal = _sqlHelper.ExecuteScalar(sql);

            return reVal.ToString();
        }

        //COMBO BOX -> SITE_CD, SITE_NM
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



        //SELECT
        public DataSet sSysAuthSiteDB(string SITE_CD, string DBNM, string USING_FLAG)
        {
            string con = "[PLUS-" + DBNM + "].dbo.";
            string sql = "" +
                " SELECT A.AUTH_CD, A.AUTH_NM, A.AUTH_LEVEL, ISNULL(B.LAB_APRV_FLAG, 0) LAB_APRV_FLAG, ISNULL(B.USING_FLAG, 0) USING_FLAG, ISNULL(B.MEMO, '') MEMO " +
                " FROM[PLUS-ELDIGM].dbo.T00_CODE_AUTH A " +
                " LEFT OUTER JOIN" + con + "T00_CODE_AUTH_SITE B ON A.AUTH_CD = B.AUTH_CD AND B.SITE_CD =" + SITE_CD + " ";

            if (USING_FLAG != "")
            {
                sql += " WHERE B.USING_FLAG = '" + USING_FLAG + "' ";
            }

            sql += "" +
           " ORDER BY A.AUTH_LEVEL, A.AUTH_NM ";

            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }

        //수정
        public int mSysAuthSiteDB(string DBNM, string SITE_CD ,string AUTH_CD, string LAB_APRV_FLAG, string USING_FLAG, string MEMO)
        {
            string con = "[PLUS-" + DBNM + "].dbo.";
            string sql = "" + 
            " UPDATE " + con + "T00_CODE_AUTH_SITE SET LAB_APRV_FLAG = " + LAB_APRV_FLAG + ", USING_FLAG = " + USING_FLAG + ", MEMO = '" + MEMO + "' " +
            " WHERE SITE_CD = " + SITE_CD + " AND AUTH_CD = '" + AUTH_CD + "' ";


            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }
               


        //AUTH_SITE INSERT
        public int aSysAuthSiteDB(string DBNM, string SITE_CD ,string AUTH_CD, string LAB_APRV_FLAG, string USING_FLAG, string AUTH_LEVEL, string MEMO, string INPUT_ID)
        {
            string con = "[PLUS-" + DBNM + "].dbo.";
            string sql = "" +
                " INSERT INTO " + con + "T00_CODE_AUTH_SITE (SITE_CD, AUTH_CD, LAB_APRV_FLAG, USING_FLAG, AUTH_LEVEL, MEMO, INPUT_ID, INPUT_DT) " +
                " VALUES (" + SITE_CD + ", '" + AUTH_CD + "', " + LAB_APRV_FLAG + ", "  + USING_FLAG + ", " + AUTH_LEVEL + ", '" + MEMO + "', " + INPUT_ID + ", GETDATE()) ";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

    }
}