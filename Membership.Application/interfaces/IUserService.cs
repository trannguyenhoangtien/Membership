using Membership.ViewModel.Common;
using Membership.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership.Service.interfaces
{
    public interface IUserService
    {
        Task<ResponseResult<UserAuthenticateVm>> Authenticate(LoginRequest request);
        Task<ResponseResult<bool>> Register(RegisterRequest request);
        Task<ResponseResult<bool>> Update(UserUpdateRequest request);
        Task<ResponseResult<PagedResult<UserVm>>> GetUserPaging(GetUserPagingRequest request);
        Task<ResponseResult<UserVm>> GetById(Guid id);
        Task<ResponseResult<bool>> Delete(Guid id);
        Task<ResponseResult<bool>> RoleAssign(RoleAssignRequest request);
    }
}
