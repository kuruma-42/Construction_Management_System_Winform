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

namespace EldigmPlusApp.SubForm.Worker.InOut
{
    public partial class FrmInOutTime : Form
    {
        LogUtil logs = null;
        ResourceManager wRM = null;
        ResourceManager msgRM = null;

        Form parentFrm;
        string inOutType;
        int rowIdx;

        public FrmInOutTime(string inOutType, int rowIdx, string inOutTime, Form frm)
        {
            // Sets the UI culture
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(AppInfo.SsLanguage);
            this.AutoScaleMode = AutoScaleMode.Dpi;

            InitializeComponent();

            try
            {
                logs = new LogUtil();
                wRM = new ResourceManager("EldigmPlusApp.GlobalLanguage.word_Language", typeof(FrmInOutTime).Assembly);
                msgRM = new ResourceManager("EldigmPlusApp.GlobalLanguage.msg_Language", typeof(FrmInOutTime).Assembly);

                btnApply.Text = wRM.GetString("wApply");
                btnClose.Text = wRM.GetString("wClose");

                parentFrm = frm;

                this.BackColor = Color.White;
                this.panel1.BackColor = Color.White;

                btnApply.BackColor = Color.LightSteelBlue;
                btnClose.BackColor = Color.LightSteelBlue;

                this.inOutType = inOutType;
                this.rowIdx = rowIdx;

                if (inOutType == "dgv1_IN_DT")
                {
                    this.Text = "IN";
                    dtpDate.Enabled = false;
                }
                else if (inOutType == "dgv1_OUT_DT")
                {
                    this.Text = "OUT";
                    dtpDate.Enabled = true;
                }
                else
                {
                    this.Text = "EVENT";
                }

                if (inOutTime != "")
                {
                    dtpDate.Value = Convert.ToDateTime(inOutTime);
                    dtpTime.Value = Convert.ToDateTime(inOutTime);
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmInOutTime  (Function)::FrmInOutTime  (Detail):: " + "\r\n" + ex.ToString());
            }
        }
        
        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                string inOutDate = dtpDate.Value.ToString("yyyy-MM-dd");
                string inOutTime = dtpTime.Value.ToString("HH:mm:ss");
                DateTime dt = Convert.ToDateTime(inOutDate + " " + inOutTime);

                if (parentFrm.Name == "FrmInOut")
                {
                    if (inOutType == "dgv1_IN_DT")
                    {
                        ((FrmInOut)(parentFrm)).dataGridView1_InOutTimeModify(inOutType, rowIdx, dt);

                    }
                    else if (inOutType == "dgv1_OUT_DT")
                    {
                        ((FrmInOut)(parentFrm)).dataGridView1_InOutTimeModify(inOutType, rowIdx, dt);
                    }
                }
                


                //((FrmInOut)(parentFrm)).dataGridView1_InOutTimeModify(inOutType, rowIdx, dt);

                // 2015.07.28 - 수정 시작(조건 if (inOutType == "EVENT_TIME"), else if (inOutType == "EVENT_TIME2") 추가)
                //if (inOutType == "EVENT_TIME")
                //{
                //    ((FrmMealStatus)(parentFrm)).dataGridView2_EventTimeModify(rowIdx, dt);
                //}

                //if (inOutType == "EVENT_TIME2")
                //{
                //    ((FrmMealStatus)(parentFrm)).dataGridView3_EventTimeModify(rowIdx, dt);
                //}
                //else if (inOutType == "MEET_EVENT_TIME" || inOutType == "MEET2_EVENT_TIME")
                //{
                //    if (inOutType == "MEET_EVENT_TIME")
                //        ((FrmMeet)(parentFrm)).dataGridView1_EventTimeModify(rowIdx, dt);
                //    else
                //        ((FrmMeet2)(parentFrm)).dataGridView1_EventTimeModify(rowIdx, dt);
                //}
                //else
                //{
                //    // 2017.04.04 - 수정(if문 추가)
                //    if (parentFrm.Name == "FrmBioInOut")
                //    {
                //        if (rowIdx == -1)
                //            ((FrmBioInOut)(parentFrm)).dataGridView1_InOutTimeAllModify(inOutType, dt);
                //        else
                //            ((FrmBioInOut)(parentFrm)).dataGridView1_InOutTimeModify(inOutType, rowIdx, dt);
                //    }
                //    else if (parentFrm.Name == "FrmInOut")
                //    {
                //        if (rowIdx == -1)
                //            ((FrmInOut)(parentFrm)).dataGridView1_InOutTimeAllModify(inOutType, dt);
                //        else
                //            ((FrmInOut)(parentFrm)).dataGridView1_InOutTimeModify(inOutType, rowIdx, dt);
                //    }
                //}
                // 2015.07.28 - 수정 끝
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmInOutTime  (Function)::btnApply_Click  (Detail):: " + "\r\n" + ex.ToString());
            }
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
