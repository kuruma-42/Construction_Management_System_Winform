﻿using EldigmPlusApp.Config;
using Framework.Log;
using System;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Threading;
using System.Windows.Forms;

namespace EldigmPlusApp.SubForm.Worker.InOut
{
    public partial class FrmInOutHistory : Form
    {
        LogUtil logs = null;
        ResourceManager wRM = null;
        ResourceManager msgRM = null;

        public FrmInOutHistory()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(AppInfo.SsLanguage);
            this.AutoScaleMode = AutoScaleMode.Dpi;

            InitializeComponent();

            try
            {
                logs = new LogUtil();
                wRM = new ResourceManager("EldigmPlusApp.GlobalLanguage.word_Language", typeof(FrmInOutHistory).Assembly);
                msgRM = new ResourceManager("EldigmPlusApp.GlobalLanguage.msg_Language", typeof(FrmInOutHistory).Assembly);

                btnSearch.Text = wRM.GetString("wSearch");
                btnSave.Text = wRM.GetString("wSave");

                dataGridView1.Columns["dgv1_LAB_NO"].HeaderText = wRM.GetString("wWorker") + wRM.GetString("wNumber");
                dataGridView1.Columns["dgv1_LAB_NM"].HeaderText = wRM.GetString("wName");
                dataGridView1.Columns["dgv1_EVENT_DT"].HeaderText = msgRM.GetString("wEventDate");
                dataGridView1.Columns["dgv1_CO_NM"].HeaderText = wRM.GetString("wCompany");
                dataGridView1.Columns["dgv1_TEAM_NM"].HeaderText = wRM.GetString("wTeam");
                dataGridView1.Columns["dgv1_DEV_NM"].HeaderText = wRM.GetString("wDevice");
                dataGridView1.Columns["dgv1_DEV_TYPE_NM"].HeaderText = wRM.GetString("wDevice") + wRM.GetString("wType");
                dataGridView1.Columns["dgv1_DEV_IO_NM"].HeaderText = wRM.GetString("wDevice") + wRM.GetString("wInOut");
                dataGridView1.Columns["dgv1_CODE_NM"].HeaderText = wRM.GetString("wJobType");


                Control.CheckForIllegalCrossThreadCalls = false;

                this.BackColor = Color.WhiteSmoke;

                splitContainer1.Panel1.BackColor = Color.LightSteelBlue;

                Class.Common.DatagrideViewStyleSet dvSet = new Class.Common.DatagrideViewStyleSet();
                dvSet.setStyle(dataGridView1, false, false);

            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmInOutHistory.cs  (Function)::FrmInOutHistory  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        private void FrmInOutHistory_Load(object sender, EventArgs e)
        {
            try
            {
                SetDataBind_CompanyCmb();
                SetDataBind_gridView1();
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmInOutHistory.cs  (Function)::FrmInOutHistory_Load  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
                logs.SaveLog("[error]  (page)::FrmLaborSearch.cs  (Function)::SetDataBind_CmbMember  (Detail):: " + "\r\n" + ex.ToString());
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

                reCode = wSvc.sInOutHistory(AppInfo.SsDbNm, AppInfo.SsSiteCd, dtp1_val, dtp2_val, searchCondition21.cmbCom.SelectedValue.ToString(), out getData, out reMsg);

                if (reCode == "Y")
                {
                    if (getData != null && getData.Length > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int i = 0; i < getData.Length; i++)
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[i].Cells["dgv1_LAB_NO"].Value = getData[i].LAB_NO.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_LAB_NM"].Value = getData[i].LAB_NM.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_EVENT_DT"].Value = getData[i].EVENT_DT;
                            dataGridView1.Rows[i].Cells["dgv1_CO_NM"].Value = getData[i].CO_NM.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_TEAM_NM"].Value = getData[i].TEAM_NM.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_DEV_NM"].Value = getData[i].DEV_NM.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_DEV_TYPE_NM"].Value = getData[i].DEV_TYPE_NM.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_DEV_IO_NM"].Value = getData[i].DEV_IO_NM.ToString();
                            //dataGridView1.Rows[i].Cells["dgv1_IN_IOPF_ID"].Value = getData[i].DEV_IO_NM.ToString();
                            //dataGridView1.Rows[i].Cells["dgv1_OUT_IOPF_ID"].Value = getData[i].DEV_IO_NM.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_CODE_NM"].Value = getData[i].CCODE_NM.ToString();
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
                logs.SaveLog("[error]  (page)::FrmInOutHistory.cs  (Function)::SetDataBind_gridView1  (Detail)::reMsg=[" + reMsg + "]", "Error");
                logs.SaveLog("[error]  (page)::FrmInOutHistory.cs  (Function)::SetDataBind_gridView1  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
            //M_WsCCodeGrp.WsComnCodeGrp wSvc = null;
            //string reCode = "";
            //string reMsg = "";
            //int reData = 0;
            //bool reSpecified = false;
            //try
            //{
            //    wSvc = new M_WsCCodeGrp.WsComnCodeGrp();
            //    wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/ComnCode/WsComnCodeGrp.svc";
            //    wSvc.Timeout = 1000;

            //    int reCnt = 0;

            //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //    {
            //        if (dataGridView1.Rows[i].Cells["dgv1_CHK"].Value != null)
            //        {
            //            if (dataGridView1.Rows[i].Cells["dgv1_CHK"].Value.ToString() == "1")
            //            {
            //                string ccode_val = dataGridView1.Rows[i].Cells["dgv1_CCODE_GRP"].Value.ToString();
            //                string ccodeNm_val = dataGridView1.Rows[i].Cells["dgv1_CCODE_GRP_NM"].Value.ToString();
            //                string usingFlag_val = dataGridView1.Rows[i].Cells["dgv1_USING_FLAG"].Value.ToString();


            //                string sortNo_val = "1";
            //                if (dataGridView1.Rows[i].Cells["dgv1_SORT_NO"].Value != null)
            //                {
            //                    sortNo_val = dataGridView1.Rows[i].Cells["dgv1_SORT_NO"].Value.ToString();
            //                }

            //                string memo_val = "";
            //                if (dataGridView1.Rows[i].Cells["dgv1_MEMO"].Value != null)
            //                {
            //                    memo_val = dataGridView1.Rows[i].Cells["dgv1_MEMO"].Value.ToString();
            //                }

            //                reCode = wSvc.mComnCodeGrp(ccode_val, ccodeNm_val, usingFlag_val, sortNo_val, memo_val, out reMsg, out reData, out reSpecified);

            //                if (reCode == "Y" && reData > 0)
            //                    reCnt += Convert.ToInt16(reData);
            //            }
            //        }
            //    }

            //    if (reCnt > 0)
            //        MessageBox.Show(wRM.GetString("wSave") + " " + wRM.GetString("wSuccess") + " : " + reCnt.ToString());
            //    else
            //        MessageBox.Show(wRM.GetString("wSave") + " " + wRM.GetString("wFail"));

            //    SetDataBind_gridView1();
            //}
            //catch (Exception ex)
            //{

            //    logs.SaveLog("[error]  (page)::FrmInOutHistory.cs  (Function)::btnSave_Click  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            //}
            //finally
            //{
            //    if (wSvc != null)
            //        wSvc.Dispose();
            //}
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SetDataBind_gridView1();
        }

       
    }
}
