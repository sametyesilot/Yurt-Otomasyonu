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
    public partial class StudentAdd : Form
    {
        public StudentAdd()
        {
            InitializeComponent();
        }
        DbConnection db = new DbConnection();


        private void bosOdalarıComboBoxaCek()
        {
            
            cbOdaNo2.Properties.Items.Clear();

            db.baglantiOpen();
            SqlCommand komut2 = new SqlCommand("Select OdaNo from Oda where OdaKapasite != OdaDolulukDurum", db.baglantiOpen());
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                cbOdaNo2.Properties.Items.Add(oku2[0].ToString());
            }
            db.baglantiClose();
        }
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Ogrenci", db.baglantiOpen());
            da.Fill(dt);
            gridControl1.DataSource = dt;

        }
        private void Temizle()
        {
            txtOgrAd2.ResetText();
            txtOgrSoyad2.ResetText();
            mskTc2.ResetText();
            mskOgrTel2.ResetText();
            mskDogum2.ResetText();
            txtEmail2.ResetText();
            cbBolum2.SelectedIndex = -1;
            cbOdaNo2.SelectedIndex = -1;
            txtVeliAdSoyad2.ResetText();
            mskVeliTel2.ResetText();
            memoAdres2.ResetText();

            //ogrenci Bilgilerini Listele
            listele();
            db.baglantiClose();
        }
       
        private void StudentAdd_Load(object sender, EventArgs e)
        {
            
            //ogrenci Bilgilerini Listele
            listele();
            db.baglantiClose();

            //Bolumleri Comboboxa cekme
            SqlCommand komut = new SqlCommand("Select BolumAd From Bolum", db.baglantiOpen());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                
                cbBolum2.Properties.Items.Add(oku[0].ToString());
            }
            db.baglantiClose();
            bosOdalarıComboBoxaCek();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOgrAd2.Text) ||
        string.IsNullOrWhiteSpace(txtOgrSoyad2.Text) ||
        string.IsNullOrWhiteSpace(mskTc2.Text) ||
        string.IsNullOrWhiteSpace(mskOgrTel2.Text) ||
        string.IsNullOrWhiteSpace(mskDogum2.Text) ||
        string.IsNullOrWhiteSpace(txtEmail2.Text) ||
        string.IsNullOrWhiteSpace(cbBolum2.Text) ||
        string.IsNullOrWhiteSpace(cbOdaNo2.Text) ||
        string.IsNullOrWhiteSpace(txtVeliAdSoyad2.Text) ||
        string.IsNullOrWhiteSpace(mskVeliTel2.Text) ||
        string.IsNullOrWhiteSpace(memoAdres2.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            try
            {
                db.baglantiOpen();
                SqlCommand kaydetKomut = new SqlCommand("insert into Ogrenci(OgrAd,OgrSoyad, OgrTC,OgrTelefon,OgrDogum,OgrMail,OgrBolum,OgrOdaNo,VeliAdSoyad,VeliTelefon,VeliAdres) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", db.baglantiOpen());
                kaydetKomut.Parameters.AddWithValue("@p1", txtOgrAd2.Text);
                kaydetKomut.Parameters.AddWithValue("@p2", txtOgrSoyad2.Text);
                kaydetKomut.Parameters.AddWithValue("@p3", mskTc2.Text);
                kaydetKomut.Parameters.AddWithValue("@p4", mskOgrTel2.Text);
                kaydetKomut.Parameters.AddWithValue("@p5", mskDogum2.Text);
                kaydetKomut.Parameters.AddWithValue("@p6", txtEmail2.Text);
                kaydetKomut.Parameters.AddWithValue("@p7", cbBolum2.Text);
                kaydetKomut.Parameters.AddWithValue("@p8", cbOdaNo2.Text);
                kaydetKomut.Parameters.AddWithValue("@p9", txtVeliAdSoyad2.Text);
                kaydetKomut.Parameters.AddWithValue("@p10", mskVeliTel2.Text);
                kaydetKomut.Parameters.AddWithValue("@p11", memoAdres2.Text);
                kaydetKomut.ExecuteNonQuery();

                SqlCommand dolulukGuncelleKomut = new SqlCommand("UPDATE Oda SET OdadolulukDurum = OdadolulukDurum + 1 WHERE OdaNo = @odaNo", db.baglantiOpen());
                dolulukGuncelleKomut.Parameters.AddWithValue("@odaNo", cbOdaNo2.Text);
                dolulukGuncelleKomut.ExecuteNonQuery();

                db.baglantiClose();

                MessageBox.Show("Kayıt Başarılı", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı Giriş Yaptınız! Tekrar Deneyin ", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }




            bosOdalarıComboBoxaCek();
            Temizle();

            //ogrenci Bilgilerini Listele
            listele();
            db.baglantiClose();
            
        }

        
    }
}
