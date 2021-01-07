using Membership.ViewModel.Common;
using Membership.ViewModel.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership.Service.interfaces
{
    public interface IRoleService
    {
        Task<ResponseResult<List<RoleVm>>> GetAll();
        Task<ResponseResult<bool>> Create(RoleCreateRequest request);
        Task<ResponseResult<bool>> Update(RoleUpdateRequest request);
        Task<ResponseResult<bool>> Delete(Guid id);
    }
}
