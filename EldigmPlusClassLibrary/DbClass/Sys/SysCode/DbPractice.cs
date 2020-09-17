using Framework.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldigmPlusClassLibrary.DbClass.Sys.SysCode
{
    public class DbPractice
    {
        DataObj sqlHelper = null;

        public DbPractice()
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



        public DataSet psSysCodeGrp(string SCODE_GRP)
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

        public int pmSysCodeGrp(string SCODE_GRP, string SCODE_NM, string USING_FLAG, string SORT_NO, string MEMO)
        {
            string sql = "" +
                " UPDATE TM00_CODE_SYS_GRP SET SCODE_NM = '" + SCODE_NM + "', USING_FLAG = " + USING_FLAG + ", SORT_NO = " + SORT_NO + ", MEMO = '" + MEMO + "' " +
                " WHERE SCODE_GRP = '" + SCODE_GRP + "' ";

            int reCnt = 0;
            if (sqlHelper != null)
                reCnt = sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }



    }
}
