using Sitecore.XA.Foundation.Variants.Abstractions.Models;
using System;
using System.Collections.Generic;

/// <summary>
/// Model for binding the Event list
/// </summary>
namespace Hackathon.Boilerplate.Feature.Event.Models
{
    public class EventModel : VariantsRenderingModel
    {
        public EventModel()
        {
            EventList = new List<GroupEvent>();
        }
        public List<GroupEvent> EventList { get; set; }
       
    }
    public class GroupEvent
    {
        public string Name { get; set; }
        public DateTime EventDate { get; set; }
        public string Venue { get; set; }
        public List<string> Photos { get; set; }
    }
}