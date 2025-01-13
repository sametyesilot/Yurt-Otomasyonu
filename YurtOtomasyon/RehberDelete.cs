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
    public partial class RehberDelete : Form
    {
        public RehberDelete()
        {
            InitializeComponent();
        }
        DbConnection db = new DbConnection();
        private void RehberDelete_Load(object sender, EventArgs e)
        {
            //rehberleri Comboboxa cekme
            SqlCommand komut = new SqlCommand("Select RehberAdSoyad From Rehber", db.baglantiOpen());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                cbRehber.Properties.Items.Add(oku[0].ToString());

            }
            db.baglantiClose();
        }

        private void cbRehber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRehber.SelectedIndex != -1) // Eğer bir rehber seçildiyse
            {
                string secilenRehber = cbRehber.Text;

                try
                {
                    db.baglantiOpen();
                    SqlCommand komut = new SqlCommand("SELECT RehberMail FROM Rehber WHERE RehberAdSoyad = @RehberAdSoyad", db.baglantiOpen());
                    komut.Parameters.AddWithValue("@RehberAdSoyad", secilenRehber);

                    SqlDataReader okuyucu = komut.ExecuteReader();
                    okuyucu.Read(); // Zorunlu olduğu için doğrudan okutuyoruz
                    txtRehberEmail.Text = okuyucu["RehberMail"].ToString();

                    db.baglantiClose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.baglantiClose();
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            if (cbRehber.SelectedIndex != -1) // Eğer bir rehber seçildiyse
            {
                string secilenRehber = cbRehber.Text;

                try
                {
                    // Rehberi silme işlemi
                    db.baglantiOpen();

                    // Rehberi silmek için DELETE komutu
                    SqlCommand silKomut = new SqlCommand("DELETE FROM Rehber WHERE RehberAdSoyad = @RehberAdSoyad", db.baglantiOpen());
                    silKomut.Parameters.AddWithValue("@RehberAdSoyad", secilenRehber);

                    int silinenSatirSayisi = silKomut.ExecuteNonQuery();

                    db.baglantiClose();

                    if (silinenSatirSayisi > 0)
                    {
                        MessageBox.Show("Rehber başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Silme işlemi başarısız. Lütfen tekrar deneyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                    // Combobox'ı güncellemek için silinen rehberi kaldırıyoruz
                    cbRehber.Properties.Items.Remove(secilenRehber);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.baglantiClose();
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz rehberi seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            cbRehber.ResetText();
            txtRehberEmail.ResetText();
        }
    }
}
