using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class affichage : Page
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
            IDbConnection connection = null;
            string SQLquery = "";
            connection = connectDB(@"DESKTOP-K341PHB", "new_bd");
            IDataReader SQLquerySELECT = execSQLQuery(connectDB(@"DESKTOP-K341PHB", "new_bd"), "SELECT * FROM employeSet");
            int i = 0;
            htmlTable.Text = "";
            while (SQLquerySELECT.Read())
            {
                htmlTable.Text += "<tr>";
/**/
                
                htmlTable.Text += "<td>"+ SQLquerySELECT.GetString(6) +"</td>";
                htmlTable.Text += "<td>" +SQLquerySELECT.GetString(1) + "</td>";
                htmlTable.Text += "<td>"+ SQLquerySELECT.GetString(3) + "</td>";
                htmlTable.Text += "<td>"+ SQLquerySELECT.GetInt32(0) + "</td>";
                htmlTable.Text += "<td>"+ SQLquerySELECT.GetString(4) + "</td>";
                htmlTable.Text += "<td>"+ SQLquerySELECT.GetString(5) + "</td>";

                //IDataReader  permet de recuperer le resulat d'une requete select
                IDataReader SQLquerySELECT2 = execSQLQuery(connectDB(@"DESKTOP-K341PHB", "new_bd"), "SELECT salaire FROM posteSet WHERE type_poste='"+ SQLquerySELECT.GetString(5) + "'");
                SQLquerySELECT2.Read();
                htmlTable.Text += "<td>"+ SQLquerySELECT2.GetString(0) + "</td>";

                htmlTable.Text += "</tr>";
                i++;
            }
            if (i == 0)
            {
                sqlErr.Text = "reponse vide";
            }
            else
            {
                sqlErr.Text = i +"" ;
            }
/**/
        }

        protected void Unnamed5_Click(object sender, EventArgs e)
        {


        }


        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void result_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {


        }

        protected void date_creation_TextChanged(object sender, EventArgs e)
        {

        }
    }
}