using EldigmPlusApp.Config;
using Framework.Log;
using System;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Threading;
using System.Windows.Forms;

namespace EldigmPlusApp.SubForm.Worker.Labor
{
    public partial class FrmLaborSearch : Form
    {

        LogUtil logs = null;
        ResourceManager wRM = null;
        ResourceManager msgRM = null;


        public FrmLaborSearch()
        {
            // Sets the UI culture
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(AppInfo.SsLanguage);
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            this.AutoScaleMode = AutoScaleMode.Dpi;


            InitializeComponent(); try
            {
                logs = new LogUtil();
                wRM = new ResourceManager("EldigmPlusApp.GlobalLanguage.word_Language", typeof(FrmLaborSearch).Assembly);
                msgRM = new ResourceManager("EldigmPlusApp.GlobalLanguage.msg_Language", typeof(FrmLaborSearch).Assembly);

                btnSave.Text = wRM.GetString("wSave");
                dataGridView1.Columns["dgv1_CHK"].HeaderText = "선택";
                dataGridView1.Columns["dgv1_LAB_NO"].HeaderText = "근로자 번호";
                dataGridView1.Columns["dgv1_USER_NO"].HeaderText = "사용자 번호";
                dataGridView1.Columns["dgv1_LAB_NM"].HeaderText = "근로자 이름";
                dataGridView1.Columns["dgv1_BIRTH_DATE"].HeaderText = "생년월일";
                dataGridView1.Columns["dgv1_MOBILE_NO"].HeaderText = "휴대폰 번호";
                dataGridView1.Columns["dgv1_FACE_PHOTO"].HeaderText = "얼굴 사진";              
                dataGridView1.Columns["dgv1_CO_CD"].HeaderText = "업체 코드";
                dataGridView1.Columns["dgv1_TEAM_CD"].HeaderText = "팀 코드";
                dataGridView1.Columns["dgv1_JOB_CCD"].HeaderText = "직종 C코드";
                dataGridView1.Columns["dgv1_BLOCK_CCD"].HeaderText = "구역 C코드";
                dataGridView1.Columns["dgv1_LAB_STS"].HeaderText = "근로자 상태";
                dataGridView1.Columns["dgv1_AUTH_CD"].HeaderText = "권한";



                //// 헤더 필수 항목 빨강색
                //dataGridView1.Columns["dgv1_DEVICE_ID"].HeaderCell.Style.ForeColor = Color.Maroon;
                //dataGridView1.Columns["dgv1_DEV_TYPE_SCD"].HeaderCell.Style.ForeColor = Color.Maroon;
                //dataGridView1.Columns["dgv1_DEV_IO_SCD"].HeaderCell.Style.ForeColor = Color.Maroon;

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
                logs.SaveLog("[error]  (page)::FrmLaborSearch.cs  (Function)::FrmLaborSearch  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        #region __ panel2 paint_Purple1
        private void paint_Purple1(object sender, PaintEventArgs e)
        {
            Class.UI.PanelPaint pp = new Class.UI.PanelPaint();
            pp.paint_PanelPurple1(sender, e);
        }



        #endregion

        private void FrmLaborSearch_Load(object sender, EventArgs e)
        {
            try
            {
                SetDataBind_CompanyCmb();
                SetDataBind_gridView1();
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmSysAuthSiteDB_Load.cs  (Function)::Form_Load  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }



        //업체 콤보 박스 
        private void SetDataBind_CompanyCmb()
        {
            Mem_WsWorkerLaborSearch.WsWorkerLaborSearch wSvc = null;
            string reCode = "";
            string reMsg = "";
            Mem_WsWorkerLaborSearch.DataComCombo[] getData = null;
            try
            {
                wSvc = new Mem_WsWorkerLaborSearch.WsWorkerLaborSearch();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer1 + "/WebSvc/Worker/Labor/WsWorkerLaborSearch.svc";
                wSvc.Timeout = 1000;

                reCode = wSvc.sLaborCompanyList(AppInfo.SsSiteCd, AppInfo.SsUserAuth, AppInfo.SsCoCd, out getData, out reMsg);
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
                logs.SaveLog("[error]  (page)::FrmLaborSearch.cs  (Function)::SetDataBind_CmbMember  (Detail):: " + "\r\n" + ex.ToString());
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
            Mem_WsWorkerLaborSearch.WsWorkerLaborSearch wSvc = null;
            string reCode = "";
            string reMsg = "";
            Mem_WsWorkerLaborSearch.DataLaborSearch[] getData = null;
            try
            {
                wSvc = new Mem_WsWorkerLaborSearch.WsWorkerLaborSearch();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer1 + "/WebSvc/Worker/Labor/WsWorkerLaborSearch.svc";
                wSvc.Timeout = 1000;

                //SELECT 
                reCode = wSvc.sLaborSearch(AppInfo.SsSiteCd, cmbCom.SelectedValue.ToString(), out getData, out reMsg); //AppInfo.SsSiteCD

                if (reCode == "Y")
                {
                    if (getData != null && getData.Length > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int i = 0; i < getData.Length; i++)
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[i].Cells["dgv1_LAB_NO"].Value = getData[i].LAB_NO.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_USER_NO"].Value = getData[i].USER_NO.ToString();                            
                            dataGridView1.Rows[i].Cells["dgv1_LAB_NM"].Value = getData[i].LAB_NM.ToString();                                                 
                            dataGridView1.Rows[i].Cells["dgv1_BIRTH_DATE"].Value = getData[i].BIRTH_DATE.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_MOBILE_NO"].Value = getData[i].MOBILE_NO.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_FACE_PHOTO"].Value = getData[i].FACE_PHOTO.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_CO_CD"].Value = getData[i].CO_CD.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_TEAM_CD"].Value = getData[i].TEAM_CD.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_JOB_CCD"].Value = getData[i].JOB_CCD.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_BLOCK_CCD"].Value = getData[i].BLOCK_CCD.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_LAB_STS"].Value = getData[i].LAB_STS.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_AUTH_CD"].Value = getData[i].AUTH_CD.ToString();
                        }

                        SetRowNumber(dataGridView1);
                    }
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmLaborSearch.cs  (Function)::SetDataBind_gridView1  (Detail)::reMsg=[" + reMsg + "]", "Error");
                logs.SaveLog("[error]  (page)::FrmLaborSearch.cs  (Function)::SetDataBind_gridView1  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
                                if (dataGridView1.Rows[i].Cells["dgv1_DEVICE_ID"].Value == null)
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
                    else if (dataGridView1.Rows[i].Cells["dgv1_DEV_CD"].Value == null)
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
                                if (dataGridView1.Rows[i].Cells["dgv1_DEV_NM"].Value != null)
                                    pDevNm = dataGridView1.Rows[i].Cells["dgv1_DEV_NM"].Value.ToString();

                                string pIp = "";
                                if (dataGridView1.Rows[i].Cells["dgv1_IP"].Value != null)
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

        }
        bool chkUseAll = false;
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void NoSelectGrideView(DataGridView dgv)
        {
            dgv.ClearSelection();
            dgv.CurrentCell = null;
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        private void cmbCom_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDataBind_gridView1();
        }
    }
}