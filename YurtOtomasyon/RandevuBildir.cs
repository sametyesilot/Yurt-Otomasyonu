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
using System.Net;
using System.Net.Mail;
using DevExpress.XtraGrid;

namespace YurtOtomasyon
{
    public partial class RandevuBildir : Form
    {
        public RandevuBildir()
        {
            InitializeComponent();
        }
        DbConnection db = new DbConnection();
        void listele()
        {
            DataTable dt = new DataTable();
            // BildirildiMi = 0 (false) olanlar önce sıralansın, sonra BildirildiMi = 1 (true) olanlar sıralansın.
            SqlDataAdapter da = new SqlDataAdapter("Select * from Randevu ORDER BY BildirildiMi ASC, RandevuId ASC", db.baglantiOpen());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            db.baglantiClose();

            
        }
        private void SüresiGeçmişRandevularıSil()
        {
            try
            {
                db.baglantiOpen();
                
                DateTime bugun = DateTime.Now;

                // Süresi geçmiş randevuları sil
                SqlCommand randevuSilKomut = new SqlCommand("DELETE FROM Randevu WHERE RandevuSaat < @Bugun", db.baglantiOpen());
                randevuSilKomut.Parameters.AddWithValue("@Bugun", bugun);
                int silinenRandevuSayisi = randevuSilKomut.ExecuteNonQuery();

                // Süresi geçmiş takvim etkinliklerini sil
                SqlCommand takvimSilKomut = new SqlCommand("DELETE FROM Takvim WHERE BitisTarihi < @Bugun", db.baglantiOpen());
                takvimSilKomut.Parameters.AddWithValue("@Bugun", bugun);
                int silinenTakvimKaydiSayisi = takvimSilKomut.ExecuteNonQuery();

                db.baglantiClose();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RandevuBildir_Load(object sender, EventArgs e)
        {
            SüresiGeçmişRandevularıSil();
            listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;

            if (view != null)
            {
                int rowHandle = e.FocusedRowHandle;

                // Eğer o satırda BildirildiMi true ise, fokuslanmasın
                bool bildirildiMi = Convert.ToBoolean(view.GetRowCellValue(rowHandle, "BildirildiMi"));

                if (bildirildiMi)
                {
                    // Fokuslanmış satır BildirildiMi=true ise, focusu kaldır
                    view.FocusedRowHandle = GridControl.InvalidRowHandle;

                    MessageBox.Show("Bu randevu zaten bildirildi. Lütfen başka bir randevu seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (gridView1.GetFocusedRowCellValue("RandevuId") != null)

                    {
                        txtId.Text = gridView1.GetFocusedRowCellValue("RandevuId").ToString();
                        txtOgrAd.Text = gridView1.GetFocusedRowCellValue("OgrAd").ToString();
                        txtOgrSoyad.Text = gridView1.GetFocusedRowCellValue("OgrSoyad").ToString();
                        txtOgrEmail.Text = gridView1.GetFocusedRowCellValue("OgrEmail").ToString();
                        mskOgrTel.Text = gridView1.GetFocusedRowCellValue("OgrTel").ToString();
                        cbRehber.Text = gridView1.GetFocusedRowCellValue("RehberAdSoyad").ToString();
                        txtRandevu.Text = gridView1.GetFocusedRowCellValue("RandevuSaat").ToString();
                        memoRandevuSebep.Text = gridView1.GetFocusedRowCellValue("RandevuSebep").ToString();
                        txtRehberEmail.Text = gridView1.GetFocusedRowCellValue("RehberEmail").ToString();


                    }
                }
            }
        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOgrAd.Text) ||
        string.IsNullOrEmpty(txtOgrSoyad.Text) ||
        string.IsNullOrEmpty(txtOgrEmail.Text) ||
        string.IsNullOrEmpty(mskOgrTel.Text) ||
        string.IsNullOrEmpty(cbRehber.Text) ||
        string.IsNullOrEmpty(txtRandevu.Text) ||
        string.IsNullOrEmpty(memoRandevuSebep.Text) ||
        string.IsNullOrEmpty(txtRehberEmail.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurduğunuzdan emin olun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;  
            }

            string baslik = txtOgrAd.Text + " " + txtOgrSoyad.Text + " " + txtRandevu.Text;
            string mesajRehber = "YENİ RANDEVU\n" +
                           "Öğrenci Ad: " + txtOgrAd.Text + "\n" +
                           "Öğrenci Soyad: " + txtOgrSoyad.Text + "\n" +
                           "Randevu Saati: " + txtRandevu.Text + "\n" +
                           "Randevu Sebebi: " + memoRandevuSebep.Text + "\n" +
                           "Ek Mesaj: " + memoMesaj.Text;

            string mesajOgr = "YENİ RANDEVU\n" +
                           "Rehber Ad Soyad: " + cbRehber.Text + "\n" +
                           "Randevu Saati: " + txtRandevu.Text + "\n" +
                           "Randevu Sebebi: " + memoRandevuSebep.Text + "\n" +
                           "Ek Mesaj: " + memoMesaj.Text;
            try
            {
                // Öğrenciye mail gönderme fpsqfwxzqbnhbicp
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.Credentials = new NetworkCredential("sametyesilotiletisim@gmail.com", "fpsqfwhbicp");
                smtpClient.EnableSsl = true;

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("sametyesilotiletisim@gmail.com");
                mailMessage.Subject = "Randevu Bilgisi - " + baslik;
                mailMessage.Body = mesajOgr;
                mailMessage.IsBodyHtml = false;
                mailMessage.To.Add(txtOgrEmail.Text);

                // E-posta gönder
                smtpClient.Send(mailMessage);

                // Rehbere mail gönderme
                SmtpClient smtpClientRehber = new SmtpClient("smtp.gmail.com", 587);
                smtpClientRehber.Credentials = new NetworkCredential("sametyesilotiletisim@gmail.com", "fpsqqbnhbicp");
                smtpClientRehber.EnableSsl = true;

                MailMessage mailMessageRehber = new MailMessage();
                mailMessageRehber.From = new MailAddress("sametyesilotiletisim@gmail.com");
                mailMessageRehber.Subject = "Randevu Bilgisi - " + baslik;
                mailMessageRehber.Body = mesajRehber;
                mailMessageRehber.IsBodyHtml = false;
                mailMessageRehber.To.Add(txtRehberEmail.Text);

                // E-posta gönder
                smtpClientRehber.Send(mailMessageRehber);

                db.baglantiOpen();
                int randevuId = Convert.ToInt32(txtId.Text);
                SqlCommand komut = new SqlCommand("UPDATE Randevu SET BildirildiMi = 1 WHERE RandevuId = @randevuId", db.baglantiOpen());
                komut.Parameters.AddWithValue("@randevuId", randevuId);
                komut.ExecuteNonQuery();
                db.baglantiClose();

                MessageBox.Show("Randevu bildirimi başarıyla gönderildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            listele();
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;

            if (view != null)
            {
                // "BildirildiMi" kolonunun değerini kontrol et
                bool bildirildiMi = Convert.ToBoolean(view.GetRowCellValue(e.RowHandle, "BildirildiMi"));

                // Eğer BildirildiMi true ise, satırın stilini değiştirebiliriz
                if (bildirildiMi)
                {
                    // Satır rengini gri yapmak ve yazı rengini beyaz yapmak
                    e.Appearance.BackColor = Color.Green;
                    e.Appearance.ForeColor = Color.White;
                }
                else
                {
                    // Satır rengini gri yapmak ve yazı rengini beyaz yapmak
                    e.Appearance.BackColor = Color.Red;
                    e.Appearance.ForeColor = Color.White;
                }
            }
        }

        
    }
}
