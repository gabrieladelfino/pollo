using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Pollo
{
    public partial class Pagina_Mestra : System.Web.UI.MasterPage
    {
        string linkserver = "Server=tcp:cyberbitchs.database.windows.net,1433;Initial Catalog=Primeiro_Banco;Persist Security Info=False;User ID=cyberbitchs;Password=Teste<code/>;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        string nome;
        string sexo;
        public String CompanyName{
            get {
                return (String)ViewState["companyName"];
            }
            set {
                ViewState["companyName"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string cod_usuario = (string)Session["cod_usuario"];
            if (IsPostBack == false)
            {
                using (SqlConnection conexao = new SqlConnection(linkserver))
                {
                    conexao.Open();
                    int cod_user = Convert.ToInt32(cod_usuario);
                    #region Identificando qual usuario está logado
                    using (SqlCommand cmd = new SqlCommand("SELECT sexo, nome FROM Pollo_Usuario WHERE cod_usuario = "+cod_user, conexao))
                    {

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                sexo = reader.GetString(0);
                                nome = reader.GetString(1);
                            }
                        }
                    }
                }
                #endregion
                #region Verificando o sexo para personalizar 
                if (sexo.Equals("F"))
                {
                    label.Text = "Bem vinda, " + nome + ".";
                }
                else if (sexo.Equals("M"))
                {
                    label.Text = "Bem vindo, " + nome + ".";
                }
                else if (sexo.Equals("O"))
                {
                    label.Text = "Bem vindo(a), " + nome + ".";
                }
                #endregion
            }
        }
        #region Redirecionando paginas do menu 
        protected void pollo_Click(object sender, EventArgs e)
        {
            Response.Redirect("../area_inicio/monitor.aspx");
        }

        protected void chocadeira_Click(object sender, EventArgs e)
        {
            Response.Redirect("../area_chocadeira/chocadeira.aspx");
        }

        protected void ovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("../area_ovo/ovo.aspx");
        }

        protected void analytics_Click(object sender, EventArgs e)
        {
            Response.Redirect("../area_consulta/analytics.aspx");
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("../index.aspx");
        }
        #endregion
    }
}