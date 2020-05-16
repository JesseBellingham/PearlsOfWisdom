using AutoMapper;
using AutoMapper.QueryableExtensions;
using PearlsOfWisdom.Application.Common.Interfaces;
using PearlsOfWisdom.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PearlsOfWisdom.Application.PearlLists.Queries.GetPearls
{
    public class GetPearlsQuery : IRequest<PearlsVm>
    {
    }

    public class GetPearlsQueryHandler : IRequestHandler<GetPearlsQuery, PearlsVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPearlsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PearlsVm> Handle(GetPearlsQuery request, CancellationToken cancellationToken)
        {
            return new PearlsVm
            {
                Lists = await _context.PearlLists
                    .ProjectTo<PearlListDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.Title)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}
