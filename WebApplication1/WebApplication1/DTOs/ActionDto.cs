using WebApplication1.Models;

namespace WebApplication1.DTOs;

public class ActionDto
{
    public int IdAction { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public bool NeedSpecialEquipment { get; set; }
    public ICollection<Firefighter> Firefighters { get; set; }
}