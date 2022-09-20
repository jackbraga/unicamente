using Microsoft.AspNetCore.Mvc;
using Unico.Application.DTO;
using Unico.Application.Interfaces;

namespace Unico.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChacronaController : Controller
    {
        private readonly IChacronaService _chacronaService;
        private readonly ILogger _logger;

        public ChacronaController(IChacronaService chacronaService, ILogger<ChacronaController> logger)
        {
            _chacronaService = chacronaService;
            _logger = logger;
  
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var lista = _chacronaService.GetAll();
                return Ok(lista);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
            
        }

        [HttpPost]
        public IActionResult Post([FromForm] ChacronaDTO model)
        {
            try
            {
                _chacronaService.Add(model);
                return Ok();
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
            
        }

        [HttpPut]
        public IActionResult Put([FromForm] ChacronaDTO model)
        {
            try
            {
                _chacronaService.Update(model);
                return Ok();
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                   $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _chacronaService.Remove(id);
                return Ok();

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                   $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }

        }

    }
}
