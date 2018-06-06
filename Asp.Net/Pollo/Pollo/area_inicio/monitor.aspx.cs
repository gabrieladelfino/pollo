using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


namespace Pollo
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string linkServer = "Server=tcp:cyberbitchs.database.windows.net,1433;Initial Catalog=Primeiro_Banco;Persist Security Info=False;User ID=cyberbitchs;Password=Teste<code/>;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        int i;
        string final;
        int tempo = 0;
        double temperatura_atual, temperatura_ideal;
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
            #region Verificando se o usuario está logado
            string cod_usuario = (string)Session["cod_usuario"];
            if (cod_usuario == null)
            {
                Response.Redirect("../index.aspx");
            }
            #endregion

            if (IsPostBack == false) {
                ListarChocadeiras();
                CriarDiv();
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

                Button botoes = new Button();
                botoes.CssClass = "botoes";
                botoes.Click += CriarBotoes;
                monitor.Controls.Add(botoes);

                Label lblTemperatura = new Label();
                lblTemperatura.Text = "" + cc.ElementAt(i).temperatura;

                if ((temperatura_ideal - 1) < temperatura_atual){
                    lblTemperatura.CssClass = "titulos_monitor_temp_frio";
                }else if ((temperatura_ideal+1) > temperatura_atual)
                {
                    lblTemperatura.CssClass = "titulos_monitor_temp_quente";
                }
                else
                {
                    lblTemperatura.CssClass = "titulos_monitor_temp_neutro";
                }

                monitor.Controls.Add(lblTemperatura);

                Label lblTempoRestante = new Label();
                lblTempoRestante.Text = "Dias restantes: " + cc.ElementAt(i).tempoDiaOvo;
                lblTempoRestante.CssClass = "titulos_monitor_tempo";
                monitor.Controls.Add(lblTempoRestante);

                monitores.Controls.Add(monitor);
            }
        }


        protected void CriarBotoes(object sender, EventArgs e)
        {
            Panel p = new Panel();
            p.CssClass = "monitor";
            monitores.Controls.Add(p);
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

                using (SqlCommand cmd = new SqlCommand("SELECT tbc.cod_chocadeira, tbc.nome_chocadeira, tbo.tempo_dia, tbm.temperatura, tbo.temperatura FROM Pollo_Chocadeira AS tbc, Pollo_Ovo AS tbo, Pollo_Usuario AS tbu, Pollo_Media_Minuto AS tbm WHERE tbu.cod_usuario = " + cod_user + " AND tbo.cod_usuario = " + cod_user + " AND tbm.minuto = (SELECT MAX(minuto) FROM Pollo_Media_Minuto)", conexao))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            c.codChocadeira = reader.GetInt32(0);
                            c.nomeChocadeira = reader.GetString(1);
                            c.temperatura = reader.GetDouble(3);
                            temperatura_atual = reader.GetDouble(3);
                            temperatura_ideal = reader.GetDouble(4);
                            c.tempoDiaOvo =  DiasRestantes();
                            cc.Add(c);
                        }
                    }
                }
                
            }
        }

        public int DiasRestantes()
        {
            using (SqlConnection conexao = new SqlConnection(linkServer))
            {
                conexao.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT CONVERT (VARCHAR, final) FROM Pollo_Chocadeira WHERE cod_chocadeira = "+c.codChocadeira, conexao))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            final = reader.GetString(0);
                        }
                    }

                }

                using (SqlCommand cmd = new SqlCommand("SELECT CONVERT (INT, '" + final + "' - GETDATE())", conexao))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            tempo = reader.GetInt32(0);
                        }
                    }
                }
            }

            return tempo;
        }

        protected void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
          
        }

       
    }
}