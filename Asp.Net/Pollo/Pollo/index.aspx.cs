using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pollo
{   
    public partial class index : System.Web.UI.Page
    {
        int cont_login;
        string linkserver = "Server=tcp:cyberbitchs.database.windows.net,1433;Initial Catalog=Primeiro_Banco;Persist Security Info=False;User ID=cyberbitchs;Password=Teste<code/>;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {

            Server.Transfer("/area_usuario/cadastro.aspx", true);
            Server.Transfer("index.aspx", false);
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Length == 0)
            {
                lblErro.Text = "User Invalido!";
                txtUser.Focus();
                return;
            }
            if (txtSenha.Text.Length == 0)
            {
                lblErro.Text = "Senha Invalida!";
                txtSenha.Focus();
                return;
            }

            using (SqlConnection conexao = new SqlConnection(linkserver))
            {
                conexao.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT Cod_Usuario FROM Pollo_Usuario WHERE user_pollo= '" + txtUser.Text + "' AND senha ='" + txtSenha.Text + "'", conexao))
                {

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            Session["cod_usuario"] = reader.GetInt32(0);
                            cont_login = 1;
                        }
                    }
                }
            }
            if (cont_login != 1)
            {
                lblErro.Text = "Usuario e Senha invalido!";
                txtUser.Focus();
                return;
            }
            else
            {
                lblErro.Text = Session["cod_usuario"].ToString();
                Server.Transfer("/area_chocadeira/cadastro_chocadeira.aspx", true);
                Server.Transfer("index.aspx", false);
            }
        }
    }
}