using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class FireTruck_Action
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdFireTruckAction { get; set; }

    public int IdFireTruck { get; set; }
    public int IdAction { get; set; }
    [Required] public DateTime AssignmentDate { get; set; }

    [ForeignKey("IdFireTruck")] public virtual FireTruck FireTruck { get; set; }
    [ForeignKey("IdAction")] public virtual Action Action { get; set; }
}