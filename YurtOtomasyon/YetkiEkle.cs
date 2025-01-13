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
    public partial class YetkiEkle : Form
    {
        public YetkiEkle()
        {
            InitializeComponent();
        }
        DbConnection db = new DbConnection();
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(txtYetki.Text))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                db.baglantiOpen();
                SqlCommand kaydetKomut = new SqlCommand("insert into Yetki(YetkiAd) values (@p1)", db.baglantiOpen());
                kaydetKomut.Parameters.AddWithValue("@p1", txtYetki.Text);
                kaydetKomut.ExecuteNonQuery();

                db.baglantiClose();

                MessageBox.Show("Kayıt Başarılı", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı Giriş Yaptınız! Tekrar Deneyin ", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void YetkiEkle_Load(object sender, EventArgs e)
        {

        }

        
    }
}
