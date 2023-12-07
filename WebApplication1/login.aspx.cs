using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace WebApplication1
{
    public partial class login : Page
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

            your_name.Value = "";
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

            if (your_name.Value == "")
            {
                error_N.BackColor = System.Drawing.Color.Pink;
                error_N.Text = "Erreur: veuillez entrer votre nom";
                check = false;
            }
            else
            {
                error_N.BackColor = System.Drawing.Color.Pink;
                error_N.Text = "";
            }

            if (your_pass.Value == "")
            {
                
                error_P.Text = "Erreur: veuillez entrer votre mot de passe";
                check = false;
            }
            else
            {
                error_P.BackColor = System.Drawing.Color.Pink;
                error_P.Text = "";
            }


            if(check)
            {
                IDbConnection connection = null;
                string sql = "";
                connection = connectDB(@"DESKTOP-K341PHB", "new_bd");

                if (connection == null)
                {
                    error.BackColor = System.Drawing.Color.Pink;
                    error.Text = "Connection impossible";
                }
                else
                {
                    IDataReader SqlQuery = execSQLQuery(connectDB(@"DESKTOP-K341PHB", "new_bd"), "SELECT * utilisateurSet");
                    string name ="";
                    string mdp ="";
                    while (SqlQuery.Read())
                    {
                        name = SqlQuery.GetString(1);
                        mdp = SqlQuery.GetString(4);
                    }
                    if(name == "" && mdp == "")
                    {
                        error.BackColor = System.Drawing.Color.Red;
                        error.Text = "Erreur" + SqlQuery;
                    }
                    else if(name == your_name.Value && mdp == your_pass.Value)
                    {
                        Response.Redirect("default.aspx");
                    }else
                    {
                        error.BackColor = System.Drawing.Color.Red;
                        error.Text = "informations incorecte";
                    }
                }
            }
        }
    }
}