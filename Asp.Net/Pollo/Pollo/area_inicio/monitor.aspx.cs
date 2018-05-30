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
        public List<String> nomeChocadeira { get; set; }
        public List<double> temp { get; set; }
        public List<int> tempoDia { get; set; }
        public List<int> idChocadeira { get; set; }   
        protected void Page_Load(object sender, EventArgs e)
        {

            nomeChocadeira = new List<String>();
            temp = new List<double>();
            tempoDia = new List<int>();
            idChocadeira = new List<int>();

            using (SqlConnection conexao = new SqlConnection(linkServer))
            {
                conexao.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT tbc.cod_chocadeira, tbc.nome_chocadeira,tbo.tempo_dia,tbm.temperatura FROM Pollo_Chocadeira AS tbc, Pollo_Ovo AS tbo, Pollo_Media_Minuto AS tbm WHERE minuto = (SELECT MAX(minuto) FROM Pollo_Media_Minuto)", conexao))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            idChocadeira.Add(reader.GetInt32(0));
                            nomeChocadeira.Add(reader.GetString(1));
                            tempoDia.Add(reader.GetInt32(2));
                            temp.Add(reader.GetDouble(3));

                            //lblNomeChocadeira.Text = nome_chocadeira;
                            //lblDiasRestantes.Text = "Dias restantes: " + tempo_dia;
                            //lblTemp.Text = temp.ToString(System.Globalization.CultureInfo.InvariantCulture) + "º";
                        }

                    }
                }
            }
        }
    }
}