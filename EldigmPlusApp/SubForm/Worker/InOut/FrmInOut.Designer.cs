namespace EldigmPlusApp.SubForm.Worker.InOut
{
    partial class FrmInOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInOut));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnSave = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dgv1_CHK = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgv1_LAB_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_LAB_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_IN_DT = new Infragistics.Win.UltraDataGridView.UltraCalendarComboColumn(this.components);
            this.dgv1_OUT_DT = new Infragistics.Win.UltraDataGridView.UltraCalendarComboColumn(this.components);
            this.dgv1_CO_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_TEAM_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_DEV_IO_SCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_CODE_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.searchCondition21 = new EldigmPlusApp_UserControl.SearchCondition2();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(1037, 601);
            this.splitContainer1.SplitterDistance = 40;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.searchCondition21);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnSave);
            this.splitContainer2.Size = new System.Drawing.Size(1037, 40);
            this.splitContainer2.SplitterDistance = 750;
            this.splitContainer2.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(7, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Button";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv1_CHK,
            this.dgv1_LAB_NO,
            this.dgv1_LAB_NM,
            this.dgv1_IN_DT,
            this.dgv1_OUT_DT,
            this.dgv1_CO_NM,
            this.dgv1_TEAM_NM,
            this.dgv1_DEV_IO_SCD,
            this.dgv1_CODE_NM});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1037, 557);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // dgv1_CHK
            // 
            this.dgv1_CHK.DataPropertyName = "CHK";
            this.dgv1_CHK.FalseValue = "0";
            this.dgv1_CHK.HeaderText = "CHK";
            this.dgv1_CHK.IndeterminateValue = "0";
            this.dgv1_CHK.MinimumWidth = 60;
            this.dgv1_CHK.Name = "dgv1_CHK";
            this.dgv1_CHK.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv1_CHK.TrueValue = "1";
            this.dgv1_CHK.Width = 60;
            // 
            // dgv1_LAB_NO
            // 
            this.dgv1_LAB_NO.HeaderText = "LAB_NO";
            this.dgv1_LAB_NO.MaxInputLength = 100;
            this.dgv1_LAB_NO.MinimumWidth = 90;
            this.dgv1_LAB_NO.Name = "dgv1_LAB_NO";
            this.dgv1_LAB_NO.ReadOnly = true;
            this.dgv1_LAB_NO.Visible = false;
            this.dgv1_LAB_NO.Width = 90;
            // 
            // dgv1_LAB_NM
            // 
            this.dgv1_LAB_NM.HeaderText = "LAB_NM";
            this.dgv1_LAB_NM.MaxInputLength = 100;
            this.dgv1_LAB_NM.MinimumWidth = 80;
            this.dgv1_LAB_NM.Name = "dgv1_LAB_NM";
            this.dgv1_LAB_NM.ReadOnly = true;
            this.dgv1_LAB_NM.Width = 80;
            // 
            // dgv1_IN_DT
            // 
            this.dgv1_IN_DT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgv1_IN_DT.DefaultNewRowValue = ((object)(resources.GetObject("dgv1_IN_DT.DefaultNewRowValue")));
            this.dgv1_IN_DT.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Default;
            this.dgv1_IN_DT.HeaderText = "IN_DT";
            this.dgv1_IN_DT.MinimumWidth = 150;
            this.dgv1_IN_DT.Name = "dgv1_IN_DT";
            this.dgv1_IN_DT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv1_IN_DT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dgv1_OUT_DT
            // 
            this.dgv1_OUT_DT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgv1_OUT_DT.DefaultNewRowValue = ((object)(resources.GetObject("dgv1_OUT_DT.DefaultNewRowValue")));
            this.dgv1_OUT_DT.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Default;
            this.dgv1_OUT_DT.HeaderText = "OUT_DT";
            this.dgv1_OUT_DT.MinimumWidth = 150;
            this.dgv1_OUT_DT.Name = "dgv1_OUT_DT";
            this.dgv1_OUT_DT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dgv1_CO_NM
            // 
            this.dgv1_CO_NM.HeaderText = "CO_NM";
            this.dgv1_CO_NM.MaxInputLength = 100;
            this.dgv1_CO_NM.MinimumWidth = 90;
            this.dgv1_CO_NM.Name = "dgv1_CO_NM";
            this.dgv1_CO_NM.ReadOnly = true;
            this.dgv1_CO_NM.Width = 90;
            // 
            // dgv1_TEAM_NM
            // 
            this.dgv1_TEAM_NM.HeaderText = "TEAM_NM";
            this.dgv1_TEAM_NM.MaxInputLength = 100;
            this.dgv1_TEAM_NM.MinimumWidth = 70;
            this.dgv1_TEAM_NM.Name = "dgv1_TEAM_NM";
            this.dgv1_TEAM_NM.ReadOnly = true;
            this.dgv1_TEAM_NM.Width = 70;
            // 
            // dgv1_DEV_IO_SCD
            // 
            this.dgv1_DEV_IO_SCD.HeaderText = "DEV_IO_SCD";
            this.dgv1_DEV_IO_SCD.MaxInputLength = 100;
            this.dgv1_DEV_IO_SCD.MinimumWidth = 110;
            this.dgv1_DEV_IO_SCD.Name = "dgv1_DEV_IO_SCD";
            this.dgv1_DEV_IO_SCD.ReadOnly = true;
            this.dgv1_DEV_IO_SCD.Width = 110;
            // 
            // dgv1_CODE_NM
            // 
            this.dgv1_CODE_NM.HeaderText = "CODE_NM";
            this.dgv1_CODE_NM.MaxInputLength = 100;
            this.dgv1_CODE_NM.Name = "dgv1_CODE_NM";
            this.dgv1_CODE_NM.ReadOnly = true;
            // 
            // searchCondition21
            // 
            this.searchCondition21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchCondition21.Location = new System.Drawing.Point(0, 0);
            this.searchCondition21.Name = "searchCondition21";
            this.searchCondition21.Size = new System.Drawing.Size(750, 40);
            this.searchCondition21.TabIndex = 1;
            this.searchCondition21.btnSearchClick += new System.EventHandler(this.searchCondition21_btnSearchClick);
            // 
            // FrmInOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 601);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmInOut";
            this.Text = "FrmInOut";
            this.Load += new System.EventHandler(this.FrmInOut_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgv1_CHK;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_LAB_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_LAB_NM;
        private Infragistics.Win.UltraDataGridView.UltraCalendarComboColumn dgv1_IN_DT;
        private Infragistics.Win.UltraDataGridView.UltraCalendarComboColumn dgv1_OUT_DT;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_CO_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_TEAM_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_DEV_IO_SCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_CODE_NM;
        private EldigmPlusApp_UserControl.SearchCondition2 searchCondition21;
    }
}