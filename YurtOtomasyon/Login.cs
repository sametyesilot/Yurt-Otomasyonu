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
    public partial class Login : Form
    {
        private Form1 mainForm;
        public Login(Form1 form1)
        {
            InitializeComponent();
            mainForm = form1;
        }
        DbConnection db = new DbConnection();
        public User user;

        private void Login_Load(object sender, EventArgs e)
        {
            labelControl1.Appearance.BackColor = Color.FromArgb(28, 24, 52);
            labelControl2.Appearance.BackColor = Color.FromArgb(28, 24, 52);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtSifre.Text;
            string sifre = txtKullaniciAdi.Text;
            db.baglantiOpen();
            SqlCommand komut = new SqlCommand();
            komut.Connection = db.baglantiOpen();
            komut.CommandText = "Select *from Admin where YoneticiKullaniciAd = '" + txtKullaniciAdi.Text + "'  and YoneticiSifre='" + txtSifre.Text + "'";
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                TimeSpan time = DateTime.Now.TimeOfDay;
                string formattedTime = time.ToString(@"hh\:mm\:ss");
                dr.Close(); 
                SqlCommand ekleKomut = new SqlCommand("INSERT INTO Giris (KullaniciAd, Sifre, GirisTarihi) VALUES (@kullaniciAdi, @sifre, @girisTarihi)", db.baglantiOpen());
                ekleKomut.Parameters.AddWithValue("@kullaniciAdi", sifre);
                ekleKomut.Parameters.AddWithValue("@sifre", kullaniciAdi);
                ekleKomut.Parameters.AddWithValue("@girisTarihi", formattedTime);
                ekleKomut.ExecuteNonQuery();
                db.baglantiClose();

                //  MessageBox.Show("Giriş Başarılı", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                user = new User(txtKullaniciAdi.Text, txtSifre.Text);
                mainForm.SetUser(user);
                

                mainForm.Visible = true;
                this.Close();



            }
            else
            {
                MessageBox.Show("Hatalı Giriş Yaptınız! Tekrar Deneyin ", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            db.baglantiClose();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
