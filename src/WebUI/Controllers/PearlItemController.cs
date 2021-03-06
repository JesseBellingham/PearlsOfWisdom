﻿using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PearlsOfWisdom.Application.PearlItems.Commands.CreatePearlItem;
using PearlsOfWisdom.WebUI.Pages;

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
            return Ok(await Mediator.Send(command));
        }
    }
}