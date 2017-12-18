using System;
using System.Collections.Generic;

namespace DFC.Domain.Core.Interfaces
{
    public interface IHandler<T> : IDisposable where T : IDomainEvent
    {
        void Handle(T args);

        IEnumerable<T> Notify();

        bool HasNotifications();

        List<T> GetValues();
    }
}