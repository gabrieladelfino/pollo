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
    public partial class WebForm3 : System.Web.UI.Page
    {

        string linkserver = "Server=tcp:cyberbitchs.database.windows.net,1433;Initial Catalog=Primeiro_Banco;Persist Security Info=False;User ID=cyberbitchs;Password=Teste<code/>;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        int cod_tamanho, cont_ovo, i;
        int cont_excluir;
        int cod_chocadeira;
        string inicio;
        string final;
        Button btnEditar;
        Button btnExcluir;
        Ovo o;
        List<Ovo> oo;

        public struct Ovo
        {
            public string tipo;
            public int codOvo;
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
                Session["status"] = false;
                btnCadastrar.Text = "Cadatrar";
                using (SqlConnection conexao = new SqlConnection(linkserver))
                {
                    conexao.Open();

                    #region Alimentando a ddl dos tamanhos
                    using (SqlCommand cmd = new SqlCommand("SELECT cod_tamanho, tamanho FROM Pollo_Tamanho_Ovo WHERE cod_usuario= 1000 OR cod_usuario=" + cod_usuario, conexao))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                cod_tamanho = reader.GetInt32(0);
                                string tamanho = reader.GetString(1);
                                ddlTamanho.Items.Add(new ListItem(tamanho, cod_tamanho + ""));
                            }
                        }
                    }
                    #endregion
                }
            }
        }

        #region Botão Cadastrar/Editar
        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            bool status = (bool)Session["status"];
            string cod_usuario = (string)Session["cod_usuario"];

            #region Verificando se está editando para não fazer verificação de nome
            if (!status)
            {
                using (SqlConnection conexao = new SqlConnection(linkserver))
                {

                    conexao.Open();

                    #region Verificando se tem Ovo com mesmo nome e tamanho repetido

                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Pollo_Ovo WHERE tipo= '" + txtTipo.Text + "' AND cod_tamanho ='" + ddlTamanho.SelectedValue + "' AND cod_usuario = " + cod_usuario, conexao))
                    {

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                cont_ovo = 1;
                            }
                        }
                    }
                }
                #endregion
                if (cont_ovo == 1)
                {
                    lblErro.Text = "Ovo já cadastrado";
                    txtTipo.Focus();
                    return;
                }
            }
            #endregion
            #region Verificação cadastro
            if (txtTipo.Text.Length == 0)
            {
                lblErro.Text = "Tipo Invalido";
                txtTipo.Focus();
                return;
            }


            string tamanho = ddlTamanho.SelectedValue;
            if (tamanho.Equals(""))
            {
                lblErro.Text = "Tamanho Não Selecionado";
                ddlTamanho.Focus();
                return;
            }

            double temperatura;
            if (double.TryParse(txtTemperatura.Text, out temperatura) == false)
            {
                lblErro.Text = "Temperatura Invalida";
                txtTemperatura.Focus();
                return;
            }

            int tempo;
            if (int.TryParse(txtTempo.Text, out tempo) == false)
            {
                lblErro.Text = "Tempo Invalido";
                txtTempo.Focus();
                return;
            }
            #endregion
            #region Insert/Update no banco
            using (SqlConnection conexao = new SqlConnection(linkserver))
            {

                conexao.Open();
                int cod_user = Convert.ToInt32(cod_usuario);
                cod_tamanho = Convert.ToInt32(tamanho);

                #region Update do editar
                if (status)
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE Pollo_Ovo SET tipo = @tipo, cod_tamanho= @cod_tamanho , temperatura= @temperatura ,tempo_dia= @tempo WHERE cod_ovo=@cod_ovo", conexao))
                    {
                        int cod_ovo = Convert.ToInt32(Session["ovo"]);
                        cmd.Parameters.AddWithValue("@tipo", txtTipo.Text);
                        cmd.Parameters.AddWithValue("@cod_tamanho", cod_tamanho);
                        cmd.Parameters.AddWithValue("@temperatura", txtTemperatura.Text);
                        cmd.Parameters.AddWithValue("@tempo", txtTempo.Text);
                        cmd.Parameters.AddWithValue("@cod_ovo", cod_ovo);
                        cmd.ExecuteNonQuery();

                        SelectInicio();
                        SelectFinal();
                        UpdateFinal();

                        #region Limpando os campos
                        lblErro.Text = "Ovo editado com sucesso";
                        txtTipo.Text = "";
                        ddlTamanho.SelectedValue = "";
                        txtTemperatura.Text = "";
                        txtTempo.Text = "";
                        #endregion
                    }
                    #region Verificando de se tem esse ovo em alguma chocadeira
                    using (SqlCommand cmd = new SqlCommand("SELECT tbc.cod_chocadeira, tbo.tempo_dia FROM Pollo_Chocadeira AS tbc , Pollo_Ovo AS tbo WHERE tbo.cod_ovo= @cod_ovo", conexao))
                    {
                        string cod_ovo= (string)Session["ovo"];
                        cmd.Parameters.AddWithValue("@cod_ovo", cod_ovo);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                cod_chocadeira = reader.GetInt32(0);
                                tempo = reader.GetInt32(1);
                            }
                        }
                    }
                    
                    #endregion
                }
                #endregion

                #region Insert do cadastrar
                else
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Pollo_Ovo (tipo, cod_tamanho, temperatura, tempo_dia, cod_usuario) VALUES (@tipo, @cod_tamanho, @temperatura, @tempo, @cod_usuario)", conexao))
                    {
                        cmd.Parameters.AddWithValue("@tipo", txtTipo.Text);
                        cmd.Parameters.AddWithValue("@cod_tamanho", cod_tamanho);
                        cmd.Parameters.AddWithValue("@temperatura", txtTemperatura.Text);
                        cmd.Parameters.AddWithValue("@tempo", txtTempo.Text);
                        cmd.Parameters.AddWithValue("@cod_usuario", cod_user);
                        cmd.ExecuteNonQuery();

                        #region Limpando os campos
                        lblErro.Text = "Cadastro efetuado com sucesso";
                        txtTipo.Text = "";
                        ddlTamanho.SelectedValue = "";
                        txtTemperatura.Text = "";
                        txtTempo.Text = "";
                        #endregion
                    }
                }
                #endregion
            }
        }
        #endregion


        public void SelectInicio()
        {
            using (SqlConnection conexao = new SqlConnection(linkserver))
            {
                conexao.Open();
                string cod_ovo = (string)Session["ovo"];
                int cod_o = Convert.ToInt32(cod_ovo);
                using (SqlCommand cmd = new SqlCommand("SELECT CONVERT(VARCHAR, inicio, 111) FROM Pollo_Chocadeira WHERE cod_ovo= "+cod_o, conexao))
                {                  
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            inicio =reader.GetString(0);
                        }
                    }
                }
            }
        }

        public void SelectFinal()
        {
            using (SqlConnection conexao = new SqlConnection(linkserver))
            {
                conexao.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT CONVERT(VARCHAR, (DATEADD(DAY," + txtTempo.Text + ",  '" + inicio + "' )),111) FROM Pollo_Chocadeira", conexao))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            final = reader.GetString(0);
                        }
                    }
                }
            }
                
        }

        public void UpdateFinal()
        {
            using (SqlConnection conexao = new SqlConnection(linkserver))
            {
                conexao.Open();

                string cod_ovo = (string)Session["ovo"];
                int cod_o = Convert.ToInt32(cod_ovo);

                using (SqlCommand cmd = new SqlCommand("UPDATE Pollo_Chocadeira SET final = @final WHERE cod_ovo = "+cod_o, conexao))
                {
                    cmd.Parameters.AddWithValue("@final", final);
                    cmd.ExecuteNonQuery();
                }
            }      
        }
        #endregion

        #region Botão Limpar
        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            #region Limpando os campos
            txtTemperatura.Text = "";
            txtTempo.Text = "";
            txtTipo.Text = "";
            ddlTamanho.SelectedValue = "";
            #endregion
        }
        #endregion
        #region Criando panel, botões e label
        public void CriarRegistros()
        {
            

            for (i = 0; i < oo.Count; i++)
            {
                
                Panel linha = new Panel();
                linha.CssClass = "linha";
                cadastrados.Controls.Add(linha);

                Label lblNome = new Label();
                lblNome.Text = oo.ElementAt(i).tipo.ToString();
                lblNome.CssClass = "nome";
                linha.Controls.Add(lblNome);

                btnEditar = new Button();
                btnEditar.Text = "";
                btnEditar.CssClass = "botao_editar";
                btnEditar.Command += Editar;
                btnEditar.CommandArgument = oo.ElementAt(i).codOvo.ToString();
                linha.Controls.Add(btnEditar);

                btnExcluir = new Button();
                btnExcluir.Text = "";
                btnExcluir.CssClass = "botao_excluir";
                btnExcluir.Command += Excluir;
                btnExcluir.CommandArgument = oo.ElementAt(i).codOvo.ToString();
                linha.Controls.Add(btnExcluir);
            }
        }
        #endregion

        #region Botão excluir
        public void Excluir(object sender, CommandEventArgs e)
        {
            int cod_ovo = int.Parse(e.CommandArgument.ToString());
            using (SqlConnection conexao = new SqlConnection(linkserver))
            {
                conexao.Open();

                #region Deletando 
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Pollo_Chocadeira WHERE cod_ovo = @cod_ovo", conexao))
                {
                    cmd.Parameters.AddWithValue("@cod_ovo", cod_ovo);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            cont_excluir = 1;
                        }
                    }
                }
                if (cont_excluir == 1)
                {
                    //Mostrar que o ovo não pode ser excluido pq ta em uso numa chocadeira
                }
                else
                { 
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Pollo_Ovo WHERE cod_ovo = @cod_ovo", conexao))
                    {
                        cmd.Parameters.AddWithValue("@cod_ovo", cod_ovo);
                        cmd.ExecuteNonQuery();
                        //Mostra pro usuario que foi deletado de alguma forma ou da uma mensagem de "você tem ctz?"
                    }
                }
                #endregion
            }
        }
        #endregion
        #region Botão editar
        public void Editar(object sender, CommandEventArgs e)
        {
            txtTemperatura.Text = "";
            txtTempo.Text = "";
            txtTipo.Text = "";
            ddlTamanho.SelectedValue = "";
            
            using (SqlConnection conexao = new SqlConnection(linkserver))
            {
                conexao.Open();

                #region Alimentando os campos com o ovo selecionado
                using (SqlCommand cmd = new SqlCommand("SELECT tipo, cod_tamanho ,temperatura, tempo_dia FROM Pollo_Ovo WHERE cod_ovo = @cod_ovo", conexao))
                {
                    int cod_ovo = int.Parse(e.CommandArgument.ToString());
                    cmd.Parameters.AddWithValue("@cod_ovo", cod_ovo);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                       
                        while (reader.Read() == true)
                        {
                            txtTipo.Text = reader.GetString(0);
                            ddlTamanho.SelectedValue = "" + reader.GetInt32(1);
                            txtTemperatura.Text = "" + reader.GetDouble(2);
                            txtTempo.Text = "" + reader.GetInt32(3);
                            btnCadastrar.Text = "Editar";
                            Session["status"] = true;
                            Session["ovo"] = cod_ovo+"";
                        }
                    }
                }
                #endregion
            }
        }
         #endregion
        #region Listar registros no painel
        public void ListarRegistros()
        {
            string cod_usuario = (string)Session["cod_usuario"];
            int cod_user = Convert.ToInt32(cod_usuario);

            o = new Ovo();
            oo = new List<Ovo>();

            using (SqlConnection conexao = new SqlConnection(linkserver))
            {
                conexao.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT  cod_ovo, tipo FROM Pollo_Ovo WHERE cod_usuario = " + cod_user, conexao))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            o.codOvo = reader.GetInt32(0);
                            o.tipo = reader.GetString(1);
                            oo.Add(o);
                        }
                    }
                }

            }
        }
        #endregion
    }
}