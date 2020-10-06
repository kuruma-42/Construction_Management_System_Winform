using EldigmPlusSvc_Memco.Biz.Common;
using EldigmPlusSvc_Memco.Biz.Sys.SysAuth;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EldigmPlusSvc_Memco.WebSvc.Sys.SysAuth
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드, svc 및 config 파일에서 클래스 이름 "WsSysAuthMemberDB"을 변경할 수 있습니다.
    // 참고: 이 서비스를 테스트하기 위해 WCF 테스트 클라이언트를 시작하려면 솔루션 탐색기에서 WsSysAuthMemberDB.svc나 WsSysAuthMemberDB.svc.cs를 선택하고 디버깅을 시작하십시오.
    public class WsSysAuthMemberDB : IWsSysAuthMemberDB
    {//
        // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드, svc 및 config 파일에서 클래스 이름 "WsSysAuthMainDB"을 변경할 수 있습니다.
        // 참고: 이 서비스를 테스트하기 위해 WCF 테스트 클라이언트를 시작하려면 솔루션 탐색기에서 WsSysAuthMainDB.svc나 WsSysAuthMainDB.svc.cs를 선택하고 디버깅을 시작하십시오.

        LogClass logs = new LogClass();
        public string sDbNm(string pMemcoCd, out string reData, out string reMsg)
        {
            string reCode = "N";

            string reVal = "";
            BizSysAuthMemberDB bizHome = null;
            try
            {
                bizHome = new BizSysAuthMemberDB();

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
                logs.SaveLog("[error]  (page)::WsSysAuthMemberDB.svc  (Function)::sDbNm  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg = "[검색 에러 - BizSystem 연결 실패] :: " + ex.ToString();
                reCode = "N";
            }

            reData = reVal;

            return reCode;
        }

        public string sMemberMainDB(out List<DataMemberMainDB> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizSysAuthMemberDB bizSys = null;
            try
            {
                bizSys = new BizSysAuthMemberDB();

                try
                {
                    ds = bizSys.sMemberMainDB();

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

            List<DataMemberMainDB> data = new List<DataMemberMainDB>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataMemberMainDB>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsSysAuthMemberDB.svc  (Function)::sMemberMainDB  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }


        public string sSysAuthMemberDB(string pDbnm, string pUsingFlag, out List<DataSysAuthMemberDB> reList, out string reMsg) //셀렉트 
        {
            string reCode = "N";

            DataSet ds = null;
            BizSysAuthMemberDB bizSys = null;
            try
            {
                bizSys = new BizSysAuthMemberDB();

                try
                {
                    ds = bizSys.sSysAuthMemberDB(pDbnm, pUsingFlag);

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

            List<DataSysAuthMemberDB> data = new List<DataSysAuthMemberDB>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataSysAuthMemberDB>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsSysAuthMemberDB.svc  (Function)::sSysAuthMemberDB  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        //수정
        public string mSysAuthMemberDB(string pDbnm, string sauthCd_val, string sauthNm_val, string myblockFlag_val, string myconFlag_val, string mycomFlag_val, string myteamFlag_val, string usingFlag_val, string memo_val, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizSysAuthMemberDB bizSys = null;
            try
            {
                bizSys = new BizSysAuthMemberDB();

                int reCnt = bizSys.mSysAuthMemberDB(pDbnm, sauthCd_val, sauthNm_val, myblockFlag_val, myconFlag_val, mycomFlag_val, myteamFlag_val, usingFlag_val, memo_val);

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
                logs.SaveLog("[error]  (page)::WsSysAuthMemberDB.svc  (Function)::mSysAuthMemberDB  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        //중복 체크
        public string exSysAuthMainDB(string sauthCd_val, string sauthNm_val, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizSysAuthMemberDB bizSys = null;
            try
            {
                bizSys = new BizSysAuthMemberDB();

                int reCnt = bizSys.exSysAuthMainDB(sauthCd_val, sauthNm_val);

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
                logs.SaveLog("[error]  (page)::WsSysAuthMemberDB.svc  (Function)::exSysAuthMemberDB  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[검색 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        //추가 
        public string aSysAuthMemberDB(string pDbnm, string sauthCd_val, string sauthNm_val, string myblockFlag_val, string myconFlag_val, string mycomFlag_val, string myteamFlag_val, string usingFlag_val, string sauthLevel_val, string memo_val, string pInputId, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "";

            BizSysAuthMemberDB bizSys = null;
            try
            {
                bizSys = new BizSysAuthMemberDB();

                int reCnt = bizSys.aSysAuthMemberDB(pDbnm, sauthCd_val, sauthNm_val, myblockFlag_val, myconFlag_val, mycomFlag_val, myteamFlag_val, usingFlag_val, sauthLevel_val, memo_val, pInputId);

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
                logs.SaveLog("[error]  (page)::WsSysAuthMemberDB.svc  (Function)::aSysAuthMemberDB  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        //MAIN DB에 INSERT
        public string aSysAuthMainDB(string sauthCd_val, string sauthNm_val, string myblockFlag_val, string myconFlag_val, string mycomFlag_val, string myteamFlag_val, string usingFlag_val, string sauthLevel_val, string memo_val, string pInputId, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "";

            BizSysAuthMemberDB bizSys = null;
            try
            {
                bizSys = new BizSysAuthMemberDB();

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
                logs.SaveLog("[error]  (page)::WsSysAuthMemberDB.svc  (Function)::aSysAuthMainDB  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }




        //SysAuthSiteDB PART  


        //SysAuthSiteDB
        //COMBO BOX -> SITE_CD SITE_NM
        public string sSiteMainDB(string pMemcoCd, out List<DataSiteMainDB> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizSysSiteDB bizSys = null;
            try
            {
                bizSys = new BizSysSiteDB();

                try
                {
                    ds = bizSys.sSiteMainDB(pMemcoCd);

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

            List<DataSiteMainDB> data = new List<DataSiteMainDB>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataSiteMainDB>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsSysAuthMemberDB.svc  (Function)::sSiteMainDB  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        //SysAuthSiteDB
        //SITE -> DBNM 가져오기 
        public string siteDbNm(string pSiteCd, out string reData, out string reMsg)
        {
            string reCode = "N";

            string reVal = "";
            BizSysSiteDB bizHome = null;
            try
            {
                bizHome = new BizSysSiteDB();

                try
                {
                    reVal = bizHome.siteDbNm(pSiteCd);

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
                logs.SaveLog("[error]  (page)::WsSysAuthMemberDB.svc  (Function)::siteDbNm  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg = "[검색 에러 - BizSystem 연결 실패] :: " + ex.ToString();
                reCode = "N";
            }

            reData = reVal;

            return reCode;
        }

        //SysAuthSiteDB
        //SELECT 
        public string sSysAuthSiteDB(string pSiteCd, string pDbnm, string pUsingFlag, out List<DataSysAuthSiteDB> reList, out string reMsg) 
        {
            string reCode = "N";

            DataSet ds = null;
            BizSysSiteDB bizSys = null;
            try
            {
                bizSys = new BizSysSiteDB();

                try
                {
                    ds = bizSys.sSysAuthSiteDB(pSiteCd, pDbnm, pUsingFlag);

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

            List<DataSysAuthSiteDB> data = new List<DataSysAuthSiteDB>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataSysAuthSiteDB>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsSysAuthMemberDB.svc  (Function)::sSysAuthSiteDB  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }


        //SysAuthSiteDB
        //수정
        public string mSysAuthSiteDB(string pDbnm, string pSiteCd, string sauthCd_val, string lab_aprv_Flag_val, string usingFlag_val, string memo_val, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizSysSiteDB bizSys = null;
            try
            {
                bizSys = new BizSysSiteDB();

                int reCnt = bizSys.mSysAuthSiteDB(pDbnm, pSiteCd, sauthCd_val, lab_aprv_Flag_val, usingFlag_val, memo_val);

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
                logs.SaveLog("[error]  (page)::WsSysAuthMemberDB.svc  (Function)::mSysAuthSiteDB  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        //SysAuthSiteDB
        //추가 
        public string aSysAuthSiteDB(string pDbnm, string pSiteCd, string sauthCd_val, string lab_aprv_Flag_val, string usingFlag_val, string sauthLevel_val, string memo_val, string pInputId, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "";

            BizSysSiteDB bizSys = null;
            try
            {
                bizSys = new BizSysSiteDB();

                int reCnt = bizSys.aSysAuthSiteDB(pDbnm, pSiteCd, sauthCd_val, lab_aprv_Flag_val, usingFlag_val, sauthLevel_val, memo_val, pInputId);

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
                logs.SaveLog("[error]  (page)::WsSysAuthMemberDB.svc  (Function)::aSysAuthSiteDB  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }
    }

 
    



}
