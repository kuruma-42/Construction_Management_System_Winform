namespace EldigmPlusApp.SubForm.Sys.MemberSite
{
    partial class FrmSite
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.cmbMember = new System.Windows.Forms.ComboBox();
            this.cmbUse = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dgv2_SITE_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv2_SORT_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv2_HEADCO_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv2_MEMO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv2_BTNADD = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dgv1_CHK = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgv1_SITE_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_MEMCO_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_SITE_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_USING_FLAG = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgv1_SORT_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_MEMO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1037, 601);
            this.splitContainer1.SplitterDistance = 40;
            this.splitContainer1.TabIndex = 2;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.cmbMember);
            this.splitContainer3.Panel1.Controls.Add(this.cmbUse);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.btnSave);
            this.splitContainer3.Size = new System.Drawing.Size(1037, 40);
            this.splitContainer3.SplitterDistance = 817;
            this.splitContainer3.TabIndex = 0;
            // 
            // cmbMember
            // 
            this.cmbMember.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMember.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMember.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMember.FormattingEnabled = true;
            this.cmbMember.Location = new System.Drawing.Point(12, 14);
            this.cmbMember.Name = "cmbMember";
            this.cmbMember.Size = new System.Drawing.Size(170, 20);
            this.cmbMember.TabIndex = 7;
            this.cmbMember.SelectedIndexChanged += new System.EventHandler(this.cmbMember_SelectedIndexChanged);
            // 
            // cmbUse
            // 
            this.cmbUse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUse.FormattingEnabled = true;
            this.cmbUse.Location = new System.Drawing.Point(187, 14);
            this.cmbUse.Name = "cmbUse";
            this.cmbUse.Size = new System.Drawing.Size(170, 20);
            this.cmbUse.TabIndex = 6;
            this.cmbUse.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(3, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dataGridView1);
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dataGridView2);
            this.splitContainer2.Size = new System.Drawing.Size(1037, 557);
            this.splitContainer2.SplitterDistance = 501;
            this.splitContainer2.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv1_CHK,
            this.dgv1_SITE_CD,
            this.dgv1_MEMCO_CD,
            this.dgv1_SITE_NM,
            this.dgv1_USING_FLAG,
            this.dgv1_SORT_NO,
            this.dgv1_MEMO});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1037, 476);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1037, 25);
            this.panel1.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 11);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 12);
            this.lblName.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv2_SITE_NM,
            this.dgv2_SORT_NO,
            this.dgv2_HEADCO_CD,
            this.dgv2_MEMO,
            this.dgv2_BTNADD});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(1037, 52);
            this.dataGridView2.TabIndex = 2;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // dgv2_SITE_NM
            // 
            this.dgv2_SITE_NM.HeaderText = "SITE_NM";
            this.dgv2_SITE_NM.MinimumWidth = 100;
            this.dgv2_SITE_NM.Name = "dgv2_SITE_NM";
            // 
            // dgv2_SORT_NO
            // 
            this.dgv2_SORT_NO.HeaderText = "SORT_NO";
            this.dgv2_SORT_NO.MinimumWidth = 60;
            this.dgv2_SORT_NO.Name = "dgv2_SORT_NO";
            this.dgv2_SORT_NO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dgv2_HEADCO_CD
            // 
            this.dgv2_HEADCO_CD.HeaderText = "HEADCO_CD";
            this.dgv2_HEADCO_CD.MinimumWidth = 100;
            this.dgv2_HEADCO_CD.Name = "dgv2_HEADCO_CD";
            // 
            // dgv2_MEMO
            // 
            this.dgv2_MEMO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgv2_MEMO.HeaderText = "MEMO";
            this.dgv2_MEMO.MinimumWidth = 100;
            this.dgv2_MEMO.Name = "dgv2_MEMO";
            // 
            // dgv2_BTNADD
            // 
            this.dgv2_BTNADD.HeaderText = "";
            this.dgv2_BTNADD.Name = "dgv2_BTNADD";
            this.dgv2_BTNADD.Text = "";
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
            // dgv1_SITE_CD
            // 
            this.dgv1_SITE_CD.HeaderText = "SITE_CD";
            this.dgv1_SITE_CD.MinimumWidth = 100;
            this.dgv1_SITE_CD.Name = "dgv1_SITE_CD";
            this.dgv1_SITE_CD.ReadOnly = true;
            // 
            // dgv1_MEMCO_CD
            // 
            this.dgv1_MEMCO_CD.HeaderText = "MEMCO_CD";
            this.dgv1_MEMCO_CD.MinimumWidth = 100;
            this.dgv1_MEMCO_CD.Name = "dgv1_MEMCO_CD";
            this.dgv1_MEMCO_CD.ReadOnly = true;
            // 
            // dgv1_SITE_NM
            // 
            this.dgv1_SITE_NM.HeaderText = "SITE_NM";
            this.dgv1_SITE_NM.MinimumWidth = 250;
            this.dgv1_SITE_NM.Name = "dgv1_SITE_NM";
            this.dgv1_SITE_NM.Width = 250;
            // 
            // dgv1_USING_FLAG
            // 
            this.dgv1_USING_FLAG.FalseValue = "0";
            this.dgv1_USING_FLAG.HeaderText = "USING_FLAG";
            this.dgv1_USING_FLAG.IndeterminateValue = "0";
            this.dgv1_USING_FLAG.MinimumWidth = 60;
            this.dgv1_USING_FLAG.Name = "dgv1_USING_FLAG";
            this.dgv1_USING_FLAG.TrueValue = "1";
            // 
            // dgv1_SORT_NO
            // 
            this.dgv1_SORT_NO.HeaderText = "SORT_NO";
            this.dgv1_SORT_NO.MinimumWidth = 60;
            this.dgv1_SORT_NO.Name = "dgv1_SORT_NO";
            // 
            // dgv1_MEMO
            // 
            this.dgv1_MEMO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgv1_MEMO.HeaderText = "MEMO";
            this.dgv1_MEMO.MinimumWidth = 100;
            this.dgv1_MEMO.Name = "dgv1_MEMO";
            // 
            // FrmSite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 601);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmSite";
            this.Text = "FrmSite";
            this.Load += new System.EventHandler(this.FrmSite_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ComboBox cmbMember;
        private System.Windows.Forms.ComboBox cmbUse;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv2_SITE_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv2_SORT_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv2_HEADCO_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv2_MEMO;
        private System.Windows.Forms.DataGridViewButtonColumn dgv2_BTNADD;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgv1_CHK;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_SITE_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_MEMCO_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_SITE_NM;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgv1_USING_FLAG;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_SORT_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_MEMO;
    }
}