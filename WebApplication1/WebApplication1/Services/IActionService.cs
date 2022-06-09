using WebApplication1.DTOs;

namespace WebApplication1.Services;

public interface IActionService
{
    Task<ActionDto> GetAction(int id);
    Task<int> DeleteAction(int id);
}