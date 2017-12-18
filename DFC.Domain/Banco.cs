using System.Collections.Generic;
using DFC.Domain.Core;

namespace DFC.Domain
{
    public class Banco : BaseEntity<Banco>
    {
        public string Nome { get; private set; }
        public ICollection<BancoAgencia> Agencias { get; private set; }
        public ICollection<Conta> Contas { get; private set; }

        protected Banco()
        {
            
        }

        public Banco(string nome, int id = 0)
        {
            Id = id;
            Nome = nome;
        }
        public void DefinirAgencias(ICollection<BancoAgencia> agencias)
        {
            Agencias = agencias;
        }

        public override bool EhValido()
        {
            return true;
        }
    }
}
