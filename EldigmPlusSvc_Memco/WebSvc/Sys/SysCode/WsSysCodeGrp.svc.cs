using EldigmPlusSvc_Memco.Biz.Common;
using EldigmPlusSvc_Memco.Biz.Sys.SysCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EldigmPlusSvc_Memco.WebSvc.Sys.SysCode
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드, svc 및 config 파일에서 클래스 이름 "WsSysCodeGrp"을 변경할 수 있습니다.
    // 참고: 이 서비스를 테스트하기 위해 WCF 테스트 클라이언트를 시작하려면 솔루션 탐색기에서 WsSysCodeGrp.svc나 WsSysCodeGrp.svc.cs를 선택하고 디버깅을 시작하십시오.
    public class WsSysCodeGrp : IWsSysCodeGrp
    {
        LogClass logs = new LogClass();

        public string sSysCodeGrp(string pScodeGrp, out List<DataSysCodeGrp> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizSysCodeGrp bizSys = null;
            try
            {
                bizSys = new BizSysCodeGrp();

                try
                {
                    ds = bizSys.sSysCodeGrp(pScodeGrp);

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

            List<DataSysCodeGrp> data = new List<DataSysCodeGrp>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataSysCodeGrp>(ds.Tables[0]);
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

        public string mSysCodeGrp(string pScodeGrp, string pScodeNm, string pUsingFlag, string pSortNo, string pMemo, out string reMsg, out int reData)
        {
            string reCode = "N";
            reData = 0;

            BizSysCodeGrp bizSys = null;
            try
            {
                bizSys = new BizSysCodeGrp();

                int reCnt = bizSys.mSysCodeGrp(pScodeGrp, pScodeNm, pUsingFlag, pSortNo, pMemo);

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
                logs.SaveLog("[error]  (page)::WsSysCodeGrp.svc  (Function)::mSysCodeGrp  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        public string sSysCodeGrp_UsingFlag(string pUsingFlag, out List<DataSysCodeGrp> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizSysCodeGrp bizSys = null;
            try
            {
                bizSys = new BizSysCodeGrp();

                try
                {
                    ds = bizSys.sSysCodeGrp_UsingFlag(pUsingFlag);

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

            List<DataSysCodeGrp> data = new List<DataSysCodeGrp>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataSysCodeGrp>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsSysCodeGrp.svc  (Function)::sSysCodeGrp_UsingFlag  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        public string sSysCode(string pScodeGrp, string pUsingFlag, string pScodeNm, out List<DataSysCode> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizSysCodeGrp bizSys = null;
            try
            {
                bizSys = new BizSysCodeGrp();

                try
                {
                    ds = bizSys.sSysCode(pScodeGrp, pUsingFlag, pScodeNm);

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
                logs.SaveLog("[error]  (page)::WsSysCodeGrp.svc  (Function)::sSysCodeGrp_UsingFlag  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        public string mSysCode(string pScode, string pScodeNm, string pUsingFlag, string pSortNo, string pMemo, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "";

            BizSysCodeGrp bizSys = null;
            try
            {
                bizSys = new BizSysCodeGrp();

                int reCnt = bizSys.mSysCode(pScode, pScodeNm, pUsingFlag, pSortNo, pMemo);

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
                logs.SaveLog("[error]  (page)::WsSysCodeGrp.svc  (Function)::mSysCode  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        public string exSysCode(string pScode, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizSysCodeGrp bizSys = null;
            try
            {
                bizSys = new BizSysCodeGrp();

                int reCnt = bizSys.exSysCode(pScode);

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
                logs.SaveLog("[error]  (page)::WsSysCodeGrp.svc  (Function)::exSysCode  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[검색 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        public string aSysCode(string pScode, string pScodeGrp, string pScodeNm, string pUsingFlag, string pMemo, string pSortNo, string pInputId, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "";

            BizSysCodeGrp bizSys = null;
            try
            {
                bizSys = new BizSysCodeGrp();

                int reCnt = bizSys.aSysCode(pScode, pScodeGrp, pScodeNm, pUsingFlag, pMemo, pSortNo, pInputId);
                int reCnt2 = bizSys.aSysCodeLog(pScode, pScodeNm, pUsingFlag, pSortNo, pMemo, pInputId);

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
                logs.SaveLog("[error]  (page)::WsSysCodeGrp.svc  (Function)::aSysCode  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        public string fSysCodeSearch(string _scodeGrp, string pScode_Nm, out List<DataSysCode> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizSysCodeGrp bizSys = null;
            try
            {
                bizSys = new BizSysCodeGrp();

                try
                {
                    ds = bizSys.fSysCodeSearch(_scodeGrp, pScode_Nm);

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
                logs.SaveLog("[error]  (page)::WsSysCodeGrp.svc  (Function)::sSysCodeGrp_UsingFlag  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }



    }
}

