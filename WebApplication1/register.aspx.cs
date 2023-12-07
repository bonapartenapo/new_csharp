using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.DynamicData;

namespace WebApplication1
{
    public partial class register : Page
    {

        public IDbConnection connectDB(string SERVEUR, string DATABASE)
        {
            IDbConnection connexion = null;
            try
            {
                connexion = new SqlConnection(@"Data Source=" + SERVEUR + ";Initial Catalog=" + DATABASE + ";Integrated Security=True;Pooling=False;");
                connexion.Open();
            }
            catch
            {
                return null;
            }
            return connexion;
        }
        public string execNotSQLQuery(IDbConnection connexion, string QUERY)
        {
            try
            {
                IDbCommand commandSQL = connexion.CreateCommand();
                commandSQL.CommandText = QUERY;
                commandSQL.CommandType = CommandType.Text;
                commandSQL.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return e.Message;
            }
            return "";
        }
        public IDataReader execSQLQuery(IDbConnection connexion, string QUERY)
        {
            IDataReader lire = null;
            try
            {
                IDbCommand commandSQL = connexion.CreateCommand();
                commandSQL.CommandText = QUERY;
                commandSQL.CommandType = CommandType.Text;
                lire = commandSQL.ExecuteReader();
            }
            catch
            {
                return null;
            }
            return lire;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindGridView();
            }

        }
        protected void BindGridView()
        {
            /*int nbre = int.Parse(poste.Text);
            GridView1.DataSource = GetFilteredData(nbre);
            GridView1.DataBind();*/
        }

        protected void nom_entreprise_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            BindGridView();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            bool check = true;
            
            if (nom.Text =="")
            {
                err_nom.BackColor = System.Drawing.Color.Pink;
                err_nom.Text = "Erreur: veuillez entrer votre nom";
                check= false;
            }else
            {
                err_nom.BackColor = System.Drawing.Color.Pink;
                err_nom.Text = "";
            }

            if (prenom.Text == "")
            {
                err_prenom.BackColor = System.Drawing.Color.Pink;
                err_prenom.Text = "Erreur: veuillez entrer votre nom";
                check = false;
            }
            else
            {
                err_nom.BackColor = System.Drawing.Color.Pink;
                err_nom.Text = " ";
            }

            if (email.Text == "")
            {
                err_email.BackColor = System.Drawing.Color.Pink;
                err_email.Text = "Erreur: Veuillez entrer votre Email ";
                check = false;
            }
            else
            {
                err_email.BackColor = System.Drawing.Color.Pink;
                err_email.Text = "";
            }



            if (mdp.Text =="")
            {
                err_mdp.BackColor = System.Drawing.Color.Pink;
                err_mdp.Text = "Erreur: Veuillez entrer votre mot de passe ";
                check = false;
            }
            else
            {
                err_mdp.BackColor = System.Drawing.Color.Pink;
                err_mdp.Text = "";
            }


            if(check) 
            {
                IDbConnection connection = null;
                string Sql = "";
                connection = connectDB(@"DESKTOP-K341PHB", "new_bd");
                if(connection == null)
                {
                    err_sql.BackColor = System.Drawing.Color.Pink;
                    err_sql.Text = "Connection impossible";
                }else
                {
                    Sql = execNotSQLQuery(connection, "INSERT INTO utilisateurSet (nom,prenom,email,mdp) VALUES('" + nom.Text + "','" + prenom.Text + "','" + email.Text + "','" + mdp.Text + "')");
               
                    if(Sql != "")
                    {
                        err_sql.BackColor = System.Drawing.Color.Pink;
                        err_sql.Text = "Une erreur s'est produite" + Sql;
                    }
                }
                //Response.Redirect("login.aspx"); 

            }

        }
    }
}