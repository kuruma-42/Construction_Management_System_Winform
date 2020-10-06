using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace EldigmPlusSvc_Main.Biz.Common
{
    public class ListClass
    {
        public static List<T> ConvertDataTableToList<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                    {
                        pro.SetValue(obj, dr[column.ColumnName], null);
                        break;
                    }
                }
            }
            return obj;
        }

        /// <summary>
        /// 현재 QueryResult값을 List 형태로 리턴한다.
        /// 각 데이타는 Dictionary의 List형태로 가지고 있으며,
        /// 각 Dictionary의 key는 column 명, value는 현재순서의 row 값을 가지고 있다.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> DataTableToArrayList(DataTable dt)
        {
            List<Dictionary<string, object>> result = new List<Dictionary<string, object>>();

            int columnCount = dt.Columns.Count;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow queryRow = dt.Rows[i];
                Dictionary<string, object> dic = new Dictionary<string, object>();
                for (int cols = 0; cols < columnCount; cols++)
                {
                    dic.Add(dt.Columns[cols].ColumnName, queryRow[dt.Columns[cols].ColumnName]);
                }
                result.Add(dic);
            }
            return result;
        }
    }
}