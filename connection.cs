using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;




namespace StudentDetails
{
    public class connection
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adp;
        SqlDataReader rdr;
        DataSet ds;

        public SqlConnection Connect()
        {

            con = new SqlConnection();
            string strcon = ConfigurationManager.AppSettings.Get("connect");
            con.ConnectionString = strcon;
            con.Open();
            return con;

        }
        public void insupdel(string sql)
        {
            cmd = new SqlCommand(sql, Connect());
            cmd.ExecuteNonQuery();

        }
        public SqlDataReader getdata(string sql)
        {
            cmd = new SqlCommand(sql, Connect());
            rdr = cmd.ExecuteReader();
            return rdr;

        }
        public DataSet gridview(string sql)
        {
            adp = new SqlDataAdapter(sql, Connect());
            DataSet ds = new DataSet();
            adp.Fill(ds);
            return ds;

        }
    }




}
