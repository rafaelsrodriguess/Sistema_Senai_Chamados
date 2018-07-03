
using AutoMapper;
using Senai.Chamados.Data.Contexto;
using Senai.Chamados.Data.Repositorios;
using Senai.Chamados.Domain.Entidades;
using Senai.Chamados.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Security.Claims;
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
        [ValidateAntiForgeryToken]

        public ActionResult Login(LoginViewModel Login)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Erro = "Dados Inválidos";
                return View();
            }

            using (UsuarioRepositorio _repUsuario = new UsuarioRepositorio()) 
            {
                UsuarioDomain UsuarioBanco = _repUsuario.Login(Login.Email, Login.Senha);
                if(UsuarioBanco !=null)
                {
                    var identity = new ClaimsIdentity(new[]
                    { new Claim(ClaimTypes.Name,UsuarioBanco.Nome),
                      new Claim(ClaimTypes.Email,UsuarioBanco.Email),
                      new Claim(ClaimTypes.PrimarySid,UsuarioBanco.Id.ToString()),
                      new Claim(ClaimTypes.NameIdentifier,UsuarioBanco.Id.ToString())
                    }, "ApplicationCookie");

                    Request.GetOwinContext().Authentication.SignIn(identities: identity);
                  return  RedirectToAction("Index","Usuario");

                }
                else
                {
                    ViewBag.Erro = "Usuario ou  senha inválidos. Tente novamente";
                }
            }
            //Valida Usuário
            if (Login.Email == "senai@br.senai.sp" && Login.Senha == "123456")
            {
                TempData["Autenticado"] = "Usuário Autenticado";
                //Redireciona para página Home
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Autenticado = "Usuário não cadastrado";
                //Redireciona para página de cadastro de usuário
                return RedirectToAction("CadastrarUsuario");
            }
        }

        [HttpGet]
        public ActionResult CadastrarUsuario()
        {
            CadastrarUsuarioViewModel objCadastrarUsuario = new CadastrarUsuarioViewModel();
            //objCadastrarUsuario.Nome = "Fernando Henrique";
            //objCadastrarUsuario.Email = "fernando.guerra@corujasdev.com.br";

            objCadastrarUsuario.Sexo = ListaSexo();


            return View(objCadastrarUsuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastrarUsuario(CadastrarUsuarioViewModel usuario)
        {
            usuario.Sexo = ListaSexo();

            if (!ModelState.IsValid)
            {
                ViewBag.Erro = "Dados inválidos";
                return View(usuario);
            }
            //SenaiChamadosDbContext context = new SenaiChamadosDbContext();
            UsuarioDomain usuarioBanco = new UsuarioDomain();
            try
            {
                //usuarioBanco.Id = Guid.NewGuid();
                //usuarioBanco.Nome = usuario.Nome;
               // usuarioBanco.Email = usuario.Email;
                //usuarioBanco.Senha = usuario.Senha;
               // usuarioBanco.Telefone = usuario.Telefone;
                usuario.Cpf = usuario.Cpf.Replace(".", "").Replace(".", "");
                usuario.Cep = usuario.Cep.Replace(".", "");
               // usuarioBanco.Logradouro = usuario.Logradouro;
               // usuarioBanco.Numero = usuario.Numero;
               // usuarioBanco.Complemento = usuario.Complemento;
               // usuarioBanco.Bairro = usuario.Bairro;
               // usuarioBanco.Cidade = usuario.Cidade;
               // usuarioBanco.Estado = usuario.Estado;
               // usuarioBanco.DataCriacao = DateTime.Now;
               // usuarioBanco.DataAlteracao = DateTime.Now;

                using (UsuarioRepositorio _repUsuario = new UsuarioRepositorio())
                {
                    _repUsuario.Inserir(Mapper.Map<CadastrarUsuarioViewModel, UsuarioDomain>(usuario));
                }
                    TempData["Mensagem"] = "Usuário Cadastrado";
                return RedirectToAction("Login");
                
            }
            catch (System.Exception ex)
            {
                ViewBag.Erro = ex.Message;
                return View(usuario);
            }
            finally
            {
                //context = null;
                usuarioBanco = null;
            }
            
        }

        private SelectList ListaSexo()
        {
            return new SelectList(
                    new List<SelectListItem>
                    {
                        new SelectListItem { Text = "Masculino", Value = "1"},
                        new SelectListItem { Text= "Feminino", Value = "2"},
                    }, "Value", "Text");
        }
        [HttpGet]
        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut("ApplicationCookie");
            return RedirectToAction("Login");
        }
    }
}
 
