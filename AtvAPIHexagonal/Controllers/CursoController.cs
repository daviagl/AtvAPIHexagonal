using AtvAPIHexagonal.Application;
using Microsoft.AspNetCore.Mvc;

namespace AtvAPIHexagonal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursoController : ControllerBase
    {
        private readonly CursoService _cursoService;

        public CursoController(CursoService cursoService)        {
            _cursoService = cursoService;
        }

        [HttpPost]
        public IActionResult Post([FromQuery] string name, [FromQuery] int workload)
        {
            try
            {
                _cursoService.NewCurso(name, workload);
                return Ok("curso criado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_cursoService.Listar());
        }



    }
}
