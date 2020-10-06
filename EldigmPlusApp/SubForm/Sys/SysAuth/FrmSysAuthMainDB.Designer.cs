namespace EldigmPlusApp.SubForm.Sys.SysAuth
{
    partial class FrmSysAuthMainDB
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
            this.cmbUse = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dgv1_CHK = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgv1_AUTH_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_AUTH_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_MYBLOCK_FLAG = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgv1_MYCON_FLAG = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgv1_MYCOM_FLAG = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgv1_MYTEAM_FLAG = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgv1_USING_FLAG = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgv1_AUTH_LEVEL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_MEMO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dgv2_AUTH_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv2_AUTH_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv2_MYBLOCK_FLAG = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgv2_MYCON_FLAG = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgv2_MYCOM_FLAG = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgv2_MYTEAM_FLAG = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgv2_AUTH_LEVEL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv2_MEMO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv2_BTNADD = new System.Windows.Forms.DataGridViewButtonColumn();
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
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.cmbUse);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.btnSave);
            this.splitContainer3.Size = new System.Drawing.Size(1037, 40);
            this.splitContainer3.SplitterDistance = 817;
            this.splitContainer3.TabIndex = 0;
            // 
            // cmbUse
            // 
            this.cmbUse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUse.FormattingEnabled = true;
            this.cmbUse.Location = new System.Drawing.Point(12, 14);
            this.cmbUse.Name = "cmbUse";
            this.cmbUse.Size = new System.Drawing.Size(170, 20);
            this.cmbUse.TabIndex = 5;
            this.cmbUse.SelectedIndexChanged += new System.EventHandler(this.cmbUse_SelectedIndexChanged);
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
            this.dgv1_AUTH_CD,
            this.dgv1_AUTH_NM,
            this.dgv1_MYBLOCK_FLAG,
            this.dgv1_MYCON_FLAG,
            this.dgv1_MYCOM_FLAG,
            this.dgv1_MYTEAM_FLAG,
            this.dgv1_USING_FLAG,
            this.dgv1_AUTH_LEVEL,
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
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // dgv1_CHK
            // 
            this.dgv1_CHK.FalseValue = "0";
            this.dgv1_CHK.HeaderText = "CHK";
            this.dgv1_CHK.IndeterminateValue = "0";
            this.dgv1_CHK.Name = "dgv1_CHK";
            this.dgv1_CHK.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv1_CHK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgv1_CHK.TrueValue = "1";
            // 
            // dgv1_AUTH_CD
            // 
            this.dgv1_AUTH_CD.HeaderText = "AUTH_CD";
            this.dgv1_AUTH_CD.Name = "dgv1_AUTH_CD";
            this.dgv1_AUTH_CD.ReadOnly = true;
            // 
            // dgv1_AUTH_NM
            // 
            this.dgv1_AUTH_NM.HeaderText = "AUTH_NM";
            this.dgv1_AUTH_NM.Name = "dgv1_AUTH_NM";
            this.dgv1_AUTH_NM.ReadOnly = true;
            // 
            // dgv1_MYBLOCK_FLAG
            // 
            this.dgv1_MYBLOCK_FLAG.FalseValue = "0";
            this.dgv1_MYBLOCK_FLAG.HeaderText = "MYBLOCK_FLAG";
            this.dgv1_MYBLOCK_FLAG.IndeterminateValue = "0";
            this.dgv1_MYBLOCK_FLAG.Name = "dgv1_MYBLOCK_FLAG";
            this.dgv1_MYBLOCK_FLAG.TrueValue = "1";
            // 
            // dgv1_MYCON_FLAG
            // 
            this.dgv1_MYCON_FLAG.FalseValue = "0";
            this.dgv1_MYCON_FLAG.HeaderText = "MYCON_FLAG";
            this.dgv1_MYCON_FLAG.IndeterminateValue = "0";
            this.dgv1_MYCON_FLAG.Name = "dgv1_MYCON_FLAG";
            this.dgv1_MYCON_FLAG.TrueValue = "1";
            // 
            // dgv1_MYCOM_FLAG
            // 
            this.dgv1_MYCOM_FLAG.FalseValue = "0";
            this.dgv1_MYCOM_FLAG.HeaderText = "MYCOM_FLAG";
            this.dgv1_MYCOM_FLAG.IndeterminateValue = "0";
            this.dgv1_MYCOM_FLAG.Name = "dgv1_MYCOM_FLAG";
            this.dgv1_MYCOM_FLAG.TrueValue = "1";
            // 
            // dgv1_MYTEAM_FLAG
            // 
            this.dgv1_MYTEAM_FLAG.FalseValue = "0";
            this.dgv1_MYTEAM_FLAG.HeaderText = "MYTEAM_FLAG";
            this.dgv1_MYTEAM_FLAG.IndeterminateValue = "0";
            this.dgv1_MYTEAM_FLAG.Name = "dgv1_MYTEAM_FLAG";
            this.dgv1_MYTEAM_FLAG.TrueValue = "1";
            // 
            // dgv1_USING_FLAG
            // 
            this.dgv1_USING_FLAG.FalseValue = "0";
            this.dgv1_USING_FLAG.HeaderText = "USING_FLAG";
            this.dgv1_USING_FLAG.IndeterminateValue = "0";
            this.dgv1_USING_FLAG.Name = "dgv1_USING_FLAG";
            this.dgv1_USING_FLAG.TrueValue = "1";
            // 
            // dgv1_AUTH_LEVEL
            // 
            this.dgv1_AUTH_LEVEL.HeaderText = "AUTH_LEVEL";
            this.dgv1_AUTH_LEVEL.Name = "dgv1_AUTH_LEVEL";
            this.dgv1_AUTH_LEVEL.ReadOnly = true;
            this.dgv1_AUTH_LEVEL.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv1_AUTH_LEVEL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgv1_MEMO
            // 
            this.dgv1_MEMO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgv1_MEMO.HeaderText = "MEMO";
            this.dgv1_MEMO.Name = "dgv1_MEMO";
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
            this.dgv2_AUTH_CD,
            this.dgv2_AUTH_NM,
            this.dgv2_MYBLOCK_FLAG,
            this.dgv2_MYCON_FLAG,
            this.dgv2_MYCOM_FLAG,
            this.dgv2_MYTEAM_FLAG,
            this.dgv2_AUTH_LEVEL,
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
            // dgv2_AUTH_CD
            // 
            this.dgv2_AUTH_CD.HeaderText = "AUTH_CD";
            this.dgv2_AUTH_CD.Name = "dgv2_AUTH_CD";
            // 
            // dgv2_AUTH_NM
            // 
            this.dgv2_AUTH_NM.HeaderText = "AUTH_NM";
            this.dgv2_AUTH_NM.Name = "dgv2_AUTH_NM";
            // 
            // dgv2_MYBLOCK_FLAG
            // 
            this.dgv2_MYBLOCK_FLAG.FalseValue = "0";
            this.dgv2_MYBLOCK_FLAG.HeaderText = "MYBLOCK_FLAG";
            this.dgv2_MYBLOCK_FLAG.IndeterminateValue = "0";
            this.dgv2_MYBLOCK_FLAG.Name = "dgv2_MYBLOCK_FLAG";
            this.dgv2_MYBLOCK_FLAG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgv2_MYBLOCK_FLAG.TrueValue = "1";
            // 
            // dgv2_MYCON_FLAG
            // 
            this.dgv2_MYCON_FLAG.FalseValue = "0";
            this.dgv2_MYCON_FLAG.HeaderText = "MYCON_FLAG";
            this.dgv2_MYCON_FLAG.IndeterminateValue = "0";
            this.dgv2_MYCON_FLAG.Name = "dgv2_MYCON_FLAG";
            this.dgv2_MYCON_FLAG.TrueValue = "1";
            // 
            // dgv2_MYCOM_FLAG
            // 
            this.dgv2_MYCOM_FLAG.FalseValue = "0";
            this.dgv2_MYCOM_FLAG.HeaderText = "MYCOM_FLAG";
            this.dgv2_MYCOM_FLAG.IndeterminateValue = "0";
            this.dgv2_MYCOM_FLAG.Name = "dgv2_MYCOM_FLAG";
            this.dgv2_MYCOM_FLAG.TrueValue = "1";
            // 
            // dgv2_MYTEAM_FLAG
            // 
            this.dgv2_MYTEAM_FLAG.FalseValue = "0";
            this.dgv2_MYTEAM_FLAG.HeaderText = "MYTEAM_FLAG";
            this.dgv2_MYTEAM_FLAG.IndeterminateValue = "0";
            this.dgv2_MYTEAM_FLAG.Name = "dgv2_MYTEAM_FLAG";
            this.dgv2_MYTEAM_FLAG.TrueValue = "1";
            // 
            // dgv2_AUTH_LEVEL
            // 
            this.dgv2_AUTH_LEVEL.HeaderText = "AUTH_LEVEL";
            this.dgv2_AUTH_LEVEL.Name = "dgv2_AUTH_LEVEL";
            this.dgv2_AUTH_LEVEL.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv2_AUTH_LEVEL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            this.dgv2_BTNADD.Text = "";
            // 
            // FrmSysAuthMainDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 601);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmSysAuthMainDB";
            this.Text = "FrmSysAuth";
            this.Load += new System.EventHandler(this.FrmSysAuthMainDB_Load);
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
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgv1_CHK;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_AUTH_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_AUTH_NM;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgv1_MYBLOCK_FLAG;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgv1_MYCON_FLAG;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgv1_MYCOM_FLAG;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgv1_MYTEAM_FLAG;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgv1_USING_FLAG;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_AUTH_LEVEL;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_MEMO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv2_AUTH_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv2_AUTH_NM;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgv2_MYBLOCK_FLAG;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgv2_MYCON_FLAG;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgv2_MYCOM_FLAG;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgv2_MYTEAM_FLAG;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv2_AUTH_LEVEL;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv2_MEMO;
        private System.Windows.Forms.DataGridViewButtonColumn dgv2_BTNADD;
        private System.Windows.Forms.ComboBox cmbUse;
    }
}