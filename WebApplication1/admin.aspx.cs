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
    public partial class admin : Page
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
        Class1 admine = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed5_Click(object sender, EventArgs e)
        {
            /* Class1.name_entreprise = nomE.Text;
             Class1.dat = date_creation.Text;
             Class1.nbre_poste = int.Parse(nbre_poste.Text);
             Class1.coef = int.Parse(coef.Text);
             Class1.nbre_employe = int.Parse(nbre_employe.Text);
             //nbre_employe.Text = Class1.nbre_employe.ToString(); // Correction : il faut utiliser Class1.nbre_employe pour assigner la valeur correcte

             int nbreLignes = int.Parse(nbre_poste.Text);*/

            bool check = true;

            if (nomE.Text == "")
            {
                label_nom_entreprise.BackColor = System.Drawing.Color.Pink;
                label_nom_entreprise.Text = "Vous devez entrer un nom ! ";
                check = false;
            }
            else
            {
                label_nom_entreprise.BackColor = System.Drawing.Color.Transparent;
                label_nom_entreprise.Text = "";
            }

            DateTime DATE;
            if (DateTime.TryParse(date_creation.Text, out DATE))
            {
                if (DATE < DateTime.Now)
                {
                    label_creation.BackColor = System.Drawing.Color.Transparent;
                    label_creation.Text = "";
                }
                else
                {
                    label_creation.BackColor = System.Drawing.Color.Pink;
                    label_creation.Text = "Cette date ne peux pas etre acceptée ! ";
                    check = false;
                }
            }
            else
            {
                label_creation.BackColor = System.Drawing.Color.Pink;
                label_creation.Text = "Vous devez entrer une date valide ! ";
                check = false;
            }
            Class1.dat = date_creation.Text;

            int NBE;
            if (int.TryParse(nbre_employe.Text, out NBE))
            {
                if (NBE > 0)
                {
                    label_nbre_employe.BackColor = System.Drawing.Color.Transparent;
                    label_nbre_employe.Text = "";
                }
                else
                {
                    label_nbre_employe.BackColor = System.Drawing.Color.Pink;
                    label_nbre_employe.Text = "Entrez un entier positif non nul ! ";
                    check = false;
                }
            }
            else
            {
                label_nbre_employe.BackColor = System.Drawing.Color.Pink;
                label_nbre_employe.Text = "Entrez un entier ! ";
                check = false;
            }
            Class1.nbre_employe = NBE;

            double NBX;
            if (double.TryParse(coef.Text, out NBX))
            {
                if (NBX > 0)
                {
                    label_coeficient.BackColor = System.Drawing.Color.Transparent;
                    label_coeficient.Text = "";
                }
                else
                {
                    label_coeficient.BackColor = System.Drawing.Color.Pink;
                    label_coeficient.Text = "Entrez un réel positif non nul ! ";
                    check = false;
                }
            }
            else
            {
                label_coeficient.BackColor = System.Drawing.Color.Pink;
                label_coeficient.Text = "Entrez un réel ! ";
                check = false;
            }

            if (check)
            {
                IDbConnection connection = null;
                string SQLquery = "";
                connection = connectDB(@"DESKTOP-K341PHB", "new_bd");
                if (connection == null)
                {
                    label_valider.BackColor = System.Drawing.Color.Pink;
                    label_valider.Text = "Une erreur s'est produite : Connexion impossible !";
                }
                else
                {

                    SQLquery = execNotSQLQuery(connection, "INSERT INTO EntrepriseSet (nom_E, Date_creation, capacite, coef) VALUES ('" + nomE.Text + "','" + DATE.Date + "'," + NBE + " ," + NBX + " )");
                    if (SQLquery == "")
                    {
                        label_valider.Text = "";

                        Class1.name_entreprise = nomE.Text;
                        // mettre un lien de redireciton ver un page de confirmation
                    }
                    else
                    {
                        label_valider.BackColor = System.Drawing.Color.Pink;
                        label_valider.Text = "Une erreur s'est produite : " + SQLquery;
                    }

                    Response.Redirect("user.aspx");
                }
            }

            Class1.tableau_salaires = new string[NBE];

            for (int i = 0; i < NBE; i++)
            {
                Class1.tableau_salaires[i] = "";
            }

            Class1.tableau_postes = new string[NBE];

            for (int i = 0; i < NBE; i++)
            {
                Class1.tableau_postes[i] = "";
            }


            for (int j = 0; j < NBE; j++)
            {
                TextBox poste = (TextBox)divTableau.FindControl("poste_" + j);
                if (poste != null)
                {
                    Class1.tableau_postes[j] = poste.Text;
                }

                TextBox salaire = (TextBox)divTableau.FindControl("salaire_" + j);
                if (salaire != null)
                {
                    Class1.tableau_salaires[j] = salaire.Text;
                }

                poste_salaire.Text += "Poste : " + Class1.tableau_postes[j] + ", Salaire : " + Class1.tableau_salaires[j] + "<br/>";
            }
            //TextBox p = Class1.poste_Id[0];
            // string pe = p.ID;
            // date_creation.Text = p.Text;
            // nomE.Text = Class1.poste_Id[0].Text;




            // Response.Redirect("user.aspx");

        }



        protected void result_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {

            /*int nbreLignes = int.Parse(nbre_poste.Text);
            if (nbreLignes > 0)
            {

                Table table = new Table();

                // Création de la ligne d'en-tête
                TableHeaderRow headerRow = new TableHeaderRow();

                // Création de la cellule pour le titre "poste"
                TableHeaderCell posteHeaderCell = new TableHeaderCell();
                posteHeaderCell.Text = "poste";
                posteHeaderCell.ForeColor = System.Drawing.Color.Red; // Définition de la couleur rouge
                headerRow.Cells.Add(posteHeaderCell);

                // Création de la cellule pour le titre "salaire"
                TableHeaderCell salaireHeaderCell = new TableHeaderCell();
                salaireHeaderCell.Text = "salaire";
                salaireHeaderCell.ForeColor = System.Drawing.Color.Red; // Définition de la couleur rouge
                headerRow.Cells.Add(salaireHeaderCell);

                table.Rows.Add(headerRow);
                    Class1.poste_Id = new TextBox[nbreLignes];
                    Class1.salaire_Id = new TextBox[nbreLignes];

                for (int i = 0; i < nbreLignes; i++)
                {
                    TableRow row = new TableRow();

                    TableCell posteCell = new TableCell();
                    TextBox posteTextBox = new TextBox();
                    posteTextBox.ID = "poste_" + i;
                    Class1.poste_Id[i] = posteTextBox;

                    posteCell.Controls.Add(posteTextBox);
                    row.Cells.Add(posteCell);  //ajout du contenu dans la cellule

                    TableCell salaireCell = new TableCell();
                    TextBox salaireTextBox = new TextBox();
                    salaireTextBox.ID = "salaire_" + i;
                    Class1.salaire_Id[i] = salaireTextBox;
                    salaireCell.Controls.Add(salaireTextBox);
                    row.Cells.Add(salaireCell);

                    table.Rows.Add(row);
                }


                divTableau.Controls.Add(table);

            }
            */
        }
        protected void date_creation_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {


            IDbConnection connection = null;
            string SQLquery = "";
            connection = connectDB(@"DESKTOP-K341PHB", "new_bd");
            if (connection == null)
            {
                label_valider.BackColor = System.Drawing.Color.Pink;
                label_valider.Text = "Une erreur s'est produite : Connexion impossible !";
            }
            else
            {

                SQLquery = execNotSQLQuery(connection, "INSERT INTO posteSet (type_poste, salaire) VALUES ('" + Type_poste.Text + "','" + salaire.Text + "' )");


                /*for(int x = 0; x < post; x++)
                    SQLquery = execNotSQLQuery(connection, "INSERT INTO posteSet (type_poste, salaire) VALUES ('" + poste.Text + "','" + Class1.tableau_salaires[x] + "' )");
               */
                if (SQLquery == "")
                {
                    label_valider.Text = "";

                    Class1.name_entreprise = nomE.Text;
                    // mettre un lien de redireciton ver un page de confirmation
                }
                else
                {
                    label_valider.BackColor = System.Drawing.Color.Pink;
                    label_valider.Text = "Une erreur s'est produite : " + SQLquery;
                }
            }
        }
    }
}