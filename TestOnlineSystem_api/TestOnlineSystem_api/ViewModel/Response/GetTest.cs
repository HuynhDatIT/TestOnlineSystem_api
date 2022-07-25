using System;
using System.Collections.Generic;

namespace Mini_project_API.ViewModel.Response
{
    public class GetTest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime TestDay { get; set; }
        public ulong Minute { get; set; }
        public uint MaxScores { get; set; }
        public IList<GetQuestion> Questions { get; set; }
    }
}
