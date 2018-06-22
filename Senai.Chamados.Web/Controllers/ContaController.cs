using Senai.Chamados.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Senai.Chamados.Web.Controllers
{
    public class ContaController : Controller
    {
        // GET: Conta
        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel usuario)
        {

            return View();
        }
        [HttpGet]
        public ActionResult CadastrarUsuario()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CadastrarUsuario(CadastrarUsuarioViewModel usuario)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.Erro = "Dados invalidos";
                return View();
            }
            //TODO:Efettuar cadastro no banco de dados
            return View();
        }
    }
}