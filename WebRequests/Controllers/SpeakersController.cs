using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebRequests.Models;

namespace WebRequests.Controllers
{
    public class SpeakersController : Controller
    {

        public ActionResult GetSpeakers()
        {
            string responseFromServer;
            WebRequest request = WebRequest.Create("https://localhost:44337/api/Speakers/");    // Create a request for the URL.
            request.Credentials = CredentialCache.DefaultCredentials;           // If required by the server, set the credentials. 

            WebResponse response = request.GetResponse();                       // Get the response.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);   // Display the status.

            using (Stream dataStream = response.GetResponseStream())            // Get the stream containing content returned by the server.
            {                                                                   // The using block ensures the stream is automatically closed.
                StreamReader reader = new StreamReader(dataStream);             // Open the stream using a StreamReader for easy access.
                responseFromServer = reader.ReadToEnd();                 // Read the content.
            }

            response.Close(); // Close the response.

            //Console.WriteLine(responseFromServer);   // Display the content.

            return View(responseFromServer);

        }
















        // POST: SpeakersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostRequest(string uri, Speaker postParameters)
        {
            string postData = JsonConvert.SerializeObject(postParameters);
            byte[] bytes = Encoding.UTF8.GetBytes(postData);
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentLength = bytes.Length;
            httpWebRequest.ContentType = "application/json";
            using (Stream requestStream = httpWebRequest.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Count());
            }
            var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            Console.WriteLine(httpWebResponse);

            return View();
        }










        // GET: SpeakersController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SpeakersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SpeakersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SpeakersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SpeakersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SpeakersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SpeakersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SpeakersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
