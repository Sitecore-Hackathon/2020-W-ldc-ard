using System.Web.Mvc;
using Hackathon.Boilerplate.Feature.Event.Repositories;
using Sitecore.XA.Foundation.RenderingVariants.Controllers;

namespace Hackathon.Boilerplate.Feature.Event.Controllers
{
    public class EventController : VariantsController
    {
        protected readonly IEventRepository _eventRepository;

        public EventController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        protected override object GetModel()
        {
            return _eventRepository.GetModel();
        }

        public override ActionResult Index()
        {
            return View("~/Views/Feature/Event/EventList.cshtml", this.GetModel());
        }
    }
}