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
using Hackathon.Boilerplate.Foundation.DependencyInjection;
using Hackathon.Boilerplate.Foundation.Search.Models;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.Linq.Utilities;

namespace Hackathon.Boilerplate.Feature.Account.Repositories
{
    [Service(typeof(ISearchRepository))]
    public class SearchRepository : ISearchRepository
    {
        public SearchResultResponse GetAccounts(SearchFilter filter)
        {
            var searchIndex = Sitecore.ContentSearch.ContentSearchManager.GetIndex("sitecore_web_index");
            if (searchIndex != null)
            {
                using (var searchContext = searchIndex.CreateSearchContext())
                {
                    IQueryable<SearchResultItem> searchQuery = searchContext.GetQueryable<SearchResultItem>();
                    var queryBuilder = PredicateBuilder.True<SearchResultItem>();
                    queryBuilder = queryBuilder.And(x => x.Language == Sitecore.Context.Language.Name);

                    if (filter.IncludedTemplateList.Any())
                    {
                        var includedTemplateBuilder = PredicateBuilder.False<SearchResultItem>();
                        foreach (var template in filter.IncludedTemplateList)
                        {
                            includedTemplateBuilder =
                                includedTemplateBuilder.Or(x => x.TemplateId.ToString().Equals(template));
                        }
                        queryBuilder = queryBuilder.And(includedTemplateBuilder);
                    }

                    if (filter.ExcludedTemplateList.Any())
                    {
                        var excludedTemplateBuilder = PredicateBuilder.True<SearchResultItem>();
                        foreach (var template in filter.ExcludedTemplateList)
                        {
                            excludedTemplateBuilder =
                                excludedTemplateBuilder.And(x => x.TemplateId.ToString().Equals(template));
                        }
                        queryBuilder = queryBuilder.And(excludedTemplateBuilder);
                    }

                    if (filter.IncludedIdList.Any())
                    {
                        var includedIdBuilder = PredicateBuilder.False<SearchResultItem>();
                        foreach (var id in filter.IncludedIdList)
                        {
                            includedIdBuilder = includedIdBuilder.Or(x => x.ItemId.ToString().Equals(id));
                        }
                        queryBuilder = queryBuilder.And(includedIdBuilder);
                    }

                    if (filter.ExcludedIdList.Any())
                    {
                        var excludedIdBuilder = PredicateBuilder.True<SearchResultItem>();
                        foreach (var id in filter.ExcludedIdList)
                        {
                            excludedIdBuilder = excludedIdBuilder.And(x => x.TemplateId.ToString().Equals(id));
                        }
                        queryBuilder = queryBuilder.And(excludedIdBuilder);
                    }

                    if (filter.FieldValueList.Count > 0)
                    {
                        var fieldValueBuilder = PredicateBuilder.True<SearchResultItem>();
                        foreach (var field in filter.FieldValueList)
                        {
                            fieldValueBuilder = fieldValueBuilder.And(x => x[field.Key].Equals(field.Value));
                        }
                        queryBuilder = queryBuilder.And(fieldValueBuilder);
                    }

                    if (filter.ParentIdList.Count > 0)
                    {
                        var parentIdBuilder = PredicateBuilder.True<SearchResultItem>();
                        foreach (var parentId in filter.ParentIdList)
                        {
                            parentIdBuilder = parentIdBuilder.And(x => x.Parent.Guid.ToString().Equals(parentId));
                        }
                        queryBuilder = queryBuilder.And(parentIdBuilder);
                    }

                    if (filter.KeywordList.Count > 0)
                    {
                        var keywordBuilder = PredicateBuilder.True<SearchResultItem>();
                        foreach (var parentId in filter.ParentIdList)
                        {
                            keywordBuilder = keywordBuilder.And(x => x.Content.Contains(parentId));
                        }
                        queryBuilder = queryBuilder.And(keywordBuilder);
                    }

                    searchQuery = searchQuery.Where(queryBuilder);
                    var results = from resultItems in searchQuery select resultItems;

                    return new SearchResultResponse()
                    {
                        TotalResultCount = searchQuery.GetResults().TotalSearchResults,
                        CurrentResults = results.ToList(),
                        CurrentResultCount = results.Count()
                    };
                }
            }
            return new SearchResultResponse();
        }
    }
}