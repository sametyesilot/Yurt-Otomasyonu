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
    public partial class YoneticiAdd : Form
    {
        public YoneticiAdd()
        {
            InitializeComponent();
        }
        DbConnection db = new DbConnection();

        private void Temizle()
        {
            txtSifre.ResetText();
            txtKullaniciAd.ResetText();
            cbYetki.SelectedIndex = -1;


            //personel bilgilerini guncelle
            listele();
            db.baglantiClose();
        }
        
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Admin", db.baglantiOpen());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            db.baglantiClose();
        }
        private void YoneticiAdd_Load(object sender, EventArgs e)
        {
            listele();


            //yetkileri Comboboxa cekme
            SqlCommand komut = new SqlCommand("Select YetkiAd From Yetki", db.baglantiOpen());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                cbYetki.Properties.Items.Add(oku[0].ToString());
                
            }
            db.baglantiClose();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKullaniciAd.Text) ||
        string.IsNullOrWhiteSpace(txtSifre.Text) ||
        cbYetki.SelectedItem == null)
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // İşlemi durdur
            }

            try
            {
                db.baglantiOpen();
                SqlCommand kaydetKomut = new SqlCommand("insert into Admin(YoneticiKullaniciAd,YoneticiSifre,YoneticiYetki) values (@p1,@p2,@p3)", db.baglantiOpen());
                kaydetKomut.Parameters.AddWithValue("@p1", txtKullaniciAd.Text);
                kaydetKomut.Parameters.AddWithValue("@p2", txtSifre.Text);
                kaydetKomut.Parameters.AddWithValue("@p3", cbYetki.Text);
                kaydetKomut.ExecuteNonQuery();
                db.baglantiClose();


                MessageBox.Show("Kayıt Başarılı", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnKaydet.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı Giriş Yaptınız! Tekrar Deneyin ", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            Temizle();
        }

        
    }
}
