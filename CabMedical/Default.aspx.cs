using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CabMedical
{
    public partial class _Default : Page
    {
        ADO d = new ADO();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_Contact_Click(object sender, EventArgs e)
        {
            d.connecter();
            d.cmd.CommandText = "insert into Contact (Nom  , tel , email , messageC ) values ('"+TextBox_Nom.Text+"','"+TextBox_Tel.Text+"','"+TextBox_email.Text+"','"+tb_Message.Text+"')";
            d.cmd.Connection = d.con;
            d.cmd.ExecuteNonQuery();
            d.Deconnecter();

            TextBox_Tel.Text = TextBox_Nom.Text = TextBox_email.Text = tb_Message.Text = "";

            Response.Write("<script>alert('Merci');window.location = 'Default.aspx';</script>");
        }
    }
}