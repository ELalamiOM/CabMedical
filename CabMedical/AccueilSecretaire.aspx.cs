using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace CabMedical
{
    public partial class AccueilSecretaire : System.Web.UI.Page
    {
        ADO d = new ADO();
        public void RemplirGrid()
        {
            d.connecter();
            if (d.dt.Rows != null)
            {
                d.dt.Clear();
            }
            d.cmd.CommandText = "SELECT Num_RendezVous, DataRendez , Nom_Prénom_Utilisateur  , Age, Telephone, email from AddRendezVousParPatient";
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
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!Page.IsPostBack)
            {
                RemplirGrid();
            }

            tbExpéditeur.Text = "testtestdeprj123@gmail.com";
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            try {
                MailMessage message = new MailMessage(tbExpéditeur.Text, tbDestinataire.Text, tb_Object.Text, tb_Message.Text);
                message.IsBodyHtml = true;

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential("testtestdeprj123@gmail.com", "Fst@20202021");
                client.Send(message);

                lblErreur.Text = "bien fait";
            }
            catch(Exception ex)
            {
                lblErreur.Text = ex.Message;
            }
        }

        protected void GridView_RendezVousAddParUser_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int a = e.RowIndex;
            int code = int.Parse(GridView_RendezVousAddParUser.Rows[a].Cells[1].Text);
            d.connecter();
            d.cmd.CommandText = " delete from AddRendezVousParPatient where Num_RendezVous = '"+ code + "'";
            d.cmd.Connection = d.con;
            d.cmd.ExecuteNonQuery();
            RemplirGrid();
            d.Deconnecter();
        }
    }
}