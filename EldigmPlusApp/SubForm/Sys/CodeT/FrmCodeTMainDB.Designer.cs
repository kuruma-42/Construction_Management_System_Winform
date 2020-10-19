namespace EldigmPlusApp.SubForm.Sys.CodeT
{
    partial class FrmCodeTMainDB
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
            this.lblName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dgv1_CHK = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgv1_TCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_TTYPE_SCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_LIST_FLAG = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgv1_REQUIRED_FLAG = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgv1_NUMERIC_FLAG = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgv1_USING_CNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dgv2_TCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv2_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv2_LIST_FLAG = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgv2_REQUIRED_FLAG = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgv2_NUMERIC_FLAG = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgv2_BTNADD = new System.Windows.Forms.DataGridViewButtonColumn();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnSave = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
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
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
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
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer4.Location = new System.Drawing.Point(0, 25);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.dataGridView2);
            this.splitContainer4.Size = new System.Drawing.Size(853, 532);
            this.splitContainer4.SplitterDistance = 475;
            this.splitContainer4.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv1_CHK,
            this.dgv1_TCODE,
            this.dgv1_TTYPE_SCD,
            this.dgv1_NM,
            this.dgv1_LIST_FLAG,
            this.dgv1_REQUIRED_FLAG,
            this.dgv1_NUMERIC_FLAG,
            this.dgv1_USING_CNT});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(853, 475);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
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
            // dgv1_TCODE
            // 
            this.dgv1_TCODE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgv1_TCODE.HeaderText = "TCODE";
            this.dgv1_TCODE.MaxInputLength = 1000;
            this.dgv1_TCODE.MinimumWidth = 100;
            this.dgv1_TCODE.Name = "dgv1_TCODE";
            // 
            // dgv1_TTYPE_SCD
            // 
            this.dgv1_TTYPE_SCD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgv1_TTYPE_SCD.HeaderText = "TTYPE_SCD";
            this.dgv1_TTYPE_SCD.MaxInputLength = 1000;
            this.dgv1_TTYPE_SCD.MinimumWidth = 100;
            this.dgv1_TTYPE_SCD.Name = "dgv1_TTYPE_SCD";
            // 
            // dgv1_NM
            // 
            this.dgv1_NM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgv1_NM.HeaderText = "NM";
            this.dgv1_NM.MaxInputLength = 1000;
            this.dgv1_NM.MinimumWidth = 150;
            this.dgv1_NM.Name = "dgv1_NM";
            // 
            // dgv1_LIST_FLAG
            // 
            this.dgv1_LIST_FLAG.DataPropertyName = "LIST_FLAG";
            this.dgv1_LIST_FLAG.FalseValue = "0";
            this.dgv1_LIST_FLAG.HeaderText = "LIST_FLAG";
            this.dgv1_LIST_FLAG.IndeterminateValue = "0";
            this.dgv1_LIST_FLAG.MinimumWidth = 60;
            this.dgv1_LIST_FLAG.Name = "dgv1_LIST_FLAG";
            this.dgv1_LIST_FLAG.TrueValue = "1";
            this.dgv1_LIST_FLAG.Width = 60;
            // 
            // dgv1_REQUIRED_FLAG
            // 
            this.dgv1_REQUIRED_FLAG.DataPropertyName = "REQUIRED_FLAG";
            this.dgv1_REQUIRED_FLAG.FalseValue = "0";
            this.dgv1_REQUIRED_FLAG.HeaderText = "REQUIRED_FLAG";
            this.dgv1_REQUIRED_FLAG.IndeterminateValue = "0";
            this.dgv1_REQUIRED_FLAG.MinimumWidth = 60;
            this.dgv1_REQUIRED_FLAG.Name = "dgv1_REQUIRED_FLAG";
            this.dgv1_REQUIRED_FLAG.TrueValue = "1";
            this.dgv1_REQUIRED_FLAG.Width = 60;
            // 
            // dgv1_NUMERIC_FLAG
            // 
            this.dgv1_NUMERIC_FLAG.DataPropertyName = "NUMERIC_FLAG";
            this.dgv1_NUMERIC_FLAG.FalseValue = "0";
            this.dgv1_NUMERIC_FLAG.HeaderText = "NUMERIC_FLAG";
            this.dgv1_NUMERIC_FLAG.IndeterminateValue = "0";
            this.dgv1_NUMERIC_FLAG.MinimumWidth = 60;
            this.dgv1_NUMERIC_FLAG.Name = "dgv1_NUMERIC_FLAG";
            this.dgv1_NUMERIC_FLAG.TrueValue = "1";
            this.dgv1_NUMERIC_FLAG.Width = 60;
            // 
            // dgv1_USING_CNT
            // 
            this.dgv1_USING_CNT.HeaderText = "USING_CNT";
            this.dgv1_USING_CNT.MaxInputLength = 1000;
            this.dgv1_USING_CNT.MinimumWidth = 100;
            this.dgv1_USING_CNT.Name = "dgv1_USING_CNT";
            this.dgv1_USING_CNT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
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
            // dgv1_TCODE
            // 
            this.dgv1_TCODE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgv1_TCODE.HeaderText = "TCODE";
            this.dgv1_TCODE.MaxInputLength = 1000;
            this.dgv1_TCODE.MinimumWidth = 100;
            this.dgv1_TCODE.Name = "dgv1_TCODE";
            this.dgv1_TCODE.ReadOnly = true;
            // 
            // dgv1_TTYPE_SCD
            // 
            this.dgv1_TTYPE_SCD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgv1_TTYPE_SCD.HeaderText = "TTYPE_SCD";
            this.dgv1_TTYPE_SCD.MaxInputLength = 1000;
            this.dgv1_TTYPE_SCD.MinimumWidth = 100;
            this.dgv1_TTYPE_SCD.Name = "dgv1_TTYPE_SCD";
            this.dgv1_TTYPE_SCD.ReadOnly = true;
            // 
            // dgv1_NM
            // 
            this.dgv1_NM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgv1_NM.HeaderText = "NM";
            this.dgv1_NM.MaxInputLength = 1000;
            this.dgv1_NM.MinimumWidth = 150;
            this.dgv1_NM.Name = "dgv1_NM";
            this.dgv1_NM.ReadOnly = true;
            // 
            // dgv1_LIST_FLAG
            // 
            this.dgv1_LIST_FLAG.DataPropertyName = "LIST_FLAG";
            this.dgv1_LIST_FLAG.FalseValue = "0";
            this.dgv1_LIST_FLAG.HeaderText = "LIST_FLAG";
            this.dgv1_LIST_FLAG.IndeterminateValue = "0";
            this.dgv1_LIST_FLAG.MinimumWidth = 60;
            this.dgv1_LIST_FLAG.Name = "dgv1_LIST_FLAG";
            this.dgv1_LIST_FLAG.TrueValue = "1";
            this.dgv1_LIST_FLAG.Width = 60;
            // 
            // dgv1_REQUIRED_FLAG
            // 
            this.dgv1_REQUIRED_FLAG.DataPropertyName = "REQUIRED_FLAG";
            this.dgv1_REQUIRED_FLAG.FalseValue = "0";
            this.dgv1_REQUIRED_FLAG.HeaderText = "REQUIRED_FLAG";
            this.dgv1_REQUIRED_FLAG.IndeterminateValue = "0";
            this.dgv1_REQUIRED_FLAG.MinimumWidth = 60;
            this.dgv1_REQUIRED_FLAG.Name = "dgv1_REQUIRED_FLAG";
            this.dgv1_REQUIRED_FLAG.TrueValue = "1";
            this.dgv1_REQUIRED_FLAG.Width = 60;
            // 
            // dgv1_NUMERIC_FLAG
            // 
            this.dgv1_NUMERIC_FLAG.DataPropertyName = "NUMERIC_FLAG";
            this.dgv1_NUMERIC_FLAG.FalseValue = "0";
            this.dgv1_NUMERIC_FLAG.HeaderText = "NUMERIC_FLAG";
            this.dgv1_NUMERIC_FLAG.IndeterminateValue = "0";
            this.dgv1_NUMERIC_FLAG.MinimumWidth = 60;
            this.dgv1_NUMERIC_FLAG.Name = "dgv1_NUMERIC_FLAG";
            this.dgv1_NUMERIC_FLAG.TrueValue = "1";
            this.dgv1_NUMERIC_FLAG.Width = 60;
            // 
            // dgv1_USING_CNT
            // 
            this.dgv1_USING_CNT.HeaderText = "USING_CNT";
            this.dgv1_USING_CNT.MaxInputLength = 1000;
            this.dgv1_USING_CNT.MinimumWidth = 100;
            this.dgv1_USING_CNT.Name = "dgv1_USING_CNT";
            this.dgv1_USING_CNT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv2_TCODE,
            this.dgv2_NM,
            this.dgv2_LIST_FLAG,
            this.dgv2_REQUIRED_FLAG,
            this.dgv2_NUMERIC_FLAG,
            this.dgv2_BTNADD});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(853, 53);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // splitContainer2
            // 
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
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
            this.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSave.Location = new System.Drawing.Point(7, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

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
            // dgv2_TCODE
            // 
            this.dgv2_TCODE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgv2_TCODE.HeaderText = "TCODE";
            this.dgv2_TCODE.MaxInputLength = 1000;
            this.dgv2_TCODE.MinimumWidth = 100;
            this.dgv2_TCODE.Name = "dgv2_TCODE";
            // 
            // dgv2_NM
            // 
            this.dgv2_NM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgv2_NM.HeaderText = "NM";
            this.dgv2_NM.MaxInputLength = 1000;
            this.dgv2_NM.MinimumWidth = 150;
            this.dgv2_NM.Name = "dgv2_NM";
            // 
            // dgv2_LIST_FLAG
            // 
            this.dgv2_LIST_FLAG.FalseValue = "0";
            this.dgv2_LIST_FLAG.HeaderText = "LIST_FLAG";
            this.dgv2_LIST_FLAG.IndeterminateValue = "0";
            this.dgv2_LIST_FLAG.MinimumWidth = 60;
            this.dgv2_LIST_FLAG.Name = "dgv2_LIST_FLAG";
            this.dgv2_LIST_FLAG.TrueValue = "1";
            this.dgv2_LIST_FLAG.Width = 60;
            // 
            // dgv2_REQUIRED_FLAG
            // 
            this.dgv2_REQUIRED_FLAG.FalseValue = "0";
            this.dgv2_REQUIRED_FLAG.HeaderText = "REQUIRED_FLAG";
            this.dgv2_REQUIRED_FLAG.IndeterminateValue = "0";
            this.dgv2_REQUIRED_FLAG.MinimumWidth = 60;
            this.dgv2_REQUIRED_FLAG.Name = "dgv2_REQUIRED_FLAG";
            this.dgv2_REQUIRED_FLAG.TrueValue = "1";
            this.dgv2_REQUIRED_FLAG.Width = 60;
            // 
            // dgv2_NUMERIC_FLAG
            // 
            this.dgv2_NUMERIC_FLAG.FalseValue = "0";
            this.dgv2_NUMERIC_FLAG.HeaderText = "NUMERIC_FLAG";
            this.dgv2_NUMERIC_FLAG.IndeterminateValue = "0";
            this.dgv2_NUMERIC_FLAG.MinimumWidth = 60;
            this.dgv2_NUMERIC_FLAG.Name = "dgv2_NUMERIC_FLAG";
            this.dgv2_NUMERIC_FLAG.TrueValue = "1";
            this.dgv2_NUMERIC_FLAG.Width = 60;
            // 
            // dgv2_BTNADD
            // 
            this.dgv2_BTNADD.HeaderText = "";
            this.dgv2_BTNADD.MinimumWidth = 50;
            this.dgv2_BTNADD.Name = "dgv2_BTNADD";
            this.dgv2_BTNADD.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv2_BTNADD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgv2_BTNADD.Text = "Add";
            // 
            // FrmCodeTMainDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 601);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmCodeTMainDB";
            this.Text = "FrmCodeTMainDB";
            this.Load += new System.EventHandler(this.FrmCodeTMainDB_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
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


        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv2_TCODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv2_NM;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgv2_LIST_FLAG;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgv2_REQUIRED_FLAG;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgv2_NUMERIC_FLAG;
        private System.Windows.Forms.DataGridViewButtonColumn dgv2_BTNADD;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgv1_CHK;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_TCODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_TTYPE_SCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_NM;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgv1_LIST_FLAG;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgv1_REQUIRED_FLAG;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgv1_NUMERIC_FLAG;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_USING_CNT;
    }
}