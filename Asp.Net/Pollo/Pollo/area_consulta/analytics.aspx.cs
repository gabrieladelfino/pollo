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
            #region Verificando se o usuario está logado
            string cod_usuario = (string)Session["cod_usuario"];
            if (cod_usuario == null)
            {
                Response.Redirect("../index.aspx");
            }
            #endregion

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

            PegarMaxMin();
            PegarMedia();
            PegarQuartil();
            PegarDesvModa();
        }

        protected void btnMaxMin_Click(object sender, EventArgs e)
        {
            if (btnMaxMin.Text.Equals("< Max >"))
            {
                btnMaxMin.Text = "< Min >";
                PegarMaxMin();
            }
            else
            {
                btnMaxMin.Text = "< Max >";
                PegarMaxMin();
            }
        }

        protected void btnQuartil_Click(object sender, EventArgs e)
        {
            if (btnQuartil.Text.Equals("< 1° Quartil >"))
            {
                btnQuartil.Text = "< 3° Quartil >";
                PegarQuartil();
            }
            else
            {
                btnQuartil.Text = "< 1° Quartil >";
                PegarQuartil();
            }
        }

        protected void btnMedia_Click(object sender, EventArgs e)
        {
            if (btnMedia.Text.Equals("< Média >"))
            {
                btnMedia.Text = "< Mediana >";
                PegarMedia();
            }
            else
            {
                btnMedia.Text = "< Média >";
                PegarMedia();
            }
        }

        protected void btnDesv_Click(object sender, EventArgs e)
        {
            if (btnDesv.Text.Equals("< Desv. Padrão >"))
            {
                btnDesv.Text = "< Moda >";
                PegarDesvModa();
            }
            else
            {
                btnDesv.Text = "< Desv. Padrão >";
                PegarDesvModa();
            }
        }

        public void PegarMaxMin()
        {
            using (SqlConnection conexao = new SqlConnection(linkServer))
            {
                conexao.Open();

                if (btnMaxMin.Text.Equals("< Max >"))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT ROUND(MAX(temperatura),2) FROM Pollo_Media_Minuto", conexao))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                lblMaxMin.Text = "" + reader.GetDouble(0);
                            }
                        }
                    }
                }
                else
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT ROUND(MIN(temperatura),2) FROM Pollo_Media_Minuto", conexao))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                lblMaxMin.Text = "" + reader.GetDouble(0);
                            }
                        }
                    }
                }
               
            }
        }

        public void PegarDesvModa()
        {
            using (SqlConnection conexao = new SqlConnection(linkServer))
            {
                conexao.Open();

                if (btnDesv.Text.Equals("< Desv. Padrão >"))
                {
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
                else
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 temperatura FROM Pollo_Media_Minuto GROUP BY temperatura HAVING COUNT(temperatura) > 1 ORDER BY temperatura DESC", conexao))
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
        }

        public void PegarMedia()
        {
            using (SqlConnection conexao = new SqlConnection(linkServer))
            {
                conexao.Open();

                if (btnMedia.Text.Equals("< Média >"))
                {
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
                else
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT PERCENTILE_CONT(0.50) WITHIN GROUP(ORDER BY temperatura) OVER (PARTITION BY 1) FROM Pollo_Media_Minuto", conexao))
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
        }

        public void PegarQuartil()
        {
            using (SqlConnection conexao = new SqlConnection(linkServer))
            {
                conexao.Open();

                if (btnQuartil.Text.Equals("< 1° Quartil >"))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT PERCENTILE_CONT(0.25) WITHIN GROUP(ORDER BY temperatura) OVER (PARTITION BY 1) FROM Pollo_Media_Minuto", conexao))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                lblQuartil.Text = "" + reader.GetDouble(0);
                            }
                        }
                    }
                }
                else
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT PERCENTILE_CONT(0.75) WITHIN GROUP(ORDER BY temperatura) OVER (PARTITION BY 1) FROM Pollo_Media_Minuto", conexao))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                lblQuartil.Text = "" + reader.GetDouble(0);
                            }
                        }
                    }
                }

            }
        }
    }
}



