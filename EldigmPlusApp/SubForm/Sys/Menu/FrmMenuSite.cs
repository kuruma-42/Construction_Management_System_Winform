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
    public partial class FrmMenuSite : Form
    {
        LogUtil logs = null;
        ResourceManager lngRM = null;
        ResourceManager msgRM = null;

        string _topMenuCd = "";
        string[] codeArr = { "2", "1", "0", "0" };

        public FrmMenuSite()
        {
            // Sets the UI culture
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(AppInfo.SsLanguage);
            this.AutoScaleMode = AutoScaleMode.Dpi;

            InitializeComponent();

            try
            {
                logs = new LogUtil();
                lngRM = new ResourceManager("EldigmPlusApp.strLanguage", typeof(FrmMenuSite).Assembly);
                msgRM = new ResourceManager("EldigmPlusApp.msgLanguage", typeof(FrmMenuSite).Assembly);

                //btnSearch.Text = lngRM.GetString("lngSearch");
                btnSave.Text = "저장";

                dataGridView1.Columns["dgv1_CHK"].HeaderText = "선택";
                dataGridView1.Columns["dgv1_MENU_CD"].HeaderText = "메뉴코드";
                dataGridView1.Columns["dgv1_SUB_MENU_CD"].HeaderText = "서브메뉴코드";
                dataGridView1.Columns["dgv1_TOP_MENU_CD"].HeaderText = "탑메뉴코드";
                dataGridView1.Columns["dgv1_NM"].HeaderText = "이름";
                dataGridView1.Columns["dgv1_APP_FLAG"].HeaderText = "앱사용";
                dataGridView1.Columns["dgv1_USING_FLAG"].HeaderText = "사용";
                dataGridView1.Columns["dgv1_SORT_NO"].HeaderText = "정렬";
                dataGridView1.Columns["dgv1_MENU_PATH"].HeaderText = "파일경로";
                dataGridView1.Columns["dgv1_FILE_FOLDER"].HeaderText = "파일폴더";
                dataGridView1.Columns["dgv1_MEMO"].HeaderText = "메모";

                dataGridView2.Columns["dgv2_MENU_CD"].HeaderText = "메뉴코드";
                dataGridView2.Columns["dgv2_SUB_MENU_CD"].HeaderText = "서브메뉴코드";
                dataGridView2.Columns["dgv2_TOP_MENU_CD"].HeaderText = "탑메뉴코드";
                dataGridView2.Columns["dgv2_NM"].HeaderText = "이름";
                dataGridView2.Columns["dgv2_SORT_NO"].HeaderText = "정렬";
                dataGridView2.Columns["dgv2_MENU_PATH"].HeaderText = "파일경로";
                dataGridView2.Columns["dgv2_FILE_FOLDER"].HeaderText = "파일폴더";

                //dataGridView2.Columns["dgv2_MENU_CD"].HeaderCell.Style.ForeColor = Color.Maroon; // 헤더 필수 항목 빨강색
                //dataGridView2.Columns["dgv2_SUB_MENU_CD"].HeaderCell.Style.ForeColor = Color.Maroon; // 헤더 필수 항목 빨강색
                //dataGridView2.Columns["dgv2_TOP_MENU_CD"].HeaderCell.Style.ForeColor = Color.Maroon; // 헤더 필수 항목 빨강색

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
                logs.SaveLog("[error]  (page)::FrmMenuSite.cs  (Function)::FrmMenuSite  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        #region __ panel2 paint_Purple1
        private void paint_Purple1(object sender, PaintEventArgs e)
        {
            Class.UI.PanelPaint pp = new Class.UI.PanelPaint();
            pp.paint_PanelPurple1(sender, e);
        }
        #endregion

        private void FrmMenuSite_Load(object sender, EventArgs e)
        {
            try
            {
                SetDataBind_CmbSite();
                SetDataBind_treeView1();
                GetDbNm();
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmMenuSite.cs  (Function)::FrmMenuSite_Load  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        private void SetDataBind_CmbSite()
        {
            M_WsMenuMainDB.WsMenuMainDB wSvc = null;
            string reCode = "";
            string reMsg = "";
            M_WsMenuMainDB.DataSiteMainDB[] getData = null;
            try
            {
                wSvc = new M_WsMenuMainDB.WsMenuMainDB();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/Menu/WsMenuMainDB.svc";
                wSvc.Timeout = 1000;

                reCode = wSvc.sSiteMainDB(AppInfo.SsMemcoCd, out getData, out reMsg);
                if (reCode == "Y")
                {
                    if (getData != null && getData.Length > 0)
                    {
                        Class.Common.ComboBoxItemSet setCmb = null;

                        setCmb = new Class.Common.ComboBoxItemSet();
                        setCmb.AddColumn();

                        for (int i = 0; i < getData.Length; i++)
                        {
                            setCmb.AddRow(getData[i].SITE_NM.ToString(), getData[i].SITE_CD.ToString());
                        }

                        setCmb.Bind(cmbSite);
                    }
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmMenuSite.cs  (Function)::SetDataBind_CmbSite  (Detail):: " + "\r\n" + ex.ToString());
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
                        AppInfo.SsDbNm = reData;
                    //AppInfo.SsSiteCd = cmbSite.SelectedValue.ToString(); // CMBBOX에서 선택된 SITE_CD 값을 APPINFO.SsSiteCD에 담는다
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmMenuSite.cs  (Function)::GetDbNm  (Detail)::reCode=[" + reCode + "], reMsg=[" + reMsg + "]", "Error");
                logs.SaveLog("[error]  (page)::FrmMenuSite.cs  (Function)::GetDbNm  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (wSvc != null)
                    wSvc.Dispose();
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

                //TreeNode root = new TreeNode();
                //root.Tag = "";
                //root.Text = "전체";

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
                            root.Tag = "2-" + tmenuCd_val + "-0" + "-0";
                            root.Text = tmenuNm_val;

                            //root.Nodes.Add(node1);

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
                logs.SaveLog("[error]  (page)::FrmMenuSite.cs  (Function)::SetDataBind_treeView1  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
                logs.SaveLog("[error]  (page)::FrmMenuSite.cs  (Function)::treeView1_AfterSelect  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        private void SetDataBind_gridView1(string code_grp, string tmenuCd, string smenuCd, string menuCd)
        {
            SetDataBind_grideView2();
            //string searchTxt_val = "";
            //if (!string.IsNullOrEmpty(txtSearch.Text))
            //{
            //    searchTxt_val = txtSearch.Text;
            //}

            M_WsMenuMainDB.WsMenuMainDB wSvc = null;
            string reCode = "";
            string reMsg = "";
            M_WsMenuMainDB.DataMenuSub[] getData2 = null;
            M_WsMenuMainDB.DataMenuSite[] getData3 = null;

            try
            {
                wSvc = new M_WsMenuMainDB.WsMenuMainDB();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/Menu/WsMenuMainDB.svc";
                wSvc.Timeout = 1000;

                if (code_grp == "2")
                {
                    btnSave.Enabled = false;
                    dataGridView1.Enabled = false;
                    dataGridView2.Enabled = false;

                    dataGridView2.Columns["dgv2_TOP_MENU_CD"].Visible = false;
                    dataGridView1.Columns["dgv1_APP_FLAG"].Visible = false;
                    dataGridView1.Columns["dgv1_MENU_CD"].Visible = false;
                    dataGridView2.Columns["dgv2_MENU_CD"].Visible = false;

                    dataGridView1.Columns["dgv1_TOP_MENU_CD"].ReadOnly = true;
                    dataGridView2.Columns["dgv2_TOP_MENU_CD"].ReadOnly = true;
                    dataGridView1.Columns["dgv1_SUB_MENU_CD"].ReadOnly = true;
                    dataGridView2.Columns["dgv2_SUB_MENU_CD"].ReadOnly = false;
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
                            MessageBox.Show("데이터가 없습니다");
                        }
                    }


                }
                else if (code_grp == "3")
                {
                    btnSave.Enabled = true;
                    dataGridView1.Enabled = true;
                    dataGridView2.Enabled = true;

                    dataGridView2.Columns["dgv2_TOP_MENU_CD"].Visible = false;
                    dataGridView2.Columns["dgv2_SUB_MENU_CD"].Visible = false;
                    dataGridView1.Columns["dgv1_APP_FLAG"].Visible = false;
                    dataGridView1.Columns["dgv1_MENU_CD"].Visible = true;
                    dataGridView2.Columns["dgv2_MENU_CD"].Visible = true;

                    dataGridView1.Columns["dgv1_TOP_MENU_CD"].ReadOnly = true;
                    dataGridView2.Columns["dgv2_TOP_MENU_CD"].ReadOnly = true;
                    dataGridView1.Columns["dgv1_SUB_MENU_CD"].ReadOnly = true;
                    dataGridView2.Columns["dgv2_SUB_MENU_CD"].ReadOnly = true;
                    dataGridView1.Columns["dgv1_MENU_CD"].ReadOnly = true;
                    dataGridView2.Columns["dgv2_MENU_CD"].ReadOnly = false;

                    reCode = wSvc.sMenuMemberDB(AppInfo.SsDbNm, AppInfo.SsSiteCd, tmenuCd, smenuCd, out getData3, out reMsg);
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
                                dataGridView1.Rows[i].Cells["dgv1_MEMO"].Value = getData3[i].MEMO.ToString();
                            }

                            SetRowNumber(dataGridView1);
                        }
                        else
                        {
                            dataGridView1.Rows.Clear();
                            MessageBox.Show("데이터가 없습니다");
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmMenuSite.cs  (Function)::SetDataBind_gridView1  (Detail)::pScodeGrp=[" + _topMenuCd + "]", "Error");
                logs.SaveLog("[error]  (page)::FrmMenuSite.cs  (Function)::SetDataBind_gridView1  (Detail)::reMsg=[" + reMsg + "]", "Error");
                logs.SaveLog("[error]  (page)::FrmMenuSite.cs  (Function)::SetDataBind_gridView1  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
                logs.SaveLog("[error]  (page)::FrmMenuSite.cs  (Function)::dataGridView1_CellBeginEdit  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
                logs.SaveLog("[error]  (page)::FrmMenuSite.cs  (Function)::dataGridView1_ColumnHeaderMouseClick  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
                dataGridView2.Rows[0].Cells["dgv2_SORT_NO"].Value = "1";
                dataGridView2.Rows[0].Cells["dgv2_BTNADD"].Value = "추가";
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmMenuSite.cs  (Function)::SetDataBind_grideView2  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            M_WsMenuMainDB.WsMenuMainDB wSvc = null;
            string reCode = "";
            string reMsg = "";
            string reData = "";
            string codeGrp = codeArr[0].ToString();
            string tMenuCd = codeArr[1].ToString();
            string sMenuCd = codeArr[2].ToString();
            string menuCd = codeArr[3].ToString();

            string colNm = dataGridView2.Columns[e.ColumnIndex].Name;

            if (colNm == "dgv2_BTNADD")
            {
                if (codeGrp == "3")
                {
                    string reVal = ChkDgv2ParamMenu();

                    if (reVal != "")
                        MessageBox.Show("데이터 확인 :: " + reVal);
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

                        string memo_val = "";

                        string pInputId = "1";

                        try
                        {
                            wSvc = new M_WsMenuMainDB.WsMenuMainDB();
                            wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/Menu/WsMenuMainDB.svc";
                            wSvc.Timeout = 1000;

                            reCode = wSvc.exMenu(menuCd_val, tMenuCd, sMenuCd, out reMsg, out reData);
                            if (reCode == "Y" && reData != "0")
                            {
                                MessageBox.Show("중복 데이터 입니다.");
                            }
                            else
                            {
                                reCode = "";
                                reCode = wSvc.aMenu(tMenuCd, sMenuCd, menuCd_val, Nm_val, "1", sortNo_val, menuPath_val, fileFolder_val, pInputId, out reMsg, out reData);
                                int reCnt = 0;

                                if (reCode == "Y")
                                {
                                    if (reData != "")
                                    {
                                        reCode = "";
                                        // * 멤버 디비에 인서트를 해준다. 
                                        reCode = wSvc.aMenuMemberDB(AppInfo.SsDbNm, AppInfo.SsSiteCd, menuCd_val, tMenuCd, sMenuCd, Nm_val, "1", sortNo_val, memo_val, pInputId, out reMsg, out reData);


                                        if (reCode == "Y" && reData != "")
                                            reCnt = Convert.ToInt16(reData);
                                    }
                                }

                                if (reCnt > 0)
                                    MessageBox.Show("저장 성공" + " : " + reCnt.ToString());
                                else
                                    MessageBox.Show("저장 실패");

                                SetDataBind_gridView1(codeGrp, tMenuCd, sMenuCd, menuCd);

                            }

                        }
                        catch (Exception ex)
                        {
                            logs.SaveLog("[error]  (page)::FrmMenuSite.cs  (Function)::dataGridView2_CellClick  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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

        private string ChkDgv2ParamMenu()
        {
            string reVal = "";
            string tMenuCd = codeArr[1].ToString();
            string sMenuCd = codeArr[2].ToString();
            string menuCd = codeArr[3].ToString();

            try
            {
                if (menuCd != null)
                {
                    if (menuCd == "")
                    {
                        reVal = "메뉴코드";
                        return reVal;
                    }
                }
                else
                {
                    reVal = "메뉴코드";
                    return reVal;
                }

                if (sMenuCd != null)
                {
                    if (sMenuCd == "")
                    {
                        reVal = "서브메뉴코드";
                        return reVal;
                    }
                }
                else
                {
                    reVal = "서브메뉴코드";
                    return reVal;
                }

                if (tMenuCd != null)
                {
                    if (tMenuCd == "")
                    {
                        reVal = "탑메뉴코드";
                        return reVal;
                    }
                }
                else
                {
                    reVal = "탑메뉴코드";
                    return reVal;
                }

                if (dataGridView2.Rows[0].Cells["dgv2_NM"].Value != null)
                {
                    if (dataGridView2.Rows[0].Cells["dgv2_NM"].Value.ToString() == "")
                    {
                        reVal = "이름";
                        return reVal;
                    }
                }
                else
                {
                    reVal = "이름";
                    return reVal;
                }

            }
            catch (Exception ex)
            {
                reVal = "에러";
                logs.SaveLog("[error]  (page)::FrmMenuSite.cs  (Function)::ChkDgv2ParamMenu  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
                int reCnt3 = 0;

                if (codeGrp == "3")
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (dataGridView1.Rows[i].Cells["dgv1_CHK"].Value != null)
                        {
                            if (dataGridView1.Rows[i].Cells["dgv1_CHK"].Value.ToString() == "1")
                            {
                                string menuCd_val = dataGridView1.Rows[i].Cells["dgv1_MENU_CD"].Value.ToString();
                                string usingFlag_val = dataGridView1.Rows[i].Cells["dgv1_USING_FLAG"].Value.ToString();
                                string pNm_val = dataGridView1.Rows[i].Cells["dgv1_NM"].Value.ToString();

                                string sortNo_val = "1";
                                if (dataGridView1.Rows[i].Cells["dgv1_SORT_NO"].Value != null)
                                    sortNo_val = dataGridView1.Rows[i].Cells["dgv1_SORT_NO"].Value.ToString();

                                string menuPath_val = "";
                                if (dataGridView1.Rows[i].Cells["dgv1_MENU_PATH"].Value != null)
                                    menuPath_val = dataGridView1.Rows[i].Cells["dgv1_MENU_PATH"].Value.ToString();

                                string fileFolder_val = "";
                                if (dataGridView1.Rows[i].Cells["dgv1_FILE_FOLDER"].Value != null)
                                    fileFolder_val = dataGridView1.Rows[i].Cells["dgv1_FILE_FOLDER"].Value.ToString();

                                string memo_val = "";
                                if (dataGridView1.Rows[i].Cells["dgv1_MEMO"].Value != null)
                                    memo_val = dataGridView1.Rows[i].Cells["dgv1_MEMO"].Value.ToString();

                                string pInputId = "1";

                                reCode = wSvc.mMenu(tMenuCd, sMenuCd, menuCd_val, usingFlag_val, sortNo_val, menuPath_val, fileFolder_val, out reMsg, out reData);

                                if (reCode == "Y")
                                {
                                    reCode = wSvc.mMenuMemberDB(AppInfo.SsDbNm, AppInfo.SsSiteCd, menuCd_val, usingFlag_val, sortNo_val, memo_val, out reMsg, out reData);
                                    if (Convert.ToInt16(reData) < 1)
                                    {
                                        if (usingFlag_val == "1")
                                        {
                                            //Member DB 업데이트 실패시 INSERT 해준다.
                                            reCode = wSvc.aMenuMemberDB(AppInfo.SsDbNm, AppInfo.SsSiteCd, menuCd_val, tMenuCd, sMenuCd, pNm_val, usingFlag_val, sortNo_val, memo_val, pInputId, out reMsg, out reData);

                                        }
                                        else
                                        {
                                            reCnt3++;
                                        }
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

                    MessageBox.Show("성공" + "[" + reCnt.ToString() + "], " + "실패" + "[" + reCnt2.ToString() + "], " + "보류(미사용)" + "[" + reCnt3.ToString() + "]");
                    SetDataBind_gridView1(codeGrp, tMenuCd, sMenuCd, menuCd);

                }

            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmMenuSite.cs  (Function)::btnSave_Click  (Detail):: " + "\r\n" + ex.ToString(), "Error");

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
            AppInfo.SsSiteCd = cmbSite.SelectedValue.ToString();
            string codeGrp = codeArr[0].ToString();
            string tMenuCd = codeArr[1].ToString();
            string sMenuCd = codeArr[2].ToString();
            string menuCd = codeArr[3].ToString();
            SetDataBind_gridView1(codeGrp, tMenuCd, sMenuCd, menuCd);
        }
    }
}

