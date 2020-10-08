using EldigmPlusApp.Config;
using Framework.Log;
using System;
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
        ResourceManager lngRM = null;
        ResourceManager msgRM = null;

        string _topMenuCd = "";
        //string[] _codeArr = new string[2];
        string _codeGrp = "";
        string _code = "";

        public FrmCodeTMainDB()
        {
            // Sets the UI culture
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(AppInfo.SsLanguage);
            this.AutoScaleMode = AutoScaleMode.Dpi;

            InitializeComponent();

            try
            {
                logs = new LogUtil();
                lngRM = new ResourceManager("EldigmPlusApp.strLanguage", typeof(FrmCodeTMainDB).Assembly);
                msgRM = new ResourceManager("EldigmPlusApp.msgLanguage", typeof(FrmCodeTMainDB).Assembly);

                //btnSearch.Text = lngRM.GetString("lngSearch");
                btnSave.Text = "저장";

                dataGridView1.Columns["dgv1_CHK"].HeaderText = "선택";
                dataGridView1.Columns["dgv1_TCODE"].HeaderText = "T코드";
                dataGridView1.Columns["dgv1_TTYPE_SCD"].HeaderText = "T유형S코드";
                dataGridView1.Columns["dgv1_NM"].HeaderText = "이름";
                dataGridView1.Columns["dgv1_LIST_FLAG"].HeaderText = "리스트";
                dataGridView1.Columns["dgv1_REQUIRED_FLAG"].HeaderText = "필수";
                dataGridView1.Columns["dgv1_NUMERIC_FLAG"].HeaderText = "숫자";
                dataGridView1.Columns["dgv1_USING_CNT"].HeaderText = "사용카운터";

                dataGridView2.Columns["dgv2_MENU_CD"].HeaderText = "메뉴코드";
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


                //SetDataBind_gridView1(codeArr[0].ToString(), codeArr[1].ToString(), codeArr[2].ToString(), codeArr[3].ToString());
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

                if (codeGrp == "1")
                {
                    reCode = wSvc.sCodeT(code_val, out getData1, out reMsg);
                    if (reCode == "Y")
                    {
                        if (getData1 != null && getData1.Length > 0)
                        {
                            dataGridView1.Rows.Clear();
                            for (int i = 0; i < getData1.Length; i++)
                            {
                                dataGridView1.Rows.Add();
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
                            MessageBox.Show("데이터가 없습니다");
                        }
                    }
                }
                else if (codeGrp == "2")
                {
                    if(code_val == "InspectionMethod" || code_val == "CarSize")
                    {
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
                                MessageBox.Show("데이터가 없습니다");
                            }
                        }

                    }
                   
                }

            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmCodeTMainDB.cs  (Function)::SetDataBind_gridView1  (Detail)::pScodeGrp=[" + _topMenuCd + "]", "Error");
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
                dataGridView2.Rows[0].Cells["dgv2_SORT_NO"].Value = "1";
                dataGridView2.Rows[0].Cells["dgv2_BTNADD"].Value = "추가";
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmCodeTMainDB.cs  (Function)::dataGridView1_DataBindingComplete  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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

                if (_codeGrp == "2")
                {
                    string reVal = ChkDgv2ParamSubMenu();

                    if (reVal != "")
                        MessageBox.Show("데이터 확인 :: " + reVal);
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

                            //reCode = wSvc.exMenuSub(sMenuCd, tMenuCd, Nm_val, out reMsg, out reData);
                            if (reCode == "Y" && reData != "0")
                            {
                                MessageBox.Show("중복 데이터 입니다.");
                            }
                            else
                            {
                                reCode = "";
                                reCode = wSvc.aMenuSub(_code, Nm_val, "1", sortNo_val, pInputId, out reMsg, out reData);

                                int reCnt = 0;

                                if (reCode == "Y" && reData != "")
                                    reCnt = Convert.ToInt16(reData);

                                if (reCnt > 0)
                                    MessageBox.Show("저장 성공" + " : " + reCnt.ToString());
                                else
                                    MessageBox.Show("저장 실패");

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

                if (_codeGrp == "3")
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

                        string pInputId = "1";

                        try
                        {
                            wSvc = new M_WsMenuMainDB.WsMenuMainDB();
                            wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/Menu/WsMenuMainDB.svc";
                            wSvc.Timeout = 1000;

                            //reCode = wSvc.exMenu(menuCd_val, tMenuCd, sMenuCd, out reMsg, out reData);
                            if (reCode == "Y" && reData != "0")
                            {
                                MessageBox.Show("중복 데이터 입니다.");
                            }
                            else
                            {
                                reCode = "";
                                //reCode = wSvc.aMenu(tMenuCd, sMenuCd, menuCd_val, Nm_val, "1", sortNo_val, menuPath_val, fileFolder_val, pInputId, out reMsg, out reData);

                                int reCnt = 0;

                                if (reCode == "Y" && reData != "")
                                    reCnt = Convert.ToInt16(reData);

                                if (reCnt > 0)
                                    MessageBox.Show("저장 성공" + " : " + reCnt.ToString());
                                else
                                    MessageBox.Show("저장 실패");

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

        private string ChkDgv2ParamSubMenu()
        {
            string reVal = "";
            try
            {
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
                logs.SaveLog("[error]  (page)::FrmCodeTMainDB.cs  (Function)::ChkDgv2ParamSubMenu  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
                logs.SaveLog("[error]  (page)::FrmCodeTMainDB.cs  (Function)::ChkDgv2ParamMenu  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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

                                reCode = wSvc.mMenuSub(_code, sMenuCd_val, usingFlag_val, sortNo_val, out reMsg, out reData);

                                if (reCode == "Y" && reData != "")
                                    reCnt += Convert.ToInt16(reData);
                            }
                        }
                    }
                    if (reCnt > 0)
                        MessageBox.Show("저장 성공" + " : " + reCnt.ToString());
                    else
                        MessageBox.Show("저장 실패");

                    SetDataBind_gridView1(_codeGrp, _code);
                }

                if (_codeGrp == "3")
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (dataGridView1.Rows[i].Cells["dgv1_CHK"].Value != null)
                        {
                            if (dataGridView1.Rows[i].Cells["dgv1_CHK"].Value.ToString() == "1")
                            {
                                string topMenuCd_val = dataGridView1.Rows[i].Cells["dgv1_TOP_MENU_CD"].Value.ToString();
                                string subMenuCd_val = dataGridView1.Rows[i].Cells["dgv1_SUB_MENU_CD"].Value.ToString();
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

                                reCode = wSvc.mMenu(topMenuCd_val, subMenuCd_val, menuCd_val, usingFlag_val, sortNo_val, menuPath_val, fileFolder_val, out reMsg, out reData);

                                if (reCode == "Y" && reData != "")
                                    reCnt += Convert.ToInt16(reData);
                            }
                        }
                    }
                    if (reCnt > 0)
                        MessageBox.Show("저장 성공" + " : " + reCnt.ToString());
                    else
                        MessageBox.Show("저장 실패");

                    SetDataBind_gridView1(_codeGrp, _code);
                }


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
            //if (e.KeyChar == '\r')
            //{
            //    btnSearch_Click(null, null);
            //}
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //SetDataBind_gridView1("", "", "", "");
        }

        private void cmbUse_SelectedIndexChanged(object sender, EventArgs e)
        {

            //string codeGrp = codeArr[0].ToString();
            //string tMenuCd = codeArr[1].ToString();
            //string sMenuCd = codeArr[2].ToString();
            //string menuCd = codeArr[3].ToString();

            //SetDataBind_gridView1(codeGrp, tMenuCd, sMenuCd, menuCd);
        }
    }
}

