using EldigmPlusSvc_Main.Biz.Common;
using EldigmPlusSvc_Main.Biz.Sys.ComnCode;
using System;
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



    }
}