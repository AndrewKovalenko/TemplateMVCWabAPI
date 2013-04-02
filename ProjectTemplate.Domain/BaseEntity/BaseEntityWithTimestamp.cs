using System;

namespace ProjectTemplate.Domain.BaseEntity
{
    public abstract class BaseEntityWithTimestamps<T> : BaseEntity<T> where T : struct 
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}