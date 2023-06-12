using Applications.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Interface
{
    public interface IUserRequestService
    {
        Task<long> CreateProfileAsync(UserDTO profile);

        Task<bool> EditProfileAsync(UserDTO profile, long id);

        Task<bool> AddMetroByUserIdAsync(long userid,int metroId);

        Task<bool> DeleteMetroByUserIdAsync(long userid, int metroId);

        Task<RoleDTO> GetRoleByIdAsync(long id);

        Task<UserDTO> GetFirstAsync();
    }
}
