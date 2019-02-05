using System;
using System.Web;
using System.Web.UI;
using BLL.Model;
using DAL.Persistence;
using System.Threading;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace View.Pages
{
    public partial class CidadeCadastro : System.Web.UI.Page
    {

        public void Page_Load(object sender, EventArgs e){

            bindEstados();

        }

        public void btnCadastrarCidade(object sender, EventArgs e){

            try
            {

                Cidade cidade = new Cidade();
                cidade.Descricao = descricao.Text;
                cidade.IdEstado = Int32.Parse(idEstado.SelectedValue);

                CidadeDal cidadeDal = new CidadeDal();
                cidadeDal.salvar(cidade);

                descricao.Text = "";
                idEstado.Text = "";

                string msg = "Cidade de " + cidade.Descricao +
                             " cadastrada com sucesso";

                lblMensagem.Attributes.CssStyle.Add("color", "green");
                lblMensagem.Text = msg;

                //Thread.Sleep(5000);
                Response.Redirect("/pages/CidadeCadastro.aspx");

            }
            catch (Exception erro)
            {

                lblMensagem.Text = erro.Message;
            }

        }

        public void bindEstados(){

            EstadoDal estadoDal = new EstadoDal();
            List<Estado> listaEstado = new List<Estado>();

            listaEstado = estadoDal.Listar();
            
            foreach(var estado in listaEstado){

                idEstado.Items.Insert(0, new System.Web.UI.WebControls.ListItem(estado.Nome, estado.Id.ToString()));

            }



        }

    }
}