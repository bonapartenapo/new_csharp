using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public class Class1
    {
        public static int nbre_employe = 0, anne_min, coef;
        public static string[] tableau_postes { get; set; }
        public static string[] tableau_salaires { get; set; }

        public static TextBox[] poste_Id;
        public static TextBox[] salaire_Id;



        public static int p = 1, i = 1, sal = 0, nbre_poste = 0;
        public static string pos, dat, rep;
        public static float cal;
        public static DateTime date = DateTime.MinValue;
        public static string name_entreprise = "";
        public static int anne_max = DateTime.Now.Year;
        public static bool date_valide = false;
        public static string poste_employe;
        public static double salaire;
    }
}