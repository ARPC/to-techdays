using System;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TennisAwesome.Web
{
    public class IndexPageModel: PageModel
    {
        public string PageTitle = "Recent matches";
        
        public MatchSummary[] MatchSummaries;

        public void OnGet()
        {
            MatchSummaryDataProvider _dataProvider = new MatchSummaryDataProvider();
            MatchSummaries = _dataProvider.GetAll();
        }
    }
}