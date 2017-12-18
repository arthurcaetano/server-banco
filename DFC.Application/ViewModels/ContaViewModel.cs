using System.Collections.Generic;
using DFC.Domain.Core.Enums;

namespace DFC.Application.ViewModels
{
    public class ContaViewModel
    {
        public int Id { get; set; }
        public string Titular { get; set; }
        public string CpfCnpj { get; set; }
        public string Numero { get; set; }
        public EnumTipoConta TipoConta { get; set; }
        public EnumTipoPessoa TipoPessoa { get; set; }
        public int IdBanco { get; set; }
        public ICollection<MovimentacaoViewModel> Movimentacao { get; set; }
    }
}