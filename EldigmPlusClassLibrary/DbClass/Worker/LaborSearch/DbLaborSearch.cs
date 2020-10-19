using EldigmPlusDb.DbClass.Common;
using Framework.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldigmPlusClassLibrary.DbClass.Worker.LaborSearch
{
    public class DbLaborSearch
    {
        DataObj _sqlHelper = null;

        public DbLaborSearch(string pCon_IP, string pCon_DB, string pCon_USER, string pType)
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


        public string sDbNm(string SITE_CD)
        {
            string sql = "" +

            " SELECT ISNULL(MAX(B.DB_NM), '') DB_NM " +
            " FROM [PLUS_MAIN].dbo.TM00_SITE A  " +
            " INNER JOIN [PLUS_MAIN].dbo.TM00_MEMCO B ON A.MEMCO_CD = B.MEMCO_CD " +
            " WHERE SITE_CD =" + SITE_CD + " ";

            object reVal = null;

            if (_sqlHelper != null)
                reVal = _sqlHelper.ExecuteScalar(sql);

            return reVal.ToString();
        }


        public string sMyComFlag(string SITE_CD, string AUTH_CD)
        {
            string dbNm = "";
            dbNm = sDbNm(SITE_CD);

            string sql = "" +

            " SELECT MYCOM_FLAG FROM [PLUS-" + dbNm + "].dbo.T00_CODE_AUTH A " +
            " INNER JOIN [PLUS-" + dbNm + "].dbo.T00_CODE_AUTH_SITE B ON A.AUTH_CD = B.AUTH_CD " +
            " WHERE B.AUTH_CD = '" + AUTH_CD + "' AND B.SITE_CD = " + SITE_CD + " ";


            object reVal = null;

            if (_sqlHelper != null)
                reVal = _sqlHelper.ExecuteScalar(sql);

            return reVal.ToString();
        }


        //COMPANY CMB BOX 
        public DataSet sLaborCompanyList(string SITE_CD, int MYCOM_FLAG, int CO_CD)
        {
            string dbNm = sDbNm(SITE_CD);

            string sql = "" +
                " SELECT CO_CD, CO_NM " +
                " FROM [PLUS-" + dbNm + "].dbo.View_Company " +
                " WHERE SITE_CD = " + SITE_CD + " AND USING_FLAG = 1 ";

            if (MYCOM_FLAG == 1)
                sql += " AND CO_CD = " + CO_CD + " ";


            sql += "" +
                " ORDER BY SORT_NO, CO_NM ";

            DataSet ds = null;

            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }



        // LAB_STS 를 CMB BOX로 쓸 것인지 Frm의 용도 물어보기 
        //SELECT 
        public DataSet sLaborSearch(string SITE_CD, string CO_CD)
        {
            string dbNm = sDbNm(SITE_CD);

            string sql = "" +
                " SELECT LAB_NO, USER_NO, LAB_NM, BIRTH_DATE, MOBILE_NO, ISNULL(FACE_PHOTO,0) FACE_PHOTO, CO_CD, TEAM_CD,JOB_CCD, BLOCK_CCD, LAB_STS, AUTH_CD " +
                " FROM [PLUS-" + dbNm + "].dbo.View_Lab " +
                " WHERE SITE_CD = " + SITE_CD + " AND  CO_CD = " + CO_CD + " AND LAB_STS = 1";

            //if (LAB_STS != "")
            //{
            //    sql += " WHERE LAB_STS = '" + LAB_STS + "' ";
            //}

            sql += "" +
                " ORDER BY LAB_NO, LAB_NM ";

            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
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
            string sql = "" +
               " SELECT DEV_CD, DEVICE_ID, DEV_TYPE_SCD, DEV_IO_SCD, DEV_NM, IP, USING_FLAG, SORT_NO, MEMO " +
               " FROM [PLUS-" + DBNM + "].dbo.T00_DEVICE " +
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
        public int mDevice(string DBNM, string SITE_CD, string DEV_CD, string DEVICE_ID, string DEV_TYPE_SCD, string DEV_IO_SCD, string DEV_NM, string IP, string SORT_NO, string USING_FLAG, string MEMO)
        {
            string sql = "" +
              " UPDATE [PLUS-" + DBNM + "].dbo.T00_DEVICE " +
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
            string sql = "" +
                " INSERT INTO [PLUS-" + DBNM + "].dbo.T00_DEVICE_LOG (DEV_CD, LOG_NO, SITE_CD, DEVICE_ID, DEV_TYPE_SCD, DEV_IO_SCD, DEV_NM, IP, USING_FLAG, SORT_NO, MEMO, INPUT_ID, INPUT_DT) " +
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