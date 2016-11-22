using ProjectData.Entity;

namespace ProjectData.Data
{
    public class InsertDbSmsRequest : DbSms
    {
        public InsertDbSmsRequest(DbSms dbSms)
        {
            Time = dbSms.Time;
            IsAlarm = dbSms.IsAlarm;
            AlarmContent = dbSms.AlarmContent;
        }
    }
}