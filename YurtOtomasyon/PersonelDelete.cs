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
    public partial class PersonelDelete : Form
    {
        public PersonelDelete()
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
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue("PersonelId") != null)
            {
         
                txtId.Text = gridView1.GetFocusedRowCellValue("PersonelId").ToString();
                txtAdSoyad.Text = gridView1.GetFocusedRowCellValue("PersonelAdSoyad").ToString();
                cbDepart.Text = gridView1.GetFocusedRowCellValue("PersonelDepartman").ToString();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show(
                "Silmek istediğinize emin misiniz?",  // Mesaj metni
                "Silme Onayı",                       // Başlık
                MessageBoxButtons.YesNo,             // Buton seçenekleri
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    db.baglantiOpen();
                    int id = int.Parse(txtId.Text);
                    SqlCommand komut = new SqlCommand("DELETE FROM Personel WHERE PersonelId = @id", db.baglantiOpen());
                    komut.Parameters.AddWithValue("@id", id);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Başarılıyla Silindi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch
                {
                    MessageBox.Show("Lütfen bir satır seçtiğinizden emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                listele();
                TemizleGuncelleSil();

            }
            else if (result == DialogResult.No)
            {

            }


            
        }
    }
}
