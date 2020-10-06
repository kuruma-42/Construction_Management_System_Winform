using Framework.Data;
using System.Data;

namespace EldigmPlusClassLibrary.DbClass.Sys.ComnCode
{
    public class DbComnCodeGrp
    {
        DataObj sqlHelper = null;

        public DbComnCodeGrp()
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
        public int aComnCodeGrp(string CCODE_GRP, string CCODE_NM, string USING_FLAG, string SORT_NO, string MEMO, string INPUT_ID)
        {
            string sql = "" +
                " INSERT INTO [PLUS_MAIN].dbo.TM00_CODE_COMN_GRP (CCODE_GRP, CCODE_NM, USING_FLAG, SORT_NO, MEMO, INPUT_ID, INPUT_DT) " +
                " VALUES ('" + CCODE_GRP + "', '" + CCODE_NM + "', " + USING_FLAG + ", " + SORT_NO + ", '" + MEMO + "', " + INPUT_ID + ", GETDATE()) ";

            int reCnt = 0;
            if (sqlHelper != null)
                reCnt = sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

        public DataSet sComnCodeGrp(string CCODE_GRP)
        {
            string sql = "" +
                " SELECT CCODE_GRP, CCODE_NM, USING_FLAG, SORT_NO, MEMO " +
                " FROM [PLUS_MAIN].dbo.TM00_CODE_COMN_GRP ";

            if (CCODE_GRP != "")
                sql += " WHERE CCODE_GRP = '" + CCODE_GRP + "'";

            sql += "" +
                " ORDER BY SORT_NO, CCODE_NM ";

            DataSet ds = null;
            if (sqlHelper != null)
                ds = sqlHelper.ExecuteFill(sql);

            return ds;
        }
    }
}
