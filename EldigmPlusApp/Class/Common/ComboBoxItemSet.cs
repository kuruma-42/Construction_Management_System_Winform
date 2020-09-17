using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldigmPlusApp.Class.Common
{
    class ComboBoxItemSet
    {
        DataTable dt = new DataTable();

        public void AddColumn()
        {
            dt.Columns.Add("text");
            dt.Columns.Add("value");
        }

        public void AddRow(string text, string value)
        {
            DataRow dr = dt.NewRow();

            dr["text"] = text;
            dr["value"] = value;

            dt.Rows.Add(dr);
        }

        public void Bind(System.Windows.Forms.ComboBox comboBox)
        {
            if (dt.Rows.Count < 1) return; // 값이 없으면 바인딩할 필요가 없다.


            comboBox.DisplayMember = "text";
            comboBox.ValueMember = "value";

            comboBox.DataSource = dt;

        }

        public DataTable GetDataTable()
        {
            return dt;
        }
    }
}
