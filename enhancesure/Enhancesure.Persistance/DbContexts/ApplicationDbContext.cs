using EnhanceSure.Domain.Common;
using EnhanceSure.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace EnhanceSure.Persistance.DbContexts {
    public class ApplicationDbContext: DbContext{
        public Guid AnnonimousUserId = new Guid();
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach(var entry in ChangeTracker.Entries<BaseEntity>())
            {
                entry.Entity.LastModifiedAt=DateTime.Now;
                if(entry.State==EntityState.Added)
                {
                    entry.Entity.CreatedAt=DateTime.Now;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        public DbSet<Interviewee> Interviewees { get; set; }
        public DbSet<Interviewer> Intervieweers { get; set; }
        public DbSet<InterviewSchedule> InterviewSchedules { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }

        //for Datatype information see: https://learn.microsoft.com/en-us/sql/t-sql/data-types/data-types-transact-sql?view=sql-server-ver16
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity((EntityTypeBuilder<Interviewee> mappings) =>
            {
                mappings.ToTable(PersistanceConstants.Tables.tblInterviewee);
                mappings.Property(p => p.Id).IsRequired().HasColumnType("uniqueidentifier");
                mappings.Property(p => p.FirstName).HasColumnType("nvarchar").HasMaxLength(10);
                mappings.Property(p => p.MiddleName).HasColumnType("nvarchar").HasMaxLength(10);
                mappings.Property(p => p.LastName).HasColumnType("nvarchar").HasMaxLength(10);
                mappings.Property(p => p.PhoneNumber).HasColumnType("nvarchar").HasMaxLength(10);
                mappings.Property(p => p.Address).HasColumnType("nvarchar").HasMaxLength(100);
                mappings.Property(p => p.EmailAddress).HasColumnType("nvarchar").HasMaxLength(225);
                mappings.Property(p => p.CreatedAt).HasColumnType("datetime2");
                mappings.Property(p => p.CreatedBy).HasColumnType("uniqueidentifier");
                mappings.Property(p => p.LastModifiedAt).HasColumnType("datetime2");
                mappings.Property(p => p.LastModifiedBy).HasColumnType("uniqueidentifier");
            });
        }
    }
}
