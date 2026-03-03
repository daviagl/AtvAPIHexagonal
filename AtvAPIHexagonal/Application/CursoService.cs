using AtvAPIHexagonal.Domain;
using AtvAPIHexagonal.Application;
using AtvAPIHexagonal.Infrastructure;

namespace AtvAPIHexagonal.Application
{
    public class CursoService
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoService(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }


        public void NewCurso(string name, int workload)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Curso deve ter um nome");

            if (workload < 3)
                throw new ArgumentException("Curso deve ter uma carga horária de no minimo 3 horas");


            var curso = new Curso(name, workload);

            _cursoRepository.Add(curso);

        }

        public IEnumerable<Curso> Listar() 
        {
            return _cursoRepository.GetAll();
        }

    }
}
