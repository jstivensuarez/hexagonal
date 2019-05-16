using Core.dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.actions.queries
{
    public interface IPersonQueries
    {
        List<PersonDto> Get();
    }
}
