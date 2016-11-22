using ProjectData.Entity;
using ProjectData.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectData.DomainModel
{
    public class ProjectDataDomainModel
    {
        private static ProjectDataDomainModel instance;
        private static object syncObj = new object();
        private ProjectDataDaoService daoService = new ProjectDataDaoService();

        private ProjectDataDomainModel()
        {
        }

        public static ProjectDataDomainModel Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncObj)
                    {
                        if (instance == null)
                        {
                            instance = new ProjectDataDomainModel();
                        }
                    }
                }
                return instance;
            }
        }

        public IList<DbData> GetDbData(bool isAutoQuery, string startTime, string endTime, int pageNumber, int pageSize)
        {
            return daoService.GetDbData(isAutoQuery, startTime, endTime, pageNumber, pageSize);
        }

        public DataTable GetDbDataForDataTable(bool isAutoQuery, string startTime, string endTime, int pageNumber, int pageSize)
        {
            return daoService.GetDbDataForDataTable(isAutoQuery, startTime, endTime, pageNumber, pageSize);
        }

        public int GetDbDataCount(bool isAutoQuery, string startTime, string endTime)
        {
            return daoService.GetDbDataCount(isAutoQuery, startTime, endTime);
        }

        public object InsertDbData(DbData data)
        {
            return daoService.InsertDbData(data);
        }

        public object InsertDbSms(DbSms data)
        {
            return daoService.InsertDbSms(data);
        }
    }
}
