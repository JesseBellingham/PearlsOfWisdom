using PearlsOfWisdom.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace PearlsOfWisdom.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<PearlList> PearlLists { get; set; }

        DbSet<PearlItem> PearlItems { get; set; }
        
        DbSet<KeyPoint> KeyPoints { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
