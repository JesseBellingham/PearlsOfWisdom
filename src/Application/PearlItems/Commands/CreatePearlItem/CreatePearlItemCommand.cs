using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PearlsOfWisdom.Application.Common.Interfaces;
using PearlsOfWisdom.Domain.Entities;

namespace PearlsOfWisdom.Application.PearlItems.Commands.CreatePearlItem
{
    public class CreatePearlItemCommand : IRequest<Guid>
    {
        public Guid ListId { get; set; }

        public string Title { get; set; }
        
        public string Transcription { get; set; }
        
        public string Author { get; set; }
    }

    public class CreatePearlItemCommandHandler : IRequestHandler<CreatePearlItemCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreatePearlItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreatePearlItemCommand request, CancellationToken cancellationToken)
        {
            var entity = new PearlItem
            {
                ListId = request.ListId,
                Title = request.Title,
                Transcription = request.Transcription,
                Author = request.Author,
                Done = false
            };

            await _context.PearlItems.AddAsync(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}