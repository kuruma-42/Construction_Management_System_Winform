using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EldigmPlusApp.Class.Common
{
    class DatagrideViewStyleSet
    {
        public void setStyle(DataGridView dataGridView1, bool multiSelect, bool fullRowSelect)
        {
            dataGridView1.BackgroundColor = Color.White;

            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.LightSteelBlue;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSteelBlue;

            dataGridView1.MultiSelect = multiSelect;    // 여러줄 동시 선택

            if (fullRowSelect)
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;    // 한줄 전체 선택

            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

            dataGridView1.ColumnHeadersHeight = 29;

            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;

            dataGridView1.EnableHeadersVisualStyles = false;    // 헤더 색상 변경 가능토록

            //dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.PowderBlue;

            //dataGridView1.Columns[2].HeaderCell.Style.ForeColor = Color.Maroon; // 헤더 필수 항목 빨강색
        }
    }
}
