namespace AtvAPIHexagonal.Domain
{
    public class Curso
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int Workload { get; private set; }

        public Curso(string name, int workload)
        {
            Id = Guid.NewGuid();
            Name = name;
            Workload = workload;
        }
    }
}
