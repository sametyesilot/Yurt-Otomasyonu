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
    public partial class DepartDelete : Form
    {
        public DepartDelete()
        {
            InitializeComponent();
        }
        DbConnection db = new DbConnection();
        private void DepartDelete_Load(object sender, EventArgs e)
        {
            //rehberleri Comboboxa cekme
            SqlCommand komut = new SqlCommand("Select DepartName From Depart", db.baglantiOpen());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                cbDepartman.Properties.Items.Add(oku[0].ToString());

            }
            db.baglantiClose();
        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            string secilenBolum = cbDepartman.SelectedItem?.ToString();

            // Seçim yapılmamışsa uyarı ver
            if (string.IsNullOrEmpty(secilenBolum))
            {
                MessageBox.Show("Lütfen silmek istediğiniz bölümü seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Bölümü silme komutu
                SqlCommand komut = new SqlCommand("DELETE FROM Depart WHERE DepartName = @DepartName", db.baglantiOpen());
                komut.Parameters.AddWithValue("@DepartName", secilenBolum);

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
            cbDepartman.SelectedIndex = -1;
            cbDepartman.Properties.Items.Clear();
            //rehberleri Comboboxa cekme
            SqlCommand komut2 = new SqlCommand("Select DepartName From Depart", db.baglantiOpen());
            SqlDataReader oku = komut2.ExecuteReader();
            while (oku.Read())
            {
                cbDepartman.Properties.Items.Add(oku[0].ToString());

            }
            db.baglantiClose();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
