using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class FireTruck
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdFireTruck { get; set; }

    [Required] [MaxLength(30)] public string OperationalNumber { get; set; }
    [Required] public bool SpecialEquipment { get; set; }
}