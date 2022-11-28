using System;
namespace EndlessMilestones.Models;
using System.ComponentModel.DataAnnotations;


public class methods
{
    [Key]
    public int method_id { get; set; }
    public string method_descp { get; set; }
}

