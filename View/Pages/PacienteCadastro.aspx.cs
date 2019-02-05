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

    public partial class PacienteCadastro : System.Web.UI.Page
    {

        public void Page_Load(object sender, EventArgs e)
        {

            bindCidade();

        }

        public void btnCadastrarPaciente(object sender, EventArgs e)
        {

            try
            {

                Paciente paciente = new Paciente();
                paciente.Nome = nome.Text;
                paciente.IdCidade = Int32.Parse(idCidade.SelectedValue);

                PacienteDal pacienteDal = new PacienteDal();
                pacienteDal.salvar(paciente);

                nome.Text = "";
                idCidade.Text = "";

                string msg = "paciente " + paciente.Nome +
                             " cadastrado com sucesso";

                lblMensagem.Attributes.CssStyle.Add("color", "green");
                lblMensagem.Text = msg;

                //Thread.Sleep(5000);
                //Response.Redirect("/pages/pacienteCadastro.aspx");

            }
            catch (Exception erro)
            {

                lblMensagem.Text = erro.Message;
            }

        }

        public void bindCidade()
        {

            CidadeDal cidadeDal = new CidadeDal();
            List<Cidade> listaCidade = new List<Cidade>();

            listaCidade = cidadeDal.Listar();

            foreach (var especialidade in listaCidade)
            {

                idCidade.Items.Insert(0, new System.Web.UI.WebControls.ListItem(especialidade.Descricao, especialidade.Id.ToString()));

            }



        }

    }
}
