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
    public partial class cadastro : System.Web.UI.Page
    {
        string linkserver ="Server=tcp:cyberbitchs.database.windows.net,1433;Initial Catalog=Primeiro_Banco;Persist Security Info=False;User ID=cyberbitchs;Password=Teste<code/>;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                using (SqlConnection conexao = new SqlConnection(linkserver))
                {
                    conexao.Open();
 
                }
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Length == 0)
            {
                lblErro.Text = "User Invalido!";
                txtUser.Focus();
                return;
            }

            if (txtEmail.Text.Length == 0)
            {
                lblErro.Text = "Email Invalido!";
                txtEmail.Focus();
                return;
            }

            if (txtSenha.Text.Length == 0)
            {
                lblErro.Text = "Senha Invalida!";
                txtSenha.Focus();
                return;
            }

            string Pergunta;
            Pergunta = ddlPergunta.SelectedValue;
            if (Pergunta.Equals(""))
            {
                lblErro.Text = "Pergunta Não Selecionada!";
                ddlPergunta.Focus();
                return;
            }


            if (txtResposta.Text.Length == 0)
            {
                lblErro.Text = "Resposta Invalida!";
                txtResposta.Focus();
                return;
            }
        }

        protected void btnProsseguir_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Length == 0)
            {
                lblErro.Text = "Nome Invalido!";
                txtNome.Focus();
                return;
            }

            DateTime Nascimento;
            if (DateTime.TryParse(txtNasc.Text, out Nascimento) == false)
            {
                lblErro.Text = "Data Invalida!";
                txtNasc.Focus();
                return;

            }

            if (txtCPF.Text.Length == 0)
            {
                lblErro.Text = "CPF Invalido!";
                txtCPF.Focus();
                return;
            }

            string Sexo;
            Sexo = ddlSexo.SelectedValue;
            if (Sexo.Equals(""))
            {
                lblErro.Text = "Sexo não selecionado!";
                ddlSexo.Focus();
                return;
            }

            int Telefone;
            if (int.TryParse(txtTelefone.Text, out Telefone) == false)
            {
                lblErro.Text = "Telefone Invalido!";
                txtTelefone.Focus();
                return;
            }

            using (SqlConnection conexao = new SqlConnection(linkserver))
            {
                conexao.Open();

                // using (SqlCommand cmd = new SqlCommand("INSERT INTO Pollo_Usuario (Nome, DataNasc, CPF, Sexo, Telefone, User, Email, Senha, Pergunta, Resposta"))
                // {
                    // cmd.Parameters.AddWithValue("@Nome", txtNome.Text);
                    // cmd.Parameters.AddWithValue("@DataNasc", Nascimento);
                    // cmd.Parameters.AddWithValue("@CPF", txtCPF.Text);
                    // cmd.Parameters.AddWithValue("@Sexo", Sexo);
                    // cmd.Parameters.AddWithValue("@Telefone", txtTelefone.Text);
                    // cmd.Parameters.AddWithValue("@User", txtUser.Text);
                    // cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    // cmd.Parameters.AddWithValue("@Senha", txtSenha.Text);
                    // cmd.Parameters.AddWithValue("@Pergunta", ddlPergunta.Text);
                    // cmd.Parameters.AddWithValue("@Resposta", txtResposta.Text);
                    // cmd.ExecuteNonQuery();

                    // lblErro.Text = "Cadastro Efetuado com Sucesso!";
                    // txtNome.Text = "";
                    // txtNasc.Text = "";
                    // txtCPF.Text = "";
                    // ddlSexo.SelectedValue = "";
                    // txtTelefone.Text = "";
                    // txtUser.Text = "";
                    // txtEmail.Text = "";
                    // txtSenha.Text = "";
                    // ddlPergunta.SelectedValue = "";
                    // txtResposta.Text = "";



                // }
            }
        }
    }
}
