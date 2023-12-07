using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class About : Page
    {

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
    }
}