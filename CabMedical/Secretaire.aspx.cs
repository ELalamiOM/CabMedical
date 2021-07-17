using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CabMedical
{
    public partial class Secretaire : System.Web.UI.Page
    {
        ADO d = new ADO();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_Ajouter_Click(object sender, EventArgs e)
        {
            d.connecter();
            d.cmd.CommandText =
"insert into Secretaires(Nom_Secretaire , Prenom_Secretaire , LoginSec , MDPSec ) values('"+TextBox_Nom.Text+"', '"+TextBox_Prenom.Text+"', '"+TextBox_Login.Text+"', '"+TextBox_Passe.Text+"')";
            d.cmd.Connection = d.con;
            d.cmd.ExecuteNonQuery();
            d.Deconnecter();

            TextBox_Nom.Text = TextBox_Prenom.Text = TextBox_Login.Text = TextBox_Passe.Text = "";
            Response.Write("<script>alert('Merci, nous vous contacterons pour confirmer le rendez-vous');window.location = 'RendezVous_Add.aspx';</script>");
        }
    }
}