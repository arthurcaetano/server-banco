using System.Collections;
using System.Collections.Generic;
using DFC.Application.Core.Interfaces;
using DFC.Application.ViewModels;

namespace DFC.Application.Interfaces
{
    public interface IMovimentacaoAppService : IBaseApplicationService<MovimentacaoViewModel>
    {
        IEnumerable<MovimentacaoViewModel> ObterTodasPorConta(int idConta);
    }
}