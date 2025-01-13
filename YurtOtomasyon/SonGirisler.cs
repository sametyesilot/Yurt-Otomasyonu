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
    public partial class SonGirisler : Form
    {
        public SonGirisler()
        {
            InitializeComponent();
        }
        DbConnection db = new DbConnection();
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Giris ORDER BY GirisId DESC", db.baglantiOpen());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void TemizleEskiKayıtlar()
        {
            string query = @"
        DELETE FROM Giris 
        WHERE GirisId NOT IN 
        (
            SELECT TOP 50 GirisId FROM Giris ORDER BY GirisId DESC
        )";
            db.baglantiOpen();
            SqlCommand command = new SqlCommand(query, db.baglantiOpen());
                    
            command.ExecuteNonQuery();
                
            
        }
        private void SonGirisler_Load(object sender, EventArgs e)
        {
            TemizleEskiKayıtlar();
            listele();
            
        }
    }
}
