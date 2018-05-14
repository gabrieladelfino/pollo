using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pollo
{   
    public partial class index : System.Web.UI.Page
    {
       protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {

            Server.Transfer("/area_usuario/cadastro.aspx", true); 
            Server.Transfer("index.aspx", false);
        }
    }
}