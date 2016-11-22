using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectData.UI;
using ProjectData.UI.Controllers;
using ProjectData.Client;
using ProjectData.Entity;

namespace ProjectData.UI.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Index() as ViewResult;

            ProjectDataClient client = new ProjectDataClient();
            object obj = client.InsertDbSms("http://localhost:47921/api/", new DbSms() { Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), IsAlarm = true, AlarmContent = "Test-" + new Random().Next(0, 9999).ToString().PadLeft(4, '0') });
        }
    }
}
