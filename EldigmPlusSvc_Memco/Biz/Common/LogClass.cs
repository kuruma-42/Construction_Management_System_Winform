using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace EldigmPlusSvc_Memco.Biz.Common
{
    public class LogClass
    {
        //저장하고 싶은 로그를 파일로 저장한다.
        public void SaveLog(string msg, string folderNm)
        {
            try
            {
                //string foldernm = HostingEnvironment.MapPath("/EldigmPlus") + "\\Logs\\" + folderNm + "\\";
                string foldernm = "D:\\Logs\\EldigmPlusSvc_Memco\\" + folderNm + "\\";

                if (!Directory.Exists(foldernm))
                    Directory.CreateDirectory(foldernm);

                // 파일에 로그를 남긴다.
                string strFilename = foldernm + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";

                // 저장할때 사용한 스트림의 인스턴스
                StreamWriter sw;

                // 파일이 존재하지 않으면 만든다.
                if (File.Exists(strFilename))
                {
                    // 이미 존재한다면 추가한다.
                    sw = File.AppendText(strFilename);
                }
                else
                {
                    // 없을 경우 생성한다.
                    sw = File.CreateText(strFilename);
                }

                // 로그파일에 기록한다.
                sw.WriteLine(DateTime.Now.ToString() + " || " + msg);

                // 스트림을 종료한다.
                sw.Close();
            }
            catch (Exception ex)
            {
                SaveLog(ex.ToString(), folderNm);
            }
            finally
            {

            }
        }
    }
}