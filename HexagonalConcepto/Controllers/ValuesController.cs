using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using exagonalConcepto.actions.queries;
using HexagonalConcepto.actions.commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HexagonalConcepto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        IMediator mediator;
        IPersonQueries personQueries;
        public ValuesController(IMediator mediator, IPersonQueries personQuery)
        {
            this.mediator = mediator;
            this.personQueries = personQuery;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var list = personQueries.Get();
            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            AddPersonCommand command = new AddPersonCommand(10, "Stiven");
            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}
