using IntelligentEmploymentSystem.DBEntities;
using Microsoft.AspNetCore.Mvc;

namespace IntelligentEmploymentSystem.Controllers
{
    public class ScoreController : Controller
    {
        DBEntities.IntelligentEmploymentSystemContext context = new DBEntities.IntelligentEmploymentSystemContext();
        public IActionResult Apply(int jobId)

        {

            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login","User");

            var user = context.Users.FirstOrDefault(u => u.UserId == userId);
            if (user == null) return NotFound();

            var resume = context.Resumes.Where(x => x.UserId == user.UserId).FirstOrDefault();
            if (resume == null)
                return BadRequest("No resume found for the user.");


            DBEntities.Score score = new DBEntities.Score();

            score.JobDescriptionId = jobId;
            score.Score1 = -9999;
            score.ResumeId = resume.ResumeId;

            context.Add(score);
            context.SaveChanges();





            return RedirectToAction("GetAllJobDescription", "JobDescription");
        }
    }
}
