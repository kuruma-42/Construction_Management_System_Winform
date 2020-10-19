using EldigmPlusDb.DbClass.Common;
using Framework.Data;
using System;
using System.Collections;
using System.Data;

namespace EldigmPlusClassLibrary.DbClass.Sys.CompanyTeam
{
    public class DbTeam
    {
        DataObj _sqlHelper = null;

        public DbTeam(string pCon_IP, string pCon_DB, string pCon_USER, string pType)
        {
            string mainKey_E256 = "6LL/J2V3x6N8kXK3qj5FOxZpRR20xWFlgnscFikXwy0=";

            EncDecClass edc = new EncDecClass();
            string mainKey_D256 = edc.AESDecrypt256(mainKey_E256, "eldigm");
            string strDbconn = "";
            if (pType == "1")
                strDbconn = pCon_IP + pCon_DB + edc.AESDecrypt256(pCon_USER, mainKey_D256);
            else
                strDbconn = pCon_IP + edc.AESDecrypt256(pCon_DB, mainKey_D256) + edc.AESDecrypt256(pCon_USER, mainKey_D256);
            //string strDbconn = pCon_IP + edc.AESDecrypt256(pCon_DB, mainKey_D256) + edc.AESDecrypt256(pCon_USER, mainKey_D256);

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

        //COMPANY CMB BOX 
        public DataSet companyCmb(string SITE_CD)
        {
            string dbNm = sDbNm(SITE_CD);

            string sql = "" +
                " SELECT CO_CD, CO_NM " +
                " FROM [PLUS-ELDIGM].dbo.View_Company " +
                " WHERE SITE_CD = " + SITE_CD + " ";


            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }


        //SELECT
        public DataSet sTeam(string SITE_CD, string CO_CD, string USING_FLAG, string TEAM_NM)
        {
            string dbNm = sDbNm(SITE_CD);

            string sql = "" +

            " SELECT A.TEAM_CD, A.TEAM_NM,A.USING_FLAG,A.SORT_NO,A.MEMO " +
            " FROM [PLUS-" + dbNm + "].dbo.T00_TEAM_SITE A " +
            " INNER JOIN [PLUS-" + dbNm + "].dbo.View_Company B ON A.CO_CD = B.CO_CD AND A.SITE_CD = B.SITE_CD " +
            " WHERE A.CO_CD = " + CO_CD + " AND A.SITE_CD = " + SITE_CD + " ";

            if (TEAM_NM != "")
            {
                sql += " AND A.TEAM_NM LIKE '%" + TEAM_NM + "%' ";
            }
            if (USING_FLAG != "")
            {
                sql += " AND A.USING_FLAG = '" + USING_FLAG + "' ";
            }

            sql += "" +
                " ORDER BY A.SORT_NO, A.TEAM_NM ";

            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }


        //UPDATE
        public int mTeamMemco(string SITE_CD, string TEAM_CD, string TEAM_NM, string USING_FLAG, string SORT_NO, string MEMO)
        {
            string dbNm = sDbNm(SITE_CD);
            string sql = "" +
                " UPDATE [PLUS-" + dbNm + "].dbo.T00_TEAM_SITE " +
                " SET TEAM_NM = '" + TEAM_NM + "',USING_FLAG = " + USING_FLAG + ", SORT_NO = " + SORT_NO + ", MEMO = '" + MEMO + "' " +
                " WHERE TEAM_CD = " + TEAM_CD + " AND SITE_CD = " + SITE_CD + " ";


            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

        //INSERT TEAM WITH PROCEDURE
        public string aTeamPro(Hashtable param, out Hashtable outVal)
        {
            string sql = "sp_TEAM_New";

            object reObj = _sqlHelper.ExecuteCommandsp(sql, param, out outVal);

            return reObj.ToString();
        }


        //CONST CMB BOX 
        public DataSet constCmb(string SITE_CD)
        {
            string dbNm = sDbNm(SITE_CD);

            string sql = "" +
            " SELECT VALUE, TEXT " +
                " FROM( " +
                    " SELECT CCODE AS VALUE, CCODE_NM AS TEXT, SORT_NO " +
                    " FROM[PLUS-" + dbNm + "].dbo.View_Code_Comn " +
                    " WHERE CCODE_GRP = 'Const' " +
                    " AND SITE_CD = " + SITE_CD + " AND USING_FLAG = 1 " +
                    " UNION ALL " +
                    " SELECT '0' AS VALUE, '미선택' AS TEXT, '99999999' AS SORT_NO " +
                    " ) X " +
              " ORDER BY SORT_NO, TEXT ";


            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }

        //CO_TYPE CMB BOX 
        public DataSet cotype_Cmb()
        {
            string sql = "" +

            " SELECT VALUE, TEXT " +
            " FROM " +
                " ( " +
                    " SELECT SCODE AS VALUE, SCODE_NM AS TEXT, SORT_NO " +
                    " FROM [PLUS_MAIN].dbo.TM00_CODE_SYS " +
                    " WHERE SCODE_GRP = 'CoType' " +
                    " AND USING_FLAG = 1 " +
                    " UNION ALL " +
                    " SELECT '0' AS VALUE, '미선택' AS TEXT, '99999999' AS SORT_NO " +
                    " ) X " +
            " ORDER BY SORT_NO, TEXT ";


            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }

        //CONST CMB BOX Without NoSelect
        public DataSet constCmb2(string SITE_CD)
        {
            string dbNm = sDbNm(SITE_CD);

            string sql = "" +
                " SELECT CCODE, CCODE_NM " +
                " FROM [PLUS-" + dbNm + "].dbo.View_Code_Comn " +
                " WHERE CCODE_GRP = 'Const' " +
                " AND SITE_CD = " + SITE_CD + " AND USING_FLAG = 1 " +
                " ORDER BY SORT_NO, CCODE_NM ";



            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }


        //CO_TYPE CMB BOX Without NoSelct
        public DataSet cotype_Cmb2()
        {
            string sql = "" +
                " SELECT SCODE , SCODE_NM " +
                " FROM [PLUS_MAIN].dbo.TM00_CODE_SYS " +
                " WHERE SCODE_GRP = 'CoType' AND USING_FLAG = 1 " +
                " ORDER BY SORT_NO, SCODE_NM ";


            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }



        public DataSet sCompany(string SITE_CD, string USING_FLAG, string CO_NM)
        {
            string dbNm = sDbNm(SITE_CD);

            string sql = "" +

            " SELECT A.CO_CD, A.CO_NM, ISNULL(A.HEADCO_CD,'') HEADCO_CD, A.CONST_CCD, A.CO_TYPE_SCD, ISNULL(A.SORT_NO, '') SORT_NO " +
            " , A.SITE_CD, A.START_DATE, A.END_DATE, A.USING_FLAG, ISNULL(A.MEMO, '') MEMO, B.BIZ_NO, B.OWNER_NM, B.TEL, B.ADDR, B.USING_CNT " +
            " FROM [PLUS-" + dbNm + "].dbo.View_Company A " +
            " INNER JOIN [PLUS_MAIN].dbo.TM00_COMPANY b on a.CO_CD = b.CO_CD " +
            " WHERE SITE_CD =" + SITE_CD + " ";

            if (CO_NM != "")
            {
                sql += " AND A.CO_NM LIKE '%" + CO_NM + "%' ";
            }
            if (USING_FLAG != "")
            {
                sql += " AND A.USING_FLAG = '" + USING_FLAG + "' ";
            }

            sql += "" +
                " ORDER BY SORT_NO, A.CO_NM ";

            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }

        public int mCompanyMain(string CO_CD, string CO_NM, string BIZ_NO, string CONST_CCD, string CO_TYPE_SCD, string OWNER_NM, string TEL, string ADDR)
        {
            string sql = "" +
                " UPDATE [PLUS_MAIN].dbo.TM00_COMPANY " +
                " SET CO_NM = '" + CO_NM + "', BIZ_NO = '" + BIZ_NO + "', CONST_CCD = " + CONST_CCD + ", CO_TYPE_SCD = '" + CO_TYPE_SCD +
                "', OWNER_NM = '" + OWNER_NM + "', TEL = '" + TEL + "', ADDR = '" + ADDR + "' " +
                " WHERE CO_CD = " + CO_CD + " ";


            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

        public int mCompanyMemco(string SITE_CD, string CO_CD, string CO_NM, string HEADCO_CD, string CONST_CCD, string CO_TYPE_SCD, string SORT_NO)
        {
            string dbNm = sDbNm(SITE_CD);
            string sql = "" +

                " UPDATE [PLUS-" + dbNm + "].dbo.T00_COMPANY " +
                " SET CO_NM = '" + CO_NM + "', HEADCO_CD = '" + HEADCO_CD + "', CONST_CCD =" + CONST_CCD + ", CO_TYPE_SCD = '" + CO_TYPE_SCD + "', SORT_NO = " + SORT_NO + " " +
                " WHERE CO_CD =" + CO_CD + " ";



            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }


        public int mCompanyMemcoSite(string SITE_CD, string CO_CD, string START_DATE, string END_DATE, string USING_FLAG, string SORT_NO, string MEMO)
        {
            string dbNm = sDbNm(SITE_CD);
            string sql = "" +
                " UPDATE [PLUS-" + dbNm + "].dbo.T00_COMPANY_SITE " +
                " SET START_DATE = " + START_DATE + ", END_DATE = " + END_DATE + ", USING_FLAG = " + USING_FLAG + ", SORT_NO = " + SORT_NO + ", MEMO = '" + MEMO + "' " +
                " WHERE CO_CD = " + CO_CD + " AND SITE_CD = " + SITE_CD + " ";


            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }

        //INSERT MEMCO COMPANY_SITE
        public int aCompanyMemcoSite(string CO_CD, string SITE_CD, string START_DATE, string END_DATE, string USING_FLAG, string SORT_NO, string MEMO, string INPUT_ID)
        {
            string dbNm = sDbNm(SITE_CD);
            string sql = "" +
                " INSERT INTO [PLUS-" + dbNm + "].dbo.T00_COMPANY_SITE (CO_CD, SITE_CD, START_DATE, END_DATE, USING_FLAG, SORT_NO, MEMO, INPUT_ID, INPUT_DT) " +
                " VALUES(" + CO_CD + ", " + SITE_CD + ", " + START_DATE + ", " + END_DATE + ", " + USING_FLAG + ", " + SORT_NO + ", " + MEMO + ", " + INPUT_ID + ", GETDATE())";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }


        //INSERT COMPANY WITH PROCEDURE
        public string aCompanyPro(Hashtable param, out Hashtable outVal)
        {
            string sql = "sp_COMPANY_New";

            object reObj = _sqlHelper.ExecuteCommandsp(sql, param, out outVal);

            return reObj.ToString();
        }

        //COMPANY MAIN LOG UPDATE 
        public int mConpanyMainLog(string CO_CD, string CO_NM, string BIZ_NO, string CONST_CCD, string CO_TYPE_SCD, string OWNER_NM, string TEL, string ADDR, string USING_CNT, string INPUT_ID)
        {
            string sql = "" +
                " INSERT INTO [PLUS_MAIN].dbo.TM00_COMPANY_LOG (LOG_NO, CO_CD, CO_NM, BIZ_NO, CONST_CCD, CO_TYPE_SCD, OWNER_NM, TEL, ADDR, USING_CNT, INPUT_ID, INPUT_DT) " +
                " VALUES ((SELECT ISNULL(MAX(LOG_NO ),0)+1 FROM [PLUS_MAIN].dbo.TM00_COMPANY_LOG WHERE CO_CD = " + CO_CD + "), " + CO_CD + ", '" + CO_NM + "' ,'" + BIZ_NO + "', " + CONST_CCD + ", '" + CO_TYPE_SCD + "', '" + OWNER_NM + "', '" + TEL + "', '" + ADDR + "', " + USING_CNT + ", " + INPUT_ID + ", GETDATE())";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }


        //COMPANY MEMCO SITE LOG UPDATE 
        public int mCompanySiteLog(string CO_CD, string SITE_CD, string CO_NM, string CONST_CCD, string CO_TYPE_SCD, string START_DATE, string END_DATE, string USING_FLAG, string SORT_NO, string MEMO, string INPUT_ID)
        {
            string dbNm = sDbNm(SITE_CD);
            string sql = "" +
            " INSERT INTO [PLUS-" + dbNm + "].dbo.T00_COMPANY_SITE_LOG (CO_CD, SITE_CD, LOG_NO, CO_NM, CONST_CCD, CO_TYPE_SCD, START_DATE, END_DATE, USING_FLAG, SORT_NO, MEMO, INPUT_ID, INPUT_DT) " +
            " VALUES (" + CO_CD + ", " + SITE_CD + ", (SELECT ISNULL(MAX(LOG_NO),0)+1 FROM [PLUS-" + dbNm + "].dbo.T00_COMPANY_SITE_LOG WHERE SITE_CD = " + SITE_CD + " AND CO_CD = " + CO_CD + ") " +
            " , '" + CO_NM + "', " + CONST_CCD + ", '" + CO_TYPE_SCD + "', " + START_DATE + ", " + END_DATE + ", " + USING_FLAG + ", " + SORT_NO + ", '" + MEMO + "', " + INPUT_ID + ", GETDATE())";


            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }
    }
}
