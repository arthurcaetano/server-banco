
using System.Collections.Generic;
using DFC.Domain.Core.Events;

namespace DFC.Application.Core.Interfaces
{
    public interface IBaseApplicationService<T>
        where T : class
    {
        T Adicionar(T model);

        void Atualizar(T model);

        void Excluir(int id);

        T ObterPorId(int id);

        IEnumerable<T> ObterTodos();

        List<DomainNotification> ObterNotificacoes();
    }
}