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
        int cont_login;
        string linkserver = "Server=tcp:cyberbitchs.database.windows.net,1433;Initial Catalog=Primeiro_Banco;Persist Security Info=False;User ID=cyberbitchs;Password=Teste<code/>;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        protected void Page_Load(object sender, EventArgs e)
        {
            string cod_usuario = (string)Session["cod_usuario"];
            if (cod_usuario != null)
            {
                Response.Redirect("area_inicio/monitor.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            #region Verificação de campos
            if (txtUser.Text.Length == 0)
            {
                //lblErro.Text = "User Invalido!";
                txtUser.Focus();
                return;
            }
           
            if (txtSenha.Text.Length == 0)
            {
                //lblErro.Text = "Senha Invalida!";
                txtSenha.Focus();
                return;
            }
            #endregion
            using (SqlConnection conexao = new SqlConnection(linkserver))
            {
                conexao.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT Cod_Usuario FROM Pollo_Usuario WHERE (user_pollo= '" + txtUser.Text + "' AND senha = '" + txtSenha.Text + "') OR (email = '" + txtUser.Text + "' AND senha = '" + txtSenha.Text + "')", conexao))
                {

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            int cod_user = reader.GetInt32(0);
                            Session["cod_usuario"] = cod_user + "";
                            cont_login = 1;
                        }
                    }
                }
            }
            if (cont_login != 1)
            {
                txtUser.Focus();
                return;
            }
            else
            {
                Response.Redirect("area_inicio/monitor.aspx");
            }
        }
    }
}