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
    public partial class StudentUpdate : Form
    {
        public StudentUpdate()
        {
            InitializeComponent();
        }
        DbConnection db = new DbConnection();


        private void bosOdalarıComboBoxaCek()
        {
            cbOdaNo.Properties.Items.Clear();
            

            db.baglantiOpen();
            SqlCommand komut2 = new SqlCommand("Select OdaNo from Oda where OdaKapasite != OdaDolulukDurum", db.baglantiOpen());
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                cbOdaNo.Properties.Items.Add(oku2[0].ToString());
                

            }
            db.baglantiClose();
        }
        private void TemizleGuncelleSil()
        {
            //guncelle için temizleme
            txtId.ResetText();
            txtOgrAd.ResetText();
            txtOgrSoyad.ResetText();
            mskTc.ResetText();
            mskOgrTel.ResetText();
            mskDogum.ResetText();
            txtEmail.ResetText();
            cbBolum.SelectedIndex = -1;
            cbOdaNo.SelectedIndex = -1;
            txtVeliAdSoyad.ResetText();
            mskVeliTel.ResetText();
            memoAdres.ResetText();
        }
        
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Ogrenci", db.baglantiOpen());
            da.Fill(dt);
            gridControl1.DataSource = dt;

        }
        private void StudentUpdate_Load(object sender, EventArgs e)
        {
            
            //ogrenci Bilgilerini Listele
            listele();
            db.baglantiClose();

            //Bolumleri Comboboxa cekme
            SqlCommand komut = new SqlCommand("Select BolumAd From Bolum", db.baglantiOpen());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                cbBolum.Properties.Items.Add(oku[0].ToString());
                
            }
            db.baglantiClose();
            bosOdalarıComboBoxaCek();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue("OgrenciId") != null)

            {
                //guncelle için
                txtId.Text = gridView1.GetFocusedRowCellValue("OgrenciId").ToString();
                txtOgrAd.Text = gridView1.GetFocusedRowCellValue("OgrAd").ToString();
                txtOgrSoyad.Text = gridView1.GetFocusedRowCellValue("OgrSoyad").ToString();
                mskTc.Text = gridView1.GetFocusedRowCellValue("OgrTC").ToString();
                mskOgrTel.Text = gridView1.GetFocusedRowCellValue("OgrTelefon").ToString();
                mskDogum.Text = gridView1.GetFocusedRowCellValue("OgrDogum").ToString();
                txtEmail.Text = gridView1.GetFocusedRowCellValue("OgrMail").ToString();
                cbBolum.Text = gridView1.GetFocusedRowCellValue("OgrBolum").ToString();
                cbOdaNo.Text = gridView1.GetFocusedRowCellValue("OgrOdaNo").ToString();
                txtVeliAdSoyad.Text = gridView1.GetFocusedRowCellValue("VeliAdSoyad").ToString();
                mskVeliTel.Text = gridView1.GetFocusedRowCellValue("VeliTelefon").ToString();
                memoAdres.Text = gridView1.GetFocusedRowCellValue("VeliAdres").ToString();
                
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

            
            try
            {
                db.baglantiOpen();
                int id = int.Parse(txtId.Text);

                SqlCommand eskiOdaAzaltKomut = new SqlCommand("UPDATE Oda SET OdadolulukDurum = OdadolulukDurum - 1 WHERE OdaNo = (SELECT OgrOdaNo FROM Ogrenci WHERE OgrenciId = @id)", db.baglantiOpen());
                eskiOdaAzaltKomut.Parameters.AddWithValue("@id", id);
                eskiOdaAzaltKomut.ExecuteNonQuery();

                SqlCommand komut = new SqlCommand("UPDATE Ogrenci SET OgrAd = @ad, OgrSoyad = @soyad, OgrTc = @tc, OgrTelefon=@tel, OgrDogum = @dogum, OgrMail= @mail, OgrBolum = @bolum, OgrOdaNo = @oda, VeliAdSoyad =@veliad,VeliTelefon=@velitel , VeliAdres= @veliadres WHERE OgrenciId = @id", db.baglantiOpen());
                komut.Parameters.AddWithValue("@id", txtId.Text);
                komut.Parameters.AddWithValue("@ad", txtOgrAd.Text);
                komut.Parameters.AddWithValue("@soyad", txtOgrSoyad.Text);
                komut.Parameters.AddWithValue("@tc", mskTc.Text);
                komut.Parameters.AddWithValue("@tel", mskOgrTel.Text);
                komut.Parameters.AddWithValue("@dogum", mskDogum.Text);
                komut.Parameters.AddWithValue("@mail", txtEmail.Text);
                komut.Parameters.AddWithValue("@bolum", cbBolum.Text);
                komut.Parameters.AddWithValue("@oda", cbOdaNo.Text);
                komut.Parameters.AddWithValue("@veliad", txtVeliAdSoyad.Text);
                komut.Parameters.AddWithValue("@velitel", mskVeliTel.Text);
                komut.Parameters.AddWithValue("@veliadres", memoAdres.Text);
                komut.ExecuteNonQuery();

                SqlCommand yeniOdaArtirKomut = new SqlCommand("UPDATE Oda SET OdadolulukDurum = OdadolulukDurum + 1 WHERE OdaNo = @yeniOda", db.baglantiOpen());
                yeniOdaArtirKomut.Parameters.AddWithValue("@yeniOda", cbOdaNo.Text);
                yeniOdaArtirKomut.ExecuteNonQuery();

                db.baglantiClose();

                bosOdalarıComboBoxaCek();
                MessageBox.Show("Kayıt başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Lütfen bir satır seçtiğinizden emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            TemizleGuncelleSil();
            listele();
            db.baglantiClose();
        }
    }
}
