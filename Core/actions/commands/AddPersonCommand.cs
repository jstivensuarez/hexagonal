using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.actions.commands
{
    public class AddPersonCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public AddPersonCommand(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
