using EldigmPlusApp.Config;
using Framework.Log;
using System;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Threading;
using System.Windows.Forms;

namespace EldigmPlusApp.SubForm.Sys.SysCode
{
    public partial class FrmSysCodeGrp : Form
    {
        LogUtil logs = null;
        ResourceManager lngRM = null;
        ResourceManager msgRM = null;

        public FrmSysCodeGrp()
        {
            // Sets the UI culture
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(AppInfo.SsLanguage);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;

            InitializeComponent();

            try
            {
                logs = new LogUtil();
                lngRM = new ResourceManager("EldigmPlusApp.strLanguage", typeof(FrmSysCodeGrp).Assembly);
                msgRM = new ResourceManager("EldigmPlusApp.msgLanguage", typeof(FrmSysCodeGrp).Assembly);

                btnSave.Text = "저장";

                dataGridView1.Columns["CODE_NM1"].HeaderText = "*이름1";
                dataGridView1.Columns["CODE_NM2"].HeaderText = "이름2";
                dataGridView1.Columns["USE_YN"].HeaderText = "사용";
                dataGridView1.Columns["ADMIN_YN"].HeaderText = "관리자";
                dataGridView1.Columns["SORT_NO"].HeaderText = "정렬";

                dataGridView1.Columns["CODE_NM1"].HeaderCell.Style.ForeColor = Color.Maroon; // 헤더 필수 항목 빨강색

                Control.CheckForIllegalCrossThreadCalls = false;

                this.BackColor = Color.WhiteSmoke;

                splitContainer1.Panel1.BackColor = Color.LightSteelBlue;

                EldigmPlusApp.Class.Common.DatagrideViewStyleSet dvSet = new Class.Common.DatagrideViewStyleSet();
                dvSet.setStyle(dataGridView1, false, false);

                lblName.BackColor = Color.FromArgb(204, 219, 243);
                this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.paint_Purple1);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmSysCodeGrp  (Function)::FrmSysCodeGrp  (Detail):: " + "\r\n" + ex.ToString());
            }
        }

        #region __ panel2 paint_Purple1
        private void paint_Purple1(object sender, PaintEventArgs e)
        {
            EldigmPlusApp.Class.UI.PanelPaint pp = new Class.UI.PanelPaint();
            pp.paint_PanelPurple1(sender, e);
        }
        #endregion

        private void FrmSysCodeGrp_Load(object sender, EventArgs e)
        {
            try
            {
                setDataBind_treeView1();
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmSysCodeGrp  (Function)::Form_Load  (Detail):: " + "\r\n" + ex.ToString());
            }
        }


        private void setDataBind_treeView1()
        {
            treeView1.Nodes.Clear();

            //WsMHome.WsMainHomeClient wsMHome = null;
            //string reCode = "";
            //string reMsg = "";
            //WsMHome.DataTopMenu[] getData = null;
            


            WsMHome.WsMainHomeClient wsMHome = null;
            string reCode = "";
            string reMsg = "";
            WsMHome.DataTopMenu[] getData = null;
            try
            {
                wsMHome = new WsMHome.WsMainHomeClient();
                string wsUrl = "http://localhost:49501/WebSvc/Sys/SysCode/WsSysCode.svc";
                wsMHome.Endpoint.Address = new System.ServiceModel.EndpointAddress(wsUrl);
                wsMHome.Open();

                ImageList myimageList = new ImageList();
                myimageList.Images.Add(Image.FromFile(@"Image\treeicon1.png"));

                treeView1.ImageList = myimageList;
                treeView1.ImageIndex = 0;

                TreeNode root = new TreeNode();
                root.Text = "전체";
                root.Tag = "";

                reCode = wsMHome.sSiteMenu(AppInfo.SsDbNm, AppInfo.SsSiteCd, out getData, out reMsg);
                if (reCode == "Y")
                {
                    if (getData != null && getData.Length > 0)
                    {
                        for (int i = 0; i < getData.Length; i++)
                        {
                            string code_grp = getData[i].TOP_MENU_CD.ToString();
                            string code_nm1 = getData[i].TOP_MENU_CD.ToString();
                            string code_nm2 = getData[i].TOP_MENU_CD.ToString();

                            //string code_nm = code_nm1;
                            string code_nm = code_nm1;

                            TreeNode node1 = new TreeNode();
                            node1.Text = code_nm;
                            node1.Tag = code_grp;

                            root.Nodes.Add(node1);
                        }

                        treeView1.Nodes.Add(root);

                        if (treeView1.Nodes.Count > 0)
                            treeView1.SelectedNode = treeView1.GetNodeAt(0, 0);

                        treeView1.ExpandAll();
                    }
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmSysCodeGrp  (Function)::setDataBind_treeView1  (Detail):: " + "\r\n" + ex.ToString());
            }
            finally
            {
                if (wsMHome != null)
                    wsMHome.Close();
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
