using EldigmPlusDb.DbClass.Common;
using Framework.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldigmPlusClassLibrary.DbClass.Sys.MemberSite
{
    public class DbMember
    {
        DataObj _sqlHelper = null;

        public DbMember(string pCon_IP, string pCon_DB, string pCon_USER)
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

        //SELECT (USING FLAG CHECKED)
        public DataSet sMember_UsingFlag(string USING_FLAG)
        {
            string sql = "" + " " +
                "SELECT MEMCO_CD, MEMCO_NM, USING_FLAG, SORT_NO, MEMO " +
                " FROM [PLUS_MAIN].dbo.TM00_MEMCO ";

            if (USING_FLAG != "")
                sql += " WHERE USING_FLAG = " + USING_FLAG + "";

            sql += "" +
                " ORDER BY SORT_NO, MEMCO_NM ";

            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }

        //DATA GRID VIEW1 SELECT 
        public DataSet sMember(string MEMCO_CD)
        {
            string sql = "" +
              " SELECT MEMCO_CD, MEMCO_NM, USING_FLAG, SORT_NO, MEMO " +
              " FROM [PLUS_MAIN].dbo.TM00_MEMCO ";

            if (MEMCO_CD != "")
                sql += " WHERE MEMCO_CD = '" + MEMCO_CD + "'";

            sql += "" +
                " ORDER BY SORT_NO, MEMCO_NM ";

            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }

        //MODIFY
        public int mMember(string MEMCO_CD, string MEMCO_NM, string USING_FLAG, string SORT_NO, string MEMO)
        {
            string sql = "" +
                " UPDATE [PLUS_MAIN].dbo.TM00_MEMCO " +
                " SET USING_FLAG = " + USING_FLAG + ", SORT_NO = " + SORT_NO + ", MEMO = '" + MEMO + "' " +
                " WHERE MEMCO_CD = " + MEMCO_CD + "AND MEMCO_NM = '" + MEMCO_NM + "' ";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

        //DUPLICATE CHECK 
        public int exMember(string MEMCO_CD, string MEMCO_NM)
        {
            string sql = "" +
                " SELECT COUNT(*) CNT " +
                " FROM [PLUS_MAIN].dbo.TM00_MEMCO " +
                " WHERE MEMCO_CD = '" + MEMCO_CD + "' AND MEMCO_NM = '" + MEMCO_NM + "' ";

            object reObj = 0;
            if (_sqlHelper != null)
                reObj = _sqlHelper.ExecuteScalar(sql);

            return Convert.ToInt16(reObj);
        }

        //INSERT
        public int aMember(string MEMCO_NM, string DB_NM, string SORT_NO, string USING_FLAG, string MEMO, string INPUT_ID)
        {
            string sql = "" +
                " INSERT INTO [PLUS_MAIN].dbo.TM00_MEMCO (MEMCO_NM, DB_NM, USING_FLAG, SORT_NO, MEMO, INPUT_ID, INPUT_DT) " +
                " VALUES ('" + MEMCO_NM + "', '" + DB_NM + "', " + USING_FLAG + ", " + SORT_NO + ", '" + MEMO + "', " + INPUT_ID + ", GETDATE()) ";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }


    }
}