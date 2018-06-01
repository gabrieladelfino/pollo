﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Pollo.area_usuario
{
    public partial class recuperacao_senha : System.Web.UI.Page
    {
        string linkserver = "Server=tcp:cyberbitchs.database.windows.net,1433;Initial Catalog=Primeiro_Banco;Persist Security Info=False;User ID=cyberbitchs;Password=Teste<code/>;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        int cod_pergunta;
        string pergunta;
        int cont_senha;
        int cod_user;
        int cont_resposta;

        protected void Page_Load(object sender, EventArgs e)
        {
            #region Verificação usuario logado
            string cod_usuario = (string)Session["cod_usuario"];
            if (cod_usuario != null)
            {
                Response.Redirect("index.aspx");
            }
            #endregion
            if (IsPostBack == false)
            {
                txtPergunta.Enabled = false;
                txtResposta.Enabled = false;
                txtNovaSenha.Enabled = false;
                txtConfirmarSenha.Enabled = false;
            }
        }

        protected void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection conexao = new SqlConnection(linkserver))
            {
                conexao.Open();
                #region Identificando usuario e obtendo o codigo da pergunta
                using (SqlCommand cmd = new SqlCommand("SELECT cod_usuario, cod_pergunta FROM Pollo_Usuario WHERE user_pollo = '" + txtUsuario.Text + "' OR email = '" + txtUsuario.Text + "'", conexao))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            cod_user = reader.GetInt32(0);
                            cod_pergunta = reader.GetInt32(1);
                            txtResposta.Enabled = true;
                        }
                    }
                }
                #endregion
                #region Obtendo a pergunta com base no codigo
                using (SqlCommand cmd = new SqlCommand("SELECT pergunta FROM Pollo_Pergunta WHERE cod_pergunta =" + cod_pergunta, conexao))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            pergunta = reader.GetString(0);
                        }
                    }
                }
                txtPergunta.Text = pergunta;
                #endregion
            }
        }
        protected void txtResposta_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection conexao = new SqlConnection(linkserver))
            {
                conexao.Open();
                #region Verificando se a resposta está correta
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Pollo_Usuario WHERE user_pollo = '" + txtUsuario.Text + "' OR email = '" + txtUsuario.Text + "' AND rec_resposta = '" + txtResposta.Text + "'", conexao))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            cont_resposta = 1;
                            txtResposta.Enabled = true;
                        }
                    }
                }
            }
                #endregion
                #region Verificando se a resposta coincide
                if (cont_resposta == 1)
            {
                txtNovaSenha.Enabled = true;
                txtConfirmarSenha.Enabled = true;
            }
            #endregion
        }

       
        protected void btnRecuperar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexao = new SqlConnection(linkserver))
            {
                conexao.Open();
                #region Update nova senha
                if (txtNovaSenha.Text != txtConfirmarSenha.Text)
                {
                    txtConfirmarSenha.Focus();
                    return;
                }
                else
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Pollo_Usuario WHERE senha = '" + txtNovaSenha.Text + "' AND cod_usuario = " + cod_user, conexao))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
         
                           while (reader.Read() == true)
                            {
                                cont_senha = 1;
                            }
                        }
                    }
                    if (cont_senha == 1)
                    {
                        txtNovaSenha.Focus();
                        return;
                        //DA UM JEITO DE AVISAR O USUARIO QUE ESSA ERA UMA SENHA QUE ELE JÁ UTILIZOU
                    }
                    else
                    {
                        using (SqlCommand cmd = new SqlCommand("UPDATE Pollo_Usuario SET senha = '" + txtNovaSenha.Text + "' WHERE cod_usuario =" + cod_user, conexao))
                        {
                        }
                    }

                    #endregion
                }
            }
        }
    }
}