﻿using Hackathon.Boilerplate.Feature.Social.Repositories;
using Sitecore.XA.Foundation.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            return View("", this.GetModel());
        }
    }
}