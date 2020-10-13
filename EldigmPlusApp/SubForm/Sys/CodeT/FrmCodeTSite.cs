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
    public partial class FrmCodeTSite : Form
    {
        LogUtil logs = null;
        ResourceManager lngRM = null;
        ResourceManager msgRM = null;

        string _ccode = "";

        public FrmCodeTSite()
        {
            // Sets the UI culture
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(AppInfo.SsLanguage);
            this.AutoScaleMode = AutoScaleMode.Dpi;

            InitializeComponent();

            try
            {
                logs = new LogUtil();
                lngRM = new ResourceManager("EldigmPlusApp.strLanguage", typeof(FrmCodeTSite).Assembly);
                msgRM = new ResourceManager("EldigmPlusApp.msgLanguage", typeof(FrmCodeTSite).Assembly);

                //btnSearch.Text = lngRM.GetString("lngSearch");
                btnSave.Text = "저장";
                btnAdd.Text = "추가";

                dataGridView1.Columns["dgv1_CHK"].HeaderText = "선택";
                dataGridView1.Columns["dgv1_TCODE"].HeaderText = "T코드";
                dataGridView1.Columns["dgv1_NM"].HeaderText = "이름";
                dataGridView1.Columns["dgv1_DEFAULT_VALUE"].HeaderText = "기본값";
                dataGridView1.Columns["dgv1_USING_FLAG"].HeaderText = "사용";
                dataGridView1.Columns["dgv1_SORT_NO"].HeaderText = "정렬";
                dataGridView1.Columns["dgv1_MEMO"].HeaderText = "메모";

               

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
                logs.SaveLog("[error]  (page)::FrmCodeTSite.cs  (Function)::FrmCodeTSite  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        #region __ panel2 paint_Purple1
        private void paint_Purple1(object sender, PaintEventArgs e)
        {
            Class.UI.PanelPaint pp = new Class.UI.PanelPaint();
            pp.paint_PanelPurple1(sender, e);
        }
        #endregion

        private void FrmCodeTSite_Load(object sender, EventArgs e)
        {
            try
            {
                SetDataBind_treeView1();
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmCodeTSite.cs  (Function)::FrmCodeTSite_Load  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }


        private void SetDataBind_treeView1()
        {
            treeView1.Nodes.Clear();

            M_WsCodeTMainDB.WsCodeTMainDB wSvc = null;
            string reCode = "";
            string reMsg = "";
            M_WsCodeTMainDB.DataCodeTSiteTreeView[] getData1 = null;
            try
            {
                wSvc = new M_WsCodeTMainDB.WsCodeTMainDB();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/CodeT/WsCodeTMainDB.svc";
                wSvc.Timeout = 1000;

                ImageList myimageList = new ImageList();
                myimageList.Images.Add(Image.FromFile(@"Image\treeicon1.png"));

                treeView1.ImageList = myimageList;
                treeView1.ImageIndex = 0;

                reCode = wSvc.sCodeTSiteTreeView(AppInfo.SsDbNm, AppInfo.SsSiteCd, AppInfo.SsUserAuth, out getData1, out reMsg);
                if (reCode == "Y")
                {
                    if (getData1 != null && getData1.Length > 0)
                    {
                        for (int j = 0; j < getData1.Length; j++)
                        {
                            string ccode_val = getData1[j].CCODE.ToString();
                            string ccodeNm_val = getData1[j].CCODE_NM.ToString();

                            TreeNode root = new TreeNode();
                            root.Tag = ccode_val;
                            root.Text = ccodeNm_val;

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
                logs.SaveLog("[error]  (page)::FrmCodeTSite.cs  (Function)::SetDataBind_treeView1  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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

                _ccode = e.Node.Tag.ToString();
                lblName.Text = "** " + e.Node.Text;

                SetDataBind_gridView1(_ccode);

            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmCodeTSite.cs  (Function)::treeView1_AfterSelect  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        private void SetDataBind_gridView1(string _ccode)
        {
            M_WsCodeTMainDB.WsCodeTMainDB wSvc = null;
            string reCode = "";
            string reMsg = "";

            M_WsCodeTMainDB.DataCodeTSite[] getData1 = null;

            try
            {
                wSvc = new M_WsCodeTMainDB.WsCodeTMainDB();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/CodeT/WsCodeTMainDB.svc";
                wSvc.Timeout = 1000;

                reCode = wSvc.sCodeTSite(AppInfo.SsDbNm, AppInfo.SsSiteCd, _ccode, out getData1, out reMsg);
                if (reCode == "Y")
                {
                    if (getData1 != null && getData1.Length > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int i = 0; i < getData1.Length; i++)
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[i].Cells["dgv1_TCODE"].Value = getData1[i].TCODE.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_NM"].Value = getData1[i].TCODE_NM.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_DEFAULT_VALUE"].Value = getData1[i].DEFAULT_VALUE.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_USING_FLAG"].Value = getData1[i].USING_FLAG.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_SORT_NO"].Value = getData1[i].SORT_NO.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_MEMO"].Value = getData1[i].MEMO.ToString();
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
                logs.SaveLog("[error]  (page)::FrmCodeTSite.cs  (Function)::SetDataBind_gridView1  (Detail)::_ccode=[" + _ccode + "]", "Error");
                logs.SaveLog("[error]  (page)::FrmCodeTSite.cs  (Function)::SetDataBind_gridView1  (Detail)::reMsg=[" + reMsg + "]", "Error");
                logs.SaveLog("[error]  (page)::FrmCodeTSite.cs  (Function)::SetDataBind_gridView1  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
                logs.SaveLog("[error]  (page)::FrmCodeTSite.cs  (Function)::dataGridView1_CellBeginEdit  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
                logs.SaveLog("[error]  (page)::FrmCodeTSite.cs  (Function)::dataGridView1_ColumnHeaderMouseClick  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
            M_WsCodeTMainDB.WsCodeTMainDB wSvc = null;
            string reCode = "";
            string reMsg = "";
            string reData = "";

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
                            string tcode_val = dataGridView1.Rows[i].Cells["dgv1_TCODE"].Value.ToString();

                            string defaultValue_val = "";
                            if (dataGridView1.Rows[i].Cells["dgv1_DEFAULT_VALUE"].Value != null)
                                defaultValue_val = dataGridView1.Rows[i].Cells["dgv1_DEFAULT_VALUE"].Value.ToString();

                            string usingFlag_val = dataGridView1.Rows[i].Cells["dgv1_USING_FLAG"].Value.ToString();

                            string sortNo_val = "";
                            if (dataGridView1.Rows[i].Cells["dgv1_SORT_NO"].Value != null)
                                sortNo_val = dataGridView1.Rows[i].Cells["dgv1_SORT_NO"].Value.ToString();

                            string memo_val = "";
                            if (dataGridView1.Rows[i].Cells["dgv1_MEMO"].Value != null)
                                memo_val = dataGridView1.Rows[i].Cells["dgv1_MEMO"].Value.ToString();

                            reCode = wSvc.mCodeTSite(AppInfo.SsDbNm, AppInfo.SsSiteCd, tcode_val, defaultValue_val, usingFlag_val, sortNo_val, memo_val, out reMsg, out reData);

                            if (reCode == "Y" && reData != "")
                                reCnt += Convert.ToInt16(reData);
                        }
                    }
                }
                if (reCnt > 0)
                    MessageBox.Show("저장 성공" + " : " + reCnt.ToString());
                else
                    MessageBox.Show("저장 실패");

                SetDataBind_gridView1(_ccode);


            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmCodeTSite.cs  (Function)::btnSave_Click  (Detail):: " + "\r\n" + ex.ToString(), "Error");

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //    int sub_tmenuCd = 0;
            //    int sub_menuCd = 0;

            //    DataSet ds = null;

            //    if (AppInfo.SsUser_Id.ToLower() != "sysadmin" && AppInfo.SsUser_Id.ToLower() != "eldigmadmin")
            //    {
            //        if (Hub2Info.hub2SecurityYn == "Y" || Hub2Info.hub2WebConnectYn == "Y")
            //        {
            //            WebSvc_Worker.Worker wsWorker = null;
            //            try
            //            {
            //                wsWorker = new WebSvc_Worker.Worker();
            //                wsWorker.Url = Hub2Info.hub2SslType + AppInfo.SsServer + AppInfo.SsWebPort + "/SubForm/Worker/Worker.asmx";
            //                //wsLogin.Timeout = 60000;

            //                sub_tmenuCd = wsWorker.sTmenuCd(Hub2Info.hub2LoginKey, AppInfo.SsUser_Id, AppInfo.SsSite_Cd, AppInfo.SsAuth_Cd, "시스템관리");
            //                if (sub_tmenuCd.ToString() == "-100")
            //                    accessFail();

            //                sub_menuCd = wsWorker.sMenuCd(Hub2Info.hub2LoginKey, AppInfo.SsUser_Id, sub_tmenuCd.ToString(), AppInfo.SsSite_Cd, AppInfo.SsAuth_Cd, "menuSiteCode");
            //                if (sub_menuCd.ToString() == "-100")
            //                    accessFail();

            //                ds = wsWorker.sMenuAuth(Hub2Info.hub2LoginKey, AppInfo.SsUser_Id, AppInfo.SsSite_Cd, AppInfo.SsAuth_Cd, sub_menuCd.ToString());
            //                if (ds.Tables[0].TableName.ToString() == "ACCESS_FAIL")
            //                    accessFail();
            //            }
            //            catch (Exception ex)
            //            {
            //                logs.SaveLog("[error]  (page)::FrmWorkerDetail  (Function)::lblJob_Click  (Detail):: " + "\r\n" + ex.ToString());
            //            }
            //            finally
            //            {
            //                if (wsWorker != null)
            //                    wsWorker.Dispose();
            //            }

            //            if (ds.Tables[0].Rows.Count < 1)
            //            { // 권한 없음
            //                MessageBox.Show(msgRM.GetString("msgNoAuthority"));
            //                return;
            //            }
            //            else
            //            {
            //                if (ds.Tables[0].Rows[0]["AUTH_ADD_YN"].ToString() != "Y")
            //                { // 권한 없음
            //                    MessageBox.Show(msgRM.GetString("msgNoAuthority"));
            //                    return;
            //                }
            //            }
            //        }
            //        else
            //        {
            //            DbSite db = null;
            //            try
            //            {
            //                db = new DbSite();
            //                sub_tmenuCd = db.sTmenuCd(AppInfo.SsSite_Cd, AppInfo.SsAuth_Cd, "시스템관리");
            //                sub_menuCd = db.sMenuCd(sub_tmenuCd.ToString(), AppInfo.SsSite_Cd, AppInfo.SsAuth_Cd, "menuSiteCode");

            //                ds = db.sMenuAuth(AppInfo.SsSite_Cd, AppInfo.SsAuth_Cd, sub_menuCd.ToString());
            //            }
            //            catch (Exception ex)
            //            {
            //                logs.SaveLog("[error]  (page)::FrmWorkerDetail  (Function)::lblJob_Click  (Detail):: " + "\r\n" + ex.ToString());
            //            }
            //            finally
            //            {
            //                if (db != null)
            //                    db.DisConnect();
            //            }

            //            if (ds.Tables[0].Rows.Count < 1)
            //            { // 권한 없음
            //                MessageBox.Show(msgRM.GetString("msgNoAuthority"));
            //                return;
            //            }
            //            else
            //            {
            //                if (ds.Tables[0].Rows[0]["AUTH_ADD_YN"].ToString() != "Y")
            //                { // 권한 없음
            //                    MessageBox.Show(msgRM.GetString("msgNoAuthority"));
            //                    return;
            //                }
            //            }
            //        }
            //    }

            //    if (regCodeBool)
            //    {
            //        foreach (Form f in Application.OpenForms)
            //        {
            //            if (f.GetType().ToString() == "EldigmHub.SubForm.Sys.FrmCodeSite")
            //            {
            //                f.Close();
            //                break;
            //            }
            //        }

            //        Sys.FrmCodeSite frm = new Sys.FrmCodeSite("9");
            //        frm.StartPosition = FormStartPosition.CenterScreen;
            //        frm.ShowInTaskbar = false;
            //        frm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            //        frm.TopMost = true;
            //        //frm.Tag = thisTags;   // 2018.04.11 - 주석처리(권한관련)
            //        //this.AddOwnedForm(frm);

            //        string menu_Tag = "";

            //        if (AppInfo.SsUser_Id.ToLower() != "sysadmin" && AppInfo.SsUser_Id.ToLower() != "eldigmadmin")
            //        {
            //            string add = "N";
            //            string write = "N";
            //            string report = "N";
            //            string del = "N";

            //            if (ds.Tables[0].Rows.Count > 0)
            //            {
            //                add = ds.Tables[0].Rows[0]["AUTH_ADD_YN"].ToString();
            //                write = ds.Tables[0].Rows[0]["AUTH_WRITE_YN"].ToString();
            //                report = ds.Tables[0].Rows[0]["AUTH_REPORT_YN"].ToString();
            //                del = ds.Tables[0].Rows[0]["AUTH_DEL_YN"].ToString();
            //            }

            //            menu_Tag = sub_tmenuCd + "@" + sub_menuCd + "@" + "EldigmHub.SubForm.Sys.FrmCodeSite" + "@" + "Code" + "@" + add + "@" + write + "@" + report + "@" + del;
            //        }
            //        else
            //            menu_Tag = "" + "@" + "" + "@" + "EldigmHub.SubForm.Sys.FrmCodeSite" + "@" + "Code" + "@" + "Y" + "@" + "Y" + "@" + "Y" + "@" + "Y";

            //        frm.Tag = menu_Tag;

            //        DialogResult result = frm.ShowDialog();

            //        if (result == DialogResult.OK)
            //        {
            //            // 2016.04.20 - 주석 처리 시작
            //            //string selectedCode = cmbJob.SelectedValue.ToString();
            //            //setComboJob();
            //            //cmbJob.SelectedValue = selectedCode;
            //            // 2016.04.20 - 주석 처리 끝

            //            string selectedCode = "";
            //            if (cmbJob.Items.Count > 0)
            //                selectedCode = cmbJob.SelectedValue.ToString();

            //            setComboJob();

            //            if (selectedCode != "")
            //                cmbJob.SelectedValue = selectedCode;
            //        }
            //    }
        }


    }
}

