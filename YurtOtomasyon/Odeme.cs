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
    public partial class Odeme : Form
    {
        public Odeme()
        {
            InitializeComponent();
        }
        DbConnection db = new DbConnection();
        void listele()
        {
            
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT OgrenciId, OgrAd, OgrSoyad, OgrTC, OdemeDurumu FROM Ogrenci", db.baglantiOpen());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void Odeme_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue("OgrenciId") != null)

            {        //silme için
                txtId.Text = gridView1.GetFocusedRowCellValue("OgrenciId").ToString();
                txtOgrAd.Text = gridView1.GetFocusedRowCellValue("OgrAd").ToString();
                txtOgrSoyad.Text = gridView1.GetFocusedRowCellValue("OgrSoyad").ToString();
                mskTc.Text = gridView1.GetFocusedRowCellValue("OgrTC").ToString();

                var odemeDurumu = gridView1.GetFocusedRowCellValue("OdemeDurumu");

                // Eğer OdemeDurumu false ise "Yapılmadı", 1 ise "Yapıldı" yazdırıyoruz
                if (odemeDurumu != null)
                {
                    if (Convert.ToBoolean(odemeDurumu) == false)
                    {
                        txtOdemeDrumu.Text = "Yapılmadı";
                    }
                    else if (Convert.ToBoolean(odemeDurumu) == true)
                    {
                        txtOdemeDrumu.Text = "Yapıldı";
                    }
                }
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            
            int ogrenciId = Convert.ToInt32(txtId.Text);
            try
            {
                db.baglantiOpen();
                SqlCommand cmd = new SqlCommand("SELECT OdemeDurumu FROM Ogrenci WHERE OgrenciId = @ogrenciId", db.baglantiOpen());
                cmd.Parameters.AddWithValue("@ogrenciId", ogrenciId);
                var odemeDurumu = cmd.ExecuteScalar();

                // Eğer OdemeDurumu 1 ise, ödeme yapılmış demektir
                if (odemeDurumu != null && Convert.ToBoolean(odemeDurumu) == true)
                {
                    MessageBox.Show("Ödeme zaten yapılmış.");
                    return;
                }
                SqlCommand komut = new SqlCommand("UPDATE Ogrenci SET OdemeDurumu = 1 WHERE OgrenciId = @ogrenciId", db.baglantiOpen());
                komut.Parameters.AddWithValue("@ogrenciId", ogrenciId);
                komut.ExecuteNonQuery();
                MessageBox.Show("Ödeme durumu başarıyla güncellendi.");
                listele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
            finally
            {
                db.baglantiClose();
            }
        }
    }
}
