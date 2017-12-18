using System;

namespace DFC.Domain.Core.Interfaces
{
    public interface IDomainEvent
    {
        int Versao { get; }

        DateTime DataOcorrencia { get; }
    }
}