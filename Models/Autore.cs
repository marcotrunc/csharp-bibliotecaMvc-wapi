namespace csharp_bibliotecaMvc.Models
{
    public class Autore
    {
        public int AutoreID { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Libro>? Libro { get; set; }
    }
}
