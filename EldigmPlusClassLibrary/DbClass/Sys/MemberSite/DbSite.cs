using EldigmPlusDb.DbClass.Common;
using Framework.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldigmPlusClassLibrary.DbClass.Sys.MemberSite
{
    public class DbSite
    {
        DataObj _sqlHelper = null;

        public DbSite(string pCon_IP, string pCon_DB, string pCon_USER, string pType)
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


        public DataSet sMemberMainDB()
        {
            string sql = "" +
               " SELECT MEMCO_CD, MEMCO_NM " +
               " FROM TM00_MEMCO " +
               " WHERE USING_FLAG =1 ";

            sql += "" +
                " ORDER BY SORT_NO, MEMCO_NM ";

            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }

        public string sDbNm(string MEMCO_CD)
        {
            string sql = "" +
                " SELECT ISNULL(MAX(DB_NM), '') DB_NM " +
                " FROM [PLUS_MAIN].dbo.TM00_MEMCO " +
                " WHERE MEMCO_CD = " + MEMCO_CD + " ";

            object reVal = null;

            if (_sqlHelper != null)
                reVal = _sqlHelper.ExecuteScalar(sql);

            return reVal.ToString();
        }



        //SELECT
        public DataSet sSite(string MEMCO_CD, string USING_FLAG)
        {
            string dbNm = sDbNm(MEMCO_CD);

            string sql = "" +
            " SELECT B.SITE_CD,B.MEMCO_CD,B.SITE_NM, ISNULL(A.USING_FLAG, 0) USING_FLAG, ISNULL(A.SORT_NO, 1) SORT_NO, ISNULL(A.MEMO, '') MEMO " +
            " FROM [PLUS_MAIN].dbo.TM00_SITE A " +
            " INNER JOIN [PLUS-" + dbNm + "].dbo.T00_SITE B ON A.SITE_CD = B.SITE_CD " +
            " WHERE A.MEMCO_CD = " + MEMCO_CD + " ";

            if (USING_FLAG != "")
            {
                sql += " AND A.USING_FLAG = '" + USING_FLAG + "' ";
            }

            sql += "" +
           " ORDER BY A.SORT_NO, B.SITE_NM ";

            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }

        //MODIFY
        public int mSite(string SITE_CD, string SITE_NM, string USING_FLAG, string SORT_NO, string MEMO)
        {
            string sql = "" +

                " UPDATE [PLUS_MAIN].dbo.TM00_SITE " +
                " SET SITE_NM = '" + SITE_NM + "', USING_FLAG = " + USING_FLAG + ", SORT_NO =" + SORT_NO + ", MEMO = '" + MEMO + "' " +
                " WHERE SITE_CD = " + SITE_CD + " ";


            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

        //DUPLICATE
        //중복체크는 SITE_NM으로만 한다.         
        //중복된 SITE_CD값을 RETURN.
        public int exSite(string SITE_NM)
        {
            string sql = "" +

                " SELECT ISNULL(MAX(SITE_CD),0) SITE_CD" +
                " FROM [PLUS_MAIN].dbo.TM00_SITE " +
                " WHERE SITE_NM = '" + SITE_NM + "' ";


            object reObj = 0;
            if (_sqlHelper != null)
                reObj = _sqlHelper.ExecuteScalar(sql);

            return Convert.ToInt16(reObj);
        }

        //INSERT MAIN SITE
        public string aSite(Hashtable param, out Hashtable outVal)
        {
            string sql = "sp_SITE_New";

            object reObj = _sqlHelper.ExecuteCommandsp(sql, param, out outVal);

            return reObj.ToString();
        }        
    }
}

