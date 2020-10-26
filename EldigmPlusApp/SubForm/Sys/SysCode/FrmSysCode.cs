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
    public partial class FrmSysCode : Form
    {
        LogUtil logs = null;
        ResourceManager wRM = null;
        ResourceManager msgRM = null;

        string _scodeGrp = "";

        public FrmSysCode()
        {
            // Sets the UI culture
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(AppInfo.SsLanguage);
            this.AutoScaleMode = AutoScaleMode.Dpi;

            InitializeComponent();

            try
            {
                logs = new LogUtil();
                wRM = new ResourceManager("EldigmPlusApp.GlobalLanguage.word_Language", typeof(FrmSysCode).Assembly);
                msgRM = new ResourceManager("EldigmPlusApp.GlobalLanguage.msg_Language", typeof(FrmSysCode).Assembly);

                btnSearch.Text = wRM.GetString("wSearch");
                btnSave.Text = wRM.GetString("wSave");

                dataGridView1.Columns["dgv1_CHK"].HeaderText = wRM.GetString("wSelect");
                dataGridView1.Columns["dgv1_SCODE"].HeaderText = wRM.GetString("wCode");
                dataGridView1.Columns["dgv1_SCODE_NM"].HeaderText = wRM.GetString("wName");
                dataGridView1.Columns["dgv1_USING_FLAG"].HeaderText = wRM.GetString("wUse");
                dataGridView1.Columns["dgv1_SORT_NO"].HeaderText = wRM.GetString("wSort");
                dataGridView1.Columns["dgv1_MEMO"].HeaderText = wRM.GetString("wMemo");

                dataGridView2.Columns["dgv2_SCODE"].HeaderText = "*" + wRM.GetString("wCode");
                dataGridView2.Columns["dgv2_SCODE_NM"].HeaderText = "*" + wRM.GetString("wName");
                dataGridView2.Columns["dgv2_SORT_NO"].HeaderText = wRM.GetString("wSort");
                dataGridView2.Columns["dgv2_MEMO"].HeaderText = wRM.GetString("wMemo");

                dataGridView2.Columns["dgv2_SCODE"].HeaderCell.Style.ForeColor = Color.Maroon; // 헤더 필수 항목 빨강색
                dataGridView2.Columns["dgv2_SCODE_NM"].HeaderCell.Style.ForeColor = Color.Maroon; // 헤더 필수 항목 빨강색

                Control.CheckForIllegalCrossThreadCalls = false;

                this.BackColor = Color.WhiteSmoke;

                splitContainer1.Panel1.BackColor = Color.LightSteelBlue;

                Class.Common.DatagrideViewStyleSet dvSet = new Class.Common.DatagrideViewStyleSet();
                dvSet.setStyle(dataGridView1, false, false);
                dvSet.setStyle(dataGridView2, false, false);

                lblName.BackColor = Color.FromArgb(204, 219, 243);
                this.panel2.Paint += new PaintEventHandler(this.paint_Purple1);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmSysCode.cs  (Function)::FrmSysCode  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        #region __ panel2 paint_Purple1
        private void paint_Purple1(object sender, PaintEventArgs e)
        {
            Class.UI.PanelPaint pp = new Class.UI.PanelPaint();
            pp.paint_PanelPurple1(sender, e);
        }
        #endregion

        private void FrmSysCode_Load(object sender, EventArgs e)
        {
            try
            {
                SetDataBind_Combo();

                SetDataBind_treeView1();
                SetDataBind_grideView2();
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmSysCode.cs  (Function)::Form_Load  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        private void SetDataBind_Combo()
        {
            try
            {
                Class.Common.ComboBoxItemSet setCmb = null;

                setCmb = new Class.Common.ComboBoxItemSet();

                setCmb.AddColumn();

                setCmb.AddRow(wRM.GetString("wUse"), "1");
                setCmb.AddRow(wRM.GetString("wNotUsing"), "0");
                setCmb.AddRow(wRM.GetString("wTotal"), "");

                setCmb.Bind(cmbUse);

            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmSysCode.cs  (Function)::setDataBind_Combo  (Detail):: " + "\r\n" + ex.ToString());
            }

        }

        private void SetDataBind_treeView1()
        {
            treeView1.Nodes.Clear();

            M_WsSysCodeGrp.WsSysCodeGrp wSvc = null;
            string reCode = "";
            string reMsg = "";
            M_WsSysCodeGrp.DataSysCodeGrp[] getData = null;
            try
            {
                wSvc = new M_WsSysCodeGrp.WsSysCodeGrp();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/SysCode/WsSysCodeGrp.svc";
                wSvc.Timeout = 1000;

                ImageList myimageList = new ImageList();
                myimageList.Images.Add(Image.FromFile(@"Image\treeicon1.png"));

                treeView1.ImageList = myimageList;
                treeView1.ImageIndex = 0;

                //TreeNode root = new TreeNode();
                //root.Tag = "";
                //root.Text = "전체";

                reCode = wSvc.sSysCodeGrp_UsingFlag("1", out getData, out reMsg);
                if (reCode == "Y")
                {
                    if (getData != null && getData.Length > 0)
                    {
                        for (int i = 0; i < getData.Length; i++)
                        {
                            string scodeGrp_val = getData[i].SCODE_GRP.ToString();
                            string scodeNm_val = getData[i].SCODE_GRP_NM.ToString();

                            TreeNode node1 = new TreeNode();
                            node1.Tag = scodeGrp_val;
                            node1.Text = scodeNm_val;

                            treeView1.Nodes.Add(node1);
                        }

                        //treeView1.Nodes.Add();

                        if (treeView1.Nodes.Count > 0)
                            treeView1.SelectedNode = treeView1.GetNodeAt(0, 0);

                        treeView1.ExpandAll();
                    }
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmSysCode.cs  (Function)::setDataBind_treeView1  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (wSvc != null)
                    wSvc.Dispose();
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

                _scodeGrp = e.Node.Tag.ToString();
                lblName.Text = "** " + e.Node.Text;

                SetDataBind_gridView1(_scodeGrp);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmSysCode.cs  (Function)::treeView1_AfterSelect  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        private void SetDataBind_gridView1(string pScodeGrp)
        {
            if (_scodeGrp == "")
                return;

            string searchTxt_val = "";
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                searchTxt_val = txtSearch.Text;
            }

            M_WsSysCodeGrp.WsSysCodeGrp wSvc = null;
            string reCode = "";
            string reMsg = "";
            M_WsSysCodeGrp.DataSysCode[] getData = null;
            try
            {
                wSvc = new M_WsSysCodeGrp.WsSysCodeGrp(); // 시스템 코드 보여주기 
                wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/SysCode/WsSysCodeGrp.svc";
                wSvc.Timeout = 1000;

                reCode = wSvc.sSysCode(_scodeGrp, cmbUse.SelectedValue.ToString(), searchTxt_val, out getData, out reMsg);

                if (reCode == "Y")
                {
                    if (getData != null && getData.Length > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int i = 0; i < getData.Length; i++)
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[i].Cells["dgv1_CHK"].Value = "0";
                            dataGridView1.Rows[i].Cells["dgv1_SCODE"].Value = getData[i].SCODE.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_SCODE_NM"].Value = getData[i].SCODE_NM.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_USING_FLAG"].Value = getData[i].USING_FLAG.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_SORT_NO"].Value = getData[i].SORT_NO.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_MEMO"].Value = getData[i].MEMO.ToString();
                        }

                        SetRowNumber(dataGridView1);
                    }
                    else
                    {
                        dataGridView1.Rows.Clear();
                        //MessageBox.Show("데이터가 없습니다");
                    }
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmSysCode.cs  (Function)::SetDataBind_gridView1  (Detail)::pScodeGrp=[" + pScodeGrp + "]", "Error");
                logs.SaveLog("[error]  (page)::FrmSysCode.cs  (Function)::SetDataBind_gridView1  (Detail)::reMsg=[" + reMsg + "]", "Error");
                logs.SaveLog("[error]  (page)::FrmSysCode.cs  (Function)::SetDataBind_gridView1  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (wSvc != null)
                    wSvc.Dispose();
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
                logs.SaveLog("[error]  (page)::FrmSysCode.cs  (Function)::dataGridView1_CellBeginEdit  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
                    SetRowNumber(dataGridView1);

                NoSelectGrideView(dataGridView1);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmSysCode.cs  (Function)::dataGridView1_ColumnHeaderMouseClick  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SetRowNumber(dataGridView1);
        }

        private void SetDataBind_grideView2()
        {
            try
            {
                dataGridView2.Rows.Clear();
                dataGridView2.Rows.Add();
                dataGridView2.Rows[0].Cells["dgv2_SORT_NO"].Value = "10";
                dataGridView2.Rows[0].Cells["dgv2_BTNADD"].Value = wRM.GetString("wAdd");
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmSysCode.cs  (Function)::SetDataBind_grideView2  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string colNm = dataGridView2.Columns[e.ColumnIndex].Name;

            if (colNm == "dgv2_BTNADD")
            {
                string reVal = ChkDgv2Param();

                if (reVal != "")
                    MessageBox.Show(wRM.GetString("wCheck") + " :: " + reVal);
                else
                {
                    string scode_val = dataGridView2.Rows[0].Cells["dgv2_SCODE"].Value.ToString();
                    string scodeNm_val = dataGridView2.Rows[0].Cells["dgv2_SCODE_NM"].Value.ToString();

                    string sortNo_val = "1";
                    if (dataGridView2.Rows[0].Cells["dgv2_SORT_NO"].Value != null)
                        sortNo_val = dataGridView2.Rows[0].Cells["dgv2_SORT_NO"].Value.ToString();

                    string memo_val = "";
                    if (dataGridView2.Rows[0].Cells["dgv2_MEMO"].Value != null)
                        memo_val = dataGridView2.Rows[0].Cells["dgv2_MEMO"].Value.ToString();

                    string pInputId = "1";

                    M_WsSysCodeGrp.WsSysCodeGrp wSvc = null;
                    string reCode = "";
                    string reMsg = "";
                    string reData = "";
                    try
                    {
                        wSvc = new M_WsSysCodeGrp.WsSysCodeGrp();
                        wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/SysCode/WsSysCodeGrp.svc";
                        wSvc.Timeout = 1000;

                        int reCnt = 0;

                        reCode = wSvc.exSysCode(scode_val, out reMsg, out reData);
                        if (reCode == "Y" && reData != "0")
                        {
                            MessageBox.Show(msgRM.GetString("msgDuplicated"));
                        }
                        else
                        {
                            reCode = "";
                            reCode = wSvc.aSysCode(scode_val, _scodeGrp, scodeNm_val, "1", memo_val, sortNo_val, pInputId, out reMsg, out reData);

                            if (reCode == "Y" && reData != "")
                                reCnt = Convert.ToInt16(reData);

                            if (reCnt > 0)
                                MessageBox.Show(wRM.GetString("wSave") + " " + wRM.GetString("wSuccess") + " : " + reCnt.ToString());
                            else
                                MessageBox.Show(wRM.GetString("wSave") + " " + wRM.GetString("wFail"));
                        }

                       

                        SetDataBind_gridView1(_scodeGrp);
                        SetDataBind_grideView2();
                    }
                    catch (Exception ex)
                    {
                        logs.SaveLog("[error]  (page)::FrmSysCode.cs  (Function)::dataGridView2_CellClick  (Detail):: " + "\r\n" + ex.ToString(), "Error");
                    }
                    finally
                    {
                        if (wSvc != null)
                            wSvc.Dispose();
                    }
                }
            }
        }

        private string ChkDgv2Param()
        {
            string reVal = "";

            try
            {
                if (dataGridView2.Rows[0].Cells["dgv2_SCODE"].Value != null)
                {
                    if (dataGridView2.Rows[0].Cells["dgv2_SCODE"].Value.ToString() == "")
                    {
                        reVal = wRM.GetString("wCode");
                        return reVal;
                    }
                }
                else
                {
                    reVal = wRM.GetString("wCode");
                    return reVal;
                }

                if (dataGridView2.Rows[0].Cells["dgv2_SCODE_NM"].Value != null)
                {
                    if (dataGridView2.Rows[0].Cells["dgv2_SCODE_NM"].Value.ToString() == "")
                    {
                        reVal = wRM.GetString("wName");
                        return reVal;
                    }
                }
                else
                {
                    reVal = wRM.GetString("wName");
                    return reVal;
                }
            }
            catch (Exception ex)
            {
                reVal = wRM.GetString("wError");
                logs.SaveLog("[error]  (page)::FrmSysCode.cs  (Function)::ChkDgv2Param  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }

            return reVal;
        }

        // dataGridView 선택값 없애기
        private void NoSelectGrideView(DataGridView dgv)
        {
            dgv.ClearSelection();
            dgv.CurrentCell = null;
        }

        private void SetRowNumber(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
                row.HeaderCell.Value = String.Format("{0}", row.Index + 1);

            dgv.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            M_WsSysCodeGrp.WsSysCodeGrp wSvc = null;
            string reCode = "";
            string reMsg = "";
            string reData = "";
            try
            {
                wSvc = new M_WsSysCodeGrp.WsSysCodeGrp();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/SysCode/WsSysCodeGrp.svc";
                wSvc.Timeout = 1000;

                int reCnt = 0;

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells["dgv1_CHK"].Value != null)
                    {
                        if (dataGridView1.Rows[i].Cells["dgv1_CHK"].Value.ToString() == "1")
                        {
                            string scode_val = dataGridView1.Rows[i].Cells["dgv1_SCODE"].Value.ToString();
                            string scodeNm_val = dataGridView1.Rows[i].Cells["dgv1_SCODE_NM"].Value.ToString();
                            string usingFlag_val = dataGridView1.Rows[i].Cells["dgv1_USING_FLAG"].Value.ToString();


                            string sortNo_val = "1";
                            if (dataGridView1.Rows[i].Cells["dgv1_SORT_NO"].Value != null)
                            {
                                sortNo_val = dataGridView1.Rows[i].Cells["dgv1_SORT_NO"].Value.ToString();
                            }


                            string memo_val = "";
                            if (dataGridView1.Rows[i].Cells["dgv1_MEMO"].Value != null)
                            {
                                memo_val = dataGridView1.Rows[i].Cells["dgv1_MEMO"].Value.ToString();
                            }

                            string inputId_val = "1";

                            reCode = wSvc.mSysCode(scode_val, scodeNm_val, usingFlag_val, sortNo_val, memo_val, inputId_val, out reMsg, out reData);

                            if (reCode == "Y" && reData != "")
                                reCnt += Convert.ToInt16(reData);
                        }
                    }
                }

                if (reCnt > 0)
                    MessageBox.Show(wRM.GetString("wSave") + " " + wRM.GetString("wSuccess") + " : " + reCnt.ToString());
                else
                    MessageBox.Show(wRM.GetString("wSave") + " " + wRM.GetString("wFail"));

                SetDataBind_gridView1(_scodeGrp);
            }
            catch (Exception ex)
            {

                logs.SaveLog("[error]  (page)::FrmSysCode.cs  (Function)::btnSave_Click  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (wSvc != null)
                    wSvc.Dispose();
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                btnSearch_Click(null, null);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SetDataBind_gridView1(_scodeGrp);
        }
    }
}

