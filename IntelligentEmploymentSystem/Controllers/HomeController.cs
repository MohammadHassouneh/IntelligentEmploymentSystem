using IntelligentEmploymentSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace IntelligentEmploymentSystem.Controllers
{
    public class HomeController : Controller

    {
        DBEntities.IntelligentEmploymentSystemContext context = new DBEntities.IntelligentEmploymentSystemContext();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var jobs = await (from company in context.Companies
                              join job in context.JobDescriptions
                              on company.CompanyId equals job.CompanyId
                              select new Models.JobDescriptionModel
                              {
                                  JobDescriptionId = job.JobDescriptionId,
                                  JobTitle = job.JobTitle,
                                  CompanyName = company.CompanyName,
                                  JobBrief = job.JobBrief,
                              }).ToListAsync();

            return View(jobs);
        }

        public IActionResult Privacy()
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
