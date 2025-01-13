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
    public partial class BolumDelete : Form
    {
        public BolumDelete()
        {
            InitializeComponent();
        }
        DbConnection db = new DbConnection();
        private void btnKayit_Click(object sender, EventArgs e)
        {
            string secilenBolum = cbBolum.SelectedItem?.ToString();

            // Seçim yapılmamışsa uyarı ver
            if (string.IsNullOrEmpty(secilenBolum))
            {
                MessageBox.Show("Lütfen silmek istediğiniz bölümü seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Bölümü silme komutu
                SqlCommand komut = new SqlCommand("DELETE FROM Bolum WHERE BolumAd = @BolumAd", db.baglantiOpen());
                komut.Parameters.AddWithValue("@BolumAd", secilenBolum);

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
            cbBolum.SelectedIndex = -1;
            cbBolum.Properties.Items.Clear();
            //rehberleri Comboboxa cekme
            SqlCommand komut2 = new SqlCommand("Select BolumAd From Bolum", db.baglantiOpen());
            SqlDataReader oku = komut2.ExecuteReader();
            while (oku.Read())
            {
                cbBolum.Properties.Items.Add(oku[0].ToString());

            }
            db.baglantiClose();
        }

        private void BolumDelete_Load(object sender, EventArgs e)
        {
            //rehberleri Comboboxa cekme
            SqlCommand komut = new SqlCommand("Select BolumAd From Bolum", db.baglantiOpen());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                cbBolum.Properties.Items.Add(oku[0].ToString());

            }
            db.baglantiClose();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
