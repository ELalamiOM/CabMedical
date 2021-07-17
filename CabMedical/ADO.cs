using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace CabMedical
{
    public class ADO
    {
        public SqlConnection con = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        public SqlDataReader dr;
        public DataTable dt = new DataTable();
        public SqlDataAdapter dap = new SqlDataAdapter();
        public DataSet ds = new DataSet();
        public SqlCommandBuilder bc;

        public void connecter()
        {
            if(con.State == ConnectionState.Closed || con.State == ConnectionState.Broken)
            {
                con.ConnectionString = "Data Source=DESKTOP-HT16NSJ\\SQLEXPRESS;Initial Catalog=MyCabMedDB2;Integrated Security=True";
                con.Open();
            }
        }

        public void Deconnecter()
        {
            if(con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}