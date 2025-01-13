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
    public partial class YoneticiUpdate : Form
    {
        public YoneticiUpdate()
        {
            InitializeComponent();
        }
        DbConnection db = new DbConnection();
        private void TemizleGuncelleSil()
        {
            txtId2.ResetText();
            txtKullaniciAd2.ResetText();
            txtSifre2.ResetText();
            cbYetki2.SelectedIndex = -1;


        }
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Admin", db.baglantiOpen());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            db.baglantiClose();
        }
        private void YoneticiUpdate_Load(object sender, EventArgs e)
        {
            listele();

            //yetkileri Comboboxa cekme
            SqlCommand komut = new SqlCommand("Select YetkiAd From Yetki", db.baglantiOpen());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                cbYetki2.Properties.Items.Add(oku[0].ToString());
            }
            db.baglantiClose();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue("YoneticiId") != null)
            {
                //guncelle için
                txtId2.Text = gridView1.GetFocusedRowCellValue("YoneticiId").ToString();
                txtKullaniciAd2.Text = gridView1.GetFocusedRowCellValue("YoneticiKullaniciAd").ToString();
                txtSifre2.Text = gridView1.GetFocusedRowCellValue("YoneticiSifre").ToString();
                cbYetki2.Text = gridView1.GetFocusedRowCellValue("YoneticiYetki").ToString();
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

            
            try
            {
                db.baglantiOpen();
                int id = int.Parse(txtId2.Text);
                SqlCommand komut = new SqlCommand("UPDATE Admin SET YoneticiKullaniciAd = @ad, YoneticiSifre = @sifre,YoneticiYetki = @yetki WHERE YoneticiId = @id", db.baglantiOpen());
                komut.Parameters.AddWithValue("@id", id);
                komut.Parameters.AddWithValue("@ad", txtKullaniciAd2.Text);
                komut.Parameters.AddWithValue("@sifre", txtSifre2.Text);
                komut.Parameters.AddWithValue("@yetki", cbYetki2.Text);
                komut.ExecuteNonQuery();

                listele();
                db.baglantiClose();

                MessageBox.Show("Kayıt başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {

                MessageBox.Show("Lütfen bir satır seçtiğinizden emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            listele();
            TemizleGuncelleSil();
        }
    }
}
