using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PearlsOfWisdom.Application.Common.Interfaces;
using PearlsOfWisdom.Application.PearlLists.Queries.GetPearls;

namespace PearlsOfWisdom.Application.PearlLists.Queries.GetPearlLists
{
    public class GetPearlListsQuery : IRequest<PearlListsVm>
    {
    }

    public class GetPearlListsQueryHandler : IRequestHandler<GetPearlListsQuery, PearlListsVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPearlListsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PearlListsVm> Handle(GetPearlListsQuery request, CancellationToken cancellationToken)
        {
            return new PearlListsVm
            {
                Lists = await _context.PearlLists
                    .ProjectTo<PearlListDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.Title)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}
