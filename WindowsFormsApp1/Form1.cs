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
        bool backwork1 = true;
        int pid = 0;
        int cpudec = 0;
        long SingleAoBScanResult;
        string memory = null;
        string cpuhex = null;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void About_Load(object sender, EventArgs e)
        {

        }

        private void Using_TrackBar_Load(object sender, EventArgs e)
        {
            trackBar1.Value = 10;
        }

        //**********************************************************************************************************//
        // 백그라운드 작업 - 프로세스 id 검색 및 attach

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) // auto-detach process
        {
            while (true)
            {
                if (backwork1 == true)
                {
                    pid = m.GetProcIdFromName("fcadefbneo");

                    if (pid != 0)
                    {
                        ProcOpen = true;
                        m.OpenProcess("fcadefbneo");
                        backgroundWorker1.ReportProgress(0);
                        Thread.Sleep(1000);
                        return;
                    }

                    else if (pid == 0)
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

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e) // 결과 상호작용
        {
            if (backwork1 == true)
            {
                if (!m.OpenProcess("fcadefbneo"))
                {
                    ProcOpen = false;
                    cpustatus.Text = "The Emulator is Not Working";
                    cpudec = 0;
                    memory = null;
                    cpuhex = null;
                }

                if (m.OpenProcess("fcadefbneo"))
                {
                    ProcOpen = true;
                    backwork1 = false;
                    cpustatus.Text = "The Emulator is Working now";
                    scanbyte.PerformClick();
                }
            }

            if (backwork1 == false)
            {
                if (!m.OpenProcess("fcadefbneo"))
                {
                    ProcOpen = false;
                    backwork1 = true;
                }
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) // 무한루프용
        {
            backgroundWorker1.RunWorkerAsync();
        }

        //**********************************************************************************************************//
        // cpu 오토로 설정하기

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                backgroundWorker2.ReportProgress(0);
                Thread.Sleep(1000);
                return;
            }
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (Autocheck.Checked == true)
            {

                if (button100.Checked == true && cpudec != 256)
                {
                    button1.PerformClick();
                    return;
                }
                if (button150.Checked == true && cpudec != 336)
                {
                    button2.PerformClick();
                    return;
                }
                if (button180.Checked == true && cpudec != 384)
                {
                    button3.PerformClick();
                    return;
                }
                if (button200.Checked == true && cpudec != 512)
                {
                    button4.PerformClick();
                    return;
                }
                if (button300.Checked == true && cpudec != 768)
                {
                    button5.PerformClick();
                    return;
                }
                if (button400.Checked == true && cpudec != 1024)
                {
                    button6.PerformClick();
                    return;
                }
                if (button500.Checked == true && cpudec != 1280)
                {
                    button7.PerformClick();
                    return;
                }
                if (button533.Checked == true && cpudec != 1331)
                {
                    button8.PerformClick();
                    return;
                }

                return;

            }
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            backgroundWorker2.RunWorkerAsync();
        }

        //**********************************************************************************************************//
        // Array Of Byte 스캔 - 범용으로 만들기 위해서는 필수

        // this function is async, which means it does not block other code
        public async void AoBScan()
        {
            if (!m.OpenProcess("fcadefbneo"))
            {
                MessageBox.Show("Process Is Not Found or Open!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            IEnumerable<long> AoBScanResults = await m.AoBScan("?? ?? 00 00 44 97 02", true, true, true);
            SingleAoBScanResult = AoBScanResults.FirstOrDefault();

            memory = SingleAoBScanResult.ToString("X"); //16진수 메모리주소
            cpudec = Int32.Parse(m.Read2Byte(SingleAoBScanResult.ToString("X")).ToString()); //10진수256(100%)
            cpuhex = cpudec.ToString("X"); // 16진수 100(256)

            // NOT NOW, BUT SOMEDAY...
            //MessageBox.Show("Our First Found Address is " + SingleAoBScanResult); // 메모리주소 발견
            //MessageBox.Show("Value for our address is " + m.Read2Byte(SingleAoBScanResult.ToString("X")).ToString()); // 10진수 표현
            //MessageBox.Show("Value for our address is " + Convert.ToString(m.Read2Byte(SingleAoBScanResult.ToString("X")), 16)); // aob스캐닝 및 100 표현 성공
            //MessageBox.Show("Our First Found Address is " + memory);
            //MessageBox.Show("Emulator current cpu value is " + cpudec + "(" + cpuhex + "%)");

            //reference : https://www.delftstack.com/ko/howto/csharp/integer-to-hexadecimal-in-csharp/
        }

        //**********************************************************************************************************//
        // 버튼 및 UI 기능
        private void button1_Click(object sender, EventArgs e) // 100%
        {
            if (!ProcOpen)
            {
                cpustatus.Text = "Emulator is not opened!";
                cpuvalue2.Text = "N/A";
                return;
            }

            m.WriteMemory(memory, "int", "256");
            cpustatus.Text = "Overclock Disabled";
            cpuvalue2.Text = "100%";
            cpudec = 256;
        }

        private void button2_Click(object sender, EventArgs e) // 150%
        {
            if (!ProcOpen)
            {
                cpustatus.Text = "Emulator is not opened!";
                cpuvalue2.Text = "N/A";
                return;
            }

            m.WriteMemory(memory, "int", "336");
            cpustatus.Text = "Overclocked with 150%";
            cpuvalue2.Text = "150%";
            cpudec = 336;
        }

        private void button3_Click(object sender, EventArgs e) // 180%
        {
            if (!ProcOpen)
            {
                cpustatus.Text = "Emulator is not opened!";
                cpuvalue2.Text = "N/A";
                return;
            }

            m.WriteMemory(memory, "int", "384");
            cpustatus.Text = "Overclocked with 180%";
            cpuvalue2.Text = "180%";
            cpudec = 384;
        }

        private void button4_Click(object sender, EventArgs e) // 200%
        {
            if (!ProcOpen)
            {
                cpustatus.Text = "Emulator is not opened!";
                cpuvalue2.Text = "N/A";
                return;
            }

            m.WriteMemory(memory, "int", "512");
            cpustatus.Text = "Overclocked with 200%";
            cpuvalue2.Text = "200%";
            cpudec = 512;
        }

        private void button5_Click(object sender, EventArgs e) // 300%
        {
            if (!ProcOpen)
            {
                cpustatus.Text = "Emulator is not opened!";
                cpuvalue2.Text = "N/A";
                return;
            }

            m.WriteMemory(memory, "int", "768");
            cpustatus.Text = "Overclocked with 300%";
            cpuvalue2.Text = "300%";
            cpudec = 768;
        }

        private void button6_Click(object sender, EventArgs e) // 400%
        {
            if (!ProcOpen)
            {
                cpustatus.Text = "Emulator is not opened!";
                cpuvalue2.Text = "N/A";
                return;
            }

            m.WriteMemory(memory, "int", "1024");
            cpustatus.Text = "Overclocked with 400%";
            cpuvalue2.Text = "400%";
            cpudec = 1024;
        }

        private void button7_Click(object sender, EventArgs e) // 500%
        {
            if (!ProcOpen)
            {
                cpustatus.Text = "Emulator is not opened!";
                cpuvalue2.Text = "N/A";
                return;
            }

            m.WriteMemory(memory, "int", "1280");
            cpustatus.Text = "Overclocked with 500%";
            cpuvalue2.Text = "500%";
            cpudec = 1280;
        }

        private void button8_Click(object sender, EventArgs e) // 533%
        {
            if (!ProcOpen)
            {
                cpustatus.Text = "Emulator is not opened!";
                cpuvalue2.Text = "N/A";
                return;
            }

            m.WriteMemory(memory, "int", "1331");
            cpustatus.Text = "Overclocked with 533%";
            cpuvalue2.Text = "533%";
            cpudec = 1331;
        }

        private void button9_Click_1(object sender, EventArgs e) // ok button
        {
            if (!ProcOpen)
            {
                cpustatus.Text = "Emulator is not opened!";
                cpuvalue2.Text = "N/A";
                return;
            }

            String cpupercent = Convert.ToString(textBox1.Text);
            int cpuvalue = Convert.ToInt32(cpupercent, 16);
            string cpuvalue3 = Convert.ToString(cpuvalue);
            cpudec = cpuvalue;

            m.WriteMemory(memory, "int", cpuvalue3);
            cpustatus.Text = "Overclocked with " + cpupercent + " %";
            cpuvalue2.Text = cpupercent + " %";

            return;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
            backgroundWorker2.RunWorkerAsync();
            backgroundWorker3.RunWorkerAsync();
            button100.Checked = true;
            button100.Parent = groupBox1;
            button150.Parent = groupBox1;
            button180.Parent = groupBox1;
            button200.Parent = groupBox1;
            button300.Parent = groupBox1;
            button400.Parent = groupBox1;
            button500.Parent = groupBox1;
            button533.Parent = groupBox1;
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            About newform2 = new About();
            newform2.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Task taskA = new Task(() => AoBScan());
            taskA.Start();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox1.Text = "" + trackBar1.Value;
            //            textBox1.Text = trackBar1.Value.ToString();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
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
    }
}

