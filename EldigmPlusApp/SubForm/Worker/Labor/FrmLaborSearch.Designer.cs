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
            this.btnSave = new System.Windows.Forms.Button();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.cmbCom = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dgv1_CHK = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgv1_LAB_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_USER_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_LAB_NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_BIRTH_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_MOBILE_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_FACE_PHOTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_CO_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_TEAM_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_JOB_CCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_BLOCK_CCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_LAB_STS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1_AUTH_CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(3, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.cmbCom);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.btnSave);
            this.splitContainer3.Size = new System.Drawing.Size(1037, 40);
            this.splitContainer3.SplitterDistance = 817;
            this.splitContainer3.TabIndex = 0;
            // 
            // cmbCom
            // 
            this.cmbCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCom.FormattingEnabled = true;
            this.cmbCom.Location = new System.Drawing.Point(12, 12);
            this.cmbCom.Name = "cmbCom";
            this.cmbCom.Size = new System.Drawing.Size(170, 20);
            this.cmbCom.TabIndex = 5;
            this.cmbCom.SelectedIndexChanged += new System.EventHandler(this.cmbCom_SelectedIndexChanged);
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
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(1037, 601);
            this.splitContainer1.SplitterDistance = 40;
            this.splitContainer1.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv1_CHK,
            this.dgv1_LAB_NO,
            this.dgv1_USER_NO,
            this.dgv1_LAB_NM,
            this.dgv1_BIRTH_DATE,
            this.dgv1_MOBILE_NO,
            this.dgv1_FACE_PHOTO,
            this.dgv1_CO_CD,
            this.dgv1_TEAM_CD,
            this.dgv1_JOB_CCD,
            this.dgv1_BLOCK_CCD,
            this.dgv1_LAB_STS,
            this.dgv1_AUTH_CD});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1037, 532);
            this.dataGridView1.TabIndex = 4;
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
            // dgv1_USER_NO
            // 
            this.dgv1_USER_NO.HeaderText = "USER_NO";
            this.dgv1_USER_NO.MinimumWidth = 100;
            this.dgv1_USER_NO.Name = "dgv1_USER_NO";
            // 
            // dgv1_LAB_NM
            // 
            this.dgv1_LAB_NM.HeaderText = "LAB_NM";
            this.dgv1_LAB_NM.MinimumWidth = 150;
            this.dgv1_LAB_NM.Name = "dgv1_LAB_NM";
            this.dgv1_LAB_NM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv1_LAB_NM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgv1_LAB_NM.Width = 150;
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
            this.dgv1_MOBILE_NO.HeaderText = "MOBILE_NO";
            this.dgv1_MOBILE_NO.Name = "dgv1_MOBILE_NO";
            // 
            // dgv1_FACE_PHOTO
            // 
            this.dgv1_FACE_PHOTO.HeaderText = "FACE_PHOTO";
            this.dgv1_FACE_PHOTO.Name = "dgv1_FACE_PHOTO";
            // 
            // dgv1_CO_CD
            // 
            this.dgv1_CO_CD.HeaderText = "CO_CD";
            this.dgv1_CO_CD.Name = "dgv1_CO_CD";
            // 
            // dgv1_TEAM_CD
            // 
            this.dgv1_TEAM_CD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgv1_TEAM_CD.HeaderText = "TEAM_CD";
            this.dgv1_TEAM_CD.MinimumWidth = 150;
            this.dgv1_TEAM_CD.Name = "dgv1_TEAM_CD";
            // 
            // dgv1_JOB_CCD
            // 
            this.dgv1_JOB_CCD.HeaderText = "JOB_CCD";
            this.dgv1_JOB_CCD.Name = "dgv1_JOB_CCD";
            // 
            // dgv1_BLOCK_CCD
            // 
            this.dgv1_BLOCK_CCD.HeaderText = "BLOCK_CCD";
            this.dgv1_BLOCK_CCD.Name = "dgv1_BLOCK_CCD";
            // 
            // dgv1_LAB_STS
            // 
            this.dgv1_LAB_STS.HeaderText = "LAB_STS";
            this.dgv1_LAB_STS.Name = "dgv1_LAB_STS";
            // 
            // dgv1_AUTH_CD
            // 
            this.dgv1_AUTH_CD.HeaderText = "AUTH_CD";
            this.dgv1_AUTH_CD.Name = "dgv1_AUTH_CD";
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
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbCom;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgv1_CHK;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_LAB_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_USER_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_LAB_NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_BIRTH_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_MOBILE_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_FACE_PHOTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_CO_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_TEAM_CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_JOB_CCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_BLOCK_CCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_LAB_STS;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1_AUTH_CD;
    }
}