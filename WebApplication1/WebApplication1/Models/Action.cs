using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class Action
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdAction { get; set; }

    [Required] public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    [Required] public bool NeedSpecialEquipment { get; set; }
}