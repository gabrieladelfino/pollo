using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Pollo.area_chocadeira
{
    public partial class cadastro_chocadeira : System.Web.UI.Page
    {
        string linkconexao = "Server=tcp:cyberbitchs.database.windows.net,1433;Initial Catalog=Primeiro_Banco;Persist Security Info=False;User ID=cyberbitchs;Password=Teste<code/>;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        int cod_ovo;
        protected void Page_Load(object sender, EventArgs e)
        {
           if (IsPostBack == false)
            {
                using (SqlConnection conexao = new SqlConnection(linkconexao))
                {

                    conexao.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT Cod_Ovo, Tipo, Tamanho FROM Pollo_Ovo", conexao))
                    {

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                        
                            while (reader.Read() == true)
                            {
                                cod_ovo = reader.GetInt32(0);
                                string tipo = reader.GetString(1);
                                string tamanho = reader.GetString(2);
                                ddlCod_ovo.Items.Add(tipo + " " + tamanho);
                            }
                        }
                    }
                }
            }
        }
        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            int cod_usuario = (int)Session["cod_usuario"];

            if (txtNomeChocadeira.Text.Length == 0)
            {
                lblErro.Text = "Nome invalido";
                txtNomeChocadeira.Focus();
                return;
            }

            string item = ddlCod_ovo.SelectedValue;
            
            if (item.Equals(""))
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


            using (SqlConnection conexao = new SqlConnection(linkconexao))
            {
                conexao.Open();

                using (SqlCommand cmd = new SqlCommand("INSERT INTO Pollo_Chocadeira (nome_chocadeira, cod_ovo, quantidade_ovos, cod_usuario) VALUES (@nome_chocadeira, @cod_ovo, @quantidade_ovos, @cod_usuario)", conexao))
                {
                    cmd.Parameters.AddWithValue("@nome_chocadeira", txtNomeChocadeira.Text);
                    cmd.Parameters.AddWithValue("@cod_ovo", item);
                    cmd.Parameters.AddWithValue("@quantidade_ovos", qtd_ovo);
                    cmd.Parameters.AddWithValue("@cod_usuario", cod_usuario);
                    cmd.ExecuteNonQuery();
                    lblErro.Text = "Cadastrado com sucesso";

                }
            }

        }
    }
}