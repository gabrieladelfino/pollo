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
        int cod_ovo, i;
        string tipo;
        int cod_tamanho;
        int cont_chocadeira;
        int tempo;
        DateTime inicio;
        DateTime final;

        Chocadeira c;
        List<Chocadeira> cc;
       
        public struct Chocadeira
        {
            public string nomeChocadeira;
            public int codChocadeira;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            #region Verificando se o usuario está logado
            string cod_usuario = (string)Session["cod_usuario"];
            if (cod_usuario == null)
            {
                Response.Redirect("../index.aspx");
            }
            #endregion
            
            if (IsPostBack == false)
            {

                ListarRegistros();
                CriarRegistros();

                using (SqlConnection conexao = new SqlConnection(linkserver))
                {

                    conexao.Open();

                    #region Alimentando a ddl do tipo de ovo
                    #region Selecionando cod, tipo e cod do tamanho
                    using (SqlCommand cmd = new SqlCommand("SELECT cod_ovo, tipo, cod_tamanho FROM Pollo_Ovo WHERE cod_usuario= 1000 OR cod_usuario=" + cod_usuario, conexao))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                cod_ovo = reader.GetInt32(0);
                                tipo = reader.GetString(1);
                                cod_tamanho = reader.GetInt32(2);
                            }
                        }
                    }
                    #endregion
                    #region Identificando o tamanho com o codigo
                    using (SqlCommand cmd = new SqlCommand("SELECT tamanho FROM Pollo_Tamanho_Ovo WHERE cod_tamanho =" + cod_tamanho, conexao))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                string tamanho = reader.GetString(0);
                                ddlCod_ovo.Items.Add(new ListItem(tipo + " " + tamanho, cod_ovo + ""));
                            }
                        }
                    }
                    #endregion
                    #endregion
                }
            }
        }
        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            string cod_usuario = (string)Session["cod_usuario"];

            using (SqlConnection conexao = new SqlConnection(linkserver))
            {
                conexao.Open();

                #region Verificando se tem Nome de Chocadeira repetido
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
                #endregion
            }

            #region Verificação cadastro
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
            #endregion

            using (SqlConnection conexao = new SqlConnection(linkserver))
            {
                conexao.Open();
                cod_ovo = Convert.ToInt32(ovo);
                int cod_user = Convert.ToInt32(cod_usuario);

                #region Verificando a quantidade de dias do ovo selecionado
                using (SqlCommand cmd = new SqlCommand("SELECT tempo_dia FROM Pollo_Ovo WHERE cod_ovo = " + ovo, conexao))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            tempo = reader.GetInt32(0);
                        }
                    }
                }
                #endregion
                #region Obtendo o dia de hoje
                using (SqlCommand cmd = new SqlCommand("SELECT CONVERT(DATE, GETDATE())", conexao))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            inicio = reader.GetDateTime(0);
                        }
                    }
                }
                #endregion
                #region Obtendo o dia final de incubação
                using (SqlCommand cmd = new SqlCommand("SELECT CONVERT(DATE, GETDATE()+" + tempo + ")", conexao))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            final = reader.GetDateTime(0);
                        }
                    }
                }
                #endregion
                #region Insert no banco
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Pollo_Chocadeira (nome_chocadeira, cod_ovo, quantidade_ovos, inicio, final, cod_usuario) VALUES (@nome_chocadeira, @cod_ovo, @quantidade_ovos, @inicio, @final, @cod_usuario)", conexao))
                {
                    cmd.Parameters.AddWithValue("@nome_chocadeira", txtNomeChocadeira.Text);
                    cmd.Parameters.AddWithValue("@cod_ovo", ovo);
                    cmd.Parameters.AddWithValue("@quantidade_ovos", qtd_ovo);
                    cmd.Parameters.AddWithValue("@inicio", inicio);
                    cmd.Parameters.AddWithValue("@final", final);
                    cmd.Parameters.AddWithValue("@cod_usuario", cod_user);
                    cmd.ExecuteNonQuery();
                    lblErro.Text = "Cadastrado com sucesso";

                    txtNomeChocadeira.Text = "";
                    txtQtdOvos.Text = "";
                    ddlCod_ovo.SelectedValue = "";
                }
                #endregion
            }
        }


        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNomeChocadeira.Text = "";
            txtQtdOvos.Text = "";
            ddlCod_ovo.SelectedValue = "";
        }


        public void CriarRegistros()
        {
            for (i = 0; i < cc.Count; i++)
            {
                Panel linha = new Panel();
                linha.CssClass = "linha";
                cadastrados.Controls.Add(linha);

                Label lblNome = new Label();
                lblNome.Text = "" + cc.ElementAt(i).nomeChocadeira;
                lblNome.CssClass = "nome";
                linha.Controls.Add(lblNome);

                Button btnEditar = new Button();
                btnEditar.Text = "Editar";
                btnEditar.CssClass = "botao_editar";
                btnEditar.Click += Editar;
               // linha.Controls.Add(btnEditar);
            
                Button btnExcluir = new Button();
                btnExcluir.Text = "Excluir";
                btnExcluir.CssClass = "botao_excluir";
                btnExcluir.Click += Excluir;
               // linha.Controls.Add(btnExcluir);
            }
        }

        public void Editar(object sender, EventArgs e)
        {

        }

        public void Excluir(object sender, EventArgs e)
        {

        }

        public void ListarRegistros()
        {
            string cod_usuario = (string)Session["cod_usuario"];
            int cod_user = Convert.ToInt32(cod_usuario);

            c = new Chocadeira();
            cc = new List<Chocadeira>();

            using (SqlConnection conexao = new SqlConnection(linkserver))
            {
                conexao.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT cod_chocadeira, nome_chocadeira FROM Pollo_Chocadeira  WHERE cod_usuario = " + cod_user, conexao))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            c.codChocadeira = reader.GetInt32(0);
                            c.nomeChocadeira = reader.GetString(1);
                            cc.Add(c);
                        }
                    }
                }

            }
        }

    }
}