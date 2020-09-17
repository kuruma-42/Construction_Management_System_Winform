using Framework.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldigmPlusClassLibrary.DbClass.Sys.SysCode
{
    public class DbSysCodeGrp
    {
        DataObj sqlHelper = null;

        public DbSysCodeGrp()
        {
            sqlHelper = new DataObj();
            sqlHelper.SetConnect(dbConStr());
        }

        private string dbConStr()
        {
            string server = "192.168.0.77";
            string dbPort = "61433";
            string dataBase = "PLUS_MAIN";
            string uid = "eldigmplus";
            string pwd = "!@#Plus1203";

            return "server=" + server + "," + dbPort + ";database=" + dataBase + ";uid=" + uid + ";pwd=" + pwd + ";";
        }

        public void DisConnect()
        {
            if (sqlHelper != null)
            {
                sqlHelper.DisConnect();
                sqlHelper = null;
            }
        }



        public DataSet sSysCodeGrp(string SCODE_GRP)
        {
            string sql = "" +
                " SELECT SCODE_GRP, SCODE_NM, USING_FLAG, SORT_NO, MEMO " +
                " FROM [PLUS_MAIN].dbo.TM00_CODE_SYS_GRP ";

            if (SCODE_GRP != "")
                sql += " WHERE SCODE_GRP = '" + SCODE_GRP + "'";

            sql += "" +
                " ORDER BY SORT_NO, SCODE_NM ";

            DataSet ds = null;
            if (sqlHelper != null)
                ds = sqlHelper.ExecuteFill(sql);

            return ds;
        }

        public int mSysCodeGrp(string SCODE_GRP, string SCODE_NM, string USING_FLAG, string SORT_NO, string MEMO)
        {
            string sql = "" +
                " UPDATE [PLUS_MAIN].dbo.TM00_CODE_SYS_GRP SET SCODE_NM = '" + SCODE_NM + "', USING_FLAG = " + USING_FLAG + ", SORT_NO = " + SORT_NO + ", MEMO = '" + MEMO + "' " +
                " WHERE SCODE_GRP = '" + SCODE_GRP + "' ";

            int reCnt = 0;
            if (sqlHelper != null)
                reCnt = sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

        public DataSet sSysCodeGrp_UsingFlag(string USING_FLAG)
        {
            string sql = "" +
                " SELECT SCODE_GRP, SCODE_NM, USING_FLAG, SORT_NO, MEMO " +
                " FROM [PLUS_MAIN].dbo.TM00_CODE_SYS_GRP ";

            if (USING_FLAG != "")
                sql += " WHERE USING_FLAG = '" + USING_FLAG + "'";

            sql += "" +
                " ORDER BY SORT_NO, SCODE_NM ";

            DataSet ds = null;
            if (sqlHelper != null)
                ds = sqlHelper.ExecuteFill(sql);

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
            if (sqlHelper != null)
                ds = sqlHelper.ExecuteFill(sql);

            return ds;
        }

        public int mSysCode(string SCODE, string SCODE_NM, string USING_FLAG, string SORT_NO, string MEMO)
        {
            string sql = "" +
                " UPDATE [PLUS_MAIN].dbo.TM00_CODE_SYS SET SCODE_NM = '" + SCODE_NM + "', USING_FLAG = " + USING_FLAG + ", SORT_NO = " + SORT_NO + ", MEMO = '" + MEMO + "' " +
                " WHERE SCODE = '" + SCODE + "' ";

            int reCnt = 0;
            if (sqlHelper != null)
                reCnt = sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

        public int exSysCode(string SCODE)
        {
            string sql = "" +
                " SELECT COUNT(*) CNT " +
                " FROM TM00_CODE_SYS " +
                " WHERE SCODE = '" + SCODE + "' ";

            object reObj = 0;
            if (sqlHelper != null)
                reObj = sqlHelper.ExecuteScalar(sql);

            return Convert.ToInt16(reObj);
        }

        public int aSysCode(string SCODE, string SCODE_GRP, string SCODE_NM, string USING_FLAG, string MEMO, string SORT_NO, string INPUT_ID)
        {
            string sql = "" +
                " INSERT INTO [PLUS_MAIN].dbo.TM00_CODE_SYS (SCODE, SCODE_GRP, SCODE_NM, USING_FLAG, MEMO, SORT_NO, INPUT_ID, INPUT_DT) " +
                " VALUES ('" + SCODE + "', '" + SCODE_GRP + "', '" + SCODE_NM + "', " + USING_FLAG + ", '" + MEMO + "', " + SORT_NO + ", " + INPUT_ID + ", GETDATE()) ";

            int reCnt = 0;
            if (sqlHelper != null)
                reCnt = sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

        public int aSysCodeLog(string SCODE, string SCODE_NM, string USING_FLAG, string SORT_NO, string MEMO, string INPUT_ID)
        {
            string sql = "" +
                " INSERT INTO [PLUS_MAIN].dbo.TM00_CODE_SYS_LOG (SCODE, SNO, SCODE_NM, USING_FLAG, SORT_NO, MEMO, INPUT_ID, INPUT_DT) " +
                " VALUES ('" + SCODE + "', (SELECT ISNULL(MAX(SNO),0)+1 FROM TM00_CODE_SYS_LOG WHERE SCODE = '" + SCODE + "'), '" + SCODE_NM + "', " + USING_FLAG + ", " + SORT_NO + "" +
                " , '" + MEMO + "', " + INPUT_ID + ", GETDATE()) ";

            int reCnt = 0;
            if (sqlHelper != null)
                reCnt = sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

        public DataSet fSysCodeSearch(string SCODE_GRP, string SCODE_NM)
        {
            string sql = "" +
            " SELECT SCODE, SCODE_NM, USING_FLAG, MEMO, SORT_NO" +
            " FROM[PLUS_MAIN].dbo.TM00_CODE_SYS ";

            //if (SCODE_NM != "")
            sql += " WHERE SCODE_NM Like '%" + SCODE_NM + "%' AND SCODE_GRP = '" + SCODE_GRP +"'";

            sql += "" +
               " ORDER BY SORT_NO, SCODE_NM ";


            //" Where SCODE_NM Like '%" + SCODE_NM +"%' ";

            DataSet ds = null;
            if (sqlHelper != null)
                ds = sqlHelper.ExecuteFill(sql);

            return ds;


        }




    }
}
