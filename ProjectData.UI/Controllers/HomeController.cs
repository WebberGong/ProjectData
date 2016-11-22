using System;
using System.IO;
using System.Web.Mvc;
using ProjectData.DomainModel;

namespace ProjectData.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ExportDbData(bool isAutoQuery, string startTime, string endTime, int pageNumber,
            int pageSize)
        {
            var directory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "TempFiles");
            foreach (var info in directory.GetFileSystemInfos())
            {
                if (info.CreationTime < DateTime.Now.AddHours(-1))
                {
                    info.Delete();
                }
            }
            var helper = new CsvHelper();
            var dt = ProjectDataDomainModel.Instance.GetDbDataForDataTable(isAutoQuery, startTime, endTime, pageNumber,
                pageSize);
            var temp = helper.ExportDataToCsv(dt);
            if (string.IsNullOrEmpty(temp))
            {
                Response.Write("无返回结果，请修改查询条件后重试！");
                return new EmptyResult();
            }
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, temp);
            var fileName = Path.GetFileName(filePath);
            return File(filePath, "application/octet-stream", fileName);
        }
    }
}