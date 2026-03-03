namespace AtvAPIHexagonal.Domain
{
    public interface ICursoRepository
    {
        void Add(Curso curso);
        Curso GetById(Guid id);
        IEnumerable<Curso> GetAll();
    }
}
