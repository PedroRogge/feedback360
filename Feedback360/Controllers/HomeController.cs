using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Feedback360.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
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
        public ActionResult Index()
        {
            if (AlunoLogado)
            {
                return RedirectToAction("Index", "Feedback");
            }
            else
            {
                return RedirectToAction("Logar", "Feedback");
            }
        }
    }
}
    
