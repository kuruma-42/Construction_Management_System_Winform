using EldigmPlusApp.Config;
using Framework.Log;
using System;
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

namespace EldigmPlusApp.SubForm.Sys.CompanyTeam
{
    public partial class FrmTeam : Form
    {
        LogUtil logs = null;
        ResourceManager wRM = null;
        ResourceManager msgRM = null;


        public FrmTeam()
        {
            // Sets the UI culture
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(AppInfo.SsLanguage);
            this.AutoScaleMode = AutoScaleMode.Dpi;

            InitializeComponent();

            try
            {
                logs = new LogUtil();
                wRM = new ResourceManager("EldigmPlusApp.GlobalLanguage.word_Language", typeof(FrmTeam).Assembly);
                msgRM = new ResourceManager("EldigmPlusApp.GlobalLanguage.msg_Language", typeof(FrmTeam).Assembly);

                btnSearch.Text = wRM.GetString("wSearch");
                btnSave.Text = wRM.GetString("wSave");

                dataGridView1.Columns["dgv1_CHK"].HeaderText = wRM.GetString("wSelect");
                dataGridView1.Columns["dgv1_TEAM_CD"].HeaderText = wRM.GetString("wCode");
                dataGridView1.Columns["dgv1_TEAM_NM"].HeaderText = wRM.GetString("wName");
                dataGridView1.Columns["dgv1_USING_FLAG"].HeaderText = wRM.GetString("wUse");
                dataGridView1.Columns["dgv1_SORT_NO"].HeaderText = wRM.GetString("wSort");
                dataGridView1.Columns["dgv1_MEMO"].HeaderText = wRM.GetString("wMemo");


                dataGridView2.Columns["dgv2_TEAM_NM"].HeaderText = "*" + wRM.GetString("wName");
                dataGridView2.Columns["dgv2_SORT_NO"].HeaderText = wRM.GetString("wSort");
                dataGridView2.Columns["dgv2_MEMO"].HeaderText = wRM.GetString("wMemo");




                dataGridView2.Columns["dgv2_TEAM_NM"].HeaderCell.Style.ForeColor = Color.Maroon; // 헤더 필수 항목 빨강색

                Control.CheckForIllegalCrossThreadCalls = false;

                this.BackColor = Color.WhiteSmoke;

                splitContainer1.Panel1.BackColor = Color.LightSteelBlue;

                Class.Common.DatagrideViewStyleSet dvSet = new Class.Common.DatagrideViewStyleSet();
                dvSet.setStyle(dataGridView1, false, false);
                dvSet.setStyle(dataGridView2, false, false);

            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmTeam.cs  (Function)::FrmCompany  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        #region __ panel2 paint_Purple1
        private void paint_Purple1(object sender, PaintEventArgs e)
        {
            Class.UI.PanelPaint pp = new Class.UI.PanelPaint();
            pp.paint_PanelPurple1(sender, e);
        }
        #endregion

        private void FrmTeam_Load(object sender, EventArgs e)
        {
            try
            {
                SetDataBind_CompanyCmb();
                SetDataBind_gridView1();
                SetDataBind_grideView2();
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmTeam.cs  (Function)::FrmTeam_Load  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        //업체 콤보 박스 
        private void SetDataBind_CompanyCmb()
        {
            Mem_WsSysCompanyTeam.WsSysCompanyTeam wSvc = null;
            string reCode = "";
            string reMsg = "";
            Mem_WsSysCompanyTeam.DataCompanyCmb[] getData = null;
            try
            {
                wSvc = new Mem_WsSysCompanyTeam.WsSysCompanyTeam();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer1 + "/WebSvc/Sys/CompanyTeam/WsSysCompanyTeam.svc";
                wSvc.Timeout = 1000;

                reCode = wSvc.companyCmb(AppInfo.SsSiteCd, out getData, out reMsg);
                if (reCode == "Y")
                {
                    if (getData != null && getData.Length > 0)
                    {
                        Class.Common.ComboBoxItemSet setCmb = null;

                        setCmb = new Class.Common.ComboBoxItemSet();
                        setCmb.AddColumn();

                        for (int i = 0; i < getData.Length; i++)
                        {
                            setCmb.AddRow(getData[i].CO_NM.ToString(), getData[i].CO_CD.ToString());
                        }

                        setCmb.Bind(cmbCom);
                    }
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmSite.cs  (Function)::SetDataBind_CmbMember  (Detail):: " + "\r\n" + ex.ToString());
            }
        }


        private void SetDataBind_gridView1()
        {
            string searchTxt_val = "";
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                searchTxt_val = txtSearch.Text;
            }

            Mem_WsSysCompanyTeam.WsSysCompanyTeam wSvc = null;
            string reCode = "";
            string reMsg = "";
            Mem_WsSysCompanyTeam.DataTeam[] getData = null;
            try
            {
                wSvc = new Mem_WsSysCompanyTeam.WsSysCompanyTeam();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer1 + "/WebSvc/Sys/CompanyTeam/WsSysCompanyTeam.svc";
                wSvc.Timeout = 1000;

                reCode = wSvc.sTeam(AppInfo.SsSiteCd, cmbCom.SelectedValue.ToString(),"1", searchTxt_val, out getData, out reMsg);

                if (reCode == "Y")
                {
                    if (getData != null && getData.Length > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int i = 0; i < getData.Length; i++)
                        {

                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[i].Cells["dgv1_CHK"].Value = "0";
                            dataGridView1.Rows[i].Cells["dgv1_TEAM_CD"].Value = getData[i].TEAM_CD.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_TEAM_NM"].Value = getData[i].TEAM_NM.ToString();
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
                logs.SaveLog("[error]  (page)::FrmSysCode.cs  (Function)::SetDataBind_gridView1  (Detail)::reMsg=[" + reMsg + "]", "Error");
                logs.SaveLog("[error]  (page)::FrmSysCode.cs  (Function)::SetDataBind_gridView1  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
                logs.SaveLog("[error]  (page)::FrmSysCode.cs  (Function)::dataGridView1_CellBeginEdit  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
                logs.SaveLog("[error]  (page)::FrmSysCode.cs  (Function)::dataGridView1_ColumnHeaderMouseClick  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
                logs.SaveLog("[error]  (page)::FrmTeam.cs  (Function)::SetDataBind_grideView2  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }

        }
        //수정
        private void btnSave_Click(object sender, EventArgs e)
        {
            Mem_WsSysCompanyTeam.WsSysCompanyTeam wSvc = null;
            string reCode = "";
            string reMsg = "";
            string reData = "0";

            try
            {
                wSvc = new Mem_WsSysCompanyTeam.WsSysCompanyTeam();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer1 + "/WebSvc/Sys/CompanyTeam/WsSysCompanyTeam.svc";
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
                    MessageBox.Show(wRM.GetString("msgNotSelected"));
                    return;
                }

                reCnt = 0;


                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells["dgv1_CHK"].Value != null)
                    {
                        if (dataGridView1.Rows[i].Cells["dgv1_CHK"].Value.ToString() == "1")
                        {                                                       
                            string pTeamCd = dataGridView1.Rows[i].Cells["dgv1_TEAM_CD"].Value.ToString();
                            string pTeamNm = dataGridView1.Rows[i].Cells["dgv1_TEAM_NM"].Value.ToString();
                            string pUsingFlag = dataGridView1.Rows[i].Cells["dgv1_USING_FLAG"].Value.ToString();

                            string pSortNo = "10";
                            if (dataGridView1.Rows[i].Cells["dgv1_SORT_NO"].Value != null)
                                pSortNo = dataGridView1.Rows[i].Cells["dgv1_SORT_NO"].Value.ToString();

                            string pMemo = "";
                            if (dataGridView1.Rows[i].Cells["dgv1_MEMO"].Value != null)
                                pMemo = dataGridView1.Rows[i].Cells["dgv1_MEMO"].Value.ToString();                           

                            string pInputId = AppInfo.SsLabNo;
                            string pSiteCd = AppInfo.SsSiteCd;

                            reCode = wSvc.mTeamMemco( pSiteCd,  pTeamCd,  pTeamNm,  pUsingFlag,  pSortNo,  pMemo, out  reMsg, out  reData);

                            if (reCode == "Y" && reData != "0")
                                reCnt += Convert.ToInt16(reData);
                        }
                    }
                }
                if (reCnt > 0)
                {
                    MessageBox.Show(wRM.GetString("wSave") + " " + wRM.GetString("wSuccess"));
                }
                else
                {
                    MessageBox.Show(wRM.GetString("wSave") + " " + wRM.GetString("wFail"));
                }

                SetDataBind_gridView1();
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmTeam.cs  (Function)::btnSave_Click  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (wSvc != null)
                    wSvc.Dispose();
            }
        }

        //INSERT WITH PROCEDURE
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

                    string pSiteCd = AppInfo.SsSiteCd;
                    string pCoCd = cmbCom.SelectedValue.ToString();
                    string pTeamNm = dataGridView2.Rows[0].Cells["dgv2_TEAM_NM"].Value.ToString();

                    string pSortNo = "10";
                    if (dataGridView2.Rows[0].Cells["dgv2_SORT_NO"].Value != null)
                        pSortNo = dataGridView2.Rows[0].Cells["dgv2_SORT_NO"].Value.ToString();

                    string pMemo = "";
                    if (dataGridView2.Rows[0].Cells["dgv2_MEMO"].Value != null)
                        pMemo = dataGridView2.Rows[0].Cells["dgv2_MEMO"].Value.ToString();                                                          

                    string pInputId = AppInfo.SsLabNo;

                    Mem_WsSysCompanyTeam.WsSysCompanyTeam wSvc = null;
                    string reCode = "";
                    string reMsg = "";
                    string reData = "";
                    int reCnt = 0;
                    try
                    {
                        wSvc = new Mem_WsSysCompanyTeam.WsSysCompanyTeam();
                        wSvc.Url = "http://" + AppInfo.SsWsvcServer1 + "/WebSvc/Sys/CompanyTeam/WsSysCompanyTeam.svc";
                        wSvc.Timeout = 1000;


                        string[] param = new string[6];
                        param[0] = pSiteCd;
                        param[1] = pCoCd;
                        param[2] = pTeamNm;                      
                        param[3] = pMemo;
                        param[4] = pSortNo;
                        param[5] = pInputId;

                        //INSERT WITH PROCEDURE
                        reCode = wSvc.aTeamPro(AppInfo.SsDbNm, param, out reData, out reMsg);

                        if (reCode == "Y" && reData != "")
                            reCnt = Convert.ToInt16(reData);

                        if (reCnt != 0)
                            MessageBox.Show(wRM.GetString("wSave") + " " + wRM.GetString("wSuccess"));

                        else
                            MessageBox.Show(wRM.GetString("wSave") + " " + wRM.GetString("wFail"));


                        SetDataBind_gridView1();
                        SetDataBind_grideView2();
                    }
                    catch (Exception ex)
                    {
                        logs.SaveLog("[error]  (page)::FrmTeam.cs  (Function)::dataGridView2_CellClick  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
                if (dataGridView2.Rows[0].Cells["dgv2_TEAM_NM"].Value != null)
                {
                    if (dataGridView2.Rows[0].Cells["dgv2_TEAM_NM"].Value.ToString() == "")
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
                logs.SaveLog("[error]  (page)::FrmTeam.cs  (Function)::ChkDgv2Param  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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


        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                btnSearch_Click(null, null);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SetDataBind_gridView1();
        }

    
    }
}


