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
    public partial class StudentDelete : Form
    {
        public StudentDelete()
        {
            InitializeComponent();
        }
        DbConnection db = new DbConnection();

        private void TemizleGuncelleSil()
        {

            //sil için temizleme
            txtId1.ResetText();
            txtOgrAd1.ResetText();
            txtOgrSoyad1.ResetText();
            mskTc1.ResetText();
            mskOgrTel1.ResetText();
            mskDogum1.ResetText();
            txtEmail1.ResetText();
            cbBolum1.SelectedIndex = -1;
            cbOdaNo1.SelectedIndex = -1;
            txtVeliAdSoyad1.ResetText();
            mskVeliTel1.ResetText();
            memoAdres1.ResetText();
        }
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Ogrenci", db.baglantiOpen());
            da.Fill(dt);
            gridControl1.DataSource = dt;

        }
        private void StudentDelete_Load(object sender, EventArgs e)
        {
            listele();
            db.baglantiClose();

            
            
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue("OgrenciId") != null)

            {        //silme için
                txtId1.Text = gridView1.GetFocusedRowCellValue("OgrenciId").ToString();
                txtOgrAd1.Text = gridView1.GetFocusedRowCellValue("OgrAd").ToString();
                txtOgrSoyad1.Text = gridView1.GetFocusedRowCellValue("OgrSoyad").ToString();
                mskTc1.Text = gridView1.GetFocusedRowCellValue("OgrTC").ToString();
                mskOgrTel1.Text = gridView1.GetFocusedRowCellValue("OgrTelefon").ToString();
                mskDogum1.Text = gridView1.GetFocusedRowCellValue("OgrDogum").ToString();
                cbBolum1.Text = gridView1.GetFocusedRowCellValue("OgrBolum").ToString();
                txtEmail1.Text = gridView1.GetFocusedRowCellValue("OgrMail").ToString();
                cbOdaNo1.Text = gridView1.GetFocusedRowCellValue("OgrOdaNo").ToString();
                txtVeliAdSoyad1.Text = gridView1.GetFocusedRowCellValue("VeliAdSoyad").ToString();
                mskVeliTel1.Text = gridView1.GetFocusedRowCellValue("VeliTelefon").ToString();
                memoAdres1.Text = gridView1.GetFocusedRowCellValue("VeliAdres").ToString();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            
            DialogResult result = MessageBox.Show(
                "Silmek istediğinize emin misiniz?",  // Mesaj metni
                "Silme Onayı",                       // Başlık
                MessageBoxButtons.YesNo,             // Buton seçenekleri
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    db.baglantiOpen();
                    int id = int.Parse(txtId1.Text);

                    //oda doluluk durumunu kontrol et
                    SqlCommand dolulukAzaltKomut = new SqlCommand("UPDATE Oda SET OdadolulukDurum = OdadolulukDurum - 1 WHERE OdaNo = @odaNo", db.baglantiOpen());
                    dolulukAzaltKomut.Parameters.AddWithValue("@odaNo", cbOdaNo1.Text);
                    dolulukAzaltKomut.ExecuteNonQuery();

                    //ogrenciyi sil
                    SqlCommand komut = new SqlCommand("DELETE FROM Ogrenci WHERE OgrenciId = @id", db.baglantiOpen());
                    komut.Parameters.AddWithValue("@id", id);
                    komut.ExecuteNonQuery();
                    db.baglantiClose();
                    MessageBox.Show("Kayıt Başarılıyla Silindi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Lütfen bir satır seçtiğinizden emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                TemizleGuncelleSil();
                listele();
                db.baglantiClose();
            }
            else if (result == DialogResult.No)
            {

            }
            

        }
    }
}
