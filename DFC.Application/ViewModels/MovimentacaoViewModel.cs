using System;
using DFC.Domain.Core.Enums;

namespace DFC.Application.ViewModels
{
    public class MovimentacaoViewModel
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public EnumTipoMovimentacao Tipo { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public int IdConta { get; set; }
    }
}