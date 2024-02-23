using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol.Plugins;
using Unicamente.Application.DTOs;
using Unicamente.Application.Interfaces;
using Unicamente.Domain.Entities;
using Unicamente.UI.Web.Models;
using System.Diagnostics;

namespace Unicamente.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger,   IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        public IActionResult Index()

        {
            List<SelectListItem> tipoPessoa = new List<SelectListItem>();
            tipoPessoa.Add(new SelectListItem { Text = "Física", Value = "1" });
            tipoPessoa.Add(new SelectListItem { Text = "Jurídica", Value = "2" });
            ViewBag.TipoPessoa = tipoPessoa;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Cadastro()
        {

            //_notyf.Custom("Custom Notification - closes in 5 seconds.", 5, "whitesmoke", "fa fa-gear");
            return View();
        }

        //[HttpPost]
        //public IActionResult EmailContato(EmailContatoViewModel contato)
        //{
        //    try
        //    {
        //        _investidorService.EnviaEmailContato(contato.Nome, contato.Email, contato.Telefone, contato.Assunto, contato.Mensagem);

        //        return Json(new { success = true, icone = "success", titulo = "Recebemos sua mensagem!", mensagem = "Aguarde que em breve um especialista entrará em contato." });

        //    }
        //    catch (Exception ex)
        //    {

        //        return Json(new { success = false, message = ex.Message });
        //    }
        //}


        //[HttpPost]
        //public IActionResult Imovel(ImovelViewModel imovel)
        //{
        //    var imovelDto = _mapper.Map<ImovelDTO>(imovel);
        //    _imovelService.Add(imovelDto);

        //    return RedirectToAction("Imovel");
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}


    }
}