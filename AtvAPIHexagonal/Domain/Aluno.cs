namespace AtvAPIHexagonal.Domain
{
    public class Aluno
    { 
        public Guid Id { get; private set; } 
        public string FirstName { get; private set; }
        public string Email { get; private set; }
        public List<Curso> Cursos { get; private set; }

        public Aluno(string firstName, string email)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            Email = email;
            Cursos = new List<Curso>();
        }

        
        public void MatricularEmCurso(Curso curso) 
        {
            if (Cursos.Any(c => c.Id == curso.Id))
                throw new Exception("aluno ja matriculado nesse curso");

            Cursos.Add(curso);
        }

    }
}
