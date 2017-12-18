using System;
using DFC.Domain.Core.Enums;

namespace DFC.Domain
{
    public class Movimentacao
    {
        public decimal Valor { get; set; }
        public EnumTipoMovimentacao Tipo { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
    }
}