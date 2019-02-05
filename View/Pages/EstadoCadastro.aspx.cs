﻿using System;
using System.Web;
using System.Web.UI;
using BLL.Model;
using DAL.Persistence;
using System.Threading;

namespace View.Pages
{
    public partial class EstadoCadastro : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e){

            lblMensagem.Text = "Iniciando o cadastro";

        }

        public void btnCadastrarEstado(object sender, EventArgs e){

            try
            {

                Estado estado = new Estado();
                estado.Nome = nome.Text;
                estado.Sigla = sigla.Text;

                EstadoDal estadoDal = new EstadoDal();
                estadoDal.salvar(estado);

                nome.Text = "";
                sigla.Text = "";

                string msg = "Estado de " + estado.Nome +
                             " - " + estado.Sigla +
                             " foi cadastrado com sucesso";

                lblMensagem.Attributes.CssStyle.Add("color", "green");
                lblMensagem.Text = msg;

                //Thread.Sleep(5000);
                //Response.Redirect("/pages/EstadoCadastro.aspx");

            }
            catch (Exception erro)
            {

                lblMensagem.Text = erro.Message;
            }


        }

    }
}