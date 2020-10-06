using EldigmPlusDb.DbClass.Common;
using Framework.Data;
using System;
using System.Data;

namespace EldigmPlusClassLibrary.DbClass.Sys.CommonCode
{
    public class DbComnCodeGrpMainDB
    {
        DataObj _sqlHelper = null;

        public DbComnCodeGrpMainDB(string pCon_IP, string pCon_DB, string pCon_USER)
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

        public DataSet sComnCodeGrp()
        {
            string sql = "" +
                " SELECT CCODE_GRP, CCODE_NM, USING_FLAG, SORT_NO, MEMO " +
                " FROM [PLUS_MAIN].dbo.TM00_CODE_COMN_GRP ";

            sql += "" +
                " ORDER BY SORT_NO, CCODE_NM ";

            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }

        public int aComnCodeGrp(string CCODE_GRP, string CCODE_NM, string USING_FLAG, string SORT_NO, string MEMO, string INPUT_ID)
        {
            string sql = "" +
                " INSERT INTO [PLUS_MAIN].dbo.TM00_CODE_COMN_GRP (CCODE_GRP, CCODE_NM, USING_FLAG, SORT_NO, MEMO, INPUT_ID, INPUT_DT) " +
                " VALUES ('" + CCODE_GRP + "', '" + CCODE_NM + "', " + USING_FLAG + ", " + SORT_NO + ", '" + MEMO + "', " + INPUT_ID + ", GETDATE()) ";

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

        public int mComnCodeGrp(string CCODE_GRP, string CCODE_NM, string USING_FLAG, string SORT_NO, string MEMO)
        {
            string sql = "" +
                " UPDATE [PLUS_MAIN].dbo.TM00_CODE_COMN_GRP SET CCODE_NM = '" + CCODE_NM + "', USING_FLAG = " + USING_FLAG + ", SORT_NO = " + SORT_NO + ", MEMO = '" + MEMO + "' " +
                " WHERE CCODE_GRP = '" + CCODE_GRP + "' ";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

    }
}
