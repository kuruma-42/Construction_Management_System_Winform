using EldigmPlusDb.DbClass.Common;
using Framework.Data;
using System;
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
                " SELECT TTYPE_SCD, TCODE_NM, LIST_FLAG, REQUIRED_FLAG, NUMERIC_FLAG FROM TM00_CODE_T WHERE TTYPE_SCD = '" + SCODE + "'";

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

       


    }
}
