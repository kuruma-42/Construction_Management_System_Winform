using EldigmPlusSvc_Memco.Biz.Common;
using EldigmPlusSvc_Memco.Biz.Sys.Device;
using EldigmPlusSvc_Memco.Biz.Worker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EldigmPlusSvc_Memco.WebSvc.Sys.Worker
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드, svc 및 config 파일에서 클래스 이름 "WsWorkerLaborSearch"을 변경할 수 있습니다.
    // 참고: 이 서비스를 테스트하기 위해 WCF 테스트 클라이언트를 시작하려면 솔루션 탐색기에서 WsWorkerLaborSearch.svc나 WsWorkerLaborSearch.svc.cs를 선택하고 디버깅을 시작하십시오.
    public class WsWorkerLaborSearch : IWsWorkerLaborSearch
    {
        LogClass logs = new LogClass();


        //Block CMB BOX 
        public string sLaborBlockList(string pSiteCd, string pAuthCd, string pCcode, out List<DataComCombo> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizLaborSearch bizSys = null;
            try
            {
                bizSys = new BizLaborSearch();

                try
                {
                    ds = bizSys.sLaborBlockList(pSiteCd, pAuthCd, pCcode);

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

            List<DataComCombo> data = new List<DataComCombo>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataComCombo>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsWorkerLaborSearch.svc  (Function)::sLaborConstList  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }


        //Const CMB BOX 
        public string sLaborConstList(string pSiteCd, string pAuthCd, string pCcode, out List<DataComCombo> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizLaborSearch bizSys = null;
            try
            {
                bizSys = new BizLaborSearch();

                try
                {
                    ds = bizSys.sLaborConstList(pSiteCd, pAuthCd, pCcode);

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

            List<DataComCombo> data = new List<DataComCombo>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataComCombo>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsWorkerLaborSearch.svc  (Function)::sLaborConstList  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }


        //JOB CMB BOX 
        public string sLaborJobList(string pSiteCd, out List<DataComCombo> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizLaborSearch bizSys = null;
            try
            {
                bizSys = new BizLaborSearch();

                try
                {
                    ds = bizSys.sLaborJobList(pSiteCd);

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

            List<DataComCombo> data = new List<DataComCombo>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataComCombo>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsWorkerLaborSearch.svc  (Function)::sLaborJobList  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }


        //COMPANY CMB BOX 
        public string sLaborCompanyList(string pSiteCd, string pAuthCd, string pCoCd, out List<DataComCombo> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizLaborSearch bizSys = null;
            try
            {
                bizSys = new BizLaborSearch();

                try
                {
                    ds = bizSys.sLaborCompanyList(pSiteCd, pAuthCd, pCoCd);

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

            List<DataComCombo> data = new List<DataComCombo>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataComCombo>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsWorkerLaborSearch.svc  (Function)::sLaborCompanyList  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }




        //COMPANY CMB BOX 
        public string sLaborTeamList(string pSiteCd, string pAuthCd, string pTeamCd, string pCoCd, out List<DataComCombo> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizLaborSearch bizSys = null;
            try
            {
                bizSys = new BizLaborSearch();

                try
                {
                    ds = bizSys.sLaborTeamList(pSiteCd, pAuthCd, pTeamCd, pCoCd);

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

            List<DataComCombo> data = new List<DataComCombo>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataComCombo>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsWorkerLaborSearch.svc  (Function)::sLaborTeamList  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }


        //SELECT 
        public string sLaborSearch(string pSiteCd, string pBlockCcd, string pConstCcd, string pCoCd, string pTeamCd, string pSearchCondition, string pSearchTxt, out List<DataLaborSearch> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizLaborSearch bizSys = null;
            try
            {
                bizSys = new BizLaborSearch();

                try
                {
                    ds = bizSys.sLaborSearch(pSiteCd, pBlockCcd, pConstCcd, pCoCd, pTeamCd, pSearchCondition, pSearchTxt);

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

            List<DataLaborSearch> data = new List<DataLaborSearch>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataLaborSearch>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsDevice.svc  (Function)::sDevice  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }
    }
}