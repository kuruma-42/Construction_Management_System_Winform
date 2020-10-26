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
    public partial class SearchCondition2 : UserControl
    {
        public SearchCondition2()
        {
            InitializeComponent();
        }

        [Description("Search 클릭 시"), Category("UserControlProperty")]
        public event EventHandler btnSearchClick;

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.btnSearchClick?.Invoke(this, e);
        }
    }
}
