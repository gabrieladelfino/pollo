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

        public int contador = 1, tamanho, tempo;
        public string tabela, campo_tabela;

        string linkServer = "Server=tcp:cyberbitchs.database.windows.net,1433;Initial Catalog=Primeiro_Banco;Persist Security Info=False;User ID=cyberbitchs;Password=Teste<code/>;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        protected void Page_Load(object sender, EventArgs e)
        {
            #region Verificando se o usuario está logado
            string cod_usuario = (string)Session["cod_usuario"];

            if (cod_usuario == null)
            {
                Response.Redirect("../index.aspx");
            }
            #endregion

            #region 'Chamando metodos para listar temperaturas'
            PegarMax();
            PegarMin();
            PegarMedia();
            PegarMediana();
            PegarDesv();
            PegarModa();
            PegarPrimeiroQuartil();
            PegarTerceiroQuartil();
            #endregion
        }

        #region 'Carregando ddl'
        protected void ddlTempo_Load(object sender, EventArgs e)
        {
                using (SqlConnection conexao = new SqlConnection(linkServer))
                {
                    conexao.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT minuto FROM Contador", conexao))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                contador = reader.GetInt32(0);
                            }
                        }
                    }
                }

                tabela = "Pollo_Media_Minuto";
                campo_tabela = "minuto";
                tempo = 60;
                lblTempo.Text = "minuto";

                if (contador / tempo == 0)
                {
                    tamanho = 1;
                    Listar();
                }
                else if (contador / tempo == 1)
                {
                    tamanho = 61;
                    Listar();
                }
                else if (contador / tempo == 2)
                {
                    tamanho = 121;
                    Listar();
                }
            }
        #endregion

        #region 'Selecionando Parâmetro'
        protected void SelecionarParametro(object sender, EventArgs e)
        {
            using (SqlConnection conexao = new SqlConnection(linkServer))
            {
                conexao.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT "+ campo_tabela +" FROM Contador", conexao))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            contador = reader.GetInt32(0);
                        }
                    }
                }
            }

            if (ddlTempo.SelectedValue == "0")
            {
                tabela = "Pollo_Media_Minuto";
                campo_tabela = "minuto";
                tempo = 60;
                lblTempo.Text = "minuto";

                if (contador / tempo == 0)
                {
                    tamanho = 1;
                    Listar();
                }
                else if (contador / tempo == 1)
                {
                    tamanho = 61;
                    Listar();
                }
                else if (contador / tempo == 2)
                {
                    tamanho = 121;
                    Listar();
                }
            }

            if (ddlTempo.SelectedValue == "1")
            {
                tabela = "Pollo_Media_Hora";
                campo_tabela = "hora";
                tempo = 24;
                lblTempo.Text = "hora";

                if (contador / tempo == 0)
                {
                    tamanho = 1;
                    Listar();
                }
                else if (contador / tempo == 1)
                {
                    tamanho = 25;
                    Listar();
                }
                else if (contador / tempo == 2)
                {
                    tamanho = 49;
                    Listar();
                }
            }

            if (ddlTempo.SelectedValue == "2")
            {
                tabela = "Pollo_Media_Dia";
                campo_tabela = "dia";
                tempo = 30;
                lblTempo.Text = "dia";

                if (contador / tempo == 0)
                {
                    tamanho = 1;
                    Listar();
                }
                else if (contador / tempo == 1)
                {
                    tamanho = 31;
                    Listar();
                }
                else if (contador / tempo == 2)
                {
                    tamanho = 61;
                    Listar();
                } 
            }
        }
        #endregion

        #region 'Listando temperaturas'
        public void Listar() { 
            
            if(tabela == null)
            {
                tabela = "Pollo_Media_Minuto";
                campo_tabela = "minuto";
                tempo = 60;

                using (SqlConnection conexao = new SqlConnection(linkServer))
                {
                    conexao.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT "+ campo_tabela +" FROM Contador", conexao))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                contador = reader.GetInt32(0);
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

                using (SqlCommand cmd = new SqlCommand("SELECT "+ campo_tabela +", temperatura FROM " + tabela +" WHERE "+ campo_tabela + " <= " + contador +" AND "+ campo_tabela+" >= "+tamanho, conexao))
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
        #endregion

        #region 'Maxima'
        public void PegarMax()
        {
            using (SqlConnection conexao = new SqlConnection(linkServer))
            {
                conexao.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT ROUND(MAX(temperatura),2) FROM Pollo_Media_Minuto", conexao))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            lblMax.Text = "" + reader.GetDouble(0);
                        }
                    }
                }
            }
        }
        #endregion

        #region 'Minima'
        public void PegarMin()
        {
            using (SqlConnection conexao = new SqlConnection(linkServer))
            {
                conexao.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT ROUND(MIN(temperatura),2) FROM Pollo_Media_Minuto", conexao))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            lblMin.Text = "" + reader.GetDouble(0);
                        }
                    }
                }
            }
        }
        #endregion
 
        #region 'Desvio Padrão'
        public void PegarDesv()
        {
            using (SqlConnection conexao = new SqlConnection(linkServer))
            {
                conexao.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT ROUND(STDEV(temperatura),2) FROM Pollo_Media_Minuto", conexao))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            lblDesv.Text = "" + reader.GetDouble(0);
                        }
                    }
                }
                
            }
        }
        #endregion

        #region 'Moda'
        public void PegarModa()
        {
            using (SqlConnection conexao = new SqlConnection(linkServer))
            {
                conexao.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 temperatura FROM Pollo_Media_Minuto GROUP BY temperatura HAVING COUNT(temperatura) > 1 ORDER BY temperatura DESC", conexao))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            lblModa.Text = "" + reader.GetDouble(0);
                        }
                    }
                }
            }

        }
        #endregion

        #region 'Média'
        public void PegarMedia()
        {
            using (SqlConnection conexao = new SqlConnection(linkServer))
            {
                conexao.Open();
                
                using (SqlCommand cmd = new SqlCommand("SELECT ROUND(AVG(temperatura),2) FROM Pollo_Media_Minuto", conexao))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            lblMedia.Text = "" + reader.GetDouble(0);
                        }
                    }
                }
                
            }
        }
        #endregion

        #region 'Mediana'
            public void PegarMediana()
        {
            using (SqlConnection conexao = new SqlConnection(linkServer))
            {
                conexao.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT PERCENTILE_CONT(0.50) WITHIN GROUP(ORDER BY temperatura) OVER (PARTITION BY 1) FROM Pollo_Media_Minuto", conexao))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            lblMediana.Text = "" + reader.GetDouble(0);
                        }
                    }
                }
            }
        }
        #endregion

        #region 'Primeiro Quartil'
        public void PegarPrimeiroQuartil()
        {
            using (SqlConnection conexao = new SqlConnection(linkServer))
            {
                conexao.Open();
                
                using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT PERCENTILE_CONT(0.25) WITHIN GROUP(ORDER BY temperatura) OVER (PARTITION BY 1) FROM Pollo_Media_Minuto", conexao))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            lblPQuartil.Text = "" + reader.GetDouble(0);
                        }
                    }
                }
                
            }
        }
        #endregion

        #region 'Terceiro Quartil'
        public void PegarTerceiroQuartil()
        {
            using (SqlConnection conexao = new SqlConnection(linkServer))
            {
                conexao.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT PERCENTILE_CONT(0.75) WITHIN GROUP(ORDER BY temperatura) OVER (PARTITION BY 1) FROM Pollo_Media_Minuto", conexao))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            lblTQuartil.Text = "" + reader.GetDouble(0);
                        }
                    }
                }
            }
        }
        #endregion

    }
}



