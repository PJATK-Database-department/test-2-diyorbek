using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class Firefighter_Action
{
    [Key] public int IdFirefighter { get; set; }
    [Key] public int IdAction { get; set; }
    [ForeignKey("IdFirefighter")] public virtual Firefighter Firefighter { get; set; }
    [ForeignKey("IdAction")] public virtual Action Action { get; set; }
}