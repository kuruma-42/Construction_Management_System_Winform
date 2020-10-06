using EldigmPlusSvc_Main.Biz.Common;
using EldigmPlusSvc_Main.Biz.Sys.SysAuth;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using static EldigmPlusSvc_Main.WebSvc.Sys.SysAuth.IWsSysAuthMainDB;

namespace EldigmPlusSvc_Main.WebSvc.Sys.SysAuth
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드, svc 및 config 파일에서 클래스 이름 "WsSysAuthMainDB"을 변경할 수 있습니다.
    // 참고: 이 서비스를 테스트하기 위해 WCF 테스트 클라이언트를 시작하려면 솔루션 탐색기에서 WsSysAuthMainDB.svc나 WsSysAuthMainDB.svc.cs를 선택하고 디버깅을 시작하십시오.
    public class WsSysAuthMainDB : IWsSysAuthMainDB
    {
        // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드, svc 및 config 파일에서 클래스 이름 "WsSysAuthMainDB"을 변경할 수 있습니다.
        // 참고: 이 서비스를 테스트하기 위해 WCF 테스트 클라이언트를 시작하려면 솔루션 탐색기에서 WsSysAuthMainDB.svc나 WsSysAuthMainDB.svc.cs를 선택하고 디버깅을 시작하십시오.

        LogClass logs = new LogClass();
        public string sSysAuthMainDB(string pUsingFlag , out List<DataSysAuthMainDB> reList, out string reMsg) //셀렉트 
        {
            string reCode = "N";

            DataSet ds = null;
            BizSysAuthMainDB bizSys = null;
            try
            {
                bizSys = new BizSysAuthMainDB();

                try
                {
                    ds = bizSys.sSysAuthMainDB(pUsingFlag);

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

            List<DataSysAuthMainDB> data = new List<DataSysAuthMainDB>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataSysAuthMainDB>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsSysAuthMainDB.svc  (Function)::sSysAuthMainDB  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        //수정
        public string mSysAuthMainDB(string sauthCd_val, string sauthNm_val, string myblockFlag_val, string myconFlag_val, string mycomFlag_val, string myteamFlag_val, string usingFlag_val, string memo_val, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizSysAuthMainDB bizSys = null;
            try
            {
                bizSys = new BizSysAuthMainDB();

                int reCnt = bizSys.mSysAuthMainDB(sauthCd_val, sauthNm_val, myblockFlag_val, myconFlag_val, mycomFlag_val, myteamFlag_val, usingFlag_val, memo_val);

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
                logs.SaveLog("[error]  (page)::WsSysAuthMainDB.svc  (Function)::mSysAuthMainDB  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        //중복 체크
        public string exSysAuthMainDB(string sauthCd_val, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizSysAuthMainDB bizSys = null;
            try
            {
                bizSys = new BizSysAuthMainDB();

                int reCnt = bizSys.exSysAuthMainDB(sauthCd_val);

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
                logs.SaveLog("[error]  (page)::WsSysAuthMainDB.svc  (Function)::exSysAuthMainDB  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[검색 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        //추가 
        public string aSysAuthMainDB(string sauthCd_val, string sauthNm_val, string myblockFlag_val, string myconFlag_val, string mycomFlag_val, string myteamFlag_val, string usingFlag_val, string sauthLevel_val, string memo_val, string pInputId, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "";

            BizSysAuthMainDB bizSys = null;
            try
            {
                bizSys = new BizSysAuthMainDB();

                int reCnt = bizSys.aSysAuthMainDB(sauthCd_val, sauthNm_val, myblockFlag_val, myconFlag_val, mycomFlag_val, myteamFlag_val, usingFlag_val, sauthLevel_val, memo_val, pInputId);

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
                logs.SaveLog("[error]  (page)::WsSysAuthMainDB.svc  (Function)::aSysAuthMainDB  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }
        
    }

}
