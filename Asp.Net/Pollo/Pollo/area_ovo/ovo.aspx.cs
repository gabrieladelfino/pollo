using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pollo
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        string linkserver = "Server=tcp:cyberbitchs.database.windows.net,1433;Initial Catalog=Primeiro_Banco;Persist Security Info=False;User ID=cyberbitchs;Password=Teste<code/>;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            int cod_usuario = (int)Session["cod_usuario"];
            if (txtTipo.Text.Length == 0)
            {
                lblErro.Text = "Tipo Invalido";
                txtTipo.Focus();
                return;
            }

            string tamanho = ddlTamanho.SelectedValue;
            if (tamanho.Equals(""))
            {
                lblErro.Text = "Tamanho Não Selecionada";
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

                using (SqlCommand cmd = new SqlCommand("INSERT INTO Pollo_Ovo (tipo, tamanho, temperatura, tempo_dia, cod_usuario) VALUES (@tipo, @tamanho, @temperatura, @tempo, @cod_usuario)", conexao))
                {
                    cmd.Parameters.AddWithValue("@tipo", txtTipo.Text);
                    cmd.Parameters.AddWithValue("@tamanho", tamanho);
                    cmd.Parameters.AddWithValue("@temperatura", txtTemperatura.Text);
                    cmd.Parameters.AddWithValue("@tempo", txtTempo.Text);
                    cmd.Parameters.AddWithValue("@cod_usuario", cod_usuario);
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

        }
    }
}