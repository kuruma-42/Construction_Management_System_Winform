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
        ResourceManager lngRM = null;
        ResourceManager msgRM = null;

        string _topMenuCd = "";
        string[] codeArr;

        public FrmMenuMainDB()
        {
            // Sets the UI culture
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(AppInfo.SsLanguage);
            this.AutoScaleMode = AutoScaleMode.Dpi;

            InitializeComponent();

            try
            {
                logs = new LogUtil();
                lngRM = new ResourceManager("EldigmPlusApp.strLanguage", typeof(FrmMenuMainDB).Assembly);
                msgRM = new ResourceManager("EldigmPlusApp.msgLanguage", typeof(FrmMenuMainDB).Assembly);

                btnSearch.Text = lngRM.GetString("lngSearch");
                btnSave.Text = "저장";

                dataGridView1.Columns["dgv1_MENU_CD"].HeaderText = "메뉴코드";
                dataGridView1.Columns["dgv1_SUB_MENU_CD"].HeaderText = "서브메뉴코드";
                dataGridView1.Columns["dgv1_TOP_MENU_CD"].HeaderText = "탑메뉴코드";
                dataGridView1.Columns["dgv1_NM"].HeaderText = "이름";
                dataGridView1.Columns["dgv1_APP_FLAG"].HeaderText = "앱사용";
                dataGridView1.Columns["dgv1_USING_FLAG"].HeaderText = "사용";
                dataGridView1.Columns["dgv1_SORT_NO"].HeaderText = "정렬";

                dataGridView2.Columns["dgv2_MENU_CD"].HeaderText = "메뉴코드";
                dataGridView2.Columns["dgv2_SUB_MENU_CD"].HeaderText = "서브메뉴코드";
                dataGridView2.Columns["dgv2_TOP_MENU_CD"].HeaderText = "탑메뉴코드";
                dataGridView2.Columns["dgv2_NM"].HeaderText = "이름";
                dataGridView2.Columns["dgv2_SORT_NO"].HeaderText = "정렬";

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
                logs.SaveLog("[error]  (page)::FrmMenu.cs  (Function)::FrmMenu  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        #region __ panel2 paint_Purple1
        private void paint_Purple1(object sender, PaintEventArgs e)
        {
            Class.UI.PanelPaint pp = new Class.UI.PanelPaint();
            pp.paint_PanelPurple1(sender, e);
        }
        #endregion

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            try
            {
                SetDataBind_Combo();

                SetDataBind_treeView1();
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmMenu.cs  (Function)::FrmMenu_Load  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        private void SetDataBind_Combo()
        {
            try
            {
                Class.Common.ComboBoxItemSet setCmb = null;

                setCmb = new Class.Common.ComboBoxItemSet();

                setCmb.AddColumn();

                setCmb.AddRow("사용", "1");
                setCmb.AddRow("미사용", "0");
                setCmb.AddRow("전체", "");

                setCmb.Bind(cmbUse);

            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmMenu.cs  (Function)::setDataBind_Combo  (Detail):: " + "\r\n" + ex.ToString());
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
            M_WsMenuMainDB.DataMenu[] getData3 = null;
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

                reCode = wSvc.sManuTopTreeView(cmbUse.SelectedValue.ToString(), out getData1, out reMsg);
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

                            reCode = wSvc.sManuSubTreeView(tmenuCd_val, cmbUse.SelectedValue.ToString(), out getData2, out reMsg);
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

                                        reCode = wSvc.sManuTreeView(tmenuCd_val, smenuCd_val, cmbUse.SelectedValue.ToString(), out getData3, out reMsg);
                                        if (reCode == "Y")
                                        {
                                            if (getData3 != null && getData3.Length > 0)
                                            {
                                                for (int k = 0; k < getData3.Length; k++)
                                                {
                                                    string menuCd_val = getData3[k].MENU_CD.ToString();
                                                    string menuNm_val = getData3[k].MENU_NM.ToString();
                                                    TreeNode node3 = new TreeNode();
                                                    node3.Tag = "4-" + tmenuCd_val + "-" + smenuCd_val + "-" + menuCd_val;
                                                    node3.Text = menuNm_val;

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

                codeArr = eNodeTag.Split('-');

                dataGridView2.Rows[0].Cells["dgv2_CODE_GRP"].Value = codeArr[0].ToString();
                dataGridView2.Rows[0].Cells["dgv2_TOP_MENU_CD"].Value = codeArr[1].ToString();
                dataGridView2.Rows[0].Cells["dgv2_SUB_MENU_CD"].Value = codeArr[2].ToString();
                dataGridView2.Rows[0].Cells["dgv2_MENU_CD"].Value = codeArr[3].ToString();

                SetDataBind_gridView1(codeArr[0].ToString(), codeArr[1].ToString(), codeArr[2].ToString(), codeArr[3].ToString());

            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmMenuMainDB.cs  (Function)::treeView1_AfterSelect  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        private void SetDataBind_gridView1(string code_grp, string tmenuCd, string smenuCd, string menuCd)
        {
            //string searchTxt_val = "";
            //if (!string.IsNullOrEmpty(txtSearch.Text))
            //{
            //    searchTxt_val = txtSearch.Text;
            //}

            M_WsMenuMainDB.WsMenuMainDB wSvc = null;
            string reCode = "";
            string reMsg = "";
            //M_WsMenuMainDB.DataMenuTop[] getData1 = null;
            M_WsMenuMainDB.DataMenuSub[] getData2 = null;
            M_WsMenuMainDB.DataMenu[] getData3 = null;

            try
            {
                wSvc = new M_WsMenuMainDB.WsMenuMainDB(); // 시스템 코드 보여주기 
                wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/Menu/WsMenuMainDB.svc";
                wSvc.Timeout = 1000;

                string tMenuCd_val = dataGridView2.Rows[0].Cells["dgv2_TOP_MENU_CD"].Value.ToString();
                string sMenuCd_val = dataGridView2.Rows[0].Cells["dgv2_SUB_MENU_CD"].Value.ToString();
                string menuCd_val = dataGridView2.Rows[0].Cells["dgv2_MENU_CD"].Value.ToString();
                if (tMenuCd_val == "0")
                {
                    dataGridView2.Rows[0].Cells["dgv2_TOP_MENU_CD"].Value = null;
                }
                if (sMenuCd_val == "0")
                {
                    dataGridView2.Rows[0].Cells["dgv2_SUB_MENU_CD"].Value = null;
                }
                if (menuCd_val == "0")
                {
                    dataGridView2.Rows[0].Cells["dgv2_MENU_CD"].Value = null;
                }
                //if (code_grp == "1")
                //{
                //    dataGridView1.Columns["dgv1_APP_FLAG"].Visible = true;

                //    reCode = wSvc.sManuTopTreeView(out getData1, out reMsg);
                //    if (reCode == "Y")
                //    {
                //        if (getData1 != null && getData1.Length > 0)
                //        {
                //            dataGridView1.Rows.Clear();
                //            for (int i = 0; i < getData1.Length; i++)
                //            {
                //                dataGridView1.Rows.Add();
                //                dataGridView1.Rows[i].Cells["dgv1_TOP_MENU_CD"].Value = getData1[i].TOP_MENU_CD.ToString();
                //                dataGridView1.Rows[i].Cells["dgv1_TOP_MENU_NM"].Value = getData1[i].TOP_MENU_NM.ToString();
                //                dataGridView1.Rows[i].Cells["dgv1_APP_FLAG"].Value = getData1[i].APP_FLAG.ToString();
                //                dataGridView1.Rows[i].Cells["dgv1_USING_FLAG"].Value = getData1[i].USING_FLAG.ToString();
                //                dataGridView1.Rows[i].Cells["dgv1_SORT_NO"].Value = getData1[i].SORT_NO.ToString();
                //            }

                //            SetRowNumber(dataGridView1);
                //        }
                //        else
                //        {
                //    dataGridView1.Rows.Clear();
                //    MessageBox.Show("데이터가 없습니다");
                //}
                //    }
                //}
                if (code_grp == "2")
                {
                    dataGridView1.Columns["dgv1_APP_FLAG"].Visible = false;
                    dataGridView1.Columns["dgv1_MENU_CD"].Visible = false;
                    dataGridView2.Columns["dgv2_MENU_CD"].Visible = false;
                    dataGridView2.Columns["dgv2_TOP_MENU_CD"].ReadOnly = true;
                    dataGridView2.Columns["dgv2_SUB_MENU_CD"].ReadOnly = false;


                    reCode = wSvc.sManuSubTreeView(tmenuCd, cmbUse.SelectedValue.ToString(), out getData2, out reMsg);
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
                    dataGridView1.Columns["dgv1_APP_FLAG"].Visible = false;
                    dataGridView1.Columns["dgv1_MENU_CD"].Visible = true;
                    dataGridView2.Columns["dgv2_MENU_CD"].Visible = true;
                    dataGridView2.Columns["dgv2_TOP_MENU_CD"].ReadOnly = true;
                    dataGridView2.Columns["dgv2_SUB_MENU_CD"].ReadOnly = true;
                    dataGridView2.Columns["dgv2_MENU_CD"].ReadOnly = false;

                    reCode = wSvc.sManuTreeView(tmenuCd, smenuCd, cmbUse.SelectedValue.ToString(), out getData3, out reMsg);
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
                            }

                            SetRowNumber(dataGridView1);
                            //dataGridView2.Rows[0].Cells["dgv2_CODE_GRP"].Value = "3";
                        }
                        else
                        {
                            dataGridView1.Rows.Clear();
                            MessageBox.Show("데이터가 없습니다");
                        }
                    }
                }
                else if (code_grp == "4")
                {
                    dataGridView1.Columns["dgv1_MENU_CD"].Visible = true;
                    dataGridView2.Columns["dgv2_MENU_CD"].Visible = true;
                    dataGridView2.Columns["dgv2_TOP_MENU_CD"].ReadOnly = true;
                    dataGridView2.Columns["dgv2_SUB_MENU_CD"].ReadOnly = true;
                    dataGridView2.Columns["dgv2_MENU_CD"].ReadOnly = true;

                    reCode = wSvc.sManuTreeView2(tmenuCd, smenuCd, menuCd, cmbUse.SelectedValue.ToString(), out getData3, out reMsg);
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
                            }

                            SetRowNumber(dataGridView1);
                            //dataGridView2.Rows[0].Cells["dgv2_CODE_GRP"].Value = "4";

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
                logs.SaveLog("[error]  (page)::FrmMenuMainDB.cs  (Function)::SetDataBind_gridView1  (Detail)::pScodeGrp=[" + _topMenuCd + "]", "Error");
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
                dataGridView2.Rows[0].Cells["dgv2_SORT_NO"].Value = "1";
                dataGridView2.Rows[0].Cells["dgv2_BTNADD"].Value = "추가";
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmMenuMainDB.cs  (Function)::SetDataBind_grideView2  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string codeGrp = "1";
            if (dataGridView2.Rows[0].Cells["dgv2_CODE_GRP"].Value != null)
                codeGrp = dataGridView2.Rows[0].Cells["dgv2_CODE_GRP"].Value.ToString();

            string colNm = dataGridView2.Columns[e.ColumnIndex].Name;

            if (colNm == "dgv2_BTNADD")
            {

                //if (codeGrp == "1")
                //{
                //    string reVal = ChkDgv2Param();

                //    if (reVal != "")
                //        MessageBox.Show("데이터 확인 :: " + reVal);
                //    else
                //    {
                //        reCode = wSvc.exMenu(menuCd_val, Nm_val, out reMsg, out reData);
                //    }


                //    if (reCode == "Y" && reData != "0")
                //    {
                //        MessageBox.Show("중복 데이터 입니다.");
                //    }
                //    else
                //    {
                //        reCode = "";
                //        //reCode = wSvc.aSysCode(menuCd_val, topMenuCd, Nm_val, "1", sortNo_val, pInputId, out reMsg, out reData);

                //        int reCnt = 0;

                //        if (reCode == "Y" && reData != "")
                //            reCnt = Convert.ToInt16(reData);

                //        if (reCnt > 0)
                //            MessageBox.Show("저장 성공" + " : " + reCnt.ToString());
                //        else
                //            MessageBox.Show("저장 실패");

                //        SetDataBind_gridView1(topMenuCd, "", "", "");
                ////        SetDataBind_grideView2();
                //    }
                //}
                if (codeGrp == "2")
                {
                    string reVal = ChkDgv2ParamSubMenu();

                    if (reVal != "")
                        MessageBox.Show("데이터 확인 :: " + reVal);
                    else
                    {
                        string menuCd_val = dataGridView2.Rows[0].Cells["dgv2_MENU_CD"].Value.ToString();
                        string subMenuCd_val = dataGridView2.Rows[0].Cells["dgv2_SUB_MENU_CD"].Value.ToString();
                        string topMenuCd_val = dataGridView2.Rows[0].Cells["dgv2_TOP_MENU_CD"].Value.ToString();
                        string Nm_val = dataGridView2.Rows[0].Cells["dgv2_NM"].Value.ToString();
                        string sortNo_val = "1";
                        if (dataGridView2.Rows[0].Cells["dgv2_SORT_NO"].Value != null)
                            sortNo_val = dataGridView2.Rows[0].Cells["dgv2_SORT_NO"].Value.ToString();

                        string pInputId = "1";

                        M_WsMenuMainDB.WsMenuMainDB wSvc = null;
                        string reCode = "";
                        string reMsg = "";
                        string reData = "";

                        try
                        {
                            wSvc = new M_WsMenuMainDB.WsMenuMainDB();
                            wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/Menu/WsMenuMainDB.svc";
                            wSvc.Timeout = 1000;

                            reCode = wSvc.exMenuSub(subMenuCd_val, topMenuCd_val, Nm_val, out reMsg, out reData);
                            if (reCode == "Y" && reData != "0")
                            {
                                MessageBox.Show("중복 데이터 입니다.");
                            }
                            else
                            {
                                reCode = "";
                                reCode = wSvc.aMenuSub(topMenuCd_val, Nm_val, "1", sortNo_val, pInputId, out reMsg, out reData);

                                int reCnt = 0;

                                if (reCode == "Y" && reData != "")
                                    reCnt = Convert.ToInt16(reData);

                                if (reCnt > 0)
                                    MessageBox.Show("저장 성공" + " : " + reCnt.ToString());
                                else
                                    MessageBox.Show("저장 실패");

                                SetDataBind_gridView1(codeGrp, topMenuCd_val, "0", "0");
                                //SetDataBind_grideView2();
                                dataGridView2.Rows[0].Cells["dgv2_SUB_MENU_CD"].Value = null;
                                dataGridView2.Rows[0].Cells["dgv2_NM"].Value = null;
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
                if (codeGrp == "3")
                {
                    string reVal = ChkDgv2ParamMenu();

                    if (reVal != "")
                        MessageBox.Show("데이터 확인 :: " + reVal);
                    else
                    {
                        string menuCd_val = dataGridView2.Rows[0].Cells["dgv2_MENU_CD"].Value.ToString();
                        string subMenuCd_val = dataGridView2.Rows[0].Cells["dgv2_SUB_MENU_CD"].Value.ToString();
                        string topMenuCd_val = dataGridView2.Rows[0].Cells["dgv2_TOP_MENU_CD"].Value.ToString();
                        string Nm_val = dataGridView2.Rows[0].Cells["dgv2_NM"].Value.ToString();

                        string sortNo_val = "1";
                        if (dataGridView2.Rows[0].Cells["dgv2_SORT_NO"].Value != null)
                            sortNo_val = dataGridView2.Rows[0].Cells["dgv2_SORT_NO"].Value.ToString();

                        string pInputId = "1";

                        M_WsMenuMainDB.WsMenuMainDB wSvc = null;
                        string reCode = "";
                        string reMsg = "";
                        string reData = "";

                        try
                        {
                            wSvc = new M_WsMenuMainDB.WsMenuMainDB();
                            wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/Menu/WsMenuMainDB.svc";
                            wSvc.Timeout = 1000;

                            reCode = wSvc.exMenu(menuCd_val, topMenuCd_val, subMenuCd_val, Nm_val, out reMsg, out reData);
                            if (reCode == "Y" && reData != "0")
                            {
                                MessageBox.Show("중복 데이터 입니다.");
                            }
                            else
                            {
                                reCode = "";
                                reCode = wSvc.aMenu(menuCd_val, topMenuCd_val, subMenuCd_val, Nm_val, "1", sortNo_val, pInputId, out reMsg, out reData);

                                int reCnt = 0;

                                if (reCode == "Y" && reData != "")
                                    reCnt = Convert.ToInt16(reData);

                                if (reCnt > 0)
                                    MessageBox.Show("저장 성공" + " : " + reCnt.ToString());
                                else
                                    MessageBox.Show("저장 실패");

                                SetDataBind_gridView1(codeGrp, topMenuCd_val, subMenuCd_val, menuCd_val);
                                //SetDataBind_grideView2();
                                dataGridView2.Rows[0].Cells["dgv2_MENU_CD"].Value = null;
                                dataGridView2.Rows[0].Cells["dgv2_NM"].Value = null;

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
                //if (codeGrp == "4")
                //{
                //    string reVal = ChkDgv2ParamMenu();

                //    if (reVal != "")
                //        MessageBox.Show("데이터 확인 :: " + reVal);
                //    else
                //    {
                //        string menuCd_val = dataGridView2.Rows[0].Cells["dgv2_MENU_CD"].Value.ToString();
                //        string subMenuCd_val = dataGridView2.Rows[0].Cells["dgv2_SUB_MENU_CD"].Value.ToString();
                //        string topMenuCd_val = dataGridView2.Rows[0].Cells["dgv2_TOP_MENU_CD"].Value.ToString();
                //        string Nm_val = dataGridView2.Rows[0].Cells["dgv2_NM"].Value.ToString();

                //        string sortNo_val = "1";
                //        if (dataGridView2.Rows[0].Cells["dgv2_SORT_NO"].Value != null)
                //            sortNo_val = dataGridView2.Rows[0].Cells["dgv2_SORT_NO"].Value.ToString();

                //        string pInputId = "1";

                //        M_WsMenuMainDB.WsMenuMainDB wSvc = null;
                //        string reCode = "";
                //        string reMsg = "";
                //        string reData = "";

                //        try
                //        {
                //            wSvc = new M_WsMenuMainDB.WsMenuMainDB();
                //            wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/Menu/WsMenuMainDB.svc";
                //            wSvc.Timeout = 1000;

                //            //reCode = wSvc.exMenuSub(subMenuCd_val, topMenuCd_val, Nm_val, out reMsg, out reData);
                //            if (reCode == "Y" && reData != "0")
                //            {
                //                MessageBox.Show("중복 데이터 입니다.");
                //            }
                //            else
                //            {
                //                reCode = "";
                //                //reCode = wSvc.aMenuSub(topMenuCd_val, Nm_val, "1", sortNo_val, pInputId, out reMsg, out reData);

                //                int reCnt = 0;

                //                if (reCode == "Y" && reData != "")
                //                    reCnt = Convert.ToInt16(reData);

                //                if (reCnt > 0)
                //                    MessageBox.Show("저장 성공" + " : " + reCnt.ToString());
                //                else
                //                    MessageBox.Show("저장 실패");

                //                SetDataBind_gridView1(codeGrp, topMenuCd_val, subMenuCd_val, menuCd_val);
                //                //SetDataBind_grideView2();
                //                dataGridView2.Rows[0].Cells["dgv2_NM"].Value = null;

                //            }

                //        }
                //        catch (Exception ex)
                //        {
                //            logs.SaveLog("[error]  (page)::FrmMenuMainDB.cs  (Function)::dataGridView2_CellClick  (Detail):: " + "\r\n" + ex.ToString(), "Error");
                //        }
                //        finally
                //        {
                //            if (wSvc != null)
                //                wSvc.Dispose();
                //        }
                //    }

                //}

            }
        }

        private string ChkDgv2ParamTopMenu()
        {

            string reVal = "";
            try
            {
                if (dataGridView2.Rows[0].Cells["dgv2_TOP_MENU_CD"].Value != null)
                {
                    if (dataGridView2.Rows[0].Cells["dgv2_TOP_MENU_CD"].Value.ToString() == "")
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
                logs.SaveLog("[error]  (page)::FrmMenuMainDB.cs  (Function)::ChkDgv2ParamTopMenu  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }

            return reVal;
        }

        private string ChkDgv2ParamSubMenu()
        {
            string reVal = "";
            try
            {
                if (dataGridView2.Rows[0].Cells["dgv2_SUB_MENU_CD"].Value != null)
                {
                    if (dataGridView2.Rows[0].Cells["dgv2_SUB_MENU_CD"].Value.ToString() == "")
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
                if (dataGridView2.Rows[0].Cells["dgv2_TOP_MENU_CD"].Value != null)
                {
                    if (dataGridView2.Rows[0].Cells["dgv2_TOP_MENU_CD"].Value.ToString() == "")
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
                        reVal = "메뉴코드";
                        return reVal;
                    }
                }
                else
                {
                    reVal = "메뉴코드";
                    return reVal;
                }

                if (dataGridView2.Rows[0].Cells["dgv2_SUB_MENU_CD"].Value != null)
                {
                    if (dataGridView2.Rows[0].Cells["dgv2_SUB_MENU_CD"].Value.ToString() == "")
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

                if (dataGridView2.Rows[0].Cells["dgv2_TOP_MENU_CD"].Value != null)
                {
                    if (dataGridView2.Rows[0].Cells["dgv2_TOP_MENU_CD"].Value.ToString() == "")
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
            //M_WsMenuMainDB.WsMenuMainDB wSvc = null;
            //string reCode = "";
            //string reMsg = "";
            //string reData = "";
            //string codeGrp = codeArr[0].ToString();

            //int reCnt = 0;

            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    if (dataGridView1.Rows[i].Cells["dgv1_USING_FLAG"].Value != null)
            //    {
            //        if (dataGridView1.Rows[i].Cells["dgv1_USING_FLAG"].Value.ToString() == "1")
            //        {
            //            string menuCd_val = dataGridView2.Rows[0].Cells["dgv2_MENU_CD"].Value.ToString();
            //            string subMenuCd_val = dataGridView2.Rows[0].Cells["dgv2_SUB_MENU_CD"].Value.ToString();
            //            string topMenuCd_val = dataGridView2.Rows[0].Cells["dgv2_TOP_MENU_CD"].Value.ToString();
            //            string Nm_val = dataGridView2.Rows[0].Cells["dgv2_NM"].Value.ToString();

            //            string sortNo_val = "1";
            //            if (dataGridView2.Rows[0].Cells["dgv2_SORT_NO"].Value != null)
            //                sortNo_val = dataGridView2.Rows[0].Cells["dgv2_SORT_NO"].Value.ToString();

            //            string pInputId = "1";

            //            reCode = wSvc.mMenuSub(menuCd_val, subMenuCd_val, topMenuCd_val, "1", sortNo_val, pInputId, out reMsg, out reData);

            //            if (reCode == "Y" && reData != "")
            //                reCnt += Convert.ToInt16(reData);
            //        }
            //    }
            //}

            //if (reCnt > 0)
            //    MessageBox.Show("저장 성공" + " : " + reCnt.ToString());
            //else
            //    MessageBox.Show("저장 실패");

            ////SetDataBind_gridView1(topMenuCd);

            //if (codeGrp == "2")
            //{


            //    string menuCd_val = dataGridView2.Rows[0].Cells["dgv2_MENU_CD"].Value.ToString();
            //    string subMenuCd_val = dataGridView2.Rows[0].Cells["dgv2_SUB_MENU_CD"].Value.ToString();
            //    string topMenuCd_val = dataGridView2.Rows[0].Cells["dgv2_TOP_MENU_CD"].Value.ToString();
            //    string Nm_val = dataGridView2.Rows[0].Cells["dgv2_NM"].Value.ToString();
            //    string sortNo_val = "1";
            //    if (dataGridView2.Rows[0].Cells["dgv2_SORT_NO"].Value != null)
            //        sortNo_val = dataGridView2.Rows[0].Cells["dgv2_SORT_NO"].Value.ToString();

            //    string pInputId = "1";

            //    M_WsMenuMainDB.WsMenuMainDB wSvc = null;
            //    string reCode = "";
            //    string reMsg = "";
            //    string reData = "";

            //    try
            //    {
            //        wSvc = new M_WsMenuMainDB.WsMenuMainDB();
            //        wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/Menu/WsMenuMainDB.svc";
            //        wSvc.Timeout = 1000;

            //        reCode = wSvc.exMenuSub(subMenuCd_val, topMenuCd_val, Nm_val, out reMsg, out reData);
            //        if (reCode == "Y" && reData != "0")
            //        {
            //            MessageBox.Show("중복 데이터 입니다.");
            //        }
            //        else
            //        {
            //            reCode = "";
            //            reCode = wSvc.aMenuSub(topMenuCd_val, Nm_val, "1", sortNo_val, pInputId, out reMsg, out reData);

            //            int reCnt = 0;

            //            if (reCode == "Y" && reData != "")
            //                reCnt = Convert.ToInt16(reData);

            //            if (reCnt > 0)
            //                MessageBox.Show("저장 성공" + " : " + reCnt.ToString());
            //            else
            //                MessageBox.Show("저장 실패");

            //            SetDataBind_gridView1(codeGrp, topMenuCd_val, "0", "0");
            //            //SetDataBind_grideView2();
            //            dataGridView2.Rows[0].Cells["dgv2_SUB_MENU_CD"].Value = null;
            //            dataGridView2.Rows[0].Cells["dgv2_NM"].Value = null;
            //        }

            //    }
            //    catch (Exception ex)
            //    {
            //        logs.SaveLog("[error]  (page)::FrmMenuMainDB.cs  (Function)::dataGridView2_CellClick  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            //    }
            //    finally
            //    {
            //        if (wSvc != null)
            //            wSvc.Dispose();
            //    }

            //}
            //if (codeGrp == "3")
            //{
            //    string reVal = ChkDgv2ParamMenu();

            //    if (reVal != "")
            //        MessageBox.Show("데이터 확인 :: " + reVal);
            //    else
            //    {
            //        string menuCd_val = dataGridView2.Rows[0].Cells["dgv2_MENU_CD"].Value.ToString();
            //        string subMenuCd_val = dataGridView2.Rows[0].Cells["dgv2_SUB_MENU_CD"].Value.ToString();
            //        string topMenuCd_val = dataGridView2.Rows[0].Cells["dgv2_TOP_MENU_CD"].Value.ToString();
            //        string Nm_val = dataGridView2.Rows[0].Cells["dgv2_NM"].Value.ToString();

            //        string sortNo_val = "1";
            //        if (dataGridView2.Rows[0].Cells["dgv2_SORT_NO"].Value != null)
            //            sortNo_val = dataGridView2.Rows[0].Cells["dgv2_SORT_NO"].Value.ToString();

            //        string pInputId = "1";

            //        M_WsMenuMainDB.WsMenuMainDB wSvc = null;
            //        string reCode = "";
            //        string reMsg = "";
            //        string reData = "";

            //        try
            //        {
            //            wSvc = new M_WsMenuMainDB.WsMenuMainDB();
            //            wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/Menu/WsMenuMainDB.svc";
            //            wSvc.Timeout = 1000;

            //            reCode = wSvc.exMenu(menuCd_val, topMenuCd_val, subMenuCd_val, Nm_val, out reMsg, out reData);
            //            if (reCode == "Y" && reData != "0")
            //            {
            //                MessageBox.Show("중복 데이터 입니다.");
            //            }
            //            else
            //            {
            //                reCode = "";
            //                reCode = wSvc.aMenu(menuCd_val, topMenuCd_val, subMenuCd_val, Nm_val, "1", sortNo_val, pInputId, out reMsg, out reData);

            //                int reCnt = 0;

            //                if (reCode == "Y" && reData != "")
            //                    reCnt = Convert.ToInt16(reData);

            //                if (reCnt > 0)
            //                    MessageBox.Show("저장 성공" + " : " + reCnt.ToString());
            //                else
            //                    MessageBox.Show("저장 실패");

            //                SetDataBind_gridView1(codeGrp, topMenuCd_val, subMenuCd_val, menuCd_val);
            //                //SetDataBind_grideView2();
            //                dataGridView2.Rows[0].Cells["dgv2_MENU_CD"].Value = null;
            //                dataGridView2.Rows[0].Cells["dgv2_NM"].Value = null;

            //            }

            //        }
            //        catch (Exception ex)
            //        {
            //            logs.SaveLog("[error]  (page)::FrmMenuMainDB.cs  (Function)::dataGridView2_CellClick  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            //        }
            //        finally
            //        {
            //            if (wSvc != null)
            //                wSvc.Dispose();
            //        }
            //    }

            //}
        }

    }

    //private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
    //{
    //    //if (e.KeyChar == '\r')
    //    //{
    //    //    btnSearch_Click(null, null);
    //    //}
    //}

    //private void btnSearch_Click(object sender, EventArgs e)
    //{
    //    //SetDataBind_gridView1("", "", "", "");
    //}

}


