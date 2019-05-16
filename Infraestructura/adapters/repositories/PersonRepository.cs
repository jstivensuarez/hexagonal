using Domain.models;
using Domain.ports.repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura.adapters.repositories
{
    public class PersonRepository : IPersonRepository
    {
        public void Add(Person person)
        {

        }

        public List<Person> Get()
        {
            List<Person> list = new List<Person>
            {
                new Person{Id  = 1, Name = "Jesús"},
                new Person{Id  = 2, Name = "Stiven"},
                new Person{Id  = 3, Name = "Jhova"}
            };
            return list;
        }
    }
}
