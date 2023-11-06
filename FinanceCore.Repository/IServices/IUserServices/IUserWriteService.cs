using FinanceCore.Domain.Entities;
using FinanceCore.Repository.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceCore.Repository.IServices.IUserServices
{
    public interface IUserWriteService:IWriteService<User>
    {
        public Task<User> RemoveUserDeleteAsync(UserDeleteDto userDeleteDto);

        public Task<UserDto> AddUserAsync(UserDto userDto);
    }
}
