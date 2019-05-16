using Domain.ports.repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ports
{
    public interface IUnitOfWork
    {
        Task<bool> Save();

        IPersonRepository PersonRepository { get; }
    }
}
