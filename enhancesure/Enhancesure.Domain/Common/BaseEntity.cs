namespace Enhancesure.Domain.Common {
    public abstract class BaseEntity {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public Guid LastModifiedBy { get; set; }
        public void GenerateId()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
