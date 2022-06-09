using Microsoft.EntityFrameworkCore;
using WebApplication1.Contexts;
using WebApplication1.DTOs;
using WebApplication1.Errors;

namespace WebApplication1.Services;

public class ActionService : IActionService
{
    private readonly AppDbContext _context;

    public ActionService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ActionDto> GetAction(int id)
    {
        if (!await CheckActionExists(id)) throw new NotFoundError("Action(id=" + id + ") not found");

        return await _context.Actions
            .Include(action => action.FirefighterActions)
            .ThenInclude(action => action.Firefighter)
            .Where(action => action.IdAction == id)
            .Select(action => new ActionDto
            {
                IdAction = action.IdAction,
                StartTime = action.StartTime,
                EndTime = action.EndTime,
                NeedSpecialEquipment = action.NeedSpecialEquipment,
                Firefighters = action.FirefighterActions
                    .Select(fAction => fAction.Firefighter)
                    .ToList()
            }).FirstAsync();
    }

    private async Task<bool> CheckActionExists(int id)
    {
        return await _context.Actions.AnyAsync(action => action.IdAction == id);
    }
}