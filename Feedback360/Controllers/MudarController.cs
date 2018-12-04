using Feedback360.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Feedback360.Controllers
{
    public class MudarController : Controller
    {
        public ComandosBancoDeDados Comandos { get; set; }

        public MudarController()
        {
            Comandos = new ComandosBancoDeDados();
        }

        // GET: Manter
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CriarMudar()
        {
            PreencherViewBagPessoa();
            return View();
        }

        public ActionResult SalvarMudar(Mudar mudar)
        {
            if (ModelState.IsValid)
            {
                Comandos.InserirFeedbackMudar(mudar);
                return RedirectToRoute(new
                {
                    controller = "Feedback",
                    action = "Carregar",
                    pessoaId = mudar.PessoaId
                });
            }
            PreencherViewBagPessoa();
            return View("CriarMudar", mudar);
        }

        public void PreencherViewBagPessoa()
        {
            ViewBag.Pessoas = Comandos.BuscarPessoas();
        }
    }
}