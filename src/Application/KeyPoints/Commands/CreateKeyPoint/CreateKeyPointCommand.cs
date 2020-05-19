using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PearlsOfWisdom.Application.Common.Interfaces;
using PearlsOfWisdom.Domain.Entities;

namespace PearlsOfWisdom.Application.KeyPoints.Commands.CreateKeyPoint
{
    public class CreateKeyPointCommand : IRequest<Guid>
    {
        public Guid PearlItemId { get; set; }
        public string Text { get; set; }
    }

    public class CreateKeyPointCommandHandler : IRequestHandler<CreateKeyPointCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateKeyPointCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        
        public async Task<Guid> Handle(CreateKeyPointCommand request, CancellationToken cancellationToken)
        {
            var entity = new KeyPoint
            {
                PearlItemId = request.PearlItemId,
                Text = request.Text
            };

            await _context.KeyPoints.AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}