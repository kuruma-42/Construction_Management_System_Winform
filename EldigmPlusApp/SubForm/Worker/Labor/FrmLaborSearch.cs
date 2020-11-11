using EldigmPlusApp.Config;
using EldigmPlusApp.SubForm.Sys.CompanyTeam;
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

        string columnNm = "";
        int rowIdx = 0;

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

                btnAdd.Text = wRM.GetString("wAdd");
                btnSearch.Text = wRM.GetString("wSearch");
                btnReset.Text = wRM.GetString("wReset");
                lblAddInfo.Text = wRM.GetString("wAdd") + wRM.GetString("wInfo");

                //VISIBLE
                DataGridView1.Columns["dgv1_CHK"].HeaderText = wRM.GetString("wSelect");
                DataGridView1.Columns["dgv1_LAB_NO"].HeaderText = wRM.GetString("wWorker") + wRM.GetString("wNumber");
                DataGridView1.Columns["dgv1_CO_NM"].HeaderText = wRM.GetString("wCompany") + wRM.GetString("wName");
                DataGridView1.Columns["dgv1_LAB_NM"].HeaderText = wRM.GetString("wWorker") + wRM.GetString("wName");
                DataGridView1.Columns["dgv1_TEAM_NM"].HeaderText = wRM.GetString("wTeam") + wRM.GetString("wName");
                DataGridView1.Columns["dgv1_JOB_NM"].HeaderText = wRM.GetString("wJobType");
                DataGridView1.Columns["dgv1_BIRTH_DATE"].HeaderText = wRM.GetString("wBirthDate");
                DataGridView1.Columns["dgv1_MOBILE_NO"].HeaderText = wRM.GetString("wTel");
                DataGridView1.Columns["dgv1_USER_NO"].HeaderText = wRM.GetString("wUser") + wRM.GetString("wNumber");
                DataGridView1.Columns["dgv1_AUTH_CD"].HeaderText = wRM.GetString("wAuthority");

                //INVISIBLE(THESE ARE JUST FOR TRANSFERING DATA TO POP UP MODIFY PAGE)
                DataGridView1.Columns["dgv1_BLOCK_CCD"].HeaderText = wRM.GetString("wBlock") + wRM.GetString("wCode");
                DataGridView1.Columns["dgv1_CO_CD"].HeaderText = wRM.GetString("wCompany") + wRM.GetString("wCode");
                DataGridView1.Columns["dgv1_TEAM_CD"].HeaderText = wRM.GetString("wTeam") + wRM.GetString("wCode");
                DataGridView1.Columns["dgv1_JOB_CCD"].HeaderText = wRM.GetString("wJobType") + wRM.GetString("wCode");



                //POSSIBLE TO USE THESE DATA AFTER 
                //dataGridView1.Columns["dgv1_BLOCK_CCD"].HeaderText = "구역 C코드";
                //dataGridView1.Columns["dgv1_FACE_PHOTO"].HeaderText = "얼굴 사진";
                //dataGridView1.Columns["dgv1_LAB_STS"].HeaderText = "근로자 상태";




                //// 헤더 필수 항목 빨강색
                //dataGridView1.Columns["dgv1_DEVICE_ID"].HeaderCell.Style.ForeColor = Color.Maroon;
                //dataGridView1.Columns["dgv1_DEV_TYPE_SCD"].HeaderCell.Style.ForeColor = Color.Maroon;
                //dataGridView1.Columns["dgv1_DEV_IO_SCD"].HeaderCell.Style.ForeColor = Color.Maroon;

                Control.CheckForIllegalCrossThreadCalls = false;

                this.BackColor = Color.WhiteSmoke;

                splitContainer1.Panel1.BackColor = Color.LightSteelBlue;

                Class.Common.DatagrideViewStyleSet dvSet = new Class.Common.DatagrideViewStyleSet();
                dvSet.setStyle(DataGridView1, false, false);


                //lblName.BackColor = Color.FromArgb(204, 219, 243);
                this.panel1.Paint += new PaintEventHandler(this.paint_Purple1);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmLaborSearch.cs  (Function)::FrmLaborSearch  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        //private void btnShow_Click(object sender, EventArgs e)
        //{
        //    if (btnShow.Text == "↓↓")
        //    {
        //        splitContainer1.SplitterDistance = 150; // 2015.07.15 - 수정(120 -> 150)
        //        btnShow.Text = "↑↑";
        //    }
        //    else
        //    {
        //        splitContainer1.SplitterDistance = 40;
        //        btnShow.Text = "↓↓";
        //    }
        //}

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


                //LABOR INFO          
                SetDataBind_BlockCmb();
                SetDataBind_ConstCmb();
                SetDataBind_CompanyCmb();
                SetDataBind_TeamCmb();
                SetDataBind_LabSearchCondition();

                //ADD INFO 
                SetDataBind_CcodeCmb();
                SetDataBind_LabInfoTypeCmb();
                SetDataBind_TcodeCmb();
                SetDataBind_gridView1();
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmSysAuthSiteDB_Load.cs  (Function)::Form_Load  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }


        //BLOCK COMBO BOX 
        private void SetDataBind_BlockCmb()
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

                reCode = wSvc.sLaborBlockList(AppInfo.SsSiteCd, AppInfo.SsLabAuth, AppInfo.SsBlockCcd, wRM.GetString("wBlock"), out getData, out reMsg);
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

                        setCmb.Bind(searchCondition11.comboBox1);
                        searchCondition11.comboBox1.SelectedValue = "0";
                    }
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmLaborSearch.cs  (Function)::SetDataBind_CmbMember  (Detail):: " + "\r\n" + ex.ToString());
            }
        }

        //직종인지 공종인지 확실히 체크할 것 
        //CONST COMBO BOX 
        private void SetDataBind_ConstCmb()
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

                reCode = wSvc.sLaborConstList(AppInfo.SsSiteCd, AppInfo.SsLabAuth, AppInfo.SsConstCd, wRM.GetString("wConstructionTypes"), out getData, out reMsg);
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

                        setCmb.Bind(searchCondition11.comboBox2);
                        searchCondition11.comboBox2.SelectedValue = "0";
                    }
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmLaborSearch.cs  (Function)::SetDataBind_CmbMember  (Detail):: " + "\r\n" + ex.ToString());
            }
        }



        //COMPANY CMB BOX
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

                reCode = wSvc.sLaborCompanyList(AppInfo.SsSiteCd, AppInfo.SsLabAuth, AppInfo.SsCoCd, wRM.GetString("wCompany"), out getData, out reMsg);
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
                        setCmb.Bind(searchCondition11.comboBox3);
                        searchCondition11.comboBox3.SelectedIndex = searchCondition11.comboBox3.Items.Count - 1;
                    }
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmLaborSearch.cs  (Function)::SetDataBind_CmbMember  (Detail):: " + "\r\n" + ex.ToString());
            }
        }


        private void searchCondition11_cmb3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDataBind_TeamCmb();
        }



        //TEAM COMBO BOX 
        private void SetDataBind_TeamCmb()
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

                reCode = wSvc.sLaborTeamList(AppInfo.SsSiteCd, AppInfo.SsLabAuth, AppInfo.SsTeamCd, searchCondition11.comboBox3.SelectedValue.ToString(), wRM.GetString("wTeam"), out getData, out reMsg);
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

                        setCmb.Bind(searchCondition11.comboBox4);
                        searchCondition11.comboBox4.SelectedValue = "0";
                    }
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmLaborSearch.cs  (Function)::SetDataBind_CmbMember  (Detail):: " + "\r\n" + ex.ToString());
            }
        }



        private void SetDataBind_LabSearchCondition()
        {
            try
            {
                Class.Common.ComboBoxItemSet setCmb = null;

                setCmb = new Class.Common.ComboBoxItemSet();

                setCmb.AddColumn();

                setCmb.AddRow("근로자 이름", "1");
                setCmb.AddRow("휴대폰 번호", "2");
                setCmb.AddRow("생년월일", "3");
                setCmb.AddRow("직종 이름", "4");

                setCmb.Bind(searchCondition11.comboBox5);

            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmSysAuthMainDB_Load.cs  (Function)::setDataBind_Combo  (Detail):: " + "\r\n" + ex.ToString());
            }

        }


        //CCODE COMBO BOX 
        private void SetDataBind_CcodeCmb()
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

                reCode = wSvc.sLaborAddInfoCcode2(AppInfo.SsSiteCd, AppInfo.SsLabAuth, wRM.GetString("wGroup"), out getData, out reMsg);
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

                        setCmb.Bind(CcodeCmb);
                        CcodeCmb.SelectedValue = "0";
                    }
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmLaborSearchPop.cs  (Function)::SetDataBind_CcodeCmb  (Detail):: " + "\r\n" + ex.ToString());
            }
        }


        //LAB INFO TYPE CMB BOX 
        private void SetDataBind_LabInfoTypeCmb()
        {
            Mem_WsWorkerLaborSearch.WsWorkerLaborSearch wSvc = null;
            string reCode = "";
            string reMsg = "";
            Mem_WsWorkerLaborSearch.DataComComboStr[] getData = null;
            try
            {
                wSvc = new Mem_WsWorkerLaborSearch.WsWorkerLaborSearch();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer1 + "/WebSvc/Worker/Labor/WsWorkerLaborSearch.svc";
                wSvc.Timeout = 1000;

                reCode = wSvc.sLabInfoTypeList(AppInfo.SsSiteCd, wRM.GetString("wForm"), out getData, out reMsg);
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

                        setCmb.Bind(LabInfoTypeCmb);
                        LabInfoTypeCmb.SelectedValue = "0";
                    }
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmLaborSearch.cs  (Function)::SetDataBind_LabInfoTypeCmb  (Detail):: " + "\r\n" + ex.ToString());
            }
        }


        //TCODE TYPE CMB BOX 
        private void SetDataBind_TcodeCmb()
        {
            Mem_WsWorkerLaborSearch.WsWorkerLaborSearch wSvc = null;
            string reCode = "";
            string reMsg = "";
            Mem_WsWorkerLaborSearch.DataComComboStr[] getData = null;
            try
            {
                wSvc = new Mem_WsWorkerLaborSearch.WsWorkerLaborSearch();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer1 + "/WebSvc/Worker/Labor/WsWorkerLaborSearch.svc";
                wSvc.Timeout = 1000;




                reCode = wSvc.sLabTcodeList(AppInfo.SsSiteCd, CcodeCmb.SelectedValue.ToString(), LabInfoTypeCmb.SelectedValue.ToString(), wRM.GetString("wCategory"), AppInfo.SsLabAuth, out getData, out reMsg);
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

                        setCmb.Bind(TcodeCmb);
                        TcodeCmb.SelectedValue = "0";
                    }
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmLaborSearch.cs  (Function)::SetDataBind_LabInfoTypeCmb  (Detail):: " + "\r\n" + ex.ToString());
            }
        }

        //COMBO BOX 가 없을 때 Null Exception 
        private void set_Grideview4Combo1()
        {
            Mem_WsWorkerLaborSearch.WsWorkerLaborSearch wSvc = null;
            string reCode = "";
            string reMsg = "";
            Mem_WsWorkerLaborSearch.DataAddinfoCcodesub[] getData = null;
            try
            {
                wSvc = new Mem_WsWorkerLaborSearch.WsWorkerLaborSearch();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer1 + "/WebSvc/Worker/Labor/WsWorkerLaborSearch.svc";
                wSvc.Timeout = 1000;

                reCode = wSvc.sLaborAddInfoSub(AppInfo.SsDbNm, TcodeCmb.SelectedValue.ToString(), out getData, out reMsg);
                if (reCode == "Y")
                {
                    if (getData != null && getData.Length > 0)
                    {
                        Class.Common.ComboBoxItemSet setCmb = null;

                        setCmb = new Class.Common.ComboBoxItemSet();
                        setCmb.AddColumn();

                        for (int i = 0; i < getData.Length; i++)
                        {
                            setCmb.AddRow(getData[i].TSCODE_NM.ToString(), getData[i].TSCODE.ToString());
                        }

                        setCmb.Bind(comboSearch);
                        //comboSearch.SelectedValue = "0";
                    }
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmCompany.cs  (Function)::SetDataBind_CmbMember  (Detail):: " + "\r\n" + ex.ToString());
            }
        }

        private void SetDataBind_gridView1()
        {
            string reVal = ChkDgv2Param();

            if (reVal != "")
                MessageBox.Show(wRM.GetString("wCheck") + " :: " + reVal);

            else
            {
                string pSearchTxt = "";
                if (!string.IsNullOrEmpty(searchCondition11.textSearch.Text))
                {
                    pSearchTxt = searchCondition11.textSearch.Text;
                }

                string pBlockCcd = searchCondition11.comboBox1.SelectedValue.ToString();
                string pConstCcd = searchCondition11.comboBox2.SelectedValue.ToString();
                string pCodCd = searchCondition11.comboBox3.SelectedValue.ToString();
                string pTeamCd = searchCondition11.comboBox4.SelectedValue.ToString();
                string pSearchCondition = searchCondition11.comboBox5.SelectedValue.ToString();

                string pTtypeScd = LabInfoTypeCmb.SelectedValue.ToString();
                string pTcode = TcodeCmb.SelectedValue.ToString();
                string pValue = "";

                //CHECK VALUE 는 TEXT로 가져올 수 없음 CHECKED를 써야함. 
                if (pTtypeScd == "Check")
                {
                    if (chkSearch.Checked == true)
                    {
                        pValue = "1";
                    }
                    else
                    {
                        pValue = "0";
                    }
                }

                else if (pTtypeScd == "Text")
                {
                    pValue = txtSearch.Text;
                }

                else if (pTtypeScd == "Calender")
                {
                    pValue = Convert.ToDateTime(calSearch.Value).ToString("yyyyMMdd");
                }

                else if (pTtypeScd == "Combobox")
                {
                    pValue = comboSearch.SelectedValue.ToString();
                }

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
                    reCode = wSvc.sLaborSearch(AppInfo.SsSiteCd, pBlockCcd, pConstCcd, pCodCd, pTeamCd, pSearchCondition, pSearchTxt, pTtypeScd, pTcode, pValue, out getData, out reMsg); //AppInfo.SsSiteCD

                    if (reCode == "Y")
                    {
                        if (getData != null && getData.Length > 0)
                        {
                            DataGridView1.Rows.Clear();
                            for (int i = 0; i < getData.Length; i++)
                            {
                                DataGridView1.Rows.Add();
                                //VISBLE 
                                DataGridView1.Rows[i].Cells["dgv1_LAB_NO"].Value = getData[i].LAB_NO.ToString();
                                DataGridView1.Rows[i].Cells["dgv1_CO_NM"].Value = getData[i].CO_NM.ToString();
                                DataGridView1.Rows[i].Cells["dgv1_LAB_NM"].Value = getData[i].LAB_NM.ToString();
                                DataGridView1.Rows[i].Cells["dgv1_JOB_NM"].Value = getData[i].JOB_NM.ToString();
                                DataGridView1.Rows[i].Cells["dgv1_TEAM_NM"].Value = getData[i].TEAM_NM.ToString();
                                DataGridView1.Rows[i].Cells["dgv1_BIRTH_DATE"].Value = getData[i].BIRTH_DATE.ToString();
                                DataGridView1.Rows[i].Cells["dgv1_MOBILE_NO"].Value = getData[i].MOBILE_NO.ToString();
                                DataGridView1.Rows[i].Cells["dgv1_USER_NO"].Value = getData[i].USER_NO.ToString();
                                DataGridView1.Rows[i].Cells["dgv1_AUTH_CD"].Value = getData[i].AUTH_CD.ToString();
                                DataGridView1.Rows[i].Cells["dgv1_BIRTH_DATE"].Value = getData[i].BIRTH_DATE.ToString();
                                DataGridView1.Rows[i].Cells["dgv1_MOBILE_NO"].Value = getData[i].MOBILE_NO.ToString();
                                DataGridView1.Rows[i].Cells["dgv1_USER_NO"].Value = getData[i].USER_NO.ToString();
                                DataGridView1.Rows[i].Cells["dgv1_AUTH_CD"].Value = getData[i].AUTH_CD.ToString();

                                //INVISIBLE(THESE ARE JUST FOR TRANSFERING DATA TO POP UP MODIFY PAGE)
                                DataGridView1.Rows[i].Cells["dgv1_BLOCK_CCD"].Value = getData[i].BLOCK_CCD.ToString();
                                DataGridView1.Rows[i].Cells["dgv1_CO_CD"].Value = getData[i].CO_CD.ToString();
                                DataGridView1.Rows[i].Cells["dgv1_TEAM_CD"].Value = getData[i].TEAM_CD.ToString();
                                DataGridView1.Rows[i].Cells["dgv1_JOB_CCD"].Value = getData[i].JOB_CCD.ToString();



                                //dataGridView1.Rows[i].Cells["dgv1_FACE_PHOTO"].Value = getData[i].FACE_PHOTO.ToString();      
                                //dataGridView1.Rows[i].Cells["dgv1_BLOCK_CCD"].Value = getData[i].BLOCK_CCD.ToString();
                                //dataGridView1.Rows[i].Cells["dgv1_LAB_STS"].Value = getData[i].LAB_STS.ToString();

                            }

                            SetRowNumber(DataGridView1);
                        }

                        else
                        {
                            MessageBox.Show("검색된 데이터가 없습니다.");
                            //SetDataBind_LabSearchCondition();
                            //SetDataBind_TeamCmb();
                            //SetDataBind_BlockCmb();
                            //SetDataBind_ConstCmb();
                            //SetDataBind_CompanyCmb();
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
        }

        private void btnSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                btnSearch_Click(null, null);
            }
        }


        //PARAMETER CHECK 
        private string ChkDgv2Param()
        {
            string reVal = "";

            try
            {
                if (CcodeCmb.SelectedValue != null)
                {
                    if (CcodeCmb.SelectedValue.ToString() != "0")
                    {
                        if (LabInfoTypeCmb.SelectedValue.ToString() == "0")
                        {
                            reVal = wRM.GetString("wAdd") + wRM.GetString("wInfo") + " - " + wRM.GetString("wForm");
                            return reVal;
                        }
                    }
                }



                if (LabInfoTypeCmb.SelectedValue != null)
                {
                    //추가정보 형식이 선택 되었을 때
                    if (LabInfoTypeCmb.SelectedValue.ToString() != "0")
                    {
                        //추가정보 항목이 선택이 안 되었을 때  
                        if (TcodeCmb.SelectedValue.ToString() == "0")
                        {
                            reVal = wRM.GetString("wAdd") + wRM.GetString("wInfo") + " - " + wRM.GetString("wCategory");
                            return reVal;
                        }
                        //추가 정보 항목이 선택 되었을 때 
                        else if (TcodeCmb.SelectedValue.ToString() != "0")
                        {
                            //형식이 Text 이고 값이 없을 때 
                            if (LabInfoTypeCmb.SelectedValue.ToString() == "Text" && txtSearch.Text == "")
                            {
                                reVal = wRM.GetString("wAdd") + wRM.GetString("wInfo") + " " + msgRM.GetString("msgInputValue");
                                return reVal;
                            }

                            //형식이 Calender 이고 값이 없을 때 
                            if (LabInfoTypeCmb.SelectedValue.ToString() == "Calender" && calSearch.Text == "")
                            {
                                reVal = wRM.GetString("wAdd") + wRM.GetString("wInfo") + " " + msgRM.GetString("msgInputValue");
                                return reVal;
                            }

                            //형식이 Combobox 이고 값이 없을 때 
                            if (LabInfoTypeCmb.SelectedValue.ToString() == "Combobox" && comboSearch.Text == "")
                            {
                                reVal = wRM.GetString("wAdd") + wRM.GetString("wInfo") + " " + msgRM.GetString("msgInputValue");
                                return reVal;
                            }

                            //형식이 Check 이고 값이 없을 때는 쓰지 않는다. Checked == true & false 만 존재.  
                            //if (LabInfoTypeCmb.SelectedValue.ToString() == "Check" && chkSearch.Text == "")
                            //{
                            //    reVal = wRM.GetString("wAdd") + wRM.GetString("wInfo") + " " + msgRM.GetString("msgInputValue");
                            //    return reVal;
                            //}

                        }
                    }
                    else if (LabInfoTypeCmb.SelectedValue.ToString() == "0")
                    {
                        if (TcodeCmb.SelectedValue.ToString() != "0")
                        {
                            reVal = wRM.GetString("wAdd") + wRM.GetString("wInfo") + " - " + wRM.GetString("wForm");
                            return reVal;
                        }
                    }
                }
                else
                {
                    reVal = wRM.GetString("wAdd") + wRM.GetString("wInfo");
                    return reVal;
                }


            }
            catch (Exception ex)
            {
                reVal = wRM.GetString("wError");
                logs.SaveLog("[error]  (page)::FrmLaborSearch.cs  (Function)::ChkDgv2Param  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }

            return reVal;
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
                string colName = DataGridView1.Columns[e.ColumnIndex].Name;
                if (colName != "dgv1_CHK")
                    DataGridView1.Rows[e.RowIndex].Cells["dgv1_CHK"].Value = "1";
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
                string columnNm = DataGridView1.Columns[e.ColumnIndex].Name;
                if (columnNm == "dgv1_CHK")
                {
                    for (int i = 0; i < DataGridView1.Rows.Count; i++)
                    {
                        if (chkUseAll)
                            DataGridView1.Rows[i].Cells[columnNm].Value = "0";
                        else
                            DataGridView1.Rows[i].Cells[columnNm].Value = "1";
                    }

                    if (chkUseAll)
                        chkUseAll = false;
                    else
                        chkUseAll = true;
                }
                else
                    SetRowNumber(DataGridView1);

                NoSelectGrideView(DataGridView1);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmSysCode.cs  (Function)::dataGridView1_ColumnHeaderMouseClick  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        private void NoSelectGrideView(DataGridView dgv)
        {
            dgv.ClearSelection();
            dgv.CurrentCell = null;
        }



        private void btnSearch_Click(object sender, EventArgs e)
        {
            SetDataBind_gridView1();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmLaborSearchPop frm = new FrmLaborSearchPop();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowInTaskbar = false;
            frm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            frm.TopMost = true;

            //DialogResult result =
            frm.ShowDialog();
        }


        //MODIFY FUNCTION
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            columnNm = DataGridView1.Columns[e.ColumnIndex].Name;
            rowIdx = Convert.ToInt16(DataGridView1.Rows[e.RowIndex].Index);

            if (e.RowIndex < 0)
                return;


            //COMBO VALUE 
            string pBlock_Cd = DataGridView1.Rows[e.RowIndex].Cells["dgv1_BLOCK_CCD"].Value.ToString();
            string pCo_Cd = DataGridView1.Rows[e.RowIndex].Cells["dgv1_CO_CD"].Value.ToString();
            string pTeam_Cd = DataGridView1.Rows[e.RowIndex].Cells["dgv1_TEAM_CD"].Value.ToString();
            string pJob_Cd = DataGridView1.Rows[e.RowIndex].Cells["dgv1_JOB_CCD"].Value.ToString();

            //TEXT 
            string pLab_No = DataGridView1.Rows[e.RowIndex].Cells["dgv1_LAB_NO"].Value.ToString();
            string pLab_Nm = DataGridView1.Rows[e.RowIndex].Cells["dgv1_LAB_NM"].Value.ToString();
            string pBirth_Date = DataGridView1.Rows[e.RowIndex].Cells["dgv1_BIRTH_DATE"].Value.ToString();
            string pMobile_No = DataGridView1.Rows[e.RowIndex].Cells["dgv1_MOBILE_NO"].Value.ToString();
            string pUser_No = DataGridView1.Rows[e.RowIndex].Cells["dgv1_USER_NO"].Value.ToString();
            string pAuth_Cd = DataGridView1.Rows[e.RowIndex].Cells["dgv1_AUTH_CD"].Value.ToString();


            //PART OF LABOR SEARCH POP UP MODIFYING PAGE CALLING 
            FrmLaborSearchPopModify frm = new FrmLaborSearchPopModify(pBlock_Cd, pCo_Cd, pTeam_Cd, pJob_Cd, pLab_No, pLab_Nm, pBirth_Date, pMobile_No, pUser_No, pAuth_Cd, this);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowInTaskbar = false;
            frm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            frm.TopMost = true;

            //DialogResult result =
            frm.ShowDialog();
        }

        private void btnComAdd_Click(object sender, EventArgs e)
        {
            FrmCompany frm = new FrmCompany();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowInTaskbar = false;
            frm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            frm.TopMost = true;

            //DialogResult result =
            frm.ShowDialog();
        }

        private void CcodeCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDataBind_TcodeCmb();
            SetDataBind_LabInfoTypeCmb();
        }

        private void LabInfoTypeCmb_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (LabInfoTypeCmb.SelectedValue.ToString() == "Check")
            {
                SetDataBind_TcodeCmb();

                chkSearch.Visible = true;
                chkSearch.Enabled = true;
                txtSearch.Visible = false;

                calSearch.Visible = false;
                comboSearch.Visible = false;

                chkSearch.Checked = false; // 초기화
            }

            else if (LabInfoTypeCmb.SelectedValue.ToString() == "Text")
            {
                SetDataBind_TcodeCmb();

                chkSearch.Visible = false;
                txtSearch.Visible = true;
                txtSearch.Enabled = true;

                calSearch.Visible = false;
                comboSearch.Visible = false;

                txtSearch.Clear(); // 초기화
            }

            else if (LabInfoTypeCmb.SelectedValue.ToString() == "Calender")
            {
                SetDataBind_TcodeCmb();

                chkSearch.Visible = false;
                txtSearch.Visible = false;

                calSearch.Visible = true;
                calSearch.Enabled = true;
                comboSearch.Visible = false;


                calSearch.Value = DateTime.Now; // 초기화
            }

            else if (LabInfoTypeCmb.SelectedValue.ToString() == "Combobox")
            {
                SetDataBind_TcodeCmb();
                set_Grideview4Combo1();

                chkSearch.Visible = false;
                txtSearch.Visible = false;

                calSearch.Visible = false;
                comboSearch.Visible = true;
                comboSearch.Enabled = true;
            }

            else if (LabInfoTypeCmb.SelectedValue.ToString() == "0")
            {
                SetDataBind_TcodeCmb();

                chkSearch.Visible = false;
                txtSearch.Visible = false;

                calSearch.Visible = false;
                comboSearch.Visible = false;
            }
        }

        private void TcodeCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            set_Grideview4Combo1();
        }

        public void btnReset_Click(object sender, EventArgs e)
        {
            //LABOR INFO          
            SetDataBind_BlockCmb();
            SetDataBind_ConstCmb();
            SetDataBind_CompanyCmb();
            SetDataBind_TeamCmb();
            SetDataBind_LabSearchCondition();

            //ADD INFO 
            SetDataBind_CcodeCmb();
            SetDataBind_LabInfoTypeCmb();
            SetDataBind_TcodeCmb();
            SetDataBind_gridView1();
        }

        //FOR INSERT POP UP PART DATA GRID VIEW RESET 
        public void dgv1_Reset()
        {
            //LABOR INFO          
            SetDataBind_BlockCmb();
            SetDataBind_ConstCmb();
            SetDataBind_CompanyCmb();
            SetDataBind_TeamCmb();
            SetDataBind_LabSearchCondition();

            //ADD INFO 
            SetDataBind_CcodeCmb();
            SetDataBind_LabInfoTypeCmb();
            SetDataBind_TcodeCmb();
            SetDataBind_gridView1();
        }
    }
}







