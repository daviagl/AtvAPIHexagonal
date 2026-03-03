using AtvAPIHexagonal.Domain;
using AtvAPIHexagonal.Application;
using AtvAPIHexagonal.Infrastructure;

namespace AtvAPIHexagonal.Application
{
    public class AlunoService
    {
        private readonly IAlunoRepository _repository;
        private readonly ICursoRepository _cursoRepository;

        public AlunoService(IAlunoRepository repository, ICursoRepository cursoRepository)
        {
            _repository = repository;
            _cursoRepository = cursoRepository;

        }

        public void Matricular(string firstName, string email)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("não pode ser vazio");

            if (firstName.Length > 50)
                throw new ArgumentException("deve ter no máximo 50 caracteres");

            if (!email.EndsWith("@faculdade.edu"))
                throw new ArgumentException("deve terminar com '@faculdade.edu'");

            var alunoExistente = _repository.GetByEmail(email);

            if (alunoExistente != null)
                throw new ArgumentException("Email já cadastrado");

            var aluno = new Aluno(firstName, email);

            _repository.Add(aluno);
        }
        public IEnumerable<Aluno> Listar()
        {
            return _repository.GetAll();
        }

        public void MatricularEmCurso(Guid alunoId, Guid cursoId)
        {
            var aluno = _repository.GetAll().FirstOrDefault(a => a.Id == alunoId);

            if (aluno == null)
                throw new Exception("Aluno não encontrado.");

            var curso = _cursoRepository.GetById(cursoId);
            if (curso == null)
                throw new Exception("Curso não encontrado.");

            aluno.MatricularEmCurso(curso);
        }

    }
}
