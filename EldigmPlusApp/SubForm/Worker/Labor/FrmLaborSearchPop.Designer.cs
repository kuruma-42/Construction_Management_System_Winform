namespace EldigmPlusApp.SubForm.Worker.Labor
{
    partial class FrmLaborSearchPop
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLaborSearchPop));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblHead = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.LabDetail = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.CcodeCmb = new System.Windows.Forms.ComboBox();
            this.dgv3_addInfo = new System.Windows.Forms.DataGridView();
            this.dgv3_TCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv3_TTYPE_SCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv3_TCODE_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv3_CONTENT = new Infragistics.Win.UltraDataGridView.UltraCalendarComboColumn(this.components);
            this.dgv4_addInfo = new System.Windows.Forms.DataGridView();
            this.dgv4_TCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv4_TTYPE_SCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv4_TCODE_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv4_CONTENT = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgv2_addInfo = new System.Windows.Forms.DataGridView();
            this.dgv2_TCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv2_TTYPE_SCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv2_TCODE_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv2_CONTENT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.dgv1_addInfo = new System.Windows.Forms.DataGridView();
            this.dgv1_TCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_TTYPE_SCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_TCODE_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_CONTENT = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblBlock = new System.Windows.Forms.Label();
            this.BlockCmb = new System.Windows.Forms.ComboBox();
            this.btnFile = new System.Windows.Forms.Button();
            this.btnCamera = new System.Windows.Forms.Button();
            this.lblTeam = new System.Windows.Forms.Label();
            this.lblJob = new System.Windows.Forms.Label();
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblCom = new System.Windows.Forms.Label();
            this.TeamCmb = new System.Windows.Forms.ComboBox();
            this.JobCmb = new System.Windows.Forms.ComboBox();
            this.Birth_DatePicker = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PhoneTxt = new System.Windows.Forms.TextBox();
            this.NameKorTxt = new System.Windows.Forms.TextBox();
            this.ComCmb = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.LabDetail.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv3_addInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv4_addInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2_addInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1_addInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.LabDetail);
            this.splitContainer1.Size = new System.Drawing.Size(579, 961);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblHead);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(579, 25);
            this.panel1.TabIndex = 0;
            // 
            // lblHead
            // 
            this.lblHead.AutoSize = true;
            this.lblHead.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblHead.Location = new System.Drawing.Point(6, 6);
            this.lblHead.Name = "lblHead";
            this.lblHead.Size = new System.Drawing.Size(94, 12);
            this.lblHead.TabIndex = 0;
            this.lblHead.Text = "** 근로자 추가";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(513, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(62, 20);
            this.btnAdd.TabIndex = 35;
            this.btnAdd.Text = "추가";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click_pop);
            // 
            // LabDetail
            // 
            this.LabDetail.Controls.Add(this.tabPage1);
            this.LabDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabDetail.Location = new System.Drawing.Point(0, 0);
            this.LabDetail.Name = "LabDetail";
            this.LabDetail.SelectedIndex = 0;
            this.LabDetail.Size = new System.Drawing.Size(579, 932);
            this.LabDetail.TabIndex = 4;
            this.LabDetail.Tag = "";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.CcodeCmb);
            this.tabPage1.Controls.Add(this.dgv3_addInfo);
            this.tabPage1.Controls.Add(this.dgv4_addInfo);
            this.tabPage1.Controls.Add(this.dgv2_addInfo);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.dgv1_addInfo);
            this.tabPage1.Controls.Add(this.lblBlock);
            this.tabPage1.Controls.Add(this.BlockCmb);
            this.tabPage1.Controls.Add(this.btnFile);
            this.tabPage1.Controls.Add(this.btnCamera);
            this.tabPage1.Controls.Add(this.lblTeam);
            this.tabPage1.Controls.Add(this.lblJob);
            this.tabPage1.Controls.Add(this.lblBirthDate);
            this.tabPage1.Controls.Add(this.lblPhone);
            this.tabPage1.Controls.Add(this.lblName);
            this.tabPage1.Controls.Add(this.lblCom);
            this.tabPage1.Controls.Add(this.TeamCmb);
            this.tabPage1.Controls.Add(this.JobCmb);
            this.tabPage1.Controls.Add(this.Birth_DatePicker);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.PhoneTxt);
            this.tabPage1.Controls.Add(this.NameKorTxt);
            this.tabPage1.Controls.Add(this.ComCmb);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(571, 906);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "인원정보";
            // 
            // CcodeCmb
            // 
            this.CcodeCmb.FormattingEnabled = true;
            this.CcodeCmb.Location = new System.Drawing.Point(16, 247);
            this.CcodeCmb.Name = "CcodeCmb";
            this.CcodeCmb.Size = new System.Drawing.Size(210, 20);
            this.CcodeCmb.TabIndex = 60;
            this.CcodeCmb.SelectedIndexChanged += new System.EventHandler(this.CcodeCmb_SelectedIndexChanged);
            // 
            // dgv3_addInfo
            // 
            this.dgv3_addInfo.AllowUserToAddRows = false;
            this.dgv3_addInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv3_addInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv3_TCODE,
            this.dgv3_TTYPE_SCD,
            this.dgv3_TCODE_NM,
            this.dgv3_CONTENT});
            this.dgv3_addInfo.Location = new System.Drawing.Point(16, 527);
            this.dgv3_addInfo.Name = "dgv3_addInfo";
            this.dgv3_addInfo.RowTemplate.Height = 23;
            this.dgv3_addInfo.Size = new System.Drawing.Size(267, 225);
            this.dgv3_addInfo.TabIndex = 59;
            // 
            // dgv3_TCODE
            // 
            this.dgv3_TCODE.HeaderText = "TCODE";
            this.dgv3_TCODE.Name = "dgv3_TCODE";
            this.dgv3_TCODE.ReadOnly = true;
            this.dgv3_TCODE.Visible = false;
            // 
            // dgv3_TTYPE_SCD
            // 
            this.dgv3_TTYPE_SCD.HeaderText = "TTYPE_SCD";
            this.dgv3_TTYPE_SCD.Name = "dgv3_TTYPE_SCD";
            this.dgv3_TTYPE_SCD.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv3_TTYPE_SCD.Visible = false;
            // 
            // dgv3_TCODE_NM
            // 
            this.dgv3_TCODE_NM.HeaderText = "TCODE_NM";
            this.dgv3_TCODE_NM.Name = "dgv3_TCODE_NM";
            this.dgv3_TCODE_NM.ReadOnly = true;
            // 
            // dgv3_CONTENT
            // 
            this.dgv3_CONTENT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgv3_CONTENT.DefaultNewRowValue = ((object)(resources.GetObject("dgv3_CONTENT.DefaultNewRowValue")));
            this.dgv3_CONTENT.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Default;
            this.dgv3_CONTENT.HeaderText = "CONTENT";
            this.dgv3_CONTENT.Name = "dgv3_CONTENT";
            this.dgv3_CONTENT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv3_CONTENT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dgv4_addInfo
            // 
            this.dgv4_addInfo.AllowUserToAddRows = false;
            this.dgv4_addInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv4_addInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv4_TCODE,
            this.dgv4_TTYPE_SCD,
            this.dgv4_TCODE_NM,
            this.dgv4_CONTENT});
            this.dgv4_addInfo.Location = new System.Drawing.Point(288, 527);
            this.dgv4_addInfo.Name = "dgv4_addInfo";
            this.dgv4_addInfo.RowTemplate.Height = 23;
            this.dgv4_addInfo.Size = new System.Drawing.Size(267, 225);
            this.dgv4_addInfo.TabIndex = 58;
            // 
            // dgv4_TCODE
            // 
            this.dgv4_TCODE.HeaderText = "TCODE";
            this.dgv4_TCODE.Name = "dgv4_TCODE";
            this.dgv4_TCODE.ReadOnly = true;
            this.dgv4_TCODE.Visible = false;
            // 
            // dgv4_TTYPE_SCD
            // 
            this.dgv4_TTYPE_SCD.HeaderText = "TTYPE_SCD";
            this.dgv4_TTYPE_SCD.Name = "dgv4_TTYPE_SCD";
            this.dgv4_TTYPE_SCD.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv4_TTYPE_SCD.Visible = false;
            // 
            // dgv4_TCODE_NM
            // 
            this.dgv4_TCODE_NM.HeaderText = "TCODE_NM";
            this.dgv4_TCODE_NM.Name = "dgv4_TCODE_NM";
            this.dgv4_TCODE_NM.ReadOnly = true;
            // 
            // dgv4_CONTENT
            // 
            this.dgv4_CONTENT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgv4_CONTENT.HeaderText = "CONTENT";
            this.dgv4_CONTENT.Name = "dgv4_CONTENT";
            this.dgv4_CONTENT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv4_CONTENT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dgv2_addInfo
            // 
            this.dgv2_addInfo.AllowUserToAddRows = false;
            this.dgv2_addInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv2_addInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv2_TCODE,
            this.dgv2_TTYPE_SCD,
            this.dgv2_TCODE_NM,
            this.dgv2_CONTENT});
            this.dgv2_addInfo.Location = new System.Drawing.Point(288, 273);
            this.dgv2_addInfo.Name = "dgv2_addInfo";
            this.dgv2_addInfo.RowTemplate.Height = 23;
            this.dgv2_addInfo.Size = new System.Drawing.Size(267, 225);
            this.dgv2_addInfo.TabIndex = 57;
            // 
            // dgv2_TCODE
            // 
            this.dgv2_TCODE.HeaderText = "TCODE";
            this.dgv2_TCODE.Name = "dgv2_TCODE";
            this.dgv2_TCODE.ReadOnly = true;
            this.dgv2_TCODE.Visible = false;
            // 
            // dgv2_TTYPE_SCD
            // 
            this.dgv2_TTYPE_SCD.HeaderText = "TTYPE_SCD";
            this.dgv2_TTYPE_SCD.Name = "dgv2_TTYPE_SCD";
            this.dgv2_TTYPE_SCD.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv2_TTYPE_SCD.Visible = false;
            // 
            // dgv2_TCODE_NM
            // 
            this.dgv2_TCODE_NM.HeaderText = "TCODE_NM";
            this.dgv2_TCODE_NM.Name = "dgv2_TCODE_NM";
            this.dgv2_TCODE_NM.ReadOnly = true;
            // 
            // dgv2_CONTENT
            // 
            this.dgv2_CONTENT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgv2_CONTENT.HeaderText = "CONTENT";
            this.dgv2_CONTENT.MinimumWidth = 120;
            this.dgv2_CONTENT.Name = "dgv2_CONTENT";
            this.dgv2_CONTENT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(14, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 56;
            this.label4.Text = "추가정보";
            // 
            // dgv1_addInfo
            // 
            this.dgv1_addInfo.AllowUserToAddRows = false;
            this.dgv1_addInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1_addInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv1_TCODE,
            this.dgv1_TTYPE_SCD,
            this.dgv1_TCODE_NM,
            this.dgv1_CONTENT});
            this.dgv1_addInfo.Location = new System.Drawing.Point(15, 273);
            this.dgv1_addInfo.Name = "dgv1_addInfo";
            this.dgv1_addInfo.RowTemplate.Height = 23;
            this.dgv1_addInfo.Size = new System.Drawing.Size(267, 225);
            this.dgv1_addInfo.TabIndex = 52;
            // 
            // dgv1_TCODE
            // 
            this.dgv1_TCODE.HeaderText = "TCODE";
            this.dgv1_TCODE.Name = "dgv1_TCODE";
            this.dgv1_TCODE.ReadOnly = true;
            this.dgv1_TCODE.Visible = false;
            // 
            // dgv1_TTYPE_SCD
            // 
            this.dgv1_TTYPE_SCD.HeaderText = "TTYPE_SCD";
            this.dgv1_TTYPE_SCD.Name = "dgv1_TTYPE_SCD";
            this.dgv1_TTYPE_SCD.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv1_TTYPE_SCD.Visible = false;
            // 
            // dgv1_TCODE_NM
            // 
            this.dgv1_TCODE_NM.HeaderText = "TCODE_NM";
            this.dgv1_TCODE_NM.Name = "dgv1_TCODE_NM";
            this.dgv1_TCODE_NM.ReadOnly = true;
            this.dgv1_TCODE_NM.Width = 150;
            // 
            // dgv1_CONTENT
            // 
            this.dgv1_CONTENT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgv1_CONTENT.FalseValue = "0";
            this.dgv1_CONTENT.HeaderText = "CONTENT";
            this.dgv1_CONTENT.IndeterminateValue = "0";
            this.dgv1_CONTENT.MinimumWidth = 70;
            this.dgv1_CONTENT.Name = "dgv1_CONTENT";
            this.dgv1_CONTENT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv1_CONTENT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgv1_CONTENT.TrueValue = "1";
            // 
            // lblBlock
            // 
            this.lblBlock.Location = new System.Drawing.Point(20, 9);
            this.lblBlock.Name = "lblBlock";
            this.lblBlock.Size = new System.Drawing.Size(41, 12);
            this.lblBlock.TabIndex = 0;
            this.lblBlock.Text = "* 구역";
            // 
            // BlockCmb
            // 
            this.BlockCmb.FormattingEnabled = true;
            this.BlockCmb.Location = new System.Drawing.Point(20, 24);
            this.BlockCmb.Name = "BlockCmb";
            this.BlockCmb.Size = new System.Drawing.Size(162, 20);
            this.BlockCmb.TabIndex = 36;
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(488, 194);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(67, 23);
            this.btnFile.TabIndex = 34;
            this.btnFile.Text = "파일";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // btnCamera
            // 
            this.btnCamera.Location = new System.Drawing.Point(395, 194);
            this.btnCamera.Name = "btnCamera";
            this.btnCamera.Size = new System.Drawing.Size(67, 23);
            this.btnCamera.TabIndex = 33;
            this.btnCamera.Text = "카메라";
            this.btnCamera.UseVisualStyleBackColor = true;
            // 
            // lblTeam
            // 
            this.lblTeam.AutoSize = true;
            this.lblTeam.Location = new System.Drawing.Point(22, 53);
            this.lblTeam.Name = "lblTeam";
            this.lblTeam.Size = new System.Drawing.Size(27, 12);
            this.lblTeam.TabIndex = 32;
            this.lblTeam.Text = "* 팀";
            // 
            // lblJob
            // 
            this.lblJob.AutoSize = true;
            this.lblJob.Location = new System.Drawing.Point(195, 53);
            this.lblJob.Name = "lblJob";
            this.lblJob.Size = new System.Drawing.Size(39, 12);
            this.lblJob.TabIndex = 30;
            this.lblJob.Text = "* 직종";
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.AutoSize = true;
            this.lblBirthDate.Location = new System.Drawing.Point(195, 97);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(63, 12);
            this.lblBirthDate.TabIndex = 24;
            this.lblBirthDate.Text = "* 생년월일";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(18, 141);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(51, 12);
            this.lblPhone.TabIndex = 23;
            this.lblPhone.Text = "* 연락처";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(22, 97);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(39, 12);
            this.lblName.TabIndex = 21;
            this.lblName.Text = "* 이름";
            // 
            // lblCom
            // 
            this.lblCom.AutoSize = true;
            this.lblCom.Location = new System.Drawing.Point(195, 9);
            this.lblCom.Name = "lblCom";
            this.lblCom.Size = new System.Drawing.Size(39, 12);
            this.lblCom.TabIndex = 19;
            this.lblCom.Text = "* 업체";
            // 
            // TeamCmb
            // 
            this.TeamCmb.FormattingEnabled = true;
            this.TeamCmb.Location = new System.Drawing.Point(20, 68);
            this.TeamCmb.Name = "TeamCmb";
            this.TeamCmb.Size = new System.Drawing.Size(162, 20);
            this.TeamCmb.TabIndex = 18;
            // 
            // JobCmb
            // 
            this.JobCmb.FormattingEnabled = true;
            this.JobCmb.Location = new System.Drawing.Point(197, 68);
            this.JobCmb.Name = "JobCmb";
            this.JobCmb.Size = new System.Drawing.Size(162, 20);
            this.JobCmb.TabIndex = 17;
            // 
            // Birth_DatePicker
            // 
            this.Birth_DatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Birth_DatePicker.Location = new System.Drawing.Point(197, 112);
            this.Birth_DatePicker.Name = "Birth_DatePicker";
            this.Birth_DatePicker.Size = new System.Drawing.Size(160, 21);
            this.Birth_DatePicker.TabIndex = 15;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(395, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(160, 179);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // PhoneTxt
            // 
            this.PhoneTxt.Location = new System.Drawing.Point(20, 156);
            this.PhoneTxt.Name = "PhoneTxt";
            this.PhoneTxt.Size = new System.Drawing.Size(160, 21);
            this.PhoneTxt.TabIndex = 4;
            // 
            // NameKorTxt
            // 
            this.NameKorTxt.Location = new System.Drawing.Point(20, 112);
            this.NameKorTxt.Name = "NameKorTxt";
            this.NameKorTxt.Size = new System.Drawing.Size(160, 21);
            this.NameKorTxt.TabIndex = 2;
            // 
            // ComCmb
            // 
            this.ComCmb.FormattingEnabled = true;
            this.ComCmb.Location = new System.Drawing.Point(197, 24);
            this.ComCmb.Name = "ComCmb";
            this.ComCmb.Size = new System.Drawing.Size(162, 20);
            this.ComCmb.TabIndex = 0;
            // 
            // FrmLaborSearchPop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 961);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmLaborSearchPop";
            this.Text = "FrmLaborSearchPop";
            this.Load += new System.EventHandler(this.FrmLaborSearchPop_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.LabDetail.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv3_addInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv4_addInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2_addInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1_addInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl LabDetail;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.Button btnCamera;
        private System.Windows.Forms.Label lblTeam;
        private System.Windows.Forms.Label lblJob;
        private System.Windows.Forms.Label lblBirthDate;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblCom;
        private System.Windows.Forms.ComboBox TeamCmb;
        private System.Windows.Forms.ComboBox JobCmb;
        private System.Windows.Forms.DateTimePicker Birth_DatePicker;
        private System.Windows.Forms.TextBox PhoneTxt;
        private System.Windows.Forms.TextBox NameKorTxt;
        private System.Windows.Forms.ComboBox ComCmb;
        private System.Windows.Forms.Button btnAdd;
        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblBlock;
        private System.Windows.Forms.ComboBox BlockCmb;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.DataGridView dgv1_addInfo;
        private System.Windows.Forms.Label lblHead;
        public System.Windows.Forms.DataGridView dgv2_addInfo;
        public System.Windows.Forms.DataGridView dgv4_addInfo;
        public System.Windows.Forms.DataGridView dgv3_addInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_TCODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_TTYPE_SCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_TCODE_NM;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgv1_CONTENT;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv3_TCODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv3_TTYPE_SCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv3_TCODE_NM;
        private Infragistics.Win.UltraDataGridView.UltraCalendarComboColumn dgv3_CONTENT;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv4_TCODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv4_TTYPE_SCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv4_TCODE_NM;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgv4_CONTENT;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv2_TCODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv2_TTYPE_SCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv2_TCODE_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv2_CONTENT;
        private System.Windows.Forms.ComboBox CcodeCmb;
    }
}