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
    public class DbSysAuthMainDB
    {
        DataObj _sqlHelper = null;

        public DbSysAuthMainDB(string pCon_IP, string pCon_DB, string pCon_USER)
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


        public DataSet sDbSysAuthMainDB(string USING_FLAG)
        {
            string sql = "" +
                " SELECT AUTH_CD, AUTH_NM, MYBLOCK_FLAG, MYCON_FLAG, MYCOM_FLAG, MYTEAM_FLAG, USING_FLAG, AUTH_LEVEL, MEMO " +
                " FROM [PLUS_MAIN].dbo.TM00_CODE_AUTH ";

            if (USING_FLAG != "")
            {
                sql += " WHERE USING_FLAG = '" + USING_FLAG + "' ";
            }

            sql += "" + 
               " ORDER BY AUTH_LEVEL, AUTH_NM ";

            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }

        public int mSysAuthMainDB(string AUTH_CD, string AUTH_NM, string MYBLOCK_FLAG, string MYCON_FLAG, string MYCOM_FLAG, string MYTEAM_FLAG, string USING_FLAG, string MEMO)
        {
            string sql = "" +
                " UPDATE [PLUS_MAIN].dbo.TM00_CODE_AUTH SET MYBLOCK_FLAG = " + MYBLOCK_FLAG + ", MYCON_FLAG = " + MYCON_FLAG + ", MYCOM_FLAG = " + MYCOM_FLAG + ", MYTEAM_FLAG = " + MYTEAM_FLAG + ", USING_FLAG = " + USING_FLAG + ", MEMO = '" + MEMO + "' " +
                " WHERE AUTH_CD = '" + AUTH_CD + "' ";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

        public int exSysAuthMainDB(string AUTH_CD)
        {
            string sql = "" +
                " SELECT COUNT(*) CNT " +
                " FROM [PLUS_MAIN].dbo.TM00_CODE_AUTH " +
                " WHERE AUTH_CD = '" + AUTH_CD + "' ";

            object reObj = 0;
            if (_sqlHelper != null)
                reObj = _sqlHelper.ExecuteScalar(sql);

            return Convert.ToInt16(reObj);
        }

        public int aSysAuthMainDB(string AUTH_CD, string AUTH_NM, string MYBLOCK_FLAG, string MYCON_FLAG, string MYCOM_FLAG, string MYTEAM_FLAG, string USING_FLAG, string AUTH_LEVEL, string MEMO, string INPUT_ID)
        {
            string sql = "" +
                " INSERT INTO [PLUS_MAIN].dbo.TM00_CODE_AUTH (AUTH_CD, AUTH_NM, MYBLOCK_FLAG, MYCON_FLAG, MYCOM_FLAG, MYTEAM_FLAG, USING_FLAG, AUTH_LEVEL, MEMO, INPUT_ID, INPUT_DT) " +
                " VALUES ('" + AUTH_CD + "', '" + AUTH_NM + "', " + MYBLOCK_FLAG + ", " + MYCON_FLAG + ", " + MYCOM_FLAG + ", " + MYTEAM_FLAG + ", " + USING_FLAG + ", " + AUTH_LEVEL + ", '" + MEMO + "', " + INPUT_ID + ", GETDATE()) ";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

    }
}
