using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class SALES
    {
        // 총 메뉴별 금액 저장하는 부분
        private int americanohsu = 0, cafelattehsu = 0, cappuccinohsu = 0, cafemochahsu = 0, caramelhsu = 0, americanoisu = 0, cafelatteisu = 0, cappuccinoisu = 0, cafemochaisu = 0, caramelisu = 0, chococakesu = 0, cheezecakesu = 0, browniesu = 0, tiramisusu = 0, muffinsu = 0, bagelsu = 0, wafflesu = 0;
        // 결제한 금액과 오늘 총금액 저장하는 부분
        private int sumcas = 0 , salessu = 0;

        // 결제한 금액이랑 오늘 총금액에 대한 프로퍼티
        public int sumcash {
            get { return sumcas; }
            set { sumcas = value; }
        }
        public int salessum {
            get { return salessu; }
            set { salessu = value; }
        }

        // 메뉴들 금액에 대한 프로퍼티
        public int americanohsum
        {
            get { return americanohsu; }
            set { americanohsu = value; }
        }
        public int cafelattehsum
        {
            get { return cafelattehsu; }
            set { cafelattehsu = value; }
        }
        public int cappuccinohsum
        {
            get { return cappuccinohsu; }
            set { cappuccinohsu = value; }
        }
        public int cafemochahsum
        {
            get { return cafemochahsu; }
            set { cafemochahsu = value; }
        }
        public int caramelhsum
        {
            get { return caramelhsu; }
            set { caramelhsu = value; }
        }
        public int americanoisum
        {
            get { return americanoisu; }
            set { americanoisu = value; }
        }
        public int cafelatteisum
        {
            get { return cafelatteisu; }
            set { cafelatteisu = value; }
        }
        public int cappuccinoisum
        {
            get { return cappuccinoisu; }
            set { cappuccinoisu = value; }
        }
        public int cafemochaisum
        {
            get { return cafemochaisu; }
            set { cafemochaisu = value; }
        }
        public int caramelisum
        {
            get { return caramelisu; }
            set { caramelisu = value; }
        }
        public int chococakesum
        {
            get { return chococakesu; }
            set { chococakesu = value; }
        }
        public int cheezecakesum
        {
            get { return cheezecakesu; }
            set { cheezecakesu = value; }
        }
        public int browniesum
        {
            get { return browniesu; }
            set { browniesu = value; }
        }
        public int tiramisusum
        {
            get { return tiramisusu; }
            set { tiramisusu = value; }
        }
        public int muffinsum
        {
            get { return muffinsu; }
            set { muffinsu = value; }
        }
        public int bagelsum
        {
            get { return bagelsu; }
            set { bagelsu = value; }
        }
        public int wafflesum
        {
            get { return wafflesu; }
            set { wafflesu = value; }
        }

        // 오늘 총매출 반환하는 메소드
        public int Salessum()
        {
            salessum += sumcash;
            return salessum;
        }
    }
}
