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
        Button btnEditar;
        Button btnExcluir;
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

            ListarRegistros();
            CriarRegistros();

            if (IsPostBack == false)
            {

                
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

            bool statusc = (bool)Session["statusc"];
            string cod_usuario = (string)Session["cod_usuario"];

            if (!statusc)
            {
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
                #region Update do editar
                if (statusc)
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE Pollo_Chocadeira SET nome_chocadeira = @nome_chocadeira, cod_ovo = @cod_ovo, quantidade_ovos = @quantidade_ovos WHERE cod_chocadeira = @cod_chocadeira", conexao))
                    {
                        int cod_chocadeira = Convert.ToInt32(Session["chocadeira"]);
                        cmd.Parameters.AddWithValue("@cod_chocadeira", cod_chocadeira);
                        cmd.Parameters.AddWithValue("@nome_chocadeira", txtNomeChocadeira.Text);
                        cmd.Parameters.AddWithValue("@cod_ovo", ddlCod_ovo.SelectedValue);
                        cmd.Parameters.AddWithValue("@quantidade_ovos", txtQtdOvos.Text);
                        cmd.ExecuteNonQuery();

                        lblErro.Text = "Chocadeira editado com sucesso";


                    }

                }
                #endregion
                else
                {
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
                    }
                    #endregion
                }

            }
            #region Limpando os campos
            txtNomeChocadeira.Text = "";
            ddlCod_ovo.SelectedValue = "";
            txtQtdOvos.Text = "";
            #endregion

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

                btnEditar = new Button();
                btnEditar.Text = "";
                btnEditar.CssClass = "botao_editar";
                btnEditar.Command += Editar;
                btnEditar.CommandArgument = cc.ElementAt(i).codChocadeira.ToString();
                linha.Controls.Add(btnEditar);

                btnExcluir = new Button();
                btnExcluir.Text = "";
                btnExcluir.CssClass = "botao_excluir";
                btnExcluir.Command += Excluir;
                btnExcluir.CommandArgument = cc.ElementAt(i).codChocadeira.ToString();
                linha.Controls.Add(btnExcluir);
            }
        }

        public void Editar(object sender, CommandEventArgs e)
        {
            
            txtNomeChocadeira.Text = "";
            txtQtdOvos.Text = "";
            ddlCod_ovo.SelectedValue = "";

            using (SqlConnection conexao = new SqlConnection(linkserver))
            {
                conexao.Open();

                #region Alimentando os campos com a chocadeira
                using (SqlCommand cmd = new SqlCommand("SELECT nome_chocadeira, cod_ovo, quantidade_ovos FROM Pollo_Chocadeira WHERE cod_chocadeira = @cod_chocadeira", conexao))
                {
                    int cod_chocadeira = int.Parse(e.CommandArgument.ToString());
                    cmd.Parameters.AddWithValue("@cod_chocadeira", cod_chocadeira);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read() == true)
                        {
                            txtNomeChocadeira.Text = reader.GetString(0);
                            ddlCod_ovo.SelectedValue = "" + reader.GetInt32(1) ;
                            txtQtdOvos.Text = Convert.ToString(reader.GetInt32(2));
                            btnCadastrar.Text = "Editar";
                            Session["statusc"] = true;
                            Session["chocadeira"] = cod_chocadeira+"";
                        }
                    }
                }
                #endregion
            }
            
        }

        public void Excluir(object sender, CommandEventArgs e)
        {
            int cod_chocadeira = int.Parse(e.CommandArgument.ToString());
            using (SqlConnection conexao = new SqlConnection(linkserver))
            {
                conexao.Open();

                 using (SqlCommand cmd = new SqlCommand("DELETE FROM Pollo_Chocadeira WHERE cod_chocadeira = @cod_chocadeira", conexao))
                 {
                        cmd.Parameters.AddWithValue("@cod_chocadeira", cod_chocadeira);
                        cmd.ExecuteNonQuery();
                        //Mostra pro usuario que foi deletado de alguma forma ou da uma mensagem de "você tem ctz?"
                 }
            }
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