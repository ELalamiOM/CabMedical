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
    public partial class ConsultatioData : System.Web.UI.Page
    {
        ADO d = new ADO();
        public void RemplirGrid()
        {
            d.connecter();
            if (d.dt.Rows != null)
            {
                d.dt.Clear();
            }
            d.cmd.CommandText = "select Consultations.Num_Consultation,  Date_Consultation , Prix , Observation_Consultation ,medecin ,  Nom_Prénom_Patient from Consultations join Patients on Patients.Num_Patient = Consultations.patient";
            d.cmd.Connection = d.con;
            d.dr = d.cmd.ExecuteReader();
            d.dt.Load(d.dr);
            GridView_RendezVousAddParUser.DataSource = d.dt;
            GridView_RendezVousAddParUser.DataBind();
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


            TextBox_Date_Consulation.Enabled = false;
            TextBox_Prix.Enabled = false;
            TextBox1_Description.Enabled = false;
            DropDownList_Patient.Enabled = false;
            
        }

        protected void GridView_RendezVousAddParUser_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int a = e.RowIndex;
            int code = int.Parse(GridView_RendezVousAddParUser.Rows[a].Cells[2].Text);
            d.connecter();
            d.cmd.CommandText = " delete from Consultations where Num_Consultation= '"+code+"' ";
            d.cmd.Connection = d.con;
            d.cmd.ExecuteNonQuery();
            RemplirGrid();
            d.Deconnecter();
        }

        protected void GridView_RendezVousAddParUser_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int r = e.NewSelectedIndex;
            Textox_Numero_Consultation.Text = GridView_RendezVousAddParUser.Rows[r].Cells[2].Text;
            TextBox_Date_Consulation.Text = GridView_RendezVousAddParUser.Rows[r].Cells[3].Text;
            TextBox_Prix.Text = GridView_RendezVousAddParUser.Rows[r].Cells[4].Text;
            TextBox1_Description.Text = GridView_RendezVousAddParUser.Rows[r].Cells[5].Text;
            TextBox_Medecin.Text = GridView_RendezVousAddParUser.Rows[r].Cells[6].Text;
            //DropDownList_Patient.SelectedValue = GridView_RendezVousAddParUser.Rows[r].Cells[7].Text;

            TextBox_Date_Consulation.Enabled = true;
            TextBox_Prix.Enabled = true;
            TextBox1_Description.Enabled = true;
            DropDownList_Patient.Enabled = true;

        }

        protected void Btn_Modifier_Click(object sender, EventArgs e)
        {
            d.connecter();
            d.cmd.CommandText = " update Consultations set Date_Consultation = '"+TextBox_Date_Consulation.Text+"', Prix = '"+TextBox_Prix.Text+"', Observation_Consultation = '"+TextBox1_Description.Text+"', medecin = '"+TextBox_Medecin.Text+"', patient = '"+DropDownList_Patient.SelectedValue+"' where Num_Consultation = '"+Textox_Numero_Consultation.Text+"' ";
            d.cmd.Connection = d.con;
            d.cmd.ExecuteNonQuery();
            RemplirGrid();
            d.Deconnecter();
        }
    }
}