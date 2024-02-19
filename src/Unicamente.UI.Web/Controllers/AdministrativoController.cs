using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Unicamente.Application.DTOs;
using Unicamente.Application.ExternalServices.Correios;
using Unicamente.Application.Interfaces;
using Unicamente.Domain.Entities;
using Unicamente.UI.Web.Models;

namespace Unicamente.UI.Web.Controllers
{
    public class AdministrativoController : Controller
    {

        private readonly IInvestidorService _investidorService;
        private readonly ILogger<AdministrativoController> _logger;
        private readonly IMapper _mapper;
        private readonly ICorreios _correios;
        private readonly IImobiliariaService _imobiliariaService;

        public AdministrativoController(IInvestidorService investidorService, ILogger<AdministrativoController> logger, IMapper mapper, ICorreios correios, IImobiliariaService imobiliariaService)
        {
            _investidorService = investidorService;
            _logger = logger;
            _mapper = mapper;
            _correios = correios;
            _imobiliariaService = imobiliariaService;
        }

        public IActionResult Index()
        {

            AdministrativoViewModel administrativoViewModel = new AdministrativoViewModel();
            var imobiliarias = _imobiliariaService.GetAll();
            administrativoViewModel.Imobiliarias = _mapper.Map<IEnumerable<ImobiliariaViewModel>>(imobiliarias);
            administrativoViewModel.Imobiliaria = new ImobiliariaViewModel();
            //return View(administrativoViewModel);
            return View(administrativoViewModel);
        }

        [HttpPost]
        public IActionResult SalvarImobiliaria(ImobiliariaViewModel imob)
        {
            try
            {
                var imobDTO = _mapper.Map<ImobiliariaDTO>(imob);

                if (imob.ID > 0)
                {
                    _imobiliariaService.Update(imobDTO);

                    return Json(new
                    {
                        success = true,
                        message =
                        "Imobiliária atualizada com sucesso!"
                    });
                }
                else
                {
                    _imobiliariaService.Add(imobDTO);
                    return Json(new
                    {
                        success = true,
                        message =
                        "Imobiliária adicionada com sucesso!"
                    });
                }
                //HttpContext.Session.SetInt32("ID", idImobiliaria);


            }

            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public IActionResult ListaImobiliarias()
        {
            try
            {
                AdministrativoViewModel administrativoViewModel = new AdministrativoViewModel();
                var imobiliarias = _imobiliariaService.GetAll();
                administrativoViewModel.Imobiliarias = _mapper.Map<IEnumerable<ImobiliariaViewModel>>(imobiliarias);
                return PartialView("~/Views/Administrativo/_ListaImobiliarias.cshtml", administrativoViewModel.Imobiliarias);

            }
            catch (Exception ex)
            {

                return PartialView(new { success = false, message = ex.Message });
            }

        }

        public IActionResult DetalheImobiliaria(int id)
        {
            try
            {
                ImobiliariaViewModel imobViewModel = new ImobiliariaViewModel();
                if (id == 0)
                {
                    return PartialView("~/Views/Administrativo/_FormularioImobiliaria.cshtml", imobViewModel);
                }

                var imob = _imobiliariaService.GetById(id);
                imobViewModel = _mapper.Map<ImobiliariaViewModel>(imob);
                return PartialView("~/Views/Administrativo/_FormularioImobiliaria.cshtml", imobViewModel);

            }
            catch (Exception ex)
            {

                return PartialView(new { success = false, message = ex.Message });
            }

        }
    }
}