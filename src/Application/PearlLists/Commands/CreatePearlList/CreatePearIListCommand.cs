using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PearlsOfWisdom.Application.Common.Interfaces;
using PearlsOfWisdom.Domain.Entities;

namespace PearlsOfWisdom.Application.PearlLists.Commands.CreatePearlList
{
    public class CreatePearlListCommand : IRequest<Guid>
    {
        public Guid ListId { get; set; }

        public string Title { get; set; }
    }

    public class CreatePearlListCommandHandler : IRequestHandler<CreatePearlListCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreatePearlListCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreatePearlListCommand request, CancellationToken cancellationToken)
        {
            var entity = new PearlList
            {
                Title = request.Title,
            };

            await _context.PearlLists.AddAsync(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}