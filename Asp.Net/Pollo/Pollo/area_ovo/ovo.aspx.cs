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
            if (IsPostBack == false)
            {
                ListarRegistros();
                CriarRegistros();
                using (SqlConnection conexao = new SqlConnection(linkserver))
                {
                    conexao.Open();

                    #region Alimentando a ddl dos tamanhos
                    using (SqlCommand cmd = new SqlCommand("SELECT cod_tamanho, tamanho FROM Pollo_Tamanho_Ovo WHERE cod_usuario= 1000 OR cod_usuario="+cod_usuario, conexao))
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

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            string cod_usuario = (string)Session["cod_usuario"];

            using (SqlConnection conexao = new SqlConnection(linkserver))
            {
               
                conexao.Open();

                #region Verificando se tem Ovo com mesmo nome e tamanho repetido
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Pollo_Ovo WHERE tipo= '" + txtTipo.Text + "' AND cod_tamanho ='" + ddlTamanho.SelectedValue + "' AND cod_usuario = "+cod_usuario, conexao))
                {

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            cont_ovo = 1;
                        }
                    }
                }
                #endregion
            }
            #region Verificação cadastro
            if (txtTipo.Text.Length == 0)
            {
                lblErro.Text = "Tipo Invalido";
                txtTipo.Focus();
                return;
            }
            if (cont_ovo == 1)
            {
                lblErro.Text = "Ovo já cadastrado";
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
            #region Insert no banco
            using (SqlConnection conexao = new SqlConnection(linkserver))
            {
                conexao.Open();
                int cod_user = Convert.ToInt32(cod_usuario);
                cod_tamanho = Convert.ToInt32(tamanho);
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

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            #region Limpando os campos
            txtTemperatura.Text = "";
            txtTempo.Text = "";
            txtTipo.Text = "";
            ddlTamanho.SelectedValue = "";
            #endregion
        }

        public void CriarRegistros()
        {
            for (i = 0; i < oo.Count; i++)
            {
                Panel linha = new Panel();
                linha.CssClass = "linha";
                cadastrados.Controls.Add(linha);

                Label lblNome = new Label();
                lblNome.Text = "" + oo.ElementAt(i).tipo;
                lblNome.CssClass = "nome";
                linha.Controls.Add(lblNome);

                Button editar = new Button();
                editar.Text = "Editar";
                editar.CssClass = "botao";
                linha.Controls.Add(editar);

                Button excluir = new Button();
                excluir.Text = "Excluir";
                excluir.CssClass = "botao";
                linha.Controls.Add(excluir);
            }
        }

        public void ListarRegistros()
        {
            string cod_usuario = (string)Session["cod_usuario"];
            int cod_user = Convert.ToInt32(cod_usuario);

            o = new Ovo();
            oo = new List<Ovo>();

            using (SqlConnection conexao = new SqlConnection(linkserver))
            {
                conexao.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT  tbo.cod_ovo, tbo.tipo FROM Pollo_Ovo AS tbo, Pollo_Usuario AS tbu WHERE tbu.cod_usuario = " + cod_user, conexao))
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
    }
}