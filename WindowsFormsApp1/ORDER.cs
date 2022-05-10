using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class ORDER
    {
        // 각 음료 한잔당 곱해야할 가격 종류
        private int won1500 = 1500, won2000 = 2000, won2500 = 2500, won3000 = 3000, won3500 = 3500;
        // 각 음료별 잔수 카운트 (이제 수량이랑 금액 계산때문에 1로 둠)
        private int americanohcoun = 1, cafelattehcoun = 1, cappuccinohcoun = 1, cafemochahcoun = 1, caramelhcoun = 1,americanoicoun = 1, cafelatteicoun = 1, cappuccinoicoun = 1, cafemochaicoun = 1, caramelicoun = 1 , chococakecoun = 1, cheezecakecoun = 1, browniecoun = 1,tiramisucoun = 1, muffincoun = 1, bagelcoun = 1, wafflecoun = 1;
        // 각 음료별 주문한 총 금액
        private int americanohsu = 0, cafelattehsu = 0, cappuccinohsu = 0, cafemochahsu = 0, caramelhsu = 0, americanoisu = 0, cafelatteisu = 0, cappuccinoisu = 0, cafemochaisu = 0, caramelisu = 0, chococakesu = 0, cheezecakesu = 0, browniesu = 0, tiramisusu = 0, muffinsu = 0, bagelsu = 0, wafflesu = 0;

        //총 금액, 총 커피잔, 총 디저트수 자동 구형 프로퍼티
        public int sumnumber
        {
            get; set;
        }
        public int sumcash {
            get;set;
        }
        public int sumdessert {
            get;set;
        }

        // 메뉴들 카운트에 대한 프로퍼티
        public int americanohcount {
            get { return americanohcoun; }
            set { americanohcoun = value; }
        }
        public int cafelattehcount
        {
            get { return cafelattehcoun; }
            set { cafelattehcoun = value; }
        }
        public int cappuccinohcount
        {
            get { return cappuccinohcoun; }
            set { cappuccinohcoun = value; }
        }
        public int cafemochahcount
        {
            get { return cafemochahcoun; }
            set { cafemochahcoun = value; }
        }
        public int caramelhcount
        {
            get { return caramelhcoun; }
            set { caramelhcoun = value; }
        }
        public int americanoicount
        {
            get { return americanoicoun; }
            set { americanoicoun = value; }
        }
        public int cafelatteicount
        {
            get { return cafelatteicoun; }
            set { cafelatteicoun = value; }
        }
        public int cappuccinoicount
        {
            get { return cappuccinoicoun; }
            set { cappuccinoicoun = value; }
        }
        public int cafemochaicount
        {
            get { return cafemochaicoun; }
            set { cafemochaicoun = value; }
        }
        public int caramelicount
        {
            get { return caramelicoun; }
            set { caramelicoun = value; }
        }
        public int chococakecount
        {
            get { return chococakecoun; }
            set { chococakecoun = value; }
        }
        public int cheezecakecount
        {
            get { return cheezecakecoun; }
            set { cheezecakecoun = value; }
        }
        public int browniecount
        {
            get { return browniecoun; }
            set { browniecoun = value; }
        }
        public int tiramisucount
        {
            get { return tiramisucoun; }
            set { tiramisucoun = value; }
        }
        public int muffincount
        {
            get { return muffincoun; }
            set { muffincoun = value; }
        }
        public int bagelcount
        {
            get { return bagelcoun; }
            set { bagelcoun = value; }
        }
        public int wafflecount
        {
            get { return wafflecoun; }
            set { wafflecoun = value; }
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

        // 메뉴들 총금액을 계산해서 반환해주는 메소드
        public int AmericanohSum() 
        { 
            americanohsum = americanohcount * won1500;
            return americanohsum;
        }
        public int CafelattehSum() 
        { 
            cafelattehsum = cafelattehcount * won2000;
            return cafelattehsum;
        }
        public int CappuccinohSum()
        {
            cappuccinohsum = cappuccinohcount * won2000;
            return cappuccinohsum;
        }
        public int CafemochahSum()
        {
            cafemochahsum = cafemochahcount * won2500;
            return cafemochahsum;
        }
        public int CaramelhSum()
        {
            caramelhsum = caramelhcount * won2500;
            return caramelhsum;
        }
        public int AmericanoiSum()
        {
            americanoisum = americanoicount * won2000;
            return americanoisum;
        }
        public int CafelatteiSum() 
        {
            cafelatteisum = cafelatteicount * won2500;
            return cafelatteisum;
        }
        public int CappuccinoiSum()
        {
            cappuccinoisum = cappuccinoicount * won2500;
            return cappuccinoisum;
        }
        public int CafemochaiSum()
        {
            cafemochaisum = cafemochaicount * won3000;
            return cafemochaisum;
        }
        public int CarameliSum() 
        {
            caramelisum = caramelicount * won3000; 
            return caramelisum;
        }
        public int SumNumber() 
        {
            sumnumber = americanohcount + cafelattehcount + cappuccinohcount + cafemochahcount + caramelhcount + americanoicount + cafelatteicount + cappuccinoicount + cafemochaicount + caramelicount;
            return sumnumber-10;
        }
        public int SumCash() 
        {
            sumcash = americanohsum + cafelattehsum + cappuccinohsum + cafemochahsum + caramelhsum + americanoisum + cafelatteisum + cappuccinoisum + cafemochaisum + caramelisum + chococakesum + cheezecakesum + browniesum + tiramisusum + muffinsum + bagelsum + wafflesum;
            return sumcash;
        }
        public int Sumdessert() 
        {
            sumdessert = chococakecount + cheezecakecount + browniecount + tiramisucount + muffincount + bagelcount + wafflecount;
            return sumdessert - 7;
        }
        public int ChococakeSum() 
        {
            chococakesum = chococakecount * won3500;
            return chococakesum;
        }
        public int CheezecakeSum()
        {
            cheezecakesum = cheezecakecount * won3500;
            return cheezecakesum;
        }
        public int BrownieSum()
        {
            browniesum = browniecount * won3000;
            return browniesum;
        }
        public int TiramisuSum() 
        {
            tiramisusum = tiramisucount * won3000;
            return tiramisusum;
        }
        public int MuffinSum()
        {
            muffinsum = muffincount * won2500;
            return muffinsum;
        }
        public int BagelSum() 
        {
            bagelsum = bagelcount * won2000;
            return bagelsum;
        }
        public int WaffleSum() 
        {
            wafflesum = wafflecount * won2000;
            return wafflesum;
        }
    }
}
