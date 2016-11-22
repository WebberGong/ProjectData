using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectData.Entity
{
    public class DbSms
    {
        public string Time { get; set; }
        public bool IsAlarm { get; set; }
        public string AlarmContent { get; set; }
    }
}
