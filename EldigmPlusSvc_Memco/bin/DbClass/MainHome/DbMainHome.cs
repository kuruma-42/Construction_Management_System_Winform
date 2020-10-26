using EldigmPlusDb.DbClass.Common;
using Framework.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldigmPlusClassLibrary.DbClass.MainHome
{
    public class DbMainHome
    {
        DataObj _sqlHelper = null;

        //public DbMainHome()
        //{
        //    _sqlHelper = new DataObj();
        //    _sqlHelper.SetConnect(dbConStr());
        //}

        //private string dbConStr()
        //{
        //    string server = "192.168.0.77";
        //    string dbPort = "61433";
        //    string dataBase = "PLUS_MAIN";
        //    string uid = "eldigmplus";
        //    string pwd = "!@#Plus1203";

        //    return "server=" + server + "," + dbPort + ";database=" + dataBase + ";uid=" + uid + ";pwd=" + pwd + ";";
        //}

        public DbMainHome(string pCon_IP, string pCon_DB, string pCon_USER)
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

        public DataSet sSiteMenu(string DBNM, string SITE_CD)
        {
            //string dbNm = siteDbNm(SITE_CD);
            string con = "[PLUS-" + DBNM + "].dbo.";
            string sql = "" +
                " SELECT A.TOP_MENU_CD, B.TOP_MENU_NM " +
                " FROM " + con + "T00_MENU_SITE A " +
                " INNER JOIN [PLUS_MAIN].dbo.TM00_MENU_TOP B ON A.TOP_MENU_CD = B.TOP_MENU_CD " +
                " WHERE A.SITE_CD = " + SITE_CD + " AND A.TOP_MENU_CD != 1 " +
                " GROUP BY A.TOP_MENU_CD, B.TOP_MENU_NM, B.SORT_NO " +
                " ORDER BY B.SORT_NO ";

            DataSet ds = null;

            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }

        public DataSet sSiteSubMenu1(string DBNM, string SITE_CD, string TOP_MENU_CD)
        {
            string con = "[PLUS-" + DBNM + "].dbo.";
            string sql = "" +
                " SELECT A.SUB_MENU_CD, B.SUB_MENU_NM " +
                " FROM " + con + "T00_MENU_SITE A " +
                " INNER JOIN [PLUS_MAIN].dbo.TM00_MENU_SUB B ON A.SUB_MENU_CD = B.SUB_MENU_CD " +
                " WHERE A.SITE_CD = " + SITE_CD + " AND A.TOP_MENU_CD = " + TOP_MENU_CD + " " +
                " GROUP BY A.SUB_MENU_CD, B.SUB_MENU_NM, B.SORT_NO " +
                " ORDER BY B.SORT_NO ";

            DataSet ds = null;

            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }

        public DataSet sSiteSubMenu2(string DBNM, string SITE_CD, string TOP_MENU_CD, string SUB_MENU_CD)
        {
            string con = "[PLUS-" + DBNM + "].dbo.";
            string sql = "" +
                " SELECT A.MENU_CD, A.TOP_MENU_CD, A.SUB_MENU_CD, A.MENU_NM, A.MEMO " +
                " , B.MENU_PATH " +
                " FROM " + con + "T00_MENU_SITE A " +
                " INNER JOIN [PLUS_MAIN].dbo.TM00_MENU B ON A.MENU_CD = B.MENU_CD AND A.TOP_MENU_CD = B.TOP_MENU_CD AND A.SUB_MENU_CD = B.SUB_MENU_CD " +
                " WHERE A.SITE_CD = " + SITE_CD + " AND A.TOP_MENU_CD = " + TOP_MENU_CD + " AND A.SUB_MENU_CD = " + SUB_MENU_CD + " " +
                " AND A.USING_FLAG = 1 " +
                " ORDER BY A.SORT_NO ";

            DataSet ds = null;

            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }



    }
}