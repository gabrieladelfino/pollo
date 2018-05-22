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

            Temperaturas = new List<double>();
            Minutos = new List<int>();

            using (SqlConnection conexao = new SqlConnection(linkServer))
            {
                conexao.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT temperatura, minuto FROM Pollo_Minuto", conexao))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            Temperaturas.Add(reader.GetDouble(0));
                            Minutos.Add(reader.GetInt32(1));
                        }
                    }
                }
            }
        }
    }
}