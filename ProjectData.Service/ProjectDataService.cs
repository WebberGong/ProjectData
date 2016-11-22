using ProjectData.Data;
using ProjectData.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectData.Service
{
    public class ProjectDataService : ServiceStack.ServiceInterface.Service
    {
        public GetDbDataResponse Any(GetDbDataRequest request)
        {
            var result = ProjectDataDomainModel.Instance.GetDbData(request.IsAutoQuery, request.StartTime, request.EndTime, request.PageNumber, request.PageSize);
            var count = ProjectDataDomainModel.Instance.GetDbDataCount(request.IsAutoQuery, request.StartTime, request.EndTime);
            return new GetDbDataResponse() { Data = result, TotalCount = count };
        }

        public object Any(InsertDbDataRequest request)
        {
            return ProjectDataDomainModel.Instance.InsertDbData(request);
        }

        public object Any(InsertDbSmsRequest request)
        {
            return ProjectDataDomainModel.Instance.InsertDbSms(request);
        }
    }
}
