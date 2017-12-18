using System;
using DFC.Domain.Core.Interfaces;

namespace DFC.Domain.Core.Events
{
    public class DomainNotification : IDomainEvent
    {
        public string Key { get; private set; }

        public string Value { get; private set; }

        public DateTime DataOcorrencia { get; }

        public int Versao { get; }

        public DomainNotification(string key, string value)
        {
            Versao = 1;
            Key = key;
            Value = value;
            DataOcorrencia = DateTime.Now;
        }
    }
}