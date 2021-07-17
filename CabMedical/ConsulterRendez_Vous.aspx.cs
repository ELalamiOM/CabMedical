using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;


namespace CabMedical
{
    public partial class ConsulterRendez_Vous : System.Web.UI.Page
    {
        ADO d = new ADO();
        public void RemplirGrid()
        {
            d.connecter();
            if (d.dt.Rows != null)
            {
                d.dt.Clear();
            }
            d.cmd.CommandText = "SELECT DataRendez , Nom_Utilisateur , Prenom_Utilisateur , Age, Telephone, email from AddRendezVousParPatient";
            d.cmd.Connection = d.con;
            d.dr = d.cmd.ExecuteReader();
            d.dt.Load(d.dr);
            GridView_RendezVousAddParUser.DataSource = d.dt;
            GridView_RendezVousAddParUser.DataBind();
            d.dr.Close();
            d.Deconnecter();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                RemplirGrid();
            }
        }

        
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage msg = new MailMessage();
                msg.To.Add(tbDestinataire.Text);
                msg.From = new MailAddress("testernumeroun@gmail.com");
                msg.Subject = "subject";
                msg.Body = tb_Message.Text;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "relay-hostin.secureserver.net";
                smtp.Port = 25;
                smtp.Credentials = new System.Net.NetworkCredential("testernumeroun@gmail.com", "casa0664804487");
                smtp.Send(msg);
                lblErreur.Text = "Successfully";
            }
            catch(Exception ex)
            {
                lblErreur.Text = ex.Message;
            }
        }
    }
}