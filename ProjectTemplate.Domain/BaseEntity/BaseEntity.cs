using System.ComponentModel.DataAnnotations;

namespace ProjectTemplate.Domain.BaseEntity
{

    public abstract class BaseEntity<T> where T : struct
    {
        [Key]
        [Required]
        public T Id { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as BaseEntity<T>);
        }

        public virtual bool Equals(BaseEntity<T> obj)
        {
            if (obj == null) return false;
            
            return obj.Id.Equals(Id) && obj.GetType() == GetType();
        }

        public abstract override int GetHashCode();
    }
}

