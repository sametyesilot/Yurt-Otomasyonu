using DevExpress.XtraScheduler;
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

namespace YurtOtomasyon
{
    public partial class RandevuTakvimi : Form
    {
        public RandevuTakvimi()
        {
            InitializeComponent();
        }
        DbConnection db = new DbConnection();
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
        private void SüresiGeçmişRandevularıSil()
        {

            db.baglantiOpen();

            // Süresi geçmiş randevuları sil
            SqlCommand randevuSilKomut = new SqlCommand("DELETE FROM Randevu WHERE RandevuSaat < @Bugun", db.baglantiOpen());
            randevuSilKomut.Parameters.AddWithValue("@Bugun", DateTime.Now);
            int silinenRandevuSayisi = randevuSilKomut.ExecuteNonQuery();

            // Süresi geçmiş takvim etkinliklerini sil
            SqlCommand takvimSilKomut = new SqlCommand("DELETE FROM Takvim WHERE BitisTarihi < @Bugun", db.baglantiOpen());
            takvimSilKomut.Parameters.AddWithValue("@Bugun", DateTime.Now);
            int silinenTakvimKaydiSayisi = takvimSilKomut.ExecuteNonQuery();

            db.baglantiClose(); 
        }

        private void RandevuTakvimi_Load(object sender, EventArgs e)
        {
            SüresiGeçmişRandevularıSil();
            YükleTakvimEtkinlikleri();
            int gun = DateTime.Now.Day;
            int ay = DateTime.Now.Month;
            int yil = DateTime.Now.Year;
            schedulerControl1.Start = new DateTime(yil, ay, gun );
            schedulerControl1.OptionsCustomization.AllowAppointmentCreate = UsedAppointmentType.None; // Yeni randevu oluşturmayı engeller
            schedulerControl1.OptionsCustomization.AllowAppointmentEdit = UsedAppointmentType.None;  // Mevcut randevuları düzenlemeyi engeller
            schedulerControl1.OptionsCustomization.AllowAppointmentDelete = UsedAppointmentType.None; // Randevu silmeyi engeller
            schedulerControl1.OptionsCustomization.AllowAppointmentDrag = UsedAppointmentType.None;   // Randevuyu sürüklemeyi engeller
            schedulerControl1.OptionsCustomization.AllowAppointmentResize = UsedAppointmentType.None; // Randevuyu yeniden boyutlandırmayı engeller
        }
    }
}
