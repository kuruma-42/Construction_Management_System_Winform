using EldigmPlusSvc_Main.Biz.Common;
using EldigmPlusSvc_Main.Biz.Worker.InOut;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EldigmPlusSvc_Main.WebSvc.Worker.InOut
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드, svc 및 config 파일에서 클래스 이름 "WsInOut"을 변경할 수 있습니다.
    // 참고: 이 서비스를 테스트하기 위해 WCF 테스트 클라이언트를 시작하려면 솔루션 탐색기에서 WsInOut.svc나 WsInOut.svc.cs를 선택하고 디버깅을 시작하십시오.
    public class WsInOut : IWsInOut
    {
        LogClass logs = new LogClass();

        //DEVICE TYPE CMB BOX
        public string sLaborCompanyList(string pSiteCd, string pAuthCd, string pCoCd, out List<DataComCombo> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizInOut bizInOut = null;
            try
            {
                bizInOut = new BizInOut();

                try
                {
                    ds = bizInOut.sLaborCompanyList(pSiteCd, pAuthCd, pCoCd);

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
                logs.SaveLog("[error]  (page)::WsInOut.svc  (Function)::sLaborCompanyList  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        public string co_Cmb(string pSiteCd, out List<DataComCombo> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizInOut bizInOut = null;
            try
            {
                bizInOut = new BizInOut();

                try
                {
                    ds = bizInOut.co_Cmb(pSiteCd);

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
                logs.SaveLog("[error]  (page)::WsInOut.svc  (Function)::sLaborCompanyList  (Detail)::co_Cmb " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        public string team_Cmb(string pSiteCd, out List<DataComCombo> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizInOut bizInOut = null;
            try
            {
                bizInOut = new BizInOut();

                try
                {
                    ds = bizInOut.team_Cmb(pSiteCd);

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
                logs.SaveLog("[error]  (page)::WsInOut.svc  (Function)::team_Cmb  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        public string sInOut(string pDbnm, string pSiteCd, string pDtp1, string pDtp2, string pCocd, string pCmbIO, out List<DataInOut> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizInOut bizInOut = null;
            try
            {
                bizInOut = new BizInOut();

                try
                {
                    ds = bizInOut.sInOut(pDbnm, pSiteCd, pDtp1, pDtp2, pCocd, pCmbIO);

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

            List<DataInOut> data = new List<DataInOut>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataInOut>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsInOut.svc  (Function)::sInOut  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        public string sInOutHistory(string pDbnm, string pSiteCd, string pDtp1, string pDtp2, string pCocd, out List<DataInOut> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizInOut bizInOut = null;
            try
            {
                bizInOut = new BizInOut();

                try
                {
                    ds = bizInOut.sInOutHistory(pDbnm, pSiteCd, pDtp1, pDtp2, pCocd);

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

            List<DataInOut> data = new List<DataInOut>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataInOut>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsInOut.svc  (Function)::sInOutHistory  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        public string mInOut(string pDbnm, string pLabNo, string pSiteCd, string pRegDate, string pInDt, string pOutDt, string pCoCd, string pTeamCd, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizInOut bizInOut = null;
            try
            {
                bizInOut = new BizInOut();

                int reCnt = bizInOut.mInOut(pDbnm, pLabNo, pSiteCd, pRegDate, pInDt, pOutDt, pCoCd, pTeamCd);

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
                logs.SaveLog("[error]  (page)::WsInOut.svc  (Function)::mInOut  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        public string aInOutLog(string pDbnm, string pLabNo, string pSiteCd, string pRegDate, string pInDt, string pOutDt, string pCoCd, string pTeamCd, string pInIOPFId, string pOutIOPFId, string pInputId, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizInOut bizInOut = null;
            try
            {
                bizInOut = new BizInOut();

                int reCnt = bizInOut.aInOutLog(pDbnm, pLabNo, pSiteCd, pRegDate, pInDt, pOutDt, pCoCd, pTeamCd, pInIOPFId, pOutIOPFId, pInputId);

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
                logs.SaveLog("[error]  (page)::WsInOut.svc  (Function)::aInOutLog  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        public string dInHistory(string pDbnm, string pLabNo, string pSiteCd, string pRegDate, string pEventDt, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizInOut bizInOut = null;
            try
            {
                bizInOut = new BizInOut();

                int reCnt = bizInOut.dInHistory(pDbnm, pLabNo, pSiteCd, pRegDate, pEventDt);

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
                logs.SaveLog("[error]  (page)::WsInOut.svc  (Function)::exInOutHistory  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        public string dOutHistory(string pDbnm, string pLabNo, string pSiteCd, string pRegDate, string pEventDt, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizInOut bizInOut = null;
            try
            {
                bizInOut = new BizInOut();

                int reCnt = bizInOut.dOutHistory(pDbnm, pLabNo, pSiteCd, pRegDate, pEventDt);

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
                logs.SaveLog("[error]  (page)::WsInOut.svc  (Function)::exInOutHistory  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        public string mInOutHistory(string pDbnm, string pLabNo, string pSiteCd, string pRegDate, string pEventDt, string pEventDtH, string pCoCd, string pTeamCd, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizInOut bizInOut = null;
            try
            {
                bizInOut = new BizInOut();

                int reCnt = bizInOut.mInOutHistory(pDbnm, pLabNo, pSiteCd, pRegDate, pEventDt, pEventDtH, pCoCd, pTeamCd);

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
                logs.SaveLog("[error]  (page)::WsInOut.svc  (Function)::mInOutHistory  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        public string aInOutHistory(string pDbnm, string pLabNo, string pSiteCd, string pRegDate, string pEventDt, string pCoCd, string pTeamCd, string pInputId, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizInOut bizInOut = null;
            try
            {
                bizInOut = new BizInOut();

                int reCnt = bizInOut.aInOutHistory(pDbnm, pLabNo, pSiteCd, pRegDate, pEventDt, pCoCd, pTeamCd, pInputId);

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
                logs.SaveLog("[error]  (page)::WsInOut.svc  (Function)::aInOutHistory  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        public string aInOut(string pDbnm, string pLabNo, string pSiteCd, string pRegDate, string pInDt, string pOutDt, string pCoCd, string pTeamCd, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizInOut bizInOut = null;
            try
            {
                bizInOut = new BizInOut();

                int reCnt = bizInOut.aInOut(pDbnm, pLabNo, pSiteCd, pRegDate, pInDt, pOutDt, pCoCd, pTeamCd);

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
                logs.SaveLog("[error]  (page)::WsInOut.svc  (Function)::aInOut  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        public string exInOutCo(string pDbnm, string pLabNo, string pSiteCd, string CO_CD, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizInOut bizInOut = null;
            try
            {
                bizInOut = new BizInOut();

                string reCnt = bizInOut.exInOutCo(pDbnm, pLabNo, pSiteCd, CO_CD);

                if (reCnt != "0")
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
                logs.SaveLog("[error]  (page)::WsInOut.svc  (Function)::exInOutCo  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        public string aInOutCo(string pDbnm, string pLabNo, string pSiteCd, string pCoCd, string pInDt, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizInOut bizInOut = null;
            try
            {
                bizInOut = new BizInOut();

                int reCnt = bizInOut.aInOutCo(pDbnm, pLabNo, pSiteCd, pCoCd, pInDt);

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
                logs.SaveLog("[error]  (page)::WsInOut.svc  (Function)::aInOutCo  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        public string mInOutCo(string pDbnm, string pLabNo, string pSiteCd, string pCoCd, string pInDt, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizInOut bizInOut = null;
            try
            {
                bizInOut = new BizInOut();

                int reCnt = bizInOut.mInOutCo(pDbnm, pLabNo, pSiteCd, pCoCd, pInDt);

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
                logs.SaveLog("[error]  (page)::WsInOut.svc  (Function)::mInOutCo  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        public string exLabInOutFinal(string pLabNo, string pSiteCd, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizInOut bizInOut = null;
            try
            {
                bizInOut = new BizInOut();

                int reCnt = bizInOut.exLabInOutFinal(pLabNo, pSiteCd);

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
                logs.SaveLog("[error]  (page)::WsInOut.svc  (Function)::exLabInOutFinal  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        public string mLabInOutFinal(string pLabNo, string pSiteCd, string pCoCd, string pTeamCd, string pRegDate, string pInHHMM, string pOutHHMM, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizInOut bizInOut = null;
            try
            {
                bizInOut = new BizInOut();

                int reCnt = bizInOut.mLabInOutFinal(pLabNo, pSiteCd, pCoCd, pTeamCd, pRegDate, pInHHMM, pOutHHMM);

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
                logs.SaveLog("[error]  (page)::WsInOut.svc  (Function)::mLabInOutFinal  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        public string aLabInOutFinal(string pLabNo, string pSiteCd, string pCoCd, string pTeamCd, string pRegDate, string pInHHMM, string pOutHHMM, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizInOut bizInOut = null;
            try
            {
                bizInOut = new BizInOut();

                int reCnt = bizInOut.aLabInOutFinal(pLabNo, pSiteCd, pCoCd, pTeamCd, pRegDate, pInHHMM, pOutHHMM);

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
                logs.SaveLog("[error]  (page)::WsInOut.svc  (Function)::aLabInOutFinal  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        public string exInOut2020(string pLabNo, string pSiteCd, string pRegdate, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizInOut bizInOut = null;
            try
            {
                bizInOut = new BizInOut();

                int reCnt = bizInOut.exInOut2020(pLabNo, pSiteCd, pRegdate);

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
                logs.SaveLog("[error]  (page)::WsInOut.svc  (Function)::exInOut2020  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        public string aInOut2020(string pLabNo, string pSiteCd, string pRegdate, string pCoCd, string pTeamCd, string pInHHMM, string pOutHHMM, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizInOut bizInOut = null;
            try
            {
                bizInOut = new BizInOut();

                int reCnt = bizInOut.aInOut2020(pLabNo, pSiteCd, pRegdate, pCoCd, pTeamCd, pInHHMM, pOutHHMM);

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
                logs.SaveLog("[error]  (page)::WsInOut.svc  (Function)::aInOut2020  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        public string mInOut2020(string pLabNo, string pSiteCd, string pRegdate, string pCoCd, string pTeamCd, string pInHHMM, string pOutHHMM, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizInOut bizInOut = null;
            try
            {
                bizInOut = new BizInOut();

                int reCnt = bizInOut.mInOut2020(pLabNo, pSiteCd, pRegdate, pCoCd, pTeamCd, pInHHMM, pOutHHMM);

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
                logs.SaveLog("[error]  (page)::WsInOut.svc  (Function)::mInOut2020  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

    }
}
