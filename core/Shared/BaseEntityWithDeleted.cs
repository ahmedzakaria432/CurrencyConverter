

namespace Core.Shared;

    public abstract class BaseEntityWithDeleted:BaseEntity
    {
        
        public bool IsDeleted { get; set; }

    }

