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

        protected void Page_Load(object sender, EventArgs e)
        {
            cod_usuario = (string)Session["cod_usuario"];
            if (cod_usuario == null)
            {
                Response.Redirect("../index.aspx");
            }
            CarregarFoto();
        }

        public void CarregarFoto()
        {

            using (SqlConnection conexao = new SqlConnection(linkserver))
            {
                conexao.Open();

                int cod_user = Convert.ToInt32(cod_usuario);

                using (SqlCommand cmd = new SqlCommand("SELECT caminho_foto, nome FROM Pollo_Usuario WHERE cod_usuario = " + cod_user, conexao))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            imgUsuario.ImageUrl = "../imagens/fotos_usuarios/" + reader.GetString(0);
                            lblNomeUsuario.Text = reader.GetString(1);
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
                        CarregarFoto();
                    }
                }
            }
            else
            {
                lblMessage.Text = "Selecione uma imagem.";
            }

        }
    }
}