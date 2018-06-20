using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
namespace Pollo
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        string linkserver = "Server=tcp:cyberbitchs.database.windows.net,1433;Initial Catalog=Primeiro_Banco;Persist Security Info=False;User ID=cyberbitchs;Password=Teste<code/>;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        string cod_usuario;

        int cont_celular, cont_user, cont_email, cod_user;

        protected void Page_Load(object sender, EventArgs e)
        {
            cod_usuario = (string)Session["cod_usuario"];
            if (cod_usuario == null)
            {
                Response.Redirect("../index.aspx");
            }

            CarregarDados();
        }

        public void CarregarDados()
        {

            using (SqlConnection conexao = new SqlConnection(linkserver))
            {
                conexao.Open();

                int cod_user = Convert.ToInt32(cod_usuario);

                using (SqlCommand cmd = new SqlCommand("SELECT caminho_foto, nome, data_nasc, email, celular, user_pollo FROM Pollo_Usuario WHERE cod_usuario = " + cod_user, conexao))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            imgUsuario.ImageUrl = "../imagens/fotos_usuarios/" + reader.GetString(0);
                            lblNomeUsuario.Text = reader.GetString(1);
                            txtNome.Text = reader.GetString(1);
                            txtDataNasc.Text = reader.GetString(2);
                            txtEmail.Text = reader.GetString(3);
                            txtCelular.Text = reader.GetString(4);
                            txtUser.Text = reader.GetString(5);
                        }
                    }
                }
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {

            if (fileImagem.HasFile)
            {
                string nome_imagem = fileImagem.FileName;
                string path = "~/area_usuario/fotos/" + nome_imagem.ToString();
                fileImagem.PostedFile.SaveAs(Server.MapPath(path));
                
                using (SqlConnection conexao = new SqlConnection(linkserver))
                {
                    conexao.Open();

                    cod_usuario = (string)Session["cod_usuario"];
                    int cod_user = Convert.ToInt32(cod_usuario);

                    using (SqlCommand cmd = new SqlCommand("UPDATE Pollo_Usuario SET caminho_foto = @nome_imagem WHERE cod_usuario = @cod_user", conexao))
                    {
                        cmd.Parameters.AddWithValue("@nome_imagem", nome_imagem);
                        cmd.Parameters.AddWithValue("@cod_user", cod_user);
                        cmd.ExecuteNonQuery();
                        lblMessage.Text = "Salvo";
                        CarregarDados();
                    }
                }
            }
            else
            {
                lblMessage.Text = "Selecione uma imagem.";
            }

        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            cod_usuario = (string)Session["cod_usuario"];
            cod_user = Convert.ToInt32(cod_usuario);

            #region 'Verificando se existem dados repetidos'
            using (SqlConnection conexao = new SqlConnection(linkserver))
            {
                conexao.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Pollo_Usuario WHERE email = '" + txtEmail.Text + "' AND cod_usuario = " + cod_usuario, conexao))
                {

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            cont_email = 1;
                        }
                    }
                }

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Pollo_Usuario WHERE user_pollo = '" + txtUser.Text + "' AND cod_usuario = " + cod_usuario, conexao))
                {

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            cont_user = 1;
                        }
                    }

                }

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Pollo_Usuario WHERE user_pollo = '" + txtCelular.Text + "' AND cod_usuario = " + cod_usuario, conexao))
                {

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            cont_celular = 1;
                        }
                    }
                }
                }
            #endregion

            if (txtNome.Text.Length == 0)
            {
                lblErro.Text = "Existem dados inválidos.";
                txtNome.Focus();
                return;
            }

            if (txtDataNasc.Text.Length == 0)
            {
                lblErro.Text = "Existem dados inválidos.";
                txtNome.Focus();
                return;
            }

            if (txtEmail.Text.Length == 0 || cont_email == 1)
            {
                lblErro.Text = "Campo vazio ou user já cadastrado.";
                txtNome.Focus();
                return;
            }

            if (txtUser.Text.Length == 0 || cont_user == 1)
            {
                lblErro.Text = "Campo vazio ou user já cadastrado.";
                txtNome.Focus();
                return;
            }

            if (txtCelular.Text.Length == 0 || cont_celular == 1)
            {
                lblErro.Text = "Campo vazio ou número de celular já cadastrado.";
                txtNome.Focus();
                return;
            }

            else
            {
                using (SqlConnection conexao = new SqlConnection(linkserver))
                {
                    conexao.Open();

                    using (SqlCommand cmd = new SqlCommand("UPDATE Pollo_Usuario SET nome = @nome, data_nasc = @data_nasc, email = @email, celular = @celular, user_pollo = @user WHERE cod_usuario = @cod_user", conexao))
                    {
                        cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                        cmd.Parameters.AddWithValue("@data_nasc", txtDataNasc.Text);
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@celular", txtCelular.Text);
                        cmd.Parameters.AddWithValue("@user", txtUser.Text);
                        cmd.Parameters.AddWithValue("@cod_user", cod_user);
                        cmd.ExecuteNonQuery();
                        lblErro.Text = "Dados editados com sucesso.";
                    }
                }
            }
           

        }
        
    }
}