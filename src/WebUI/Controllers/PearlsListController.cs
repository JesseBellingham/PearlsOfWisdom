using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PearlsOfWisdom.Application.PearlLists.Queries.GetPearlListById;
using PearlsOfWisdom.Application.PearlLists.Queries.GetPearlLists;
using PearlsOfWisdom.Application.PearlLists.Queries.Shared;

namespace PearlsOfWisdom.WebUI.Controllers
{
    public class PearlsListController : ApiController
    {
        public PearlsListController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IList<PearlListVm>>> Get()
        {
            return Ok(await Mediator.Send(new GetPearlListsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PearlListVm>> Get(Guid id)
        {
            return Ok(await Mediator.Send(new GetPearlListByIdQuery { ListId = id }));
        }
    }
}