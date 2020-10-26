using EldigmPlusApp.Config;
using Framework.Log;
using System;
using System.Collections;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Threading;
using System.Windows.Forms;

namespace EldigmPlusApp.SubForm.Sys.CodeT
{
    public partial class FrmCodeTMainDB : Form
    {
        LogUtil logs = null;
        ResourceManager wRM = null;
        ResourceManager msgRM = null;

        string _codeGrp = "";
        string _code = "";
        FrmCodeTSite _formCodeTSite;

        public FrmCodeTMainDB()
        {
            // Sets the UI culture
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(AppInfo.SsLanguage);
            this.AutoScaleMode = AutoScaleMode.Dpi;

            InitializeComponent();

            try
            {
                logs = new LogUtil();
                wRM = new ResourceManager("EldigmPlusApp.GlobalLanguage.word_Language", typeof(FrmCodeTMainDB).Assembly);
                msgRM = new ResourceManager("EldigmPlusApp.GlobalLanguage.msg_Language", typeof(FrmCodeTMainDB).Assembly);

                btnSave.Text = wRM.GetString("wSave");

                dataGridView1.Columns["dgv1_CHK"].HeaderText = wRM.GetString("wSelect");
                dataGridView1.Columns["dgv1_TCODE"].HeaderText = wRM.GetString("wTcode");
                dataGridView1.Columns["dgv1_TTYPE_SCD"].HeaderText = "T" + wRM.GetString("wType") + wRM.GetString("wScode");
                dataGridView1.Columns["dgv1_NM"].HeaderText = wRM.GetString("wName");
                dataGridView1.Columns["dgv1_LIST_FLAG"].HeaderText = wRM.GetString("wList");
                dataGridView1.Columns["dgv1_REQUIRED_FLAG"].HeaderText = wRM.GetString("wRequired");
                dataGridView1.Columns["dgv1_NUMERIC_FLAG"].HeaderText = wRM.GetString("wNumeric");
                dataGridView1.Columns["dgv1_USING_CNT"].HeaderText = wRM.GetString("wUse") + wRM.GetString("wCounter");

                dataGridView2.Columns["dgv2_TCODE"].HeaderText = "*" + wRM.GetString("wTcode");
                dataGridView2.Columns["dgv2_NM"].HeaderText = "*" + wRM.GetString("wName");
                dataGridView2.Columns["dgv2_LIST_FLAG"].HeaderText = wRM.GetString("wList");
                dataGridView2.Columns["dgv2_REQUIRED_FLAG"].HeaderText = wRM.GetString("wRequired");
                dataGridView2.Columns["dgv2_NUMERIC_FLAG"].HeaderText = wRM.GetString("wNumeric");

                dataGridView2.Columns["dgv2_TCODE"].HeaderCell.Style.ForeColor = Color.Maroon; // 헤더 필수 항목 빨강색
                dataGridView2.Columns["dgv2_NM"].HeaderCell.Style.ForeColor = Color.Maroon; // 헤더 필수 항목 빨강색

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
                logs.SaveLog("[error]  (page)::FrmCodeTMainDB.cs  (Function)::FrmCodeTMainDB  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        public FrmCodeTMainDB(FrmCodeTSite CodeTSite)
        {
            // Sets the UI culture
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(AppInfo.SsLanguage);
            this.AutoScaleMode = AutoScaleMode.Dpi;

            InitializeComponent();
            _formCodeTSite = CodeTSite;

            try
            {
                logs = new LogUtil();
                wRM = new ResourceManager("EldigmPlusApp.GlobalLanguage.word_Language", typeof(FrmCodeTMainDB).Assembly);
                msgRM = new ResourceManager("EldigmPlusApp.GlobalLanguage.msg_Language", typeof(FrmCodeTMainDB).Assembly);

                btnSave.Text = wRM.GetString("wApply");
                
                dataGridView1.Columns["dgv1_CHK"].HeaderText = wRM.GetString("wSelect");
                dataGridView1.Columns["dgv1_TCODE"].HeaderText = wRM.GetString("wTcode");
                dataGridView1.Columns["dgv1_TTYPE_SCD"].HeaderText = "T" + wRM.GetString("wType") + wRM.GetString("wScode");
                dataGridView1.Columns["dgv1_NM"].HeaderText = wRM.GetString("wName");
                dataGridView1.Columns["dgv1_LIST_FLAG"].HeaderText = wRM.GetString("wList");
                dataGridView1.Columns["dgv1_REQUIRED_FLAG"].HeaderText = wRM.GetString("wRequired");
                dataGridView1.Columns["dgv1_NUMERIC_FLAG"].HeaderText = wRM.GetString("wNumeric");
                dataGridView1.Columns["dgv1_USING_CNT"].HeaderText = wRM.GetString("wUse") + wRM.GetString("wCounter");

                dataGridView2.Columns["dgv2_TCODE"].HeaderText = "*" + wRM.GetString("wTcode");
                dataGridView2.Columns["dgv2_NM"].HeaderText = "*" + wRM.GetString("wName");
                dataGridView2.Columns["dgv2_LIST_FLAG"].HeaderText = wRM.GetString("wList");
                dataGridView2.Columns["dgv2_REQUIRED_FLAG"].HeaderText = wRM.GetString("wRequired");
                dataGridView2.Columns["dgv2_NUMERIC_FLAG"].HeaderText = wRM.GetString("wNumeric");


                dataGridView2.Columns["dgv2_TCODE"].HeaderCell.Style.ForeColor = Color.Maroon; // 헤더 필수 항목 빨강색
                dataGridView2.Columns["dgv2_NM"].HeaderCell.Style.ForeColor = Color.Maroon; // 헤더 필수 항목 빨강색

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
                logs.SaveLog("[error]  (page)::FrmCodeTMainDB.cs  (Function)::FrmCodeTMainDB  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        #region __ panel2 paint_Purple1
        private void paint_Purple1(object sender, PaintEventArgs e)
        {
            Class.UI.PanelPaint pp = new Class.UI.PanelPaint();
            pp.paint_PanelPurple1(sender, e);
        }
        #endregion

        private void FrmCodeTMainDB_Load(object sender, EventArgs e)
        {
            try
            {
                SetDataBind_treeView1();
                SetDataBind_grideView2();
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmCodeTMainDB.cs  (Function)::FrmCodeTMainDB_Load  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }


        private void SetDataBind_treeView1()
        {
            treeView1.Nodes.Clear();

            M_WsCodeTMainDB.WsCodeTMainDB wSvc = null;
            string reCode = "";
            string reMsg = "";
            M_WsCodeTMainDB.DataSysCode[] getData1 = null;
            M_WsCodeTMainDB.DataCodeT[] getData2 = null;
            M_WsCodeTMainDB.DataCodeTSub[] getData3 = null;
            try
            {
                wSvc = new M_WsCodeTMainDB.WsCodeTMainDB();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/CodeT/WsCodeTMainDB.svc";
                wSvc.Timeout = 1000;

                ImageList myimageList = new ImageList();
                myimageList.Images.Add(Image.FromFile(@"Image\treeicon1.png"));

                treeView1.ImageList = myimageList;
                treeView1.ImageIndex = 0;

                reCode = wSvc.sSysCode(out getData1, out reMsg);
                if (reCode == "Y")
                {
                    if (getData1 != null && getData1.Length > 0)
                    {
                        for (int j = 0; j < getData1.Length; j++)
                        {
                            string sCode_val = getData1[j].SCODE.ToString();
                            string sCodeNm_val = getData1[j].SCODE_NM.ToString();

                            TreeNode root = new TreeNode();
                            root.Tag = "1-" + sCode_val;
                            root.Text = sCodeNm_val;

                            reCode = wSvc.sCodeTTreeView(sCode_val, out getData2, out reMsg);
                            if (reCode == "Y")
                            {
                                if (getData2 != null && getData2.Length > 0)
                                {
                                    for (int k = 0; k < getData2.Length; k++)
                                    {
                                        string tcode_val = getData2[k].TCODE.ToString();
                                        string tcodeNm_val = getData2[k].TCODE_NM.ToString();
                                        TreeNode node2 = new TreeNode();
                                        node2.Tag = "2-" + tcode_val;
                                        node2.Text = tcodeNm_val;

                                        root.Nodes.Add(node2);

                                        reCode = wSvc.sCodeTSubTreeView(tcode_val, out getData3, out reMsg);
                                        if (reCode == "Y")
                                        {
                                            if (getData3 != null && getData3.Length > 0)
                                            {
                                                for (int i = 0; i < getData3.Length; i++)
                                                {
                                                    string tscode_val = getData3[i].TSCODE.ToString();
                                                    string tscodeNm_val = getData3[i].TSCODE_NM.ToString();
                                                    TreeNode node3 = new TreeNode();
                                                    node3.Tag = "3-" + tscode_val;
                                                    node3.Text = tscodeNm_val;

                                                    node2.Nodes.Add(node3);

                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            treeView1.Nodes.Add(root);

                            if (treeView1.Nodes.Count > 0)
                                treeView1.SelectedNode = treeView1.GetNodeAt(0, 0);

                        }

                        treeView1.ExpandAll();
                    }
                }
            }

            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmCodeTMainDB.cs  (Function)::SetDataBind_treeView1  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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

                _codeGrp = codeArr[0].ToString();
                _code = codeArr[1].ToString();

                SetDataBind_grideView2();
                SetDataBind_gridView1(_codeGrp, _code);

            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmCodeTMainDB.cs  (Function)::treeView1_AfterSelect  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        private void SetDataBind_gridView1(string codeGrp, string code_val)
        {
            M_WsCodeTMainDB.WsCodeTMainDB wSvc = null;
            string reCode = "";
            string reMsg = "";

            M_WsCodeTMainDB.DataCodeT[] getData1 = null;
            M_WsCodeTMainDB.DataCodeTSub[] getData2 = null;

            try
            {
                wSvc = new M_WsCodeTMainDB.WsCodeTMainDB();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/CodeT/WsCodeTMainDB.svc";
                wSvc.Timeout = 1000;

                dataGridView2.Enabled = false;
                btnSave.Enabled = false;

                if (codeGrp == "1")
                {
                    dataGridView2.Enabled = true;
                    btnSave.Enabled = true;

                    dataGridView1.Columns["dgv1_TTYPE_SCD"].Visible = true;
                    dataGridView1.Columns["dgv1_LIST_FLAG"].Visible = true;
                    dataGridView1.Columns["dgv1_REQUIRED_FLAG"].Visible = true;
                    dataGridView1.Columns["dgv1_NUMERIC_FLAG"].Visible = true;
                    dataGridView1.Columns["dgv1_USING_CNT"].Visible = false;
                    dataGridView2.Columns["dgv2_LIST_FLAG"].Visible = true;
                    dataGridView2.Columns["dgv2_REQUIRED_FLAG"].Visible = true;
                    dataGridView2.Columns["dgv2_NUMERIC_FLAG"].Visible = true;
                    dataGridView2.Columns["dgv2_TCODE"].ReadOnly = false;


                    reCode = wSvc.sCodeT(code_val, out getData1, out reMsg);
                    if (reCode == "Y")
                    {
                        if (getData1 != null && getData1.Length > 0)
                        {
                            dataGridView1.Rows.Clear();
                            for (int i = 0; i < getData1.Length; i++)
                            {
                                dataGridView1.Rows.Add();
                                dataGridView1.Rows[i].Cells["dgv1_TCODE"].Value = getData1[i].TCODE.ToString();
                                dataGridView1.Rows[i].Cells["dgv1_TTYPE_SCD"].Value = getData1[i].TTYPE_SCD.ToString();
                                dataGridView1.Rows[i].Cells["dgv1_NM"].Value = getData1[i].TCODE_NM.ToString();
                                dataGridView1.Rows[i].Cells["dgv1_LIST_FLAG"].Value = getData1[i].LIST_FLAG.ToString();
                                dataGridView1.Rows[i].Cells["dgv1_REQUIRED_FLAG"].Value = getData1[i].REQUIRED_FLAG.ToString();
                                dataGridView1.Rows[i].Cells["dgv1_NUMERIC_FLAG"].Value = getData1[i].NUMERIC_FLAG.ToString();
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
                else if (codeGrp == "2")
                {
                    dataGridView1.Columns["dgv1_TTYPE_SCD"].Visible = false;
                    dataGridView1.Columns["dgv1_LIST_FLAG"].Visible = false;
                    dataGridView1.Columns["dgv1_REQUIRED_FLAG"].Visible = false;
                    dataGridView1.Columns["dgv1_NUMERIC_FLAG"].Visible = false;
                    dataGridView1.Columns["dgv1_USING_CNT"].Visible = true;
                    dataGridView2.Columns["dgv2_LIST_FLAG"].Visible = false;
                    dataGridView2.Columns["dgv2_REQUIRED_FLAG"].Visible = false;
                    dataGridView2.Columns["dgv2_NUMERIC_FLAG"].Visible = false;

                    if (code_val == "InspectionMethod" || code_val == "CarSize")
                    {
                        dataGridView2.Enabled = true;
                        btnSave.Enabled = true;

                        if (btnSave.Text == wRM.GetString("wApply"))
                        {
                                btnSave.Enabled = false;
                                dataGridView2.Enabled = false;
                        }

                        dataGridView2.Rows[0].Cells["dgv2_TCODE"].Value = code_val;
                        dataGridView2.Columns["dgv2_TCODE"].ReadOnly = true;

                        reCode = wSvc.sCodeTSub(code_val, out getData2, out reMsg);
                        if (reCode == "Y")
                        {
                            if (getData2 != null && getData2.Length > 0)
                            {
                                dataGridView1.Rows.Clear();

                                for (int i = 0; i < getData2.Length; i++)
                                {
                                    dataGridView1.Rows.Add();
                                    dataGridView1.Rows[i].Cells["dgv1_TCODE"].Value = getData2[i].TCODE.ToString();
                                    dataGridView1.Rows[i].Cells["dgv1_NM"].Value = getData2[i].TSCODE_NM.ToString();
                                    dataGridView1.Rows[i].Cells["dgv1_USING_CNT"].Value = getData2[i].USING_CNT.ToString();
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
                    else
                    {
                        dataGridView1.Rows.Clear();
                        lblName.Text = null;
                    }
                }
                else
                {
                    dataGridView1.Rows.Clear();
                    lblName.Text = null;
                }

            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmCodeTMainDB.cs  (Function)::SetDataBind_gridView1  (Detail)::codeGrp=[" + codeGrp + "], code_val=[" + code_val + "]", "Error");
                logs.SaveLog("[error]  (page)::FrmCodeTMainDB.cs  (Function)::SetDataBind_gridView1  (Detail)::reMsg=[" + reMsg + "]", "Error");
                logs.SaveLog("[error]  (page)::FrmCodeTMainDB.cs  (Function)::SetDataBind_gridView1  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
                logs.SaveLog("[error]  (page)::FrmCodeTMainDB.cs  (Function)::dataGridView1_CellBeginEdit  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        bool chkUseAll = false;
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                string columnNm = dataGridView1.Columns[e.ColumnIndex].Name;
                if (columnNm == "dgv1_CHK" || columnNm == "dgv1_LIST_FLAG" || columnNm == "dgv1_REQUIRED_FLAG" || columnNm == "dgv1_NUMERIC_FLAG")
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (chkUseAll)
                            dataGridView1.Rows[i].Cells[columnNm].Value = "0";
                        else
                            dataGridView1.Rows[i].Cells[columnNm].Value = "1";

                        if (columnNm == "dgv1_LIST_FLAG" || columnNm == "dgv1_REQUIRED_FLAG" || columnNm == "dgv1_NUMERIC_FLAG")
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
                logs.SaveLog("[error]  (page)::FrmCodeTMainDB.cs  (Function)::dataGridView1_ColumnHeaderMouseClick  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
                dataGridView2.Rows[0].Cells["dgv2_BTNADD"].Value = wRM.GetString("wAdd");
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmCodeTMainDB.cs  (Function)::dataGridView1_DataBindingComplete  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            M_WsCodeTMainDB.WsCodeTMainDB wSvc = null;
            string reCode = "";
            string reMsg = "";
            string reData = "";

            string colNm = dataGridView2.Columns[e.ColumnIndex].Name;

            if (colNm == "dgv2_BTNADD")
            {
                if (_codeGrp == "1")
                {
                    string reVal = ChkDgv2Param();

                    if (reVal != "")
                        MessageBox.Show(wRM.GetString("wCheck") + " :: " + reVal);
                    else
                    {
                        string tCode_val = dataGridView2.Rows[0].Cells["dgv2_TCODE"].Value.ToString();
                        string tCodeNm_val = dataGridView2.Rows[0].Cells["dgv2_NM"].Value.ToString();

                        string listFlag_val = "0";
                        if (dataGridView2.Rows[0].Cells["dgv2_LIST_FLAG"].Value != null)
                            listFlag_val = dataGridView2.Rows[0].Cells["dgv2_LIST_FLAG"].Value.ToString();

                        string requiredFlag_val = "0";
                        if (dataGridView2.Rows[0].Cells["dgv2_REQUIRED_FLAG"].Value != null)
                            requiredFlag_val = dataGridView2.Rows[0].Cells["dgv2_REQUIRED_FLAG"].Value.ToString();

                        string numericFlag_val = "0";
                        if (dataGridView2.Rows[0].Cells["dgv2_NUMERIC_FLAG"].Value != null)
                            numericFlag_val = dataGridView2.Rows[0].Cells["dgv2_NUMERIC_FLAG"].Value.ToString();

                        try
                        {
                            wSvc = new M_WsCodeTMainDB.WsCodeTMainDB();
                            wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/CodeT/WsCodeTMainDB.svc";
                            wSvc.Timeout = 1000;

                            reCode = wSvc.exCodeT(tCode_val, tCodeNm_val, out reMsg, out reData);
                            if (reCode == "Y" && reData != "0")
                            {
                                MessageBox.Show(msgRM.GetString("msgDuplicated"));
                            }
                            else
                            {
                                   reCode = "";
                                reCode = wSvc.aCodeT(tCode_val, _code, tCodeNm_val, listFlag_val, requiredFlag_val, numericFlag_val, AppInfo.SsLabNo, out reMsg, out reData);
                                if (btnSave.Text == wRM.GetString("wApply"))
                                {
                                    string[] param = new string[9];

                                    param[0] = tCode_val;
                                    param[1] = _code;
                                    param[2] = tCodeNm_val;
                                    param[3] = requiredFlag_val;
                                    param[4] = numericFlag_val;
                                    param[5] = listFlag_val;
                                    param[6] = AppInfo.SsLabNo;
                                    param[7] = AppInfo.SsSiteCd;
                                    param[8] = _formCodeTSite.getTgrpCcd();

                                    reCode = wSvc.aCodeTSite(AppInfo.SsDbNm, param, out reMsg, out reData);
                                    _formCodeTSite.Popup_End();
                                }



                                int reCnt = 0;

                                if (reCode == "Y" && reData != "")
                                    reCnt = Convert.ToInt16(reData);

                                if (reCnt > 0)
                                    MessageBox.Show(wRM.GetString("wSave") + " " + wRM.GetString("wSuccess") + " : " + reCnt.ToString());
                                else
                                    MessageBox.Show(wRM.GetString("wSave") + " " + wRM.GetString("wFail"));

                                SetDataBind_gridView1(_codeGrp, _code);

                            }

                        }
                        catch (Exception ex)
                        {
                            logs.SaveLog("[error]  (page)::FrmCodeTMainDB.cs  (Function)::dataGridView2_CellClick  (Detail):: " + "\r\n" + ex.ToString(), "Error");
                        }
                        finally
                        {
                            if (wSvc != null)
                                wSvc.Dispose();
                        }
                    }

                }

                if (_codeGrp == "2")
                {
                    string reVal = ChkDgv2Param();

                    if (reVal != "")
                        MessageBox.Show(wRM.GetString("wCheck") + " :: " + reVal);
                    else
                    {
                        string tCode_val = dataGridView2.Rows[0].Cells["dgv2_TCODE"].Value.ToString();
                        string tscodeNm_val = dataGridView2.Rows[0].Cells["dgv2_NM"].Value.ToString();

                        try
                        {
                            wSvc = new M_WsCodeTMainDB.WsCodeTMainDB();
                            wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/CodeT/WsCodeTMainDB.svc";
                            wSvc.Timeout = 1000;

                            reCode = wSvc.exCodeTSub(tCode_val, tscodeNm_val, out reMsg, out reData);
                            if (reCode == "Y" && reData != "0")
                            {
                                MessageBox.Show(msgRM.GetString("msgDuplicated"));
                            }
                            else
                            {
                                reCode = "";
                                reCode = wSvc.aCodeTSub(tCode_val, tscodeNm_val, "0", AppInfo.SsLabNo, out reMsg, out reData);

                                int reCnt = 0;

                                if (reCode == "Y" && reData != "")
                                    reCnt = Convert.ToInt16(reData);

                                if (reCnt > 0)
                                    MessageBox.Show(wRM.GetString("wSave") + " " + wRM.GetString("wSuccess") + " : " + reCnt.ToString());
                                else
                                    MessageBox.Show(wRM.GetString("wSave") + " " + wRM.GetString("wFail"));

                                SetDataBind_gridView1(_codeGrp, _code);
                            }

                        }
                        catch (Exception ex)
                        {
                            logs.SaveLog("[error]  (page)::FrmCodeTMainDB.cs  (Function)::dataGridView2_CellClick  (Detail):: " + "\r\n" + ex.ToString(), "Error");
                        }
                        finally
                        {
                            if (wSvc != null)
                                wSvc.Dispose();
                        }
                    }

                }

            }
        }

        private string ChkDgv2Param()
        {
            string reVal = "";
            try
            {
                if (dataGridView2.Rows[0].Cells["dgv2_TCODE"].Value != null)
                {
                    if (dataGridView2.Rows[0].Cells["dgv2_TCODE"].Value.ToString() == "")
                    {
                        reVal = wRM.GetString("wTcode");
                        return reVal;
                    }
                }
                else
                {
                    reVal = wRM.GetString("wTcode");
                    return reVal;
                }

                if (dataGridView2.Rows[0].Cells["dgv2_NM"].Value != null)
                {
                    if (dataGridView2.Rows[0].Cells["dgv2_NM"].Value.ToString() == "")
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
                logs.SaveLog("[error]  (page)::FrmCodeTMainDB.cs  (Function)::ChkDgv2Param  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
            M_WsCodeTMainDB.WsCodeTMainDB wSvc = null;
            string reCode = "";
            string reMsg = "";
            string reData = "";
            M_WsCodeTMainDB.DataCodeTSub[] getData = null;

            //_formCodeT.btnSearch_Click
            try
            {
                wSvc = new M_WsCodeTMainDB.WsCodeTMainDB();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/CodeT/WsCodeTMainDB.svc";
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

                if (btnSave.Text == wRM.GetString("wApply"))
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (dataGridView1.Rows[i].Cells["dgv1_CHK"].Value != null)
                        {
                            if (dataGridView1.Rows[i].Cells["dgv1_CHK"].Value.ToString() == "1")
                            {
                                string[] param = new string[9];

                                param[0] = dataGridView1.Rows[i].Cells["dgv1_TCODE"].Value.ToString();
                                param[1] = dataGridView1.Rows[i].Cells["dgv1_TTYPE_SCD"].Value.ToString();
                                param[2] = dataGridView1.Rows[i].Cells["dgv1_NM"].Value.ToString();
                                param[3] = dataGridView1.Rows[i].Cells["dgv1_REQUIRED_FLAG"].Value.ToString();
                                param[4] = dataGridView1.Rows[i].Cells["dgv1_NUMERIC_FLAG"].Value.ToString();
                                param[5] = dataGridView1.Rows[i].Cells["dgv1_LIST_FLAG"].Value.ToString();
                                param[6] = AppInfo.SsLabNo;
                                param[7] = AppInfo.SsSiteCd;
                                param[8] = _formCodeTSite.getTgrpCcd();

                                reCode = wSvc.aCodeTSite(AppInfo.SsDbNm, param, out reMsg, out reData);
                                
                                if (reData == "2")
                                {
                                    MessageBox.Show(msgRM.GetString("msgAlreadyUsed"));
                                    return;
                                }
                                else
                                {
                                    if (dataGridView1.Rows[i].Cells["dgv1_TTYPE_SCD"].Value.ToString() == "Combobox")
                                    {
                                        reCode = wSvc.sCodeTSubTscode(param[0], out getData, out reMsg);
                                        if (reCode == "Y")
                                        {
                                            if (getData != null && getData.Length > 0)
                                            {
                                                for (int j = 0; j < getData.Length; j++)
                                                {
                                                    string[] paramSub = new string[5];

                                                    paramSub[0] = param[0];
                                                    paramSub[1] = getData[j].TSCODE.ToString();
                                                    paramSub[2] = getData[j].TSCODE_NM.ToString();
                                                    paramSub[3] = AppInfo.SsLabNo;
                                                    paramSub[4] = AppInfo.SsSiteCd;

                                                    reCode = wSvc.aCodeTSubSite(AppInfo.SsDbNm, paramSub, out reMsg, out reData);

                                                }
                                            }
                                        }
                                    }
                                    if (reCode == "Y" && reData != "" && reData != "2")
                                        reCnt += Convert.ToInt16(reData);
                                }
                            }
                        }
                    }
                    if (reCnt > 0)
                        MessageBox.Show(wRM.GetString("wSave") + " " + wRM.GetString("wSuccess") + " : " + reCnt.ToString());
                    else
                        MessageBox.Show(wRM.GetString("wSave") + " " + wRM.GetString("wFail"));

                    _formCodeTSite.Popup_End();
                    SetDataBind_gridView1(_codeGrp, _code);
                }
                else if (_codeGrp == "1")
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (dataGridView1.Rows[i].Cells["dgv1_CHK"].Value != null)
                        {
                            if (dataGridView1.Rows[i].Cells["dgv1_CHK"].Value.ToString() == "1")
                            {
                                string tcode_val = dataGridView1.Rows[i].Cells["dgv1_TCODE"].Value.ToString();
                                string listFlag_val = dataGridView1.Rows[i].Cells["dgv1_LIST_FLAG"].Value.ToString();
                                string requiredFlag_val = dataGridView1.Rows[i].Cells["dgv1_REQUIRED_FLAG"].Value.ToString();
                                string numericFlag_val = dataGridView1.Rows[i].Cells["dgv1_NUMERIC_FLAG"].Value.ToString();

                                reCode = wSvc.mCodeT(tcode_val, listFlag_val, requiredFlag_val, numericFlag_val, out reMsg, out reData);

                                if (reCode == "Y" && reData != "")
                                    reCnt += Convert.ToInt16(reData);
                            }
                        }
                    }
                    if (reCnt > 0)
                        MessageBox.Show(wRM.GetString("wSave") + " " + wRM.GetString("wSuccess") + " : " + reCnt.ToString());
                    else
                        MessageBox.Show(wRM.GetString("wSave") + " " + wRM.GetString("wFail"));

                    SetDataBind_gridView1(_codeGrp, _code);
                }



            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmCodeTMainDB.cs  (Function)::btnSave_Click  (Detail):: " + "\r\n" + ex.ToString(), "Error");

            }
            finally
            {
                if (wSvc != null)
                    wSvc.Dispose();
            }
        }

     
    }
}

