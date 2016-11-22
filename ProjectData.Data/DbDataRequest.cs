using ProjectData.Entity;
using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectData.Data
{
    public class GetDbDataRequest
    {
        public bool IsAutoQuery { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class InsertDbDataRequest : DbData
    {
        public InsertDbDataRequest(DbData dbData)
        {
            this.RiQiShiKe = dbData.RiQiShiKe;
            this.PanHao = dbData.PanHao;
            this.PeiBiHao = dbData.PeiBiHao;
            this.CheHao = dbData.CheHao;
            this.KeHuHao = dbData.KeHuHao;
            this.GuLiao6 = dbData.GuLiao6;
            this.GuLiao5 = dbData.GuLiao5;
            this.GuLiao4 = dbData.GuLiao4;
            this.GuLiao3 = dbData.GuLiao3;
            this.GuLiao2 = dbData.GuLiao2;
            this.GuLiao1 = dbData.GuLiao1;
            this.ShiFen3 = dbData.ShiFen3;
            this.ShiFen2 = dbData.ShiFen2;
            this.ShiFen1 = dbData.ShiFen1;
            this.LiQing = dbData.LiQing;
            this.HeJi = dbData.HeJi;
            this.YiCangWd = dbData.YiCangWd;
            this.HunHeLiaoWd = dbData.HunHeLiaoWd;
            this.ChuChenQiWd = dbData.ChuChenQiWd;
            this.LiQingWd = dbData.LiQingWd;
            this.GuLiaoWd = dbData.GuLiaoWd;
        }
    }
}
