using System;
namespace EndlessMilestones.Models;
using System.ComponentModel.DataAnnotations;


public class Users
{
    [Key]
    public int user_id { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
    public int age { get; set; }
    public int goals_id { get; set; }
}

