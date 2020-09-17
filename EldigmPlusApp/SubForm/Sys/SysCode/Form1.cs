using EldigmPlusApp.Config;
using Framework.Log;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EldigmPlusApp.SubForm.Sys.SysCode
{
    public partial class Form1 : Form
    {
        LogUtil logs = null;
        ResourceManager lngRM = null;
        ResourceManager msgRM = null;

        string scodeGrp = "";

        public Form1()
        {
            // Sets the UI culture
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(AppInfo.SsLanguage);
            this.AutoScaleMode = AutoScaleMode.Dpi;

            InitializeComponent();

            try
            {
                logs = new LogUtil();
                lngRM = new ResourceManager("EldigmPlusApp.strLanguage", typeof(FrmSysCodeGrp).Assembly);
                msgRM = new ResourceManager("EldigmPlusApp.msgLanguage", typeof(FrmSysCodeGrp).Assembly);

                btnSave.Text = "저장";

                dataGridView1.Columns["dgv1_CHK"].HeaderText = "선택";
                dataGridView1.Columns["dgv1_SCODE_NM"].HeaderText = "*이름";
                dataGridView1.Columns["dgv1_USING_FLAG"].HeaderText = "사용";
                dataGridView1.Columns["dgv1_SORT_NO"].HeaderText = "정렬";
                dataGridView1.Columns["dgv1_MEMO"].HeaderText = "메모";

                dataGridView1.Columns["dgv1_SCODE_NM"].HeaderCell.Style.ForeColor = Color.Maroon; // 헤더 필수 항목 빨강색

                Control.CheckForIllegalCrossThreadCalls = false;

                this.BackColor = Color.WhiteSmoke;

                splitContainer1.Panel1.BackColor = Color.LightSteelBlue;

                Class.Common.DatagrideViewStyleSet dvSet = new Class.Common.DatagrideViewStyleSet();
                dvSet.setStyle(dataGridView1, false, false);

                lblName.BackColor = Color.FromArgb(204, 219, 243);
                this.panel2.Paint += new PaintEventHandler(this.paint_Purple1);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmSysCodeGrp.cs  (Function)::FrmSysCodeGrp  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        #region __ panel2 paint_Purple1
        private void paint_Purple1(object sender, PaintEventArgs e)
        {
            Class.UI.PanelPaint pp = new Class.UI.PanelPaint();
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
                logs.SaveLog("[error]  (page)::FrmSysCodeGrp.cs  (Function)::Form_Load  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }


        private void setDataBind_treeView1()
        {
            treeView1.Nodes.Clear();

            WsSCodeGrpPra.WsSysCodeGrpPra pwSvc = null;
            string reCode = "";
            string reMsg = "";
            WsSCodeGrpPra.DataSysCodeGrpPra[] getData = null;

            
            try
            {
                pwSvc = new WsSCodeGrpPra.WsSysCodeGrpPra();
                pwSvc.Url = "http://" + AppInfo.SsServer + "/WebSvc/Sys/SysCode/WsSysCodeGrpPra.svc";
                pwSvc.Timeout = 1000;

                ImageList myimageList = new ImageList();
                myimageList.Images.Add(Image.FromFile(@"Image\treeicon1.png"));

                treeView1.ImageList = myimageList;
                treeView1.ImageIndex = 0;

                TreeNode root = new TreeNode();
                root.Tag = "";
                root.Text = "전체";

                reCode = pwSvc.psSysCodeGrp("", out getData, out reMsg);
                if (reCode == "Y")
                {
                    if (getData != null && getData.Length > 0)
                    {
                        for (int i = 0; i < getData.Length; i++)
                        {
                            string scodeGrp_val = getData[i].SCODE_GRP.ToString();
                            string scodeNm_val = getData[i].SCODE_NM.ToString();

                            TreeNode node1 = new TreeNode();
                            node1.Tag = scodeGrp_val;
                            node1.Text = scodeNm_val;

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
                logs.SaveLog("[error]  (page)::FrmSysCodeGrp.cs  (Function)::setDataBind_treeView1  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (pwSvc != null)
                    pwSvc.Dispose();
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (treeView1.SelectedNode == null)
                {
                    return;
                }

                scodeGrp = e.Node.Tag.ToString();
                lblName.Text = "** " + e.Node.Text;

                setDataBind_grideView1(scodeGrp);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmSysCodeGrp.cs  (Function)::treeView1_AfterSelect  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            setDataBind_treeView1();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            treeView1.CollapseAll();
        }

        private void setDataBind_grideView1(string pScodeGrp)
        {
            WsSCodeGrpPra.WsSysCodeGrpPra pwSvc = null;
            string reCode = "";
            string reMsg = "";
            WsSCodeGrpPra.DataSysCodeGrpPra[] getData = null;
            try
            {
                pwSvc = new WsSCodeGrpPra.WsSysCodeGrpPra();
                pwSvc.Url = "http://" + AppInfo.SsServer + "/WebSvc/Sys/SysCode/WsSysCodeGrpPra.svc";
                pwSvc.Timeout = 1000;

                reCode = pwSvc.psSysCodeGrp(pScodeGrp, out getData, out reMsg);

                //dataGridView1.DataSource = getData;
                if (reCode == "Y")
                {
                    if (getData != null && getData.Length > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int i = 0; i < getData.Length; i++)
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[i].Cells["dgv1_CHK"].Value = "0";
                            dataGridView1.Rows[i].Cells["dgv1_SCODE_GRP"].Value = getData[i].SCODE_GRP.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_SCODE_NM"].Value = getData[i].SCODE_NM.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_USING_FLAG"].Value = getData[i].USING_FLAG.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_SORT_NO"].Value = getData[i].SORT_NO.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_MEMO"].Value = getData[i].MEMO.ToString();
                        }

                        setRowNumber(dataGridView1);
                    }
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmSysCodeGrp.cs  (Function)::setDataBind_grideView1  (Detail)::pScodeGrp=[" + pScodeGrp + "]", "Error");
                logs.SaveLog("[error]  (page)::FrmSysCodeGrp.cs  (Function)::setDataBind_grideView1  (Detail)::reMsg=[" + reMsg + "]", "Error");
                logs.SaveLog("[error]  (page)::FrmSysCodeGrp.cs  (Function)::setDataBind_grideView1  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (pwSvc != null)
                    pwSvc.Dispose();
            }
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                string colName = dataGridView1.Columns[e.ColumnIndex].Name;
                if (colName != "dgv1_CHK")
                    dataGridView1.Rows[e.RowIndex].Cells["dgv1_CHK"].Value = "1";
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmSysCodeGrp.cs  (Function)::dataGridView1_CellBeginEdit  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        bool chkUseAll = false;
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                string columnNm = dataGridView1.Columns[e.ColumnIndex].Name;
                if (columnNm == "dgv1_CHK" || columnNm == "dgv1_USING_FLAG")
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (chkUseAll)
                            dataGridView1.Rows[i].Cells[columnNm].Value = "0";
                        else
                            dataGridView1.Rows[i].Cells[columnNm].Value = "1";

                        if (columnNm == "dgv1_USING_FLAG")
                            dataGridView1.Rows[i].Cells["dgv1_CHK"].Value = "1";
                    }

                    if (chkUseAll)
                        chkUseAll = false;
                    else
                        chkUseAll = true;

                }
                else
                    setRowNumber(dataGridView1);

                NoSelectGrideView(dataGridView1);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmSysCodeGrp.cs  (Function)::dataGridView1_ColumnHeaderMouseClick  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        // dataGridView 선택값 없애기
        private void NoSelectGrideView(DataGridView dgv)
        {
            dgv.ClearSelection();
            dgv.CurrentCell = null;
        }

        private void setRowNumber(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
                row.HeaderCell.Value = String.Format("{0}", row.Index + 1);

            dgv.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            setRowNumber(dataGridView1);
        }

       

        private void btnSave_Click(object sender, EventArgs e)
        {
            WsSCodeGrpPra.WsSysCodeGrpPra pwSvc = null;
            string reCode = "";
            string reMsg = "";
            try
            {
                pwSvc = new WsSCodeGrpPra.WsSysCodeGrpPra();
                pwSvc.Url = "http://" + AppInfo.SsServer + "/WebSvc/Sys/SysCode/WsSysCodeGrpPra.svc";
                pwSvc.Timeout = 1000;

                int reCnt = 0;

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells["dgv1_CHK"].Value != null)
                    {
                        if (dataGridView1.Rows[i].Cells["dgv1_CHK"].Value.ToString() == "1")
                        {
                            string scodeGrp_val = dataGridView1.Rows[i].Cells["dgv1_SCODE_GRP"].Value.ToString();
                            string scodeNm_val = dataGridView1.Rows[i].Cells["dgv1_SCODE_NM"].Value.ToString();
                            string usingFlag_val = dataGridView1.Rows[i].Cells["dgv1_USING_FLAG"].Value.ToString();
                            string sortNo_val = dataGridView1.Rows[i].Cells["dgv1_SORT_NO"].Value.ToString();
                            string memo_val = dataGridView1.Rows[i].Cells["dgv1_MEMO"].Value.ToString();

                            reCode = pwSvc.pmSysCodeGrp(scodeGrp_val, scodeNm_val, usingFlag_val, sortNo_val, memo_val, out reMsg);

                            if (reCode == "Y")
                                reCnt++;
                        }
                    }
                }

                if (reCnt > 0)
                {
                    MessageBox.Show("저장 성공" + " : " + reCnt.ToString());
                }
                else
                {
                    MessageBox.Show("저장 실패");
                }

                setDataBind_grideView1(scodeGrp);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmSysCodeGrp.cs  (Function)::btnSave_Click  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (pwSvc != null)
                    pwSvc.Dispose();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    }
    
