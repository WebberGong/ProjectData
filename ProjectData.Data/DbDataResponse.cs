using System.Collections.Generic;
using ProjectData.Entity;

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