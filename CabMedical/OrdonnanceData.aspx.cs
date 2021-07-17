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
    public partial class OrdonnanceData : System.Web.UI.Page
    {

        ADO d = new ADO();
        public void RemplirGrid()
        {
            d.connecter();
            if (d.dt.Rows != null)
            {
                d.dt.Clear();
            }
            d.cmd.CommandText = "select Ordonnances.Num_Ordonnance,  Date_Ordonnance , Ville_Ordonnances , Description_Ordonnances ,medecin ,  Nom_Prénom_Patient ,consultation from Ordonnances join Patients on Patients.Num_Patient = Ordonnances.patient";
            d.cmd.Connection = d.con;
            d.dr = d.cmd.ExecuteReader();
            d.dt.Load(d.dr);
            GridView_Ordonnance.DataSource = d.dt;
            GridView_Ordonnance.DataBind();
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

            TextBox_Date_Ordonnance.Enabled = false;
            TextBox_Ville.Enabled = false;
            TextBox1_Description.Enabled = false;
            TextBox_Medecin.Enabled = false;
            DropDownList_Patient.Enabled = false;
            TextBox_Consultation.Enabled = false;
        }

        protected void Btn_Modifier_Click(object sender, EventArgs e)
        {
            d.connecter();
            d.cmd.CommandText = " update Ordonnances set Ville_Ordonnances = '"+TextBox_Ville.Text+"' , Description_Ordonnances = '"+TextBox1_Description.Text+"' where Num_Ordonnance = '"+Textox_Numero_Ordonnance.Text+"' ";
            d.cmd.Connection = d.con;
            d.cmd.ExecuteNonQuery();
            RemplirGrid();
            d.Deconnecter();
            Response.Write("<script>alert('Update');window.location = 'OrdonnanceData.aspx';</script>");
        }

        protected void GridView_Ordonnance_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int a  = e.RowIndex;
            int code = int.Parse(GridView_Ordonnance.Rows[a].Cells[2].Text);
            d.connecter();
            d.cmd.CommandText = " delete from Ordonnances where Num_Ordonnance = '"+code+"'";
            d.cmd.Connection = d.con;
            d.cmd.ExecuteNonQuery();
            RemplirGrid();
            d.Deconnecter();
        }

        protected void GridView_Ordonnance_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int r = e.NewSelectedIndex;
            Textox_Numero_Ordonnance.Text = GridView_Ordonnance.Rows[r].Cells[2].Text;
            TextBox_Date_Ordonnance.Text = GridView_Ordonnance.Rows[r].Cells[3].Text;
            TextBox_Ville.Text = GridView_Ordonnance.Rows[r].Cells[4].Text;
            TextBox1_Description.Text = GridView_Ordonnance.Rows[r].Cells[5].Text;
            TextBox_Medecin.Text = GridView_Ordonnance.Rows[r].Cells[6].Text;
            //DropDownList_Patient.SelectedValue = GridView_Ordonnance.Rows[r].Cells[7].Text;
            TextBox_Consultation.Text = GridView_Ordonnance.Rows[r].Cells[8].Text;

            //TextBox_Date_Ordonnance.Enabled = true;
            TextBox_Ville.Enabled = true;
            TextBox1_Description.Enabled = true;

        }

        protected void Button_Actualiser_Click(object sender, EventArgs e)
        {
            RemplirGrid();
        }

        protected void Button_Imprimer_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-GPDIAMB\\SQLEXPRESS;Initial Catalog=MyCabMedDB2;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Select * from Ordonnances  where Num_Ordonnance = '" + TextBox_Num_Ordonnance.Text + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            ReportDocument crp = new ReportDocument();
            crp.Load(Server.MapPath("CrystalReport_Ordonnance.rpt"));
            crp.SetDataSource(ds.Tables["table"]);

            CrystalReportViewer1.ReportSource = crp;

            crp.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Ordonnances");
        }
    }
}