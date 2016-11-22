using System.Collections;
using System.Collections.Generic;
using System.Data;
using Boco.Rios.Framework.Persistence;
using ProjectData.Entity;

namespace ProjectData.Persistence
{
    public class ProjectDataDao : BaseSqlMapDao, IProjectDataDao
    {
        public IList<DbData> GetDbData(bool isAutoQuery, string startTime, string endTime, int pageNumber, int pageSize)
        {
            var ht = new Hashtable();
            ht.Add("IsAutoQuery", isAutoQuery);
            ht.Add("StartTime", startTime);
            ht.Add("EndTime", endTime);
            ht.Add("PageNumber", pageNumber);
            ht.Add("PageSize", pageSize);
            return ExecuteQueryForList<DbData>("QueryDbData", ht);
        }

        public DataTable GetDbDataForDataTable(bool isAutoQuery, string startTime, string endTime, int pageNumber,
            int pageSize)
        {
            var ht = new Hashtable();
            ht.Add("IsAutoQuery", isAutoQuery);
            ht.Add("StartTime", startTime);
            ht.Add("EndTime", endTime);
            ht.Add("PageNumber", pageNumber);
            ht.Add("PageSize", pageSize);
            return ExecuteQueryForDataTable("QueryDbData", ht);
        }

        public int GetDbDataCount(bool isAutoQuery, string startTime, string endTime)
        {
            var ht = new Hashtable();
            ht.Add("IsAutoQuery", isAutoQuery);
            ht.Add("StartTime", startTime);
            ht.Add("EndTime", endTime);
            var dt = ExecuteQueryForDataTable("QueryDbDataCount", ht);
            if (dt.Rows.Count > 0)
            {
                return int.Parse(dt.Rows[0][0].ToString());
            }
            return 0;
        }

        public object InsertDbData(DbData data)
        {
            return ExecuteInsert("InsertDbData", data);
        }

        public object InsertDbSms(DbSms data)
        {
            return ExecuteInsert("InsertDbSms", data);
        }
    }
}