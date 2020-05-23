using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PearlsOfWisdom.Application.KeyPoints.Commands.CreateKeyPoint;
using PearlsOfWisdom.Application.KeyPoints.Queries;
using PearlsOfWisdom.Application.PearlLists.Queries.Shared;

namespace PearlsOfWisdom.WebUI.Controllers
{
    public class KeyPointController : ApiController
    {
        public KeyPointController(IMediator mediator) : base(mediator)
        {
        }
        
        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateKeyPointCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        public async Task<ActionResult<IList<KeyPointVm>>> Get(Guid pearlId)
        {
            return Ok(await Mediator.Send(new GetKeyPointsQuery{ PearlId = pearlId }));
        }
    }
}