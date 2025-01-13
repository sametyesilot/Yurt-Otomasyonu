using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YurtOtomasyon
{
    public class User
    {
        private string kullaniciAd;
        private string sifre;

        

        public User(string kullaniciAd,string sifre)
        {
            this.kullaniciAd = kullaniciAd;
            this.sifre = sifre;
        }
        public string KullaniciAd
        {
            get
            {
                return kullaniciAd;
            }
        }
        public string Sifre
        {
            get
            {
                return sifre;
            }
        }
    }
}
