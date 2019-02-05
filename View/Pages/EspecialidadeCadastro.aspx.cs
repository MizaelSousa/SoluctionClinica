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

    public partial class EspecialidadeCadastro : System.Web.UI.Page
    {

        public void btnCadastrarEspecialidade(object sender, EventArgs e)
        {

            try
            {

                Especialidade especialidade = new Especialidade();
                especialidade.Descricao = descricao.Text;

                EspecialidadeDal especialidadeDal = new EspecialidadeDal();
                especialidadeDal.salvar(especialidade);

                descricao.Text = "";

                string msg = "Especialidade " + especialidade.Descricao +
                             " cadastrada com sucesso";

                lblMensagem.Attributes.CssStyle.Add("color", "green");
                lblMensagem.Text = msg;

                //Thread.Sleep(5000);
                //Response.Redirect("/pages/EspecialidadeCadastro.aspx");

            }
            catch (Exception erro)
            {

                lblMensagem.Text = erro.Message;
            }

        }

    }
}
