using Mini_project_API.Enum;
using System;
using System.Collections.Generic;

namespace Mini_project_API.ViewModel.Response
{
    public class GetReportTest
    {
        public string Title { get; set; }
        public DateTime TestDay { get; set; }
        
        public IList<GetAccountReport> AccountReports { get; set; }
    }
}
