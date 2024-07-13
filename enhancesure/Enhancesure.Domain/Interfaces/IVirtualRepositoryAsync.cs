using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enhancesure.Domain.Interfaces;
public interface IVirtualRepositoryAsync<out T> where T : class {
    IQueryable<T> Entities { get; }
    IQueryable<T> AsQueryable();
}
