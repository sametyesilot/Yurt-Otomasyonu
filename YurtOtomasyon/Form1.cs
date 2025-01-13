using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YurtOtomasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DbConnection db = new DbConnection();
        User user;
        private void Form1_Load(object sender, EventArgs e)
        {

            this.Visible = false;
            Login log = new Login(this);
            log.Show();
        }
        
        public void SetUser(User user)
    {
        this.user = user;
        lblHosgeldiniz.Text = user.KullaniciAd ;
        lblSifre.Text = user.Sifre;
    }
        
        PersonelAdd personelAdd;
        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (Form acik in this.MdiChildren)
            {
                acik.Close();
            }

            if (personelAdd == null)
            {
                personelAdd = new PersonelAdd();
                personelAdd.MdiParent = this;
                personelAdd.Show();

                personelAdd.FormClosed += (s, args) => personelAdd = null;
            }
        }
        PersonelUpdate personelUpdate;
        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (Form acik in this.MdiChildren)
            {
                acik.Close();
            }

            if (personelUpdate == null)
            {
                personelUpdate = new PersonelUpdate();
                personelUpdate.MdiParent = this;
                personelUpdate.Show();

                personelUpdate.FormClosed += (s, args) => personelUpdate = null;
            }
        }
        PersonelDelete personelDelete;
        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (Form acik in this.MdiChildren)
            {
                acik.Close();
            }

            if (personelDelete == null)
            {
                personelDelete = new PersonelDelete();
                personelDelete.MdiParent = this;
                personelDelete.Show();

                personelDelete.FormClosed += (s, args) => personelDelete = null;
            }
        }
        StudentAdd studentAdd;
        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (Form acik in this.MdiChildren)
            {
                acik.Close();
            }

            if (studentAdd == null)
            {
                studentAdd = new StudentAdd();
                studentAdd.MdiParent = this;
                studentAdd.Show();
                studentAdd.FormClosed += (s, args) => studentAdd = null;
            }
        }
        StudentUpdate studentUpdate;      

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (Form acik in this.MdiChildren)
            {
                acik.Close();
            }

            if (studentUpdate == null)
            {
                studentUpdate = new StudentUpdate();
                studentUpdate.MdiParent = this;
                studentUpdate.Show();
                studentUpdate.FormClosed += (s, args) => studentUpdate = null;
            }
        }
        StudentDelete studentDelete;
        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (Form acik in this.MdiChildren)
            {
                acik.Close();
            }

            if (studentDelete == null)
            {
                studentDelete = new StudentDelete();
                studentDelete.MdiParent = this;
                studentDelete.Show();
                studentDelete.FormClosed += (s, args) => studentDelete = null;
            }
        }
        YoneticiAdd yoneticiAdd;
        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (Form acik in this.MdiChildren)
            {
                acik.Close();
            }
            string kullaniciAdi = lblHosgeldiniz.Text; // lblHosgeldiniz'den kullanıcı adını al
            if (KullaniciYetkiKontrol(kullaniciAdi))
            {
                if (yoneticiAdd == null)
                {
                    yoneticiAdd = new YoneticiAdd();
                    yoneticiAdd.MdiParent = this;
                    yoneticiAdd.Show();
                    yoneticiAdd.FormClosed += (s, args) => yoneticiAdd = null;
                }
            }
            else
            {
                MessageBox.Show("Bu ekrana erişim yetkiniz yok.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        YoneticiUpdate yoneticiUpdate;
        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (Form acik in this.MdiChildren)
            {
                acik.Close();
            }
            string kullaniciAdi = lblHosgeldiniz.Text; // lblHosgeldiniz'den kullanıcı adını al
            if (KullaniciYetkiKontrol(kullaniciAdi))
            {
                if (yoneticiUpdate == null)
                {
                    yoneticiUpdate = new YoneticiUpdate();
                    yoneticiUpdate.MdiParent = this;
                    yoneticiUpdate.Show();
                    yoneticiUpdate.FormClosed += (s, args) => yoneticiUpdate = null;
                }
            }
            else
            {
                MessageBox.Show("Bu ekrana erişim yetkiniz yok.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        YoneticiDelete yoneticiDelete;
        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (Form acik in this.MdiChildren)
            {
                acik.Close();
            }
            string kullaniciAdi = lblHosgeldiniz.Text; // lblHosgeldiniz'den kullanıcı adını al
            if (KullaniciYetkiKontrol(kullaniciAdi))
            {
                if (yoneticiDelete == null)
                {
                    yoneticiDelete = new YoneticiDelete();
                    yoneticiDelete.MdiParent = this;
                    yoneticiDelete.Show();
                    yoneticiDelete.FormClosed += (s, args) => yoneticiDelete = null;
                }
            }
            else
            {
                MessageBox.Show("Bu ekrana erişim yetkiniz yok.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void barBtnHesap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void barBtnWord_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("winword");
        }

        private void barBtnExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("excel");
        }
        Doviz doviz;
        private void barButtonItem23_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (Form acik in this.MdiChildren)
            {
                acik.Close();
            }

            if (doviz == null)
            {
                doviz = new Doviz();
                doviz.MdiParent = this;
                doviz.Show();
                doviz.FormClosed += (s, args) => doviz = null;
            }

        }
        RandevuAdd randevuAdd;    
        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (Form acik in this.MdiChildren)
            {
                acik.Close();
            }

            if (randevuAdd == null)
            {
                randevuAdd = new RandevuAdd();
                randevuAdd.MdiParent = this;
                randevuAdd.Show();
                randevuAdd.FormClosed += (s, args) => randevuAdd = null;
            }
        }
        RandevuBildir randevu;
        private void barButtonItem25_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (Form acik in this.MdiChildren)
            {
                acik.Close();
            }

            if (randevu == null)
            {
                randevu = new RandevuBildir();
                randevu.MdiParent = this;
                randevu.Show();
                randevu.FormClosed += (s, args) => randevu = null;
            }
        }
        RehberEkle rehber;
        private void barButtonItem26_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (rehber == null || rehber.IsDisposed)
            {
                rehber = new RehberEkle();
                rehber.Show();

                // kapat null yap
                rehber.FormClosed += (s, args) => rehber = null;
            }
            else
            {
                // önplana getir
                rehber.BringToFront();
            }
        }
        YetkiEkle yetki;
        private void barButtonItem22_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (yetki == null || yetki.IsDisposed)
            {
                yetki = new YetkiEkle();
                yetki.Show();

                // kapat null yap
                yetki.FormClosed += (s, args) => yetki = null;
            }
            else
            {
                // önplana getir
                yetki.BringToFront();
            }
        }
        DepartmanEkle depart;
        private void barButtonItem21_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (depart == null || depart.IsDisposed)
            {
                depart = new DepartmanEkle();
                depart.Show();

                // kapat null yap
                depart.FormClosed += (s, args) => depart = null;
            }
            else
            {
                // önplana getir
                depart.BringToFront();
            }
        }
        BolumEkle bolum;
        private void barButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bolum == null || bolum.IsDisposed)
            {
                bolum = new BolumEkle();
                bolum.Show();

                // kapat null yap
                bolum.FormClosed += (s, args) => bolum = null;
            }
            else
            {
                // önplana getir
                bolum.BringToFront();
            }
        }
        OgrenciListele ogrListele;
        private void barButtonItem27_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (Form ogrListele in this.MdiChildren)
            {
                ogrListele.Close();
            }

            if (ogrListele == null)
            {
                ogrListele = new OgrenciListele();
                ogrListele.MdiParent = this;
                ogrListele.Show();
                ogrListele.FormClosed += (s, args) => ogrListele = null;
            }
        }
        PersonelleriListele persListele;
        private void barButtonItem28_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (Form persListele in this.MdiChildren)
            {
                persListele.Close();
            }

            if (persListele == null)
            {
                persListele = new PersonelleriListele();
                persListele.MdiParent = this;
                persListele.Show();
                persListele.FormClosed += (s, args) => persListele = null;
            }
        }
        YoneticileriListele yonetListele;
        private void barButtonItem29_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (Form acik in this.MdiChildren)
            {
                acik.Close();
            }
            string kullaniciAdi = lblHosgeldiniz.Text; // lblHosgeldiniz'den kullanıcı adını al
            if (KullaniciYetkiKontrol(kullaniciAdi))
            {
                if (yonetListele == null)
                {
                    yonetListele = new YoneticileriListele();
                    yonetListele.MdiParent = this;
                    yonetListele.Show();
                    yonetListele.FormClosed += (s, args) => yonetListele = null;
                }
            }
            else
            {
                MessageBox.Show("Bu ekrana erişim yetkiniz yok.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        RandevuTakvimi takvim;
        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (Form acik in this.MdiChildren)
            {
                acik.Close();
            }

            if (takvim == null)
            {
                takvim = new RandevuTakvimi();
                takvim.MdiParent = this;
                takvim.Show();
                takvim.FormClosed += (s, args) => takvim = null;
            }
        }
        RehberDelete rehberDelete;
        private void barButtonItem30_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (rehberDelete == null || rehberDelete.IsDisposed)
            {
                rehberDelete = new RehberDelete();
                rehberDelete.Show();

                // kapat null yap
                rehberDelete.FormClosed += (s, args) => rehberDelete = null;
            }
            else
            {
                // önplana getir
                rehberDelete.BringToFront();
            }
        }
        BolumDelete bolumDelete;
        private void barButtonItem31_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bolumDelete == null || bolumDelete.IsDisposed)
            {
                bolumDelete = new BolumDelete();
                bolumDelete.Show();

                // kapat null yap
                bolumDelete.FormClosed += (s, args) => bolumDelete = null;
            }
            else
            {
                // önplana getir
                bolumDelete.BringToFront();
            }
        }
        Home home;
        private void barButtonItem33_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (Form acik in this.MdiChildren)
            {
                acik.Close();
            }

            if (home == null)
            {
                home = new Home();
                home.MdiParent = this;
                home.Show();
                home.FormClosed += (s, args) => home = null;
            }
        }
        Oda oda;
        private void barButtonItem34_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (Form acik in this.MdiChildren)
            {
                acik.Close();
            }

            if (oda == null)
            {
                oda = new Oda();
                oda.MdiParent = this;
                oda.Show();
                oda.FormClosed += (s, args) => oda = null;
            }
        }
        YetkiDelete yetkiDelete;
        private void barButtonItem36_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (yetkiDelete == null || yetkiDelete.IsDisposed)
            {
                yetkiDelete = new YetkiDelete();
                yetkiDelete.Show();

                // kapat null yap
                yetkiDelete.FormClosed += (s, args) => yetkiDelete = null;
            }
            else
            {
                // önplana getir
                yetkiDelete.BringToFront();
            }
        }
        DepartDelete departDelete;
        private void barButtonItem35_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (departDelete == null || departDelete.IsDisposed)
            {
                departDelete = new DepartDelete();
                departDelete.Show();

                // kapat null yap
                departDelete.FormClosed += (s, args) => departDelete = null;
            }
            else
            {
                // önplana getir
                departDelete.BringToFront();
            }
        }

        private void barButtonItem37_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("outlookcal:");
        }
        Saat saat;
        private void barButtonItem38_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (Form acik in this.MdiChildren)
            {
                acik.Close();
            }

            if (saat == null)
            {
                saat = new Saat();
                saat.MdiParent = this;
                saat.Show();
                saat.FormClosed += (s, args) => saat = null;
            }
        }

        private void barButtonItem39_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                // Windows'un yerleşik kronometre uygulamasını başlatıyoruz
                Process.Start("ms-clock:");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kronometre uygulaması açılamadı: " + ex.Message);
            }
        }
        Odeme odeme;
        private void barButtonItem32_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (Form acik in this.MdiChildren)
            {
                acik.Close();
            }

            if (odeme == null)
            {
                odeme = new Odeme();
                odeme.MdiParent = this;
                odeme.Show();
                odeme.FormClosed += (s, args) => odeme = null;
            }
        }

        private void barButtonItem41_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (Form acik in this.MdiChildren)
            {
                acik.Close();
            }

            if (ogrListele == null)
            {
                ogrListele = new OgrenciListele();
                ogrListele.MdiParent = this;
                ogrListele.Show();
                ogrListele.FormClosed += (s, args) => ogrListele = null;
            }
        }

        private void barButtonItem42_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (Form acik in this.MdiChildren)
            {
                acik.Close();
            }

            if (persListele == null)
            {
                persListele = new PersonelleriListele();
                persListele.MdiParent = this;
                persListele.Show();
                persListele.FormClosed += (s, args) => persListele = null;
            }
        }

        private void barButtonItem43_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (Form acik in this.MdiChildren)
            {
                acik.Close();
            }
            string kullaniciAdi = lblHosgeldiniz.Text; // lblHosgeldiniz'den kullanıcı adını al
            if (KullaniciYetkiKontrol(kullaniciAdi))
            {
                if (yonetListele == null)
                {
                    yonetListele = new YoneticileriListele();
                    yonetListele.MdiParent = this;
                    yonetListele.Show();
                    yonetListele.FormClosed += (s, args) => yonetListele = null;
                }
            }
            else
            {
                MessageBox.Show("Bu ekrana erişim yetkiniz yok.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        SonGirisler sonGirisler;
        private void barButtonItem44_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            foreach (Form acik in this.MdiChildren)
            {
                acik.Close();
            }
            string kullaniciAdi = lblHosgeldiniz.Text; // lblHosgeldiniz'den kullanıcı adını al
            if (KullaniciYetkiKontrol(kullaniciAdi))
            {
                if (sonGirisler == null)
                {
                    sonGirisler = new SonGirisler();
                    sonGirisler.MdiParent = this;
                    sonGirisler.Show();
                    sonGirisler.FormClosed += (s, args) => sonGirisler = null;
                }
            }
            else
            {
                MessageBox.Show("Bu ekrana erişim yetkiniz yok.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool KullaniciYetkiKontrol(string kullaniciAdi)
        {
            bool yetkili = false;

            db.baglantiOpen();

            SqlCommand command = new SqlCommand("SELECT YoneticiYetki FROM Admin WHERE YoneticiKullaniciAd = @KullaniciAd", db.baglantiOpen());
                
                    command.Parameters.AddWithValue("@KullaniciAd", kullaniciAdi);
                        object result = command.ExecuteScalar();

                    if (result != null && result.ToString() == "Müdür")
                    {
                        yetkili = true;
                    }
            db.baglantiClose();
            return yetkili;
        }

        private void barButtonItem40_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                // Google'ı varsayılan tarayıcıda açma
                Process.Start("https://www.google.com");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }
    }
}
