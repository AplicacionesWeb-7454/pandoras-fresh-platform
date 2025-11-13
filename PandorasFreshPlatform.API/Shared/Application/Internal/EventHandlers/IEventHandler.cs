using PandorasFreshPlatform.API.Shared.Domain.Model.Events;
using Cortex.Mediator.Notifications;

namespace PandorasFreshPlatform.API.Shared.Application.Internal.EventHandlers;

public interface IEventHandler<in TEvent> : INotificationHandler<TEvent> where TEvent : IEvent
{
    
}