using EldigmPlusSvc_Memco.Biz.Common;
using EldigmPlusSvc_Memco.Biz.Sys.Device;
using EldigmPlusSvc_Memco.Biz.Worker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EldigmPlusSvc_Memco.WebSvc.Sys.Worker
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드, svc 및 config 파일에서 클래스 이름 "WsWorkerLaborSearch"을 변경할 수 있습니다.
    // 참고: 이 서비스를 테스트하기 위해 WCF 테스트 클라이언트를 시작하려면 솔루션 탐색기에서 WsWorkerLaborSearch.svc나 WsWorkerLaborSearch.svc.cs를 선택하고 디버깅을 시작하십시오.
    public class WsWorkerLaborSearch : IWsWorkerLaborSearch
    {
        LogClass logs = new LogClass();


        //Block CMB BOX 
        public string sLaborBlockList(string pSiteCd, string pAuthCd, string pCcode, string pLngBlock, out List<DataComCombo> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizLaborSearch bizSys = null;
            try
            {
                bizSys = new BizLaborSearch();

                try
                {
                    ds = bizSys.sLaborBlockList(pSiteCd, pAuthCd, pCcode, pLngBlock);

                    reMsg = "[검색 성공]";
                    reCode = "Y";
                }
                catch (Exception ex)
                {
                    reMsg = "[검색 실패]" + ex.ToString();
                    reCode = "N";
                }
            }
            catch (Exception ex)
            {
                reMsg = "[검색 에러] :: " + ex.ToString();
                reCode = "N";
            }

            List<DataComCombo> data = new List<DataComCombo>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataComCombo>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsWorkerLaborSearch.svc  (Function)::sLaborBlockList  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }


        //Const CMB BOX 
        public string sLaborConstList(string pSiteCd, string pAuthCd, string pCcode, string pLngConst, out List<DataComCombo> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizLaborSearch bizSys = null;
            try
            {
                bizSys = new BizLaborSearch();

                try
                {
                    ds = bizSys.sLaborConstList(pSiteCd, pAuthCd, pCcode, pLngConst);

                    reMsg = "[검색 성공]";
                    reCode = "Y";
                }
                catch (Exception ex)
                {
                    reMsg = "[검색 실패]" + ex.ToString();
                    reCode = "N";
                }
            }
            catch (Exception ex)
            {
                reMsg = "[검색 에러] :: " + ex.ToString();
                reCode = "N";
            }

            List<DataComCombo> data = new List<DataComCombo>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataComCombo>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsWorkerLaborSearch.svc  (Function)::sLaborConstList  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }


        //JOB CMB BOX 
        public string sLaborJobList(string pSiteCd, string pLngJob, out List<DataComCombo> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizLaborSearch bizSys = null;
            try
            {
                bizSys = new BizLaborSearch();

                try
                {
                    ds = bizSys.sLaborJobList(pSiteCd, pLngJob);

                    reMsg = "[검색 성공]";
                    reCode = "Y";
                }
                catch (Exception ex)
                {
                    reMsg = "[검색 실패]" + ex.ToString();
                    reCode = "N";
                }
            }
            catch (Exception ex)
            {
                reMsg = "[검색 에러] :: " + ex.ToString();
                reCode = "N";
            }

            List<DataComCombo> data = new List<DataComCombo>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataComCombo>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsWorkerLaborSearch.svc  (Function)::sLaborJobList  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }


        //COMPANY CMB BOX 
        public string sLaborCompanyList(string pSiteCd, string pAuthCd, string pCoCd, string pLngCom, out List<DataComCombo> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizLaborSearch bizSys = null;
            try
            {
                bizSys = new BizLaborSearch();

                try
                {
                    ds = bizSys.sLaborCompanyList(pSiteCd, pAuthCd, pCoCd, pLngCom);

                    reMsg = "[검색 성공]";
                    reCode = "Y";
                }
                catch (Exception ex)
                {
                    reMsg = "[검색 실패]" + ex.ToString();
                    reCode = "N";
                }
            }
            catch (Exception ex)
            {
                reMsg = "[검색 에러] :: " + ex.ToString();
                reCode = "N";
            }

            List<DataComCombo> data = new List<DataComCombo>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataComCombo>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsWorkerLaborSearch.svc  (Function)::sLaborCompanyList  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }




        //COMPANY CMB BOX 
        public string sLaborTeamList(string pSiteCd, string pAuthCd, string pTeamCd, string pCoCd, string pLngTeam, out List<DataComCombo> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizLaborSearch bizSys = null;
            try
            {
                bizSys = new BizLaborSearch();

                try
                {
                    ds = bizSys.sLaborTeamList(pSiteCd, pAuthCd, pTeamCd, pCoCd, pLngTeam);

                    reMsg = "[검색 성공]";
                    reCode = "Y";
                }
                catch (Exception ex)
                {
                    reMsg = "[검색 실패]" + ex.ToString();
                    reCode = "N";
                }
            }
            catch (Exception ex)
            {
                reMsg = "[검색 에러] :: " + ex.ToString();
                reCode = "N";
            }

            List<DataComCombo> data = new List<DataComCombo>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataComCombo>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsWorkerLaborSearch.svc  (Function)::sLaborTeamList  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }


        //LAB INFO TYPE CMB 
        public string sLabInfoTypeList(string pSiteCd, string pLngCategory, out List<DataComComboStr> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizLaborSearch bizSys = null;
            try
            {
                bizSys = new BizLaborSearch();

                try
                {
                    ds = bizSys.sLabInfoTypeList(pSiteCd, pLngCategory);

                    reMsg = "[검색 성공]";
                    reCode = "Y";
                }
                catch (Exception ex)
                {
                    reMsg = "[검색 실패]" + ex.ToString();
                    reCode = "N";
                }
            }
            catch (Exception ex)
            {
                reMsg = "[검색 에러] :: " + ex.ToString();
                reCode = "N";
            }

            List<DataComComboStr> data = new List<DataComComboStr>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataComComboStr>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsWorkerLaborSearch.svc  (Function)::sLabInfoTypeList  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }


        //LAB INFO TYPE CMB 
        public string sLabTcodeList(string pSiteCd, string pTgrpCcd, string pTtypeScd, string pLngCategory, string pAuthCd, out List<DataComComboStr> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizLaborSearch bizSys = null;
            try
            {
                bizSys = new BizLaborSearch();

                try
                {
                    ds = bizSys.sLabTcodeList(pSiteCd, pTgrpCcd, pTtypeScd, pLngCategory, pAuthCd);

                    reMsg = "[검색 성공]";
                    reCode = "Y";
                }
                catch (Exception ex)
                {
                    reMsg = "[검색 실패]" + ex.ToString();
                    reCode = "N";
                }
            }
            catch (Exception ex)
            {
                reMsg = "[검색 에러] :: " + ex.ToString();
                reCode = "N";
            }

            List<DataComComboStr> data = new List<DataComComboStr>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataComComboStr>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsWorkerLaborSearch.svc  (Function)::sLabTcodeList  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        //CCODE COMBO BOX (USING THIS CMB CCODE AS TGRP_CCD **INCLUDE CATEGORY PARAMETER FOR VALUE 0**)
        public string sLaborAddInfoCcode2(string pSiteCd, string pAuth, string pLangCategory, out List<DataComCombo> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizLaborSearch bizSys = null;
            try
            {
                bizSys = new BizLaborSearch();

                try
                {
                    ds = bizSys.sLaborAddInfoCcode2(pSiteCd, pAuth, pLangCategory);

                    reMsg = "[검색 성공]";
                    reCode = "Y";
                }
                catch (Exception ex)
                {
                    reMsg = "[검색 실패]" + ex.ToString();
                    reCode = "N";
                }
            }
            catch (Exception ex)
            {
                reMsg = "[검색 에러] :: " + ex.ToString();
                reCode = "N";
            }

            List<DataComCombo> data = new List<DataComCombo>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataComCombo>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsWorkerLaborSearch.svc  (Function)::sLaborAddInfoCcode2  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        //SELECT 
        public string sLaborSearch(string pSiteCd, string pBlockCcd, string pConstCcd, string pCoCd, string pTeamCd, string pSearchCondition, string pSearchTxt, string pTtypeScd, string pTcode, string pValue, out List<DataLaborSearch> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizLaborSearch bizSys = null;
            try
            {
                bizSys = new BizLaborSearch();

                try
                {
                    ds = bizSys.sLaborSearch(pSiteCd, pBlockCcd, pConstCcd, pCoCd, pTeamCd, pSearchCondition, pSearchTxt, pTtypeScd, pTcode, pValue);

                    reMsg = "[검색 성공]";
                    reCode = "Y";
                }
                catch (Exception ex)
                {
                    reMsg = "[검색 실패]" + ex.ToString();
                    reCode = "N";
                }
            }
            catch (Exception ex)
            {
                reMsg = "[검색 에러] :: " + ex.ToString();
                reCode = "N";
            }

            List<DataLaborSearch> data = new List<DataLaborSearch>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataLaborSearch>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsWorkerLaborSearch.svc  (Function)::sDevice  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }










        // ** LABOR SEARCH POP UP START **

        public string sLabAprvFlag(string pSiteCd, string pAuthCd, out string reData, out string reMsg)
        {
            string reCode = "N";

            string reVal = "";
            BizLaborSearch bizSys = null;
            try
            {
                bizSys = new BizLaborSearch();

                try
                {
                    reVal = bizSys.sLabAprvFlag(pSiteCd, pAuthCd);

                    reMsg = "[검색 성공]";
                    reCode = "Y";
                }
                catch (Exception ex)
                {
                    reMsg = "[검색 실패]" + ex.ToString();
                    reCode = "N";
                }
            }
            catch (Exception ex)
            {
                reMsg = "[검색 에러 - BizMainHome 연결 실패] :: " + ex.ToString();
                reCode = "N";
            }

            reData = reVal;

            return reCode;
        }



        //SELECT THE LOWEST AUTH_CD AT SITE 
        public string sLabAuth(string pSiteCd, out string reData, out string reMsg)
        {
            string reCode = "N";

            string reVal = "";
            BizLaborSearch bizSys = null;
            try
            {
                bizSys = new BizLaborSearch();

                try
                {
                    reVal = bizSys.sLabAuth(pSiteCd);

                    reMsg = "[검색 성공]";
                    reCode = "Y";
                }
                catch (Exception ex)
                {
                    reMsg = "[검색 실패]" + ex.ToString();
                    reCode = "N";
                }
            }
            catch (Exception ex)
            {
                reMsg = "[검색 에러 - BizMainHome 연결 실패] :: " + ex.ToString();
                reCode = "N";
            }

            reData = reVal;

            return reCode;
        }



        //DUPLICATE CHECK MEMBER AND RETURN LAB_NO 
        public string exLabMember(string pSiteCd, string pLabNm, string pMobileNo, string pBirthDate, out string reData, out string reMsg)
        {
            string reCode = "N";

            string reVal = "";
            BizLaborSearch bizSys = null;
            try
            {
                bizSys = new BizLaborSearch();

                try
                {
                    reVal = bizSys.exLabMember(pSiteCd, pLabNm, pMobileNo, pBirthDate);

                    reMsg = "[검색 성공]";
                    reCode = "Y";
                }
                catch (Exception ex)
                {
                    reMsg = "[검색 실패]" + ex.ToString();
                    reCode = "N";
                }
            }
            catch (Exception ex)
            {
                reMsg = "[검색 에러 - BizMainHome 연결 실패] :: " + ex.ToString();
                reCode = "N";
            }

            reData = reVal;

            return reCode;
        }



        //DUPLICATE CHECK MAIN AND RETURN LAB_NO 
        public string exLabMain(string pLabNm, string pMobileNo, string pBirthDate, out string reData, out string reMsg)
        {
            string reCode = "N";

            string reVal = "";
            BizLaborSearch bizSys = null;
            try
            {
                bizSys = new BizLaborSearch();

                try
                {
                    reVal = bizSys.exLabMain(pLabNm, pMobileNo, pBirthDate);

                    reMsg = "[검색 성공]";
                    reCode = "Y";
                }
                catch (Exception ex)
                {
                    reMsg = "[검색 실패]" + ex.ToString();
                    reCode = "N";
                }
            }
            catch (Exception ex)
            {
                reMsg = "[검색 에러 - BizMainHome 연결 실패] :: " + ex.ToString();
                reCode = "N";
            }

            reData = reVal;

            return reCode;
        }

        //ADD INFO CCD COMBO BOX (CCODE = TGRP_CCD )
        public string sLaborAddInfoCcode(string pDbnm, string pSiteCd, string pAuth, out List<DataAddinfoCcode> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizLaborSearch bizSys = null;
            try
            {
                bizSys = new BizLaborSearch();

                try
                {
                    ds = bizSys.sLaborAddInfoCcode(pDbnm, pSiteCd, pAuth);

                    reMsg = "[검색 성공]";
                    reCode = "Y";
                }
                catch (Exception ex)
                {
                    reMsg = "[검색 실패]" + ex.ToString();
                    reCode = "N";
                }
            }
            catch (Exception ex)
            {
                reMsg = "[검색 에러] :: " + ex.ToString();
                reCode = "N";
            }

            List<DataAddinfoCcode> data = new List<DataAddinfoCcode>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataAddinfoCcode>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsWorkerLaborSearch.svc  (Function)::sLaborAddInfoCcode  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        //ADD INFO DATA 
        public string sLaborAddInfo(string pSiteCd, string pCodeT, string pTgrpCcd, string pAuthCd, out List<DataAddinfo> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizLaborSearch bizSys = null;
            try
            {
                bizSys = new BizLaborSearch();

                try
                {
                    ds = bizSys.sLaborAddInfo(pSiteCd, pCodeT, pTgrpCcd, pAuthCd);

                    reMsg = "[검색 성공]";
                    reCode = "Y";
                }
                catch (Exception ex)
                {
                    reMsg = "[검색 실패]" + ex.ToString();
                    reCode = "N";
                }
            }
            catch (Exception ex)
            {
                reMsg = "[검색 에러] :: " + ex.ToString();
                reCode = "N";
            }

            List<DataAddinfo> data = new List<DataAddinfo>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataAddinfo>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsWorkerLaborSearch.svc  (Function)::sLaborAddInfo  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }


        //ADD INFO DATA 
        public string sLaborAddInfoModify(string pLabNo, string pSiteCd, string pTtypeScd,string pTgrpCcd, out List<DataAddinfo> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizLaborSearch bizSys = null;
            try
            {
                bizSys = new BizLaborSearch();

                try
                {
                    ds = bizSys.sLaborAddInfoModify(pLabNo, pSiteCd, pTtypeScd, pTgrpCcd);

                    reMsg = "[검색 성공]";
                    reCode = "Y";
                }
                catch (Exception ex)
                {
                    reMsg = "[검색 실패]" + ex.ToString();
                    reCode = "N";
                }
            }
            catch (Exception ex)
            {
                reMsg = "[검색 에러] :: " + ex.ToString();
                reCode = "N";
            }

            List<DataAddinfo> data = new List<DataAddinfo>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataAddinfo>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsWorkerLaborSearch.svc  (Function)::sLaborAddInfoModify  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        //ADD INFO DATA 
        public string sLaborAddInfoSub(string pSiteCd, string pTcode, out List<DataAddinfoCcodesub> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizLaborSearch bizSys = null;
            try
            {
                bizSys = new BizLaborSearch();

                try
                {
                    ds = bizSys.sLaborAddInfoSub(pSiteCd, pTcode);

                    reMsg = "[검색 성공]";
                    reCode = "Y";
                }
                catch (Exception ex)
                {
                    reMsg = "[검색 실패]" + ex.ToString();
                    reCode = "N";
                }
            }
            catch (Exception ex)
            {
                reMsg = "[검색 에러] :: " + ex.ToString();
                reCode = "N";
            }

            List<DataAddinfoCcodesub> data = new List<DataAddinfoCcodesub>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataAddinfoCcodesub>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsWorkerLaborSearch.svc  (Function)::sLaborAddInfoSub  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }



        //INSERT WITH PROCEDURE
        public string aLaborPro(string pDbNm, string[] param, out string[] reData, out string reMsg)
        {
            string reCode = "N";

            string reVal = "";
            string[] reValArray = new string[2];
            int i = 0;

            BizLaborSearch bizSys = null;

            try
            {
                bizSys = new BizLaborSearch();

                try
                {
                    Hashtable hParam = new Hashtable();
                    hParam.Add("pLab_No", Convert.ToInt32(param[0]));
                    hParam.Add("pMobile_No", param[1].ToString());
                    hParam.Add("pLab_Nm", param[2].ToString());
                    hParam.Add("pBirth_Date", Convert.ToInt32(param[3]));
                    hParam.Add("pSite_Cd", Convert.ToInt32(param[4]));
                    hParam.Add("pCo_Cd", Convert.ToInt32(param[5]));
                    hParam.Add("pAuth_Cd", param[6].ToString());
                    hParam.Add("pAprv_Flag", Convert.ToInt32(param[7]));
                    hParam.Add("pTeam_Cd", Convert.ToInt32(param[8]));
                    hParam.Add("pJob_Cd", Convert.ToInt32(param[9]));
                    hParam.Add("pBlock_Cd", Convert.ToInt32(param[10]));
                    hParam.Add("pInput_Id", Convert.ToInt32(param[11]));
                    hParam.Add("@rtnUser_No", "");
                    hParam.Add("@rtnLab_No", "");

                    
                    reVal = bizSys.aLaborPro(pDbNm, hParam, out Hashtable outVal);

                    if (outVal != null)
                    {
                        foreach (DictionaryEntry dictionaryEntry in outVal)
                        {  
                            string[] row = new string[] { dictionaryEntry.Key.ToString(), dictionaryEntry.Value.ToString(), "" };                           
                            reValArray[i] = row[1].ToString();
                            i++;
                        }
                    }

                    reMsg = "[검색 성공]";
                    reCode = "Y";
                }
                catch (Exception ex)
                {
                    reMsg = "[검색 실패]" + ex.ToString();
                    reCode = "N";
                }
            }
            catch (Exception ex)
            {
                reMsg = "[검색 에러 - BizSystem 연결 실패] :: " + ex.ToString();
                reCode = "N";
            }

            reData = reValArray;

            return reCode;
        }


        //MODIFY WITH PROCEDURE
        public string mLaborPro(string pDbNm, string[] param, out string reData, out string reMsg)
        {
            string reCode = "N";

            string reVal = "";

            BizLaborSearch bizSys = null;

            try
            {
                bizSys = new BizLaborSearch();

                try
                {
                    Hashtable hParam = new Hashtable();
                    hParam.Add("pLab_No", Convert.ToInt32(param[0]));
                    hParam.Add("pUser_No", Convert.ToInt32(param[1]));
                    hParam.Add("pLab_Nm", param[2].ToString());
                    hParam.Add("pBirth_Date", Convert.ToInt32(param[3]));
                    hParam.Add("pMobile_No", param[4].ToString());                    
                    hParam.Add("pSite_Cd", Convert.ToInt32(param[5]));
                    hParam.Add("pCo_Cd", Convert.ToInt32(param[6]));
                    hParam.Add("pAprv_Flag", Convert.ToInt32(param[7]));
                    hParam.Add("pTeam_Cd", Convert.ToInt32(param[8]));
                    hParam.Add("pJob_Cd", Convert.ToInt32(param[9]));
                    hParam.Add("pBlock_Cd", Convert.ToInt32(param[10]));
                    hParam.Add("pInput_Id", Convert.ToInt32(param[11]));
                    hParam.Add("@rtnVal", "");


                    reVal = bizSys.mLaborPro(pDbNm, hParam, out Hashtable outVal);

                    if (outVal != null)
                    {
                        foreach (DictionaryEntry dictionaryEntry in outVal)
                        {
                            string[] row = new string[] { dictionaryEntry.Key.ToString(), dictionaryEntry.Value.ToString(), "" };
                            reVal = row[1].ToString();
                        }
                    }

                    reMsg = "[검색 성공]";
                    reCode = "Y";
                }
                catch (Exception ex)
                {
                    reMsg = "[검색 실패]" + ex.ToString();
                    reCode = "N";
                }
            }
            catch (Exception ex)
            {
                reMsg = "[검색 에러 - BizSystem 연결 실패] :: " + ex.ToString();
                reCode = "N";
            }

            reData = reVal;

            return reCode; 
        }
        //INSERT LAB_TCODE_SITE
        public string aLaborLabTcodeSite(string pDbnm, string pLabNo, string pSiteCd, string pTcode, string pTtypeScd, string pValue, out string reData, out string reMsg)
        {
            string reCode = "N";
            reData = "";

            BizLaborSearch bizSys = null;
            try
            {
                bizSys = new BizLaborSearch();

                int reCnt = bizSys.aLaborLabTcodeSite(pDbnm, pLabNo, pSiteCd, pTcode, pTtypeScd, pValue);

                if (reCnt > 0)
                {
                    reMsg = "[저장 성공]";
                    reCode = "Y";
                    reData = reCnt.ToString();
                }
                else
                {
                    reMsg = "[저장 성공] - 정보 없음";
                    reCode = "Y";
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsWorkerLaborSearch.svc  (Function)::aLaborLabTcodeSite  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        //UPDATE LAB_TCODE_SITE //추가 
        public string mLaborLabTcodeSite(string pDbnm, string pLabNo, string pSiteCd, string pTcode, string pValue, out string reData, out string reMsg)
        {
            string reCode = "N";
            reData = "";

            BizLaborSearch bizSys = null;
            try
            {
                bizSys = new BizLaborSearch();

                int reCnt = bizSys.mLaborLabTcodeSite(pDbnm, pLabNo, pSiteCd, pTcode, pValue);

                if (reCnt >= 0)
                {
                    reMsg = "[저장 성공]";
                    reCode = "Y";
                    reData = reCnt.ToString();
                }
                else
                {
                    reMsg = "[저장 성공] - 정보 없음";
                    reCode = "Y";
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsWorkerLaborSearch.svc  (Function)::mLaborLabTcodeSite  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }
        

        //UPDATE LAB_TCODE_SITE //추가 
        public string aLaborLabTcodeSiteLog(string pDbnm, string pLabNo, string pSiteCd, string pTcode, string pTtypeScd, string pValue, string pInputId, out string reData, out string reMsg)
        {
            string reCode = "N";
            reData = "";

            BizLaborSearch bizSys = null;
            try
            {
                bizSys = new BizLaborSearch();

                int reCnt = bizSys.aLaborLabTcodeSiteLog(pDbnm, pLabNo, pSiteCd, pTcode, pTtypeScd, pValue, pInputId);

                if (reCnt >= 0)
                {
                    reMsg = "[저장 성공]";
                    reCode = "Y";
                    reData = reCnt.ToString();
                }
                else
                {
                    reMsg = "[저장 성공] - 정보 없음";
                    reCode = "Y";
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsWorkerLaborSearch.svc  (Function)::mLaborLabTcodeSiteLog  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }



        //** AUTH SET PART START 

        //DUPLICATE CHECK MEMBER AND RETURN LAB_NO 
        public string AuthLaborNew(string pDbNm, string pSiteCd, string pAuthCd, out string reData, out string reMsg)
        {
            string reCode = "N";

            string reVal = "";
            BizLaborSearch bizSys = null;
            try
            {
                bizSys = new BizLaborSearch();

                try
                {
                    reVal = bizSys.AuthLaborNew(pDbNm, pSiteCd, pAuthCd);

                    reMsg = "[검색 성공]";
                    reCode = "Y";
                }
                catch (Exception ex)
                {
                    reMsg = "[검색 실패]" + ex.ToString();
                    reCode = "N";
                }
            }
            catch (Exception ex)
            {
                reMsg = "[검색 에러 - BizMainHome 연결 실패] :: " + ex.ToString();
                reCode = "N";
            }

            reData = reVal;

            return reCode;
        }

        public string AuthLaborModify(string pDbNm, string pSiteCd, string pAuthCd, out string reData, out string reMsg)
        {

            string reCode = "N";

            string reVal = "";
            BizLaborSearch bizSys = null;
            try
            {
                bizSys = new BizLaborSearch();

                try
                {
                    reVal = bizSys.AuthLaborModify(pDbNm, pSiteCd, pAuthCd);

                    reMsg = "[검색 성공]";
                    reCode = "Y";
                }
                catch (Exception ex)
                {
                    reMsg = "[검색 실패]" + ex.ToString();
                    reCode = "N";
                }
            }
            catch (Exception ex)
            {
                reMsg = "[검색 에러 - BizMainHome 연결 실패] :: " + ex.ToString();
                reCode = "N";
            }

            reData = reVal;

            return reCode;
        }



        //** AUTH SET PART END






        //UPDATE LAB_TCODE_SITE //추가 
        //public string mLaborLabTcodeSiteLog(string pDbnm, string pLabNo, string pSiteCd, string pTcode, string pTtypeScd, string pValue, string pInputId, out string reData, out string reMsg)
        //{
        //    string reCode = "N";
        //    reData = "";

        //    BizLaborSearch bizSys = null;
        //    try
        //    {
        //        bizSys = new BizLaborSearch();

        //        int reCnt = bizSys.mLaborLabTcodeSiteLog(pDbnm, pLabNo, pSiteCd, pTcode, pTtypeScd, pValue, pInputId);

        //        if (reCnt >= 0)
        //        {
        //            reMsg = "[저장 성공]";
        //            reCode = "Y";
        //            reData = reCnt.ToString();
        //        }
        //        else
        //        {
        //            reMsg = "[저장 성공] - 정보 없음";
        //            reCode = "Y";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        logs.SaveLog("[error]  (page)::WsWorkerLaborSearch.svc  (Function)::mLaborLabTcodeSiteLog  (Detail)::" + "\r\n" + ex.ToString(), "Error");
        //        reMsg = "[저장 에러] :: " + ex.ToString();
        //        reCode = "N";
        //    }

        //    return reCode;
        //}

        // ** LABOR SEARCH POP UP END **
    }
}