using Hackathon.Boilerplate.Feature.Event.Models;
using Sitecore.Data.Fields;
using Sitecore.Mvc.Presentation;
using Sitecore.XA.Foundation.Mvc.Repositories.Base;
using Sitecore.XA.Foundation.RenderingVariants.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;
using Hackathon.Boilerplate.Foundation.DependencyInjection;

namespace Hackathon.Boilerplate.Feature.Event.Repositories
{
    [Service(typeof(IEventRepository))]
    public class EventRepositories : VariantsRepository, IEventRepository
    {
        public override IRenderingModelBase GetModel()
        {
            EventModel eventModel = new EventModel();
            try
            {
                eventModel.EventList = new List<GroupEvent>();
                GetEventList(eventModel);
                FillBaseProperties(eventModel);
            }
            catch(Exception ex)
            {
                Sitecore.Diagnostics.Log.Error(ex.Message.ToString(), this);
            }
            return eventModel;
        }

        public void GetEventList(EventModel eventModel)
        {
            string dataSource = RenderingContext.Current.Rendering.DataSource;
            if(!string.IsNullOrEmpty(dataSource))
            {
                Item userGroupItem = Sitecore.Context.Database.GetItem(dataSource);
                MultilistField selectedEventField = userGroupItem.Fields[EventConstant.GroupEvent];

                if(selectedEventField != null)
                { 
                    Item[] eventItems = selectedEventField.GetItems();
                    if(eventItems != null && eventItems.Length > 0)
                    {
                        foreach (var item in eventItems)
                        {
                            GroupEvent eventItem = new GroupEvent();
                            eventItem.Name = item[EventConstant.EventName];
                            eventItem.Venue = item[EventConstant.EventVenue];
                            DateField dateTimeField = item.Fields[EventConstant.EventDate];
                            eventItem.EventDate = Sitecore.DateUtil.IsoDateToDateTime(dateTimeField.Value);
                            MultilistField photoslist = item.Fields[EventConstant.EventPhotos];
                            Item[] photos = null;
                            if(photoslist != null)
                            {
                                photos = photoslist.GetItems();
                            }
                            eventItem.Photos = GetUrlOfPhotos(photos);
                        }
                    }
                }
            }
        }

        private List<string> GetUrlOfPhotos(Item[] selecteddPhotos)
        {
            List<string> photos = new List<string>();
            foreach(var photo in selecteddPhotos)
            {
                MediaItem media = new MediaItem(photo);
                var theURL = Sitecore.Resources.Media.MediaManager.GetMediaUrl(media);
                string mediaUrl = Sitecore.Resources.Media.HashingUtils.ProtectAssetUrl(theURL);
                photos.Add(mediaUrl);
            }
            return photos;
        }
    }
}