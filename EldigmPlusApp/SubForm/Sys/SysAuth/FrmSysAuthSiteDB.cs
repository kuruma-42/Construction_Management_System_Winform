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

namespace EldigmPlusApp.SubForm.Sys.SysAuth
{
    public partial class FrmSysAuthSiteDB : Form
    {
        LogUtil logs = null;
        ResourceManager wRM = null;
        ResourceManager msgRM = null;

        string DBNM = "";

        public FrmSysAuthSiteDB()
        {
            // Sets the UI culture
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(AppInfo.SsLanguage);
            this.AutoScaleMode = AutoScaleMode.Dpi;

            InitializeComponent(); try
            {
                logs = new LogUtil();
                wRM = new ResourceManager("EldigmPlusApp.GlobalLanguage.word_Language", typeof(FrmSysAuthMainDB).Assembly);
                msgRM = new ResourceManager("EldigmPlusApp.GlobalLanguage.msg_Language", typeof(FrmSysAuthMainDB).Assembly);


                btnSave.Text = wRM.GetString("wSave");
                dataGridView1.Columns["dgv1_CHK"].HeaderText = wRM.GetString("wSelect");
                dataGridView1.Columns["dgv1_AUTH_CD"].HeaderText = wRM.GetString("wAuthority") + wRM.GetString("wCode");
                dataGridView1.Columns["dgv1_AUTH_NM"].HeaderText = wRM.GetString("wName");
                dataGridView1.Columns["dgv1_AUTH_LEVEL"].HeaderText = wRM.GetString("wAuthority") + wRM.GetString("wLevel");
                dataGridView1.Columns["dgv1_LAB_APRV_FLAG"].HeaderText = msgRM.GetString("msgWorkerApprovalStatus");
                dataGridView1.Columns["dgv1_USING_FLAG"].HeaderText = msgRM.GetString("msgUsageStatus");
                dataGridView1.Columns["dgv1_MEMO"].HeaderText = wRM.GetString("wMemo");




                Control.CheckForIllegalCrossThreadCalls = false;

                this.BackColor = Color.WhiteSmoke;

                splitContainer1.Panel1.BackColor = Color.LightSteelBlue;

                Class.Common.DatagrideViewStyleSet dvSet = new Class.Common.DatagrideViewStyleSet();
                dvSet.setStyle(dataGridView1, false, false);


                //lblName.BackColor = Color.FromArgb(204, 219, 243);
                this.panel1.Paint += new PaintEventHandler(this.paint_Purple1);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmSysAuthSiteDB.cs  (Function)::FrmSysCode  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        #region __ panel2 paint_Purple1
        private void paint_Purple1(object sender, PaintEventArgs e)
        {
            Class.UI.PanelPaint pp = new Class.UI.PanelPaint();
            pp.paint_PanelPurple1(sender, e);
        }



        #endregion

        private void FrmSysAuthMemberDB_Load(object sender, EventArgs e)
        {
            try
            {
                SetDataBind_CmbSite();
                SetDataBind_Combo();
                GetDbNm();
                SetDataBind_gridView1();
                
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmSysAuthSiteDB_Load.cs  (Function)::Form_Load  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        //CmbBox -> SITE
        private void SetDataBind_CmbSite()
        {
            Mem_WsSysAuthMemberDB.WsSysAuthMemberDB wSvc = null;
            string reCode = "";
            string reMsg = "";
            Mem_WsSysAuthMemberDB.DataSiteMainDB[] getData = null;
            try
            {
                wSvc = new Mem_WsSysAuthMemberDB.WsSysAuthMemberDB();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer1 + "/WebSvc/Sys/SysAuth/WsSysAuthMemberDB.svc";
                wSvc.Timeout = 1000;

                reCode = wSvc.sSiteMainDB(AppInfo.SsMemcoCd, out getData, out reMsg);
                if (reCode == "Y")
                {
                    if (getData != null && getData.Length > 0)
                    {
                        Class.Common.ComboBoxItemSet setCmb = null;

                        setCmb = new Class.Common.ComboBoxItemSet();
                        setCmb.AddColumn();

                        for (int i = 0; i < getData.Length; i++)
                        {
                            setCmb.AddRow(getData[i].SITE_NM.ToString(), getData[i].SITE_CD.ToString());
                        }

                        setCmb.Bind(cmbSite);
                    }
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmSysAuthSiteDB.cs  (Function)::SetDataBind_CmbMember  (Detail):: " + "\r\n" + ex.ToString());
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
                logs.SaveLog("[error]  (page)::FrmSysAuthSiteDB.cs  (Function)::setDataBind_Combo  (Detail):: " + "\r\n" + ex.ToString());
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
                        DBNM = reData;                        
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmSysAuthSiteDB.cs  (Function)::GetDbNm  (Detail)::reCode=[" + reCode + "], reMsg=[" + reMsg + "]", "Error");
                logs.SaveLog("[error]  (page)::FrmSysAuthSiteDB.cs  (Function)::GetDbNm  (Detail)::" + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (wSvc != null)
                    wSvc.Dispose();
            }
        }

        private void SetDataBind_gridView1()
        {
            Mem_WsSysAuthMemberDB.WsSysAuthMemberDB wSvc = null;
            string reCode = "";
            string reMsg = "";
            Mem_WsSysAuthMemberDB.DataSysAuthSiteDB[] getData = null;
            try
            {
                wSvc = new Mem_WsSysAuthMemberDB.WsSysAuthMemberDB();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer1 + "/WebSvc/Sys/SysAuth/WsSysAuthMemberDB.svc";
                wSvc.Timeout = 1000;

                reCode = wSvc.sSysAuthSiteDB(cmbSite.SelectedValue.ToString(), DBNM, cmbUse.SelectedValue.ToString(), out getData, out reMsg); //AppInfo.SsSiteCD

                if (reCode == "Y")
                {
                    if (getData != null && getData.Length > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int i = 0; i < getData.Length; i++)
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[i].Cells["dgv1_AUTH_CD"].Value = getData[i].AUTH_CD.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_AUTH_NM"].Value = getData[i].AUTH_NM.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_AUTH_LEVEL"].Value = getData[i].AUTH_LEVEL.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_LAB_APRV_FLAG"].Value = getData[i].LAB_APRV_FLAG.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_USING_FLAG"].Value = getData[i].USING_FLAG.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_MEMO"].Value = getData[i].MEMO.ToString();
                        }

                        SetRowNumber(dataGridView1);
                    }
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmSysAuthSiteDB.cs  (Function)::SetDataBind_gridView1  (Detail)::reMsg=[" + reMsg + "]", "Error");
                logs.SaveLog("[error]  (page)::FrmSysAuthSiteDB.cs  (Function)::SetDataBind_gridView1  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
            Mem_WsSysAuthMemberDB.WsSysAuthMemberDB wSvc = null;
            string reCode = "";
            string reMsg = "";
            string reData = "0";
            try
            {
                wSvc = new Mem_WsSysAuthMemberDB.WsSysAuthMemberDB();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer1 + "/WebSvc/Sys/SysAuth/WsSysAuthMemberDB.svc";
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
                int reCnt2 = 0;
                int reCnt3 = 0;

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells["dgv1_AUTH_CD"].Value != null)
                    {
                        if (dataGridView1.Rows[i].Cells["dgv1_CHK"].Value != null)
                        {
                            if (dataGridView1.Rows[i].Cells["dgv1_CHK"].Value.ToString() == "1")
                            {
                                            

                                string sauthCd_val = dataGridView1.Rows[i].Cells["dgv1_AUTH_CD"].Value.ToString(); //readonly        
                                string sauthNm_val = dataGridView1.Rows[i].Cells["dgv1_AUTH_NM"].Value.ToString(); //readonly 
                                string sauthLevel_val = dataGridView1.Rows[i].Cells["dgv1_AUTH_LEVEL"].Value.ToString(); //readonly 
                                string lab_aprv_Flag_val = dataGridView1.Rows[i].Cells["dgv1_LAB_APRV_FLAG"].Value.ToString();
                                string usingFlag_val = dataGridView1.Rows[i].Cells["dgv1_USING_FLAG"].Value.ToString();
                                string memo_val = "";
                                if (dataGridView1.Rows[i].Cells["dgv1_MEMO"].Value != null)
                                    memo_val = dataGridView1.Rows[i].Cells["dgv1_MEMO"].Value.ToString();



                                reCode = wSvc.mSysAuthSiteDB(DBNM, cmbSite.SelectedValue.ToString(), sauthCd_val, lab_aprv_Flag_val, usingFlag_val, memo_val, out reMsg, out reData);

                                if (reCode == "Y")
                                {
                                    //SITE DB 업데이트 실패시 INSERT 해준다.
                                    if (Convert.ToInt16(reData) < 1)
                                    {
                                        string pInputId = AppInfo.SsLabNo;
                                        if (usingFlag_val == "1")
                                        {
                                                                                
                                            reCode = wSvc.aSysAuthSiteDB(DBNM, cmbSite.SelectedValue.ToString(), sauthCd_val, lab_aprv_Flag_val, usingFlag_val, sauthLevel_val, memo_val, pInputId, out reMsg, out reData);

                                            if (reCode == "Y" && reData != "0")
                                            {
                                                reCnt += Convert.ToInt16(reData);
                                            }
                                        }
                                        else
                                        {
                                            reCnt3++;
                                        }
                                    }
                                    else
                                    {
                                        reCnt += Convert.ToInt16(reData);
                                    }
                                }
                                else
                                {
                                    reCnt2++;
                                }
                            }
                        }
                    }
                }

                if (reCnt > 0)
                {
                    MessageBox.Show(wRM.GetString("wSuccess") + "[" + reCnt.ToString() + "], " + wRM.GetString("wFail") + "[" + reCnt2.ToString() + "], " + wRM.GetString("wNotUsing") + "[" + reCnt3.ToString() + "]");
                }
                else
                {
                    MessageBox.Show(wRM.GetString("wSuccess") + "[" + reCnt.ToString() + "], " + wRM.GetString("wFail") + "[" + reCnt2.ToString() + "], " + wRM.GetString("wNotUsing") + "[" + reCnt3.ToString() + "]");
                }

                SetDataBind_gridView1();
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmSysAuthSiteDB.cs  (Function)::btnSave_Click  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
                logs.SaveLog("[error]  (page)::FrmSysAuthMemberDB.cs  (Function)::dataGridView1_CellBeginEdit  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }
        bool chkUseAll = false;
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                string columnNm = dataGridView1.Columns[e.ColumnIndex].Name;
                if (columnNm == "dgv1_CHK" || columnNm == "dgv1_USING_FLAG" || columnNm == "dgv1_LAB_APRV_FLAG")
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
                logs.SaveLog("[error]  (page)::FrmSysAuthMemberDB.cs  (Function)::dataGridView1_ColumnHeaderMouseClick  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        private void NoSelectGrideView(DataGridView dgv)
        {
            dgv.ClearSelection();
            dgv.CurrentCell = null;
        }

        //콤보박스 사용 미사용 전체 선택시 다시 로드
        private void cmbUse_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDataBind_gridView1();
        }

        private void cmbMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetDbNm();
            SetDataBind_gridView1();
        }      
    }
}