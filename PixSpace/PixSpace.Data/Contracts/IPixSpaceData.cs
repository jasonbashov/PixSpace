namespace PixSpace.Data.Contracts
{
    using PixSpace.Data.Models;

    interface IPixSpaceData
    {
        IRepository<ApplicationUser> Users { get; }

        IRepository<PixImage> PixImages { get; }

        IRepository<Bucket> Buckets { get; }

        IApplicationDbContext Context { get; }

        int SaveChanges();
    }
}
