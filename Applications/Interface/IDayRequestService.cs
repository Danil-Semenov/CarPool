using Applications.DB.Entities;
using Applications.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Interface
{
    public interface IDayRequestService
    {
        Task<int> CreateDayAsync(DayDTO day);

        Task<DayDTO> GetDayByIdAsync(int id);

        Task<DayDTO> GetDayByUserIdAsync(int userId);

        Task<IEnumerable<DayDTO>> GetAllDayAsync();
    }
}
