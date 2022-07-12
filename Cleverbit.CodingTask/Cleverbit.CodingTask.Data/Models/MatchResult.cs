using System;
using System.Collections.Generic;
using System.Text;

namespace Cleverbit.CodingTask.Data.Models
{
    public class MatchResult
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public string Winner { get; set; }
        public int UserId { get; set; }

        public Match Match { get; set; }
        public User User { get; set; }
    }
}
