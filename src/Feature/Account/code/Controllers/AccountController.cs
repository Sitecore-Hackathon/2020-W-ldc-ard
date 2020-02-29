using Sitecore.XA.Foundation.Mvc.Controllers;
using System.Web.Mvc;
using Hackathon.Boilerplate.Feature.Account.Models;
using Hackathon.Boilerplate.Feature.Account.Repositories;
using Sitecore.Mvc.Presentation;

namespace Hackathon.Boilerplate.Feature.Account.Controllers
{
    public class AccountController : StandardController
    {
        private IAccountRepository _accountRepository;
        private ISearchRepository _searchRepository;



        public AccountController(IAccountRepository accountRepository, ISearchRepository searchRepository)
        {
            this._accountRepository = accountRepository;
            this._searchRepository = searchRepository;
        }

        public ActionResult AccountList()
        {
            var currentItem = RenderingContext.Current.Rendering.Item ?? Sitecore.Context.Item;
            if (currentItem != null)
            {
                var listType = RenderingContext.Current.Rendering.Parameters["Full"] == "1";
                var viewPath = listType ? "~/Views/Account/AccountList.cshtml" : "~/Views/Account/AccountListMini.cshtml";
                var viewListType = listType ? AccountListType.Full : AccountListType.Mini;
                var accountContext = RenderingContext.Current.Rendering.Parameters["Context"];

                switch (currentItem.TemplateName)
                {
                    case "Account":
                        return View(viewPath, _accountRepository.GetAccounts(viewListType, AccountContext.Account, _searchRepository));
                    case "UserGroup":
                        return View(viewPath, _accountRepository.GetAccounts(viewListType, AccountContext.UserGroup, _searchRepository));
                    case "Event":
                        return View(viewPath, _accountRepository.GetAccounts(viewListType, AccountContext.Event, _searchRepository));
                }
            }
            return new EmptyResult();
        }
    }
}
