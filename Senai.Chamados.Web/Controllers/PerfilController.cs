using Senai.Chamados.Data.Repositorios;
using Senai.Chamados.Domain.Entidades;
using Senai.Chamados.Web.ViewModels.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Senai.Chamados.Web.Controllers
{
    [Authorize]
    public class PerfilController : Controller
    {
        private object objRepoUsuario;

        // GET: Perfis
        public ActionResult AlterarSenha()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AlterarSenha(AlterarSenhaViewModel senha)
        {
            try
            {

                if(!ModelState.IsValid)
                {
                    ViewBag.Erro = "Dados inválidos. Vereifique!";
                }

                //Obtem as Claims do usuario logado
                var identity = User.Identity as ClaimsIdentity;

                //Pega o valor do Id do usuário
                var id = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
                var telefone = identity.Claims.FirstOrDefault(x => x.Type == "Telefone").Value;
                using (UsuarioRepositorio objRepoUsuario = new UsuarioRepositorio())
                {
                    UsuarioDomain objUsuario = objRepoUsuario.BuscarPorID(new Guid(id));

                    if (senha.SenhaAtual !=objUsuario.Senha)
                    {
                        ModelState.AddModelError("SenhaAtual", "Senha incorreta");
                        return View();

                    }

                    objUsuario.Senha = senha.NovaSenha;
                    objRepoUsuario.Alterar(objUsuario);
                    TempData["Sucesso"] = "Senha Alterada";
                    return RedirectToAction("Index", "Usuario");
                }
                    return RedirectToAction("Index", "Usuario");
            }
            catch (System.Exception ex)
            {
                ViewBag.Erro = "Ocorreu um erro" + ex.Message;
                return View();
            }
        }
    }
}