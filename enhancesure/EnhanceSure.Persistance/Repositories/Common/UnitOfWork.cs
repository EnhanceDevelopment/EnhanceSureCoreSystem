using EnhanceSure.Domain.Interfaces.Common;
using EnhanceSure.Persistance.DbContexts;
using Microsoft.EntityFrameworkCore.Storage;

namespace EnhanceSure.Persistance.Repositories.Common {
    public class UnitOfWork: IUnitOfWork {
        private readonly ApplicationDbContext _dbContext;
        private IDbContextTransaction _transaction;
        private bool _disposed;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext=dbContext??throw new ArgumentNullException(nameof(dbContext));
        }
        public async Task StartTransaction(CancellationToken cancellationToken)
        {
            if(_transaction!=null)
                throw new InvalidOperationException("A transaction is already in progress.");
            _transaction=await _dbContext.Database.BeginTransactionAsync(cancellationToken);
        }
        public async Task<int> Commit(CancellationToken cancellationToken)
        {
            if(_transaction==null)
                return await _dbContext.SaveChangesAsync(cancellationToken);

            try
            {
                var result = await _dbContext.SaveChangesAsync(cancellationToken);
                await _transaction.CommitAsync(cancellationToken);
                return result;
            } catch(Exception ex)
            {
                await Rollback();
                throw ex;
            }

        }

        public async Task Rollback()
        {
            if(_transaction!=null)
            {
                await _transaction.RollbackAsync();
                _transaction.Dispose();
                _transaction=null;
            }
        }
        //public void Rollback()
        //{
        //    foreach(var entry in _dbContext.ChangeTracker.Entries())
        //    {
        //        switch(entry.State)
        //        {
        //            case EntityState.Added:
        //                entry.State=EntityState.Detached;
        //                break;
        //            case EntityState.Modified:
        //            case EntityState.Deleted:
        //                entry.Reload();
        //                break;
        //        }
        //    }
        //    // If explicit database transactions are used, rollback here.
        //    // For EF Core, SaveChangesAsync() handles transaction implicitly
        //    // and an exception will prevent commit.
        //}

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(!_disposed)
            {
                if(disposing)
                {
                    //dispose managed resources
                    _dbContext.Dispose();
                    _transaction?.Dispose();
                }
            }
            //dispose unmanaged resources
            _disposed=true;
        }
    }

}
