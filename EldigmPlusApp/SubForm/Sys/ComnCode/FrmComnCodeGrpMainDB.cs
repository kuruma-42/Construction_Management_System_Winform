using EldigmPlusApp.Config;
using Framework.Log;
using System;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Threading;
using System.Windows.Forms;

namespace EldigmPlusApp.SubForm.Sys.ComnCode
{
    public partial class FrmComnCodeGrpMainDB : Form
    {
        LogUtil logs = null;
        ResourceManager wRM = null;
        ResourceManager msgRM = null;

        public FrmComnCodeGrpMainDB()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(AppInfo.SsLanguage);
            this.AutoScaleMode = AutoScaleMode.Dpi;

            InitializeComponent();

            try
            {
                logs = new LogUtil();
                wRM = new ResourceManager("EldigmPlusApp.GlobalLanguage.word_Language", typeof(FrmComnCodeGrpMainDB).Assembly);
                msgRM = new ResourceManager("EldigmPlusApp.GlobalLanguage.msg_Language", typeof(FrmComnCodeGrpMainDB).Assembly);

                btnSave.Text = wRM.GetString("wSave");
                
                dataGridView1.Columns["dgv1_CHK"].HeaderText = wRM.GetString("wSelect");
                dataGridView1.Columns["dgv1_CCODE_GRP"].HeaderText = wRM.GetString("wCode");
                dataGridView1.Columns["dgv1_CCODE_GRP_NM"].HeaderText = wRM.GetString("wName");
                dataGridView1.Columns["dgv1_USING_FLAG"].HeaderText = wRM.GetString("wUse");
                dataGridView1.Columns["dgv1_SORT_NO"].HeaderText = wRM.GetString("wSort");
                dataGridView1.Columns["dgv1_MEMO"].HeaderText = wRM.GetString("wMemo");

                dataGridView2.Columns["dgv2_CCODE_GRP"].HeaderText = "*" + wRM.GetString("wCode");
                dataGridView2.Columns["dgv2_CCODE_GRP_NM"].HeaderText = "*" + wRM.GetString("wName");
                dataGridView2.Columns["dgv2_SORT_NO"].HeaderText = wRM.GetString("wSort");
                dataGridView2.Columns["dgv2_MEMO"].HeaderText = wRM.GetString("wMemo");

                dataGridView2.Columns["dgv2_CCODE_GRP"].HeaderCell.Style.ForeColor = Color.Maroon; // 헤더 필수 항목 빨강색
                dataGridView2.Columns["dgv2_CCODE_GRP_NM"].HeaderCell.Style.ForeColor = Color.Maroon; // 헤더 필수 항목 빨강색

                Control.CheckForIllegalCrossThreadCalls = false;

                this.BackColor = Color.WhiteSmoke;

                splitContainer1.Panel1.BackColor = Color.LightSteelBlue;

                Class.Common.DatagrideViewStyleSet dvSet = new Class.Common.DatagrideViewStyleSet();
                dvSet.setStyle(dataGridView1, false, false);
                dvSet.setStyle(dataGridView2, false, false);

            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmComnCodeGrpMainDB.cs  (Function)::FrmComnCodeGrpMainDB  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        private void FrmComnCodeGrpMainDB_Load(object sender, EventArgs e)
        {
            try
            {
                SetDataBind_gridView1();
                SetDataBind_grideView2();
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmComnCodeGrpMainDB.cs  (Function)::FrmComnCodeGrpMainDB_Load  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        private void SetDataBind_gridView1()
        {
            M_WsCCodeGrp.WsComnCodeGrp wSvc = null;
            string reCode = "";
            string reMsg = "";
            M_WsCCodeGrp.DataComnCodeGrp[] getData = null;
            try
            {
                wSvc = new M_WsCCodeGrp.WsComnCodeGrp(); // 시스템 코드 보여주기 
                wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/ComnCode/WsComnCodeGrp.svc";
                wSvc.Timeout = 1000;

                reCode = wSvc.sComnCodeGrp(out getData, out reMsg);

                if (reCode == "Y")
                {
                    if (getData != null && getData.Length > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int i = 0; i < getData.Length; i++)
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[i].Cells["dgv1_CHK"].Value = "0";
                            dataGridView1.Rows[i].Cells["dgv1_CCODE_GRP"].Value = getData[i].CCODE_GRP.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_CCODE_GRP_NM"].Value = getData[i].CCODE_GRP_NM.ToString();
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
                logs.SaveLog("[error]  (page)::FrmComnCodeGrpMainDB.cs  (Function)::SetDataBind_gridView1  (Detail)::reMsg=[" + reMsg + "]", "Error");
                logs.SaveLog("[error]  (page)::FrmComnCodeGrpMainDB.cs  (Function)::SetDataBind_gridView1  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
                logs.SaveLog("[error]  (page)::FrmComnCodeGrpMainDB.cs  (Function)::dataGridView1_CellBeginEdit  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
                logs.SaveLog("[error]  (page)::FrmComnCodeGrpMainDB.cs  (Function)::dataGridView1_ColumnHeaderMouseClick  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
                dataGridView2.Rows[0].Cells["dgv2_BTNADD"].Value = wRM.GetString("wAdd");
                dataGridView2.Rows[0].Cells["dgv2_SORT_NO"].Value = "10";
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmComnCodeGrpMainDB.cs  (Function)::setDataBind_grideView2  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }

        }

        private void SetRowNumber(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
                row.HeaderCell.Value = String.Format("{0}", row.Index + 1);

            dgv.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
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
                    string ccodeGrp_val = dataGridView2.Rows[0].Cells["dgv2_CCODE_GRP"].Value.ToString();
                    string ccodeNm_val = dataGridView2.Rows[0].Cells["dgv2_CCODE_GRP_NM"].Value.ToString();
                    string usingFlag_val = "1";

                    string sortNo_val = "1";
                    if (dataGridView2.Rows[0].Cells["dgv2_SORT_NO"].Value != null)
                        sortNo_val = dataGridView2.Rows[0].Cells["dgv2_SORT_NO"].Value.ToString();

                    string memo_val = "";
                    if (dataGridView2.Rows[0].Cells["dgv2_MEMO"].Value != null)
                        memo_val = dataGridView2.Rows[0].Cells["dgv2_MEMO"].Value.ToString();

                    string pInputId = "1";

                    M_WsCCodeGrp.WsComnCodeGrp wSvc = null;
                    string reCode = "";
                    string reMsg = "";
                    string reData = "";
                    try
                    {
                        wSvc = new M_WsCCodeGrp.WsComnCodeGrp();
                        wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/ComnCode/WsComnCodeGrp.svc";
                        wSvc.Timeout = 1000;

                        reCode = wSvc.exComnCodeGrp(ccodeGrp_val, out reMsg, out reData);

                        if (reCode == "Y" && reData != "0")
                        {
                            MessageBox.Show(msgRM.GetString("msgDuplicated"));
                        }
                        else
                        {
                            reCode = "";
                            reCode = wSvc.aComnCodeGrp(ccodeGrp_val, ccodeNm_val, usingFlag_val, sortNo_val, memo_val, pInputId, out reMsg, out reData);

                            int reCnt = 0;

                            if (reCode == "Y" && reData != "")
                                reCnt = Convert.ToInt16(reData);

                            if (reCnt > 0)
                                MessageBox.Show(wRM.GetString("wSave") + " " + wRM.GetString("wSuccess") + " : " + reCnt.ToString());
                            else
                                MessageBox.Show(wRM.GetString("wSave") + " " + wRM.GetString("wFail"));
                        }

                        SetDataBind_gridView1();
                        SetDataBind_grideView2();

                    }
                    catch (Exception ex)
                    {
                        logs.SaveLog("[error]  (page)::FrmComnCodeGrpMainDB.cs  (Function)::dataGridView2_CellClick  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
                if (dataGridView2.Rows[0].Cells["dgv2_CCODE_GRP"].Value != null)
                {
                    if (dataGridView2.Rows[0].Cells["dgv2_CCODE_GRP"].Value.ToString() == "")
                    {
                        reVal = wRM.GetString("wCode");
                        return reVal;
                    }
                }
                else
                {
                    reVal = wRM.GetString("wCode");
                    return reVal;
                }

                if (dataGridView2.Rows[0].Cells["dgv2_CCODE_GRP_NM"].Value != null)
                {
                    if (dataGridView2.Rows[0].Cells["dgv2_CCODE_GRP_NM"].Value.ToString() == "")
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
                logs.SaveLog("[error]  (page)::FrmComnCodeGrpMainDB.cs  (Function)::ChkDgv2Param  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }

            return reVal;
        }

        private void NoSelectGrideView(DataGridView dgv)
        {
            dgv.ClearSelection();
            dgv.CurrentCell = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            M_WsCCodeGrp.WsComnCodeGrp wSvc = null;
            string reCode = "";
            string reMsg = "";
            int reData = 0;
            bool reSpecified = false;
            try
            {
                wSvc = new M_WsCCodeGrp.WsComnCodeGrp();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/ComnCode/WsComnCodeGrp.svc";
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
                            string ccode_val = dataGridView1.Rows[i].Cells["dgv1_CCODE_GRP"].Value.ToString();
                            string ccodeNm_val = dataGridView1.Rows[i].Cells["dgv1_CCODE_GRP_NM"].Value.ToString();
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
                            
                            reCode = wSvc.mComnCodeGrp(ccode_val, ccodeNm_val, usingFlag_val, sortNo_val, memo_val, out reMsg, out reData, out reSpecified);

                            if (reCode == "Y" && reData > 0)
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

                logs.SaveLog("[error]  (page)::FrmComnCodeGrpMainDB.cs  (Function)::btnSave_Click  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (wSvc != null)
                    wSvc.Dispose();
            }
        }
    }
}
