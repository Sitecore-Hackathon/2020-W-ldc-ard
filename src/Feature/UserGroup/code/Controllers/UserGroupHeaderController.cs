using Hackathon.Boilerplate.Feature.UserGroup.Repositories;
using Sitecore.XA.Foundation.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hackathon.Boilerplate.Feature.UserGroup.Controllers
{
    public class UserGroupHeaderController : StandardController
    {
        private readonly IUserGroupHeaderRepository _userGroupHeaderRepository;
        
        public UserGroupHeaderController(IUserGroupHeaderRepository userGroupHeaderRepository)
        {
            _userGroupHeaderRepository = userGroupHeaderRepository;
        }

        protected override object GetModel()
        {
            return _userGroupHeaderRepository.GetModel();
        }
        public  override ActionResult Index()
        {
            return View("~/Views/Feature/Event/UserGroupHeader.cshtml", this.GetModel());
        }
    }
}