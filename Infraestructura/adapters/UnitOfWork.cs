using Domain.ports;
using Domain.ports.repositories;
using Infraestructura.adapters.repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.adapters
{
    public class UnitOfWork : IUnitOfWork
    {
        public IPersonRepository PersonRepository => new PersonRepository();

        public Task<bool> Save()
        {
            return Task.Run(() => {
                return true;
            });
        }
    }
}
