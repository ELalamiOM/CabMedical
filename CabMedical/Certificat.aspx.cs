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
    public partial class Certificat : System.Web.UI.Page
    {
        ADO d = new ADO();
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
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                RemplirDrop_Patient();
            }
            TextBox_Medecin.Text = Session["User"].ToString();
        }

        protected void Button_Ajouter_Click(object sender, EventArgs e)
        {
            d.connecter();
            d.cmd.CommandText = " Insert into Certificats(Date_Certificat , Ville_Certificat , Discription_Certificat , medecin , patient ) values('" + TextBox_Date.Text + "', '" + TextBox_Ville.Text + "', '" + TextBox_Description.Text + "', '" + TextBox_Medecin.Text + "','" + DropDownList_Patient.Text + "') ";
            d.cmd.Connection = d.con;
            d.cmd.ExecuteNonQuery();
            d.Deconnecter();
            Response.Write("<script>alert('Add');window.location = 'Certificat.aspx';</script>");
        }

        protected void Button_View_Click(object sender, EventArgs e)
        {       
            Response.Redirect("CertificatData.aspx");
        }

        protected void Button_View_Click1(object sender, EventArgs e)
        {
            Response.Redirect("CertificatData.aspx");
        }
    }
}