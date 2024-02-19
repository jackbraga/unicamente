using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Unicamente.Application.DTOs;
using Unicamente.Application.Interfaces;
using Unicamente.Application.Services;
using Unicamente.Domain.Entities;
using Unicamente.UI.Web.Models;
using System.Security.Policy;

namespace Unicamente.UI.Web.Controllers
{
    public class LoginController : Controller
    {

        private readonly ILoginService _loginService;
        private readonly IInvestidorService _investidorService;
        private readonly IMapper _mapper;
        public LoginController(ILoginService loginService, IInvestidorService investidorService, IMapper mapper)
        {
            _loginService = loginService;
            _investidorService = investidorService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ConfirmarEmail(string c)
        {
            _investidorService.ConfirmarEmail(c);
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                var loginDto = _mapper.Map<LoginDTO>(login);

                var investidor = _investidorService.Login(loginDto);
                HttpContext.Session.SetInt32("ID", investidor.ID);

                if (investidor.SituacaoCadastro == SituacaoCadastroDTO.Ativo)
                {
                    return Json(new { success = true, situacao = "ativo", icone="success",titulo="Sucesso!", mensagem = "Login efetuado com sucesso!" });
                }
                if (investidor.SituacaoCadastro == SituacaoCadastroDTO.PendenteEmail)
                {
                    return Json(new { success = false, situacao = "pendente_email", icone = "warning", titulo = "Faltou uma coisinha...", mensagem = "É necessário realizar a ativação da conta. Verifique seu e-mail" });
                }
                return Json(new { success = false, situacao = "nao_identificado", icone = "error", titulo = "Oops...", mensagem = "Não é possível realizar login no momento!" });
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message });
            }

        }




        [HttpGet]
        public IActionResult BemVindo()
        {
            return View();
        }

    }
}
