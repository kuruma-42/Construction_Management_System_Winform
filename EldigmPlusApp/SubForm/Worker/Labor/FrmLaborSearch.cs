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

                dataGridView1.Columns["dgv1_CHK"].HeaderText = "선택";
                dataGridView1.Columns["dgv1_LAB_NO"].HeaderText = "근로자 번호";
                dataGridView1.Columns["dgv1_CO_NM"].HeaderText = "업체 이름";
                dataGridView1.Columns["dgv1_LAB_NM"].HeaderText = "근로자 이름";                                              
                dataGridView1.Columns["dgv1_TEAM_NM"].HeaderText = "팀 이름";
                dataGridView1.Columns["dgv1_JOB_NM"].HeaderText = "직종";
                dataGridView1.Columns["dgv1_BIRTH_DATE"].HeaderText = "생년월일";
                dataGridView1.Columns["dgv1_MOBILE_NO"].HeaderText = "휴대폰 번호";
                dataGridView1.Columns["dgv1_USER_NO"].HeaderText = "사용자 번호";
                dataGridView1.Columns["dgv1_AUTH_CD"].HeaderText = "권한";




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
                SetDataBind_LabSearchCondition();
                SetDataBind_TeamCmb();
                SetDataBind_BlockCmb();
                SetDataBind_ConstCmb();
                SetDataBind_CompanyCmb();
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

                reCode = wSvc.sLaborBlockList(AppInfo.SsSiteCd, AppInfo.SsLabAuth, AppInfo.SsBlockCcd, out getData, out reMsg);
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

                reCode = wSvc.sLaborConstList(AppInfo.SsSiteCd, AppInfo.SsLabAuth, AppInfo.SsConstCd, out getData, out reMsg);
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
                        setCmb.Bind(searchCondition11.comboBox3);
                        searchCondition11.comboBox3.SelectedValue = "0";
                    }
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmLaborSearch.cs  (Function)::SetDataBind_CmbMember  (Detail):: " + "\r\n" + ex.ToString());
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

                reCode = wSvc.sLaborTeamList(AppInfo.SsSiteCd, AppInfo.SsLabAuth, AppInfo.SsTeamCd, AppInfo.SsCoCd, out getData, out reMsg);
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
      
        

        private void SetDataBind_gridView1()
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
                reCode = wSvc.sLaborSearch(AppInfo.SsSiteCd, pBlockCcd , pConstCcd, pCodCd, pTeamCd, pSearchCondition, pSearchTxt, out getData, out reMsg); //AppInfo.SsSiteCD

                if (reCode == "Y")
                {
                    if (getData != null && getData.Length > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int i = 0; i < getData.Length; i++)
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[i].Cells["dgv1_LAB_NO"].Value = getData[i].LAB_NO.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_CO_NM"].Value = getData[i].CO_NM.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_LAB_NM"].Value = getData[i].LAB_NM.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_JOB_NM"].Value = getData[i].JOB_NM.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_TEAM_NM"].Value = getData[i].TEAM_NM.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_BIRTH_DATE"].Value = getData[i].BIRTH_DATE.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_MOBILE_NO"].Value = getData[i].MOBILE_NO.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_USER_NO"].Value = getData[i].USER_NO.ToString();
                            dataGridView1.Rows[i].Cells["dgv1_AUTH_CD"].Value = getData[i].AUTH_CD.ToString();                          


                            //dataGridView1.Rows[i].Cells["dgv1_FACE_PHOTO"].Value = getData[i].FACE_PHOTO.ToString();      
                            //dataGridView1.Rows[i].Cells["dgv1_BLOCK_CCD"].Value = getData[i].BLOCK_CCD.ToString();
                            //dataGridView1.Rows[i].Cells["dgv1_LAB_STS"].Value = getData[i].LAB_STS.ToString();
                            
                        }

                        SetRowNumber(dataGridView1);
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

        private void btnSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                btnSearch_Click(null, null);
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
                logs.SaveLog("[error]  (page)::FrmSysCode.cs  (Function)::dataGridView1_CellBeginEdit  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        bool chkUseAll = false;
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                string columnNm = dataGridView1.Columns[e.ColumnIndex].Name;
                if (columnNm == "dgv1_CHK" )
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (chkUseAll)
                            dataGridView1.Rows[i].Cells[columnNm].Value = "0";
                        else
                            dataGridView1.Rows[i].Cells[columnNm].Value = "1";
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
            frm.Show();
        }
    }
}