using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pollo
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string linkServer = "Server=tcp:cyberbitchs.database.windows.net,1433;Initial Catalog=Primeiro_Banco;Persist Security Info=False;User ID=cyberbitchs;Password=Teste<code/>;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public List<double> Temperatura { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            double temp;
            string nome_chocadeira;
            int tempo_dia;

            using (SqlConnection conexao = new SqlConnection(linkServer))
            {
                conexao.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT tbc.nome_chocadeira,tbo.tempo_dia,tbm.temperatura FROM Pollo_Chocadeira AS tbc, Pollo_Ovo AS tbo, Pollo_Media_Minuto AS tbm WHERE cod_minuto = (SELECT MAX(cod_minuto) FROM Pollo_Media_Minuto)", conexao))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            nome_chocadeira = (reader.GetString(0));
                            tempo_dia = (reader.GetInt32(1));
                            temp = (reader.GetDouble(2));

                            lblNomeChocadeira.Text = nome_chocadeira;
                            lblDiasRestantes.Text = "Dias restantes: " + tempo_dia;
                            lblTemp.Text = temp + "º";
                        }

                    }
                }
            }
        }
    }
}