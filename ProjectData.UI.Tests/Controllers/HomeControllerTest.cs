using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectData.Client;
using ProjectData.Entity;
using ProjectData.UI.Controllers;

namespace ProjectData.UI.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            var controller = new HomeController();
            var result = controller.Index() as ViewResult;

            var client = new ProjectDataClient();
            var obj = client.InsertDbSms("http://localhost:47921/api/",
                new DbSms
                {
                    Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    IsAlarm = true,
                    AlarmContent = "Test-" + new Random().Next(0, 9999).ToString().PadLeft(4, '0')
                });
        }
    }
}