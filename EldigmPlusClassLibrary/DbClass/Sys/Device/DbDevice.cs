using EldigmPlusDb.DbClass.Common;
using Framework.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldigmPlusClassLibrary.DbClass.Sys.Device
{
   public class DbDevice
    {
        DataObj _sqlHelper = null;

        public DbDevice(string pCon_IP, string pCon_DB, string pCon_USER, string pType)
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




        //Dev Type CMB BOX 
        public DataSet devTypeCmb()
        {
            string sql = "" +
                " SELECT SCODE, SCODE_NM " +
                " FROM [PLUS_MAIN].dbo.TM00_CODE_SYS " +
                " WHERE SCODE_GRP = 'DevType' AND USING_FLAG = 1 ";

            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }


        //DevIO CMB BOX 
        public DataSet devIOCmb()
        {
            string sql = "" +
                " SELECT SCODE, SCODE_NM " +
                " FROM [PLUS_MAIN].dbo.TM00_CODE_SYS " +
                " WHERE SCODE_GRP = 'DevIO' AND USING_FLAG = 1 ";


            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }




        //SELECT 
        public DataSet sDevice(string DBNM, string SITE_CD)
        {
            string con = "[PLUS-" + DBNM + "].dbo.";
            string sql = "" +
               " SELECT DEV_CD, DEVICE_ID, DEV_TYPE_SCD, DEV_IO_SCD, DEV_NM, IP, USING_FLAG, SORT_NO, MEMO " +
               " FROM " + con + "T00_DEVICE " +
               " WHERE SITE_CD =" + SITE_CD + " " +
               " ORDER BY SORT_NO, DEV_NM ";

            //if (USING_FLAG != "")
            //{
            //    sql += " WHERE B.USING_FLAG = '" + USING_FLAG + "' ";
            //}


            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }



        //MODIFY
        public int mDevice(string DBNM, string SITE_CD, string DEV_CD, string DEVICE_ID, string DEV_TYPE_SCD, string DEV_IO_SCD, string DEV_NM, string IP, string SORT_NO,  string USING_FLAG, string MEMO)
        {
            string con = "[PLUS-" + DBNM + "].dbo.";
            string sql = "" +
              " UPDATE " + con + "T00_DEVICE " +
              " SET DEVICE_ID = " + DEVICE_ID + ", DEV_TYPE_SCD = '" + DEV_TYPE_SCD + "', DEV_IO_SCD = '" + DEV_IO_SCD + "', DEV_NM = '" + DEV_NM + "', IP = '" + IP + "', USING_FLAG = " + USING_FLAG + ", SORT_NO = " + SORT_NO + ", MEMO = '" + MEMO + "' " +
              " WHERE DEV_CD = " + DEV_CD + " AND SITE_CD = " + SITE_CD + " ";


            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }
    

        //LOG
        public int logDevice(string DBNM, string DEV_CD, string SITE_CD, string DEVICE_ID, string DEV_TYPE_SCD, string DEV_IO_SCD, string DEV_NM, string IP, string USING_FLAG, string SORT_NO, string MEMO, string INPUT_ID)
        {
            string con = "[PLUS-" + DBNM + "].dbo.";
            string sql = "" +
                " INSERT INTO " + con + "T00_DEVICE_LOG (DEV_CD, LOG_NO, SITE_CD, DEVICE_ID, DEV_TYPE_SCD, DEV_IO_SCD, DEV_NM, IP, USING_FLAG, SORT_NO, MEMO, INPUT_ID, INPUT_DT) " +
                " VALUES (" + DEV_CD + ",(SELECT ISNULL(MAX(LOG_NO),0)+1 FROM [PLUS-ELDIGM].dbo.T00_DEVICE_LOG WHERE SITE_CD = SITE_CD AND DEV_CD = DEV_CD), " + SITE_CD + ", " + DEVICE_ID +
                ", '" + DEV_TYPE_SCD + "', '" + DEV_IO_SCD + "' ,'" + DEV_NM + "', '" + IP + "', " + USING_FLAG + ", " + SORT_NO + ", '" + MEMO + "' ," + INPUT_ID + ", GETDATE())";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }



        //INSERT COMPANY WITH PROCEDURE
        public string aDevicePro(Hashtable param, out Hashtable outVal)
        {
            string sql = "sp_DEVICE_New";

            object reObj = _sqlHelper.ExecuteCommandsp(sql, param, out outVal);

            return reObj.ToString();
        }
    }
}