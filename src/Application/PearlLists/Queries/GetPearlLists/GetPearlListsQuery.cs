using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PearlsOfWisdom.Application.Common.Interfaces;
using PearlsOfWisdom.Application.PearlLists.Queries.Shared;

namespace PearlsOfWisdom.Application.PearlLists.Queries.GetPearlLists
{
    public class GetPearlListsQuery : IRequest<IList<PearlListVm>>
    {
    }

    public class GetPearlListsQueryHandler : IRequestHandler<GetPearlListsQuery, IList<PearlListVm>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPearlListsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<PearlListVm>> Handle(GetPearlListsQuery request, CancellationToken cancellationToken)
        {
            return await _context.PearlLists
                .ProjectTo<PearlListVm>(_mapper.ConfigurationProvider)
                .OrderBy(t => t.Title)
                .ToListAsync(cancellationToken);
        }
    }
}
