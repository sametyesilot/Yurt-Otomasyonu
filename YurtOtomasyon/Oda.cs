using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;

namespace YurtOtomasyon
{
    public partial class Oda : Form
    {
        public Oda()
        {
            InitializeComponent();
        }

        // Veritabanı bağlantı sınıfı (kendi bağlantı sınıfınıza göre düzenleyin)
        DbConnection db = new DbConnection();

        // Oda bilgilerini listeleyen metot
        void listele()
        {
            DataTable dt = new DataTable();
            string query = @"
        SELECT ISNULL(Ogrenci.OgrAd, 'Boş') AS OgrAd, 
               ISNULL(Ogrenci.OgrSoyad, 'Boş') AS OgrSoyad,
               Oda.OdaNo, Oda.OdaKapasite, Oda.OdaDolulukDurum, Oda.OdaDurum
        FROM Oda
        LEFT JOIN Ogrenci ON Oda.OdaNo = Ogrenci.OgrOdaNo";

            SqlDataAdapter da = new SqlDataAdapter(query, db.baglantiOpen());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void Oda_Load(object sender, EventArgs e)
        {
            listele();
            
            gridView1.ClearGrouping(); 
            gridView1.Columns["OdaNo"].GroupIndex = 0;
            gridView1.OptionsCustomization.AllowColumnMoving = false; // Kolon taşıma işlemini aktif bırakıyoruz


        }
    }
}