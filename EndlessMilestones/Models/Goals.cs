using System;
using System.ComponentModel.DataAnnotations;

namespace EndlessMilestones.Models
{
    public class Goals
    {
        [Key]
        public int goals_id { get; set; }
        public string goal_title { get; set; }
        public string goal_desc { get; set; }
        public DateTime deadline { get; set; }
        public bool completed { get; set; }
        public int method_id { get; set; }
    }
}

