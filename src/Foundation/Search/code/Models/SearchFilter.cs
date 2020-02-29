using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.ContentSearch;

namespace Hackathon.Boilerplate.Foundation.Search.Models
{
    public class SearchFilter
    {
        public SearchType SearchType { get; set; }
        public List<string> IncludedTemplateList { get; set; }
        public List<string> IncludedIdList { get; set; }
        public List<string> ExcludedTemplateList { get; set; }
        public List<string> ExcludedIdList { get; set; }
        public List<string> ParentIdList { get; set; }
        public List<string> KeywordList { get; set; }
        public Dictionary<string, string> FieldValueList { get; set; }

        public SearchFilter()
        {
            IncludedTemplateList = new List<string>();
            IncludedIdList = new List<string>();
            ExcludedTemplateList = new List<string>();
            ExcludedIdList = new List<string>();
            ParentIdList = new List<string>();
            KeywordList = new List<string>();
            FieldValueList = new Dictionary<string, string>();
        }
    }
}