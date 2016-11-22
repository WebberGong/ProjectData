using System.Collections.Generic;
using System.Data;
using ProjectData.Entity;
using ProjectData.Persistence;

namespace ProjectData.DomainModel
{
    public class ProjectDataDomainModel
    {
        private static ProjectDataDomainModel _instance;
        private static readonly object SyncObj = new object();
        private readonly ProjectDataDaoService _daoService = new ProjectDataDaoService();

        private ProjectDataDomainModel()
        {
        }

        public static ProjectDataDomainModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncObj)
                    {
                        if (_instance == null)
                        {
                            _instance = new ProjectDataDomainModel();
                        }
                    }
                }
                return _instance;
            }
        }

        public IList<DbData> GetDbData(bool isAutoQuery, string startTime, string endTime, int pageNumber, int pageSize)
        {
            return _daoService.GetDbData(isAutoQuery, startTime, endTime, pageNumber, pageSize);
        }

        public DataTable GetDbDataForDataTable(bool isAutoQuery, string startTime, string endTime, int pageNumber,
            int pageSize)
        {
            return _daoService.GetDbDataForDataTable(isAutoQuery, startTime, endTime, pageNumber, pageSize);
        }

        public int GetDbDataCount(bool isAutoQuery, string startTime, string endTime)
        {
            return _daoService.GetDbDataCount(isAutoQuery, startTime, endTime);
        }

        public object InsertDbData(DbData data)
        {
            return _daoService.InsertDbData(data);
        }

        public object InsertDbSms(DbSms data)
        {
            return _daoService.InsertDbSms(data);
        }
    }
}