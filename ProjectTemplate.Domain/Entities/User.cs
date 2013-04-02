using System;
using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;
using ProjectTemplate.Domain.BaseEntity;

namespace ProjectTemplate.Domain.Entities
{
    public class User : EntityWithTimestamp
    {
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }

        [Email]
        public string Email { get; set; }

        public string FacebookUid { get; set; }
    }
}