using System;
using DFC.Domain.Core;
using DFC.Domain.Core.Enums;

namespace DFC.Domain
{
    public class Movimentacao : BaseEntity<Movimentacao>
    {
        public decimal Valor { get; set; }
        public EnumTipoMovimentacao Tipo { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public Conta Conta { get; set; }
        public int? IdConta { get; set; }

        protected Movimentacao()
        {
            
        }

        public override bool EhValido()
        {
            return true;
        }
    }
}