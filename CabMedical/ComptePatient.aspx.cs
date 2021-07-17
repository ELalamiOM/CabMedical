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
    
    public partial class ComptePatient : System.Web.UI.Page
    {
        ADO d = new ADO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
           
            if(!Page.IsPostBack)
            {
                RemplirGrid();
            }
        }
        public void RemplirGrid()
        {
            string sql = "select * from Patients";
            d.connecter();
            if (d.dt.Rows != null)
            {
                d.dt.Clear();
            }
            d.cmd.CommandText = sql;
            d.cmd.Connection = d.con;
            d.dr = d.cmd.ExecuteReader();
            d.dt.Load(d.dr);
            GridView_Patient.DataSource = d.dt;
            GridView_Patient.DataBind();
            d.dr.Close();
            d.Deconnecter();
        }
        protected void Button_Ajouter_Patient_Click(object sender, EventArgs e)
        {
            d.connecter();
            d.cmd.CommandText = "insert into Patients(Nom_Prénom_Patient, Adresse , Sexe , SituationFamiliale , DateNaissance_Patient , LieuNaissance_Patient , Telephone  , Email) values('" + TextBox_Nom_Prenom_Patient.Text + "', '" + TextBox_Adresse_Patient.Text + "', '" + DropDownList_Sexe_Patient.SelectedValue + "', '" + DropDownList_SituationFamiliale.SelectedValue + "','" + TextBox_DateNaissance.Text + "', '" + TextBox_Lieu_Naissance.Text + "', '" + TextBox_Tel_Patient.Text + "' , '" + TextBox_Email_Patient.Text + "')";
            d.cmd.Connection = d.con;
            d.cmd.ExecuteNonQuery();
            RemplirGrid();
            d.Deconnecter();
            TextBox_Adresse_Patient.Text = TextBox_Email_Patient.Text = TextBox_Lieu_Naissance.Text =  TextBox_Nom_Prenom_Patient.Text = TextBox_Tel_Patient.Text = "";

            Response.Write("<script>alert('l'ajout de patient bien fait');window.location = 'Patient.aspx';</script>");
        }

        protected void GridView_Patient_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int a = e.RowIndex;
            int code = int.Parse(GridView_Patient.Rows[a].Cells[2].Text);
            d.connecter();
            d.cmd.CommandText = "delete from Patients where Num_Patient = '" + code + "' ";
            d.cmd.Connection = d.con;
            d.cmd.ExecuteNonQuery();
            RemplirGrid();
            d.Deconnecter();
        }

        protected void GridView_Patient_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int r = e.NewSelectedIndex;
            Session["CodePatient"] = GridView_Patient.Rows[r].Cells[2].Text;
            TextBox_Code_Patient.Text = GridView_Patient.Rows[r].Cells[2].Text;
            TextBox_Nom_Prenom_Patient.Text = GridView_Patient.Rows[r].Cells[3].Text;
            TextBox_Lieu_Naissance.Text = GridView_Patient.Rows[r].Cells[4].Text;
            TextBox_Adresse_Patient.Text = GridView_Patient.Rows[r].Cells[5].Text;
            DropDownList_Sexe_Patient.Text = GridView_Patient.Rows[r].Cells[6].Text;
            TextBox_Tel_Patient.Text = GridView_Patient.Rows[r].Cells[7].Text;
            TextBox_Email_Patient.Text = GridView_Patient.Rows[r].Cells[8].Text;
            DropDownList_SituationFamiliale.Text = GridView_Patient.Rows[r].Cells[9].Text;
            TextBox_DateNaissance.Text = GridView_Patient.Rows[r].Cells[10].Text;

        }

        protected void Button_Modifier_Patient_Click(object sender, EventArgs e)
        {
            //string req =
            //    " update Patients set Nom_Prénom_Patient = '"+TextBox_Nom_Prenom_Patient.Text+"' where Num_Patient = '"+TextBox_Code_Patient.Text+"' ";
            //d.connecter();
            //d.cmd.CommandText = req;
            //d.cmd.Connection = d.con;
            //d.cmd.ExecuteNonQuery();
            //RemplirGrid();
            //d.Deconnecter();

            //RemplirGrid();
            //Response.Write("<script>alert('Update');window.location = 'ComptePatient.aspx';</script>");

            //string con = "Data Source=DESKTOP-GPDIAMB\\SQLEXPRESS;Initial Catalog=MyCabMedDB2;Integrated Security=True";
            //string req = "select Nom_Prénom_Patient , Num_Patient from Patients";
            //daPat = new SqlDataAdapter(req, con);
            //daPat.Fill(dsPat, "Patients");
            //DropDownList_Patient.DataTextField = "Nom_Prénom_Patient";
            //DropDownList_Patient.DataValueField = "Num_Patient";
            //DropDownList_Patient.DataSource = dsPat.Tables["Patients"];
            //DropDownList_Patient.DataBind();
            
            string code = TextBox_Code_Patient.Text;
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-HT16NSJ\\SQLEXPRESS;Initial Catalog=MyCabMedDB2;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(" update Patients set Nom_Prénom_Patient = @Nom where Num_Patient = '"+Session["CodePatient"] +"' ", con);
            cmd.Parameters.Add(new SqlParameter("@Nom", TextBox_Nom_Prenom_Patient.Text));
            //cmd.Parameters.Add(new SqlParameter("@Code", int.Parse(TextBox_Code_Patient.Text)));
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            RemplirGrid();
            Response.Write("<script>alert('Update');window.location = 'ComptePatient.aspx';</script>");


        }

        protected void GridView_Patient_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //GridView_Patient.EditIndex = e.NewEditIndex;
        }

        protected void GridView_Patient_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //GridView_Patient.EditIndex = -1;
        }

        protected void GridView_Patient_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //TextBox t2 = (TextBox)GridView_Patient.Rows[e.RowIndex].Cells[2].Controls[0];
            //TextBox t3 = (TextBox)GridView_Patient.Rows[e.RowIndex].Cells[3].Controls[0];

            //SqlCommand cmd =
            //    new SqlCommand("update Patients set Nom_Prénom_Patient = @Nom where Num_Patient = @Code ",d.con);

            //cmd.Parameters.Add(new SqlParameter("@Nom", TextBox_Nom_Prenom_Patient.Text));
            //cmd.Parameters.Add(new SqlParameter("@Code", TextBox_Code_Patient.Text));

            //d.con.Open();
            //cmd.ExecuteNonQuery();
            //d.con.Close();
        }
    }
}