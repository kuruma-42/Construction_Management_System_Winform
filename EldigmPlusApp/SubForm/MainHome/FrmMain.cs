﻿using EldigmPlusApp.Config;
using Framework.IO;
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

namespace EldigmPlusApp.SubForm.MainHome
{
    public partial class FrmMain : Form
    {
        LogUtil logs = null;
        ResourceManager lngRM = null;

        string appPath = "";

        string firstMenuCd;
        string firstMenuTag;
        string firstMenuNm;

        public FrmMain()
        {
            InitializeComponent();

            try
            {
                appPath = Application.StartupPath + "\\";
                GetIni();

                // Sets the UI culture
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(AppInfo.SsLanguage);
                this.AutoScaleMode = AutoScaleMode.Dpi;

                logs = new LogUtil();
                lngRM = new ResourceManager("EldigmPlusApp.strLanguage", typeof(FrmMain).Assembly);

                //Home 메뉴
                homeToolStripMenuItem.Text = lngRM.GetString("lngHome");
                programInfoToolStripMenuItem.Text = lngRM.GetString("lngProgram") + " " + lngRM.GetString("lngInfo");
                exitToolStripMenuItem.Text = lngRM.GetString("lngEnd");

                //ultraDockManager1.ControlPanes[0].Text = lngRM.GetString("lngMenuItems");
                ultraDockManager1.ControlPanes[0].Text = "";
                ultraDockManager1.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.Office2007;

                panelMainLeft.BackColor = Color.WhiteSmoke;

                splitContainer1.BackColor = Color.WhiteSmoke;
                splitContainer1.Visible = true;

                this.IsMdiContainer = false;

                this.menuStripTop.Paint += new PaintEventHandler(this.paint_MenuStrip);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmMain.cs  (Function)::FrmMain  (Detail)::" + "\r\n" + ex.ToString());
            }
        }

        #region __ menuStripTop paint_MenuStrip
        private void paint_MenuStrip(object sender, PaintEventArgs e)
        {
            Class.UI.PanelPaint pp = new Class.UI.PanelPaint();
            pp.paint_MenuStripSteelBlue1(sender, e);
        }
        #endregion

        private void GetIni()
        {
            try
            {
                string filePath = appPath + "Config\\";

                IniFile ini = new IniFile(filePath + "EldigmPlusApp.ini");

                AppInfo.SsDbNm = "";

                AppInfo.SsLanguage = ini.IniReadValue("INFO", "Language");
                AppInfo.SsMemcoCd = ini.IniReadValue("INFO", "MemcoCd");
                AppInfo.SsSiteCd = ini.IniReadValue("INFO", "SiteCd");
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmMain.cs  (Function)::GetIni  (Detail)::" + "\r\n" + ex.ToString());
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                GetDbNm();
                SetTopMenu();
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmMain.cs  (Function)::FrmMain_Load  (Detail)::" + "\r\n" + ex.ToString());
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GetDbNm()
        {
            WsMHome.WsMainHomeClient wsMHome = null;
            
            string reCode = "";
            string reMsg = "";
            string reData = "";
            try
            {
                wsMHome = new WsMHome.WsMainHomeClient();
                string wsUrl = "http://localhost:49501/WebSvc/MainHome/WsMainHome.svc";
                wsMHome.Endpoint.Address = new System.ServiceModel.EndpointAddress(wsUrl);
                wsMHome.Open();

                reCode = wsMHome.sDbNm(AppInfo.SsMemcoCd, out reData, out reMsg);
                
                if (reCode == "Y")
                {
                    if (!string.IsNullOrEmpty(reData))
                        AppInfo.SsDbNm = reData;
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmMain  (Function)::GetDbNm  (Detail)::reMsg=[" + reMsg + "]");
                logs.SaveLog("[error]  (page)::FrmMain  (Function)::GetDbNm  (Detail)::" + "\r\n" + ex.ToString());
            }
            finally
            {
                if (wsMHome != null)
                    wsMHome.Close();
            }
        }

        // ** 상단 메뉴 **
        private void SetTopMenu()
        {
            WsMHome.WsMainHomeClient wsMHome = null;
            string reCode = "";
            string reMsg = "";
            WsMHome.DataTopMenu[] getData = null;
            try
            {
                wsMHome = new WsMHome.WsMainHomeClient();
                string wsUrl = "http://localhost:49501/WebSvc/MainHome/WsMainHome.svc";
                wsMHome.Endpoint.Address = new System.ServiceModel.EndpointAddress(wsUrl);
                wsMHome.Open();

                reCode = wsMHome.sSiteMenu(AppInfo.SsDbNm, AppInfo.SsSiteCd, out getData, out reMsg);

                ToolStripMenuItem TopMenu;
                if (reCode == "Y")
                {
                    if (getData != null && getData.Length > 0)
                    {
                        for (int i = 0; i < getData.Length; i++)
                        {
                            string topMenuCd = getData[i].TOP_MENU_CD.ToString();
                            string topMenuNm = getData[i].TOP_MENU_NM.ToString();

                            TopMenu = new ToolStripMenuItem(topMenuNm);

                            TopMenu.Click += new EventHandler(topMenu_click);    //상단 Main 메뉴 클릭시 좌측 메뉴 셋팅
                            TopMenu.Name = topMenuCd;
                            TopMenu.Tag = topMenuNm;

                            menuStripTop.Items.AddRange(new ToolStripItem[] { TopMenu });

                            if (i == 0)
                            {
                                SetLeftMenu(topMenuCd);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmMain  (Function)::SetTopMenu  (Detail)::reMsg=[" + reMsg + "]");
                logs.SaveLog("[error]  (page)::FrmMain  (Function)::SetTopMenu  (Detail)::" + "\r\n" + ex.ToString());
            }
            finally
            {
                if (wsMHome != null)
                    wsMHome.Close();
            }
        }

        // ** 상단 메뉴 클릭 좌측 메뉴 셋팅 **
        private void topMenu_click(object sender, EventArgs e)
        {
            string menuCd = "";
            try
            {
                ToolStripMenuItem TopMenu = sender as ToolStripMenuItem;

                menuCd = TopMenu.Name;
                SetLeftMenu(menuCd);
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmMain  (Function)::topMenu_click  (Detail)::" + "\r\n" + ex.ToString());
            }
        }

        // ** 좌측 메뉴 **
        private void SetLeftMenu(string pTopMenuCd)
        {
            WsMHome.WsMainHomeClient wsMHome = null;
            string reCode = "";
            string reMsg = "";
            WsMHome.DataSubMenu1[] getData1 = null;
            try
            {
                wsMHome = new WsMHome.WsMainHomeClient();
                string wsUrl = "http://localhost:49501/WebSvc/MainHome/WsMainHome.svc";
                wsMHome.Endpoint.Address = new System.ServiceModel.EndpointAddress(wsUrl);

                reCode = wsMHome.sSiteSubMenu1(AppInfo.SsDbNm, AppInfo.SsSiteCd, pTopMenuCd, out getData1, out reMsg);

                if (reCode == "Y")
                {
                    if (getData1 != null && getData1.Length > 0)
                    {
                        for (int i = 0; i < getData1.Length; i++)
                        {
                            string subMenuCd = getData1[i].SUB_MENU_CD.ToString();
                            string subMenuNm = getData1[i].SUB_MENU_NM.ToString();

                            if (!ultraExplorerBarLeft.Groups.Exists(subMenuCd))
                                ultraExplorerBarLeft.Groups.Add(subMenuCd, subMenuNm);

                            if (i == 0)
                                ultraExplorerBarLeft.Groups[i].Expanded = true;
                            else
                                ultraExplorerBarLeft.Groups[i].Expanded = false;



                            WsMHome.DataSubMenu2[] getData2 = null;

                            reCode = wsMHome.sSiteSubMenu2(AppInfo.SsDbNm, AppInfo.SsSiteCd, pTopMenuCd, subMenuCd, out getData2, out reMsg);

                            if (reCode == "Y")
                            {
                                if (getData2 != null && getData2.Length > 0)
                                {
                                    for (int k = 0; k < getData2.Length; k++)
                                    {
                                        string menuCd = getData2[k].MENU_CD.ToString();
                                        string topMenuCd = getData2[k].TOP_MENU_CD.ToString();
                                        string subMenuCd2 = getData2[k].SUB_MENU_CD.ToString();
                                        string menuNm = getData2[k].MENU_NM.ToString();
                                        string memo = getData2[k].MEMO.ToString();
                                        string menuPath = getData2[k].MENU_PATH.ToString();

                                        string menuTag = menuCd + "@" + topMenuCd + "@" + subMenuCd2 + "@" + menuNm + "@" + memo + "@" + menuPath;

                                        if (!ultraExplorerBarLeft.Groups[i].Items.Exists(menuCd))
                                        {
                                            ultraExplorerBarLeft.Groups[i].Items.Add(menuCd, menuNm);
                                            ultraExplorerBarLeft.Groups[i].Items[k].Tag = menuTag;
                                        }

                                        // ** 로딩 후 좌측 울트라 메뉴 첫번째 페이지 열기 **
                                        if (i == 0 && k == 0)
                                        {
                                            firstMenuCd = menuCd;
                                            firstMenuTag = menuTag;
                                            firstMenuNm = menuNm;

                                            StartFirstMenuForm(firstMenuCd, firstMenuTag, firstMenuNm);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmMain  (Function)::SetLeftMenu  (Detail)::pTopMenuCd=[" + pTopMenuCd + "]");
                logs.SaveLog("[error]  (page)::FrmMain  (Function)::SetLeftMenu  (Detail)::reMsg1=[" + reMsg + "]");
                logs.SaveLog("[error]  (page)::FrmMain  (Function)::SetLeftMenu  (Detail)::" + "\r\n" + ex.ToString());
            }
            finally
            {
                if (wsMHome != null)
                    wsMHome.Close();
            }
        }

        private void StartFirstMenuForm(string pMenuCd, string pMenuTag, string pFrmText)
        {
            try
            {
                string[] menuTagArr = pMenuTag.Split('@');
                string formAddress = menuTagArr[5];

                System.Reflection.Assembly cuasm = System.Reflection.Assembly.GetExecutingAssembly();

                foreach (Form f in this.MdiChildren)
                {
                    if (f.GetType().ToString() == formAddress)
                    {
                        for (int k = 0; k < f.Controls.Count; k++)
                        {
                            f.Controls[k].Dispose();
                        }

                        f.Close();
                    }
                }

                splitContainer1.Visible = false;
                this.IsMdiContainer = true;

                Form frm = (Form)cuasm.CreateInstance(string.Format("{0}", formAddress));
                frm.MdiParent = this;
                frm.Tag = pMenuTag;
                frm.Text = pFrmText;
                frm.Dock = DockStyle.Fill;
                frm.Show();
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmMain  (Function)::StartFirstMenuForm  (Detail)::pMenuCd=[" + pMenuCd + "], pMenuTag=[" + pMenuTag + "], pFrmText=[" + pFrmText + "]");
                logs.SaveLog("[error]  (page)::FrmMain  (Function)::StartFirstMenuForm  (Detail)::" + "\r\n" + ex.ToString());
            }
        }

        private void ultraExplorerBarLeft_ItemClick(object sender, Infragistics.Win.UltraWinExplorerBar.ItemEventArgs e)
        {
            try
            {
                string menuCd = e.Item.Key;
                string menuTag = e.Item.Tag.ToString();
                string[] menuTagArr = menuTag.Split('@');
                string formAddress = menuTagArr[5];

                System.Reflection.Assembly cuasm = System.Reflection.Assembly.GetExecutingAssembly();

                foreach (Form f in this.MdiChildren)
                {
                    if (f.GetType().ToString() == formAddress)
                    {
                        for (int k = 0; k < f.Controls.Count; k++)
                        {
                            f.Controls[k].Dispose();
                        }

                        f.Close();
                    }
                }

                splitContainer1.Visible = false;
                this.IsMdiContainer = true;

                Form frm = (Form)cuasm.CreateInstance(string.Format("{0}", formAddress));
                frm.MdiParent = this;
                frm.Tag = menuTag;
                frm.Text = e.Item.Text;
                frm.Dock = DockStyle.Fill;
                frm.Show();
            }
            catch (Exception ex)
            {
                logs.SaveLog("[error]  (page)::FrmMain  (Function)::ultraExplorerBarLeft_ItemClick  (Detail)::" + "\r\n" + ex.ToString());
            }
        }

        private void ultraTabbedMdiManager1_TabSelected(object sender, Infragistics.Win.UltraWinTabbedMdi.MdiTabEventArgs e)
        {
            try
            {
                //    string formName = e.Tab.Form.Name.ToString();

                //    Form frm = e.Tab.Form;

                //    if (formName == "FrmWorker") //  || formName == "FrmWorkerScan"
                //    {
                //        ((FrmWorker)(frm)).tabSelected();
                //    }
                //    else if (formName == "FrmWorkerScan")
                //    {
                //        ((FrmWorkerScan)(frm)).tabSelected();
                //    }
                //    else if (formName == "FrmWorkerSimple") // 2016.08.22 - 조건 추가
                //    {
                //        ((FrmWorkerSimple)(frm)).tabSelected();
                //    }
                //    else if (formName == "FrmWorkerSimpleP") // 2019.03.20 - 조건 추가
                //    {
                //        ((FrmWorkerSimpleP)(frm)).tabSelected();
                //    }
                //    else if (formName == "FrmWorkerSimpleD")
                //    {
                //        ((FrmWorkerSimpleD)(frm)).tabSelected();
                //    }
                //    else if (formName == "FrmWorkerHDC")
                //    {
                //        ((FrmWorkerHDC)(frm)).tabSelected();
                //    }
                //    else if (formName == "FrmWorkerSimpleH_I")
                //    {
                //        ((FrmWorkerSimpleH_I)(frm)).tabSelected();
                //    }
                //    else if (formName == "FrmWorkerSAMHO")
                //    {
                //        ((FrmWorkerSAMHO)(frm)).tabSelected();
                //    }
                //    else if (formName == "FrmWorkerBOOYOUNG")
                //    {
                //        ((FrmWorkerBOOYOUNG)(frm)).tabSelected();
                //    }
            }
            catch
            {
            }
        }



    }
}
