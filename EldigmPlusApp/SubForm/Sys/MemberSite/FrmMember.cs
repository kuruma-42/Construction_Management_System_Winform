using EldigmPlusApp.Config;
using Framework.Log;
using System;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Threading;
using System.Windows.Forms;

namespace EldigmPlusApp.SubForm.Sys.MemberSite
{
    public partial class FrmMember : Form
    {
        LogUtil logs = null;
        ResourceManager wRM = null;
        ResourceManager msgRM = null;

    

        public FrmMember()
        {
            // Sets the UI culture
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(AppInfo.SsLanguage);
            this.AutoScaleMode = AutoScaleMode.Dpi;

            InitializeComponent();

            try
            {
                logs = new LogUtil();
                wRM = new ResourceManager("EldigmPlusApp.GlobalLanguage.word_Language", typeof(FrmMember).Assembly);
                msgRM = new ResourceManager("EldigmPlusApp.GlobalLanguage.msg_Language", typeof(FrmMember).Assembly);

                //btnSearch.Text = wRM.GetString("lngSearch");
                btnSave.Text = wRM.GetString("wSave");

                dataGridView1.Columns["dgv1_CHK"].HeaderText = wRM.GetString("wSelect");
                dataGridView1.Columns["dgv1_MEMCO_CD"].HeaderText = wRM.GetString("wCode");
                dataGridView1.Columns["dgv1_MEMCO_NM"].HeaderText = wRM.GetString("wName");
                dataGridView1.Columns["dgv1_USING_FLAG"].HeaderText = wRM.GetString("wUse");
                dataGridView1.Columns["dgv1_SORT_NO"].HeaderText = wRM.GetString("wSort");
                dataGridView1.Columns["dgv1_MEMO"].HeaderText = wRM.GetString("wMemo");

                dataGridView2.Columns["dgv2_MEMCO_NM"].HeaderText = "*" + wRM.GetString("wName");
                dataGridView2.Columns["dgv2_SORT_NO"].HeaderText = wRM.GetString("wSort");
                dataGridView2.Columns["dgv2_MEMO"].HeaderText = wRM.GetString("wMemo");
                dataGridView2.Columns["dgv2_MEMCO_NM"].HeaderCell.Style.ForeColor = Color.Maroon; // 헤더 필수 항목 빨강색

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
                logs.SaveLog("[error]  (page)::FrmMember.cs  (Function)::FrmMember  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        #region __ panel2 paint_Purple1
        private void paint_Purple1(object sender, PaintEventArgs e)
        {
            Class.UI.PanelPaint pp = new Class.UI.PanelPaint();
            pp.paint_PanelPurple1(sender, e);
        }
        #endregion

        private void FrmMember_Load(object sender, EventArgs e)
        {
            try
            {                
                SetDataBind_treeView1();
                SetDataBind_grideView2();
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmMember.cs  (Function)::Form_Load  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }
              

        private void SetDataBind_treeView1()
        {
            treeView1.Nodes.Clear();

            M_WsMember.WsMember wSvc = null;
            string reCode = "";
            string reMsg = "";
            M_WsMember.DataMemberDB[] getData = null;
            try
            {
                wSvc = new M_WsMember.WsMember();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/MemberSite/WsMember.svc";
                wSvc.Timeout = 1000;

                ImageList myimageList = new ImageList();
                myimageList.Images.Add(Image.FromFile(@"Image\treeicon1.png"));

                treeView1.ImageList = myimageList;
                treeView1.ImageIndex = 0;

                TreeNode root = new TreeNode();
                root.Tag = "";
                root.Text = wRM.GetString("wTotal");

                reCode = wSvc.sMember_UsingFlag("", out getData, out reMsg);
                if (reCode == "Y")
                {
                    if (getData != null && getData.Length > 0)
                    {
                        for (int i = 0; i < getData.Length; i++)
                        {
                            string scodeGrp_val = getData[i].MEMCO_CD.ToString();
                            string scodeNm_val = getData[i].MEMCO_NM.ToString();

                            TreeNode node1 = new TreeNode();
                            node1.Tag = scodeGrp_val;
                            node1.Text = scodeNm_val;

                            root.Nodes.Add(node1);
                        }

                        treeView1.Nodes.Add(root);



                        if (treeView1.Nodes.Count > 0)
                            treeView1.SelectedNode = treeView1.GetNodeAt(0, 0);

                        treeView1.ExpandAll();
                    }
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmMember.cs  (Function)::setDataBind_treeView1  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
                
                    return;
                

                string pMemcoCD = "";

                pMemcoCD = e.Node.Tag.ToString();

                lblName.Text = "** " + e.Node.Text;

                SetDataBind_gridView1(pMemcoCD);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmMember.cs  (Function)::treeView1_AfterSelect  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        private void SetDataBind_gridView1(string pMemcoCD)
        {            

            M_WsMember.WsMember wSvc = null;
            string reCode = "";
            string reMsg = "";
            M_WsMember.DataMemberDB[] getData = null;
            try
            {
                wSvc = new M_WsMember.WsMember(); // 시스템 코드 보여주기 
                wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/MemberSite/WsMember.svc";
                wSvc.Timeout = 1000;

                reCode = wSvc.sMember(pMemcoCD, out getData, out reMsg);

                if (reCode == "Y")
                {
                    if (getData != null && getData.Length > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int i = 0; i < getData.Length; i++)
                        {

                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[i].Cells["dgv1_CHK"].Value = "0";
                            dataGridView1.Rows[i].Cells["dgv1_MEMCO_CD"].Value = getData[i].MEMCO_CD.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_MEMCO_NM"].Value = getData[i].MEMCO_NM.ToString();
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
                logs.SaveLog("[error]  (page)::FrmMember.cs  (Function)::SetDataBind_gridView1  (Detail)::pMemcoCD=[" + pMemcoCD + "]", "Error");
                logs.SaveLog("[error]  (page)::FrmMember.cs  (Function)::SetDataBind_gridView1  (Detail)::reMsg=[" + reMsg + "]", "Error");
                logs.SaveLog("[error]  (page)::FrmMember.cs  (Function)::SetDataBind_gridView1  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
                logs.SaveLog("[error]  (page)::FrmMember.cs  (Function)::dataGridView1_CellBeginEdit  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
                logs.SaveLog("[error]  (page)::FrmMember.cs  (Function)::dataGridView1_ColumnHeaderMouseClick  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SetRowNumber(dataGridView1);
        }

        //저장 
        private void btnSave_Click(object sender, EventArgs e)
        {
            M_WsMember.WsMember wSvc = null;
            string reCode = "";
            string reMsg = "";
            string reData = "";
            try
            {
                wSvc = new M_WsMember.WsMember();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/MemberSite/WsMember.svc";
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
                

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells["dgv1_CHK"].Value != null)
                    {
                        if (dataGridView1.Rows[i].Cells["dgv1_CHK"].Value.ToString() == "1")
                        {
                            string pMemcoCd = dataGridView1.Rows[i].Cells["dgv1_MEMCO_CD"].Value.ToString();
                            string pMemcoNm = dataGridView1.Rows[i].Cells["dgv1_MEMCO_NM"].Value.ToString();
                            string usingFlag_val = dataGridView1.Rows[i].Cells["dgv1_USING_FLAG"].Value.ToString();


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
                                                       

                            reCode = wSvc.mMember(pMemcoCd, pMemcoNm, usingFlag_val, sortNo_val, memo_val, out reMsg, out reData);

                            if (reCode == "Y" && reData != "")
                                reCnt = Convert.ToInt16(reData);

                            if (reCnt > 0)
                                MessageBox.Show(wRM.GetString("wSave") + " " + wRM.GetString("wSuccess") + " : " + reCnt.ToString());
                            else
                                MessageBox.Show(wRM.GetString("wSave") + " " + wRM.GetString("wFail"));

                            SetDataBind_gridView1(pMemcoCd);
                            SetDataBind_treeView1();
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                logs.SaveLog("[error]  (page)::FrmMember.cs  (Function)::btnSave_Click  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (wSvc != null)
                    wSvc.Dispose();
            }
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
                logs.SaveLog("[error]  (page)::FrmMember.cs  (Function)::SetDataBind_grideView2  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
                    
                    string pMemcoNm = dataGridView2.Rows[0].Cells["dgv2_MEMCO_NM"].Value.ToString();
                    string pDb_Nm = AppInfo.SsDbNm;
                    string sortNo_val = "10";
                    if (dataGridView2.Rows[0].Cells["dgv2_SORT_NO"].Value != null)
                        sortNo_val = dataGridView2.Rows[0].Cells["dgv2_SORT_NO"].Value.ToString();

                    string memo_val = "";
                    if (dataGridView2.Rows[0].Cells["dgv2_MEMO"].Value != null)
                        memo_val = dataGridView2.Rows[0].Cells["dgv2_MEMO"].Value.ToString();
                    string usingFlag_val = "1";
                    string pInputId = AppInfo.SsLabNo;

                    M_WsMember.WsMember wSvc = null;
                    string reCode = "";
                    string reMsg = "";
                    string reData = "";
                    try
                    {
                        wSvc = new M_WsMember.WsMember();
                        wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/MemberSite/WsMember.svc";
                        wSvc.Timeout = 1000;

                        int reCnt = 0;

                        reCode = wSvc.exMember(AppInfo.SsMemcoCd, pMemcoNm, out reMsg, out reData);
                        if (reCode == "Y" && reData != "0")
                        {                            
                            //중복데이터 체크 후 USING FLAG 1로 업데이트 
                            //본인이 소속된 SiteCd
                            reCode = wSvc.mMember(AppInfo.SsSiteCd, pMemcoNm, usingFlag_val, sortNo_val, memo_val, out reMsg, out reData);
                            MessageBox.Show(wRM.GetString("msgDuplicated") + " " + wRM.GetString("msgChangeUsingFlag"));
                        }
                        else
                        {
                            //중복 없으면 인서트 
                            reCode = "";
                            reCode = wSvc.aMember(pMemcoNm, AppInfo.SsDbNm, usingFlag_val, sortNo_val, memo_val, pInputId, out reMsg, out reData);

                            if (reCode == "Y" && reData != "")
                                reCnt = Convert.ToInt16(reData);

                            if (reCnt > 0)
                                MessageBox.Show(wRM.GetString("wSave") + " " + wRM.GetString("wSuccess") + " : " + reCnt.ToString());
                            else
                                MessageBox.Show(wRM.GetString("wSave") + " " + wRM.GetString("wFail"));
                        }

                                             
                        SetDataBind_gridView1(AppInfo.SsMemcoCd);
                        SetDataBind_treeView1();
                    }
                    catch (Exception ex)
                    {
                        logs.SaveLog("[error]  (page)::FrmMember.cs  (Function)::dataGridView2_CellClick  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
                if (dataGridView2.Rows[0].Cells["dgv2_MEMCO_NM"].Value != null)
                {
                    if (dataGridView2.Rows[0].Cells["dgv2_MEMCO_NM"].Value.ToString() == "")
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
                logs.SaveLog("[error]  (page)::FrmMember.cs  (Function)::ChkDgv2Param  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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

       
    }
}