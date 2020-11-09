using EldigmPlusApp.Config;
using Framework.Log;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EldigmPlusApp.SubForm.Worker.Labor
{
    public partial class FrmLaborSearchPop : Form
    {
        LogUtil logs = null;
        ResourceManager wRM = null;
        ResourceManager msgRM = null;
        //List<string[]> _memoryAddinfoList = new List<string[]>();
        string _CcodeCmb = "";
        List<searchData> sd = new List<searchData>();
        searchData sdRow = new searchData();
        string _labNo = "";




        public FrmLaborSearchPop()
        {
            // Sets the UI culture
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(AppInfo.SsLanguage);
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            this.AutoScaleMode = AutoScaleMode.Dpi;


            InitializeComponent(); try
            {
                logs = new LogUtil();
                wRM = new ResourceManager("EldigmPlusApp.GlobalLanguage.word_Language", typeof(FrmLaborSearchPop).Assembly);
                msgRM = new ResourceManager("EldigmPlusApp.GlobalLanguage.msg_Language", typeof(FrmLaborSearchPop).Assembly);


                lblHead.Text = "** " + wRM.GetString("wWorker") + " " + wRM.GetString("wRegistration");
                lblName.Text = wRM.GetString("wWorker") + wRM.GetString("wName");
                lblPhone.Text = wRM.GetString("wTel");
                lblBirthDate.Text = wRM.GetString("wBirthDate");
                lblBlock.Text = wRM.GetString("wBlock");
                lblCom.Text = wRM.GetString("wCompany");
                lblJob.Text = wRM.GetString("wJobType");
                lblTeam.Text = wRM.GetString("wTeam");
                //lblJoinCom.Text = wRM.GetString("wJoinCom");
                btnAdd.Text = wRM.GetString("wAdd");
                btnCamera.Text = wRM.GetString("wCamera");
                btnFile.Text = wRM.GetString("wFile");

                dgv1_addInfo.Columns["dgv1_TCODE"].HeaderText = wRM.GetString("wTcode");
                dgv1_addInfo.Columns["dgv1_TTYPE_SCD"].HeaderText = "T" + wRM.GetString("wType") + wRM.GetString("wScode");
                dgv1_addInfo.Columns["dgv1_TCODE_NM"].HeaderText = wRM.GetString("wTcode") + wRM.GetString("wName");
                dgv1_addInfo.Columns["dgv1_CONTENT"].HeaderText = wRM.GetString("wContent");

                dgv2_addInfo.Columns["dgv2_TCODE"].HeaderText = wRM.GetString("wTcode");
                dgv2_addInfo.Columns["dgv2_TTYPE_SCD"].HeaderText = "T" + wRM.GetString("wType") + wRM.GetString("wScode");
                dgv2_addInfo.Columns["dgv2_TCODE_NM"].HeaderText = wRM.GetString("wTcode") + wRM.GetString("wName");
                dgv2_addInfo.Columns["dgv2_CONTENT"].HeaderText = wRM.GetString("wContent");

                dgv3_addInfo.Columns["dgv3_TCODE"].HeaderText = wRM.GetString("wTcode");
                dgv3_addInfo.Columns["dgv3_TTYPE_SCD"].HeaderText = "T" + wRM.GetString("wType") + wRM.GetString("wScode");
                dgv3_addInfo.Columns["dgv3_TCODE_NM"].HeaderText = wRM.GetString("wTcode") + wRM.GetString("wName");
                dgv3_addInfo.Columns["dgv3_CONTENT"].HeaderText = wRM.GetString("wContent");

                dgv4_addInfo.Columns["dgv4_TCODE"].HeaderText = wRM.GetString("wTcode");
                dgv4_addInfo.Columns["dgv4_TTYPE_SCD"].HeaderText = "T" + wRM.GetString("wType") + wRM.GetString("wScode");
                dgv4_addInfo.Columns["dgv4_TCODE_NM"].HeaderText = wRM.GetString("wTcode") + wRM.GetString("wName");
                dgv4_addInfo.Columns["dgv4_CONTENT"].HeaderText = wRM.GetString("wContent");


                btnAdd.BackColor = Color.LightSteelBlue;
                lblName.ForeColor = Color.Maroon;
                lblPhone.ForeColor = Color.Maroon;
                lblBirthDate.ForeColor = Color.Maroon;
                lblBlock.ForeColor = Color.Maroon;
                lblCom.ForeColor = Color.Maroon;
                //lblJob.ForeColor = Color.Maroon;
                //lblTeam.ForeColor = Color.Maroon;

                Control.CheckForIllegalCrossThreadCalls = false;

                this.BackColor = Color.WhiteSmoke;
                tabPage1.BackColor = Color.WhiteSmoke;

                splitContainer1.Panel2.BackColor = Color.LightSteelBlue;

                Class.Common.DatagrideViewStyleSet dvSet = new Class.Common.DatagrideViewStyleSet();
                dvSet.setStyle(dgv1_addInfo, false, false);
                dvSet.setStyle(dgv2_addInfo, false, false);
                dvSet.setStyle(dgv3_addInfo, false, false);
                dvSet.setStyle(dgv4_addInfo, false, false);


                lblHead.BackColor = Color.FromArgb(204, 219, 243);
                this.panel1.Paint += new PaintEventHandler(this.paint_Purple1);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmLaborSearchPop.cs  (Function)::FrmLaborSearchPop  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        #region __ panel2 paint_Purple1
        private void paint_Purple1(object sender, PaintEventArgs e)
        {
            Class.UI.PanelPaint pp = new Class.UI.PanelPaint();
            pp.paint_PanelPurple1(sender, e);
        }



        #endregion

        private void FrmLaborSearchPop_Load(object sender, EventArgs e)
        {
            try
            {
                //** LAB PART 
                SetDataBind_BlockCmb();
                SetDataBind_TeamCmb();
                SetDataBind_JobCmb();
                SetDataBind_CompanyCmb();

                //**ADD INFO PART 
                SetDataBind_CcodeCmb();
                SetDataBind_gridView1();
                SetDataBind_gridView2();
                SetDataBind_gridView3();
                SetDataBind_gridView4();
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmLaborSearchPop_Load.cs  (Function)::Form_Load  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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

                        setCmb.Bind(BlockCmb);
                        BlockCmb.SelectedIndex = BlockCmb.Items.Count - 1;
                        //BlockCmb.SelectedValue = "0";
                    }
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmLaborSearchPop.cs  (Function)::SetDataBind_BlockCmb  (Detail):: " + "\r\n" + ex.ToString());
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
                        setCmb.Bind(ComCmb);
                        ComCmb.SelectedIndex = ComCmb.Items.Count - 1;

                    }
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmLaborSearchPop.cs  (Function)::SetDataBind_CompanyCmb  (Detail):: " + "\r\n" + ex.ToString());
            }
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

                reCode = wSvc.sLaborTeamList(AppInfo.SsSiteCd, AppInfo.SsLabAuth, AppInfo.SsTeamCd, AppInfo.SsCoCd, wRM.GetString("wTeam"), out getData, out reMsg);
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

                        setCmb.Bind(TeamCmb);
                        TeamCmb.SelectedIndex = TeamCmb.Items.Count - 1;
                    }
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmLaborSearchPop.cs  (Function)::SetDataBind_TeamCmb  (Detail):: " + "\r\n" + ex.ToString());
            }
        }


        //JOB COMBO BOX 
        private void SetDataBind_JobCmb()
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

                reCode = wSvc.sLaborJobList(AppInfo.SsSiteCd, wRM.GetString("wConstructionTypes"), out getData, out reMsg);
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

                        setCmb.Bind(JobCmb);
                        JobCmb.SelectedIndex = JobCmb.Items.Count - 1;
                    }
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmLaborSearchPop.cs  (Function)::SetDataBind_JobCmb  (Detail):: " + "\r\n" + ex.ToString());
            }
        }

        //CCODE COMBO BOX 
        private void SetDataBind_CcodeCmb()
        {
            Mem_WsWorkerLaborSearch.WsWorkerLaborSearch wSvc = null;
            string reCode = "";
            string reMsg = "";
            Mem_WsWorkerLaborSearch.DataAddinfoCcode[] getData = null;
            try
            {
                wSvc = new Mem_WsWorkerLaborSearch.WsWorkerLaborSearch();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer1 + "/WebSvc/Worker/Labor/WsWorkerLaborSearch.svc";
                wSvc.Timeout = 1000;

                reCode = wSvc.sLaborAddInfoCcode(AppInfo.SsDbNm, AppInfo.SsSiteCd, AppInfo.SsLabAuth, out getData, out reMsg);
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

                        setCmb.Bind(CcodeCmb);
                        //CcodeCmb.SelectedIndex = CcodeCmb.Items.Count - 1;
                    }
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmLaborSearchPop.cs  (Function)::SetDataBind_CcodeCmb  (Detail):: " + "\r\n" + ex.ToString());
            }
        }



        private void NoSelectGrideView(DataGridView dgv)
        {
            dgv.ClearSelection();
            dgv.CurrentCell = null;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmLaborSearchPop frm = new FrmLaborSearchPop();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowInTaskbar = false;
            frm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            frm.TopMost = true;

            //DialogResult result =
            frm.Show();
        }


        //PREPARED FOR PROCEDURE 20.10.23 
        private void btnAdd_Click_pop(object sender, EventArgs e)
        {
            //faceImg_Save();
            string reVal = ChkDgv2Param();

            if (reVal != "")
                MessageBox.Show(wRM.GetString("wCheck") + " :: " + reVal);
            else
            {


                string pSite_Cd = AppInfo.SsSiteCd;
                string pLab_No = "";
                string pLab_Nm = NameKorTxt.Text;
                string pBirth_Date = Convert.ToDateTime(Birth_DatePicker.Value).ToString("yyyyMMdd");
                string pMobile_No = PhoneTxt.Text;
                string pCo_Cd = ComCmb.SelectedValue.ToString();
                string pTeam_Cd = TeamCmb.SelectedValue.ToString();
                string pJob_Cd = JobCmb.SelectedValue.ToString();
                string pBlock_Cd = BlockCmb.SelectedValue.ToString();
                string pInput_Id = AppInfo.SsLabNo;
                string pAuth_Cd = "";

                string pAprv_Flag = "0";




                Mem_WsWorkerLaborSearch.WsWorkerLaborSearch wSvc = null;
                string reCode = "";
                string reMsg = "";
                string reData = "";
                string[] reDataArray = new string[2];
                int reCnt = 0;
                try
                {
                    wSvc = new Mem_WsWorkerLaborSearch.WsWorkerLaborSearch();
                    wSvc.Url = "http://" + AppInfo.SsWsvcServer1 + "/WebSvc/Worker/Labor/WsWorkerLaborSearch.svc";
                    wSvc.Timeout = 1000;

                    //REGISTER AUTH CHECK
                    reCode = wSvc.sLabAprvFlag(pSite_Cd, AppInfo.SsLabAuth, out reData, out reMsg);
                    if (reCode == "Y")
                    {
                        if (reData == "1")
                        {
                            pAprv_Flag = "1";
                        }
                    }

                    //SELECT LOWEST AUTH AT SITE 
                    reCode = wSvc.sLabAuth(pSite_Cd, out reData, out reMsg);
                    if (reCode == "Y")
                    {
                        if (!string.IsNullOrEmpty(reData))
                            pAuth_Cd = reData;
                    }

                    //DUPLICATE CHECK MEMBER AND RETURN LAB_NO 
                    reCode = wSvc.exLabMember(pSite_Cd, pLab_Nm, pMobile_No, pBirth_Date, out reData, out reMsg);
                    if (reCode == "Y")
                    {
                        if (!string.IsNullOrEmpty(reData))
                        {
                            MessageBox.Show("중복 근로자");
                            return;
                        }
                        else
                        {
                            //DUPLICATE CHECK MAIN AND RETURN LAB_NO 
                            reCode = wSvc.exLabMain(pLab_Nm, pMobile_No, pBirth_Date, out reData, out reMsg);
                            if (!string.IsNullOrEmpty(reData))
                            {
                                pLab_No = reData;

                                string[] param = new string[12];
                                param[0] = pLab_No;
                                param[1] = pMobile_No;
                                param[2] = pLab_Nm;
                                param[3] = pBirth_Date;
                                param[4] = pSite_Cd;
                                param[5] = pCo_Cd;
                                param[6] = pAuth_Cd;
                                param[7] = pAprv_Flag;
                                param[8] = pTeam_Cd;
                                param[9] = pJob_Cd;
                                param[10] = pBlock_Cd;
                                param[11] = pInput_Id;

                                //INSERT WITH PROCEDURE
                                reCode = wSvc.aLaborPro(AppInfo.SsDbNm, param, out reDataArray, out reMsg);

                                // reDataArray BRING USERNO, LABNO FOR SAVE PICTURE  
                                string labNo = reDataArray[1].ToString();
                                string userNo = reDataArray[2].ToString();

                                reData = labNo;
                            }
                            else
                            {
                                pLab_No = "0";

                                string[] param = new string[12];
                                param[0] = pLab_No;
                                param[1] = pMobile_No;
                                param[2] = pLab_Nm;
                                param[3] = pBirth_Date;
                                param[4] = pSite_Cd;
                                param[5] = pCo_Cd;
                                param[6] = pAuth_Cd;
                                param[7] = pAprv_Flag;
                                param[8] = pTeam_Cd;
                                param[9] = pJob_Cd;
                                param[10] = pBlock_Cd;
                                param[11] = pInput_Id;

                                //INSERT WITH PROCEDURE
                                reCode = wSvc.aLaborPro(AppInfo.SsDbNm, param, out reDataArray, out reMsg);

                                // reDataArray BRING USERNO, LABNO FOR SAVE PICTURE  
                                _labNo = reDataArray[0].ToString();
                                string userNo = reDataArray[1].ToString();

                            }
                        }
                    }

                    for (int i = 0; i < sd.Count; i++)
                    {
                        string[] strArr = sd[i].str.Split('$');

                        if (strArr[1] == "Calender" && strArr[4] != "")
                        {
                            reCode = wSvc.mLaborLabTcodeSite(AppInfo.SsDbNm, _labNo, AppInfo.SsSiteCd, strArr[2], Convert.ToDateTime(strArr[4]).ToString("yyyyMMdd"), out reData, out reMsg);
                            if (reCode == "Y" && reData == "0")
                            {
                                //strArr[4] SHOULD CONVERT TO TYPE OF DATE AND SHAPE HAVE TO BE LIKE "yyyyMMdd"
                                reCode = wSvc.aLaborLabTcodeSite(AppInfo.SsDbNm, _labNo, AppInfo.SsSiteCd, strArr[2], strArr[1], Convert.ToDateTime(strArr[4]).ToString("yyyyMMdd"), out reData, out reMsg);

                                if (reCode == "Y" && reData == "1")
                                {
                                    //LAB TCODE SITE LOG WHEN INSTERT SUCCESS 
                                    reCode = reCode = wSvc.aLaborLabTcodeSiteLog(AppInfo.SsDbNm, _labNo, AppInfo.SsSiteCd, strArr[2], strArr[1], Convert.ToDateTime(strArr[4]).ToString("yyyyMMdd"), AppInfo.SsLabNo, out reData, out reMsg);
                                }
                            }
                            else if (reCode == "Y" && reData == "1")
                            {
                                //LAB TCODE SITE LOG WHEN UPDATE SUCCESS 
                                reCode = reCode = wSvc.aLaborLabTcodeSiteLog(AppInfo.SsDbNm, _labNo, AppInfo.SsSiteCd, strArr[2], strArr[1], Convert.ToDateTime(strArr[4]).ToString("yyyyMMdd"), AppInfo.SsLabNo, out reData, out reMsg);
                            }

                        }
                        else
                        {
                            reCode = wSvc.mLaborLabTcodeSite(AppInfo.SsDbNm, _labNo, AppInfo.SsSiteCd, strArr[2], strArr[4], out reData, out reMsg);
                            if (reCode == "Y" && reData == "0")
                            {
                                reCode = wSvc.aLaborLabTcodeSite(AppInfo.SsDbNm, _labNo, AppInfo.SsSiteCd, strArr[2], strArr[1], strArr[4], out reData, out reMsg);

                                if (reCode == "Y" && reData == "1")
                                {
                                    //LAB TCODE SITE LOG WHEN INSTERT SUCCESS 
                                    reCode = reCode = wSvc.aLaborLabTcodeSiteLog(AppInfo.SsDbNm, _labNo, AppInfo.SsSiteCd, strArr[2], strArr[1], strArr[4], AppInfo.SsLabNo, out reData, out reMsg);
                                }
                            }
                            else if (reCode == "Y" && reData == "1")
                            {
                                //LAB TCODE SITE LOG WHEN UPDATE SUCCESS 
                                reCode = reCode = wSvc.aLaborLabTcodeSiteLog(AppInfo.SsDbNm, _labNo, AppInfo.SsSiteCd, strArr[2], strArr[1], strArr[4], AppInfo.SsLabNo, out reData, out reMsg);
                            }
                        }

                    }

                    // LIST FOR DGV SELECTED DATA BUT NOT BELONGING TO ARRAY  
                    // THIS DECLARE WILL BE RESET WHENEVER THIS CLASS BE CALLED 
                    List<searchData> sd1 = new List<searchData>();
                    searchData sdRow1 = new searchData();

                    //** DGV1 PART START 
                    for (int i = 0; i < dgv1_addInfo.RowCount; i++)
                    {
                        if (dgv1_addInfo.Rows[i].Cells["dgv1_CONTENT"].Value == null)
                            dgv1_addInfo.Rows[i].Cells["dgv1_CONTENT"].Value = "0";
                        else
                            dgv1_addInfo.Rows[i].Cells["dgv1_CONTENT"].Value.ToString();


                        sdRow1.str = _CcodeCmb + "$" + dgv1_addInfo.Rows[i].Cells["dgv1_TTYPE_SCD"].Value.ToString() + "$" + dgv1_addInfo.Rows[i].Cells["dgv1_TCODE"].Value.ToString()
                            + "$" + dgv1_addInfo.Rows[i].Cells["dgv1_TCODE_NM"].Value.ToString() + "$" + dgv1_addInfo.Rows[i].Cells["dgv1_CONTENT"].Value.ToString();

                        sd1.Add(sdRow1);

                    }


                    //** DGV2 PART START 
                    for (int i = 0; i < dgv2_addInfo.RowCount; i++)
                    {
                        if (dgv2_addInfo.Rows[i].Cells["dgv2_CONTENT"].Value == null)
                            dgv2_addInfo.Rows[i].Cells["dgv2_CONTENT"].Value = "";
                        else
                            dgv2_addInfo.Rows[i].Cells["dgv2_CONTENT"].Value.ToString();


                        sdRow1.str = _CcodeCmb + "$" + dgv2_addInfo.Rows[i].Cells["dgv2_TTYPE_SCD"].Value.ToString() + "$" + dgv2_addInfo.Rows[i].Cells["dgv2_TCODE"].Value.ToString()
                            + "$" + dgv2_addInfo.Rows[i].Cells["dgv2_TCODE_NM"].Value.ToString() + "$" + dgv2_addInfo.Rows[i].Cells["dgv2_CONTENT"].Value.ToString();

                        sd1.Add(sdRow1);

                    }

                    //** DGV3 PART START 
                    for (int i = 0; i < dgv3_addInfo.RowCount; i++)
                    {
                        if (dgv3_addInfo.Rows[i].Cells["dgv3_CONTENT"].Value == null)
                            dgv3_addInfo.Rows[i].Cells["dgv3_CONTENT"].Value = "";
                        else
                            dgv3_addInfo.Rows[i].Cells["dgv3_CONTENT"].Value.ToString();


                        sdRow1.str = _CcodeCmb + "$" + dgv3_addInfo.Rows[i].Cells["dgv3_TTYPE_SCD"].Value.ToString() + "$" + dgv3_addInfo.Rows[i].Cells["dgv3_TCODE"].Value.ToString()
                            + "$" + dgv3_addInfo.Rows[i].Cells["dgv3_TCODE_NM"].Value.ToString() + "$" + dgv3_addInfo.Rows[i].Cells["dgv3_CONTENT"].Value.ToString();

                        sd1.Add(sdRow1);

                    }

                    //** DGV4 PART START 
                    for (int i = 0; i < dgv4_addInfo.RowCount; i++)
                    {
                        if (dgv4_addInfo.Rows[i].Cells["dgv4_CONTENT"].Value == null)
                            dgv4_addInfo.Rows[i].Cells["dgv4_CONTENT"].Value = "";
                        else
                            dgv4_addInfo.Rows[i].Cells["dgv4_CONTENT"].Value.ToString();


                        sdRow1.str = _CcodeCmb + "$" + dgv4_addInfo.Rows[i].Cells["dgv4_TTYPE_SCD"].Value.ToString() + "$" + dgv4_addInfo.Rows[i].Cells["dgv4_TCODE"].Value.ToString()
                            + "$" + dgv4_addInfo.Rows[i].Cells["dgv4_TCODE_NM"].Value.ToString() + "$" + dgv4_addInfo.Rows[i].Cells["dgv4_CONTENT"].Value.ToString();

                        sd1.Add(sdRow1);
                    }


                    for (int i = 0; i < sd1.Count; i++)
                    {
                        string[] strArr = sd1[i].str.Split('$');

                        if (strArr[1] == "Calender" && strArr[4] != "")
                        {
                            reCode = wSvc.mLaborLabTcodeSite(AppInfo.SsDbNm, _labNo, AppInfo.SsSiteCd, strArr[2], Convert.ToDateTime(strArr[4]).ToString("yyyyMMdd"), out reData, out reMsg);
                            if (reCode == "Y" && reData == "0")
                            {
                                //strArr[4] SHOULD CONVERT TO TYPE OF DATE AND SHAPE HAVE TO BE LIKE "yyyyMMdd"
                                reCode = wSvc.aLaborLabTcodeSite(AppInfo.SsDbNm, _labNo, AppInfo.SsSiteCd, strArr[2], strArr[1], Convert.ToDateTime(strArr[4]).ToString("yyyyMMdd"), out reData, out reMsg);
                                if (reCode == "Y" && reData == "1")
                                {
                                    //LAB TCODE SITE LOG WHEN INSTERT SUCCESS 
                                    reCode = reCode = wSvc.aLaborLabTcodeSiteLog(AppInfo.SsDbNm, _labNo, AppInfo.SsSiteCd, strArr[2], strArr[1], Convert.ToDateTime(strArr[4]).ToString("yyyyMMdd"), AppInfo.SsLabNo, out reData, out reMsg);
                                }
                            }
                            else if (reCode == "Y" && reData == "1")
                            {
                                //LAB TCODE SITE LOG WHEN UPDATE SUCCESS 
                                reCode = reCode = wSvc.aLaborLabTcodeSiteLog(AppInfo.SsDbNm, _labNo, AppInfo.SsSiteCd, strArr[2], strArr[1], Convert.ToDateTime(strArr[4]).ToString("yyyyMMdd"), AppInfo.SsLabNo, out reData, out reMsg);
                            }
                        }
                        else
                        {
                            reCode = wSvc.mLaborLabTcodeSite(AppInfo.SsDbNm, _labNo, AppInfo.SsSiteCd, strArr[2], strArr[4], out reData, out reMsg);
                            if (reCode == "Y" && reData == "0")
                            {
                                reCode = wSvc.aLaborLabTcodeSite(AppInfo.SsDbNm, _labNo, AppInfo.SsSiteCd, strArr[2], strArr[1], strArr[4], out reData, out reMsg);
                                if (reCode == "Y" && reData == "1")
                                {
                                    //LAB TCODE SITE LOG WHEN INSTERT SUCCESS 
                                    reCode = reCode = wSvc.aLaborLabTcodeSiteLog(AppInfo.SsDbNm, _labNo, AppInfo.SsSiteCd, strArr[2], strArr[1], strArr[4], AppInfo.SsLabNo, out reData, out reMsg);
                                }
                            }
                            else if (reCode == "Y" && reData == "1")
                            {
                                //LAB TCODE SITE LOG WHEN UPDATE SUCCESS 
                                reCode = reCode = wSvc.aLaborLabTcodeSiteLog(AppInfo.SsDbNm, _labNo, AppInfo.SsSiteCd, strArr[2], strArr[1], strArr[4], AppInfo.SsLabNo, out reData, out reMsg);
                            }
                        }
                    }

                    if (reCode == "Y" && reData != "")
                        reCnt = Convert.ToInt16(reData);

                    if (reCnt != 0)
                        MessageBox.Show(wRM.GetString("wSave") + " " + wRM.GetString("wSuccess"));

                    else
                        MessageBox.Show(wRM.GetString("wSave") + " " + wRM.GetString("wFail"));

                }
                catch (Exception ex)
                {
                    logs.SaveLog("[error]  (page)::FrmLaborSearchPop.cs  (Function)::dataGridView2_CellClick  (Detail):: " + "\r\n" + ex.ToString(), "Error");
                }
                finally
                {
                    if (wSvc != null)
                        wSvc.Dispose();

                    //** LAB PART 
                    SetDataBind_BlockCmb();
                    SetDataBind_TeamCmb();
                    SetDataBind_JobCmb();
                    SetDataBind_CompanyCmb();

                    //**ADD INFO PART 
                    SetDataBind_CcodeCmb();
                    SetDataBind_gridView1();
                    SetDataBind_gridView2();
                    SetDataBind_gridView3();
                    SetDataBind_gridView4();
                }

            }
        }


        //public string saveFaceimg()
        //{
        //    Mem_WsWorkerLaborSearch.WsWorkerLaborSearch wSvc = null;
        //    string reCode = "";
        //    string reMsg = "";
        //    string reData = "";
        //    int reCnt = 0;
        //    try
        //    {
        //        wSvc = new Mem_WsWorkerLaborSearch.WsWorkerLaborSearch();
        //        wSvc.Url = "http://" + AppInfo.SsWsvcServer1 + "/WebSvc/Sys/CompanyTeam/WsSysCompanyTeam.svc";
        //        wSvc.Timeout = 1000;


        //        MemoryStream ms = new MemoryStream();

        //        pictureBox1.Image.Save(ms, ImageFormat.Jpeg);

        //        byte[] buffer = new byte[ms.Length];
        //        ms.Position = 0;
        //        ms.Read(buffer, 0, buffer.Length);
        //        ms.Close();


        //        string[] orgFileInfo;
        //        string orgFileNmFace = "";

        //        if (pictureBox1.ImageLocation != null)
        //        {
        //            orgFileInfo = pictureBox1.ImageLocation.ToString().Split('\\');
        //            orgFileNmFace = orgFileInfo[orgFileInfo.Length - 1].ToString();
        //        }


        //            f_Face = wsMain.HubSaveImageFile(Hub2Info.hub2LoginKey, AppInfo.SsUser_Id, AppInfo.SsMemco_Cd, AppInfo.SsSite_Cd, folder_nm, orgFileNmFace
        //                , Convert.ToBase64String(buffer));

        //            if (f_Face.ToString() == "-100")
        //                accessFail();

        //        else
        //        {
        //            string fileName = "";

        //            EldigmHub.Class.Common.FtpUploadClass ftpClass = new Class.Common.FtpUploadClass();
        //            fileName = ftpClass.filesToSend(buffer, folder_nm, orgFileNmFace);    // ftp 이미지 저장(썸네일 포함)

        //            // 사진파일정보DB저장
        //            if (fileName != "")
        //            {
        //                try
        //                {
        //                    string fileUrl = AppInfo.SsMemco_Cd + "/" + AppInfo.SsSite_Cd + "/" + folder_nm + "/";
        //                    f_Face = wsMain.sp_File_Save(Hub2Info.hub2LoginKey, AppInfo.SsUser_Id, AppInfo.SsSite_Cd, fileName, fileUrl, orgFileNmFace, "", folder_nm);
        //                    if (f_Face.ToString() == "-100")
        //                        accessFail();
        //                }
        //                catch (Exception ex)
        //                {
        //                    logs.SaveLog("[error]  (page)::FrmWorkerDetail.cs  (Function)::saveFaceimg 사진파일정보DB저장에러 (Detail):: " + "\r\n" + ex.ToString());
        //                }
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        logs.SaveLog("[error]  (page)::FrmWorkerDetail  (Function)::saveFaceimg  (Detail):: " + "\r\n" + ex.ToString());
        //        MessageBox.Show("사진저장 실패");
        //    }
        //    finally
        //    {
        //        if (wsMain != null)
        //            wsMain.Dispose();

        //        if (db != null)
        //            db.DisConnect();

        //        if (svcs != null)
        //            svcs.Dispose();
        //        if (wsMain != null)
        //            wsMain.Dispose();
        //    }


        //    return f_Face;
        //}

        private void btnFile_Click(object sender, EventArgs e)
        {
            string image_file = string.Empty;

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = @"C:\";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image_file = dialog.FileName;
            }

            else if (dialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            pictureBox1.Image = Bitmap.FromFile(image_file);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void faceImg_Save()
        {
            try
            {
                string save_route = @"D:\3.DevOps\testImg";

                if (!System.IO.Directory.Exists(save_route))
                {
                    System.IO.Directory.CreateDirectory(save_route);

                    pictureBox1.Image.Save(save_route + "\\test_image.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }

            catch (Exception ex)
            {
                return;
            }

        }


        //PARAMETER CHECK 
        private string ChkDgv2Param()
        {
            string reVal = "";

            try
            {
                if (NameKorTxt.Text != null)
                {
                    if (NameKorTxt.Text == "")
                    {
                        reVal = wRM.GetString("wWorker") + " " + wRM.GetString("wName");
                        return reVal;
                    }
                }
                else
                {
                    reVal = wRM.GetString("wWorker") + wRM.GetString("wName");
                    return reVal;
                }

                if (Birth_DatePicker.Value != null)
                {
                    if (Convert.ToDateTime(Birth_DatePicker.Value).ToString() == "")
                    {
                        reVal = wRM.GetString("wBirthDate");
                        return reVal;
                    }
                }
                else
                {
                    reVal = wRM.GetString("wBirthDate");
                    return reVal;
                }

                if (PhoneTxt.Text != null)
                {
                    if (PhoneTxt.Text == "")
                    {
                        reVal = wRM.GetString("wTel");
                        return reVal;
                    }
                }
                else
                {
                    reVal = wRM.GetString("wTel");
                    return reVal;
                }

                if (ComCmb.SelectedValue != null)
                {
                    if (ComCmb.SelectedValue.ToString() == "0")
                    {
                        reVal = wRM.GetString("wCompany");
                        return reVal;
                    }
                }
                else
                {
                    reVal = wRM.GetString("wCompany");
                    return reVal;
                }


                if (BlockCmb.SelectedValue != null)
                {
                    if (BlockCmb.SelectedValue.ToString() == "0")
                    {
                        reVal = wRM.GetString("wBlock");
                        return reVal;
                    }
                }
                else
                {
                    reVal = wRM.GetString("wBlock");
                    return reVal;
                }



            }
            catch (Exception ex)
            {
                reVal = wRM.GetString("wError");
                logs.SaveLog("[error]  (page)::FrmLaborSearchPop.cs  (Function)::ChkDgv2Param  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }

            return reVal;
        }

        //ADD INFO CHECK 
        private void SetDataBind_gridView1()
        {


            Mem_WsWorkerLaborSearch.WsWorkerLaborSearch wSvc = null;
            string reCode = "";
            string reMsg = "";
            Mem_WsWorkerLaborSearch.DataAddinfo[] getData = null;
            try
            {
                wSvc = new Mem_WsWorkerLaborSearch.WsWorkerLaborSearch();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer1 + "/WebSvc/Worker/Labor/WsWorkerLaborSearch.svc";
                wSvc.Timeout = 1000;

                //DECLARE TYPE OF TCODE 
                string pTcode = "Check";

                //SELECT
                reCode = wSvc.sLaborAddInfo(AppInfo.SsSiteCd, pTcode, CcodeCmb.SelectedValue.ToString(), out getData, out reMsg);

                if (reCode == "Y")
                {
                    if (getData != null && getData.Length > 0)
                    {
                        dgv1_addInfo.Rows.Clear();
                        for (int i = 0; i < getData.Length; i++)
                        {
                            dgv1_addInfo.Rows.Add();
                            //VISBLE 
                            dgv1_addInfo.Rows[i].Cells["dgv1_TCODE_NM"].Value = getData[i].TCODE_NM.ToString();

                            //INVISIBLE
                            dgv1_addInfo.Rows[i].Cells["dgv1_TCODE"].Value = getData[i].TCODE.ToString();
                            dgv1_addInfo.Rows[i].Cells["dgv1_TTYPE_SCD"].Value = getData[i].TTYPE_SCD.ToString();

                        }

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


        //ADD INFO TEXT 
        private void SetDataBind_gridView2()
        {


            Mem_WsWorkerLaborSearch.WsWorkerLaborSearch wSvc = null;
            string reCode = "";
            string reMsg = "";
            Mem_WsWorkerLaborSearch.DataAddinfo[] getData = null;
            try
            {
                wSvc = new Mem_WsWorkerLaborSearch.WsWorkerLaborSearch();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer1 + "/WebSvc/Worker/Labor/WsWorkerLaborSearch.svc";
                wSvc.Timeout = 1000;

                //DECLARE TYPE OF TCODE 
                string pTcode = "TEXT";

                //SELECT
                reCode = wSvc.sLaborAddInfo(AppInfo.SsSiteCd, pTcode, CcodeCmb.SelectedValue.ToString(), out getData, out reMsg);

                if (reCode == "Y")
                {
                    if (getData != null && getData.Length > 0)
                    {
                        dgv2_addInfo.Rows.Clear();
                        for (int i = 0; i < getData.Length; i++)
                        {
                            dgv2_addInfo.Rows.Add();
                            //VISBLE 
                            dgv2_addInfo.Rows[i].Cells["dgv2_TCODE_NM"].Value = getData[i].TCODE_NM.ToString();

                            //INVISIBLE
                            dgv2_addInfo.Rows[i].Cells["dgv2_TCODE"].Value = getData[i].TCODE.ToString();
                            dgv2_addInfo.Rows[i].Cells["dgv2_TTYPE_SCD"].Value = getData[i].TTYPE_SCD.ToString();

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmLaborSearch.cs  (Function)::SetDataBind_gridView2  (Detail)::reMsg=[" + reMsg + "]", "Error");
                logs.SaveLog("[error]  (page)::FrmLaborSearch.cs  (Function)::SetDataBind_gridView2  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (wSvc != null)
                    wSvc.Dispose();
            }
        }



        //ADD INFO CALENDER
        private void SetDataBind_gridView3()
        {


            Mem_WsWorkerLaborSearch.WsWorkerLaborSearch wSvc = null;
            string reCode = "";
            string reMsg = "";
            Mem_WsWorkerLaborSearch.DataAddinfo[] getData = null;
            try
            {
                wSvc = new Mem_WsWorkerLaborSearch.WsWorkerLaborSearch();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer1 + "/WebSvc/Worker/Labor/WsWorkerLaborSearch.svc";
                wSvc.Timeout = 1000;

                //DECLARE TYPE OF TCODE 
                string pTcode = "Calender";

                //SELECT
                reCode = wSvc.sLaborAddInfo(AppInfo.SsSiteCd, pTcode, CcodeCmb.SelectedValue.ToString(), out getData, out reMsg);

                if (reCode == "Y")
                {
                    if (getData != null && getData.Length > 0)
                    {
                        dgv3_addInfo.Rows.Clear();
                        for (int i = 0; i < getData.Length; i++)
                        {
                            dgv3_addInfo.Rows.Add();
                            //VISBLE 
                            dgv3_addInfo.Rows[i].Cells["dgv3_TCODE_NM"].Value = getData[i].TCODE_NM.ToString();

                            //INVISIBLE
                            dgv3_addInfo.Rows[i].Cells["dgv3_TCODE"].Value = getData[i].TCODE.ToString();
                            dgv3_addInfo.Rows[i].Cells["dgv3_TTYPE_SCD"].Value = getData[i].TTYPE_SCD.ToString();


                        }

                    }
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmLaborSearch.cs  (Function)::SetDataBind_gridView3  (Detail)::reMsg=[" + reMsg + "]", "Error");
                logs.SaveLog("[error]  (page)::FrmLaborSearch.cs  (Function)::SetDataBind_gridView3  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (wSvc != null)
                    wSvc.Dispose();
            }
        }

        //COMBO BOX 가 없을 때 Null Exception 
        private void set_Grideview4Combo1(int rnum, string column_name, string pTcode)
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

                reCode = wSvc.sLaborAddInfoSub(AppInfo.SsDbNm, pTcode, out getData, out reMsg);
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
                        DataGridViewComboBoxCell tCodeSubCombo = new DataGridViewComboBoxCell();

                        tCodeSubCombo.DisplayMember = "TEXT";
                        tCodeSubCombo.ValueMember = "VALUE";

                        tCodeSubCombo.DataSource = setCmb.GetDataTable();

                        dgv4_addInfo.Rows[rnum].Cells[column_name] = tCodeSubCombo;
                    }
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmCompany.cs  (Function)::SetDataBind_CmbMember  (Detail):: " + "\r\n" + ex.ToString());
            }
        }


        //ADD INFO COMBO
        private void SetDataBind_gridView4()
        {


            Mem_WsWorkerLaborSearch.WsWorkerLaborSearch wSvc = null;
            string reCode = "";
            string reMsg = "";
            Mem_WsWorkerLaborSearch.DataAddinfo[] getData = null;
            try
            {
                wSvc = new Mem_WsWorkerLaborSearch.WsWorkerLaborSearch();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer1 + "/WebSvc/Worker/Labor/WsWorkerLaborSearch.svc";
                wSvc.Timeout = 1000;

                //DECLARE TYPE OF TCODE 
                string pTcode = "ComboBox";

                //SELECT
                reCode = wSvc.sLaborAddInfo(AppInfo.SsSiteCd, pTcode, CcodeCmb.SelectedValue.ToString(), out getData, out reMsg);

                if (reCode == "Y")
                {
                    if (getData != null && getData.Length > 0)
                    {
                        dgv4_addInfo.Rows.Clear();
                        for (int i = 0; i < getData.Length; i++)
                        {
                            dgv4_addInfo.Rows.Add();
                            //VISBLE 
                            dgv4_addInfo.Rows[i].Cells["dgv4_TCODE_NM"].Value = getData[i].TCODE_NM.ToString();

                            //INVISIBLE
                            dgv4_addInfo.Rows[i].Cells["dgv4_TCODE"].Value = getData[i].TCODE.ToString();
                            dgv4_addInfo.Rows[i].Cells["dgv4_TTYPE_SCD"].Value = getData[i].TTYPE_SCD.ToString();

                            set_Grideview4Combo1(i, "dgv4_CONTENT", dgv4_addInfo.Rows[i].Cells["dgv4_TCODE"].Value.ToString());


                        }

                    }
                    else
                    {
                        dgv4_addInfo.Rows.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmLaborSearch.cs  (Function)::SetDataBind_gridView4  (Detail)::reMsg=[" + reMsg + "]", "Error");
                logs.SaveLog("[error]  (page)::FrmLaborSearch.cs  (Function)::SetDataBind_gridView4  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (wSvc != null)
                    wSvc.Dispose();
            }
        }

        private void CcodeCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_CcodeCmb == "")
            {

                SetDataBind_gridView1();
                SetDataBind_gridView2();
                SetDataBind_gridView3();
                SetDataBind_gridView4();
            }
            else
            {
                for (int i = sd.Count - 1; i >= 0; i--)
                {
                    string[] strArr = sd[i].str.Split('$');

                    //CcodeCmb.SelectedValue.ToStrig() => 현재 페이지의 값을 지우는 것이 아니라 넘어갈 페이지의 값을 지우게 됨. 
                    if (strArr[0] == _CcodeCmb)
                    {
                        sd.RemoveAt(i);
                    }
                }

                //** DGV1 PART START 
                for (int i = 0; i < dgv1_addInfo.RowCount; i++)
                {
                    if (dgv1_addInfo.Rows[i].Cells["dgv1_CONTENT"].Value == null)
                        dgv1_addInfo.Rows[i].Cells["dgv1_CONTENT"].Value = "0";
                    else
                        dgv1_addInfo.Rows[i].Cells["dgv1_CONTENT"].Value.ToString();


                    sdRow.str = _CcodeCmb + "$" + dgv1_addInfo.Rows[i].Cells["dgv1_TTYPE_SCD"].Value.ToString() + "$" + dgv1_addInfo.Rows[i].Cells["dgv1_TCODE"].Value.ToString()
                        + "$" + dgv1_addInfo.Rows[i].Cells["dgv1_TCODE_NM"].Value.ToString() + "$" + dgv1_addInfo.Rows[i].Cells["dgv1_CONTENT"].Value.ToString();

                    sd.Add(sdRow);

                }


                //** DGV2 PART START 
                for (int i = 0; i < dgv2_addInfo.RowCount; i++)
                {
                    if (dgv2_addInfo.Rows[i].Cells["dgv2_CONTENT"].Value == null)
                        dgv2_addInfo.Rows[i].Cells["dgv2_CONTENT"].Value = "";
                    else
                        dgv2_addInfo.Rows[i].Cells["dgv2_CONTENT"].Value.ToString();


                    sdRow.str = _CcodeCmb + "$" + dgv2_addInfo.Rows[i].Cells["dgv2_TTYPE_SCD"].Value.ToString() + "$" + dgv2_addInfo.Rows[i].Cells["dgv2_TCODE"].Value.ToString()
                        + "$" + dgv2_addInfo.Rows[i].Cells["dgv2_TCODE_NM"].Value.ToString() + "$" + dgv2_addInfo.Rows[i].Cells["dgv2_CONTENT"].Value.ToString();

                    sd.Add(sdRow);

                }

                //** DGV3 PART START 
                for (int i = 0; i < dgv3_addInfo.RowCount; i++)
                {
                    if (dgv3_addInfo.Rows[i].Cells["dgv3_CONTENT"].Value == null)
                        dgv3_addInfo.Rows[i].Cells["dgv3_CONTENT"].Value = "";
                    else
                        dgv3_addInfo.Rows[i].Cells["dgv3_CONTENT"].Value.ToString();


                    sdRow.str = _CcodeCmb + "$" + dgv3_addInfo.Rows[i].Cells["dgv3_TTYPE_SCD"].Value.ToString() + "$" + dgv3_addInfo.Rows[i].Cells["dgv3_TCODE"].Value.ToString()
                        + "$" + dgv3_addInfo.Rows[i].Cells["dgv3_TCODE_NM"].Value.ToString() + "$" + dgv3_addInfo.Rows[i].Cells["dgv3_CONTENT"].Value.ToString();

                    sd.Add(sdRow);

                }

                //** DGV4 PART START 
                for (int i = 0; i < dgv4_addInfo.RowCount; i++)
                {
                    if (dgv4_addInfo.Rows[i].Cells["dgv4_CONTENT"].Value == null)
                        dgv4_addInfo.Rows[i].Cells["dgv4_CONTENT"].Value = "";
                    else
                        dgv4_addInfo.Rows[i].Cells["dgv4_CONTENT"].Value.ToString();


                    sdRow.str = _CcodeCmb + "$" + dgv4_addInfo.Rows[i].Cells["dgv4_TTYPE_SCD"].Value.ToString() + "$" + dgv4_addInfo.Rows[i].Cells["dgv4_TCODE"].Value.ToString()
                        + "$" + dgv4_addInfo.Rows[i].Cells["dgv4_TCODE_NM"].Value.ToString() + "$" + dgv4_addInfo.Rows[i].Cells["dgv4_CONTENT"].Value.ToString();

                    sd.Add(sdRow);

                }

                //CALL DGV FIRTS FOR SETTING DGV CELLS VALUE  
                SetDataBind_gridView1();
                SetDataBind_gridView2();
                SetDataBind_gridView3();
                SetDataBind_gridView4();



                for (int i = 0; i < sd.Count; i++)
                {
                    string[] strArr = sd[i].str.Split('$');

                    if (strArr[0] == CcodeCmb.SelectedValue.ToString())
                    {
                        if (strArr[1] == "Check")
                        {
                            for (int r = 0; r < dgv1_addInfo.RowCount; r++)
                            {
                                if (dgv1_addInfo.Rows[r].Cells["dgv1_TCODE"].Value.ToString() == strArr[2])
                                {
                                    dgv1_addInfo.Rows[r].Cells["dgv1_TTYPE_SCD"].Value = strArr[1];
                                    dgv1_addInfo.Rows[r].Cells["dgv1_TCODE"].Value = strArr[2];
                                    dgv1_addInfo.Rows[r].Cells["dgv1_TCODE_NM"].Value = strArr[3];
                                    dgv1_addInfo.Rows[r].Cells["dgv1_CONTENT"].Value = strArr[4];
                                }
                            }
                        }

                        if (strArr[1] == "Text")
                        {
                            for (int r = 0; r < dgv2_addInfo.RowCount; r++)
                            {
                                if (dgv2_addInfo.Rows[r].Cells["dgv2_TCODE"].Value.ToString() == strArr[2])
                                {
                                    dgv2_addInfo.Rows[r].Cells["dgv2_TTYPE_SCD"].Value = strArr[1];
                                    dgv2_addInfo.Rows[r].Cells["dgv2_TCODE"].Value = strArr[2];
                                    dgv2_addInfo.Rows[r].Cells["dgv2_TCODE_NM"].Value = strArr[3];
                                    dgv2_addInfo.Rows[r].Cells["dgv2_CONTENT"].Value = strArr[4];
                                }
                            }

                        }

                        if (strArr[1] == "Calender")
                        {
                            for (int r = 0; r < dgv3_addInfo.RowCount; r++)
                            {
                                if (dgv3_addInfo.Rows[r].Cells["dgv3_TCODE"].Value.ToString() == strArr[2])
                                {
                                    dgv3_addInfo.Rows[r].Cells["dgv3_TTYPE_SCD"].Value = strArr[1];
                                    dgv3_addInfo.Rows[r].Cells["dgv3_TCODE"].Value = strArr[2];
                                    dgv3_addInfo.Rows[r].Cells["dgv3_TCODE_NM"].Value = strArr[3];
                                    dgv3_addInfo.Rows[r].Cells["dgv3_CONTENT"].Value = strArr[4];
                                }
                            }
                        }

                        if (strArr[1] == "Combobox")
                        {
                            for (int r = 0; r < dgv4_addInfo.RowCount; r++)
                            {
                                if (dgv4_addInfo.Rows[r].Cells["dgv4_TCODE"].Value.ToString() == strArr[2])
                                {
                                    dgv4_addInfo.Rows[r].Cells["dgv4_TTYPE_SCD"].Value = strArr[1];
                                    dgv4_addInfo.Rows[r].Cells["dgv4_TCODE"].Value = strArr[2];
                                    dgv4_addInfo.Rows[r].Cells["dgv4_TCODE_NM"].Value = strArr[3];
                                    dgv4_addInfo.Rows[r].Cells["dgv4_CONTENT"].Value = strArr[4];
                                }
                            }
                        }

                    }
                }
            }


            _CcodeCmb = CcodeCmb.SelectedValue.ToString();

        }


        struct searchData
        {
            public string str;  // 열화상 데이터            
        }

    }
}




