using EldigmPlusDb.DbClass.Common;
using Framework.Data;
using System;
using System.Data;

namespace EldigmPlusClassLibrary.DbClass.Sys.SysCode
{
    public class DbSysCodeGrp
    {
        DataObj _sqlHelper = null;

        public DbSysCodeGrp(string pCon_IP, string pCon_DB, string pCon_USER)
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



        public DataSet sSysCodeGrp(string SCODE_GRP)
        {
            string sql = "" +
                " SELECT SCODE_GRP, SCODE_GRP_NM, USING_FLAG, SORT_NO, MEMO " +
                " FROM [PLUS_MAIN].dbo.TM00_CODE_SYS_GRP ";

            if (SCODE_GRP != "")
                sql += " WHERE SCODE_GRP = '" + SCODE_GRP + "'";

            sql += "" +
                " ORDER BY SORT_NO, SCODE_GRP_NM ";

            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }

        public int mSysCodeGrp(string SCODE_GRP, string SCODE_GRP_NM, string USING_FLAG, string SORT_NO, string MEMO)
        {
            string sql = "" +
                " UPDATE [PLUS_MAIN].dbo.TM00_CODE_SYS_GRP SET SCODE_GRP_NM = '" + SCODE_GRP_NM + "', USING_FLAG = " + USING_FLAG + ", SORT_NO = " + SORT_NO + ", MEMO = '" + MEMO + "' " +
                " WHERE SCODE_GRP = '" + SCODE_GRP + "' ";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

        public int exSysCodeGrp(string SCODE_GRP)
        {
            string sql = "" +
                " SELECT COUNT(*) CNT " +
                " FROM [PLUS_MAIN].dbo.TM00_CODE_SYS_GRP " +
                " WHERE SCODE_GRP = '" + SCODE_GRP + "' ";

            object reObj = 0;
            if (_sqlHelper != null)
                reObj = _sqlHelper.ExecuteScalar(sql);

            return Convert.ToInt16(reObj);
        }

        public int aSysCodeGrp(string SCODE_GRP, string SCODE_GRP_NM, string USING_FLAG, string SORT_NO, string MEMO, string INPUT_ID)
        {
            string sql = "" +
                " INSERT INTO [PLUS_MAIN].dbo.TM00_CODE_SYS_GRP (SCODE_GRP, SCODE_GRP_NM, USING_FLAG, SORT_NO, MEMO, INPUT_ID, INPUT_DT) " +
                " VALUES ('" + SCODE_GRP + "', '" + SCODE_GRP_NM + "', " + USING_FLAG + ", " + SORT_NO + ", '" + MEMO + "', " + INPUT_ID + ", GETDATE()) ";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }


        public DataSet sSysCodeGrp_UsingFlag(string USING_FLAG)
        {
            string sql = "" +
                " SELECT SCODE_GRP, SCODE_GRP_NM, USING_FLAG, SORT_NO, MEMO " +
                " FROM [PLUS_MAIN].dbo.TM00_CODE_SYS_GRP ";

            if (USING_FLAG != "")
                sql += " WHERE USING_FLAG = " + USING_FLAG + "";

            sql += "" +
                " ORDER BY SORT_NO, SCODE_GRP_NM ";

            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }

        public DataSet sSysCode(string SCODE_GRP, string USING_FLAG, string SCODE_NM)
        {
            string sql = "" +
                " SELECT SCODE, SCODE_NM, USING_FLAG, MEMO, SORT_NO " +
                " FROM [PLUS_MAIN].dbo.TM00_CODE_SYS " +
                " WHERE SCODE != '' ";

            if (SCODE_GRP != "")
            {
                sql += " AND SCODE_GRP = '" + SCODE_GRP + "' AND SCODE_NM LIKE '%" + SCODE_NM + "%' ";
            }
            if (USING_FLAG != "")
            {
                sql += " AND USING_FLAG = '" + USING_FLAG + "' ";
            }

            sql += "" +
                " ORDER BY SORT_NO, SCODE_NM ";

            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }

        public int mSysCode(string SCODE, string SCODE_NM, string USING_FLAG, string SORT_NO, string MEMO)
        {
            string sql = "" +
                " UPDATE [PLUS_MAIN].dbo.TM00_CODE_SYS SET SCODE_NM = '" + SCODE_NM + "', USING_FLAG = " + USING_FLAG + ", SORT_NO = " + SORT_NO + ", MEMO = '" + MEMO + "' " +
                " WHERE SCODE = '" + SCODE + "' ";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

        public int exSysCode(string SCODE)
        {
            string sql = "" +
                " SELECT COUNT(*) CNT " +
                " FROM [PLUS_MAIN].dbo.TM00_CODE_SYS " +
                " WHERE SCODE = '" + SCODE + "' ";

            object reObj = 0;
            if (_sqlHelper != null)
                reObj = _sqlHelper.ExecuteScalar(sql);

            return Convert.ToInt16(reObj);
        }

        public int aSysCode(string SCODE, string SCODE_GRP, string SCODE_NM, string USING_FLAG, string MEMO, string SORT_NO, string INPUT_ID)
        {
            string sql = "" +
                " INSERT INTO [PLUS_MAIN].dbo.TM00_CODE_SYS (SCODE, SCODE_GRP, SCODE_NM, USING_FLAG, MEMO, SORT_NO, INPUT_ID, INPUT_DT) " +
                " VALUES ('" + SCODE + "', '" + SCODE_GRP + "', '" + SCODE_NM + "', " + USING_FLAG + ", '" + MEMO + "', " + SORT_NO + ", " + INPUT_ID + ", GETDATE()) ";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

        public int aSysCodeLog(string SCODE, string SCODE_NM, string USING_FLAG, string SORT_NO, string MEMO, string INPUT_ID)
        {
            string sql = "" +
                " INSERT INTO [PLUS_MAIN].dbo.TM00_CODE_SYS_LOG (SCODE, SNO, SCODE_NM, USING_FLAG, SORT_NO, MEMO, INPUT_ID, INPUT_DT) " +
                " VALUES ('" + SCODE + "', (SELECT ISNULL(MAX(SNO),0)+1 FROM TM00_CODE_SYS_LOG WHERE SCODE = '" + SCODE + "'), '" + SCODE_NM + "', " + USING_FLAG + ", " + SORT_NO + "" +
                " , '" + MEMO + "', " + INPUT_ID + ", GETDATE()) ";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }


    }
}
