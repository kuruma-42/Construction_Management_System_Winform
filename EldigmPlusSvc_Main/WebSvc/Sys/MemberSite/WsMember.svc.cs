using EldigmPlusSvc_Main.Biz.Common;
using EldigmPlusSvc_Main.Biz.Sys.MemberSite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EldigmPlusSvc_Main.WebSvc.Sys.MemberSite
{


    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드, svc 및 config 파일에서 클래스 이름 "WsMember"을 변경할 수 있습니다.
    // 참고: 이 서비스를 테스트하기 위해 WCF 테스트 클라이언트를 시작하려면 솔루션 탐색기에서 WsMember.svc나 WsMember.svc.cs를 선택하고 디버깅을 시작하십시오.
    public class WsMember : IWsMember
    {

        LogClass logs = new LogClass();

        //Select -> TreeView 
        public string sMember_UsingFlag(string pUsingFlag, out List<DataMemberDB> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizMember bizSys = null;
            try
            {
                bizSys = new BizMember();

                try
                {
                    ds = bizSys.sMember_UsingFlag(pUsingFlag);

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

            List<DataMemberDB> data = new List<DataMemberDB>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataMemberDB>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsMember.svc  (Function)::sMember_UsingFlag  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }


        //Select -> GridView1
        public string sMember(string pMemcoCd, out List<DataMemberDB> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizMember bizSys = null;
            try
            {
                bizSys = new BizMember();

                try
                {
                    ds = bizSys.sMember(pMemcoCd);

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

            List<DataMemberDB> data = new List<DataMemberDB>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataMemberDB>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsMember.svc  (Function)::sMember  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        //MODIFY
        public string mMember(string pMemcoCd, string pMemcoNm, string pUsingFlag, string pSortNo, string pMemo, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "";

            BizMember bizSys = null;
            try
            {
                bizSys = new BizMember();

                int reCnt = bizSys.mMember(pMemcoCd, pMemcoNm, pUsingFlag, pSortNo, pMemo);                

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
                logs.SaveLog("[error]  (page)::WsMember.svc  (Function)::mMember  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        //DUPLICATE CHECK  
        public string exMember(string pMemcoCd, string pMemcoNm, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizMember bizSys = null;
            try
            {
                bizSys = new BizMember();

                int reCnt = bizSys.exMember(pMemcoCd, pMemcoNm);

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
                logs.SaveLog("[error]  (page)::WsMember.svc  (Function)::exMember  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[검색 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        //INSERT 
        public string aMember(string pMemcoNM, string pDb_Nm, string pUsingFlag, string pSortNo, string pMemo, string pInputId, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "";

            BizMember bizSys = null;
            try
            {
                bizSys = new BizMember();

                int reCnt = bizSys.aMember(pMemcoNM, pDb_Nm, pUsingFlag, pSortNo, pMemo, pInputId);
              

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
                logs.SaveLog("[error]  (page)::WsMember.svc  (Function)::aMember  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }








        //SITE PART 
        //CMB BOX MEMCO_CD MEMCO_NM
        public string sMemberMainDB(out List<DataMemberMainDB> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizSite bizSys = null;
            try
            {
                bizSys = new BizSite();

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
                logs.SaveLog("[error]  (page)::WsMember.svc  (Function)::sMemberMainDB  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        //SELECT 
        public string sSite(string pMemcoCd, string pUsingFlag, out List<DataSiteDB> reList, out string reMsg) //셀렉트 
        {
            string reCode = "N";

            DataSet ds = null;
            BizSite bizSys = null;
            try
            {
                bizSys = new BizSite();

                try
                {
                    ds = bizSys.sSite(pMemcoCd, pUsingFlag);

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

            List<DataSiteDB> data = new List<DataSiteDB>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataSiteDB>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsMember.svc  (Function)::sSite  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }


        //MODIFY
        public string mSite(string siteCd_val, string siteNm_val, string usingFlag_val, string sortNo_val, string memo_val, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizSite bizSys = null;
            try
            {
                bizSys = new BizSite();

                int reCnt = bizSys.mSite(siteCd_val, siteNm_val, usingFlag_val, sortNo_val, memo_val);

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
                logs.SaveLog("[error]  (page)::WsMember.svc  (Function)::mSite  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }


        //DUPLICATE CHECK  
        public string exSite(string pSiteNm, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizSite bizSys = null;
            try
            {
                bizSys = new BizSite();

                int reCnt = bizSys.exSite(pSiteNm);

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
                logs.SaveLog("[error]  (page)::WsMember.svc  (Function)::exSite  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[검색 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        public string aSite(string pDbNm, string[] param, out string reData, out string reMsg)
        {
            string reCode = "N";

            string reVal = "";
            BizSite bizSys = null;
            try
            {
                bizSys = new BizSite();

                try
                {
                    Hashtable hParam = new Hashtable();
                    hParam.Add("pMemco_Cd", Convert.ToInt32(param[0]));
                    hParam.Add("pSite_Nm", param[1].ToString());
                    hParam.Add("pSort_No", Convert.ToInt32(param[2]));
                    hParam.Add("pMemo", param[3].ToString());
                    hParam.Add("pInput_Id", param[4].ToString());
                    hParam.Add("pHeadco_Cd", param[5].ToString());
                    hParam.Add("@rtnSite_Cd", "");

                    reVal = bizSys.aSite(pDbNm, hParam, out Hashtable outVal);

                    if (outVal != null)
                    {
                        foreach (DictionaryEntry dictionaryEntry in outVal)
                        {
                            string[] row = new string[] { dictionaryEntry.Key.ToString(), dictionaryEntry.Value.ToString() , "" };
                            //string rowCount = row.Length.ToString();
                            //string rowKey = row[0].ToString();
                            reVal = row[1].ToString();
                        }
                    }

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

        ////INSERT 
        //public string aSite(string memcoCd_val, string siteNm_val, string usingFlag_val, string sortNo_val, string memo_val, string pInputId, out string reMsg, out string reData)
        //{
        //    string reCode = "N";
        //    reData = "";

        //    BizSite bizSys = null;
        //    try
        //    {
        //        bizSys = new BizSite();

        //        int reCnt = bizSys.aSite(memcoCd_val, siteNm_val, usingFlag_val, sortNo_val, memo_val, pInputId);


        //        if (reCnt > 0)
        //        {
        //            reMsg = "[저장 성공]";
        //            reCode = "Y";
        //            reData = reCnt.ToString();
        //        }
        //        else
        //        {
        //            reMsg = "[저장 성공] - 정보 없음";
        //            reCode = "Y";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        logs.SaveLog("[error]  (page)::WsMember.svc  (Function)::aSite  (Detail)::" + "\r\n" + ex.ToString(), "Error");
        //        reMsg = "[저장 에러] :: " + ex.ToString();
        //        reCode = "N";
        //    }

        //    return reCode;
        //}


        ////INSERT MEMCO SITE
        //public string aSite_Member(string siteCd_val, string memcoCd_val, string siteNm_val, string headcoCd_val, out string reMsg, out string reData)
        //{
        //    string reCode = "N";
        //    reData = "";

        //    BizSite bizSys = null;
        //    try
        //    {
        //        bizSys = new BizSite();

        //        int reCnt = bizSys.aSite_Member(siteCd_val, memcoCd_val, siteNm_val, headcoCd_val);


        //        if (reCnt > 0)
        //        {
        //            reMsg = "[저장 성공]";
        //            reCode = "Y";
        //            reData = reCnt.ToString();
        //        }
        //        else
        //        {
        //            reMsg = "[저장 성공] - 정보 없음";
        //            reCode = "Y";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        logs.SaveLog("[error]  (page)::WsMember.svc  (Function)::aSite_Member  (Detail)::" + "\r\n" + ex.ToString(), "Error");
        //        reMsg = "[저장 에러] :: " + ex.ToString();
        //        reCode = "N";
        //    }

        //    return reCode;
        //}


        ////INSERT MEMCO SITE_INFO
        //public string aSiteInfo_Member(string siteCd_val, string memcoCd_val, out string reMsg, out string reData)
        //{
        //    string reCode = "N";
        //    reData = "";

        //    BizSite bizSys = null;
        //    try
        //    {
        //        bizSys = new BizSite();

        //        int reCnt = bizSys.aSiteInfo_Member(siteCd_val, memcoCd_val);


        //        if (reCnt > 0)
        //        {
        //            reMsg = "[저장 성공]";
        //            reCode = "Y";
        //            reData = reCnt.ToString();
        //        }
        //        else
        //        {
        //            reMsg = "[저장 성공] - 정보 없음";
        //            reCode = "Y";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        logs.SaveLog("[error]  (page)::WsMember.svc  (Function)::aSiteInfo_Member  (Detail)::" + "\r\n" + ex.ToString(), "Error");
        //        reMsg = "[저장 에러] :: " + ex.ToString();
        //        reCode = "N";
        //    }

        //    return reCode;
        //}


    }
}