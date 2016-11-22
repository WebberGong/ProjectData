using System.Collections.Generic;
using ProjectData.Data;
using ProjectData.Entity;
using ServiceStack.ServiceClient.Web;

namespace ProjectData.Client
{
    public class ProjectDataClient
    {
        public IList<DbData> GetDbData(string url, string startTime, string endTime)
        {
            using (var client = new JsonServiceClient(url))
            {
                return client.Send<IList<DbData>>(new GetDbDataRequest {StartTime = startTime, EndTime = endTime});
            }
        }

        public object InsertDbData(string url, DbData data)
        {
            using (var client = new JsonServiceClient(url))
            {
                return client.Send<object>(new InsertDbDataRequest(data));
            }
        }

        public object InsertDbSms(string url, DbSms data)
        {
            using (var client = new JsonServiceClient(url))
            {
                return client.Send<object>(new InsertDbSmsRequest(data));
            }
        }
    }
}