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
    public partial class MedicoCadastro : System.Web.UI.Page
    {

        public void Page_Load(object sender, EventArgs e){

            bindEspecialidade();

        }

        public void btnCadastrarMedico(object sender, EventArgs e)
        {

            try
            {

                Medico medico = new Medico();
                medico.Nome = nome.Text;
                medico.Crm = crm.Text;
                medico.IdEspecialidade = Int32.Parse(idEspecialidade.SelectedValue);

                MedicoDal medicoDal = new MedicoDal();
                medicoDal.salvar(medico);

                nome.Text = "";
                idEspecialidade.Text = "";

                string msg = "Medico " + medico.Nome +
                             " cadastrado com sucesso";

                lblMensagem.Attributes.CssStyle.Add("color", "green");
                lblMensagem.Text = msg;

                //Thread.Sleep(5000);
                //Response.Redirect("/pages/MedicoCadastro.aspx");

            }
            catch (Exception erro)
            {

                lblMensagem.Text = erro.Message;
            }

        }

        public void bindEspecialidade(){

            EspecialidadeDal especialidadeDal = new EspecialidadeDal();
            List<Especialidade> listaEspecialidade = new List<Especialidade>();

            listaEspecialidade = especialidadeDal.Listar();

            foreach (var especialidade in listaEspecialidade)
            {

                idEspecialidade.Items.Insert(0, new System.Web.UI.WebControls.ListItem(especialidade.Descricao, especialidade.Id.ToString()));

            }



        }

    }
}
