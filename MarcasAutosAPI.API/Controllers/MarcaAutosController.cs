using MarcasAUtosAPI.Application.Contracts;
using MarcasAUtosAPI.Domain;
using Microsoft.AspNetCore.Mvc;

namespace MarcasAutosAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarcaAutosController : ControllerBase
    {
        private readonly IBaseRepository<MarcaAuto> _marcaAutoRepository;

        public MarcaAutosController(IBaseRepository<MarcaAuto> marcaAutoRepository)
        {
            _marcaAutoRepository = marcaAutoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var marcas = await _marcaAutoRepository.GetAllAsync();
            return Ok(marcas);
        }

    }
}
