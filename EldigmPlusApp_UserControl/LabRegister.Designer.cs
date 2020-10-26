namespace EldigmPlusApp_UserControl
{
    partial class LabRegister
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
            this.btnFile = new System.Windows.Forms.Button();
            this.btnCamera = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblJoinCom = new System.Windows.Forms.Label();
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblNameEng = new System.Windows.Forms.Label();
            this.lblNameKor = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.lblCom = new System.Windows.Forms.Label();
            this.TeamCmb = new System.Windows.Forms.ComboBox();
            this.JoinCom_DatePicker = new System.Windows.Forms.DateTimePicker();
            this.Birth_DatePicker = new System.Windows.Forms.DateTimePicker();
            this.JobSubTxt = new System.Windows.Forms.TextBox();
            this.RfidCarTxt = new System.Windows.Forms.TextBox();
            this.RfidTxt = new System.Windows.Forms.TextBox();
            this.PinTxt = new System.Windows.Forms.TextBox();
            this.AdressTxt = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PhoneTxt = new System.Windows.Forms.TextBox();
            this.NameEngTxt = new System.Windows.Forms.TextBox();
            this.NameKorTxt = new System.Windows.Forms.TextBox();
            this.IdNumTxt = new System.Windows.Forms.TextBox();
            this.ComCmb = new System.Windows.Forms.ComboBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.JobCmb = new System.Windows.Forms.ComboBox();
            this.LabDetail = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.LabDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(458, 228);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(75, 23);
            this.btnFile.TabIndex = 34;
            this.btnFile.Text = "파일";
            this.btnFile.UseVisualStyleBackColor = true;
            // 
            // btnCamera
            // 
            this.btnCamera.Location = new System.Drawing.Point(371, 228);
            this.btnCamera.Name = "btnCamera";
            this.btnCamera.Size = new System.Drawing.Size(75, 23);
            this.btnCamera.TabIndex = 33;
            this.btnCamera.Text = "카메라";
            this.btnCamera.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(338, 411);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(17, 12);
            this.label14.TabIndex = 32;
            this.label14.Text = "팀";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(176, 411);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 12);
            this.label13.TabIndex = 31;
            this.label13.Text = "직종(서브)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 411);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 30;
            this.label12.Text = "직종";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(338, 342);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 12);
            this.label11.TabIndex = 29;
            this.label11.Text = "RFID CAR";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(172, 342);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 12);
            this.label10.TabIndex = 28;
            this.label10.Text = "RFID";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 342);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 12);
            this.label9.TabIndex = 27;
            this.label9.Text = "PIN";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 255);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 26;
            this.label8.Text = "주소";
            // 
            // lblJoinCom
            // 
            this.lblJoinCom.AutoSize = true;
            this.lblJoinCom.Location = new System.Drawing.Point(237, 198);
            this.lblJoinCom.Name = "lblJoinCom";
            this.lblJoinCom.Size = new System.Drawing.Size(51, 12);
            this.lblJoinCom.TabIndex = 25;
            this.lblJoinCom.Text = "* 입사일";
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.AutoSize = true;
            this.lblBirthDate.Location = new System.Drawing.Point(124, 198);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(63, 12);
            this.lblBirthDate.TabIndex = 24;
            this.lblBirthDate.Text = "* 생년월일";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(8, 198);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(51, 12);
            this.lblPhone.TabIndex = 23;
            this.lblPhone.Text = "* 연락처";
            // 
            // lblNameEng
            // 
            this.lblNameEng.AutoSize = true;
            this.lblNameEng.Location = new System.Drawing.Point(172, 140);
            this.lblNameEng.Name = "lblNameEng";
            this.lblNameEng.Size = new System.Drawing.Size(67, 12);
            this.lblNameEng.TabIndex = 22;
            this.lblNameEng.Text = " 이름(영문)";
            // 
            // lblNameKor
            // 
            this.lblNameKor.AutoSize = true;
            this.lblNameKor.Location = new System.Drawing.Point(8, 140);
            this.lblNameKor.Name = "lblNameKor";
            this.lblNameKor.Size = new System.Drawing.Size(73, 12);
            this.lblNameKor.TabIndex = 21;
            this.lblNameKor.Text = "* 이름(국문)";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(8, 60);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(54, 12);
            this.lblId.TabIndex = 20;
            this.lblId.Text = "* ID 번호";
            // 
            // lblCom
            // 
            this.lblCom.AutoSize = true;
            this.lblCom.Location = new System.Drawing.Point(8, 13);
            this.lblCom.Name = "lblCom";
            this.lblCom.Size = new System.Drawing.Size(39, 12);
            this.lblCom.TabIndex = 19;
            this.lblCom.Text = "* 업체";
            // 
            // TeamCmb
            // 
            this.TeamCmb.FormattingEnabled = true;
            this.TeamCmb.Location = new System.Drawing.Point(340, 427);
            this.TeamCmb.Name = "TeamCmb";
            this.TeamCmb.Size = new System.Drawing.Size(160, 20);
            this.TeamCmb.TabIndex = 18;
            // 
            // JoinCom_DatePicker
            // 
            this.JoinCom_DatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.JoinCom_DatePicker.Location = new System.Drawing.Point(239, 213);
            this.JoinCom_DatePicker.Name = "JoinCom_DatePicker";
            this.JoinCom_DatePicker.Size = new System.Drawing.Size(107, 21);
            this.JoinCom_DatePicker.TabIndex = 16;
            // 
            // Birth_DatePicker
            // 
            this.Birth_DatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Birth_DatePicker.Location = new System.Drawing.Point(126, 213);
            this.Birth_DatePicker.Name = "Birth_DatePicker";
            this.Birth_DatePicker.Size = new System.Drawing.Size(107, 21);
            this.Birth_DatePicker.TabIndex = 15;
            // 
            // JobSubTxt
            // 
            this.JobSubTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.JobSubTxt.Location = new System.Drawing.Point(174, 426);
            this.JobSubTxt.Name = "JobSubTxt";
            this.JobSubTxt.Size = new System.Drawing.Size(160, 21);
            this.JobSubTxt.TabIndex = 13;
            // 
            // RfidCarTxt
            // 
            this.RfidCarTxt.Location = new System.Drawing.Point(338, 357);
            this.RfidCarTxt.Name = "RfidCarTxt";
            this.RfidCarTxt.Size = new System.Drawing.Size(112, 21);
            this.RfidCarTxt.TabIndex = 11;
            // 
            // RfidTxt
            // 
            this.RfidTxt.Location = new System.Drawing.Point(174, 357);
            this.RfidTxt.Name = "RfidTxt";
            this.RfidTxt.Size = new System.Drawing.Size(112, 21);
            this.RfidTxt.TabIndex = 10;
            // 
            // PinTxt
            // 
            this.PinTxt.Location = new System.Drawing.Point(8, 357);
            this.PinTxt.Name = "PinTxt";
            this.PinTxt.Size = new System.Drawing.Size(112, 21);
            this.PinTxt.TabIndex = 9;
            // 
            // AdressTxt
            // 
            this.AdressTxt.Location = new System.Drawing.Point(8, 270);
            this.AdressTxt.Name = "AdressTxt";
            this.AdressTxt.Size = new System.Drawing.Size(545, 21);
            this.AdressTxt.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(371, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(162, 194);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // PhoneTxt
            // 
            this.PhoneTxt.Location = new System.Drawing.Point(8, 213);
            this.PhoneTxt.Name = "PhoneTxt";
            this.PhoneTxt.Size = new System.Drawing.Size(112, 21);
            this.PhoneTxt.TabIndex = 4;
            // 
            // NameEngTxt
            // 
            this.NameEngTxt.Location = new System.Drawing.Point(174, 155);
            this.NameEngTxt.Name = "NameEngTxt";
            this.NameEngTxt.Size = new System.Drawing.Size(160, 21);
            this.NameEngTxt.TabIndex = 3;
            // 
            // NameKorTxt
            // 
            this.NameKorTxt.Location = new System.Drawing.Point(8, 155);
            this.NameKorTxt.Name = "NameKorTxt";
            this.NameKorTxt.Size = new System.Drawing.Size(160, 21);
            this.NameKorTxt.TabIndex = 2;
            // 
            // IdNumTxt
            // 
            this.IdNumTxt.Location = new System.Drawing.Point(8, 75);
            this.IdNumTxt.Name = "IdNumTxt";
            this.IdNumTxt.Size = new System.Drawing.Size(215, 21);
            this.IdNumTxt.TabIndex = 1;
            // 
            // ComCmb
            // 
            this.ComCmb.FormattingEnabled = true;
            this.ComCmb.Location = new System.Drawing.Point(8, 28);
            this.ComCmb.Name = "ComCmb";
            this.ComCmb.Size = new System.Drawing.Size(215, 20);
            this.ComCmb.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnFile);
            this.tabPage1.Controls.Add(this.btnCamera);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.lblJoinCom);
            this.tabPage1.Controls.Add(this.lblBirthDate);
            this.tabPage1.Controls.Add(this.lblPhone);
            this.tabPage1.Controls.Add(this.lblNameEng);
            this.tabPage1.Controls.Add(this.lblNameKor);
            this.tabPage1.Controls.Add(this.lblId);
            this.tabPage1.Controls.Add(this.lblCom);
            this.tabPage1.Controls.Add(this.TeamCmb);
            this.tabPage1.Controls.Add(this.JobCmb);
            this.tabPage1.Controls.Add(this.JoinCom_DatePicker);
            this.tabPage1.Controls.Add(this.Birth_DatePicker);
            this.tabPage1.Controls.Add(this.JobSubTxt);
            this.tabPage1.Controls.Add(this.RfidCarTxt);
            this.tabPage1.Controls.Add(this.RfidTxt);
            this.tabPage1.Controls.Add(this.PinTxt);
            this.tabPage1.Controls.Add(this.AdressTxt);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.PhoneTxt);
            this.tabPage1.Controls.Add(this.NameEngTxt);
            this.tabPage1.Controls.Add(this.NameKorTxt);
            this.tabPage1.Controls.Add(this.IdNumTxt);
            this.tabPage1.Controls.Add(this.ComCmb);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(587, 687);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "인원정보";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // JobCmb
            // 
            this.JobCmb.FormattingEnabled = true;
            this.JobCmb.Location = new System.Drawing.Point(8, 426);
            this.JobCmb.Name = "JobCmb";
            this.JobCmb.Size = new System.Drawing.Size(159, 20);
            this.JobCmb.TabIndex = 17;
            // 
            // LabDetail
            // 
            this.LabDetail.Controls.Add(this.tabPage1);
            this.LabDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabDetail.Location = new System.Drawing.Point(0, 0);
            this.LabDetail.Name = "LabDetail";
            this.LabDetail.SelectedIndex = 0;
            this.LabDetail.Size = new System.Drawing.Size(595, 713);
            this.LabDetail.TabIndex = 4;
            this.LabDetail.Tag = "";
            // 
            // LabRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LabDetail);
            this.Name = "LabRegister";
            this.Size = new System.Drawing.Size(595, 713);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.LabDetail.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.Button btnCamera;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblJoinCom;
        private System.Windows.Forms.Label lblBirthDate;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblNameEng;
        private System.Windows.Forms.Label lblNameKor;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblCom;
        private System.Windows.Forms.ComboBox TeamCmb;
        private System.Windows.Forms.TextBox IdNumTxt;
        private System.Windows.Forms.TabControl LabDetail;
        public System.Windows.Forms.DateTimePicker JoinCom_DatePicker;
        public System.Windows.Forms.DateTimePicker Birth_DatePicker;
        public System.Windows.Forms.TextBox JobSubTxt;
        public System.Windows.Forms.TextBox RfidCarTxt;
        public System.Windows.Forms.TextBox RfidTxt;
        public System.Windows.Forms.TextBox PinTxt;
        public System.Windows.Forms.TextBox AdressTxt;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.TextBox PhoneTxt;
        public System.Windows.Forms.TextBox NameEngTxt;
        public System.Windows.Forms.TextBox NameKorTxt;
        public System.Windows.Forms.ComboBox ComCmb;
        public System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.ComboBox JobCmb;
    }
}
