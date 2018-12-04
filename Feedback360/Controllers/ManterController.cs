using Feedback360.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Feedback360.Controllers
{
    public class ManterController : Controller
    {
        public ComandosBancoDeDados Comandos { get; set; }

        public ManterController()
        {
            Comandos = new ComandosBancoDeDados();
        }

        // GET: Manter
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CriarManter()
        {
            PreencherViewBagPessoa();
            return View();
        }

        public ActionResult SalvarManter(Manter manter)
        {
            if (ModelState.IsValid)
            {
                Comandos.InserirFeedbackManter(manter);
                return RedirectToRoute(new
                {
                    controller = "Feedback",
                    action = "Carregar",
                    pessoaId = manter.PessoaId
                });
            }
            PreencherViewBagPessoa();
            return View("CriarManter",manter);
        }

        public void PreencherViewBagPessoa()
        {
            ViewBag.Pessoas = Comandos.BuscarPessoas();
        }
    }
}