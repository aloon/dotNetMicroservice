// http://msdn.microsoft.com/es-es/library/ee728598(v=vs.98).aspx


using Micromodularized.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Micromodularized.Controllers
{
    public class IndexController : AsyncController 
    {

        public void IndexAsync()
        {

            AsyncManager.OutstandingOperations.Increment(2);
            var client = new WebClient();
            var uri = new Uri("http://localhost:10001/");
            client.DownloadStringCompleted += (sender, e) =>
            {
                AsyncManager.Parameters["nancyData"] = e.Result;
                AsyncManager.OutstandingOperations.Decrement();
            };
            client.DownloadStringAsync(uri);

            var client2 = new WebClient();
            client2.DownloadStringCompleted += (sender, e) =>
            {
                AsyncManager.Parameters["nancyData2"] = e.Result;
                AsyncManager.OutstandingOperations.Decrement();
            };
            client2.DownloadStringAsync(uri);
        }

        public ActionResult IndexCompleted(string nancyData, string nancyData2)
        {
            var externals = new HomeModel()
            {
                ext1 = nancyData,
                ext2 = nancyData2
            };
            return View(externals);
        }
    }
}