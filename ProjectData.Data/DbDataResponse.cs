using ProjectData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectData.Data
{
    public class GetDbDataResponse : CollectionResultResponse<DbData>
    {
    }

    public class CollectionResultResponse<T>
    {
        public IList<T> Data { get; set; }
        public int TotalCount { get; set; }
    }
}
