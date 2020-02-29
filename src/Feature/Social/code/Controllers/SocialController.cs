using Hackathon.Boilerplate.Feature.Social.Repositories;
using Sitecore.XA.Foundation.Mvc.Controllers;
using System.Web.Mvc;

namespace Hackathon.Boilerplate.Feature.Social.Controllers
{
    public class SocialController : StandardController
    {
        private readonly ISocialShareRepository _socialShareRepository;

        public SocialController(ISocialShareRepository socialShareRepository)
        {
            _socialShareRepository = socialShareRepository;
        }

        protected override object GetModel()
        {
            return _socialShareRepository.GetModel();
        }
        public override ActionResult Index()
        {
            return View("~/Views/Feature/Event/SocialShare.cshtml", this.GetModel());
        }
    }
}