using System;
using System.Collections.Generic;
using DFC.Domain.Core.Events;
using DFC.Domain.Core.Handlers;
using DFC.Domain.Core.Interfaces;
using DFC.Infra.Data.Interface;
using Microsoft.AspNetCore.Http;

namespace DFC.Application.Core
{
    public class BaseApplicationService
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IHandler<DomainNotification> Notifications;

        public BaseApplicationService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            if (DomainEvent.Container == null)
            {
                Notifications = new DomainNotificationHandler();

            }
        }

        public List<DomainNotification> ObterNotificacoesDominio()
        {
            if (Notifications.HasNotifications())
            {
                return Notifications.GetValues();
            }
            return null;
        }

        public bool Commit()
        {
            if (Notifications.HasNotifications())
                return false;

            UnitOfWork.Commit();
            return true;
        }

    }
}