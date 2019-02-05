﻿using System;
using System.Web;
using System.Web.UI;
using BLL.Model;
using DAL.Persistence;

namespace View.Pages
{

    public partial class EspecialidadeLista : System.Web.UI.Page
    {
        public void Page_Load(Object sender, EventArgs e){
            EspecialidadeDal especialidadeDal = new EspecialidadeDal();
            gridListaEspecialidade.DataSource = especialidadeDal.Listar();
            gridListaEspecialidade.DataBind();

        }
    }
}
