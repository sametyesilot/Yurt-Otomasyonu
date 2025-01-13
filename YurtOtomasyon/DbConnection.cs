using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace YurtOtomasyon
{
    class DbConnection
    {
        SqlConnection connect;

        public string ConnectionString => ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public SqlConnection baglantiOpen()
        {
            string connect1 = @"Data Source=DESKTOP-9A2P5HN\SQLEXPRESS01;Initial Catalog=YurtOtomasyon;Integrated Security=True";

            connect = new SqlConnection(connect1);
            connect.Open();
            return connect;
        }
        public void baglantiClose()
        {
            connect.Close();
        }



    }
}
