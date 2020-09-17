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
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드, svc 및 config 파일에서 클래스 이름 "WsSysCodeGrpPra"을 변경할 수 있습니다.
    // 참고: 이 서비스를 테스트하기 위해 WCF 테스트 클라이언트를 시작하려면 솔루션 탐색기에서 WsSysCodeGrpPra.svc나 WsSysCodeGrpPra.svc.cs를 선택하고 디버깅을 시작하십시오.
    public class WsSysCodeGrpPra : IWsSysCodeGrpPra
    {
        LogClass logs = new LogClass();

        public string psSysCodeGrp(string pScodeGrp, out List<DataSysCodeGrpPra> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizSysCodeGrpPra bizSys = null;
            try
            {
                bizSys = new BizSysCodeGrpPra();

                try
                {
                    ds = bizSys.psSysCodeGrp(pScodeGrp);

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

            List<DataSysCodeGrpPra> data = new List<DataSysCodeGrpPra>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataSysCodeGrpPra>(ds.Tables[0]);
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

        public string pmSysCodeGrp(string pScodeGrp, string pScodeNm, string pUsingFlag, string pSortNo, string pMemo, out string reMsg)
        {
            string reCode = "N";

            BizSysCodeGrpPra bizSys = null;
            try
            {
                bizSys = new BizSysCodeGrpPra();

                int reCnt = bizSys.pmSysCodeGrp(pScodeGrp, pScodeNm, pUsingFlag, pSortNo, pMemo);

                if (reCnt > 0)
                {
                    reMsg = "[저장 성공]";
                    reCode = "Y";
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



    }
}
