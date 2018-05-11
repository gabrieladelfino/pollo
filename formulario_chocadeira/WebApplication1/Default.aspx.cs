using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {
        string linkconexao = "Server=tcp:cyberbitchs.database.windows.net,1433;Initial Catalog=Primeiro_Banco;Persist Security Info=False;User ID=cyberbitchs;Password=Teste<code/>;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private string txtCodDispositivo;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnProsseguir_chocadeira_Click(object sender, EventArgs e)
        {

            if (txtNomeChocadeira.Text.Length == 0)
            {
                lblErro.Text = "Nome invalido";
                return;
            }

            string item = ddlCod_dispositivo.SelectedValue;

            if (item.Equals(""))
            {
                lblErro.Text = "Opção não selecionada";
                return;
            }

            string item2 = ddlCod_ovo.SelectedValue;

            if (item.Equals(""))
            {
                lblErro.Text = "Opção não selecionada";
                return;
            }



            int qtd_ovo;

            if (int.TryParse(txtQtdOvos.Text, out qtd_ovo) == false)
            {
                lblErro.Text = "Quantidade invalida";
                return;
            }

            SqlConnection conexao;
            using ( conexao = new SqlConnection(linkconexao))
            {
                conexao.Open();

                using (SqlCommand cmd = new SqlCommand("INSERT INTO Pollo_Chocadeira (nome_chocadeira, cod_dipositivo, cod_ovo quantidade_ovos) VALUES (@nome_chocadeira, @cod_dispositivo, @cod_ovo, @quantidade_ovos", conexao))
                {
                    cmd.Parameters.AddWithValue("@nome_chocadeira", txtNomeChocadeira.Text); 
                    cmd.Parameters.AddWithValue("@cod_dispositivo", item);
                    cmd.Parameters.AddWithValue("@quantidade_ovos", item2) ;
                    cmd.Parameters.AddWithValue("@quantidade_ovos", qtd_ovo);
                    cmd.ExecuteNonQuery();
                    lblErro.Text = "Cadastrado com sucesso";

                }
                conexao.Close();
            }

        }

        private static void NewMethod(SqlConnection conexao)
        {
            conexao.Open();
        }

        protected void btnProsseguir_dispositivo_Click(object sender, EventArgs e)
        {

            int codDispositivo;
            if (int.TryParse(txtCodDispositivo, out codDispositivo) == false)
            {
                lblErro2.Text = "Valor invalido";
                return;
            }

            if (txtNomeDispositivo.Text.Length == 0)
            {
                lblErro2.Text = "Nome invalido";
                return;
            }
            DateTime data;

            if (DateTime.TryParse(dateConexao.Text, out data) == false)
            {
                lblErro2.Text = "Data invalida";
                return;
            }

            SqlConnection conexao;
            using (conexao = new SqlConnection(linkconexao))
            {
                conexao.Open();


                using (SqlCommand cmd = new SqlCommand("INSERT INTO Pollo_Dispoitivo (cod_dispositivo, nome_dispositivo, data_conexao) VALUES (@cod_dispositivo, @nome_dispositivo, @data_conexao", conexao))
                {
                    cmd.Parameters.AddWithValue("@cod_dispositivo", txtCodDispositivo);
                    cmd.Parameters.AddWithValue("@nome_dispositivo", txtNomeDispositivo.Text);
                    cmd.Parameters.AddWithValue("@data_conexao", dateConexao.Text);
                    cmd.ExecuteNonQuery();
                    lblErro.Text = "Cadastrado com sucesso";

                }
                conexao.Close();

            }
         
        }

        protected void btnProsseguir_sensor_Click(object sender, EventArgs e)
        {
            int CodSensor;
            if (int.TryParse(txtEntrada.Text, out CodSensor) == false)
            {
                lblErro.Text = "Valor invalido";
                return;
            }

            if (txtTipoSensor.Text.Length == 0)
            {
                lblErro2.Text = "Tipo invalido";
                return;
            }

            int entrada;
            if (int.TryParse(txtEntrada.Text, out entrada) == false)
            {
                lblErro.Text = "Valor invalido";
                return;
            }

            SqlConnection conexao;
            using (conexao = new SqlConnection(linkconexao))
            {
                conexao.Open();


                using (SqlCommand cmd = new SqlCommand("INSERT INTO Pollo_Sensor (cod_sensor, tipo, entrada) VALUES (@cod_sensor, @tipo, @entrada", conexao))
                {
                    cmd.Parameters.AddWithValue("@cod_sensor", CodSensor);
                    cmd.Parameters.AddWithValue("@tpo", txtTipoSensor.Text);
                    cmd.Parameters.AddWithValue("@entrada", entrada);
                    cmd.ExecuteNonQuery();
                    lblErro.Text = "Cadastrado com sucesso";

                }
                conexao.Close();

            }


        }
    }
}
