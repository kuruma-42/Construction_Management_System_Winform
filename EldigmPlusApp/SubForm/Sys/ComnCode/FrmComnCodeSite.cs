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

namespace EldigmPlusApp.SubForm.Sys.ComnCode
{
    public partial class FrmComnCodeSite : Form
    {
        LogUtil logs = null;
        ResourceManager wRM = null;
        ResourceManager msgRM = null;

        string _pCcodeGrp = "";
        string _pNewFlag = "";
        string _pModifyFlag = "";
        string _pDelFlag = "";

        public FrmComnCodeSite()
        {
            // Sets the UI culture
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(AppInfo.SsLanguage);
            this.AutoScaleMode = AutoScaleMode.Dpi;

            InitializeComponent();

            try
            {
                logs = new LogUtil();
                wRM = new ResourceManager("EldigmPlusApp.GlobalLanguage.word_Language", typeof(FrmComnCodeSite).Assembly);
                msgRM = new ResourceManager("EldigmPlusApp.GlobalLanguage.msg_Language", typeof(FrmComnCodeSite).Assembly);

                btnSearch.Text = wRM.GetString("wSearch");
                btnSave.Text = wRM.GetString("wSave");

                dataGridView1.Columns["dgv1_CHK"].HeaderText = wRM.GetString("wSelect");
                dataGridView1.Columns["dgv1_CCODE_GRP"].HeaderText = wRM.GetString("wCode");
                dataGridView1.Columns["dgv1_CCODE_NM"].HeaderText = wRM.GetString("wName");
                dataGridView1.Columns["dgv1_USING_FLAG"].HeaderText = wRM.GetString("wUse");
                dataGridView1.Columns["dgv1_SORT_NO"].HeaderText = wRM.GetString("wSort");
                dataGridView1.Columns["dgv1_MEMO"].HeaderText = wRM.GetString("wMemo");

                dataGridView2.Columns["dgv2_CCODE_NM"].HeaderText = "*" + wRM.GetString("wName");
                dataGridView2.Columns["dgv2_SORT_NO"].HeaderText = wRM.GetString("wSort");
                dataGridView2.Columns["dgv2_MEMO"].HeaderText = wRM.GetString("wMemo");

                dataGridView2.Columns["dgv2_CCODE_NM"].HeaderCell.Style.ForeColor = Color.Maroon; // 헤더 필수 항목 빨강색

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
                logs.SaveLog("[error]  (page)::FrmComnCodeSite.cs  (Function)::FrmComnCodeSite  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        #region __ panel2 paint_Purple1
        private void paint_Purple1(object sender, PaintEventArgs e)
        {
            Class.UI.PanelPaint pp = new Class.UI.PanelPaint();
            pp.paint_PanelPurple1(sender, e);
        }
        #endregion

        private void FrmComnCodeSite_Load(object sender, EventArgs e)
        {
            try
            {
                SetDataBind_treeView1();
                SetDataBind_Combo();
                SetDataBind_grideView2();
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmComnCodeSite.cs  (Function)::FrmComnCodeSite_Load  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
                logs.SaveLog("[error]  (page)::FrmComnCodeSite.cs  (Function)::setDataBind_Combo  (Detail):: " + "\r\n" + ex.ToString());
            }

        }

        private void SetDataBind_treeView1()
        {
            treeView1.Nodes.Clear();

            M_WsCCodeGrp.WsComnCodeGrp wSvc = null;
            string reCode = "";
            string reMsg = "";
            M_WsCCodeGrp.DataSetAuthSiteMemberDB[] getData1 = null;
            try
            {
                wSvc = new M_WsCCodeGrp.WsComnCodeGrp();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/ComnCode/WsComnCodeGrp.svc";
                wSvc.Timeout = 1000;

                ImageList myimageList = new ImageList();
                myimageList.Images.Add(Image.FromFile(@"Image\treeicon1.png"));

                treeView1.ImageList = myimageList;
                treeView1.ImageIndex = 0;

                reCode = wSvc.sComnSiteTreeView(AppInfo.SsDbNm, AppInfo.SsSiteCd, AppInfo.SsLabAuth, out getData1, out reMsg);
                if (reCode == "Y")
                {
                    if (getData1 != null && getData1.Length > 0)
                    {
                        for (int i = 0; i < getData1.Length; i++)
                        {
                            string ccodeGrp_val = getData1[i].CCODE_GRP.ToString();
                            string ccodeGrpNm_val = getData1[i].CCODE_GRP_NM.ToString();
                            string newFlag_val = getData1[i].NEW_FLAG.ToString();
                            string modifyFlag_val = getData1[i].MODIFY_FLAG.ToString();
                            string delFlag_val = getData1[i].DEL_FLAG.ToString();

                            TreeNode node1 = new TreeNode();
                            node1.Tag = ccodeGrp_val + "-" + newFlag_val + "-" + modifyFlag_val + "-" + delFlag_val;
                            node1.Text = ccodeGrpNm_val;

                            treeView1.Nodes.Add(node1);
                        }

                        if (treeView1.Nodes.Count > 0)
                            treeView1.SelectedNode = treeView1.GetNodeAt(0, 0);

                        treeView1.ExpandAll();
                    }
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmComnCodeSite.cs  (Function)::setDataBind_treeView1  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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

                string eNodeTag = "";
                eNodeTag = e.Node.Tag.ToString();
                lblName.Text = "** " + e.Node.Text;

                string[] codeArr = eNodeTag.Split('-');

                _pCcodeGrp = codeArr[0].ToString();
                _pNewFlag = codeArr[1].ToString();
                _pModifyFlag = codeArr[2].ToString();
                _pDelFlag = codeArr[3].ToString();

                SetDataBind_gridView1(_pCcodeGrp);

            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmComnCodeSite.cs  (Function)::treeView1_AfterSelect  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        private void SetDataBind_gridView1(string pCcodeGrp)
        {
            string searchTxt_val = "";
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                searchTxt_val = txtSearch.Text;
            }

            M_WsCCodeGrp.WsComnCodeGrp wSvc = null;
            string reCode = "";
            string reMsg = "";
            M_WsCCodeGrp.DataComecodeSite[] getData = null;
            try
            {
                wSvc = new M_WsCCodeGrp.WsComnCodeGrp();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/ComnCode/WsComnCodeGrp.svc";
                wSvc.Timeout = 1000;

                reCode = wSvc.sComnSite(AppInfo.SsDbNm, AppInfo.SsSiteCd, pCcodeGrp, cmbUse.SelectedValue.ToString(), searchTxt_val, out getData, out reMsg);

                if (reCode == "Y")
                {
                    if (getData != null && getData.Length > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int i = 0; i < getData.Length; i++)
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[i].Cells["dgv1_CHK"].Value = "0";
                            dataGridView1.Rows[i].Cells["dgv1_CCODE"].Value = getData[i].CCODE.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_CCODE_GRP"].Value = getData[i].CCODE_GRP.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_CCODE_NM"].Value = getData[i].CCODE_NM.ToString();
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
                logs.SaveLog("[error]  (page)::FrmComnCodeSite.cs  (Function)::SetDataBind_gridView1  (Detail)::pCcodeGrp=[" + pCcodeGrp + "]", "Error");
                logs.SaveLog("[error]  (page)::FrmComnCodeSite.cs  (Function)::SetDataBind_gridView1  (Detail)::reMsg=[" + reMsg + "]", "Error");
                logs.SaveLog("[error]  (page)::FrmComnCodeSite.cs  (Function)::SetDataBind_gridView1  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
                logs.SaveLog("[error]  (page)::FrmComnCodeSite.cs  (Function)::dataGridView1_CellBeginEdit  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
                logs.SaveLog("[error]  (page)::FrmComnCodeSite.cs  (Function)::dataGridView1_ColumnHeaderMouseClick  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
                dataGridView2.Rows.Add();
                dataGridView2.Rows[0].Cells["dgv2_SORT_NO"].Value = "10";
                dataGridView2.Rows[0].Cells["dgv2_BTNADD"].Value = wRM.GetString("wAdd");
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmComnCodeSite.cs  (Function)::SetDataBind_grideView2  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
                    string ccodeNm_val = dataGridView2.Rows[0].Cells["dgv2_CCODE_Nm"].Value.ToString();

                    string memo_val = "";
                    if (dataGridView2.Rows[0].Cells["dgv2_MEMO"].Value != null)
                    {
                        memo_val = dataGridView2.Rows[0].Cells["dgv2_MEMO"].Value.ToString();
                    }

                    string sortNo_val = "10";
                    if (dataGridView2.Rows[0].Cells["dgv2_SORT_NO"].Value != null)
                    {
                        sortNo_val = dataGridView2.Rows[0].Cells["dgv2_SORT_NO"].Value.ToString();
                    }

                    M_WsCCodeGrp.WsComnCodeGrp wSvc = null;
                    string reCode = "";
                    string reMsg = "";
                    string reData = "";
                    try
                    {
                        wSvc = new M_WsCCodeGrp.WsComnCodeGrp();
                        wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/ComnCode/WsComnCodeGrp.svc";
                        wSvc.Timeout = 1000;

                        int reCnt = 0;

                        string[] param = new string[6];
                        param[0] = AppInfo.SsSiteCd;
                        param[1] = _pCcodeGrp;
                        param[2] = ccodeNm_val;
                        param[3] = memo_val;
                        param[4] = sortNo_val;
                        param[5] = AppInfo.SsLabNo;

                        reCode = wSvc.aComnSite(AppInfo.SsDbNm, param, out reMsg, out reData);

                        if (reCode == "Y" && reData != "0")
                            reCnt += Convert.ToInt16(reData);


                        if (reCnt != 0)
                        {
                            string searchValue = dataGridView2.Rows[0].Cells["dgv2_CCODE_Nm"].Value.ToString();

                            //int rowIndex = -1;
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                if (row.Cells["dgv1_CCODE_NM"].Value.ToString().Equals(searchValue))
                                {
                                    MessageBox.Show(msgRM.GetString("msgSameName"));
                                    return;
                                }
                            }
                            MessageBox.Show(wRM.GetString("wSave") + " " + wRM.GetString("wSuccess"));
                        }
                        else
                        {
                            MessageBox.Show(wRM.GetString("wSave") + " " + wRM.GetString("wFail"));
                        }

                        SetDataBind_gridView1(_pCcodeGrp);

                    }
                    catch (Exception ex)
                    {
                        logs.SaveLog("[error]  (page)::FrmComnCodeSite.cs  (Function)::dataGridView2_CellClick  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
                if (dataGridView2.Rows[0].Cells["dgv2_CCODE_NM"].Value != null)
                {
                    if (dataGridView2.Rows[0].Cells["dgv2_CCODE_NM"].Value.ToString() == "")
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
                logs.SaveLog("[error]  (page)::FrmComnCodeSite.cs  (Function)::ChkDgv2Param  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
            M_WsCCodeGrp.WsComnCodeGrp wSvc = null;
            string reCode = "";
            string reMsg = "";
            string reData = "";

            try
            {
                wSvc = new M_WsCCodeGrp.WsComnCodeGrp();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/ComnCode/WsComnCodeGrp.svc";
                wSvc.Timeout = 1000;

                int reCnt = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells["dgv1_CHK"].Value != null)
                    {
                        if (dataGridView1.Rows[i].Cells["dgv1_CHK"].Value.ToString() == "1")
                        {
                            reCnt++;
                        }
                    }
                }
                if (reCnt < 1)
                {
                    MessageBox.Show(msgRM.GetString("msgNotSelected"));
                    return;
                }

                reCnt = 0;

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells["dgv1_CHK"].Value != null)
                    {
                        if (dataGridView1.Rows[i].Cells["dgv1_CHK"].Value.ToString() == "1")
                        {
                            string ccode_val = dataGridView1.Rows[i].Cells["dgv1_CCODE"].Value.ToString();

                            string usingFlag_val = "1";
                            if (dataGridView1.Rows[i].Cells["dgv1_USING_FLAG"].Value != null)
                            {
                                usingFlag_val = dataGridView1.Rows[i].Cells["dgv1_USING_FLAG"].Value.ToString();
                            }

                            string sortNo_val = "10";
                            if (dataGridView1.Rows[i].Cells["dgv1_SORT_NO"].Value != null)
                            {
                                sortNo_val = dataGridView1.Rows[i].Cells["dgv1_SORT_NO"].Value.ToString();
                            }

                            string memo_val = "";
                            if (dataGridView1.Rows[i].Cells["dgv1_MEMO"].Value != null)
                            {
                                memo_val = dataGridView1.Rows[i].Cells["dgv1_MEMO"].Value.ToString();
                            }

                            reCode = wSvc.mComnSite(AppInfo.SsDbNm, AppInfo.SsSiteCd, ccode_val, usingFlag_val, sortNo_val, memo_val, AppInfo.SsLabNo, out reMsg, out reData);
                            if (reCode == "Y" && reData != "")
                                reCnt += Convert.ToInt16(reData);
                        }
                    }
                }

                if (reCnt > 0)
                    MessageBox.Show(wRM.GetString("wSave") + " " + wRM.GetString("wSuccess") + " : " + reCnt.ToString());
                else
                    MessageBox.Show(wRM.GetString("wSave") + " " + wRM.GetString("wFail"));

                SetDataBind_gridView1(_pCcodeGrp);
            }
            catch (Exception ex)
            {

                logs.SaveLog("[error]  (page)::FrmComnCodeSite.cs  (Function)::btnSave_Click  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
            SetDataBind_gridView1(_pCcodeGrp);
        }

        private void cmbUse_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDataBind_gridView1(_pCcodeGrp);
        }
    }
}

