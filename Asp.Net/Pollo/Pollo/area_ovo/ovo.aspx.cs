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
        int cont_ovo;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cod_usuario = (string)Session["cod_usuario"];
            if (cod_usuario == null)
            {
                Response.Redirect("../index.aspx");
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            string cod_usuario = (string)Session["cod_usuario"];

            using (SqlConnection conexao = new SqlConnection(linkserver))
            {
                conexao.Open();

                //Verificando se tem Ovo com mesmo nome e tamanho repetido
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Pollo_Ovo WHERE tipo= '" + txtTipo.Text + "' AND tamanho ='" + ddlTamanho.SelectedValue + "' AND cod_usuario = "+cod_usuario, conexao))
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
                if (txtTipo.Text.Length == 0|| cont_ovo == 1)
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

            using (SqlConnection conexao = new SqlConnection(linkserver))
            {
                conexao.Open();
                int cod_user = Convert.ToInt32(cod_usuario);
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Pollo_Ovo (tipo, tamanho, temperatura, tempo_dia, cod_usuario) VALUES (@tipo, @tamanho, @temperatura, @tempo, @cod_usuario)", conexao))
                {
                    cmd.Parameters.AddWithValue("@tipo", txtTipo.Text);
                    cmd.Parameters.AddWithValue("@tamanho", tamanho);
                    cmd.Parameters.AddWithValue("@temperatura", txtTemperatura.Text);
                    cmd.Parameters.AddWithValue("@tempo", txtTempo.Text);
                    cmd.Parameters.AddWithValue("@cod_usuario", cod_user);
                    cmd.ExecuteNonQuery();

                    lblErro.Text = "Cadastro efetuado com sucesso";
                    txtTipo.Text = "";
                    ddlTamanho.SelectedValue = "";
                    txtTemperatura.Text = "";
                    txtTempo.Text = "";
                }

            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            txtTemperatura.Text = "";
            txtTempo.Text = "";
            txtTipo.Text = "";
            ddlTamanho.SelectedValue = "";
        }
    }
}