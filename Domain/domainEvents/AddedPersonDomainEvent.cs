using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.domainEvents
{
    public class AddedPersonDomainEvent : INotification
    {
        public string Message { get; set; }

        public AddedPersonDomainEvent(string message)
        {
            this.Message = message;
        }
    }
}
