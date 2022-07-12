using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cleverbit.CodingTask.Data.Models
{
    public class Match
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }        
        public DateTime ExpiryDate { get; set; }
    }
}
