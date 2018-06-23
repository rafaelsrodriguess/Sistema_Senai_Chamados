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
        public ActionResult Login(LoginViewModel Login)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Erro = "Dados inválidos";

                return View();
            }
            //valida usuario
            if (Login.Email == "senai@br.senai.sp" && Login.Senha == "123456")
            {
                ViewBag.Autenticado = "Usuario Autenticado";
                //Redireciona para pagina de cadastro de usuário
                return RedirectToAction("Index", "Home");
            }
            else
            {
               TempData["Autenticado"] = "Usuario não Cadastrado";
                return RedirectToAction("CadastroUsuario");
            }
        }


        [HttpGet]
        public ActionResult CadastrarUsuario()
        {
            CadastrarUsuarioViewModel objcadastrarUsuario = new CadastrarUsuarioViewModel();
            // objcadastrarUsuarioViewModel.Nome = "Rafael Rodrigues";
            //objcadastrarUsuarioViewModel.Email = "rafaelsrodriguess@gmail.com";
            //return View(objcadastrarUsuarioViewModel);
            objcadastrarUsuario.Sexo = ListaSexo();


            return View(objcadastrarUsuario);
        }


        [HttpPost]
        public ActionResult CadastrarUsuario(CadastrarUsuarioViewModel usuario)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Erro = "Dados inválidos";
                return View();
            }
            usuario.Sexo = ListaSexo();

            //TODO:Efettuar cadastro no banco de dados
            return View(usuario);
        }

        private SelectList ListaSexo()
        {
            return new SelectList(
                new List<SelectListItem>
            {
            new SelectListItem { Text = "Masculino", Value = "1" },
            new SelectListItem { Text = "Feminino", Value = "2" },
        }, "Value", "Text");
        }
    }
}
    
