using Feedback360.Models;
using System;
using System.Web.Mvc;

namespace Feedback360.Controllers
{
    public class FeedbackController : Controller
    {
        public bool AlunoLogado
        {
            get
            {
                if (TempData["AlunoLogado"] != null)
                {
                    TempData.Keep("AlunoLogado");
                    return (bool)TempData["AlunoLogado"];
                }
                else
                    return false;
            }
            set
            {
                TempData["AlunoLogado"] = value;
            }
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

        public ActionResult Index()
        {
            if (AlunoLogado)
            {
                ComandosBancoDeDados comandos = new ComandosBancoDeDados();
                var listaDePessoas = comandos.BuscarPessoas();
                return View(listaDePessoas);
            }
            else
            {   
                return RedirectToAction("Logar");
            }
        }
        public ActionResult Carregar(Guid pessoaId)
        {
            if (AlunoLogado)
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
            else
            {
                return RedirectToAction("Logar");
            }
        }

        [HttpGet]
        public ActionResult Logar()
        {
            if (AlunoLogado)
            {
                return View();
            }
            else
            {
                return View();
            }
        }

        public ActionResult CriarFeedback()
        {
            if (AlunoLogado)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Logar");
            }
        }
        public ActionResult InserirFeedbackManter(Manter manter)
        {
            if (AlunoLogado)
            {
                ComandosBancoDeDados comandos = new ComandosBancoDeDados();
                comandos.InserirFeedbackManter(manter);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Logar");
            }
        }
        public ActionResult InserirFeedbackMudar(Mudar mudar)
        {
            if (AlunoLogado)
            {
                ComandosBancoDeDados comandos = new ComandosBancoDeDados();
                comandos.InserirFeedbackMudar(mudar);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Logar");
            }
        }
        public ActionResult InserirFeedbackMelhorar(Melhorar melhorar)
        {
            if (AlunoLogado)
            {
                ComandosBancoDeDados comandos = new ComandosBancoDeDados();
                comandos.InserirFeedbackMelhorar(melhorar);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Logar");
            }
        }

    }
}
