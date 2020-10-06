using EldigmPlusSvc_Main.Biz.Common;
using EldigmPlusSvc_Main.Biz.Sys.Menu;
using System;
using System.Collections.Generic;
using System.Data;

namespace EldigmPlusSvc_Main.WebSvc.Sys.Menu
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드, svc 및 config 파일에서 클래스 이름 "WsMenuMainDB"을 변경할 수 있습니다.
    // 참고: 이 서비스를 테스트하기 위해 WCF 테스트 클라이언트를 시작하려면 솔루션 탐색기에서 WsMenuMainDB.svc나 WsMenuMainDB.svc.cs를 선택하고 디버깅을 시작하십시오.
    public class WsMenuMainDB : IWsMenuMainDB
    {
        LogClass logs = new LogClass();

        public string sManuTopTreeView(string USING_FLAG, out List<DataMenuTop> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizMenuMainDB bizManu = null;
            try
            {
                bizManu = new BizMenuMainDB();

                try
                {
                    ds = bizManu.sManuTopTreeView(USING_FLAG);

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

            List<DataMenuTop> data = new List<DataMenuTop>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataMenuTop>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsMenuMainDB.svc  (Function)::sManuTopTreeView  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        public string sManuSubTreeView(string TOP_MENU_CD, string USING_FLAG, out List<DataMenuSub> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizMenuMainDB bizManu = null;
            try
            {
                bizManu = new BizMenuMainDB();

                try
                {
                    ds = bizManu.sManuSubTreeView(TOP_MENU_CD, USING_FLAG);

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

            List<DataMenuSub> data = new List<DataMenuSub>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataMenuSub>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsMenuMainDB.svc  (Function)::sManuSubTreeView  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        public string sManuTreeView(string TOP_MENU_CD, string SUB_MENU_CD, string USING_FLAG, out List<DataMenu> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizMenuMainDB bizManu = null;
            try
            {
                bizManu = new BizMenuMainDB();

                try
                {
                    ds = bizManu.sManuTreeView(TOP_MENU_CD, SUB_MENU_CD, USING_FLAG);

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

            List<DataMenu> data = new List<DataMenu>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataMenu>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsMenuMainDB.svc  (Function)::sManuTreeView  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        public string sManuTreeView2(string TOP_MENU_CD, string SUB_MENU_CD, string MENU_CD, string USING_FLAG, out List<DataMenu> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizMenuMainDB bizManu = null;
            try
            {
                bizManu = new BizMenuMainDB();

                try
                {
                    ds = bizManu.sManuTreeView2(TOP_MENU_CD, SUB_MENU_CD, MENU_CD, USING_FLAG);

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

            List<DataMenu> data = new List<DataMenu>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataMenu>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsMenuMainDB.svc  (Function)::sManuTreeView  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        public string exMenuTop(string TOP_MENU_CD, string TOP_MENU_NM, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizMenuMainDB bizManu = null;
            try
            {
                bizManu = new BizMenuMainDB();

                int reCnt = bizManu.exMenuTop(TOP_MENU_CD, TOP_MENU_NM);

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
                logs.SaveLog("[error]  (page)::WsMenuMainDB.svc  (Function)::exMenuTop  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[검색 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        public string exMenuSub(string SUB_MENU_CD, string TOP_MENU_CD, string SUB_MENU_NM, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizMenuMainDB bizManu = null;
            try
            {
                bizManu = new BizMenuMainDB();

                int reCnt = bizManu.exMenuSub(SUB_MENU_CD, TOP_MENU_CD, SUB_MENU_NM);

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
                logs.SaveLog("[error]  (page)::WsMenuMainDB.svc  (Function)::exMenuSub  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[검색 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        public string exMenu(string MENU_CD, string TOP_MENU_CD, string SUB_MENU_CD, string MENU_NM, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizMenuMainDB bizManu = null;
            try
            {
                bizManu = new BizMenuMainDB();

                int reCnt = bizManu.exMenu(MENU_CD, TOP_MENU_CD, SUB_MENU_CD, MENU_NM);

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
                logs.SaveLog("[error]  (page)::WsMenuMainDB.svc  (Function)::exMenu  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[검색 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        public string aMenuTop(string TOP_MENU_NM, string APP_FLAG, string USING_FLAG, string SORT_NO, string INPUT_ID, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizMenuMainDB bizManu = null;
            try
            {
                bizManu = new BizMenuMainDB();

                int reCnt = bizManu.aMenuTop(TOP_MENU_NM, APP_FLAG, USING_FLAG, SORT_NO, INPUT_ID);

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
                logs.SaveLog("[error]  (page)::WsMenuMainDB.svc  (Function)::aMenuTop  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[검색 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        public string aMenuSub(string TOP_MENU_CD, string SUB_MENU_NM, string USING_FLAG, string SORT_NO, string INPUT_ID, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizMenuMainDB bizManu = null;
            try
            {
                bizManu = new BizMenuMainDB();

                int reCnt = bizManu.aMenuSub(TOP_MENU_CD, SUB_MENU_NM, USING_FLAG, SORT_NO, INPUT_ID);

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
                logs.SaveLog("[error]  (page)::WsMenuMainDB.svc  (Function)::aMenuSub  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[검색 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        public string aMenu(string MENU_CD, string TOP_MENU_CD, string SUB_MENU_CD, string MENU_NM, string USING_FLAG, string SORT_NO, string INPUT_ID, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizMenuMainDB bizManu = null;
            try
            {
                bizManu = new BizMenuMainDB();

                int reCnt = bizManu.aMenu(MENU_CD, TOP_MENU_CD, SUB_MENU_CD, MENU_NM, USING_FLAG, SORT_NO, INPUT_ID);

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
                logs.SaveLog("[error]  (page)::WsMenuMainDB.svc  (Function)::aMenu  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[검색 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

    }
}
