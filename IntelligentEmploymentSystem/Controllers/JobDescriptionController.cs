using IntelligentEmploymentSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace IntelligentEmploymentSystem.Controllers
{
    public class JobDescriptionController : Controller
    {
        DBEntities.IntelligentEmploymentSystemContext context=new DBEntities.IntelligentEmploymentSystemContext();
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult AddJobDescription(Models.JobDescriptionModel jobDescriptionModel)
        {

            int? companyId= HttpContext.Session.GetInt32("CompanyId");
            if (companyId == null)
                return RedirectToAction("Login","Company");

            jobDescriptionModel.CompanyId = companyId.Value;

            

                DBEntities.JobDescription jobDescription = new DBEntities.JobDescription();

                jobDescription.JobTitle = jobDescriptionModel.JobTitle;
                jobDescription.JobBrief = jobDescriptionModel.JobBrief;
                jobDescription.Responsibilities = jobDescriptionModel.Responsibilities;
                jobDescription.Requirements = jobDescriptionModel.Requirements;
                jobDescription.CompanyId = companyId.Value;


                context.JobDescriptions.Add(jobDescription);
                context.SaveChanges();

            

            return RedirectToAction("Profile", "Company");
        }

        public IActionResult GetAllJobDescription()
        {

            var jobsData = (from jobs in context.JobDescriptions
                            join score in context.Scores
                                on jobs.JobDescriptionId equals score.JobDescriptionId
                                into jobScores 
                            from score in jobScores.DefaultIfEmpty() 
                            select new
                            {
                                jobs.JobTitle,
                                jobs.JobBrief,
                                jobs.Responsibilities,
                                jobs.Requirements,
                                jobs.JobDescriptionId,
                                jobs.CompanyId,
                                CompanyName = jobs.Company.CompanyName,
                                ResumeId = score != null ? score.ResumeId : (int?)null, 
                                JobDescId = jobs.JobDescriptionId
                            }).ToList();


            List<Models.JobDescriptionModel> jobDescriptions = jobsData.Select(j => new Models.JobDescriptionModel
            {
                JobTitle = j.JobTitle,
                JobBrief = j.JobBrief,
                Responsibilities = j.Responsibilities,
                Requirements = j.Requirements,
                JobDescriptionId = j.JobDescriptionId,
                CompanyId = j.CompanyId,
                CompanyName = j.CompanyName,
                Status = RetrunStatus(j.ResumeId, j.JobDescId) 
            }).ToList();

            return View(jobDescriptions);
        }


        public string RetrunStatus(int? resumeId, int jobDescriptionId)
        {

            int count = context.Scores.Where(x => x.ResumeId == resumeId && x.JobDescriptionId == jobDescriptionId).Count();

            if (count == 0) { return "Apply Now"; }


            else { return "Applied for job"; }
           

        }


        public IActionResult Remove(int jobId)
        {

            var score = context.Scores.Where(s => s.JobDescriptionId == jobId).ToList();
            context.Scores.RemoveRange(score);
            context.SaveChanges();


            var job = context.JobDescriptions.FirstOrDefault(x => x.JobDescriptionId == jobId);

            context.JobDescriptions.Remove(job);
            context.SaveChanges();



            return RedirectToAction("JobReview", "Company");
        }

    }
}
