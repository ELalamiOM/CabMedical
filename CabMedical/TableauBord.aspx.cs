using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CabMedical
{
    public partial class TableauBord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                ShowData();

                //ShowData1();
        }

        private void ShowData()
        {
            //String myConnection = ConfigurationManager.ConnectionStrings["myConnection"].ToString();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-HT16NSJ\\SQLEXPRESS;Initial Catalog=MyCabMedDB2;Integrated Security=True");
            String query = "select  Date_Consultation,patient from Consultations";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable tb = new DataTable();
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                tb.Load(dr, LoadOption.OverwriteChanges);
                con.Close();
            }
            catch { }

            if (tb != null)
            {
                DateTime endDt = default(DateTime);
                DateTime DateSur = default(DateTime);

                DateSur = Convert.ToDateTime(tb.Rows[0]["Date_Consultation"].ToString());/* TODO ERROR: Skipped SkippedTokensTrivia */

                endDt = new DateTime(DateSur.Year, DateSur.Month, DateTime.DaysInMonth(DateSur.Year, DateSur.Month));

                String chart = "";
                chart = "<canvas id=\"line-chart\" width=\"100%\" height=\"35\"></canvas>";
                chart += "<script>";
                chart += "new Chart(document.getElementById(\"line-chart\"), { type: 'line', data: {labels: [";

                // more detais
                for (int i = 1; i < endDt.Day; i++)
                    chart += i.ToString() + ",";
                chart = chart.Substring(0, chart.Length);

                chart += "],datasets: [{ data: [";

                // get data from database and add to chart
                String value = "";
                for (int i = 0; i < tb.Rows.Count; i++)
                    value += tb.Rows[i]["patient"].ToString() + ",";
                value = value.Substring(0, value.Length);
                chart += value;

                chart += "],label: \"Nombre de consultation dans le mois juillet\",borderColor: \"#3e95cd\",fill: true}"; // Chart color
                chart += "]},options: { title: { display: true,text: ''} }"; // Chart title
                chart += "});";
                chart += "</script>";           

                ltChart.Text = chart;
            }

        }


        //private void ShowData1()
        //{
        //    String chart1 = "";
        //    chart1 = "<canvas id=\"line-chart\" width=\"100%\" height=\"35\"></canvas>";
        //    chart1 += "<script>";
        //    chart1 += "new Chart(document.getElementById(\"line-chart\"), { type: 'line', data: {";
        //    chart1 += "labels: [1500,1600,1700,1750,1800]";
        //    chart1 += ",datasets: [{ data: [";
        //    chart1 += "114.3,106,107,133,144";
        //    chart1 += "],label: \"Chart \",borderColor: \"#3e95cd\",fill: false}"; // Chart color
        //    chart1 += "]},options: { title: { display: true,text: 'Chart'} }"; // Chart title
        //    chart1 += "});";
        //    chart1 += "</script>";

        //    ltChart1.Text = chart1;
        //}

    }

}
