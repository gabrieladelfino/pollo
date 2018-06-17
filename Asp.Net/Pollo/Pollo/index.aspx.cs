using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Pollo
{   
    public partial class index : System.Web.UI.Page
    {
        string linkserver = "Server=tcp:cyberbitchs.database.windows.net,1433;Initial Catalog=Primeiro_Banco;Persist Security Info=False;User ID=cyberbitchs;Password=Teste<code/>;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        string user, email, senha;
        int cod_user;
        int cont_login;

        protected void Page_Load(object sender, EventArgs e)
        {
            #region Verificando se o usuario está logado
            string cod_usuario = (string)Session["cod_usuario"];
            if (cod_usuario != null)
            {
                Response.Redirect("area_inicio/monitor.aspx");
            }
            #endregion
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            #region Verificação de campos
            if (txtUser.Text.Length == 0)
            {               
                txtUser.Focus();
                return;
            }
           
            if (txtSenha.Text.Length == 0)
            {
                txtSenha.Focus();
                return;
            }
            #endregion
            using (SqlConnection conexao = new SqlConnection(linkserver))
            {
                conexao.Open();
                #region Verificando dados para logar
                using (SqlCommand cmd = new SqlCommand("SELECT cod_Usuario, user_pollo, email, senha FROM Pollo_Usuario WHERE (user_pollo= '" + txtUser.Text + "' AND senha = '" + txtSenha.Text + "') OR (email = '" + txtUser.Text + "' AND senha = '" + txtSenha.Text + "')", conexao))
                {

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            cod_user = reader.GetInt32(0);
                            user = reader.GetString(1);
                            email = reader.GetString(2);
                            senha = reader.GetString(3);                            
                        }
                    }
                }
                #endregion

            }
            #region Verificando Login
            string txt_user = Convert.ToString(txtUser.Text);
            string txt_senha = Convert.ToString(txtSenha.Text);
            if ((user == txt_user || email==txt_user) && senha == txt_senha)
             {
                Session["cod_usuario"] = cod_user + "";
                cont_login = 1;
            }
            #endregion
            #region Logando
            if (cont_login != 1)
            {
                txtUser.Focus();
                return;
            }
            else
            {
                Response.Redirect("area_inicio/monitor.aspx");
            }
            #endregion
        }
    }
}