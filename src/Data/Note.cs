﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Data
{
    public record Note 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [IgnoreDataMember]
        public DateTime CreationDate { get; set; }

        [IgnoreDataMember]
        public DateTime? UpdateTime { get; set; }

        [MinLength(1)]
        [MaxLength(1000)]
        public required string Content { get; set; }

        [MinLength(1)]
        [MaxLength(1000)]
        public required string Title { get; set; }
    }
}