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
        Task<bool> CreateProfileAsync(UserDTO profile);

        Task<bool> EditProfileAsync(UserDTO profile, int id);

        Task<RoleDTO> GetRoleByTgLinkAsync(string tglink);

        Task<UserDTO> GetFirstAsync();
    }
}
