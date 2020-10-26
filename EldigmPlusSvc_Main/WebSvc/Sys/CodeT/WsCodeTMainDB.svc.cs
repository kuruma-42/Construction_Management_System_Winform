using EldigmPlusSvc_Main.Biz.Common;
using EldigmPlusSvc_Main.Biz.Sys.CodeT;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EldigmPlusSvc_Main.WebSvc.Sys.CodeT
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드, svc 및 config 파일에서 클래스 이름 "WsCodeTMainDB"을 변경할 수 있습니다.
    // 참고: 이 서비스를 테스트하기 위해 WCF 테스트 클라이언트를 시작하려면 솔루션 탐색기에서 WsCodeTMainDB.svc나 WsCodeTMainDB.svc.cs를 선택하고 디버깅을 시작하십시오.
    public class WsCodeTMainDB : IWsCodeTMainDB
    {
        LogClass logs = new LogClass();

        public string sSysCode(out List<DataSysCode> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizCodeT bizCodeT = null;
            try
            {
                bizCodeT = new BizCodeT();

                try
                {
                    ds = bizCodeT.sSysCode();

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

            List<DataSysCode> data = new List<DataSysCode>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataSysCode>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsCodeTMainDB.svc  (Function)::sSysCode  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        public string sCodeTTreeView(string pScode, out List<DataCodeT> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizCodeT bizCodeT = null;
            try
            {
                bizCodeT = new BizCodeT();

                try
                {
                    ds = bizCodeT.sCodeTTreeView(pScode);

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

            List<DataCodeT> data = new List<DataCodeT>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataCodeT>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsCodeTMainDB.svc  (Function)::sCodeTTreeView  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        public string sCodeT(string pScode, out List<DataCodeT> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizCodeT bizCodeT = null;
            try
            {
                bizCodeT = new BizCodeT();

                try
                {
                    ds = bizCodeT.sCodeT(pScode);

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

            List<DataCodeT> data = new List<DataCodeT>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataCodeT>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsCodeTMainDB.svc  (Function)::sCodeT  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        public string sCodeTSubTreeView(string pTcode, out List<DataCodeTSub> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizCodeT bizCodeT = null;
            try
            {
                bizCodeT = new BizCodeT();

                try
                {
                    ds = bizCodeT.sCodeTSubTreeView(pTcode);

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

            List<DataCodeTSub> data = new List<DataCodeTSub>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataCodeTSub>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsCodeTMainDB.svc  (Function)::sCodeTSubTreeView  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        public string sCodeTSub(string pTcode, out List<DataCodeTSub> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizCodeT bizCodeT = null;
            try
            {
                bizCodeT = new BizCodeT();

                try
                {
                    ds = bizCodeT.sCodeTSub(pTcode);

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

            List<DataCodeTSub> data = new List<DataCodeTSub>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataCodeTSub>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsCodeTMainDB.svc  (Function)::sCodeTSub  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        public string sCodeTSubTscode(string pTcode, out List<DataCodeTSub> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizCodeT bizCodeT = null;
            try
            {
                bizCodeT = new BizCodeT();

                try
                {
                    ds = bizCodeT.sCodeTSubTscode(pTcode);

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

            List<DataCodeTSub> data = new List<DataCodeTSub>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataCodeTSub>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsCodeTMainDB.svc  (Function)::sCodeTSubTreeView  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        public string mCodeT(string pTcode, string pListFlag, string pRequiredFlag, string pNumericFlag, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizCodeT bizCodeT = null;
            try
            {
                bizCodeT = new BizCodeT();

                int reCnt = bizCodeT.mCodeT(pTcode, pListFlag, pRequiredFlag, pNumericFlag);

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
                logs.SaveLog("[error]  (page)::WsCodeTMainDB.svc  (Function)::mCodeT  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        public string exCodeT(string pTcode, string ptcodeNm, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizCodeT bizCodeT = null;
            try
            {
                bizCodeT = new BizCodeT();

                int reCnt = bizCodeT.exCodeT(pTcode, ptcodeNm);

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
                logs.SaveLog("[error]  (page)::WsCodeTMainDB.svc  (Function)::exCodeT  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        public string aCodeT(string pTcode, string pttypeScd, string ptcodeNm, string pListFlag, string pRequiredFlag, string pNumericFlag, string pInputId, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizCodeT bizCodeT = null;
            try
            {
                bizCodeT = new BizCodeT();

                int reCnt = bizCodeT.aCodeT(pTcode, pttypeScd, ptcodeNm, pListFlag, pRequiredFlag, pNumericFlag, pInputId);

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
                logs.SaveLog("[error]  (page)::WsCodeTMainDB.svc  (Function)::aCodeT  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }



        public string exCodeTSub(string pTcode, string ptscodeNm, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizCodeT bizCodeT = null;
            try
            {
                bizCodeT = new BizCodeT();

                int reCnt = bizCodeT.exCodeTSub(pTcode, ptscodeNm);

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
                logs.SaveLog("[error]  (page)::WsCodeTMainDB.svc  (Function)::exCodeTSub  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        public string aCodeTSub(string pTcode, string pTscodeNm, string pUsingCnt, string pInputId, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizCodeT bizCodeT = null;
            try
            {
                bizCodeT = new BizCodeT();

                int reCnt = bizCodeT.aCodeTSub(pTcode, pTscodeNm, pUsingCnt, pInputId);

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
                logs.SaveLog("[error]  (page)::WsCodeTMainDB.svc  (Function)::aCodeTSub  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        public string sCodeTSiteTreeView(string pDbnm, string pSiteCd, string pAuth, out List<DataCodeTSiteTreeView> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizCodeT bizCodeT = null;
            try
            {
                bizCodeT = new BizCodeT();

                try
                {
                    ds = bizCodeT.sCodeTSiteTreeView(pDbnm, pSiteCd, pAuth);

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

            List<DataCodeTSiteTreeView> data = new List<DataCodeTSiteTreeView>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataCodeTSiteTreeView>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsCodeTMainDB.svc  (Function)::sCodeTSiteTreeView  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        public string sCodeTSite(string pDbnm, string pSiteCd, string pTgrpCcd, out List<DataCodeTSite> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizCodeT bizCodeT = null;
            try
            {
                bizCodeT = new BizCodeT();

                try
                {
                    ds = bizCodeT.sCodeTSite(pDbnm, pSiteCd, pTgrpCcd);

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

            List<DataCodeTSite> data = new List<DataCodeTSite>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataCodeTSite>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsCodeTMainDB.svc  (Function)::sCodeTSite  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        public string mCodeTSite(string pDbnm, string pSiteCd, string pTcode, string pDefaultValue, string pUsingFlag, string pSortNo, string pMemo, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizCodeT bizCodeT = null;
            try
            {
                bizCodeT = new BizCodeT();

                int reCnt = bizCodeT.mCodeTSite(pDbnm, pSiteCd, pTcode, pDefaultValue, pUsingFlag, pSortNo, pMemo);

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
                logs.SaveLog("[error]  (page)::WsCodeTMainDB.svc  (Function)::mCodeT  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        public string aCodeTSite(string pDbNm, string[] param, out string reMsg, out string reData)
        {
            string reCode = "N";

            string reVal = "";
            BizCodeT bizCodeT = null;
            try
            {
                bizCodeT = new BizCodeT();

                try
                {
                    Hashtable hParam = new Hashtable();
                    hParam.Add("pTcode", param[0].ToString());
                    hParam.Add("pTtype_scd", param[1].ToString());
                    hParam.Add("pTcode_Nm", param[2].ToString());
                    hParam.Add("pRequired_Flag", Convert.ToInt16(param[3]));
                    hParam.Add("pNumerric_Flag", Convert.ToInt16(param[4]));
                    hParam.Add("pList_Flag", Convert.ToInt16(param[5]));
                    hParam.Add("pInput_Id", Convert.ToInt16(param[6]));
                    hParam.Add("pSite_Cd", Convert.ToInt16(param[7]));
                    hParam.Add("pTgrp_Ccd", Convert.ToInt16(param[8]));
                    hParam.Add("@rtnTcode", "");

                    reVal = bizCodeT.aCodeTSite(pDbNm, hParam, out Hashtable outVal);

                    if (outVal != null)
                    {
                        foreach (DictionaryEntry dictionaryEntry in outVal)
                        {
                            string[] row = new string[] { dictionaryEntry.Key.ToString(), dictionaryEntry.Value.ToString(), "" };
                            string rowCount = row.Length.ToString();
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
                reMsg = "[검색 에러 - BizCodeT 연결 실패] :: " + ex.ToString();
                reCode = "N";
            }

            reData = reVal;

            return reCode;
        }

        public string aCodeTSubSite(string pDbNm, string[] param, out string reMsg, out string reData)
        {
            string reCode = "N";

            string reVal = "";
            BizCodeT bizCodeT = null;
            try
            {
                bizCodeT = new BizCodeT();

                try
                {
                    Hashtable hParam = new Hashtable();
                    hParam.Add("pTcode", param[0].ToString());
                    hParam.Add("pTscode", Convert.ToInt32(param[1]));
                    hParam.Add("pTscode_Nm", param[2].ToString());
                    hParam.Add("pInput_Id", Convert.ToInt16(param[3]));
                    hParam.Add("pSite_Cd", Convert.ToInt16(param[4]));
                    hParam.Add("@rtnTcode", "");

                    reVal = bizCodeT.aCodeTSubSite(pDbNm, hParam, out Hashtable outVal);

                    if (outVal != null)
                    {
                        foreach (DictionaryEntry dictionaryEntry in outVal)
                        {
                            string[] row = new string[] { dictionaryEntry.Key.ToString(), dictionaryEntry.Value.ToString(), "" };
                            string rowCount = row.Length.ToString();
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
                reMsg = "[검색 에러 - BizCodeT 연결 실패] :: " + ex.ToString();
                reCode = "N";
            }

            reData = reVal;

            return reCode;
        }

        public string aCodeTSiteLog(string pDbnm, string pSiteCd, string pTcode, string pTgrpCcd, string pRequiredFlag, string pNumericFlag, string pDefaultValue, string pUsingFlag, string pSortNo, string pMemo, string pInputId, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizCodeT bizCodeT = null;
            try
            {
                bizCodeT = new BizCodeT();

                int reCnt = bizCodeT.aCodeTSiteLog(pDbnm, pSiteCd, pTcode, pTgrpCcd, pRequiredFlag, pNumericFlag, pDefaultValue, pUsingFlag, pSortNo, pMemo, pInputId);

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
                logs.SaveLog("[error]  (page)::WsCodeTMainDB.svc  (Function)::aCodeTSub  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        //** AUTH PART START 

        //TREE VIEW SELECT 
        public string sCodeAuthTTreeView(string pScode, string pSiteCd, out List<DataCodeTAuth> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizCodeT bizCodeT = null;
            try
            {
                bizCodeT = new BizCodeT();

                try
                {
                    ds = bizCodeT.sCodeTAuthTreeView(pScode, pSiteCd);

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

            List<DataCodeTAuth> data = new List<DataCodeTAuth>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataCodeTAuth>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsCodeTMainDB.svc  (Function)::sCodeAuthTTreeView  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        //SELECT
        public string sCodeTAuth(string pTcode, string pSiteCd, string pAuthCd, out List<DataCodeTAuthSelect> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizCodeT bizCodeT = null;
            try
            {
                bizCodeT = new BizCodeT();

                try
                {
                    ds = bizCodeT.sCodeTAuth(pTcode, pSiteCd, pAuthCd);

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

            List<DataCodeTAuthSelect> data = new List<DataCodeTAuthSelect>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataCodeTAuthSelect>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsCodeTMainDB.svc  (Function)::sCodeAuth  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        //SELECT : WHEN USER CLICK TTYPE_SCD 
        public string sCodeTAuthTtype(string pTtypeScd, string pSiteCd, string pAuthCd, out List<DataCodeTAuthSelect> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizCodeT bizCodeT = null;
            try
            {
                bizCodeT = new BizCodeT();

                try
                {
                    ds = bizCodeT.sCodeTAuthTtype(pTtypeScd, pSiteCd, pAuthCd);

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

            List<DataCodeTAuthSelect> data = new List<DataCodeTAuthSelect>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataCodeTAuthSelect>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsCodeTMainDB.svc  (Function)::sCodeTAuthTtype  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }


        //AUTH MODIFY
        public string mCodeTAuth(string pTcode, string pSiteCd, string pAuthCd, string pViewFlag, string pNewFlag, string pModifyFlag, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizCodeT bizCodeT = null;
            try
            {
                bizCodeT = new BizCodeT();

                int reCnt = bizCodeT.mCodeTAuth(pTcode, pSiteCd, pAuthCd, pViewFlag, pNewFlag, pModifyFlag);

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
                logs.SaveLog("[error]  (page)::WsCodeTMainDB.svc  (Function)::mCodeT  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        //**AUTH PART END
    }
}

