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
    public partial class YetkiDelete : Form
    {
        public YetkiDelete()
        {
            InitializeComponent();
        }
        DbConnection db = new DbConnection();
        private void YetkiDelete_Load(object sender, EventArgs e)
        {
            //rehberleri Comboboxa cekme
            SqlCommand komut = new SqlCommand("Select YetkiAd From Yetki", db.baglantiOpen());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                cbYetki.Properties.Items.Add(oku[0].ToString());

            }
            db.baglantiClose();
        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            string secilenBolum = cbYetki.SelectedItem?.ToString();

            // Seçim yapılmamışsa uyarı ver
            if (string.IsNullOrEmpty(secilenBolum))
            {
                MessageBox.Show("Lütfen silmek istediğiniz bölümü seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Bölümü silme komutu
                SqlCommand komut = new SqlCommand("DELETE FROM Yetki WHERE YetkiAd = @YetkiAd", db.baglantiOpen());
                komut.Parameters.AddWithValue("@YetkiAd", secilenBolum);

                int sonuc = komut.ExecuteNonQuery(); // Komutun etkilediği satır sayısını al
                db.baglantiClose();

                MessageBox.Show("Başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                db.baglantiClose();
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cbYetki.SelectedIndex = -1;
            cbYetki.Properties.Items.Clear();
            //rehberleri Comboboxa cekme
            SqlCommand komut2 = new SqlCommand("Select YetkiAd From Yetki", db.baglantiOpen());
            SqlDataReader oku = komut2.ExecuteReader();
            while (oku.Read())
            {
                cbYetki.Properties.Items.Add(oku[0].ToString());

            }
            db.baglantiClose();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
