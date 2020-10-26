using EldigmPlusApp.Config;
using Framework.Log;
using System;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Threading;
using System.Windows.Forms;

namespace EldigmPlusApp.SubForm.Sys.Menu
{
    public partial class FrmMenuMainDB : Form
    {
        LogUtil logs = null;
        ResourceManager wRM = null;
        ResourceManager msgRM = null;

        string _codeGrp = "";
        string _tMenuCd = "";
        string _sMenuCd = "";

        public FrmMenuMainDB()
        {
            // Sets the UI culture
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(AppInfo.SsLanguage);
            this.AutoScaleMode = AutoScaleMode.Dpi;

            InitializeComponent();

            try
            {
                logs = new LogUtil();
                wRM = new ResourceManager("EldigmPlusApp.GlobalLanguage.word_Language", typeof(FrmMenuMainDB).Assembly);
                msgRM = new ResourceManager("EldigmPlusApp.GlobalLanguage.msg_Language", typeof(FrmMenuMainDB).Assembly);

                //btnSearch.Text = wRM.GetString("lngSearch");
                btnSave.Text = wRM.GetString("wSave");

                dataGridView1.Columns["dgv1_CHK"].HeaderText = wRM.GetString("wSelect");
                dataGridView1.Columns["dgv1_MENU_CD"].HeaderText = wRM.GetString("wMenu") + wRM.GetString("wCode");
                dataGridView1.Columns["dgv1_SUB_MENU_CD"].HeaderText = wRM.GetString("wSub") + wRM.GetString("wMenu") + wRM.GetString("wCode");
                dataGridView1.Columns["dgv1_TOP_MENU_CD"].HeaderText = wRM.GetString("wTop") + wRM.GetString("wMenu") + wRM.GetString("wCode");
                dataGridView1.Columns["dgv1_NM"].HeaderText = wRM.GetString("wName");
                dataGridView1.Columns["dgv1_APP_FLAG"].HeaderText = wRM.GetString("wApp") + wRM.GetString("wUse");
                dataGridView1.Columns["dgv1_USING_FLAG"].HeaderText = wRM.GetString("wUse");
                dataGridView1.Columns["dgv1_SORT_NO"].HeaderText = wRM.GetString("wSort");
                dataGridView1.Columns["dgv1_MENU_PATH"].HeaderText = wRM.GetString("wFile") + wRM.GetString("wPath");
                dataGridView1.Columns["dgv1_FILE_FOLDER"].HeaderText = wRM.GetString("wFile") + wRM.GetString("wFolder");

                dataGridView2.Columns["dgv2_MENU_CD"].HeaderText = "*" + wRM.GetString("wMenu") + wRM.GetString("wCode");
                dataGridView2.Columns["dgv2_NM"].HeaderText = "*" + wRM.GetString("wName");
                dataGridView2.Columns["dgv2_SORT_NO"].HeaderText = wRM.GetString("wSort");
                dataGridView2.Columns["dgv2_MENU_PATH"].HeaderText = wRM.GetString("wFile") + wRM.GetString("wPath");
                dataGridView2.Columns["dgv2_FILE_FOLDER"].HeaderText = wRM.GetString("wFile") + wRM.GetString("wFolder");

                dataGridView2.Columns["dgv2_MENU_CD"].HeaderCell.Style.ForeColor = Color.Maroon; // 헤더 필수 항목 빨강색
                dataGridView2.Columns["dgv2_NM"].HeaderCell.Style.ForeColor = Color.Maroon; // 헤더 필수 항목 빨강색

                Control.CheckForIllegalCrossThreadCalls = false;

                this.BackColor = Color.WhiteSmoke;

                splitContainer1.Panel1.BackColor = Color.LightSteelBlue;

                Class.Common.DatagrideViewStyleSet dvSet = new Class.Common.DatagrideViewStyleSet();
                dvSet.setStyle(dataGridView1, false, false);
                dvSet.setStyle(dataGridView2, false, false);

                lblName.BackColor = Color.FromArgb(204, 219, 243);
                this.panel2.Paint += new PaintEventHandler(this.paint_Purple1);
                SetDataBind_grideView2();
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmMenuMainDB.cs  (Function)::FrmMenuMainDB  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        #region __ panel2 paint_Purple1
        private void paint_Purple1(object sender, PaintEventArgs e)
        {
            Class.UI.PanelPaint pp = new Class.UI.PanelPaint();
            pp.paint_PanelPurple1(sender, e);
        }
        #endregion

        private void FrmMenuMainDB_Load(object sender, EventArgs e)
        {
            try
            {
                SetDataBind_treeView1();
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmMenuMainDB.cs  (Function)::FrmMenuMainDB_Load  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }


        private void SetDataBind_treeView1()
        {
            treeView1.Nodes.Clear();

            M_WsMenuMainDB.WsMenuMainDB wSvc = null;
            string reCode = "";
            string reMsg = "";
            M_WsMenuMainDB.DataMenuTop[] getData1 = null;
            M_WsMenuMainDB.DataMenuSub[] getData2 = null;
            try
            {
                wSvc = new M_WsMenuMainDB.WsMenuMainDB();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/Menu/WsMenuMainDB.svc";
                wSvc.Timeout = 1000;

                ImageList myimageList = new ImageList();
                myimageList.Images.Add(Image.FromFile(@"Image\treeicon1.png"));

                treeView1.ImageList = myimageList;
                treeView1.ImageIndex = 0;

                reCode = wSvc.sMenuTopTreeView(out getData1, out reMsg);
                if (reCode == "Y")
                {
                    if (getData1 != null && getData1.Length > 0)
                    {
                        for (int i = 0; i < getData1.Length; i++)
                        {
                            string tmenuCd_val = getData1[i].TOP_MENU_CD.ToString();
                            string tmenuNm_val = getData1[i].TOP_MENU_NM.ToString();

                            TreeNode root = new TreeNode();
                            root.Tag = "1-" + tmenuCd_val + "-0";
                            root.Text = tmenuNm_val;

                            reCode = wSvc.sMenuSubTreeView(tmenuCd_val, out getData2, out reMsg);
                            if (reCode == "Y")
                            {
                                if (getData2 != null && getData2.Length > 0)
                                {
                                    for (int j = 0; j < getData2.Length; j++)
                                    {
                                        string smenuCd_val = getData2[j].SUB_MENU_CD.ToString();
                                        string smenuNm_val = getData2[j].SUB_MENU_NM.ToString();

                                        TreeNode node2 = new TreeNode();
                                        node2.Tag = "2-" + tmenuCd_val + "-" + smenuCd_val;
                                        node2.Text = smenuNm_val;

                                        root.Nodes.Add(node2);

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
                logs.SaveLog("[error]  (page)::FrmMenuMainDB.cs  (Function)::SetDataBind_treeView1  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
                _tMenuCd = codeArr[1].ToString();
                _sMenuCd = codeArr[2].ToString();

                SetDataBind_gridView1(_codeGrp, _tMenuCd, _sMenuCd);

            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmMenuMainDB.cs  (Function)::treeView1_AfterSelect  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        private void SetDataBind_gridView1(string code_grp, string tmenuCd, string smenuCd)
        {
            SetDataBind_grideView2();

            M_WsMenuMainDB.WsMenuMainDB wSvc = null;
            string reCode = "";
            string reMsg = "";
            M_WsMenuMainDB.DataMenuSub[] getData2 = null;
            M_WsMenuMainDB.DataMenu[] getData3 = null;

            try
            {
                wSvc = new M_WsMenuMainDB.WsMenuMainDB();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/Menu/WsMenuMainDB.svc";
                wSvc.Timeout = 1000;

                if (code_grp == "1")
                {
                    dataGridView1.Columns["dgv1_APP_FLAG"].Visible = false;
                    dataGridView1.Columns["dgv1_MENU_CD"].Visible = false;
                    dataGridView2.Columns["dgv2_MENU_CD"].Visible = false;
                    dataGridView1.Columns["dgv1_MENU_PATH"].Visible = false;
                    dataGridView1.Columns["dgv1_FILE_FOLDER"].Visible = false;
                    dataGridView2.Columns["dgv2_MENU_PATH"].Visible = false;
                    dataGridView2.Columns["dgv2_FILE_FOLDER"].Visible = false;

                    dataGridView1.Columns["dgv1_TOP_MENU_CD"].ReadOnly = true;
                    dataGridView1.Columns["dgv1_SUB_MENU_CD"].ReadOnly = true;
                    dataGridView1.Columns["dgv1_NM"].ReadOnly = true;

                    reCode = wSvc.sMenuSubTreeView(tmenuCd, out getData2, out reMsg);
                    if (reCode == "Y")
                    {
                        if (getData2 != null && getData2.Length > 0)
                        {
                            dataGridView1.Rows.Clear();
                            for (int i = 0; i < getData2.Length; i++)
                            {
                                dataGridView1.Rows.Add();
                                dataGridView1.Rows[i].Cells["dgv1_SUB_MENU_CD"].Value = getData2[i].SUB_MENU_CD.ToString();
                                dataGridView1.Rows[i].Cells["dgv1_TOP_MENU_CD"].Value = getData2[i].TOP_MENU_CD.ToString();
                                dataGridView1.Rows[i].Cells["dgv1_NM"].Value = getData2[i].SUB_MENU_NM.ToString();
                                dataGridView1.Rows[i].Cells["dgv1_USING_FLAG"].Value = getData2[i].USING_FLAG.ToString();
                                dataGridView1.Rows[i].Cells["dgv1_SORT_NO"].Value = getData2[i].SORT_NO.ToString();
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
                else if (code_grp == "2")
                {
                    dataGridView1.Columns["dgv1_APP_FLAG"].Visible = false;
                    dataGridView1.Columns["dgv1_MENU_CD"].Visible = true;
                    dataGridView2.Columns["dgv2_MENU_CD"].Visible = true;
                    dataGridView1.Columns["dgv1_MENU_PATH"].Visible = true;
                    dataGridView1.Columns["dgv1_FILE_FOLDER"].Visible = true;
                    dataGridView2.Columns["dgv2_MENU_PATH"].Visible = true;
                    dataGridView2.Columns["dgv2_FILE_FOLDER"].Visible = true;

                    dataGridView1.Columns["dgv1_TOP_MENU_CD"].ReadOnly = true;
                    dataGridView1.Columns["dgv1_SUB_MENU_CD"].ReadOnly = true;
                    dataGridView1.Columns["dgv1_MENU_CD"].ReadOnly = true;
                    dataGridView2.Columns["dgv2_MENU_CD"].ReadOnly = false;
                    dataGridView1.Columns["dgv1_NM"].ReadOnly = true;


                    reCode = wSvc.sMenuTreeView(tmenuCd, smenuCd, out getData3, out reMsg);
                    if (reCode == "Y")
                    {
                        if (getData3 != null && getData3.Length > 0)
                        {
                            dataGridView1.Rows.Clear();

                            for (int i = 0; i < getData3.Length; i++)
                            {
                                dataGridView1.Rows.Add();
                                dataGridView1.Rows[i].Cells["dgv1_MENU_CD"].Value = getData3[i].MENU_CD.ToString();
                                dataGridView1.Rows[i].Cells["dgv1_TOP_MENU_CD"].Value = getData3[i].TOP_MENU_CD.ToString();
                                dataGridView1.Rows[i].Cells["dgv1_SUB_MENU_CD"].Value = getData3[i].SUB_MENU_CD.ToString();
                                dataGridView1.Rows[i].Cells["dgv1_NM"].Value = getData3[i].MENU_NM.ToString();
                                dataGridView1.Rows[i].Cells["dgv1_USING_FLAG"].Value = getData3[i].USING_FLAG.ToString();
                                dataGridView1.Rows[i].Cells["dgv1_SORT_NO"].Value = getData3[i].SORT_NO.ToString();
                                dataGridView1.Rows[i].Cells["dgv1_MENU_PATH"].Value = getData3[i].MENU_PATH.ToString();
                                dataGridView1.Rows[i].Cells["dgv1_FILE_FOLDER"].Value = getData3[i].FILE_FOLDER.ToString();
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

            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmMenuMainDB.cs  (Function)::SetDataBind_gridView1  (Detail)::code_grp=[" + code_grp + "], tmenuCd=[" + tmenuCd + "], smenuCd=[" + smenuCd + "]", "Error");
                logs.SaveLog("[error]  (page)::FrmMenuMainDB.cs  (Function)::SetDataBind_gridView1  (Detail)::reMsg=[" + reMsg + "]", "Error");
                logs.SaveLog("[error]  (page)::FrmMenuMainDB.cs  (Function)::SetDataBind_gridView1  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
                logs.SaveLog("[error]  (page)::FrmMenuMainDB.cs  (Function)::dataGridView1_CellBeginEdit  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
                logs.SaveLog("[error]  (page)::FrmMenuMainDB.cs  (Function)::dataGridView1_ColumnHeaderMouseClick  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
                logs.SaveLog("[error]  (page)::FrmMenuMainDB.cs  (Function)::dataGridView1_DataBindingComplete  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            M_WsMenuMainDB.WsMenuMainDB wSvc = null;
            string reCode = "";
            string reMsg = "";
            string reData = "";

            string colNm = dataGridView2.Columns[e.ColumnIndex].Name;

            if (colNm == "dgv2_BTNADD")
            {
                if (_codeGrp == "1")
                {
                    string reVal = ChkDgv2ParamSubMenu();

                    if (reVal != "")
                        MessageBox.Show(wRM.GetString("wCheck") + " :: " + reVal);
                    else
                    {
                        string Nm_val = dataGridView2.Rows[0].Cells["dgv2_NM"].Value.ToString();
                        string sortNo_val = "1";
                        if (dataGridView2.Rows[0].Cells["dgv2_SORT_NO"].Value != null)
                            sortNo_val = dataGridView2.Rows[0].Cells["dgv2_SORT_NO"].Value.ToString();

                        string pInputId = "1";

                        try
                        {
                            wSvc = new M_WsMenuMainDB.WsMenuMainDB();
                            wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/Menu/WsMenuMainDB.svc";
                            wSvc.Timeout = 1000;

                            reCode = wSvc.exMenuSub(_sMenuCd, _tMenuCd, Nm_val, out reMsg, out reData);
                            if (reCode == "Y" && reData != "0")
                            {
                                MessageBox.Show(msgRM.GetString("msgDuplicated"));
                            }
                            else
                            {
                                reCode = "";
                                reCode = wSvc.aMenuSub(_tMenuCd, Nm_val, "1", sortNo_val, pInputId, out reMsg, out reData);

                                int reCnt = 0;

                                if (reCode == "Y" && reData != "")
                                    reCnt = Convert.ToInt16(reData);

                                if (reCnt > 0)
                                    MessageBox.Show(wRM.GetString("wSave") + " " + wRM.GetString("wSuccess") + " : " + reCnt.ToString());
                                else
                                    MessageBox.Show(wRM.GetString("wSave") + " " + wRM.GetString("wFail"));

                                SetDataBind_gridView1(_codeGrp, _tMenuCd, _sMenuCd);

                            }

                        }
                        catch (Exception ex)
                        {
                            logs.SaveLog("[error]  (page)::FrmMenuMainDB.cs  (Function)::dataGridView2_CellClick  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
                    string reVal = ChkDgv2ParamMenu();

                    if (reVal != "")
                        MessageBox.Show(wRM.GetString("wCheck") + " :: " + reVal);
                    else
                    {
                        string menuCd_val = dataGridView2.Rows[0].Cells["dgv2_MENU_CD"].Value.ToString();
                        string Nm_val = dataGridView2.Rows[0].Cells["dgv2_NM"].Value.ToString();

                        string sortNo_val = "1";
                        if (dataGridView2.Rows[0].Cells["dgv2_SORT_NO"].Value != null)
                            sortNo_val = dataGridView2.Rows[0].Cells["dgv2_SORT_NO"].Value.ToString();

                        string menuPath_val = "";
                        if (dataGridView2.Rows[0].Cells["dgv2_MENU_PATH"].Value != null)
                            menuPath_val = dataGridView2.Rows[0].Cells["dgv2_MENU_PATH"].Value.ToString();

                        string fileFolder_val = "";
                        if (dataGridView2.Rows[0].Cells["dgv2_FILE_FOLDER"].Value != null)
                            fileFolder_val = dataGridView2.Rows[0].Cells["dgv2_FILE_FOLDER"].Value.ToString();

                        string pInputId = "1";

                        try
                        {
                            wSvc = new M_WsMenuMainDB.WsMenuMainDB();
                            wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/Menu/WsMenuMainDB.svc";
                            wSvc.Timeout = 1000;

                            reCode = wSvc.exMenu(menuCd_val, _tMenuCd, _sMenuCd, out reMsg, out reData);
                            if (reCode == "Y" && reData != "0")
                            {
                                MessageBox.Show(msgRM.GetString("msgDuplicated"));
                            }
                            else
                            {
                                reCode = "";
                                reCode = wSvc.aMenu(_tMenuCd, _sMenuCd, menuCd_val, Nm_val, "1", sortNo_val, menuPath_val, fileFolder_val, pInputId, out reMsg, out reData);

                                int reCnt = 0;

                                if (reCode == "Y" && reData != "")
                                    reCnt = Convert.ToInt16(reData);

                                if (reCnt > 0)
                                    MessageBox.Show(wRM.GetString("wSave") + " " + wRM.GetString("wSuccess") + " : " + reCnt.ToString());
                                else
                                    MessageBox.Show(wRM.GetString("wSave") + " " + wRM.GetString("wFail"));

                                SetDataBind_gridView1(_codeGrp, _tMenuCd, _sMenuCd);

                            }

                        }
                        catch (Exception ex)
                        {
                            logs.SaveLog("[error]  (page)::FrmMenuMainDB.cs  (Function)::dataGridView2_CellClick  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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

        private string ChkDgv2ParamSubMenu()
        {
            string reVal = "";
            try
            {
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
                logs.SaveLog("[error]  (page)::FrmMenuMainDB.cs  (Function)::ChkDgv2ParamSubMenu  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }

            return reVal;
        }

        private string ChkDgv2ParamMenu()
        {
            string reVal = "";

            try
            {
                if (dataGridView2.Rows[0].Cells["dgv2_MENU_CD"].Value != null)
                {
                    if (dataGridView2.Rows[0].Cells["dgv2_MENU_CD"].Value.ToString() == "")
                    {
                        reVal = wRM.GetString("wMenu") + wRM.GetString("wCode");
                        return reVal;
                    }
                }
                else
                {
                    reVal = wRM.GetString("wMenu") + wRM.GetString("wCode");
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
                logs.SaveLog("[error]  (page)::FrmMenuMainDB.cs  (Function)::ChkDgv2ParamMenu  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
            M_WsMenuMainDB.WsMenuMainDB wSvc = null;
            string reCode = "";
            string reMsg = "";
            string reData = "";

            try
            {
                wSvc = new M_WsMenuMainDB.WsMenuMainDB();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/Menu/WsMenuMainDB.svc";
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

                if (_codeGrp == "1")
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (dataGridView1.Rows[i].Cells["dgv1_CHK"].Value != null)
                        {
                            if (dataGridView1.Rows[i].Cells["dgv1_CHK"].Value.ToString() == "1")
                            {

                                string sMenuCd_val = dataGridView1.Rows[i].Cells["dgv1_SUB_MENU_CD"].Value.ToString();
                                string usingFlag_val = dataGridView1.Rows[i].Cells["dgv1_USING_FLAG"].Value.ToString();

                                string sortNo_val = "1";
                                if (dataGridView1.Rows[i].Cells["dgv1_SORT_NO"].Value != null)
                                    sortNo_val = dataGridView1.Rows[i].Cells["dgv1_SORT_NO"].Value.ToString();

                                reCode = wSvc.mMenuSub(_tMenuCd, sMenuCd_val, usingFlag_val, sortNo_val, out reMsg, out reData);

                                if (reCode == "Y" && reData != "")
                                    reCnt += Convert.ToInt16(reData);
                            }
                        }
                    }
                    if (reCnt > 0)
                        MessageBox.Show(wRM.GetString("wSave") + " " + wRM.GetString("wSuccess") + " : " + reCnt.ToString());
                    else
                        MessageBox.Show(wRM.GetString("wSave") + " " + wRM.GetString("wFail"));

                    SetDataBind_gridView1(_codeGrp, _tMenuCd, _sMenuCd);
                }

                if (_codeGrp == "2")
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (dataGridView1.Rows[i].Cells["dgv1_CHK"].Value != null)
                        {
                            if (dataGridView1.Rows[i].Cells["dgv1_CHK"].Value.ToString() == "1")
                            {
                                string menuCd_val = dataGridView1.Rows[i].Cells["dgv1_MENU_CD"].Value.ToString();
                                string usingFlag_val = dataGridView1.Rows[i].Cells["dgv1_USING_FLAG"].Value.ToString();

                                string sortNo_val = "1";
                                if (dataGridView1.Rows[i].Cells["dgv1_SORT_NO"].Value != null)
                                    sortNo_val = dataGridView1.Rows[i].Cells["dgv1_SORT_NO"].Value.ToString();

                                string menuPath_val = "";
                                if (dataGridView1.Rows[i].Cells["dgv1_MENU_PATH"].Value != null)
                                    menuPath_val = dataGridView1.Rows[i].Cells["dgv1_MENU_PATH"].Value.ToString();

                                string fileFolder_val = "";
                                if (dataGridView1.Rows[i].Cells["dgv1_FILE_FOLDER"].Value != null)
                                    fileFolder_val = dataGridView1.Rows[i].Cells["dgv1_FILE_FOLDER"].Value.ToString();

                                reCode = wSvc.mMenu(_tMenuCd, _sMenuCd, menuCd_val, usingFlag_val, sortNo_val, menuPath_val, fileFolder_val, out reMsg, out reData);

                                if (reCode == "Y" && reData != "")
                                    reCnt += Convert.ToInt16(reData);
                            }
                        }
                    }
                    if (reCnt > 0)
                        MessageBox.Show(wRM.GetString("wSave") + " " + wRM.GetString("wSuccess") + " : " + reCnt.ToString());
                    else
                        MessageBox.Show(wRM.GetString("wSave") + " " + wRM.GetString("wFail"));

                    SetDataBind_gridView1(_codeGrp, _tMenuCd, _sMenuCd);

                }


            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmMenuMainDB.cs  (Function)::btnSave_Click  (Detail):: " + "\r\n" + ex.ToString(), "Error");

            }
            finally
            {
                if (wSvc != null)
                    wSvc.Dispose();
            }
        }

     

    }
}

