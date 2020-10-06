namespace EldigmPlusApp.SubForm.Sys.ComnCode
{
    partial class FrmComnCodeGrpMainDB
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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnSave = new System.Windows.Forms.Button();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dgv1_CHK = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgv1_CCODE_GRP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_CCODE_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_USING_FLAG = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgv1_SORT_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_MEMO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dgv2_CCODE_GRP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv2_CCODE_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv2_SORT_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv2_MEMO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv2_BTNADD = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
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
            this.splitContainer3.SplitterDistance = 503;
            this.splitContainer3.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv1_CHK,
            this.dgv1_CCODE_GRP,
            this.dgv1_CCODE_NM,
            this.dgv1_USING_FLAG,
            this.dgv1_SORT_NO,
            this.dgv1_MEMO});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1037, 503);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // dgv1_CHK-
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
            // dgv1_CCODE_GRP
            // 
            this.dgv1_CCODE_GRP.DataPropertyName = "CCODE_GRP";
            this.dgv1_CCODE_GRP.HeaderText = "CCODE_GRP";
            this.dgv1_CCODE_GRP.MaxInputLength = 100;
            this.dgv1_CCODE_GRP.MinimumWidth = 100;
            this.dgv1_CCODE_GRP.Name = "dgv1_CCODE_GRP";
            this.dgv1_CCODE_GRP.ReadOnly = true;
            // 
            // dgv1_CCODE_NM
            // 
            this.dgv1_CCODE_NM.DataPropertyName = "CCODE_NM";
            this.dgv1_CCODE_NM.HeaderText = "CCODE_NM";
            this.dgv1_CCODE_NM.MaxInputLength = 100;
            this.dgv1_CCODE_NM.MinimumWidth = 150;
            this.dgv1_CCODE_NM.Name = "dgv1_CCODE_NM";
            this.dgv1_CCODE_NM.ReadOnly = true;
            this.dgv1_CCODE_NM.Width = 150;
            // 
            // dgv1_USING_FLAG
            // 
            this.dgv1_USING_FLAG.DataPropertyName = "USING_FLAG";
            this.dgv1_USING_FLAG.FalseValue = "0";
            this.dgv1_USING_FLAG.HeaderText = "USING_FLAG";
            this.dgv1_USING_FLAG.IndeterminateValue = "0";
            this.dgv1_USING_FLAG.MinimumWidth = 60;
            this.dgv1_USING_FLAG.Name = "dgv1_USING_FLAG";
            this.dgv1_USING_FLAG.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv1_USING_FLAG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgv1_USING_FLAG.TrueValue = "1";
            this.dgv1_USING_FLAG.Width = 60;
            // 
            // dgv1_SORT_NO
            // 
            this.dgv1_SORT_NO.DataPropertyName = "SORT_NO";
            this.dgv1_SORT_NO.HeaderText = "SORT_NO";
            this.dgv1_SORT_NO.MaxInputLength = 100;
            this.dgv1_SORT_NO.MinimumWidth = 80;
            this.dgv1_SORT_NO.Name = "dgv1_SORT_NO";
            this.dgv1_SORT_NO.Width = 80;
            // 
            // dgv1_MEMO
            // 
            this.dgv1_MEMO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgv1_MEMO.DataPropertyName = "MEMO";
            this.dgv1_MEMO.HeaderText = "MEMO";
            this.dgv1_MEMO.MaxInputLength = 100;
            this.dgv1_MEMO.Name = "dgv1_MEMO";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv2_CCODE_GRP,
            this.dgv2_CCODE_NM,
            this.dgv2_SORT_NO,
            this.dgv2_MEMO,
            this.dgv2_BTNADD});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(1037, 50);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // dgv2_CCODE_GRP
            // 
            this.dgv2_CCODE_GRP.DataPropertyName = "CCODE_GRP";
            this.dgv2_CCODE_GRP.HeaderText = "CCODE_GRP";
            this.dgv2_CCODE_GRP.MaxInputLength = 1000;
            this.dgv2_CCODE_GRP.Name = "dgv2_CCODE_GRP";
            // 
            // dgv2_CCODE_NM
            // 
            this.dgv2_CCODE_NM.DataPropertyName = "CCODE_NM";
            this.dgv2_CCODE_NM.HeaderText = "CCODE_NM";
            this.dgv2_CCODE_NM.MaxInputLength = 1000;
            this.dgv2_CCODE_NM.Name = "dgv2_CCODE_NM";
            // 
            // dgv2_SORT_NO
            // 
            this.dgv2_SORT_NO.DataPropertyName = "SORT_NO";
            this.dgv2_SORT_NO.HeaderText = "SORT_NO";
            this.dgv2_SORT_NO.MaxInputLength = 1000;
            this.dgv2_SORT_NO.Name = "dgv2_SORT_NO";
            // 
            // dgv2_MEMO
            // 
            this.dgv2_MEMO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgv2_MEMO.HeaderText = "MEMO";
            this.dgv2_MEMO.MaxInputLength = 1000;
            this.dgv2_MEMO.Name = "dgv2_MEMO";
            // 
            // dgv2_BTNADD
            // 
            this.dgv2_BTNADD.HeaderText = "";
            this.dgv2_BTNADD.Name = "dgv2_BTNADD";
            this.dgv2_BTNADD.Text = "Add";
            // 
            // FrmComnCodeGrpMainDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 601);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmComnCodeGrpMainDB";
            this.Text = "FrmComnCodeGrpMainDB";
            this.Load += new System.EventHandler(this.FrmComnCodeGrpMainDB_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv2_CCODE_GRP;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv2_CCODE_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv2_SORT_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv2_MEMO;
        private System.Windows.Forms.DataGridViewButtonColumn dgv2_BTNADD;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgv1_CHK;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_CCODE_GRP;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_CCODE_NM;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgv1_USING_FLAG;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_SORT_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_MEMO;
    }
}