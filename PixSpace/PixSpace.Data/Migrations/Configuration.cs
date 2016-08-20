namespace PixSpace.Data.Migrations
{
    using Models;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PixSpace.Data.ApplicationDbContext>
    {
        public Configuration()
        {

            this.AutomaticMigrationsEnabled = true;

            // TODO: Remove in production
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PixSpace.Data.ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                this.SeedUsers(context);
            }
        }

        private void SeedBuckes(ApplicationDbContext context, ApplicationUser user)
        {
            var publicBucket = new Bucket() { CreatedOn = DateTime.Now, IsPrivate = false, Name = "public bucket" };
            var privateBucket = new Bucket() { CreatedOn = DateTime.Now, IsPrivate = true, Name = "private bucket" };

            context.Buckets.Add(publicBucket);
            context.Buckets.Add(privateBucket);
            user.Buckets.Add(publicBucket);
            user.Buckets.Add(privateBucket);
            context.SaveChanges();
        }

        private void SeedUsers(ApplicationDbContext context)
        {
            var user = new ApplicationUser()
            {
                Email = "kakamara@abv.bg",
                UserName = "kakamara",
                PasswordHash = "AIaND2hZxxnrfssS7c16QGaTRGzw60uHbunGB4DI9N2pOQfwLC93x1bQOTvX2/x3vw==", //123123
                SecurityStamp = "3c8114cf-1e6a-4fcd-929e-908d641559be"
            };
            
            context.Users.Add(user);
            context.SaveChanges();
            
            if (!context.Buckets.Any())
            {
                this.SeedBuckes(context, user);
            }
        }
    }
}
