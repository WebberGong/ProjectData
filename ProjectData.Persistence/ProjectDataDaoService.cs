using System.Collections.Generic;
using System.Data;
using Boco.Rios.Framework.Persistence;
using ProjectData.Entity;

namespace ProjectData.Persistence
{
    public class ProjectDataDaoService : DAOServiceBase<IProjectDataDao>
    {
        public IList<DbData> GetDbData(bool isAutoQuery, string startTime, string endTime, int pageNumber, int pageSize)
        {
            return Dao.GetDbData(isAutoQuery, startTime, endTime, pageNumber, pageSize);
        }

        public DataTable GetDbDataForDataTable(bool isAutoQuery, string startTime, string endTime, int pageNumber,
            int pageSize)
        {
            return Dao.GetDbDataForDataTable(isAutoQuery, startTime, endTime, pageNumber, pageSize);
        }

        public int GetDbDataCount(bool isAutoQuery, string startTime, string endTime)
        {
            return Dao.GetDbDataCount(isAutoQuery, startTime, endTime);
        }

        public object InsertDbData(DbData data)
        {
            return Dao.InsertDbData(data);
        }

        public object InsertDbSms(DbSms data)
        {
            return Dao.InsertDbSms(data);
        }
    }
}