using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        private Main_Form Main_Form;
        LOGINC log = new LOGINC();
        

        public int openclosecount { // 카운터를 메인폼과 연계하는 프로퍼티
            get; set;
        }

        public Login(Main_Form main_Form)
        {
            this.Main_Form = main_Form;
            InitializeComponent();
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox_PW_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_log_Click(sender, e);
            }
        }

        private void button_log_Click(object sender, EventArgs e) // 로그인 버튼 클릭시 발생
        {
            log.ID = "admin";
            log.PW = "1234";
            if (log.ID != textBox_ID.Text)
            {
                textBox_result.Text = "아이디가 올바르지 않습니다.";
            }
            else if (log.PW != textBox_PW.Text)
            {
                textBox_result.Text = "비밀번호가 올바르지 않습니다.";
            }
            else
            {
                textBox_result.Text = "로그인 성공";
                openclosecount = 1;
                Main_Form.openclosecount = openclosecount;
            }
        }
    }
}
