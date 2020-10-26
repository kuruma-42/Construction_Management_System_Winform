using EldigmPlusSvc_Memco.Biz.Common;
using EldigmPlusSvc_Memco.Biz.MainHome;
using System;
using System.Collections.Generic;
using System.Data;

namespace EldigmPlusSvc_Memco.WebSvc.MainHome
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드, svc 및 config 파일에서 클래스 이름 "WsMainHome"을 변경할 수 있습니다.
    // 참고: 이 서비스를 테스트하기 위해 WCF 테스트 클라이언트를 시작하려면 솔루션 탐색기에서 WsMainHome.svc나 WsMainHome.svc.cs를 선택하고 디버깅을 시작하십시오.
    public class WsMainHome : IWsMainHome
    {
        LogClass logs = new LogClass();

        public string sDbNm(string pMemcoCd, out string reData, out string reMsg)
        {
            string reCode = "N";

            string reVal = "";
            BizMainHome bizHome = null;
            try
            {
                bizHome = new BizMainHome();

                try
                {
                    reVal = bizHome.sDbNm(pMemcoCd);

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
                reMsg = "[검색 에러 - BizMainHome 연결 실패] :: " + ex.ToString();
                reCode = "N";
            }

            reData = reVal;

            return reCode;
        }

        public string sSiteMenu(string pDbNm, string pSiteCd, out List<DataTopMenu> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizMainHome bizHome = null;
            try
            {
                bizHome = new BizMainHome();

                try
                {
                    ds = bizHome.sSiteMenu(pDbNm, pSiteCd);

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
                reMsg = "[검색 에러 - BizMainHome 연결 실패] :: " + ex.ToString();
                reCode = "N";
            }

            List<DataTopMenu> data = new List<DataTopMenu>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataTopMenu>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsMainHome.svc  (Function)::sSiteMenu  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        public string sSiteSubMenu1(string pDbNm, string pSiteCd, string pTopMenuCd, out List<DataSubMenu1> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizMainHome bizHome = null;
            try
            {
                bizHome = new BizMainHome();

                try
                {
                    ds = bizHome.sSiteSubMenu1(pDbNm, pSiteCd, pTopMenuCd);

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
                reMsg = "[검색 에러 - BizMainHome 연결 실패] :: " + ex.ToString();
                reCode = "N";
            }

            List<DataSubMenu1> data = new List<DataSubMenu1>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataSubMenu1>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsMainHome.svc  (Function)::sSiteSubMenu1  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        public string sSiteSubMenu2(string pDbNm, string pSiteCd, string pTopMenuCd, string pSubMenuCd, out List<DataSubMenu2> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizMainHome bizHome = null;
            try
            {
                bizHome = new BizMainHome();

                try
                {
                    ds = bizHome.sSiteSubMenu2(pDbNm, pSiteCd, pTopMenuCd, pSubMenuCd);

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
                reMsg = "[검색 에러 - BizMainHome 연결 실패] :: " + ex.ToString();
                reCode = "N";
            }

            List<DataSubMenu2> data = new List<DataSubMenu2>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataSubMenu2>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsMainHome.svc  (Function)::sSiteSubMenu2  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }
    }
}
