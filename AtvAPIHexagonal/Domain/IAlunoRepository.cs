namespace AtvAPIHexagonal.Domain
{
    public interface IAlunoRepository
    {
        void Add(Aluno aluno);
        Aluno GetByEmail(string email);
        IEnumerable<Aluno> GetAll();
    }
}
