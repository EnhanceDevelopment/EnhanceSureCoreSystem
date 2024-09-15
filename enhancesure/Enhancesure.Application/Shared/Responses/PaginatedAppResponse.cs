using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhanceSure.Application.Shared.Responses {
    public class PaginatedAppResponse<T>: AppResponse<T> {

        public class PaginatedWrapper {
            public List<T> Items { get; set; }
            public bool HasNextPage { get; set; }
            public int TotalRecordsCount { get; set; }
        }

        public new PaginatedWrapper Data { get; set; }
    }
}
