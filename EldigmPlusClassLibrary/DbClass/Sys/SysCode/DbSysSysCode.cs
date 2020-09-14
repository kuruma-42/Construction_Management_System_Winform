using Framework.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldigmPlusClassLibrary.DbClass.Sys.SysCode
{
    public class DbSysSysCode
    {
        DataObj sqlHelper = null;

        public DbSysSysCode()
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


        public string sDbNm(string MEMCO_CD)
        {
            string sql = "" +
                " SELECT ISNULL(MAX(DB_NM), '') DB_NM " +
                " FROM[PLUS_MAIN].dbo.TM00_MEMCO " +
                " WHERE MEMCO_CD = " + MEMCO_CD + " ";

            object reVal = null;

            if (sqlHelper != null)
                reVal = sqlHelper.ExecuteScalar(sql);

            return reVal.ToString();
        }

        public DataSet sSysCodeGrp()
        {

            string sql = "" +
                " SELECT SCODE_GRP, SCODE_NM" +
                " FROM[PLUS_MAIN].dbo.TM00_CODE_SYS_GRP ";

            //object reVal = null;              

            DataSet ds = null;

            if (sqlHelper != null)
                ds = sqlHelper.ExecuteFill(sql);

            return ds;
        
        }


    }
}
