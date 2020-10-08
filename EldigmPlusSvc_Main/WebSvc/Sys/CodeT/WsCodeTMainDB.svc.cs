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
                logs.SaveLog("[error]  (page)::WsSysCodeGrp.svc  (Function)::sSysCodeGrp_UsingFlag  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
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
                logs.SaveLog("[error]  (page)::WsSysCodeGrp.svc  (Function)::sSysCodeGrp_UsingFlag  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
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
                logs.SaveLog("[error]  (page)::WsSysCodeGrp.svc  (Function)::sSysCodeGrp_UsingFlag  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
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
                logs.SaveLog("[error]  (page)::WsSysCodeGrp.svc  (Function)::sSysCodeGrp_UsingFlag  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
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
                logs.SaveLog("[error]  (page)::WsSysCodeGrp.svc  (Function)::sSysCodeGrp_UsingFlag  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }


    }
}
