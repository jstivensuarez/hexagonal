using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Core.dto;
using Domain.ports;

namespace Core.actions.queries
{
    public class PersonQueries : IPersonQueries
    {
        readonly IUnitOfWork unitOfWork;
        readonly IMapper mapper;
        public PersonQueries(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public List<PersonDto> Get()
        {
            var list = unitOfWork.PersonRepository.Get();
            return mapper.Map<List<PersonDto>>(list);
        }
    }
}
