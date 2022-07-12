using System;
using System.Collections.Generic;
using System.Text;

namespace Cleverbit.CodingTask.Data.Models
{
    public class MatchEntry
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int UserId { get; set; } 
        public string UserName { get; set; }
        public int Score { get; set; }

        public Match Match { get; set; }
        public User User { get; set; }
    }
}
