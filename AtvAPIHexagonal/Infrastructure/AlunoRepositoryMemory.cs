using AtvAPIHexagonal.Domain;

namespace AtvAPIHexagonal.Infrastructure
{
    public class AlunoRepositoryMemory : IAlunoRepository
    {
        private static List<Aluno> _alunos = new List<Aluno>();
        public void Add(Aluno aluno)
        {
            _alunos.Add(aluno);
        }

        public IEnumerable<Aluno> GetAll()
        {
            return _alunos;
        }

        public Aluno GetByEmail(string email)
        {
            return _alunos.FirstOrDefault(a => a.Email == email);
        }
    }
}
