namespace EldigmPlusApp.SubForm.Sys.CompanyTeam
{
    partial class FrmTeam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTeam));
            this.dgv1_SITE_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_END_DATE = new Infragistics.Win.UltraDataGridView.UltraCalendarComboColumn(this.components);
            this.dgv1_BIZ_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_OWNER_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_TEL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_ADDR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_USING_CNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_SORT_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_MEMO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dgv2_CO_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv2_BIZ_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv2_CONST_CCD = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgv2_CO_TYPE_SCD = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgv2_OWNER_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv2_TEL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv2_ADDR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv2_SORT_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv2_MEMO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv2_BTNADD = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dgv1_START_DATE = new Infragistics.Win.UltraDataGridView.UltraCalendarComboColumn(this.components);
            this.dgv1_CO_TYPE_SCD = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbCom = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dgv1_CHK = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgv1_CO_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_CO_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_USING_FLAG = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgv1_HEADCO_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_CONST_CCD = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv1_SITE_CD
            // 
            this.dgv1_SITE_CD.HeaderText = "SITE_CD";
            this.dgv1_SITE_CD.Name = "dgv1_SITE_CD";
            this.dgv1_SITE_CD.ReadOnly = true;
            // 
            // dgv1_END_DATE
            // 
            this.dgv1_END_DATE.DefaultNewRowValue = ((object)(resources.GetObject("dgv1_END_DATE.DefaultNewRowValue")));
            this.dgv1_END_DATE.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Default;
            this.dgv1_END_DATE.HeaderText = "END_DATE";
            this.dgv1_END_DATE.Name = "dgv1_END_DATE";
            this.dgv1_END_DATE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv1_END_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dgv1_BIZ_NO
            // 
            this.dgv1_BIZ_NO.HeaderText = "BIZ_NO";
            this.dgv1_BIZ_NO.Name = "dgv1_BIZ_NO";
            // 
            // dgv1_OWNER_NM
            // 
            this.dgv1_OWNER_NM.HeaderText = "OWNER_NM";
            this.dgv1_OWNER_NM.Name = "dgv1_OWNER_NM";
            // 
            // dgv1_TEL
            // 
            this.dgv1_TEL.HeaderText = "TEL";
            this.dgv1_TEL.Name = "dgv1_TEL";
            // 
            // dgv1_ADDR
            // 
            this.dgv1_ADDR.HeaderText = "ADDR";
            this.dgv1_ADDR.Name = "dgv1_ADDR";
            // 
            // dgv1_USING_CNT
            // 
            this.dgv1_USING_CNT.HeaderText = "USING_CNT";
            this.dgv1_USING_CNT.Name = "dgv1_USING_CNT";
            // 
            // dgv1_SORT_NO
            // 
            this.dgv1_SORT_NO.HeaderText = "SORT_NO";
            this.dgv1_SORT_NO.MinimumWidth = 80;
            this.dgv1_SORT_NO.Name = "dgv1_SORT_NO";
            this.dgv1_SORT_NO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv1_SORT_NO.Width = 80;
            // 
            // dgv1_MEMO
            // 
            this.dgv1_MEMO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgv1_MEMO.HeaderText = "MEMO";
            this.dgv1_MEMO.MaxInputLength = 100;
            this.dgv1_MEMO.MinimumWidth = 100;
            this.dgv1_MEMO.Name = "dgv1_MEMO";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv2_CO_NM,
            this.dgv2_BIZ_NO,
            this.dgv2_CONST_CCD,
            this.dgv2_CO_TYPE_SCD,
            this.dgv2_OWNER_NM,
            this.dgv2_TEL,
            this.dgv2_ADDR,
            this.dgv2_SORT_NO,
            this.dgv2_MEMO,
            this.dgv2_BTNADD});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(1037, 78);
            this.dataGridView2.TabIndex = 1;
            // 
            // dgv2_CO_NM
            // 
            this.dgv2_CO_NM.HeaderText = "CO_NM";
            this.dgv2_CO_NM.MaxInputLength = 50;
            this.dgv2_CO_NM.Name = "dgv2_CO_NM";
            // 
            // dgv2_BIZ_NO
            // 
            this.dgv2_BIZ_NO.HeaderText = "BIZ_NO";
            this.dgv2_BIZ_NO.Name = "dgv2_BIZ_NO";
            // 
            // dgv2_CONST_CCD
            // 
            this.dgv2_CONST_CCD.HeaderText = "CONST_CCD";
            this.dgv2_CONST_CCD.Name = "dgv2_CONST_CCD";
            this.dgv2_CONST_CCD.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv2_CONST_CCD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dgv2_CO_TYPE_SCD
            // 
            this.dgv2_CO_TYPE_SCD.HeaderText = "CO_TYPE_SCD";
            this.dgv2_CO_TYPE_SCD.Name = "dgv2_CO_TYPE_SCD";
            // 
            // dgv2_OWNER_NM
            // 
            this.dgv2_OWNER_NM.HeaderText = "OWNER_NM";
            this.dgv2_OWNER_NM.Name = "dgv2_OWNER_NM";
            // 
            // dgv2_TEL
            // 
            this.dgv2_TEL.HeaderText = "TEL";
            this.dgv2_TEL.Name = "dgv2_TEL";
            // 
            // dgv2_ADDR
            // 
            this.dgv2_ADDR.HeaderText = "ADDR";
            this.dgv2_ADDR.Name = "dgv2_ADDR";
            // 
            // dgv2_SORT_NO
            // 
            this.dgv2_SORT_NO.HeaderText = "SORT_NO";
            this.dgv2_SORT_NO.MaxInputLength = 1000;
            this.dgv2_SORT_NO.Name = "dgv2_SORT_NO";
            // 
            // dgv2_MEMO
            // 
            this.dgv2_MEMO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgv2_MEMO.HeaderText = "MEMO";
            this.dgv2_MEMO.Name = "dgv2_MEMO";
            // 
            // dgv2_BTNADD
            // 
            this.dgv2_BTNADD.HeaderText = "";
            this.dgv2_BTNADD.Name = "dgv2_BTNADD";
            this.dgv2_BTNADD.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv2_BTNADD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgv2_BTNADD.Text = "Add";
            // 
            // dgv1_START_DATE
            // 
            this.dgv1_START_DATE.DefaultNewRowValue = ((object)(resources.GetObject("dgv1_START_DATE.DefaultNewRowValue")));
            this.dgv1_START_DATE.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Default;
            this.dgv1_START_DATE.HeaderText = "START_DATE";
            this.dgv1_START_DATE.Name = "dgv1_START_DATE";
            this.dgv1_START_DATE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv1_START_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dgv1_CO_TYPE_SCD
            // 
            this.dgv1_CO_TYPE_SCD.HeaderText = "CO_TYPE_SCD";
            this.dgv1_CO_TYPE_SCD.Name = "dgv1_CO_TYPE_SCD";
            this.dgv1_CO_TYPE_SCD.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv1_CO_TYPE_SCD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "MEMO";
            this.dataGridViewTextBoxColumn6.HeaderText = "Memo";
            this.dataGridViewTextBoxColumn6.MaxInputLength = 100;
            this.dataGridViewTextBoxColumn6.MinimumWidth = 150;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "SORT_NO";
            this.dataGridViewTextBoxColumn4.HeaderText = "Sort";
            this.dataGridViewTextBoxColumn4.MaxInputLength = 100;
            this.dataGridViewTextBoxColumn4.MinimumWidth = 50;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.Width = 60;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "CODE_NM2";
            this.dataGridViewTextBoxColumn3.HeaderText = "Name2";
            this.dataGridViewTextBoxColumn3.MaxInputLength = 100;
            this.dataGridViewTextBoxColumn3.MinimumWidth = 70;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 167;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "CODE_NM1";
            this.dataGridViewTextBoxColumn2.HeaderText = "Name1";
            this.dataGridViewTextBoxColumn2.MaxInputLength = 100;
            this.dataGridViewTextBoxColumn2.MinimumWidth = 70;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 168;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CODE_GRP";
            this.dataGridViewTextBoxColumn1.HeaderText = "CODE_GRP";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.btnSearch);
            this.splitContainer2.Panel1.Controls.Add(this.txtSearch);
            this.splitContainer2.Panel1.Controls.Add(this.cmbCom);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnSave);
            this.splitContainer2.Size = new System.Drawing.Size(1037, 40);
            this.splitContainer2.SplitterDistance = 750;
            this.splitContainer2.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSearch.Location = new System.Drawing.Point(317, 11);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(184, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(130, 21);
            this.txtSearch.TabIndex = 5;
            // 
            // cmbCom
            // 
            this.cmbCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCom.FormattingEnabled = true;
            this.cmbCom.Location = new System.Drawing.Point(10, 12);
            this.cmbCom.Name = "cmbCom";
            this.cmbCom.Size = new System.Drawing.Size(170, 20);
            this.cmbCom.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSave.Location = new System.Drawing.Point(7, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1MinSize = 40;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1037, 601);
            this.splitContainer1.SplitterDistance = 40;
            this.splitContainer1.TabIndex = 3;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.dataGridView2);
            this.splitContainer3.Size = new System.Drawing.Size(1037, 557);
            this.splitContainer3.SplitterDistance = 475;
            this.splitContainer3.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv1_CHK,
            this.dgv1_CO_CD,
            this.dgv1_CO_NM,
            this.dgv1_USING_FLAG,
            this.dgv1_HEADCO_CD,
            this.dgv1_CONST_CCD,
            this.dgv1_CO_TYPE_SCD,
            this.dgv1_SITE_CD,
            this.dgv1_START_DATE,
            this.dgv1_END_DATE,
            this.dgv1_BIZ_NO,
            this.dgv1_OWNER_NM,
            this.dgv1_TEL,
            this.dgv1_ADDR,
            this.dgv1_USING_CNT,
            this.dgv1_SORT_NO,
            this.dgv1_MEMO});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1037, 475);
            this.dataGridView1.TabIndex = 1;
            // 
            // dgv1_CHK
            // 
            this.dgv1_CHK.FalseValue = "0";
            this.dgv1_CHK.HeaderText = "CHK";
            this.dgv1_CHK.IndeterminateValue = "0";
            this.dgv1_CHK.MinimumWidth = 100;
            this.dgv1_CHK.Name = "dgv1_CHK";
            this.dgv1_CHK.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv1_CHK.TrueValue = "1";
            // 
            // dgv1_CO_CD
            // 
            this.dgv1_CO_CD.HeaderText = "CO_CD";
            this.dgv1_CO_CD.MaxInputLength = 100;
            this.dgv1_CO_CD.MinimumWidth = 100;
            this.dgv1_CO_CD.Name = "dgv1_CO_CD";
            this.dgv1_CO_CD.ReadOnly = true;
            // 
            // dgv1_CO_NM
            // 
            this.dgv1_CO_NM.HeaderText = "CO_NM";
            this.dgv1_CO_NM.MaxInputLength = 100;
            this.dgv1_CO_NM.MinimumWidth = 150;
            this.dgv1_CO_NM.Name = "dgv1_CO_NM";
            this.dgv1_CO_NM.Width = 150;
            // 
            // dgv1_USING_FLAG
            // 
            this.dgv1_USING_FLAG.FalseValue = "0";
            this.dgv1_USING_FLAG.HeaderText = "USING_FLAG";
            this.dgv1_USING_FLAG.IndeterminateValue = "0";
            this.dgv1_USING_FLAG.MinimumWidth = 60;
            this.dgv1_USING_FLAG.Name = "dgv1_USING_FLAG";
            this.dgv1_USING_FLAG.TrueValue = "1";
            this.dgv1_USING_FLAG.Width = 60;
            // 
            // dgv1_HEADCO_CD
            // 
            this.dgv1_HEADCO_CD.HeaderText = "HEADCO_CD";
            this.dgv1_HEADCO_CD.Name = "dgv1_HEADCO_CD";
            // 
            // dgv1_CONST_CCD
            // 
            this.dgv1_CONST_CCD.HeaderText = "CONST_CCD";
            this.dgv1_CONST_CCD.Name = "dgv1_CONST_CCD";
            this.dgv1_CONST_CCD.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv1_CONST_CCD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "MEMO";
            this.dataGridViewTextBoxColumn5.HeaderText = "Memo";
            this.dataGridViewTextBoxColumn5.MaxInputLength = 100;
            this.dataGridViewTextBoxColumn5.MinimumWidth = 150;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // FrmTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 601);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmTeam";
            this.Text = "FrmTeam";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_SITE_CD;
        private Infragistics.Win.UltraDataGridView.UltraCalendarComboColumn dgv1_END_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_BIZ_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_OWNER_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_TEL;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_ADDR;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_USING_CNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_SORT_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_MEMO;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv2_CO_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv2_BIZ_NO;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgv2_CONST_CCD;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgv2_CO_TYPE_SCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv2_OWNER_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv2_TEL;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv2_ADDR;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv2_SORT_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv2_MEMO;
        private System.Windows.Forms.DataGridViewButtonColumn dgv2_BTNADD;
        private Infragistics.Win.UltraDataGridView.UltraCalendarComboColumn dgv1_START_DATE;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgv1_CO_TYPE_SCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbCom;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgv1_CHK;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_CO_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_CO_NM;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgv1_USING_FLAG;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_HEADCO_CD;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgv1_CONST_CCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    }
}