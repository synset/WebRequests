using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebRequests.Models;
using WebRequests.Models.ViewModels;

namespace WebRequests.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        //GET request
        public ActionResult GetResult()
        {


            string responseFromServer;
            WebRequest request = WebRequest.Create("https://localhost:44315/api/Speakers/");   
            request.Credentials = CredentialCache.DefaultCredentials;          

            WebResponse response = request.GetResponse();                      

            using (Stream dataStream = response.GetResponseStream())            
            {                                                                   
                StreamReader reader = new StreamReader(dataStream);  
                responseFromServer = reader.ReadToEnd();
            }

            var mySpeakerList = JsonConvert.DeserializeObject<List<Speaker>>(responseFromServer);

            response.Close();
            

            return View(mySpeakerList);



        }

        //// POST Request
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult PostResult(string uri, Speaker postParameters)
        //{
        //    string postData = JsonConvert.SerializeObject(postParameters);
        //    byte[] bytes = Encoding.UTF8.GetBytes(postData);
        //    var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
        //    httpWebRequest.Method = "POST";
        //    httpWebRequest.ContentLength = bytes.Length;
        //    httpWebRequest.ContentType = "application/json";
        //    using (Stream requestStream = httpWebRequest.GetRequestStream())
        //    {
        //        requestStream.Write(bytes, 0, bytes.Count());
        //    }
        //    var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        //    Console.WriteLine(httpWebResponse);

        //    return View();
        //}


        //Index
        public IActionResult Index()
        {
            return View();
        }
        //GetRequest Page
        public IActionResult GetRequest()
        {
            return View();
        }
       
        //PostRequest Page
        public IActionResult PostRequest()
        {
            return View();
        }
       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
