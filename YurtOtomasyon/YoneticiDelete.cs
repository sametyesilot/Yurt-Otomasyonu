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
    public partial class YoneticiDelete : Form
    {
        public YoneticiDelete()
        {
            InitializeComponent();
        }
        DbConnection db = new DbConnection();

        private void TemizleGuncelleSil()
        {
            txtId3.ResetText();
            txtKullaniciAd3.ResetText();
            txtSifre3.ResetText();
            cbYetki3.SelectedIndex = -1;
        }

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Admin", db.baglantiOpen());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            db.baglantiClose();
        }
        private void YoneticiDelete_Load(object sender, EventArgs e)
        {
            listele();

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue("YoneticiId") != null)
            {
                //silme için
                txtId3.Text = gridView1.GetFocusedRowCellValue("YoneticiId").ToString();
                txtKullaniciAd3.Text = gridView1.GetFocusedRowCellValue("YoneticiKullaniciAd").ToString();
                txtSifre3.Text = gridView1.GetFocusedRowCellValue("YoneticiSifre").ToString();
                cbYetki3.Text = gridView1.GetFocusedRowCellValue("YoneticiYetki").ToString();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {

            
            DialogResult result = MessageBox.Show(
                "Silmek istediğinize emin misiniz?",  
                "Silme Onayı",                       
                MessageBoxButtons.YesNo,             
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    db.baglantiOpen();
                    int id = int.Parse(txtId3.Text);
                    SqlCommand komut = new SqlCommand("DELETE FROM Admin WHERE YoneticiId = @id", db.baglantiOpen());
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
