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
    public partial class RehberEkle : Form
    {
        public RehberEkle()
        {
            InitializeComponent();
        }
        DbConnection db = new DbConnection();
            private void btnKayit_Click(object sender, EventArgs e)
            {
                try
                {

                if (string.IsNullOrWhiteSpace(txtRehberAdSoyad.Text) || string.IsNullOrWhiteSpace(txtRehberEmail.Text))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; 
                }
                db.baglantiOpen();
                    SqlCommand kaydetKomut = new SqlCommand("insert into Rehber(RehberAdSoyad,RehberMail) values (@p1,@p2)", db.baglantiOpen());
                    kaydetKomut.Parameters.AddWithValue("@p1", txtRehberAdSoyad.Text);
                    kaydetKomut.Parameters.AddWithValue("@p2", txtRehberEmail.Text);
                
                    kaydetKomut.ExecuteNonQuery();
                
                    db.baglantiClose();

                    MessageBox.Show("Kayıt Başarılı", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Hatalı Giriş Yaptınız! Tekrar Deneyin ", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            txtRehberAdSoyad.ResetText();
            txtRehberEmail.ResetText();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RehberEkle_Load(object sender, EventArgs e)
        {

        }
    }
}
