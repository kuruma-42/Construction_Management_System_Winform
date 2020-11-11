namespace EldigmPlusApp.SubForm.Worker.Labor
{
    partial class FrmLaborSearch
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
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblAddInfo = new System.Windows.Forms.Label();
            this.comboSearch = new System.Windows.Forms.ComboBox();
            this.calSearch = new System.Windows.Forms.DateTimePicker();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.chkSearch = new System.Windows.Forms.CheckBox();
            this.TcodeCmb = new System.Windows.Forms.ComboBox();
            this.LabInfoTypeCmb = new System.Windows.Forms.ComboBox();
            this.CcodeCmb = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.searchCondition11 = new EldigmPlusApp_UserControl.SearchCondition1();
            this.btnSearch = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.dgv1_CHK = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgv1_LAB_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_CO_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_LAB_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_JOB_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_TEAM_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_BIRTH_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_MOBILE_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_USER_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_AUTH_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_BLOCK_CCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_CO_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_TEAM_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_JOB_CCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.button1);
            this.splitContainer3.Panel1.Controls.Add(this.btnReset);
            this.splitContainer3.Panel1.Controls.Add(this.lblAddInfo);
            this.splitContainer3.Panel1.Controls.Add(this.comboSearch);
            this.splitContainer3.Panel1.Controls.Add(this.calSearch);
            this.splitContainer3.Panel1.Controls.Add(this.txtSearch);
            this.splitContainer3.Panel1.Controls.Add(this.chkSearch);
            this.splitContainer3.Panel1.Controls.Add(this.TcodeCmb);
            this.splitContainer3.Panel1.Controls.Add(this.LabInfoTypeCmb);
            this.splitContainer3.Panel1.Controls.Add(this.CcodeCmb);
            this.splitContainer3.Panel1.Controls.Add(this.btnAdd);
            this.splitContainer3.Panel1.Controls.Add(this.searchCondition11);
            this.splitContainer3.Panel1.Controls.Add(this.btnSearch);
            this.splitContainer3.Size = new System.Drawing.Size(1037, 134);
            this.splitContainer3.SplitterDistance = 817;
            this.splitContainer3.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(542, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(44, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(668, 40);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(120, 20);
            this.btnReset.TabIndex = 17;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblAddInfo
            // 
            this.lblAddInfo.AutoSize = true;
            this.lblAddInfo.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblAddInfo.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAddInfo.Location = new System.Drawing.Point(18, 84);
            this.lblAddInfo.Name = "lblAddInfo";
            this.lblAddInfo.Size = new System.Drawing.Size(54, 12);
            this.lblAddInfo.TabIndex = 16;
            this.lblAddInfo.Text = "AddInfo";
            // 
            // comboSearch
            // 
            this.comboSearch.FormattingEnabled = true;
            this.comboSearch.Location = new System.Drawing.Point(399, 103);
            this.comboSearch.Name = "comboSearch";
            this.comboSearch.Size = new System.Drawing.Size(121, 20);
            this.comboSearch.TabIndex = 15;
            this.comboSearch.Visible = false;
            // 
            // calSearch
            // 
            this.calSearch.Enabled = false;
            this.calSearch.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.calSearch.Location = new System.Drawing.Point(399, 103);
            this.calSearch.Name = "calSearch";
            this.calSearch.Size = new System.Drawing.Size(121, 21);
            this.calSearch.TabIndex = 14;
            this.calSearch.Visible = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Enabled = false;
            this.txtSearch.Location = new System.Drawing.Point(399, 102);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(121, 21);
            this.txtSearch.TabIndex = 13;
            this.txtSearch.Visible = false;
            // 
            // chkSearch
            // 
            this.chkSearch.AutoSize = true;
            this.chkSearch.Enabled = false;
            this.chkSearch.Location = new System.Drawing.Point(399, 106);
            this.chkSearch.Name = "chkSearch";
            this.chkSearch.Size = new System.Drawing.Size(15, 14);
            this.chkSearch.TabIndex = 12;
            this.chkSearch.UseVisualStyleBackColor = true;
            this.chkSearch.Visible = false;
            // 
            // TcodeCmb
            // 
            this.TcodeCmb.FormattingEnabled = true;
            this.TcodeCmb.Location = new System.Drawing.Point(272, 102);
            this.TcodeCmb.Name = "TcodeCmb";
            this.TcodeCmb.Size = new System.Drawing.Size(121, 20);
            this.TcodeCmb.TabIndex = 11;
            this.TcodeCmb.SelectedIndexChanged += new System.EventHandler(this.TcodeCmb_SelectedIndexChanged);
            // 
            // LabInfoTypeCmb
            // 
            this.LabInfoTypeCmb.FormattingEnabled = true;
            this.LabInfoTypeCmb.Location = new System.Drawing.Point(145, 102);
            this.LabInfoTypeCmb.Name = "LabInfoTypeCmb";
            this.LabInfoTypeCmb.Size = new System.Drawing.Size(121, 20);
            this.LabInfoTypeCmb.TabIndex = 10;
            this.LabInfoTypeCmb.SelectedIndexChanged += new System.EventHandler(this.LabInfoTypeCmb_SelectedIndexChanged);
            // 
            // CcodeCmb
            // 
            this.CcodeCmb.FormattingEnabled = true;
            this.CcodeCmb.Location = new System.Drawing.Point(18, 102);
            this.CcodeCmb.Name = "CcodeCmb";
            this.CcodeCmb.Size = new System.Drawing.Size(121, 20);
            this.CcodeCmb.TabIndex = 9;
            this.CcodeCmb.SelectedIndexChanged += new System.EventHandler(this.CcodeCmb_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(668, 14);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 20);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // searchCondition11
            // 
            this.searchCondition11.Location = new System.Drawing.Point(0, 0);
            this.searchCondition11.Name = "searchCondition11";
            this.searchCondition11.Size = new System.Drawing.Size(536, 80);
            this.searchCondition11.TabIndex = 8;
            this.searchCondition11.cmb3_SelectedIndexChanged += new System.EventHandler(this.searchCondition11_cmb3_SelectedIndexChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSearch.Location = new System.Drawing.Point(542, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 20);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.btnSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnSearch_KeyPress);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DataGridView1);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(1037, 601);
            this.splitContainer1.SplitterDistance = 134;
            this.splitContainer1.TabIndex = 2;
            // 
            // DataGridView1
            // 
            this.DataGridView1.AllowUserToAddRows = false;
            this.DataGridView1.AllowUserToDeleteRows = false;
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv1_CHK,
            this.dgv1_LAB_NO,
            this.dgv1_CO_NM,
            this.dgv1_LAB_NM,
            this.dgv1_JOB_NM,
            this.dgv1_TEAM_NM,
            this.dgv1_BIRTH_DATE,
            this.dgv1_MOBILE_NO,
            this.dgv1_USER_NO,
            this.dgv1_AUTH_CD,
            this.dgv1_BLOCK_CCD,
            this.dgv1_CO_CD,
            this.dgv1_TEAM_CD,
            this.dgv1_JOB_CCD});
            this.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridView1.Location = new System.Drawing.Point(0, 25);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.RowTemplate.Height = 23;
            this.DataGridView1.Size = new System.Drawing.Size(1037, 438);
            this.DataGridView1.TabIndex = 4;
            this.DataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.DataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.DataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            // 
            // dgv1_CHK
            // 
            this.dgv1_CHK.FalseValue = "0";
            this.dgv1_CHK.HeaderText = "CHK";
            this.dgv1_CHK.IndeterminateValue = "0";
            this.dgv1_CHK.MinimumWidth = 60;
            this.dgv1_CHK.Name = "dgv1_CHK";
            this.dgv1_CHK.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv1_CHK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgv1_CHK.TrueValue = "1";
            // 
            // dgv1_LAB_NO
            // 
            this.dgv1_LAB_NO.HeaderText = "LAB_NO";
            this.dgv1_LAB_NO.MinimumWidth = 100;
            this.dgv1_LAB_NO.Name = "dgv1_LAB_NO";
            this.dgv1_LAB_NO.ReadOnly = true;
            // 
            // dgv1_CO_NM
            // 
            this.dgv1_CO_NM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgv1_CO_NM.HeaderText = "CO_NM";
            this.dgv1_CO_NM.MinimumWidth = 150;
            this.dgv1_CO_NM.Name = "dgv1_CO_NM";
            // 
            // dgv1_LAB_NM
            // 
            this.dgv1_LAB_NM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgv1_LAB_NM.HeaderText = "LAB_NM";
            this.dgv1_LAB_NM.MinimumWidth = 150;
            this.dgv1_LAB_NM.Name = "dgv1_LAB_NM";
            this.dgv1_LAB_NM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv1_LAB_NM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgv1_JOB_NM
            // 
            this.dgv1_JOB_NM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgv1_JOB_NM.HeaderText = "JOB_NM";
            this.dgv1_JOB_NM.MinimumWidth = 100;
            this.dgv1_JOB_NM.Name = "dgv1_JOB_NM";
            // 
            // dgv1_TEAM_NM
            // 
            this.dgv1_TEAM_NM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgv1_TEAM_NM.HeaderText = "TEAM_NM";
            this.dgv1_TEAM_NM.MinimumWidth = 150;
            this.dgv1_TEAM_NM.Name = "dgv1_TEAM_NM";
            // 
            // dgv1_BIRTH_DATE
            // 
            this.dgv1_BIRTH_DATE.HeaderText = "BIRTH_DATE";
            this.dgv1_BIRTH_DATE.MinimumWidth = 150;
            this.dgv1_BIRTH_DATE.Name = "dgv1_BIRTH_DATE";
            this.dgv1_BIRTH_DATE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv1_BIRTH_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgv1_BIRTH_DATE.Width = 150;
            // 
            // dgv1_MOBILE_NO
            // 
            this.dgv1_MOBILE_NO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgv1_MOBILE_NO.HeaderText = "MOBILE_NO";
            this.dgv1_MOBILE_NO.MinimumWidth = 100;
            this.dgv1_MOBILE_NO.Name = "dgv1_MOBILE_NO";
            // 
            // dgv1_USER_NO
            // 
            this.dgv1_USER_NO.HeaderText = "USER_NO";
            this.dgv1_USER_NO.MinimumWidth = 100;
            this.dgv1_USER_NO.Name = "dgv1_USER_NO";
            // 
            // dgv1_AUTH_CD
            // 
            this.dgv1_AUTH_CD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgv1_AUTH_CD.HeaderText = "AUTH_CD";
            this.dgv1_AUTH_CD.MinimumWidth = 100;
            this.dgv1_AUTH_CD.Name = "dgv1_AUTH_CD";
            // 
            // dgv1_BLOCK_CCD
            // 
            this.dgv1_BLOCK_CCD.HeaderText = "BLOCK_CCD";
            this.dgv1_BLOCK_CCD.Name = "dgv1_BLOCK_CCD";
            this.dgv1_BLOCK_CCD.Visible = false;
            // 
            // dgv1_CO_CD
            // 
            this.dgv1_CO_CD.HeaderText = "CO_CD";
            this.dgv1_CO_CD.Name = "dgv1_CO_CD";
            this.dgv1_CO_CD.Visible = false;
            // 
            // dgv1_TEAM_CD
            // 
            this.dgv1_TEAM_CD.HeaderText = "TEAM_CD";
            this.dgv1_TEAM_CD.Name = "dgv1_TEAM_CD";
            this.dgv1_TEAM_CD.Visible = false;
            // 
            // dgv1_JOB_CCD
            // 
            this.dgv1_JOB_CCD.HeaderText = "JOB_CCD";
            this.dgv1_JOB_CCD.Name = "dgv1_JOB_CCD";
            this.dgv1_JOB_CCD.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1037, 25);
            this.panel1.TabIndex = 0;
            // 
            // FrmLaborSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 601);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmLaborSearch";
            this.Text = "FrmLaborSearch";
            this.Load += new System.EventHandler(this.FrmLaborSearch_Load);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSearch;
        private EldigmPlusApp_UserControl.SearchCondition1 searchCondition11;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView DataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgv1_CHK;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_LAB_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_CO_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_LAB_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_JOB_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_TEAM_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_BIRTH_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_MOBILE_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_USER_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_AUTH_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_BLOCK_CCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_CO_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_TEAM_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_JOB_CCD;
        private System.Windows.Forms.ComboBox TcodeCmb;
        private System.Windows.Forms.ComboBox LabInfoTypeCmb;
        private System.Windows.Forms.ComboBox CcodeCmb;
        private System.Windows.Forms.CheckBox chkSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DateTimePicker calSearch;
        private System.Windows.Forms.ComboBox comboSearch;
        private System.Windows.Forms.Label lblAddInfo;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button button1;
    }
}