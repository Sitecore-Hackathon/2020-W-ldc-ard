using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Sitecore.Resources.Media;
using Sitecore.XA.Foundation.Mvc.Repositories.Base;
using Sitecore.XA.Foundation.RenderingVariants.Repositories;
using Sitecore.Data.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hackathon.Boilerplate.Feature.Account.Models;
using Hackathon.Boilerplate.Foundation.DependencyInjection;
using Hackathon.Boilerplate.Foundation.Search.Models;
using Hackathon.Boilerplate.Foundation.Search.Service;

namespace Hackathon.Boilerplate.Feature.Account.Repositories
{
    [Service(typeof(IAccountRepository))]
    public class AccountRepository : VariantsRepository, IAccountRepository
    {
        SearchResultResponse IAccountRepository.GetAccounts(AccountListType type, AccountContext context, ISearchRepository searchRepository)
        {
            var searchService = new SearchService(searchRepository);
            var searchFilter = new SearchFilter()
            {
                SearchType = SearchType.Account,
                IncludedTemplateList = new List<string>(){ "{C575A4FF-AB06-46C1-B78C-70C65DC6374C}" }
            };
            var fieldList = new Dictionary<string, string>();
            switch (context)
            {
                case AccountContext.Event:
                    fieldList.Add("Events", "");
                    searchFilter.FieldValueList = fieldList;
                    return searchService.GetSearchResults(searchFilter);
                case AccountContext.UserGroup:
                    fieldList.Add("Groups", "");
                    searchFilter.FieldValueList = fieldList;
                    return searchService.GetSearchResults(searchFilter);
                case AccountContext.Account:
                    return searchService.GetSearchResults(searchFilter);
            }

            return new SearchResultResponse();
        }
    }
}