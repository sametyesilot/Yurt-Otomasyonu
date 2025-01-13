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
    public partial class PersonelUpdate : Form
    {
        public PersonelUpdate()
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
        private void TemizleGuncelleSil()
        {
           
            txtId.ResetText();
            txtAdSoyad.ResetText();
            cbDepart.SelectedIndex = -1;


        }
        private void PersonelDelete_Load(object sender, EventArgs e)
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

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue("PersonelId") != null)
            {
                //guncelle için
                txtId.Text = gridView1.GetFocusedRowCellValue("PersonelId").ToString();
                txtAdSoyad.Text = gridView1.GetFocusedRowCellValue("PersonelAdSoyad").ToString();
                cbDepart.Text = gridView1.GetFocusedRowCellValue("PersonelDepartman").ToString();
            }
            }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                db.baglantiOpen();
                int id = int.Parse(txtId.Text);
                SqlCommand komut = new SqlCommand("UPDATE Personel SET PersonelAdSoyad = @ad, PersonelDepartman = @depart WHERE PersonelId = @id", db.baglantiOpen());
                komut.Parameters.AddWithValue("@id", id);
                komut.Parameters.AddWithValue("@ad", txtAdSoyad.Text);
                komut.Parameters.AddWithValue("@depart", cbDepart.Text);
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
