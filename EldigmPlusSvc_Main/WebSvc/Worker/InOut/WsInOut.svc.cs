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

        public string sInOut(string pDbnm, string pSiteCd, string pDtp1, string pDtp2, out List<DataInOut> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizInOut bizInOut = null;
            try
            {
                bizInOut = new BizInOut();

                try
                {
                    ds = bizInOut.sInOut(pDbnm, pSiteCd, pDtp1, pDtp2);

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
                logs.SaveLog("[error]  (page)::WsSysCodeGrp.svc  (Function)::sSysCodeGrp  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        public string sInOutLog(string pDbnm, string pSiteCd, string pDtp1, string pDtp2, out List<DataInOut> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizInOut bizInOut = null;
            try
            {
                bizInOut = new BizInOut();

                try
                {
                    ds = bizInOut.sInOutLog(pDbnm, pSiteCd, pDtp1, pDtp2);

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
                logs.SaveLog("[error]  (page)::WsSysCodeGrp.svc  (Function)::sSysCodeGrp  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }


    }
}
