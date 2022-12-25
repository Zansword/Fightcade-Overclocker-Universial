using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory;

namespace WindowsFormsApp1
{
    public partial class Mainwin : Form
    {

        public Mem m = new Mem();

        public Mainwin()
        {
            InitializeComponent();
        }

        bool ProcOpen = false;
        bool ProcOpen2 = false;
        bool backwork1 = true; // fc1 scan
        bool backwork2 = true; // fc2 scan
//        bool backwork3 = true;
//        bool backwork4 = true;
        int fc1pid = 0;
        int fc2pid = 0;
        int fc1dec = 0;
        int fc2dec = 0;
        long fc1SingleAoBScanResult;
        long fc2SingleAoBScanResult;
        string fc1memory = null;
        string fc2memory = null;
        string fc1hex = null;
        string fc2hex = null;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Using_TrackBar2_Load(object sender, EventArgs e)
        {
            trackBar2.Value = 100;
        }

        //**********************************************************************************************************//
        // 백그라운드 작업 - 프로세스 id 검색 및 attach // fc1

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (backwork1 == true)
                {
                    fc1pid = m.GetProcIdFromName("ggpofba-ng");

                    if (fc1pid != 0)
                    {
                        ProcOpen = true;
                        m.OpenProcess("ggpofba-ng");
                        backgroundWorker1.ReportProgress(0);
                        Thread.Sleep(1000);
                        return;
                    }

                    else if (fc1pid == 0)
                    {
                        ProcOpen = false;
                        backgroundWorker1.ReportProgress(0);
                        Thread.Sleep(1000);
                        return;
                    }

                }

                else if (backwork1 == false)
                {
                    backgroundWorker1.ReportProgress(0);
                    Thread.Sleep(1000);
                    return;
                }
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (backwork1 == true)
            {
                if (!m.OpenProcess("ggpofba-ng"))
                {
                    ProcOpen = false;
                    fc1status.Text = "No Emulator Works";
                    fc1dec = 0;
                    fc1memory = null;
                    fc1hex = null;
                }

                if (m.OpenProcess("ggpofba-ng"))
                {
                    ProcOpen = true;
                    backwork1 = false;
                    fc1status.Text = "Emulator Detected!";
                    fc1Scan();
                }
            }

            if (backwork1 == false)
            {
                if (!m.OpenProcess("ggpofba-ng"))
                {
                    ProcOpen = false;
                    backwork1 = true;
                }
            }

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        //**********************************************************************************************************//
        // 백그라운드 작업 - 프로세스 id 검색 및 attach // fc2

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            if (backwork2 == true)
            {
                fc2pid = m.GetProcIdFromName("fcadefbneo");

                if (fc2pid != 0)
                {
                    ProcOpen2 = true;
                    m.OpenProcess("fcadefbneo");
                    backgroundWorker2.ReportProgress(0);
                    Thread.Sleep(1000);
                    return;
                }

                else if (fc2pid == 0)
                {
                    ProcOpen2 = false;
                    backgroundWorker2.ReportProgress(0);
                    Thread.Sleep(1000);
                    return;
                }

            }

            else if (backwork2 == false)
            {
                backgroundWorker2.ReportProgress(0);
                Thread.Sleep(1000);
                return;
            }
        }


        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (backwork2 == true)
            {

                if (!m.OpenProcess("fcadefbneo"))
                {
                    ProcOpen2 = false;
                    fc2status.Text = "No Emulator Works";
                    fc2dec = 0;
                    fc2memory = null;
                    fc2hex = null;
                }

                if (m.OpenProcess("fcadefbneo"))
                {
                    ProcOpen2 = true;
                    backwork2 = false;
                    fc2status.Text = "Emulator Detected!";
                    fc2Scan();
                }

            }

            if (backwork2 == false)
            {
                if (!m.OpenProcess("fcadefbneo"))
                {
                    ProcOpen2 = false;
                    backwork2 = true;
                }
            }
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            backgroundWorker2.RunWorkerAsync();
        }

        //**********************************************************************************************************//
        // Array Of Byte 스캔 - 범용으로 만들기 위해서는 필수
        // this function is async, which means it does not block other code
        //reference : https://www.delftstack.com/ko/howto/csharp/integer-to-hexadecimal-in-csharp/

        public async void fc1Scan()
        {
            if (!m.OpenProcess("ggpofba-ng"))
            {
                MessageBox.Show("Process Is Not Found or Open!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            IEnumerable<long> fc1AoBScanResults = await m.AoBScan("?? ?? 00 00 01 00 00 00 FF FF 01 01", true, true, true);
            fc1SingleAoBScanResult = fc1AoBScanResults.FirstOrDefault();

            fc1memory = fc1SingleAoBScanResult.ToString("X"); //16진수 메모리주소
            fc1dec = Int32.Parse(m.Read2Byte(fc1SingleAoBScanResult.ToString("X")).ToString()); //10진수256(100%)
            fc1hex = fc1dec.ToString("X"); // 16진수 100(256)
        }

        public async void fc2Scan()
        {
            if (!m.OpenProcess("fcadefbneo"))
            {
                MessageBox.Show("Process Is Not Found or Open!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            IEnumerable<long> fc2AoBScanResults = await m.AoBScan("?? ?? 00 00 44 97 02", true, true, true);
            fc2SingleAoBScanResult = fc2AoBScanResults.FirstOrDefault();

            fc2memory = fc2SingleAoBScanResult.ToString("X"); //16진수 메모리주소
            fc2dec = Int32.Parse(m.Read2Byte(fc2SingleAoBScanResult.ToString("X")).ToString()); //10진수256(100%)
            fc2hex = fc2dec.ToString("X"); // 16진수 100(256)
        }

        // NOT NOW, BUT SOMEDAY...
        //MessageBox.Show("Our First Found Address is " + SingleAoBScanResult); // 메모리주소 발견
        //MessageBox.Show("Value for our address is " + m.Read2Byte(SingleAoBScanResult.ToString("X")).ToString()); // 10진수 표현
        //MessageBox.Show("Value for our address is " + Convert.ToString(m.Read2Byte(SingleAoBScanResult.ToString("X")), 16)); // aob스캐닝 및 100 표현 성공
        //MessageBox.Show("Our First Found Address is " + memory);
        //MessageBox.Show("Emulator current cpu value is " + cpudec + "(" + cpuhex + "%)");

        //**********************************************************************************************************//
        // 스캔버튼 및 UI 기능(fc1)

        private void fc1scanbutton_Click(object sender, EventArgs e)
        {
            Task taskA = new Task(() => fc1Scan());
            taskA.Start();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            textBox2.Text = "" + trackBar2.Value;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.Text = "0";
            }
            if (Convert.ToInt32(textBox2.Text) > 533)
            {
                textBox2.Text = "533";
            }
            trackBar2.Value = Convert.ToInt32(textBox2.Text);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ProcOpen)
            {
                fc1status.Text = "Emulator is not opened!";
                fc1value.Text = "N/A";
                return;
            }

            String fc1percent = Convert.ToString(textBox1.Text);
            int fc1value2 = Convert.ToInt32(fc1percent, 16);
            string cpuvaluefc1 = Convert.ToString(fc1value2);
            fc1dec = fc1value2;

            m.WriteMemory(fc1memory, "int", cpuvaluefc1);
            fc1status.Text = "Overclocked with " + fc1percent + " %";
            fc1value.Text = fc1percent + " %";
            return;
        }

        private void fc1ok_Click(object sender, EventArgs e)
        {
            if (!ProcOpen)
            {
                fc1status.Text = "Emulator is not opened!";
                fc1value.Text = "N/A";
                return;
            }

            String fc1percent = Convert.ToString(textBox2.Text);
            int fc1value2 = Convert.ToInt32(fc1percent, 16);
            string cpuvaluefc1 = Convert.ToString(fc1value2);
            fc1dec = fc1value2;

            m.WriteMemory(fc1memory, "int", cpuvaluefc1);
            fc1status.Text = "Overclocked with " + fc1percent + " %";
            fc1value.Text = fc1percent + " %";
            return;
        }

//**********************************************************************************************************//
// 클럭 버튼 기능(fc1)	

        private void fc1btn1_Click(object sender, EventArgs e)
        {
            if (!ProcOpen)
            {
                fc1status.Text = "Emulator is not opened!";
                fc1value.Text = "N/A";
                return;
            }

            m.WriteMemory(fc1memory, "int", "256");
            fc1status.Text = "Overclock Disabled";
            fc1value.Text = "100%";
            fc1dec = 256;
        }

        private void fc1btn2_Click(object sender, EventArgs e)
        {
            if (!ProcOpen)
            {
                fc1status.Text = "Emulator is not opened!";
                fc1value.Text = "N/A";
                return;
            }

            m.WriteMemory(fc1memory, "int", "336");
            fc1status.Text = "Overclocked with 150%";
            fc1value.Text = "150%";
            fc1dec = 336;
        }

        private void fc1btn3_Click(object sender, EventArgs e)
        {
            if (!ProcOpen)
            {
                fc1status.Text = "Emulator is not opened!";
                fc1value.Text = "N/A";
                return;
            }

            m.WriteMemory(fc1memory, "int", "384");
            fc1status.Text = "Overclocked with 180%";
            fc1value.Text = "180%";
            fc1dec = 384;
        }

        private void fc1btn4_Click(object sender, EventArgs e)
        {
            if (!ProcOpen)
            {
                fc1status.Text = "Emulator is not opened!";
                fc1value.Text = "N/A";
                return;
            }

            m.WriteMemory(fc1memory, "int", "512");
            fc1status.Text = "Overclocked with 200%";
            fc1value.Text = "200%";
            fc1dec = 512;
        }

        private void fc1btn5_Click(object sender, EventArgs e)
        {
            if (!ProcOpen)
            {
                fc1status.Text = "Emulator is not opened!";
                fc1value.Text = "N/A";
                return;
            }

            m.WriteMemory(fc1memory, "int", "768");
            fc1status.Text = "Overclocked with 300%";
            fc1value.Text = "300%";
            fc1dec = 768;
        }

        private void fc1btn6_Click(object sender, EventArgs e)
        {
            if (!ProcOpen)
            {
                fc1status.Text = "Emulator is not opened!";
                fc1value.Text = "N/A";
                return;
            }

            m.WriteMemory(fc1memory, "int", "1024");
            fc1status.Text = "Overclocked with 400%";
            fc1value.Text = "400%";
            fc1dec = 1024;
        }

        private void fc1btn7_Click(object sender, EventArgs e)
        {
            if (!ProcOpen)
            {
                fc1status.Text = "Emulator is not opened!";
                fc1value.Text = "N/A";
                return;
            }

            m.WriteMemory(fc1memory, "int", "1280");
            fc1status.Text = "Overclocked with 500%";
            fc1value.Text = "500%";
            fc1dec = 1280;
        }

        private void fc1btn8_Click(object sender, EventArgs e)
        {
            if (!ProcOpen)
            {
                fc1status.Text = "Emulator is not opened!";
                fc1value.Text = "N/A";
                return;
            }

            m.WriteMemory(fc1memory, "int", "1331");
            fc1status.Text = "Overclocked with 533%";
            fc1value.Text = "533%";
            fc1dec = 1331;
        }

//**********************************************************************************************************//
// 클럭 버튼 기능(fc2)

        private void fc2btn1_Click(object sender, EventArgs e)
        {
            if (!ProcOpen2)
            {
                fc2status.Text = "Emulator is not opened!";
                fc2value.Text = "N/A";
                return;
            }

            m.WriteMemory(fc2memory, "int", "256");
            fc2status.Text = "Overclock Disabled";
            fc2value.Text = "100%";
            fc2dec = 256;
        }

        private void fc2btn2_Click(object sender, EventArgs e)
        {
            if (!ProcOpen2)
            {
                fc2status.Text = "Emulator is not opened!";
                fc2value.Text = "N/A";
                return;
            }

            m.WriteMemory(fc2memory, "int", "336");
            fc2status.Text = "Overclocked with 150%";
            fc2value.Text = "150%";
            fc2dec = 336;
        }

        private void fc2btn3_Click(object sender, EventArgs e)
        {
            if (!ProcOpen2)
            {
                fc2status.Text = "Emulator is not opened!";
                fc2value.Text = "N/A";
                return;
            }

            m.WriteMemory(fc2memory, "int", "384");
            fc2status.Text = "Overclocked with 180%";
            fc2value.Text = "180%";
            fc2dec = 384;
        }

        private void fc2btn4_Click(object sender, EventArgs e)
        {
            if (!ProcOpen2)
            {
                fc2status.Text = "Emulator is not opened!";
                fc2value.Text = "N/A";
                return;
            }

            m.WriteMemory(fc2memory, "int", "512");
            fc2status.Text = "Overclocked with 200%";
            fc2value.Text = "200%";
            fc2dec = 512;
        }

        private void fc2btn5_Click(object sender, EventArgs e)
        {
            if (!ProcOpen2)
            {
                fc2status.Text = "Emulator is not opened!";
                fc2value.Text = "N/A";
                return;
            }

            m.WriteMemory(fc2memory, "int", "768");
            fc2status.Text = "Overclocked with 300%";
            fc2value.Text = "300%";
            fc2dec = 768;
        }

        private void fc2btn6_Click(object sender, EventArgs e)
        {
            if (!ProcOpen2)
            {
                fc2status.Text = "Emulator is not opened!";
                fc2value.Text = "N/A";
                return;
            }

            m.WriteMemory(fc2memory, "int", "1024");
            fc2status.Text = "Overclocked with 400%";
            fc2value.Text = "400%";
            fc2dec = 1024;
        }

        private void fc2btn7_Click(object sender, EventArgs e)
        {
            if (!ProcOpen2)
            {
                fc2status.Text = "Emulator is not opened!";
                fc2value.Text = "N/A";
                return;
            }

            m.WriteMemory(fc2memory, "int", "1280");
            fc2status.Text = "Overclocked with 500%";
            fc2value.Text = "500%";
            fc2dec = 1280;
        }

        private void fc2btn8_Click(object sender, EventArgs e)
        {
            if (!ProcOpen2)
            {
                fc2status.Text = "Emulator is not opened!";
                fc2value.Text = "N/A";
                return;
            }

            m.WriteMemory(fc2memory, "int", "1331");
            fc2status.Text = "Overclocked with 533%";
            fc2value.Text = "533%";
            fc2dec = 1331;
        }

//**********************************************************************************************************//
// 슬라이더(fc2)

        private void fc2scan2_Click(object sender, EventArgs e)
        {
            Task taskB = new Task(() => fc2Scan());
            taskB.Start();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox1.Text = "" + trackBar1.Value;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Text = "0";
            }
            if (Convert.ToInt32(textBox1.Text) > 533)
            {
                textBox1.Text = "533";
            }
            trackBar1.Value = Convert.ToInt32(textBox1.Text);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (!ProcOpen2)
            {
                fc2status.Text = "Emulator is not opened!";
                fc2value.Text = "N/A";
                return;
            }

            String fc2percent = Convert.ToString(textBox1.Text);
            int fc2value2 = Convert.ToInt32(fc2percent, 16);
            string cpuvaluefc2 = Convert.ToString(fc2value2);
            fc2dec = fc2value2;

            m.WriteMemory(fc2memory, "int", cpuvaluefc2);
            fc2status.Text = "Overclocked with " + fc2percent + " %";
            fc2value.Text = fc2percent + " %";
            return;
        }


//**********************************************************************************************************//
// cpu 오토로 설정하기 FC1

        private void backgroundWorker3_DoWork_1(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                backgroundWorker3.ReportProgress(0);
                Thread.Sleep(1000);
                return;
            }
        }
        
        private void backgroundWorker3_ProgressChanged_1(object sender, ProgressChangedEventArgs e)
        {
            if (Autocheckfc1.Checked == true)
            {

                if (fc1100.Checked == true && fc1dec != 256)
                {
                    fc1btn1.PerformClick();
                    return;
                }
                if (fc1150.Checked == true && fc1dec != 336)
                {
                    fc1btn2.PerformClick();
                    return;
                }
                if (fc1180.Checked == true && fc1dec != 384)
                {
                    fc1btn3.PerformClick();
                    return;
                }
                if (fc1200.Checked == true && fc1dec != 512)
                {
                    fc1btn4.PerformClick();
                    return;
                }
                if (fc1300.Checked == true && fc1dec != 768)
                {
                    fc1btn5.PerformClick();
                    return;
                }
                if (fc1400.Checked == true && fc1dec != 1024)
                {
                    fc1btn6.PerformClick();
                    return;
                }
                if (fc1500.Checked == true && fc1dec != 1280)
                {
                    fc1btn7.PerformClick();
                    return;
                }
                if (fc1533.Checked == true && fc1dec != 1331)
                {
                    fc1btn8.PerformClick();
                    return;
                }

                return;
            }
        }

        private void backgroundWorker3_RunWorkerCompleted_1(object sender, RunWorkerCompletedEventArgs e)
        {
            backgroundWorker3.RunWorkerAsync();
        }
//**********************************************************************************************************//
// cpu 오토로 설정하기(FC2)

        private void backgroundWorker4_DoWork_1(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                backgroundWorker4.ReportProgress(0);
                Thread.Sleep(1000);
                return;
            }
        }

        private void backgroundWorker4_ProgressChanged_1(object sender, ProgressChangedEventArgs e)
        {
            if (Autocheck.Checked == true)
            {

                if (fc2100.Checked == true && fc2dec != 256)
                {
                    fc2btn1.PerformClick();
                    return;
                }
                if (fc2150.Checked == true && fc2dec != 336)
                {
                    fc2btn2.PerformClick();
                    return;
                }
                if (fc2180.Checked == true && fc2dec != 384)
                {
                    fc2btn3.PerformClick();
                    return;
                }
                if (fc2200.Checked == true && fc2dec != 512)
                {
                    fc2btn4.PerformClick();
                    return;
                }
                if (fc2300.Checked == true && fc2dec != 768)
                {
                    fc2btn5.PerformClick();
                    return;
                }
                if (fc2400.Checked == true && fc2dec != 1024)
                {
                    fc2btn6.PerformClick();
                    return;
                }
                if (fc2500.Checked == true && fc2dec != 1280)
                {
                    fc2btn7.PerformClick();
                    return;
                }
                if (fc2533.Checked == true && fc2dec != 1331)
                {
                    fc2btn8.PerformClick();
                    return;
                }

                return;

            }
        }

        private void backgroundWorker4_RunWorkerCompleted_1(object sender, RunWorkerCompletedEventArgs e)
        {
            backgroundWorker4.RunWorkerAsync();
        }

        private void Mainwin_Shown(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
            backgroundWorker2.RunWorkerAsync();
            backgroundWorker3.RunWorkerAsync();
            backgroundWorker4.RunWorkerAsync();

            fc2100.Checked = true; //fc2
            fc2100.Parent = groupBox1;
            fc2150.Parent = groupBox1;
            fc2180.Parent = groupBox1;
            fc2200.Parent = groupBox1;
            fc2300.Parent = groupBox1;
            fc2400.Parent = groupBox1;
            fc2500.Parent = groupBox1;
            fc2533.Parent = groupBox1;

            fc1100.Checked = true; //fc1
            fc1100.Parent = groupBox2;
            fc1150.Parent = groupBox2;
            fc1180.Parent = groupBox2;
            fc1200.Parent = groupBox2;
            fc1300.Parent = groupBox2;
            fc1400.Parent = groupBox2;
            fc1500.Parent = groupBox2;
            fc1533.Parent = groupBox2;
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Zansword/Fightcade-Overclocker-Universial/releases");
        }

        private void linkLabel2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://chamcham425.blogspot.com/");
        }

        private void linkLabel3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.fightcade.com/");
        }

        private void linkLabel4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/rxjcur9mTT");
        }
    }
}

