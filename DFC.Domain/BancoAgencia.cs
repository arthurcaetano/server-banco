using System.Collections.Generic;

namespace DFC.Domain
{
    public class BancoAgencia
    {
        public int Id { get; set; }
        public int IdBanco { get; set; }
        public Banco Banco { get; set; }
        public string Codigo { get; set; }
        public ICollection<Conta> Contas { get; private set; }
    }
}