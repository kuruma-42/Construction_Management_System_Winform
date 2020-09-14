using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldigmPlusApp.Config
{
    class AppInfo
    {
        static string nnDbNm;

        static string nnLanguage;
        static string nnMemcoCd;
        static string nnSiteCd;

        public static string SsDbNm
        {
            get { return nnDbNm; }
            set { nnDbNm = value; }
        }



        public static string SsLanguage
        {
            get { return nnLanguage; }
            set { nnLanguage = value; }
        }
        public static string SsMemcoCd
        {
            get { return nnMemcoCd; }
            set { nnMemcoCd = value; }
        }
        public static string SsSiteCd
        {
            get { return nnSiteCd; }
            set { nnSiteCd = value; }
        }
    }
}
