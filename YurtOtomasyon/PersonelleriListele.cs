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
    public partial class PersonelleriListele : Form
    {
        public PersonelleriListele()
        {
            InitializeComponent();
        }
        DbConnection db = new DbConnection();
        private void PersonelleriListele_Load(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Personel", db.baglantiOpen());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            db.baglantiClose();
        }
    }
}
