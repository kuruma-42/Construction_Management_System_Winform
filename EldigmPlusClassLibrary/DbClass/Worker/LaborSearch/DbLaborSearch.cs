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


        // ** LaborSearch Part Start **      


        //TOTAL FLAG 
        public DataSet sMyFlags(string SITE_CD, string AUTH_CD)
        {
            string dbNm = "";
            dbNm = sDbNm(SITE_CD);
            string con = "[PLUS-" + dbNm + "].dbo.";


            string sql = "" +

            " SELECT MYBLOCK_FLAG, MYCON_FLAG, MYCOM_FLAG, MYTEAM_FLAG " +
            " FROM " + con + "T00_CODE_AUTH A " +
            " INNER JOIN " + con + "T00_CODE_AUTH_SITE B ON A.AUTH_CD = B.AUTH_CD " +
            " WHERE B.AUTH_CD = '" + AUTH_CD + "' AND B.SITE_CD = " + SITE_CD + " ";


            DataSet ds = null;

            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }





        //BLOCK CMB BOX 
        public DataSet sLaborBlockList(string SITE_CD, int MYBLOCK_FLAG, int CCODE, string pLngBlock)
        {
            string dbNm = sDbNm(SITE_CD);
            string con = "[PLUS-" + dbNm + "].dbo.";

            string sql = "" +
                " SELECT VALUE, TEXT  " +
                " FROM( " +
                " SELECT CCODE AS VALUE, CCODE_NM AS TEXT, SORT_NO " +
                " FROM " + con + "View_Code_Comn " +
                " WHERE CCODE_GRP = 'Block' AND SITE_CD = " + SITE_CD + " AND USING_FLAG = 1 " +
                " UNION ALL " +
                " SELECT '0' AS VALUE, '" + pLngBlock + "' AS TEXT, '9999999' AS SORT_NO " +
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
        public DataSet sLaborConstList(string SITE_CD, int MYCON_FLAG, int CCODE, string pLngConst)
        {
            string dbNm = sDbNm(SITE_CD);
            string con = "[PLUS-" + dbNm + "].dbo.";

            string sql = "" +
                " SELECT VALUE, TEXT  " +
                " FROM( " +
                " SELECT CCODE AS VALUE, CCODE_NM AS TEXT, SORT_NO " +
                " FROM " + con + "View_Code_Comn " +
                " WHERE CCODE_GRP = 'Const' AND SITE_CD = " + SITE_CD + " AND USING_FLAG = 1 " +
                " UNION ALL " +
                " SELECT '0' AS VALUE, '" + pLngConst + "' AS TEXT, '9999999' AS SORT_NO " +
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
        public DataSet sLaborJobList(string SITE_CD, string pLngJob)
        {
            string dbNm = sDbNm(SITE_CD);
            string con = "[PLUS-" + dbNm + "].dbo.";

            string sql = "" +
                " SELECT VALUE, TEXT  " +
                " FROM( " +
                " SELECT CCODE AS VALUE, CCODE_NM AS TEXT, SORT_NO " +
                " FROM " + con + "View_Code_Comn " +
                " WHERE CCODE_GRP = 'Job' AND SITE_CD = " + SITE_CD + " AND USING_FLAG = 1 " +
                " UNION ALL " +
                " SELECT '0' AS VALUE, '" + pLngJob +"' AS TEXT, '9999999' AS SORT_NO " +
                " )X ";         

            sql += "" +
                " ORDER BY SORT_NO, TEXT ";

            DataSet ds = null;

            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }



        //COMPANY CMB BOX 
        public DataSet sLaborCompanyList(string SITE_CD, int MYCOM_FLAG, int CO_CD, string pLngCom)
        {
            string dbNm = sDbNm(SITE_CD);
            string con = "[PLUS-" + dbNm + "].dbo.";

            string sql = "" +
                " SELECT VALUE, TEXT  " +
                " FROM( " +
                " SELECT CO_CD AS VALUE, CO_NM AS TEXT, SORT_NO " +
                " FROM " + con + "View_Company " +
                " WHERE SITE_CD = " + SITE_CD + " AND USING_FLAG = 1 " +
                " UNION ALL " +
                " SELECT '0' AS VALUE, '" + pLngCom + "' AS TEXT, '999999' AS SORT_NO " +
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
        public DataSet sLaborTeamList(string SITE_CD, int MYTEAM_FLAG, int TEAM_CD, string CO_CD, string pLngTeam)
        {
            string dbNm = sDbNm(SITE_CD);
            string con = "[PLUS-" + dbNm + "].dbo.";

            string sql = "" +
                " SELECT VALUE, TEXT  " +
                " FROM( " +
                " SELECT TEAM_CD AS VALUE, TEAM_NM AS TEXT, SORT_NO " +
                " FROM " + con + "T00_TEAM_SITE " +
                " WHERE SITE_CD = " + SITE_CD + " AND USING_FLAG = 1 AND CO_CD = " + CO_CD + " " +
                " UNION ALL " +
                " SELECT '0' AS VALUE, '" + pLngTeam + "' AS TEXT, '999999' AS SORT_NO " +
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
            string con = "[PLUS-" + dbNm + "].dbo.";

            string sql = "" +

            " SELECT A.LAB_NO, COM.CO_NM, A.LAB_NM, ISNULL(A.JOB_NM, '') JOB_NM, ISNULL(TEAM.TEAM_NM, '') TEAM_NM , A.BIRTH_DATE, A.MOBILE_NO, A.USER_NO, A.AUTH_CD, A.BLOCK_CCD, A.CO_CD, A.TEAM_CD,A.JOB_CCD  " +
            " FROM " + con + "View_Lab_Job A " +
            " INNER JOIN " + con + "View_Company COM ON A.SITE_CD = COM.SITE_CD AND A.CO_CD = COM.CO_CD " +
            " LEFT OUTER JOIN " + con + "T00_TEAM_SITE TEAM ON A.SITE_CD = TEAM.SITE_CD AND A.CO_CD = TEAM.CO_CD AND A.TEAM_CD = TEAM.TEAM_CD " +
            " WHERE A.SITE_CD = " + SITE_CD + " ";

            //AND A.LAB_STS = 1


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

        // ** LaborSearch Part END **









        // ** LaborSearch Pop Up Part START  **  

        public string sLabAprvFlag(string SITE_CD, string AUTH_CD)
        {
            string dbNm = "";
            dbNm = sDbNm(SITE_CD);
            string con = "[PLUS-" + dbNm + "].dbo.";

            string sql = "" +
                " SELECT LAB_APRV_FLAG " +
                " FROM " + con + "T00_CODE_AUTH_SITE " +
                " WHERE AUTH_CD = '" + AUTH_CD + "' ";


            object reVal = null;

            if (_sqlHelper != null)
                reVal = _sqlHelper.ExecuteScalar(sql);

            return reVal.ToString();
        }


        //SELECT THE LOWEST AUTH_CD AT SITE 
        public string sLabAuth(string SITE_CD)
        {
            string dbNm = "";
            dbNm = sDbNm(SITE_CD);
            string con = "[PLUS-" + dbNm + "].dbo.";

            string sql = "" +
                " SELECT AUTH_CD  FROM " + con + "T00_CODE_AUTH_SITE " +
                " WHERE SITE_CD = " + SITE_CD + " " +
                " AND USING_FLAG = 1 " +
                " AND AUTH_LEVEL = (SELECT MAX(AUTH_LEVEL) FROM [PLUS-ELDIGM].dbo.T00_CODE_AUTH_SITE WHERE SITE_CD = " + SITE_CD + ") ";


            object reVal = null;

            if (_sqlHelper != null)
                reVal = _sqlHelper.ExecuteScalar(sql);

            return reVal.ToString();
        }

        //DUPLICATE CHECK MEMBER AND RETURN LAB_NO 
        public string exLabMember(string SITE_CD, string LAB_NM, string MOBILE_NO, string BIRTH_DATE)
        {
            string dbNm = "";
            dbNm = sDbNm(SITE_CD);

            string con = "[PLUS-" + dbNm + "].dbo.";

            string sql = "" +
          " SELECT LAB_NO FROM " + con + "T01_LAB " +
          " WHERE LAB_NM = '" + LAB_NM + "' " +
          " AND MOBILE_NO = '" + MOBILE_NO + "' " +
          " AND BIRTH_DATE = '" + BIRTH_DATE + "' ";


            object reVal = null;

            if (_sqlHelper != null)
                reVal = _sqlHelper.ExecuteScalar(sql);

            return reVal.ToString();
        }


        //DUPLICATE CHECK MAIN AND RETURN LAB_NO 
        public string exLabMain(string USER_NM, string MOBILE_NO, string BIRTH_DATE)
        {
            string sql = "" +
           " SELECT LAB_NO FROM [PLUS_MAIN].dbo.TM01_LAB_PSINFO " +
            " WHERE USER_NM = '" + USER_NM + "' " +
            " AND MOBILE_NO = '" + MOBILE_NO + "' " +
            " AND BIRTH_DATE = '" + BIRTH_DATE + "' ";


            object reVal = null;

            if (_sqlHelper != null)
                reVal = _sqlHelper.ExecuteScalar(sql);

            return reVal.ToString();
        }

        //CCODE COMBO BOX (USING THIS CMB CCODE AS TGRP_CCD)
        public DataSet sLaborAddInfoCcode(string DBNM, string SITE_CD, string AUTH_CD)
        {
            string sql = "" +
                " SELECT A.CCODE, A.CCODE_NM FROM (SELECT A.CCODE, A.CCODE_GRP, A.CCODE_NM, B.SORT_NO " +
                " FROM [PLUS-" + DBNM + "].dbo.T00_CODE_COMN A INNER JOIN [PLUS-" + DBNM + "].dbo.T00_CODE_COMN_SITE B " +
                " ON A.CCODE = B.CCODE WHERE SITE_CD = " + SITE_CD + " AND CCODE_GRP = 'AddinfoGrp' AND USING_FLAG = 1) A " +
                " INNER JOIN (SELECT CCODE_GRP FROM [PLUS-" + DBNM + "].dbo.T00_CODE_GRP_SETAUTH_SITE WHERE SITE_CD = " + SITE_CD + "" +
                " AND AUTH_CD = '" + AUTH_CD + "' AND CCODE_GRP = 'AddinfoGrp' AND VIEW_FLAG = 1) B ON A.CCODE_GRP = B.CCODE_GRP ";

            sql += "" +
                " ORDER BY SORT_NO, A.CCODE_NM ";

            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }


        //SELECT ADD INFO CHECK BOX (INSERT POP UP) 
        public DataSet sLaborAddInfo(string SITE_CD, string TCODE, string TGRP_CCD)
        {
            string dbNm = sDbNm(SITE_CD);
            string con = "[PLUS-" + dbNm + "].dbo.";

            string sql = "" +
                " SELECT TCODE, TTYPE_SCD, TCODE_NM FROM " + con + "View_Code_T " +
                " WHERE TTYPE_SCD = '" + TCODE + "' AND SITE_CD = " + SITE_CD + " AND USING_FLAG = 1 ";
                

            if (TGRP_CCD != "0")
            {
                sql += "AND TGRP_CCD = " + TGRP_CCD + " ";
            }

            sql += "" +
                " ORDER BY SORT_NO, TCODE_NM ";


            DataSet ds = null;

            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }


        //SELECT ADD INFO CHECK BOX (MODIFY POP UP) 
        public DataSet sLaborAddInfoModify(string LAB_NO, string SITE_CD, string TTYPE_SCD, string TGRP_CCD)
        {
            string dbNm = sDbNm(SITE_CD);
            string con = "[PLUS-" + dbNm + "].dbo.";

            string sql = "" +
               " SELECT A.TCODE, A.TTYPE_SCD, A.VALUE, B.TCODE_NM " + 
               " FROM " + 
               " ( " +
               " SELECT TCODE, TTYPE_SCD, VALUE " +
               " FROM " + con + "T01_LAB_TCODE_SITE " +
               " WHERE LAB_NO = " + LAB_NO + " AND SITE_CD = " + SITE_CD + " AND TTYPE_SCD = '" + TTYPE_SCD + "' " +
               " )A " +
               " INNER JOIN " +
               " ( " +
               " SELECT TCODE, TCODE_NM, TGRP_CCD, TTYPE_SCD, SORT_NO " +
               " FROM " + con + "View_Code_T " +
               " WHERE SITE_CD = " + SITE_CD + " " +
               " )B " +
               " ON A.TCODE = B.TCODE AND A.TTYPE_SCD = B.TTYPE_SCD " +
               " WHERE B.TGRP_CCD = " + TGRP_CCD + " " +
               " ORDER BY B.SORT_NO, B.TCODE_NM ";


            DataSet ds = null;

            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }

        //ADD INFO dgv4 COMBO (ex. CarSize, InspectionMethod)  
        public DataSet sLaborAddInfoSub(string DBNMN, string TCODE)
        {
            string con = "[PLUS-" + DBNMN + "].dbo.";

            string sql = "" +
               " SELECT TSCODE, TSCODE_NM FROM " + con + "T00_CODE_TSUB WHERE TCODE = '" + TCODE + "' " + 
                " ORDER BY TSCODE, TSCODE_NM";

            DataSet ds = null;
            if (_sqlHelper != null)
                ds = _sqlHelper.ExecuteFill(sql);

            return ds;
        }



        //INSERT COMPANY WITH PROCEDURE
        public string aLaborPro(Hashtable param, out Hashtable outVal)
        {
            string sql = "sp_LAB_New";

            object reObj = _sqlHelper.ExecuteCommandsp(sql, param, out outVal);

            return reObj.ToString();
        }


        //MODIFY COMPANY WITH PROCEDURE
        public string mLaborPro(Hashtable param, out Hashtable outVal)
        {
            string sql = "sp_LAB_Modify";

            object reObj = _sqlHelper.ExecuteCommandsp(sql, param, out outVal);

            return reObj.ToString();
        }


        //INSERT TCODE_LAB 
        public int aLaborLabTcodeSite(string DBNM, string LAB_NO, string SITE_CD, string TCODE, string TTYPE_SCD, string VALUE)
        {
            string con = "[PLUS-" + DBNM + "].dbo.";
            string sql = "" +
                " INSERT INTO " + con + "T01_LAB_TCODE_SITE(LAB_NO, SITE_CD, TCODE, TTYPE_SCD, VALUE) " +
                " VALUES(" + LAB_NO + ", " + SITE_CD + ",  '" + TCODE + "',  '" + TTYPE_SCD + "',  '" + VALUE + "') ";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }


        //UPDATE TCODE_LAB 
        public int mLaborLabTcodeSite(string DBNM, string LAB_NO, string SITE_CD, string TCODE, string VALUE)
        {
            string con = "[PLUS-" + DBNM + "].dbo.";
            string sql = "" +
                " UPDATE " + con + "T01_LAB_TCODE_SITE SET VALUE = '" + VALUE + "' " +
                " WHERE LAB_NO = " + LAB_NO + " AND SITE_CD = " + SITE_CD + " AND TCODE = '" + TCODE + "' ";

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }  


        //INSERT TCODE_LAB LOG
        public int aLaborLabTcodeSiteLog(string DBNM, string LAB_NO, string SITE_CD, string TCODE, string TTYPE_SCD, string VALUE, string INPUT_ID)
        {
            string con = "[PLUS-" + DBNM + "].dbo.";
            string sql = "" +
                 " INSERT INTO " + con + " T01_LAB_TCODE_SITE_LOG(LAB_NO, SITE_CD, TCODE, LOG_NO, TTYPE_SCD, VALUE, INPUT_ID, INPUT_DT) " +
                 " VALUES(" + LAB_NO + ", " + SITE_CD + ", '" + TCODE + "', (SELECT ISNULL(MAX(LOG_NO), 0) + 1 FROM" + con + " T01_LAB_TCODE_SITE_LOG WHERE  LAB_NO = " + LAB_NO + "AND SITE_CD = " + SITE_CD + " AND TCODE = '" + TCODE + "') ,'" + TTYPE_SCD + "', '" + VALUE + "', " + INPUT_ID + ", GETDATE())"; 
  

            int reCnt = 0;
            if (_sqlHelper != null)
                reCnt = _sqlHelper.ExecuteCommand(sql);

            return reCnt;
        }









        ////FIRST INSERT LAB_TCODE_SITE_LOG 
        //public int aLaborLabTcodeSiteLog(string DBNM, string LAB_NO, string SITE_CD, string TCODE, string TTYPE_SCD, string VALUE, string INPUT_ID)
        //{
        //    string con = "[PLUS-" + DBNM + "].dbo.";
        //    string sql = "" +
        //         " INSERT INTO " + con + " T01_LAB_TCODE_SITE_LOG(LAB_NO, SITE_CD, TCODE, LOG_NO, TTYPE_SCD, VALUE, INPUT_ID, INPUT_DT) " +
        //         " VALUES(" + LAB_NO + ", " + SITE_CD + ", '" + TCODE + "', 1 ,'" + TTYPE_SCD + "', '" + VALUE + "', " + INPUT_ID + ", GETDATE())";


        //    int reCnt = 0;
        //    if (_sqlHelper != null)
        //        reCnt = _sqlHelper.ExecuteCommand(sql);

        //    return reCnt;
        //}


        //** READY FOR USING WHEN MY MODIFY GOING TO BE WRONG ** 
        //BLOCK CMB BOX 
        //public string sMyBlockFlag(string SITE_CD, string AUTH_CD)
        //{
        //    string dbNm = "";
        //    dbNm = sDbNm(SITE_CD);

        //    string con = "[PLUS-" + dbNm + "].dbo.";
        //    string sql = "" +

        //    " SELECT MYBLOCK_FLAG FROM " + con + "T00_CODE_AUTH A " +
        //    " INNER JOIN " + con + "T00_CODE_AUTH_SITE B ON A.AUTH_CD = B.AUTH_CD " +
        //    " WHERE B.AUTH_CD = '" + AUTH_CD + "' AND B.SITE_CD = " + SITE_CD + " ";


        //    object reVal = null;

        //    if (_sqlHelper != null)
        //        reVal = _sqlHelper.ExecuteScalar(sql);

        //    return reVal.ToString();
        //}

        //CONST CMB BOX 
        //public string sMyConFlag(string SITE_CD, string AUTH_CD)
        //{
        //    string dbNm = "";
        //    dbNm = sDbNm(SITE_CD);

        //    string con = "[PLUS-" + dbNm + "].dbo.";
        //    string sql = "" +

        //    " SELECT MYCON_FLAG FROM " + con + "T00_CODE_AUTH A " +
        //    " INNER JOIN " + con + "T00_CODE_AUTH_SITE B ON A.AUTH_CD = B.AUTH_CD " +
        //    " WHERE B.AUTH_CD = '" + AUTH_CD + "' AND B.SITE_CD = " + SITE_CD + " ";


        //    object reVal = null;

        //    if (_sqlHelper != null)
        //        reVal = _sqlHelper.ExecuteScalar(sql);

        //    return reVal.ToString();
        //}


        //COMPANY CMB BOX 
        //public string sMyComFlag(string SITE_CD, string AUTH_CD)
        //{
        //    string dbNm = "";
        //    dbNm = sDbNm(SITE_CD);

        //    string con = "[PLUS-" + dbNm + "].dbo.";
        //    string sql = "" +

        //    " SELECT MYCOM_FLAG FROM " + con + "T00_CODE_AUTH A " +
        //    " INNER JOIN " + con + "T00_CODE_AUTH_SITE B ON A.AUTH_CD = B.AUTH_CD " +
        //    " WHERE B.AUTH_CD = '" + AUTH_CD + "' AND B.SITE_CD = " + SITE_CD + " ";


        //    object reVal = null;

        //    if (_sqlHelper != null)
        //        reVal = _sqlHelper.ExecuteScalar(sql);

        //    return reVal.ToString();
        //}


        //TEAM CMB BOX 
        //public string sMyTeamFlag(string SITE_CD, string AUTH_CD)
        //{
        //    string dbNm = "";
        //    dbNm = sDbNm(SITE_CD);
        //    string con = "[PLUS-" + dbNm + "].dbo.";

        //    string sql = "" +

        //    " SELECT MYTEAM_FLAG FROM " + con + "T00_CODE_AUTH A " +
        //    " INNER JOIN " + con + "T00_CODE_AUTH_SITE B ON A.AUTH_CD = B.AUTH_CD " +
        //    " WHERE B.AUTH_CD = '" + AUTH_CD + "' AND B.SITE_CD = " + SITE_CD + " ";


        //    object reVal = null;

        //    if (_sqlHelper != null)
        //        reVal = _sqlHelper.ExecuteScalar(sql);

        //    return reVal.ToString();
        //}



    }

}
