using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace CabMedical
{
    public partial class RendezVous_Secretaire : System.Web.UI.Page
    {
        ADO d = new ADO();
        DataSet dsMed = new DataSet();
        SqlDataAdapter daMed;

        DataSet dsSec = new DataSet();
        SqlDataAdapter daSec;
        public void RemplirDrop_Med()
        {
            string con = "Data Source=DESKTOP-HT16NSJ\\SQLEXPRESS;Initial Catalog=MyCabMedDB2;Integrated Security=True";
            string req = "select Nom_Prénom_Medecin , Num_Medecin from Medecins";
            daMed = new SqlDataAdapter(req, con);
            daMed.Fill(dsMed, "Medecins");
            DropDownList_Med.DataTextField = "Nom_Prénom_Medecin";
            DropDownList_Med.DataValueField = "Num_Medecin";
            DropDownList_Med.DataSource = dsMed.Tables["Medecins"];
            DropDownList_Med.DataBind();
        }
       

        public void RemplirDrop_Patient()
        {
            string con = "Data Source=DESKTOP-HT16NSJ\\SQLEXPRESS;Initial Catalog=MyCabMedDB2;Integrated Security=True";
            string req = "select Nom_Prénom_Utilisateur , Num_RendezVous from AddRendezVousParPatient";
            daSec = new SqlDataAdapter(req, con);
            daSec.Fill(dsSec, "AddRendezVousParPatient");
            DropDownList_Nom_Prenom.DataTextField = "Nom_Prénom_Utilisateur";
            DropDownList_Nom_Prenom.DataValueField = "Num_RendezVous";
            DropDownList_Nom_Prenom.DataSource = dsSec.Tables["AddRendezVousParPatient"];
            DropDownList_Nom_Prenom.DataBind();
        }

        public void RemplirGrid()
        {
            string sql = "select RendezVousS.Num_RendezVous, Date_RendezVous , Heure_RendezVous , Nom_Prénom_Medecin  , Nom_Prénom_Utilisateur from RendezVousS JOIN Medecins ON Medecins.Num_Medecin = RendezVousS.medecin join AddRendezVousParPatient on AddRendezVousParPatient.Num_RendezVous = RendezVousS.patient";
            d.connecter();
            if (d.dt.Rows != null)
            {
                d.dt.Clear();
            }
            d.cmd.CommandText = sql;
            d.cmd.Connection = d.con;
            d.dr = d.cmd.ExecuteReader();
            d.dt.Load(d.dr);
            GridView_RendezVous.DataSource = d.dt;
            GridView_RendezVous.DataBind();
            d.dr.Close();
            d.Deconnecter();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {            
                RemplirDrop_Med();                
                RemplirDrop_Patient();
                RemplirGrid();
            }

            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            TextBox_Sec.Text = Session["User"].ToString();

            
        }

        protected void Button_Ajouter_Click(object sender, EventArgs e)
        {
            d.connecter();
            d.cmd.CommandText = "insert into RendezVousS(medecin , patient , secretaire ,  Date_RendezVous , Heure_RendezVous)" +
                "values('" + DropDownList_Med.SelectedValue + "', '" + DropDownList_Nom_Prenom.SelectedValue + "','" + TextBox_Sec.Text + "' ,'" + TextBox_Date_Rendezvous.Text+"', '"+TextBox_Heure_Rendezvous.Text+"')";

            d.cmd.Connection = d.con;
            d.cmd.ExecuteNonQuery();
            d.Deconnecter();


            Response.Write("<script>alert('Merci, nous vous contacterons pour confirmer le rendez-vous');window.location = 'RendezVous_Secretaire.aspx';</script>");
        }

        protected void GridView_RendezVous_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView_RendezVous_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int a = e.RowIndex;
            int code = int.Parse(GridView_RendezVous.Rows[a].Cells[2].Text);
            d.connecter();
            d.cmd.CommandText = "delete from RendezVousS where Num_RendezVous = '" + code + "' ";
            d.cmd.Connection = d.con;
            d.cmd.ExecuteNonQuery();
            RemplirGrid();
            d.Deconnecter();
        }

        protected void GridView_RendezVous_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int a = e.NewSelectedIndex;
            TextBox_Code_RV.Text = GridView_RendezVous.Rows[a].Cells[2].Text;
            TextBox_Date_Rendezvous.Text = GridView_RendezVous.Rows[a].Cells[3].Text;
            TextBox_Heure_Rendezvous.Text = GridView_RendezVous.Rows[a].Cells[4].Text;
            DropDownList_Med.DataTextField = GridView_RendezVous.Rows[a].Cells[5].Text;
            DropDownList_Nom_Prenom.DataTextField = GridView_RendezVous.Rows[a].Cells[6].Text;
        }

        protected void Button_Modifier_Click(object sender, EventArgs e)
        { 
     
            string req = " update RendezVousS set Date_RendezVous = '"+TextBox_Date_Rendezvous.Text+"' , Heure_RendezVous = '"+TextBox_Heure_Rendezvous.Text+"' , medecin = '"+("select Num_Medecin from Medecins where Nom_Prénom_Medecin = '"+ "Saadi Ahmed" + "'")+"'  , patient = '"+(" select Num_RendezVous from AddRendezVousParPatient where Nom_Prénom_Utilisateur = '" +DropDownList_Med.SelectedValue.ToString()+ "' ") +"'   , secretaire ='"+TextBox_Sec.Text+"' where Num_RendezVous = '"+TextBox_Code_RV.Text+"' ";
            d.connecter();   
            d.cmd.CommandText = req;
            d.cmd.Connection = d.con;
            d.cmd.ExecuteNonQuery();
            RemplirGrid();
            d.Deconnecter();
            Response.Write("<script>alert('Update');window.location = 'RendezVous_Secretaire.aspx';</script>");

        }
    }
}