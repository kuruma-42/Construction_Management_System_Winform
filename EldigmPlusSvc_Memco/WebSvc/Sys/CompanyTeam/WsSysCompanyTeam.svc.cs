using EldigmPlusSvc_Memco.Biz.Common;
using EldigmPlusSvc_Memco.Biz.Sys.CompanyTeam;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EldigmPlusSvc_Memco.WebSvc.Sys.CompanyTeam
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드, svc 및 config 파일에서 클래스 이름 "WsSysCompanyTeam"을 변경할 수 있습니다.
    // 참고: 이 서비스를 테스트하기 위해 WCF 테스트 클라이언트를 시작하려면 솔루션 탐색기에서 WsSysCompanyTeam.svc나 WsSysCompanyTeam.svc.cs를 선택하고 디버깅을 시작하십시오.
    public class WsSysCompanyTeam : IWsSysCompanyTeam
    {
        LogClass logs = new LogClass();

        //CONST CMB BOX
        public string constCmb(string pSiteCd, out List<DataConstCmb> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizCompany bizSys = null;
            try
            {
                bizSys = new BizCompany();

                try
                {
                    ds = bizSys.constCmb(pSiteCd);

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

            List<DataConstCmb> data = new List<DataConstCmb>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataConstCmb>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsSysCompanyTeam.svc  (Function)::constCmb  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        //COTYPE CMB BOX
        public string cotype_Cmb( out List<DataCotypeCmb> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizCompany bizSys = null;
            try
            {
                bizSys = new BizCompany();

                try
                {
                    ds = bizSys.cotype_Cmb();

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

            List<DataCotypeCmb> data = new List<DataCotypeCmb>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataCotypeCmb>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsSysCompanyTeam.svc  (Function)::cotype_Cmb  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        //CONST CMB BOX WITHOUT NO SELECT 
        public string constCmb2(string pSiteCd, out List<DataConstCmb2> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizCompany bizSys = null;
            try
            {
                bizSys = new BizCompany();

                try
                {
                    ds = bizSys.constCmb2(pSiteCd);

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

            List<DataConstCmb2> data = new List<DataConstCmb2>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataConstCmb2>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsSysCompanyTeam.svc  (Function)::constCmb2  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        //COTYPE CMB BOX WITHOUT NO SELECT
        public string cotype_Cmb2(out List<DataCotypeCmb2> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizCompany bizSys = null;
            try
            {
                bizSys = new BizCompany();

                try
                {
                    ds = bizSys.cotype_Cmb2();

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

            List<DataCotypeCmb2> data = new List<DataCotypeCmb2>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataCotypeCmb2>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsSysCompanyTeam.svc  (Function)::cotype_Cmb2  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }



        public string sCompany(string pSiteCd, string pUsingFlag, string pCoNm, out List<DataCompany> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizCompany bizSys = null;
            try
            {
                bizSys = new BizCompany();

                try
                {
                    ds = bizSys.sCompany(pSiteCd, pUsingFlag, pCoNm);

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

            List<DataCompany> data = new List<DataCompany>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataCompany>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsSysCompanyTeam.svc  (Function)::sCompany  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }


        public string mCompanyMain(string pCoCd, string pCoNm, string pBizNo, string pConstCcd, string pCoTypeScd, string pOwnerNm, string pTel, string pAddr, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "";

            BizCompany bizSys = null;
            try
            {
                bizSys = new BizCompany();

                int reCnt = bizSys.mCompanyMain(pCoCd, pCoNm, pBizNo, pConstCcd, pCoTypeScd, pOwnerNm, pTel, pAddr);
                //int reCntLog = bizSys.aSysCodeLog(pScode, pScodeNm, pUsingFlag, pSortNo, pMemo, pInputId);

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
                logs.SaveLog("[error]  (page)::WsSysCompanyTeam.svc  (Function)::mCompanyMain  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }
        

        public string mCompanyMemco(string pSiteCd, string pCoCd, string pCoNm, string pHeadcoCd, string pConstCcd, string pCoTypeScd, string pSortNo, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "";

            BizCompany bizSys = null;
            try
            {
                bizSys = new BizCompany();

                int reCnt = bizSys.mCompanyMemco(pSiteCd, pCoCd, pCoNm, pHeadcoCd, pConstCcd, pCoTypeScd, pSortNo);
                //int reCntLog = bizSys.aSysCodeLog(pScode, pScodeNm, pUsingFlag, pSortNo, pMemo, pInputId);

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
                logs.SaveLog("[error]  (page)::WsSysCompanyTeam.svc  (Function)::mCompanyMemco  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }        


        public string mCompanyMemcoSite(string pSiteCd, string pCoCd, string pStartDate, string pEndDate, string pUsingFlag, string pSortNo, string pMemo, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "";

            BizCompany bizSys = null;
            try
            {
                bizSys = new BizCompany();

                int reCnt = bizSys.mCompanyMemcoSite(pSiteCd, pCoCd, pStartDate, pEndDate, pUsingFlag, pSortNo, pMemo);
                //int reCntLog = bizSys.aSysCodeLog(pScode, pScodeNm, pUsingFlag, pSortNo, pMemo, pInputId);

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
                logs.SaveLog("[error]  (page)::WsSysCompanyTeam.svc  (Function)::mCompanyMemcoSite  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        public string mConpanyMainLog(string pCoCd, string pCoNm, string pBizNo, string pConstCcd, string pCoTypeScd, string pOwnerNm, string pTel, string pAddr, string pUsingCnt, string pInputId, out string reMsg, out string reData)

        {
            string reCode = "N";
            reData = "";

            BizCompany bizSys = null;
            try
            {
                bizSys = new BizCompany();

                int reCnt = bizSys.mConpanyMainLog(pCoCd, pCoNm, pBizNo, pConstCcd, pCoTypeScd, pOwnerNm, pTel, pAddr, pUsingCnt, pInputId);


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
                logs.SaveLog("[error]  (page)::WsSysCompanyTeam.svc  (Function)::mConpanyMainLog  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        public string mCompanySiteLog(string pCoCd, string pSiteCd, string pCoNm, string pConstCcd, string pCoTypeScd, string pStartDate, string pEndDate, string pUsingFlag, string pSortNo, string pMemo, string pInputId, out string reMsg, out string reData)

        {
            string reCode = "N";
            reData = "";

            BizCompany bizSys = null;
            try
            {
                bizSys = new BizCompany();

                int reCnt = bizSys.mCompanySiteLog(pCoCd, pSiteCd, pCoNm, pConstCcd, pCoTypeScd, pStartDate, pEndDate, pUsingFlag, pSortNo, pMemo, pInputId);


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
                logs.SaveLog("[error]  (page)::WsSysCompanyTeam.svc  (Function)::mCompanySiteLog  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }


        public string aCompanyMemcoSite(string pSiteCd, string pCoCd, string pStartDate, string pEndDate, string pUsingFlag, string pSortNo, string pMemo, string pInputId, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "";

            BizCompany bizSys = null;
            try
            {
                bizSys = new BizCompany();

                int reCnt = bizSys.aCompanyMemcoSite(pSiteCd, pCoCd, pStartDate, pEndDate, pUsingFlag, pSortNo, pMemo, pInputId);
                

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
                logs.SaveLog("[error]  (page)::WsSysCompanyTeam.svc  (Function)::aCompanyMemcoSite  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        //INSERT WITH PROCEDURE
        public string aCompanyPro(string pDbNm, string[] param, out string reData, out string reMsg)
        {
            string reCode = "N";

            string reVal = "";
            BizCompany bizSys = null;
            try
            {
                bizSys = new BizCompany();

                try
                {
                    Hashtable hParam = new Hashtable();
                    hParam.Add("pSite_Cd", Convert.ToInt32(param[0]));
                    hParam.Add("pCo_Nm", param[1].ToString());
                    hParam.Add("pBiz_No", param[2].ToString());
                    hParam.Add("pConst_Ccd", Convert.ToInt32(param[3]));
                    hParam.Add("pCo_Type_Scd", param[4].ToString());
                    hParam.Add("pOwner_Nm", param[5].ToString());
                    hParam.Add("pTel", param[6].ToString());
                    hParam.Add("pAddr", param[7].ToString());
                    hParam.Add("pStart_Date", Convert.ToInt32(param[8]));
                    hParam.Add("pEnd_Date", Convert.ToInt32(param[9]));
                    hParam.Add("pMemo", param[10].ToString());
                    hParam.Add("pSort_No", Convert.ToInt32(param[11]));
                    hParam.Add("pInput_Id", Convert.ToInt32(param[12]));
                    hParam.Add("@rtnCo_Cd", "");
                    
                    reVal = bizSys.aCompanyPro(pDbNm, hParam, out Hashtable outVal);

                    if (outVal != null)
                    {
                        foreach (DictionaryEntry dictionaryEntry in outVal)
                        {
                            string[] row = new string[] { dictionaryEntry.Key.ToString(), dictionaryEntry.Value.ToString(), "" };
                            //string rowCount = row.Length.ToString();
                            //string rowKey = row[0].ToString();
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




        //**TEAM PART START FROM HERE**





        //COMPANY CMB BOX
        public string companyCmb(string pSiteCd, out List<DataCompanyCmb> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizTeam bizSys = null;
            try
            {
                bizSys = new BizTeam();

                try
                {
                    ds = bizSys.companyCmb(pSiteCd);

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

            List<DataCompanyCmb> data = new List<DataCompanyCmb>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataCompanyCmb>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsSysCompanyTeam.svc  (Function)::companyCmb  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        //SELECT
        public string sTeam(string pSiteCd, string pCoCd, string pUsingFlag, string pTeamNm, out List<DataTeam> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizTeam bizSys = null;
            try
            {
                bizSys = new BizTeam();

                try
                {
                    ds = bizSys.sTeam(pSiteCd, pCoCd, pUsingFlag, pTeamNm);

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

            List<DataTeam> data = new List<DataTeam>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataTeam>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsSysCompanyTeam.svc  (Function)::sTeam  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        //MODIFY
        public string mTeamMemco(string pSiteCd, string pTeamCd, string pTeamNm, string pUsingFalg, string pSortNo, string pMemo, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "";

            BizTeam bizSys = null;
            try
            {
                bizSys = new BizTeam();

                int reCnt = bizSys.mTeamMemco(pSiteCd, pTeamCd, pTeamNm, pUsingFalg, pSortNo, pMemo);

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
                logs.SaveLog("[error]  (page)::WsSysCompanyTeam.svc  (Function)::mTeamMemco  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }


        //INSERT WITH PROCEDURE
        public string aTeamPro(string pDbNm, string[] param, out string reData, out string reMsg)
        {
            string reCode = "N";

            string reVal = "";
            BizTeam bizSys = null;
            try
            {
                bizSys = new BizTeam();

                try
                {
                    Hashtable hParam = new Hashtable();
                    hParam.Add("pSite_Cd", Convert.ToInt32(param[0]));
                    hParam.Add("pCo_Cd", Convert.ToInt32(param[1]));
                    hParam.Add("pTeam_Nm", param[2].ToString());                   
                    hParam.Add("pMemo", param[3].ToString());
                    hParam.Add("pSort_No", Convert.ToInt32(param[4]));
                    hParam.Add("pInput_Id", Convert.ToInt32(param[5]));
                    hParam.Add("@rtnTeam_Cd", "");

                    reVal = bizSys.aTeamPro(pDbNm, hParam, out Hashtable outVal);

                    if (outVal != null)
                    {
                        foreach (DictionaryEntry dictionaryEntry in outVal)
                        {
                            string[] row = new string[] { dictionaryEntry.Key.ToString(), dictionaryEntry.Value.ToString(), "" };
                            //string rowCount = row.Length.ToString();
                            //string rowKey = row[0].ToString();
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
    }
}