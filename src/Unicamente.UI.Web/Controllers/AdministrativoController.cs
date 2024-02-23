using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Unicamente.Application.DTOs;
using Unicamente.Application.ExternalServices.Correios;
using Unicamente.Application.Interfaces;
using Unicamente.UI.Web.Models;

namespace Unicamente.UI.Web.Controllers
{
    public class AdministrativoController : Controller
    {

        private readonly ILogger<AdministrativoController> _logger;
        private readonly IMapper _mapper;
        private readonly ICorreios _correios;
        private readonly IImobiliariaService _imobiliariaService;
        private readonly IRecipienteService _recipienteService;
        private readonly IMaririService _maririService;
        private readonly IChacronaService _chacronaService;
        private readonly IVegetalService _vegetalService;

        public AdministrativoController(
            ILogger<AdministrativoController> logger,
            IMapper mapper, ICorreios correios,
            IImobiliariaService imobiliariaService,
            IRecipienteService recipienteService,
            IMaririService maririService,
            IChacronaService chacronaService,
            IVegetalService vegetalService
            )
        {
            _logger = logger;
            _mapper = mapper;
            _correios = correios;
            _imobiliariaService = imobiliariaService;
            _recipienteService = recipienteService;
            _maririService = maririService;
            _chacronaService = chacronaService;
            _vegetalService = vegetalService;
        }

        public IActionResult Index()
        {

            AdministrativoViewModel administrativoViewModel = new AdministrativoViewModel();
            var recipientes = _recipienteService.GetAll();
            administrativoViewModel.Recipientes = _mapper.Map<IEnumerable<RecipienteViewModel>>(recipientes);
            administrativoViewModel.Recipiente = new RecipienteViewModel();


            var mariris = _maririService.GetAll();
            administrativoViewModel.Mariris = _mapper.Map<IEnumerable<MaririViewModel>>(mariris);
            administrativoViewModel.Mariri = new MaririViewModel();

            var chacronas = _chacronaService.GetAll();
            administrativoViewModel.Chacronas = _mapper.Map<IEnumerable<ChacronaViewModel>>(chacronas);
            administrativoViewModel.Chacrona = new ChacronaViewModel();



            var vegetals = _vegetalService.GetAll();
            administrativoViewModel.Vegetals = _mapper.Map<IEnumerable<VegetalViewModel>>(vegetals);
            administrativoViewModel.Vegetal = new VegetalViewModel();

            //var imobiliarias = _imobiliariaService.GetAll();
            //administrativoViewModel.Imobiliaria = new ImobiliariaViewModel();
            //return View(administrativoViewModel);
            return View(administrativoViewModel);
        }


        #region Recipiente


        public IActionResult DetalheRecipiente(int id)
        {
            try
            {
                RecipienteViewModel recipienteViewModel = new RecipienteViewModel();
                if (id == 0)
                {
                    return PartialView("~/Views/Administrativo/Recipientes/_FormularioRecipiente.cshtml", recipienteViewModel);
                }

                var recipiente = _recipienteService.GetById(id);
                recipienteViewModel = _mapper.Map<RecipienteViewModel>(recipiente);
                return PartialView("~/Views/Administrativo/Recipientes/_FormularioRecipiente.cshtml", recipienteViewModel);

            }
            catch (Exception ex)
            {

                return PartialView(new { success = false, message = ex.Message });
            }

        }

        [HttpGet]
        public IActionResult ListaRecipientes()
        {
            try
            {
                var recipientes = _recipienteService.GetAll();
                var recipientesViewModel = _mapper.Map<IEnumerable<RecipienteViewModel>>(recipientes);
                return PartialView("~/Views/Administrativo/Recipientes/_ListaRecipientes.cshtml", recipientesViewModel);

            }
            catch (Exception ex)
            {

                return PartialView(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult SalvarRecipiente(RecipienteViewModel recipiente, IFormFile photo)
        {
            try
            {
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    byte[] imagemBytes;
                    using (var ms = new MemoryStream())
                    {
                        photo.CopyTo(ms);
                        imagemBytes = ms.ToArray();
                    }
                    recipiente.Imagem = imagemBytes;
                }


                var recipienteDTO = _mapper.Map<RecipienteDTO>(recipiente);




                if (recipiente.ID > 0)
                {
                    _recipienteService.Update(recipienteDTO);

                    return Json(new
                    {
                        success = true,
                        message =
                        "Recipiente Atualizado com sucesso!"
                    });
                }
                else
                {
                    _recipienteService.Add(recipienteDTO);
                    return Json(new
                    {
                        success = true,
                        message =
                        "Recipiente cadastrado com sucesso!"
                    });
                }
                //HttpContext.Session.SetInt32("ID", idImobiliaria);


            }

            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult DeletarRecipiente(int id)
        {
            try
            {
                _recipienteService.Remove(id);

                return Json(new
                {
                    sucesso = true,
                    mensagem =
                    "Item deletado com sucesso!"
                });

            }

            catch (Exception ex)
            {
                return Json(new { sucesso = false, mensagem = ex.Message });
            }
        }
        #endregion







        public IActionResult DetalheMariri(int id)
        {
            try
            {
                MaririViewModel maririViewModel = new MaririViewModel();
                if (id == 0)
                {
                    return PartialView("~/Views/Administrativo/Mariri/_FormularioMariri.cshtml", maririViewModel);
                }

                var mariri = _maririService.GetById(id);
                maririViewModel = _mapper.Map<MaririViewModel>(mariri);
                return PartialView("~/Views/Administrativo/Mariri/_FormularioMariri.cshtml", maririViewModel);

            }
            catch (Exception ex)
            {

                return PartialView(new { success = false, message = ex.Message });
            }

        }

        [HttpGet]
        public IActionResult ListaMariris()
        {
            try
            {
                var mariris = _maririService.GetAll();
                var maririsViewModel = _mapper.Map<IEnumerable<MaririViewModel>>(mariris);
                return PartialView("~/Views/Administrativo/Mariri/_ListaMariris.cshtml", maririsViewModel);

            }
            catch (Exception ex)
            {

                return PartialView(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult SalvarMariri(MaririViewModel mariri, IFormFile photo)
        {
            try
            {
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    byte[] imagemBytes;
                    using (var ms = new MemoryStream())
                    {
                        photo.CopyTo(ms);
                        imagemBytes = ms.ToArray();
                    }
                    mariri.Imagem = imagemBytes;
                }


                var maririDTO = _mapper.Map<MaririDTO>(mariri);




                if (mariri.ID > 0)
                {
                    _maririService.Update(maririDTO);

                    return Json(new
                    {
                        success = true,
                        message =
                        "Mariri Atualizado com sucesso!"
                    });
                }
                else
                {
                    _maririService.Add(maririDTO);
                    return Json(new
                    {
                        success = true,
                        message =
                        "Mariri cadastrado com sucesso!"
                    });
                }
                //HttpContext.Session.SetInt32("ID", idImobiliaria);


            }

            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult DeletarMariri(int id)
        {
            try
            {
                _maririService.Remove(id);

                return Json(new
                {
                    sucesso = true,
                    mensagem =
                    "Item deletado com sucesso!"
                });

            }

            catch (Exception ex)
            {
                return Json(new { sucesso = false, mensagem = ex.Message });
            }
        }






        [HttpGet]
        public IActionResult DetalheChacrona(int id)
        {
            try
            {
                ChacronaViewModel chacronaViewModel = new ChacronaViewModel();
                if (id == 0)
                {
                    return PartialView("~/Views/Administrativo/Chacrona/_FormularioChacrona.cshtml", chacronaViewModel);
                }

                var chacrona = _chacronaService.GetById(id);
                chacronaViewModel = _mapper.Map<ChacronaViewModel>(chacrona);
                return PartialView("~/Views/Administrativo/Chacrona/_FormularioChacrona.cshtml", chacronaViewModel);

            }
            catch (Exception ex)
            {

                return PartialView(new { success = false, message = ex.Message });
            }

        }

        [HttpGet]
        public IActionResult ListaChacronas()
        {
            try
            {
                var chacronas = _chacronaService.GetAll();
                var chacronasViewModel = _mapper.Map<IEnumerable<ChacronaViewModel>>(chacronas);
                return PartialView("~/Views/Administrativo/Chacrona/_ListaChacronas.cshtml", chacronasViewModel);

            }
            catch (Exception ex)
            {

                return PartialView(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult SalvarChacrona(ChacronaViewModel chacrona, IFormFile photo)
        {
            try
            {
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    byte[] imagemBytes;
                    using (var ms = new MemoryStream())
                    {
                        photo.CopyTo(ms);
                        imagemBytes = ms.ToArray();
                    }
                    chacrona.Imagem = imagemBytes;
                }


                var chacronaDTO = _mapper.Map<ChacronaDTO>(chacrona);




                if (chacrona.ID > 0)
                {
                    _chacronaService.Update(chacronaDTO);

                    return Json(new
                    {
                        success = true,
                        message =
                        "Chacrona Atualizada com sucesso!"
                    });
                }
                else
                {
                    _chacronaService.Add(chacronaDTO);
                    return Json(new
                    {
                        success = true,
                        message =
                        "Chacrona cadastrada com sucesso!"
                    });
                }
                //HttpContext.Session.SetInt32("ID", idImobiliaria);


            }

            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult DeletarChacrona(int id)
        {
            try
            {
                _chacronaService.Remove(id);

                return Json(new
                {
                    sucesso = true,
                    mensagem =
                    "Item deletado com sucesso!"
                });

            }

            catch (Exception ex)
            {
                return Json(new { sucesso = false, mensagem = ex.Message });
            }
        }





        public IActionResult DetalheVegetal(int id)
        {
            try
            {
                VegetalViewModel vegetalViewModel = new VegetalViewModel();
                if (id == 0)
                {
                    return PartialView("~/Views/Administrativo/Vegetal/_FormularioVegetal.cshtml", vegetalViewModel);
                }

                var vegetal = _vegetalService.GetById(id);
                vegetalViewModel = _mapper.Map<VegetalViewModel>(vegetal);
                return PartialView("~/Views/Administrativo/Vegetal/_FormularioVegetal.cshtml", vegetalViewModel);

            }
            catch (Exception ex)
            {

                return PartialView(new { success = false, message = ex.Message });
            }

        }

        [HttpGet]
        public IActionResult ListaVegetals()
        {
            try
            {
                var listaDTO = _chacronaService.GetAll();
                var listaViewModel = _mapper.Map<IEnumerable<VegetalViewModel>>(listaDTO);
                return PartialView("~/Views/Administrativo/Vegetal/_ListaVegetals.cshtml", listaViewModel);

            }
            catch (Exception ex)
            {

                return PartialView(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult SalvarVegetal(VegetalViewModel objeto, IFormFile photo)
        {
            try
            {
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    byte[] imagemBytes;
                    using (var ms = new MemoryStream())
                    {
                        photo.CopyTo(ms);
                        imagemBytes = ms.ToArray();
                    }
                    objeto.Imagem = imagemBytes;
                }


                var objetoDTO = _mapper.Map<VegetalDTO>(objeto);




                if (objeto.ID > 0)
                {
                    _vegetalService.Update(objetoDTO);

                    return Json(new
                    {
                        success = true,
                        message =
                        "Vegetal Atualizado com sucesso!"
                    });
                }
                else
                {
                    _vegetalService.Add(objetoDTO);
                    return Json(new
                    {
                        success = true,
                        message =
                        "Vegetal cadastrado com sucesso!"
                    });
                }
                //HttpContext.Session.SetInt32("ID", idImobiliaria);


            }

            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult DeletarVegetal(int id)
        {
            try
            {
                _vegetalService.Remove(id);

                return Json(new
                {
                    sucesso = true,
                    mensagem =
                    "Item deletado com sucesso!"
                });

            }

            catch (Exception ex)
            {
                return Json(new { sucesso = false, mensagem = ex.Message });
            }
        }



    }
}