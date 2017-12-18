using System;

namespace DFC.Domain.Interfaces
{
    public interface IBancoService : IDisposable
    {
        void Adicionar(Banco banco);

        void Atualizar(Banco banco);

        void Excluir(int id);
    }
}