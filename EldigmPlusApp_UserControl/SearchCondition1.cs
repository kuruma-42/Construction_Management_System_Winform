using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EldigmPlusApp_UserControl
{
    public partial class SearchCondition1 : UserControl
    {
        public SearchCondition1()
        {
            InitializeComponent();
        }

        [Description("업체 콤보 데이터 변경 시"), Category("UserControlProperty")]
        public event EventHandler cmb3_SelectedIndexChanged;


        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cmb3_SelectedIndexChanged?.Invoke(this, e);
        }
    }
}
