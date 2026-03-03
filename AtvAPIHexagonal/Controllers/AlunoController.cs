using AtvAPIHexagonal.Application;
using Microsoft.AspNetCore.Mvc;

namespace AtvAPIHexagonal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly AlunoService _service;

        public AlunoController(AlunoService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Post([FromQuery] string firstName, [FromQuery] string email)
        {
            try
            {
                _service.Matricular(firstName, email);
                return Ok("Aluno matriculado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("matricular em curso")]
        public IActionResult Matricular(Guid alunoId, Guid cursoId)
        {
            try
            {
                _service.MatricularEmCurso(alunoId, cursoId);
                return Ok("Matrícula realizada com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.Listar());
        }
    }
}
