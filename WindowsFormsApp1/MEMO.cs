using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class MEMO : Form
    {
        
        public MEMO()
        {
            InitializeComponent();
        }

        private void MEMO_Load(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("memojang.txt", FileMode.Open); //파일을 열기위해 파일스트림 객체 생성
            StreamReader sr = new StreamReader(fs,Encoding.Default); // 스트림 리더 생성
            string memo = sr.ReadToEnd(); // 스트림 리더를 통해 파일을 윗줄부터 한라인씩 읽어내는거.
            textBox1.Text = memo;
            sr.Close();
            fs.Close();
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            FileStream fw = new FileStream("memojang.txt", FileMode.Open); //파일을 열기위해 파일스트림 객체 생성
            StreamWriter sw = new StreamWriter(fw, Encoding.Default); // 스트림 리더 생성
            sw.WriteLine(textBox1.Text);
            sw.Close();
            fw.Close();
            this.Close();
        }
    }
}
