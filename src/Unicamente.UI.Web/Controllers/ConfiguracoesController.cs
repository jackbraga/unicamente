using Microsoft.AspNetCore.Mvc;
using Unicamente.Application.Interfaces;

namespace Unicamente.UI.Web.Controllers
{
    public class ConfiguracoesController : Controller
    {
        private readonly ITipoImovelService _tipoImovelService;

        public ConfiguracoesController(ITipoImovelService tipoImovelService)
        {
            _tipoImovelService = tipoImovelService;
        }
        // GET: ConfiguracoesController
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult TipoImovel()
        //{
        //    var lista = _tipoImovelService.GetAll();
        //    return View(lista);
        //}

    }
}
