using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;

namespace AutoRecord
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            if (textBox1.Text != "")
            {
                he = File.GetLastWriteTime(textBox1.Text);
            }
            
        }
        public DateTime he;
        private void button1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == false)
            {
                timer1.Enabled = true;
                button1.Text = "Stop";
            }
            else if (timer1.Enabled == true)
            {
                timer1.Enabled = false;
                button1.Text = "Start";
            }
        }
        public void StartRecording()
        {
                InputSimulator Input = new InputSimulator();
                Input.Keyboard.KeyDown(VirtualKeyCode.F13);
                Thread.Sleep(100);
                Input.Keyboard.KeyUp(VirtualKeyCode.F13);
        }
        [DllImport("User32.dll")]
        static extern bool SetForegroundWindow(IntPtr point);

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (File.GetLastWriteTime(textBox1.Text) != he)
            {
                StartRecording();
                he = File.GetLastWriteTime(textBox1.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StartRecording();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            he = File.GetLastWriteTime(textBox1.Text);
        }
    }
}
