using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Senai.Chamados.Web.Controllers
{
    public class PerfilController : Controller
    {
        // GET: Perfis
        public ActionResult AlterarSenha()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AlterarSenha(AlterarSenhaViewModel senha)
        {

            return RedirectToAction("Index", "Usuario");
        }
    }
}