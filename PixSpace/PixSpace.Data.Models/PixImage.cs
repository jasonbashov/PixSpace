namespace PixSpace.Data.Models
{
    using PixSpace.Data.Common.Contracts;
    using PixSpace.Data.Common.Models;
    using System.ComponentModel.DataAnnotations;
    using System;

    public class PixImage : AuditInfo, IDeletableEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        
        public byte[] Image { get; set; }
        
        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}