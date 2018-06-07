using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Pollo.area_usuario
{
    public partial class recuperacao_senha : System.Web.UI.Page
    {
        string linkserver = "Server=tcp:cyberbitchs.database.windows.net,1433;Initial Catalog=Primeiro_Banco;Persist Security Info=False;User ID=cyberbitchs;Password=Teste<code/>;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        int cod_pergunta, cont_senha, cod_user, cont_resposta;
        string pergunta, nova_senha;

        protected void Page_Load(object sender, EventArgs e)
        {
            #region Verificação usuario logado
            string cod_usuario = (string)Session["cod_usuario"];
            if (cod_usuario != null)
            {
                Response.Redirect("index.aspx");
            }
            #endregion
            if (IsPostBack == false)
            {
                txtPergunta.CssClass = "txt_disable";
                txtResposta.CssClass = "txt_disable";
                txtNovaSenha.CssClass = "txt_disable";
                txtConfirmarSenha.CssClass = "txt_disable";
            }
        }

        protected void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection conexao = new SqlConnection(linkserver))
            {
                conexao.Open();
                #region Identificando usuario e obtendo o codigo da pergunta
                using (SqlCommand cmd = new SqlCommand("SELECT cod_usuario, cod_pergunta FROM Pollo_Usuario WHERE user_pollo = '" + txtUsuario.Text + "' OR email = '" + txtUsuario.Text + "'", conexao))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            cod_user = reader.GetInt32(0);
                            cod_pergunta = reader.GetInt32(1);
                            txtResposta.CssClass = "txt";
                        }
                    }
                }
                #endregion
                #region Obtendo a pergunta com base no codigo
                using (SqlCommand cmd = new SqlCommand("SELECT pergunta FROM Pollo_Pergunta WHERE cod_pergunta =" + cod_pergunta, conexao))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            pergunta = reader.GetString(0);
                        }
                    }
                }
                txtPergunta.Text = pergunta;
                #endregion
            }
        }

        protected void txtResposta_TextChanged(object sender, EventArgs e)
        {
            #region Verificando se a resposta está correta
            using (SqlConnection conexao = new SqlConnection(linkserver))
            {
                conexao.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Pollo_Usuario WHERE user_pollo = '" + txtUsuario.Text + "' OR email = '" + txtUsuario.Text + "' AND rec_resposta = '" + txtResposta.Text + "'", conexao))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            cont_resposta = 1;
                            txtResposta.CssClass = "txt";
                        }
                    }
                }
            }
            #endregion

            #region Verificando se a resposta coincide
            if (cont_resposta == 1)
            {
                txtNovaSenha.CssClass = "txt";
                txtConfirmarSenha.CssClass = "txt";
            }
            else
            {
                txtNovaSenha.CssClass = "txt_disable";
                txtConfirmarSenha.CssClass = "txt_disable";
            }
            #endregion
        }


        protected void btnRecuperar_Click(object sender, EventArgs e)
        {
            #region Update nova senha
            #region Verificação senhas
            if (txtNovaSenha.Text.Length == 0)
            {
                txtNovaSenha.Focus();
                return;
            }

            if (txtConfirmarSenha.Text.Length == 0)
            {
                txtConfirmarSenha.Focus();
                return;
            }
            #endregion
            #region Verificando se a senha antiga é igual a nova senha
            using (SqlConnection conexao = new SqlConnection(linkserver))
            {
                conexao.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Pollo_Usuario WHERE senha = '" + txtNovaSenha.Text + "' AND cod_usuario = " + cod_user, conexao))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            cont_senha = 1;
                        }
                    }
                }
            }
            #endregion
            if (cont_senha == 1)
            {
                txtNovaSenha.Focus();
                return;
            }
            #region Verificando se as senhas coincidem
            if (txtNovaSenha.Text != txtConfirmarSenha.Text)
            {
                txtConfirmarSenha.Focus();
                return;
            }
            #endregion

           //     nova_senha = (txtNovaSenha.Text).ToString();
                using (SqlConnection conexao = new SqlConnection(linkserver))
                {
                    conexao.Open();
                    using (SqlCommand cmd = new SqlCommand("UPDATE Pollo_Usuario SET senha = @senha WHERE cod_usuario = @cod_user", conexao))
                    {
                        cmd.Parameters.AddWithValue("@senha", txtNovaSenha.Text);
                        cmd.Parameters.AddWithValue("@cod_user", PegarCod());
                        cmd.ExecuteNonQuery();
                    }
                }
            }

        #endregion
        public int PegarCod()
        {
            #region Verificando se a resposta está correta
            using (SqlConnection conexao = new SqlConnection(linkserver))
            {
                conexao.Open();
                
                using (SqlCommand cmd = new SqlCommand("SELECT cod_usuario FROM Pollo_Usuario WHERE user_pollo = '" + txtUsuario.Text + "' OR email = '" + txtUsuario.Text + "' AND rec_resposta = '" + txtResposta.Text + "'", conexao))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            cod_user = reader.GetInt32(0);
                        }
                    }
                }
            }
            return cod_user;
            #endregion
        }

       
    }
}
    
