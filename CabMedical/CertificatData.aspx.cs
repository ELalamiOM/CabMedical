using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CabMedical
{
    public partial class CertificatData : System.Web.UI.Page
    {
        ADO d = new ADO();
        public void RemplirGrid()
        {
            d.connecter();
            if (d.dt.Rows != null)
            {
                d.dt.Clear();
            }
            d.cmd.CommandText = "select Certificats.Num_Certificat,  Date_Certificat , Ville_Certificat , Discription_Certificat ,medecin ,  Nom_Prénom_Patient  from Certificats join Patients on Patients.Num_Patient = Certificats.patient";
            d.cmd.Connection = d.con;
            d.dr = d.cmd.ExecuteReader();
            d.dt.Load(d.dr);
            GridView_Certificat.DataSource = d.dt;
            GridView_Certificat.DataBind();
            d.dr.Close();
            d.Deconnecter();
        }

        DataSet dsPat = new DataSet();
        SqlDataAdapter daPat;
        public void RemplirDrop_Patient()
        {
            string con = "Data Source=DESKTOP-HT16NSJ\\SQLEXPRESS;Initial Catalog=MyCabMedDB2;Integrated Security=True";
            string req = "select Nom_Prénom_Patient , Num_Patient from Patients";
            daPat = new SqlDataAdapter(req, con);
            daPat.Fill(dsPat, "Patients");
            DropDownList_Patient.DataTextField = "Nom_Prénom_Patient";
            DropDownList_Patient.DataValueField = "Num_Patient";
            DropDownList_Patient.DataSource = dsPat.Tables["Patients"];
            DropDownList_Patient.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RemplirGrid();
                RemplirDrop_Patient();
            }

            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            TextBox_Date.Enabled = false;
            TextBox_Ville.Enabled = false;
            TextBox1_Description.Enabled = false;
            TextBox_Medecin.Enabled = false;
            DropDownList_Patient.Enabled = false;
        }

        protected void Button_Actualiser_Click(object sender, EventArgs e)
        {
            RemplirGrid();
        }

        protected void GridView_Certificat_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int a = e.RowIndex;
            int code = int.Parse(GridView_Certificat.Rows[a].Cells[1].Text);
            d.connecter();
            d.cmd.CommandText = "delete from Certificats where Num_Certificat = '" + code+"' ";
            d.cmd.Connection = d.con;
            d.cmd.ExecuteNonQuery();
            RemplirGrid();
            d.Deconnecter();
        }

        protected void GridView_Certificat_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int r = e.NewSelectedIndex;
            Textox_Numero.Text = GridView_Certificat.Rows[r].Cells[2].Text;
            TextBox_Date.Text = GridView_Certificat.Rows[r].Cells[3].Text;
            TextBox_Ville.Text = GridView_Certificat.Rows[r].Cells[4].Text;
            TextBox1_Description.Text = GridView_Certificat.Rows[r].Cells[5].Text;
            TextBox_Medecin.Text = GridView_Certificat.Rows[r].Cells[6].Text;
            //DropDownList_Patient.SelectedValue = GridView_Ordonnance.Rows[r].Cells[7].Text;

            TextBox_Date.Enabled = true;
            TextBox_Ville.Enabled = true;
            TextBox1_Description.Enabled = true;
            TextBox_Medecin.Enabled = true;
            DropDownList_Patient.Enabled = true;
        }

        protected void Button_Imprimer_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-GPDIAMB\\SQLEXPRESS;Initial Catalog=MyCabMedDB2;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Select * from Certificats join Patients on Certificats.patient = Patients.Num_Patient where Num_Certificat = '" + TextBox_Num_Certificat.Text+"'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            ReportDocument crp = new ReportDocument();
            crp.Load(Server.MapPath("CrystalReport_Certificat.rpt"));
            crp.SetDataSource(ds.Tables["table"]);

            CrystalReportViewer1.ReportSource = crp;

            crp.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Certificats");
        }
    }
}