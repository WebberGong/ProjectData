using ProjectData.Entity;
using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectData.Data
{
    public class InsertDbSmsRequest : DbSms
    {
        public InsertDbSmsRequest(DbSms dbSms)
        {
            this.Time = dbSms.Time;
            this.IsAlarm = dbSms.IsAlarm;
            this.AlarmContent = dbSms.AlarmContent;
        }
    }
}
