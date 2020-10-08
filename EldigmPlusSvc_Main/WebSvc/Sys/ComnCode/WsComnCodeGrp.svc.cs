using EldigmPlusSvc_Main.Biz.Common;
using EldigmPlusSvc_Main.Biz.Sys.ComnCode;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EldigmPlusSvc_Main.WebSvc.Sys.ComnCode
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드, svc 및 config 파일에서 클래스 이름 "WsComnCodeGrp"을 변경할 수 있습니다.
    // 참고: 이 서비스를 테스트하기 위해 WCF 테스트 클라이언트를 시작하려면 솔루션 탐색기에서 WsComnCodeGrp.svc나 WsComnCodeGrp.svc.cs를 선택하고 디버깅을 시작하십시오.
    public class WsComnCodeGrp : IWsComnCodeGrp
    {
        LogClass logs = new LogClass();

        public string sComnCodeGrp(out List<DataComnCodeGrp> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizComnCodeGrp bizComn = null;
            try
            {
                bizComn = new BizComnCodeGrp();

                try
                {
                    ds = bizComn.sComnCodeGrp();

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

            List<DataComnCodeGrp> data = new List<DataComnCodeGrp>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataComnCodeGrp>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsSysCodeGrp.svc  (Function)::sSysCodeGrp  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        public string sComnCodeGrpUsingFlag(out List<DataComnCodeGrp> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizComnCodeGrp bizComn = null;
            try
            {
                bizComn = new BizComnCodeGrp();

                try
                {
                    ds = bizComn.sComnCodeGrpUsingFlag();

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

            List<DataComnCodeGrp> data = new List<DataComnCodeGrp>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataComnCodeGrp>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsSysCodeGrp.svc  (Function)::sSysCodeGrp  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        public string aComnCodeGrp(string pCcodeGrp, string pCcodeGrpNm, string pUsingFlag, string pSortNo, string pMemo, string pInputId, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "";

            BizComnCodeGrp bizComn = null;
            try
            {
                bizComn = new BizComnCodeGrp();

                int reCnt = bizComn.aComnCodeGrp(pCcodeGrp, pCcodeGrpNm, pUsingFlag, pSortNo, pMemo, pInputId);

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
                logs.SaveLog("[error]  (page)::WsSysCodeGrp.svc  (Function)::aComnCodeGrp  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }


        public string exComnCodeGrp(string pCcodeGrp, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizComnCodeGrp bizComn = null;
            try
            {
                bizComn = new BizComnCodeGrp();

                int reCnt = bizComn.exComnCodeGrp(pCcodeGrp);

                if (reCnt > 0)
                {
                    reMsg = "[검색 성공]";
                    reCode = "Y";
                    reData = reCnt.ToString();
                }
                else
                {
                    reMsg = "[검색 성공] - 정보 없음";
                    reCode = "Y";
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizComnCodeGrp.svc  (Function)::exComnCodeGrp  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[검색 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        public string mComnCodeGrp(string pCcodeGrp, string pCcodeGrpNm, string pUsingFlag, string pSortNo, string pMemo, out string reMsg, out int reData)
        {
            string reCode = "N";
            reData = 0;

            BizComnCodeGrp bizComn = null;
            try
            {
                bizComn = new BizComnCodeGrp();

                int reCnt = bizComn.mComnCodeGrp(pCcodeGrp, pCcodeGrpNm, pUsingFlag, pSortNo, pMemo);

                if (reCnt > 0)
                {
                    reMsg = "[저장 성공]";
                    reCode = "Y";
                    reData = reCnt;
                }
                else
                {
                    reMsg = "[저장 성공] - 정보 없음";
                    reCode = "Y";
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsComnCodeGrp.svc  (Function)::mComnCodeGrp  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        public string siteDbNm(string pSiteCd, out string reData, out string reMsg)
        {
            string reCode = "N";

            string reVal = "";
            BizComnCodeGrp bizComn = null;
            try
            {
                bizComn = new BizComnCodeGrp();

                try
                {
                    reVal = bizComn.siteDbNm(pSiteCd);

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
                logs.SaveLog("[error]  (page)::WsMenuMainDB.svc  (Function)::siteDbNm  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg = "[검색 에러 - BizSystem 연결 실패] :: " + ex.ToString();
                reCode = "N";
            }

            reData = reVal;

            return reCode;
        }

        public string sCodeAuthSiteMemberDB(string pDbnm, out List<DataCodeAuthSiteMemberDB> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizComnCodeGrp bizComn = null;
            try
            {
                bizComn = new BizComnCodeGrp();

                try
                {
                    ds = bizComn.sCodeAuthSiteMemberDB(pDbnm);

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

            List<DataCodeAuthSiteMemberDB> data = new List<DataCodeAuthSiteMemberDB>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataCodeAuthSiteMemberDB>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsSysCodeGrp.svc  (Function)::sSysCodeGrp  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        public string sSetAuthSiteMemberDB(string pDbnm, string pSiteCd, string pAuthCd, out List<DataSetAuthSiteMemberDB> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizComnCodeGrp bizComn = null;
            try
            {
                bizComn = new BizComnCodeGrp();

                try
                {
                    ds = bizComn.sSetAuthSiteMemberDB(pDbnm, pSiteCd, pAuthCd);

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

            List<DataSetAuthSiteMemberDB> data = new List<DataSetAuthSiteMemberDB>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataSetAuthSiteMemberDB>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsMenuMainDB.svc  (Function)::sSiteMainDB  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        public string sSetAuthSiteMemberDBSub(string pCcodeGrp, string pDbnm, string pSiteCd, string pAuthCd, out List<DataSetAuthSiteMemberDB> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizComnCodeGrp bizComn = null;
            try
            {
                bizComn = new BizComnCodeGrp();

                try
                {
                    ds = bizComn.sSetAuthSiteMemberDBSub(pCcodeGrp, pDbnm, pSiteCd, pAuthCd);

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

            List<DataSetAuthSiteMemberDB> data = new List<DataSetAuthSiteMemberDB>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataSetAuthSiteMemberDB>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsMenuMainDB.svc  (Function)::sSiteMainDB  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        public string mSetAuthSiteMemberDB(string pDbnm, string pSiteCd, string pAuthCd, string pCcodeGrp, string pViewFlag, string pNewFlag, string pModifyFlag, string pDelFlag, string pReportFlag, string pPrintFlag, string pDownloadFlag, string pInputId, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizComnCodeGrp bizComn = null;
            try
            {
                bizComn = new BizComnCodeGrp();

                int reCnt = bizComn.mSetAuthSiteMemberDB(pDbnm, pSiteCd, pAuthCd, pCcodeGrp, pViewFlag, pNewFlag, pModifyFlag, pDelFlag, pReportFlag, pPrintFlag, pDownloadFlag);
                int reCntLog = bizComn.aSetAuthSiteMemberDBLog(pDbnm, pSiteCd, pAuthCd, pCcodeGrp, pViewFlag, pNewFlag, pModifyFlag, pDelFlag, pReportFlag, pPrintFlag, pDownloadFlag, pInputId);

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
                logs.SaveLog("[error]  (page)::WsMenuMainDB.svc  (Function)::mMenuMemberDB  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        public string aSetAuthSiteMemberDB(string pDbnm, string pSiteCd, string pAuthCd, string pCcodeGrp, string pViewFlag, string pNewFlag, string pModifyFlag, string pDelFlag, string pReportFlag, string pPrintFlag, string pDownloadFlag, string pInputId, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizComnCodeGrp bizComn = null;
            try
            {
                bizComn = new BizComnCodeGrp();

                int reCnt = bizComn.aSetAuthSiteMemberDB(pDbnm, pSiteCd, pAuthCd, pCcodeGrp, pViewFlag, pNewFlag, pModifyFlag, pDelFlag, pReportFlag, pPrintFlag, pDownloadFlag, pInputId);
                int reCntLog = bizComn.aSetAuthSiteMemberDBLog(pDbnm, pSiteCd, pAuthCd, pCcodeGrp, pViewFlag, pNewFlag, pModifyFlag, pDelFlag, pReportFlag, pPrintFlag, pDownloadFlag, pInputId);
                if (reCnt > 0)
                {
                    reMsg = "[검색 성공]";
                    reCode = "Y";
                    reData = reCnt.ToString();
                }
                else
                {
                    reMsg = "[검색 성공] - 정보 없음";
                    reCode = "Y";
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsMenuMainDB.svc  (Function)::aMenuMemberDB  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[검색 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        public string sComnSiteTreeView(string pDbnm, string pSiteCd, string pAuthCd, out List<DataSetAuthSiteMemberDB> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizComnCodeGrp bizComn = null;
            try
            {
                bizComn = new BizComnCodeGrp();

                try
                {
                    ds = bizComn.sComnSiteTreeView(pDbnm, pSiteCd, pAuthCd);

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

            List<DataSetAuthSiteMemberDB> data = new List<DataSetAuthSiteMemberDB>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataSetAuthSiteMemberDB>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsMenuMainDB.svc  (Function)::sSiteMainDB  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        public string sComnSite(string pDbnm, string pSiteCd, string pCcodeGrp, string pUsingFlag, string pCcodeNm, out List<DataComecodeSite> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizComnCodeGrp bizComn = null;
            try
            {
                bizComn = new BizComnCodeGrp();

                try
                {
                    ds = bizComn.sComnSite(pDbnm, pSiteCd, pCcodeGrp, pUsingFlag, pCcodeNm);

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

            List<DataComecodeSite> data = new List<DataComecodeSite>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataComecodeSite>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsMenuMainDB.svc  (Function)::sSiteMainDB  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        public string mComnSite(string pDbnm, string pSiteCd, string pCcode, string pUsingFlag, string pSortNo, string pMemo, string pInputId, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizComnCodeGrp bizComn = null;
            try
            {
                bizComn = new BizComnCodeGrp();

                int reCnt = bizComn.mComnSite(pDbnm, pSiteCd, pCcode, pUsingFlag, pSortNo, pMemo);
                int reCntLog = bizComn.aComnSiteLog(pDbnm, pSiteCd, pCcode, pUsingFlag, pSortNo, pMemo, pInputId);

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
                logs.SaveLog("[error]  (page)::WsMenuMainDB.svc  (Function)::mMenuMemberDB  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        public string aComnSite(string pDbNm, string[] param, out string reMsg, out string reData)
        {
            string reCode = "N";

            string reVal = "";
            BizComnCodeGrp bizComn = null;
            try
            {
                bizComn = new BizComnCodeGrp();

                try
                {
                    Hashtable hParam = new Hashtable();
                    hParam.Add("pSite_Cd", Convert.ToInt32(param[0]));
                    hParam.Add("pCcode_Grp", param[1].ToString());
                    hParam.Add("pCcode_Nm", param[2].ToString());
                    hParam.Add("pMemo", param[3].ToString());
                    hParam.Add("pSort_No", Convert.ToInt32(param[4]));
                    hParam.Add("pInput_Id", Convert.ToInt32(param[5]));
                    hParam.Add("@rtnCcode", "");

                    reVal = bizComn.aComnSite(pDbNm, hParam, out Hashtable outVal);

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
                reMsg = "[검색 에러 - BizSystem 연결 실패] :: " + ex.ToString();
                reCode = "N";
            }

            reData = reVal;

            return reCode;
        }

    }
}