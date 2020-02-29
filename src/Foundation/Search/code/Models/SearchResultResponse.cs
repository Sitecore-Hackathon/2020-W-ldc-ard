using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon.Boilerplate.Foundation.Search.Models
{
    public class SearchResultResponse
    {
        public int TotalResultCount { get; set; }
        public int CurrentResultCount { get; set; }
        public List<SearchResultItem> CurrentResults { get; set; }

        public SearchResultResponse()
        {
            this.CurrentResults = new List<SearchResultItem>();
        }
    }
}