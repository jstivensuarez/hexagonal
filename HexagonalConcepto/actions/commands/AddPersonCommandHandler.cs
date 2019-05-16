using Domain.domainEvents;
using Domain.models;
using Domain.ports;
using Domain.ports.repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HexagonalConcepto.actions.commands
{
    public class AddPersonCommandHandler : IRequestHandler<AddPersonCommand, bool>
    {
        readonly IUnitOfWork unitOfWork;
        IMediator mediator;

        public AddPersonCommandHandler(IUnitOfWork unitOfWork, IMediator mediator)
        {
            this.unitOfWork = unitOfWork;
            this.mediator = mediator;
        }

        public Task<bool> Handle(AddPersonCommand request, CancellationToken cancellationToken)
        {
            Person persona = new Person
            {
                Id = request.Id,
                Name = request.Name
            };
            unitOfWork.PersonRepository.Add(persona);
            AddedPersonDomainEvent notification = new AddedPersonDomainEvent("Hello world");
            mediator.Publish(notification);
            return unitOfWork.Save();
        }
    }
}
