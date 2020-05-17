using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PearlsOfWisdom.Application.PearlItems.Commands.CreatePearlItem;

namespace PearlsOfWisdom.WebUI.Controllers
{
    public class PearlItemController : ApiController
    {
        public PearlItemController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreatePearlItemCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}