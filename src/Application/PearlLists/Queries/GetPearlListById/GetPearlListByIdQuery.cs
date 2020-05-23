using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PearlsOfWisdom.Application.Common.Interfaces;
using PearlsOfWisdom.Application.PearlLists.Queries.Shared;

namespace PearlsOfWisdom.Application.PearlLists.Queries.GetPearlListById
{
    public class GetPearlListByIdQuery : IRequest<PearlListVm>
    {
        public Guid ListId { get; set; }
    }

    public class GetPearlListByIdQueryHandler : IRequestHandler<GetPearlListByIdQuery, PearlListVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPearlListByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PearlListVm> Handle(GetPearlListByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.PearlLists
                .Where(_ => _.Id == request.ListId)
                .ProjectTo<PearlListVm>(_mapper.ConfigurationProvider)
                .OrderBy(t => t.Title)
                .SingleOrDefaultAsync(cancellationToken);
        }
    }
}
