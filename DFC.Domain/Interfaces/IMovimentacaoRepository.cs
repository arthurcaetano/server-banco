using System;
using System.Collections.Generic;
using DFC.Infra.Data.Interface;

namespace DFC.Domain.Interfaces
{
    public interface IMovimentacaoRepository : IRepository<Movimentacao>
    {
        IEnumerable<Movimentacao> ObterPorIdConta(int idConta);
    }
}