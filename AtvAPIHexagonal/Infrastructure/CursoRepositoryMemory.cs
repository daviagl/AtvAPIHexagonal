using AtvAPIHexagonal.Domain;

namespace AtvAPIHexagonal.Infrastructure
{
    public class CursoRepositoryMemory : ICursoRepository
    {
        private static List<Curso> _cursos = new List<Curso>();
        

        public void Add(Curso curso)
        {
            _cursos.Add(curso);
        }

        public IEnumerable<Curso> GetAll() 
        {
            return _cursos;
        }

        public Curso GetById(Guid id)
        {
            return _cursos.FirstOrDefault(c => c.Id == id);
        }


    }
}
