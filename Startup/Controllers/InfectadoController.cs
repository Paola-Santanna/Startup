using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Startup.Domain.Collection;
using Startup.Domain.DTO;
using Statup.Infrastructure;

namespace Startup.Controllers;

[ApiController]
[Route("[controller]")]
public class InfectadoController : ControllerBase
{
    Mongo_DB _mongoDB;
    IMongoCollection<Infectado> _infectadosCollection;

    public InfectadoController(Mongo_DB mongoDB)
    {
        _mongoDB = mongoDB;
        _infectadosCollection = _mongoDB.DB.GetCollection<Infectado>(typeof(Infectado).Name.ToLower());
    }

    [HttpPost]
    public ActionResult SalvarInfectado([FromBody] InfectadoDTO dto)
    {
        var infectado = new Infectado(dto.DataNascimento, dto.Sexo, dto.Latitude, dto.Longitude);

        _infectadosCollection.InsertOne(infectado);

        return StatusCode(201, "Infectado adicionado com sucesso!");
    }

    [HttpGet]
    public IActionResult ObterInfectados()
    {
        var infectados = _infectadosCollection
            .Find(Builders<Infectado>.Filter.Empty).ToList();



        return Ok(infectados);
    }
}

