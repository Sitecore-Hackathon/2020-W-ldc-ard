using Hackathon.Boilerplate.Feature.Social.Models;
using Sitecore.Mvc.Presentation;
using Sitecore.XA.Foundation.Mvc.Repositories.Base;
using Sitecore.XA.Foundation.RenderingVariants.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;
using Hackathon.Boilerplate.Foundation.DependencyInjection;

namespace Hackathon.Boilerplate.Feature.Social.Repositories
{
    [Service(typeof(ISocialShareRepository))]
    public class SocialShareRepository : VariantsRepository, ISocialShareRepository
    {
        public override IRenderingModelBase GetModel()
        {
            ShareIconModel viewModel = new ShareIconModel();
            FillSocialSharePropeties(viewModel);
            FillBaseProperties(viewModel);
            return viewModel;
        }

        public void FillSocialSharePropeties(ShareIconModel model)
        {
            string dataSource = RenderingContext.Current.Rendering.DataSource;
            if(string.IsNullOrEmpty(dataSource))
            {
                Item socialShareItem = Sitecore.Context.Database.GetItem(dataSource);
                if(socialShareItem != null)
                {
                    model.FacebookIcon = socialShareItem["FacebookIcon"];
                    model.TwitterIcon = socialShareItem["TwitterIcon"];
                    model.LinkedinIcon = socialShareItem["Linkedin"];
                }
            }
        }
    }
}