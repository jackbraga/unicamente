using Microsoft.AspNetCore.Mvc;
using Unico.Application.DTO;
using Unico.Application.Interfaces;

namespace Unico.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaririController : Controller
    {
        private readonly IMaririService _maririService;
        private readonly ILogger _logger;

        public MaririController(IMaririService maririService, ILogger<MaririController> logger)
        {
            _maririService = maririService;
            _logger = logger;
  
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var lista = _maririService.GetAll();
                return Ok(lista);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
            
        }

        [HttpPost]
        public IActionResult Post([FromForm] MaririDTO model)
        {
            try
            {
                _maririService.Add(model);
                return Ok();
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
            
        }

        [HttpPut]
        public IActionResult Put([FromForm] MaririDTO model)
        {
            try
            {
                _maririService.Update(model);
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
                _maririService.Remove(id);
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
