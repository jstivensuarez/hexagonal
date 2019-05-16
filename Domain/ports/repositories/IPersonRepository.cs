using Domain.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ports.repositories
{
    public interface IPersonRepository
    {
        void Add(Person person);

        List<Person> Get();
    }
}
