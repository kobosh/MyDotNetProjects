using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MessageBoards.Services;
namespace MessageBoards.Controllers
{
    public class HomeController : Controller
    {
        
        public HomeController(IMailService mail,MessageBoards.Data.IMessageBoardRepository repo)
        {
            _mail=mail;
            _repo = repo;
        }

        public HomeController()
        {
            // TODO: Complete member initialization
        }
        public ActionResult Index()

        {
            var topics = _repo.GetTopics().OrderByDescending(p => p.Created).Take(25).ToList ();
                
            return View(topics);
        }
        [Authorize]
        public ActionResult Messages()
        {
            return View();
        }
        public ActionResult Test()
        {


            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Contact(ContactModel model)
        {
            var msg = string.Format("Comment from:{1}{0}Email:{2}{0}Website:{3}{0}Comment:{4}{0}",
                Environment.NewLine,
                model.Name,
                model.Email,
                model.Website,
            model.Comment);

           // var svc = new Services.MailService();
            if (_mail.SendMail("noreply@dmn.com", "his@hisdmn.com", "website contact ", msg))
            { ViewBag.MailSent = true; }
            return View();
        }
    
public  IMailService _mail { get; set; }
public Data.IMessageBoardRepository _repo { get; set; }


    }
}