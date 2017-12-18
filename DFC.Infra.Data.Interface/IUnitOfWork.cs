using System;

namespace DFC.Infra.Data.Interface
{
    public interface IUnitOfWork
    {
        bool Commit();
    }
}
