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

namespace EldigmPlusApp.SubForm.Sys.Device
{
    public partial class FrmAccessDevice : Form
    {

        LogUtil logs = null;
        ResourceManager wRM = null;
        ResourceManager msgRM = null;


        public FrmAccessDevice()
        {
            // Sets the UI culture
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(AppInfo.SsLanguage);
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            this.AutoScaleMode = AutoScaleMode.Dpi;


            InitializeComponent(); try
            {
                logs = new LogUtil();
                wRM = new ResourceManager("EldigmPlusApp.GlobalLanguage.word_Language", typeof(FrmAccessDevice).Assembly);
                msgRM = new ResourceManager("EldigmPlusApp.GlobalLanguage.msg_Language", typeof(FrmAccessDevice).Assembly);

                btnSave.Text = wRM.GetString("wSave");
                dataGridView1.Columns["dgv1_CHK"].HeaderText = "선택";
                dataGridView1.Columns["dgv1_DEV_CD"].HeaderText = "장치 코드";
                dataGridView1.Columns["dgv1_DEVICE_ID"].HeaderText = "*장치 ID";
                dataGridView1.Columns["dgv1_DEV_TYPE_SCD"].HeaderText = "*장치 유형 S코드";
                dataGridView1.Columns["dgv1_DEV_IO_SCD"].HeaderText = "*장치 IO S코드";
                dataGridView1.Columns["dgv1_DEV_NM"].HeaderText = "장치 이름";
                dataGridView1.Columns["dgv1_IP"].HeaderText = "IP";
                dataGridView1.Columns["dgv1_USING_FLAG"].HeaderText = "사용 여부";
                dataGridView1.Columns["dgv1_SORT_NO"].HeaderText = "정렬";
                dataGridView1.Columns["dgv1_MEMO"].HeaderText = "메모";



                // 헤더 필수 항목 빨강색
                dataGridView1.Columns["dgv1_DEVICE_ID"].HeaderCell.Style.ForeColor = Color.Maroon;
                dataGridView1.Columns["dgv1_DEV_TYPE_SCD"].HeaderCell.Style.ForeColor = Color.Maroon;
                dataGridView1.Columns["dgv1_DEV_IO_SCD"].HeaderCell.Style.ForeColor = Color.Maroon;

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
                SetDataBind_gridView1();
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmSysAuthSiteDB_Load.cs  (Function)::Form_Load  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }





        //DEV TYPE COMBO 
        private void set_Grideview1Combo1(int rnum, string column_name)
        {
            Mem_WsDevice.WsDevice wSvc = null;
            string reCode = "";
            string reMsg = "";
            Mem_WsDevice.DataDevCombo[] getData = null;
            try
            {
                wSvc = new Mem_WsDevice.WsDevice();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer1 + "/WebSvc/Sys/Device/WsDevice.svc";
                wSvc.Timeout = 1000;

                reCode = wSvc.devTypeCmb(out getData, out reMsg);
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
                logs.SaveLog("[error]  (page)::FrmAccessDevice.cs  (Function)::SetDataBind_CmbMember  (Detail):: " + "\r\n" + ex.ToString());
            }
        }



        //DEV I/O COMBO
        private void set_Grideview1Combo2(int rnum, string column_name)
        {
            Mem_WsDevice.WsDevice wSvc = null;
            string reCode = "";
            string reMsg = "";
            Mem_WsDevice.DataDevCombo[] getData = null;
            try
            {
                wSvc = new Mem_WsDevice.WsDevice();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer1 + "/WebSvc/Sys/Device/WsDevice.svc";
                wSvc.Timeout = 1000;

                reCode = wSvc.devIOCmb(out getData, out reMsg);
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

                        dataGridView1.Rows[rnum].Cells[column_name] = cotype_Combo1;
                    }
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmAccessDevice.cs  (Function)::set_Grideview1Combo2  (Detail):: " + "\r\n" + ex.ToString());
            }
        }



        private void SetDataBind_gridView1()
        {
            Mem_WsDevice.WsDevice wSvc = null;
            string reCode = "";
            string reMsg = "";
            Mem_WsDevice.DataDevice[] getData = null;
            try
            {
                wSvc = new Mem_WsDevice.WsDevice();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer1 + "/WebSvc/Sys/Device/WsDevice.svc";
                wSvc.Timeout = 1000;

                reCode = wSvc.sDevice(AppInfo.SsDbNm, AppInfo.SsSiteCd, out getData, out reMsg); //AppInfo.SsSiteCD

                if (reCode == "Y")
                {
                    if (getData != null && getData.Length > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int i = 0; i < getData.Length; i++)
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[i].Cells["dgv1_DEV_CD"].Value = getData[i].DEV_CD.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_DEVICE_ID"].Value = getData[i].DEVICE_ID.ToString();
                            set_Grideview1Combo1(i, "dgv1_DEV_TYPE_SCD");
                            dataGridView1.Rows[i].Cells["dgv1_DEV_TYPE_SCD"].Value = getData[i].DEV_TYPE_SCD.ToString();
                            set_Grideview1Combo2(i, "dgv1_DEV_IO_SCD");
                            dataGridView1.Rows[i].Cells["dgv1_DEV_IO_SCD"].Value = getData[i].DEV_IO_SCD.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_DEV_NM"].Value = getData[i].DEV_NM.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_IP"].Value = getData[i].IP.ToString();
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
                logs.SaveLog("[error]  (page)::FrmAccessDevice.cs  (Function)::SetDataBind_gridView1  (Detail)::reMsg=[" + reMsg + "]", "Error");
                logs.SaveLog("[error]  (page)::FrmAccessDevice.cs  (Function)::SetDataBind_gridView1  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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


            Mem_WsDevice.WsDevice wSvc = null;
            string reCode = "";
            string reMsg = "";
            string reData = "0";
            try
            {
                wSvc = new Mem_WsDevice.WsDevice();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer1 + "/WebSvc/Sys/Device/WsDevice.svc";
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
                    if (dataGridView1.Rows[i].Cells["dgv1_DEV_CD"].Value != null)
                    {
                        if (dataGridView1.Rows[i].Cells["dgv1_CHK"].Value != null)
                        {
                            if (dataGridView1.Rows[i].Cells["dgv1_CHK"].Value.ToString() == "1")
                            {
                                string pDbNm = AppInfo.SsDbNm;
                                string pSiteCd = AppInfo.SsSiteCd;
                                string pDevCd = dataGridView1.Rows[i].Cells["dgv1_DEV_CD"].Value.ToString(); //Invisible

                                string pDeviceId = "";
                                if(dataGridView1.Rows[i].Cells["dgv1_DEVICE_ID"].Value == null)
                                {
                                    MessageBox.Show("장치 이름을 입력해주세요");
                                    return;
                                }
                                else
                                {
                                    pDeviceId = dataGridView1.Rows[i].Cells["dgv1_DEVICE_ID"].Value.ToString();                                    
                                }
                                    
                                string pDevTypeScd = dataGridView1.Rows[i].Cells["dgv1_DEV_TYPE_SCD"].Value.ToString();
                                string pDevIOScd = dataGridView1.Rows[i].Cells["dgv1_DEV_IO_SCD"].Value.ToString();
                                string pDevNm = "";
                                if (dataGridView1.Rows[i].Cells["dgv1_DEV_NM"].Value != null)
                                    pDevNm = dataGridView1.Rows[i].Cells["dgv1_DEV_NM"].Value.ToString();

                                string pIp = "";
                                if (dataGridView1.Rows[i].Cells["dgv1_IP"].Value != null)
                                    pIp = dataGridView1.Rows[i].Cells["dgv1_IP"].Value.ToString();

                                string pSortNo = "10";
                                if (dataGridView1.Rows[i].Cells["dgv1_SORT_NO"].Value != null)
                                    pSortNo = dataGridView1.Rows[i].Cells["dgv1_SORT_NO"].Value.ToString();

                                string pUsingFlag = dataGridView1.Rows[i].Cells["dgv1_USING_FLAG"].Value.ToString();

                                string pMemo = "";
                                if (dataGridView1.Rows[i].Cells["dgv1_MEMO"].Value != null)
                                    pMemo = dataGridView1.Rows[i].Cells["dgv1_MEMO"].Value.ToString();

                                //UPDATE 
                                reCode = wSvc.mDevice(pDbNm, pSiteCd, pDevCd, pDeviceId, pDevTypeScd, pDevIOScd, pDevNm, pIp, pSortNo, pUsingFlag, pMemo, out reMsg, out reData);

                                //UPDATE LOG 
                                wSvc.logDevice(pDbNm, pDevCd, pSiteCd, pDeviceId, pDevTypeScd, pDevIOScd, pDevNm, pIp, pUsingFlag, pSortNo, pMemo, AppInfo.SsUserId, out reMsg, out reData);

                                if (reCode == "Y" && reData != "0")
                                    reCnt += Convert.ToInt16(reData);
                            }
                        }
                    }
                    //DEV_CD 저장 버튼에서 추가가 일어난다. (DEV_CD 를 INVISIBLE로 해놨기 때문에 추가에는 DEV_CD가 NULL)
                    else if(dataGridView1.Rows[i].Cells["dgv1_DEV_CD"].Value == null)
                    {
                        if (dataGridView1.Rows[i].Cells["dgv1_CHK"].Value != null)
                        {
                            if (dataGridView1.Rows[i].Cells["dgv1_CHK"].Value.ToString() == "1")
                            {
                                string pDbNm = AppInfo.SsDbNm;
                                string pSiteCd = AppInfo.SsSiteCd;

                                string pDeviceId = "";
                                if (dataGridView1.Rows[i].Cells["dgv1_DEVICE_ID"].Value == null)
                                {
                                    MessageBox.Show("장치 이름을 입력해주세요");
                                    return;
                                }
                                else
                                {
                                    pDeviceId = dataGridView1.Rows[i].Cells["dgv1_DEVICE_ID"].Value.ToString();
                                }

                                string pDevTypeScd = "";
                                if (dataGridView1.Rows[i].Cells["dgv1_DEV_TYPE_SCD"].Value == null)
                                {
                                    MessageBox.Show("장치 유형을 선택해주세요");
                                    return;
                                }
                                else
                                {
                                    pDevTypeScd = dataGridView1.Rows[i].Cells["dgv1_DEV_TYPE_SCD"].Value.ToString();
                                }

                                string pDevIOScd = "";
                                if (dataGridView1.Rows[i].Cells["dgv1_DEV_IO_SCD"].Value == null)
                                {
                                    MessageBox.Show("장치 IO 선택해주세요");
                                    return;
                                }
                                else
                                {
                                    pDevIOScd = dataGridView1.Rows[i].Cells["dgv1_DEV_IO_SCD"].Value.ToString();
                                }
                                                              

                                string pDevNm = "";
                                if(dataGridView1.Rows[i].Cells["dgv1_DEV_NM"].Value != null)
                                    pDevNm = dataGridView1.Rows[i].Cells["dgv1_DEV_NM"].Value.ToString();

                                string pIp = "";
                                if(dataGridView1.Rows[i].Cells["dgv1_IP"].Value !=null)
                                    pIp = dataGridView1.Rows[i].Cells["dgv1_IP"].Value.ToString();

                                string pSortNo = "10";
                                if (dataGridView1.Rows[i].Cells["dgv1_SORT_NO"].Value != null)
                                    pSortNo = dataGridView1.Rows[i].Cells["dgv1_SORT_NO"].Value.ToString();

                                string pUsingFlag = "1";

                                string pMemo = "";
                                if (dataGridView1.Rows[i].Cells["dgv1_MEMO"].Value != null)
                                    pMemo = dataGridView1.Rows[i].Cells["dgv1_MEMO"].Value.ToString();



                                string[] param = new string[10];
                                param[0] = AppInfo.SsSiteCd;
                                param[1] = pDeviceId;
                                param[2] = pDevTypeScd;
                                param[3] = pDevIOScd;
                                param[4] = pDevNm;
                                param[5] = pIp;
                                param[6] = pUsingFlag;
                                param[7] = pSortNo;
                                param[8] = pMemo;
                                param[9] = AppInfo.SsUserId;

                                //INSERT WITH PROCEDURE 
                                reCode = wSvc.aDevicePro(AppInfo.SsDbNm, param, out reData, out reMsg);
                                                                                                                            

                                if (reCode == "Y" && reData != "0")
                                    reCnt += Convert.ToInt16(reData);
                            }
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
                logs.SaveLog("[error]  (page)::FrmSysAuthSiteDB.cs  (Function)::btnSave_Click  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (wSvc != null)
                    wSvc.Dispose();
            }
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

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            set_Grideview1Combo1(dataGridView1.RowCount - 1, "dgv1_DEV_TYPE_SCD");
            set_Grideview1Combo2(dataGridView1.RowCount - 1, "dgv1_DEV_IO_SCD");
        }
    }
}