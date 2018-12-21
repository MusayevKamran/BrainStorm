using BrainStorm.Models;
using BrainStorm.Models.System;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrainStorm.Models.Interface
{
    public interface IUser
    {
        List<BrainStormUser> GetUsers();
        Task<List<BrainStormUser>> GetUsersAsync();

        BrainStormUser GetUsersById(Guid? Id);
        Task<BrainStormUser> GetUsersByIdAsync(Guid? Id);

        BrainStormUser CreateUsers(BrainStormUser BrainStormUser);
        Task<BrainStormUser> CreateUsersAsync(BrainStormUser BrainStormUser);

        BrainStormUser UpdateUsers(Guid? Id, BrainStormUser BrainStormUser);
        Task<BrainStormUser> UpdateUsersAsync(Guid? Id, BrainStormUser BrainStormUser);

        void DeleteUsers(Guid? Id);
        Task<BrainStormUser> DeleteUsersAsync(Guid? Id);

        bool UsersExists(Guid id);
    }
}
