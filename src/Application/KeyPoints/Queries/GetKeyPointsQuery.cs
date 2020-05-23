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

namespace PearlsOfWisdom.Application.KeyPoints.Queries
{
    public class GetKeyPointsQuery : IRequest<IList<KeyPointVm>>
    {
        public Guid PearlId { get; set; }
    }

    public class GetKeyPointsQueryHandler : IRequestHandler<GetKeyPointsQuery, IList<KeyPointVm>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetKeyPointsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        
        public async Task<IList<KeyPointVm>> Handle(GetKeyPointsQuery request, CancellationToken cancellationToken)
        {
            return await _context.KeyPoints
                .Where(_ => _.PearlItemId == request.PearlId)
                .OrderByDescending(_ => _.Created)
                .ProjectTo<KeyPointVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}