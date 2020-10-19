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



        //DEVICE TYPE CMB BOX
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


        //SELECT 
        public string sLaborSearch(string pSiteCd, string pCoCd, out List<DataLaborSearch> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizLaborSearch bizSys = null;
            try
            {
                bizSys = new BizLaborSearch();

                try
                {
                    ds = bizSys.sLaborSearch(pSiteCd, pCoCd);

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











        //DEVICE TYPE CMB BOX
        public string devTypeCmb(out List<DataDevCombo> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizDevice bizSys = null;
            try
            {
                bizSys = new BizDevice();

                try
                {
                    ds = bizSys.devTypeCmb();

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

            List<DataDevCombo> data = new List<DataDevCombo>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataDevCombo>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsDevice.svc  (Function)::devTypeCmb  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }

        //DEVICE I/O CMB BOX
        public string devIOCmb(out List<DataDevCombo> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizDevice bizSys = null;
            try
            {
                bizSys = new BizDevice();

                try
                {
                    ds = bizSys.devIOCmb();

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

            List<DataDevCombo> data = new List<DataDevCombo>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataDevCombo>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::WsSysCompanyTeam.svc  (Function)::cotype_Cmb2  (Detail)::ConvertDataTableToList " + "\r\n" + ex.ToString(), "Error");
                reMsg += "/[List 에러]" + ex.ToString();
                reCode = "N";
            }

            reList = data;

            return reCode;
        }


        //SELECT 
        public string sDevice(string pDbNm, string pSiteCd, out List<DataDevice> reList, out string reMsg)
        {
            string reCode = "N";

            DataSet ds = null;
            BizDevice bizSys = null;
            try
            {
                bizSys = new BizDevice();

                try
                {
                    ds = bizSys.sDevice(pDbNm, pSiteCd);

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

            List<DataDevice> data = new List<DataDevice>();
            try
            {
                data = ListClass.ConvertDataTableToList<DataDevice>(ds.Tables[0]);
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



        //MODIFY
        public string mDevice(string pDbNm, string pSiteCd, string pDevCd, string pDeviceId, string pDevTypeScd, string pDevIOScd, string pDevNm, string pIp, string pSortNo, string pUsingFalg, string pMemo, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "0";

            BizDevice bizSys = null;
            try
            {
                bizSys = new BizDevice();

                int reCnt = bizSys.mDevice(pDbNm, pSiteCd, pDevCd, pDeviceId, pDevTypeScd, pDevIOScd, pDevNm, pIp, pSortNo, pUsingFalg, pMemo);

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
                logs.SaveLog("[error]  (page)::WsDevice.svc  (Function)::mDevice  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }

        //INSERT WITH PROCEDURE
        public string aDevicePro(string pDbNm, string[] param, out string reData, out string reMsg)
        {
            string reCode = "N";

            string reVal = "";
            BizDevice bizSys = null;
            try
            {
                bizSys = new BizDevice();

                try
                {
                    Hashtable hParam = new Hashtable();
                    hParam.Add("pSiteCd", Convert.ToInt32(param[0]));
                    hParam.Add("pDeviceId", Convert.ToInt32(param[1]));
                    hParam.Add("pDevTypeScd", param[2].ToString());
                    hParam.Add("pDevIOScd", param[3].ToString());
                    hParam.Add("pDevNm", param[4].ToString());
                    hParam.Add("pIp", param[5].ToString());
                    hParam.Add("pUsingFlag", Convert.ToInt32(param[6]));
                    hParam.Add("pSortNo", Convert.ToInt32(param[7]));
                    hParam.Add("pMemo", param[8].ToString());
                    hParam.Add("pUserId", Convert.ToInt32(param[9]));

                    hParam.Add("@rtnDevCd", "");

                    reVal = bizSys.aDevicePro(pDbNm, hParam, out Hashtable outVal);

                    if (outVal != null)
                    {
                        foreach (DictionaryEntry dictionaryEntry in outVal)
                        {
                            string[] row = new string[] { dictionaryEntry.Key.ToString(), dictionaryEntry.Value.ToString(), "" };
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


        //LOG
        public string logDevice(string pDbNm, string pDevCd, string pSiteCd, string pDeviceId, string pDevTypeScd, string pDevIOScd, string pDevNm, string pIp, string pUsingFalg, string pSortNo, string pMemo, string pInputId, out string reMsg, out string reData)
        {
            string reCode = "N";
            reData = "";

            BizDevice bizSys = null;
            try
            {
                bizSys = new BizDevice();

                int reCnt = bizSys.logDevice(pDbNm, pDevCd, pSiteCd, pDeviceId, pDevTypeScd, pDevIOScd, pDevNm, pIp, pUsingFalg, pSortNo, pMemo, pInputId);

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
                logs.SaveLog("[error]  (page)::WsDevice.svc  (Function)::logDevice  (Detail)::" + "\r\n" + ex.ToString(), "Error");
                reMsg = "[저장 에러] :: " + ex.ToString();
                reCode = "N";
            }

            return reCode;
        }


    }
}