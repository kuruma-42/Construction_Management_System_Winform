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
        ResourceManager lngRM = null;
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
                lngRM = new ResourceManager("EldigmPlusApp.strLanguage", typeof(FrmCompany).Assembly);
                msgRM = new ResourceManager("EldigmPlusApp.msgLanguage", typeof(FrmCompany).Assembly);

                btnSearch.Text = lngRM.GetString("lngSearch");
                btnSave.Text = "저장";

                dataGridView1.Columns["dgv1_CHK"].HeaderText = "선택";
                dataGridView1.Columns["dgv1_CO_CD"].HeaderText = "업체 코드";
                dataGridView1.Columns["dgv1_CO_NM"].HeaderText = "업체 이름";
                dataGridView1.Columns["dgv1_USING_FLAG"].HeaderText = "사용";
                dataGridView1.Columns["dgv1_HEADCO_CD"].HeaderText = "본사";
                dataGridView1.Columns["dgv1_CONST_CCD"].HeaderText = "공종";
                dataGridView1.Columns["dgv1_CO_TYPE_SCD"].HeaderText = "업체구분";
                dataGridView1.Columns["dgv1_SITE_CD"].HeaderText = "현장";
                dataGridView1.Columns["dgv1_START_DATE"].HeaderText = "시작일";
                dataGridView1.Columns["dgv1_END_DATE"].HeaderText = "종료일";
                dataGridView1.Columns["dgv1_BIZ_NO"].HeaderText = "사업자 번호";
                dataGridView1.Columns["dgv1_OWNER_NM"].HeaderText = "대표자";
                dataGridView1.Columns["dgv1_TEL"].HeaderText = "연락처";
                dataGridView1.Columns["dgv1_ADDR"].HeaderText = "주소";
                dataGridView1.Columns["dgv1_USING_CNT"].HeaderText = "사용 현장";
                dataGridView1.Columns["dgv1_SORT_NO"].HeaderText = "정렬";
                dataGridView1.Columns["dgv1_MEMO"].HeaderText = "메모";



                dataGridView2.Columns["dgv2_CO_NM"].HeaderText = "*업체 이름";
                dataGridView2.Columns["dgv2_BIZ_NO"].HeaderText = "사업자 번호";
                dataGridView2.Columns["dgv2_CONST_CCD"].HeaderText = "공종";
                dataGridView2.Columns["dgv2_CO_TYPE_SCD"].HeaderText = "업체구분";
                dataGridView2.Columns["dgv2_OWNER_NM"].HeaderText = "대표자";
                dataGridView2.Columns["dgv2_TEL"].HeaderText = "연락처";
                dataGridView2.Columns["dgv2_ADDR"].HeaderText = "주소";
                dataGridView2.Columns["dgv2_SORT_NO"].HeaderText = "정렬";
                dataGridView2.Columns["dgv2_MEMO"].HeaderText = "메모";




                dataGridView2.Columns["dgv2_CO_NM"].HeaderCell.Style.ForeColor = Color.Maroon; // 헤더 필수 항목 빨강색

                Control.CheckForIllegalCrossThreadCalls = false;

                this.BackColor = Color.WhiteSmoke;

                splitContainer1.Panel1.BackColor = Color.LightSteelBlue;

                Class.Common.DatagrideViewStyleSet dvSet = new Class.Common.DatagrideViewStyleSet();
                dvSet.setStyle(dataGridView1, false, false);
                dvSet.setStyle(dataGridView2, false, false);

            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmCompany.cs  (Function)::FrmCompany  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        #region __ panel2 paint_Purple1
        private void paint_Purple1(object sender, PaintEventArgs e)
        {
            Class.UI.PanelPaint pp = new Class.UI.PanelPaint();
            pp.paint_PanelPurple1(sender, e);
        }
        #endregion

        private void FrmCompany_Load(object sender, EventArgs e)
        {
            try
            {
                SetDataBind_Combo();
                SetDataBind_gridView1();
                SetDataBind_grideView2();
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmCompany.cs  (Function)::FrmCompany_Load  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        private void SetDataBind_Combo()
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

                        setCmb.Bind(cmbCom);
                    }
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmSite.cs  (Function)::SetDataBind_CmbMember  (Detail):: " + "\r\n" + ex.ToString());
            }
        }

        //private void SetDataBind_Combo()
        //{
        //    try
        //    {
        //        Class.Common.ComboBoxItemSet setCmb = null;

        //        setCmb = new Class.Common.ComboBoxItemSet();

        //        setCmb.AddColumn();

        //        setCmb.AddRow("사용", "1");
        //        setCmb.AddRow("전체", "");

        //        setCmb.Bind(cmbUse);

        //    }
        //    catch (Exception ex)
        //    {
        //        logs.SaveLog("[error]  (page)::FrmCompany.cs  (Function)::FrmCompany_Load  (Detail):: " + "\r\n" + ex.ToString());
        //    }

        //}



        private void set_Grideview1Combo1(int rnum, string column_name)
        {
            Mem_WsSysCompanyTeam.WsSysCompanyTeam wSvc = null;
            string reCode = "";
            string reMsg = "";
            Mem_WsSysCompanyTeam.DataConstCmb[] getData = null;
            try
            {
                wSvc = new Mem_WsSysCompanyTeam.WsSysCompanyTeam();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer1 + "/WebSvc/Sys/CompanyTeam/WsSysCompanyTeam.svc";
                wSvc.Timeout = 1000;

                reCode = wSvc.constCmb(AppInfo.SsSiteCd, out getData, out reMsg);
                if (reCode == "Y")
                {
                    if (getData != null && getData.Length > 0)
                    {
                        Class.Common.ComboBoxItemSet setCmb = null;

                        setCmb = new Class.Common.ComboBoxItemSet();
                        setCmb.AddColumn();

                        for (int i = 0; i < getData.Length; i++)
                        {
                            setCmb.AddRow(getData[i].TEXT.ToString(), getData[i].VALUE.ToString());
                        }
                        DataGridViewComboBoxCell constCombo1 = new DataGridViewComboBoxCell();

                        constCombo1.DisplayMember = "TEXT";
                        constCombo1.ValueMember = "VALUE";

                        constCombo1.DataSource = setCmb.GetDataTable();

                        dataGridView1.Rows[rnum].Cells[column_name] = constCombo1;
                    }
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmCompany.cs  (Function)::SetDataBind_CmbMember  (Detail):: " + "\r\n" + ex.ToString());
            }
        }

        private void set_Grideview1Combo2(int rnum, string column_name)
        {
            Mem_WsSysCompanyTeam.WsSysCompanyTeam wSvc = null;
            string reCode = "";
            string reMsg = "";
            Mem_WsSysCompanyTeam.DataCotypeCmb[] getData = null;
            try
            {
                wSvc = new Mem_WsSysCompanyTeam.WsSysCompanyTeam();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer1 + "/WebSvc/Sys/CompanyTeam/WsSysCompanyTeam.svc";
                wSvc.Timeout = 1000;

                reCode = wSvc.cotype_Cmb(out getData, out reMsg);
                if (reCode == "Y")
                {
                    if (getData != null && getData.Length > 0)
                    {
                        Class.Common.ComboBoxItemSet setCmb = null;

                        setCmb = new Class.Common.ComboBoxItemSet();
                        setCmb.AddColumn();

                        for (int i = 0; i < getData.Length; i++)
                        {
                            setCmb.AddRow(getData[i].TEXT.ToString(), getData[i].VALUE.ToString());
                        }
                        DataGridViewComboBoxCell cotype_Combo1 = new DataGridViewComboBoxCell();

                        cotype_Combo1.DisplayMember = "TEXT";
                        cotype_Combo1.ValueMember = "VALUE";

                        cotype_Combo1.DataSource = setCmb.GetDataTable();

                        dataGridView1.Rows[rnum].Cells[column_name] = cotype_Combo1;
                    }
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmCompany.cs  (Function)::set_Grideview1Combo2  (Detail):: " + "\r\n" + ex.ToString());
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
            Mem_WsSysCompanyTeam.DataCompany[] getData = null;
            try
            {
                wSvc = new Mem_WsSysCompanyTeam.WsSysCompanyTeam();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer1 + "/WebSvc/Sys/CompanyTeam/WsSysCompanyTeam.svc";
                wSvc.Timeout = 1000;

                reCode = wSvc.sCompany(AppInfo.SsSiteCd, cmbCom.SelectedValue.ToString(), searchTxt_val, out getData, out reMsg);

                if (reCode == "Y")
                {
                    if (getData != null && getData.Length > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int i = 0; i < getData.Length; i++)
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[i].Cells["dgv1_CHK"].Value = "0";
                            dataGridView1.Rows[i].Cells["dgv1_CO_CD"].Value = getData[i].CO_CD.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_CO_NM"].Value = getData[i].CO_NM.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_USING_FLAG"].Value = getData[i].USING_FLAG.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_HEADCO_CD"].Value = getData[i].HEADCO_CD.ToString();
                            set_Grideview1Combo1(i, "dgv1_CONST_CCD");
                            dataGridView1.Rows[i].Cells["dgv1_CONST_CCD"].Value = getData[i].CONST_CCD.ToString();
                            set_Grideview1Combo2(i, "dgv1_CO_TYPE_SCD");
                            dataGridView1.Rows[i].Cells["dgv1_CO_TYPE_SCD"].Value = getData[i].CO_TYPE_SCD.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_SITE_CD"].Value = getData[i].SITE_CD.ToString();

                            string startDt = getData[i].START_DATE.ToString();
                            DateTime start_dt = Convert.ToDateTime(startDt.Substring(0, 4) + "-" + startDt.Substring(4, 2) + "-" + startDt.Substring(6));
                            dataGridView1.Rows[i].Cells["dgv1_START_DATE"].Value = start_dt;

                            string endDt = getData[i].END_DATE.ToString();
                            DateTime end_dt = Convert.ToDateTime(startDt.Substring(0, 4) + "-" + startDt.Substring(4, 2) + "-" + startDt.Substring(6));
                            dataGridView1.Rows[i].Cells["dgv1_END_DATE"].Value = end_dt;

                            dataGridView1.Rows[i].Cells["dgv1_BIZ_NO"].Value = getData[i].BIZ_NO.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_OWNER_NM"].Value = getData[i].OWNER_NM.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_TEL"].Value = getData[i].TEL.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_ADDR"].Value = getData[i].ADDR.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_USING_CNT"].Value = getData[i].USING_CNT.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_SORT_NO"].Value = getData[i].SORT_NO.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_MEMO"].Value = getData[i].MEMO.ToString();

                            dataGridView2.Columns["dgv2_CO_NM"].HeaderText = "*업체 이름";
                            dataGridView2.Columns["dgv2_BIZ_NO"].HeaderText = "사업자 번호";
                            dataGridView2.Columns["dgv2_CONST_CCD"].HeaderText = "공종";
                            dataGridView2.Columns["dgv2_CO_TYPE_SCD"].HeaderText = "업체구분";
                            dataGridView2.Columns["dgv2_OWNER_NM"].HeaderText = "대표자";
                            dataGridView2.Columns["dgv2_TEL"].HeaderText = "연락처";
                            dataGridView2.Columns["dgv2_ADDR"].HeaderText = "주소";
                            dataGridView2.Columns["dgv2_SORT_NO"].HeaderText = "정렬";
                            dataGridView2.Columns["dgv2_MEMO"].HeaderText = "메모";

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

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SetRowNumber(dataGridView1);
        }

        private void set_Grideview2Combo1(int rnum, string column_name)
        {
            Mem_WsSysCompanyTeam.WsSysCompanyTeam wSvc = null;
            string reCode = "";
            string reMsg = "";
            Mem_WsSysCompanyTeam.DataConstCmb2[] getData = null;
            try
            {
                wSvc = new Mem_WsSysCompanyTeam.WsSysCompanyTeam();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer1 + "/WebSvc/Sys/CompanyTeam/WsSysCompanyTeam.svc";
                wSvc.Timeout = 1000;

                reCode = wSvc.constCmb2(AppInfo.SsSiteCd, out getData, out reMsg);
                if (reCode == "Y")
                {
                    if (getData != null && getData.Length > 0)
                    {
                        Class.Common.ComboBoxItemSet setCmb = null;

                        setCmb = new Class.Common.ComboBoxItemSet();
                        setCmb.AddColumn();

                        for (int i = 0; i < getData.Length; i++)
                        {
                            setCmb.AddRow(getData[i].CCODE_NM.ToString(), getData[i].CCODE.ToString());
                        }
                        DataGridViewComboBoxCell constCombo1 = new DataGridViewComboBoxCell();

                        constCombo1.DisplayMember = "TEXT";
                        constCombo1.ValueMember = "VALUE";

                        constCombo1.DataSource = setCmb.GetDataTable();

                        dataGridView2.Rows[rnum].Cells[column_name] = constCombo1;
                    }
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmCompany.cs  (Function)::SetDataBind_CmbMember  (Detail):: " + "\r\n" + ex.ToString());
            }
        }

        private void set_Grideview2Combo2(int rnum, string column_name)
        {
            Mem_WsSysCompanyTeam.WsSysCompanyTeam wSvc = null;
            string reCode = "";
            string reMsg = "";
            Mem_WsSysCompanyTeam.DataCotypeCmb2[] getData = null;
            try
            {
                wSvc = new Mem_WsSysCompanyTeam.WsSysCompanyTeam();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer1 + "/WebSvc/Sys/CompanyTeam/WsSysCompanyTeam.svc";
                wSvc.Timeout = 1000;

                reCode = wSvc.cotype_Cmb2(out getData, out reMsg);
                if (reCode == "Y")
                {
                    if (getData != null && getData.Length > 0)
                    {
                        Class.Common.ComboBoxItemSet setCmb = null;

                        setCmb = new Class.Common.ComboBoxItemSet();
                        setCmb.AddColumn();

                        for (int i = 0; i < getData.Length; i++)
                        {
                            setCmb.AddRow(getData[i].SCODE_NM.ToString(), getData[i].SCODE.ToString());
                        }
                        DataGridViewComboBoxCell cotype_Combo1 = new DataGridViewComboBoxCell();

                        cotype_Combo1.DisplayMember = "TEXT";
                        cotype_Combo1.ValueMember = "VALUE";

                        cotype_Combo1.DataSource = setCmb.GetDataTable();

                        dataGridView2.Rows[rnum].Cells[column_name] = cotype_Combo1;
                    }
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmCompany.cs  (Function)::set_Grideview1Combo2  (Detail):: " + "\r\n" + ex.ToString());
            }
        }


        private void SetDataBind_grideView2()
        {
            try
            {
                dataGridView2.Rows.Clear();
                dataGridView2.Rows.Add();
                set_Grideview2Combo1(0, "dgv2_CONST_CCD");
                set_Grideview2Combo2(0, "dgv2_CO_TYPE_SCD");
                dataGridView2.Rows[0].Cells["dgv2_SORT_NO"].Value = "1";
                dataGridView2.Rows[0].Cells["dgv2_BTNADD"].Value = "추가";
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmCompany.cs  (Function)::SetDataBind_grideView2  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
                    MessageBox.Show("선택된 데이터가 없습니다.");
                    return;
                }

                reCnt = 0;


                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells["dgv1_CHK"].Value != null)
                    {
                        if (dataGridView1.Rows[i].Cells["dgv1_CHK"].Value.ToString() == "1")
                        {


                            dataGridView2.Columns["dgv2_CO_NM"].HeaderText = "*업체 이름";
                            dataGridView2.Columns["dgv2_BIZ_NO"].HeaderText = "사업자 번호";
                            dataGridView2.Columns["dgv2_CONST_CCD"].HeaderText = "공종";
                            dataGridView2.Columns["dgv2_CO_TYPE_SCD"].HeaderText = "업체구분";
                            dataGridView2.Columns["dgv2_OWNER_NM"].HeaderText = "대표자";
                            dataGridView2.Columns["dgv2_TEL"].HeaderText = "연락처";
                            dataGridView2.Columns["dgv2_ADDR"].HeaderText = "주소";
                            dataGridView2.Columns["dgv2_SORT_NO"].HeaderText = "정렬";
                            dataGridView2.Columns["dgv2_MEMO"].HeaderText = "메모";


                            string pCoCd = dataGridView1.Rows[i].Cells["dgv1_CO_CD"].Value.ToString();
                            string pCoNm = dataGridView1.Rows[i].Cells["dgv1_CO_NM"].Value.ToString();
                            string pUsingFlag = dataGridView1.Rows[i].Cells["dgv1_USING_FLAG"].Value.ToString();

                            string pHeadcoCd = "";
                            if (dataGridView1.Rows[i].Cells["dgv1_HEADCO_CD"].Value != null)
                                pHeadcoCd = dataGridView1.Rows[i].Cells["dgv1_HEADCO_CD"].Value.ToString();

                            string pConstCcd = dataGridView1.Rows[i].Cells["dgv1_CONST_CCD"].Value.ToString();
                            string pCoTypeScd = dataGridView1.Rows[i].Cells["dgv1_CO_TYPE_SCD"].Value.ToString();
                            string pSiteCd = dataGridView1.Rows[i].Cells["dgv1_SITE_CD"].Value.ToString();

                            string pStartDate = Convert.ToDateTime(dataGridView1.Rows[i].Cells["dgv1_START_DATE"].Value).ToString("yyyyMMdd");
                            string pEndDate = Convert.ToDateTime(dataGridView1.Rows[i].Cells["dgv1_END_DATE"].Value).ToString("yyyyMMdd");

                            string pBizNo = "";
                            if (dataGridView1.Rows[i].Cells["dgv1_BIZ_NO"].Value != null)
                                pBizNo = dataGridView1.Rows[i].Cells["dgv1_BIZ_NO"].Value.ToString();

                            string pOwnerNm = "";
                            if (dataGridView1.Rows[i].Cells["dgv1_OWNER_NM"].Value != null)
                                pOwnerNm = dataGridView1.Rows[i].Cells["dgv1_OWNER_NM"].Value.ToString();

                            string pTel = "";
                            if (dataGridView1.Rows[i].Cells["dgv1_TEL"].Value != null)
                                pTel = dataGridView1.Rows[i].Cells["dgv1_TEL"].Value.ToString();

                            string pAddr = "";
                            if (dataGridView1.Rows[i].Cells["dgv1_ADDR"].Value != null)
                                pAddr = dataGridView1.Rows[i].Cells["dgv1_ADDR"].Value.ToString();

                            string pUsingCnt = dataGridView1.Rows[i].Cells["dgv1_USING_CNT"].Value.ToString();

                            string pSortNo = "1";
                            if (dataGridView1.Rows[i].Cells["dgv1_SORT_NO"].Value != null)
                                pSortNo = dataGridView1.Rows[i].Cells["dgv1_SORT_NO"].Value.ToString();

                            string pMemo = "";
                            if (dataGridView1.Rows[i].Cells["dgv1_MEMO"].Value != null)
                                pMemo = dataGridView1.Rows[i].Cells["dgv1_MEMO"].Value.ToString();

                            string pInputId = AppInfo.SsUserId;

                            int updatefail = 0;

                            //MAIN DB UPDATE
                            reCode = wSvc.mCompanyMain(pCoCd, pCoNm, pBizNo, pConstCcd, pCoTypeScd, pOwnerNm, pTel, pAddr, out reMsg, out reData);
                            //MAIN DB LOG UPDATE
                            reCode = wSvc.mConpanyMainLog(pCoCd, pCoNm, pBizNo, pConstCcd, pCoTypeScd, pOwnerNm, pTel, pAddr, pUsingCnt, pInputId, out reMsg, out reData);


                            //MEMCO DB UPDATE
                            reCode = wSvc.mCompanyMemco(pSiteCd, pCoCd, pCoNm, pHeadcoCd, pConstCcd, pCoTypeScd, pSortNo, out reMsg, out reData);

                            //MEMCO DB COMPANY SITE UPDATE 
                            reCode = wSvc.mCompanyMemcoSite(pSiteCd, pCoCd, pStartDate, pEndDate, pUsingFlag, pSortNo, pMemo, out reMsg, out reData);
                            if (reCode == "Y" && reData == "0")
                            {
                                //MEMCO DB COMPANY SITE INSERT 
                                reCode = wSvc.aCompanyMemcoSite(pSiteCd, pCoCd, pStartDate, pEndDate, pUsingFlag, pSortNo, pMemo, pInputId, out reMsg, out reData);
                                //MEMCO DB COMPANY SITE LOG INSERT 
                                reCode = wSvc.mCompanySiteLog(pCoCd, pSiteCd, pCoNm, pConstCcd, pCoTypeScd, pStartDate, pEndDate, pUsingFlag, pSortNo, pMemo, pInputId, out reMsg, out reData);
                                updatefail++;
                            }

                            //MEMCO DB COMPANY SITE LOG INSERT 
                            if (updatefail == 0)
                                reCode = wSvc.mCompanySiteLog(pCoCd, pSiteCd, pCoNm, pConstCcd, pCoTypeScd, pStartDate, pEndDate, pUsingFlag, pSortNo, pMemo, pInputId, out reMsg, out reData);

                            if (reCode == "Y" && reData != "0")
                                reCnt += Convert.ToInt16(reData);
                        }
                    }
                }
                if (reCnt > 0)
                {
                    MessageBox.Show("저장 성공");
                }
                else
                {
                    MessageBox.Show("저장 실패");
                }

                SetDataBind_gridView1();
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmCompany.cs  (Function)::btnSave_Click  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (wSvc != null)
                    wSvc.Dispose();
            }
        }


        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string colNm = dataGridView2.Columns[e.ColumnIndex].Name;

            if (colNm == "dgv2_BTNADD")
            {
                string reVal = ChkDgv2Param();

                if (reVal != "")
                    MessageBox.Show("데이터 확인 :: " + reVal);
                else
                {
                    string pCoNm = dataGridView2.Rows[0].Cells["dgv2_CO_NM"].Value.ToString();

                    string pBizNo = "";
                    if (dataGridView2.Rows[0].Cells["dgv2_BIZ_NO"].Value != null)
                        pBizNo = dataGridView2.Rows[0].Cells["dgv2_BIZ_NO"].Value.ToString();

                    string pConstCcd = dataGridView2.Rows[0].Cells["dgv2_CONST_CCD"].Value.ToString();
                    string pCoTypeScd = dataGridView2.Rows[0].Cells["dgv2_CO_TYPE_SCD"].Value.ToString();


                    string pStartDate = DateTime.Now.ToString("yyyyMMdd");
                    string pEndDate = DateTime.Now.AddYears(1).ToString("yyyyMMdd");

                    string pOwnerNm = "";
                    if (dataGridView2.Rows[0].Cells["dgv2_OWNER_NM"].Value != null)
                        pOwnerNm = dataGridView2.Rows[0].Cells["dgv2_OWNER_NM"].Value.ToString();

                    string pTel = "";
                    if (dataGridView2.Rows[0].Cells["dgv2_TEL"].Value != null)
                        pTel = dataGridView2.Rows[0].Cells["dgv2_TEL"].Value.ToString();

                    string pAddr = "";
                    if (dataGridView2.Rows[0].Cells["dgv2_ADDR"].Value != null)
                        pAddr = dataGridView2.Rows[0].Cells["dgv2_ADDR"].Value.ToString();

                    string pSortNo = "1";
                    if (dataGridView2.Rows[0].Cells["dgv2_SORT_NO"].Value != null)
                        pSortNo = dataGridView2.Rows[0].Cells["dgv2_SORT_NO"].Value.ToString();

                    string pMemo = "";
                    if (dataGridView2.Rows[0].Cells["dgv2_MEMO"].Value != null)
                        pMemo = dataGridView2.Rows[0].Cells["dgv2_MEMO"].Value.ToString();

                    string pInputId = AppInfo.SsUserId;

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


                        string[] param = new string[13];
                        param[0] = AppInfo.SsSiteCd;
                        param[1] = pCoNm;
                        param[2] = pBizNo;
                        param[3] = pConstCcd;
                        param[4] = pCoTypeScd;
                        param[5] = pOwnerNm;
                        param[6] = pTel;
                        param[7] = pAddr;
                        param[8] = pStartDate;
                        param[9] = pEndDate;
                        param[10] = pMemo;
                        param[11] = pSortNo;
                        param[12] = pInputId;

                        //INSERT WITH PROCEDURE
                        reCode = wSvc.aCompanyPro(AppInfo.SsDbNm, param, out reData, out reMsg);

                        if (reCode == "Y" && reData != "")
                            reCnt = Convert.ToInt16(reData);

                        if (reCnt != 0)
                            MessageBox.Show("저장 성공");

                        else
                            MessageBox.Show("저장 실패");


                        SetDataBind_gridView1();
                        SetDataBind_grideView2();
                    }
                    catch (Exception ex)
                    {
                        logs.SaveLog("[error]  (page)::FrmCompany.cs  (Function)::dataGridView2_CellClick  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
                if (dataGridView2.Rows[0].Cells["dgv2_CO_NM"].Value != null)
                {
                    if (dataGridView2.Rows[0].Cells["dgv2_CO_NM"].Value.ToString() == "")
                    {
                        reVal = "업체 이름";
                        return reVal;
                    }
                }
                else
                {
                    reVal = "업체 이름";
                    return reVal;
                }

                if (dataGridView2.Rows[0].Cells["dgv2_CONST_CCD"].Value != null)
                {
                    if (dataGridView2.Rows[0].Cells["dgv2_CONST_CCD"].Value.ToString() == "")
                    {
                        reVal = "공종";
                        return reVal;
                    }
                }
                else
                {
                    reVal = "공종";
                    return reVal;
                }



                if (dataGridView2.Rows[0].Cells["dgv2_CO_TYPE_SCD"].Value != null)
                {
                    if (dataGridView2.Rows[0].Cells["dgv2_CO_TYPE_SCD"].Value.ToString() == "")
                    {
                        reVal = "업체 구분";
                        return reVal;
                    }
                }
                else
                {
                    reVal = "업체 구분";
                    return reVal;
                }
            }
            catch (Exception ex)
            {
                reVal = "에러";
                logs.SaveLog("[error]  (page)::FrmCompany.cs  (Function)::ChkDgv2Param  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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


