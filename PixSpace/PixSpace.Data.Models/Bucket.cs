namespace PixSpace.Data.Models
{
    using PixSpace.Data.Common.Contracts;
    using PixSpace.Data.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Bucket : AuditInfo, IDeletableEntity
    {
        public Bucket()
        {
            this.PixImages = new HashSet<PixImage>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsPrivate { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<PixImage> PixImages { get; set; }
    }
}
