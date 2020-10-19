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
        ResourceManager lngRM = null;
        ResourceManager msgRM = null;

        string _topMenuCd = "";
        string[] codeArr = { "2", "1", "0", "0" };
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
                lngRM = new ResourceManager("EldigmPlusApp.strLanguage", typeof(FrmMenuSetAuthSite).Assembly);
                msgRM = new ResourceManager("EldigmPlusApp.msgLanguage", typeof(FrmMenuSetAuthSite).Assembly);

                //btnSearch.Text = lngRM.GetString("lngSearch");
                btnSave.Text = "저장";

                dataGridView1.Columns["dgv1_CHK"].HeaderText = "선택";
                dataGridView1.Columns["dgv1_MENU_CD"].HeaderText = "메뉴코드";
                dataGridView1.Columns["dgv1_NM"].HeaderText = "이름";
                dataGridView1.Columns["dgv1_VIEW_FLAG"].HeaderText = "보기";
                dataGridView1.Columns["dgv1_NEW_FLAG"].HeaderText = "추가";
                dataGridView1.Columns["dgv1_MODIFY_FLAG"].HeaderText = "수정";
                dataGridView1.Columns["dgv1_DEL_FLAG"].HeaderText = "삭제";
                dataGridView1.Columns["dgv1_REPORT_FLAG"].HeaderText = "보고서";
                dataGridView1.Columns["dgv1_PRINT_FLAG"].HeaderText = "프린트";
                dataGridView1.Columns["dgv1_DOWNLOAD_FLAG"].HeaderText = "다운로드";

                //dataGridView2.Columns["dgv2_MENU_CD"].HeaderCell.Style.ForeColor = Color.Maroon; // 헤더 필수 항목 빨강색
                //dataGridView2.Columns["dgv2_SUB_MENU_CD"].HeaderCell.Style.ForeColor = Color.Maroon; // 헤더 필수 항목 빨강색
                //dataGridView2.Columns["dgv2_TOP_MENU_CD"].HeaderCell.Style.ForeColor = Color.Maroon; // 헤더 필수 항목 빨강색

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

                //TreeNode root = new TreeNode();
                //root.Tag = "";
                //root.Text = "전체";

                //reCode = wSvc.sMenuTopTreeView(out getData1, out reMsg);
                //if (reCode == "Y")
                //{
                //    if (getData1 != null && getData1.Length > 0)
                //    {
                //        for (int i = 0; i < getData1.Length; i++)
                //        {
                //            string tmenuCd_val = getData1[i].TOP_MENU_CD.ToString();
                //            string tmenuNm_val = getData1[i].TOP_MENU_NM.ToString();

                //            TreeNode root = new TreeNode();
                //            root.Tag = "2-" + tmenuCd_val + "-0" + "-0";
                //            root.Text = tmenuNm_val;

                //root.Nodes.Add(node1);
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
                            node2.Tag = "3-" + tmenuCd_val + "-" + smenuCd_val + "-0";
                            node2.Text = smenuNm_val;

                            treeView1.Nodes.Add(node2);

                        }
                    }
                }

                if (treeView1.Nodes.Count > 0)
                    treeView1.SelectedNode = treeView1.GetNodeAt(0, 0);

                //}
                treeView1.ExpandAll();
                //        }
                //    }


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

                codeArr = eNodeTag.Split('-');

                string codeGrp = codeArr[0].ToString();
                string tMenuCd = codeArr[1].ToString();
                string sMenuCd = codeArr[2].ToString();
                string menuCd = codeArr[3].ToString();

                if (tMenuCd == "0")
                {
                    tMenuCd = null;
                }
                if (sMenuCd == "0")
                {
                    sMenuCd = null;
                }
                if (menuCd == "0")
                {
                    menuCd = null;
                }

                //SetDataBind_gridView1(codeArr[0].ToString(), codeArr[1].ToString(), codeArr[2].ToString(), codeArr[3].ToString());
                SetDataBind_gridView1(codeGrp, tMenuCd, sMenuCd, menuCd);

            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmMenuSetAuthSite.cs  (Function)::treeView1_AfterSelect  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        private void SetDataBind_gridView1(string code_grp, string tmenuCd, string smenuCd, string menuCd)
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

                if (code_grp == "3")
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
                logs.SaveLog("[error]  (page)::FrmMenuSetAuthSite.cs  (Function)::SetDataBind_gridView1  (Detail)::pScodeGrp=[" + _topMenuCd + "]", "Error");
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
            string codeGrp = codeArr[0].ToString();
            string tMenuCd = codeArr[1].ToString();
            string sMenuCd = codeArr[2].ToString();
            string menuCd = codeArr[3].ToString();

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
                    MessageBox.Show("선택된 데이터가 없습니다.");
                    return;
                }

                reCnt = 0;
                int reCnt2 = 0;
                //int reCnt3 = 0;

                if (codeGrp == "3")
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

                    MessageBox.Show("성공" + "[" + reCnt.ToString() + "], " + "실패" + "[" + reCnt2.ToString() + "]");
                    SetDataBind_gridView1(codeGrp, tMenuCd, sMenuCd, menuCd);

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

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == '\r')
            //{
            //    btnSearch_Click(null, null);
            //}
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //SetDataBind_gridView1("", "", "", "");
        }

        private void cmbSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            string codeGrp = codeArr[0].ToString();
            string tMenuCd = codeArr[1].ToString();
            string sMenuCd = codeArr[2].ToString();
            string menuCd = codeArr[3].ToString();
            SetDataBind_gridView1(codeGrp, tMenuCd, sMenuCd, menuCd);
        }

        private void cmbMenuTop_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDataBind_treeView1();
            string codeGrp = codeArr[0].ToString();
            string tMenuCd = codeArr[1].ToString();
            string sMenuCd = codeArr[2].ToString();
            string menuCd = codeArr[3].ToString();
            SetDataBind_gridView1(codeGrp, tMenuCd, sMenuCd, menuCd);
        }
    }
}

