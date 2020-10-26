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



        //BLOCK CMB BOX 
        public string sMyBlockFlag(string SITE_CD, string AUTH_CD)
        {
            string dbNm = "";
            dbNm = sDbNm(SITE_CD);

            string sql = "" +

            " SELECT MYBLOCK_FLAG FROM [PLUS-" + dbNm + "].dbo.T00_CODE_AUTH A " +
            " INNER JOIN [PLUS-" + dbNm + "].dbo.T00_CODE_AUTH_SITE B ON A.AUTH_CD = B.AUTH_CD " +
            " WHERE B.AUTH_CD = '" + AUTH_CD + "' AND B.SITE_CD = " + SITE_CD + " ";


            object reVal = null;

            if (_sqlHelper != null)
                reVal = _sqlHelper.ExecuteScalar(sql);

            return reVal.ToString();
        }


        //BLOCK CMB BOX 
        public DataSet sLaborBlockList(string SITE_CD, int MYBLOCK_FLAG, int CCODE)
        {
            string dbNm = sDbNm(SITE_CD);

            string sql = "" +
                " SELECT VALUE, TEXT  " +
                " FROM( " +
                " SELECT CCODE AS VALUE, CCODE_NM AS TEXT, SORT_NO " +
                " FROM [PLUS-" + dbNm + "].dbo.View_Code_Comn " +
                " WHERE CCODE_GRP = 'Block' AND SITE_CD = " + SITE_CD + " AND USING_FLAG = 1 " +
                " UNION ALL " +
                " SELECT '0' AS VALUE, '구역' AS TEXT, '9999999' AS SORT_NO " +
                " )X ";

            if (MYBLOCK_FLAG == 1)
                sql += " WHERE VALUE = " + CCODE + " ";

            sql += "" +
                " ORDER BY SORT_NO, TEXT ";

            DataSet ds = null;

            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }


        //CONST CMB BOX 
        public string sMyConFlag(string SITE_CD, string AUTH_CD)
        {
            string dbNm = "";
            dbNm = sDbNm(SITE_CD);

            string sql = "" +

            " SELECT MYCON_FLAG FROM [PLUS-" + dbNm + "].dbo.T00_CODE_AUTH A " +
            " INNER JOIN [PLUS-" + dbNm + "].dbo.T00_CODE_AUTH_SITE B ON A.AUTH_CD = B.AUTH_CD " +
            " WHERE B.AUTH_CD = '" + AUTH_CD + "' AND B.SITE_CD = " + SITE_CD + " ";


            object reVal = null;

            if (_sqlHelper != null)
                reVal = _sqlHelper.ExecuteScalar(sql);

            return reVal.ToString();
        }


        //CONST CMB BOX 
        public DataSet sLaborConstList(string SITE_CD, int MYCON_FLAG, int CCODE)
        {
            string dbNm = sDbNm(SITE_CD);

            string sql = "" +
                " SELECT VALUE, TEXT  " +
                " FROM( " +
                " SELECT CCODE AS VALUE, CCODE_NM AS TEXT, SORT_NO " +
                " FROM [PLUS-" + dbNm + "].dbo.View_Code_Comn " +
                " WHERE CCODE_GRP = 'Const' AND SITE_CD = " + SITE_CD + " AND USING_FLAG = 1 " +
                " UNION ALL " +
                " SELECT '0' AS VALUE, '공종' AS TEXT, '9999999' AS SORT_NO " +
                " )X ";

            if (MYCON_FLAG == 1)
                sql += " WHERE VALUE = " + CCODE + " ";

            sql += "" +
                " ORDER BY SORT_NO, TEXT ";

            DataSet ds = null;

            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }
                                   

        //JOB CMB BOX 
        public DataSet sLaborJobList(string SITE_CD)
        {
            string dbNm = sDbNm(SITE_CD);

            string sql = "" +
                " SELECT VALUE, TEXT  " +
                " FROM( " +
                " SELECT CCODE AS VALUE, CCODE_NM AS TEXT, SORT_NO " +
                " FROM [PLUS-" + dbNm + "].dbo.View_Code_Comn " +
                " WHERE CCODE_GRP = 'Job' AND SITE_CD = " + SITE_CD + " AND USING_FLAG = 1 " +
                " UNION ALL " +
                " SELECT '0' AS VALUE, '직종' AS TEXT, '9999999' AS SORT_NO " +
                " )X ";         

            sql += "" +
                " ORDER BY SORT_NO, TEXT ";

            DataSet ds = null;

            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }

        //COMPANY CMB BOX 
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
                " SELECT VALUE, TEXT  " +
                " FROM( " +
                " SELECT CO_CD AS VALUE, CO_NM AS TEXT, SORT_NO " +
                " FROM [PLUS-" + dbNm + "].dbo.View_Company " +
                " WHERE SITE_CD = " + SITE_CD + " AND USING_FLAG = 1 " +
                " UNION ALL " +
                " SELECT '0' AS VALUE, '업체' AS TEXT, '999999' AS SORT_NO " +
                " )X ";

            if (MYCOM_FLAG == 1)
                sql += " WHERE VALUE = " + CO_CD + " ";

            sql += "" +
                " ORDER BY SORT_NO, TEXT ";


            DataSet ds = null;

            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }



        //TEAM CMB BOX 
        public string sMyTeamFlag(string SITE_CD, string AUTH_CD)
        {
            string dbNm = "";
            dbNm = sDbNm(SITE_CD);

            string sql = "" +

            " SELECT MYTEAM_FLAG FROM [PLUS-" + dbNm + "].dbo.T00_CODE_AUTH A " +
            " INNER JOIN [PLUS-" + dbNm + "].dbo.T00_CODE_AUTH_SITE B ON A.AUTH_CD = B.AUTH_CD " +
            " WHERE B.AUTH_CD = '" + AUTH_CD + "' AND B.SITE_CD = " + SITE_CD + " ";


            object reVal = null;

            if (_sqlHelper != null)
                reVal = _sqlHelper.ExecuteScalar(sql);

            return reVal.ToString();
        }


        //TEAM CMB BOX 
        public DataSet sLaborTeamList(string SITE_CD, int MYTEAM_FLAG, int TEAM_CD, string CO_CD)
        {
            string dbNm = sDbNm(SITE_CD);

            string sql = "" +
                " SELECT VALUE, TEXT  " +
                " FROM( " +
                " SELECT TEAM_CD AS VALUE, TEAM_NM AS TEXT, SORT_NO " +
                " FROM [PLUS-" + dbNm + "].dbo.T00_TEAM_SITE " +
                " WHERE SITE_CD = " + SITE_CD + " AND USING_FLAG = 1 AND CO_CD = " + CO_CD + " " +
                " UNION ALL " +
                " SELECT '0' AS VALUE, '팀' AS TEXT, '999999' AS SORT_NO " +
                " )X ";

            if (MYTEAM_FLAG == 1)
                sql += " WHERE VALUE = " + TEAM_CD + " ";

            sql += "" +
                " ORDER BY SORT_NO, TEXT ";


            DataSet ds = null;

            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }




        // LAB_STS 를 CMB BOX로 쓸 것인지 Frm의 용도 물어보기 
        //SELECT 
        public DataSet sLaborSearch(string SITE_CD, string BLOCK_CCD, string CONST_CCD, string CO_CD, string TEAM_CD, string SEARCH_CONDITION, string SEARCH_TXT)
        {
            string dbNm = sDbNm(SITE_CD);

            string sql = "" +
            //" SELECT LAB_NO, USER_NO, LAB_NM, BIRTH_DATE, MOBILE_NO, ISNULL(FACE_PHOTO,0) FACE_PHOTO, CO_CD, TEAM_CD, JOB_CCD, BLOCK_CCD, LAB_STS, AUTH_CD " +
            //" FROM [PLUS-" + dbNm + "].dbo.View_Lab " +
            //" WHERE SITE_CD = " + SITE_CD + "  AND LAB_STS = 1";

            " SELECT A.LAB_NO, COM.CO_NM, A.LAB_NM, ISNULL(A.JOB_NM, '') JOB_NM, ISNULL(TEAM.TEAM_NM, '') TEAM_NM , A.BIRTH_DATE, A.MOBILE_NO, A.USER_NO, A.AUTH_CD  " +
            " FROM [PLUS-" + dbNm + "].dbo.View_Lab_Job A " +
            " INNER JOIN [PLUS-" + dbNm + "].dbo.View_Company COM ON A.SITE_CD = COM.SITE_CD AND A.CO_CD = COM.CO_CD " +
            " LEFT OUTER JOIN [PLUS-" + dbNm + "].dbo.T00_TEAM_SITE TEAM ON A.SITE_CD = TEAM.SITE_CD AND A.CO_CD = TEAM.CO_CD AND A.TEAM_CD = TEAM.TEAM_CD " +
            " WHERE A.SITE_CD = " + SITE_CD + " AND A.LAB_STS = 1";



            if (BLOCK_CCD != "0")
            {
                sql += "AND A.BLOCK_CCD = " + BLOCK_CCD + " ";
            }

            if (CONST_CCD != "0")
            {
                sql += "AND COM.CONST_CCD = " + CONST_CCD + " ";
            }

            if (CO_CD != "0")
            {
                sql += "AND A.CO_CD = " + CO_CD + " ";
            }

            if (TEAM_CD != "0")
            {
                sql += "AND A.TEAM_CD = " + TEAM_CD + " ";
            }

            if (SEARCH_CONDITION == "1" && SEARCH_TXT != "")
            {
                sql += " AND A.LAB_NM LIKE '%" + SEARCH_TXT + "%' ";
            }

            if (SEARCH_CONDITION == "2" && SEARCH_TXT != "")
            {
                sql += " AND A.MOBILE_NO LIKE '%" + SEARCH_TXT + "%' ";
            }

            if (SEARCH_CONDITION == "3" && SEARCH_TXT != "")
            {
                sql += " AND A.BIRTH_DATE LIKE '%" + SEARCH_TXT + "%' ";
            }

            if (SEARCH_CONDITION == "4" && SEARCH_TXT != "")
            {
                sql += " AND A.JOB_NM LIKE '%" + SEARCH_TXT + "%' ";
            }


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

    }

}
