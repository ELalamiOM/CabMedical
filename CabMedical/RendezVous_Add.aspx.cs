using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace CabMedical
{
    public partial class RendezVous_Add : System.Web.UI.Page
    {
        ADO d = new ADO();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            d.connecter();
            d.cmd.CommandText =
               "insert into " +
               "AddRendezVousParPatient(DataRendez , Nom_Prénom_Utilisateur , Age , Telephone , email) " +
               "values('" + Cale_RendezVousUser.Text + "','" + TextBox_Nom_Prenom_User.Text + "'," + TextBox_AgeUser.Text + " , '"+TextBox_Telephone_User.Text+"' , '"+TextBox_Email_User.Text+"')";

            d.cmd.Connection = d.con;
            d.cmd.ExecuteNonQuery();
            d.Deconnecter();

            TextBox_AgeUser.Text = TextBox_AgeUser.Text = TextBox_Nom_Prenom_User.Text = TextBox_Email_User.Text = TextBox_Telephone_User.Text = "";

            Response.Write("<script>alert('Merci, nous vous contacterons pour confirmer le rendez-vous');window.location = 'Default.aspx';</script>");
        }
    }
}