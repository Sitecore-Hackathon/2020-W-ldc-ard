using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hackathon.Boilerplate.Feature.Account.Repositories;
using Hackathon.Boilerplate.Foundation.Search.Models;

namespace Hackathon.Boilerplate.Foundation.Search.Service
{
    public class SearchService
    {
        private ISearchRepository _searchRepository;

        public SearchService(ISearchRepository searchRepository)
        {
            this._searchRepository = searchRepository;
        }

        public SearchResultResponse GetSearchResults(SearchFilter filter)
        {
            if (filter != null)
            {
                switch (filter.SearchType)
                {
                    case SearchType.Account:
                        return _searchRepository.GetAccounts(filter);
                }
            }
            return new SearchResultResponse();
        }
    }
}