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
    public partial class FrmSysAuthMainDB : Form
    {
        LogUtil logs = null;
        ResourceManager wRM = null;
        ResourceManager msgRM = null;

        public FrmSysAuthMainDB()
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
                dataGridView1.Columns["dgv1_MYBLOCK_FLAG"].HeaderText = msgRM.GetString("msgMyZoneStatus");
                dataGridView1.Columns["dgv1_MYCON_FLAG"].HeaderText = msgRM.GetString("msgMyConstructionTypesStatus");
                dataGridView1.Columns["dgv1_MYCOM_FLAG"].HeaderText = msgRM.GetString("msgMyCompanyStatus");
                dataGridView1.Columns["dgv1_MYTEAM_FLAG"].HeaderText = msgRM.GetString("msgMyTeamStatus");
                dataGridView1.Columns["dgv1_USING_FLAG"].HeaderText = msgRM.GetString("msgUsageStatus");
                dataGridView1.Columns["dgv1_AUTH_LEVEL"].HeaderText = wRM.GetString("wAuthority") + wRM.GetString("wLevel");
                dataGridView1.Columns["dgv1_MEMO"].HeaderText = wRM.GetString("wMemo");


                dataGridView2.Columns["dgv2_AUTH_CD"].HeaderText = "*" + wRM.GetString("wAuthority") + wRM.GetString("wCode");
                dataGridView2.Columns["dgv2_AUTH_NM"].HeaderText = "*" + wRM.GetString("wName");
                dataGridView2.Columns["dgv2_MYBLOCK_FLAG"].HeaderText = msgRM.GetString("msgMyZoneStatus");
                dataGridView2.Columns["dgv2_MYCON_FLAG"].HeaderText = msgRM.GetString("msgMyConstructionTypesStatus");
                dataGridView2.Columns["dgv2_MYCOM_FLAG"].HeaderText = msgRM.GetString("msgMyCompanyStatus");
                dataGridView2.Columns["dgv2_MYTEAM_FLAG"].HeaderText = msgRM.GetString("msgUsageStatus");
                dataGridView2.Columns["dgv2_AUTH_LEVEL"].HeaderText = "*" + wRM.GetString("wAuthority") + wRM.GetString("wLevel");
                dataGridView2.Columns["dgv2_MEMO"].HeaderText = wRM.GetString("wMemo");


                dataGridView2.Columns["dgv2_AUTH_CD"].HeaderCell.Style.ForeColor = Color.Maroon; // 헤더 필수 항목 빨강색
                dataGridView2.Columns["dgv2_AUTH_NM"].HeaderCell.Style.ForeColor = Color.Maroon;
                dataGridView2.Columns["dgv2_AUTH_LEVEL"].HeaderCell.Style.ForeColor = Color.Maroon;


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

        private void FrmSysAuthMainDB_Load(object sender, EventArgs e)
        {
            try
            {
                SetDataBind_Combo();
                SetDataBind_gridView1();
                SetDataBind_gridView2();
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmSysAuthMainDB_Load.cs  (Function)::Form_Load  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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

            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmSysAuthMainDB_Load.cs  (Function)::setDataBind_Combo  (Detail):: " + "\r\n" + ex.ToString());
            }

        }

        private void SetDataBind_gridView1()
        {
            M_WsSysAuthMainDB.WsSysAuthMainDB wSvc = null;
            string reCode = "";
            string reMsg = "";
            M_WsSysAuthMainDB.DataSysAuthMainDB[] getData = null;
            try
            {
                wSvc = new M_WsSysAuthMainDB.WsSysAuthMainDB();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/SysAuth/WsSysAuthMainDB.svc";
                wSvc.Timeout = 1000;

                reCode = wSvc.sSysAuthMainDB(cmbUse.SelectedValue.ToString(), out getData, out reMsg);

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
                            dataGridView1.Rows[i].Cells["dgv1_MYBLOCK_FLAG"].Value = getData[i].MYBLOCK_FLAG.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_MYCON_FLAG"].Value = getData[i].MYCON_FLAG.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_MYCOM_FLAG"].Value = getData[i].MYCOM_FLAG.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_MYTEAM_FLAG"].Value = getData[i].MYTEAM_FLAG.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_USING_FLAG"].Value = getData[i].USING_FLAG.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_AUTH_LEVEL"].Value = getData[i].AUTH_LEVEL.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_MEMO"].Value = getData[i].MEMO.ToString();
                        }

                        SetRowNumber(dataGridView1);
                    }
                }
            }
            catch (Exception ex)
            {
                //logs.SaveLog("[error]  (page)::FrmSysCodeGrp.cs  (Function)::SetDataBind_gridView1  (Detail)::pScodeGrp=[" + pScodeGrp + "]", "Error");
                logs.SaveLog("[error]  (page)::FrmSysAuthMainDB.cs  (Function)::SetDataBind_gridView1  (Detail)::reMsg=[" + reMsg + "]", "Error");
                logs.SaveLog("[error]  (page)::FrmSysAuthMainDB.cs  (Function)::SetDataBind_gridView1  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
            M_WsSysAuthMainDB.WsSysAuthMainDB wSvc = null;
            string reCode = "";
            string reMsg = "";
            string reData = "0";
            try
            {
                wSvc = new M_WsSysAuthMainDB.WsSysAuthMainDB();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/SysAuth/WsSysAuthMainDB.svc";
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
                    if (dataGridView1.Rows[i].Cells["dgv1_AUTH_CD"].Value != null)
                    {
                        if (dataGridView1.Rows[i].Cells["dgv1_CHK"].Value != null)
                        {
                            if (dataGridView1.Rows[i].Cells["dgv1_CHK"].Value.ToString() == "1")
                            {

                                string sauthCd_val = dataGridView1.Rows[i].Cells["dgv1_AUTH_CD"].Value.ToString();
                                string sauthNm_val = dataGridView1.Rows[i].Cells["dgv1_AUTH_NM"].Value.ToString();
                                string myblockFlag_val = dataGridView1.Rows[i].Cells["dgv1_MYBLOCK_FLAG"].Value.ToString();
                                string myconFlag_val = dataGridView1.Rows[i].Cells["dgv1_MYCON_FLAG"].Value.ToString();
                                string mycomFlag_val = dataGridView1.Rows[i].Cells["dgv1_MYCOM_FLAG"].Value.ToString();
                                string myteamFlag_val = dataGridView1.Rows[i].Cells["dgv1_MYTEAM_FLAG"].Value.ToString();
                                string usingFlag_val = dataGridView1.Rows[i].Cells["dgv1_USING_FLAG"].Value.ToString();
                                string sauthLevel_val = dataGridView1.Rows[i].Cells["dgv1_AUTH_LEVEL"].Value.ToString();
                                string memo_val = dataGridView1.Rows[i].Cells["dgv1_MEMO"].Value.ToString();

                                reCode = wSvc.mSysAuthMainDB(sauthCd_val, sauthNm_val, myblockFlag_val, myconFlag_val, mycomFlag_val, myteamFlag_val, usingFlag_val, memo_val, out reMsg, out reData);
                            }
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
                logs.SaveLog("[error]  (page)::FrmSysAuthMainDB.cs  (Function)::btnSave_Click  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
                dataGridView2.Rows[0].Cells["dgv2_BTNADD"].Value = wRM.GetString("wAdd");
                dataGridView2.Rows[0].Cells["dgv2_MYBLOCK_FLAG"].Value = "0";
                dataGridView2.Rows[0].Cells["dgv2_MYCON_FLAG"].Value = "0";
                dataGridView2.Rows[0].Cells["dgv2_MYCOM_FLAG"].Value = "0";
                dataGridView2.Rows[0].Cells["dgv2_MYTEAM_FLAG"].Value = "0";
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmSysAuthMainDB.cs  (Function)::setDataBind_grideView2  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }


        //추가버튼 클릭 
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
                    string sauthCd_val = dataGridView2.Rows[0].Cells["dgv2_AUTH_CD"].Value.ToString();
                    string sauthNm_val = dataGridView2.Rows[0].Cells["dgv2_AUTH_NM"].Value.ToString();
                    string myblockFlag_val = dataGridView2.Rows[0].Cells["dgv2_MYBLOCK_FLAG"].Value.ToString();
                    string myconFlag_val = dataGridView2.Rows[0].Cells["dgv2_MYCON_FLAG"].Value.ToString();
                    string mycomFlag_val = dataGridView2.Rows[0].Cells["dgv2_MYCOM_FLAG"].Value.ToString();
                    string myteamFlag_val = dataGridView2.Rows[0].Cells["dgv2_MYTEAM_FLAG"].Value.ToString();
                    string usingFlag_val = "1";
                    string sauthLevel_val = dataGridView2.Rows[0].Cells["dgv2_AUTH_LEVEL"].Value.ToString();
                    string memo_val = "";
                    if (dataGridView2.Rows[0].Cells["dgv2_MEMO"].Value != null)
                        memo_val = dataGridView2.Rows[0].Cells["dgv2_MEMO"].Value.ToString();
                    string pInputId = AppInfo.SsLabNo;



                    M_WsSysAuthMainDB.WsSysAuthMainDB wSvc = null;
                    string reCode = "";
                    string reMsg = "";
                    string reData = "";
                    try
                    {
                        wSvc = new M_WsSysAuthMainDB.WsSysAuthMainDB();
                        wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/SysAuth/WsSysAuthMainDB.svc";
                        wSvc.Timeout = 1000;

                        reCode = wSvc.exSysAuthMainDB(sauthCd_val, out reMsg, out reData); //중복 확인 

                        if (reCode == "Y" && reData != "0")
                            MessageBox.Show(msgRM.GetString("msgDuplicated"));
                        else
                        {
                            reCode = "";
                            reCode = wSvc.aSysAuthMainDB(sauthCd_val, sauthNm_val, myblockFlag_val, myconFlag_val, mycomFlag_val, myteamFlag_val, usingFlag_val, sauthLevel_val, memo_val, pInputId, out reMsg, out reData);

                            int reCnt = 0;

                            if (reCode == "Y" && reData != "")
                                reCnt = Convert.ToInt16(reData);

                            if (reCnt > 0)
                                MessageBox.Show(wRM.GetString("wSave") + " " + wRM.GetString("wSuccess"));
                            else
                                MessageBox.Show(wRM.GetString("wSave") + " " + wRM.GetString("wFail"));
                        }

                        SetDataBind_gridView1();
                        SetDataBind_gridView2();
                    }
                    catch (Exception ex)
                    {
                        logs.SaveLog("[error]  (page)::FrmSysAuthMainDB.cs  (Function)::dataGridView2_CellClick  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
                if (dataGridView2.Rows[0].Cells["dgv2_AUTH_CD"].Value != null)
                {
                    if (dataGridView2.Rows[0].Cells["dgv2_AUTH_CD"].Value.ToString() == "")
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

                if (dataGridView2.Rows[0].Cells["dgv2_AUTH_NM"].Value != null)
                {
                    if (dataGridView2.Rows[0].Cells["dgv2_AUTH_NM"].Value.ToString() == "")
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

                if (dataGridView2.Rows[0].Cells["dgv2_AUTH_LEVEL"].Value != null)
                {
                    if (dataGridView2.Rows[0].Cells["dgv2_AUTH_LEVEL"].Value.ToString() == "")
                    {
                        reVal = wRM.GetString("wAuthority") + wRM.GetString("wLevel");
                        return reVal;
                    }
                }
                else
                {
                    reVal = wRM.GetString("wAuthority") + wRM.GetString("wLevel");
                    return reVal;
                }
            }
            catch (Exception ex)
            {
                reVal = wRM.GetString("wError");
                logs.SaveLog("[error]  (page)::FrmSysAuthMainDB.cs  (Function)::ChkDgv2Param  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
                logs.SaveLog("[error]  (page)::FrmSysAuthMainDB.cs  (Function)::dataGridView1_CellBeginEdit  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
                logs.SaveLog("[error]  (page)::FrmSysAuthMainDB.cs  (Function)::dataGridView1_ColumnHeaderMouseClick  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}


