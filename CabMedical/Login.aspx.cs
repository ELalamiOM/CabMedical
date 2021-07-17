using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace CabMedical
{
    public partial class Login : System.Web.UI.Page
    {
        ADO D = new ADO();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public int Sec()
        {
            D.connecter();
            int Sec;
            D.cmd.CommandText = "SELECT count(Num_Secretaire)  FROM Secretaires WHERE LoginSec  LIKE 'Sec%'";
            D.cmd.Connection = D.con;
            Sec = (int)D.cmd.ExecuteScalar();
            D.Deconnecter();
            return Sec;
        }
        public int Med()
        {
            D.connecter();
            int Med;
            D.cmd.CommandText = "SELECT count(Num_Medecin)  FROM Medecins WHERE LoginMed  LIKE 'Med%'";
            D.cmd.Connection = D.con;
            Med = (int)D.cmd.ExecuteScalar();
            D.Deconnecter();
            return Med;
        }

        protected void Button_Login_Click(object sender, EventArgs e)
        {
            if (Med() > 0)
            {
                try
                {
                    string req = string.Format("Select * from Medecins where LoginMed = '{0}' and MDPMed = '{1}' ", TextBox_Login.Text, TextBox_MDP.Text);
                    SqlCommand cmd = new SqlCommand(req, D.con);
                    D.connecter();
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        Session["User"] = rd[1].ToString();
                        D.Deconnecter();
                        Response.Redirect("AccueilMedecin.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Check your Login and PassWord');window.location = 'Login.aspx';</script>");
                        D.Deconnecter();
                    }
                }
                catch (Exception)
                {
                    Response.Write("<script>alert('Check PassWord');window.location = 'Login.aspx';</script>");
                }
            }
            if (Sec() > 0)
            {
                try
                {
                    string req = string.Format("Select * from Secretaires where LoginSec = '{0}' and MDPSec = '{1}' ", TextBox_Login.Text, TextBox_MDP.Text);
                    SqlCommand cmd = new SqlCommand(req, D.con);
                    D.connecter();
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        Session["User"] = rd[1].ToString();
                        D.Deconnecter();
                        Response.Redirect("AccueilSecretaire.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Check your Login and PassWord');window.location = 'Login.aspx';</script>");
                        D.Deconnecter();
                    }
                }
                catch (Exception)
                {
                    Response.Write("<script>alert('Check PassWord');window.location = 'Login.aspx';</script>");
                }
            }

        }
    }
}