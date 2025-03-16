using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhanceSure.Domain.Interfaces.Common {
    public interface IUnitOfWork: IDisposable {
        Task<int> Commit(CancellationToken cancellationToken);

        Task Rollback();
    }
}
