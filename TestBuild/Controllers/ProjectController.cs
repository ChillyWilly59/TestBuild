using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TestBuild.Model;
using TestBuild.Models;

namespace TestBuild.Controllers
{
    public class ProjectController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TotalChats()
        {
            try
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "TotalChats.json");
                var chatReport = LoadChatsFromJsonFile(filePath);

                return View(chatReport);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "An error occurred while loading chat data: " + ex.Message;
                return View("Error");
            }
        }

        private static TotalChats LoadChatsFromJsonFile(string filePath)
        {
            if (!System.IO.File.Exists(filePath))
            {
                throw new FileNotFoundException("File not found", filePath);
            }

            string jsonData = System.IO.File.ReadAllText(filePath);

            return JsonConvert.DeserializeObject<TotalChats>(jsonData);
        }
        public ActionResult Duration()
        {
            try
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Duration.json");
                var duration = LoadDurationFromJsonFile(filePath);

                return View(duration);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "An error occurred while loading chat data: " + ex.Message;
                return View("Error");
            }
        }
        private static DurationReport LoadDurationFromJsonFile(string filePath)
        {
            if (!System.IO.File.Exists(filePath))
            {
                throw new FileNotFoundException("File not found", filePath);
            }

            string jsonData = System.IO.File.ReadAllText(filePath);

            return JsonConvert.DeserializeObject<DurationReport>(jsonData);
        }
        public ActionResult Ratings()
        {
            try
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Rating.json");
                var rating = LoadRatingFromJsonFile(filePath);

                return View(rating);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "An error occurred while loading chat data: " + ex.Message;
                return View("Error");
            }
        }
        private static Rating LoadRatingFromJsonFile(string filePath)
        {
            if (!System.IO.File.Exists(filePath))
            {
                throw new FileNotFoundException("File not found", filePath);
            }

            string jsonData = System.IO.File.ReadAllText(filePath);

            return JsonConvert.DeserializeObject<Rating>(jsonData);
        }
        public ActionResult ResponseTime()
        {
            try
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Response.json");
                var responseTime = LoadResponseTimeFromJsonFile(filePath);

                return View(responseTime);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "An error occurred while loading chat data: " + ex.Message;
                return View("Error");
            }
        }
        private static ResponseTime LoadResponseTimeFromJsonFile(string filePath)
        {
            if (!System.IO.File.Exists(filePath))
            {
                throw new FileNotFoundException("File not found", filePath);
            }

            string jsonData = System.IO.File.ReadAllText(filePath);

            return JsonConvert.DeserializeObject<ResponseTime>(jsonData);
        }
        public ActionResult Tags()
        {
            try
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Tags.json");
                List<TagReportViewModel> tagReports = LoadTagsFromJsonFile(filePath);

                return View(tagReports);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "An error occurred while loading chat data: " + ex.ToString();
                return View("Error");
            }
        }

        private static List<TagReportViewModel> LoadTagsFromJsonFile(string filePath)
        {
            if (!System.IO.File.Exists(filePath))
            {
                throw new FileNotFoundException("File not found", filePath);
            }

            string jsonData = System.IO.File.ReadAllText(filePath);
            JObject jsonObject = JObject.Parse(jsonData);

            List<TagReportViewModel> tagReports = new List<TagReportViewModel>();
            foreach (var record in jsonObject["records"].Children())
            {
                string date = ((JProperty)record).Name;
                var tagRecords = record.First.Children()
                    .Select(p => new TagRecord { Tag = ((JProperty)p).Name, Count = (int)((JProperty)p).Value })
                    .ToList();

                TagReportViewModel tagReport = new TagReportViewModel
                {
                    Date = date,
                    TagRecords = tagRecords
                };

                tagReports.Add(tagReport);
            }

            return tagReports;
        }

    }
}
