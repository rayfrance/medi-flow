namespace MediFlow.Web.Domain.Entities
{
    public class Cirurgia
    {
        public int Id { get; private set; }
        public int PacienteId { get; private set; }
        public int SalaId { get; private set; }
        public DateTime Inicio { get; private set; }
        public DateTime Fim { get; private set; }

        // Propriedades de Navegação (Relacionamentos)
        public virtual Paciente Paciente { get; private set; }
        public virtual Sala Sala { get; private set; }

        protected Cirurgia() { }
        public Cirurgia(int pacienteId, int salaId, DateTime inicio, DateTime fim)
        {
            if (inicio >= fim) throw new ArgumentException("A data fim deve ser maior que o início.");

            PacienteId = pacienteId;
            SalaId = salaId;
            Inicio = inicio;
            Fim = fim;
        }
    }
}