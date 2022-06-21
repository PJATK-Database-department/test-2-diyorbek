using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class Firefighter
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdFirefighter { get; set; }

    [Required] [MaxLength(30)] public string FirstName { get; set; }
    [Required] [MaxLength(30)] public string LastName { get; set; }
}