using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PearlsOfWisdom.WebUI.Controllers
{
    [Route("api/[controller]")]
    public class ApiController : ControllerBase
    {
        public ApiController(IMediator mediator)
        {
            Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        protected IMediator Mediator { get; }
    }
}