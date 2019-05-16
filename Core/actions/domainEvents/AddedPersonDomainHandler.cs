using Domain.domainEvents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.actions.domainEvents
{
    public class AddedPersonDomainHandler : INotificationHandler<AddedPersonDomainEvent>
    {
        public async Task Handle(AddedPersonDomainEvent notification, CancellationToken cancellationToken)
        {
            Console.Write("A person is Added...");
        }
    }
}
