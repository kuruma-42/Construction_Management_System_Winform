using EldigmPlusApp.Config;
using Framework.Log;
using System;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Threading;
using System.Windows.Forms;

namespace EldigmPlusApp.SubForm.Worker.InOut
{
    //
    public partial class FrmInOut : Form
    {
        LogUtil logs = null;
        ResourceManager wRM = null;
        ResourceManager msgRM = null;

        int rowIdx;
        string columnNm;

        public FrmInOut()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(AppInfo.SsLanguage);
            this.AutoScaleMode = AutoScaleMode.Dpi;

            InitializeComponent();

            try
            {
                logs = new LogUtil();
                wRM = new ResourceManager("EldigmPlusApp.GlobalLanguage.word_Language", typeof(FrmInOut).Assembly);
                msgRM = new ResourceManager("EldigmPlusApp.GlobalLanguage.msg_Language", typeof(FrmInOut).Assembly);

                searchCondition21.btnSearch.Text = wRM.GetString("wSearch");
                btnSave.Text = wRM.GetString("wSave");

                dataGridView1.Columns["dgv1_CHK"].HeaderText = wRM.GetString("wSelect");
                dataGridView1.Columns["dgv1_LAB_NO"].HeaderText = wRM.GetString("wWorker") + wRM.GetString("wNumber");
                dataGridView1.Columns["dgv1_LAB_NM"].HeaderText = wRM.GetString("wName");
                dataGridView1.Columns["dgv1_IN_DT"].HeaderText = msgRM.GetString("msgStartDate");
                dataGridView1.Columns["dgv1_OUT_DT"].HeaderText = msgRM.GetString("msgEndDate");
                dataGridView1.Columns["dgv1_CO_CD"].HeaderText = wRM.GetString("wCompany");
                dataGridView1.Columns["dgv1_TEAM_CD"].HeaderText = wRM.GetString("wTeam");
                dataGridView1.Columns["dgv1_IN_IOPF_ID"].HeaderText = wRM.GetString("wAttendance") + wRM.GetString("wPicture");
                dataGridView1.Columns["dgv1_OUT_IOPF_ID"].HeaderText = wRM.GetString("wGetOff") + wRM.GetString("wPicture");
                dataGridView1.Columns["dgv1_CCODE_NM"].HeaderText = wRM.GetString("wJobType");

                Control.CheckForIllegalCrossThreadCalls = false;

                this.BackColor = Color.WhiteSmoke;

                splitContainer1.Panel1.BackColor = Color.LightSteelBlue;

                Class.Common.DatagrideViewStyleSet dvSet = new Class.Common.DatagrideViewStyleSet();
                dvSet.setStyle(dataGridView1, false, false);


            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmInOut.cs  (Function)::FrmInOut  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        private void FrmInOut_Load(object sender, EventArgs e)
        {
            try
            {
                SetDataBind_CompanyCmb();
                SetDataBind_CmbInOut();
                SetDataBind_gridView1();
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmInOut.cs  (Function)::FrmInOut_Load  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        //업체 콤보 박스 
        private void SetDataBind_CompanyCmb()
        {
            Mem_WsInOut.WsInOut wSvc = null;
            string reCode = "";
            string reMsg = "";
            Mem_WsInOut.DataComCombo[] getData = null;
            try
            {
                wSvc = new Mem_WsInOut.WsInOut();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Worker/InOut/WsInOut.svc";
                wSvc.Timeout = 1000;

                reCode = wSvc.sLaborCompanyList(AppInfo.SsSiteCd, AppInfo.SsLabAuth, AppInfo.SsCoCd, out getData, out reMsg);
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

                        setCmb.Bind(searchCondition21.cmbCom);
                    }
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmInOut.cs  (Function)::SetDataBind_CompanyCmb  (Detail):: " + "\r\n" + ex.ToString());
            }
        }

        private void SetDataBind_CmbInOut()
        {
            try
            {
                Class.Common.ComboBoxItemSet setCmb = null;

                setCmb = new Class.Common.ComboBoxItemSet();

                setCmb.AddColumn();

                setCmb.AddRow(wRM.GetString("wAttendance"), "1");
                setCmb.AddRow(wRM.GetString("wNotAttendance"), "0");

                setCmb.Bind(searchCondition21.cmbInOut);

            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmInOut.cs  (Function)::SetDataBind_CmbInOut  (Detail):: " + "\r\n" + ex.ToString());
            }
        }

        private void set_Grideview1Combo1(int rnum, string column_name)
        {
            Mem_WsInOut.WsInOut wSvc = null;
            string reCode = "";
            string reMsg = "";
            Mem_WsInOut.DataComCombo[] getData = null;
            try
            {
                wSvc = new Mem_WsInOut.WsInOut();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Worker/InOut/WsInOut.svc";
                wSvc.Timeout = 1000;

                reCode = wSvc.co_Cmb(AppInfo.SsSiteCd, out getData, out reMsg);
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
                        DataGridViewComboBoxCell coCombo1 = new DataGridViewComboBoxCell();

                        coCombo1.DisplayMember = "TEXT";
                        coCombo1.ValueMember = "VALUE";

                        coCombo1.DataSource = setCmb.GetDataTable();

                        dataGridView1.Rows[rnum].Cells[column_name] = coCombo1;
                    }
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmInOut.cs  (Function)::set_Grideview1Combo1  (Detail):: " + "\r\n" + ex.ToString());
            }
        }

        private void set_Grideview1Combo2(int rnum, string column_name)
        {
            Mem_WsInOut.WsInOut wSvc = null;
            string reCode = "";
            string reMsg = "";
            Mem_WsInOut.DataComCombo[] getData = null;
            try
            {
                wSvc = new Mem_WsInOut.WsInOut();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Worker/InOut/WsInOut.svc";
                wSvc.Timeout = 1000;

                reCode = wSvc.team_Cmb(AppInfo.SsSiteCd, out getData, out reMsg);
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
                        DataGridViewComboBoxCell teamCombo1 = new DataGridViewComboBoxCell();

                        teamCombo1.DisplayMember = "TEXT";
                        teamCombo1.ValueMember = "VALUE";

                        teamCombo1.DataSource = setCmb.GetDataTable();

                        dataGridView1.Rows[rnum].Cells[column_name] = teamCombo1;
                    }
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmInOut.cs  (Function)::set_Grideview1Combo2  (Detail):: " + "\r\n" + ex.ToString());
            }
        }

        private void SetDataBind_gridView1()
        {
            Mem_WsInOut.WsInOut wSvc = null;
            string reCode = "";
            string reMsg = "";
            Mem_WsInOut.DataInOut[] getData = null;
            try
            {
                wSvc = new Mem_WsInOut.WsInOut(); // 시스템 코드 보여주기 
                wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Worker/InOut/WsInOut.svc";
                wSvc.Timeout = 1000;

                string dtp1_val = searchCondition21.dateTimePicker1.Value.ToString("yyyyMMdd");
                string dtp2_val = searchCondition21.dateTimePicker2.Value.AddDays(1).ToString("yyyyMMdd");

                reCode = wSvc.sInOut(AppInfo.SsDbNm, AppInfo.SsSiteCd, dtp1_val, dtp2_val, searchCondition21.cmbCom.SelectedValue.ToString(), searchCondition21.cmbInOut.SelectedValue.ToString(), out getData, out reMsg);

                if (reCode == "Y")
                {
                    if (searchCondition21.cmbInOut.SelectedValue.ToString() == "1")
                    {
                        if (getData != null && getData.Length > 0)
                        {
                            dataGridView1.Columns["dgv1_DEV_IO_SCD"].Visible = true;
                            dataGridView1.Columns["dgv1_IN_IOPF_ID"].Visible = true;
                            dataGridView1.Columns["dgv1_OUT_IOPF_ID"].Visible = true;

                            dataGridView1.Rows.Clear();
                            for (int i = 0; i < getData.Length; i++)
                            {
                                dataGridView1.Rows.Add();
                                dataGridView1.Rows[i].Cells["dgv1_CHK"].Value = "0";
                                dataGridView1.Rows[i].Cells["dgv1_LAB_NO"].Value = getData[i].LAB_NO.ToString();
                                dataGridView1.Rows[i].Cells["dgv1_REG_DATE"].Value = getData[i].REG_DATE.ToString();
                                dataGridView1.Rows[i].Cells["dgv1_LAB_NM"].Value = getData[i].LAB_NM.ToString();
                                dataGridView1.Rows[i].Cells["dgv1_IN_DT"].Value = getData[i].IN_DT;
                                dataGridView1.Rows[i].Cells["dgv1_OUT_DT"].Value = getData[i].OUT_DT;
                                if (getData[i].OUT_DT.ToString() == "1900-01-01 오전 12:00:00")
                                    dataGridView1.Rows[i].Cells["dgv1_OUT_DT"].Value = null;
                                //dataGridView1.Rows[i].Cells["dgv1_CO_CD"].Value = getData[i].CO_CD;
                                //dataGridView1.Rows[i].Cells["dgv1_CO_NM"].Value = getData[i].CO_NM.ToString();
                                set_Grideview1Combo1(i, "dgv1_CO_CD");
                                dataGridView1.Rows[i].Cells["dgv1_CO_CD"].Value = getData[i].CO_CD.ToString();
                                set_Grideview1Combo2(i, "dgv1_TEAM_CD");
                                dataGridView1.Rows[i].Cells["dgv1_TEAM_CD"].Value = getData[i].TEAM_CD.ToString();
                                dataGridView1.Rows[i].Cells["dgv1_IN_IOPF_ID"].Value = getData[i].IN_IOPF_ID.ToString();
                                dataGridView1.Rows[i].Cells["dgv1_OUT_IOPF_ID"].Value = getData[i].OUT_IOPF_ID.ToString();
                                dataGridView1.Rows[i].Cells["dgv1_CCODE_NM"].Value = getData[i].CCODE_NM.ToString();
                            }

                            SetRowNumber(dataGridView1);

                        }
                        else
                        {
                            dataGridView1.Rows.Clear();
                            //MessageBox.Show("데이터가 없습니다");
                        }
                    }
                    else
                    {
                        dataGridView1.Columns["dgv1_DEV_IO_SCD"].Visible = false;
                        dataGridView1.Columns["dgv1_IN_IOPF_ID"].Visible = false;
                        dataGridView1.Columns["dgv1_OUT_IOPF_ID"].Visible = false;

                        if (getData != null && getData.Length > 0)
                        {
                            dataGridView1.Rows.Clear();
                            for (int i = 0; i < getData.Length; i++)
                            {
                                dataGridView1.Rows.Add();
                                dataGridView1.Rows[i].Cells["dgv1_CHK"].Value = "0";
                                dataGridView1.Rows[i].Cells["dgv1_LAB_NO"].Value = getData[i].LAB_NO.ToString();
                                dataGridView1.Rows[i].Cells["dgv1_LAB_NM"].Value = getData[i].LAB_NM.ToString();
                                set_Grideview1Combo1(i, "dgv1_CO_CD");
                                dataGridView1.Rows[i].Cells["dgv1_CO_CD"].Value = getData[i].CO_CD.ToString();
                                set_Grideview1Combo2(i, "dgv1_TEAM_CD");
                                dataGridView1.Rows[i].Cells["dgv1_TEAM_CD"].Value = getData[i].TEAM_CD.ToString();
                                dataGridView1.Rows[i].Cells["dgv1_CCODE_NM"].Value = getData[i].CCODE_NM.ToString();
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
                NoSelectGrideView(dataGridView1);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmInOut.cs  (Function)::SetDataBind_gridView1  (Detail)::reMsg=[" + reMsg + "]", "Error");
                logs.SaveLog("[error]  (page)::FrmInOut.cs  (Function)::SetDataBind_gridView1  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (wSvc != null)
                    wSvc.Dispose();
            }
        }

        bool chkUseAll = false;
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0)
                return;

            string columnNm = dataGridView1.Columns[e.ColumnIndex].Name;

            if (columnNm == "dgv1_CHK")
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    //if (i == 0)
                    //    dataGridView1.Rows[i].Cells["dgv1_CO_NM"].Selected = true;

                    if (chkUseAll)
                    {
                        dataGridView1.Rows[i].Cells["dgv1_CHK"].Value = "0";
                    }
                    else
                    {
                        if (!dataGridView1.Rows[i].ReadOnly)
                        {
                            dataGridView1.Rows[i].Cells["dgv1_CHK"].Value = "1";

                            if (dataGridView1.Rows[i].Cells["dgv1_IN_DT"].Value == null)
                            {
                                dataGridView1.Rows[i].Cells["dgv1_IN_DT"].Value = Convert.ToDateTime(searchCondition21.dateTimePicker1.Value.ToString("yyyy-MM-dd") + " 07:00:00");
                            }
                            if (dataGridView1.Rows[i].Cells["dgv1_OUT_DT"].Value == null)
                            {
                                dataGridView1.Rows[i].Cells["dgv1_OUT_DT"].Value = Convert.ToDateTime(searchCondition21.dateTimePicker1.Value.ToString("yyyy-MM-dd") + " 18:00:00");
                            }
                        }
                    }
                }

                if (chkUseAll)
                    chkUseAll = false;
                else
                    chkUseAll = true;
            }
            else
            {
                SetRowNumber(dataGridView1);
            }
            NoSelectGrideView(dataGridView1);
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SetRowNumber(dataGridView1);
        }


        private void SetRowNumber(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
                row.HeaderCell.Value = String.Format("{0}", row.Index + 1);

            dgv.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }


        private void NoSelectGrideView(DataGridView dgv)
        {
            dgv.ClearSelection();
            dgv.CurrentCell = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Mem_WsInOut.WsInOut wSvc = null;
            string reMsg = "";
            string reData = "";
            string reCode = "";
            try
            {
                wSvc = new Mem_WsInOut.WsInOut();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Worker/InOut/WsInOut.svc";
                wSvc.Timeout = 1000;

                int reCnt = 0;

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells["dgv1_CHK"].Value != null)
                    {
                        if (dataGridView1.Rows[i].Cells["dgv1_CHK"].Value.ToString() == "1")
                        {
                            if (searchCondition21.cmbInOut.SelectedValue.ToString() == "1")
                            {
                                string labNo_val = dataGridView1.Rows[i].Cells["dgv1_LAB_NO"].Value.ToString();
                                string regDate_val = dataGridView1.Rows[i].Cells["dgv1_REG_DATE"].Value.ToString();
                                string inDt_val = Convert.ToDateTime(dataGridView1.Rows[i].Cells["dgv1_IN_DT"].Value).ToString("yyyyMMdd HH:mm:ss");
                                string outDt_val = Convert.ToDateTime(dataGridView1.Rows[i].Cells["dgv1_OUT_DT"].Value).ToString("yyyyMMdd HH:mm:ss");
                                string outDt2_val = Convert.ToDateTime(dataGridView1.Rows[i].Cells["dgv1_OUT_DT"].Value).ToString();
                                string inDt_HHMM = Convert.ToDateTime(dataGridView1.Rows[i].Cells["dgv1_IN_DT"].Value).ToString("HHmm");
                                string outDt_HHMM = Convert.ToDateTime(dataGridView1.Rows[i].Cells["dgv1_OUT_DT"].Value).ToString("HHmm");
                                string coCd_val = dataGridView1.Rows[i].Cells["dgv1_CO_CD"].Value.ToString();
                                string teamCd_val = dataGridView1.Rows[i].Cells["dgv1_TEAM_CD"].Value.ToString();
                                string inIOPFId_val = dataGridView1.Rows[i].Cells["dgv1_IN_IOPF_ID"].Value.ToString();
                                string outIOPFId_val = dataGridView1.Rows[i].Cells["dgv1_OUT_IOPF_ID"].Value.ToString();

                                reCode = wSvc.mInOut(AppInfo.SsDbNm, labNo_val, AppInfo.SsSiteCd, regDate_val, inDt_val, outDt_val, coCd_val, teamCd_val, out reMsg, out reData);

                                if (reCode == "Y" && reData != "0")
                                {
                                    reCode = wSvc.dInHistory(AppInfo.SsDbNm, labNo_val, AppInfo.SsSiteCd, regDate_val, inDt_val, out reMsg, out reData);
                                    reCode = wSvc.aInOutHistory(AppInfo.SsDbNm, labNo_val, AppInfo.SsSiteCd, regDate_val, inDt_val, coCd_val, teamCd_val, AppInfo.SsLabNo, out reMsg, out reData);

                                    reCode = wSvc.dOutHistory(AppInfo.SsDbNm, labNo_val, AppInfo.SsSiteCd, regDate_val, outDt_val, out reMsg, out reData);
                                    reCode = wSvc.aInOutHistory(AppInfo.SsDbNm, labNo_val, AppInfo.SsSiteCd, regDate_val, outDt_val, coCd_val, teamCd_val, AppInfo.SsLabNo, out reMsg, out reData);

                                    if (reCode == "Y" && reData != "0")
                                        reCode = wSvc.aInOutLog(AppInfo.SsDbNm, labNo_val, AppInfo.SsSiteCd, regDate_val, inDt_val, outDt_val, coCd_val, teamCd_val, inIOPFId_val, outIOPFId_val, AppInfo.SsLabNo, out reMsg, out reData);

                                    reCode = wSvc.exInOutCo(AppInfo.SsDbNm, labNo_val, AppInfo.SsSiteCd, coCd_val, out reMsg, out reData);
                                    if (reData == "")
                                        reCode = wSvc.aInOutCo(AppInfo.SsDbNm, labNo_val, AppInfo.SsSiteCd, coCd_val, outDt_val, out reMsg, out reData);
                                    else
                                    {
                                        if (Int32.Parse(Convert.ToDateTime(reData).ToString("yyyyMMdd")) <= Int32.Parse(Convert.ToDateTime(outDt2_val).ToString("yyyyMMdd")))
                                        {
                                            if (reCode == "Y" && reData != "0")
                                                reCode = wSvc.mInOutCo(AppInfo.SsDbNm, labNo_val, AppInfo.SsSiteCd, coCd_val, outDt_val, out reMsg, out reData);
                                        }
                                    }

                                    reCode = wSvc.exLabInOutFinal(labNo_val, AppInfo.SsSiteCd, out reMsg, out reData);
                                    if (reData == "0")
                                        reCode = wSvc.aLabInOutFinal(labNo_val, AppInfo.SsSiteCd, coCd_val, teamCd_val, regDate_val, inDt_HHMM, outDt_HHMM, out reMsg, out reData);
                                    else
                                    {
                                        if (Convert.ToInt32(reData) <= Convert.ToInt32(regDate_val))
                                        {
                                            if (reCode == "Y" && reData != "0")
                                                reCode = wSvc.mLabInOutFinal(labNo_val, AppInfo.SsSiteCd, coCd_val, teamCd_val, regDate_val, inDt_HHMM, outDt_HHMM, out reMsg, out reData);
                                        }
                                    }

                                    reCode = wSvc.exInOut2020(labNo_val, AppInfo.SsSiteCd, regDate_val, out reMsg, out reData);
                                    if (reData == "0")
                                        reCode = wSvc.aInOut2020(labNo_val, AppInfo.SsSiteCd, regDate_val, coCd_val, teamCd_val, inDt_HHMM, outDt_HHMM, out reMsg, out reData);
                                    else
                                    {
                                        if (reCode == "Y" && reData != "0")
                                            reCode = wSvc.mInOut2020(labNo_val, AppInfo.SsSiteCd, regDate_val, coCd_val, teamCd_val, inDt_HHMM, outDt_HHMM, out reMsg, out reData);
                                    }

                                    if (reCode == "Y" && reData != "0")
                                        reCnt += Convert.ToInt16(reData);

                                }
                            }
                            else
                            {
                                string labNo_val = dataGridView1.Rows[i].Cells["dgv1_LAB_NO"].Value.ToString();
                                string inDt_val = Convert.ToDateTime(dataGridView1.Rows[i].Cells["dgv1_IN_DT"].Value).ToString("yyyyMMdd HH:mm:ss");
                                string outDt_val = Convert.ToDateTime(dataGridView1.Rows[i].Cells["dgv1_OUT_DT"].Value).ToString("yyyyMMdd HH:mm:ss");
                                string outDt2_val = Convert.ToDateTime(dataGridView1.Rows[i].Cells["dgv1_OUT_DT"].Value).ToString();
                                string inDt_HHMM = Convert.ToDateTime(dataGridView1.Rows[i].Cells["dgv1_IN_DT"].Value).ToString("HHmm");
                                string outDt_HHMM = Convert.ToDateTime(dataGridView1.Rows[i].Cells["dgv1_OUT_DT"].Value).ToString("HHmm");
                                if (outDt_val == "00010101 00:00:00")
                                {
                                    outDt_val = null;
                                }
                                string regDate_val = Convert.ToDateTime(dataGridView1.Rows[i].Cells["dgv1_IN_DT"].Value).ToString("yyyyMMdd");
                                string coCd_val = dataGridView1.Rows[i].Cells["dgv1_CO_CD"].Value.ToString();
                                string teamCd_val = dataGridView1.Rows[i].Cells["dgv1_TEAM_CD"].Value.ToString();

                                reCode = wSvc.aInOut(AppInfo.SsDbNm, labNo_val, AppInfo.SsSiteCd, regDate_val, inDt_val, outDt_val, coCd_val, teamCd_val, out reMsg, out reData);

                                if (reCode == "Y" && reData != "0")
                                {
                                    reCode = wSvc.aInOutHistory(AppInfo.SsDbNm, labNo_val, AppInfo.SsSiteCd, regDate_val, inDt_val, coCd_val, teamCd_val, AppInfo.SsLabNo, out reMsg, out reData);
                                    reCode = wSvc.aInOutHistory(AppInfo.SsDbNm, labNo_val, AppInfo.SsSiteCd, regDate_val, outDt_val, coCd_val, teamCd_val, AppInfo.SsLabNo, out reMsg, out reData);

                                    if (reCode == "Y" && reData != "0")
                                        reCode = wSvc.aInOutLog(AppInfo.SsDbNm, labNo_val, AppInfo.SsSiteCd, regDate_val, inDt_val, outDt_val, coCd_val, teamCd_val, "0", "0", AppInfo.SsLabNo, out reMsg, out reData);

                                    if (outDt_val != null)
                                    {
                                        reCode = wSvc.exInOutCo(AppInfo.SsDbNm, labNo_val, AppInfo.SsSiteCd, coCd_val, out reMsg, out reData);
                                        if (reData == "")
                                            reCode = wSvc.aInOutCo(AppInfo.SsDbNm, labNo_val, AppInfo.SsSiteCd, coCd_val, outDt_val, out reMsg, out reData);
                                        else
                                        {
                                            if (Int32.Parse(Convert.ToDateTime(reData).ToString("yyyyMMdd")) <= Int32.Parse(Convert.ToDateTime(outDt2_val).ToString("yyyyMMdd")))
                                            {
                                                if (reCode == "Y" && reData != "0")
                                                    reCode = wSvc.mInOutCo(AppInfo.SsDbNm, labNo_val, AppInfo.SsSiteCd, coCd_val, outDt_val, out reMsg, out reData);
                                            }
                                        }
                                    }

                                    reCode = wSvc.exLabInOutFinal(labNo_val, AppInfo.SsSiteCd, out reMsg, out reData);
                                    if (reData == "0")
                                        reCode = wSvc.aLabInOutFinal(labNo_val, AppInfo.SsSiteCd, coCd_val, teamCd_val, regDate_val, inDt_HHMM, outDt_HHMM, out reMsg, out reData);
                                    else
                                    {
                                        if (Convert.ToInt32(reData) <= Convert.ToInt32(regDate_val))
                                        {
                                            if (reCode == "Y" && reData != "0")
                                                reCode = wSvc.mLabInOutFinal(labNo_val, AppInfo.SsSiteCd, coCd_val, teamCd_val, regDate_val, inDt_HHMM, outDt_HHMM, out reMsg, out reData);
                                        }
                                    }

                                    reCode = wSvc.exInOut2020(labNo_val, AppInfo.SsSiteCd, regDate_val, out reMsg, out reData);
                                    if (reData == "0")
                                        reCode = wSvc.aInOut2020(labNo_val, AppInfo.SsSiteCd, regDate_val, coCd_val, teamCd_val, inDt_HHMM, outDt_HHMM, out reMsg, out reData);
                                    else
                                    {
                                        if (reCode == "Y" && reData != "0")
                                            reCode = wSvc.mInOut2020(labNo_val, AppInfo.SsSiteCd, regDate_val, coCd_val, teamCd_val, inDt_HHMM, outDt_HHMM, out reMsg, out reData);
                                    }
                                }

                                if (reCode == "Y" && reData != "0")
                                    reCnt += Convert.ToInt16(reData);

                            }
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

                logs.SaveLog("[error]  (page)::FrmInOut.cs  (Function)::btnSave_Click  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (wSvc != null)
                    wSvc.Dispose();
            }
        }

        private void searchCondition21_btnSearchClick(object sender, EventArgs e)
        {
            SetDataBind_gridView1();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            columnNm = dataGridView1.Columns[e.ColumnIndex].Name;

            if (columnNm == "dgv1_OUT_DT")
            {
                if (dataGridView1.Rows[e.RowIndex].Cells["dgv1_IN_DT"].Value == null)
                    return;
            }

            rowIdx = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Index);
            string inOutTime = "";

            if (columnNm == "dgv1_IN_DT" || columnNm == "dgv1_OUT_DT")
            {
                if (searchCondition21.cmbInOut.SelectedValue.ToString() == "1")
                {
                    if (columnNm == "dgv1_IN_DT")
                    {
                        inOutTime = dataGridView1.Rows[e.RowIndex].Cells["dgv1_IN_DT"].Value.ToString();
                    }
                    else if (columnNm == "dgv1_OUT_DT" && dataGridView1.Rows[e.RowIndex].Cells["dgv1_OUT_DT"].Value != null)
                    {
                        inOutTime = dataGridView1.Rows[e.RowIndex].Cells["dgv1_OUT_DT"].Value.ToString();
                    }
                }
                else
                {
                    inOutTime = searchCondition21.dateTimePicker1.Value.ToString();
                }

                FrmInOutTime frm = new FrmInOutTime(columnNm, rowIdx, inOutTime, this);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.TopMost = true;
                frm.ShowDialog();
            }
        }

        public void dataGridView1_InOutTimeModify(string inOutType, int rowIdx, DateTime dt)
        {
            dataGridView1.Rows[rowIdx].Cells[inOutType].Value = dt;
            dataGridView1.Rows[rowIdx].Cells["dgv1_CHK"].Value = "1";
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows[rowIdx].Cells["dgv1_CHK"].Value = "1";

            if (dataGridView1.Rows[rowIdx].Cells["dgv1_IN_DT"].Value == null)
            {
                string dt = searchCondition21.dateTimePicker1.Value.ToString("yyyy-MM-dd") + " 07:00:00";
                dataGridView1.Rows[rowIdx].Cells["dgv1_IN_DT"].Value = Convert.ToDateTime(dt);
            }
            if (dataGridView1.Rows[rowIdx].Cells["dgv1_OUT_DT"].Value == null)
            {
                string dt = searchCondition21.dateTimePicker1.Value.ToString("yyyy-MM-dd") + " 18:00:00";
                dataGridView1.Rows[rowIdx].Cells["dgv1_OUT_DT"].Value = Convert.ToDateTime(dt);
            }
        }
    }
}
