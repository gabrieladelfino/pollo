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
    public partial class WebForm2 : System.Web.UI.Page
    {
        string linkserver = "Server=tcp:cyberbitchs.database.windows.net,1433;Initial Catalog=Primeiro_Banco;Persist Security Info=False;User ID=cyberbitchs;Password=Teste<code/>;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        int cod_ovo;
        int cont_chocadeira;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cod_usuario = (string)Session["cod_usuario"];
            if (cod_usuario == null)
            {
                Response.Redirect("../index.aspx");
            }

            if (IsPostBack == false)
            {
                using (SqlConnection conexao = new SqlConnection(linkserver))
                {

                    conexao.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT cod_ovo, tipo, tamanho FROM Pollo_Ovo", conexao))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                cod_ovo = reader.GetInt32(0);
                                string tipo = reader.GetString(1);
                                string tamanho = reader.GetString(2);
                                ddlCod_ovo.Items.Add(new ListItem(tipo + " " + tamanho, cod_ovo + ""));
                            }
                        }
                    }
                }
            }
        }
        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            string cod_usuario = (string)Session["cod_usuario"];

            using (SqlConnection conexao = new SqlConnection(linkserver))
            {
                conexao.Open();

                //Verificando se tem Nome de Chocadeira repetido
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Pollo_Chocadeira WHERE nome_chocadeira= '" + txtNomeChocadeira.Text + "' AND cod_usuario = " + cod_usuario, conexao))
                {

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            cont_chocadeira = 1;
                        }
                    }
                }
            }
            if (txtNomeChocadeira.Text.Length == 0 || cont_chocadeira == 1)
            {
                lblErro.Text = "Nome invalido";
                txtNomeChocadeira.Focus();
                return;
            }

            string ovo = ddlCod_ovo.SelectedValue;
            if (ovo.Equals(""))
            {
                lblErro.Text = "Opção não selecionada";
                ddlCod_ovo.Focus();
                return;
            }
            int qtd_ovo;

            if (int.TryParse(txtQtdOvos.Text, out qtd_ovo) == false)
            {
                lblErro.Text = "Quantidade invalida";
                txtQtdOvos.Focus();
                return;
            }


            using (SqlConnection conexao = new SqlConnection(linkserver))
            {
                conexao.Open();
                cod_ovo = Convert.ToInt32(ovo);
                int cod_user = Convert.ToInt32(cod_usuario);
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Pollo_Chocadeira (nome_chocadeira, cod_ovo, quantidade_ovos, cod_usuario) VALUES (@nome_chocadeira, @cod_ovo, @quantidade_ovos, @cod_usuario)", conexao))
                {
                    cmd.Parameters.AddWithValue("@nome_chocadeira", txtNomeChocadeira.Text);
                    cmd.Parameters.AddWithValue("@cod_ovo", ovo);
                    cmd.Parameters.AddWithValue("@quantidade_ovos", qtd_ovo);
                    cmd.Parameters.AddWithValue("@cod_usuario", cod_user);
                    cmd.ExecuteNonQuery();
                    lblErro.Text = "Cadastrado com sucesso";

                    txtNomeChocadeira.Text = "";
                    txtQtdOvos.Text = "";
                    ddlCod_ovo.SelectedValue = "";
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            txtNomeChocadeira.Text = "";
            txtQtdOvos.Text = "";
            ddlCod_ovo.SelectedValue = "";
        }
    }
}