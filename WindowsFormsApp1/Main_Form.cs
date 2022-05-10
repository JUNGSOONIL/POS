using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace WindowsFormsApp1
{
    public partial class Main_Form : Form
    {
        ORDER ord = new ORDER();
        STOCK sto = new STOCK();
        SALES sal = new SALES();

        int membercount = 0, forcount = 0, stockcount = 0; // 회원 검색 버튼 카운터, 회원 검색시 포문 카운터, 재고 검색 버튼 카운터
        Int32 Salesday = 0, Salesmuney = 0; // 매출 달력 날짜 누르면 이제 해당 날짜랑 그날 매출이 저장되는 변수
        int cash = 0; // 총 받을 금액
        int stockErrorcount = 0; // 재고부족한거 카운트하는거
        string SName, STell, Sbirthday, Stockname, Stockcount, Stocknote; // 회원 정보 수정, 재고 수정 에 사용되는 변수들 수정 이전 내용을 저장해놈 
        string memberfile = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=member.mdb";
        string stockfile = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=stock.mdb";
        string salesfile = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = sales.mdb";
     

        OleDbConnection memberconn;
        OleDbCommand membercomm;

        OleDbConnection stockconn;
        OleDbCommand stockcomm;

        OleDbConnection salesconn;
        OleDbCommand salescomm;

        public int openclosecount // 로그인 폼에서 openclosecount 값 전달받는곳, 즉 로그인폼에서 메인폼으로 값 전달
        {
            set; get;
        }

        public Main_Form()
        {
            InitializeComponent();
        }


        // ------------------------------------------------------------------주문 관리-----------------------------------------------------------------------------
        private void button_order_Click(object sender, EventArgs e)// 주문관리 버튼
        {
            if (groupBox_order.Visible == false)
            {
                groupBox_order.Visible = true;
            }
            else
            {
                groupBox_order.Visible = false;
            }
            groupBox_member.Visible = false;
            groupBox_stock.Visible = false;
            groupBox_sales.Visible = false;
            openclosecount = 0;
        }

        private void button_Americano_Click(object sender, EventArgs e)// 아메리카노 hot 버튼 누르면 리스트뷰에 뜨게하는거
        {
            int count = listView_order.Items.Count; // 리스트뷰 항목 수 반환
            if (ord.americanohcount >= 2)
            {
                for (int i = 0; i < count; i++) // 리스트 뷰 내에서 검색하는 포문
                {
                    if (listView_order.Items[i].SubItems[0].Text == button_Americanoh.Text) // 리스트 뷰에 해당 버튼의 텍스트가 있으면
                    {
                        listView_order.Items[i].Focused = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.Items[i].Selected = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.FocusedItem.SubItems[0].Text = button_Americanoh.Text; // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[1].Text = Convert.ToString(ord.americanohcount); // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[2].Text = Convert.ToString(ord.AmericanohSum()); // 포커스된 부분에 내용 덮어쓰는거
                        ord.americanohcount++;
                        listView_order.Items[i].Selected = false;
                    }
                }
            }
            else
            {
                var coffee = new string[] { this.button_Americanoh.Text, Convert.ToString(ord.americanohcount), Convert.ToString(ord.AmericanohSum()) };
                var lvt = new ListViewItem(coffee);
                this.listView_order.Items.Add(lvt);
                listView_order.Focus();
                ord.americanohcount++;
            }
            textBox_sumnumber.Text = Convert.ToString(ord.SumNumber());
            textBox_sumcash.Text = Convert.ToString(ord.SumCash());
        }

        private void button_Americanoi_Click(object sender, EventArgs e)// 아메리카노 ice 버튼 누르면 리스트 뷰에 뜨게하는거
        {
            int count = listView_order.Items.Count; // 리스트뷰 항목 수 반환
            if (ord.americanoicount >= 2)
            {
                for (int i = 0; i < count; i++) // 리스트 뷰 내에서 검색하는 포문
                {
                    if (listView_order.Items[i].SubItems[0].Text == button_Americanoi.Text)
                    {
                        listView_order.Items[i].Focused = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.Items[i].Selected = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.FocusedItem.SubItems[0].Text = button_Americanoi.Text; // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[1].Text = Convert.ToString(ord.americanoicount); // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[2].Text = Convert.ToString(ord.AmericanoiSum()); // 포커스된 부분에 내용 덮어쓰는거
                        ord.americanoicount++;
                        listView_order.Items[i].Selected = false;
                    }
                }
            }
            else
            {
                var coffee = new string[] { this.button_Americanoi.Text, Convert.ToString(ord.americanoicount), Convert.ToString(ord.AmericanoiSum()) };
                var lvt = new ListViewItem(coffee);
                this.listView_order.Items.Add(lvt);
                listView_order.Focus();
                ord.americanoicount++;
            }
            textBox_sumnumber.Text = Convert.ToString(ord.SumNumber());
            textBox_sumcash.Text = Convert.ToString(ord.SumCash());
        }

        private void button_Cafelatteh_Click(object sender, EventArgs e)// 카페라떼 hot 버튼 누르면 리스트뷰에 뜨게하는거
        {
            int count = listView_order.Items.Count; // 리스트뷰 항목 수 반환
            if (ord.cafelattehcount >= 2)
            {
                for (int i = 0; i < count; i++) // 리스트 뷰 내에서 검색하는 포문
                {
                    if (listView_order.Items[i].SubItems[0].Text == button_Cafelatteh.Text)

                    {
                        listView_order.Items[i].Focused = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.Items[i].Selected = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.FocusedItem.SubItems[0].Text = button_Cafelatteh.Text; // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[1].Text = Convert.ToString(ord.cafelattehcount); // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[2].Text = Convert.ToString(ord.CafelattehSum()); // 포커스된 부분에 내용 덮어쓰는거
                        ord.cafelattehcount++;
                        listView_order.Items[i].Selected = false;
                    }
                }
            }
            else
            {
                var coffee = new string[] { this.button_Cafelatteh.Text, Convert.ToString(ord.cafelattehcount), Convert.ToString(ord.CafelattehSum()) };
                var lvt = new ListViewItem(coffee);
                this.listView_order.Items.Add(lvt);
                listView_order.Focus();
                ord.cafelattehcount++;
            }
            textBox_sumnumber.Text = Convert.ToString(ord.SumNumber());
            textBox_sumcash.Text = Convert.ToString(ord.SumCash());
        }

        private void button_Cafelattei_Click(object sender, EventArgs e)// 카페라떼 ice 버튼 누르면 리스트뷰에 뜨게하는거
        {
            int count = listView_order.Items.Count; // 리스트뷰 항목 수 반환
            if (ord.cafelatteicount >= 2)
            {
                for (int i = 0; i < count; i++) // 리스트 뷰 내에서 검색하는 포문
                {
                    if (listView_order.Items[i].SubItems[0].Text == button_Cafelattei.Text)

                    {
                        listView_order.Items[i].Focused = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.Items[i].Selected = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.FocusedItem.SubItems[0].Text = button_Cafelattei.Text; // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[1].Text = Convert.ToString(ord.cafelatteicount); // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[2].Text = Convert.ToString(ord.CafelatteiSum()); // 포커스된 부분에 내용 덮어쓰는거
                        ord.cafelatteicount++;
                        listView_order.Items[i].Selected = false;
                    }
                }
            }
            else
            {
                var coffee = new string[] { this.button_Cafelattei.Text, Convert.ToString(ord.cafelatteicount), Convert.ToString(ord.CafelatteiSum()) };
                var lvt = new ListViewItem(coffee);
                this.listView_order.Items.Add(lvt);
                listView_order.Focus();
                ord.cafelatteicount++;
            }
            textBox_sumnumber.Text = Convert.ToString(ord.SumNumber());
            textBox_sumcash.Text = Convert.ToString(ord.SumCash());
        }

        private void button_Cappuccinoh_Click(object sender, EventArgs e)// 카푸치노 hot 버튼 누르면 리스트뷰에 뜨게하는거
        {
            int count = listView_order.Items.Count; // 리스트뷰 항목 수 반환
            if (ord.cappuccinohcount >= 2)
            {
                for (int i = 0; i < count; i++) // 리스트 뷰 내에서 검색하는 포문
                {
                    if (listView_order.Items[i].SubItems[0].Text == button_Cappuccinoh.Text)

                    {
                        listView_order.Items[i].Focused = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.Items[i].Selected = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.FocusedItem.SubItems[0].Text = button_Cappuccinoh.Text; // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[1].Text = Convert.ToString(ord.cappuccinohcount); // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[2].Text = Convert.ToString(ord.CappuccinohSum()); // 포커스된 부분에 내용 덮어쓰는거
                        ord.cappuccinohcount++;
                        listView_order.Items[i].Selected = false;
                    }
                }
            }
            else
            {
                var coffee = new string[] { this.button_Cappuccinoh.Text, Convert.ToString(ord.cappuccinohcount), Convert.ToString(ord.CappuccinohSum()) };
                var lvt = new ListViewItem(coffee);
                this.listView_order.Items.Add(lvt);
                listView_order.Focus();
                ord.cappuccinohcount++;
            }
            textBox_sumnumber.Text = Convert.ToString(ord.SumNumber());
            textBox_sumcash.Text = Convert.ToString(ord.SumCash());
        }

        private void button_Cappuccinoi_Click(object sender, EventArgs e)// 카푸치노 ice 버튼 누르면 리스트뷰에 뜨게하는거
        {
            int count = listView_order.Items.Count; // 리스트뷰 항목 수 반환
            if (ord.cappuccinoicount >= 2)
            {
                for (int i = 0; i < count; i++) // 리스트 뷰 내에서 검색하는 포문
                {
                    if (listView_order.Items[i].SubItems[0].Text == button_Cappuccinoi.Text)

                    {
                        listView_order.Items[i].Focused = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.Items[i].Selected = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.FocusedItem.SubItems[0].Text = button_Cappuccinoi.Text; // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[1].Text = Convert.ToString(ord.cappuccinoicount); // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[2].Text = Convert.ToString(ord.CappuccinoiSum()); // 포커스된 부분에 내용 덮어쓰는거
                        ord.cappuccinoicount++;
                        listView_order.Items[i].Selected = false;
                    }
                }
            }
            else
            {
                var coffee = new string[] { this.button_Cappuccinoi.Text, Convert.ToString(ord.cappuccinoicount), Convert.ToString(ord.CappuccinoiSum()) };
                var lvt = new ListViewItem(coffee);
                this.listView_order.Items.Add(lvt);
                listView_order.Focus();
                ord.cappuccinoicount++;
            }
            textBox_sumnumber.Text = Convert.ToString(ord.SumNumber());
            textBox_sumcash.Text = Convert.ToString(ord.SumCash());
        }

        private void button_CafeMochah_Click(object sender, EventArgs e)// 카페모카 hot 버튼 누르면 리스트뷰에 뜨게하는거
        {
            int count = listView_order.Items.Count; // 리스트뷰 항목 수 반환
            if (ord.cafemochahcount >= 2)
            {
                for (int i = 0; i < count; i++) // 리스트 뷰 내에서 검색하는 포문
                {
                    if (listView_order.Items[i].SubItems[0].Text == button_CafeMochah.Text)

                    {
                        listView_order.Items[i].Focused = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.Items[i].Selected = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.FocusedItem.SubItems[0].Text = button_CafeMochah.Text; // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[1].Text = Convert.ToString(ord.cafemochahcount); // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[2].Text = Convert.ToString(ord.CafemochahSum()); // 포커스된 부분에 내용 덮어쓰는거
                        ord.cafemochahcount++;
                        listView_order.Items[i].Selected = false;
                    }
                }
            }
            else
            {
                var coffee = new string[] { this.button_CafeMochah.Text, Convert.ToString(ord.cafemochahcount), Convert.ToString(ord.CafemochahSum()) };
                var lvt = new ListViewItem(coffee);
                this.listView_order.Items.Add(lvt);
                listView_order.Focus();
                ord.cafemochahcount++;
            }
            textBox_sumnumber.Text = Convert.ToString(ord.SumNumber());
            textBox_sumcash.Text = Convert.ToString(ord.SumCash());
        }

        private void button_CafeMochai_Click(object sender, EventArgs e)// 카페모카 ice 버튼 누르면 리스트뷰에 뜨게하는거
        {
            int count = listView_order.Items.Count; // 리스트뷰 항목 수 반환
            if (ord.cafemochaicount >= 2)
            {
                for (int i = 0; i < count; i++) // 리스트 뷰 내에서 검색하는 포문
                {
                    if (listView_order.Items[i].SubItems[0].Text == button_CafeMochai.Text)

                    {
                        listView_order.Items[i].Focused = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.Items[i].Selected = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.FocusedItem.SubItems[0].Text = button_CafeMochai.Text; // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[1].Text = Convert.ToString(ord.cafemochaicount); // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[2].Text = Convert.ToString(ord.CafemochaiSum()); // 포커스된 부분에 내용 덮어쓰는거
                        ord.cafemochaicount++;
                        listView_order.Items[i].Selected = false;
                    }
                }
            }
            else
            {
                var coffee = new string[] { this.button_CafeMochai.Text, Convert.ToString(ord.cafemochaicount), Convert.ToString(ord.CafemochaiSum()) };
                var lvt = new ListViewItem(coffee);
                this.listView_order.Items.Add(lvt);
                listView_order.Focus();
                ord.cafemochaicount++;
            }
            textBox_sumnumber.Text = Convert.ToString(ord.SumNumber());
            textBox_sumcash.Text = Convert.ToString(ord.SumCash());
        }

        private void button_caramelh_Click(object sender, EventArgs e)// 카라멜 마끼아또 hot 버튼 누르면 리스트뷰에 뜨게하는거
        {
            int count = listView_order.Items.Count; // 리스트뷰 항목 수 반환
            if (ord.caramelhcount >= 2)
            {
                for (int i = 0; i < count; i++) // 리스트 뷰 내에서 검색하는 포문
                {
                    if (listView_order.Items[i].SubItems[0].Text == button_caramelh.Text)

                    {
                        listView_order.Items[i].Focused = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.Items[i].Selected = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.FocusedItem.SubItems[0].Text = button_caramelh.Text; // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[1].Text = Convert.ToString(ord.caramelhcount); // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[2].Text = Convert.ToString(ord.CaramelhSum()); // 포커스된 부분에 내용 덮어쓰는거
                        ord.caramelhcount++;
                        listView_order.Items[i].Selected = false;
                    }
                }
            }
            else
            {
                var coffee = new string[] { this.button_caramelh.Text, Convert.ToString(ord.caramelhcount), Convert.ToString(ord.CaramelhSum()) };
                var lvt = new ListViewItem(coffee);
                this.listView_order.Items.Add(lvt);
                listView_order.Focus();
                ord.caramelhcount++;
            }
            textBox_sumnumber.Text = Convert.ToString(ord.SumNumber());
            textBox_sumcash.Text = Convert.ToString(ord.SumCash());
        }

        private void button_carameli_Click(object sender, EventArgs e)// 카라멜 마끼아또 ice 버튼 누르면 리스트뷰에 뜨게하는거
        {
            int count = listView_order.Items.Count; // 리스트뷰 항목 수 반환
            if (ord.caramelicount >= 2)
            {
                for (int i = 0; i < count; i++) // 리스트 뷰 내에서 검색하는 포문
                {
                    if (listView_order.Items[i].SubItems[0].Text == button_carameli.Text)

                    {
                        listView_order.Items[i].Focused = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.Items[i].Selected = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.FocusedItem.SubItems[0].Text = button_carameli.Text; // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[1].Text = Convert.ToString(ord.caramelicount); // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[2].Text = Convert.ToString(ord.CarameliSum()); // 포커스된 부분에 내용 덮어쓰는거
                        ord.caramelicount++;
                        listView_order.Items[i].Selected = false;
                    }
                }
            }
            else
            {
                var coffee = new string[] { this.button_carameli.Text, Convert.ToString(ord.caramelicount), Convert.ToString(ord.CarameliSum()) };
                var lvt = new ListViewItem(coffee);
                this.listView_order.Items.Add(lvt);
                listView_order.Focus();
                ord.caramelicount++;
            }
            textBox_sumnumber.Text = Convert.ToString(ord.SumNumber());
            textBox_sumcash.Text = Convert.ToString(ord.SumCash());
        }

        private void button_Chococake_Click(object sender, EventArgs e)// 초코케익 버튼 누르면 리스트뷰에 뜨게하는거
        {
            int count = listView_order.Items.Count; // 리스트뷰 항목 수 반환
            if (ord.chococakecount >= 2)
            {
                for (int i = 0; i < count; i++) // 리스트 뷰 내에서 검색하는 포문
                {
                    if (listView_order.Items[i].SubItems[0].Text == button_Chococake.Text)

                    {
                        listView_order.Items[i].Focused = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.Items[i].Selected = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.FocusedItem.SubItems[0].Text = button_Chococake.Text; // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[1].Text = Convert.ToString(ord.chococakecount); // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[2].Text = Convert.ToString(ord.ChococakeSum()); // 포커스된 부분에 내용 덮어쓰는거
                        ord.chococakecount++;
                        listView_order.Items[i].Selected = false;
                    }
                }
            }
            else
            {
                var dessert = new string[] { this.button_Chococake.Text, Convert.ToString(ord.chococakecount), Convert.ToString(ord.ChococakeSum()) };
                var lvt = new ListViewItem(dessert);
                this.listView_order.Items.Add(lvt);
                listView_order.Focus();
                ord.chococakecount++;
            }
            textBox_dessertsum.Text = Convert.ToString(ord.Sumdessert());
            textBox_sumcash.Text = Convert.ToString(ord.SumCash());
        }

        private void button_Cheezecake_Click(object sender, EventArgs e)// 치즈케익 버튼 누르면 리스트뷰에 뜨게 하는거
        {
            int count = listView_order.Items.Count; // 리스트뷰 항목 수 반환
            if (ord.cheezecakecount >= 2)
            {
                for (int i = 0; i < count; i++) // 리스트 뷰 내에서 검색하는 포문
                {
                    if (listView_order.Items[i].SubItems[0].Text == button_Cheezecake.Text)

                    {
                        listView_order.Items[i].Focused = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.Items[i].Selected = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.FocusedItem.SubItems[0].Text = button_Cheezecake.Text; // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[1].Text = Convert.ToString(ord.cheezecakecount); // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[2].Text = Convert.ToString(ord.CheezecakeSum()); // 포커스된 부분에 내용 덮어쓰는거
                        ord.cheezecakecount++;
                        listView_order.Items[i].Selected = false;
                    }
                }
            }
            else
            {
                var dessert = new string[] { this.button_Cheezecake.Text, Convert.ToString(ord.cheezecakecount), Convert.ToString(ord.CheezecakeSum()) };
                var lvt = new ListViewItem(dessert);
                this.listView_order.Items.Add(lvt);
                listView_order.Focus();
                ord.cheezecakecount++;
            }
            textBox_dessertsum.Text = Convert.ToString(ord.Sumdessert());
            textBox_sumcash.Text = Convert.ToString(ord.SumCash());
        }

        private void button_Brownie_Click(object sender, EventArgs e)// 브라우니 버튼 누르면 리스트뷰에 뜨게 하는거
        {
            int count = listView_order.Items.Count; // 리스트뷰 항목 수 반환
            if (ord.browniecount >= 2)
            {
                for (int i = 0; i < count; i++) // 리스트 뷰 내에서 검색하는 포문
                {
                    if (listView_order.Items[i].SubItems[0].Text == button_Brownie.Text)

                    {
                        listView_order.Items[i].Focused = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.Items[i].Selected = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.FocusedItem.SubItems[0].Text = button_Brownie.Text; // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[1].Text = Convert.ToString(ord.browniecount); // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[2].Text = Convert.ToString(ord.BrownieSum()); // 포커스된 부분에 내용 덮어쓰는거
                        ord.browniecount++;
                        listView_order.Items[i].Selected = false;
                    }
                }
            }
            else
            {
                var dessert = new string[] { this.button_Brownie.Text, Convert.ToString(ord.browniecount), Convert.ToString(ord.BrownieSum()) };
                var lvt = new ListViewItem(dessert);
                this.listView_order.Items.Add(lvt);
                listView_order.Focus();
                ord.browniecount++;
            }
            textBox_dessertsum.Text = Convert.ToString(ord.Sumdessert());
            textBox_sumcash.Text = Convert.ToString(ord.SumCash());
        }

        private void button_Tiramisu_Click(object sender, EventArgs e) // 티리미슈 버튼 누르면 리스트뷰에 뜨게 하는거
        {
            int count = listView_order.Items.Count; // 리스트뷰 항목 수 반환
            if (ord.tiramisucount >= 2)
            {
                for (int i = 0; i < count; i++) // 리스트 뷰 내에서 검색하는 포문
                {
                    if (listView_order.Items[i].SubItems[0].Text == button_Tiramisu.Text)

                    {
                        listView_order.Items[i].Focused = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.Items[i].Selected = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.FocusedItem.SubItems[0].Text = button_Tiramisu.Text; // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[1].Text = Convert.ToString(ord.tiramisucount); // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[2].Text = Convert.ToString(ord.TiramisuSum()); // 포커스된 부분에 내용 덮어쓰는거
                        ord.tiramisucount++;
                        listView_order.Items[i].Selected = false;
                    }
                }
            }
            else
            {
                var dessert = new string[] { this.button_Tiramisu.Text, Convert.ToString(ord.tiramisucount), Convert.ToString(ord.TiramisuSum()) };
                var lvt = new ListViewItem(dessert);
                this.listView_order.Items.Add(lvt);
                listView_order.Focus();
                ord.tiramisucount++;
            }
            textBox_dessertsum.Text = Convert.ToString(ord.Sumdessert());
            textBox_sumcash.Text = Convert.ToString(ord.SumCash());
        }

        private void button_Muffin_Click(object sender, EventArgs e) // 머핀 버튼 누르면 리스트뷰에 뜨게 하는거
        {
            int count = listView_order.Items.Count; // 리스트뷰 항목 수 반환
            if (ord.muffincount >= 2)
            {
                for (int i = 0; i < count; i++) // 리스트 뷰 내에서 검색하는 포문
                {
                    if (listView_order.Items[i].SubItems[0].Text == button_Muffin.Text)

                    {
                        listView_order.Items[i].Focused = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.Items[i].Selected = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.FocusedItem.SubItems[0].Text = button_Muffin.Text; // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[1].Text = Convert.ToString(ord.muffincount); // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[2].Text = Convert.ToString(ord.MuffinSum()); // 포커스된 부분에 내용 덮어쓰는거
                        ord.muffincount++;
                        listView_order.Items[i].Selected = false;
                    }
                }
            }
            else
            {
                var dessert = new string[] { this.button_Muffin.Text, Convert.ToString(ord.muffincount), Convert.ToString(ord.MuffinSum()) };
                var lvt = new ListViewItem(dessert);
                this.listView_order.Items.Add(lvt);
                listView_order.Focus();
                ord.muffincount++;
            }
            textBox_dessertsum.Text = Convert.ToString(ord.Sumdessert());
            textBox_sumcash.Text = Convert.ToString(ord.SumCash());
        }

        private void button_Bagel_Click(object sender, EventArgs e) // 베이글 버튼 누르면 리스트뷰에 뜨게 하는거
        {
            int count = listView_order.Items.Count; // 리스트뷰 항목 수 반환
            if (ord.bagelcount >= 2)
            {
                for (int i = 0; i < count; i++) // 리스트 뷰 내에서 검색하는 포문
                {
                    if (listView_order.Items[i].SubItems[0].Text == button_Bagel.Text)

                    {
                        listView_order.Items[i].Focused = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.Items[i].Selected = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.FocusedItem.SubItems[0].Text = button_Bagel.Text; // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[1].Text = Convert.ToString(ord.bagelcount); // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[2].Text = Convert.ToString(ord.BagelSum()); // 포커스된 부분에 내용 덮어쓰는거
                        ord.bagelcount++;
                        listView_order.Items[i].Selected = false;
                    }
                }
            }
            else
            {
                var dessert = new string[] { this.button_Bagel.Text, Convert.ToString(ord.bagelcount), Convert.ToString(ord.BagelSum()) };
                var lvt = new ListViewItem(dessert);
                this.listView_order.Items.Add(lvt);
                listView_order.Focus();
                ord.bagelcount++;
            }
            textBox_dessertsum.Text = Convert.ToString(ord.Sumdessert());
            textBox_sumcash.Text = Convert.ToString(ord.SumCash());
        }

        private void button_Waffle_Click(object sender, EventArgs e) // 와플 버튼 누르면 리스트뷰에 뜨게 하는거
        {
            int count = listView_order.Items.Count; // 리스트뷰 항목 수 반환
            if (ord.wafflecount >= 2)
            {
                for (int i = 0; i < count; i++) // 리스트 뷰 내에서 검색하는 포문
                {
                    if (listView_order.Items[i].SubItems[0].Text == button_Waffle.Text)

                    {
                        listView_order.Items[i].Focused = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.Items[i].Selected = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                        listView_order.FocusedItem.SubItems[0].Text = button_Waffle.Text; // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[1].Text = Convert.ToString(ord.wafflecount); // 포커스된 부분에 내용 덮어쓰는거
                        listView_order.FocusedItem.SubItems[2].Text = Convert.ToString(ord.WaffleSum()); // 포커스된 부분에 내용 덮어쓰는거
                        ord.wafflecount++;
                        listView_order.Items[i].Selected = false;
                    }
                }
            }
            else
            {
                var dessert = new string[] { this.button_Waffle.Text, Convert.ToString(ord.wafflecount), Convert.ToString(ord.WaffleSum()) };
                var lvt = new ListViewItem(dessert);
                this.listView_order.Items.Add(lvt);
                listView_order.Focus();
                ord.wafflecount++;
            }
            textBox_dessertsum.Text = Convert.ToString(ord.Sumdessert());
            textBox_sumcash.Text = Convert.ToString(ord.SumCash());
        }

        private void button_bell7_Click(object sender, EventArgs e)// 계산기 7번 버튼
        {
            if (cash == 0)
            {
                cash = 7;
                textBox_cash.Text = Convert.ToString(cash);
            }
            else
            {
                cash *= 10;
                cash += 7;
                textBox_cash.Text = Convert.ToString(cash);
            }
            textBox_cash2.Text = Convert.ToString(cash - ord.SumCash());
        }

        private void button_bell8_Click(object sender, EventArgs e)// 계산기 8번 버튼
        {
            if (cash == 0)
            {
                cash = 8;
                textBox_cash.Text = Convert.ToString(cash);
            }
            else
            {
                cash *= 10;
                cash += 8;
                textBox_cash.Text = Convert.ToString(cash);
            }
            textBox_cash2.Text = Convert.ToString(cash - ord.SumCash());
        }

        private void button_bell9_Click(object sender, EventArgs e)// 계산기 9번 버튼
        {
            if (cash == 0)
            {
                cash = 9;
                textBox_cash.Text = Convert.ToString(cash);
            }
            else
            {
                cash *= 10;
                cash += 9;
                textBox_cash.Text = Convert.ToString(cash);
            }
            textBox_cash2.Text = Convert.ToString(cash - ord.SumCash());
        }

        private void button_bell4_Click(object sender, EventArgs e) // 계산기 4번 버튼
        {
            if (cash == 0)
            {
                cash = 4;
                textBox_cash.Text = Convert.ToString(cash);
            }
            else
            {
                cash *= 10;
                cash += 4;
                textBox_cash.Text = Convert.ToString(cash);
            }
            textBox_cash2.Text = Convert.ToString(cash - ord.SumCash());
        }

        private void button_bell5_Click(object sender, EventArgs e)// 계산기 5번 버튼
        {
            if (cash == 0)
            {
                cash = 5;
                textBox_cash.Text = Convert.ToString(cash);
            }
            else
            {
                cash *= 10;
                cash += 5;
                textBox_cash.Text = Convert.ToString(cash);
            }
            textBox_cash2.Text = Convert.ToString(cash - ord.SumCash());
        }

        private void button_bell6_Click(object sender, EventArgs e)// 계산기 6번 버튼
        {
            if (cash == 0)
            {
                cash = 6;
                textBox_cash.Text = Convert.ToString(cash);
            }
            else
            {
                cash *= 10;
                cash += 6;
                textBox_cash.Text = Convert.ToString(cash);
            }
            textBox_cash2.Text = Convert.ToString(cash - ord.SumCash());
        }

        private void button_bell1_Click(object sender, EventArgs e)// 계산기 1번 버튼
        {
            if (cash == 0)
            {
                cash = 1;
                textBox_cash.Text = Convert.ToString(cash);
            }
            else
            {
                cash *= 10;
                cash += 1;
                textBox_cash.Text = Convert.ToString(cash);
            }
            textBox_cash2.Text = Convert.ToString(cash - ord.SumCash());
        }

        private void button_bell2_Click(object sender, EventArgs e)// 계산기 2번 버튼
        {
            if (cash == 0)
            {
                cash = 2;
                textBox_cash.Text = Convert.ToString(cash);
            }
            else
            {
                cash *= 10;
                cash += 2;
                textBox_cash.Text = Convert.ToString(cash);
            }
            textBox_cash2.Text = Convert.ToString(cash - ord.SumCash());
        }

        private void button_bell3_Click(object sender, EventArgs e)// 계산기 3번 버튼
        {
            if (cash == 0)
            {
                cash = 3;
                textBox_cash.Text = Convert.ToString(cash);
            }
            else
            {
                cash *= 10;
                cash += 3;
                textBox_cash.Text = Convert.ToString(cash);
            }
            textBox_cash2.Text = Convert.ToString(cash - ord.SumCash());
        }

        private void button_bell0_Click(object sender, EventArgs e)// 계산기 0번 버튼
        {
            cash *= 10;
            textBox_cash.Text = Convert.ToString(cash);
            textBox_cash2.Text = Convert.ToString(cash - ord.SumCash());
        }

        private void button_bell00_Click(object sender, EventArgs e)// 계산기 00번 버튼
        {
            cash *= 100;
            textBox_cash.Text = Convert.ToString(cash);
            textBox_cash2.Text = Convert.ToString(cash - ord.SumCash());
        }

        private void button_bellce_Click(object sender, EventArgs e)// 계산기 CE 버튼
        {
            cash = 0;
            textBox_cash.Text = Convert.ToString(cash);
            textBox_cash2.Text = Convert.ToString(cash - ord.SumCash());
        }

        private void button_Cash_Click(object sender, EventArgs e) // 현금결제 버튼
        {
            int count = listView_order.Items.Count; // 리스트뷰 항목수 반환
            if (count == 0)
            {
                MessageBox.Show("결제할 메뉴가 없습니다!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                if (textBox_cash.Text == "0") {
                    textBox_cash.Text = textBox_sumcash.Text;
                }
                DialogResult dlr = MessageBox.Show("현금결제 하시겠습니까?", "현금 결제", MessageBoxButtons.YesNo);
                switch (dlr)
                {
                    case DialogResult.Yes:
                        listView_order.Items.Clear();
                        textBox_cash.Text = "0";
                        textBox_cash2.Text = "0";
                        textBox_sumcash.Text = "0";
                        textBox_sumnumber.Text = "0";
                        textBox_dessertsum.Text = "0";

                        sal.sumcash = ord.sumcash;
                        sal.Salessum();
                        cash = 0;

                        sto.americanohcount += ord.americanohcount - 1;
                        sto.cafelattehcount += ord.cafelattehcount - 1;
                        sto.cappuccinohcount += ord.cappuccinohcount - 1;
                        sto.cafemochahcount += ord.cafemochahcount - 1;
                        sto.caramelhcount += ord.caramelhcount - 1;
                        sto.americanoicount += ord.americanoicount - 1;
                        sto.cafelatteicount += ord.cafelatteicount - 1;
                        sto.cappuccinoicount += ord.cappuccinoicount - 1;
                        sto.cafemochaicount += ord.cafemochaicount - 1;
                        sto.caramelicount += ord.caramelicount - 1;
                        sto.chococakecount += ord.chococakecount - 1;
                        sto.cheezecakecount += ord.cheezecakecount - 1;
                        sto.browniecount += ord.browniecount - 1;
                        sto.tiramisucount += ord.tiramisucount - 1;
                        sto.muffincount += ord.muffincount - 1;
                        sto.bagelcount += ord.bagelcount - 1;
                        sto.wafflecount += ord.wafflecount - 1;

                        sto.Stockopen();

                        if (sto[0] - sto.americanohcount - sto.cafelattehcount - sto.cappuccinohcount - sto.cafemochahcount - sto.caramelhcount - sto.americanoicount - sto.cafelatteicount - sto.cappuccinoicount - sto.cafemochaicount - sto.caramelicount < 0) {
                            MessageBox.Show("현재 주문한 메뉴만큼 원두가 있지않습니다.");
                        }

                        if (sto[1] - sto.cafelattehcount - sto.cappuccinohcount - sto.cafemochahcount - sto.caramelhcount - sto.cafelatteicount - sto.cappuccinoicount - sto.cafemochaicount - sto.caramelicount < 0)
                        {
                            MessageBox.Show("현재 주문한 메뉴만큼 우유가 있지않습니다.");
                        }

                        if (sto[2] - sto.cafemochahcount - sto.cafemochaicount < 0)
                        {
                            MessageBox.Show("현재 주문한 메뉴만큼 모카 시럽이 있지않습니다.");
                        }

                        if (sto[3] - sto.caramelhcount - sto.caramelicount < 0)
                        {
                            MessageBox.Show("현재 주문한 메뉴만큼 카라멜 시럽이가 있지않습니다.");
                        }

                        if (sto[4] - sto.chococakecount < 0)
                        {
                            MessageBox.Show("현재 주문한 메뉴만큼 초코 케익이 있지않습니다.");
                        }
                        if (sto[5] - sto.cheezecakecount < 0)
                        {
                            MessageBox.Show("현재 주문한 메뉴만큼 치즈 케익이 있지않습니다.");
                        }
                        if (sto[6] - sto.browniecount < 0)
                        {
                            MessageBox.Show("현재 주문한 메뉴만큼 브라우니가 있지않습니다.");
                        }
                        if (sto[7] - sto.tiramisucount < 0)
                        {
                            MessageBox.Show("현재 주문한 메뉴만큼 티라미슈가 있지않습니다.");
                        }
                        if (sto[8] - sto.muffincount < 0)
                        {
                            MessageBox.Show("현재 주문한 메뉴만큼 머핀이 있지않습니다.");
                        }
                        if (sto[9] - sto.bagelcount < 0)
                        {
                            MessageBox.Show("현재 주문한 메뉴만큼 베이글이 있지않습니다.");
                        }
                        if (sto[10] - sto.wafflecount < 0)
                        {
                            MessageBox.Show("현재 주문한 메뉴만큼 와플이 있지않습니다.");
                        }

                        if (sto[0] - sto.americanohcount - sto.cafelattehcount - sto.cappuccinohcount - sto.cafemochahcount - sto.caramelhcount - sto.americanoicount - sto.cafelatteicount - sto.cappuccinoicount - sto.cafemochaicount - sto.caramelicount >= 0 && sto[1] - sto.cafelattehcount - sto.cappuccinohcount - sto.cafemochahcount - sto.caramelhcount - sto.cafelatteicount - sto.cappuccinoicount - sto.cafemochaicount - sto.caramelicount >= 0 && sto[2] - sto.cafemochahcount - sto.cafemochaicount >= 0 &&
                            sto[3] - sto.caramelhcount - sto.caramelicount >= 0 && sto[4] - sto.chococakecount >= 0 && sto[5] - sto.cheezecakecount >= 0 && sto[6] - sto.browniecount >= 0 && sto[7] - sto.tiramisucount >= 0 && sto[8] - sto.muffincount >= 0 && sto[9] - sto.bagelcount >= 0 && sto[10] - sto.wafflecount >= 0)
                        {
                            sto.Stockstart();
                            sto.Stocksave();
                        }

                        sto.americanohcount = 0; sto.cafelattehcount = 0; sto.cappuccinohcount = 0; sto.cafemochahcount = 0; sto.caramelhcount = 0; sto.americanoicount = 0; sto.cafelatteicount = 0; sto.cappuccinoicount = 0; sto.cafemochaicount = 0; sto.caramelicount = 0; sto.chococakecount = 0; sto.cheezecakecount = 0; sto.browniecount = 0; sto.tiramisucount = 0; sto.muffincount = 0; sto.bagelcount = 0; sto.wafflecount = 0;
                        ord.americanohcount = ord.cafelattehcount = ord.cappuccinohcount = ord.cafemochahcount = ord.caramelhcount = ord.americanoicount = ord.cafelatteicount = ord.cappuccinoicount = ord.cafemochaicount = ord.caramelicount = ord.chococakecount = ord.cheezecakecount = ord.browniecount = ord.tiramisucount = ord.muffincount = ord.bagelcount = ord.wafflecount = 1;
                        ord.americanohsum = ord.cafelattehsum = ord.cappuccinohsum = ord.cafemochahsum = ord.caramelhsum = ord.americanoisum = ord.cafelatteisum = ord.cappuccinoisum = ord.cafemochaisum = ord.caramelisum = ord.chococakesum = ord.cheezecakesum = ord.browniesum = ord.tiramisusum = ord.muffinsum = ord.bagelsum = ord.wafflesum = 0;

                        stockError(); //재고가 일정량 및으로 내려가면 결제시 오류창 3번 띠우고 재고가 없으면 해당 재고가 필요로 하는 메뉴 버튼 잠금
                        break;
                }
            }
        } 

        private void button_Card_Click(object sender, EventArgs e)// 카드결제 버튼
        {
            int count = listView_order.Items.Count;
            if (count == 0)
            {
                MessageBox.Show("결제할 메뉴가 없습니다!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                textBox_cash.Text = textBox_sumcash.Text;
                DialogResult dlr = MessageBox.Show("카드결제 하시겠습니까?", "카드 결제", MessageBoxButtons.YesNo);
                switch (dlr)
                {
                    case DialogResult.Yes:
                        listView_order.Items.Clear();
                        textBox_cash.Text = "0";
                        textBox_cash2.Text = "0";
                        textBox_sumcash.Text = "0";
                        textBox_sumnumber.Text = "0";
                        textBox_dessertsum.Text = "0";

                        cash = 0;

                        sto.americanohcount += ord.americanohcount - 1;
                        sto.cafelattehcount += ord.cafelattehcount - 1;
                        sto.cappuccinohcount += ord.cappuccinohcount - 1;
                        sto.cafemochahcount += ord.cafemochahcount - 1;
                        sto.caramelhcount += ord.caramelhcount - 1;
                        sto.americanoicount += ord.americanoicount - 1;
                        sto.cafelatteicount += ord.cafelatteicount - 1;
                        sto.cappuccinoicount += ord.cappuccinoicount - 1;
                        sto.cafemochaicount += ord.cafemochaicount - 1;
                        sto.caramelicount += ord.caramelicount - 1;
                        sto.chococakecount += ord.chococakecount - 1;
                        sto.cheezecakecount += ord.cheezecakecount - 1;
                        sto.browniecount += ord.browniecount - 1;
                        sto.tiramisucount += ord.tiramisucount - 1;
                        sto.muffincount += ord.muffincount - 1;
                        sto.bagelcount += ord.bagelcount - 1;
                        sto.wafflecount += ord.wafflecount - 1;

                        sal.americanohsum += ord.AmericanohSum();
                        sal.cafelattehsum += ord.CafelattehSum();
                        sal.cappuccinohsum += ord.CappuccinohSum();
                        sal.cafemochahsum += ord.CafemochahSum();
                        sal.caramelhsum += ord.CaramelhSum();
                        sal.americanoisum += ord.AmericanoiSum();
                        sal.cafelatteisum += ord.CafelatteiSum();
                        sal.cappuccinoisum += ord.CappuccinoiSum();
                        sal.cafemochaisum += ord.CafemochaiSum();
                        sal.caramelisum += ord.CarameliSum();
                        sal.chococakesum += ord.ChococakeSum();
                        sal.cheezecakesum += ord.CheezecakeSum();
                        sal.browniesum += ord.BrownieSum();
                        sal.tiramisusum += ord.TiramisuSum();
                        sal.muffinsum += ord.MuffinSum();
                        sal.bagelsum += ord.BagelSum();
                        sal.wafflesum += ord.WaffleSum();

                        sto.Stockopen();

                        if (sto[0] - sto.americanohcount - sto.cafelattehcount - sto.cappuccinohcount - sto.cafemochahcount - sto.caramelhcount - sto.americanoicount - sto.cafelatteicount - sto.cappuccinoicount - sto.cafemochaicount - sto.caramelicount < 0)
                        {
                            MessageBox.Show("현재 주문한 메뉴만큼 원두가 있지않습니다.");
                            stockconn.Close();
                        }

                        if (sto[1] - sto.cafelattehcount - sto.cappuccinohcount - sto.cafemochahcount - sto.caramelhcount - sto.cafelatteicount - sto.cappuccinoicount - sto.cafemochaicount - sto.caramelicount < 0)
                        {
                            MessageBox.Show("현재 주문한 메뉴만큼 우유가 있지않습니다.");
                            stockconn.Close();
                        }

                        if (sto[2] - sto.cafemochahcount - sto.cafemochaicount < 0)
                        {
                            MessageBox.Show("현재 주문한 메뉴만큼 모카 시럽이 있지않습니다.");
                            stockconn.Close();
                        }

                        if (sto[3] - sto.caramelhcount - sto.caramelicount < 0)
                        {
                            MessageBox.Show("현재 주문한 메뉴만큼 카라멜 시럽이가 있지않습니다.");
                            stockconn.Close();
                        }

                        if (sto[4] - sto.chococakecount < 0)
                        {
                            MessageBox.Show("현재 주문한 메뉴만큼 초코 케익이 있지않습니다.");
                            stockconn.Close();
                        }
                        if (sto[5] - sto.cheezecakecount < 0)
                        {
                            MessageBox.Show("현재 주문한 메뉴만큼 치즈 케익이 있지않습니다.");
                            stockconn.Close();
                        }
                        if (sto[6] - sto.browniecount < 0)
                        {
                            MessageBox.Show("현재 주문한 메뉴만큼 브라우니가 있지않습니다.");
                            stockconn.Close();
                        }
                        if (sto[7] - sto.tiramisucount < 0)
                        {
                            MessageBox.Show("현재 주문한 메뉴만큼 티라미슈가 있지않습니다.");
                            stockconn.Close();
                        }
                        if (sto[8] - sto.muffincount < 0)
                        {
                            MessageBox.Show("현재 주문한 메뉴만큼 머핀이 있지않습니다.");
                            stockconn.Close();
                        }
                        if (sto[9] - sto.bagelcount < 0)
                        {
                            MessageBox.Show("현재 주문한 메뉴만큼 베이글이 있지않습니다.");
                            stockconn.Close();
                        }
                        if (sto[10] - sto.wafflecount < 0)
                        {
                            MessageBox.Show("현재 주문한 메뉴만큼 와플이 있지않습니다.");
                            stockconn.Close();
                        }

                        if (sto[0] - sto.americanohcount - sto.cafelattehcount - sto.cappuccinohcount - sto.cafemochahcount - sto.caramelhcount - sto.americanoicount - sto.cafelatteicount - sto.cappuccinoicount - sto.cafemochaicount - sto.caramelicount >= 0 && sto[1] - sto.cafelattehcount - sto.cappuccinohcount - sto.cafemochahcount - sto.caramelhcount - sto.cafelatteicount - sto.cappuccinoicount - sto.cafemochaicount - sto.caramelicount >= 0 && sto[2] - sto.cafemochahcount - sto.cafemochaicount >= 0 &&
                            sto[3] - sto.caramelhcount - sto.caramelicount >= 0 && sto[4] - sto.chococakecount >= 0 && sto[5] - sto.cheezecakecount >= 0 && sto[6] - sto.browniecount >= 0 &&  sto[7] - sto.tiramisucount >= 0 && sto[8] - sto.muffincount >= 0 && sto[9] - sto.bagelcount >= 0 && sto[10] - sto.wafflecount >= 0)
                        {
                            sto.Stockstart();
                            sto.Stocksave();
                        }


                        sto.americanohcount = 0; sto.cafelattehcount = 0; sto.cappuccinohcount = 0; sto.cafemochahcount = 0; sto.caramelhcount = 0; sto.americanoicount = 0; sto.cafelatteicount = 0; sto.cappuccinoicount = 0; sto.cafemochaicount = 0; sto.caramelicount = 0; sto.chococakecount = 0; sto.cheezecakecount = 0; sto.browniecount = 0; sto.tiramisucount = 0; sto.muffincount = 0; sto.bagelcount = 0; sto.wafflecount = 0;
                        ord.americanohcount = ord.cafelattehcount = ord.cappuccinohcount = ord.cafemochahcount = ord.caramelhcount = ord.americanoicount = ord.cafelatteicount = ord.cappuccinoicount = ord.cafemochaicount = ord.caramelicount = ord.chococakecount = ord.cheezecakecount = ord.browniecount = ord.tiramisucount = ord.muffincount = ord.bagelcount = ord.wafflecount = 1;
                        ord.americanohsum = ord.cafelattehsum = ord.cappuccinohsum = ord.cafemochahsum = ord.caramelhsum = ord.americanoisum = ord.cafelatteisum = ord.cappuccinoisum = ord.cafemochaisum = ord.caramelisum = ord.chococakesum = ord.cheezecakesum = ord.browniesum = ord.tiramisusum = ord.muffinsum = ord.bagelsum = ord.wafflesum = 0;

                        stockError();//재고가 일정량 및으로 내려가면 결제시 오류창 3번 띠우고 재고가 없으면 해당 재고가 필요로 하는 메뉴 버튼 잠금
                        break;
                }
            }
        }

        private void button_cancel2_Click(object sender, EventArgs e)// 전체 취소
        {
            int count = listView_order.Items.Count;
            if (count == 0)
            {
                MessageBox.Show("취소할 메뉴가 없습니다!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                listView_order.Items.Clear();
                textBox_cash.Text = "0";
                textBox_cash2.Text = "0";
                textBox_sumcash.Text = "0";
                textBox_sumnumber.Text = "0";
                textBox_dessertsum.Text = "0";
                cash = 0;
                ord.americanohcount = ord.cafelattehcount = ord.cappuccinohcount = ord.cafemochahcount = ord.caramelhcount = ord.americanoicount = ord.cafelatteicount = ord.cappuccinoicount = ord.cafemochaicount = ord.caramelicount = ord.chococakecount = ord.cheezecakecount = ord.browniecount = ord.tiramisucount = ord.muffincount = ord.bagelcount = ord.wafflecount = 1;
                ord.americanohsum = ord.cafelattehsum = ord.cappuccinohsum = ord.cafemochahsum = ord.caramelhsum = ord.americanoisum = ord.cafelatteisum = ord.cappuccinoisum = ord.cafemochaisum = ord.caramelisum = ord.chococakesum = ord.cheezecakesum = ord.browniesum = ord.tiramisusum = ord.muffinsum = ord.bagelsum = ord.wafflesum = 0;
            }
        }

        private void button_cancel1_Click(object sender, EventArgs e)// 선택 취소
        {
            int count = listView_order.Items.Count;
            if (count == 0)
            {
                MessageBox.Show("취소할 메뉴가 없습니다!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                if (listView_order.FocusedItem.SubItems[0].Text == button_Americanoh.Text)
                {
                    ord.americanohcount = 1;
                    ord.americanohsum = 0;
                }
                else if (listView_order.FocusedItem.SubItems[0].Text == button_Americanoi.Text)
                {
                    ord.americanoicount = 1;
                    ord.americanoisum = 0;
                }
                else if (listView_order.FocusedItem.SubItems[0].Text == button_Cafelatteh.Text)
                {
                    ord.cafelattehcount = 1;
                    ord.cafelattehsum = 0;

                }
                else if (listView_order.FocusedItem.SubItems[0].Text == button_Cafelattei.Text)
                {
                    ord.cafelatteicount = 1;
                    ord.cafelatteisum = 0;
                }
                else if (listView_order.FocusedItem.SubItems[0].Text == button_Cappuccinoh.Text)
                {
                    ord.cappuccinohcount = 1;
                    ord.cappuccinohsum = 0;
                }
                else if (listView_order.FocusedItem.SubItems[0].Text == button_Cappuccinoi.Text)
                {
                    ord.cappuccinoicount = 1;
                    ord.cappuccinoisum = 0;
                }
                else if (listView_order.FocusedItem.SubItems[0].Text == button_CafeMochah.Text)
                {
                    ord.cafemochahcount = 1;
                    ord.cafemochahsum = 0;
                }
                else if (listView_order.FocusedItem.SubItems[0].Text == button_CafeMochai.Text)
                {
                    ord.cafemochaicount = 1;
                    ord.cafemochaisum = 0;

                }
                else if (listView_order.FocusedItem.SubItems[0].Text == button_caramelh.Text)
                {
                    ord.caramelhcount = 1;
                    ord.caramelhsum = 0;

                }
                else if (listView_order.FocusedItem.SubItems[0].Text == button_carameli.Text)
                {
                    ord.caramelicount = 1;
                    ord.caramelisum = 0;
                }
                else if (listView_order.FocusedItem.SubItems[0].Text == button_Chococake.Text)
                {
                    ord.chococakecount = 1;
                    ord.chococakesum = 0;
                }
                else if (listView_order.FocusedItem.SubItems[0].Text == button_Cheezecake.Text)
                {
                    ord.cheezecakecount = 1;
                    ord.cheezecakesum = 0;
                }
                else if (listView_order.FocusedItem.SubItems[0].Text == button_Brownie.Text)
                {
                    ord.browniecount = 1;
                    ord.browniesum = 0;
                }
                else if (listView_order.FocusedItem.SubItems[0].Text == button_Tiramisu.Text)
                {
                    ord.tiramisucount = 1;
                    ord.tiramisusum = 0;
                }
                else if (listView_order.FocusedItem.SubItems[0].Text == button_Muffin.Text)
                {
                    ord.muffincount = 1;
                    ord.muffinsum = 0;
                }
                else if (listView_order.FocusedItem.SubItems[0].Text == button_Bagel.Text)
                {
                    ord.bagelcount = 1;
                    ord.bagelsum = 0;
                }
                else if (listView_order.FocusedItem.SubItems[0].Text == button_Waffle.Text)
                {
                    ord.wafflecount = 1;
                    ord.wafflesum = 0;
                }
                textBox_sumnumber.Text = Convert.ToString(ord.SumNumber());
                textBox_sumcash.Text = Convert.ToString(ord.SumCash());
                textBox_dessertsum.Text = Convert.ToString(ord.Sumdessert());
                listView_order.Items.Remove(listView_order.FocusedItem); // 컨트롤 부분을 제거하는거.
            }
        }











        // ------------------------------------------------------------------회원 관리-----------------------------------------------------------------------------
        private void button_member_Click(object sender, EventArgs e)// 회원관리 버튼
        {
            lvList_Insert();
            if (groupBox_member.Visible == false)
            {
                groupBox_member.Visible = true;
            }
            else
            {
                groupBox_member.Visible = false;
            }
            groupBox_order.Visible = false;
            groupBox_stock.Visible = false;
            groupBox_sales.Visible = false;
            openclosecount = 0;
            forcount = 0;
            textBox_name.Text = "";
            textBox_tell.Text = "";
            textBox_birthday.Text = "";
            textBox_se.Text = "";
        }

        private void buttonIN_Click(object sender, EventArgs e) // 회원 추가 버튼
        {
            if (Control_Check())
            {
                if (textBox_birthday.Text.Length == 8 && textBox_tell.Text.Length ==11)
                {
                    memberconn = new OleDbConnection(memberfile);
                    memberconn.Open();
                    string con = "insert into member(Name,Birthday,Tell) values('" + textBox_name.Text + "','" + textBox_birthday.Text + "','" + textBox_tell.Text + "')";
                    membercomm = new OleDbCommand(con, memberconn);
                    int i = membercomm.ExecuteNonQuery();
                    if (i == 1)
                    {
                        MessageBox.Show("데이터가 저장되었습니다", "알림", MessageBoxButtons.OK);
                        lvList_Insert(); // 리스트뷰에 db 내용 삽입하는 메소드
                        Control_Empty(); // 텍스트 박스 초기화 하는 메소드
                    }
                    else
                    {
                        MessageBox.Show("데이터가 저장되지 못했습니다", "알림", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    memberconn.Close();
                }
                else {
                    MessageBox.Show("생일의 길이는 6자로, 휴대폰 번호는 11자로 맞춰주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        private void buttonMO_Click(object sender, EventArgs e) // 정보 수정 버튼
        {
            if (Control_Check())
            {
                if (textBox_birthday.Text.Length == 8 && textBox_tell.Text.Length == 11) {
                    memberconn = new OleDbConnection(memberfile);
                    memberconn.Open();
                    string Sql = "update member set Name='" + textBox_name.Text + "',Birthday=" + textBox_birthday.Text + ",Tell='" + textBox_tell.Text + "'";
                    Sql += "where Name = '" + SName + "'and Birthday=" + Sbirthday + "and Tell='" + STell + "'";
                    membercomm = new OleDbCommand(Sql, memberconn);
                    int i = membercomm.ExecuteNonQuery();
                    if (i == 1)
                    {
                        MessageBox.Show("데이터가 수정되었습니다", "알림", MessageBoxButtons.OK);
                        lvList_Insert(); // 리스트뷰에 db 내용 삽입하는 메소드
                        Control_Empty(); // 텍스트 박스 초기화 하는 메소드
                    }
                    else
                    {
                        MessageBox.Show("데이터가 수정되지 못했습니다", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    memberconn.Close();
                }
                else {
                    MessageBox.Show("생일의 길이는 6자로, 휴대폰 번호는 11자로 맞춰주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            membercount = forcount = 0;
        }

        private void buttonDEL_Click(object sender, EventArgs e) // 회원 삭제 버튼
        {
            if (Control_Check())
            {
                DialogResult dlr = MessageBox.Show("삭제할까요?", "알림", MessageBoxButtons.YesNo);
                switch (dlr)
                {
                    case DialogResult.Yes:

                        memberconn = new OleDbConnection(memberfile);
                        memberconn.Open();
                        string Sql = "Delete from member where Name='" + SName + "'and Birthday=" + Sbirthday + "and Tell+'" + STell + "'";
                        membercomm = new OleDbCommand(Sql, memberconn);
                        int i = membercomm.ExecuteNonQuery();
                        if (i == 1)
                        {
                            MessageBox.Show("데이터가 삭제되었습니다", "알림", MessageBoxButtons.OK);
                            memberconn.Close();
                            lvList_Insert(); // 리스트뷰에 db 내용 삽입하는 메소드
                            Control_Empty(); // 텍스트 박스 초기화 하는 메소드
                        }
                        else
                        {
                            MessageBox.Show("데이터가 삭제되지 못했습니다", "알림", MessageBoxButtons.OK);
                            memberconn.Close();
                        }
                        break;
                }
                membercount = forcount = 0;
            }
        }

        private void buttonSER_Click(object sender, EventArgs e) // 회원 검색 버튼
        {
            if (textBox_se.Text == "")
            {
                MessageBox.Show("검색할 이름을 입력하세요!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int count = listView_member.Items.Count; // 리스트뷰 항목 수 반환
                if (membercount > 0) // 멤버 카운트 버튼 한번 클릭했는지 여러번 클릭했는지 확인
                {
                    for (int i = forcount; i < count; i++) // 리스트 뷰 내에서 검색하는 포문
                    {
                        if (listView_member.Items[i].SubItems[0].Text == textBox_se.Text)
                        {
                            listView_member.Items[i].Focused = true;
                            listView_member.Items[i].Selected = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                            textBox_name.Text = listView_member.FocusedItem.SubItems[0].Text;
                            textBox_birthday.Text = listView_member.FocusedItem.SubItems[1].Text;
                            textBox_tell.Text = listView_member.FocusedItem.SubItems[2].Text;
                            SName = listView_member.FocusedItem.SubItems[0].Text;
                            Sbirthday = listView_member.FocusedItem.SubItems[1].Text;
                            STell = listView_member.FocusedItem.SubItems[2].Text;
                            forcount++;
                            if (forcount == count) // 포문을 끝까지 다 확인하고 나면
                            {
                                membercount = forcount = 0; // 멤버 카운트, 포문 카운트 초기화
                            }
                            break;
                        }
                        else
                        {
                            forcount++;
                            if (forcount == count) // 포문을 끝까지 다 확인하고 나면
                            {
                                membercount = forcount = 0; // 멤버 카운트, 포문 카운트 초기화
                            }
                        }
                    }
                }

                else
                {
                    for (int i = 0; i < count; i++) // 리스트 뷰 내에서 검색하는 포문
                    {
                        if (listView_member.Items[i].SubItems[0].Text == textBox_se.Text)
                        {
                            listView_member.Items[i].Focused = true;
                            listView_member.Items[i].Selected = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                            textBox_name.Text = listView_member.FocusedItem.SubItems[0].Text;
                            textBox_birthday.Text = listView_member.FocusedItem.SubItems[1].Text;
                            textBox_tell.Text = listView_member.FocusedItem.SubItems[2].Text;
                            SName = listView_member.FocusedItem.SubItems[0].Text;
                            Sbirthday = listView_member.FocusedItem.SubItems[1].Text;
                            STell = listView_member.FocusedItem.SubItems[2].Text;
                            forcount++;
                            membercount++;
                            break;
                        }
                        else
                        {
                            forcount++;
                        }
                    }
                }
            }
        }

        private void listView_member_SelectedIndexChanged(object sender, EventArgs e) //리스트뷰 클릭시 해당 회원 이름 텍스트 박스로 출력
        {
            textBox_se.Text = listView_member.FocusedItem.SubItems[0].Text;
        }

        private Boolean Control_Check() // 회원관리 입력창 예외 처리
        {
            if (textBox_name.Text == "")
            {
                MessageBox.Show("이름을 입력하세요!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_name.Focus();
                return false;
            }
            else if (textBox_birthday.Text == "")
            {
                MessageBox.Show("생일을 입력하세요!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_birthday.Focus();
                return false;
            }
            else if (textBox_tell.Text == "")
            {
                MessageBox.Show("전화번호를 입력하세요!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_tell.Focus();
                return false;
            }
            else
                return true;
        }

        private void Control_Empty() // 텍스트 박스 초기화
        {
            textBox_name.Text = "";
            textBox_tell.Text = "";
            textBox_birthday.Text = "";
            textBox_se.Text = "";
        }

        private void lvList_Insert()// 내용 삽입
        {
            memberconn = new OleDbConnection(memberfile);
            memberconn.Open();

            listView_member.Items.Clear();
            membercomm = new OleDbCommand("Select * From member", memberconn);
            var myRead = membercomm.ExecuteReader();
            while (myRead.Read())
            {
                var strArray = new String[] { myRead["Name"].ToString(), myRead["Birthday"].ToString(), myRead["Tell"].ToString() };
                var lvt = new ListViewItem(strArray);
                listView_member.Items.Add(lvt);
            }
            myRead.Close();
            memberconn.Close();
        }













        // ------------------------------------------------------------------재고 관리-----------------------------------------------------------------------------
        private void button_stock_Click(object sender, EventArgs e)// 재고관리 버튼
        {
            listView_stockin();
            if (groupBox_stock.Visible == false)
            {
                groupBox_stock.Visible = true;
            }
            else
            {
                groupBox_stock.Visible = false;
            }
            groupBox_member.Visible = false;
            groupBox_order.Visible = false;
            groupBox_sales.Visible = false;
            openclosecount = 0;
            forcount = 0;
            stockError2();
        }

        private void listView_stock_SelectedIndexChanged(object sender, EventArgs e) //리스트뷰 클릭시 해당 재고명 텍스트 박스로 출력
        {
            textBox_stockse.Text = listView_stock.FocusedItem.SubItems[0].Text;
        }

        private void button_stockse_Click(object sender, EventArgs e)// 재고 검색 버튼
        {
            if (textBox_stockse.Text == "")
            {
                MessageBox.Show("검색할 재고명을 입력하세요!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int count = listView_stock.Items.Count; // 리스트뷰 항목 수 반환
                if (stockcount > 0)
                {
                    for (int i = forcount; i < count; i++) // 리스트 뷰 내에서 검색하는 포문
                    {
                        if (listView_stock.Items[i].SubItems[0].Text == textBox_stockse.Text)
                        {
                            listView_stock.Items[i].Focused = true;
                            listView_stock.Items[i].Selected = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                            textBox_stockname.Text = listView_stock.FocusedItem.SubItems[0].Text;
                            textBox_stockcount.Text = listView_stock.FocusedItem.SubItems[1].Text;
                            textBox_stocknote.Text = listView_stock.FocusedItem.SubItems[2].Text;
                            Stockname = listView_stock.FocusedItem.SubItems[0].Text;
                            Stockcount = listView_stock.FocusedItem.SubItems[1].Text;
                            Stocknote = listView_stock.FocusedItem.SubItems[2].Text;
                            forcount++;
                            break;
                        }
                        else
                        {
                            if (forcount == count - 1 || forcount == count - 2)
                            {
                                stockcount = forcount = 0;
                            }
                            else
                                forcount++;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < count; i++) // 리스트 뷰 내에서 검색하는 포문
                    {
                        if (listView_stock.Items[i].SubItems[0].Text == textBox_stockse.Text)
                        {
                            listView_stock.Items[i].Focused = true;
                            listView_stock.Items[i].Selected = true; // 리스트뷰 컨트롤에서 항목 선택 가능하도록 하는거
                            textBox_stockname.Text = listView_stock.FocusedItem.SubItems[0].Text;
                            textBox_stockcount.Text = listView_stock.FocusedItem.SubItems[1].Text;
                            textBox_stocknote.Text = listView_stock.FocusedItem.SubItems[2].Text;
                            Stockname = listView_stock.FocusedItem.SubItems[0].Text;
                            Stockcount = listView_stock.FocusedItem.SubItems[1].Text;
                            Stocknote = listView_stock.FocusedItem.SubItems[2].Text;
                            forcount++;
                        }
                    }
                    stockcount++;
                }
            }
        }

        public void stockError()// 재고량 부족하면 알려주는건데 3번만 알려주고 주문 메뉴에서 결제시 사용됨.
        {
            if (stockErrorcount <= 3) // 프로그램 실행동안 메세지를 3번만 출력함
            {
                if (sto[0] <= 50 || sto[1] <= 12 || sto[2] <= 40 || sto[3] <= 40 || sto[4] <= 10 || sto[5] <= 10 || sto[6] <= 10 || sto[7] <= 10 || sto[8] <= 10 || sto[9] <= 10 || sto[10] <= 10)
                { // 재고들이 특정량 이하일 경우
                    MessageBox.Show("주문해야할 재고가 있습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    stockErrorcount++;
                }
            }

            if (sto[0] <= 0) // 원두가 없으면 원두 사용하는 메뉴 버튼 잠금
            {
                button_Americanoh.Enabled = false;
                button_Americanoi.Enabled = false;
                button_Cafelatteh.Enabled = false;
                button_Cafelattei.Enabled = false;
                button_Cappuccinoh.Enabled = false;
                button_Cappuccinoi.Enabled = false;
                button_CafeMochah.Enabled = false;
                button_CafeMochai.Enabled = false;
                button_caramelh.Enabled = false;
                button_carameli.Enabled = false;
            }

            if (sto[1] <= 0) // 우유가 없으면 우유 사용하는 메뉴 버튼 잠금
            {
                button_Cafelatteh.Enabled = false;
                button_Cafelattei.Enabled = false;
                button_Cappuccinoh.Enabled = false;
                button_Cappuccinoi.Enabled = false;
                button_CafeMochah.Enabled = false;
                button_CafeMochai.Enabled = false;
                button_caramelh.Enabled = false;
                button_carameli.Enabled = false;
            }
           
            if (sto[2] <= 0) // 모카 시럽이 없으면 모카 시럽 사용하는 메뉴 버튼 잠금
            {
                button_CafeMochah.Enabled = false;
                button_CafeMochai.Enabled = false;
            }

            if (sto[3] <= 0) // 카라멜 시럽이 없으면 카라멜 시럽 사용하는 메뉴 버튼 잠금
            {
                button_caramelh.Enabled = false;
                button_carameli.Enabled = false;
            }
            
            if (sto[4] <= 0) // 초코 케익이 없으면 초코케익 잠금
            {

                button_Chococake.Enabled = false;
            }           

            if (sto[5] <= 0) // 치즈 케익이 없으면 치즈 케익 잠금
            {
                button_Cheezecake.Enabled = false;
            }
            
            if (sto[6] <= 0) // 브라우니가 없으면 브라우니 잠금
            {
                button_Brownie.Enabled = false;
            }
           
            if (sto[7] <= 0) // 티라미슈가 없으면 티라미슈 잠금
            {
                button_Tiramisu.Enabled = false;
            }
           
            if (sto[8] <= 0) // 머핀이 없으면 머핀 잠금
            {
                button_Muffin.Enabled = false;
            }
           
            if (sto[9] <= 0) // 베이글이 없으면 베이글 잠금
            {
                button_Bagel.Enabled = false;
            }
           
            if (sto[10] <= 0) // 와플이 없으면 와플 잠금
            {
                button_Waffle.Enabled = false;
            }
        }

        public void stockError2()// 재고량 부족하면 알려주는건데 주문메뉴 사용시 사용되는데 재고 수정 검색시도 사용됨.
        {
            sto.Stockopen(); // 데이터 베이스로 현재 재고량 저장하는 STOCK클래스의 메소드

            if (sto[0] <= 50) //
            {
                MessageBox.Show("원두가 얼마 남지 않았습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (sto[0] <= 0)
            {
                MessageBox.Show("더이상 원두가 남아있지 않습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (sto[0] > 0 && sto[1] > 0 && sto[2] > 0 && sto[3] > 0)
            { //즉 원두랑 우유랑 모카, 카라멜시럽이 채워지면 버튼 잠금 해재
                button_Americanoh.Enabled = true;
                button_Americanoi.Enabled = true;
                button_Cafelatteh.Enabled = true;
                button_Cafelattei.Enabled = true;
                button_Cappuccinoh.Enabled = true;
                button_Cappuccinoi.Enabled = true;
                button_CafeMochah.Enabled = true;
                button_CafeMochai.Enabled = true;
                button_caramelh.Enabled = true;
                button_carameli.Enabled = true;
            }
            else if (sto[0] > 0)// 즉 원두만 채워지면 잠금 해재
            {
                button_Americanoh.Enabled = true;
                button_Americanoi.Enabled = true;
            }

            if (sto[1] <= 12)
            {
                MessageBox.Show("우유가 얼마 남지 않았습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (sto[1] <= 0)
            {
                MessageBox.Show("더이상 우유가 남아있지 않습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (sto[0] > 0 && sto[1] > 0) // 즉 원두랑 우유가 채워지면 버튼 잠금 해재
            {
                button_Cafelatteh.Enabled = true;
                button_Cafelattei.Enabled = true;
                button_Cappuccinoh.Enabled = true;
                button_Cappuccinoi.Enabled = true;
            }

            if (sto[2] <= 40)
            {
                MessageBox.Show("모카시럽이 얼마 남지 않았습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (sto[2] <= 0)
            {
                MessageBox.Show("더이상 모카시럽이 남아있지 않습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (sto[0] > 0 && sto[1] > 0 && sto[2] > 0) // 원두랑 우유량 모카시럽이 채워지면 버튼 잠금 해재
            {
                button_CafeMochah.Enabled = true;
                button_CafeMochai.Enabled = true;
            }

            if (sto[3] <= 40)
            {
                MessageBox.Show("카라멜시럽이 얼마 남지 않았습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (sto[3] <= 0)
            {
                MessageBox.Show("더이상 카라멜시럽이 남아있지 않습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (sto[0] > 0 && sto[1] > 0 && sto[3] > 0) // 원두랑 우유량 카라멜시럽이 채워지면 버튼 잠금 해재
            {
                button_caramelh.Enabled = true;
                button_carameli.Enabled = true;
            }

            if (sto[4] <= 10)
            {
                MessageBox.Show("조각 케익(초코)가 얼마 남지 않았습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (sto[4] <= 0)
            {
                MessageBox.Show("더이상 조각 케익(초코)가 남아있지 않습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (sto[4] > 0) button_Chococake.Enabled = true;

            if (sto[5] <= 1)
            {
                MessageBox.Show("조각 케익(치즈)가 얼마 남지 않았습니다..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (sto[5] <= 0)
            {
                MessageBox.Show("더이상 조각 케익(치즈)가 남아있지 않습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (sto[5] > 0) button_Cheezecake.Enabled = true;

            if (sto[6] <= 10)
            {
                MessageBox.Show("브라우니가 얼마 남지 않았습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (sto[6] <= 0)
            {
                MessageBox.Show("더이상 브라우니가 남아있지 않습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (sto[6] > 0) button_Brownie.Enabled = true;

            if (sto[7] <= 10)
            {
                MessageBox.Show("티라미슈가 얼마 남지 않았습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (sto[7] <= 0)
            {
                MessageBox.Show("더이상 티라미슈가 남아있지 않습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (sto[7] > 0) button_Tiramisu.Enabled = true;

            if (sto[8] <= 10)
            {
                MessageBox.Show("머핀이 얼마 남지 않았습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (sto[8] <= 0)
            {
                MessageBox.Show("더이상 머핀이 남아있지 않습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (sto[8] > 0) button_Muffin.Enabled = true;

            if (sto[9] <= 10)
            {
                MessageBox.Show("베이글이 얼마 남지 않았습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (sto[9] <= 0)
            {
                MessageBox.Show("더이상 베이글이 남아있지 않습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (sto[9] > 0) button_Bagel.Enabled = true;

            if (sto[10] <= 10)
            {
                MessageBox.Show("와플이 얼마 남지 않았습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (sto[10] <= 0)
            {
                MessageBox.Show("더이상 와플이 남아있지 않습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (sto[10] > 0) button_Waffle.Enabled = true;
        }

        private void button_stockmo_Click(object sender, EventArgs e)// 재고 수정 버튼 클릭
        {
            if (Control_Check2())
            {
                stockconn = new OleDbConnection(stockfile);
                stockconn.Open();
                string Sql = "update stock set Stockname='" + textBox_stockname.Text + "',Stockcount=" + textBox_stockcount.Text + ",Stocknote='" + textBox_stocknote.Text + "'";
                Sql += "where Stockname = '" + Stockname + "'and Stockcount=" + Stockcount + "and Stocknote='" + Stocknote + "'";
                stockcomm = new OleDbCommand(Sql, stockconn);
                int i = stockcomm.ExecuteNonQuery();
                if (i == 1)
                {
                    MessageBox.Show("재고가 수정되었습니다", "알림", MessageBoxButtons.OK);
                    stockconn.Close();
                    listView_stockin();
                    Control_Empty2();
                    stockError2();
                }
                else
                {
                    MessageBox.Show("재고가 수정되지 못했습니다", "알림", MessageBoxButtons.OK);
                    stockconn.Close();
                }
                
            }
            stockcount = forcount = 0;
        }

        private Boolean Control_Check2() // 재고 관리 예외 처리
        {
            if (textBox_stockname.Text == "")
            {
                MessageBox.Show("재고명을 입력하세요!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_stockname.Focus();
                return false;
            }
            else if (textBox_stockcount.Text == "")
            {
                MessageBox.Show("수량을 입력하세요!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_stockcount.Focus();
                return false;
            }
            else if (textBox_stocknote.Text == "")
            {
                MessageBox.Show("비고를 입력하세요!!( 없으면 - )", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_stocknote.Focus();
                return false;
            }
            else
                return true;
        }

        private void Control_Empty2() // 텍스트 박스 초기화
        {
            textBox_stockname.Text = "";
            textBox_stockcount.Text = "";
            textBox_stocknote.Text = "";
        }

        private void listView_stockin() // 내용 삽입
        {
            listView_stock.Items.Clear();
            stockconn = new OleDbConnection(stockfile);
            stockconn.Open();
            stockcomm = new OleDbCommand("Select * From stock", stockconn);
            var myRead = stockcomm.ExecuteReader();
            while (myRead.Read())
            {
                var strArray = new String[] { myRead["Stockname"].ToString(), myRead["Stockcount"].ToString(), myRead["Stocknote"].ToString() };
                var lvt = new ListViewItem(strArray);
                listView_stock.Items.Add(lvt);
            }
            myRead.Close();
            stockconn.Close();
        }


       

        // ------------------------------------------------------------------매출 관리-----------------------------------------------------------------------------
        private void button_sales_Click(object sender, EventArgs e)// 매출관리 버튼
        {
            if (openclosecount == 1)
            {
                if (groupBox_sales.Visible == false)
                {
                    groupBox_sales.Visible = true;
                }
                else
                {
                    groupBox_sales.Visible = false;
                    openclosecount = 0;
                }
                groupBox_member.Visible = false;
                groupBox_stock.Visible = false;
                groupBox_order.Visible = false;
            }
            else
            {
                Login login = new Login(this);
                login.ShowDialog();
            }
        }

        private void button_salessum_Click(object sender, EventArgs e) // 오늘 매출 확인 
        {
            textBox_salessum.Text = Convert.ToString(sal.salessum);
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e) // 달력 날짜 클릭하면 해당 날짜 텍스트 박스에 뛰우는 이벤트
        {
            DateTime date = monthCalendar1.SelectionStart; // data에 달력 시작 날짜를 넣음
            string day = date.ToShortDateString().Replace("-", ""); // 달력 시작 날짜를 가져오는데 날짜 형식에서 "-"부분을 ""로 바꿔주는거.
            textBox_day.Text = day;

            salesconn = new OleDbConnection(salesfile);
            salesconn.Open();
            DataTable schemaTab = salesconn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new Object[] { null, null, null, "TABLE" });  // 테이블 이름을 빼오기위해 사용
            int count = 0; // 카운트 매출이 있는지 없는지 확인용도

            for (int i = 0; i < schemaTab.Rows.Count; i++) //테이블의 개수만큼 포문을 돌림
            {
                string sTableNm = schemaTab.Rows[i].ItemArray[2].ToString(); //테이블의 이름을 가져와서 저장한다.
                if (sTableNm != day) // 테이블 이름이랑 오늘 날짜랑 다르면 카운트 하는 부분 
                {
                    count++;
                }
            }

            if (schemaTab.Rows.Count - 1 == count) // 만약에 테이블의 개수 -1이 카운트 한 값과 같으면 해당 테이블은 존재하므로 매출이 존재한다.
            {
                string salesok = "select * from " + day; // 데이터베이스에서 해당 날짜의 테이블의 필드 내용을 가져옴

                salescomm = new OleDbCommand(salesok, salesconn);
                OleDbDataReader sr = salescomm.ExecuteReader();

                while (sr.Read())
                {
                    Salesday = sr.GetInt32(0); // 날짜를 저장
                    Salesmuney = sr.GetInt32(1); // 매출을 저장
                }
                textBox_sales.Text = Convert.ToString(Salesmuney); // 텍스트 박스에 매출 출력
                sr.Close();
            }
            else // 아니면 이제 해당 날짜에 매출이 없으므로 매출을 추가해 줄 필요가 있다.
            {
                textBox_sales.Text = "";
                MessageBox.Show("해당 날짜에 매출이 없습니다.");
            }
            salesconn.Close();
        }

        private void button_salesadd_Click(object sender, EventArgs e) // 매출 추가 버튼 클릭
        {
            if (textBox_day.Text == "")
            {
                MessageBox.Show("매출을 추가할 날짜를 선택하세요", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox_sales.Text != ""&& textBox_salessum.Text == "")
            {
                MessageBox.Show("이미 매출이 있습니다 매출 수정 버튼을 이용하세요", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox_salessum.Text == "") {
                MessageBox.Show("매출을 입력하세요", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                salesconn = new OleDbConnection(salesfile);
                salesconn.Open();

                DateTime date = monthCalendar1.SelectionStart; // data에 달력 시작 날짜를 넣음
                string day = date.ToShortDateString().Replace("-", ""); // 달력 시작 날짜를 가져오는데 날짜 형식에서 "-"부분을 ""로 바꿔주는거.

                string salesadd = "create table " + day + "(날짜 int, 매출 int)"; // 클릭한 날짜의 테이블을 만들고 안에 날짜 매출 필드를 만듬.
                OleDbCommand salescomm = new OleDbCommand(salesadd, salesconn);
                int a = salescomm.ExecuteNonQuery();

                string salesadd1 = "Insert into " + day + " values(" + day + "," + textBox_salessum.Text + ")"; // 날짜 매출 필드안에 값을 집어넣어줌
                OleDbCommand salescomm1 = new OleDbCommand(salesadd1, salesconn);
                int b = salescomm1.ExecuteNonQuery();

                MessageBox.Show("매출 추가가 완료되었습니다.", "OK", MessageBoxButtons.OK, MessageBoxIcon.None);
                salesconn.Close();
            }
        }

        private void button_salesmo_Click(object sender, EventArgs e) // 매출 수정 버튼 클릭 
        {
            if (textBox_day.Text == "")
            {
                MessageBox.Show("매출을 수정할 날짜를 선택하세요", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox_sales.Text == "")
            {
                MessageBox.Show("수정할 매출을 입력하세요", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                salesconn = new OleDbConnection(salesfile);
                salesconn.Open();

                DateTime date = monthCalendar1.SelectionStart; // data에 달력 시작 날짜를 넣음
                string day = date.ToShortDateString().Replace("-", ""); // 달력 시작 날짜를 가져오는데 날짜 형식에서 "-"부분을 ""로 바꿔주는거.

                string salesok = "select * from " + day;


                Int32 ok = 0, ok1 = 0; // 테이블내 날짜와 매출의 값을 저장하는 변수
                salescomm = new OleDbCommand(salesok, salesconn);
                OleDbDataReader sr = salescomm.ExecuteReader();

                while (sr.Read())
                {
                    ok = sr.GetInt32(0);
                    ok1 = sr.GetInt32(1);
                }

                string salesmo = "UPDATE " + day + " set 날짜=" + ok + ",매출='" + textBox_sales.Text + "'"; // 데이터베이스에 day 테이블 안에 날짜는 ok로 매출은 sales의 텍스트로 아래의 조건에 만족하는 곳으로 바꿔줌
                salesmo += "where 날짜=" + ok + "";

                OleDbCommand salescomm1 = new OleDbCommand(salesmo, salesconn);
                int a = salescomm1.ExecuteNonQuery();
                if (a == 1)
                {
                    MessageBox.Show("매출 수정이 완료되었습니다.", "OK", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                else {
                    MessageBox.Show("매출 수정이 되지 못했습니다.", "OK", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                salesconn.Close();
            }
        }

        private void button_all_Click(object sender, EventArgs e) // 매출 목록 버튼 클릭
        {
            listView_sales.Items.Clear();
            salesconn = new OleDbConnection(salesfile);
            salesconn.Open();
            DataTable schemaTab = salesconn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new Object[] { null, null, null, "TABLE" });

            DateTime date = monthCalendar1.SelectionStart; // data에 달력 시작 날짜를 넣음
            string day = date.ToShortDateString().Replace("-", ""); // 달력 시작 날짜를 가져오는데 날짜 형식에서 "-"부분을 ""로 바꿔주는거.


            for (int i = 0; i < schemaTab.Rows.Count; i++)// 테이블 개수만큼 포문을 돌림
            {
                string sTableNm = schemaTab.Rows[i].ItemArray[2].ToString(); // 테이블의 이름을 저장
                string salesok = "select * from " + sTableNm; // 데이터베이스에서 해당 테이블에 내용을 가져옴

                Int32 ok = 0, ok1 = 0;

                salescomm = new OleDbCommand(salesok, salesconn);
                OleDbDataReader sr = salescomm.ExecuteReader();

                while (sr.Read())
                {
                    ok = sr.GetInt32(0); // 날짜를 저장
                    ok1 = sr.GetInt32(1); // 매출을 저장
                    var strArry = new string[] { ok.ToString(), ok1.ToString() };
                    var lvt = new ListViewItem(strArry);
                    listView_sales.Items.Add(lvt);
                }
            }
            salesconn.Close();

        }

        private void button_salesde_Click(object sender, EventArgs e) // 매출 삭제 버튼 클릭
        {
            if (textBox_day.Text == "")
            {
                MessageBox.Show("매출 삭제할 날짜를 선택하세요", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox_sales.Text == "") {
                MessageBox.Show("해당 매출은 이미 없습니다.", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dlr = MessageBox.Show("삭제할까요?", "알림", MessageBoxButtons.YesNo);
                switch (dlr)
                {
                    case DialogResult.Yes:
                        DateTime date = monthCalendar1.SelectionStart; // data에 달력 시작 날짜를 넣음
                        string day = date.ToShortDateString().Replace("-", ""); // 달력 시작 날짜를 가져오는데 날짜 형식에서 "-"부분을 ""로 바꿔주는거.

                        salesconn = new OleDbConnection(salesfile);
                        salesconn.Open();

                        bool tableExists = false; // 삭제할 날짜와 일치하는 테이블이 있는지 확인하는거

                        DataTable dt = salesconn.GetSchema("tables"); //데이터 테이블 dt에 테이블 정보를 저장

                        foreach (DataRow row in dt.Rows) //dt의 데이터 원소 개수만큼 반복문을 돌린다.
                        {
                            if (row["TABLE_NAME"].ToString() == day) //테이블 이름이 선택한 날짜와 같은지 확인해준다
                            {
                                tableExists = true;
                                break;
                            }
                        }

                        if (tableExists) //테이블과 선택한 날짜가 같은게 있으면 
                        {
                            salescomm = new OleDbCommand(string.Format("DROP TABLE {0}", day), salesconn); // 해당 테이블을 삭제
                            salescomm.ExecuteNonQuery();
                            MessageBox.Show("해당 매출이 삭제되었습니다", "알림", MessageBoxButtons.OK);
                        }
                        else {
                            MessageBox.Show("해당 매출이 삭제되지 않았습니다", "에러", MessageBoxButtons.OK);
                        } 
                        salesconn.Close();
                        break;
                }
            }
        }




        // ------------------------------------------------------------------기타-----------------------------------------------------------------------------
        private void timer_Tick(object sender, EventArgs e) // 타이머 사용해서 영업일자 나타내는거
        {
            labelTIME.Text = DateTime.Now.ToString();
        }

        private void 메모장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MEMO mem = new MEMO();
            mem.Show();

        }

        private void 도움말ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HELP help = new HELP();
            help.Show();
        }

    }
}

