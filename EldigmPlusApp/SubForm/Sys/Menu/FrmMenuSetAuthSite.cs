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
    public partial class FrmMenuSetAuthSite : Form
    {
        LogUtil logs = null;
        ResourceManager wRM = null;
        ResourceManager msgRM = null;

        string _codeGrp = "";
        string _tMenuCd = "";
        string _sMenuCd = "";
        string _dbNm = "";

        public FrmMenuSetAuthSite()
        {
            // Sets the UI culture
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(AppInfo.SsLanguage);
            this.AutoScaleMode = AutoScaleMode.Dpi;

            InitializeComponent();

            try
            {
                logs = new LogUtil();
                wRM = new ResourceManager("EldigmPlusApp.GlobalLanguage.word_Language", typeof(FrmMenuSetAuthSite).Assembly);
                msgRM = new ResourceManager("EldigmPlusApp.GlobalLanguage.msg_Language", typeof(FrmMenuSetAuthSite).Assembly);

                btnSave.Text = wRM.GetString("wSave");

                dataGridView1.Columns["dgv1_CHK"].HeaderText = wRM.GetString("wSelect");
                dataGridView1.Columns["dgv1_MENU_CD"].HeaderText = wRM.GetString("wMenu") + wRM.GetString("wCode");
                dataGridView1.Columns["dgv1_NM"].HeaderText = wRM.GetString("wName");
                dataGridView1.Columns["dgv1_VIEW_FLAG"].HeaderText = wRM.GetString("wView");
                dataGridView1.Columns["dgv1_NEW_FLAG"].HeaderText = wRM.GetString("wAdd");
                dataGridView1.Columns["dgv1_MODIFY_FLAG"].HeaderText = wRM.GetString("wModify");
                dataGridView1.Columns["dgv1_DEL_FLAG"].HeaderText = wRM.GetString("wDelete");
                dataGridView1.Columns["dgv1_REPORT_FLAG"].HeaderText = wRM.GetString("wReport");
                dataGridView1.Columns["dgv1_PRINT_FLAG"].HeaderText = wRM.GetString("wPrint");
                dataGridView1.Columns["dgv1_DOWNLOAD_FLAG"].HeaderText = wRM.GetString("wDownload");

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
                logs.SaveLog("[error]  (page)::FrmMenuSetAuthSite.cs  (Function)::FrmMenuSetAuthSite  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        #region __ panel2 paint_Purple1
        private void paint_Purple1(object sender, PaintEventArgs e)
        {
            Class.UI.PanelPaint pp = new Class.UI.PanelPaint();
            pp.paint_PanelPurple1(sender, e);
        }
        #endregion

        private void FrmMenuSetAuthSite_Load(object sender, EventArgs e)
        {
            try
            {
                GetDbNm();
                SetDataBind_CmbSite();
                SetDataBind_CmbMenuTop();
                SetDataBind_treeView1();
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmMenuSetAuthSite.cs  (Function)::FrmMenuSetAuthSite_Load  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }


        private void GetDbNm()
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


                reCode = wSvc.siteDbNm(AppInfo.SsSiteCd, out reData, out reMsg);

                if (reCode == "Y")
                {
                    if (!string.IsNullOrEmpty(reData))
                        _dbNm = reData;
                    //AppInfo.SsSiteCd = cmbSite.SelectedValue.ToString(); // CMBBOX에서 선택된 SITE_CD 값을 APPINFO.SsSiteCD에 담는다
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmMenuSetAuthSite.cs  (Function)::GetDbNm  (Detail)::reCode=[" + reCode + "], reMsg=[" + reMsg + "]", "Error");
                logs.SaveLog("[error]  (page)::FrmMenuSetAuthSite.cs  (Function)::GetDbNm  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (wSvc != null)
                    wSvc.Dispose();
            }
        }


        private void SetDataBind_CmbMenuTop()
        {
            M_WsMenuMainDB.WsMenuMainDB wSvc = null;
            string reCode = "";
            string reMsg = "";
            M_WsMenuMainDB.DataMenuTop[] getData1 = null;
            try
            {
                wSvc = new M_WsMenuMainDB.WsMenuMainDB();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/Menu/WsMenuMainDB.svc";
                wSvc.Timeout = 1000;

                reCode = wSvc.sMenuTopTreeView(out getData1, out reMsg);

                if (reCode == "Y")
                {
                    if (getData1 != null && getData1.Length > 0)
                    {
                        Class.Common.ComboBoxItemSet setCmb = null;

                        setCmb = new Class.Common.ComboBoxItemSet();
                        setCmb.AddColumn();

                        for (int i = 0; i < getData1.Length; i++)
                        {
                            string tmenuCd_val = getData1[i].TOP_MENU_CD.ToString();
                            string tmenuNm_val = getData1[i].TOP_MENU_NM.ToString();
                            setCmb.AddRow(getData1[i].TOP_MENU_NM.ToString(), getData1[i].TOP_MENU_CD.ToString());
                        }

                        setCmb.Bind(cmbMenuTop);
                    }
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmMenuSetAuthSite.cs  (Function)::SetDataBind_CmbMenuTop  (Detail):: " + "\r\n" + ex.ToString());
            }
        }

        private void SetDataBind_CmbSite()
        {
            M_WsMenuMainDB.WsMenuMainDB wSvc = null;
            string reCode = "";
            string reMsg = "";
            M_WsMenuMainDB.DataCodeAuthSiteMemberDB[] getData = null;
            try
            {
                wSvc = new M_WsMenuMainDB.WsMenuMainDB();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/Menu/WsMenuMainDB.svc";
                wSvc.Timeout = 1000;

                reCode = wSvc.sCodeAuthSiteMemberDB(_dbNm, out getData, out reMsg);
                if (reCode == "Y")
                {
                    if (getData != null && getData.Length > 0)
                    {
                        Class.Common.ComboBoxItemSet setCmb = null;

                        setCmb = new Class.Common.ComboBoxItemSet();
                        setCmb.AddColumn();

                        for (int i = 0; i < getData.Length; i++)
                        {
                            setCmb.AddRow(getData[i].AUTH_NM.ToString(), getData[i].AUTH_CD.ToString());
                        }

                        setCmb.Bind(cmbSite);
                    }
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmMenuSetAuthSite.cs  (Function)::SetDataBind_CmbSite  (Detail):: " + "\r\n" + ex.ToString());
            }
        }


        private void SetDataBind_treeView1()
        {
            treeView1.Nodes.Clear();

            M_WsMenuMainDB.WsMenuMainDB wSvc = null;
            string reCode = "";
            string reMsg = "";
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

                string tmenuCd_val = cmbMenuTop.SelectedValue.ToString();

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
                            node2.Tag = "1-" + tmenuCd_val + "-" + smenuCd_val;
                            node2.Text = smenuNm_val;

                            treeView1.Nodes.Add(node2);

                        }
                    }
                }

                if (treeView1.Nodes.Count > 0)
                    treeView1.SelectedNode = treeView1.GetNodeAt(0, 0);

                treeView1.ExpandAll();


            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmMenuSetAuthSite.cs  (Function)::SetDataBind_treeView1  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
                logs.SaveLog("[error]  (page)::FrmMenuSetAuthSite.cs  (Function)::treeView1_AfterSelect  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        private void SetDataBind_gridView1(string code_grp, string tmenuCd, string smenuCd)
        {
            M_WsMenuMainDB.WsMenuMainDB wSvc = null;
            string reCode = "";
            string reMsg = "";
            M_WsMenuMainDB.DataSetAuthSiteMemberDB[] getData = null;

            try
            {
                wSvc = new M_WsMenuMainDB.WsMenuMainDB();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/Menu/WsMenuMainDB.svc";
                wSvc.Timeout = 1000;

                if (code_grp == "1")
                {
                    reCode = wSvc.sSetAuthSiteMemberDB(_dbNm, AppInfo.SsSiteCd, tmenuCd, smenuCd, cmbSite.SelectedValue.ToString(), out getData, out reMsg);

                    if (reCode == "Y")
                    {
                        if (getData != null && getData.Length > 0)
                        {
                            dataGridView1.Rows.Clear();

                            for (int i = 0; i < getData.Length; i++)
                            {
                                dataGridView1.Rows.Add();
                                dataGridView1.Rows[i].Cells["dgv1_MENU_CD"].Value = getData[i].MENU_CD.ToString();
                                dataGridView1.Rows[i].Cells["dgv1_NM"].Value = getData[i].MENU_NM.ToString();
                                dataGridView1.Rows[i].Cells["dgv1_VIEW_FLAG"].Value = getData[i].VIEW_FLAG.ToString();
                                dataGridView1.Rows[i].Cells["dgv1_NEW_FLAG"].Value = getData[i].NEW_FLAG.ToString();
                                dataGridView1.Rows[i].Cells["dgv1_MODIFY_FLAG"].Value = getData[i].MODIFY_FLAG.ToString();
                                dataGridView1.Rows[i].Cells["dgv1_DEL_FLAG"].Value = getData[i].DEL_FLAG.ToString();
                                dataGridView1.Rows[i].Cells["dgv1_REPORT_FLAG"].Value = getData[i].REPORT_FLAG.ToString();
                                dataGridView1.Rows[i].Cells["dgv1_PRINT_FLAG"].Value = getData[i].PRINT_FLAG.ToString();
                                dataGridView1.Rows[i].Cells["dgv1_DOWNLOAD_FLAG"].Value = getData[i].DOWNLOAD_FLAG.ToString();
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
                logs.SaveLog("[error]  (page)::FrmMenuSetAuthSite.cs  (Function)::SetDataBind_gridView1  (Detail)::code_grp=[" + code_grp + "], tmenuCd=[" + tmenuCd + "], smenuCd=[" + smenuCd + "]", "Error");
                logs.SaveLog("[error]  (page)::FrmMenuSetAuthSite.cs  (Function)::SetDataBind_gridView1  (Detail)::reMsg=[" + reMsg + "]", "Error");
                logs.SaveLog("[error]  (page)::FrmMenuSetAuthSite.cs  (Function)::SetDataBind_gridView1  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
                logs.SaveLog("[error]  (page)::FrmMenuSetAuthSite.cs  (Function)::dataGridView1_CellBeginEdit  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        bool chkUseAll = false;
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                string columnNm = dataGridView1.Columns[e.ColumnIndex].Name;
                if (columnNm != "dgv1_MENU_CD" && columnNm != "dgv1_NM")
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (chkUseAll)
                            dataGridView1.Rows[i].Cells[columnNm].Value = "0";
                        else
                            dataGridView1.Rows[i].Cells[columnNm].Value = "1";
                        
                        if (columnNm != "dgv1_CHK" && columnNm != "dgv1_MENU_CD" && columnNm != "dgv1_NM")
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
                logs.SaveLog("[error]  (page)::FrmMenuSetAuthSite.cs  (Function)::dataGridView1_ColumnHeaderMouseClick  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SetRowNumber(dataGridView1);
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
                int reCnt2 = 0;

                if (_codeGrp == "1")
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (dataGridView1.Rows[i].Cells["dgv1_CHK"].Value != null)
                        {
                            if (dataGridView1.Rows[i].Cells["dgv1_CHK"].Value.ToString() == "1")
                            {
                                string menuCd_val = dataGridView1.Rows[i].Cells["dgv1_MENU_CD"].Value.ToString();
                                string viewFlag_val = dataGridView1.Rows[i].Cells["dgv1_VIEW_FLAG"].Value.ToString();
                                string newFlag_val = dataGridView1.Rows[i].Cells["dgv1_NEW_FLAG"].Value.ToString();
                                string modifyFlag_val = dataGridView1.Rows[i].Cells["dgv1_MODIFY_FLAG"].Value.ToString();
                                string delFlag_val = dataGridView1.Rows[i].Cells["dgv1_DEL_FLAG"].Value.ToString();
                                string reportFlag_val = dataGridView1.Rows[i].Cells["dgv1_REPORT_FLAG"].Value.ToString();
                                string printFlag_val = dataGridView1.Rows[i].Cells["dgv1_PRINT_FLAG"].Value.ToString();
                                string downloadFlag_val = dataGridView1.Rows[i].Cells["dgv1_DOWNLOAD_FLAG"].Value.ToString();
                                string pInputId = "1";
                                reCode = wSvc.mSetAuthSiteMemberDB(_dbNm, AppInfo.SsSiteCd, menuCd_val, cmbSite.SelectedValue.ToString(), viewFlag_val, newFlag_val, modifyFlag_val, delFlag_val, reportFlag_val, printFlag_val, downloadFlag_val, pInputId, out reMsg, out reData);

                                if (reCode == "Y")
                                {
                                    if (Convert.ToInt16(reData) < 1)
                                    {
                                            reCode = wSvc.aSetAuthSiteMemberDB(_dbNm, AppInfo.SsSiteCd, menuCd_val, cmbSite.SelectedValue.ToString(), viewFlag_val, newFlag_val, modifyFlag_val, delFlag_val, reportFlag_val, printFlag_val, downloadFlag_val, pInputId, out reMsg, out reData);
                                    }
                                    
                                }


                                if (reCode == "Y" && reData != "0")
                                {
                                    reCnt++;
                                }
                                else
                                    reCnt2++;

                            }
                        }
                    }

                    MessageBox.Show(wRM.GetString("wSuccess") + "[" + reCnt.ToString() + "], " + wRM.GetString("wFail") + "[" + reCnt2.ToString() + "]");
                    SetDataBind_gridView1(_codeGrp, _tMenuCd, _sMenuCd);

                }

            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmMenuSetAuthSite.cs  (Function)::btnSave_Click  (Detail):: " + "\r\n" + ex.ToString(), "Error");

            }
            finally
            {
                if (wSvc != null)
                    wSvc.Dispose();
            }
        }

        private void cmbSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDataBind_gridView1(_codeGrp, _tMenuCd, _sMenuCd);
        }

        private void cmbMenuTop_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDataBind_treeView1();
            SetDataBind_gridView1(_codeGrp, _tMenuCd, _sMenuCd);
        }
    }
}

