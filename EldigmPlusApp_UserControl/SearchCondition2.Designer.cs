namespace EldigmPlusApp_UserControl
{
    partial class SearchCondition2
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cmbCom = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbInOut = new System.Windows.Forms.ComboBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(318, 10);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(98, 21);
            this.dateTimePicker2.TabIndex = 11;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(199, 10);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(98, 21);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // cmbCom
            // 
            this.cmbCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCom.FormattingEnabled = true;
            this.cmbCom.Location = new System.Drawing.Point(16, 10);
            this.cmbCom.Name = "cmbCom";
            this.cmbCom.Size = new System.Drawing.Size(170, 20);
            this.cmbCom.TabIndex = 9;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(423, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbInOut
            // 
            this.cmbInOut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInOut.FormattingEnabled = true;
            this.cmbInOut.Location = new System.Drawing.Point(508, 11);
            this.cmbInOut.Name = "cmbInOut";
            this.cmbInOut.Size = new System.Drawing.Size(121, 20);
            this.cmbInOut.TabIndex = 13;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(301, 15);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(14, 12);
            this.lbl1.TabIndex = 14;
            this.lbl1.Text = "~";
            // 
            // SearchCondition2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.cmbInOut);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.cmbCom);
            this.Name = "SearchCondition2";
            this.Size = new System.Drawing.Size(750, 40);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DateTimePicker dateTimePicker2;
        public System.Windows.Forms.DateTimePicker dateTimePicker1;
        public System.Windows.Forms.ComboBox cmbCom;
        public System.Windows.Forms.Button btnSearch;
        public System.Windows.Forms.ComboBox cmbInOut;
        private System.Windows.Forms.Label lbl1;
    }
}
