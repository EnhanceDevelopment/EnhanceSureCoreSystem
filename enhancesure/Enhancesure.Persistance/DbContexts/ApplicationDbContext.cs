using EnhanceSure.Domain.Common;
using EnhanceSure.Domain.Entities;
using EnhanceSure.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace EnhanceSure.Persistance.DbContexts {
    public class ApplicationDbContext: DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach(var entry in ChangeTracker.Entries<BaseEntity>())
            {
                entry.Entity.LastModifiedAt = DateTime.Now;
                if(entry.State == EntityState.Added)
                    entry.Entity.CreatedAt = DateTime.Now;
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        public DbSet<Interviewee> Interviewees { get; set; }
        public DbSet<Interviewer> Intervieweers { get; set; }
        public DbSet<InterviewSchedule> InterviewSchedules { get; set; }

        //for Datatype information see: https://learn.microsoft.com/en-us/sql/t-sql/data-types/data-types-transact-sql?view=sql-server-ver16
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ////  Type1
            ///// using this way we need not to define the structure of the table that is to be created into database.
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            ////  Type2
            /////  using below type 
            /////- we cannot use the navigation in our code.
            /////- we can define the structure of the table that is to be created into the database.
            /////- need to make type handler to handle the list and foreign keys

            modelBuilder.Entity((EntityTypeBuilder<Interviewee> mappings) =>
            {
                mappings.ToTable(PersistanceConstants.Tables.tblInterviewee);
                mappings.Property(p => p.Id).IsRequired().HasColumnType("uniqueidentifier ");
                mappings.Property(p => p.FirstName).HasColumnType("nvarchar").HasMaxLength(10);
                mappings.Property(p => p.MiddleName).HasColumnType("nvarchar").HasMaxLength(10);
                mappings.Property(p => p.LastName).HasColumnType("nvarchar").HasMaxLength(10);
                mappings.Property(p => p.PhoneNumber).HasColumnType("nvarchar").HasMaxLength(10);
                mappings.Property(p => p.Address).HasColumnType("nvarchar").HasMaxLength(100);
                mappings.Property(p => p.CreatedAt).HasColumnType("datetime2");
                mappings.Property(p => p.CreatedBy).HasColumnType("uniqueidentifier ");
                mappings.Property(p => p.EmailAddress).HasColumnType("uniqueidentifier ");
                mappings.Property(p => p.LastModifiedAt).HasColumnType("datetime2");
                mappings.Property(p => p.LastModifiedBy).HasColumnType("uniqueidentifier ");
            });
            modelBuilder.Entity((EntityTypeBuilder<Interviewer> mappings) =>
            {
                mappings.ToTable(PersistanceConstants.Tables.tblInterviewer);
                mappings.Property(p => p.Id).IsRequired().HasColumnType("uniqueidentifier ");
                mappings.Property(p => p.FirstName).HasColumnType("nvarchar").HasMaxLength(10);
                mappings.Property(p => p.MiddleName).HasColumnType("nvarchar").HasMaxLength(10);
                mappings.Property(p => p.LastName).HasColumnType("nvarchar").HasMaxLength(10);
                mappings.Property(p => p.PhoneNumber).HasColumnType("nvarchar").HasMaxLength(10);
                mappings.Property(p => p.Address).HasColumnType("nvarchar").HasMaxLength(100);
                mappings.Property(p => p.CreatedAt).HasColumnType("datetime2");
                mappings.Property(p => p.CreatedBy).HasColumnType("uniqueidentifier ");
                mappings.Property(p => p.EmailAddress).HasColumnType("uniqueidentifier ");
                mappings.Property(p => p.LastModifiedAt).HasColumnType("datetime2");
                mappings.Property(p => p.LastModifiedBy).HasColumnType("uniqueidentifier ");
            });
            modelBuilder.Entity((EntityTypeBuilder<InterviewSchedule> mappings) =>
            {
                mappings.ToTable(PersistanceConstants.Tables.tblInterviewSchedule);
                mappings.Property(p => p.Id).IsRequired().HasColumnType("uniqueidentifier ");
                mappings.Property(p => p.Interviewer).HasColumnType("uniqueidentifier ");
                mappings.Property(p => p.Interviewee).HasColumnType("uniqueidentifier ");
                mappings.Property(p => p.InterviewDateTime).HasColumnType("datetime2");
                mappings.Property(p => p.Status).HasColumnType("int").HasMaxLength(2);
                mappings.Property(p => p.IsDeleted).HasColumnType("bit");
                mappings.Property(p => p.CreatedAt).HasColumnType("datetime2");
                mappings.Property(p => p.CreatedBy).HasColumnType("uniqueidentifier ");
                mappings.Property(p => p.LastModifiedAt).HasColumnType("datetime2");
                mappings.Property(p => p.LastModifiedBy).HasColumnType("uniqueidentifier ");

            });
        }
    }
}
