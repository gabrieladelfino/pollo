using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Pollo
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string linkServer = "Server=tcp:cyberbitchs.database.windows.net,1433;Initial Catalog=Primeiro_Banco;Persist Security Info=False;User ID=cyberbitchs;Password=Teste<code/>;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        int i;
        Chocadeira c;
        List<Chocadeira> cc;

        public struct Chocadeira
        {
            public string nomeChocadeira;
            public int codChocadeira;
            public int tempoDiaOvo;
            public double temperatura;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false) {
                ListarChocadeiras();
                CriarDiv();
            }
            else
            {

            }
           
        }

        public void CriarDiv(){
            for (i= 0; i<cc.Count; i++)
            {
                Panel monitor = new Panel();
                monitor.CssClass = "monitor";

                Label lblNome = new Label();
                lblNome.Text = ""+cc.ElementAt(i).nomeChocadeira;
                lblNome.CssClass = "titulos_monitor";
                monitor.Controls.Add(lblNome);

                Label lblTemperatura = new Label();
                lblTemperatura.Text = "" + cc.ElementAt(i).temperatura;
                lblTemperatura.CssClass = "titulos_monitor_temp";
                monitor.Controls.Add(lblTemperatura);

                Label lblTempoRestante = new Label();
                lblTempoRestante.Text = "" + cc.ElementAt(i).tempoDiaOvo;
                lblTempoRestante.CssClass = "titulos_monitor";
                monitor.Controls.Add(lblTempoRestante);

                monitores.Controls.Add(monitor);
            }
        }

        public void ListarChocadeiras()
        {
            string cod_usuario = (string)Session["cod_usuario"];
            int cod_user = Convert.ToInt32(cod_usuario);

            c = new Chocadeira();
            cc = new List<Chocadeira>();

            using (SqlConnection conexao = new SqlConnection(linkServer))
            {
                conexao.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT tbc.cod_chocadeira, tbc.nome_chocadeira, tbo.tempo_dia, tbm.temperatura FROM Pollo_Chocadeira AS tbc, Pollo_Ovo AS tbo, Pollo_Usuario AS tbu, Pollo_Media_Minuto AS tbm WHERE tbu.cod_usuario = " + cod_user + " AND tbo.cod_usuario = " + cod_user + " AND tbm.minuto = (SELECT MAX(minuto) FROM Pollo_Media_Minuto)", conexao))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            c.codChocadeira = reader.GetInt32(0);
                            c.nomeChocadeira = reader.GetString(1);
                            c.tempoDiaOvo = reader.GetInt32(2);
                            c.temperatura = reader.GetDouble(3);
                            cc.Add(c);
                        }
                    }
                }
            }
        }
        
    }
}