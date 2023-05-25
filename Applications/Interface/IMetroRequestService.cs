using Applications.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Interface
{
    public interface IMetroRequestService
    {
        Task<int> CreateMetroAsync(string name);

        Task<MetroDTO> GetMetroByIdAsync(int id);

        Task<MetroDTO> GetMetroByNameAsync(string name);

        Task<IEnumerable<MetroDTO>> GetAllMetroAsync();
    }
}
