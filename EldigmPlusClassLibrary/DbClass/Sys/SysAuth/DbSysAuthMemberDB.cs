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
    public class DbSysAuthMemberDB
    {
        DataObj _sqlHelper = null;

        public DbSysAuthMemberDB(string pCon_IP, string pCon_DB, string pCon_USER)
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

        public DataSet sMemberMainDB()
        {
            string sql = "" +
               " SELECT MEMCO_CD, MEMCO_NM " +
               " FROM [PLUS_MAIN].dbo.TM00_MEMCO " +
               " WHERE USING_FLAG =1 ";

            sql += "" +
                " ORDER BY SORT_NO, MEMCO_NM ";

            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }



        //SELECT
        public DataSet sSysAuthMemberDB(string DBNM, string USING_FLAG)
        {
            string sql = "" +
               " SELECT A.AUTH_CD, A.AUTH_NM, ISNULL(B.MYBLOCK_FLAG, 0) MYBLOCK_FLAG, ISNULL(B.MYCON_FLAG, 0) MYCON_FLAG, ISNULL(B.MYCOM_FLAG, 0) MYCOM_FLAG " +
               " , ISNULL(B.MYTEAM_FLAG, 0) MYTEAM_FLAG, ISNULL(B.USING_FLAG, 0) USING_FLAG " +
               " , CASE WHEN B.AUTH_LEVEL IS NOT NULL THEN B.AUTH_LEVEL ELSE A.AUTH_LEVEL END AUTH_LEVEL " +
               " , ISNULL(B.MEMO, '') MEMO " +
               " FROM [PLUS_MAIN].dbo.TM00_CODE_AUTH A " +
               " LEFT OUTER JOIN [PLUS-" + DBNM + "].dbo.T00_CODE_AUTH B ON A.AUTH_CD = B.AUTH_CD ";
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
        public int mSysAuthMemberDB(string DBNM, string AUTH_CD, string AUTH_NM, string MYBLOCK_FLAG, string MYCON_FLAG, string MYCOM_FLAG, string MYTEAM_FLAG, string USING_FLAG, string MEMO)
        {
            string sql = "" +
                " UPDATE [PLUS-" + DBNM + "].dbo.T00_CODE_AUTH SET MYBLOCK_FLAG = " + MYBLOCK_FLAG + ", MYCON_FLAG = " + MYCON_FLAG + ", MYCOM_FLAG = " + MYCOM_FLAG + ", MYTEAM_FLAG = " + MYTEAM_FLAG + ", USING_FLAG = " + USING_FLAG + ", MEMO = '" + MEMO + "' " +
                " WHERE AUTH_CD = '" + AUTH_CD + "' ";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

        //중복체크는 PLUS_MAIN 에서 이뤄진다. 
        //따로 회원사의 코드에서는 중복을 검사하지 않는다.      
        public int exSysAuthMainDB(string AUTH_CD, string AUTH_NM)
        {
            string sql = "" +
                " SELECT COUNT(*) CNT " +
                " FROM [PLUS_MAIN].dbo.TM00_CODE_AUTH " +
                " WHERE AUTH_CD = '" + AUTH_CD + "' AND AUTH_NM = '" + AUTH_NM + "' ";

            object reObj = 0;
            if (_sqlHelper != null)
                reObj = _sqlHelper.ExecuteScalar(sql);

            return Convert.ToInt16(reObj);
        }

        //중복이 없을 때는 PLUS_MAIN INSERT 그 후 MEMBER DB INSERT
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


        //MEMBER DB INSERT
        public int aSysAuthMemberDB(string DBNM, string AUTH_CD, string AUTH_NM, string MYBLOCK_FLAG, string MYCON_FLAG, string MYCOM_FLAG, string MYTEAM_FLAG, string USING_FLAG, string AUTH_LEVEL, string MEMO, string INPUT_ID)
        {
            string sql = "" +
                " INSERT INTO [PLUS-" + DBNM + "].dbo.T00_CODE_AUTH (AUTH_CD, AUTH_NM, MYBLOCK_FLAG, MYCON_FLAG, MYCOM_FLAG, MYTEAM_FLAG, USING_FLAG, AUTH_LEVEL, MEMO, INPUT_ID, INPUT_DT) " +
                " VALUES ('" + AUTH_CD + "', '" + AUTH_NM + "', " + MYBLOCK_FLAG + ", " + MYCON_FLAG + ", " + MYCOM_FLAG + ", " + MYTEAM_FLAG + ", " + USING_FLAG + ", " + AUTH_LEVEL + ", '" + MEMO + "', " + INPUT_ID + ", GETDATE()) ";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

    }
}
