///WEB APP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
///SQL SERVEUR
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
///MORE
using System.Text;


namespace WebApplication1
{
    public partial class _Default : Page
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

        }
    }
}