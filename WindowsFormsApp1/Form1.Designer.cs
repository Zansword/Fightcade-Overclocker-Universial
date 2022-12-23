
namespace WindowsFormsApp1
{
    partial class Mainwin
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cpustatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cpuvalue = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Autocheck = new System.Windows.Forms.CheckBox();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.button100 = new System.Windows.Forms.RadioButton();
            this.button150 = new System.Windows.Forms.RadioButton();
            this.button180 = new System.Windows.Forms.RadioButton();
            this.button200 = new System.Windows.Forms.RadioButton();
            this.button300 = new System.Windows.Forms.RadioButton();
            this.button400 = new System.Windows.Forms.RadioButton();
            this.button500 = new System.Windows.Forms.RadioButton();
            this.button533 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.cpuvalue2 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.backgroundWorker4 = new System.ComponentModel.BackgroundWorker();
            this.scanbyte = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 46);
            this.button1.TabIndex = 9;
            this.button1.Text = "Default\r\n(100%)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(96, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(79, 46);
            this.button2.TabIndex = 10;
            this.button2.Text = "Overclock\r\n(150%)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(11, 83);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(79, 46);
            this.button3.TabIndex = 11;
            this.button3.Text = "Overclock\r\n(180%)";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(96, 83);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(79, 46);
            this.button4.TabIndex = 12;
            this.button4.Text = "Overclock\r\n(200%)";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(11, 157);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(79, 46);
            this.button5.TabIndex = 13;
            this.button5.Text = "Overclock\r\n(300%)";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(96, 157);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(79, 46);
            this.button6.TabIndex = 14;
            this.button6.Text = "Overclock\r\n(400%)";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(11, 231);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(79, 46);
            this.button7.TabIndex = 15;
            this.button7.Text = "Overclock\r\n(500%)";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(96, 231);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(79, 46);
            this.button8.TabIndex = 16;
            this.button8.Text = "Overclock\r\n(533%)";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 339);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 269);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 12);
            this.label3.TabIndex = 27;
            this.label3.Text = "Status :";
            // 
            // cpustatus
            // 
            this.cpustatus.AutoSize = true;
            this.cpustatus.Location = new System.Drawing.Point(99, 269);
            this.cpustatus.Name = "cpustatus";
            this.cpustatus.Size = new System.Drawing.Size(0, 12);
            this.cpustatus.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 245);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 12);
            this.label2.TabIndex = 29;
            this.label2.Text = "Cpu    :";
            // 
            // cpuvalue
            // 
            this.cpuvalue.AutoSize = true;
            this.cpuvalue.Location = new System.Drawing.Point(99, 245);
            this.cpuvalue.Name = "cpuvalue";
            this.cpuvalue.Size = new System.Drawing.Size(0, 12);
            this.cpuvalue.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 293);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 12);
            this.label4.TabIndex = 32;
            this.label4.Text = "Auto    :";
            // 
            // Autocheck
            // 
            this.Autocheck.AutoSize = true;
            this.Autocheck.Location = new System.Drawing.Point(101, 292);
            this.Autocheck.Name = "Autocheck";
            this.Autocheck.Size = new System.Drawing.Size(63, 16);
            this.Autocheck.TabIndex = 33;
            this.Autocheck.Text = "Enable";
            this.Autocheck.UseVisualStyleBackColor = true;
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerReportsProgress = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker2_ProgressChanged);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // button100
            // 
            this.button100.AutoSize = true;
            this.button100.Location = new System.Drawing.Point(25, 61);
            this.button100.Name = "button100";
            this.button100.Size = new System.Drawing.Size(48, 16);
            this.button100.TabIndex = 35;
            this.button100.TabStop = true;
            this.button100.Text = "Auto";
            this.button100.UseVisualStyleBackColor = true;
            // 
            // button150
            // 
            this.button150.AutoSize = true;
            this.button150.Location = new System.Drawing.Point(111, 61);
            this.button150.Name = "button150";
            this.button150.Size = new System.Drawing.Size(48, 16);
            this.button150.TabIndex = 36;
            this.button150.TabStop = true;
            this.button150.Text = "Auto";
            this.button150.UseVisualStyleBackColor = true;
            // 
            // button180
            // 
            this.button180.AutoSize = true;
            this.button180.Location = new System.Drawing.Point(25, 135);
            this.button180.Name = "button180";
            this.button180.Size = new System.Drawing.Size(48, 16);
            this.button180.TabIndex = 37;
            this.button180.TabStop = true;
            this.button180.Text = "Auto";
            this.button180.UseVisualStyleBackColor = true;
            // 
            // button200
            // 
            this.button200.AutoSize = true;
            this.button200.Location = new System.Drawing.Point(111, 135);
            this.button200.Name = "button200";
            this.button200.Size = new System.Drawing.Size(48, 16);
            this.button200.TabIndex = 38;
            this.button200.TabStop = true;
            this.button200.Text = "Auto";
            this.button200.UseVisualStyleBackColor = true;
            // 
            // button300
            // 
            this.button300.AutoSize = true;
            this.button300.Location = new System.Drawing.Point(25, 209);
            this.button300.Name = "button300";
            this.button300.Size = new System.Drawing.Size(48, 16);
            this.button300.TabIndex = 39;
            this.button300.TabStop = true;
            this.button300.Text = "Auto";
            this.button300.UseVisualStyleBackColor = true;
            // 
            // button400
            // 
            this.button400.AutoSize = true;
            this.button400.Location = new System.Drawing.Point(111, 209);
            this.button400.Name = "button400";
            this.button400.Size = new System.Drawing.Size(48, 16);
            this.button400.TabIndex = 40;
            this.button400.TabStop = true;
            this.button400.Text = "Auto";
            this.button400.UseVisualStyleBackColor = true;
            // 
            // button500
            // 
            this.button500.AutoSize = true;
            this.button500.Location = new System.Drawing.Point(25, 283);
            this.button500.Name = "button500";
            this.button500.Size = new System.Drawing.Size(48, 16);
            this.button500.TabIndex = 41;
            this.button500.TabStop = true;
            this.button500.Text = "Auto";
            this.button500.UseVisualStyleBackColor = true;
            // 
            // button533
            // 
            this.button533.AutoSize = true;
            this.button533.Location = new System.Drawing.Point(111, 283);
            this.button533.Name = "button533";
            this.button533.Size = new System.Drawing.Size(48, 16);
            this.button533.TabIndex = 42;
            this.button533.TabStop = true;
            this.button533.Text = "Auto";
            this.button533.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.button533);
            this.groupBox1.Controls.Add(this.button500);
            this.groupBox1.Controls.Add(this.button400);
            this.groupBox1.Controls.Add(this.button300);
            this.groupBox1.Controls.Add(this.button200);
            this.groupBox1.Controls.Add(this.button180);
            this.groupBox1.Controls.Add(this.button150);
            this.groupBox1.Controls.Add(this.button100);
            this.groupBox1.Controls.Add(this.button8);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(275, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(188, 305);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            // 
            // cpuvalue2
            // 
            this.cpuvalue2.AutoSize = true;
            this.cpuvalue2.Location = new System.Drawing.Point(97, 245);
            this.cpuvalue2.Name = "cpuvalue2";
            this.cpuvalue2.Size = new System.Drawing.Size(28, 12);
            this.cpuvalue2.TabIndex = 44;
            this.cpuvalue2.Text = "N/A";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(32, 318);
            this.trackBar1.Maximum = 533;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(233, 45);
            this.trackBar1.TabIndex = 45;
            this.trackBar1.TickFrequency = 533;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Value = 10;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(286, 320);
            this.textBox1.MaxLength = 500;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(58, 21);
            this.textBox1.TabIndex = 46;
            this.textBox1.Text = "10";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(350, 323);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 12);
            this.label5.TabIndex = 47;
            this.label5.Text = "%";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(371, 319);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(79, 21);
            this.button9.TabIndex = 48;
            this.button9.Text = "OK";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click_1);
            // 
            // scanbyte
            // 
            this.scanbyte.Location = new System.Drawing.Point(183, 187);
            this.scanbyte.Name = "scanbyte";
            this.scanbyte.Size = new System.Drawing.Size(54, 24);
            this.scanbyte.TabIndex = 34;
            this.scanbyte.Text = "Scan!";
            this.scanbyte.UseVisualStyleBackColor = true;
            this.scanbyte.Click += new System.EventHandler(this.button9_Click);
            // 
            // Mainwin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 403);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.cpuvalue2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Autocheck);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cpuvalue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cpustatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.scanbyte);
            this.Name = "Mainwin";
            this.ShowIcon = false;
            this.Text = "Fightcade FBNeo Overclocker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label cpustatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label cpuvalue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox Autocheck;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.RadioButton button100;
        private System.Windows.Forms.RadioButton button150;
        private System.Windows.Forms.RadioButton button180;
        private System.Windows.Forms.RadioButton button200;
        private System.Windows.Forms.RadioButton button300;
        private System.Windows.Forms.RadioButton button400;
        private System.Windows.Forms.RadioButton button500;
        private System.Windows.Forms.RadioButton button533;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private System.Windows.Forms.Label cpuvalue2;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button9;
        private System.ComponentModel.BackgroundWorker backgroundWorker4;
        private System.Windows.Forms.Button scanbyte;
    }
}

