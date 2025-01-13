using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraScheduler;

namespace YurtOtomasyon
{
    public partial class RandevuAdd : Form
    {

        public RandevuAdd()
        {
            InitializeComponent();
        }
        DbConnection db = new DbConnection();

        void Temizle()
        {
            txtRehberMail.ResetText();
            cbRandevu.ResetText();
            cbRehber.SelectedIndex = -1;
            memoRandevuSebep.ResetText();
        }
        private void SüresiGeçmişRandevularıSil()
        {
            
                db.baglantiOpen(); // Bağlantıyı bir kez açıyoruz.

                // Süresi geçmiş randevuları sil
                SqlCommand randevuSilKomut = new SqlCommand("DELETE FROM Randevu WHERE RandevuSaat < @Bugun", db.baglantiOpen());
                randevuSilKomut.Parameters.AddWithValue("@Bugun", DateTime.Now);
                int silinenRandevuSayisi = randevuSilKomut.ExecuteNonQuery();

                // Süresi geçmiş takvim etkinliklerini sil
                SqlCommand takvimSilKomut = new SqlCommand("DELETE FROM Takvim WHERE BitisTarihi < @Bugun", db.baglantiOpen());
                takvimSilKomut.Parameters.AddWithValue("@Bugun", DateTime.Now);
                int silinenTakvimKaydiSayisi = takvimSilKomut.ExecuteNonQuery();

                db.baglantiClose(); // Bağlantıyı kapatıyoruz.
            
           
                
            
        }

        private void VeritabaninaKaydet(string konu, DateTime baslangicTarihi, DateTime bitisTarihi, string aciklama)
        {
            // Veritabanında aynı etkinlik olup olmadığını kontrol et
            db.baglantiOpen();
            SqlCommand kontrolKomut = new SqlCommand("SELECT COUNT(*) FROM Takvim WHERE BaslangicTarihi = @BaslangicTarihi AND BitisTarihi = @BitisTarihi AND Konu = @Konu", db.baglantiOpen());
            kontrolKomut.Parameters.AddWithValue("@BaslangicTarihi", baslangicTarihi);
            kontrolKomut.Parameters.AddWithValue("@BitisTarihi", bitisTarihi);
            kontrolKomut.Parameters.AddWithValue("@Konu", konu);

            int mevcutKayitSayisi = (int)kontrolKomut.ExecuteScalar();

            // Eğer aynı etkinlik zaten varsa kaydetme
            if (mevcutKayitSayisi > 0)
            {
                MessageBox.Show("Bu etkinlik zaten mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                db.baglantiClose();
                return;
            }

            // Veritabanına yeni etkinliği kaydet
            SqlCommand komut = new SqlCommand("INSERT INTO Takvim (Konu, BaslangicTarihi, BitisTarihi) " +
                                               "VALUES (@Konu, @BaslangicTarihi, @BitisTarihi)", db.baglantiOpen());
            komut.Parameters.AddWithValue("@Konu", konu);
            komut.Parameters.AddWithValue("@BaslangicTarihi", baslangicTarihi);
            komut.Parameters.AddWithValue("@BitisTarihi", bitisTarihi);
            
            komut.ExecuteNonQuery();
            db.baglantiClose();

            DateTime selectedDateTime = (DateTime)cbRandevu.EditValue;

            // Tarih kısmını al
            DateTime selectedDate = selectedDateTime.Date;  // Tarihi al, saat kısmı 00:00:00 olacaktır.

            // Saat bilgisini al
            string saat = selectedDateTime.ToString("HH:mm"); // Saat kısmını "HH:mm" formatında al

            // Eğer sadece tarih kısmını almak isterseniz
            DateTime randevuTarihi = selectedDate;
            

            string birlesik = $"{randevuTarihi:yyyy-MM-dd} {saat}"; // Tarih ve saat birleştiriliyor

            DateTime randevu = DateTime.ParseExact(birlesik, "yyyy-MM-dd HH:mm", null);

            try
            {
                db.baglantiOpen();
                SqlCommand kaydetKomut = new SqlCommand("insert into Randevu(OgrAd,OgrSoyad, OgrEmail,OgrTel,RehberAdSoyad,RandevuSaat,RandevuSebep,RehberEmail) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", db.baglantiOpen());
                kaydetKomut.Parameters.AddWithValue("@p1", txtOgrAd.Text);
                kaydetKomut.Parameters.AddWithValue("@p2", txtOgrSoyad.Text);
                kaydetKomut.Parameters.AddWithValue("@p3", txtOgrEmail.Text);
                kaydetKomut.Parameters.AddWithValue("@p4", mskOgrTel.Text);
                kaydetKomut.Parameters.AddWithValue("@p5", cbRehber.Text);
                kaydetKomut.Parameters.AddWithValue("@p6", randevu);
                kaydetKomut.Parameters.AddWithValue("@p7", memoRandevuSebep.Text);
                kaydetKomut.Parameters.AddWithValue("@p8", txtRehberMail.Text);
                kaydetKomut.ExecuteNonQuery();

                db.baglantiClose();

                MessageBox.Show("Kayıt Başarılı", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı Giriş Yaptınız! Tekrar Deneyin ", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void YükleTakvimEtkinlikleri()
        { 

            
            if (schedulerControl1.Storage == null)
            {
                schedulerControl1.Storage = new DevExpress.XtraScheduler.SchedulerStorage();
            }
            schedulerControl1.Storage.Appointments.Clear();

            db.baglantiOpen();
            SqlCommand komut = new SqlCommand("SELECT Konu, BaslangicTarihi, BitisTarihi, BildirildiMi FROM Takvim", db.baglantiOpen());
            
            SqlDataReader okuyucu = komut.ExecuteReader();
            
            while (okuyucu.Read())
            {
                string konu = okuyucu.GetString(0);
                DateTime baslangicTarihi = okuyucu.GetDateTime(1);
                DateTime bitisTarihi = okuyucu.GetDateTime(2);
                bool bildirildiMi = okuyucu.GetBoolean(3);

                Appointment etkinlik = schedulerControl1.Storage.CreateAppointment(AppointmentType.Normal);
                etkinlik.Subject = konu;
                etkinlik.Start = baslangicTarihi;
                etkinlik.End = bitisTarihi;
                etkinlik.Description = "";

                schedulerControl1.Storage.Appointments.Labels[2].Color = Color.Red;
                schedulerControl1.Storage.Appointments.Labels[3].Color = Color.Green;

                if (bildirildiMi)
                {
                    etkinlik.LabelId = 3; // Yeşil (Varsayılan olarak yeşil renk)
                }
                else
                {
                    etkinlik.LabelId = 2; // Kırmızı (Varsayılan olarak kırmızı renk)
                }

                schedulerControl1.Storage.Appointments.Add(etkinlik);
            }

            db.baglantiClose();
        }

        void tabloyaEkle()
        {

            if (schedulerControl1.Storage == null)
            {
                schedulerControl1.Storage = new DevExpress.XtraScheduler.SchedulerStorage();
            }

            DateTime selectedDateTime = (DateTime)cbRandevu.EditValue;

            DateTime randevuTarihi = selectedDateTime.Date;
            string saat = selectedDateTime.ToString("HH:mm");

            // 1. Şart: Randevu saati 09:00 ile 17:00 arasında olmalı
            if (selectedDateTime.Hour < 9 || selectedDateTime.Hour >= 17)
            {
                MessageBox.Show("Randevu saati 09:00 ile 17:00 arasında olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime randevuSaati = DateTime.Parse(randevuTarihi.ToString("yyyy-MM-dd") + " " + saat);
            bool randevuCakismasi = false;

            // 2. Şart: Çakışan bir etkinlik olup olmadığını kontrol et
            foreach (Appointment mevcutRandevu in schedulerControl1.Storage.Appointments.Items)
            {
                if (mevcutRandevu.Start < randevuSaati.AddHours(1) && mevcutRandevu.End > randevuSaati)
                {
                    randevuCakismasi = true;
                    break;
                }
            }

            if (randevuCakismasi)
            {
                MessageBox.Show("Bu saatte zaten bir etkinlik var. Lütfen başka bir saat seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // 3. Şart: Bugün ve önceki tarihler için randevu oluşturmayı engelle
            if (selectedDateTime.Date <= DateTime.Now.Date)
            {
                MessageBox.Show("Yalnızca yarından itibaren randevu oluşturabilirsiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Yeni randevuyu oluştur
            DevExpress.XtraScheduler.Appointment newAppointment = schedulerControl1.Storage.CreateAppointment(DevExpress.XtraScheduler.AppointmentType.Normal);
            newAppointment.Start = randevuSaati;
            newAppointment.End = randevuSaati.AddHours(1); // 1 saatlik etkinlik süresi

            newAppointment.Subject = txtOgrAd.Text + " " + txtOgrSoyad.Text;
            newAppointment.LabelId = 2;

            // Etkinliği takvime ekle
            schedulerControl1.Storage.Appointments.Add(newAppointment);

            // Veritabanına kaydet
            VeritabaninaKaydet(newAppointment.Subject, newAppointment.Start, newAppointment.End, newAppointment.Description);



        }
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select OgrenciId, OgrAd, OgrSoyad,OgrTelefon,OgrMail from Ogrenci", db.baglantiOpen());
            da.Fill(dt);
            gridControl1.DataSource = dt;

        }
        private void RandevuAdd_Load(object sender, EventArgs e)
        {
            SüresiGeçmişRandevularıSil();
            YükleTakvimEtkinlikleri();
            int gun = DateTime.Now.Day;
            int ay = DateTime.Now.Month;
            int yil = DateTime.Now.Year;
            schedulerControl1.Start = new DateTime(yil, ay, gun);
            schedulerControl1.OptionsCustomization.AllowAppointmentCreate = UsedAppointmentType.None; // Yeni randevu oluşturmayı engeller
            schedulerControl1.OptionsCustomization.AllowAppointmentEdit = UsedAppointmentType.None;  // Mevcut randevuları düzenlemeyi engeller
            schedulerControl1.OptionsCustomization.AllowAppointmentDelete = UsedAppointmentType.None; // Randevu silmeyi engeller
            schedulerControl1.OptionsCustomization.AllowAppointmentDrag = UsedAppointmentType.None;   // Randevuyu sürüklemeyi engeller
            schedulerControl1.OptionsCustomization.AllowAppointmentResize = UsedAppointmentType.None; // Randevuyu yeniden boyutlandırmayı engeller

            listele();

            //rehberleri Comboboxa cekme
            SqlCommand komut = new SqlCommand("Select RehberAdSoyad From Rehber", db.baglantiOpen());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                cbRehber.Properties.Items.Add(oku[0].ToString());

            }
            db.baglantiClose();

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue("OgrenciId") != null)

            {
                
                txtId.Text = gridView1.GetFocusedRowCellValue("OgrenciId").ToString();
                txtOgrAd.Text = gridView1.GetFocusedRowCellValue("OgrAd").ToString();
                txtOgrSoyad.Text = gridView1.GetFocusedRowCellValue("OgrSoyad").ToString();
                txtOgrEmail.Text = gridView1.GetFocusedRowCellValue("OgrMail").ToString();
                mskOgrTel.Text = gridView1.GetFocusedRowCellValue("OgrTelefon").ToString();
                

            }
        }

        private void btnKayit_Click(object sender, EventArgs e)
        {



            // Boş kutucuk kontrolü
            if (string.IsNullOrWhiteSpace(txtOgrAd.Text) ||
                string.IsNullOrWhiteSpace(txtOgrSoyad.Text) ||
                string.IsNullOrWhiteSpace(txtOgrEmail.Text) ||
                string.IsNullOrWhiteSpace(mskOgrTel.Text) ||
                string.IsNullOrWhiteSpace(cbRehber.Text) ||
                string.IsNullOrWhiteSpace(cbRandevu.Text) ||
                string.IsNullOrWhiteSpace(memoRandevuSebep.Text) ||
                string.IsNullOrWhiteSpace(txtRehberMail.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // İşlemi durdur
            }
            YükleTakvimEtkinlikleri();
                tabloyaEkle();
                Temizle();
                
            
            
        }

        private void cbRehber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRehber.SelectedIndex != -1) // Eğer bir rehber seçildiyse
            {
                string secilenRehber = cbRehber.Text;

                try
                {
                    db.baglantiOpen();
                    SqlCommand komut = new SqlCommand("SELECT RehberMail FROM Rehber WHERE RehberAdSoyad = @RehberAdSoyad", db.baglantiOpen());
                    komut.Parameters.AddWithValue("@RehberAdSoyad", secilenRehber);

                    SqlDataReader okuyucu = komut.ExecuteReader();
                    okuyucu.Read(); // Zorunlu olduğu için doğrudan okutuyoruz
                    txtRehberMail.Text = okuyucu["RehberMail"].ToString();

                    db.baglantiClose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.baglantiClose();
                }
            }
        }
    }
}
