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
using System.Collections.ObjectModel;


namespace WebApplication1
{
    public partial class user : Page
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

            IDbConnection connection = null;
            string SQLquery = "";
            connection = connectDB(@"DESKTOP-K341PHB", "new_bd");
            if (connection == null)
            {
                user_error.BackColor = System.Drawing.Color.Pink;
                user_error.Text = "Une erreur s'est produite : Connexion impossible !";
            }
            else
            {
                if(Class1.nbre_employe  == 0)
                {
                    //redirection de l'utilisateur
                    Response.Redirect("admin.aspx");
                }
                else
                {

                    // Récupérer les informations de la société et le nombre d'employés
                    Company company = (Company)ViewState["Company"];
                    int numberOfEmployees = Class1.nbre_employe;
                    Table table = new Table();

                    // Création de la ligne d'en-tête
                    TableHeaderRow headerRow = new TableHeaderRow();
                    TableHeaderCell emplo = new TableHeaderCell();
                    emplo.Text = "EMPLOYE  ";
                    emplo.ForeColor = System.Drawing.Color.Red; // Définition de la couleur rouge
                    headerRow.Cells.Add(emplo);
                    // Création de la cellule pour le titre "nom"
                    TableHeaderCell nom = new TableHeaderCell();
                    nom.Text = "Nom";
                    nom.ForeColor = System.Drawing.Color.Red; // Définition de la couleur rouge
                    headerRow.Cells.Add(nom);

                    // Création de la cellule pour le titre "Prenom"
                    TableHeaderCell Prenom = new TableHeaderCell();
                    Prenom.Text = "Prenom";
                    Prenom.ForeColor = System.Drawing.Color.Red; // Définition de la couleur rouge
                    headerRow.Cells.Add(Prenom);

                    // Création de la cellule pour le titre "Sexe"
                    TableHeaderCell Sexe = new TableHeaderCell();
                    Sexe.Text = "Sexe";
                    Sexe.ForeColor = System.Drawing.Color.Red; // Définition de la couleur rouge
                    headerRow.Cells.Add(Sexe);

                    // Création de la cellule pour le titre "Date de recrutement"
                    TableHeaderCell Date_recrutement = new TableHeaderCell();
                    Date_recrutement.Text = "Date de recrutement";
                    Date_recrutement.ForeColor = System.Drawing.Color.Red; // Définition de la couleur rouge
                    headerRow.Cells.Add(Date_recrutement);


                    // Création de la cellule pour le titre "poste"
                    TableHeaderCell menu_poste = new TableHeaderCell();
                    menu_poste.Text = "poste4";
                    menu_poste.ForeColor = System.Drawing.Color.Red; // Définition de la couleur rouge
                    headerRow.Cells.Add(menu_poste);

                    // Création de la cellule pour le titre "poste"
                    TableHeaderCell btn = new TableHeaderCell();
                    btn.Text = "Valider";
                    btn.ForeColor = System.Drawing.Color.Red; // Définition de la couleur rouge
                    headerRow.Cells.Add(btn);

                    table.Rows.Add(headerRow);

                    for (int i = 0; i < numberOfEmployees; i++)
                    {
                        TableRow row = new TableRow();

                        //Spefication employe
                        TableCell empoloyeCell = new TableCell();
                        Label employe = new Label();
                        employe.Text = "N " + i;
                        employe.ForeColor = System.Drawing.Color.Red;
                        empoloyeCell.Controls.Add(employe); // ajout de l'employe a la cellule
                        row.Cells.Add(empoloyeCell);

                        // Champs pour le nom
                        TableCell NameCell = new TableCell();
                        TextBox Name = new TextBox();
                        Name.ID = "Name_" + i;
                        NameCell.Controls.Add(Name);
                        row.Cells.Add(NameCell);

                        // Champs pour le nom
                        TableCell prenomCell = new TableCell();
                        TextBox Prenom_textbox = new TextBox();
                        Prenom_textbox.ID = "prenom_textbox_" + i;
                        prenomCell.Controls.Add(Prenom_textbox);
                        row.Cells.Add(prenomCell);

                        // Champs pour le Sexe
                        TableCell SexeCell = new TableCell();
                        TextBox Sexe_textbox = new TextBox();
                        Sexe_textbox.ID = "sexe_" + i;
                        SexeCell.Controls.Add(Sexe_textbox);
                        row.Cells.Add(SexeCell);


                        // Champs pour la Date
                        TableCell dateCell = new TableCell();
                        TextBox date_recru = new TextBox();
                        date_recru.ID = "date_recru_" + i;
                        dateCell.Controls.Add(date_recru);
                        row.Cells.Add(dateCell);


                        // Menu déroulant pour le poste
                        TableCell poste_deroulantCell = new TableCell();
                        DropDownList ddlPosition = new DropDownList();

                        ddlPosition.ID = "ddlPosition" + i;
                        IDataReader SQLquerySELECT = execSQLQuery(connectDB(@"DESKTOP-K341PHB", "new_bd"), "SELECT type_poste FROM posteSet");
                        while(SQLquerySELECT.Read())
                        {     
                            ddlPosition.Items.Add(new ListItem(SQLquerySELECT.GetString(0)));
                        }

                        poste_deroulantCell.Controls.Add(ddlPosition);
                        row.Cells.Add(poste_deroulantCell);

                        // Bouton pour enregistrer l'employé
                        TableCell btnCell = new TableCell();
                        Button btnSaveEmployee = new Button();
                        btnSaveEmployee.ID = "btnSaveEmployee" + i;
                        btnSaveEmployee.Text = "Enregistrer";
                        btnSaveEmployee.Click += new EventHandler(btnSaveEmployee_Click);
                        btnCell.Controls.Add(btnSaveEmployee);
                        row.Cells.Add(btnCell);

                        table.Rows.Add(row);
                    }

                    divUser.Controls.Add(table);
                    /*for(int x = 0; x < post; x++)
                        SQLquery = execNotSQLQuery(connection, "INSERT INTO posteSet (type_poste, salaire) VALUES ('" + poste.Text + "','" + Class1.tableau_salaires[x] + "' )");
                   */
                    if (SQLquery == "")
                    {

                        //Class1.name_entreprise = nomE.Text;
                        // mettre un lien de redireciton ver un page de confirmation

                    }
                    else
                    {
                        user_error.BackColor = System.Drawing.Color.Pink;
                        user_error.Text = "Une erreur s'est produite : " + SQLquery;
                    }
                }

            }



        }

        protected void btnSaveEmployee_Click(object sender, EventArgs e)
        {
            IDbConnection connection = null;
            string SQLquery = "";
            // Récupérer l'index de l'employé
            Button btnSaveEmployee = (Button)sender;
            int employeeIndex = int.Parse(btnSaveEmployee.ID.Replace("btnSaveEmployee", ""));

            // Récupérer les informations de l'employé
            TextBox txtRecruitmentDate = (TextBox)divUser.FindControl("date_recru_" + employeeIndex);
            TextBox txtFirstName = (TextBox)divUser.FindControl("Name_" + employeeIndex);
            TextBox txtLastName = (TextBox)divUser.FindControl("prenom_textbox_" + employeeIndex);
            TextBox Sexe = (TextBox)divUser.FindControl("sexe_" + employeeIndex);
            
            DropDownList ddlPosition = (DropDownList)divUser.FindControl("ddlPosition" + employeeIndex);
            if (ddlPosition.SelectedItem != null)
            {
                string selectedText = ddlPosition.SelectedItem.Text;
                SQLquery = execNotSQLQuery(connectDB(@"DESKTOP-K341PHB", "new_bd"), "INSERT INTO employeSet (nom, sexe, prenom, date_recrutement, types_postes,nom_Entreprise) VALUES ('" + txtFirstName.Text + "','" + Sexe.Text + "','" + txtLastName.Text + "','" + txtRecruitmentDate.Text + "','"+ selectedText + "','" + Class1.name_entreprise + "' )");
                SQLerr.Text = SQLquery;


            }


/*


            // Générer le matricule de l'employé
            string recruitmentYear = txtRecruitmentDate.Text.Substring(6, 2);
            int employeeCount = company.Employees.Count + 1;
            string employeeId = $"{recruitmentYear}V{employeeCount:D4}";

            // Calculer le salaire en fonction de l'ancienneté
            DateTime recruitmentDate = DateTime.Parse(txtRecruitmentDate.Text);
            decimal salary = company.GetPositionByTitle(ddlPosition.SelectedItem.Text).Salary;
            int yearsOfService = DateTime.Now.Subtract(recruitmentDate).Days / 365;
            decimal adjustedSalary = salary * (1 + (yearsOfService * 0.02m));

            // Créer l'employé et l'ajouter à la liste
            Employee employee = new Employee(employeeId, txtFirstName.Text, txtLastName.Text, Sexe.Text, recruitmentDate, adjustedSalary);
            company.Employees.Add(employee);

            // Rediriger vers la page de création des employés
            Response.Redirect("afficher.aspx");
*/
        }

    }
}



