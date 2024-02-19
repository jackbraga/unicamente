using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Unicamente.Application.DTOs;
using Unicamente.Application.ExternalServices.Correios;
using Unicamente.Application.Interfaces;
using Unicamente.UI.Web.Models;

namespace Unicamente.UI.Web.Controllers
{
    public class InvestidorController : Controller
    {
        private readonly IInvestidorService _investidorService;
        private readonly ILogger<InvestidorController> _logger;
        private readonly IMapper _mapper;
        private readonly ICorreios _correios;

        public InvestidorController(IInvestidorService investidorService, ILogger<InvestidorController> logger, IMapper mapper, ICorreios correios)
        {
            _investidorService = investidorService;
            _logger = logger;
            _mapper = mapper;
            _correios = correios;
        }

        // GET: InvestidorController
        public ActionResult Index()
        {
            int? idInvestidor = HttpContext.Session.GetInt32("ID");
            if (idInvestidor == null)
                return RedirectToAction("Index", "Home");

            var investidor = _investidorService.GetById(idInvestidor);
            //ConsultaCEP("02228000");
            return View(investidor);
        }

        // GET: InvestidorController/Details/5
        public ActionResult Details(int id)
        {
            var investidor = _investidorService.GetById(id);
            return View(investidor);
        }

        // GET: InvestidorController/Create
        public ActionResult Create()
        {
            ViewBag.TiposDocumento = _investidorService.GetAllTiposDocumento();
            return View();
        }

        // POST: InvestidorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TelaCadastroViewModel investidor)
        {
            try
            {

                var investidorDTO = _mapper.Map<InvestidorDTO>(investidor);

                int idInvestidor = _investidorService.Add(investidorDTO);
                HttpContext.Session.SetInt32("ID", idInvestidor);

                return Json(new { success = true, message = 
                    "Oba! Deu tudo certo!" +
                    "Agora, acesse seu e-mail e confirme seu cadastro para aproveitar o melhor da multipropriedade" });

            }

            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }

        }

        // GET: InvestidorController/Edit/5
        public ActionResult Edit(int id)
        {
            var investidor = _investidorService.GetById(id);
            ViewBag.TiposDocumento = _investidorService.GetAllTiposDocumento();
            return View(investidor);
        }

        // POST: InvestidorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(InvestidorDTO investidor)
        {
            try
            {

                _investidorService.Update(investidor);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InvestidorController/Delete/5
        public ActionResult Delete(int id)
        {
            var investidor = _investidorService.GetById(id);
            return View(investidor);
        }

        // POST: InvestidorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(InvestidorDTO investidor)
        {
            try
            {
                _investidorService.Remove(investidor.ID);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult MinhaConta()
        {
            int? idInvestidor = HttpContext.Session.GetInt32("ID");
            if (idInvestidor == null)
                return RedirectToAction("Index", "Home");

            var investidor = _investidorService.GetById(idInvestidor);

            var investidorViewModel = _mapper.Map<InvestidorViewModel>(investidor);



            List<SelectListItem> UF = new List<SelectListItem>();
            UF.Add(new SelectListItem { Text = "AC", Value = "AC" });
            UF.Add(new SelectListItem { Text = "AL", Value = "AL" });
            UF.Add(new SelectListItem { Text = "AP", Value = "AP" });
            UF.Add(new SelectListItem { Text = "AM", Value = "AM" });
            UF.Add(new SelectListItem { Text = "BA", Value = "BA" });
            UF.Add(new SelectListItem { Text = "CE", Value = "CE" });
            UF.Add(new SelectListItem { Text = "DF", Value = "DF" });
            UF.Add(new SelectListItem { Text = "ES", Value = "ES" });
            UF.Add(new SelectListItem { Text = "GO", Value = "GO" });
            UF.Add(new SelectListItem { Text = "MA", Value = "MA" });
            UF.Add(new SelectListItem { Text = "MT", Value = "MT" });
            UF.Add(new SelectListItem { Text = "MS", Value = "MS" });
            UF.Add(new SelectListItem { Text = "MG", Value = "MG" });
            UF.Add(new SelectListItem { Text = "PA", Value = "PA" });
            UF.Add(new SelectListItem { Text = "PB", Value = "PB" });
            UF.Add(new SelectListItem { Text = "PR", Value = "PR" });
            UF.Add(new SelectListItem { Text = "PE", Value = "PE" });
            UF.Add(new SelectListItem { Text = "PI", Value = "PI" });
            UF.Add(new SelectListItem { Text = "RJ", Value = "RJ" });
            UF.Add(new SelectListItem { Text = "RN", Value = "RN" });
            UF.Add(new SelectListItem { Text = "RS", Value = "RS" });
            UF.Add(new SelectListItem { Text = "RO", Value = "RO" });
            UF.Add(new SelectListItem { Text = "RR", Value = "RR" });
            UF.Add(new SelectListItem { Text = "SC", Value = "SC" });
            UF.Add(new SelectListItem { Text = "SP", Value = "SP" });
            UF.Add(new SelectListItem { Text = "SE", Value = "SE" });
            UF.Add(new SelectListItem { Text = "TO", Value = "TO" });
            ViewBag.UF = UF;

            var tiposDocumento = _investidorService.GetAllTiposDocumento();

            ViewBag.TipoDocumento = new SelectList(tiposDocumento, "Sigla", "DescricaoCompleta");


            return View(investidorViewModel);
        }

        public IActionResult Index_Sidebar()
        {
            int? idInvestidor = 2;
            if (idInvestidor == null)
                return RedirectToAction("Index", "Home");

            var investidor = _investidorService.GetById(idInvestidor);

            var investidorViewModel = _mapper.Map<InvestidorViewModel>(investidor);



            List<SelectListItem> UF = new List<SelectListItem>();
            UF.Add(new SelectListItem { Text = "AC", Value = "AC" });
            UF.Add(new SelectListItem { Text = "AL", Value = "AL" });
            UF.Add(new SelectListItem { Text = "AP", Value = "AP" });
            UF.Add(new SelectListItem { Text = "AM", Value = "AM" });
            UF.Add(new SelectListItem { Text = "BA", Value = "BA" });
            UF.Add(new SelectListItem { Text = "CE", Value = "CE" });
            UF.Add(new SelectListItem { Text = "DF", Value = "DF" });
            UF.Add(new SelectListItem { Text = "ES", Value = "ES" });
            UF.Add(new SelectListItem { Text = "GO", Value = "GO" });
            UF.Add(new SelectListItem { Text = "MA", Value = "MA" });
            UF.Add(new SelectListItem { Text = "MT", Value = "MT" });
            UF.Add(new SelectListItem { Text = "MS", Value = "MS" });
            UF.Add(new SelectListItem { Text = "MG", Value = "MG" });
            UF.Add(new SelectListItem { Text = "PA", Value = "PA" });
            UF.Add(new SelectListItem { Text = "PB", Value = "PB" });
            UF.Add(new SelectListItem { Text = "PR", Value = "PR" });
            UF.Add(new SelectListItem { Text = "PE", Value = "PE" });
            UF.Add(new SelectListItem { Text = "PI", Value = "PI" });
            UF.Add(new SelectListItem { Text = "RJ", Value = "RJ" });
            UF.Add(new SelectListItem { Text = "RN", Value = "RN" });
            UF.Add(new SelectListItem { Text = "RS", Value = "RS" });
            UF.Add(new SelectListItem { Text = "RO", Value = "RO" });
            UF.Add(new SelectListItem { Text = "RR", Value = "RR" });
            UF.Add(new SelectListItem { Text = "SC", Value = "SC" });
            UF.Add(new SelectListItem { Text = "SP", Value = "SP" });
            UF.Add(new SelectListItem { Text = "SE", Value = "SE" });
            UF.Add(new SelectListItem { Text = "TO", Value = "TO" });
            ViewBag.UF = UF;

            var tiposDocumento = _investidorService.GetAllTiposDocumento();

            ViewBag.TipoDocumento = new SelectList(tiposDocumento, "Sigla", "DescricaoCompleta");


            return View(investidorViewModel);
        }


        [HttpPost]
        public IActionResult AtualizarDadosPessoais(InvestidorViewModel investidor)
        {
            try
            {
                var investidorDto = _mapper.Map<InvestidorDTO>(investidor);

                _investidorService.AtualizarDadosPessoais(investidorDto);

                return Json(new { success = true, message = "Dados atualizados com sucesso!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult AtualizarEndereco(InvestidorViewModel investidor)
        {
            try
            {
                var investidorDto = _mapper.Map<InvestidorDTO>(investidor);

                _investidorService.AtualizarEndereco(investidorDto);

                return Json(new { success = true, message = "Dados atualizados com sucesso!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }


        [HttpGet]
        public IActionResult ConsultaCEP(string cep)
        {
            try
            {
                var retorno = _correios.ConsultaCEP(cep);
                return new JsonResult(new { success = true, retorno });
            }
            catch (Exception)
            {

                return new JsonResult(new { success = false, message = "CEP não encontrado!" });
            }
        }


    }
}