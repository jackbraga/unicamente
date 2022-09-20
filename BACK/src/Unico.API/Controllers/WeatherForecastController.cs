//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using Unico.Application.DTO;
//using Unico.Application.Interfaces;

//namespace Unico.API.Controllers;

//[ApiController]
//[Route("[controller]")]
//public class WeatherForecastController : ControllerBase
//{

//    private readonly IMaririService _maririService;

//    public WeatherForecastController(IMaririService maririService, ILogger<WeatherForecastController> logger)
//    {
//        _maririService=maririService;
//        _logger = logger;
//    }

//    private static readonly string[] Summaries = new[]
//    {
//        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//    };

//    private readonly ILogger<WeatherForecastController> _logger;


//    [HttpGet(Name = "GetMariri")]
//    public IEnumerable<MaririDTO> Mariri()
//    {
//        var lista = _maririService.GetAll();
//        return lista;
//    }
//}
