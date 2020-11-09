namespace EldigmPlusApp.SubForm.Sys.Menu
{
    partial class FrmMenuSetAuthSite
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
            this.cmbSite = new System.Windows.Forms.ComboBox();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.cmbMenuTop = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgv1_CHK = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgv1_MENU_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_VIEW_FLAG = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgv1_NEW_FLAG = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgv1_MODIFY_FLAG = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgv1_DEL_FLAG = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgv1_REPORT_FLAG = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgv1_PRINT_FLAG = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgv1_DOWNLOAD_FLAG = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbSite
            // 
            this.cmbSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSite.FormattingEnabled = true;
            this.cmbSite.Location = new System.Drawing.Point(12, 14);
            this.cmbSite.Name = "cmbSite";
            this.cmbSite.Size = new System.Drawing.Size(170, 20);
            this.cmbSite.TabIndex = 5;
            this.cmbSite.SelectedIndexChanged += new System.EventHandler(this.cmbSite_SelectedIndexChanged);
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
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            this.lblName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblName.Location = new System.Drawing.Point(10, 5);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 12);
            this.lblName.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(853, 25);
            this.panel2.TabIndex = 3;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer3.Panel2.Controls.Add(this.panel2);
            this.splitContainer3.Size = new System.Drawing.Size(1037, 557);
            this.splitContainer3.SplitterDistance = 180;
            this.splitContainer3.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold);
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(180, 557);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv1_CHK,
            this.dgv1_MENU_CD,
            this.dgv1_NM,
            this.dgv1_VIEW_FLAG,
            this.dgv1_NEW_FLAG,
            this.dgv1_MODIFY_FLAG,
            this.dgv1_DEL_FLAG,
            this.dgv1_REPORT_FLAG,
            this.dgv1_PRINT_FLAG,
            this.dgv1_DOWNLOAD_FLAG});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(853, 532);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.cmbMenuTop);
            this.splitContainer2.Panel1.Controls.Add(this.cmbSite);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnSave);
            this.splitContainer2.Size = new System.Drawing.Size(1037, 40);
            this.splitContainer2.SplitterDistance = 817;
            this.splitContainer2.TabIndex = 0;
            // 
            // cmbMenuTop
            // 
            this.cmbMenuTop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMenuTop.FormattingEnabled = true;
            this.cmbMenuTop.Location = new System.Drawing.Point(196, 14);
            this.cmbMenuTop.Name = "cmbMenuTop";
            this.cmbMenuTop.Size = new System.Drawing.Size(170, 20);
            this.cmbMenuTop.TabIndex = 6;
            this.cmbMenuTop.SelectedIndexChanged += new System.EventHandler(this.cmbMenuTop_SelectedIndexChanged);
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
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.splitContainer1.TabIndex = 2;
            // 
            // dgv1_CHK
            // 
            this.dgv1_CHK.FalseValue = "0";
            this.dgv1_CHK.HeaderText = "CHK";
            this.dgv1_CHK.IndeterminateValue = "0";
            this.dgv1_CHK.MinimumWidth = 60;
            this.dgv1_CHK.Name = "dgv1_CHK";
            this.dgv1_CHK.TrueValue = "1";
            this.dgv1_CHK.Width = 60;
            // 
            // dgv1_MENU_CD
            // 
            this.dgv1_MENU_CD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgv1_MENU_CD.HeaderText = "MENU_CD";
            this.dgv1_MENU_CD.MaxInputLength = 1000;
            this.dgv1_MENU_CD.MinimumWidth = 100;
            this.dgv1_MENU_CD.Name = "dgv1_MENU_CD";
            this.dgv1_MENU_CD.ReadOnly = true;
            // 
            // dgv1_NM
            // 
            this.dgv1_NM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgv1_NM.HeaderText = "NM";
            this.dgv1_NM.MaxInputLength = 1000;
            this.dgv1_NM.MinimumWidth = 100;
            this.dgv1_NM.Name = "dgv1_NM";
            this.dgv1_NM.ReadOnly = true;
            // 
            // dgv1_VIEW_FLAG
            // 
            this.dgv1_VIEW_FLAG.FalseValue = "0";
            this.dgv1_VIEW_FLAG.HeaderText = "VIEW_FLAG";
            this.dgv1_VIEW_FLAG.IndeterminateValue = "0";
            this.dgv1_VIEW_FLAG.MinimumWidth = 60;
            this.dgv1_VIEW_FLAG.Name = "dgv1_VIEW_FLAG";
            this.dgv1_VIEW_FLAG.TrueValue = "1";
            this.dgv1_VIEW_FLAG.Width = 60;
            // 
            // dgv1_NEW_FLAG
            // 
            this.dgv1_NEW_FLAG.FalseValue = "0";
            this.dgv1_NEW_FLAG.HeaderText = "NEW_FLAG";
            this.dgv1_NEW_FLAG.IndeterminateValue = "0";
            this.dgv1_NEW_FLAG.MinimumWidth = 60;
            this.dgv1_NEW_FLAG.Name = "dgv1_NEW_FLAG";
            this.dgv1_NEW_FLAG.TrueValue = "1";
            this.dgv1_NEW_FLAG.Width = 60;
            // 
            // dgv1_MODIFY_FLAG
            // 
            this.dgv1_MODIFY_FLAG.FalseValue = "0";
            this.dgv1_MODIFY_FLAG.HeaderText = "MODIFY_FLAG";
            this.dgv1_MODIFY_FLAG.IndeterminateValue = "0";
            this.dgv1_MODIFY_FLAG.MinimumWidth = 60;
            this.dgv1_MODIFY_FLAG.Name = "dgv1_MODIFY_FLAG";
            this.dgv1_MODIFY_FLAG.TrueValue = "1";
            this.dgv1_MODIFY_FLAG.Width = 60;
            // 
            // dgv1_DEL_FLAG
            // 
            this.dgv1_DEL_FLAG.FalseValue = "0";
            this.dgv1_DEL_FLAG.HeaderText = "DEL_FLAG";
            this.dgv1_DEL_FLAG.IndeterminateValue = "0";
            this.dgv1_DEL_FLAG.MinimumWidth = 60;
            this.dgv1_DEL_FLAG.Name = "dgv1_DEL_FLAG";
            this.dgv1_DEL_FLAG.TrueValue = "1";
            this.dgv1_DEL_FLAG.Width = 60;
            // 
            // dgv1_REPORT_FLAG
            // 
            this.dgv1_REPORT_FLAG.FalseValue = "0";
            this.dgv1_REPORT_FLAG.HeaderText = "REPORT_FLAG";
            this.dgv1_REPORT_FLAG.IndeterminateValue = "0";
            this.dgv1_REPORT_FLAG.MinimumWidth = 60;
            this.dgv1_REPORT_FLAG.Name = "dgv1_REPORT_FLAG";
            this.dgv1_REPORT_FLAG.TrueValue = "1";
            this.dgv1_REPORT_FLAG.Width = 60;
            // 
            // dgv1_PRINT_FLAG
            // 
            this.dgv1_PRINT_FLAG.FalseValue = "0";
            this.dgv1_PRINT_FLAG.HeaderText = "PRINT_FLAG";
            this.dgv1_PRINT_FLAG.IndeterminateValue = "0";
            this.dgv1_PRINT_FLAG.MinimumWidth = 60;
            this.dgv1_PRINT_FLAG.Name = "dgv1_PRINT_FLAG";
            this.dgv1_PRINT_FLAG.TrueValue = "1";
            this.dgv1_PRINT_FLAG.Width = 60;
            // 
            // dgv1_DOWNLOAD_FLAG
            // 
            this.dgv1_DOWNLOAD_FLAG.FalseValue = "0";
            this.dgv1_DOWNLOAD_FLAG.HeaderText = "DOWNLOAD_FLAG";
            this.dgv1_DOWNLOAD_FLAG.IndeterminateValue = "0";
            this.dgv1_DOWNLOAD_FLAG.MinimumWidth = 60;
            this.dgv1_DOWNLOAD_FLAG.Name = "dgv1_DOWNLOAD_FLAG";
            this.dgv1_DOWNLOAD_FLAG.TrueValue = "1";
            this.dgv1_DOWNLOAD_FLAG.Width = 60;
            // 
            // FrmMenuSetAuthSite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 601);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmMenuSetAuthSite";
            this.Text = "FrmMenuSetAuthSite";
            this.Load += new System.EventHandler(this.FrmMenuSetAuthSite_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbSite;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmbMenuTop;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgv1_CHK;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_MENU_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_NM;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgv1_VIEW_FLAG;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgv1_NEW_FLAG;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgv1_MODIFY_FLAG;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgv1_DEL_FLAG;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgv1_REPORT_FLAG;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgv1_PRINT_FLAG;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgv1_DOWNLOAD_FLAG;
    }
}