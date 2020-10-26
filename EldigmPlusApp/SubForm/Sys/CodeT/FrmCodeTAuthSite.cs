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

namespace EldigmPlusApp.SubForm.Sys.CodeT
{
    public partial class FrmCodeTAuthSite : Form
    {
        LogUtil logs = null;
        ResourceManager wRM = null;
        ResourceManager msgRM = null;

        string _codeGrp = "";
        string _code = "";

        public FrmCodeTAuthSite()
        {
            // Sets the UI culture //
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(AppInfo.SsLanguage);
            this.AutoScaleMode = AutoScaleMode.Dpi;

            InitializeComponent();

            try
            {
                logs = new LogUtil();
                wRM = new ResourceManager("EldigmPlusApp.GlobalLanguage.word_Language", typeof(FrmCodeTAuthSite).Assembly);
                msgRM = new ResourceManager("EldigmPlusApp.GlobalLanguage.msg_Language", typeof(FrmCodeTAuthSite).Assembly);

                btnSave.Text = "저장";
                dataGridView1.Columns["dgv1_CHK"].HeaderText = wRM.GetString("wSelect");
                dataGridView1.Columns["dgv1_TCODE"].HeaderText = wRM.GetString("wTcode");
                dataGridView1.Columns["dgv1_AUTH_CD"].HeaderText = wRM.GetString("wAuthority") + wRM.GetString("wCode");
                dataGridView1.Columns["dgv1_TCODE_NM"].HeaderText = wRM.GetString("wTcode") + wRM.GetString("wName");
                dataGridView1.Columns["dgv1_VIEW_FLAG"].HeaderText = wRM.GetString("wView");
                dataGridView1.Columns["dgv1_NEW_FLAG"].HeaderText = wRM.GetString("wAdd");
                dataGridView1.Columns["dgv1_MODIFY_FLAG"].HeaderText = wRM.GetString("wModify");

                Control.CheckForIllegalCrossThreadCalls = false;

                this.BackColor = Color.WhiteSmoke;

                splitContainer1.Panel1.BackColor = Color.LightSteelBlue;

                Class.Common.DatagrideViewStyleSet dvSet = new Class.Common.DatagrideViewStyleSet();
                dvSet.setStyle(dataGridView1, false, false);

                lblName.BackColor = Color.FromArgb(204, 219, 243);
                this.panel2.Paint += new PaintEventHandler(this.paint_Purple1);

            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmCodeTAuthSite.cs  (Function)::FrmCodeTAuthSite  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }



        #region __ panel2 paint_Purple1
        private void paint_Purple1(object sender, PaintEventArgs e)
        {
            Class.UI.PanelPaint pp = new Class.UI.PanelPaint();
            pp.paint_PanelPurple1(sender, e);
        }
        #endregion

        private void FrmCodeTAuthSite_Load(object sender, EventArgs e)
        {
            try
            {
                SetDataBind_treeView1();
                SetDataBind_CmbSite();
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmCodeTAuthSite.cs  (Function)::FrmCodeTAuthSite_Load  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }


        private void SetDataBind_treeView1()
        {
            treeView1.Nodes.Clear();

            M_WsCodeTMainDB.WsCodeTMainDB wSvc = null;
            string reCode = "";
            string reMsg = "";
            M_WsCodeTMainDB.DataSysCode[] getData1 = null;
            M_WsCodeTMainDB.DataCodeTAuth[] getData2 = null;
            try
            {
                wSvc = new M_WsCodeTMainDB.WsCodeTMainDB();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/CodeT/WsCodeTMainDB.svc";
                wSvc.Timeout = 1000;

                ImageList myimageList = new ImageList();
                myimageList.Images.Add(Image.FromFile(@"Image\treeicon1.png"));

                treeView1.ImageList = myimageList;
                treeView1.ImageIndex = 0;

                reCode = wSvc.sSysCode(out getData1, out reMsg);
                if (reCode == "Y")
                {
                    if (getData1 != null && getData1.Length > 0)
                    {
                        for (int j = 0; j < getData1.Length; j++)
                        {
                            string sCode_val = getData1[j].SCODE.ToString();
                            string sCodeNm_val = getData1[j].SCODE_NM.ToString();

                            TreeNode root = new TreeNode();
                            root.Tag = "1-" + sCode_val;
                            root.Text = sCodeNm_val;

                            reCode = wSvc.sCodeAuthTTreeView(sCode_val, AppInfo.SsSiteCd, out getData2, out reMsg);
                            if (reCode == "Y")
                            {
                                if (getData2 != null && getData2.Length > 0)
                                {
                                    for (int k = 0; k < getData2.Length; k++)
                                    {
                                        string tcode_val = getData2[k].TCODE.ToString();
                                        string tcodeNm_val = getData2[k].TCODE_NM.ToString();
                                        TreeNode node2 = new TreeNode();
                                        node2.Tag = "2-" + tcode_val;
                                        node2.Text = tcodeNm_val;

                                        root.Nodes.Add(node2);
                                    }
                                }
                            }

                            treeView1.Nodes.Add(root);

                            if (treeView1.Nodes.Count > 0)
                                treeView1.SelectedNode = treeView1.GetNodeAt(0, 0);

                        }

                        treeView1.ExpandAll();
                    }
                }
            }

            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmCodeTAuthSite.cs  (Function)::SetDataBind_treeView1  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
            finally
            {
                if (wSvc != null)
                    wSvc.Dispose();
            }
        }


        private void SetDataBind_CmbSite()
        {
            M_WsCCodeGrp.WsComnCodeGrp wSvc = null;
            string reCode = "";
            string reMsg = "";
            M_WsCCodeGrp.DataCodeAuthSiteMemberDB[] getData = null;
            try
            {
                wSvc = new M_WsCCodeGrp.WsComnCodeGrp();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/ComnCode/WsComnCodeGrp.svc";
                wSvc.Timeout = 1000;

                reCode = wSvc.sCodeAuthSiteMemberDB(AppInfo.SsDbNm, out getData, out reMsg);
                if (reCode == "Y")
                {
                    if (getData != null && getData.Length > 0)
                    {
                        Class.Common.ComboBoxItemSet setCmb = null;

                        setCmb = new Class.Common.ComboBoxItemSet();
                        setCmb.AddColumn();

                        for (int i = 0; i < getData.Length; i++)
                        {
                            setCmb.AddRow(getData[i].AUTH_NM.ToString(), getData[i].AUTH_CD.ToString());
                        }

                        setCmb.Bind(cmbSite);
                    }
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmCodeTAuthSite.cs  (Function)::SetDataBind_CmbSite  (Detail):: " + "\r\n" + ex.ToString());
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (treeView1.SelectedNode == null)
                {
                    return;
                }

                string eNodeTag = "";
                eNodeTag = e.Node.Tag.ToString();
                lblName.Text = "** " + e.Node.Text;

                string[] codeArr = eNodeTag.Split('-');

                _codeGrp = codeArr[0].ToString();
                _code = codeArr[1].ToString();


                SetDataBind_gridView1(_codeGrp, _code);

            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmCodeTAuthSite.cs  (Function)::treeView1_AfterSelect  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        private void SetDataBind_gridView1(string codeGrp, string code_val)
        {
            M_WsCodeTMainDB.WsCodeTMainDB wSvc = null;
            string reCode = "";
            string reMsg = "";

            M_WsCodeTMainDB.DataCodeTAuthSelect[] getData1 = null;

            try
            {
                wSvc = new M_WsCodeTMainDB.WsCodeTMainDB();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/CodeT/WsCodeTMainDB.svc";
                wSvc.Timeout = 1000;

                if (codeGrp == "1")
                {

                    //SELECT WHEN USER CLICK TTYPTE (EX : TEXT, CHECK BOX ..)
                    reCode = wSvc.sCodeTAuthTtype(code_val, AppInfo.SsSiteCd, cmbSite.SelectedValue.ToString(),out getData1, out reMsg);

                    if (reCode == "Y")
                    {
                        if (getData1 != null && getData1.Length > 0)
                        {
                            dataGridView1.Rows.Clear();
                            for (int i = 0; i < getData1.Length; i++)
                            {
                                dataGridView1.Rows.Add();
                                dataGridView1.Rows[i].Cells["dgv1_TCODE"].Value = getData1[i].TCODE.ToString();
                                dataGridView1.Rows[i].Cells["dgv1_AUTH_CD"].Value = getData1[i].AUTH_CD.ToString();
                                dataGridView1.Rows[i].Cells["dgv1_TCODE_NM"].Value = getData1[i].TCODE_NM.ToString();
                                dataGridView1.Rows[i].Cells["dgv1_VIEW_FLAG"].Value = getData1[i].VIEW_FLAG.ToString();
                                dataGridView1.Rows[i].Cells["dgv1_NEW_FLAG"].Value = getData1[i].NEW_FLAG.ToString();
                                dataGridView1.Rows[i].Cells["dgv1_MODIFY_FLAG"].Value = getData1[i].MODIFY_FLAG.ToString();
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

                else if (codeGrp == "2")
                {
                    //SELECT WHEN USER CLICK TCODE 
                    reCode = wSvc.sCodeTAuth(code_val, AppInfo.SsSiteCd, cmbSite.SelectedValue.ToString(), out getData1, out reMsg);


                    if (reCode == "Y")
                    {
                        if (getData1 != null && getData1.Length > 0)
                        {
                            dataGridView1.Rows.Clear();
                            for (int i = 0; i < getData1.Length; i++)
                            {
                                dataGridView1.Rows.Add();
                                dataGridView1.Rows[i].Cells["dgv1_TCODE"].Value = getData1[i].TCODE.ToString();
                                dataGridView1.Rows[i].Cells["dgv1_AUTH_CD"].Value = getData1[i].AUTH_CD.ToString();
                                dataGridView1.Rows[i].Cells["dgv1_TCODE_NM"].Value = getData1[i].TCODE_NM.ToString();
                                dataGridView1.Rows[i].Cells["dgv1_VIEW_FLAG"].Value = getData1[i].VIEW_FLAG.ToString();
                                dataGridView1.Rows[i].Cells["dgv1_NEW_FLAG"].Value = getData1[i].NEW_FLAG.ToString();
                                dataGridView1.Rows[i].Cells["dgv1_MODIFY_FLAG"].Value = getData1[i].MODIFY_FLAG.ToString();
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

            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmCodeTAuthSite.cs  (Function)::SetDataBind_gridView1  (Detail)::codeGrp=[" + codeGrp + "], code_val=[" + code_val + "]", "Error");
                logs.SaveLog("[error]  (page)::FrmCodeTAuthSite.cs  (Function)::SetDataBind_gridView1  (Detail)::reMsg=[" + reMsg + "]", "Error");
                logs.SaveLog("[error]  (page)::FrmCodeTAuthSite.cs  (Function)::SetDataBind_gridView1  (Detail):: " + "\r\n" + ex.ToString(), "Error");
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
                logs.SaveLog("[error]  (page)::FrmCodeTAuthSite.cs  (Function)::dataGridView1_CellBeginEdit  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        bool chkUseAll = false;
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                string columnNm = dataGridView1.Columns[e.ColumnIndex].Name;
                if (columnNm == "dgv1_CHK" || columnNm == "dgv1_LIST_FLAG" || columnNm == "dgv1_REQUIRED_FLAG" || columnNm == "dgv1_NUMERIC_FLAG")
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (chkUseAll)
                            dataGridView1.Rows[i].Cells[columnNm].Value = "0";
                        else
                            dataGridView1.Rows[i].Cells[columnNm].Value = "1";

                        if (columnNm == "dgv1_LIST_FLAG" || columnNm == "dgv1_REQUIRED_FLAG" || columnNm == "dgv1_NUMERIC_FLAG")
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
                logs.SaveLog("[error]  (page)::FrmCodeTAuthSite.cs  (Function)::dataGridView1_ColumnHeaderMouseClick  (Detail):: " + "\r\n" + ex.ToString(), "Error");
            }
        }

        private void NoSelectGrideView(DataGridView dgv)
        {
            dgv.ClearSelection();
            dgv.CurrentCell = null;
        }

        private void SetRowNumber(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
                row.HeaderCell.Value = String.Format("{0}", row.Index + 1);

            dgv.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            M_WsCodeTMainDB.WsCodeTMainDB wSvc = null;
            string reCode = "";
            string reMsg = "";
            string reData = "";

            try
            {
                wSvc = new M_WsCodeTMainDB.WsCodeTMainDB();
                wSvc.Url = "http://" + AppInfo.SsWsvcServer2 + "/WebSvc/Sys/CodeT/WsCodeTMainDB.svc";
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
                            string pTcode = dataGridView1.Rows[i].Cells["dgv1_TCODE"].Value.ToString();
                            string pAuthCd = dataGridView1.Rows[i].Cells["dgv1_AUTH_CD"].Value.ToString();
                            string pTcodeNm = dataGridView1.Rows[i].Cells["dgv1_TCODE_NM"].Value.ToString();
                            string pViewFlag = dataGridView1.Rows[i].Cells["dgv1_VIEW_FLAG"].Value.ToString();
                            string pNeweFlag = dataGridView1.Rows[i].Cells["dgv1_NEW_FLAG"].Value.ToString();
                            string pModifyFlag = dataGridView1.Rows[i].Cells["dgv1_MODIFY_FLAG"].Value.ToString();
                            string pSiteCd = AppInfo.SsSiteCd;

                            reCode = wSvc.mCodeTAuth(pTcode, pSiteCd, pAuthCd, pViewFlag, pNeweFlag, pModifyFlag, out reMsg, out reData);

                            if (reCode == "Y" && reData != "")
                                reCnt += Convert.ToInt16(reData);
                        }
                    }
                }
                if (reCnt > 0)
                    MessageBox.Show(wRM.GetString("wSave") + " " + wRM.GetString("wSuccess") + " : " + reCnt.ToString());
                else
                    MessageBox.Show(wRM.GetString("wSave") + " " + wRM.GetString("wFail"));

                SetDataBind_gridView1(_codeGrp, _code);


            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmCodeTAuthSite.cs  (Function)::btnSave_Click  (Detail):: " + "\r\n" + ex.ToString(), "Error");

            }
            finally
            {
                if (wSvc != null)
                    wSvc.Dispose();
            }
        }

        private void cmbSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDataBind_gridView1(_codeGrp, _code);
        }
    }
}