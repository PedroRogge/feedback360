
using Feedback360.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Feedback360.Controllers
{
    public class FeedbackController : Controller
    {
        public bool AlunoLogado { get; private set; }

        public ActionResult Index()
        {
            ComandosBancoDeDados comandos = new ComandosBancoDeDados();
            var listaDePessoas = comandos.BuscarPessoas();
            return View(listaDePessoas);
        }
        public ActionResult CarregarFeed(Guid pessoaId)
        {
            ComandosBancoDeDados comandos = new ComandosBancoDeDados();
            var pessoa = comandos.BuscarPessoaPorPessoaId(pessoaId);
            var manter = comandos.BuscarManterPorPessoaId(pessoaId);
            var mudar = comandos.BuscarMudarPorPessoaId(pessoaId);
            var melhorar = comandos.BuscarMelhorarPorPessoaId(pessoaId);

            FeedbackCompleto feedback = new FeedbackCompleto();
            feedback.Pessoa = pessoa;
            feedback.Manter = manter;
            feedback.Mudar = mudar;
            feedback.Melhorar = melhorar;

            if (feedback.Manter.Count > feedback.Mudar.Count
                && feedback.Manter.Count > feedback.Melhorar.Count)
                feedback.MaxCount = feedback.Manter.Count;

            if (feedback.Mudar.Count > feedback.Manter.Count
               && feedback.Mudar.Count > feedback.Melhorar.Count)
                feedback.MaxCount = feedback.Mudar.Count;

            if (feedback.Melhorar.Count > feedback.Manter.Count
               && feedback.Melhorar.Count > feedback.Mudar.Count)
            {
                feedback.MaxCount = feedback.Melhorar.Count;
            }


            return View(feedback);
        }

        [HttpGet]
        public ActionResult Logar()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Logar(Login login)
        {
            ComandosBancoDeDados comandos = new ComandosBancoDeDados();
            var usuario = comandos.BuscarUsuario(login);

            if (usuario != null)
            {
                AlunoLogado = true;
                return RedirectToAction("Index/Home");
            }
            else
            {
                TempData["ErroAoLogar"] = "Usuário ou senha inválidos";
                return View();
            }
        }
    }
}
