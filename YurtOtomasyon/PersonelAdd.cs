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
    public partial class PersonelAdd : Form
    {
        public PersonelAdd()
        {
            InitializeComponent();
        }
        DbConnection db = new DbConnection();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Personel", db.baglantiOpen());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            db.baglantiClose();
        }
        private void Temizle()
        {
            txtAdSoyad.ResetText();
            cbDepart.SelectedIndex = -1;
            

            //personel bilgilerini guncelle
            listele();
            db.baglantiClose();
        }
        
        private void PersonelAdd_Load(object sender, EventArgs e)
        {

            listele();


            //depatmanları Comboboxa cekme
            SqlCommand komut = new SqlCommand("Select DepartName From Depart", db.baglantiOpen());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                cbDepart.Properties.Items.Add(oku[0].ToString());
                
            }
            db.baglantiClose();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtAdSoyad.Text) || cbDepart.SelectedItem == null)
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Kaydetme işlemini durdur
            }

            DateTime kayitTarihi = DateTime.Now;
            try
            {
                db.baglantiOpen();
                SqlCommand kaydetKomut = new SqlCommand("insert into Personel(PersonelAdSoyad,PersonelDepartman) values (@p1,@p2)", db.baglantiOpen());
                kaydetKomut.Parameters.AddWithValue("@p1", txtAdSoyad.Text);
                kaydetKomut.Parameters.AddWithValue("@p2", cbDepart.Text);

                kaydetKomut.ExecuteNonQuery();
                db.baglantiClose();


                MessageBox.Show("Kayıt Başarılı", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnKaydet.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı Giriş Yaptınız! Tekrar Deneyin ", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            Temizle();
        }
    }
}
