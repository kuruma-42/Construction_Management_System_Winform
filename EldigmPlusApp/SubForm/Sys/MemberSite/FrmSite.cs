using EldigmPlusApp.Config;
using Framework.Log;
using System;
using System.Collections;
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

namespace EldigmPlusApp.SubForm.Sys.MemberSite
{
    public partial class FrmSite : Form
    {
        LogUtil logs = null;
        ResourceManager wRM = null;
        ResourceManager msgRM = null;
        string _dbNm = "";

        public FrmSite()
        {
            // Sets the UI culture
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(AppInfo.SsLanguage);
            this.AutoScaleMode = AutoScaleMode.Dpi;

            InitializeComponent(); try
            {
                logs = new LogUtil();
                wRM = new ResourceManager("EldigmPlusApp.GlobalLanguage.word_Language", typeof(FrmSite).Assembly);
                msgRM = new ResourceManager("EldigmPlusApp.GlobalLanguage.msg_Language", typeof(FrmSite).Assembly);


                btnSave.Text = wRM.GetString("wSave");
                dataGridView1.Columns["dgv1_CHK"].HeaderText = wRM.GetString("wSelect");
                dataGridView1.Columns["dgv1_SITE_CD"].HeaderText = wRM.GetString("wSite") + wRM.GetString("wCode");
                dataGridView1.Columns["dgv1_MEMCO_CD"].HeaderText = wRM.GetString("wMember") + wRM.GetString("wCode");
                dataGridView1.Columns["dgv1_SITE_NM"].HeaderText = wRM.GetString("wSite") + wRM.GetString("wName");
                dataGridView1.Columns["dgv1_USING_FLAG"].HeaderText = msgRM.GetString("msgUsageStatus");
                dataGridView1.Columns["dgv1_SORT_NO"].HeaderText = wRM.GetString("wSort");
                dataGridView1.Columns["dgv1_MEMO"].HeaderText = wRM.GetString("wMemo");


                dataGridView2.Columns["dgv2_SITE_NM"].HeaderText = "*" + wRM.GetString("wSite") + wRM.GetString("wName");
                dataGridView2.Columns["dgv2_SORT_NO"].HeaderText = wRM.GetString("wSort");
                dataGridView2.Columns["dgv2_HEADCO_CD"].HeaderText = wRM.GetString("wHeadOffice");
                dataGridView2.Columns["dgv2_MEMO"].HeaderText = wRM.GetString("wMemo");


                dataGridView2.Columns["dgv2_SITE_NM"].HeaderCell.Style.ForeColor = Color.Maroon;  // 헤더 필수 항목 빨강색



                Control.CheckForIllegalCrossThreadCalls = false;

                this.BackColor = Color.WhiteSmoke;

                splitContainer1.Panel1.BackColor = Color.LightSteelBlue;

                Class.Common.DatagrideViewStyleSet dvSet = new Class.Common.DatagrideViewStyleSet();
                dvSet.setStyle(dataGridView1, false, false);
                dvSet.setStyle(dataGridView2, false, false);

                lblName.BackColor = Color.FromArgb(204, 219, 243);
                this.panel1.Paint += new PaintEventHandler(this.paint_Purple1);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmSysAuthMainDB.cs  (Function)::FrmSysCode  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        #region __ panel2 paint_Purple1
        private void paint_Purple1(object sender, PaintEventArgs e)
        {
            Class.UI.PanelPaint pp = new Class.UI.PanelPaint();
            pp.paint_PanelPurple1(sender, e);
        }



        #endregion

        private void FrmSite_Load(object sender, EventArgs e)
        {
            try
            {
                GetDbNm();
                SetDataBind_CmbMember();
                SetDataBind_Combo();
                SetDataBind_gridView1();
                SetDataBind_gridView2();
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmSite.cs  (Function)::Form_Load  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        private void GetDbNm()
        {
            Mem_WsSysAuthMemberDB.WsSysAuthMemberDB wSvc = null;
            string reCode = "";
            string reMsg = "";
            string reData = "";
            try
            {
                wSvc = new Mem_WsSysAuthMemberDB.WsSysAuthMemberDB();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer1 + "/WebSvc/Sys/SysAuth/WsSysAuthMemberDB.svc";
                wSvc.Timeout = 1000;

                reCode = wSvc.sDbNm(AppInfo.SsMemcoCd, out reData, out reMsg);

                if (reCode == "Y")
                {
                    if (!string.IsNullOrEmpty(reData))
                        _dbNm = reData;
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmSysAuthMemberDB.cs  (Function)::GetDbNm  (Detail)::reCode=[" + reCode + "], reMsg=[" + reMsg + "]", "Error");
                logs.SaveLog("[error]  (page)::FrmSysAuthMemberDB.cs  (Function)::GetDbNm  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (wSvc != null)
                    wSvc.Dispose();
            }
        }

        private void SetDataBind_CmbMember()
        {
            M_WsMember.WsMember wSvc = null;
            string reCode = "";
            string reMsg = "";
            M_WsMember.DataMemberMainDB[] getData = null;
            try
            {
                wSvc = new M_WsMember.WsMember();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/MemberSite/WsMember.svc";
                wSvc.Timeout = 1000;

                reCode = wSvc.sMemberMainDB(out getData, out reMsg);
                if (reCode == "Y")
                {
                    if (getData != null && getData.Length > 0)
                    {
                        Class.Common.ComboBoxItemSet setCmb = null;

                        setCmb = new Class.Common.ComboBoxItemSet();
                        setCmb.AddColumn();

                        for (int i = 0; i < getData.Length; i++)
                        {
                            setCmb.AddRow(getData[i].MEMCO_NM.ToString(), getData[i].MEMCO_CD.ToString());
                        }

                        setCmb.Bind(cmbMember);
                    }
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmSite.cs  (Function)::SetDataBind_CmbMember  (Detail):: " + "\r\n" + ex.ToString());
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

                cmbUse.SelectedIndex = cmbUse.Items.Count - 1;

            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmSysAuthMainDB.cs  (Function)::setDataBind_Combo  (Detail):: " + "\r\n" + ex.ToString());
            }

        }



        private void SetDataBind_gridView1()
        {
            M_WsMember.WsMember wSvc = null;
            string reCode = "";
            string reMsg = "";
            M_WsMember.DataSiteDB[] getData = null;
            try
            {
                wSvc = new M_WsMember.WsMember();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/MemberSite/WsMember.svc";
                wSvc.Timeout = 1000;
                string pUsing_Flag = "";

                if (cmbMember.SelectedValue != null)
                {
                    //CMB BOX SELECTED                     
                    reCode = wSvc.sSite(cmbMember.SelectedValue.ToString(), pUsing_Flag, out getData, out reMsg);
                }



                if (reCode == "Y")
                {
                    if (getData != null && getData.Length > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int i = 0; i < getData.Length; i++)
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[i].Cells["dgv1_SITE_CD"].Value = getData[i].SITE_CD.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_MEMCO_CD"].Value = getData[i].MEMCO_CD.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_SITE_NM"].Value = getData[i].SITE_NM.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_USING_FLAG"].Value = getData[i].USING_FLAG.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_SORT_NO"].Value = getData[i].SORT_NO.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_MEMO"].Value = getData[i].MEMO.ToString();
                        }

                        SetRowNumber(dataGridView1);
                    }
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmSite.cs  (Function)::SetDataBind_gridView1  (Detail)::reMsg=[" + reMsg + "]", "Error");
                logs.SaveLog("[error]  (page)::FrmSite.cs  (Function)::SetDataBind_gridView1  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (wSvc != null)
                    wSvc.Dispose();
            }
        }



        //수정
        private void btnSave_Click(object sender, EventArgs e)
        {
            M_WsMember.WsMember wSvc = null;
            string reCode = "";
            string reMsg = "";
            string reData = "0";
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

                reCnt = 0;

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells["dgv1_CHK"].Value != null)
                    {
                        if (dataGridView1.Rows[i].Cells["dgv1_CHK"].Value.ToString() == "1")
                        {

                            string siteCd_val = dataGridView1.Rows[i].Cells["dgv1_SITE_CD"].Value.ToString();
                            string memcoCd_val = dataGridView1.Rows[i].Cells["dgv1_MEMCO_CD"].Value.ToString();
                            //string memcoNm_val = dataGridView1.Rows[i].Cells["dgv1_SITE_NM"].Value.ToString();
                            string siteNm_val = dataGridView1.Rows[i].Cells["dgv1_SITE_NM"].Value.ToString();
                            string usingFlag_val = dataGridView1.Rows[i].Cells["dgv1_USING_FLAG"].Value.ToString();

                            string sortNo_val = "1";
                            if (dataGridView1.Rows[i].Cells["dgv1_SORT_NO"].Value != null)
                            {
                                sortNo_val = dataGridView1.Rows[i].Cells["dgv1_SORT_NO"].Value.ToString();
                            }

                            string memo_val = "";
                            if (dataGridView1.Rows[i].Cells["dgv1_MEMO"].Value != null)
                            {
                                memo_val = dataGridView1.Rows[i].Cells["dgv1_MEMO"].Value.ToString();
                            }




                            reCode = wSvc.mSite(siteCd_val, siteNm_val, usingFlag_val, sortNo_val, memo_val, out reMsg, out reData);



                            if (reCode == "Y" && reData != "0")
                                reCnt += Convert.ToInt16(reData);
                        }
                    }
                }
                if (reCnt > 0)
                    MessageBox.Show(wRM.GetString("wSave") + " " + wRM.GetString("wSuccess") + " : " + reCnt.ToString());
                else
                    MessageBox.Show(wRM.GetString("wSave") + " " + wRM.GetString("wFail"));

                SetDataBind_gridView1();
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmSite.cs  (Function)::btnSave_Click  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (wSvc != null)
                    wSvc.Dispose();
            }
        }






        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SetRowNumber(dataGridView1);
        }

        //열번호 자동 
        private void SetRowNumber(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
                row.HeaderCell.Value = String.Format("{0}", row.Index + 1);

            dgv.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }

        private void SetDataBind_gridView2()
        {
            try
            {
                dataGridView2.Rows.Clear();
                dataGridView2.Rows.Add();
                dataGridView2.Rows[0].Cells["dgv2_SORT_NO"].Value = "10";
                dataGridView2.Rows[0].Cells["dgv2_MEMO"].Value = "";
                dataGridView2.Rows[0].Cells["dgv2_BTNADD"].Value = wRM.GetString("wAdd");
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmSite.cs  (Function)::setDataBind_grideView2  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }


        //추가버튼 클릭 
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int reCnt = 0;
            string colNm = dataGridView2.Columns[e.ColumnIndex].Name;

            if (colNm == "dgv2_BTNADD")
            {
                string reVal = ChkDgv2Param();

                if (reVal != "")
                    MessageBox.Show(wRM.GetString("wCheck") + " :: " + reVal);
                else
                {
                    string memcoCd_val = cmbMember.SelectedValue.ToString();
                    string siteNm_val = dataGridView2.Rows[0].Cells["dgv2_SITE_NM"].Value.ToString();                    

                    string sortNo_val = "10";
                    if (dataGridView2.Rows[0].Cells["dgv2_SORT_NO"].Value != null)
                        sortNo_val = dataGridView2.Rows[0].Cells["dgv2_SORT_NO"].Value.ToString();                    

                    string memo_val = "";
                    if (dataGridView2.Rows[0].Cells["dgv2_MEMO"].Value != null)
                        memo_val = dataGridView2.Rows[0].Cells["dgv2_MEMO"].Value.ToString();

                    string pInputId = AppInfo.SsLabNo;

                    string headcoCd_val = "";
                    if (dataGridView2.Rows[0].Cells["dgv2_HEADCO_CD"].Value != null)
                        headcoCd_val = dataGridView2.Rows[0].Cells["dgv2_HEADCO_CD"].Value.ToString();



                    M_WsMember.WsMember wSvc = null;
                    string reCode = "";
                    string reMsg = "";
                    string reData = "";
                    try
                    {
                        wSvc = new M_WsMember.WsMember();
                        wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/MemberSite/WsMember.svc";
                        wSvc.Timeout = 1000;


                        string[] param = new string[6];
                        param[0] = memcoCd_val;
                        param[1] = siteNm_val;
                        param[2] = sortNo_val;
                        param[3] = memo_val;
                        param[4] = pInputId;
                        param[5] = headcoCd_val;

                        reCode = wSvc.aSite(_dbNm, param, out reMsg, out reData);



                        if (reCode == "Y" && reData != "0")
                            reCnt += Convert.ToInt16(reData);

                        if (reCnt > 0)
                        {
                            MessageBox.Show(wRM.GetString("wSave") + " " + wRM.GetString("wSuccess"));
                        }
                        else
                        {
                            MessageBox.Show(wRM.GetString("wSave") + " " + wRM.GetString("wFail"));
                        }

                        SetDataBind_gridView1();
                        SetDataBind_gridView2();


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
        //파라미터 값 확인 
        private string ChkDgv2Param()
        {
            string reVal = "";

            try
            {
                if (dataGridView2.Rows[0].Cells["dgv2_SITE_NM"].Value != null)
                {
                    if (dataGridView2.Rows[0].Cells["dgv2_SITE_NM"].Value.ToString() == "")
                    {
                        reVal = wRM.GetString("wSite") + wRM.GetString("wName");
                        return reVal;
                    }
                }
                else
                {
                    reVal = wRM.GetString("wSite") + wRM.GetString("wName");
                    return reVal;
                }

            }
            catch (Exception ex)
            {
                reVal = wRM.GetString("wError");
                logs.SaveLog("[error]  (page)::FrmSite.cs  (Function)::ChkDgv2Param  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }

            return reVal;
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
                logs.SaveLog("[error]  (page)::FrmSite.cs  (Function)::dataGridView1_CellBeginEdit  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }
        bool chkUseAll = false;
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            try
            {
                string columnNm = dataGridView1.Columns[e.ColumnIndex].Name;
                if (columnNm == "dgv1_CHK" || columnNm == "dgv1_USING_FLAG" || columnNm == "dgv1_MYBLOCK_FLAG" || columnNm == "dgv1_MYCON_FLAG" || columnNm == "dgv1_MYCOM_FLAG" || columnNm == "dgv1_MYTEAM_FLAG")
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
                logs.SaveLog("[error]  (page)::FrmSite.cs  (Function)::dataGridView1_ColumnHeaderMouseClick  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        private void NoSelectGrideView(DataGridView dgv)
        {
            dgv.ClearSelection();
            dgv.CurrentCell = null;
        }


        private void cmbMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDataBind_gridView1();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

