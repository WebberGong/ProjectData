using ProjectData.Entity;

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
            RiQiShiKe = dbData.RiQiShiKe;
            PanHao = dbData.PanHao;
            PeiBiHao = dbData.PeiBiHao;
            CheHao = dbData.CheHao;
            KeHuHao = dbData.KeHuHao;
            GuLiao6 = dbData.GuLiao6;
            GuLiao5 = dbData.GuLiao5;
            GuLiao4 = dbData.GuLiao4;
            GuLiao3 = dbData.GuLiao3;
            GuLiao2 = dbData.GuLiao2;
            GuLiao1 = dbData.GuLiao1;
            ShiFen3 = dbData.ShiFen3;
            ShiFen2 = dbData.ShiFen2;
            ShiFen1 = dbData.ShiFen1;
            LiQing = dbData.LiQing;
            HeJi = dbData.HeJi;
            YiCangWd = dbData.YiCangWd;
            HunHeLiaoWd = dbData.HunHeLiaoWd;
            ChuChenQiWd = dbData.ChuChenQiWd;
            LiQingWd = dbData.LiQingWd;
            GuLiaoWd = dbData.GuLiaoWd;
        }
    }
}