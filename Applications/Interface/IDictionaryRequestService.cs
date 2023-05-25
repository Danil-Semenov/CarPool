using Applications.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Interface
{
    public interface IDictionaryRequestService
    {
        Task<IEnumerable<DestinationDTO>> GetAllDestinationAsync();

        Task<IEnumerable<RoleDTO>> GetAllRoleAsync();

        Task<IEnumerable<StatusDTO>> GetAllStatusAsync();

    }
}
