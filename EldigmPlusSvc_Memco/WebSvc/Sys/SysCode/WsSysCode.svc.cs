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
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드, svc 및 config 파일에서 클래스 이름 "WsSysCode"을 변경할 수 있습니다.
    // 참고: 이 서비스를 테스트하기 위해 WCF 테스트 클라이언트를 시작하려면 솔루션 탐색기에서 WsSysCode.svc나 WsSysCode.svc.cs를 선택하고 디버깅을 시작하십시오.
    public class WsSysCode : IWsSysCode
    {
        LogClass logs = new LogClass();

        public string sDbNm(string pMemcoCd, out string reData, out string reMsg)
        {
            string reCode = "N";

            string reVal = "";
            BizSysSysCode bizSysSysCode = null;
            try
            {
                bizSysSysCode = new BizSysSysCode();

                try
                {
                    reVal = bizSysSysCode.sDbNm(pMemcoCd);

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

        public string sSysSysCode(out List<DataCodeGroup> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizSysSysCode bizSysSysCode = null;
            try
            {
                bizSysSysCode = new BizSysSysCode();
                ds = bizSysSysCode.sSysCodeGrp();
                reCode = "Y";


                try
                {
                    ds = bizSysSysCode.sSysCodeGrp();

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

            List<DataCodeGroup> data = new List<DataCodeGroup>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataCodeGroup>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WebSvcSystem.svc  (Function)::sSiteMenu  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }
                
    }
}
