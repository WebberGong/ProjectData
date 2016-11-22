using ProjectData.DomainModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectData.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ExportDbData(bool isAutoQuery, string startTime, string endTime, int pageNumber, int pageSize)
        {
            DirectoryInfo directory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "TempFiles");
            foreach (FileSystemInfo info in directory.GetFileSystemInfos())
            {
                if (info.CreationTime < DateTime.Now.AddHours(-1))
                {
                    info.Delete();
                }
            }
            CsvHelper helper = new CsvHelper();
            DataTable dt = ProjectDataDomainModel.Instance.GetDbDataForDataTable(isAutoQuery, startTime, endTime, pageNumber, pageSize);
            string temp = helper.ExportDataToCSV(dt);
            if (String.IsNullOrEmpty(temp))
            {
                Response.Write("无返回结果，请修改查询条件后重试！");
                return new EmptyResult();
            }
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, temp);
            string fileName = Path.GetFileName(filePath);
            return File(filePath, "application/octet-stream", fileName);
        }
    }
}
