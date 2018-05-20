using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pollo.area_consulta
{
   
    public partial class consulta : System.Web.UI.Page
    {

        string linkServer = "Server=tcp:cyberbitchs.database.windows.net,1433;Initial Catalog=Primeiro_Banco;Persist Security Info=False;User ID=cyberbitchs;Password=Teste<code/>;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public struct Temperatura
        {

            public Color cor;
            public string hora;
            public string temp;
            public double max;
            public double min;
        }

        protected void criarGrafico(object sender, EventArgs e)
        {
            int total = 0, i = 0;
            int x = 100, y = 20;

            //criando nossa "folha de desenho"
            Bitmap imagem = new Bitmap(350, 100, PixelFormat.Format32bppArgb);

            //dizendo onde ela está
            Graphics grafico = Graphics.FromImage(imagem);

            //pintando o fundo
            grafico.Clear(Color.White);


            //definindo nossa temperatura

            Temperatura[] t = new Temperatura[1];

            t[0].hora = "12h00";
            t[0].temp = "25.5";
            t[0].cor = Color.Aquamarine;
            t[0].max = 5;
            t[0].min = 1;

            for (i = 0; i < t.Length; i++)
            {
                //nosso retangulo com os respectivos atributos: cor, x, y, largura, altura
                grafico.FillRectangle(new SolidBrush(Color.Aquamarine), 220, 20, 60, 30);

                //desenhando nosso grafico com as seguintes informações: hora,fonte,pincel,x,y
                grafico.DrawString(t[i].hora, new Font("arial", 12, FontStyle.Regular), Brushes.Black, 220, 25);

                //nosso retangulo com os respectivos atributos: cor, x, y, largura, altura
                grafico.FillRectangle(new SolidBrush(Color.Red), 20, 20, 200, 30);

                //desenhando nosso grafico com as seguintes informações: temperatura,fonte,pincel,x,y
                grafico.DrawString(t[i].temp, new Font("arial", 12, FontStyle.Regular), Brushes.Black, 20, 25);

            }

            //desenhando nosso grafico
            //grafico.DrawString("Pollo - 2018", new Font("Arial", 8, FontStyle.Regular), Brushes.Black, 950, 900);


            //apresentando pro navegador como vai ser nosso grafico
            Response.Clear();
            Response.ClearHeaders();
            Response.ContentType = "image/png";

            //falando pro grafico como ele deve se comportar no navegador
            imagem.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Png);
            imagem.Dispose();
        }
    }
}