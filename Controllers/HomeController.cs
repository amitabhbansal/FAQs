using System.Diagnostics;
using FAQs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace FAQs.Controllers
    {
    public class HomeController : Controller
        {
        private FaqsContext context
            {
            get; set;
            }
        public HomeController (FaqsContext ctx)
            {
                context = ctx;
            }
        [Route("topic/{topic}/category/{category}")]
        [Route("topic/{topic}")]
        [Route("category/{category}")]
        [Route("/")]
        public IActionResult Index (string category, string topic)
            {
            var faqs = context.FAQs.Include(f=>f.Category).Include(f=>f.Topic).OrderBy(f=>f.Question).ToList();
            var cat = context.Category.OrderBy(f => f.Name).ToList();
            var top = context.Topic.OrderBy(f => f.Name).ToList();
            ViewBag.cat = cat;
            ViewBag.top = top;
            if (!string.IsNullOrEmpty(topic))
                {
                faqs=faqs.Where(f=>f.Topic.TopicId == topic).ToList();
                }
            if (!string.IsNullOrEmpty(category))
                {
                faqs = faqs.Where(f => f.Category.CategoryId == category).ToList();
                }
            return View(faqs);
            }
        }
    }
