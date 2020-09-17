using EldigmPlusClassLibrary.DbClass.Sys.SysCode;
using EldigmPlusSvc_Memco.Biz.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EldigmPlusSvc_Memco.Biz.Sys.SysCode
{
    public class BizSysCodeGrpPra
    {
        LogClass logs = new LogClass();

        public DataSet psSysCodeGrp(string pScodeGrp)
        {
            DataSet ds = null;

            DbPractice db = null;
            try
            {
                db = new DbPractice();
                ds = db.psSysCodeGrp(pScodeGrp);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizSysCodeGrp.cs  (Function)::sSysCodeGrp  (Detail)::pScodeGrp=[" + pScodeGrp + "]", "Error");
                logs.SaveLog("[error]  (page)::BizSysCodeGrp.cs  (Function)::sSysCodeGrp  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }

        public int pmSysCodeGrp(string pScodeGrp, string pScodeNm, string pUsingFlag, string pSortNo, string pMemo)
        {
            int reCnt = 0;

            DbPractice db = null;
            try
            {
                db = new DbPractice();
                reCnt = db.pmSysCodeGrp(pScodeGrp, pScodeNm, pUsingFlag, pSortNo, pMemo);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizSysCodeGrp.cs  (Function)::mSysCodeGrp  (Detail)::pScodeGrp=[" + pScodeGrp + "], pScodeNm=[" + pScodeNm + "], pUsingFlag=[" + pUsingFlag + "]" +
                    ", pSortNo=[" + pSortNo + "], pMemo=[" + pMemo + "]", "Error");
                logs.SaveLog("[error]  (page)::BizSysCodeGrp.cs  (Function)::mSysCodeGrp  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reCnt;
        }



    }
}