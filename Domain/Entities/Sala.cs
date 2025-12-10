namespace MediFlow.Web.Domain.Entities
{
    public class Sala
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public int Numero { get; private set; }

        protected Sala() { }
        public Sala(string nome, int numero)
        {
            Nome = nome;
            Numero = numero;
        }
    }
}