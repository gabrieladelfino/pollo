using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pollo
{
    public partial class WebForm4 : System.Web.UI.Page
    {

        public List<double> Temperaturas { get; set; }
        public List<int> Minutos { get; set; }

        string linkServer = "Server=tcp:cyberbitchs.database.windows.net,1433;Initial Catalog=Primeiro_Banco;Persist Security Info=False;User ID=cyberbitchs;Password=Teste<code/>;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        protected void Page_Load(object sender, EventArgs e)
        {

            string cod_usuario = (string)Session["cod_usuario"];
            if (cod_usuario == null)
            {
                Response.Redirect("../index.aspx");
            }

            if (IsPostBack == false) {
                using (SqlConnection conexao = new SqlConnection(linkServer))
                {
                    conexao.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT tbc.nome_chocadeira,tbo.tempo_dia FROM Pollo_Chocadeira AS tbc, Pollo_Ovo AS tbo WHERE tbc.cod_usuario = "+cod_usuario+" AND tbo.cod_usuario = "+cod_usuario, conexao))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                txtChocadeira.Text = "Nome chocadeira: " + reader.GetString(0);
                                txtDiasRestantes.Text = "Tempo de funcionamento: " + reader.GetInt32(1);
                            }
                        }
                    }
                }
            }

            Temperaturas = new List<double>();
            Minutos = new List<int>();

            using (SqlConnection conexao = new SqlConnection(linkServer))
            {
                conexao.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT minuto,temperatura FROM Pollo_Media_Minuto", conexao))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            Minutos.Add(reader.GetInt32(0));
                            Temperaturas.Add(reader.GetDouble(1));
                        }
                    }
                }
            }
        }
    }
}