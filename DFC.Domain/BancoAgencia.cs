namespace DFC.Domain
{
    public class BancoAgencia
    {
        public int Id { get; set; }
        public int IdBanco { get; set; }
        public Banco Banco { get; set; }
        public string Codigo { get; set; }
    }
}