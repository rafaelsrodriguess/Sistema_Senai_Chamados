
using Senai.Chamados.Data.Contexto;
using Senai.Chamados.Domain.Entidades;
using Senai.Chamados.Web.ViewModels;
using System;
using System.Collections.Generic;
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
            if (!ModelState.IsValid)
            {
                ViewBag.Erro = "Dados Inválidos";
                return View();
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
        public ActionResult CadastrarUsuario(CadastrarUsuarioViewModel usuario)
        {
            usuario.Sexo = ListaSexo();

            if (!ModelState.IsValid)
            {
                ViewBag.Erro = "Dados inválidos";
                return View(usuario);
            }
            SenaiChamadosDbContext context = new SenaiChamadosDbContext();
            UsuarioDomain usuarioBanco = new UsuarioDomain();
            try
            {
                usuarioBanco.Id = Guid.NewGuid();
                usuarioBanco.Nome = usuario.Nome;
                usuarioBanco.Email = usuario.Email;
                usuarioBanco.Senha = usuario.Senha;
                usuarioBanco.Telefone = usuario.Telefone;
                usuarioBanco.Cpf = usuario.Cpf.Replace(".", "").Replace(".", "");
                usuarioBanco.Cep = usuario.Cep.Replace(".", "");
                usuarioBanco.Logradouro = usuario.Logradouro;
                usuarioBanco.Numero = usuario.Numero;
                usuarioBanco.Complemento = usuario.Complemento;
                usuarioBanco.Bairro = usuario.Bairro;
                usuarioBanco.Cidade = usuario.Cidade;
                usuarioBanco.Estado = usuario.Estado;
                usuarioBanco.DataCriacao = DateTime.Now;
                usuarioBanco.DataAlteracao = DateTime.Now;
                context.Usuarios.Add(usuarioBanco);
                context.SaveChanges();
                TempData["Mensagem"] = "Usuário Cadastrado";
                return RedirectToAction("Login");
                return View(usuario);
            }
            catch (System.Exception ex)
            {
                ViewBag.Erro = ex.Message;
                return View(usuario);
            }
            finally
            {
                context = null;
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
    }
}
 
