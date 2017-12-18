using System.Linq;
using DFC.Domain.Core.Events;
using FluentValidation.Results;

namespace DFC.Domain.Bases
{
    public class BaseService
    {
        protected static bool PossuiConformidade(ValidationResult validationResult)
        {
            if (validationResult == null) return true;
            var notifications = validationResult.Errors.Select(validationError => new DomainNotification(validationError.PropertyName, validationError.ErrorMessage)).ToList();
            if (!notifications.Any()) return true;
            notifications.ToList().ForEach(DomainEvent.Raise); 
            return false;
        }
    }
}