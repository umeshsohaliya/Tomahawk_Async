using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Tomahawk_Async.Models;

namespace Tomahawk_Async.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private static CancellationTokenSource _tokenSource = null;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //Download
        [HttpGet]
        public IActionResult Index()
        {
            ContentLengthViewModel contentLengthViewModel = new ContentLengthViewModel()
            {
                message = "Click on download to get Content length, Cancel to cancel download operation."
            }
            ;

            return View(contentLengthViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Index(ContentLengthViewModel contentLengthViewModel)
        {
            ModelState.Clear();
            _tokenSource = new CancellationTokenSource();

            List<string> urlList = new List<string>();
            urlList.Add("http://abc.com");
            urlList.Add("http://def.com");
            urlList.Add("http://xyz.com");
            contentLengthViewModel.ContentLength = await GetContentLengthsum(urlList);
            contentLengthViewModel.message = "";
            return View(contentLengthViewModel);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Cancel()
        {
            if (_tokenSource != null)
                _tokenSource.Cancel();
            return Json("Task Cancelled");
        }




        private async Task<int> GetContentLengthsum(List<string> urlList)
        {
            int contentlength = 0;
            try
            {
                foreach (string url in urlList)
                {
                    if (_tokenSource.IsCancellationRequested)
                    {
                        _tokenSource.Token.ThrowIfCancellationRequested();
                        return contentlength;
                    }
                    contentlength += await GetContentLength(url);
                }
                return contentlength;
            }
            catch (Exception ex)
            {
                return contentlength;
            }
        }

        private async Task<int> GetContentLength(string url)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(url);
                string resultContent = await response.Content.ReadAsStringAsync();
                return resultContent.Length;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
