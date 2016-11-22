using ProjectData.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectData.Persistence
{
    public interface IProjectDataDao
    {
        IList<DbData> GetDbData(bool isAutoQuery, string startTime, string endTime, int pageNumber, int pageSize);

        DataTable GetDbDataForDataTable(bool isAutoQuery, string startTime, string endTime, int pageNumber, int pageSize);

        int GetDbDataCount(bool isAutoQuery, string startTime, string endTime);

        object InsertDbData(DbData data);

        object InsertDbSms(DbSms data);
    }
}
