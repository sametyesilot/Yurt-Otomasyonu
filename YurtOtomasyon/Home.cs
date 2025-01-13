using DevExpress.XtraCharts;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace YurtOtomasyon
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        DbConnection db = new DbConnection();
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT OgrAd, OgrSoyad, OgrOdaNo, OgrTC, OgrBolum FROM Ogrenci", db.baglantiOpen());
            da.Fill(dt);
            gridControl1.DataSource = dt;

            DataTable dt1 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM Personel", db.baglantiOpen());
            da2.Fill(dt1);
            gridControl2.DataSource = dt1;
        }

        private void Home_Load(object sender, EventArgs e)
        {
            listele();
            // Yatak kapasitesini ve öğrenci sayısını hesapla
            int kapasite = 200;
            int doluYatakSayisi = GetOgrenciSayisi(); // Öğrenci sayısını al
            int bosYatakSayisi = kapasite - doluYatakSayisi;

            // Pie Chart'a veri bağlama
            chartControl1.Series.Clear();
            Series series = new Series("Yatak Durumu", ViewType.Pie3D); // 3D Pie Chart

            // Dolu ve Boş yatakları ekle
            series.Points.Add(new SeriesPoint("Dolu Yatak", doluYatakSayisi));
            series.Points.Add(new SeriesPoint("Boş Yatak", bosYatakSayisi));

            // Pie Chart'ı ayarla
            chartControl1.Series.Add(series);
            chartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;

            // Legend'da sadece isimleri göstermek için Series.LegendTextPattern kullanma
            series.LegendTextPattern = "{A}"; // Yalnızca isimleri gösterir
            
        }
        
        private int GetOgrenciSayisi()
        {
            // MSSQL bağlantısını kullanarak öğrenci sayısını al
            int ogrenciSayisi = 0;
            string query = "SELECT COUNT(*) FROM Ogrenci";

            db.baglantiOpen();
            SqlCommand cmd = new SqlCommand(query, db.baglantiOpen());
            ogrenciSayisi = (int)cmd.ExecuteScalar();

            return ogrenciSayisi;
        }
    }
}
