namespace PixSpace.Data
{
    using PixSpace.Data.Contracts;
    using System;
    using System.Collections.Generic;
    using PixSpace.Data.Models;
    using Repository;
    using Common.Contracts;

    public class PixSpaceData : IPixSpaceData
    {
        private IApplicationDbContext context;
        private IDictionary<Type, object> repositories;

        public PixSpaceData(IApplicationDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetDeletableEntityRepository<ApplicationUser>();
            }
        }
        
        public IRepository<PixImage> PixImages
        {
            get
            {
                return this.GetDeletableEntityRepository<PixImage>();
            }
        }

        public IRepository<Bucket> Buckets
        {
            get
            {
                return this.GetDeletableEntityRepository<Bucket>();
            }
        }

        public IApplicationDbContext Context
        {
            get
            {
                return this.context;
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.context != null)
                {
                    this.context.Dispose();
                }
            }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }

        private IDeletableEntityRepository<T> GetDeletableEntityRepository<T>() where T : class, IDeletableEntity
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(DeletableEntityRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IDeletableEntityRepository<T>)this.repositories[typeof(T)];
        }
    }
}
