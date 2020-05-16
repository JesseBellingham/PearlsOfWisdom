using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PearlsOfWisdom.Application.PearlLists.Queries.GetPearls;

namespace PearlsOfWisdom.WebUI.Controllers
{
    public class PearlsListController : ApiController
    {
        public PearlsListController(IMediator mediator) : base(mediator)
        {
        }
        
        [HttpGet]
        public async Task<ActionResult<PearlsVm>> Get()
        {
            return await Mediator.Send(new GetPearlsQuery());
        }
    }
}