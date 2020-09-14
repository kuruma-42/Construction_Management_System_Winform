using EldigmPlusClassLibrary.DbClass.Sys.SysCode;
using EldigmPlusSvc_Memco.Biz.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EldigmPlusSvc_Memco.Biz.Sys.SysCode
{
    public class BizSysSysCode
    {
        LogClass logs = new LogClass();

        public string sDbNm(string pMemcoCd)
        {
            string reVal = "";

             DbSysSysCode db = null;
            try
            {
                db = new DbSysSysCode();
                reVal = db.sDbNm(pMemcoCd);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizSystem.cs  (Function)::sSiteMenu  (Detail)::pMemcoCd=[" + pMemcoCd + "]", "Error");
                logs.SaveLog("[error]  (page)::BizSystem.cs  (Function)::sSiteMenu  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return reVal;
        }

        public DataSet sSysCodeGrp()
        {
            DataSet ds = null;

            DbSysSysCode db = null;
            try
            {
                db = new DbSysSysCode();
                ds = db.sSysCodeGrp();
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::BizSystem.cs  (Function)::sSiteMenu  (Detail)::pDbNm=[" + "PLUS_MAIN" + "], pSiteCd=[" + "MAIN_CODE_SYS_GRP" + "]", "Error");
                logs.SaveLog("[error]  (page)::BizSystem.cs  (Function)::sSiteMenu  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (db != null)
                    db.DisConnect();
            }

            return ds;
        }
    }
}